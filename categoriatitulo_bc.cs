using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class categoriatitulo_bc : GxSilentTrn, IGxSilentTrn
   {
      public categoriatitulo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public categoriatitulo_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1Q64( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1Q64( ) ;
         standaloneModal( ) ;
         AddRow1Q64( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E111Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z426CategoriaTituloId = A426CategoriaTituloId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_1Q0( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Q64( ) ;
            }
            else
            {
               CheckExtendedTable1Q64( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1Q64( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1Q64( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z427CategoriaTituloNome = A427CategoriaTituloNome;
            Z428CategoriaTituloDescricao = A428CategoriaTituloDescricao;
            Z431CategoriaStatus = A431CategoriaStatus;
         }
         if ( GX_JID == -5 )
         {
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z427CategoriaTituloNome = A427CategoriaTituloNome;
            Z428CategoriaTituloDescricao = A428CategoriaTituloDescricao;
            Z431CategoriaStatus = A431CategoriaStatus;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A431CategoriaStatus) && ( Gx_BScreen == 0 ) )
         {
            A431CategoriaStatus = true;
            n431CategoriaStatus = false;
         }
      }

      protected void Load1Q64( )
      {
         /* Using cursor BC001Q4 */
         pr_default.execute(2, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound64 = 1;
            A427CategoriaTituloNome = BC001Q4_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = BC001Q4_n427CategoriaTituloNome[0];
            A428CategoriaTituloDescricao = BC001Q4_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = BC001Q4_n428CategoriaTituloDescricao[0];
            A431CategoriaStatus = BC001Q4_A431CategoriaStatus[0];
            n431CategoriaStatus = BC001Q4_n431CategoriaStatus[0];
            ZM1Q64( -5) ;
         }
         pr_default.close(2);
         OnLoadActions1Q64( ) ;
      }

      protected void OnLoadActions1Q64( )
      {
      }

      protected void CheckExtendedTable1Q64( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A427CategoriaTituloNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Categoria Titulo Nome", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Categoria Titulo Descricao", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1Q64( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Q64( )
      {
         /* Using cursor BC001Q5 */
         pr_default.execute(3, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound64 = 1;
         }
         else
         {
            RcdFound64 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001Q3 */
         pr_default.execute(1, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Q64( 5) ;
            RcdFound64 = 1;
            A426CategoriaTituloId = BC001Q3_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001Q3_n426CategoriaTituloId[0];
            A427CategoriaTituloNome = BC001Q3_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = BC001Q3_n427CategoriaTituloNome[0];
            A428CategoriaTituloDescricao = BC001Q3_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = BC001Q3_n428CategoriaTituloDescricao[0];
            A431CategoriaStatus = BC001Q3_A431CategoriaStatus[0];
            n431CategoriaStatus = BC001Q3_n431CategoriaStatus[0];
            Z426CategoriaTituloId = A426CategoriaTituloId;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1Q64( ) ;
            if ( AnyError == 1 )
            {
               RcdFound64 = 0;
               InitializeNonKey1Q64( ) ;
            }
            Gx_mode = sMode64;
         }
         else
         {
            RcdFound64 = 0;
            InitializeNonKey1Q64( ) ;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode64;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Q64( ) ;
         if ( RcdFound64 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_1Q0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1Q64( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Q2 */
            pr_default.execute(0, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CategoriaTitulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z427CategoriaTituloNome, BC001Q2_A427CategoriaTituloNome[0]) != 0 ) || ( StringUtil.StrCmp(Z428CategoriaTituloDescricao, BC001Q2_A428CategoriaTituloDescricao[0]) != 0 ) || ( Z431CategoriaStatus != BC001Q2_A431CategoriaStatus[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CategoriaTitulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q64( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q64( 0) ;
            CheckOptimisticConcurrency1Q64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q6 */
                     pr_default.execute(4, new Object[] {n427CategoriaTituloNome, A427CategoriaTituloNome, n428CategoriaTituloDescricao, A428CategoriaTituloDescricao, n431CategoriaStatus, A431CategoriaStatus});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001Q7 */
                     pr_default.execute(5);
                     A426CategoriaTituloId = BC001Q7_A426CategoriaTituloId[0];
                     n426CategoriaTituloId = BC001Q7_n426CategoriaTituloId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("CategoriaTitulo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1Q64( ) ;
            }
            EndLevel1Q64( ) ;
         }
         CloseExtendedTableCursors1Q64( ) ;
      }

      protected void Update1Q64( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Q8 */
                     pr_default.execute(6, new Object[] {n427CategoriaTituloNome, A427CategoriaTituloNome, n428CategoriaTituloDescricao, A428CategoriaTituloDescricao, n431CategoriaStatus, A431CategoriaStatus, n426CategoriaTituloId, A426CategoriaTituloId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("CategoriaTitulo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CategoriaTitulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q64( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1Q64( ) ;
         }
         CloseExtendedTableCursors1Q64( ) ;
      }

      protected void DeferredUpdate1Q64( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q64( ) ;
            AfterConfirm1Q64( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q64( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001Q9 */
                  pr_default.execute(7, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("CategoriaTitulo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode64 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Q64( ) ;
         Gx_mode = sMode64;
      }

      protected void OnDeleteControls1Q64( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001Q10 */
            pr_default.execute(8, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC001Q11 */
            pr_default.execute(9, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1Q64( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1Q64( )
      {
         /* Scan By routine */
         /* Using cursor BC001Q12 */
         pr_default.execute(10, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         RcdFound64 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound64 = 1;
            A426CategoriaTituloId = BC001Q12_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001Q12_n426CategoriaTituloId[0];
            A427CategoriaTituloNome = BC001Q12_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = BC001Q12_n427CategoriaTituloNome[0];
            A428CategoriaTituloDescricao = BC001Q12_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = BC001Q12_n428CategoriaTituloDescricao[0];
            A431CategoriaStatus = BC001Q12_A431CategoriaStatus[0];
            n431CategoriaStatus = BC001Q12_n431CategoriaStatus[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Q64( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound64 = 0;
         ScanKeyLoad1Q64( ) ;
      }

      protected void ScanKeyLoad1Q64( )
      {
         sMode64 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound64 = 1;
            A426CategoriaTituloId = BC001Q12_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001Q12_n426CategoriaTituloId[0];
            A427CategoriaTituloNome = BC001Q12_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = BC001Q12_n427CategoriaTituloNome[0];
            A428CategoriaTituloDescricao = BC001Q12_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = BC001Q12_n428CategoriaTituloDescricao[0];
            A431CategoriaStatus = BC001Q12_A431CategoriaStatus[0];
            n431CategoriaStatus = BC001Q12_n431CategoriaStatus[0];
         }
         Gx_mode = sMode64;
      }

      protected void ScanKeyEnd1Q64( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1Q64( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q64( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q64( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q64( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q64( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q64( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q64( )
      {
      }

      protected void send_integrity_lvl_hashes1Q64( )
      {
      }

      protected void AddRow1Q64( )
      {
         VarsToRow64( bcCategoriaTitulo) ;
      }

      protected void ReadRow1Q64( )
      {
         RowToVars64( bcCategoriaTitulo, 1) ;
      }

      protected void InitializeNonKey1Q64( )
      {
         A427CategoriaTituloNome = "";
         n427CategoriaTituloNome = false;
         A428CategoriaTituloDescricao = "";
         n428CategoriaTituloDescricao = false;
         A431CategoriaStatus = true;
         n431CategoriaStatus = false;
         Z427CategoriaTituloNome = "";
         Z428CategoriaTituloDescricao = "";
         Z431CategoriaStatus = false;
      }

      protected void InitAll1Q64( )
      {
         A426CategoriaTituloId = 0;
         n426CategoriaTituloId = false;
         InitializeNonKey1Q64( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A431CategoriaStatus = i431CategoriaStatus;
         n431CategoriaStatus = false;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow64( SdtCategoriaTitulo obj64 )
      {
         obj64.gxTpr_Mode = Gx_mode;
         obj64.gxTpr_Categoriatitulonome = A427CategoriaTituloNome;
         obj64.gxTpr_Categoriatitulodescricao = A428CategoriaTituloDescricao;
         obj64.gxTpr_Categoriastatus = A431CategoriaStatus;
         obj64.gxTpr_Categoriatituloid = A426CategoriaTituloId;
         obj64.gxTpr_Categoriatituloid_Z = Z426CategoriaTituloId;
         obj64.gxTpr_Categoriatitulonome_Z = Z427CategoriaTituloNome;
         obj64.gxTpr_Categoriatitulodescricao_Z = Z428CategoriaTituloDescricao;
         obj64.gxTpr_Categoriastatus_Z = Z431CategoriaStatus;
         obj64.gxTpr_Categoriatituloid_N = (short)(Convert.ToInt16(n426CategoriaTituloId));
         obj64.gxTpr_Categoriatitulonome_N = (short)(Convert.ToInt16(n427CategoriaTituloNome));
         obj64.gxTpr_Categoriatitulodescricao_N = (short)(Convert.ToInt16(n428CategoriaTituloDescricao));
         obj64.gxTpr_Categoriastatus_N = (short)(Convert.ToInt16(n431CategoriaStatus));
         obj64.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow64( SdtCategoriaTitulo obj64 )
      {
         obj64.gxTpr_Categoriatituloid = A426CategoriaTituloId;
         return  ;
      }

      public void RowToVars64( SdtCategoriaTitulo obj64 ,
                               int forceLoad )
      {
         Gx_mode = obj64.gxTpr_Mode;
         A427CategoriaTituloNome = obj64.gxTpr_Categoriatitulonome;
         n427CategoriaTituloNome = false;
         A428CategoriaTituloDescricao = obj64.gxTpr_Categoriatitulodescricao;
         n428CategoriaTituloDescricao = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A431CategoriaStatus = obj64.gxTpr_Categoriastatus;
            n431CategoriaStatus = false;
         }
         A426CategoriaTituloId = obj64.gxTpr_Categoriatituloid;
         n426CategoriaTituloId = false;
         Z426CategoriaTituloId = obj64.gxTpr_Categoriatituloid_Z;
         Z427CategoriaTituloNome = obj64.gxTpr_Categoriatitulonome_Z;
         Z428CategoriaTituloDescricao = obj64.gxTpr_Categoriatitulodescricao_Z;
         Z431CategoriaStatus = obj64.gxTpr_Categoriastatus_Z;
         n426CategoriaTituloId = (bool)(Convert.ToBoolean(obj64.gxTpr_Categoriatituloid_N));
         n427CategoriaTituloNome = (bool)(Convert.ToBoolean(obj64.gxTpr_Categoriatitulonome_N));
         n428CategoriaTituloDescricao = (bool)(Convert.ToBoolean(obj64.gxTpr_Categoriatitulodescricao_N));
         n431CategoriaStatus = (bool)(Convert.ToBoolean(obj64.gxTpr_Categoriastatus_N));
         Gx_mode = obj64.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A426CategoriaTituloId = (int)getParm(obj,0);
         n426CategoriaTituloId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1Q64( ) ;
         ScanKeyStart1Q64( ) ;
         if ( RcdFound64 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z426CategoriaTituloId = A426CategoriaTituloId;
         }
         ZM1Q64( -5) ;
         OnLoadActions1Q64( ) ;
         AddRow1Q64( ) ;
         ScanKeyEnd1Q64( ) ;
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars64( bcCategoriaTitulo, 0) ;
         ScanKeyStart1Q64( ) ;
         if ( RcdFound64 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z426CategoriaTituloId = A426CategoriaTituloId;
         }
         ZM1Q64( -5) ;
         OnLoadActions1Q64( ) ;
         AddRow1Q64( ) ;
         ScanKeyEnd1Q64( ) ;
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1Q64( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1Q64( ) ;
         }
         else
         {
            if ( RcdFound64 == 1 )
            {
               if ( A426CategoriaTituloId != Z426CategoriaTituloId )
               {
                  A426CategoriaTituloId = Z426CategoriaTituloId;
                  n426CategoriaTituloId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1Q64( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A426CategoriaTituloId != Z426CategoriaTituloId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1Q64( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1Q64( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcCategoriaTitulo, 1) ;
         SaveImpl( ) ;
         VarsToRow64( bcCategoriaTitulo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcCategoriaTitulo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Q64( ) ;
         AfterTrn( ) ;
         VarsToRow64( bcCategoriaTitulo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow64( bcCategoriaTitulo) ;
         }
         else
         {
            SdtCategoriaTitulo auxBC = new SdtCategoriaTitulo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A426CategoriaTituloId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCategoriaTitulo);
               auxBC.Save();
               bcCategoriaTitulo.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcCategoriaTitulo, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcCategoriaTitulo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Q64( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow64( bcCategoriaTitulo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow64( bcCategoriaTitulo) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars64( bcCategoriaTitulo, 0) ;
         GetKey1Q64( ) ;
         if ( RcdFound64 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A426CategoriaTituloId != Z426CategoriaTituloId )
            {
               A426CategoriaTituloId = Z426CategoriaTituloId;
               n426CategoriaTituloId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A426CategoriaTituloId != Z426CategoriaTituloId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("categoriatitulo_bc",pr_default);
         VarsToRow64( bcCategoriaTitulo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcCategoriaTitulo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCategoriaTitulo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCategoriaTitulo )
         {
            bcCategoriaTitulo = (SdtCategoriaTitulo)(sdt);
            if ( StringUtil.StrCmp(bcCategoriaTitulo.gxTpr_Mode, "") == 0 )
            {
               bcCategoriaTitulo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow64( bcCategoriaTitulo) ;
            }
            else
            {
               RowToVars64( bcCategoriaTitulo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCategoriaTitulo.gxTpr_Mode, "") == 0 )
            {
               bcCategoriaTitulo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars64( bcCategoriaTitulo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCategoriaTitulo CategoriaTitulo_BC
      {
         get {
            return bcCategoriaTitulo ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z427CategoriaTituloNome = "";
         A427CategoriaTituloNome = "";
         Z428CategoriaTituloDescricao = "";
         A428CategoriaTituloDescricao = "";
         BC001Q4_A426CategoriaTituloId = new int[1] ;
         BC001Q4_n426CategoriaTituloId = new bool[] {false} ;
         BC001Q4_A427CategoriaTituloNome = new string[] {""} ;
         BC001Q4_n427CategoriaTituloNome = new bool[] {false} ;
         BC001Q4_A428CategoriaTituloDescricao = new string[] {""} ;
         BC001Q4_n428CategoriaTituloDescricao = new bool[] {false} ;
         BC001Q4_A431CategoriaStatus = new bool[] {false} ;
         BC001Q4_n431CategoriaStatus = new bool[] {false} ;
         BC001Q5_A426CategoriaTituloId = new int[1] ;
         BC001Q5_n426CategoriaTituloId = new bool[] {false} ;
         BC001Q3_A426CategoriaTituloId = new int[1] ;
         BC001Q3_n426CategoriaTituloId = new bool[] {false} ;
         BC001Q3_A427CategoriaTituloNome = new string[] {""} ;
         BC001Q3_n427CategoriaTituloNome = new bool[] {false} ;
         BC001Q3_A428CategoriaTituloDescricao = new string[] {""} ;
         BC001Q3_n428CategoriaTituloDescricao = new bool[] {false} ;
         BC001Q3_A431CategoriaStatus = new bool[] {false} ;
         BC001Q3_n431CategoriaStatus = new bool[] {false} ;
         sMode64 = "";
         BC001Q2_A426CategoriaTituloId = new int[1] ;
         BC001Q2_n426CategoriaTituloId = new bool[] {false} ;
         BC001Q2_A427CategoriaTituloNome = new string[] {""} ;
         BC001Q2_n427CategoriaTituloNome = new bool[] {false} ;
         BC001Q2_A428CategoriaTituloDescricao = new string[] {""} ;
         BC001Q2_n428CategoriaTituloDescricao = new bool[] {false} ;
         BC001Q2_A431CategoriaStatus = new bool[] {false} ;
         BC001Q2_n431CategoriaStatus = new bool[] {false} ;
         BC001Q7_A426CategoriaTituloId = new int[1] ;
         BC001Q7_n426CategoriaTituloId = new bool[] {false} ;
         BC001Q10_A299ConfiguracoesId = new int[1] ;
         BC001Q11_A261TituloId = new int[1] ;
         BC001Q12_A426CategoriaTituloId = new int[1] ;
         BC001Q12_n426CategoriaTituloId = new bool[] {false} ;
         BC001Q12_A427CategoriaTituloNome = new string[] {""} ;
         BC001Q12_n427CategoriaTituloNome = new bool[] {false} ;
         BC001Q12_A428CategoriaTituloDescricao = new string[] {""} ;
         BC001Q12_n428CategoriaTituloDescricao = new bool[] {false} ;
         BC001Q12_A431CategoriaStatus = new bool[] {false} ;
         BC001Q12_n431CategoriaStatus = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriatitulo_bc__default(),
            new Object[][] {
                new Object[] {
               BC001Q2_A426CategoriaTituloId, BC001Q2_A427CategoriaTituloNome, BC001Q2_n427CategoriaTituloNome, BC001Q2_A428CategoriaTituloDescricao, BC001Q2_n428CategoriaTituloDescricao, BC001Q2_A431CategoriaStatus, BC001Q2_n431CategoriaStatus
               }
               , new Object[] {
               BC001Q3_A426CategoriaTituloId, BC001Q3_A427CategoriaTituloNome, BC001Q3_n427CategoriaTituloNome, BC001Q3_A428CategoriaTituloDescricao, BC001Q3_n428CategoriaTituloDescricao, BC001Q3_A431CategoriaStatus, BC001Q3_n431CategoriaStatus
               }
               , new Object[] {
               BC001Q4_A426CategoriaTituloId, BC001Q4_A427CategoriaTituloNome, BC001Q4_n427CategoriaTituloNome, BC001Q4_A428CategoriaTituloDescricao, BC001Q4_n428CategoriaTituloDescricao, BC001Q4_A431CategoriaStatus, BC001Q4_n431CategoriaStatus
               }
               , new Object[] {
               BC001Q5_A426CategoriaTituloId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Q7_A426CategoriaTituloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Q10_A299ConfiguracoesId
               }
               , new Object[] {
               BC001Q11_A261TituloId
               }
               , new Object[] {
               BC001Q12_A426CategoriaTituloId, BC001Q12_A427CategoriaTituloNome, BC001Q12_n427CategoriaTituloNome, BC001Q12_A428CategoriaTituloDescricao, BC001Q12_n428CategoriaTituloDescricao, BC001Q12_A431CategoriaStatus, BC001Q12_n431CategoriaStatus
               }
            }
         );
         Z431CategoriaStatus = true;
         n431CategoriaStatus = false;
         A431CategoriaStatus = true;
         n431CategoriaStatus = false;
         i431CategoriaStatus = true;
         n431CategoriaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121Q2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound64 ;
      private int trnEnded ;
      private int Z426CategoriaTituloId ;
      private int A426CategoriaTituloId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode64 ;
      private bool returnInSub ;
      private bool Z431CategoriaStatus ;
      private bool A431CategoriaStatus ;
      private bool n431CategoriaStatus ;
      private bool n426CategoriaTituloId ;
      private bool n427CategoriaTituloNome ;
      private bool n428CategoriaTituloDescricao ;
      private bool i431CategoriaStatus ;
      private string Z427CategoriaTituloNome ;
      private string A427CategoriaTituloNome ;
      private string Z428CategoriaTituloDescricao ;
      private string A428CategoriaTituloDescricao ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001Q4_A426CategoriaTituloId ;
      private bool[] BC001Q4_n426CategoriaTituloId ;
      private string[] BC001Q4_A427CategoriaTituloNome ;
      private bool[] BC001Q4_n427CategoriaTituloNome ;
      private string[] BC001Q4_A428CategoriaTituloDescricao ;
      private bool[] BC001Q4_n428CategoriaTituloDescricao ;
      private bool[] BC001Q4_A431CategoriaStatus ;
      private bool[] BC001Q4_n431CategoriaStatus ;
      private int[] BC001Q5_A426CategoriaTituloId ;
      private bool[] BC001Q5_n426CategoriaTituloId ;
      private int[] BC001Q3_A426CategoriaTituloId ;
      private bool[] BC001Q3_n426CategoriaTituloId ;
      private string[] BC001Q3_A427CategoriaTituloNome ;
      private bool[] BC001Q3_n427CategoriaTituloNome ;
      private string[] BC001Q3_A428CategoriaTituloDescricao ;
      private bool[] BC001Q3_n428CategoriaTituloDescricao ;
      private bool[] BC001Q3_A431CategoriaStatus ;
      private bool[] BC001Q3_n431CategoriaStatus ;
      private int[] BC001Q2_A426CategoriaTituloId ;
      private bool[] BC001Q2_n426CategoriaTituloId ;
      private string[] BC001Q2_A427CategoriaTituloNome ;
      private bool[] BC001Q2_n427CategoriaTituloNome ;
      private string[] BC001Q2_A428CategoriaTituloDescricao ;
      private bool[] BC001Q2_n428CategoriaTituloDescricao ;
      private bool[] BC001Q2_A431CategoriaStatus ;
      private bool[] BC001Q2_n431CategoriaStatus ;
      private int[] BC001Q7_A426CategoriaTituloId ;
      private bool[] BC001Q7_n426CategoriaTituloId ;
      private int[] BC001Q10_A299ConfiguracoesId ;
      private int[] BC001Q11_A261TituloId ;
      private int[] BC001Q12_A426CategoriaTituloId ;
      private bool[] BC001Q12_n426CategoriaTituloId ;
      private string[] BC001Q12_A427CategoriaTituloNome ;
      private bool[] BC001Q12_n427CategoriaTituloNome ;
      private string[] BC001Q12_A428CategoriaTituloDescricao ;
      private bool[] BC001Q12_n428CategoriaTituloDescricao ;
      private bool[] BC001Q12_A431CategoriaStatus ;
      private bool[] BC001Q12_n431CategoriaStatus ;
      private SdtCategoriaTitulo bcCategoriaTitulo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class categoriatitulo_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001Q2;
          prmBC001Q2 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q3;
          prmBC001Q3 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q4;
          prmBC001Q4 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q5;
          prmBC001Q5 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q6;
          prmBC001Q6 = new Object[] {
          new ParDef("CategoriaTituloNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("CategoriaTituloDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("CategoriaStatus",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmBC001Q7;
          prmBC001Q7 = new Object[] {
          };
          Object[] prmBC001Q8;
          prmBC001Q8 = new Object[] {
          new ParDef("CategoriaTituloNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("CategoriaTituloDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("CategoriaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q9;
          prmBC001Q9 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q10;
          prmBC001Q10 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q11;
          prmBC001Q11 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Q12;
          prmBC001Q12 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001Q2", "SELECT CategoriaTituloId, CategoriaTituloNome, CategoriaTituloDescricao, CategoriaStatus FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId  FOR UPDATE OF CategoriaTitulo",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Q3", "SELECT CategoriaTituloId, CategoriaTituloNome, CategoriaTituloDescricao, CategoriaStatus FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Q4", "SELECT TM1.CategoriaTituloId, TM1.CategoriaTituloNome, TM1.CategoriaTituloDescricao, TM1.CategoriaStatus FROM CategoriaTitulo TM1 WHERE TM1.CategoriaTituloId = :CategoriaTituloId ORDER BY TM1.CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Q5", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Q6", "SAVEPOINT gxupdate;INSERT INTO CategoriaTitulo(CategoriaTituloNome, CategoriaTituloDescricao, CategoriaStatus) VALUES(:CategoriaTituloNome, :CategoriaTituloDescricao, :CategoriaStatus);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001Q6)
             ,new CursorDef("BC001Q7", "SELECT currval('CategoriaTituloId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Q8", "SAVEPOINT gxupdate;UPDATE CategoriaTitulo SET CategoriaTituloNome=:CategoriaTituloNome, CategoriaTituloDescricao=:CategoriaTituloDescricao, CategoriaStatus=:CategoriaStatus  WHERE CategoriaTituloId = :CategoriaTituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q8)
             ,new CursorDef("BC001Q9", "SAVEPOINT gxupdate;DELETE FROM CategoriaTitulo  WHERE CategoriaTituloId = :CategoriaTituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Q9)
             ,new CursorDef("BC001Q10", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfiguracoesCategoriaTitulo = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Q11", "SELECT TituloId FROM Titulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Q12", "SELECT TM1.CategoriaTituloId, TM1.CategoriaTituloNome, TM1.CategoriaTituloDescricao, TM1.CategoriaStatus FROM CategoriaTitulo TM1 WHERE TM1.CategoriaTituloId = :CategoriaTituloId ORDER BY TM1.CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Q12,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
