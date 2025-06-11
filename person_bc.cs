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
   public class person_bc : GxSilentTrn, IGxSilentTrn
   {
      public person_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public person_bc( IGxContext context )
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
         ReadRow0K24( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0K24( ) ;
         standaloneModal( ) ;
         AddRow0K24( ) ;
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
               Z151PersonID = A151PersonID;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K24( ) ;
            }
            else
            {
               CheckExtendedTable0K24( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0K24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0K24( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z151PersonID = A151PersonID;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0K24( )
      {
         /* Using cursor BC000K4 */
         pr_default.execute(2, new Object[] {A151PersonID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound24 = 1;
            ZM0K24( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0K24( ) ;
      }

      protected void OnLoadActions0K24( )
      {
      }

      protected void CheckExtendedTable0K24( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0K24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K24( )
      {
         /* Using cursor BC000K5 */
         pr_default.execute(3, new Object[] {A151PersonID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000K3 */
         pr_default.execute(1, new Object[] {A151PersonID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K24( 1) ;
            RcdFound24 = 1;
            A151PersonID = BC000K3_A151PersonID[0];
            Z151PersonID = A151PersonID;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0K24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0K24( ) ;
            }
            Gx_mode = sMode24;
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0K24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode24;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K24( ) ;
         if ( RcdFound24 == 0 )
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
         CONFIRM_0K0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0K24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000K2 */
            pr_default.execute(0, new Object[] {A151PersonID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Person"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Person"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K24( )
      {
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K24( 0) ;
            CheckOptimisticConcurrency0K24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K6 */
                     pr_default.execute(4);
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000K7 */
                     pr_default.execute(5);
                     A151PersonID = BC000K7_A151PersonID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Person");
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
               Load0K24( ) ;
            }
            EndLevel0K24( ) ;
         }
         CloseExtendedTableCursors0K24( ) ;
      }

      protected void Update0K24( )
      {
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Person */
                     DeferredUpdate0K24( ) ;
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
            EndLevel0K24( ) ;
         }
         CloseExtendedTableCursors0K24( ) ;
      }

      protected void DeferredUpdate0K24( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0K24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K24( ) ;
            AfterConfirm0K24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000K8 */
                  pr_default.execute(6, new Object[] {A151PersonID});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Person");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0K24( ) ;
         Gx_mode = sMode24;
      }

      protected void OnDeleteControls0K24( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0K24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K24( ) ;
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

      public void ScanKeyStart0K24( )
      {
         /* Using cursor BC000K9 */
         pr_default.execute(7, new Object[] {A151PersonID});
         RcdFound24 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound24 = 1;
            A151PersonID = BC000K9_A151PersonID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0K24( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound24 = 0;
         ScanKeyLoad0K24( ) ;
      }

      protected void ScanKeyLoad0K24( )
      {
         sMode24 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound24 = 1;
            A151PersonID = BC000K9_A151PersonID[0];
         }
         Gx_mode = sMode24;
      }

      protected void ScanKeyEnd0K24( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0K24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K24( )
      {
      }

      protected void send_integrity_lvl_hashes0K24( )
      {
      }

      protected void AddRow0K24( )
      {
         VarsToRow24( bcPerson) ;
      }

      protected void ReadRow0K24( )
      {
         RowToVars24( bcPerson, 1) ;
      }

      protected void InitializeNonKey0K24( )
      {
      }

      protected void InitAll0K24( )
      {
         A151PersonID = 0;
         InitializeNonKey0K24( ) ;
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

      public void VarsToRow24( SdtPerson obj24 )
      {
         obj24.gxTpr_Mode = Gx_mode;
         obj24.gxTpr_Personid = A151PersonID;
         obj24.gxTpr_Personid_Z = Z151PersonID;
         obj24.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow24( SdtPerson obj24 )
      {
         obj24.gxTpr_Personid = A151PersonID;
         return  ;
      }

      public void RowToVars24( SdtPerson obj24 ,
                               int forceLoad )
      {
         Gx_mode = obj24.gxTpr_Mode;
         A151PersonID = obj24.gxTpr_Personid;
         Z151PersonID = obj24.gxTpr_Personid_Z;
         Gx_mode = obj24.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A151PersonID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0K24( ) ;
         ScanKeyStart0K24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z151PersonID = A151PersonID;
         }
         ZM0K24( -1) ;
         OnLoadActions0K24( ) ;
         AddRow0K24( ) ;
         ScanKeyEnd0K24( ) ;
         if ( RcdFound24 == 0 )
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
         RowToVars24( bcPerson, 0) ;
         ScanKeyStart0K24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z151PersonID = A151PersonID;
         }
         ZM0K24( -1) ;
         OnLoadActions0K24( ) ;
         AddRow0K24( ) ;
         ScanKeyEnd0K24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0K24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0K24( ) ;
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A151PersonID != Z151PersonID )
               {
                  A151PersonID = Z151PersonID;
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
                  Update0K24( ) ;
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
                  if ( A151PersonID != Z151PersonID )
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
                        Insert0K24( ) ;
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
                        Insert0K24( ) ;
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
         RowToVars24( bcPerson, 1) ;
         SaveImpl( ) ;
         VarsToRow24( bcPerson) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars24( bcPerson, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K24( ) ;
         AfterTrn( ) ;
         VarsToRow24( bcPerson) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow24( bcPerson) ;
         }
         else
         {
            SdtPerson auxBC = new SdtPerson(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A151PersonID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPerson);
               auxBC.Save();
               bcPerson.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars24( bcPerson, 1) ;
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
         RowToVars24( bcPerson, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K24( ) ;
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
               VarsToRow24( bcPerson) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow24( bcPerson) ;
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
         RowToVars24( bcPerson, 0) ;
         GetKey0K24( ) ;
         if ( RcdFound24 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A151PersonID != Z151PersonID )
            {
               A151PersonID = Z151PersonID;
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
            if ( A151PersonID != Z151PersonID )
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
         context.RollbackDataStores("person_bc",pr_default);
         VarsToRow24( bcPerson) ;
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
         Gx_mode = bcPerson.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPerson.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPerson )
         {
            bcPerson = (SdtPerson)(sdt);
            if ( StringUtil.StrCmp(bcPerson.gxTpr_Mode, "") == 0 )
            {
               bcPerson.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow24( bcPerson) ;
            }
            else
            {
               RowToVars24( bcPerson, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPerson.gxTpr_Mode, "") == 0 )
            {
               bcPerson.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars24( bcPerson, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPerson Person_BC
      {
         get {
            return bcPerson ;
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
         BC000K4_A151PersonID = new int[1] ;
         BC000K5_A151PersonID = new int[1] ;
         BC000K3_A151PersonID = new int[1] ;
         sMode24 = "";
         BC000K2_A151PersonID = new int[1] ;
         BC000K7_A151PersonID = new int[1] ;
         BC000K9_A151PersonID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.person_bc__default(),
            new Object[][] {
                new Object[] {
               BC000K2_A151PersonID
               }
               , new Object[] {
               BC000K3_A151PersonID
               }
               , new Object[] {
               BC000K4_A151PersonID
               }
               , new Object[] {
               BC000K5_A151PersonID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K7_A151PersonID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K9_A151PersonID
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound24 ;
      private int trnEnded ;
      private int Z151PersonID ;
      private int A151PersonID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode24 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000K4_A151PersonID ;
      private int[] BC000K5_A151PersonID ;
      private int[] BC000K3_A151PersonID ;
      private int[] BC000K2_A151PersonID ;
      private int[] BC000K7_A151PersonID ;
      private int[] BC000K9_A151PersonID ;
      private SdtPerson bcPerson ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class person_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000K2;
          prmBC000K2 = new Object[] {
          new ParDef("PersonID",GXType.Int32,9,0)
          };
          Object[] prmBC000K3;
          prmBC000K3 = new Object[] {
          new ParDef("PersonID",GXType.Int32,9,0)
          };
          Object[] prmBC000K4;
          prmBC000K4 = new Object[] {
          new ParDef("PersonID",GXType.Int32,9,0)
          };
          Object[] prmBC000K5;
          prmBC000K5 = new Object[] {
          new ParDef("PersonID",GXType.Int32,9,0)
          };
          Object[] prmBC000K6;
          prmBC000K6 = new Object[] {
          };
          Object[] prmBC000K7;
          prmBC000K7 = new Object[] {
          };
          Object[] prmBC000K8;
          prmBC000K8 = new Object[] {
          new ParDef("PersonID",GXType.Int32,9,0)
          };
          Object[] prmBC000K9;
          prmBC000K9 = new Object[] {
          new ParDef("PersonID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000K2", "SELECT PersonID FROM Person WHERE PersonID = :PersonID  FOR UPDATE OF Person",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000K3", "SELECT PersonID FROM Person WHERE PersonID = :PersonID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000K4", "SELECT TM1.PersonID FROM Person TM1 WHERE TM1.PersonID = :PersonID ORDER BY TM1.PersonID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000K5", "SELECT PersonID FROM Person WHERE PersonID = :PersonID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000K6", "SAVEPOINT gxupdate;INSERT INTO Person VALUES (DEFAULT);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000K6)
             ,new CursorDef("BC000K7", "SELECT currval('PersonID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000K8", "SAVEPOINT gxupdate;DELETE FROM Person  WHERE PersonID = :PersonID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000K8)
             ,new CursorDef("BC000K9", "SELECT TM1.PersonID FROM Person TM1 WHERE TM1.PersonID = :PersonID ORDER BY TM1.PersonID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K9,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
