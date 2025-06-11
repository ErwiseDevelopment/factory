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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secrole_bc : GxSilentTrn, IGxSilentTrn
   {
      public secrole_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrole_bc( IGxContext context )
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
         ReadRow0H21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H21( ) ;
         standaloneModal( ) ;
         AddRow0H21( ) ;
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
            E110H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z131SecRoleId = A131SecRoleId;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H21( ) ;
            }
            else
            {
               CheckExtendedTable0H21( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0H21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0H21( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z140SecRoleName = A140SecRoleName;
            Z139SecRoleDescription = A139SecRoleDescription;
            Z646SecRoleActive = A646SecRoleActive;
         }
         if ( GX_JID == -1 )
         {
            Z131SecRoleId = A131SecRoleId;
            Z140SecRoleName = A140SecRoleName;
            Z139SecRoleDescription = A139SecRoleDescription;
            Z646SecRoleActive = A646SecRoleActive;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0H21( )
      {
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            A140SecRoleName = BC000H4_A140SecRoleName[0];
            A139SecRoleDescription = BC000H4_A139SecRoleDescription[0];
            A646SecRoleActive = BC000H4_A646SecRoleActive[0];
            n646SecRoleActive = BC000H4_n646SecRoleActive[0];
            ZM0H21( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0H21( ) ;
      }

      protected void OnLoadActions0H21( )
      {
      }

      protected void CheckExtendedTable0H21( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0H21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H21( )
      {
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H21( 1) ;
            RcdFound21 = 1;
            A131SecRoleId = BC000H3_A131SecRoleId[0];
            A140SecRoleName = BC000H3_A140SecRoleName[0];
            A139SecRoleDescription = BC000H3_A139SecRoleDescription[0];
            A646SecRoleActive = BC000H3_A646SecRoleActive[0];
            n646SecRoleActive = BC000H3_n646SecRoleActive[0];
            Z131SecRoleId = A131SecRoleId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0H21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0H21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H21( ) ;
         if ( RcdFound21 == 0 )
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
         CONFIRM_0H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0H21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z140SecRoleName, BC000H2_A140SecRoleName[0]) != 0 ) || ( StringUtil.StrCmp(Z139SecRoleDescription, BC000H2_A139SecRoleDescription[0]) != 0 ) || ( Z646SecRoleActive != BC000H2_A646SecRoleActive[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H21( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H21( 0) ;
            CheckOptimisticConcurrency0H21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H6 */
                     pr_default.execute(4, new Object[] {A140SecRoleName, A139SecRoleDescription, n646SecRoleActive, A646SecRoleActive});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000H7 */
                     pr_default.execute(5);
                     A131SecRoleId = BC000H7_A131SecRoleId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("SecRole");
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
               Load0H21( ) ;
            }
            EndLevel0H21( ) ;
         }
         CloseExtendedTableCursors0H21( ) ;
      }

      protected void Update0H21( )
      {
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H8 */
                     pr_default.execute(6, new Object[] {A140SecRoleName, A139SecRoleDescription, n646SecRoleActive, A646SecRoleActive, A131SecRoleId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecRole");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H21( ) ;
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
            EndLevel0H21( ) ;
         }
         CloseExtendedTableCursors0H21( ) ;
      }

      protected void DeferredUpdate0H21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H21( ) ;
            AfterConfirm0H21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H9 */
                  pr_default.execute(7, new Object[] {A131SecRoleId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("SecRole");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0H21( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000H10 */
            pr_default.execute(8, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000H11 */
            pr_default.execute(9, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionality Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0H21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H21( ) ;
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

      public void ScanKeyStart0H21( )
      {
         /* Scan By routine */
         /* Using cursor BC000H12 */
         pr_default.execute(10, new Object[] {A131SecRoleId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound21 = 1;
            A131SecRoleId = BC000H12_A131SecRoleId[0];
            A140SecRoleName = BC000H12_A140SecRoleName[0];
            A139SecRoleDescription = BC000H12_A139SecRoleDescription[0];
            A646SecRoleActive = BC000H12_A646SecRoleActive[0];
            n646SecRoleActive = BC000H12_n646SecRoleActive[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H21( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound21 = 0;
         ScanKeyLoad0H21( ) ;
      }

      protected void ScanKeyLoad0H21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound21 = 1;
            A131SecRoleId = BC000H12_A131SecRoleId[0];
            A140SecRoleName = BC000H12_A140SecRoleName[0];
            A139SecRoleDescription = BC000H12_A139SecRoleDescription[0];
            A646SecRoleActive = BC000H12_A646SecRoleActive[0];
            n646SecRoleActive = BC000H12_n646SecRoleActive[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0H21( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0H21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H21( )
      {
      }

      protected void send_integrity_lvl_hashes0H21( )
      {
      }

      protected void AddRow0H21( )
      {
         VarsToRow21( bcwwpbaseobjects_SecRole) ;
      }

      protected void ReadRow0H21( )
      {
         RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
      }

      protected void InitializeNonKey0H21( )
      {
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         A646SecRoleActive = false;
         n646SecRoleActive = false;
         Z140SecRoleName = "";
         Z139SecRoleDescription = "";
         Z646SecRoleActive = false;
      }

      protected void InitAll0H21( )
      {
         A131SecRoleId = 0;
         InitializeNonKey0H21( ) ;
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

      public void VarsToRow21( GeneXus.Programs.wwpbaseobjects.SdtSecRole obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Secrolename = A140SecRoleName;
         obj21.gxTpr_Secroledescription = A139SecRoleDescription;
         obj21.gxTpr_Secroleactive = A646SecRoleActive;
         obj21.gxTpr_Secroleid = A131SecRoleId;
         obj21.gxTpr_Secroleid_Z = Z131SecRoleId;
         obj21.gxTpr_Secrolename_Z = Z140SecRoleName;
         obj21.gxTpr_Secroledescription_Z = Z139SecRoleDescription;
         obj21.gxTpr_Secroleactive_Z = Z646SecRoleActive;
         obj21.gxTpr_Secroleactive_N = (short)(Convert.ToInt16(n646SecRoleActive));
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( GeneXus.Programs.wwpbaseobjects.SdtSecRole obj21 )
      {
         obj21.gxTpr_Secroleid = A131SecRoleId;
         return  ;
      }

      public void RowToVars21( GeneXus.Programs.wwpbaseobjects.SdtSecRole obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A140SecRoleName = obj21.gxTpr_Secrolename;
         A139SecRoleDescription = obj21.gxTpr_Secroledescription;
         A646SecRoleActive = obj21.gxTpr_Secroleactive;
         n646SecRoleActive = false;
         A131SecRoleId = obj21.gxTpr_Secroleid;
         Z131SecRoleId = obj21.gxTpr_Secroleid_Z;
         Z140SecRoleName = obj21.gxTpr_Secrolename_Z;
         Z139SecRoleDescription = obj21.gxTpr_Secroledescription_Z;
         Z646SecRoleActive = obj21.gxTpr_Secroleactive_Z;
         n646SecRoleActive = (bool)(Convert.ToBoolean(obj21.gxTpr_Secroleactive_N));
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A131SecRoleId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H21( ) ;
         ScanKeyStart0H21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z131SecRoleId = A131SecRoleId;
         }
         ZM0H21( -1) ;
         OnLoadActions0H21( ) ;
         AddRow0H21( ) ;
         ScanKeyEnd0H21( ) ;
         if ( RcdFound21 == 0 )
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
         RowToVars21( bcwwpbaseobjects_SecRole, 0) ;
         ScanKeyStart0H21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z131SecRoleId = A131SecRoleId;
         }
         ZM0H21( -1) ;
         OnLoadActions0H21( ) ;
         AddRow0H21( ) ;
         ScanKeyEnd0H21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0H21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A131SecRoleId != Z131SecRoleId )
               {
                  A131SecRoleId = Z131SecRoleId;
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
                  Update0H21( ) ;
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
                  if ( A131SecRoleId != Z131SecRoleId )
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
                        Insert0H21( ) ;
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
                        Insert0H21( ) ;
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
         RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bcwwpbaseobjects_SecRole) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bcwwpbaseobjects_SecRole) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow21( bcwwpbaseobjects_SecRole) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecRole auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecRole(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A131SecRoleId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecRole);
               auxBC.Save();
               bcwwpbaseobjects_SecRole.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
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
         RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H21( ) ;
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
               VarsToRow21( bcwwpbaseobjects_SecRole) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow21( bcwwpbaseobjects_SecRole) ;
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
         RowToVars21( bcwwpbaseobjects_SecRole, 0) ;
         GetKey0H21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A131SecRoleId != Z131SecRoleId )
            {
               A131SecRoleId = Z131SecRoleId;
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
            if ( A131SecRoleId != Z131SecRoleId )
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
         context.RollbackDataStores("wwpbaseobjects.secrole_bc",pr_default);
         VarsToRow21( bcwwpbaseobjects_SecRole) ;
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
         Gx_mode = bcwwpbaseobjects_SecRole.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecRole.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecRole )
         {
            bcwwpbaseobjects_SecRole = (GeneXus.Programs.wwpbaseobjects.SdtSecRole)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecRole.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bcwwpbaseobjects_SecRole) ;
            }
            else
            {
               RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecRole.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bcwwpbaseobjects_SecRole, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecRole SecRole_BC
      {
         get {
            return bcwwpbaseobjects_SecRole ;
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
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z140SecRoleName = "";
         A140SecRoleName = "";
         Z139SecRoleDescription = "";
         A139SecRoleDescription = "";
         BC000H4_A131SecRoleId = new short[1] ;
         BC000H4_A140SecRoleName = new string[] {""} ;
         BC000H4_A139SecRoleDescription = new string[] {""} ;
         BC000H4_A646SecRoleActive = new bool[] {false} ;
         BC000H4_n646SecRoleActive = new bool[] {false} ;
         BC000H5_A131SecRoleId = new short[1] ;
         BC000H3_A131SecRoleId = new short[1] ;
         BC000H3_A140SecRoleName = new string[] {""} ;
         BC000H3_A139SecRoleDescription = new string[] {""} ;
         BC000H3_A646SecRoleActive = new bool[] {false} ;
         BC000H3_n646SecRoleActive = new bool[] {false} ;
         sMode21 = "";
         BC000H2_A131SecRoleId = new short[1] ;
         BC000H2_A140SecRoleName = new string[] {""} ;
         BC000H2_A139SecRoleDescription = new string[] {""} ;
         BC000H2_A646SecRoleActive = new bool[] {false} ;
         BC000H2_n646SecRoleActive = new bool[] {false} ;
         BC000H7_A131SecRoleId = new short[1] ;
         BC000H10_A133SecUserId = new short[1] ;
         BC000H10_A131SecRoleId = new short[1] ;
         BC000H11_A128SecFunctionalityId = new long[1] ;
         BC000H11_A131SecRoleId = new short[1] ;
         BC000H12_A131SecRoleId = new short[1] ;
         BC000H12_A140SecRoleName = new string[] {""} ;
         BC000H12_A139SecRoleDescription = new string[] {""} ;
         BC000H12_A646SecRoleActive = new bool[] {false} ;
         BC000H12_n646SecRoleActive = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrole_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A131SecRoleId, BC000H2_A140SecRoleName, BC000H2_A139SecRoleDescription, BC000H2_A646SecRoleActive, BC000H2_n646SecRoleActive
               }
               , new Object[] {
               BC000H3_A131SecRoleId, BC000H3_A140SecRoleName, BC000H3_A139SecRoleDescription, BC000H3_A646SecRoleActive, BC000H3_n646SecRoleActive
               }
               , new Object[] {
               BC000H4_A131SecRoleId, BC000H4_A140SecRoleName, BC000H4_A139SecRoleDescription, BC000H4_A646SecRoleActive, BC000H4_n646SecRoleActive
               }
               , new Object[] {
               BC000H5_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H7_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H10_A133SecUserId, BC000H10_A131SecRoleId
               }
               , new Object[] {
               BC000H11_A128SecFunctionalityId, BC000H11_A131SecRoleId
               }
               , new Object[] {
               BC000H12_A131SecRoleId, BC000H12_A140SecRoleName, BC000H12_A139SecRoleDescription, BC000H12_A646SecRoleActive, BC000H12_n646SecRoleActive
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120H2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z131SecRoleId ;
      private short A131SecRoleId ;
      private short RcdFound21 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode21 ;
      private bool returnInSub ;
      private bool Z646SecRoleActive ;
      private bool A646SecRoleActive ;
      private bool n646SecRoleActive ;
      private string Z140SecRoleName ;
      private string A140SecRoleName ;
      private string Z139SecRoleDescription ;
      private string A139SecRoleDescription ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000H4_A131SecRoleId ;
      private string[] BC000H4_A140SecRoleName ;
      private string[] BC000H4_A139SecRoleDescription ;
      private bool[] BC000H4_A646SecRoleActive ;
      private bool[] BC000H4_n646SecRoleActive ;
      private short[] BC000H5_A131SecRoleId ;
      private short[] BC000H3_A131SecRoleId ;
      private string[] BC000H3_A140SecRoleName ;
      private string[] BC000H3_A139SecRoleDescription ;
      private bool[] BC000H3_A646SecRoleActive ;
      private bool[] BC000H3_n646SecRoleActive ;
      private short[] BC000H2_A131SecRoleId ;
      private string[] BC000H2_A140SecRoleName ;
      private string[] BC000H2_A139SecRoleDescription ;
      private bool[] BC000H2_A646SecRoleActive ;
      private bool[] BC000H2_n646SecRoleActive ;
      private short[] BC000H7_A131SecRoleId ;
      private short[] BC000H10_A133SecUserId ;
      private short[] BC000H10_A131SecRoleId ;
      private long[] BC000H11_A128SecFunctionalityId ;
      private short[] BC000H11_A131SecRoleId ;
      private short[] BC000H12_A131SecRoleId ;
      private string[] BC000H12_A140SecRoleName ;
      private string[] BC000H12_A139SecRoleDescription ;
      private bool[] BC000H12_A646SecRoleActive ;
      private bool[] BC000H12_n646SecRoleActive ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecRole bcwwpbaseobjects_SecRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secrole_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000H2;
          prmBC000H2 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H3;
          prmBC000H3 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H4;
          prmBC000H4 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H5;
          prmBC000H5 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H6;
          prmBC000H6 = new Object[] {
          new ParDef("SecRoleName",GXType.VarChar,40,0) ,
          new ParDef("SecRoleDescription",GXType.VarChar,120,0) ,
          new ParDef("SecRoleActive",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmBC000H7;
          prmBC000H7 = new Object[] {
          };
          Object[] prmBC000H8;
          prmBC000H8 = new Object[] {
          new ParDef("SecRoleName",GXType.VarChar,40,0) ,
          new ParDef("SecRoleDescription",GXType.VarChar,120,0) ,
          new ParDef("SecRoleActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H9;
          prmBC000H9 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H10;
          prmBC000H10 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H11;
          prmBC000H11 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000H12;
          prmBC000H12 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000H2", "SELECT SecRoleId, SecRoleName, SecRoleDescription, SecRoleActive FROM SecRole WHERE SecRoleId = :SecRoleId  FOR UPDATE OF SecRole",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H3", "SELECT SecRoleId, SecRoleName, SecRoleDescription, SecRoleActive FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H4", "SELECT TM1.SecRoleId, TM1.SecRoleName, TM1.SecRoleDescription, TM1.SecRoleActive FROM SecRole TM1 WHERE TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H5", "SELECT SecRoleId FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H6", "SAVEPOINT gxupdate;INSERT INTO SecRole(SecRoleName, SecRoleDescription, SecRoleActive) VALUES(:SecRoleName, :SecRoleDescription, :SecRoleActive);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000H6)
             ,new CursorDef("BC000H7", "SELECT currval('SecRoleId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H8", "SAVEPOINT gxupdate;UPDATE SecRole SET SecRoleName=:SecRoleName, SecRoleDescription=:SecRoleDescription, SecRoleActive=:SecRoleActive  WHERE SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H8)
             ,new CursorDef("BC000H9", "SAVEPOINT gxupdate;DELETE FROM SecRole  WHERE SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H9)
             ,new CursorDef("BC000H10", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000H11", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000H12", "SELECT TM1.SecRoleId, TM1.SecRoleName, TM1.SecRoleDescription, TM1.SecRoleActive FROM SecRole TM1 WHERE TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H12,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
