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
   public class banco_bc : GxSilentTrn, IGxSilentTrn
   {
      public banco_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public banco_bc( IGxContext context )
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
         ReadRow1K59( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1K59( ) ;
         standaloneModal( ) ;
         AddRow1K59( ) ;
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
            E111K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z402BancoId = A402BancoId;
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

      protected void CONFIRM_1K0( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1K59( ) ;
            }
            else
            {
               CheckExtendedTable1K59( ) ;
               if ( AnyError == 0 )
               {
                  ZM1K59( 3) ;
               }
               CloseExtendedTableCursors1K59( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1K59( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z404BancoCodigo = A404BancoCodigo;
            Z403BancoNome = A403BancoNome;
            Z946BancoCountAgencia_F = A946BancoCountAgencia_F;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z946BancoCountAgencia_F = A946BancoCountAgencia_F;
         }
         if ( GX_JID == -1 )
         {
            Z402BancoId = A402BancoId;
            Z404BancoCodigo = A404BancoCodigo;
            Z403BancoNome = A403BancoNome;
            Z946BancoCountAgencia_F = A946BancoCountAgencia_F;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1K59( )
      {
         /* Using cursor BC001K7 */
         pr_default.execute(3, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound59 = 1;
            A404BancoCodigo = BC001K7_A404BancoCodigo[0];
            n404BancoCodigo = BC001K7_n404BancoCodigo[0];
            A403BancoNome = BC001K7_A403BancoNome[0];
            n403BancoNome = BC001K7_n403BancoNome[0];
            A946BancoCountAgencia_F = BC001K7_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = BC001K7_n946BancoCountAgencia_F[0];
            ZM1K59( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1K59( ) ;
      }

      protected void OnLoadActions1K59( )
      {
      }

      protected void CheckExtendedTable1K59( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001K5 */
         pr_default.execute(2, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A946BancoCountAgencia_F = BC001K5_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = BC001K5_n946BancoCountAgencia_F[0];
         }
         else
         {
            A946BancoCountAgencia_F = 0;
            n946BancoCountAgencia_F = false;
         }
         pr_default.close(2);
         /* Using cursor BC001K8 */
         pr_default.execute(4, new Object[] {n404BancoCodigo, A404BancoCodigo, n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Banco Codigo"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1K59( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1K59( )
      {
         /* Using cursor BC001K9 */
         pr_default.execute(5, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound59 = 1;
         }
         else
         {
            RcdFound59 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001K3 */
         pr_default.execute(1, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1K59( 1) ;
            RcdFound59 = 1;
            A402BancoId = BC001K3_A402BancoId[0];
            n402BancoId = BC001K3_n402BancoId[0];
            A404BancoCodigo = BC001K3_A404BancoCodigo[0];
            n404BancoCodigo = BC001K3_n404BancoCodigo[0];
            A403BancoNome = BC001K3_A403BancoNome[0];
            n403BancoNome = BC001K3_n403BancoNome[0];
            Z402BancoId = A402BancoId;
            sMode59 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1K59( ) ;
            if ( AnyError == 1 )
            {
               RcdFound59 = 0;
               InitializeNonKey1K59( ) ;
            }
            Gx_mode = sMode59;
         }
         else
         {
            RcdFound59 = 0;
            InitializeNonKey1K59( ) ;
            sMode59 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode59;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1K59( ) ;
         if ( RcdFound59 == 0 )
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
         CONFIRM_1K0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1K59( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001K2 */
            pr_default.execute(0, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Banco"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z404BancoCodigo != BC001K2_A404BancoCodigo[0] ) || ( StringUtil.StrCmp(Z403BancoNome, BC001K2_A403BancoNome[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Banco"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K59( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K59( 0) ;
            CheckOptimisticConcurrency1K59( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K59( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K59( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K10 */
                     pr_default.execute(6, new Object[] {n404BancoCodigo, A404BancoCodigo, n403BancoNome, A403BancoNome});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001K11 */
                     pr_default.execute(7);
                     A402BancoId = BC001K11_A402BancoId[0];
                     n402BancoId = BC001K11_n402BancoId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Banco");
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
               Load1K59( ) ;
            }
            EndLevel1K59( ) ;
         }
         CloseExtendedTableCursors1K59( ) ;
      }

      protected void Update1K59( )
      {
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K59( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K59( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K59( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K12 */
                     pr_default.execute(8, new Object[] {n404BancoCodigo, A404BancoCodigo, n403BancoNome, A403BancoNome, n402BancoId, A402BancoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Banco");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Banco"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K59( ) ;
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
            EndLevel1K59( ) ;
         }
         CloseExtendedTableCursors1K59( ) ;
      }

      protected void DeferredUpdate1K59( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1K59( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K59( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K59( ) ;
            AfterConfirm1K59( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K59( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001K13 */
                  pr_default.execute(9, new Object[] {n402BancoId, A402BancoId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Banco");
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
         sMode59 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1K59( ) ;
         Gx_mode = sMode59;
      }

      protected void OnDeleteControls1K59( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001K15 */
            pr_default.execute(10, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               A946BancoCountAgencia_F = BC001K15_A946BancoCountAgencia_F[0];
               n946BancoCountAgencia_F = BC001K15_n946BancoCountAgencia_F[0];
            }
            else
            {
               A946BancoCountAgencia_F = 0;
               n946BancoCountAgencia_F = false;
            }
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001K16 */
            pr_default.execute(11, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC001K17 */
            pr_default.execute(12, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC001K18 */
            pr_default.execute(13, new Object[] {n402BancoId, A402BancoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel1K59( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1K59( ) ;
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

      public void ScanKeyStart1K59( )
      {
         /* Scan By routine */
         /* Using cursor BC001K20 */
         pr_default.execute(14, new Object[] {n402BancoId, A402BancoId});
         RcdFound59 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound59 = 1;
            A402BancoId = BC001K20_A402BancoId[0];
            n402BancoId = BC001K20_n402BancoId[0];
            A404BancoCodigo = BC001K20_A404BancoCodigo[0];
            n404BancoCodigo = BC001K20_n404BancoCodigo[0];
            A403BancoNome = BC001K20_A403BancoNome[0];
            n403BancoNome = BC001K20_n403BancoNome[0];
            A946BancoCountAgencia_F = BC001K20_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = BC001K20_n946BancoCountAgencia_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1K59( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound59 = 0;
         ScanKeyLoad1K59( ) ;
      }

      protected void ScanKeyLoad1K59( )
      {
         sMode59 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound59 = 1;
            A402BancoId = BC001K20_A402BancoId[0];
            n402BancoId = BC001K20_n402BancoId[0];
            A404BancoCodigo = BC001K20_A404BancoCodigo[0];
            n404BancoCodigo = BC001K20_n404BancoCodigo[0];
            A403BancoNome = BC001K20_A403BancoNome[0];
            n403BancoNome = BC001K20_n403BancoNome[0];
            A946BancoCountAgencia_F = BC001K20_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = BC001K20_n946BancoCountAgencia_F[0];
         }
         Gx_mode = sMode59;
      }

      protected void ScanKeyEnd1K59( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1K59( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K59( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K59( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K59( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K59( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K59( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K59( )
      {
      }

      protected void send_integrity_lvl_hashes1K59( )
      {
      }

      protected void AddRow1K59( )
      {
         VarsToRow59( bcBanco) ;
      }

      protected void ReadRow1K59( )
      {
         RowToVars59( bcBanco, 1) ;
      }

      protected void InitializeNonKey1K59( )
      {
         A404BancoCodigo = 0;
         n404BancoCodigo = false;
         A403BancoNome = "";
         n403BancoNome = false;
         A946BancoCountAgencia_F = 0;
         n946BancoCountAgencia_F = false;
         Z404BancoCodigo = 0;
         Z403BancoNome = "";
      }

      protected void InitAll1K59( )
      {
         A402BancoId = 0;
         n402BancoId = false;
         InitializeNonKey1K59( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow59( SdtBanco obj59 )
      {
         obj59.gxTpr_Mode = Gx_mode;
         obj59.gxTpr_Bancocodigo = A404BancoCodigo;
         obj59.gxTpr_Banconome = A403BancoNome;
         obj59.gxTpr_Bancocountagencia_f = A946BancoCountAgencia_F;
         obj59.gxTpr_Bancoid = A402BancoId;
         obj59.gxTpr_Bancoid_Z = Z402BancoId;
         obj59.gxTpr_Bancocodigo_Z = Z404BancoCodigo;
         obj59.gxTpr_Banconome_Z = Z403BancoNome;
         obj59.gxTpr_Bancocountagencia_f_Z = Z946BancoCountAgencia_F;
         obj59.gxTpr_Bancoid_N = (short)(Convert.ToInt16(n402BancoId));
         obj59.gxTpr_Bancocodigo_N = (short)(Convert.ToInt16(n404BancoCodigo));
         obj59.gxTpr_Banconome_N = (short)(Convert.ToInt16(n403BancoNome));
         obj59.gxTpr_Bancocountagencia_f_N = (short)(Convert.ToInt16(n946BancoCountAgencia_F));
         obj59.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow59( SdtBanco obj59 )
      {
         obj59.gxTpr_Bancoid = A402BancoId;
         return  ;
      }

      public void RowToVars59( SdtBanco obj59 ,
                               int forceLoad )
      {
         Gx_mode = obj59.gxTpr_Mode;
         A404BancoCodigo = obj59.gxTpr_Bancocodigo;
         n404BancoCodigo = false;
         A403BancoNome = obj59.gxTpr_Banconome;
         n403BancoNome = false;
         A946BancoCountAgencia_F = obj59.gxTpr_Bancocountagencia_f;
         n946BancoCountAgencia_F = false;
         A402BancoId = obj59.gxTpr_Bancoid;
         n402BancoId = false;
         Z402BancoId = obj59.gxTpr_Bancoid_Z;
         Z404BancoCodigo = obj59.gxTpr_Bancocodigo_Z;
         Z403BancoNome = obj59.gxTpr_Banconome_Z;
         Z946BancoCountAgencia_F = obj59.gxTpr_Bancocountagencia_f_Z;
         n402BancoId = (bool)(Convert.ToBoolean(obj59.gxTpr_Bancoid_N));
         n404BancoCodigo = (bool)(Convert.ToBoolean(obj59.gxTpr_Bancocodigo_N));
         n403BancoNome = (bool)(Convert.ToBoolean(obj59.gxTpr_Banconome_N));
         n946BancoCountAgencia_F = (bool)(Convert.ToBoolean(obj59.gxTpr_Bancocountagencia_f_N));
         Gx_mode = obj59.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A402BancoId = (int)getParm(obj,0);
         n402BancoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1K59( ) ;
         ScanKeyStart1K59( ) ;
         if ( RcdFound59 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z402BancoId = A402BancoId;
         }
         ZM1K59( -1) ;
         OnLoadActions1K59( ) ;
         AddRow1K59( ) ;
         ScanKeyEnd1K59( ) ;
         if ( RcdFound59 == 0 )
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
         RowToVars59( bcBanco, 0) ;
         ScanKeyStart1K59( ) ;
         if ( RcdFound59 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z402BancoId = A402BancoId;
         }
         ZM1K59( -1) ;
         OnLoadActions1K59( ) ;
         AddRow1K59( ) ;
         ScanKeyEnd1K59( ) ;
         if ( RcdFound59 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1K59( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1K59( ) ;
         }
         else
         {
            if ( RcdFound59 == 1 )
            {
               if ( A402BancoId != Z402BancoId )
               {
                  A402BancoId = Z402BancoId;
                  n402BancoId = false;
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
                  Update1K59( ) ;
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
                  if ( A402BancoId != Z402BancoId )
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
                        Insert1K59( ) ;
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
                        Insert1K59( ) ;
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
         RowToVars59( bcBanco, 1) ;
         SaveImpl( ) ;
         VarsToRow59( bcBanco) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars59( bcBanco, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1K59( ) ;
         AfterTrn( ) ;
         VarsToRow59( bcBanco) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow59( bcBanco) ;
         }
         else
         {
            SdtBanco auxBC = new SdtBanco(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A402BancoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcBanco);
               auxBC.Save();
               bcBanco.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars59( bcBanco, 1) ;
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
         RowToVars59( bcBanco, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1K59( ) ;
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
               VarsToRow59( bcBanco) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow59( bcBanco) ;
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
         RowToVars59( bcBanco, 0) ;
         GetKey1K59( ) ;
         if ( RcdFound59 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A402BancoId != Z402BancoId )
            {
               A402BancoId = Z402BancoId;
               n402BancoId = false;
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
            if ( A402BancoId != Z402BancoId )
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
         context.RollbackDataStores("banco_bc",pr_default);
         VarsToRow59( bcBanco) ;
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
         Gx_mode = bcBanco.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcBanco.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcBanco )
         {
            bcBanco = (SdtBanco)(sdt);
            if ( StringUtil.StrCmp(bcBanco.gxTpr_Mode, "") == 0 )
            {
               bcBanco.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow59( bcBanco) ;
            }
            else
            {
               RowToVars59( bcBanco, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcBanco.gxTpr_Mode, "") == 0 )
            {
               bcBanco.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars59( bcBanco, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtBanco Banco_BC
      {
         get {
            return bcBanco ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z403BancoNome = "";
         A403BancoNome = "";
         BC001K7_A402BancoId = new int[1] ;
         BC001K7_n402BancoId = new bool[] {false} ;
         BC001K7_A404BancoCodigo = new int[1] ;
         BC001K7_n404BancoCodigo = new bool[] {false} ;
         BC001K7_A403BancoNome = new string[] {""} ;
         BC001K7_n403BancoNome = new bool[] {false} ;
         BC001K7_A946BancoCountAgencia_F = new short[1] ;
         BC001K7_n946BancoCountAgencia_F = new bool[] {false} ;
         BC001K5_A946BancoCountAgencia_F = new short[1] ;
         BC001K5_n946BancoCountAgencia_F = new bool[] {false} ;
         BC001K8_A404BancoCodigo = new int[1] ;
         BC001K8_n404BancoCodigo = new bool[] {false} ;
         BC001K9_A402BancoId = new int[1] ;
         BC001K9_n402BancoId = new bool[] {false} ;
         BC001K3_A402BancoId = new int[1] ;
         BC001K3_n402BancoId = new bool[] {false} ;
         BC001K3_A404BancoCodigo = new int[1] ;
         BC001K3_n404BancoCodigo = new bool[] {false} ;
         BC001K3_A403BancoNome = new string[] {""} ;
         BC001K3_n403BancoNome = new bool[] {false} ;
         sMode59 = "";
         BC001K2_A402BancoId = new int[1] ;
         BC001K2_n402BancoId = new bool[] {false} ;
         BC001K2_A404BancoCodigo = new int[1] ;
         BC001K2_n404BancoCodigo = new bool[] {false} ;
         BC001K2_A403BancoNome = new string[] {""} ;
         BC001K2_n403BancoNome = new bool[] {false} ;
         BC001K11_A402BancoId = new int[1] ;
         BC001K11_n402BancoId = new bool[] {false} ;
         BC001K15_A946BancoCountAgencia_F = new short[1] ;
         BC001K15_n946BancoCountAgencia_F = new bool[] {false} ;
         BC001K16_A938AgenciaId = new int[1] ;
         BC001K17_A249EmpresaId = new int[1] ;
         BC001K18_A168ClienteId = new int[1] ;
         BC001K20_A402BancoId = new int[1] ;
         BC001K20_n402BancoId = new bool[] {false} ;
         BC001K20_A404BancoCodigo = new int[1] ;
         BC001K20_n404BancoCodigo = new bool[] {false} ;
         BC001K20_A403BancoNome = new string[] {""} ;
         BC001K20_n403BancoNome = new bool[] {false} ;
         BC001K20_A946BancoCountAgencia_F = new short[1] ;
         BC001K20_n946BancoCountAgencia_F = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.banco_bc__default(),
            new Object[][] {
                new Object[] {
               BC001K2_A402BancoId, BC001K2_A404BancoCodigo, BC001K2_n404BancoCodigo, BC001K2_A403BancoNome, BC001K2_n403BancoNome
               }
               , new Object[] {
               BC001K3_A402BancoId, BC001K3_A404BancoCodigo, BC001K3_n404BancoCodigo, BC001K3_A403BancoNome, BC001K3_n403BancoNome
               }
               , new Object[] {
               BC001K5_A946BancoCountAgencia_F, BC001K5_n946BancoCountAgencia_F
               }
               , new Object[] {
               BC001K7_A402BancoId, BC001K7_A404BancoCodigo, BC001K7_n404BancoCodigo, BC001K7_A403BancoNome, BC001K7_n403BancoNome, BC001K7_A946BancoCountAgencia_F, BC001K7_n946BancoCountAgencia_F
               }
               , new Object[] {
               BC001K8_A404BancoCodigo, BC001K8_n404BancoCodigo
               }
               , new Object[] {
               BC001K9_A402BancoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K11_A402BancoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K15_A946BancoCountAgencia_F, BC001K15_n946BancoCountAgencia_F
               }
               , new Object[] {
               BC001K16_A938AgenciaId
               }
               , new Object[] {
               BC001K17_A249EmpresaId
               }
               , new Object[] {
               BC001K18_A168ClienteId
               }
               , new Object[] {
               BC001K20_A402BancoId, BC001K20_A404BancoCodigo, BC001K20_n404BancoCodigo, BC001K20_A403BancoNome, BC001K20_n403BancoNome, BC001K20_A946BancoCountAgencia_F, BC001K20_n946BancoCountAgencia_F
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121K2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z946BancoCountAgencia_F ;
      private short A946BancoCountAgencia_F ;
      private short RcdFound59 ;
      private int trnEnded ;
      private int Z402BancoId ;
      private int A402BancoId ;
      private int Z404BancoCodigo ;
      private int A404BancoCodigo ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode59 ;
      private bool returnInSub ;
      private bool n402BancoId ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private bool n946BancoCountAgencia_F ;
      private string Z403BancoNome ;
      private string A403BancoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001K7_A402BancoId ;
      private bool[] BC001K7_n402BancoId ;
      private int[] BC001K7_A404BancoCodigo ;
      private bool[] BC001K7_n404BancoCodigo ;
      private string[] BC001K7_A403BancoNome ;
      private bool[] BC001K7_n403BancoNome ;
      private short[] BC001K7_A946BancoCountAgencia_F ;
      private bool[] BC001K7_n946BancoCountAgencia_F ;
      private short[] BC001K5_A946BancoCountAgencia_F ;
      private bool[] BC001K5_n946BancoCountAgencia_F ;
      private int[] BC001K8_A404BancoCodigo ;
      private bool[] BC001K8_n404BancoCodigo ;
      private int[] BC001K9_A402BancoId ;
      private bool[] BC001K9_n402BancoId ;
      private int[] BC001K3_A402BancoId ;
      private bool[] BC001K3_n402BancoId ;
      private int[] BC001K3_A404BancoCodigo ;
      private bool[] BC001K3_n404BancoCodigo ;
      private string[] BC001K3_A403BancoNome ;
      private bool[] BC001K3_n403BancoNome ;
      private int[] BC001K2_A402BancoId ;
      private bool[] BC001K2_n402BancoId ;
      private int[] BC001K2_A404BancoCodigo ;
      private bool[] BC001K2_n404BancoCodigo ;
      private string[] BC001K2_A403BancoNome ;
      private bool[] BC001K2_n403BancoNome ;
      private int[] BC001K11_A402BancoId ;
      private bool[] BC001K11_n402BancoId ;
      private short[] BC001K15_A946BancoCountAgencia_F ;
      private bool[] BC001K15_n946BancoCountAgencia_F ;
      private int[] BC001K16_A938AgenciaId ;
      private int[] BC001K17_A249EmpresaId ;
      private int[] BC001K18_A168ClienteId ;
      private int[] BC001K20_A402BancoId ;
      private bool[] BC001K20_n402BancoId ;
      private int[] BC001K20_A404BancoCodigo ;
      private bool[] BC001K20_n404BancoCodigo ;
      private string[] BC001K20_A403BancoNome ;
      private bool[] BC001K20_n403BancoNome ;
      private short[] BC001K20_A946BancoCountAgencia_F ;
      private bool[] BC001K20_n946BancoCountAgencia_F ;
      private SdtBanco bcBanco ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class banco_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001K2;
          prmBC001K2 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K3;
          prmBC001K3 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K5;
          prmBC001K5 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K7;
          prmBC001K7 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K8;
          prmBC001K8 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K9;
          prmBC001K9 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K10;
          prmBC001K10 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoNome",GXType.VarChar,150,0){Nullable=true}
          };
          Object[] prmBC001K11;
          prmBC001K11 = new Object[] {
          };
          Object[] prmBC001K12;
          prmBC001K12 = new Object[] {
          new ParDef("BancoCodigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BancoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K13;
          prmBC001K13 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K15;
          prmBC001K15 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K16;
          prmBC001K16 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K17;
          prmBC001K17 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K18;
          prmBC001K18 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001K20;
          prmBC001K20 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001K2", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId  FOR UPDATE OF Banco",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K3", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K5", "SELECT COALESCE( T1.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia GROUP BY AgenciaBancoId ) T1 WHERE T1.AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K7", "SELECT TM1.BancoId, TM1.BancoCodigo, TM1.BancoNome, COALESCE( T2.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (Banco TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia WHERE TM1.BancoId = AgenciaBancoId GROUP BY AgenciaBancoId ) T2 ON T2.AgenciaBancoId = TM1.BancoId) WHERE TM1.BancoId = :BancoId ORDER BY TM1.BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K8", "SELECT BancoCodigo FROM Banco WHERE (BancoCodigo = :BancoCodigo) AND (Not ( BancoId = :BancoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K9", "SELECT BancoId FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K10", "SAVEPOINT gxupdate;INSERT INTO Banco(BancoCodigo, BancoNome) VALUES(:BancoCodigo, :BancoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001K10)
             ,new CursorDef("BC001K11", "SELECT currval('BancoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K12", "SAVEPOINT gxupdate;UPDATE Banco SET BancoCodigo=:BancoCodigo, BancoNome=:BancoNome  WHERE BancoId = :BancoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001K12)
             ,new CursorDef("BC001K13", "SAVEPOINT gxupdate;DELETE FROM Banco  WHERE BancoId = :BancoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001K13)
             ,new CursorDef("BC001K15", "SELECT COALESCE( T1.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia GROUP BY AgenciaBancoId ) T1 WHERE T1.AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001K16", "SELECT AgenciaId FROM Agencia WHERE AgenciaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001K17", "SELECT EmpresaId FROM Empresa WHERE EmpresaBancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001K18", "SELECT ClienteId FROM Cliente WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001K20", "SELECT TM1.BancoId, TM1.BancoCodigo, TM1.BancoNome, COALESCE( T2.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (Banco TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia WHERE TM1.BancoId = AgenciaBancoId GROUP BY AgenciaBancoId ) T2 ON T2.AgenciaBancoId = TM1.BancoId) WHERE TM1.BancoId = :BancoId ORDER BY TM1.BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K20,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
