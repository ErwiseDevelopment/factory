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
   public class temporarycode_bc : GxSilentTrn, IGxSilentTrn
   {
      public temporarycode_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public temporarycode_bc( IGxContext context )
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
         ReadRow0V34( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0V34( ) ;
         standaloneModal( ) ;
         AddRow0V34( ) ;
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
               Z214TemporaryCodeId = A214TemporaryCodeId;
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

      protected void CONFIRM_0V0( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0V34( ) ;
            }
            else
            {
               CheckExtendedTable0V34( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0V34( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0V34( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z215TemporaryCodeContent = A215TemporaryCodeContent;
            Z216TemporaryCodeDateTime = A216TemporaryCodeDateTime;
            Z217TemporaryCodeEmail = A217TemporaryCodeEmail;
            Z218TemporaryCodeUsed = A218TemporaryCodeUsed;
         }
         if ( GX_JID == -2 )
         {
            Z214TemporaryCodeId = A214TemporaryCodeId;
            Z215TemporaryCodeContent = A215TemporaryCodeContent;
            Z216TemporaryCodeDateTime = A216TemporaryCodeDateTime;
            Z217TemporaryCodeEmail = A217TemporaryCodeEmail;
            Z218TemporaryCodeUsed = A218TemporaryCodeUsed;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0V34( )
      {
         /* Using cursor BC000V4 */
         pr_default.execute(2, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound34 = 1;
            A215TemporaryCodeContent = BC000V4_A215TemporaryCodeContent[0];
            n215TemporaryCodeContent = BC000V4_n215TemporaryCodeContent[0];
            A216TemporaryCodeDateTime = BC000V4_A216TemporaryCodeDateTime[0];
            n216TemporaryCodeDateTime = BC000V4_n216TemporaryCodeDateTime[0];
            A217TemporaryCodeEmail = BC000V4_A217TemporaryCodeEmail[0];
            n217TemporaryCodeEmail = BC000V4_n217TemporaryCodeEmail[0];
            A218TemporaryCodeUsed = BC000V4_A218TemporaryCodeUsed[0];
            n218TemporaryCodeUsed = BC000V4_n218TemporaryCodeUsed[0];
            ZM0V34( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0V34( ) ;
      }

      protected void OnLoadActions0V34( )
      {
      }

      protected void CheckExtendedTable0V34( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A217TemporaryCodeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A217TemporaryCodeEmail)) ) )
         {
            GX_msglist.addItem("O valor de Temporary Code Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0V34( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0V34( )
      {
         /* Using cursor BC000V5 */
         pr_default.execute(3, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000V3 */
         pr_default.execute(1, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0V34( 2) ;
            RcdFound34 = 1;
            A214TemporaryCodeId = BC000V3_A214TemporaryCodeId[0];
            A215TemporaryCodeContent = BC000V3_A215TemporaryCodeContent[0];
            n215TemporaryCodeContent = BC000V3_n215TemporaryCodeContent[0];
            A216TemporaryCodeDateTime = BC000V3_A216TemporaryCodeDateTime[0];
            n216TemporaryCodeDateTime = BC000V3_n216TemporaryCodeDateTime[0];
            A217TemporaryCodeEmail = BC000V3_A217TemporaryCodeEmail[0];
            n217TemporaryCodeEmail = BC000V3_n217TemporaryCodeEmail[0];
            A218TemporaryCodeUsed = BC000V3_A218TemporaryCodeUsed[0];
            n218TemporaryCodeUsed = BC000V3_n218TemporaryCodeUsed[0];
            Z214TemporaryCodeId = A214TemporaryCodeId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0V34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0V34( ) ;
            }
            Gx_mode = sMode34;
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0V34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode34;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V34( ) ;
         if ( RcdFound34 == 0 )
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
         CONFIRM_0V0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0V34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000V2 */
            pr_default.execute(0, new Object[] {A214TemporaryCodeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TemporaryCode"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z215TemporaryCodeContent, BC000V2_A215TemporaryCodeContent[0]) != 0 ) || ( Z216TemporaryCodeDateTime != BC000V2_A216TemporaryCodeDateTime[0] ) || ( StringUtil.StrCmp(Z217TemporaryCodeEmail, BC000V2_A217TemporaryCodeEmail[0]) != 0 ) || ( Z218TemporaryCodeUsed != BC000V2_A218TemporaryCodeUsed[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TemporaryCode"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V34( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V34( 0) ;
            CheckOptimisticConcurrency0V34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000V6 */
                     pr_default.execute(4, new Object[] {n215TemporaryCodeContent, A215TemporaryCodeContent, n216TemporaryCodeDateTime, A216TemporaryCodeDateTime, n217TemporaryCodeEmail, A217TemporaryCodeEmail, n218TemporaryCodeUsed, A218TemporaryCodeUsed});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000V7 */
                     pr_default.execute(5);
                     A214TemporaryCodeId = BC000V7_A214TemporaryCodeId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("TemporaryCode");
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
               Load0V34( ) ;
            }
            EndLevel0V34( ) ;
         }
         CloseExtendedTableCursors0V34( ) ;
      }

      protected void Update0V34( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0V34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000V8 */
                     pr_default.execute(6, new Object[] {n215TemporaryCodeContent, A215TemporaryCodeContent, n216TemporaryCodeDateTime, A216TemporaryCodeDateTime, n217TemporaryCodeEmail, A217TemporaryCodeEmail, n218TemporaryCodeUsed, A218TemporaryCodeUsed, A214TemporaryCodeId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TemporaryCode");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TemporaryCode"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0V34( ) ;
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
            EndLevel0V34( ) ;
         }
         CloseExtendedTableCursors0V34( ) ;
      }

      protected void DeferredUpdate0V34( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V34( ) ;
            AfterConfirm0V34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V34( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000V9 */
                  pr_default.execute(7, new Object[] {A214TemporaryCodeId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("TemporaryCode");
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0V34( ) ;
         Gx_mode = sMode34;
      }

      protected void OnDeleteControls0V34( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0V34( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0V34( ) ;
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

      public void ScanKeyStart0V34( )
      {
         /* Using cursor BC000V10 */
         pr_default.execute(8, new Object[] {A214TemporaryCodeId});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound34 = 1;
            A214TemporaryCodeId = BC000V10_A214TemporaryCodeId[0];
            A215TemporaryCodeContent = BC000V10_A215TemporaryCodeContent[0];
            n215TemporaryCodeContent = BC000V10_n215TemporaryCodeContent[0];
            A216TemporaryCodeDateTime = BC000V10_A216TemporaryCodeDateTime[0];
            n216TemporaryCodeDateTime = BC000V10_n216TemporaryCodeDateTime[0];
            A217TemporaryCodeEmail = BC000V10_A217TemporaryCodeEmail[0];
            n217TemporaryCodeEmail = BC000V10_n217TemporaryCodeEmail[0];
            A218TemporaryCodeUsed = BC000V10_A218TemporaryCodeUsed[0];
            n218TemporaryCodeUsed = BC000V10_n218TemporaryCodeUsed[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0V34( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound34 = 0;
         ScanKeyLoad0V34( ) ;
      }

      protected void ScanKeyLoad0V34( )
      {
         sMode34 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound34 = 1;
            A214TemporaryCodeId = BC000V10_A214TemporaryCodeId[0];
            A215TemporaryCodeContent = BC000V10_A215TemporaryCodeContent[0];
            n215TemporaryCodeContent = BC000V10_n215TemporaryCodeContent[0];
            A216TemporaryCodeDateTime = BC000V10_A216TemporaryCodeDateTime[0];
            n216TemporaryCodeDateTime = BC000V10_n216TemporaryCodeDateTime[0];
            A217TemporaryCodeEmail = BC000V10_A217TemporaryCodeEmail[0];
            n217TemporaryCodeEmail = BC000V10_n217TemporaryCodeEmail[0];
            A218TemporaryCodeUsed = BC000V10_A218TemporaryCodeUsed[0];
            n218TemporaryCodeUsed = BC000V10_n218TemporaryCodeUsed[0];
         }
         Gx_mode = sMode34;
      }

      protected void ScanKeyEnd0V34( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0V34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V34( )
      {
      }

      protected void send_integrity_lvl_hashes0V34( )
      {
      }

      protected void AddRow0V34( )
      {
         VarsToRow34( bcTemporaryCode) ;
      }

      protected void ReadRow0V34( )
      {
         RowToVars34( bcTemporaryCode, 1) ;
      }

      protected void InitializeNonKey0V34( )
      {
         A215TemporaryCodeContent = "";
         n215TemporaryCodeContent = false;
         A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         n216TemporaryCodeDateTime = false;
         A217TemporaryCodeEmail = "";
         n217TemporaryCodeEmail = false;
         A218TemporaryCodeUsed = false;
         n218TemporaryCodeUsed = false;
         Z215TemporaryCodeContent = "";
         Z216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         Z217TemporaryCodeEmail = "";
         Z218TemporaryCodeUsed = false;
      }

      protected void InitAll0V34( )
      {
         A214TemporaryCodeId = 0;
         InitializeNonKey0V34( ) ;
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

      public void VarsToRow34( SdtTemporaryCode obj34 )
      {
         obj34.gxTpr_Mode = Gx_mode;
         obj34.gxTpr_Temporarycodecontent = A215TemporaryCodeContent;
         obj34.gxTpr_Temporarycodedatetime = A216TemporaryCodeDateTime;
         obj34.gxTpr_Temporarycodeemail = A217TemporaryCodeEmail;
         obj34.gxTpr_Temporarycodeused = A218TemporaryCodeUsed;
         obj34.gxTpr_Temporarycodeid = A214TemporaryCodeId;
         obj34.gxTpr_Temporarycodeid_Z = Z214TemporaryCodeId;
         obj34.gxTpr_Temporarycodecontent_Z = Z215TemporaryCodeContent;
         obj34.gxTpr_Temporarycodedatetime_Z = Z216TemporaryCodeDateTime;
         obj34.gxTpr_Temporarycodeemail_Z = Z217TemporaryCodeEmail;
         obj34.gxTpr_Temporarycodeused_Z = Z218TemporaryCodeUsed;
         obj34.gxTpr_Temporarycodecontent_N = (short)(Convert.ToInt16(n215TemporaryCodeContent));
         obj34.gxTpr_Temporarycodedatetime_N = (short)(Convert.ToInt16(n216TemporaryCodeDateTime));
         obj34.gxTpr_Temporarycodeemail_N = (short)(Convert.ToInt16(n217TemporaryCodeEmail));
         obj34.gxTpr_Temporarycodeused_N = (short)(Convert.ToInt16(n218TemporaryCodeUsed));
         obj34.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow34( SdtTemporaryCode obj34 )
      {
         obj34.gxTpr_Temporarycodeid = A214TemporaryCodeId;
         return  ;
      }

      public void RowToVars34( SdtTemporaryCode obj34 ,
                               int forceLoad )
      {
         Gx_mode = obj34.gxTpr_Mode;
         A215TemporaryCodeContent = obj34.gxTpr_Temporarycodecontent;
         n215TemporaryCodeContent = false;
         A216TemporaryCodeDateTime = obj34.gxTpr_Temporarycodedatetime;
         n216TemporaryCodeDateTime = false;
         A217TemporaryCodeEmail = obj34.gxTpr_Temporarycodeemail;
         n217TemporaryCodeEmail = false;
         A218TemporaryCodeUsed = obj34.gxTpr_Temporarycodeused;
         n218TemporaryCodeUsed = false;
         A214TemporaryCodeId = obj34.gxTpr_Temporarycodeid;
         Z214TemporaryCodeId = obj34.gxTpr_Temporarycodeid_Z;
         Z215TemporaryCodeContent = obj34.gxTpr_Temporarycodecontent_Z;
         Z216TemporaryCodeDateTime = obj34.gxTpr_Temporarycodedatetime_Z;
         Z217TemporaryCodeEmail = obj34.gxTpr_Temporarycodeemail_Z;
         Z218TemporaryCodeUsed = obj34.gxTpr_Temporarycodeused_Z;
         n215TemporaryCodeContent = (bool)(Convert.ToBoolean(obj34.gxTpr_Temporarycodecontent_N));
         n216TemporaryCodeDateTime = (bool)(Convert.ToBoolean(obj34.gxTpr_Temporarycodedatetime_N));
         n217TemporaryCodeEmail = (bool)(Convert.ToBoolean(obj34.gxTpr_Temporarycodeemail_N));
         n218TemporaryCodeUsed = (bool)(Convert.ToBoolean(obj34.gxTpr_Temporarycodeused_N));
         Gx_mode = obj34.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A214TemporaryCodeId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0V34( ) ;
         ScanKeyStart0V34( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z214TemporaryCodeId = A214TemporaryCodeId;
         }
         ZM0V34( -2) ;
         OnLoadActions0V34( ) ;
         AddRow0V34( ) ;
         ScanKeyEnd0V34( ) ;
         if ( RcdFound34 == 0 )
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
         RowToVars34( bcTemporaryCode, 0) ;
         ScanKeyStart0V34( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z214TemporaryCodeId = A214TemporaryCodeId;
         }
         ZM0V34( -2) ;
         OnLoadActions0V34( ) ;
         AddRow0V34( ) ;
         ScanKeyEnd0V34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0V34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0V34( ) ;
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( A214TemporaryCodeId != Z214TemporaryCodeId )
               {
                  A214TemporaryCodeId = Z214TemporaryCodeId;
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
                  Update0V34( ) ;
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
                  if ( A214TemporaryCodeId != Z214TemporaryCodeId )
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
                        Insert0V34( ) ;
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
                        Insert0V34( ) ;
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
         RowToVars34( bcTemporaryCode, 1) ;
         SaveImpl( ) ;
         VarsToRow34( bcTemporaryCode) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars34( bcTemporaryCode, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0V34( ) ;
         AfterTrn( ) ;
         VarsToRow34( bcTemporaryCode) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow34( bcTemporaryCode) ;
         }
         else
         {
            SdtTemporaryCode auxBC = new SdtTemporaryCode(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A214TemporaryCodeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTemporaryCode);
               auxBC.Save();
               bcTemporaryCode.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars34( bcTemporaryCode, 1) ;
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
         RowToVars34( bcTemporaryCode, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0V34( ) ;
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
               VarsToRow34( bcTemporaryCode) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow34( bcTemporaryCode) ;
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
         RowToVars34( bcTemporaryCode, 0) ;
         GetKey0V34( ) ;
         if ( RcdFound34 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A214TemporaryCodeId != Z214TemporaryCodeId )
            {
               A214TemporaryCodeId = Z214TemporaryCodeId;
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
            if ( A214TemporaryCodeId != Z214TemporaryCodeId )
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
         context.RollbackDataStores("temporarycode_bc",pr_default);
         VarsToRow34( bcTemporaryCode) ;
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
         Gx_mode = bcTemporaryCode.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTemporaryCode.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTemporaryCode )
         {
            bcTemporaryCode = (SdtTemporaryCode)(sdt);
            if ( StringUtil.StrCmp(bcTemporaryCode.gxTpr_Mode, "") == 0 )
            {
               bcTemporaryCode.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow34( bcTemporaryCode) ;
            }
            else
            {
               RowToVars34( bcTemporaryCode, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTemporaryCode.gxTpr_Mode, "") == 0 )
            {
               bcTemporaryCode.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars34( bcTemporaryCode, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTemporaryCode TemporaryCode_BC
      {
         get {
            return bcTemporaryCode ;
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
         Z215TemporaryCodeContent = "";
         A215TemporaryCodeContent = "";
         Z216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         Z217TemporaryCodeEmail = "";
         A217TemporaryCodeEmail = "";
         BC000V4_A214TemporaryCodeId = new int[1] ;
         BC000V4_A215TemporaryCodeContent = new string[] {""} ;
         BC000V4_n215TemporaryCodeContent = new bool[] {false} ;
         BC000V4_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000V4_n216TemporaryCodeDateTime = new bool[] {false} ;
         BC000V4_A217TemporaryCodeEmail = new string[] {""} ;
         BC000V4_n217TemporaryCodeEmail = new bool[] {false} ;
         BC000V4_A218TemporaryCodeUsed = new bool[] {false} ;
         BC000V4_n218TemporaryCodeUsed = new bool[] {false} ;
         BC000V5_A214TemporaryCodeId = new int[1] ;
         BC000V3_A214TemporaryCodeId = new int[1] ;
         BC000V3_A215TemporaryCodeContent = new string[] {""} ;
         BC000V3_n215TemporaryCodeContent = new bool[] {false} ;
         BC000V3_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000V3_n216TemporaryCodeDateTime = new bool[] {false} ;
         BC000V3_A217TemporaryCodeEmail = new string[] {""} ;
         BC000V3_n217TemporaryCodeEmail = new bool[] {false} ;
         BC000V3_A218TemporaryCodeUsed = new bool[] {false} ;
         BC000V3_n218TemporaryCodeUsed = new bool[] {false} ;
         sMode34 = "";
         BC000V2_A214TemporaryCodeId = new int[1] ;
         BC000V2_A215TemporaryCodeContent = new string[] {""} ;
         BC000V2_n215TemporaryCodeContent = new bool[] {false} ;
         BC000V2_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000V2_n216TemporaryCodeDateTime = new bool[] {false} ;
         BC000V2_A217TemporaryCodeEmail = new string[] {""} ;
         BC000V2_n217TemporaryCodeEmail = new bool[] {false} ;
         BC000V2_A218TemporaryCodeUsed = new bool[] {false} ;
         BC000V2_n218TemporaryCodeUsed = new bool[] {false} ;
         BC000V7_A214TemporaryCodeId = new int[1] ;
         BC000V10_A214TemporaryCodeId = new int[1] ;
         BC000V10_A215TemporaryCodeContent = new string[] {""} ;
         BC000V10_n215TemporaryCodeContent = new bool[] {false} ;
         BC000V10_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000V10_n216TemporaryCodeDateTime = new bool[] {false} ;
         BC000V10_A217TemporaryCodeEmail = new string[] {""} ;
         BC000V10_n217TemporaryCodeEmail = new bool[] {false} ;
         BC000V10_A218TemporaryCodeUsed = new bool[] {false} ;
         BC000V10_n218TemporaryCodeUsed = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.temporarycode_bc__default(),
            new Object[][] {
                new Object[] {
               BC000V2_A214TemporaryCodeId, BC000V2_A215TemporaryCodeContent, BC000V2_n215TemporaryCodeContent, BC000V2_A216TemporaryCodeDateTime, BC000V2_n216TemporaryCodeDateTime, BC000V2_A217TemporaryCodeEmail, BC000V2_n217TemporaryCodeEmail, BC000V2_A218TemporaryCodeUsed, BC000V2_n218TemporaryCodeUsed
               }
               , new Object[] {
               BC000V3_A214TemporaryCodeId, BC000V3_A215TemporaryCodeContent, BC000V3_n215TemporaryCodeContent, BC000V3_A216TemporaryCodeDateTime, BC000V3_n216TemporaryCodeDateTime, BC000V3_A217TemporaryCodeEmail, BC000V3_n217TemporaryCodeEmail, BC000V3_A218TemporaryCodeUsed, BC000V3_n218TemporaryCodeUsed
               }
               , new Object[] {
               BC000V4_A214TemporaryCodeId, BC000V4_A215TemporaryCodeContent, BC000V4_n215TemporaryCodeContent, BC000V4_A216TemporaryCodeDateTime, BC000V4_n216TemporaryCodeDateTime, BC000V4_A217TemporaryCodeEmail, BC000V4_n217TemporaryCodeEmail, BC000V4_A218TemporaryCodeUsed, BC000V4_n218TemporaryCodeUsed
               }
               , new Object[] {
               BC000V5_A214TemporaryCodeId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000V7_A214TemporaryCodeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000V10_A214TemporaryCodeId, BC000V10_A215TemporaryCodeContent, BC000V10_n215TemporaryCodeContent, BC000V10_A216TemporaryCodeDateTime, BC000V10_n216TemporaryCodeDateTime, BC000V10_A217TemporaryCodeEmail, BC000V10_n217TemporaryCodeEmail, BC000V10_A218TemporaryCodeUsed, BC000V10_n218TemporaryCodeUsed
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound34 ;
      private int trnEnded ;
      private int Z214TemporaryCodeId ;
      private int A214TemporaryCodeId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode34 ;
      private DateTime Z216TemporaryCodeDateTime ;
      private DateTime A216TemporaryCodeDateTime ;
      private bool Z218TemporaryCodeUsed ;
      private bool A218TemporaryCodeUsed ;
      private bool n215TemporaryCodeContent ;
      private bool n216TemporaryCodeDateTime ;
      private bool n217TemporaryCodeEmail ;
      private bool n218TemporaryCodeUsed ;
      private string Z215TemporaryCodeContent ;
      private string A215TemporaryCodeContent ;
      private string Z217TemporaryCodeEmail ;
      private string A217TemporaryCodeEmail ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000V4_A214TemporaryCodeId ;
      private string[] BC000V4_A215TemporaryCodeContent ;
      private bool[] BC000V4_n215TemporaryCodeContent ;
      private DateTime[] BC000V4_A216TemporaryCodeDateTime ;
      private bool[] BC000V4_n216TemporaryCodeDateTime ;
      private string[] BC000V4_A217TemporaryCodeEmail ;
      private bool[] BC000V4_n217TemporaryCodeEmail ;
      private bool[] BC000V4_A218TemporaryCodeUsed ;
      private bool[] BC000V4_n218TemporaryCodeUsed ;
      private int[] BC000V5_A214TemporaryCodeId ;
      private int[] BC000V3_A214TemporaryCodeId ;
      private string[] BC000V3_A215TemporaryCodeContent ;
      private bool[] BC000V3_n215TemporaryCodeContent ;
      private DateTime[] BC000V3_A216TemporaryCodeDateTime ;
      private bool[] BC000V3_n216TemporaryCodeDateTime ;
      private string[] BC000V3_A217TemporaryCodeEmail ;
      private bool[] BC000V3_n217TemporaryCodeEmail ;
      private bool[] BC000V3_A218TemporaryCodeUsed ;
      private bool[] BC000V3_n218TemporaryCodeUsed ;
      private int[] BC000V2_A214TemporaryCodeId ;
      private string[] BC000V2_A215TemporaryCodeContent ;
      private bool[] BC000V2_n215TemporaryCodeContent ;
      private DateTime[] BC000V2_A216TemporaryCodeDateTime ;
      private bool[] BC000V2_n216TemporaryCodeDateTime ;
      private string[] BC000V2_A217TemporaryCodeEmail ;
      private bool[] BC000V2_n217TemporaryCodeEmail ;
      private bool[] BC000V2_A218TemporaryCodeUsed ;
      private bool[] BC000V2_n218TemporaryCodeUsed ;
      private int[] BC000V7_A214TemporaryCodeId ;
      private int[] BC000V10_A214TemporaryCodeId ;
      private string[] BC000V10_A215TemporaryCodeContent ;
      private bool[] BC000V10_n215TemporaryCodeContent ;
      private DateTime[] BC000V10_A216TemporaryCodeDateTime ;
      private bool[] BC000V10_n216TemporaryCodeDateTime ;
      private string[] BC000V10_A217TemporaryCodeEmail ;
      private bool[] BC000V10_n217TemporaryCodeEmail ;
      private bool[] BC000V10_A218TemporaryCodeUsed ;
      private bool[] BC000V10_n218TemporaryCodeUsed ;
      private SdtTemporaryCode bcTemporaryCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class temporarycode_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000V2;
          prmBC000V2 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmBC000V3;
          prmBC000V3 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmBC000V4;
          prmBC000V4 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmBC000V5;
          prmBC000V5 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmBC000V6;
          prmBC000V6 = new Object[] {
          new ParDef("TemporaryCodeContent",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TemporaryCodeDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TemporaryCodeEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TemporaryCodeUsed",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmBC000V7;
          prmBC000V7 = new Object[] {
          };
          Object[] prmBC000V8;
          prmBC000V8 = new Object[] {
          new ParDef("TemporaryCodeContent",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TemporaryCodeDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TemporaryCodeEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TemporaryCodeUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmBC000V9;
          prmBC000V9 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmBC000V10;
          prmBC000V10 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000V2", "SELECT TemporaryCodeId, TemporaryCodeContent, TemporaryCodeDateTime, TemporaryCodeEmail, TemporaryCodeUsed FROM TemporaryCode WHERE TemporaryCodeId = :TemporaryCodeId  FOR UPDATE OF TemporaryCode",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000V3", "SELECT TemporaryCodeId, TemporaryCodeContent, TemporaryCodeDateTime, TemporaryCodeEmail, TemporaryCodeUsed FROM TemporaryCode WHERE TemporaryCodeId = :TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000V4", "SELECT TM1.TemporaryCodeId, TM1.TemporaryCodeContent, TM1.TemporaryCodeDateTime, TM1.TemporaryCodeEmail, TM1.TemporaryCodeUsed FROM TemporaryCode TM1 WHERE TM1.TemporaryCodeId = :TemporaryCodeId ORDER BY TM1.TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000V5", "SELECT TemporaryCodeId FROM TemporaryCode WHERE TemporaryCodeId = :TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000V6", "SAVEPOINT gxupdate;INSERT INTO TemporaryCode(TemporaryCodeContent, TemporaryCodeDateTime, TemporaryCodeEmail, TemporaryCodeUsed) VALUES(:TemporaryCodeContent, :TemporaryCodeDateTime, :TemporaryCodeEmail, :TemporaryCodeUsed);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000V6)
             ,new CursorDef("BC000V7", "SELECT currval('TemporaryCodeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000V8", "SAVEPOINT gxupdate;UPDATE TemporaryCode SET TemporaryCodeContent=:TemporaryCodeContent, TemporaryCodeDateTime=:TemporaryCodeDateTime, TemporaryCodeEmail=:TemporaryCodeEmail, TemporaryCodeUsed=:TemporaryCodeUsed  WHERE TemporaryCodeId = :TemporaryCodeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000V8)
             ,new CursorDef("BC000V9", "SAVEPOINT gxupdate;DELETE FROM TemporaryCode  WHERE TemporaryCodeId = :TemporaryCodeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000V9)
             ,new CursorDef("BC000V10", "SELECT TM1.TemporaryCodeId, TM1.TemporaryCodeContent, TM1.TemporaryCodeDateTime, TM1.TemporaryCodeEmail, TM1.TemporaryCodeUsed FROM TemporaryCode TM1 WHERE TM1.TemporaryCodeId = :TemporaryCodeId ORDER BY TM1.TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V10,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
