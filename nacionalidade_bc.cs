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
   public class nacionalidade_bc : GxSilentTrn, IGxSilentTrn
   {
      public nacionalidade_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public nacionalidade_bc( IGxContext context )
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
         ReadRow1R65( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1R65( ) ;
         standaloneModal( ) ;
         AddRow1R65( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z434NacionalidadeId = A434NacionalidadeId;
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

      protected void CONFIRM_1R0( )
      {
         BeforeValidate1R65( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1R65( ) ;
            }
            else
            {
               CheckExtendedTable1R65( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1R65( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1R65( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z435NacionalidadeNome = A435NacionalidadeNome;
         }
         if ( GX_JID == -1 )
         {
            Z434NacionalidadeId = A434NacionalidadeId;
            Z435NacionalidadeNome = A435NacionalidadeNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1R65( )
      {
         /* Using cursor BC001R4 */
         pr_default.execute(2, new Object[] {A434NacionalidadeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound65 = 1;
            A435NacionalidadeNome = BC001R4_A435NacionalidadeNome[0];
            n435NacionalidadeNome = BC001R4_n435NacionalidadeNome[0];
            ZM1R65( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1R65( ) ;
      }

      protected void OnLoadActions1R65( )
      {
      }

      protected void CheckExtendedTable1R65( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1R65( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1R65( )
      {
         /* Using cursor BC001R5 */
         pr_default.execute(3, new Object[] {A434NacionalidadeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound65 = 1;
         }
         else
         {
            RcdFound65 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001R3 */
         pr_default.execute(1, new Object[] {A434NacionalidadeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1R65( 1) ;
            RcdFound65 = 1;
            A434NacionalidadeId = BC001R3_A434NacionalidadeId[0];
            A435NacionalidadeNome = BC001R3_A435NacionalidadeNome[0];
            n435NacionalidadeNome = BC001R3_n435NacionalidadeNome[0];
            Z434NacionalidadeId = A434NacionalidadeId;
            sMode65 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1R65( ) ;
            if ( AnyError == 1 )
            {
               RcdFound65 = 0;
               InitializeNonKey1R65( ) ;
            }
            Gx_mode = sMode65;
         }
         else
         {
            RcdFound65 = 0;
            InitializeNonKey1R65( ) ;
            sMode65 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode65;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1R65( ) ;
         if ( RcdFound65 == 0 )
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
         CONFIRM_1R0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1R65( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001R2 */
            pr_default.execute(0, new Object[] {A434NacionalidadeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Nacionalidade"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z435NacionalidadeNome, BC001R2_A435NacionalidadeNome[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Nacionalidade"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1R65( )
      {
         BeforeValidate1R65( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1R65( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1R65( 0) ;
            CheckOptimisticConcurrency1R65( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1R65( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1R65( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001R6 */
                     pr_default.execute(4, new Object[] {n435NacionalidadeNome, A435NacionalidadeNome});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001R7 */
                     pr_default.execute(5);
                     A434NacionalidadeId = BC001R7_A434NacionalidadeId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Nacionalidade");
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
               Load1R65( ) ;
            }
            EndLevel1R65( ) ;
         }
         CloseExtendedTableCursors1R65( ) ;
      }

      protected void Update1R65( )
      {
         BeforeValidate1R65( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1R65( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1R65( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1R65( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1R65( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001R8 */
                     pr_default.execute(6, new Object[] {n435NacionalidadeNome, A435NacionalidadeNome, A434NacionalidadeId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Nacionalidade");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Nacionalidade"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1R65( ) ;
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
            EndLevel1R65( ) ;
         }
         CloseExtendedTableCursors1R65( ) ;
      }

      protected void DeferredUpdate1R65( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1R65( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1R65( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1R65( ) ;
            AfterConfirm1R65( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1R65( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001R9 */
                  pr_default.execute(7, new Object[] {A434NacionalidadeId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Nacionalidade");
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
         sMode65 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1R65( ) ;
         Gx_mode = sMode65;
      }

      protected void OnDeleteControls1R65( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001R10 */
            pr_default.execute(8, new Object[] {A434NacionalidadeId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"+" ("+"Sb Cliente Nacionalidade"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC001R11 */
            pr_default.execute(9, new Object[] {A434NacionalidadeId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"+" ("+"Sb Responsavel Nacionalidade"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1R65( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1R65( ) ;
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

      public void ScanKeyStart1R65( )
      {
         /* Using cursor BC001R12 */
         pr_default.execute(10, new Object[] {A434NacionalidadeId});
         RcdFound65 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound65 = 1;
            A434NacionalidadeId = BC001R12_A434NacionalidadeId[0];
            A435NacionalidadeNome = BC001R12_A435NacionalidadeNome[0];
            n435NacionalidadeNome = BC001R12_n435NacionalidadeNome[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1R65( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound65 = 0;
         ScanKeyLoad1R65( ) ;
      }

      protected void ScanKeyLoad1R65( )
      {
         sMode65 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound65 = 1;
            A434NacionalidadeId = BC001R12_A434NacionalidadeId[0];
            A435NacionalidadeNome = BC001R12_A435NacionalidadeNome[0];
            n435NacionalidadeNome = BC001R12_n435NacionalidadeNome[0];
         }
         Gx_mode = sMode65;
      }

      protected void ScanKeyEnd1R65( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1R65( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1R65( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1R65( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1R65( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1R65( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1R65( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1R65( )
      {
      }

      protected void send_integrity_lvl_hashes1R65( )
      {
      }

      protected void AddRow1R65( )
      {
         VarsToRow65( bcNacionalidade) ;
      }

      protected void ReadRow1R65( )
      {
         RowToVars65( bcNacionalidade, 1) ;
      }

      protected void InitializeNonKey1R65( )
      {
         A435NacionalidadeNome = "";
         n435NacionalidadeNome = false;
         Z435NacionalidadeNome = "";
      }

      protected void InitAll1R65( )
      {
         A434NacionalidadeId = 0;
         InitializeNonKey1R65( ) ;
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

      public void VarsToRow65( SdtNacionalidade obj65 )
      {
         obj65.gxTpr_Mode = Gx_mode;
         obj65.gxTpr_Nacionalidadenome = A435NacionalidadeNome;
         obj65.gxTpr_Nacionalidadeid = A434NacionalidadeId;
         obj65.gxTpr_Nacionalidadeid_Z = Z434NacionalidadeId;
         obj65.gxTpr_Nacionalidadenome_Z = Z435NacionalidadeNome;
         obj65.gxTpr_Nacionalidadenome_N = (short)(Convert.ToInt16(n435NacionalidadeNome));
         obj65.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow65( SdtNacionalidade obj65 )
      {
         obj65.gxTpr_Nacionalidadeid = A434NacionalidadeId;
         return  ;
      }

      public void RowToVars65( SdtNacionalidade obj65 ,
                               int forceLoad )
      {
         Gx_mode = obj65.gxTpr_Mode;
         A435NacionalidadeNome = obj65.gxTpr_Nacionalidadenome;
         n435NacionalidadeNome = false;
         A434NacionalidadeId = obj65.gxTpr_Nacionalidadeid;
         Z434NacionalidadeId = obj65.gxTpr_Nacionalidadeid_Z;
         Z435NacionalidadeNome = obj65.gxTpr_Nacionalidadenome_Z;
         n435NacionalidadeNome = (bool)(Convert.ToBoolean(obj65.gxTpr_Nacionalidadenome_N));
         Gx_mode = obj65.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A434NacionalidadeId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1R65( ) ;
         ScanKeyStart1R65( ) ;
         if ( RcdFound65 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z434NacionalidadeId = A434NacionalidadeId;
         }
         ZM1R65( -1) ;
         OnLoadActions1R65( ) ;
         AddRow1R65( ) ;
         ScanKeyEnd1R65( ) ;
         if ( RcdFound65 == 0 )
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
         RowToVars65( bcNacionalidade, 0) ;
         ScanKeyStart1R65( ) ;
         if ( RcdFound65 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z434NacionalidadeId = A434NacionalidadeId;
         }
         ZM1R65( -1) ;
         OnLoadActions1R65( ) ;
         AddRow1R65( ) ;
         ScanKeyEnd1R65( ) ;
         if ( RcdFound65 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1R65( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1R65( ) ;
         }
         else
         {
            if ( RcdFound65 == 1 )
            {
               if ( A434NacionalidadeId != Z434NacionalidadeId )
               {
                  A434NacionalidadeId = Z434NacionalidadeId;
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
                  Update1R65( ) ;
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
                  if ( A434NacionalidadeId != Z434NacionalidadeId )
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
                        Insert1R65( ) ;
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
                        Insert1R65( ) ;
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
         RowToVars65( bcNacionalidade, 1) ;
         SaveImpl( ) ;
         VarsToRow65( bcNacionalidade) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars65( bcNacionalidade, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1R65( ) ;
         AfterTrn( ) ;
         VarsToRow65( bcNacionalidade) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow65( bcNacionalidade) ;
         }
         else
         {
            SdtNacionalidade auxBC = new SdtNacionalidade(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A434NacionalidadeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNacionalidade);
               auxBC.Save();
               bcNacionalidade.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars65( bcNacionalidade, 1) ;
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
         RowToVars65( bcNacionalidade, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1R65( ) ;
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
               VarsToRow65( bcNacionalidade) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow65( bcNacionalidade) ;
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
         RowToVars65( bcNacionalidade, 0) ;
         GetKey1R65( ) ;
         if ( RcdFound65 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A434NacionalidadeId != Z434NacionalidadeId )
            {
               A434NacionalidadeId = Z434NacionalidadeId;
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
            if ( A434NacionalidadeId != Z434NacionalidadeId )
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
         context.RollbackDataStores("nacionalidade_bc",pr_default);
         VarsToRow65( bcNacionalidade) ;
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
         Gx_mode = bcNacionalidade.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNacionalidade.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNacionalidade )
         {
            bcNacionalidade = (SdtNacionalidade)(sdt);
            if ( StringUtil.StrCmp(bcNacionalidade.gxTpr_Mode, "") == 0 )
            {
               bcNacionalidade.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow65( bcNacionalidade) ;
            }
            else
            {
               RowToVars65( bcNacionalidade, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNacionalidade.gxTpr_Mode, "") == 0 )
            {
               bcNacionalidade.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars65( bcNacionalidade, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNacionalidade Nacionalidade_BC
      {
         get {
            return bcNacionalidade ;
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
         Z435NacionalidadeNome = "";
         A435NacionalidadeNome = "";
         BC001R4_A434NacionalidadeId = new int[1] ;
         BC001R4_A435NacionalidadeNome = new string[] {""} ;
         BC001R4_n435NacionalidadeNome = new bool[] {false} ;
         BC001R5_A434NacionalidadeId = new int[1] ;
         BC001R3_A434NacionalidadeId = new int[1] ;
         BC001R3_A435NacionalidadeNome = new string[] {""} ;
         BC001R3_n435NacionalidadeNome = new bool[] {false} ;
         sMode65 = "";
         BC001R2_A434NacionalidadeId = new int[1] ;
         BC001R2_A435NacionalidadeNome = new string[] {""} ;
         BC001R2_n435NacionalidadeNome = new bool[] {false} ;
         BC001R7_A434NacionalidadeId = new int[1] ;
         BC001R10_A168ClienteId = new int[1] ;
         BC001R11_A168ClienteId = new int[1] ;
         BC001R12_A434NacionalidadeId = new int[1] ;
         BC001R12_A435NacionalidadeNome = new string[] {""} ;
         BC001R12_n435NacionalidadeNome = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.nacionalidade_bc__default(),
            new Object[][] {
                new Object[] {
               BC001R2_A434NacionalidadeId, BC001R2_A435NacionalidadeNome, BC001R2_n435NacionalidadeNome
               }
               , new Object[] {
               BC001R3_A434NacionalidadeId, BC001R3_A435NacionalidadeNome, BC001R3_n435NacionalidadeNome
               }
               , new Object[] {
               BC001R4_A434NacionalidadeId, BC001R4_A435NacionalidadeNome, BC001R4_n435NacionalidadeNome
               }
               , new Object[] {
               BC001R5_A434NacionalidadeId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001R7_A434NacionalidadeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001R10_A168ClienteId
               }
               , new Object[] {
               BC001R11_A168ClienteId
               }
               , new Object[] {
               BC001R12_A434NacionalidadeId, BC001R12_A435NacionalidadeNome, BC001R12_n435NacionalidadeNome
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound65 ;
      private int trnEnded ;
      private int Z434NacionalidadeId ;
      private int A434NacionalidadeId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode65 ;
      private bool n435NacionalidadeNome ;
      private string Z435NacionalidadeNome ;
      private string A435NacionalidadeNome ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001R4_A434NacionalidadeId ;
      private string[] BC001R4_A435NacionalidadeNome ;
      private bool[] BC001R4_n435NacionalidadeNome ;
      private int[] BC001R5_A434NacionalidadeId ;
      private int[] BC001R3_A434NacionalidadeId ;
      private string[] BC001R3_A435NacionalidadeNome ;
      private bool[] BC001R3_n435NacionalidadeNome ;
      private int[] BC001R2_A434NacionalidadeId ;
      private string[] BC001R2_A435NacionalidadeNome ;
      private bool[] BC001R2_n435NacionalidadeNome ;
      private int[] BC001R7_A434NacionalidadeId ;
      private int[] BC001R10_A168ClienteId ;
      private int[] BC001R11_A168ClienteId ;
      private int[] BC001R12_A434NacionalidadeId ;
      private string[] BC001R12_A435NacionalidadeNome ;
      private bool[] BC001R12_n435NacionalidadeNome ;
      private SdtNacionalidade bcNacionalidade ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class nacionalidade_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001R2;
          prmBC001R2 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R3;
          prmBC001R3 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R4;
          prmBC001R4 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R5;
          prmBC001R5 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R6;
          prmBC001R6 = new Object[] {
          new ParDef("NacionalidadeNome",GXType.VarChar,100,0){Nullable=true}
          };
          Object[] prmBC001R7;
          prmBC001R7 = new Object[] {
          };
          Object[] prmBC001R8;
          prmBC001R8 = new Object[] {
          new ParDef("NacionalidadeNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R9;
          prmBC001R9 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R10;
          prmBC001R10 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R11;
          prmBC001R11 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          Object[] prmBC001R12;
          prmBC001R12 = new Object[] {
          new ParDef("NacionalidadeId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001R2", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :NacionalidadeId  FOR UPDATE OF Nacionalidade",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001R3", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :NacionalidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001R4", "SELECT TM1.NacionalidadeId, TM1.NacionalidadeNome FROM Nacionalidade TM1 WHERE TM1.NacionalidadeId = :NacionalidadeId ORDER BY TM1.NacionalidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001R5", "SELECT NacionalidadeId FROM Nacionalidade WHERE NacionalidadeId = :NacionalidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001R6", "SAVEPOINT gxupdate;INSERT INTO Nacionalidade(NacionalidadeNome) VALUES(:NacionalidadeNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001R6)
             ,new CursorDef("BC001R7", "SELECT currval('NacionalidadeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001R8", "SAVEPOINT gxupdate;UPDATE Nacionalidade SET NacionalidadeNome=:NacionalidadeNome  WHERE NacionalidadeId = :NacionalidadeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001R8)
             ,new CursorDef("BC001R9", "SAVEPOINT gxupdate;DELETE FROM Nacionalidade  WHERE NacionalidadeId = :NacionalidadeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001R9)
             ,new CursorDef("BC001R10", "SELECT ClienteId FROM Cliente WHERE ClienteNacionalidade = :NacionalidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001R11", "SELECT ClienteId FROM Cliente WHERE ResponsavelNacionalidade = :NacionalidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001R12", "SELECT TM1.NacionalidadeId, TM1.NacionalidadeNome FROM Nacionalidade TM1 WHERE TM1.NacionalidadeId = :NacionalidadeId ORDER BY TM1.NacionalidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001R12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
