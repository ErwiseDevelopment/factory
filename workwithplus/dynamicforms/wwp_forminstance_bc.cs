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
   public class wwp_forminstance_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_forminstance_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_forminstance_bc( IGxContext context )
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
         ReadRow0D15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D15( ) ;
         standaloneModal( ) ;
         AddRow0D15( ) ;
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
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z102WWPFormInstanceId = A102WWPFormInstanceId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D15( ) ;
            }
            else
            {
               CheckExtendedTable0D15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0D15( 5) ;
               }
               CloseExtendedTableCursors0D15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode15 = Gx_mode;
            CONFIRM_0D16( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode15;
            }
            /* Restore parent mode. */
            Gx_mode = sMode15;
         }
      }

      protected void CONFIRM_0D16( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Count )
         {
            ReadRow0D16( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0D16( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0D16( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0D16( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0D16( 7) ;
                           ZM0D16( 8) ;
                        }
                        CloseExtendedTableCursors0D16( ) ;
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
                  if ( RcdFound16 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0D16( ) ;
                        Load0D16( ) ;
                        BeforeValidate0D16( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0D16( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0D16( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0D16( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0D16( 7) ;
                                 ZM0D16( 8) ;
                              }
                              CloseExtendedTableCursors0D16( ) ;
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
               VarsToRow16( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_16_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormId") == 0 )
               {
                  AV11Insert_WWPFormId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormVersionNumber") == 0 )
               {
                  AV12Insert_WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
         }
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0D15( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z127WWPFormInstanceDate = A127WWPFormInstanceDate;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z97WWPFormTitle = A97WWPFormTitle;
            Z104WWPFormResume = A104WWPFormResume;
         }
         if ( GX_JID == -4 )
         {
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            Z127WWPFormInstanceDate = A127WWPFormInstanceDate;
            Z293WWPFormInstanceRecordKey = A293WWPFormInstanceRecordKey;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z97WWPFormTitle = A97WWPFormTitle;
            Z104WWPFormResume = A104WWPFormResume;
            Z121WWPFormValidations = A121WWPFormValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         AV16Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance_BC";
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A127WWPFormInstanceDate) && ( Gx_BScreen == 0 ) )
         {
            A127WWPFormInstanceDate = Gx_date;
         }
      }

      protected void Load0D15( )
      {
         /* Using cursor BC000D9 */
         pr_default.execute(7, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound15 = 1;
            A127WWPFormInstanceDate = BC000D9_A127WWPFormInstanceDate[0];
            A97WWPFormTitle = BC000D9_A97WWPFormTitle[0];
            A104WWPFormResume = BC000D9_A104WWPFormResume[0];
            A121WWPFormValidations = BC000D9_A121WWPFormValidations[0];
            A293WWPFormInstanceRecordKey = BC000D9_A293WWPFormInstanceRecordKey[0];
            n293WWPFormInstanceRecordKey = BC000D9_n293WWPFormInstanceRecordKey[0];
            A94WWPFormId = BC000D9_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000D9_A95WWPFormVersionNumber[0];
            ZM0D15( -4) ;
         }
         pr_default.close(7);
         OnLoadActions0D15( ) ;
      }

      protected void OnLoadActions0D15( )
      {
      }

      protected void CheckExtendedTable0D15( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000D8 */
         pr_default.execute(6, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Dynamic Form'.", "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A97WWPFormTitle = BC000D8_A97WWPFormTitle[0];
         A104WWPFormResume = BC000D8_A104WWPFormResume[0];
         A121WWPFormValidations = BC000D8_A121WWPFormValidations[0];
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0D15( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D15( )
      {
         /* Using cursor BC000D10 */
         pr_default.execute(8, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D7 */
         pr_default.execute(5, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0D15( 4) ;
            RcdFound15 = 1;
            A102WWPFormInstanceId = BC000D7_A102WWPFormInstanceId[0];
            A127WWPFormInstanceDate = BC000D7_A127WWPFormInstanceDate[0];
            A293WWPFormInstanceRecordKey = BC000D7_A293WWPFormInstanceRecordKey[0];
            n293WWPFormInstanceRecordKey = BC000D7_n293WWPFormInstanceRecordKey[0];
            A94WWPFormId = BC000D7_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000D7_A95WWPFormVersionNumber[0];
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0D15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0D15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0D15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D6 */
            pr_default.execute(4, new Object[] {A102WWPFormInstanceId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z127WWPFormInstanceDate ) != DateTimeUtil.ResetTime ( BC000D6_A127WWPFormInstanceDate[0] ) ) || ( Z94WWPFormId != BC000D6_A94WWPFormId[0] ) || ( Z95WWPFormVersionNumber != BC000D6_A95WWPFormVersionNumber[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstance"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D15( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D15( 0) ;
            CheckOptimisticConcurrency0D15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D11 */
                     pr_default.execute(9, new Object[] {A127WWPFormInstanceDate, n293WWPFormInstanceRecordKey, A293WWPFormInstanceRecordKey, A94WWPFormId, A95WWPFormVersionNumber});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000D12 */
                     pr_default.execute(10);
                     A102WWPFormInstanceId = BC000D12_A102WWPFormInstanceId[0];
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0D15( ) ;
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
               Load0D15( ) ;
            }
            EndLevel0D15( ) ;
         }
         CloseExtendedTableCursors0D15( ) ;
      }

      protected void Update0D15( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D13 */
                     pr_default.execute(11, new Object[] {A127WWPFormInstanceDate, n293WWPFormInstanceRecordKey, A293WWPFormInstanceRecordKey, A94WWPFormId, A95WWPFormVersionNumber, A102WWPFormInstanceId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0D15( ) ;
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
            EndLevel0D15( ) ;
         }
         CloseExtendedTableCursors0D15( ) ;
      }

      protected void DeferredUpdate0D15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D15( ) ;
            AfterConfirm0D15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D15( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0D16( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0D16( ) ;
                     Delete0D16( ) ;
                     ScanKeyNext0D16( ) ;
                  }
                  ScanKeyEnd0D16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D14 */
                     pr_default.execute(12, new Object[] {A102WWPFormInstanceId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0D15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D15 */
            pr_default.execute(13, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            A97WWPFormTitle = BC000D15_A97WWPFormTitle[0];
            A104WWPFormResume = BC000D15_A104WWPFormResume[0];
            A121WWPFormValidations = BC000D15_A121WWPFormValidations[0];
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0D16( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Count )
         {
            ReadRow0D16( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0D16( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0D16( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0D16( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0D16( ) ;
                  }
               }
            }
            KeyVarsToRow16( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_16_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_16_idx = 0;
            while ( nGXsfl_16_idx < bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Count )
            {
               ReadRow0D16( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound16 == 0 )
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
                  bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.RemoveElement(nGXsfl_16_idx);
                  nGXsfl_16_idx = (int)(nGXsfl_16_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0D16( ) ;
                  VarsToRow16( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_16_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0D16( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
      }

      protected void ProcessLevel0D15( )
      {
         /* Save parent mode. */
         sMode15 = Gx_mode;
         ProcessNestedLevel0D16( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode15;
         /* ' Update level parameters */
      }

      protected void EndLevel0D15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D15( ) ;
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

      public void ScanKeyStart0D15( )
      {
         /* Scan By routine */
         /* Using cursor BC000D16 */
         pr_default.execute(14, new Object[] {A102WWPFormInstanceId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound15 = 1;
            A102WWPFormInstanceId = BC000D16_A102WWPFormInstanceId[0];
            A127WWPFormInstanceDate = BC000D16_A127WWPFormInstanceDate[0];
            A97WWPFormTitle = BC000D16_A97WWPFormTitle[0];
            A104WWPFormResume = BC000D16_A104WWPFormResume[0];
            A121WWPFormValidations = BC000D16_A121WWPFormValidations[0];
            A293WWPFormInstanceRecordKey = BC000D16_A293WWPFormInstanceRecordKey[0];
            n293WWPFormInstanceRecordKey = BC000D16_n293WWPFormInstanceRecordKey[0];
            A94WWPFormId = BC000D16_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000D16_A95WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D15( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound15 = 0;
         ScanKeyLoad0D15( ) ;
      }

      protected void ScanKeyLoad0D15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound15 = 1;
            A102WWPFormInstanceId = BC000D16_A102WWPFormInstanceId[0];
            A127WWPFormInstanceDate = BC000D16_A127WWPFormInstanceDate[0];
            A97WWPFormTitle = BC000D16_A97WWPFormTitle[0];
            A104WWPFormResume = BC000D16_A104WWPFormResume[0];
            A121WWPFormValidations = BC000D16_A121WWPFormValidations[0];
            A293WWPFormInstanceRecordKey = BC000D16_A293WWPFormInstanceRecordKey[0];
            n293WWPFormInstanceRecordKey = BC000D16_n293WWPFormInstanceRecordKey[0];
            A94WWPFormId = BC000D16_A94WWPFormId[0];
            A95WWPFormVersionNumber = BC000D16_A95WWPFormVersionNumber[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0D15( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0D15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D15( )
      {
      }

      protected void ZM0D16( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z108WWPFormInstanceElemDate = A108WWPFormInstanceElemDate;
            Z115WWPFormInstanceElemDateTime = A115WWPFormInstanceElemDateTime;
            Z110WWPFormInstanceElemNumeric = A110WWPFormInstanceElemNumeric;
            Z114WWPFormInstanceElemBoolean = A114WWPFormInstanceElemBoolean;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
            Z106WWPFormElementDataType = A106WWPFormElementDataType;
            Z105WWPFormElementType = A105WWPFormElementType;
            Z125WWPFormElementCaption = A125WWPFormElementCaption;
            Z99WWPFormElementParentId = A99WWPFormElementParentId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z118WWPFormElementParentType = A118WWPFormElementParentType;
         }
         if ( GX_JID == -6 )
         {
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            Z103WWPFormInstanceElementId = A103WWPFormInstanceElementId;
            Z109WWPFormInstanceElemChar = A109WWPFormInstanceElemChar;
            Z108WWPFormInstanceElemDate = A108WWPFormInstanceElemDate;
            Z115WWPFormInstanceElemDateTime = A115WWPFormInstanceElemDateTime;
            Z110WWPFormInstanceElemNumeric = A110WWPFormInstanceElemNumeric;
            Z111WWPFormInstanceElemBlob = A111WWPFormInstanceElemBlob;
            Z114WWPFormInstanceElemBoolean = A114WWPFormInstanceElemBoolean;
            Z112WWPFormInstanceElemBlobFileType = A112WWPFormInstanceElemBlobFileType;
            Z113WWPFormInstanceElemBlobFileName = A113WWPFormInstanceElemBlobFileName;
            Z98WWPFormElementId = A98WWPFormElementId;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z117WWPFormElementTitle = A117WWPFormElementTitle;
            Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
            Z106WWPFormElementDataType = A106WWPFormElementDataType;
            Z105WWPFormElementType = A105WWPFormElementType;
            Z124WWPFormElementMetadata = A124WWPFormElementMetadata;
            Z125WWPFormElementCaption = A125WWPFormElementCaption;
            Z99WWPFormElementParentId = A99WWPFormElementParentId;
            Z118WWPFormElementParentType = A118WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal0D16( )
      {
      }

      protected void standaloneModal0D16( )
      {
      }

      protected void Load0D16( )
      {
         /* Using cursor BC000D17 */
         pr_default.execute(15, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A102WWPFormInstanceId, A103WWPFormInstanceElementId, A98WWPFormElementId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound16 = 1;
            A117WWPFormElementTitle = BC000D17_A117WWPFormElementTitle[0];
            A101WWPFormElementReferenceId = BC000D17_A101WWPFormElementReferenceId[0];
            A106WWPFormElementDataType = BC000D17_A106WWPFormElementDataType[0];
            A118WWPFormElementParentType = BC000D17_A118WWPFormElementParentType[0];
            A105WWPFormElementType = BC000D17_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = BC000D17_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = BC000D17_A125WWPFormElementCaption[0];
            A109WWPFormInstanceElemChar = BC000D17_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = BC000D17_n109WWPFormInstanceElemChar[0];
            A108WWPFormInstanceElemDate = BC000D17_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = BC000D17_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = BC000D17_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = BC000D17_n115WWPFormInstanceElemDateTime[0];
            A110WWPFormInstanceElemNumeric = BC000D17_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = BC000D17_n110WWPFormInstanceElemNumeric[0];
            A114WWPFormInstanceElemBoolean = BC000D17_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = BC000D17_n114WWPFormInstanceElemBoolean[0];
            A112WWPFormInstanceElemBlobFileType = BC000D17_A112WWPFormInstanceElemBlobFileType[0];
            A111WWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            A113WWPFormInstanceElemBlobFileName = BC000D17_A113WWPFormInstanceElemBlobFileName[0];
            A111WWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A99WWPFormElementParentId = BC000D17_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000D17_n99WWPFormElementParentId[0];
            A111WWPFormInstanceElemBlob = BC000D17_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = BC000D17_n111WWPFormInstanceElemBlob[0];
            ZM0D16( -6) ;
         }
         pr_default.close(15);
         OnLoadActions0D16( ) ;
      }

      protected void OnLoadActions0D16( )
      {
      }

      protected void CheckExtendedTable0D16( )
      {
         Gx_BScreen = 1;
         standaloneModal0D16( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Element'.", "ForeignKeyNotFound", 1, "WWPFORMELEMENTID");
            AnyError = 1;
         }
         A117WWPFormElementTitle = BC000D4_A117WWPFormElementTitle[0];
         A101WWPFormElementReferenceId = BC000D4_A101WWPFormElementReferenceId[0];
         A106WWPFormElementDataType = BC000D4_A106WWPFormElementDataType[0];
         A105WWPFormElementType = BC000D4_A105WWPFormElementType[0];
         A124WWPFormElementMetadata = BC000D4_A124WWPFormElementMetadata[0];
         A125WWPFormElementCaption = BC000D4_A125WWPFormElementCaption[0];
         A99WWPFormElementParentId = BC000D4_A99WWPFormElementParentId[0];
         n99WWPFormElementParentId = BC000D4_n99WWPFormElementParentId[0];
         pr_default.close(2);
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
            }
         }
         A118WWPFormElementParentType = BC000D5_A118WWPFormElementParentType[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D16( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0D16( )
      {
      }

      protected void GetKey0D16( )
      {
         /* Using cursor BC000D18 */
         pr_default.execute(16, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0D16( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D16( 6) ;
            RcdFound16 = 1;
            InitializeNonKey0D16( ) ;
            A103WWPFormInstanceElementId = BC000D3_A103WWPFormInstanceElementId[0];
            A109WWPFormInstanceElemChar = BC000D3_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = BC000D3_n109WWPFormInstanceElemChar[0];
            A108WWPFormInstanceElemDate = BC000D3_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = BC000D3_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = BC000D3_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = BC000D3_n115WWPFormInstanceElemDateTime[0];
            A110WWPFormInstanceElemNumeric = BC000D3_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = BC000D3_n110WWPFormInstanceElemNumeric[0];
            A114WWPFormInstanceElemBoolean = BC000D3_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = BC000D3_n114WWPFormInstanceElemBoolean[0];
            A112WWPFormInstanceElemBlobFileType = BC000D3_A112WWPFormInstanceElemBlobFileType[0];
            A111WWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            A113WWPFormInstanceElemBlobFileName = BC000D3_A113WWPFormInstanceElemBlobFileName[0];
            A111WWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A98WWPFormElementId = BC000D3_A98WWPFormElementId[0];
            A111WWPFormInstanceElemBlob = BC000D3_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = BC000D3_n111WWPFormInstanceElemBlob[0];
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            Z98WWPFormElementId = A98WWPFormElementId;
            Z103WWPFormInstanceElementId = A103WWPFormInstanceElementId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0D16( ) ;
            Load0D16( ) ;
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0D16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0D16( ) ;
            Gx_mode = sMode16;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0D16( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0D16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z108WWPFormInstanceElemDate ) != DateTimeUtil.ResetTime ( BC000D2_A108WWPFormInstanceElemDate[0] ) ) || ( Z115WWPFormInstanceElemDateTime != BC000D2_A115WWPFormInstanceElemDateTime[0] ) || ( Z110WWPFormInstanceElemNumeric != BC000D2_A110WWPFormInstanceElemNumeric[0] ) || ( Z114WWPFormInstanceElemBoolean != BC000D2_A114WWPFormInstanceElemBoolean[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstanceElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D16( )
      {
         BeforeValidate0D16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D16( 0) ;
            CheckOptimisticConcurrency0D16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D19 */
                     pr_default.execute(17, new Object[] {A102WWPFormInstanceId, A103WWPFormInstanceElementId, n109WWPFormInstanceElemChar, A109WWPFormInstanceElemChar, n108WWPFormInstanceElemDate, A108WWPFormInstanceElemDate, n115WWPFormInstanceElemDateTime, A115WWPFormInstanceElemDateTime, n110WWPFormInstanceElemNumeric, A110WWPFormInstanceElemNumeric, n111WWPFormInstanceElemBlob, A111WWPFormInstanceElemBlob, n114WWPFormInstanceElemBoolean, A114WWPFormInstanceElemBoolean, A112WWPFormInstanceElemBlobFileType, A113WWPFormInstanceElemBlobFileName, A98WWPFormElementId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load0D16( ) ;
            }
            EndLevel0D16( ) ;
         }
         CloseExtendedTableCursors0D16( ) ;
      }

      protected void Update0D16( )
      {
         BeforeValidate0D16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D20 */
                     pr_default.execute(18, new Object[] {n109WWPFormInstanceElemChar, A109WWPFormInstanceElemChar, n108WWPFormInstanceElemDate, A108WWPFormInstanceElemDate, n115WWPFormInstanceElemDateTime, A115WWPFormInstanceElemDateTime, n110WWPFormInstanceElemNumeric, A110WWPFormInstanceElemNumeric, n114WWPFormInstanceElemBoolean, A114WWPFormInstanceElemBoolean, A112WWPFormInstanceElemBlobFileType, A113WWPFormInstanceElemBlobFileName, A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0D16( ) ;
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
            EndLevel0D16( ) ;
         }
         CloseExtendedTableCursors0D16( ) ;
      }

      protected void DeferredUpdate0D16( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D21 */
            pr_default.execute(19, new Object[] {n111WWPFormInstanceElemBlob, A111WWPFormInstanceElemBlob, A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
            pr_default.close(19);
            pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
         }
      }

      protected void Delete0D16( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D16( ) ;
            AfterConfirm0D16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D22 */
                  pr_default.execute(20, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0D16( )
      {
         standaloneModal0D16( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D23 */
            pr_default.execute(21, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
            A117WWPFormElementTitle = BC000D23_A117WWPFormElementTitle[0];
            A101WWPFormElementReferenceId = BC000D23_A101WWPFormElementReferenceId[0];
            A106WWPFormElementDataType = BC000D23_A106WWPFormElementDataType[0];
            A105WWPFormElementType = BC000D23_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = BC000D23_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = BC000D23_A125WWPFormElementCaption[0];
            A99WWPFormElementParentId = BC000D23_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000D23_n99WWPFormElementParentId[0];
            pr_default.close(21);
            /* Using cursor BC000D24 */
            pr_default.execute(22, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
            A118WWPFormElementParentType = BC000D24_A118WWPFormElementParentType[0];
            pr_default.close(22);
         }
      }

      protected void EndLevel0D16( )
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

      public void ScanKeyStart0D16( )
      {
         /* Scan By routine */
         /* Using cursor BC000D25 */
         pr_default.execute(23, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A102WWPFormInstanceId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A103WWPFormInstanceElementId = BC000D25_A103WWPFormInstanceElementId[0];
            A117WWPFormElementTitle = BC000D25_A117WWPFormElementTitle[0];
            A101WWPFormElementReferenceId = BC000D25_A101WWPFormElementReferenceId[0];
            A106WWPFormElementDataType = BC000D25_A106WWPFormElementDataType[0];
            A118WWPFormElementParentType = BC000D25_A118WWPFormElementParentType[0];
            A105WWPFormElementType = BC000D25_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = BC000D25_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = BC000D25_A125WWPFormElementCaption[0];
            A109WWPFormInstanceElemChar = BC000D25_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = BC000D25_n109WWPFormInstanceElemChar[0];
            A108WWPFormInstanceElemDate = BC000D25_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = BC000D25_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = BC000D25_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = BC000D25_n115WWPFormInstanceElemDateTime[0];
            A110WWPFormInstanceElemNumeric = BC000D25_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = BC000D25_n110WWPFormInstanceElemNumeric[0];
            A114WWPFormInstanceElemBoolean = BC000D25_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = BC000D25_n114WWPFormInstanceElemBoolean[0];
            A112WWPFormInstanceElemBlobFileType = BC000D25_A112WWPFormInstanceElemBlobFileType[0];
            A111WWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            A113WWPFormInstanceElemBlobFileName = BC000D25_A113WWPFormInstanceElemBlobFileName[0];
            A111WWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A98WWPFormElementId = BC000D25_A98WWPFormElementId[0];
            A99WWPFormElementParentId = BC000D25_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000D25_n99WWPFormElementParentId[0];
            A111WWPFormInstanceElemBlob = BC000D25_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = BC000D25_n111WWPFormInstanceElemBlob[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D16( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound16 = 0;
         ScanKeyLoad0D16( ) ;
      }

      protected void ScanKeyLoad0D16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A103WWPFormInstanceElementId = BC000D25_A103WWPFormInstanceElementId[0];
            A117WWPFormElementTitle = BC000D25_A117WWPFormElementTitle[0];
            A101WWPFormElementReferenceId = BC000D25_A101WWPFormElementReferenceId[0];
            A106WWPFormElementDataType = BC000D25_A106WWPFormElementDataType[0];
            A118WWPFormElementParentType = BC000D25_A118WWPFormElementParentType[0];
            A105WWPFormElementType = BC000D25_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = BC000D25_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = BC000D25_A125WWPFormElementCaption[0];
            A109WWPFormInstanceElemChar = BC000D25_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = BC000D25_n109WWPFormInstanceElemChar[0];
            A108WWPFormInstanceElemDate = BC000D25_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = BC000D25_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = BC000D25_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = BC000D25_n115WWPFormInstanceElemDateTime[0];
            A110WWPFormInstanceElemNumeric = BC000D25_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = BC000D25_n110WWPFormInstanceElemNumeric[0];
            A114WWPFormInstanceElemBoolean = BC000D25_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = BC000D25_n114WWPFormInstanceElemBoolean[0];
            A112WWPFormInstanceElemBlobFileType = BC000D25_A112WWPFormInstanceElemBlobFileType[0];
            A111WWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            A113WWPFormInstanceElemBlobFileName = BC000D25_A113WWPFormInstanceElemBlobFileName[0];
            A111WWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A98WWPFormElementId = BC000D25_A98WWPFormElementId[0];
            A99WWPFormElementParentId = BC000D25_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = BC000D25_n99WWPFormElementParentId[0];
            A111WWPFormInstanceElemBlob = BC000D25_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = BC000D25_n111WWPFormInstanceElemBlob[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0D16( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0D16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D16( )
      {
      }

      protected void send_integrity_lvl_hashes0D16( )
      {
      }

      protected void send_integrity_lvl_hashes0D15( )
      {
      }

      protected void AddRow0D15( )
      {
         VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
      }

      protected void ReadRow0D15( )
      {
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
      }

      protected void AddRow0D16( )
      {
         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj16;
         obj16 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         VarsToRow16( obj16) ;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Add(obj16, 0);
         obj16.gxTpr_Mode = "UPD";
         obj16.gxTpr_Modified = 0;
      }

      protected void ReadRow0D16( )
      {
         nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
         RowToVars16( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_16_idx)), 1) ;
      }

      protected void InitializeNonKey0D15( )
      {
         A94WWPFormId = 0;
         A95WWPFormVersionNumber = 0;
         A97WWPFormTitle = "";
         A104WWPFormResume = 0;
         A121WWPFormValidations = "";
         A293WWPFormInstanceRecordKey = "";
         n293WWPFormInstanceRecordKey = false;
         A127WWPFormInstanceDate = Gx_date;
         Z127WWPFormInstanceDate = DateTime.MinValue;
         Z94WWPFormId = 0;
         Z95WWPFormVersionNumber = 0;
      }

      protected void InitAll0D15( )
      {
         A102WWPFormInstanceId = 0;
         InitializeNonKey0D15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A127WWPFormInstanceDate = i127WWPFormInstanceDate;
      }

      protected void InitializeNonKey0D16( )
      {
         A117WWPFormElementTitle = "";
         A101WWPFormElementReferenceId = "";
         A106WWPFormElementDataType = 0;
         A99WWPFormElementParentId = 0;
         n99WWPFormElementParentId = false;
         A118WWPFormElementParentType = 0;
         A105WWPFormElementType = 0;
         A124WWPFormElementMetadata = "";
         A125WWPFormElementCaption = 0;
         A109WWPFormInstanceElemChar = "";
         n109WWPFormInstanceElemChar = false;
         A108WWPFormInstanceElemDate = DateTime.MinValue;
         n108WWPFormInstanceElemDate = false;
         A115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         n115WWPFormInstanceElemDateTime = false;
         A110WWPFormInstanceElemNumeric = 0;
         n110WWPFormInstanceElemNumeric = false;
         A111WWPFormInstanceElemBlob = "";
         n111WWPFormInstanceElemBlob = false;
         A114WWPFormInstanceElemBoolean = false;
         n114WWPFormInstanceElemBoolean = false;
         A112WWPFormInstanceElemBlobFileType = "";
         A113WWPFormInstanceElemBlobFileName = "";
         Z108WWPFormInstanceElemDate = DateTime.MinValue;
         Z115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         Z110WWPFormInstanceElemNumeric = 0;
         Z114WWPFormInstanceElemBoolean = false;
      }

      protected void InitAll0D16( )
      {
         A98WWPFormElementId = 0;
         A103WWPFormInstanceElementId = 0;
         InitializeNonKey0D16( ) ;
      }

      protected void StandaloneModalInsert0D16( )
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

      public void VarsToRow15( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Wwpformid = A94WWPFormId;
         obj15.gxTpr_Wwpformversionnumber = A95WWPFormVersionNumber;
         obj15.gxTpr_Wwpformtitle = A97WWPFormTitle;
         obj15.gxTpr_Wwpformresume = A104WWPFormResume;
         obj15.gxTpr_Wwpformvalidations = A121WWPFormValidations;
         obj15.gxTpr_Wwpforminstancerecordkey = A293WWPFormInstanceRecordKey;
         obj15.gxTpr_Wwpforminstancedate = A127WWPFormInstanceDate;
         obj15.gxTpr_Wwpforminstanceid = A102WWPFormInstanceId;
         obj15.gxTpr_Wwpforminstanceid_Z = Z102WWPFormInstanceId;
         obj15.gxTpr_Wwpforminstancedate_Z = Z127WWPFormInstanceDate;
         obj15.gxTpr_Wwpformid_Z = Z94WWPFormId;
         obj15.gxTpr_Wwpformversionnumber_Z = Z95WWPFormVersionNumber;
         obj15.gxTpr_Wwpformtitle_Z = Z97WWPFormTitle;
         obj15.gxTpr_Wwpformresume_Z = Z104WWPFormResume;
         obj15.gxTpr_Wwpforminstancerecordkey_N = (short)(Convert.ToInt16(n293WWPFormInstanceRecordKey));
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance obj15 )
      {
         obj15.gxTpr_Wwpforminstanceid = A102WWPFormInstanceId;
         return  ;
      }

      public void RowToVars15( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A94WWPFormId = obj15.gxTpr_Wwpformid;
         A95WWPFormVersionNumber = obj15.gxTpr_Wwpformversionnumber;
         A97WWPFormTitle = obj15.gxTpr_Wwpformtitle;
         A104WWPFormResume = obj15.gxTpr_Wwpformresume;
         A121WWPFormValidations = obj15.gxTpr_Wwpformvalidations;
         A293WWPFormInstanceRecordKey = obj15.gxTpr_Wwpforminstancerecordkey;
         n293WWPFormInstanceRecordKey = false;
         A127WWPFormInstanceDate = obj15.gxTpr_Wwpforminstancedate;
         A102WWPFormInstanceId = obj15.gxTpr_Wwpforminstanceid;
         Z102WWPFormInstanceId = obj15.gxTpr_Wwpforminstanceid_Z;
         Z127WWPFormInstanceDate = obj15.gxTpr_Wwpforminstancedate_Z;
         Z94WWPFormId = obj15.gxTpr_Wwpformid_Z;
         Z95WWPFormVersionNumber = obj15.gxTpr_Wwpformversionnumber_Z;
         Z97WWPFormTitle = obj15.gxTpr_Wwpformtitle_Z;
         Z104WWPFormResume = obj15.gxTpr_Wwpformresume_Z;
         n293WWPFormInstanceRecordKey = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpforminstancerecordkey_N));
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow16( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Wwpformelementtitle = A117WWPFormElementTitle;
         obj16.gxTpr_Wwpformelementreferenceid = A101WWPFormElementReferenceId;
         obj16.gxTpr_Wwpformelementdatatype = A106WWPFormElementDataType;
         obj16.gxTpr_Wwpformelementparentid = A99WWPFormElementParentId;
         obj16.gxTpr_Wwpformelementparenttype = A118WWPFormElementParentType;
         obj16.gxTpr_Wwpformelementtype = A105WWPFormElementType;
         obj16.gxTpr_Wwpformelementmetadata = A124WWPFormElementMetadata;
         obj16.gxTpr_Wwpformelementcaption = A125WWPFormElementCaption;
         obj16.gxTpr_Wwpforminstanceelemchar = A109WWPFormInstanceElemChar;
         obj16.gxTpr_Wwpforminstanceelemdate = A108WWPFormInstanceElemDate;
         obj16.gxTpr_Wwpforminstanceelemdatetime = A115WWPFormInstanceElemDateTime;
         obj16.gxTpr_Wwpforminstanceelemnumeric = A110WWPFormInstanceElemNumeric;
         obj16.gxTpr_Wwpforminstanceelemblob = A111WWPFormInstanceElemBlob;
         obj16.gxTpr_Wwpforminstanceelemboolean = A114WWPFormInstanceElemBoolean;
         obj16.gxTpr_Wwpforminstanceelemblobfiletype = A112WWPFormInstanceElemBlobFileType;
         obj16.gxTpr_Wwpforminstanceelemblobfilename = A113WWPFormInstanceElemBlobFileName;
         obj16.gxTpr_Wwpformelementid = A98WWPFormElementId;
         obj16.gxTpr_Wwpforminstanceelementid = A103WWPFormInstanceElementId;
         obj16.gxTpr_Wwpformelementid_Z = Z98WWPFormElementId;
         obj16.gxTpr_Wwpforminstanceelementid_Z = Z103WWPFormInstanceElementId;
         obj16.gxTpr_Wwpformelementreferenceid_Z = Z101WWPFormElementReferenceId;
         obj16.gxTpr_Wwpformelementdatatype_Z = Z106WWPFormElementDataType;
         obj16.gxTpr_Wwpformelementparentid_Z = Z99WWPFormElementParentId;
         obj16.gxTpr_Wwpformelementparenttype_Z = Z118WWPFormElementParentType;
         obj16.gxTpr_Wwpformelementtype_Z = Z105WWPFormElementType;
         obj16.gxTpr_Wwpformelementcaption_Z = Z125WWPFormElementCaption;
         obj16.gxTpr_Wwpforminstanceelemdate_Z = Z108WWPFormInstanceElemDate;
         obj16.gxTpr_Wwpforminstanceelemdatetime_Z = Z115WWPFormInstanceElemDateTime;
         obj16.gxTpr_Wwpforminstanceelemnumeric_Z = Z110WWPFormInstanceElemNumeric;
         obj16.gxTpr_Wwpforminstanceelemblobfilename_Z = Z113WWPFormInstanceElemBlobFileName;
         obj16.gxTpr_Wwpforminstanceelemblobfiletype_Z = Z112WWPFormInstanceElemBlobFileType;
         obj16.gxTpr_Wwpforminstanceelemboolean_Z = Z114WWPFormInstanceElemBoolean;
         obj16.gxTpr_Wwpformelementparentid_N = (short)(Convert.ToInt16(n99WWPFormElementParentId));
         obj16.gxTpr_Wwpforminstanceelemchar_N = (short)(Convert.ToInt16(n109WWPFormInstanceElemChar));
         obj16.gxTpr_Wwpforminstanceelemdate_N = (short)(Convert.ToInt16(n108WWPFormInstanceElemDate));
         obj16.gxTpr_Wwpforminstanceelemdatetime_N = (short)(Convert.ToInt16(n115WWPFormInstanceElemDateTime));
         obj16.gxTpr_Wwpforminstanceelemnumeric_N = (short)(Convert.ToInt16(n110WWPFormInstanceElemNumeric));
         obj16.gxTpr_Wwpforminstanceelemblob_N = (short)(Convert.ToInt16(n111WWPFormInstanceElemBlob));
         obj16.gxTpr_Wwpforminstanceelemboolean_N = (short)(Convert.ToInt16(n114WWPFormInstanceElemBoolean));
         obj16.gxTpr_Modified = nIsMod_16;
         return  ;
      }

      public void KeyVarsToRow16( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj16 )
      {
         obj16.gxTpr_Wwpformelementid = A98WWPFormElementId;
         obj16.gxTpr_Wwpforminstanceelementid = A103WWPFormInstanceElementId;
         return  ;
      }

      public void RowToVars16( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A117WWPFormElementTitle = obj16.gxTpr_Wwpformelementtitle;
         A101WWPFormElementReferenceId = obj16.gxTpr_Wwpformelementreferenceid;
         A106WWPFormElementDataType = obj16.gxTpr_Wwpformelementdatatype;
         A99WWPFormElementParentId = obj16.gxTpr_Wwpformelementparentid;
         n99WWPFormElementParentId = false;
         A118WWPFormElementParentType = obj16.gxTpr_Wwpformelementparenttype;
         A105WWPFormElementType = obj16.gxTpr_Wwpformelementtype;
         A124WWPFormElementMetadata = obj16.gxTpr_Wwpformelementmetadata;
         A125WWPFormElementCaption = obj16.gxTpr_Wwpformelementcaption;
         A109WWPFormInstanceElemChar = obj16.gxTpr_Wwpforminstanceelemchar;
         n109WWPFormInstanceElemChar = false;
         A108WWPFormInstanceElemDate = obj16.gxTpr_Wwpforminstanceelemdate;
         n108WWPFormInstanceElemDate = false;
         A115WWPFormInstanceElemDateTime = obj16.gxTpr_Wwpforminstanceelemdatetime;
         n115WWPFormInstanceElemDateTime = false;
         A110WWPFormInstanceElemNumeric = obj16.gxTpr_Wwpforminstanceelemnumeric;
         n110WWPFormInstanceElemNumeric = false;
         A111WWPFormInstanceElemBlob = obj16.gxTpr_Wwpforminstanceelemblob;
         n111WWPFormInstanceElemBlob = false;
         A114WWPFormInstanceElemBoolean = obj16.gxTpr_Wwpforminstanceelemboolean;
         n114WWPFormInstanceElemBoolean = false;
         A112WWPFormInstanceElemBlobFileType = (String.IsNullOrEmpty(StringUtil.RTrim( obj16.gxTpr_Wwpforminstanceelemblobfiletype)) ? FileUtil.GetFileType( A111WWPFormInstanceElemBlob) : obj16.gxTpr_Wwpforminstanceelemblobfiletype);
         A113WWPFormInstanceElemBlobFileName = (String.IsNullOrEmpty(StringUtil.RTrim( obj16.gxTpr_Wwpforminstanceelemblobfilename)) ? FileUtil.GetFileName( A111WWPFormInstanceElemBlob) : obj16.gxTpr_Wwpforminstanceelemblobfilename);
         A98WWPFormElementId = obj16.gxTpr_Wwpformelementid;
         A103WWPFormInstanceElementId = obj16.gxTpr_Wwpforminstanceelementid;
         Z98WWPFormElementId = obj16.gxTpr_Wwpformelementid_Z;
         Z103WWPFormInstanceElementId = obj16.gxTpr_Wwpforminstanceelementid_Z;
         Z101WWPFormElementReferenceId = obj16.gxTpr_Wwpformelementreferenceid_Z;
         Z106WWPFormElementDataType = obj16.gxTpr_Wwpformelementdatatype_Z;
         Z99WWPFormElementParentId = obj16.gxTpr_Wwpformelementparentid_Z;
         Z118WWPFormElementParentType = obj16.gxTpr_Wwpformelementparenttype_Z;
         Z105WWPFormElementType = obj16.gxTpr_Wwpformelementtype_Z;
         Z125WWPFormElementCaption = obj16.gxTpr_Wwpformelementcaption_Z;
         Z108WWPFormInstanceElemDate = obj16.gxTpr_Wwpforminstanceelemdate_Z;
         Z115WWPFormInstanceElemDateTime = obj16.gxTpr_Wwpforminstanceelemdatetime_Z;
         Z110WWPFormInstanceElemNumeric = obj16.gxTpr_Wwpforminstanceelemnumeric_Z;
         Z113WWPFormInstanceElemBlobFileName = obj16.gxTpr_Wwpforminstanceelemblobfilename_Z;
         Z112WWPFormInstanceElemBlobFileType = obj16.gxTpr_Wwpforminstanceelemblobfiletype_Z;
         Z114WWPFormInstanceElemBoolean = obj16.gxTpr_Wwpforminstanceelemboolean_Z;
         n99WWPFormElementParentId = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpformelementparentid_N));
         n109WWPFormInstanceElemChar = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpforminstanceelemchar_N));
         n108WWPFormInstanceElemDate = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpforminstanceelemdate_N));
         n115WWPFormInstanceElemDateTime = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpforminstanceelemdatetime_N));
         n110WWPFormInstanceElemNumeric = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpforminstanceelemnumeric_N));
         n111WWPFormInstanceElemBlob = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpforminstanceelemblob_N));
         n114WWPFormInstanceElemBoolean = (bool)(Convert.ToBoolean(obj16.gxTpr_Wwpforminstanceelemboolean_N));
         nIsMod_16 = obj16.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A102WWPFormInstanceId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D15( ) ;
         ScanKeyStart0D15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
         }
         ZM0D15( -4) ;
         OnLoadActions0D15( ) ;
         AddRow0D15( ) ;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0D16( ) ;
            nGXsfl_16_idx = 1;
            while ( RcdFound16 != 0 )
            {
               Z102WWPFormInstanceId = A102WWPFormInstanceId;
               Z98WWPFormElementId = A98WWPFormElementId;
               Z103WWPFormInstanceElementId = A103WWPFormInstanceElementId;
               ZM0D16( -6) ;
               OnLoadActions0D16( ) ;
               nRcdExists_16 = 1;
               nIsMod_16 = 0;
               AddRow0D16( ) ;
               nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
               ScanKeyNext0D16( ) ;
            }
            ScanKeyEnd0D16( ) ;
         }
         ScanKeyEnd0D15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 0) ;
         ScanKeyStart0D15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
         }
         ZM0D15( -4) ;
         OnLoadActions0D15( ) ;
         AddRow0D15( ) ;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0D16( ) ;
            nGXsfl_16_idx = 1;
            while ( RcdFound16 != 0 )
            {
               Z102WWPFormInstanceId = A102WWPFormInstanceId;
               Z98WWPFormElementId = A98WWPFormElementId;
               Z103WWPFormInstanceElementId = A103WWPFormInstanceElementId;
               ZM0D16( -6) ;
               OnLoadActions0D16( ) ;
               nRcdExists_16 = 1;
               nIsMod_16 = 0;
               AddRow0D16( ) ;
               nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
               ScanKeyNext0D16( ) ;
            }
            ScanKeyEnd0D16( ) ;
         }
         ScanKeyEnd0D15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0D15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
               {
                  A102WWPFormInstanceId = Z102WWPFormInstanceId;
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
                  Update0D15( ) ;
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
                  if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
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
                        Insert0D15( ) ;
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
                        Insert0D15( ) ;
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
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance auxBC = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A102WWPFormInstanceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_dynamicforms_WWP_FormInstance);
               auxBC.Save();
               bcworkwithplus_dynamicforms_WWP_FormInstance.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
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
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D15( ) ;
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
               VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
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
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 0) ;
         GetKey0D15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
            {
               A102WWPFormInstanceId = Z102WWPFormInstanceId;
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
            if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
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
         context.RollbackDataStores("workwithplus.dynamicforms.wwp_forminstance_bc",pr_default);
         VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
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
         Gx_mode = bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_dynamicforms_WWP_FormInstance )
         {
            bcworkwithplus_dynamicforms_WWP_FormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
            }
            else
            {
               RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_FormInstance WWP_FormInstance_BC
      {
         get {
            return bcworkwithplus_dynamicforms_WWP_FormInstance ;
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
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(5);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode15 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV16Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z127WWPFormInstanceDate = DateTime.MinValue;
         A127WWPFormInstanceDate = DateTime.MinValue;
         Z97WWPFormTitle = "";
         A97WWPFormTitle = "";
         Z293WWPFormInstanceRecordKey = "";
         A293WWPFormInstanceRecordKey = "";
         Z121WWPFormValidations = "";
         A121WWPFormValidations = "";
         Gx_date = DateTime.MinValue;
         BC000D9_A102WWPFormInstanceId = new int[1] ;
         BC000D9_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000D9_A97WWPFormTitle = new string[] {""} ;
         BC000D9_A104WWPFormResume = new short[1] ;
         BC000D9_A121WWPFormValidations = new string[] {""} ;
         BC000D9_A293WWPFormInstanceRecordKey = new string[] {""} ;
         BC000D9_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000D9_A94WWPFormId = new short[1] ;
         BC000D9_A95WWPFormVersionNumber = new short[1] ;
         BC000D8_A97WWPFormTitle = new string[] {""} ;
         BC000D8_A104WWPFormResume = new short[1] ;
         BC000D8_A121WWPFormValidations = new string[] {""} ;
         BC000D10_A102WWPFormInstanceId = new int[1] ;
         BC000D7_A102WWPFormInstanceId = new int[1] ;
         BC000D7_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000D7_A293WWPFormInstanceRecordKey = new string[] {""} ;
         BC000D7_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000D7_A94WWPFormId = new short[1] ;
         BC000D7_A95WWPFormVersionNumber = new short[1] ;
         BC000D6_A102WWPFormInstanceId = new int[1] ;
         BC000D6_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000D6_A293WWPFormInstanceRecordKey = new string[] {""} ;
         BC000D6_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000D6_A94WWPFormId = new short[1] ;
         BC000D6_A95WWPFormVersionNumber = new short[1] ;
         BC000D12_A102WWPFormInstanceId = new int[1] ;
         BC000D15_A97WWPFormTitle = new string[] {""} ;
         BC000D15_A104WWPFormResume = new short[1] ;
         BC000D15_A121WWPFormValidations = new string[] {""} ;
         BC000D16_A102WWPFormInstanceId = new int[1] ;
         BC000D16_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000D16_A97WWPFormTitle = new string[] {""} ;
         BC000D16_A104WWPFormResume = new short[1] ;
         BC000D16_A121WWPFormValidations = new string[] {""} ;
         BC000D16_A293WWPFormInstanceRecordKey = new string[] {""} ;
         BC000D16_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000D16_A94WWPFormId = new short[1] ;
         BC000D16_A95WWPFormVersionNumber = new short[1] ;
         Z108WWPFormInstanceElemDate = DateTime.MinValue;
         A108WWPFormInstanceElemDate = DateTime.MinValue;
         Z115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         A115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         Z101WWPFormElementReferenceId = "";
         A101WWPFormElementReferenceId = "";
         Z109WWPFormInstanceElemChar = "";
         A109WWPFormInstanceElemChar = "";
         Z111WWPFormInstanceElemBlob = "";
         A111WWPFormInstanceElemBlob = "";
         Z112WWPFormInstanceElemBlobFileType = "";
         A112WWPFormInstanceElemBlobFileType = "";
         Z113WWPFormInstanceElemBlobFileName = "";
         A113WWPFormInstanceElemBlobFileName = "";
         Z117WWPFormElementTitle = "";
         A117WWPFormElementTitle = "";
         Z124WWPFormElementMetadata = "";
         A124WWPFormElementMetadata = "";
         BC000D17_A94WWPFormId = new short[1] ;
         BC000D17_A95WWPFormVersionNumber = new short[1] ;
         BC000D17_A102WWPFormInstanceId = new int[1] ;
         BC000D17_A103WWPFormInstanceElementId = new short[1] ;
         BC000D17_A117WWPFormElementTitle = new string[] {""} ;
         BC000D17_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000D17_A106WWPFormElementDataType = new short[1] ;
         BC000D17_A118WWPFormElementParentType = new short[1] ;
         BC000D17_A105WWPFormElementType = new short[1] ;
         BC000D17_A124WWPFormElementMetadata = new string[] {""} ;
         BC000D17_A125WWPFormElementCaption = new short[1] ;
         BC000D17_A109WWPFormInstanceElemChar = new string[] {""} ;
         BC000D17_n109WWPFormInstanceElemChar = new bool[] {false} ;
         BC000D17_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000D17_n108WWPFormInstanceElemDate = new bool[] {false} ;
         BC000D17_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000D17_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000D17_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000D17_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000D17_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D17_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D17_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         BC000D17_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         BC000D17_A98WWPFormElementId = new short[1] ;
         BC000D17_A99WWPFormElementParentId = new short[1] ;
         BC000D17_n99WWPFormElementParentId = new bool[] {false} ;
         BC000D17_A111WWPFormInstanceElemBlob = new string[] {""} ;
         BC000D17_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         A111WWPFormInstanceElemBlob_Filetype = "";
         A111WWPFormInstanceElemBlob_Filename = "";
         BC000D4_A94WWPFormId = new short[1] ;
         BC000D4_A95WWPFormVersionNumber = new short[1] ;
         BC000D4_A117WWPFormElementTitle = new string[] {""} ;
         BC000D4_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000D4_A106WWPFormElementDataType = new short[1] ;
         BC000D4_A105WWPFormElementType = new short[1] ;
         BC000D4_A124WWPFormElementMetadata = new string[] {""} ;
         BC000D4_A125WWPFormElementCaption = new short[1] ;
         BC000D4_A99WWPFormElementParentId = new short[1] ;
         BC000D4_n99WWPFormElementParentId = new bool[] {false} ;
         BC000D5_A118WWPFormElementParentType = new short[1] ;
         BC000D18_A102WWPFormInstanceId = new int[1] ;
         BC000D18_A98WWPFormElementId = new short[1] ;
         BC000D18_A103WWPFormInstanceElementId = new short[1] ;
         BC000D3_A102WWPFormInstanceId = new int[1] ;
         BC000D3_A103WWPFormInstanceElementId = new short[1] ;
         BC000D3_A109WWPFormInstanceElemChar = new string[] {""} ;
         BC000D3_n109WWPFormInstanceElemChar = new bool[] {false} ;
         BC000D3_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000D3_n108WWPFormInstanceElemDate = new bool[] {false} ;
         BC000D3_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000D3_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000D3_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000D3_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000D3_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D3_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D3_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         BC000D3_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         BC000D3_A98WWPFormElementId = new short[1] ;
         BC000D3_A111WWPFormInstanceElemBlob = new string[] {""} ;
         BC000D3_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         sMode16 = "";
         BC000D2_A102WWPFormInstanceId = new int[1] ;
         BC000D2_A103WWPFormInstanceElementId = new short[1] ;
         BC000D2_A109WWPFormInstanceElemChar = new string[] {""} ;
         BC000D2_n109WWPFormInstanceElemChar = new bool[] {false} ;
         BC000D2_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000D2_n108WWPFormInstanceElemDate = new bool[] {false} ;
         BC000D2_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000D2_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000D2_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000D2_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000D2_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D2_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D2_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         BC000D2_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         BC000D2_A98WWPFormElementId = new short[1] ;
         BC000D2_A111WWPFormInstanceElemBlob = new string[] {""} ;
         BC000D2_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         BC000D23_A117WWPFormElementTitle = new string[] {""} ;
         BC000D23_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000D23_A106WWPFormElementDataType = new short[1] ;
         BC000D23_A105WWPFormElementType = new short[1] ;
         BC000D23_A124WWPFormElementMetadata = new string[] {""} ;
         BC000D23_A125WWPFormElementCaption = new short[1] ;
         BC000D23_A99WWPFormElementParentId = new short[1] ;
         BC000D23_n99WWPFormElementParentId = new bool[] {false} ;
         BC000D24_A118WWPFormElementParentType = new short[1] ;
         BC000D25_A94WWPFormId = new short[1] ;
         BC000D25_A95WWPFormVersionNumber = new short[1] ;
         BC000D25_A102WWPFormInstanceId = new int[1] ;
         BC000D25_A103WWPFormInstanceElementId = new short[1] ;
         BC000D25_A117WWPFormElementTitle = new string[] {""} ;
         BC000D25_A101WWPFormElementReferenceId = new string[] {""} ;
         BC000D25_A106WWPFormElementDataType = new short[1] ;
         BC000D25_A118WWPFormElementParentType = new short[1] ;
         BC000D25_A105WWPFormElementType = new short[1] ;
         BC000D25_A124WWPFormElementMetadata = new string[] {""} ;
         BC000D25_A125WWPFormElementCaption = new short[1] ;
         BC000D25_A109WWPFormInstanceElemChar = new string[] {""} ;
         BC000D25_n109WWPFormInstanceElemChar = new bool[] {false} ;
         BC000D25_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000D25_n108WWPFormInstanceElemDate = new bool[] {false} ;
         BC000D25_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000D25_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000D25_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000D25_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000D25_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D25_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000D25_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         BC000D25_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         BC000D25_A98WWPFormElementId = new short[1] ;
         BC000D25_A99WWPFormElementParentId = new short[1] ;
         BC000D25_n99WWPFormElementParentId = new bool[] {false} ;
         BC000D25_A111WWPFormInstanceElemBlob = new string[] {""} ;
         BC000D25_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         i127WWPFormInstanceDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A102WWPFormInstanceId, BC000D2_A103WWPFormInstanceElementId, BC000D2_A109WWPFormInstanceElemChar, BC000D2_n109WWPFormInstanceElemChar, BC000D2_A108WWPFormInstanceElemDate, BC000D2_n108WWPFormInstanceElemDate, BC000D2_A115WWPFormInstanceElemDateTime, BC000D2_n115WWPFormInstanceElemDateTime, BC000D2_A110WWPFormInstanceElemNumeric, BC000D2_n110WWPFormInstanceElemNumeric,
               BC000D2_A114WWPFormInstanceElemBoolean, BC000D2_n114WWPFormInstanceElemBoolean, BC000D2_A112WWPFormInstanceElemBlobFileType, BC000D2_A113WWPFormInstanceElemBlobFileName, BC000D2_A98WWPFormElementId, BC000D2_A111WWPFormInstanceElemBlob, BC000D2_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               BC000D3_A102WWPFormInstanceId, BC000D3_A103WWPFormInstanceElementId, BC000D3_A109WWPFormInstanceElemChar, BC000D3_n109WWPFormInstanceElemChar, BC000D3_A108WWPFormInstanceElemDate, BC000D3_n108WWPFormInstanceElemDate, BC000D3_A115WWPFormInstanceElemDateTime, BC000D3_n115WWPFormInstanceElemDateTime, BC000D3_A110WWPFormInstanceElemNumeric, BC000D3_n110WWPFormInstanceElemNumeric,
               BC000D3_A114WWPFormInstanceElemBoolean, BC000D3_n114WWPFormInstanceElemBoolean, BC000D3_A112WWPFormInstanceElemBlobFileType, BC000D3_A113WWPFormInstanceElemBlobFileName, BC000D3_A98WWPFormElementId, BC000D3_A111WWPFormInstanceElemBlob, BC000D3_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               BC000D4_A94WWPFormId, BC000D4_A95WWPFormVersionNumber, BC000D4_A117WWPFormElementTitle, BC000D4_A101WWPFormElementReferenceId, BC000D4_A106WWPFormElementDataType, BC000D4_A105WWPFormElementType, BC000D4_A124WWPFormElementMetadata, BC000D4_A125WWPFormElementCaption, BC000D4_A99WWPFormElementParentId, BC000D4_n99WWPFormElementParentId
               }
               , new Object[] {
               BC000D5_A118WWPFormElementParentType
               }
               , new Object[] {
               BC000D6_A102WWPFormInstanceId, BC000D6_A127WWPFormInstanceDate, BC000D6_A293WWPFormInstanceRecordKey, BC000D6_n293WWPFormInstanceRecordKey, BC000D6_A94WWPFormId, BC000D6_A95WWPFormVersionNumber
               }
               , new Object[] {
               BC000D7_A102WWPFormInstanceId, BC000D7_A127WWPFormInstanceDate, BC000D7_A293WWPFormInstanceRecordKey, BC000D7_n293WWPFormInstanceRecordKey, BC000D7_A94WWPFormId, BC000D7_A95WWPFormVersionNumber
               }
               , new Object[] {
               BC000D8_A97WWPFormTitle, BC000D8_A104WWPFormResume, BC000D8_A121WWPFormValidations
               }
               , new Object[] {
               BC000D9_A102WWPFormInstanceId, BC000D9_A127WWPFormInstanceDate, BC000D9_A97WWPFormTitle, BC000D9_A104WWPFormResume, BC000D9_A121WWPFormValidations, BC000D9_A293WWPFormInstanceRecordKey, BC000D9_n293WWPFormInstanceRecordKey, BC000D9_A94WWPFormId, BC000D9_A95WWPFormVersionNumber
               }
               , new Object[] {
               BC000D10_A102WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D12_A102WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D15_A97WWPFormTitle, BC000D15_A104WWPFormResume, BC000D15_A121WWPFormValidations
               }
               , new Object[] {
               BC000D16_A102WWPFormInstanceId, BC000D16_A127WWPFormInstanceDate, BC000D16_A97WWPFormTitle, BC000D16_A104WWPFormResume, BC000D16_A121WWPFormValidations, BC000D16_A293WWPFormInstanceRecordKey, BC000D16_n293WWPFormInstanceRecordKey, BC000D16_A94WWPFormId, BC000D16_A95WWPFormVersionNumber
               }
               , new Object[] {
               BC000D17_A94WWPFormId, BC000D17_A95WWPFormVersionNumber, BC000D17_A102WWPFormInstanceId, BC000D17_A103WWPFormInstanceElementId, BC000D17_A117WWPFormElementTitle, BC000D17_A101WWPFormElementReferenceId, BC000D17_A106WWPFormElementDataType, BC000D17_A118WWPFormElementParentType, BC000D17_A105WWPFormElementType, BC000D17_A124WWPFormElementMetadata,
               BC000D17_A125WWPFormElementCaption, BC000D17_A109WWPFormInstanceElemChar, BC000D17_n109WWPFormInstanceElemChar, BC000D17_A108WWPFormInstanceElemDate, BC000D17_n108WWPFormInstanceElemDate, BC000D17_A115WWPFormInstanceElemDateTime, BC000D17_n115WWPFormInstanceElemDateTime, BC000D17_A110WWPFormInstanceElemNumeric, BC000D17_n110WWPFormInstanceElemNumeric, BC000D17_A114WWPFormInstanceElemBoolean,
               BC000D17_n114WWPFormInstanceElemBoolean, BC000D17_A112WWPFormInstanceElemBlobFileType, BC000D17_A113WWPFormInstanceElemBlobFileName, BC000D17_A98WWPFormElementId, BC000D17_A99WWPFormElementParentId, BC000D17_n99WWPFormElementParentId, BC000D17_A111WWPFormInstanceElemBlob, BC000D17_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               BC000D18_A102WWPFormInstanceId, BC000D18_A98WWPFormElementId, BC000D18_A103WWPFormInstanceElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D23_A117WWPFormElementTitle, BC000D23_A101WWPFormElementReferenceId, BC000D23_A106WWPFormElementDataType, BC000D23_A105WWPFormElementType, BC000D23_A124WWPFormElementMetadata, BC000D23_A125WWPFormElementCaption, BC000D23_A99WWPFormElementParentId, BC000D23_n99WWPFormElementParentId
               }
               , new Object[] {
               BC000D24_A118WWPFormElementParentType
               }
               , new Object[] {
               BC000D25_A94WWPFormId, BC000D25_A95WWPFormVersionNumber, BC000D25_A102WWPFormInstanceId, BC000D25_A103WWPFormInstanceElementId, BC000D25_A117WWPFormElementTitle, BC000D25_A101WWPFormElementReferenceId, BC000D25_A106WWPFormElementDataType, BC000D25_A118WWPFormElementParentType, BC000D25_A105WWPFormElementType, BC000D25_A124WWPFormElementMetadata,
               BC000D25_A125WWPFormElementCaption, BC000D25_A109WWPFormInstanceElemChar, BC000D25_n109WWPFormInstanceElemChar, BC000D25_A108WWPFormInstanceElemDate, BC000D25_n108WWPFormInstanceElemDate, BC000D25_A115WWPFormInstanceElemDateTime, BC000D25_n115WWPFormInstanceElemDateTime, BC000D25_A110WWPFormInstanceElemNumeric, BC000D25_n110WWPFormInstanceElemNumeric, BC000D25_A114WWPFormInstanceElemBoolean,
               BC000D25_n114WWPFormInstanceElemBoolean, BC000D25_A112WWPFormInstanceElemBlobFileType, BC000D25_A113WWPFormInstanceElemBlobFileName, BC000D25_A98WWPFormElementId, BC000D25_A99WWPFormElementParentId, BC000D25_n99WWPFormElementParentId, BC000D25_A111WWPFormInstanceElemBlob, BC000D25_n111WWPFormInstanceElemBlob
               }
            }
         );
         AV16Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance_BC";
         Z127WWPFormInstanceDate = DateTime.MinValue;
         A127WWPFormInstanceDate = DateTime.MinValue;
         i127WWPFormInstanceDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_16 ;
      private short RcdFound16 ;
      private short AV11Insert_WWPFormId ;
      private short AV12Insert_WWPFormVersionNumber ;
      private short Z94WWPFormId ;
      private short A94WWPFormId ;
      private short Z95WWPFormVersionNumber ;
      private short A95WWPFormVersionNumber ;
      private short Z104WWPFormResume ;
      private short A104WWPFormResume ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short nRcdExists_16 ;
      private short Z106WWPFormElementDataType ;
      private short A106WWPFormElementDataType ;
      private short Z105WWPFormElementType ;
      private short A105WWPFormElementType ;
      private short Z125WWPFormElementCaption ;
      private short A125WWPFormElementCaption ;
      private short Z99WWPFormElementParentId ;
      private short A99WWPFormElementParentId ;
      private short Z118WWPFormElementParentType ;
      private short A118WWPFormElementParentType ;
      private short Z103WWPFormInstanceElementId ;
      private short A103WWPFormInstanceElementId ;
      private short Z98WWPFormElementId ;
      private short A98WWPFormElementId ;
      private short Gxremove16 ;
      private int trnEnded ;
      private int Z102WWPFormInstanceId ;
      private int A102WWPFormInstanceId ;
      private int nGXsfl_16_idx=1 ;
      private int AV17GXV1 ;
      private decimal Z110WWPFormInstanceElemNumeric ;
      private decimal A110WWPFormInstanceElemNumeric ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode15 ;
      private string AV16Pgmname ;
      private string A111WWPFormInstanceElemBlob_Filetype ;
      private string A111WWPFormInstanceElemBlob_Filename ;
      private string sMode16 ;
      private DateTime Z115WWPFormInstanceElemDateTime ;
      private DateTime A115WWPFormInstanceElemDateTime ;
      private DateTime Z127WWPFormInstanceDate ;
      private DateTime A127WWPFormInstanceDate ;
      private DateTime Gx_date ;
      private DateTime Z108WWPFormInstanceElemDate ;
      private DateTime A108WWPFormInstanceElemDate ;
      private DateTime i127WWPFormInstanceDate ;
      private bool returnInSub ;
      private bool n293WWPFormInstanceRecordKey ;
      private bool Z114WWPFormInstanceElemBoolean ;
      private bool A114WWPFormInstanceElemBoolean ;
      private bool n109WWPFormInstanceElemChar ;
      private bool n108WWPFormInstanceElemDate ;
      private bool n115WWPFormInstanceElemDateTime ;
      private bool n110WWPFormInstanceElemNumeric ;
      private bool n114WWPFormInstanceElemBoolean ;
      private bool n99WWPFormElementParentId ;
      private bool n111WWPFormInstanceElemBlob ;
      private string Z293WWPFormInstanceRecordKey ;
      private string A293WWPFormInstanceRecordKey ;
      private string Z121WWPFormValidations ;
      private string A121WWPFormValidations ;
      private string Z109WWPFormInstanceElemChar ;
      private string A109WWPFormInstanceElemChar ;
      private string Z117WWPFormElementTitle ;
      private string A117WWPFormElementTitle ;
      private string Z124WWPFormElementMetadata ;
      private string A124WWPFormElementMetadata ;
      private string Z97WWPFormTitle ;
      private string A97WWPFormTitle ;
      private string Z101WWPFormElementReferenceId ;
      private string A101WWPFormElementReferenceId ;
      private string Z112WWPFormInstanceElemBlobFileType ;
      private string A112WWPFormInstanceElemBlobFileType ;
      private string Z113WWPFormInstanceElemBlobFileName ;
      private string A113WWPFormInstanceElemBlobFileName ;
      private string Z111WWPFormInstanceElemBlob ;
      private string A111WWPFormInstanceElemBlob ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance bcworkwithplus_dynamicforms_WWP_FormInstance ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC000D9_A102WWPFormInstanceId ;
      private DateTime[] BC000D9_A127WWPFormInstanceDate ;
      private string[] BC000D9_A97WWPFormTitle ;
      private short[] BC000D9_A104WWPFormResume ;
      private string[] BC000D9_A121WWPFormValidations ;
      private string[] BC000D9_A293WWPFormInstanceRecordKey ;
      private bool[] BC000D9_n293WWPFormInstanceRecordKey ;
      private short[] BC000D9_A94WWPFormId ;
      private short[] BC000D9_A95WWPFormVersionNumber ;
      private string[] BC000D8_A97WWPFormTitle ;
      private short[] BC000D8_A104WWPFormResume ;
      private string[] BC000D8_A121WWPFormValidations ;
      private int[] BC000D10_A102WWPFormInstanceId ;
      private int[] BC000D7_A102WWPFormInstanceId ;
      private DateTime[] BC000D7_A127WWPFormInstanceDate ;
      private string[] BC000D7_A293WWPFormInstanceRecordKey ;
      private bool[] BC000D7_n293WWPFormInstanceRecordKey ;
      private short[] BC000D7_A94WWPFormId ;
      private short[] BC000D7_A95WWPFormVersionNumber ;
      private int[] BC000D6_A102WWPFormInstanceId ;
      private DateTime[] BC000D6_A127WWPFormInstanceDate ;
      private string[] BC000D6_A293WWPFormInstanceRecordKey ;
      private bool[] BC000D6_n293WWPFormInstanceRecordKey ;
      private short[] BC000D6_A94WWPFormId ;
      private short[] BC000D6_A95WWPFormVersionNumber ;
      private int[] BC000D12_A102WWPFormInstanceId ;
      private string[] BC000D15_A97WWPFormTitle ;
      private short[] BC000D15_A104WWPFormResume ;
      private string[] BC000D15_A121WWPFormValidations ;
      private int[] BC000D16_A102WWPFormInstanceId ;
      private DateTime[] BC000D16_A127WWPFormInstanceDate ;
      private string[] BC000D16_A97WWPFormTitle ;
      private short[] BC000D16_A104WWPFormResume ;
      private string[] BC000D16_A121WWPFormValidations ;
      private string[] BC000D16_A293WWPFormInstanceRecordKey ;
      private bool[] BC000D16_n293WWPFormInstanceRecordKey ;
      private short[] BC000D16_A94WWPFormId ;
      private short[] BC000D16_A95WWPFormVersionNumber ;
      private short[] BC000D17_A94WWPFormId ;
      private short[] BC000D17_A95WWPFormVersionNumber ;
      private int[] BC000D17_A102WWPFormInstanceId ;
      private short[] BC000D17_A103WWPFormInstanceElementId ;
      private string[] BC000D17_A117WWPFormElementTitle ;
      private string[] BC000D17_A101WWPFormElementReferenceId ;
      private short[] BC000D17_A106WWPFormElementDataType ;
      private short[] BC000D17_A118WWPFormElementParentType ;
      private short[] BC000D17_A105WWPFormElementType ;
      private string[] BC000D17_A124WWPFormElementMetadata ;
      private short[] BC000D17_A125WWPFormElementCaption ;
      private string[] BC000D17_A109WWPFormInstanceElemChar ;
      private bool[] BC000D17_n109WWPFormInstanceElemChar ;
      private DateTime[] BC000D17_A108WWPFormInstanceElemDate ;
      private bool[] BC000D17_n108WWPFormInstanceElemDate ;
      private DateTime[] BC000D17_A115WWPFormInstanceElemDateTime ;
      private bool[] BC000D17_n115WWPFormInstanceElemDateTime ;
      private decimal[] BC000D17_A110WWPFormInstanceElemNumeric ;
      private bool[] BC000D17_n110WWPFormInstanceElemNumeric ;
      private bool[] BC000D17_A114WWPFormInstanceElemBoolean ;
      private bool[] BC000D17_n114WWPFormInstanceElemBoolean ;
      private string[] BC000D17_A112WWPFormInstanceElemBlobFileType ;
      private string[] BC000D17_A113WWPFormInstanceElemBlobFileName ;
      private short[] BC000D17_A98WWPFormElementId ;
      private short[] BC000D17_A99WWPFormElementParentId ;
      private bool[] BC000D17_n99WWPFormElementParentId ;
      private string[] BC000D17_A111WWPFormInstanceElemBlob ;
      private bool[] BC000D17_n111WWPFormInstanceElemBlob ;
      private short[] BC000D4_A94WWPFormId ;
      private short[] BC000D4_A95WWPFormVersionNumber ;
      private string[] BC000D4_A117WWPFormElementTitle ;
      private string[] BC000D4_A101WWPFormElementReferenceId ;
      private short[] BC000D4_A106WWPFormElementDataType ;
      private short[] BC000D4_A105WWPFormElementType ;
      private string[] BC000D4_A124WWPFormElementMetadata ;
      private short[] BC000D4_A125WWPFormElementCaption ;
      private short[] BC000D4_A99WWPFormElementParentId ;
      private bool[] BC000D4_n99WWPFormElementParentId ;
      private short[] BC000D5_A118WWPFormElementParentType ;
      private int[] BC000D18_A102WWPFormInstanceId ;
      private short[] BC000D18_A98WWPFormElementId ;
      private short[] BC000D18_A103WWPFormInstanceElementId ;
      private int[] BC000D3_A102WWPFormInstanceId ;
      private short[] BC000D3_A103WWPFormInstanceElementId ;
      private string[] BC000D3_A109WWPFormInstanceElemChar ;
      private bool[] BC000D3_n109WWPFormInstanceElemChar ;
      private DateTime[] BC000D3_A108WWPFormInstanceElemDate ;
      private bool[] BC000D3_n108WWPFormInstanceElemDate ;
      private DateTime[] BC000D3_A115WWPFormInstanceElemDateTime ;
      private bool[] BC000D3_n115WWPFormInstanceElemDateTime ;
      private decimal[] BC000D3_A110WWPFormInstanceElemNumeric ;
      private bool[] BC000D3_n110WWPFormInstanceElemNumeric ;
      private bool[] BC000D3_A114WWPFormInstanceElemBoolean ;
      private bool[] BC000D3_n114WWPFormInstanceElemBoolean ;
      private string[] BC000D3_A112WWPFormInstanceElemBlobFileType ;
      private string[] BC000D3_A113WWPFormInstanceElemBlobFileName ;
      private short[] BC000D3_A98WWPFormElementId ;
      private string[] BC000D3_A111WWPFormInstanceElemBlob ;
      private bool[] BC000D3_n111WWPFormInstanceElemBlob ;
      private int[] BC000D2_A102WWPFormInstanceId ;
      private short[] BC000D2_A103WWPFormInstanceElementId ;
      private string[] BC000D2_A109WWPFormInstanceElemChar ;
      private bool[] BC000D2_n109WWPFormInstanceElemChar ;
      private DateTime[] BC000D2_A108WWPFormInstanceElemDate ;
      private bool[] BC000D2_n108WWPFormInstanceElemDate ;
      private DateTime[] BC000D2_A115WWPFormInstanceElemDateTime ;
      private bool[] BC000D2_n115WWPFormInstanceElemDateTime ;
      private decimal[] BC000D2_A110WWPFormInstanceElemNumeric ;
      private bool[] BC000D2_n110WWPFormInstanceElemNumeric ;
      private bool[] BC000D2_A114WWPFormInstanceElemBoolean ;
      private bool[] BC000D2_n114WWPFormInstanceElemBoolean ;
      private string[] BC000D2_A112WWPFormInstanceElemBlobFileType ;
      private string[] BC000D2_A113WWPFormInstanceElemBlobFileName ;
      private short[] BC000D2_A98WWPFormElementId ;
      private string[] BC000D2_A111WWPFormInstanceElemBlob ;
      private bool[] BC000D2_n111WWPFormInstanceElemBlob ;
      private string[] BC000D23_A117WWPFormElementTitle ;
      private string[] BC000D23_A101WWPFormElementReferenceId ;
      private short[] BC000D23_A106WWPFormElementDataType ;
      private short[] BC000D23_A105WWPFormElementType ;
      private string[] BC000D23_A124WWPFormElementMetadata ;
      private short[] BC000D23_A125WWPFormElementCaption ;
      private short[] BC000D23_A99WWPFormElementParentId ;
      private bool[] BC000D23_n99WWPFormElementParentId ;
      private short[] BC000D24_A118WWPFormElementParentType ;
      private short[] BC000D25_A94WWPFormId ;
      private short[] BC000D25_A95WWPFormVersionNumber ;
      private int[] BC000D25_A102WWPFormInstanceId ;
      private short[] BC000D25_A103WWPFormInstanceElementId ;
      private string[] BC000D25_A117WWPFormElementTitle ;
      private string[] BC000D25_A101WWPFormElementReferenceId ;
      private short[] BC000D25_A106WWPFormElementDataType ;
      private short[] BC000D25_A118WWPFormElementParentType ;
      private short[] BC000D25_A105WWPFormElementType ;
      private string[] BC000D25_A124WWPFormElementMetadata ;
      private short[] BC000D25_A125WWPFormElementCaption ;
      private string[] BC000D25_A109WWPFormInstanceElemChar ;
      private bool[] BC000D25_n109WWPFormInstanceElemChar ;
      private DateTime[] BC000D25_A108WWPFormInstanceElemDate ;
      private bool[] BC000D25_n108WWPFormInstanceElemDate ;
      private DateTime[] BC000D25_A115WWPFormInstanceElemDateTime ;
      private bool[] BC000D25_n115WWPFormInstanceElemDateTime ;
      private decimal[] BC000D25_A110WWPFormInstanceElemNumeric ;
      private bool[] BC000D25_n110WWPFormInstanceElemNumeric ;
      private bool[] BC000D25_A114WWPFormInstanceElemBoolean ;
      private bool[] BC000D25_n114WWPFormInstanceElemBoolean ;
      private string[] BC000D25_A112WWPFormInstanceElemBlobFileType ;
      private string[] BC000D25_A113WWPFormInstanceElemBlobFileName ;
      private short[] BC000D25_A98WWPFormElementId ;
      private short[] BC000D25_A99WWPFormElementParentId ;
      private bool[] BC000D25_n99WWPFormElementParentId ;
      private string[] BC000D25_A111WWPFormInstanceElemBlob ;
      private bool[] BC000D25_n111WWPFormInstanceElemBlob ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_forminstance_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000D2;
          prmBC000D2 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D3;
          prmBC000D3 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D4;
          prmBC000D4 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D5;
          prmBC000D5 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000D6;
          prmBC000D6 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D7;
          prmBC000D7 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D8;
          prmBC000D8 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000D9;
          prmBC000D9 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D10;
          prmBC000D10 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D11;
          prmBC000D11 = new Object[] {
          new ParDef("WWPFormInstanceDate",GXType.Date,8,0) ,
          new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000D12;
          prmBC000D12 = new Object[] {
          };
          Object[] prmBC000D13;
          prmBC000D13 = new Object[] {
          new ParDef("WWPFormInstanceDate",GXType.Date,8,0) ,
          new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D14;
          prmBC000D14 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D15;
          prmBC000D15 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmBC000D16;
          prmBC000D16 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmBC000D17;
          prmBC000D17 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D18;
          prmBC000D18 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D19;
          prmBC000D19 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBlobFileType",GXType.VarChar,40,0) ,
          new ParDef("WWPFormInstanceElemBlobFileName",GXType.VarChar,40,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D20;
          prmBC000D20 = new Object[] {
          new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBlobFileType",GXType.VarChar,40,0) ,
          new ParDef("WWPFormInstanceElemBlobFileName",GXType.VarChar,40,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D21;
          prmBC000D21 = new Object[] {
          new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D22;
          prmBC000D22 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D23;
          prmBC000D23 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmBC000D24;
          prmBC000D24 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000D25;
          prmBC000D25 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000D2", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId  FOR UPDATE OF WWP_FormInstanceElement",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D3", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D4", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D5", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D6", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId  FOR UPDATE OF WWP_FormInstance",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D7", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D8", "SELECT WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D9", "SELECT TM1.WWPFormInstanceId, TM1.WWPFormInstanceDate, T2.WWPFormTitle, T2.WWPFormResume, T2.WWPFormValidations, TM1.WWPFormInstanceRecordKey, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (WWP_FormInstance TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY TM1.WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D10", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D11", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstance(WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber) VALUES(:WWPFormInstanceDate, :WWPFormInstanceRecordKey, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000D11)
             ,new CursorDef("BC000D12", "SELECT currval('WWPFormInstanceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D13", "SAVEPOINT gxupdate;UPDATE WWP_FormInstance SET WWPFormInstanceDate=:WWPFormInstanceDate, WWPFormInstanceRecordKey=:WWPFormInstanceRecordKey, WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D13)
             ,new CursorDef("BC000D14", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstance  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D14)
             ,new CursorDef("BC000D15", "SELECT WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D16", "SELECT TM1.WWPFormInstanceId, TM1.WWPFormInstanceDate, T2.WWPFormTitle, T2.WWPFormResume, T2.WWPFormValidations, TM1.WWPFormInstanceRecordKey, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (WWP_FormInstance TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY TM1.WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D17", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceId, T1.WWPFormInstanceElementId, T2.WWPFormElementTitle, T2.WWPFormElementReferenceId, T2.WWPFormElementDataType, T3.WWPFormElementType AS WWPFormElementParentType, T2.WWPFormElementType, T2.WWPFormElementMetadata, T2.WWPFormElementCaption, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemBoolean, T1.WWPFormInstanceElemBlobFileType, T1.WWPFormInstanceElemBlobFileName, T1.WWPFormElementId, T2.WWPFormElementParentId AS WWPFormElementParentId, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = :WWPFormId AND T2.WWPFormVersionNumber = :WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T2.WWPFormElementParentId) WHERE T1.WWPFormInstanceId = :WWPFormInstanceId and T1.WWPFormInstanceElementId = :WWPFormInstanceElementId and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D17,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D18", "SELECT WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D19", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstanceElement(WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBlob, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName, WWPFormElementId) VALUES(:WWPFormInstanceId, :WWPFormInstanceElementId, :WWPFormInstanceElemChar, :WWPFormInstanceElemDate, :WWPFormInstanceElemDateTime, :WWPFormInstanceElemNumeric, :WWPFormInstanceElemBlob, :WWPFormInstanceElemBoolean, :WWPFormInstanceElemBlobFileType, :WWPFormInstanceElemBlobFileName, :WWPFormElementId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000D19)
             ,new CursorDef("BC000D20", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemChar=:WWPFormInstanceElemChar, WWPFormInstanceElemDate=:WWPFormInstanceElemDate, WWPFormInstanceElemDateTime=:WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric=:WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean=:WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType=:WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName=:WWPFormInstanceElemBlobFileName  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D20)
             ,new CursorDef("BC000D21", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemBlob=:WWPFormInstanceElemBlob  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D21)
             ,new CursorDef("BC000D22", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstanceElement  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D22)
             ,new CursorDef("BC000D23", "SELECT WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D24", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D25", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceId, T1.WWPFormInstanceElementId, T2.WWPFormElementTitle, T2.WWPFormElementReferenceId, T2.WWPFormElementDataType, T3.WWPFormElementType AS WWPFormElementParentType, T2.WWPFormElementType, T2.WWPFormElementMetadata, T2.WWPFormElementCaption, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemBoolean, T1.WWPFormInstanceElemBlobFileType, T1.WWPFormInstanceElemBlobFileName, T1.WWPFormElementId, T2.WWPFormElementParentId AS WWPFormElementParentId, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = :WWPFormId AND T2.WWPFormVersionNumber = :WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T2.WWPFormElementParentId) WHERE T1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D25,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((bool[]) buf[19])[0] = rslt.getBool(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((string[]) buf[21])[0] = rslt.getVarchar(17);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((short[]) buf[23])[0] = rslt.getShort(19);
                ((short[]) buf[24])[0] = rslt.getShort(20);
                ((bool[]) buf[25])[0] = rslt.wasNull(20);
                ((string[]) buf[26])[0] = rslt.getBLOBFile(21, rslt.getVarchar(17), rslt.getVarchar(18));
                ((bool[]) buf[27])[0] = rslt.wasNull(21);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((bool[]) buf[19])[0] = rslt.getBool(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((string[]) buf[21])[0] = rslt.getVarchar(17);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((short[]) buf[23])[0] = rslt.getShort(19);
                ((short[]) buf[24])[0] = rslt.getShort(20);
                ((bool[]) buf[25])[0] = rslt.wasNull(20);
                ((string[]) buf[26])[0] = rslt.getBLOBFile(21, rslt.getVarchar(17), rslt.getVarchar(18));
                ((bool[]) buf[27])[0] = rslt.wasNull(21);
                return;
       }
    }

 }

}
