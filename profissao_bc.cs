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
   public class profissao_bc : GxSilentTrn, IGxSilentTrn
   {
      public profissao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profissao_bc( IGxContext context )
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
         ReadRow1S66( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1S66( ) ;
         standaloneModal( ) ;
         AddRow1S66( ) ;
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
            E111S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z440ProfissaoId = A440ProfissaoId;
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

      protected void CONFIRM_1S0( )
      {
         BeforeValidate1S66( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1S66( ) ;
            }
            else
            {
               CheckExtendedTable1S66( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1S66( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1S66( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z441ProfissaoNome = A441ProfissaoNome;
         }
         if ( GX_JID == -1 )
         {
            Z440ProfissaoId = A440ProfissaoId;
            Z441ProfissaoNome = A441ProfissaoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1S66( )
      {
         /* Using cursor BC001S4 */
         pr_default.execute(2, new Object[] {A440ProfissaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound66 = 1;
            A441ProfissaoNome = BC001S4_A441ProfissaoNome[0];
            n441ProfissaoNome = BC001S4_n441ProfissaoNome[0];
            ZM1S66( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1S66( ) ;
      }

      protected void OnLoadActions1S66( )
      {
      }

      protected void CheckExtendedTable1S66( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1S66( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1S66( )
      {
         /* Using cursor BC001S5 */
         pr_default.execute(3, new Object[] {A440ProfissaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound66 = 1;
         }
         else
         {
            RcdFound66 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001S3 */
         pr_default.execute(1, new Object[] {A440ProfissaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1S66( 1) ;
            RcdFound66 = 1;
            A440ProfissaoId = BC001S3_A440ProfissaoId[0];
            A441ProfissaoNome = BC001S3_A441ProfissaoNome[0];
            n441ProfissaoNome = BC001S3_n441ProfissaoNome[0];
            Z440ProfissaoId = A440ProfissaoId;
            sMode66 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1S66( ) ;
            if ( AnyError == 1 )
            {
               RcdFound66 = 0;
               InitializeNonKey1S66( ) ;
            }
            Gx_mode = sMode66;
         }
         else
         {
            RcdFound66 = 0;
            InitializeNonKey1S66( ) ;
            sMode66 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode66;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1S66( ) ;
         if ( RcdFound66 == 0 )
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
         CONFIRM_1S0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1S66( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001S2 */
            pr_default.execute(0, new Object[] {A440ProfissaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profissao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z441ProfissaoNome, BC001S2_A441ProfissaoNome[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Profissao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1S66( )
      {
         BeforeValidate1S66( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S66( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1S66( 0) ;
            CheckOptimisticConcurrency1S66( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S66( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1S66( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001S6 */
                     pr_default.execute(4, new Object[] {n441ProfissaoNome, A441ProfissaoNome});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001S7 */
                     pr_default.execute(5);
                     A440ProfissaoId = BC001S7_A440ProfissaoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Profissao");
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
               Load1S66( ) ;
            }
            EndLevel1S66( ) ;
         }
         CloseExtendedTableCursors1S66( ) ;
      }

      protected void Update1S66( )
      {
         BeforeValidate1S66( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S66( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S66( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S66( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1S66( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001S8 */
                     pr_default.execute(6, new Object[] {n441ProfissaoNome, A441ProfissaoNome, A440ProfissaoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Profissao");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profissao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1S66( ) ;
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
            EndLevel1S66( ) ;
         }
         CloseExtendedTableCursors1S66( ) ;
      }

      protected void DeferredUpdate1S66( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1S66( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S66( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1S66( ) ;
            AfterConfirm1S66( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1S66( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001S9 */
                  pr_default.execute(7, new Object[] {A440ProfissaoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Profissao");
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
         sMode66 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1S66( ) ;
         Gx_mode = sMode66;
      }

      protected void OnDeleteControls1S66( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001S10 */
            pr_default.execute(8, new Object[] {A440ProfissaoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC001S11 */
            pr_default.execute(9, new Object[] {A440ProfissaoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Empresa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001S12 */
            pr_default.execute(10, new Object[] {A440ProfissaoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"+" ("+"Cliente Profissao"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC001S13 */
            pr_default.execute(11, new Object[] {A440ProfissaoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"+" ("+"Db Responsavel Profissao"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1S66( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1S66( ) ;
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

      public void ScanKeyStart1S66( )
      {
         /* Scan By routine */
         /* Using cursor BC001S14 */
         pr_default.execute(12, new Object[] {A440ProfissaoId});
         RcdFound66 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound66 = 1;
            A440ProfissaoId = BC001S14_A440ProfissaoId[0];
            A441ProfissaoNome = BC001S14_A441ProfissaoNome[0];
            n441ProfissaoNome = BC001S14_n441ProfissaoNome[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1S66( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound66 = 0;
         ScanKeyLoad1S66( ) ;
      }

      protected void ScanKeyLoad1S66( )
      {
         sMode66 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound66 = 1;
            A440ProfissaoId = BC001S14_A440ProfissaoId[0];
            A441ProfissaoNome = BC001S14_A441ProfissaoNome[0];
            n441ProfissaoNome = BC001S14_n441ProfissaoNome[0];
         }
         Gx_mode = sMode66;
      }

      protected void ScanKeyEnd1S66( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1S66( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1S66( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1S66( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1S66( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1S66( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1S66( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1S66( )
      {
      }

      protected void send_integrity_lvl_hashes1S66( )
      {
      }

      protected void AddRow1S66( )
      {
         VarsToRow66( bcProfissao) ;
      }

      protected void ReadRow1S66( )
      {
         RowToVars66( bcProfissao, 1) ;
      }

      protected void InitializeNonKey1S66( )
      {
         A441ProfissaoNome = "";
         n441ProfissaoNome = false;
         Z441ProfissaoNome = "";
      }

      protected void InitAll1S66( )
      {
         A440ProfissaoId = 0;
         InitializeNonKey1S66( ) ;
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

      public void VarsToRow66( SdtProfissao obj66 )
      {
         obj66.gxTpr_Mode = Gx_mode;
         obj66.gxTpr_Profissaonome = A441ProfissaoNome;
         obj66.gxTpr_Profissaoid = A440ProfissaoId;
         obj66.gxTpr_Profissaoid_Z = Z440ProfissaoId;
         obj66.gxTpr_Profissaonome_Z = Z441ProfissaoNome;
         obj66.gxTpr_Profissaonome_N = (short)(Convert.ToInt16(n441ProfissaoNome));
         obj66.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow66( SdtProfissao obj66 )
      {
         obj66.gxTpr_Profissaoid = A440ProfissaoId;
         return  ;
      }

      public void RowToVars66( SdtProfissao obj66 ,
                               int forceLoad )
      {
         Gx_mode = obj66.gxTpr_Mode;
         A441ProfissaoNome = obj66.gxTpr_Profissaonome;
         n441ProfissaoNome = false;
         A440ProfissaoId = obj66.gxTpr_Profissaoid;
         Z440ProfissaoId = obj66.gxTpr_Profissaoid_Z;
         Z441ProfissaoNome = obj66.gxTpr_Profissaonome_Z;
         n441ProfissaoNome = (bool)(Convert.ToBoolean(obj66.gxTpr_Profissaonome_N));
         Gx_mode = obj66.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A440ProfissaoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1S66( ) ;
         ScanKeyStart1S66( ) ;
         if ( RcdFound66 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z440ProfissaoId = A440ProfissaoId;
         }
         ZM1S66( -1) ;
         OnLoadActions1S66( ) ;
         AddRow1S66( ) ;
         ScanKeyEnd1S66( ) ;
         if ( RcdFound66 == 0 )
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
         RowToVars66( bcProfissao, 0) ;
         ScanKeyStart1S66( ) ;
         if ( RcdFound66 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z440ProfissaoId = A440ProfissaoId;
         }
         ZM1S66( -1) ;
         OnLoadActions1S66( ) ;
         AddRow1S66( ) ;
         ScanKeyEnd1S66( ) ;
         if ( RcdFound66 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1S66( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1S66( ) ;
         }
         else
         {
            if ( RcdFound66 == 1 )
            {
               if ( A440ProfissaoId != Z440ProfissaoId )
               {
                  A440ProfissaoId = Z440ProfissaoId;
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
                  Update1S66( ) ;
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
                  if ( A440ProfissaoId != Z440ProfissaoId )
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
                        Insert1S66( ) ;
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
                        Insert1S66( ) ;
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
         RowToVars66( bcProfissao, 1) ;
         SaveImpl( ) ;
         VarsToRow66( bcProfissao) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars66( bcProfissao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1S66( ) ;
         AfterTrn( ) ;
         VarsToRow66( bcProfissao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow66( bcProfissao) ;
         }
         else
         {
            SdtProfissao auxBC = new SdtProfissao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A440ProfissaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProfissao);
               auxBC.Save();
               bcProfissao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars66( bcProfissao, 1) ;
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
         RowToVars66( bcProfissao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1S66( ) ;
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
               VarsToRow66( bcProfissao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow66( bcProfissao) ;
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
         RowToVars66( bcProfissao, 0) ;
         GetKey1S66( ) ;
         if ( RcdFound66 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A440ProfissaoId != Z440ProfissaoId )
            {
               A440ProfissaoId = Z440ProfissaoId;
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
            if ( A440ProfissaoId != Z440ProfissaoId )
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
         context.RollbackDataStores("profissao_bc",pr_default);
         VarsToRow66( bcProfissao) ;
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
         Gx_mode = bcProfissao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProfissao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProfissao )
         {
            bcProfissao = (SdtProfissao)(sdt);
            if ( StringUtil.StrCmp(bcProfissao.gxTpr_Mode, "") == 0 )
            {
               bcProfissao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow66( bcProfissao) ;
            }
            else
            {
               RowToVars66( bcProfissao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProfissao.gxTpr_Mode, "") == 0 )
            {
               bcProfissao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars66( bcProfissao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtProfissao Profissao_BC
      {
         get {
            return bcProfissao ;
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
         Z441ProfissaoNome = "";
         A441ProfissaoNome = "";
         BC001S4_A440ProfissaoId = new int[1] ;
         BC001S4_A441ProfissaoNome = new string[] {""} ;
         BC001S4_n441ProfissaoNome = new bool[] {false} ;
         BC001S5_A440ProfissaoId = new int[1] ;
         BC001S3_A440ProfissaoId = new int[1] ;
         BC001S3_A441ProfissaoNome = new string[] {""} ;
         BC001S3_n441ProfissaoNome = new bool[] {false} ;
         sMode66 = "";
         BC001S2_A440ProfissaoId = new int[1] ;
         BC001S2_A441ProfissaoNome = new string[] {""} ;
         BC001S2_n441ProfissaoNome = new bool[] {false} ;
         BC001S7_A440ProfissaoId = new int[1] ;
         BC001S10_A978RepresentanteId = new int[1] ;
         BC001S11_A249EmpresaId = new int[1] ;
         BC001S12_A168ClienteId = new int[1] ;
         BC001S13_A168ClienteId = new int[1] ;
         BC001S14_A440ProfissaoId = new int[1] ;
         BC001S14_A441ProfissaoNome = new string[] {""} ;
         BC001S14_n441ProfissaoNome = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profissao_bc__default(),
            new Object[][] {
                new Object[] {
               BC001S2_A440ProfissaoId, BC001S2_A441ProfissaoNome, BC001S2_n441ProfissaoNome
               }
               , new Object[] {
               BC001S3_A440ProfissaoId, BC001S3_A441ProfissaoNome, BC001S3_n441ProfissaoNome
               }
               , new Object[] {
               BC001S4_A440ProfissaoId, BC001S4_A441ProfissaoNome, BC001S4_n441ProfissaoNome
               }
               , new Object[] {
               BC001S5_A440ProfissaoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001S7_A440ProfissaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001S10_A978RepresentanteId
               }
               , new Object[] {
               BC001S11_A249EmpresaId
               }
               , new Object[] {
               BC001S12_A168ClienteId
               }
               , new Object[] {
               BC001S13_A168ClienteId
               }
               , new Object[] {
               BC001S14_A440ProfissaoId, BC001S14_A441ProfissaoNome, BC001S14_n441ProfissaoNome
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121S2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound66 ;
      private int trnEnded ;
      private int Z440ProfissaoId ;
      private int A440ProfissaoId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode66 ;
      private bool returnInSub ;
      private bool n441ProfissaoNome ;
      private string Z441ProfissaoNome ;
      private string A441ProfissaoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001S4_A440ProfissaoId ;
      private string[] BC001S4_A441ProfissaoNome ;
      private bool[] BC001S4_n441ProfissaoNome ;
      private int[] BC001S5_A440ProfissaoId ;
      private int[] BC001S3_A440ProfissaoId ;
      private string[] BC001S3_A441ProfissaoNome ;
      private bool[] BC001S3_n441ProfissaoNome ;
      private int[] BC001S2_A440ProfissaoId ;
      private string[] BC001S2_A441ProfissaoNome ;
      private bool[] BC001S2_n441ProfissaoNome ;
      private int[] BC001S7_A440ProfissaoId ;
      private int[] BC001S10_A978RepresentanteId ;
      private int[] BC001S11_A249EmpresaId ;
      private int[] BC001S12_A168ClienteId ;
      private int[] BC001S13_A168ClienteId ;
      private int[] BC001S14_A440ProfissaoId ;
      private string[] BC001S14_A441ProfissaoNome ;
      private bool[] BC001S14_n441ProfissaoNome ;
      private SdtProfissao bcProfissao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profissao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001S2;
          prmBC001S2 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S3;
          prmBC001S3 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S4;
          prmBC001S4 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S5;
          prmBC001S5 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S6;
          prmBC001S6 = new Object[] {
          new ParDef("ProfissaoNome",GXType.VarChar,90,0){Nullable=true}
          };
          Object[] prmBC001S7;
          prmBC001S7 = new Object[] {
          };
          Object[] prmBC001S8;
          prmBC001S8 = new Object[] {
          new ParDef("ProfissaoNome",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S9;
          prmBC001S9 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S10;
          prmBC001S10 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S11;
          prmBC001S11 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S12;
          prmBC001S12 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S13;
          prmBC001S13 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001S14;
          prmBC001S14 = new Object[] {
          new ParDef("ProfissaoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001S2", "SELECT ProfissaoId, ProfissaoNome FROM Profissao WHERE ProfissaoId = :ProfissaoId  FOR UPDATE OF Profissao",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001S3", "SELECT ProfissaoId, ProfissaoNome FROM Profissao WHERE ProfissaoId = :ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001S4", "SELECT TM1.ProfissaoId, TM1.ProfissaoNome FROM Profissao TM1 WHERE TM1.ProfissaoId = :ProfissaoId ORDER BY TM1.ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001S5", "SELECT ProfissaoId FROM Profissao WHERE ProfissaoId = :ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001S6", "SAVEPOINT gxupdate;INSERT INTO Profissao(ProfissaoNome) VALUES(:ProfissaoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001S6)
             ,new CursorDef("BC001S7", "SELECT currval('ProfissaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001S8", "SAVEPOINT gxupdate;UPDATE Profissao SET ProfissaoNome=:ProfissaoNome  WHERE ProfissaoId = :ProfissaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001S8)
             ,new CursorDef("BC001S9", "SAVEPOINT gxupdate;DELETE FROM Profissao  WHERE ProfissaoId = :ProfissaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001S9)
             ,new CursorDef("BC001S10", "SELECT RepresentanteId FROM Representante WHERE RepresentanteProfissao = :ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001S11", "SELECT EmpresaId FROM Empresa WHERE EmpresaRepresentanteProfissao = :ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001S12", "SELECT ClienteId FROM Cliente WHERE ClienteProfissao = :ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001S13", "SELECT ClienteId FROM Cliente WHERE ResponsavelProfissao = :ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001S14", "SELECT TM1.ProfissaoId, TM1.ProfissaoNome FROM Profissao TM1 WHERE TM1.ProfissaoId = :ProfissaoId ORDER BY TM1.ProfissaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001S14,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
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
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
