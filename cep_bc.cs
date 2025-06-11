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
   public class cep_bc : GxSilentTrn, IGxSilentTrn
   {
      public cep_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cep_bc( IGxContext context )
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
         ReadRow0P29( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0P29( ) ;
         standaloneModal( ) ;
         AddRow0P29( ) ;
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
               Z178CEPId = A178CEPId;
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

      protected void CONFIRM_0P0( )
      {
         BeforeValidate0P29( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0P29( ) ;
            }
            else
            {
               CheckExtendedTable0P29( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0P29( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0P29( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z179CEP = A179CEP;
         }
         if ( GX_JID == -1 )
         {
            Z178CEPId = A178CEPId;
            Z179CEP = A179CEP;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0P29( )
      {
         /* Using cursor BC000P4 */
         pr_default.execute(2, new Object[] {A178CEPId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound29 = 1;
            A179CEP = BC000P4_A179CEP[0];
            n179CEP = BC000P4_n179CEP[0];
            ZM0P29( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0P29( ) ;
      }

      protected void OnLoadActions0P29( )
      {
      }

      protected void CheckExtendedTable0P29( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0P29( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0P29( )
      {
         /* Using cursor BC000P5 */
         pr_default.execute(3, new Object[] {A178CEPId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000P3 */
         pr_default.execute(1, new Object[] {A178CEPId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P29( 1) ;
            RcdFound29 = 1;
            A178CEPId = BC000P3_A178CEPId[0];
            A179CEP = BC000P3_A179CEP[0];
            n179CEP = BC000P3_n179CEP[0];
            Z178CEPId = A178CEPId;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0P29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0P29( ) ;
            }
            Gx_mode = sMode29;
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0P29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode29;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P29( ) ;
         if ( RcdFound29 == 0 )
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
         CONFIRM_0P0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0P29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000P2 */
            pr_default.execute(0, new Object[] {A178CEPId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CEP"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z179CEP, BC000P2_A179CEP[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CEP"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P29( )
      {
         BeforeValidate0P29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P29( 0) ;
            CheckOptimisticConcurrency0P29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000P6 */
                     pr_default.execute(4, new Object[] {A178CEPId, n179CEP, A179CEP});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("CEP");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load0P29( ) ;
            }
            EndLevel0P29( ) ;
         }
         CloseExtendedTableCursors0P29( ) ;
      }

      protected void Update0P29( )
      {
         BeforeValidate0P29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000P7 */
                     pr_default.execute(5, new Object[] {n179CEP, A179CEP, A178CEPId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("CEP");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CEP"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P29( ) ;
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
            EndLevel0P29( ) ;
         }
         CloseExtendedTableCursors0P29( ) ;
      }

      protected void DeferredUpdate0P29( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0P29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P29( ) ;
            AfterConfirm0P29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000P8 */
                  pr_default.execute(6, new Object[] {A178CEPId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("CEP");
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0P29( ) ;
         Gx_mode = sMode29;
      }

      protected void OnDeleteControls0P29( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0P29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P29( ) ;
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

      public void ScanKeyStart0P29( )
      {
         /* Using cursor BC000P9 */
         pr_default.execute(7, new Object[] {A178CEPId});
         RcdFound29 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound29 = 1;
            A178CEPId = BC000P9_A178CEPId[0];
            A179CEP = BC000P9_A179CEP[0];
            n179CEP = BC000P9_n179CEP[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0P29( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound29 = 0;
         ScanKeyLoad0P29( ) ;
      }

      protected void ScanKeyLoad0P29( )
      {
         sMode29 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound29 = 1;
            A178CEPId = BC000P9_A178CEPId[0];
            A179CEP = BC000P9_A179CEP[0];
            n179CEP = BC000P9_n179CEP[0];
         }
         Gx_mode = sMode29;
      }

      protected void ScanKeyEnd0P29( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0P29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P29( )
      {
      }

      protected void send_integrity_lvl_hashes0P29( )
      {
      }

      protected void AddRow0P29( )
      {
         VarsToRow29( bcCEP) ;
      }

      protected void ReadRow0P29( )
      {
         RowToVars29( bcCEP, 1) ;
      }

      protected void InitializeNonKey0P29( )
      {
         A179CEP = "";
         n179CEP = false;
         Z179CEP = "";
      }

      protected void InitAll0P29( )
      {
         A178CEPId = 0;
         InitializeNonKey0P29( ) ;
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

      public void VarsToRow29( SdtCEP obj29 )
      {
         obj29.gxTpr_Mode = Gx_mode;
         obj29.gxTpr_Cep = A179CEP;
         obj29.gxTpr_Cepid = A178CEPId;
         obj29.gxTpr_Cepid_Z = Z178CEPId;
         obj29.gxTpr_Cep_Z = Z179CEP;
         obj29.gxTpr_Cep_N = (short)(Convert.ToInt16(n179CEP));
         obj29.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow29( SdtCEP obj29 )
      {
         obj29.gxTpr_Cepid = A178CEPId;
         return  ;
      }

      public void RowToVars29( SdtCEP obj29 ,
                               int forceLoad )
      {
         Gx_mode = obj29.gxTpr_Mode;
         A179CEP = obj29.gxTpr_Cep;
         n179CEP = false;
         A178CEPId = obj29.gxTpr_Cepid;
         Z178CEPId = obj29.gxTpr_Cepid_Z;
         Z179CEP = obj29.gxTpr_Cep_Z;
         n179CEP = (bool)(Convert.ToBoolean(obj29.gxTpr_Cep_N));
         Gx_mode = obj29.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A178CEPId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0P29( ) ;
         ScanKeyStart0P29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z178CEPId = A178CEPId;
         }
         ZM0P29( -1) ;
         OnLoadActions0P29( ) ;
         AddRow0P29( ) ;
         ScanKeyEnd0P29( ) ;
         if ( RcdFound29 == 0 )
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
         RowToVars29( bcCEP, 0) ;
         ScanKeyStart0P29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z178CEPId = A178CEPId;
         }
         ZM0P29( -1) ;
         OnLoadActions0P29( ) ;
         AddRow0P29( ) ;
         ScanKeyEnd0P29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0P29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0P29( ) ;
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( A178CEPId != Z178CEPId )
               {
                  A178CEPId = Z178CEPId;
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
                  Update0P29( ) ;
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
                  if ( A178CEPId != Z178CEPId )
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
                        Insert0P29( ) ;
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
                        Insert0P29( ) ;
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
         RowToVars29( bcCEP, 1) ;
         SaveImpl( ) ;
         VarsToRow29( bcCEP) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars29( bcCEP, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0P29( ) ;
         AfterTrn( ) ;
         VarsToRow29( bcCEP) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow29( bcCEP) ;
         }
         else
         {
            SdtCEP auxBC = new SdtCEP(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A178CEPId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCEP);
               auxBC.Save();
               bcCEP.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars29( bcCEP, 1) ;
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
         RowToVars29( bcCEP, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0P29( ) ;
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
               VarsToRow29( bcCEP) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow29( bcCEP) ;
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
         RowToVars29( bcCEP, 0) ;
         GetKey0P29( ) ;
         if ( RcdFound29 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A178CEPId != Z178CEPId )
            {
               A178CEPId = Z178CEPId;
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
            if ( A178CEPId != Z178CEPId )
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
         context.RollbackDataStores("cep_bc",pr_default);
         VarsToRow29( bcCEP) ;
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
         Gx_mode = bcCEP.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCEP.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCEP )
         {
            bcCEP = (SdtCEP)(sdt);
            if ( StringUtil.StrCmp(bcCEP.gxTpr_Mode, "") == 0 )
            {
               bcCEP.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow29( bcCEP) ;
            }
            else
            {
               RowToVars29( bcCEP, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCEP.gxTpr_Mode, "") == 0 )
            {
               bcCEP.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars29( bcCEP, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCEP CEP_BC
      {
         get {
            return bcCEP ;
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
         Z179CEP = "";
         A179CEP = "";
         BC000P4_A178CEPId = new int[1] ;
         BC000P4_A179CEP = new string[] {""} ;
         BC000P4_n179CEP = new bool[] {false} ;
         BC000P5_A178CEPId = new int[1] ;
         BC000P3_A178CEPId = new int[1] ;
         BC000P3_A179CEP = new string[] {""} ;
         BC000P3_n179CEP = new bool[] {false} ;
         sMode29 = "";
         BC000P2_A178CEPId = new int[1] ;
         BC000P2_A179CEP = new string[] {""} ;
         BC000P2_n179CEP = new bool[] {false} ;
         BC000P9_A178CEPId = new int[1] ;
         BC000P9_A179CEP = new string[] {""} ;
         BC000P9_n179CEP = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cep_bc__default(),
            new Object[][] {
                new Object[] {
               BC000P2_A178CEPId, BC000P2_A179CEP, BC000P2_n179CEP
               }
               , new Object[] {
               BC000P3_A178CEPId, BC000P3_A179CEP, BC000P3_n179CEP
               }
               , new Object[] {
               BC000P4_A178CEPId, BC000P4_A179CEP, BC000P4_n179CEP
               }
               , new Object[] {
               BC000P5_A178CEPId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000P9_A178CEPId, BC000P9_A179CEP, BC000P9_n179CEP
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound29 ;
      private int trnEnded ;
      private int Z178CEPId ;
      private int A178CEPId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode29 ;
      private bool n179CEP ;
      private string Z179CEP ;
      private string A179CEP ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000P4_A178CEPId ;
      private string[] BC000P4_A179CEP ;
      private bool[] BC000P4_n179CEP ;
      private int[] BC000P5_A178CEPId ;
      private int[] BC000P3_A178CEPId ;
      private string[] BC000P3_A179CEP ;
      private bool[] BC000P3_n179CEP ;
      private int[] BC000P2_A178CEPId ;
      private string[] BC000P2_A179CEP ;
      private bool[] BC000P2_n179CEP ;
      private int[] BC000P9_A178CEPId ;
      private string[] BC000P9_A179CEP ;
      private bool[] BC000P9_n179CEP ;
      private SdtCEP bcCEP ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class cep_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000P2;
          prmBC000P2 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          Object[] prmBC000P3;
          prmBC000P3 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          Object[] prmBC000P4;
          prmBC000P4 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          Object[] prmBC000P5;
          prmBC000P5 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          Object[] prmBC000P6;
          prmBC000P6 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0) ,
          new ParDef("CEP",GXType.VarChar,8,0){Nullable=true}
          };
          Object[] prmBC000P7;
          prmBC000P7 = new Object[] {
          new ParDef("CEP",GXType.VarChar,8,0){Nullable=true} ,
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          Object[] prmBC000P8;
          prmBC000P8 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          Object[] prmBC000P9;
          prmBC000P9 = new Object[] {
          new ParDef("CEPId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000P2", "SELECT CEPId, CEP FROM CEP WHERE CEPId = :CEPId  FOR UPDATE OF CEP",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000P3", "SELECT CEPId, CEP FROM CEP WHERE CEPId = :CEPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000P4", "SELECT TM1.CEPId, TM1.CEP FROM CEP TM1 WHERE TM1.CEPId = :CEPId ORDER BY TM1.CEPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000P5", "SELECT CEPId FROM CEP WHERE CEPId = :CEPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000P6", "SAVEPOINT gxupdate;INSERT INTO CEP(CEPId, CEP) VALUES(:CEPId, :CEP);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000P6)
             ,new CursorDef("BC000P7", "SAVEPOINT gxupdate;UPDATE CEP SET CEP=:CEP  WHERE CEPId = :CEPId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000P7)
             ,new CursorDef("BC000P8", "SAVEPOINT gxupdate;DELETE FROM CEP  WHERE CEPId = :CEPId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000P8)
             ,new CursorDef("BC000P9", "SELECT TM1.CEPId, TM1.CEP FROM CEP TM1 WHERE TM1.CEPId = :CEPId ORDER BY TM1.CEPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000P9,100, GxCacheFrequency.OFF ,true,false )
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
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
