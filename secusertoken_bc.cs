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
   public class secusertoken_bc : GxSilentTrn, IGxSilentTrn
   {
      public secusertoken_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secusertoken_bc( IGxContext context )
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
         ReadRow0N27( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0N27( ) ;
         standaloneModal( ) ;
         AddRow0N27( ) ;
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
               Z164SecUserTokenID = A164SecUserTokenID;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N27( ) ;
            }
            else
            {
               CheckExtendedTable0N27( ) ;
               if ( AnyError == 0 )
               {
                  ZM0N27( 3) ;
               }
               CloseExtendedTableCursors0N27( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0N27( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z166SecUserTokenDateTime = A166SecUserTokenDateTime;
            Z167SecUserTokenUsed = A167SecUserTokenUsed;
            Z133SecUserId = A133SecUserId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z164SecUserTokenID = A164SecUserTokenID;
            Z165SecUserTokenKey = A165SecUserTokenKey;
            Z166SecUserTokenDateTime = A166SecUserTokenDateTime;
            Z167SecUserTokenUsed = A167SecUserTokenUsed;
            Z133SecUserId = A133SecUserId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A167SecUserTokenUsed) && ( Gx_BScreen == 0 ) )
         {
            A167SecUserTokenUsed = false;
            n167SecUserTokenUsed = false;
         }
      }

      protected void Load0N27( )
      {
         /* Using cursor BC000N5 */
         pr_default.execute(3, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
            A165SecUserTokenKey = BC000N5_A165SecUserTokenKey[0];
            n165SecUserTokenKey = BC000N5_n165SecUserTokenKey[0];
            A166SecUserTokenDateTime = BC000N5_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = BC000N5_n166SecUserTokenDateTime[0];
            A167SecUserTokenUsed = BC000N5_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = BC000N5_n167SecUserTokenUsed[0];
            A133SecUserId = BC000N5_A133SecUserId[0];
            n133SecUserId = BC000N5_n133SecUserId[0];
            ZM0N27( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0N27( ) ;
      }

      protected void OnLoadActions0N27( )
      {
      }

      protected void CheckExtendedTable0N27( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000N4 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0N27( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N27( )
      {
         /* Using cursor BC000N6 */
         pr_default.execute(4, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000N3 */
         pr_default.execute(1, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N27( 2) ;
            RcdFound27 = 1;
            A164SecUserTokenID = BC000N3_A164SecUserTokenID[0];
            A165SecUserTokenKey = BC000N3_A165SecUserTokenKey[0];
            n165SecUserTokenKey = BC000N3_n165SecUserTokenKey[0];
            A166SecUserTokenDateTime = BC000N3_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = BC000N3_n166SecUserTokenDateTime[0];
            A167SecUserTokenUsed = BC000N3_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = BC000N3_n167SecUserTokenUsed[0];
            A133SecUserId = BC000N3_A133SecUserId[0];
            n133SecUserId = BC000N3_n133SecUserId[0];
            Z164SecUserTokenID = A164SecUserTokenID;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0N27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0N27( ) ;
            }
            Gx_mode = sMode27;
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0N27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode27;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N27( ) ;
         if ( RcdFound27 == 0 )
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
         CONFIRM_0N0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0N27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N2 */
            pr_default.execute(0, new Object[] {A164SecUserTokenID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserToken"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z166SecUserTokenDateTime != BC000N2_A166SecUserTokenDateTime[0] ) || ( Z167SecUserTokenUsed != BC000N2_A167SecUserTokenUsed[0] ) || ( Z133SecUserId != BC000N2_A133SecUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserToken"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N27( )
      {
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N27( 0) ;
            CheckOptimisticConcurrency0N27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N7 */
                     pr_default.execute(5, new Object[] {n165SecUserTokenKey, A165SecUserTokenKey, n166SecUserTokenDateTime, A166SecUserTokenDateTime, n167SecUserTokenUsed, A167SecUserTokenUsed, n133SecUserId, A133SecUserId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000N8 */
                     pr_default.execute(6);
                     A164SecUserTokenID = BC000N8_A164SecUserTokenID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserToken");
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
               Load0N27( ) ;
            }
            EndLevel0N27( ) ;
         }
         CloseExtendedTableCursors0N27( ) ;
      }

      protected void Update0N27( )
      {
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N9 */
                     pr_default.execute(7, new Object[] {n165SecUserTokenKey, A165SecUserTokenKey, n166SecUserTokenDateTime, A166SecUserTokenDateTime, n167SecUserTokenUsed, A167SecUserTokenUsed, n133SecUserId, A133SecUserId, A164SecUserTokenID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserToken");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserToken"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N27( ) ;
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
            EndLevel0N27( ) ;
         }
         CloseExtendedTableCursors0N27( ) ;
      }

      protected void DeferredUpdate0N27( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N27( ) ;
            AfterConfirm0N27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000N10 */
                  pr_default.execute(8, new Object[] {A164SecUserTokenID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserToken");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N27( ) ;
         Gx_mode = sMode27;
      }

      protected void OnDeleteControls0N27( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N27( ) ;
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

      public void ScanKeyStart0N27( )
      {
         /* Using cursor BC000N11 */
         pr_default.execute(9, new Object[] {A164SecUserTokenID});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound27 = 1;
            A164SecUserTokenID = BC000N11_A164SecUserTokenID[0];
            A165SecUserTokenKey = BC000N11_A165SecUserTokenKey[0];
            n165SecUserTokenKey = BC000N11_n165SecUserTokenKey[0];
            A166SecUserTokenDateTime = BC000N11_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = BC000N11_n166SecUserTokenDateTime[0];
            A167SecUserTokenUsed = BC000N11_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = BC000N11_n167SecUserTokenUsed[0];
            A133SecUserId = BC000N11_A133SecUserId[0];
            n133SecUserId = BC000N11_n133SecUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N27( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound27 = 0;
         ScanKeyLoad0N27( ) ;
      }

      protected void ScanKeyLoad0N27( )
      {
         sMode27 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound27 = 1;
            A164SecUserTokenID = BC000N11_A164SecUserTokenID[0];
            A165SecUserTokenKey = BC000N11_A165SecUserTokenKey[0];
            n165SecUserTokenKey = BC000N11_n165SecUserTokenKey[0];
            A166SecUserTokenDateTime = BC000N11_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = BC000N11_n166SecUserTokenDateTime[0];
            A167SecUserTokenUsed = BC000N11_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = BC000N11_n167SecUserTokenUsed[0];
            A133SecUserId = BC000N11_A133SecUserId[0];
            n133SecUserId = BC000N11_n133SecUserId[0];
         }
         Gx_mode = sMode27;
      }

      protected void ScanKeyEnd0N27( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0N27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N27( )
      {
      }

      protected void send_integrity_lvl_hashes0N27( )
      {
      }

      protected void AddRow0N27( )
      {
         VarsToRow27( bcSecUserToken) ;
      }

      protected void ReadRow0N27( )
      {
         RowToVars27( bcSecUserToken, 1) ;
      }

      protected void InitializeNonKey0N27( )
      {
         A165SecUserTokenKey = "";
         n165SecUserTokenKey = false;
         A166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         n166SecUserTokenDateTime = false;
         A133SecUserId = 0;
         n133SecUserId = false;
         A167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         Z166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         Z167SecUserTokenUsed = false;
         Z133SecUserId = 0;
      }

      protected void InitAll0N27( )
      {
         A164SecUserTokenID = 0;
         InitializeNonKey0N27( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A167SecUserTokenUsed = i167SecUserTokenUsed;
         n167SecUserTokenUsed = false;
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

      public void VarsToRow27( SdtSecUserToken obj27 )
      {
         obj27.gxTpr_Mode = Gx_mode;
         obj27.gxTpr_Secusertokenkey = A165SecUserTokenKey;
         obj27.gxTpr_Secusertokendatetime = A166SecUserTokenDateTime;
         obj27.gxTpr_Secuserid = A133SecUserId;
         obj27.gxTpr_Secusertokenused = A167SecUserTokenUsed;
         obj27.gxTpr_Secusertokenid = A164SecUserTokenID;
         obj27.gxTpr_Secusertokenid_Z = Z164SecUserTokenID;
         obj27.gxTpr_Secusertokendatetime_Z = Z166SecUserTokenDateTime;
         obj27.gxTpr_Secuserid_Z = Z133SecUserId;
         obj27.gxTpr_Secusertokenused_Z = Z167SecUserTokenUsed;
         obj27.gxTpr_Secusertokenkey_N = (short)(Convert.ToInt16(n165SecUserTokenKey));
         obj27.gxTpr_Secusertokendatetime_N = (short)(Convert.ToInt16(n166SecUserTokenDateTime));
         obj27.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj27.gxTpr_Secusertokenused_N = (short)(Convert.ToInt16(n167SecUserTokenUsed));
         obj27.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow27( SdtSecUserToken obj27 )
      {
         obj27.gxTpr_Secusertokenid = A164SecUserTokenID;
         return  ;
      }

      public void RowToVars27( SdtSecUserToken obj27 ,
                               int forceLoad )
      {
         Gx_mode = obj27.gxTpr_Mode;
         A165SecUserTokenKey = obj27.gxTpr_Secusertokenkey;
         n165SecUserTokenKey = false;
         A166SecUserTokenDateTime = obj27.gxTpr_Secusertokendatetime;
         n166SecUserTokenDateTime = false;
         A133SecUserId = obj27.gxTpr_Secuserid;
         n133SecUserId = false;
         A167SecUserTokenUsed = obj27.gxTpr_Secusertokenused;
         n167SecUserTokenUsed = false;
         A164SecUserTokenID = obj27.gxTpr_Secusertokenid;
         Z164SecUserTokenID = obj27.gxTpr_Secusertokenid_Z;
         Z166SecUserTokenDateTime = obj27.gxTpr_Secusertokendatetime_Z;
         Z133SecUserId = obj27.gxTpr_Secuserid_Z;
         Z167SecUserTokenUsed = obj27.gxTpr_Secusertokenused_Z;
         n165SecUserTokenKey = (bool)(Convert.ToBoolean(obj27.gxTpr_Secusertokenkey_N));
         n166SecUserTokenDateTime = (bool)(Convert.ToBoolean(obj27.gxTpr_Secusertokendatetime_N));
         n133SecUserId = (bool)(Convert.ToBoolean(obj27.gxTpr_Secuserid_N));
         n167SecUserTokenUsed = (bool)(Convert.ToBoolean(obj27.gxTpr_Secusertokenused_N));
         Gx_mode = obj27.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A164SecUserTokenID = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0N27( ) ;
         ScanKeyStart0N27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z164SecUserTokenID = A164SecUserTokenID;
         }
         ZM0N27( -2) ;
         OnLoadActions0N27( ) ;
         AddRow0N27( ) ;
         ScanKeyEnd0N27( ) ;
         if ( RcdFound27 == 0 )
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
         RowToVars27( bcSecUserToken, 0) ;
         ScanKeyStart0N27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z164SecUserTokenID = A164SecUserTokenID;
         }
         ZM0N27( -2) ;
         OnLoadActions0N27( ) ;
         AddRow0N27( ) ;
         ScanKeyEnd0N27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0N27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0N27( ) ;
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A164SecUserTokenID != Z164SecUserTokenID )
               {
                  A164SecUserTokenID = Z164SecUserTokenID;
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
                  Update0N27( ) ;
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
                  if ( A164SecUserTokenID != Z164SecUserTokenID )
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
                        Insert0N27( ) ;
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
                        Insert0N27( ) ;
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
         RowToVars27( bcSecUserToken, 1) ;
         SaveImpl( ) ;
         VarsToRow27( bcSecUserToken) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars27( bcSecUserToken, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N27( ) ;
         AfterTrn( ) ;
         VarsToRow27( bcSecUserToken) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow27( bcSecUserToken) ;
         }
         else
         {
            SdtSecUserToken auxBC = new SdtSecUserToken(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A164SecUserTokenID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSecUserToken);
               auxBC.Save();
               bcSecUserToken.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars27( bcSecUserToken, 1) ;
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
         RowToVars27( bcSecUserToken, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N27( ) ;
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
               VarsToRow27( bcSecUserToken) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow27( bcSecUserToken) ;
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
         RowToVars27( bcSecUserToken, 0) ;
         GetKey0N27( ) ;
         if ( RcdFound27 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A164SecUserTokenID != Z164SecUserTokenID )
            {
               A164SecUserTokenID = Z164SecUserTokenID;
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
            if ( A164SecUserTokenID != Z164SecUserTokenID )
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
         context.RollbackDataStores("secusertoken_bc",pr_default);
         VarsToRow27( bcSecUserToken) ;
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
         Gx_mode = bcSecUserToken.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSecUserToken.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSecUserToken )
         {
            bcSecUserToken = (SdtSecUserToken)(sdt);
            if ( StringUtil.StrCmp(bcSecUserToken.gxTpr_Mode, "") == 0 )
            {
               bcSecUserToken.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow27( bcSecUserToken) ;
            }
            else
            {
               RowToVars27( bcSecUserToken, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSecUserToken.gxTpr_Mode, "") == 0 )
            {
               bcSecUserToken.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars27( bcSecUserToken, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUserToken SecUserToken_BC
      {
         get {
            return bcSecUserToken ;
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
         Z166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         A166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         Z165SecUserTokenKey = "";
         A165SecUserTokenKey = "";
         BC000N5_A164SecUserTokenID = new short[1] ;
         BC000N5_A165SecUserTokenKey = new string[] {""} ;
         BC000N5_n165SecUserTokenKey = new bool[] {false} ;
         BC000N5_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000N5_n166SecUserTokenDateTime = new bool[] {false} ;
         BC000N5_A167SecUserTokenUsed = new bool[] {false} ;
         BC000N5_n167SecUserTokenUsed = new bool[] {false} ;
         BC000N5_A133SecUserId = new short[1] ;
         BC000N5_n133SecUserId = new bool[] {false} ;
         BC000N4_A133SecUserId = new short[1] ;
         BC000N4_n133SecUserId = new bool[] {false} ;
         BC000N6_A164SecUserTokenID = new short[1] ;
         BC000N3_A164SecUserTokenID = new short[1] ;
         BC000N3_A165SecUserTokenKey = new string[] {""} ;
         BC000N3_n165SecUserTokenKey = new bool[] {false} ;
         BC000N3_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000N3_n166SecUserTokenDateTime = new bool[] {false} ;
         BC000N3_A167SecUserTokenUsed = new bool[] {false} ;
         BC000N3_n167SecUserTokenUsed = new bool[] {false} ;
         BC000N3_A133SecUserId = new short[1] ;
         BC000N3_n133SecUserId = new bool[] {false} ;
         sMode27 = "";
         BC000N2_A164SecUserTokenID = new short[1] ;
         BC000N2_A165SecUserTokenKey = new string[] {""} ;
         BC000N2_n165SecUserTokenKey = new bool[] {false} ;
         BC000N2_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000N2_n166SecUserTokenDateTime = new bool[] {false} ;
         BC000N2_A167SecUserTokenUsed = new bool[] {false} ;
         BC000N2_n167SecUserTokenUsed = new bool[] {false} ;
         BC000N2_A133SecUserId = new short[1] ;
         BC000N2_n133SecUserId = new bool[] {false} ;
         BC000N8_A164SecUserTokenID = new short[1] ;
         BC000N11_A164SecUserTokenID = new short[1] ;
         BC000N11_A165SecUserTokenKey = new string[] {""} ;
         BC000N11_n165SecUserTokenKey = new bool[] {false} ;
         BC000N11_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000N11_n166SecUserTokenDateTime = new bool[] {false} ;
         BC000N11_A167SecUserTokenUsed = new bool[] {false} ;
         BC000N11_n167SecUserTokenUsed = new bool[] {false} ;
         BC000N11_A133SecUserId = new short[1] ;
         BC000N11_n133SecUserId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secusertoken_bc__default(),
            new Object[][] {
                new Object[] {
               BC000N2_A164SecUserTokenID, BC000N2_A165SecUserTokenKey, BC000N2_n165SecUserTokenKey, BC000N2_A166SecUserTokenDateTime, BC000N2_n166SecUserTokenDateTime, BC000N2_A167SecUserTokenUsed, BC000N2_n167SecUserTokenUsed, BC000N2_A133SecUserId, BC000N2_n133SecUserId
               }
               , new Object[] {
               BC000N3_A164SecUserTokenID, BC000N3_A165SecUserTokenKey, BC000N3_n165SecUserTokenKey, BC000N3_A166SecUserTokenDateTime, BC000N3_n166SecUserTokenDateTime, BC000N3_A167SecUserTokenUsed, BC000N3_n167SecUserTokenUsed, BC000N3_A133SecUserId, BC000N3_n133SecUserId
               }
               , new Object[] {
               BC000N4_A133SecUserId
               }
               , new Object[] {
               BC000N5_A164SecUserTokenID, BC000N5_A165SecUserTokenKey, BC000N5_n165SecUserTokenKey, BC000N5_A166SecUserTokenDateTime, BC000N5_n166SecUserTokenDateTime, BC000N5_A167SecUserTokenUsed, BC000N5_n167SecUserTokenUsed, BC000N5_A133SecUserId, BC000N5_n133SecUserId
               }
               , new Object[] {
               BC000N6_A164SecUserTokenID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N8_A164SecUserTokenID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N11_A164SecUserTokenID, BC000N11_A165SecUserTokenKey, BC000N11_n165SecUserTokenKey, BC000N11_A166SecUserTokenDateTime, BC000N11_n166SecUserTokenDateTime, BC000N11_A167SecUserTokenUsed, BC000N11_n167SecUserTokenUsed, BC000N11_A133SecUserId, BC000N11_n133SecUserId
               }
            }
         );
         Z167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         A167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         i167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z164SecUserTokenID ;
      private short A164SecUserTokenID ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short Gx_BScreen ;
      private short RcdFound27 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode27 ;
      private DateTime Z166SecUserTokenDateTime ;
      private DateTime A166SecUserTokenDateTime ;
      private bool Z167SecUserTokenUsed ;
      private bool A167SecUserTokenUsed ;
      private bool n167SecUserTokenUsed ;
      private bool n165SecUserTokenKey ;
      private bool n166SecUserTokenDateTime ;
      private bool n133SecUserId ;
      private bool i167SecUserTokenUsed ;
      private string Z165SecUserTokenKey ;
      private string A165SecUserTokenKey ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000N5_A164SecUserTokenID ;
      private string[] BC000N5_A165SecUserTokenKey ;
      private bool[] BC000N5_n165SecUserTokenKey ;
      private DateTime[] BC000N5_A166SecUserTokenDateTime ;
      private bool[] BC000N5_n166SecUserTokenDateTime ;
      private bool[] BC000N5_A167SecUserTokenUsed ;
      private bool[] BC000N5_n167SecUserTokenUsed ;
      private short[] BC000N5_A133SecUserId ;
      private bool[] BC000N5_n133SecUserId ;
      private short[] BC000N4_A133SecUserId ;
      private bool[] BC000N4_n133SecUserId ;
      private short[] BC000N6_A164SecUserTokenID ;
      private short[] BC000N3_A164SecUserTokenID ;
      private string[] BC000N3_A165SecUserTokenKey ;
      private bool[] BC000N3_n165SecUserTokenKey ;
      private DateTime[] BC000N3_A166SecUserTokenDateTime ;
      private bool[] BC000N3_n166SecUserTokenDateTime ;
      private bool[] BC000N3_A167SecUserTokenUsed ;
      private bool[] BC000N3_n167SecUserTokenUsed ;
      private short[] BC000N3_A133SecUserId ;
      private bool[] BC000N3_n133SecUserId ;
      private short[] BC000N2_A164SecUserTokenID ;
      private string[] BC000N2_A165SecUserTokenKey ;
      private bool[] BC000N2_n165SecUserTokenKey ;
      private DateTime[] BC000N2_A166SecUserTokenDateTime ;
      private bool[] BC000N2_n166SecUserTokenDateTime ;
      private bool[] BC000N2_A167SecUserTokenUsed ;
      private bool[] BC000N2_n167SecUserTokenUsed ;
      private short[] BC000N2_A133SecUserId ;
      private bool[] BC000N2_n133SecUserId ;
      private short[] BC000N8_A164SecUserTokenID ;
      private short[] BC000N11_A164SecUserTokenID ;
      private string[] BC000N11_A165SecUserTokenKey ;
      private bool[] BC000N11_n165SecUserTokenKey ;
      private DateTime[] BC000N11_A166SecUserTokenDateTime ;
      private bool[] BC000N11_n166SecUserTokenDateTime ;
      private bool[] BC000N11_A167SecUserTokenUsed ;
      private bool[] BC000N11_n167SecUserTokenUsed ;
      private short[] BC000N11_A133SecUserId ;
      private bool[] BC000N11_n133SecUserId ;
      private SdtSecUserToken bcSecUserToken ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secusertoken_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000N2;
          prmBC000N2 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmBC000N3;
          prmBC000N3 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmBC000N4;
          prmBC000N4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000N5;
          prmBC000N5 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmBC000N6;
          prmBC000N6 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmBC000N7;
          prmBC000N7 = new Object[] {
          new ParDef("SecUserTokenKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserTokenDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SecUserTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000N8;
          prmBC000N8 = new Object[] {
          };
          Object[] prmBC000N9;
          prmBC000N9 = new Object[] {
          new ParDef("SecUserTokenKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserTokenDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SecUserTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmBC000N10;
          prmBC000N10 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmBC000N11;
          prmBC000N11 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000N2", "SELECT SecUserTokenID, SecUserTokenKey, SecUserTokenDateTime, SecUserTokenUsed, SecUserId FROM SecUserToken WHERE SecUserTokenID = :SecUserTokenID  FOR UPDATE OF SecUserToken",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000N3", "SELECT SecUserTokenID, SecUserTokenKey, SecUserTokenDateTime, SecUserTokenUsed, SecUserId FROM SecUserToken WHERE SecUserTokenID = :SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000N4", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000N5", "SELECT TM1.SecUserTokenID, TM1.SecUserTokenKey, TM1.SecUserTokenDateTime, TM1.SecUserTokenUsed, TM1.SecUserId FROM SecUserToken TM1 WHERE TM1.SecUserTokenID = :SecUserTokenID ORDER BY TM1.SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000N6", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserTokenID = :SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000N7", "SAVEPOINT gxupdate;INSERT INTO SecUserToken(SecUserTokenKey, SecUserTokenDateTime, SecUserTokenUsed, SecUserId) VALUES(:SecUserTokenKey, :SecUserTokenDateTime, :SecUserTokenUsed, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N7)
             ,new CursorDef("BC000N8", "SELECT currval('SecUserTokenID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000N9", "SAVEPOINT gxupdate;UPDATE SecUserToken SET SecUserTokenKey=:SecUserTokenKey, SecUserTokenDateTime=:SecUserTokenDateTime, SecUserTokenUsed=:SecUserTokenUsed, SecUserId=:SecUserId  WHERE SecUserTokenID = :SecUserTokenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N9)
             ,new CursorDef("BC000N10", "SAVEPOINT gxupdate;DELETE FROM SecUserToken  WHERE SecUserTokenID = :SecUserTokenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N10)
             ,new CursorDef("BC000N11", "SELECT TM1.SecUserTokenID, TM1.SecUserTokenKey, TM1.SecUserTokenDateTime, TM1.SecUserTokenUsed, TM1.SecUserId FROM SecUserToken TM1 WHERE TM1.SecUserTokenID = :SecUserTokenID ORDER BY TM1.SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
