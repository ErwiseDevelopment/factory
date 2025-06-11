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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_form_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_form_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_form_bc( IGxContext context )
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
         ReadRow0C13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C13( ) ;
         standaloneModal( ) ;
         AddRow0C13( ) ;
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
            E110C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z94WWPFormId = A94WWPFormId;
               Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode13 = Gx_mode;
            CONFIRM_0C14( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode13;
            }
            /* Restore parent mode. */
            Gx_mode = sMode13;
         }
      }

      protected void CONFIRM_0C14( )
      {
         nGXsfl_14_idx = 0;
         while ( nGXsfl_14_idx < bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Count )
         {
            ReadRow0C14( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound14 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0C14( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0C14( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0C14( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0C14( 12) ;
                        }
                        CloseExtendedTableCursors0C14( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0C14( ) ;
                        Load0C14( ) ;
                        BeforeValidate0C14( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0C14( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0C14( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0C14( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0C14( 12) ;
                              }
                              CloseExtendedTableCursors0C14( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow14( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Item(nGXsfl_14_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z96WWPFormReferenceName = A96WWPFormReferenceName;
            Z97WWPFormTitle = A97WWPFormTitle;
            Z119WWPFormDate = A119WWPFormDate;
            Z120WWPFormIsWizard = A120WWPFormIsWizard;
            Z104WWPFormResume = A104WWPFormResume;
            Z122WWPFormInstantiated = A122WWPFormInstantiated;
            Z290WWPFormType = A290WWPFormType;
            Z291WWPFormSectionRefElements = A291WWPFormSectionRefElements;
            Z292WWPFormIsForDynamicValidations = A292WWPFormIsForDynamicValidations;
            Z107WWPFormLatestVersionNumber = A107WWPFormLatestVersionNumber;
         }
         if ( GX_JID == -10 )
         {
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z96WWPFormReferenceName = A96WWPFormReferenceName;
            Z97WWPFormTitle = A97WWPFormTitle;
            Z119WWPFormDate = A119WWPFormDate;
            Z120WWPFormIsWizard = A120WWPFormIsWizard;
            Z104WWPFormResume = A104WWPFormResume;
            Z123WWPFormResumeMessage = A123WWPFormResumeMessage;
            Z121WWPFormValidations = A121WWPFormValidations;
            Z122WWPFormInstantiated = A122WWPFormInstantiated;
            Z290WWPFormType = A290WWPFormType;
            Z291WWPFormSectionRefElements = A291WWPFormSectionRefElements;
            Z292WWPFormIsForDynamicValidations = A292WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C13( )
      {
         /* Using cursor BC000C7 */
         pr_default.execute(5, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
            A96WWPFormReferenceName = BC000C7_A96WWPFormReferenceName[0];
            A97WWPFormTitle = BC000C7_A97WWPFormTitle[0];
            A119WWPFormDate = BC000C7_A119WWPFormDate[0];
            A120WWPFormIsWizard = BC000C7_A120WWPFormIsWizard[0];
            A104WWPFormResume = BC000C7_A104WWPFormResume[0];
            A123WWPFormResumeMessage = BC000C7_A123WWPFormResumeMessage[0];
            A121WWPFormValidations = BC000C7_A121WWPFormValidations[0];
            A122WWPFormInstantiated = BC000C7_A122WWPFormInstantiated[0];
            A290WWPFormType = BC000C7_A290WWPFormType[0];
            A291WWPFormSectionRefElements = BC000C7_A291WWPFormSectionRefElements[0];
            A292WWPFormIsForDynamicValidations = BC000C7_A292WWPFormIsForDynamicValidations[0];
            ZM0C13( -10) ;
         }
         pr_default.close(5);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
         GXt_int1 = A107WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
         A107WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CheckExtendedTable0C13( )
      {
         standaloneModal( ) ;
         GXt_int1 = A107WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
         A107WWPFormLatestVersionNumber = GXt_int1;
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A94WWPFormId,  A96WWPFormReferenceName) )
         {
            GX_msglist.addItem("O nome de referência deve ser único.", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A104WWPFormResume == 0 ) || ( A104WWPFormResume == 1 ) || ( A104WWPFormResume == 2 ) ) )
         {
            GX_msglist.addItem("Campo WWPForm Resume fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A290WWPFormType == 0 ) || ( A290WWPFormType == 1 ) ) )
         {
            GX_msglist.addItem("Campo WWPForm Type fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0C13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor BC000C8 */
         pr_default.execute(6, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0C13( 10) ;
            RcdFound13 = 1;
            A94WWPFormId = BC000C6_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000C6_A95WWPFormVersionNumber[0];
            A96WWPFormReferenceName = BC000C6_A96WWPFormReferenceName[0];
            A97WWPFormTitle = BC000C6_A97WWPFormTitle[0];
            A119WWPFormDate = BC000C6_A119WWPFormDate[0];
            A120WWPFormIsWizard = BC000C6_A120WWPFormIsWizard[0];
            A104WWPFormResume = BC000C6_A104WWPFormResume[0];
            A123WWPFormResumeMessage = BC000C6_A123WWPFormResumeMessage[0];
            A121WWPFormValidations = BC000C6_A121WWPFormValidations[0];
            A122WWPFormInstantiated = BC000C6_A122WWPFormInstantiated[0];
            A290WWPFormType = BC000C6_A290WWPFormType[0];
            A291WWPFormSectionRefElements = BC000C6_A291WWPFormSectionRefElements[0];
            A292WWPFormIsForDynamicValidations = BC000C6_A292WWPFormIsForDynamicValidations[0];
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_0C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C5 */
            pr_default.execute(3, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z96WWPFormReferenceName, BC000C5_A96WWPFormReferenceName[0]) != 0 ) || ( StringUtil.StrCmp(Z97WWPFormTitle, BC000C5_A97WWPFormTitle[0]) != 0 ) || ( Z119WWPFormDate != BC000C5_A119WWPFormDate[0] ) || ( Z120WWPFormIsWizard != BC000C5_A120WWPFormIsWizard[0] ) || ( Z104WWPFormResume != BC000C5_A104WWPFormResume[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z122WWPFormInstantiated != BC000C5_A122WWPFormInstantiated[0] ) || ( Z290WWPFormType != BC000C5_A290WWPFormType[0] ) || ( StringUtil.StrCmp(Z291WWPFormSectionRefElements, BC000C5_A291WWPFormSectionRefElements[0]) != 0 ) || ( Z292WWPFormIsForDynamicValidations != BC000C5_A292WWPFormIsForDynamicValidations[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Form"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C9 */
                     pr_default.execute(7, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A96WWPFormReferenceName, A97WWPFormTitle, A119WWPFormDate, A120WWPFormIsWizard, A104WWPFormResume, A123WWPFormResumeMessage, A121WWPFormValidations, A122WWPFormInstantiated, A290WWPFormType, A291WWPFormSectionRefElements, A292WWPFormIsForDynamicValidations});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(7) == 1) )
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
                           ProcessLevel0C13( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C10 */
                     pr_default.execute(8, new Object[] {A96WWPFormReferenceName, A97WWPFormTitle, A119WWPFormDate, A120WWPFormIsWizard, A104WWPFormResume, A123WWPFormResumeMessage, A121WWPFormValidations, A122WWPFormInstantiated, A290WWPFormType, A291WWPFormSectionRefElements, A292WWPFormIsForDynamicValidations, A94WWPFormId, A95WWPFormVersionNumber});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C13( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0C14( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0C14( ) ;
                     Delete0C14( ) ;
                     ScanKeyNext0C14( ) ;
                  }
                  ScanKeyEnd0C14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C11 */
                     pr_default.execute(9, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
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
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
            A107WWPFormLatestVersionNumber = GXt_int1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPForm Instance"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000C13 */
            pr_default.execute(11, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Element"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel0C14( )
      {
         nGXsfl_14_idx = 0;
         while ( nGXsfl_14_idx < bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Count )
         {
            ReadRow0C14( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound14 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0C14( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0C14( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0C14( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0C14( ) ;
                  }
               }
            }
            KeyVarsToRow14( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Item(nGXsfl_14_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_14_idx = 0;
            while ( nGXsfl_14_idx < bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Count )
            {
               ReadRow0C14( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.RemoveElement(nGXsfl_14_idx);
                  nGXsfl_14_idx = (int)(nGXsfl_14_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0C14( ) ;
                  VarsToRow14( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Item(nGXsfl_14_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0C14( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
      }

      protected void ProcessLevel0C13( )
      {
         /* Save parent mode. */
         sMode13 = Gx_mode;
         ProcessNestedLevel0C14( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode13;
         /* ' Update level parameters */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
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

      public void ScanKeyStart0C13( )
      {
         /* Scan By routine */
         /* Using cursor BC000C14 */
         pr_default.execute(12, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A94WWPFormId = BC000C14_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000C14_A95WWPFormVersionNumber[0];
            A96WWPFormReferenceName = BC000C14_A96WWPFormReferenceName[0];
            A97WWPFormTitle = BC000C14_A97WWPFormTitle[0];
            A119WWPFormDate = BC000C14_A119WWPFormDate[0];
            A120WWPFormIsWizard = BC000C14_A120WWPFormIsWizard[0];
            A104WWPFormResume = BC000C14_A104WWPFormResume[0];
            A123WWPFormResumeMessage = BC000C14_A123WWPFormResumeMessage[0];
            A121WWPFormValidations = BC000C14_A121WWPFormValidations[0];
            A122WWPFormInstantiated = BC000C14_A122WWPFormInstantiated[0];
            A290WWPFormType = BC000C14_A290WWPFormType[0];
            A291WWPFormSectionRefElements = BC000C14_A291WWPFormSectionRefElements[0];
            A292WWPFormIsForDynamicValidations = BC000C14_A292WWPFormIsForDynamicValidations[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound13 = 0;
         ScanKeyLoad0C13( ) ;
      }

      protected void ScanKeyLoad0C13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A94WWPFormId = BC000C14_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000C14_A95WWPFormVersionNumber[0];
            A96WWPFormReferenceName = BC000C14_A96WWPFormReferenceName[0];
            A97WWPFormTitle = BC000C14_A97WWPFormTitle[0];
            A119WWPFormDate = BC000C14_A119WWPFormDate[0];
            A120WWPFormIsWizard = BC000C14_A120WWPFormIsWizard[0];
            A104WWPFormResume = BC000C14_A104WWPFormResume[0];
            A123WWPFormResumeMessage = BC000C14_A123WWPFormResumeMessage[0];
            A121WWPFormValidations = BC000C14_A121WWPFormValidations[0];
            A122WWPFormInstantiated = BC000C14_A122WWPFormInstantiated[0];
            A290WWPFormType = BC000C14_A290WWPFormType[0];
            A291WWPFormSectionRefElements = BC000C14_A291WWPFormSectionRefElements[0];
            A292WWPFormIsForDynamicValidations = BC000C14_A292WWPFormIsForDynamicValidations[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0C13( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
      }

      protected void ZM0C14( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z125WWPFormElementCaption = A125WWPFormElementCaption;
            Z105WWPFormElementType = A105WWPFormElementType;
            Z100WWPFormElementOrderIndex = A100WWPFormElementOrderIndex;
            Z106WWPFormElementDataType = A106WWPFormElementDataType;
            Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
            Z126WWPFormElementExcludeFromExport = A126WWPFormElementExcludeFromExport;
            Z99WWPFormElementParentId = A99WWPFormElementParentId;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z118WWPFormElementParentType = A118WWPFormElementParentType;
         }
         if ( GX_JID == -11 )
         {
            Z98WWPFormElementId = A98WWPFormElementId;
            Z125WWPFormElementCaption = A125WWPFormElementCaption;
            Z117WWPFormElementTitle = A117WWPFormElementTitle;
            Z105WWPFormElementType = A105WWPFormElementType;
            Z100WWPFormElementOrderIndex = A100WWPFormElementOrderIndex;
            Z106WWPFormElementDataType = A106WWPFormElementDataType;
            Z124WWPFormElementMetadata = A124WWPFormElementMetadata;
            Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
            Z126WWPFormElementExcludeFromExport = A126WWPFormElementExcludeFromExport;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z99WWPFormElementParentId = A99WWPFormElementParentId;
            Z116WWPFormElementParentName = A116WWPFormElementParentName;
            Z118WWPFormElementParentType = A118WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal0C14( )
      {
      }

      protected void standaloneModal0C14( )
      {
         if ( IsIns( )  && (0==A125WWPFormElementCaption) && ( Gx_BScreen == 0 ) )
         {
            A125WWPFormElementCaption = 1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0C14( )
      {
         /* Using cursor BC000C15 */
         pr_default.execute(13, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound14 = 1;
            A125WWPFormElementCaption = BC000C15_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = BC000C15_A117WWPFormElementTitle[0];
            A105WWPFormElementType = BC000C15_A105WWPFormElementType[0];
            A100WWPFormElementOrderIndex = BC000C15_A100WWPFormElementOrderIndex[0];
            A106WWPFormElementDataType = BC000C15_A106WWPFormElementDataType[0];
            A116WWPFormElementParentName = BC000C15_A116WWPFormElementParentName[0];
            A118WWPFormElementParentType = BC000C15_A118WWPFormElementParentType[0];
            A124WWPFormElementMetadata = BC000C15_A124WWPFormElementMetadata[0];
            A101WWPFormElementReferenceId = BC000C15_A101WWPFormElementReferenceId[0];
            A126WWPFormElementExcludeFromExport = BC000C15_A126WWPFormElementExcludeFromExport[0];
            A99WWPFormElementParentId = BC000C15_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000C15_n99WWPFormElementParentId[0];
            ZM0C14( -11) ;
         }
         pr_default.close(13);
         OnLoadActions0C14( ) ;
      }

      protected void OnLoadActions0C14( )
      {
      }

      protected void CheckExtendedTable0C14( )
      {
         Gx_BScreen = 1;
         standaloneModal0C14( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
            }
         }
         A116WWPFormElementParentName = BC000C4_A116WWPFormElementParentName[0];
         A118WWPFormElementParentType = BC000C4_A118WWPFormElementParentType[0];
         pr_default.close(2);
         if ( ! ( ( A105WWPFormElementType == 1 ) || ( A105WWPFormElementType == 2 ) || ( A105WWPFormElementType == 3 ) || ( A105WWPFormElementType == 4 ) || ( A105WWPFormElementType == 5 ) ) )
         {
            GX_msglist.addItem("Campo WWPForm Element Type fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A106WWPFormElementDataType == 1 ) || ( A106WWPFormElementDataType == 2 ) || ( A106WWPFormElementDataType == 3 ) || ( A106WWPFormElementDataType == 4 ) || ( A106WWPFormElementDataType == 5 ) || ( A106WWPFormElementDataType == 6 ) || ( A106WWPFormElementDataType == 7 ) || ( A106WWPFormElementDataType == 8 ) || ( A106WWPFormElementDataType == 9 ) || ( A106WWPFormElementDataType == 10 ) ) )
         {
            GX_msglist.addItem("Campo WWPForm Element Data Type fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A125WWPFormElementCaption == 1 ) || ( A125WWPFormElementCaption == 2 ) || ( A125WWPFormElementCaption == 3 ) ) )
         {
            GX_msglist.addItem("Campo WWPForm Element Caption fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0C14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0C14( )
      {
      }

      protected void GetKey0C14( )
      {
         /* Using cursor BC000C16 */
         pr_default.execute(14, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0C14( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C14( 11) ;
            RcdFound14 = 1;
            InitializeNonKey0C14( ) ;
            A98WWPFormElementId = BC000C3_A98WWPFormElementId[0];
            A125WWPFormElementCaption = BC000C3_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = BC000C3_A117WWPFormElementTitle[0];
            A105WWPFormElementType = BC000C3_A105WWPFormElementType[0];
            A100WWPFormElementOrderIndex = BC000C3_A100WWPFormElementOrderIndex[0];
            A106WWPFormElementDataType = BC000C3_A106WWPFormElementDataType[0];
            A124WWPFormElementMetadata = BC000C3_A124WWPFormElementMetadata[0];
            A101WWPFormElementReferenceId = BC000C3_A101WWPFormElementReferenceId[0];
            A126WWPFormElementExcludeFromExport = BC000C3_A126WWPFormElementExcludeFromExport[0];
            A99WWPFormElementParentId = BC000C3_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000C3_n99WWPFormElementParentId[0];
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z98WWPFormElementId = A98WWPFormElementId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0C14( ) ;
            Load0C14( ) ;
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0C14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0C14( ) ;
            Gx_mode = sMode14;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0C14( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0C14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z125WWPFormElementCaption != BC000C2_A125WWPFormElementCaption[0] ) || ( Z105WWPFormElementType != BC000C2_A105WWPFormElementType[0] ) || ( Z100WWPFormElementOrderIndex != BC000C2_A100WWPFormElementOrderIndex[0] ) || ( Z106WWPFormElementDataType != BC000C2_A106WWPFormElementDataType[0] ) || ( StringUtil.StrCmp(Z101WWPFormElementReferenceId, BC000C2_A101WWPFormElementReferenceId[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z126WWPFormElementExcludeFromExport != BC000C2_A126WWPFormElementExcludeFromExport[0] ) || ( Z99WWPFormElementParentId != BC000C2_A99WWPFormElementParentId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C14( )
      {
         BeforeValidate0C14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C14( 0) ;
            CheckOptimisticConcurrency0C14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C17 */
                     pr_default.execute(15, new Object[] {A98WWPFormElementId, A125WWPFormElementCaption, A117WWPFormElementTitle, A105WWPFormElementType, A100WWPFormElementOrderIndex, A106WWPFormElementDataType, A124WWPFormElementMetadata, A101WWPFormElementReferenceId, A126WWPFormElementExcludeFromExport, A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load0C14( ) ;
            }
            EndLevel0C14( ) ;
         }
         CloseExtendedTableCursors0C14( ) ;
      }

      protected void Update0C14( )
      {
         BeforeValidate0C14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C18 */
                     pr_default.execute(16, new Object[] {A125WWPFormElementCaption, A117WWPFormElementTitle, A105WWPFormElementType, A100WWPFormElementOrderIndex, A106WWPFormElementDataType, A124WWPFormElementMetadata, A101WWPFormElementReferenceId, A126WWPFormElementExcludeFromExport, n99WWPFormElementParentId, A99WWPFormElementParentId, A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0C14( ) ;
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
            EndLevel0C14( ) ;
         }
         CloseExtendedTableCursors0C14( ) ;
      }

      protected void DeferredUpdate0C14( )
      {
      }

      protected void Delete0C14( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C14( ) ;
            AfterConfirm0C14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C19 */
                  pr_default.execute(17, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C14( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0C14( )
      {
         standaloneModal0C14( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000C20 */
            pr_default.execute(18, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
            A116WWPFormElementParentName = BC000C20_A116WWPFormElementParentName[0];
            A118WWPFormElementParentType = BC000C20_A118WWPFormElementParentType[0];
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C21 */
            pr_default.execute(19, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Element"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel0C14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0C14( )
      {
         /* Scan By routine */
         /* Using cursor BC000C22 */
         pr_default.execute(20, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A98WWPFormElementId = BC000C22_A98WWPFormElementId[0];
            A125WWPFormElementCaption = BC000C22_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = BC000C22_A117WWPFormElementTitle[0];
            A105WWPFormElementType = BC000C22_A105WWPFormElementType[0];
            A100WWPFormElementOrderIndex = BC000C22_A100WWPFormElementOrderIndex[0];
            A106WWPFormElementDataType = BC000C22_A106WWPFormElementDataType[0];
            A116WWPFormElementParentName = BC000C22_A116WWPFormElementParentName[0];
            A118WWPFormElementParentType = BC000C22_A118WWPFormElementParentType[0];
            A124WWPFormElementMetadata = BC000C22_A124WWPFormElementMetadata[0];
            A101WWPFormElementReferenceId = BC000C22_A101WWPFormElementReferenceId[0];
            A126WWPFormElementExcludeFromExport = BC000C22_A126WWPFormElementExcludeFromExport[0];
            A99WWPFormElementParentId = BC000C22_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000C22_n99WWPFormElementParentId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C14( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound14 = 0;
         ScanKeyLoad0C14( ) ;
      }

      protected void ScanKeyLoad0C14( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A98WWPFormElementId = BC000C22_A98WWPFormElementId[0];
            A125WWPFormElementCaption = BC000C22_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = BC000C22_A117WWPFormElementTitle[0];
            A105WWPFormElementType = BC000C22_A105WWPFormElementType[0];
            A100WWPFormElementOrderIndex = BC000C22_A100WWPFormElementOrderIndex[0];
            A106WWPFormElementDataType = BC000C22_A106WWPFormElementDataType[0];
            A116WWPFormElementParentName = BC000C22_A116WWPFormElementParentName[0];
            A118WWPFormElementParentType = BC000C22_A118WWPFormElementParentType[0];
            A124WWPFormElementMetadata = BC000C22_A124WWPFormElementMetadata[0];
            A101WWPFormElementReferenceId = BC000C22_A101WWPFormElementReferenceId[0];
            A126WWPFormElementExcludeFromExport = BC000C22_A126WWPFormElementExcludeFromExport[0];
            A99WWPFormElementParentId = BC000C22_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000C22_n99WWPFormElementParentId[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0C14( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0C14( )
      {
         /* After Confirm Rules */
         if ( (0==A99WWPFormElementParentId) )
         {
            A99WWPFormElementParentId = 0;
            n99WWPFormElementParentId = false;
            n99WWPFormElementParentId = true;
            n99WWPFormElementParentId = true;
         }
      }

      protected void BeforeInsert0C14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C14( )
      {
      }

      protected void send_integrity_lvl_hashes0C14( )
      {
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void AddRow0C13( )
      {
         VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
      }

      protected void ReadRow0C13( )
      {
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
      }

      protected void AddRow0C14( )
      {
         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element obj14;
         obj14 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         VarsToRow14( obj14) ;
         bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Add(obj14, 0);
         obj14.gxTpr_Mode = "UPD";
         obj14.gxTpr_Modified = 0;
      }

      protected void ReadRow0C14( )
      {
         nGXsfl_14_idx = (int)(nGXsfl_14_idx+1);
         RowToVars14( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.Item(nGXsfl_14_idx)), 1) ;
      }

      protected void InitializeNonKey0C13( )
      {
         A107WWPFormLatestVersionNumber = 0;
         A96WWPFormReferenceName = "";
         A97WWPFormTitle = "";
         A119WWPFormDate = (DateTime)(DateTime.MinValue);
         A120WWPFormIsWizard = false;
         A104WWPFormResume = 0;
         A123WWPFormResumeMessage = "";
         A121WWPFormValidations = "";
         A122WWPFormInstantiated = false;
         A290WWPFormType = 0;
         A291WWPFormSectionRefElements = "";
         A292WWPFormIsForDynamicValidations = false;
         Z96WWPFormReferenceName = "";
         Z97WWPFormTitle = "";
         Z119WWPFormDate = (DateTime)(DateTime.MinValue);
         Z120WWPFormIsWizard = false;
         Z104WWPFormResume = 0;
         Z122WWPFormInstantiated = false;
         Z290WWPFormType = 0;
         Z291WWPFormSectionRefElements = "";
         Z292WWPFormIsForDynamicValidations = false;
      }

      protected void InitAll0C13( )
      {
         A94WWPFormId = 0;
         A95WWPFormVersionNumber = 0;
         InitializeNonKey0C13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0C14( )
      {
         A117WWPFormElementTitle = "";
         A105WWPFormElementType = 0;
         A100WWPFormElementOrderIndex = 0;
         A106WWPFormElementDataType = 0;
         A99WWPFormElementParentId = 0;
         n99WWPFormElementParentId = false;
         A116WWPFormElementParentName = "";
         A118WWPFormElementParentType = 0;
         A124WWPFormElementMetadata = "";
         A101WWPFormElementReferenceId = "";
         A126WWPFormElementExcludeFromExport = false;
         A125WWPFormElementCaption = 1;
         Z125WWPFormElementCaption = 0;
         Z105WWPFormElementType = 0;
         Z100WWPFormElementOrderIndex = 0;
         Z106WWPFormElementDataType = 0;
         Z101WWPFormElementReferenceId = "";
         Z126WWPFormElementExcludeFromExport = false;
         Z99WWPFormElementParentId = 0;
      }

      protected void InitAll0C14( )
      {
         A98WWPFormElementId = 0;
         InitializeNonKey0C14( ) ;
      }

      protected void StandaloneModalInsert0C14( )
      {
         A125WWPFormElementCaption = i125WWPFormElementCaption;
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

      public void VarsToRow13( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Wwpformlatestversionnumber = A107WWPFormLatestVersionNumber;
         obj13.gxTpr_Wwpformreferencename = A96WWPFormReferenceName;
         obj13.gxTpr_Wwpformtitle = A97WWPFormTitle;
         obj13.gxTpr_Wwpformdate = A119WWPFormDate;
         obj13.gxTpr_Wwpformiswizard = A120WWPFormIsWizard;
         obj13.gxTpr_Wwpformresume = A104WWPFormResume;
         obj13.gxTpr_Wwpformresumemessage = A123WWPFormResumeMessage;
         obj13.gxTpr_Wwpformvalidations = A121WWPFormValidations;
         obj13.gxTpr_Wwpforminstantiated = A122WWPFormInstantiated;
         obj13.gxTpr_Wwpformtype = A290WWPFormType;
         obj13.gxTpr_Wwpformsectionrefelements = A291WWPFormSectionRefElements;
         obj13.gxTpr_Wwpformisfordynamicvalidations = A292WWPFormIsForDynamicValidations;
         obj13.gxTpr_Wwpformid = A94WWPFormId;
         obj13.gxTpr_Wwpformversionnumber = A95WWPFormVersionNumber;
         obj13.gxTpr_Wwpformid_Z = Z94WWPFormId;
         obj13.gxTpr_Wwpformversionnumber_Z = Z95WWPFormVersionNumber;
         obj13.gxTpr_Wwpformreferencename_Z = Z96WWPFormReferenceName;
         obj13.gxTpr_Wwpformtitle_Z = Z97WWPFormTitle;
         obj13.gxTpr_Wwpformdate_Z = Z119WWPFormDate;
         obj13.gxTpr_Wwpformiswizard_Z = Z120WWPFormIsWizard;
         obj13.gxTpr_Wwpformresume_Z = Z104WWPFormResume;
         obj13.gxTpr_Wwpforminstantiated_Z = Z122WWPFormInstantiated;
         obj13.gxTpr_Wwpformlatestversionnumber_Z = Z107WWPFormLatestVersionNumber;
         obj13.gxTpr_Wwpformtype_Z = Z290WWPFormType;
         obj13.gxTpr_Wwpformsectionrefelements_Z = Z291WWPFormSectionRefElements;
         obj13.gxTpr_Wwpformisfordynamicvalidations_Z = Z292WWPFormIsForDynamicValidations;
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form obj13 )
      {
         obj13.gxTpr_Wwpformid = A94WWPFormId;
         obj13.gxTpr_Wwpformversionnumber = A95WWPFormVersionNumber;
         return  ;
      }

      public void RowToVars13( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A107WWPFormLatestVersionNumber = obj13.gxTpr_Wwpformlatestversionnumber;
         A96WWPFormReferenceName = obj13.gxTpr_Wwpformreferencename;
         A97WWPFormTitle = obj13.gxTpr_Wwpformtitle;
         A119WWPFormDate = obj13.gxTpr_Wwpformdate;
         A120WWPFormIsWizard = obj13.gxTpr_Wwpformiswizard;
         A104WWPFormResume = obj13.gxTpr_Wwpformresume;
         A123WWPFormResumeMessage = obj13.gxTpr_Wwpformresumemessage;
         A121WWPFormValidations = obj13.gxTpr_Wwpformvalidations;
         A122WWPFormInstantiated = obj13.gxTpr_Wwpforminstantiated;
         A290WWPFormType = obj13.gxTpr_Wwpformtype;
         A291WWPFormSectionRefElements = obj13.gxTpr_Wwpformsectionrefelements;
         A292WWPFormIsForDynamicValidations = obj13.gxTpr_Wwpformisfordynamicvalidations;
         A94WWPFormId = obj13.gxTpr_Wwpformid;
         A95WWPFormVersionNumber = obj13.gxTpr_Wwpformversionnumber;
         Z94WWPFormId = obj13.gxTpr_Wwpformid_Z;
         Z95WWPFormVersionNumber = obj13.gxTpr_Wwpformversionnumber_Z;
         Z96WWPFormReferenceName = obj13.gxTpr_Wwpformreferencename_Z;
         Z97WWPFormTitle = obj13.gxTpr_Wwpformtitle_Z;
         Z119WWPFormDate = obj13.gxTpr_Wwpformdate_Z;
         Z120WWPFormIsWizard = obj13.gxTpr_Wwpformiswizard_Z;
         Z104WWPFormResume = obj13.gxTpr_Wwpformresume_Z;
         Z122WWPFormInstantiated = obj13.gxTpr_Wwpforminstantiated_Z;
         Z107WWPFormLatestVersionNumber = obj13.gxTpr_Wwpformlatestversionnumber_Z;
         Z290WWPFormType = obj13.gxTpr_Wwpformtype_Z;
         Z291WWPFormSectionRefElements = obj13.gxTpr_Wwpformsectionrefelements_Z;
         Z292WWPFormIsForDynamicValidations = obj13.gxTpr_Wwpformisfordynamicvalidations_Z;
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow14( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Wwpformelementtitle = A117WWPFormElementTitle;
         obj14.gxTpr_Wwpformelementtype = A105WWPFormElementType;
         obj14.gxTpr_Wwpformelementorderindex = A100WWPFormElementOrderIndex;
         obj14.gxTpr_Wwpformelementdatatype = A106WWPFormElementDataType;
         obj14.gxTpr_Wwpformelementparentid = A99WWPFormElementParentId;
         obj14.gxTpr_Wwpformelementparentname = A116WWPFormElementParentName;
         obj14.gxTpr_Wwpformelementparenttype = A118WWPFormElementParentType;
         obj14.gxTpr_Wwpformelementmetadata = A124WWPFormElementMetadata;
         obj14.gxTpr_Wwpformelementreferenceid = A101WWPFormElementReferenceId;
         obj14.gxTpr_Wwpformelementexcludefromexport = A126WWPFormElementExcludeFromExport;
         obj14.gxTpr_Wwpformelementcaption = A125WWPFormElementCaption;
         obj14.gxTpr_Wwpformelementid = A98WWPFormElementId;
         obj14.gxTpr_Wwpformelementid_Z = Z98WWPFormElementId;
         obj14.gxTpr_Wwpformelementtype_Z = Z105WWPFormElementType;
         obj14.gxTpr_Wwpformelementorderindex_Z = Z100WWPFormElementOrderIndex;
         obj14.gxTpr_Wwpformelementdatatype_Z = Z106WWPFormElementDataType;
         obj14.gxTpr_Wwpformelementparentid_Z = Z99WWPFormElementParentId;
         obj14.gxTpr_Wwpformelementparenttype_Z = Z118WWPFormElementParentType;
         obj14.gxTpr_Wwpformelementcaption_Z = Z125WWPFormElementCaption;
         obj14.gxTpr_Wwpformelementreferenceid_Z = Z101WWPFormElementReferenceId;
         obj14.gxTpr_Wwpformelementexcludefromexport_Z = Z126WWPFormElementExcludeFromExport;
         obj14.gxTpr_Wwpformelementparentid_N = (short)(Convert.ToInt16(n99WWPFormElementParentId));
         obj14.gxTpr_Modified = nIsMod_14;
         return  ;
      }

      public void KeyVarsToRow14( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element obj14 )
      {
         obj14.gxTpr_Wwpformelementid = A98WWPFormElementId;
         return  ;
      }

      public void RowToVars14( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A117WWPFormElementTitle = obj14.gxTpr_Wwpformelementtitle;
         A105WWPFormElementType = obj14.gxTpr_Wwpformelementtype;
         A100WWPFormElementOrderIndex = obj14.gxTpr_Wwpformelementorderindex;
         A106WWPFormElementDataType = obj14.gxTpr_Wwpformelementdatatype;
         A99WWPFormElementParentId = obj14.gxTpr_Wwpformelementparentid;
         n99WWPFormElementParentId = false;
         A116WWPFormElementParentName = obj14.gxTpr_Wwpformelementparentname;
         A118WWPFormElementParentType = obj14.gxTpr_Wwpformelementparenttype;
         A124WWPFormElementMetadata = obj14.gxTpr_Wwpformelementmetadata;
         A101WWPFormElementReferenceId = obj14.gxTpr_Wwpformelementreferenceid;
         A126WWPFormElementExcludeFromExport = obj14.gxTpr_Wwpformelementexcludefromexport;
         A125WWPFormElementCaption = obj14.gxTpr_Wwpformelementcaption;
         A98WWPFormElementId = obj14.gxTpr_Wwpformelementid;
         Z98WWPFormElementId = obj14.gxTpr_Wwpformelementid_Z;
         Z105WWPFormElementType = obj14.gxTpr_Wwpformelementtype_Z;
         Z100WWPFormElementOrderIndex = obj14.gxTpr_Wwpformelementorderindex_Z;
         Z106WWPFormElementDataType = obj14.gxTpr_Wwpformelementdatatype_Z;
         Z99WWPFormElementParentId = obj14.gxTpr_Wwpformelementparentid_Z;
         Z118WWPFormElementParentType = obj14.gxTpr_Wwpformelementparenttype_Z;
         Z125WWPFormElementCaption = obj14.gxTpr_Wwpformelementcaption_Z;
         Z101WWPFormElementReferenceId = obj14.gxTpr_Wwpformelementreferenceid_Z;
         Z126WWPFormElementExcludeFromExport = obj14.gxTpr_Wwpformelementexcludefromexport_Z;
         n99WWPFormElementParentId = (bool)(Convert.ToBoolean(obj14.gxTpr_Wwpformelementparentid_N));
         nIsMod_14 = obj14.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A94WWPFormId = (short)getParm(obj,0);
         A95WWPFormVersionNumber = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C13( ) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
         }
         ZM0C13( -10) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.ClearCollection();
         if ( RcdFound13 == 1 )
         {
            ScanKeyStart0C14( ) ;
            nGXsfl_14_idx = 1;
            while ( RcdFound14 != 0 )
            {
               Z94WWPFormId = A94WWPFormId;
               Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
               Z98WWPFormElementId = A98WWPFormElementId;
               ZM0C14( -11) ;
               OnLoadActions0C14( ) ;
               nRcdExists_14 = 1;
               nIsMod_14 = 0;
               AddRow0C14( ) ;
               nGXsfl_14_idx = (int)(nGXsfl_14_idx+1);
               ScanKeyNext0C14( ) ;
            }
            ScanKeyEnd0C14( ) ;
         }
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 0) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
         }
         ZM0C13( -10) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Element.ClearCollection();
         if ( RcdFound13 == 1 )
         {
            ScanKeyStart0C14( ) ;
            nGXsfl_14_idx = 1;
            while ( RcdFound14 != 0 )
            {
               Z94WWPFormId = A94WWPFormId;
               Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
               Z98WWPFormElementId = A98WWPFormElementId;
               ZM0C14( -11) ;
               OnLoadActions0C14( ) ;
               nRcdExists_14 = 1;
               nIsMod_14 = 0;
               AddRow0C14( ) ;
               nGXsfl_14_idx = (int)(nGXsfl_14_idx+1);
               ScanKeyNext0C14( ) ;
            }
            ScanKeyEnd0C14( ) ;
         }
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
               {
                  A94WWPFormId = Z94WWPFormId;
                  A95WWPFormVersionNumber = Z95WWPFormVersionNumber;
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
                  Update0C13( ) ;
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
                  if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
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
                        Insert0C13( ) ;
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
                        Insert0C13( ) ;
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
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form auxBC = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A94WWPFormId, A95WWPFormVersionNumber);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_dynamicforms_WWP_Form);
               auxBC.Save();
               bcworkwithplus_dynamicforms_WWP_Form.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
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
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
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
               VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
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
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 0) ;
         GetKey0C13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
            {
               A94WWPFormId = Z94WWPFormId;
               A95WWPFormVersionNumber = Z95WWPFormVersionNumber;
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
            if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
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
         context.RollbackDataStores("workwithplus.dynamicforms.wwp_form_bc",pr_default);
         VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
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
         Gx_mode = bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_dynamicforms_WWP_Form )
         {
            bcworkwithplus_dynamicforms_WWP_Form = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcworkwithplus_dynamicforms_WWP_Form) ;
            }
            else
            {
               RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_dynamicforms_WWP_Form.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcworkwithplus_dynamicforms_WWP_Form, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Form WWP_Form_BC
      {
         get {
            return bcworkwithplus_dynamicforms_WWP_Form ;
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
         pr_default.close(18);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode13 = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z96WWPFormReferenceName = "";
         A96WWPFormReferenceName = "";
         Z97WWPFormTitle = "";
         A97WWPFormTitle = "";
         Z119WWPFormDate = (DateTime)(DateTime.MinValue);
         A119WWPFormDate = (DateTime)(DateTime.MinValue);
         Z291WWPFormSectionRefElements = "";
         A291WWPFormSectionRefElements = "";
         Z123WWPFormResumeMessage = "";
         A123WWPFormResumeMessage = "";
         Z121WWPFormValidations = "";
         A121WWPFormValidations = "";
         BC000C7_A94WWPFormId = new short[1] ;
         BC000C7_A95WWPFormVersionNumber = new short[1] ;
         BC000C7_A96WWPFormReferenceName = new string[] {""} ;
         BC000C7_A97WWPFormTitle = new string[] {""} ;
         BC000C7_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC000C7_A120WWPFormIsWizard = new bool[] {false} ;
         BC000C7_A104WWPFormResume = new short[1] ;
         BC000C7_A123WWPFormResumeMessage = new string[] {""} ;
         BC000C7_A121WWPFormValidations = new string[] {""} ;
         BC000C7_A122WWPFormInstantiated = new bool[] {false} ;
         BC000C7_A290WWPFormType = new short[1] ;
         BC000C7_A291WWPFormSectionRefElements = new string[] {""} ;
         BC000C7_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC000C8_A94WWPFormId = new short[1] ;
         BC000C8_A95WWPFormVersionNumber = new short[1] ;
         BC000C6_A94WWPFormId = new short[1] ;
         BC000C6_A95WWPFormVersionNumber = new short[1] ;
         BC000C6_A96WWPFormReferenceName = new string[] {""} ;
         BC000C6_A97WWPFormTitle = new string[] {""} ;
         BC000C6_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC000C6_A120WWPFormIsWizard = new bool[] {false} ;
         BC000C6_A104WWPFormResume = new short[1] ;
         BC000C6_A123WWPFormResumeMessage = new string[] {""} ;
         BC000C6_A121WWPFormValidations = new string[] {""} ;
         BC000C6_A122WWPFormInstantiated = new bool[] {false} ;
         BC000C6_A290WWPFormType = new short[1] ;
         BC000C6_A291WWPFormSectionRefElements = new string[] {""} ;
         BC000C6_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC000C5_A94WWPFormId = new short[1] ;
         BC000C5_A95WWPFormVersionNumber = new short[1] ;
         BC000C5_A96WWPFormReferenceName = new string[] {""} ;
         BC000C5_A97WWPFormTitle = new string[] {""} ;
         BC000C5_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC000C5_A120WWPFormIsWizard = new bool[] {false} ;
         BC000C5_A104WWPFormResume = new short[1] ;
         BC000C5_A123WWPFormResumeMessage = new string[] {""} ;
         BC000C5_A121WWPFormValidations = new string[] {""} ;
         BC000C5_A122WWPFormInstantiated = new bool[] {false} ;
         BC000C5_A290WWPFormType = new short[1] ;
         BC000C5_A291WWPFormSectionRefElements = new string[] {""} ;
         BC000C5_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC000C12_A102WWPFormInstanceId = new int[1] ;
         BC000C13_A94WWPFormId = new short[1] ;
         BC000C13_A95WWPFormVersionNumber = new short[1] ;
         BC000C13_A99WWPFormElementParentId = new short[1] ;
         BC000C13_n99WWPFormElementParentId = new bool[] {false} ;
         BC000C14_A94WWPFormId = new short[1] ;
         BC000C14_A95WWPFormVersionNumber = new short[1] ;
         BC000C14_A96WWPFormReferenceName = new string[] {""} ;
         BC000C14_A97WWPFormTitle = new string[] {""} ;
         BC000C14_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC000C14_A120WWPFormIsWizard = new bool[] {false} ;
         BC000C14_A104WWPFormResume = new short[1] ;
         BC000C14_A123WWPFormResumeMessage = new string[] {""} ;
         BC000C14_A121WWPFormValidations = new string[] {""} ;
         BC000C14_A122WWPFormInstantiated = new bool[] {false} ;
         BC000C14_A290WWPFormType = new short[1] ;
         BC000C14_A291WWPFormSectionRefElements = new string[] {""} ;
         BC000C14_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         Z101WWPFormElementReferenceId = "";
         A101WWPFormElementReferenceId = "";
         Z117WWPFormElementTitle = "";
         A117WWPFormElementTitle = "";
         Z124WWPFormElementMetadata = "";
         A124WWPFormElementMetadata = "";
         Z116WWPFormElementParentName = "";
         A116WWPFormElementParentName = "";
         BC000C15_A98WWPFormElementId = new short[1] ;
         BC000C15_A125WWPFormElementCaption = new short[1] ;
         BC000C15_A117WWPFormElementTitle = new string[] {""} ;
         BC000C15_A105WWPFormElementType = new short[1] ;
         BC000C15_A100WWPFormElementOrderIndex = new short[1] ;
         BC000C15_A106WWPFormElementDataType = new short[1] ;
         BC000C15_A116WWPFormElementParentName = new string[] {""} ;
         BC000C15_A118WWPFormElementParentType = new short[1] ;
         BC000C15_A124WWPFormElementMetadata = new string[] {""} ;
         BC000C15_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000C15_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         BC000C15_A94WWPFormId = new short[1] ;
         BC000C15_A95WWPFormVersionNumber = new short[1] ;
         BC000C15_A99WWPFormElementParentId = new short[1] ;
         BC000C15_n99WWPFormElementParentId = new bool[] {false} ;
         BC000C4_A116WWPFormElementParentName = new string[] {""} ;
         BC000C4_A118WWPFormElementParentType = new short[1] ;
         BC000C16_A94WWPFormId = new short[1] ;
         BC000C16_A95WWPFormVersionNumber = new short[1] ;
         BC000C16_A98WWPFormElementId = new short[1] ;
         BC000C3_A98WWPFormElementId = new short[1] ;
         BC000C3_A125WWPFormElementCaption = new short[1] ;
         BC000C3_A117WWPFormElementTitle = new string[] {""} ;
         BC000C3_A105WWPFormElementType = new short[1] ;
         BC000C3_A100WWPFormElementOrderIndex = new short[1] ;
         BC000C3_A106WWPFormElementDataType = new short[1] ;
         BC000C3_A124WWPFormElementMetadata = new string[] {""} ;
         BC000C3_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000C3_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         BC000C3_A94WWPFormId = new short[1] ;
         BC000C3_A95WWPFormVersionNumber = new short[1] ;
         BC000C3_A99WWPFormElementParentId = new short[1] ;
         BC000C3_n99WWPFormElementParentId = new bool[] {false} ;
         sMode14 = "";
         BC000C2_A98WWPFormElementId = new short[1] ;
         BC000C2_A125WWPFormElementCaption = new short[1] ;
         BC000C2_A117WWPFormElementTitle = new string[] {""} ;
         BC000C2_A105WWPFormElementType = new short[1] ;
         BC000C2_A100WWPFormElementOrderIndex = new short[1] ;
         BC000C2_A106WWPFormElementDataType = new short[1] ;
         BC000C2_A124WWPFormElementMetadata = new string[] {""} ;
         BC000C2_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000C2_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         BC000C2_A94WWPFormId = new short[1] ;
         BC000C2_A95WWPFormVersionNumber = new short[1] ;
         BC000C2_A99WWPFormElementParentId = new short[1] ;
         BC000C2_n99WWPFormElementParentId = new bool[] {false} ;
         BC000C20_A116WWPFormElementParentName = new string[] {""} ;
         BC000C20_A118WWPFormElementParentType = new short[1] ;
         BC000C21_A94WWPFormId = new short[1] ;
         BC000C21_A95WWPFormVersionNumber = new short[1] ;
         BC000C21_A99WWPFormElementParentId = new short[1] ;
         BC000C21_n99WWPFormElementParentId = new bool[] {false} ;
         BC000C22_A98WWPFormElementId = new short[1] ;
         BC000C22_A125WWPFormElementCaption = new short[1] ;
         BC000C22_A117WWPFormElementTitle = new string[] {""} ;
         BC000C22_A105WWPFormElementType = new short[1] ;
         BC000C22_A100WWPFormElementOrderIndex = new short[1] ;
         BC000C22_A106WWPFormElementDataType = new short[1] ;
         BC000C22_A116WWPFormElementParentName = new string[] {""} ;
         BC000C22_A118WWPFormElementParentType = new short[1] ;
         BC000C22_A124WWPFormElementMetadata = new string[] {""} ;
         BC000C22_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000C22_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         BC000C22_A94WWPFormId = new short[1] ;
         BC000C22_A95WWPFormVersionNumber = new short[1] ;
         BC000C22_A99WWPFormElementParentId = new short[1] ;
         BC000C22_n99WWPFormElementParentId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_form_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A98WWPFormElementId, BC000C2_A125WWPFormElementCaption, BC000C2_A117WWPFormElementTitle, BC000C2_A105WWPFormElementType, BC000C2_A100WWPFormElementOrderIndex, BC000C2_A106WWPFormElementDataType, BC000C2_A124WWPFormElementMetadata, BC000C2_A101WWPFormElementReferenceId, BC000C2_A126WWPFormElementExcludeFromExport, BC000C2_A94WWPFormId,
               BC000C2_A95WWPFormVersionNumber, BC000C2_A99WWPFormElementParentId, BC000C2_n99WWPFormElementParentId
               }
               , new Object[] {
               BC000C3_A98WWPFormElementId, BC000C3_A125WWPFormElementCaption, BC000C3_A117WWPFormElementTitle, BC000C3_A105WWPFormElementType, BC000C3_A100WWPFormElementOrderIndex, BC000C3_A106WWPFormElementDataType, BC000C3_A124WWPFormElementMetadata, BC000C3_A101WWPFormElementReferenceId, BC000C3_A126WWPFormElementExcludeFromExport, BC000C3_A94WWPFormId,
               BC000C3_A95WWPFormVersionNumber, BC000C3_A99WWPFormElementParentId, BC000C3_n99WWPFormElementParentId
               }
               , new Object[] {
               BC000C4_A116WWPFormElementParentName, BC000C4_A118WWPFormElementParentType
               }
               , new Object[] {
               BC000C5_A94WWPFormId, BC000C5_A95WWPFormVersionNumber, BC000C5_A96WWPFormReferenceName, BC000C5_A97WWPFormTitle, BC000C5_A119WWPFormDate, BC000C5_A120WWPFormIsWizard, BC000C5_A104WWPFormResume, BC000C5_A123WWPFormResumeMessage, BC000C5_A121WWPFormValidations, BC000C5_A122WWPFormInstantiated,
               BC000C5_A290WWPFormType, BC000C5_A291WWPFormSectionRefElements, BC000C5_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC000C6_A94WWPFormId, BC000C6_A95WWPFormVersionNumber, BC000C6_A96WWPFormReferenceName, BC000C6_A97WWPFormTitle, BC000C6_A119WWPFormDate, BC000C6_A120WWPFormIsWizard, BC000C6_A104WWPFormResume, BC000C6_A123WWPFormResumeMessage, BC000C6_A121WWPFormValidations, BC000C6_A122WWPFormInstantiated,
               BC000C6_A290WWPFormType, BC000C6_A291WWPFormSectionRefElements, BC000C6_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC000C7_A94WWPFormId, BC000C7_A95WWPFormVersionNumber, BC000C7_A96WWPFormReferenceName, BC000C7_A97WWPFormTitle, BC000C7_A119WWPFormDate, BC000C7_A120WWPFormIsWizard, BC000C7_A104WWPFormResume, BC000C7_A123WWPFormResumeMessage, BC000C7_A121WWPFormValidations, BC000C7_A122WWPFormInstantiated,
               BC000C7_A290WWPFormType, BC000C7_A291WWPFormSectionRefElements, BC000C7_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC000C8_A94WWPFormId, BC000C8_A95WWPFormVersionNumber
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C12_A102WWPFormInstanceId
               }
               , new Object[] {
               BC000C13_A94WWPFormId, BC000C13_A95WWPFormVersionNumber, BC000C13_A99WWPFormElementParentId
               }
               , new Object[] {
               BC000C14_A94WWPFormId, BC000C14_A95WWPFormVersionNumber, BC000C14_A96WWPFormReferenceName, BC000C14_A97WWPFormTitle, BC000C14_A119WWPFormDate, BC000C14_A120WWPFormIsWizard, BC000C14_A104WWPFormResume, BC000C14_A123WWPFormResumeMessage, BC000C14_A121WWPFormValidations, BC000C14_A122WWPFormInstantiated,
               BC000C14_A290WWPFormType, BC000C14_A291WWPFormSectionRefElements, BC000C14_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC000C15_A98WWPFormElementId, BC000C15_A125WWPFormElementCaption, BC000C15_A117WWPFormElementTitle, BC000C15_A105WWPFormElementType, BC000C15_A100WWPFormElementOrderIndex, BC000C15_A106WWPFormElementDataType, BC000C15_A116WWPFormElementParentName, BC000C15_A118WWPFormElementParentType, BC000C15_A124WWPFormElementMetadata, BC000C15_A101WWPFormElementReferenceId,
               BC000C15_A126WWPFormElementExcludeFromExport, BC000C15_A94WWPFormId, BC000C15_A95WWPFormVersionNumber, BC000C15_A99WWPFormElementParentId, BC000C15_n99WWPFormElementParentId
               }
               , new Object[] {
               BC000C16_A94WWPFormId, BC000C16_A95WWPFormVersionNumber, BC000C16_A98WWPFormElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C20_A116WWPFormElementParentName, BC000C20_A118WWPFormElementParentType
               }
               , new Object[] {
               BC000C21_A94WWPFormId, BC000C21_A95WWPFormVersionNumber, BC000C21_A99WWPFormElementParentId
               }
               , new Object[] {
               BC000C22_A98WWPFormElementId, BC000C22_A125WWPFormElementCaption, BC000C22_A117WWPFormElementTitle, BC000C22_A105WWPFormElementType, BC000C22_A100WWPFormElementOrderIndex, BC000C22_A106WWPFormElementDataType, BC000C22_A116WWPFormElementParentName, BC000C22_A118WWPFormElementParentType, BC000C22_A124WWPFormElementMetadata, BC000C22_A101WWPFormElementReferenceId,
               BC000C22_A126WWPFormElementExcludeFromExport, BC000C22_A94WWPFormId, BC000C22_A95WWPFormVersionNumber, BC000C22_A99WWPFormElementParentId, BC000C22_n99WWPFormElementParentId
               }
            }
         );
         Z125WWPFormElementCaption = 1;
         A125WWPFormElementCaption = 1;
         i125WWPFormElementCaption = 1;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120C2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z94WWPFormId ;
      private short A94WWPFormId ;
      private short Z95WWPFormVersionNumber ;
      private short A95WWPFormVersionNumber ;
      private short nIsMod_14 ;
      private short RcdFound14 ;
      private short Z104WWPFormResume ;
      private short A104WWPFormResume ;
      private short Z290WWPFormType ;
      private short A290WWPFormType ;
      private short Z107WWPFormLatestVersionNumber ;
      private short A107WWPFormLatestVersionNumber ;
      private short Gx_BScreen ;
      private short RcdFound13 ;
      private short GXt_int1 ;
      private short nRcdExists_14 ;
      private short Z125WWPFormElementCaption ;
      private short A125WWPFormElementCaption ;
      private short Z105WWPFormElementType ;
      private short A105WWPFormElementType ;
      private short Z100WWPFormElementOrderIndex ;
      private short A100WWPFormElementOrderIndex ;
      private short Z106WWPFormElementDataType ;
      private short A106WWPFormElementDataType ;
      private short Z99WWPFormElementParentId ;
      private short A99WWPFormElementParentId ;
      private short Z118WWPFormElementParentType ;
      private short A118WWPFormElementParentType ;
      private short Z98WWPFormElementId ;
      private short A98WWPFormElementId ;
      private short Gxremove14 ;
      private short i125WWPFormElementCaption ;
      private int trnEnded ;
      private int nGXsfl_14_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode13 ;
      private string sMode14 ;
      private DateTime Z119WWPFormDate ;
      private DateTime A119WWPFormDate ;
      private bool returnInSub ;
      private bool Z120WWPFormIsWizard ;
      private bool A120WWPFormIsWizard ;
      private bool Z122WWPFormInstantiated ;
      private bool A122WWPFormInstantiated ;
      private bool Z292WWPFormIsForDynamicValidations ;
      private bool A292WWPFormIsForDynamicValidations ;
      private bool Gx_longc ;
      private bool Z126WWPFormElementExcludeFromExport ;
      private bool A126WWPFormElementExcludeFromExport ;
      private bool n99WWPFormElementParentId ;
      private string Z123WWPFormResumeMessage ;
      private string A123WWPFormResumeMessage ;
      private string Z121WWPFormValidations ;
      private string A121WWPFormValidations ;
      private string Z117WWPFormElementTitle ;
      private string A117WWPFormElementTitle ;
      private string Z124WWPFormElementMetadata ;
      private string A124WWPFormElementMetadata ;
      private string Z116WWPFormElementParentName ;
      private string A116WWPFormElementParentName ;
      private string Z96WWPFormReferenceName ;
      private string A96WWPFormReferenceName ;
      private string Z97WWPFormTitle ;
      private string A97WWPFormTitle ;
      private string Z291WWPFormSectionRefElements ;
      private string A291WWPFormSectionRefElements ;
      private string Z101WWPFormElementReferenceId ;
      private string A101WWPFormElementReferenceId ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form bcworkwithplus_dynamicforms_WWP_Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000C7_A94WWPFormId ;
      private short[] BC000C7_A95WWPFormVersionNumber ;
      private string[] BC000C7_A96WWPFormReferenceName ;
      private string[] BC000C7_A97WWPFormTitle ;
      private DateTime[] BC000C7_A119WWPFormDate ;
      private bool[] BC000C7_A120WWPFormIsWizard ;
      private short[] BC000C7_A104WWPFormResume ;
      private string[] BC000C7_A123WWPFormResumeMessage ;
      private string[] BC000C7_A121WWPFormValidations ;
      private bool[] BC000C7_A122WWPFormInstantiated ;
      private short[] BC000C7_A290WWPFormType ;
      private string[] BC000C7_A291WWPFormSectionRefElements ;
      private bool[] BC000C7_A292WWPFormIsForDynamicValidations ;
      private short[] BC000C8_A94WWPFormId ;
      private short[] BC000C8_A95WWPFormVersionNumber ;
      private short[] BC000C6_A94WWPFormId ;
      private short[] BC000C6_A95WWPFormVersionNumber ;
      private string[] BC000C6_A96WWPFormReferenceName ;
      private string[] BC000C6_A97WWPFormTitle ;
      private DateTime[] BC000C6_A119WWPFormDate ;
      private bool[] BC000C6_A120WWPFormIsWizard ;
      private short[] BC000C6_A104WWPFormResume ;
      private string[] BC000C6_A123WWPFormResumeMessage ;
      private string[] BC000C6_A121WWPFormValidations ;
      private bool[] BC000C6_A122WWPFormInstantiated ;
      private short[] BC000C6_A290WWPFormType ;
      private string[] BC000C6_A291WWPFormSectionRefElements ;
      private bool[] BC000C6_A292WWPFormIsForDynamicValidations ;
      private short[] BC000C5_A94WWPFormId ;
      private short[] BC000C5_A95WWPFormVersionNumber ;
      private string[] BC000C5_A96WWPFormReferenceName ;
      private string[] BC000C5_A97WWPFormTitle ;
      private DateTime[] BC000C5_A119WWPFormDate ;
      private bool[] BC000C5_A120WWPFormIsWizard ;
      private short[] BC000C5_A104WWPFormResume ;
      private string[] BC000C5_A123WWPFormResumeMessage ;
      private string[] BC000C5_A121WWPFormValidations ;
      private bool[] BC000C5_A122WWPFormInstantiated ;
      private short[] BC000C5_A290WWPFormType ;
      private string[] BC000C5_A291WWPFormSectionRefElements ;
      private bool[] BC000C5_A292WWPFormIsForDynamicValidations ;
      private int[] BC000C12_A102WWPFormInstanceId ;
      private short[] BC000C13_A94WWPFormId ;
      private short[] BC000C13_A95WWPFormVersionNumber ;
      private short[] BC000C13_A99WWPFormElementParentId ;
      private bool[] BC000C13_n99WWPFormElementParentId ;
      private short[] BC000C14_A94WWPFormId ;
      private short[] BC000C14_A95WWPFormVersionNumber ;
      private string[] BC000C14_A96WWPFormReferenceName ;
      private string[] BC000C14_A97WWPFormTitle ;
      private DateTime[] BC000C14_A119WWPFormDate ;
      private bool[] BC000C14_A120WWPFormIsWizard ;
      private short[] BC000C14_A104WWPFormResume ;
      private string[] BC000C14_A123WWPFormResumeMessage ;
      private string[] BC000C14_A121WWPFormValidations ;
      private bool[] BC000C14_A122WWPFormInstantiated ;
      private short[] BC000C14_A290WWPFormType ;
      private string[] BC000C14_A291WWPFormSectionRefElements ;
      private bool[] BC000C14_A292WWPFormIsForDynamicValidations ;
      private short[] BC000C15_A98WWPFormElementId ;
      private short[] BC000C15_A125WWPFormElementCaption ;
      private string[] BC000C15_A117WWPFormElementTitle ;
      private short[] BC000C15_A105WWPFormElementType ;
      private short[] BC000C15_A100WWPFormElementOrderIndex ;
      private short[] BC000C15_A106WWPFormElementDataType ;
      private string[] BC000C15_A116WWPFormElementParentName ;
      private short[] BC000C15_A118WWPFormElementParentType ;
      private string[] BC000C15_A124WWPFormElementMetadata ;
      private string[] BC000C15_A101WWPFormElementReferenceId ;
      private bool[] BC000C15_A126WWPFormElementExcludeFromExport ;
      private short[] BC000C15_A94WWPFormId ;
      private short[] BC000C15_A95WWPFormVersionNumber ;
      private short[] BC000C15_A99WWPFormElementParentId ;
      private bool[] BC000C15_n99WWPFormElementParentId ;
      private string[] BC000C4_A116WWPFormElementParentName ;
      private short[] BC000C4_A118WWPFormElementParentType ;
      private short[] BC000C16_A94WWPFormId ;
      private short[] BC000C16_A95WWPFormVersionNumber ;
      private short[] BC000C16_A98WWPFormElementId ;
      private short[] BC000C3_A98WWPFormElementId ;
      private short[] BC000C3_A125WWPFormElementCaption ;
      private string[] BC000C3_A117WWPFormElementTitle ;
      private short[] BC000C3_A105WWPFormElementType ;
      private short[] BC000C3_A100WWPFormElementOrderIndex ;
      private short[] BC000C3_A106WWPFormElementDataType ;
      private string[] BC000C3_A124WWPFormElementMetadata ;
      private string[] BC000C3_A101WWPFormElementReferenceId ;
      private bool[] BC000C3_A126WWPFormElementExcludeFromExport ;
      private short[] BC000C3_A94WWPFormId ;
      private short[] BC000C3_A95WWPFormVersionNumber ;
      private short[] BC000C3_A99WWPFormElementParentId ;
      private bool[] BC000C3_n99WWPFormElementParentId ;
      private short[] BC000C2_A98WWPFormElementId ;
      private short[] BC000C2_A125WWPFormElementCaption ;
      private string[] BC000C2_A117WWPFormElementTitle ;
      private short[] BC000C2_A105WWPFormElementType ;
      private short[] BC000C2_A100WWPFormElementOrderIndex ;
      private short[] BC000C2_A106WWPFormElementDataType ;
      private string[] BC000C2_A124WWPFormElementMetadata ;
      private string[] BC000C2_A101WWPFormElementReferenceId ;
      private bool[] BC000C2_A126WWPFormElementExcludeFromExport ;
      private short[] BC000C2_A94WWPFormId ;
      private short[] BC000C2_A95WWPFormVersionNumber ;
      private short[] BC000C2_A99WWPFormElementParentId ;
      private bool[] BC000C2_n99WWPFormElementParentId ;
      private string[] BC000C20_A116WWPFormElementParentName ;
      private short[] BC000C20_A118WWPFormElementParentType ;
      private short[] BC000C21_A94WWPFormId ;
      private short[] BC000C21_A95WWPFormVersionNumber ;
      private short[] BC000C21_A99WWPFormElementParentId ;
      private bool[] BC000C21_n99WWPFormElementParentId ;
      private short[] BC000C22_A98WWPFormElementId ;
      private short[] BC000C22_A125WWPFormElementCaption ;
      private string[] BC000C22_A117WWPFormElementTitle ;
      private short[] BC000C22_A105WWPFormElementType ;
      private short[] BC000C22_A100WWPFormElementOrderIndex ;
      private short[] BC000C22_A106WWPFormElementDataType ;
      private string[] BC000C22_A116WWPFormElementParentName ;
      private short[] BC000C22_A118WWPFormElementParentType ;
      private string[] BC000C22_A124WWPFormElementMetadata ;
      private string[] BC000C22_A101WWPFormElementReferenceId ;
      private bool[] BC000C22_A126WWPFormElementExcludeFromExport ;
      private short[] BC000C22_A94WWPFormId ;
      private short[] BC000C22_A95WWPFormVersionNumber ;
      private short[] BC000C22_A99WWPFormElementParentId ;
      private bool[] BC000C22_n99WWPFormElementParentId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_form_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000C2;
          prmBC000C2 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C3;
          prmBC000C3 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C4;
          prmBC000C4 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000C5;
          prmBC000C5 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C6;
          prmBC000C6 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C7;
          prmBC000C7 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C8;
          prmBC000C8 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C9;
          prmBC000C9 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
          new ParDef("WWPFormResume",GXType.Int16,1,0) ,
          new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
          new ParDef("WWPFormType",GXType.Int16,1,0) ,
          new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
          new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0)
          };
          Object[] prmBC000C10;
          prmBC000C10 = new Object[] {
          new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
          new ParDef("WWPFormResume",GXType.Int16,1,0) ,
          new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
          new ParDef("WWPFormType",GXType.Int16,1,0) ,
          new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
          new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0) ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C11;
          prmBC000C11 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C12;
          prmBC000C12 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C13;
          prmBC000C13 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C14;
          prmBC000C14 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000C15;
          prmBC000C15 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C16;
          prmBC000C16 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C17;
          prmBC000C17 = new Object[] {
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
          new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
          new ParDef("WWPFormElementExcludeFromExport",GXType.Boolean,4,0) ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000C18;
          prmBC000C18 = new Object[] {
          new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
          new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
          new ParDef("WWPFormElementExcludeFromExport",GXType.Boolean,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C19;
          prmBC000C19 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C20;
          prmBC000C20 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000C21;
          prmBC000C21 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000C22;
          prmBC000C22 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000C2", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExport, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId  FOR UPDATE OF WWP_FormElement",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C3", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExport, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C4", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C5", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber  FOR UPDATE OF WWP_Form",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C6", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C7", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C8", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C9", "SAVEPOINT gxupdate;INSERT INTO WWP_Form(WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations) VALUES(:WWPFormId, :WWPFormVersionNumber, :WWPFormReferenceName, :WWPFormTitle, :WWPFormDate, :WWPFormIsWizard, :WWPFormResume, :WWPFormResumeMessage, :WWPFormValidations, :WWPFormInstantiated, :WWPFormType, :WWPFormSectionRefElements, :WWPFormIsForDynamicValidations);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000C9)
             ,new CursorDef("BC000C10", "SAVEPOINT gxupdate;UPDATE WWP_Form SET WWPFormReferenceName=:WWPFormReferenceName, WWPFormTitle=:WWPFormTitle, WWPFormDate=:WWPFormDate, WWPFormIsWizard=:WWPFormIsWizard, WWPFormResume=:WWPFormResume, WWPFormResumeMessage=:WWPFormResumeMessage, WWPFormValidations=:WWPFormValidations, WWPFormInstantiated=:WWPFormInstantiated, WWPFormType=:WWPFormType, WWPFormSectionRefElements=:WWPFormSectionRefElements, WWPFormIsForDynamicValidations=:WWPFormIsForDynamicValidations  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C10)
             ,new CursorDef("BC000C11", "SAVEPOINT gxupdate;DELETE FROM WWP_Form  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C11)
             ,new CursorDef("BC000C12", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C13", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C14", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C15", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExport, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C15,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C16", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C17", "SAVEPOINT gxupdate;INSERT INTO WWP_FormElement(WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExport, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) VALUES(:WWPFormElementId, :WWPFormElementCaption, :WWPFormElementTitle, :WWPFormElementType, :WWPFormElementOrderIndex, :WWPFormElementDataType, :WWPFormElementMetadata, :WWPFormElementReferenceId, :WWPFormElementExcludeFromExport, :WWPFormId, :WWPFormVersionNumber, :WWPFormElementParentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000C17)
             ,new CursorDef("BC000C18", "SAVEPOINT gxupdate;UPDATE WWP_FormElement SET WWPFormElementCaption=:WWPFormElementCaption, WWPFormElementTitle=:WWPFormElementTitle, WWPFormElementType=:WWPFormElementType, WWPFormElementOrderIndex=:WWPFormElementOrderIndex, WWPFormElementDataType=:WWPFormElementDataType, WWPFormElementMetadata=:WWPFormElementMetadata, WWPFormElementReferenceId=:WWPFormElementReferenceId, WWPFormElementExcludeFromExport=:WWPFormElementExcludeFromExport, WWPFormElementParentId=:WWPFormElementParentId  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C18)
             ,new CursorDef("BC000C19", "SAVEPOINT gxupdate;DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C19)
             ,new CursorDef("BC000C20", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C21", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementParentId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C22", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExport, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C22,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.getBool(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((bool[]) buf[14])[0] = rslt.wasNull(14);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.getBool(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((bool[]) buf[14])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
