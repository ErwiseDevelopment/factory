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
   public class secfunctionality_bc : GxSilentTrn, IGxSilentTrn
   {
      public secfunctionality_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionality_bc( IGxContext context )
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
         ReadRow0E17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E17( ) ;
         standaloneModal( ) ;
         AddRow0E17( ) ;
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
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z128SecFunctionalityId = A128SecFunctionalityId;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E17( ) ;
            }
            else
            {
               CheckExtendedTable0E17( ) ;
               if ( AnyError == 0 )
               {
                  ZM0E17( 7) ;
               }
               CloseExtendedTableCursors0E17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV18WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            while ( AV20GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SecParentFunctionalityId") == 0 )
               {
                  AV12Insert_SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
         }
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0E17( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z130SecFunctionalityKey = A130SecFunctionalityKey;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
            Z789SecFunctionalityModule = A789SecFunctionalityModule;
            Z136SecFunctionalityType = A136SecFunctionalityType;
            Z134SecFunctionalityActive = A134SecFunctionalityActive;
            Z129SecParentFunctionalityId = A129SecParentFunctionalityId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z138SecParentFunctionalityDescription = A138SecParentFunctionalityDescription;
         }
         if ( GX_JID == -5 )
         {
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z130SecFunctionalityKey = A130SecFunctionalityKey;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
            Z789SecFunctionalityModule = A789SecFunctionalityModule;
            Z136SecFunctionalityType = A136SecFunctionalityType;
            Z134SecFunctionalityActive = A134SecFunctionalityActive;
            Z129SecParentFunctionalityId = A129SecParentFunctionalityId;
            Z138SecParentFunctionalityDescription = A138SecParentFunctionalityDescription;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "WWPBaseObjects.SecFunctionality_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0E17( )
      {
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
            A130SecFunctionalityKey = BC000E5_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = BC000E5_n130SecFunctionalityKey[0];
            A135SecFunctionalityDescription = BC000E5_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000E5_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = BC000E5_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = BC000E5_n789SecFunctionalityModule[0];
            A136SecFunctionalityType = BC000E5_A136SecFunctionalityType[0];
            n136SecFunctionalityType = BC000E5_n136SecFunctionalityType[0];
            A138SecParentFunctionalityDescription = BC000E5_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = BC000E5_n138SecParentFunctionalityDescription[0];
            A134SecFunctionalityActive = BC000E5_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = BC000E5_n134SecFunctionalityActive[0];
            A129SecParentFunctionalityId = BC000E5_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = BC000E5_n129SecParentFunctionalityId[0];
            ZM0E17( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0E17( ) ;
      }

      protected void OnLoadActions0E17( )
      {
         if ( (0==A129SecParentFunctionalityId) )
         {
            A129SecParentFunctionalityId = 0;
            n129SecParentFunctionalityId = false;
            n129SecParentFunctionalityId = true;
            n129SecParentFunctionalityId = true;
         }
      }

      protected void CheckExtendedTable0E17( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000E6 */
         pr_default.execute(4, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, A128SecFunctionalityId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Functionality Key"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         if ( ! ( ( A136SecFunctionalityType == 1 ) || ( A136SecFunctionalityType == 2 ) || ( A136SecFunctionalityType == 3 ) || ( A136SecFunctionalityType == 4 ) || ( A136SecFunctionalityType == 5 ) || (0==A136SecFunctionalityType) ) )
         {
            GX_msglist.addItem("Campo Functionality Type fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A129SecParentFunctionalityId) )
         {
            A129SecParentFunctionalityId = 0;
            n129SecParentFunctionalityId = false;
            n129SecParentFunctionalityId = true;
            n129SecParentFunctionalityId = true;
         }
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {n129SecParentFunctionalityId, A129SecParentFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A129SecParentFunctionalityId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec Functionality Functionality'.", "ForeignKeyNotFound", 1, "SECPARENTFUNCTIONALITYID");
               AnyError = 1;
            }
         }
         A138SecParentFunctionalityDescription = BC000E4_A138SecParentFunctionalityDescription[0];
         n138SecParentFunctionalityDescription = BC000E4_n138SecParentFunctionalityDescription[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0E17( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E17( )
      {
         /* Using cursor BC000E7 */
         pr_default.execute(5, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E17( 5) ;
            RcdFound17 = 1;
            A128SecFunctionalityId = BC000E3_A128SecFunctionalityId[0];
            A130SecFunctionalityKey = BC000E3_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = BC000E3_n130SecFunctionalityKey[0];
            A135SecFunctionalityDescription = BC000E3_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000E3_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = BC000E3_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = BC000E3_n789SecFunctionalityModule[0];
            A136SecFunctionalityType = BC000E3_A136SecFunctionalityType[0];
            n136SecFunctionalityType = BC000E3_n136SecFunctionalityType[0];
            A134SecFunctionalityActive = BC000E3_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = BC000E3_n134SecFunctionalityActive[0];
            A129SecParentFunctionalityId = BC000E3_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = BC000E3_n129SecParentFunctionalityId[0];
            Z128SecFunctionalityId = A128SecFunctionalityId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0E17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0E17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0E17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionality"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z130SecFunctionalityKey, BC000E2_A130SecFunctionalityKey[0]) != 0 ) || ( StringUtil.StrCmp(Z135SecFunctionalityDescription, BC000E2_A135SecFunctionalityDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z789SecFunctionalityModule, BC000E2_A789SecFunctionalityModule[0]) != 0 ) || ( Z136SecFunctionalityType != BC000E2_A136SecFunctionalityType[0] ) || ( Z134SecFunctionalityActive != BC000E2_A134SecFunctionalityActive[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z129SecParentFunctionalityId != BC000E2_A129SecParentFunctionalityId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecFunctionality"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E17( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E17( 0) ;
            CheckOptimisticConcurrency0E17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E8 */
                     pr_default.execute(6, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, n135SecFunctionalityDescription, A135SecFunctionalityDescription, n789SecFunctionalityModule, A789SecFunctionalityModule, n136SecFunctionalityType, A136SecFunctionalityType, n134SecFunctionalityActive, A134SecFunctionalityActive, n129SecParentFunctionalityId, A129SecParentFunctionalityId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000E9 */
                     pr_default.execute(7);
                     A128SecFunctionalityId = BC000E9_A128SecFunctionalityId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
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
               Load0E17( ) ;
            }
            EndLevel0E17( ) ;
         }
         CloseExtendedTableCursors0E17( ) ;
      }

      protected void Update0E17( )
      {
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E10 */
                     pr_default.execute(8, new Object[] {n130SecFunctionalityKey, A130SecFunctionalityKey, n135SecFunctionalityDescription, A135SecFunctionalityDescription, n789SecFunctionalityModule, A789SecFunctionalityModule, n136SecFunctionalityType, A136SecFunctionalityType, n134SecFunctionalityActive, A134SecFunctionalityActive, n129SecParentFunctionalityId, A129SecParentFunctionalityId, A128SecFunctionalityId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionality"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E17( ) ;
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
            EndLevel0E17( ) ;
         }
         CloseExtendedTableCursors0E17( ) ;
      }

      protected void DeferredUpdate0E17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E17( ) ;
            AfterConfirm0E17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E11 */
                  pr_default.execute(9, new Object[] {A128SecFunctionalityId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0E17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000E12 */
            pr_default.execute(10, new Object[] {n129SecParentFunctionalityId, A129SecParentFunctionalityId});
            A138SecParentFunctionalityDescription = BC000E12_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = BC000E12_n138SecParentFunctionalityDescription[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E13 */
            pr_default.execute(11, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionality"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000E14 */
            pr_default.execute(12, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionalities"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000E15 */
            pr_default.execute(13, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Functionality Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0E17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E17( ) ;
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

      public void ScanKeyStart0E17( )
      {
         /* Scan By routine */
         /* Using cursor BC000E16 */
         pr_default.execute(14, new Object[] {A128SecFunctionalityId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound17 = 1;
            A128SecFunctionalityId = BC000E16_A128SecFunctionalityId[0];
            A130SecFunctionalityKey = BC000E16_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = BC000E16_n130SecFunctionalityKey[0];
            A135SecFunctionalityDescription = BC000E16_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000E16_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = BC000E16_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = BC000E16_n789SecFunctionalityModule[0];
            A136SecFunctionalityType = BC000E16_A136SecFunctionalityType[0];
            n136SecFunctionalityType = BC000E16_n136SecFunctionalityType[0];
            A138SecParentFunctionalityDescription = BC000E16_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = BC000E16_n138SecParentFunctionalityDescription[0];
            A134SecFunctionalityActive = BC000E16_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = BC000E16_n134SecFunctionalityActive[0];
            A129SecParentFunctionalityId = BC000E16_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = BC000E16_n129SecParentFunctionalityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E17( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound17 = 0;
         ScanKeyLoad0E17( ) ;
      }

      protected void ScanKeyLoad0E17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound17 = 1;
            A128SecFunctionalityId = BC000E16_A128SecFunctionalityId[0];
            A130SecFunctionalityKey = BC000E16_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = BC000E16_n130SecFunctionalityKey[0];
            A135SecFunctionalityDescription = BC000E16_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000E16_n135SecFunctionalityDescription[0];
            A789SecFunctionalityModule = BC000E16_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = BC000E16_n789SecFunctionalityModule[0];
            A136SecFunctionalityType = BC000E16_A136SecFunctionalityType[0];
            n136SecFunctionalityType = BC000E16_n136SecFunctionalityType[0];
            A138SecParentFunctionalityDescription = BC000E16_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = BC000E16_n138SecParentFunctionalityDescription[0];
            A134SecFunctionalityActive = BC000E16_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = BC000E16_n134SecFunctionalityActive[0];
            A129SecParentFunctionalityId = BC000E16_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = BC000E16_n129SecParentFunctionalityId[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0E17( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0E17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E17( )
      {
      }

      protected void send_integrity_lvl_hashes0E17( )
      {
      }

      protected void AddRow0E17( )
      {
         VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
      }

      protected void ReadRow0E17( )
      {
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
      }

      protected void InitializeNonKey0E17( )
      {
         A130SecFunctionalityKey = "";
         n130SecFunctionalityKey = false;
         A135SecFunctionalityDescription = "";
         n135SecFunctionalityDescription = false;
         A789SecFunctionalityModule = "";
         n789SecFunctionalityModule = false;
         A136SecFunctionalityType = 0;
         n136SecFunctionalityType = false;
         A129SecParentFunctionalityId = 0;
         n129SecParentFunctionalityId = false;
         A138SecParentFunctionalityDescription = "";
         n138SecParentFunctionalityDescription = false;
         A134SecFunctionalityActive = false;
         n134SecFunctionalityActive = false;
         Z130SecFunctionalityKey = "";
         Z135SecFunctionalityDescription = "";
         Z789SecFunctionalityModule = "";
         Z136SecFunctionalityType = 0;
         Z134SecFunctionalityActive = false;
         Z129SecParentFunctionalityId = 0;
      }

      protected void InitAll0E17( )
      {
         A128SecFunctionalityId = 0;
         InitializeNonKey0E17( ) ;
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

      public void VarsToRow17( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Secfunctionalitykey = A130SecFunctionalityKey;
         obj17.gxTpr_Secfunctionalitydescription = A135SecFunctionalityDescription;
         obj17.gxTpr_Secfunctionalitymodule = A789SecFunctionalityModule;
         obj17.gxTpr_Secfunctionalitytype = A136SecFunctionalityType;
         obj17.gxTpr_Secparentfunctionalityid = A129SecParentFunctionalityId;
         obj17.gxTpr_Secparentfunctionalitydescription = A138SecParentFunctionalityDescription;
         obj17.gxTpr_Secfunctionalityactive = A134SecFunctionalityActive;
         obj17.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
         obj17.gxTpr_Secfunctionalityid_Z = Z128SecFunctionalityId;
         obj17.gxTpr_Secfunctionalitykey_Z = Z130SecFunctionalityKey;
         obj17.gxTpr_Secfunctionalitydescription_Z = Z135SecFunctionalityDescription;
         obj17.gxTpr_Secfunctionalitymodule_Z = Z789SecFunctionalityModule;
         obj17.gxTpr_Secfunctionalitytype_Z = Z136SecFunctionalityType;
         obj17.gxTpr_Secparentfunctionalityid_Z = Z129SecParentFunctionalityId;
         obj17.gxTpr_Secparentfunctionalitydescription_Z = Z138SecParentFunctionalityDescription;
         obj17.gxTpr_Secfunctionalityactive_Z = Z134SecFunctionalityActive;
         obj17.gxTpr_Secfunctionalitykey_N = (short)(Convert.ToInt16(n130SecFunctionalityKey));
         obj17.gxTpr_Secfunctionalitydescription_N = (short)(Convert.ToInt16(n135SecFunctionalityDescription));
         obj17.gxTpr_Secfunctionalitymodule_N = (short)(Convert.ToInt16(n789SecFunctionalityModule));
         obj17.gxTpr_Secfunctionalitytype_N = (short)(Convert.ToInt16(n136SecFunctionalityType));
         obj17.gxTpr_Secparentfunctionalityid_N = (short)(Convert.ToInt16(n129SecParentFunctionalityId));
         obj17.gxTpr_Secparentfunctionalitydescription_N = (short)(Convert.ToInt16(n138SecParentFunctionalityDescription));
         obj17.gxTpr_Secfunctionalityactive_N = (short)(Convert.ToInt16(n134SecFunctionalityActive));
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality obj17 )
      {
         obj17.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
         return  ;
      }

      public void RowToVars17( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A130SecFunctionalityKey = obj17.gxTpr_Secfunctionalitykey;
         n130SecFunctionalityKey = false;
         A135SecFunctionalityDescription = obj17.gxTpr_Secfunctionalitydescription;
         n135SecFunctionalityDescription = false;
         A789SecFunctionalityModule = obj17.gxTpr_Secfunctionalitymodule;
         n789SecFunctionalityModule = false;
         A136SecFunctionalityType = obj17.gxTpr_Secfunctionalitytype;
         n136SecFunctionalityType = false;
         A129SecParentFunctionalityId = obj17.gxTpr_Secparentfunctionalityid;
         n129SecParentFunctionalityId = false;
         A138SecParentFunctionalityDescription = obj17.gxTpr_Secparentfunctionalitydescription;
         n138SecParentFunctionalityDescription = false;
         A134SecFunctionalityActive = obj17.gxTpr_Secfunctionalityactive;
         n134SecFunctionalityActive = false;
         A128SecFunctionalityId = obj17.gxTpr_Secfunctionalityid;
         Z128SecFunctionalityId = obj17.gxTpr_Secfunctionalityid_Z;
         Z130SecFunctionalityKey = obj17.gxTpr_Secfunctionalitykey_Z;
         Z135SecFunctionalityDescription = obj17.gxTpr_Secfunctionalitydescription_Z;
         Z789SecFunctionalityModule = obj17.gxTpr_Secfunctionalitymodule_Z;
         Z136SecFunctionalityType = obj17.gxTpr_Secfunctionalitytype_Z;
         Z129SecParentFunctionalityId = obj17.gxTpr_Secparentfunctionalityid_Z;
         Z138SecParentFunctionalityDescription = obj17.gxTpr_Secparentfunctionalitydescription_Z;
         Z134SecFunctionalityActive = obj17.gxTpr_Secfunctionalityactive_Z;
         n130SecFunctionalityKey = (bool)(Convert.ToBoolean(obj17.gxTpr_Secfunctionalitykey_N));
         n135SecFunctionalityDescription = (bool)(Convert.ToBoolean(obj17.gxTpr_Secfunctionalitydescription_N));
         n789SecFunctionalityModule = (bool)(Convert.ToBoolean(obj17.gxTpr_Secfunctionalitymodule_N));
         n136SecFunctionalityType = (bool)(Convert.ToBoolean(obj17.gxTpr_Secfunctionalitytype_N));
         n129SecParentFunctionalityId = (bool)(Convert.ToBoolean(obj17.gxTpr_Secparentfunctionalityid_N));
         n138SecParentFunctionalityDescription = (bool)(Convert.ToBoolean(obj17.gxTpr_Secparentfunctionalitydescription_N));
         n134SecFunctionalityActive = (bool)(Convert.ToBoolean(obj17.gxTpr_Secfunctionalityactive_N));
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A128SecFunctionalityId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E17( ) ;
         ScanKeyStart0E17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z128SecFunctionalityId = A128SecFunctionalityId;
         }
         ZM0E17( -5) ;
         OnLoadActions0E17( ) ;
         AddRow0E17( ) ;
         ScanKeyEnd0E17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 0) ;
         ScanKeyStart0E17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z128SecFunctionalityId = A128SecFunctionalityId;
         }
         ZM0E17( -5) ;
         OnLoadActions0E17( ) ;
         AddRow0E17( ) ;
         ScanKeyEnd0E17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0E17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A128SecFunctionalityId != Z128SecFunctionalityId )
               {
                  A128SecFunctionalityId = Z128SecFunctionalityId;
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
                  Update0E17( ) ;
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
                  if ( A128SecFunctionalityId != Z128SecFunctionalityId )
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
                        Insert0E17( ) ;
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
                        Insert0E17( ) ;
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
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A128SecFunctionalityId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecFunctionality);
               auxBC.Save();
               bcwwpbaseobjects_SecFunctionality.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
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
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E17( ) ;
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
               VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
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
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 0) ;
         GetKey0E17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A128SecFunctionalityId != Z128SecFunctionalityId )
            {
               A128SecFunctionalityId = Z128SecFunctionalityId;
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
            if ( A128SecFunctionalityId != Z128SecFunctionalityId )
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
         context.RollbackDataStores("wwpbaseobjects.secfunctionality_bc",pr_default);
         VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
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
         Gx_mode = bcwwpbaseobjects_SecFunctionality.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecFunctionality.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecFunctionality )
         {
            bcwwpbaseobjects_SecFunctionality = (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecFunctionality.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecFunctionality.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcwwpbaseobjects_SecFunctionality) ;
            }
            else
            {
               RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecFunctionality.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecFunctionality.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcwwpbaseobjects_SecFunctionality, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecFunctionality SecFunctionality_BC
      {
         get {
            return bcwwpbaseobjects_SecFunctionality ;
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
         AV18WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV19Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z130SecFunctionalityKey = "";
         A130SecFunctionalityKey = "";
         Z135SecFunctionalityDescription = "";
         A135SecFunctionalityDescription = "";
         Z789SecFunctionalityModule = "";
         A789SecFunctionalityModule = "";
         Z138SecParentFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         BC000E5_A128SecFunctionalityId = new long[1] ;
         BC000E5_A130SecFunctionalityKey = new string[] {""} ;
         BC000E5_n130SecFunctionalityKey = new bool[] {false} ;
         BC000E5_A135SecFunctionalityDescription = new string[] {""} ;
         BC000E5_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000E5_A789SecFunctionalityModule = new string[] {""} ;
         BC000E5_n789SecFunctionalityModule = new bool[] {false} ;
         BC000E5_A136SecFunctionalityType = new short[1] ;
         BC000E5_n136SecFunctionalityType = new bool[] {false} ;
         BC000E5_A138SecParentFunctionalityDescription = new string[] {""} ;
         BC000E5_n138SecParentFunctionalityDescription = new bool[] {false} ;
         BC000E5_A134SecFunctionalityActive = new bool[] {false} ;
         BC000E5_n134SecFunctionalityActive = new bool[] {false} ;
         BC000E5_A129SecParentFunctionalityId = new long[1] ;
         BC000E5_n129SecParentFunctionalityId = new bool[] {false} ;
         BC000E6_A130SecFunctionalityKey = new string[] {""} ;
         BC000E6_n130SecFunctionalityKey = new bool[] {false} ;
         BC000E4_A138SecParentFunctionalityDescription = new string[] {""} ;
         BC000E4_n138SecParentFunctionalityDescription = new bool[] {false} ;
         BC000E7_A128SecFunctionalityId = new long[1] ;
         BC000E3_A128SecFunctionalityId = new long[1] ;
         BC000E3_A130SecFunctionalityKey = new string[] {""} ;
         BC000E3_n130SecFunctionalityKey = new bool[] {false} ;
         BC000E3_A135SecFunctionalityDescription = new string[] {""} ;
         BC000E3_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000E3_A789SecFunctionalityModule = new string[] {""} ;
         BC000E3_n789SecFunctionalityModule = new bool[] {false} ;
         BC000E3_A136SecFunctionalityType = new short[1] ;
         BC000E3_n136SecFunctionalityType = new bool[] {false} ;
         BC000E3_A134SecFunctionalityActive = new bool[] {false} ;
         BC000E3_n134SecFunctionalityActive = new bool[] {false} ;
         BC000E3_A129SecParentFunctionalityId = new long[1] ;
         BC000E3_n129SecParentFunctionalityId = new bool[] {false} ;
         sMode17 = "";
         BC000E2_A128SecFunctionalityId = new long[1] ;
         BC000E2_A130SecFunctionalityKey = new string[] {""} ;
         BC000E2_n130SecFunctionalityKey = new bool[] {false} ;
         BC000E2_A135SecFunctionalityDescription = new string[] {""} ;
         BC000E2_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000E2_A789SecFunctionalityModule = new string[] {""} ;
         BC000E2_n789SecFunctionalityModule = new bool[] {false} ;
         BC000E2_A136SecFunctionalityType = new short[1] ;
         BC000E2_n136SecFunctionalityType = new bool[] {false} ;
         BC000E2_A134SecFunctionalityActive = new bool[] {false} ;
         BC000E2_n134SecFunctionalityActive = new bool[] {false} ;
         BC000E2_A129SecParentFunctionalityId = new long[1] ;
         BC000E2_n129SecParentFunctionalityId = new bool[] {false} ;
         BC000E9_A128SecFunctionalityId = new long[1] ;
         BC000E12_A138SecParentFunctionalityDescription = new string[] {""} ;
         BC000E12_n138SecParentFunctionalityDescription = new bool[] {false} ;
         BC000E13_A129SecParentFunctionalityId = new long[1] ;
         BC000E13_n129SecParentFunctionalityId = new bool[] {false} ;
         BC000E14_A132SecObjectName = new string[] {""} ;
         BC000E14_A128SecFunctionalityId = new long[1] ;
         BC000E15_A128SecFunctionalityId = new long[1] ;
         BC000E15_A131SecRoleId = new short[1] ;
         BC000E16_A128SecFunctionalityId = new long[1] ;
         BC000E16_A130SecFunctionalityKey = new string[] {""} ;
         BC000E16_n130SecFunctionalityKey = new bool[] {false} ;
         BC000E16_A135SecFunctionalityDescription = new string[] {""} ;
         BC000E16_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000E16_A789SecFunctionalityModule = new string[] {""} ;
         BC000E16_n789SecFunctionalityModule = new bool[] {false} ;
         BC000E16_A136SecFunctionalityType = new short[1] ;
         BC000E16_n136SecFunctionalityType = new bool[] {false} ;
         BC000E16_A138SecParentFunctionalityDescription = new string[] {""} ;
         BC000E16_n138SecParentFunctionalityDescription = new bool[] {false} ;
         BC000E16_A134SecFunctionalityActive = new bool[] {false} ;
         BC000E16_n134SecFunctionalityActive = new bool[] {false} ;
         BC000E16_A129SecParentFunctionalityId = new long[1] ;
         BC000E16_n129SecParentFunctionalityId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionality_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A128SecFunctionalityId, BC000E2_A130SecFunctionalityKey, BC000E2_n130SecFunctionalityKey, BC000E2_A135SecFunctionalityDescription, BC000E2_n135SecFunctionalityDescription, BC000E2_A789SecFunctionalityModule, BC000E2_n789SecFunctionalityModule, BC000E2_A136SecFunctionalityType, BC000E2_n136SecFunctionalityType, BC000E2_A134SecFunctionalityActive,
               BC000E2_n134SecFunctionalityActive, BC000E2_A129SecParentFunctionalityId, BC000E2_n129SecParentFunctionalityId
               }
               , new Object[] {
               BC000E3_A128SecFunctionalityId, BC000E3_A130SecFunctionalityKey, BC000E3_n130SecFunctionalityKey, BC000E3_A135SecFunctionalityDescription, BC000E3_n135SecFunctionalityDescription, BC000E3_A789SecFunctionalityModule, BC000E3_n789SecFunctionalityModule, BC000E3_A136SecFunctionalityType, BC000E3_n136SecFunctionalityType, BC000E3_A134SecFunctionalityActive,
               BC000E3_n134SecFunctionalityActive, BC000E3_A129SecParentFunctionalityId, BC000E3_n129SecParentFunctionalityId
               }
               , new Object[] {
               BC000E4_A138SecParentFunctionalityDescription, BC000E4_n138SecParentFunctionalityDescription
               }
               , new Object[] {
               BC000E5_A128SecFunctionalityId, BC000E5_A130SecFunctionalityKey, BC000E5_n130SecFunctionalityKey, BC000E5_A135SecFunctionalityDescription, BC000E5_n135SecFunctionalityDescription, BC000E5_A789SecFunctionalityModule, BC000E5_n789SecFunctionalityModule, BC000E5_A136SecFunctionalityType, BC000E5_n136SecFunctionalityType, BC000E5_A138SecParentFunctionalityDescription,
               BC000E5_n138SecParentFunctionalityDescription, BC000E5_A134SecFunctionalityActive, BC000E5_n134SecFunctionalityActive, BC000E5_A129SecParentFunctionalityId, BC000E5_n129SecParentFunctionalityId
               }
               , new Object[] {
               BC000E6_A130SecFunctionalityKey, BC000E6_n130SecFunctionalityKey
               }
               , new Object[] {
               BC000E7_A128SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A128SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E12_A138SecParentFunctionalityDescription, BC000E12_n138SecParentFunctionalityDescription
               }
               , new Object[] {
               BC000E13_A129SecParentFunctionalityId
               }
               , new Object[] {
               BC000E14_A132SecObjectName, BC000E14_A128SecFunctionalityId
               }
               , new Object[] {
               BC000E15_A128SecFunctionalityId, BC000E15_A131SecRoleId
               }
               , new Object[] {
               BC000E16_A128SecFunctionalityId, BC000E16_A130SecFunctionalityKey, BC000E16_n130SecFunctionalityKey, BC000E16_A135SecFunctionalityDescription, BC000E16_n135SecFunctionalityDescription, BC000E16_A789SecFunctionalityModule, BC000E16_n789SecFunctionalityModule, BC000E16_A136SecFunctionalityType, BC000E16_n136SecFunctionalityType, BC000E16_A138SecParentFunctionalityDescription,
               BC000E16_n138SecParentFunctionalityDescription, BC000E16_A134SecFunctionalityActive, BC000E16_n134SecFunctionalityActive, BC000E16_A129SecParentFunctionalityId, BC000E16_n129SecParentFunctionalityId
               }
            }
         );
         AV19Pgmname = "WWPBaseObjects.SecFunctionality_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z136SecFunctionalityType ;
      private short A136SecFunctionalityType ;
      private short RcdFound17 ;
      private int trnEnded ;
      private int AV20GXV1 ;
      private long Z128SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long AV12Insert_SecParentFunctionalityId ;
      private long Z129SecParentFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode17 ;
      private bool returnInSub ;
      private bool Z134SecFunctionalityActive ;
      private bool A134SecFunctionalityActive ;
      private bool n130SecFunctionalityKey ;
      private bool n135SecFunctionalityDescription ;
      private bool n789SecFunctionalityModule ;
      private bool n136SecFunctionalityType ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n134SecFunctionalityActive ;
      private bool n129SecParentFunctionalityId ;
      private bool Gx_longc ;
      private string Z130SecFunctionalityKey ;
      private string A130SecFunctionalityKey ;
      private string Z135SecFunctionalityDescription ;
      private string A135SecFunctionalityDescription ;
      private string Z789SecFunctionalityModule ;
      private string A789SecFunctionalityModule ;
      private string Z138SecParentFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC000E5_A128SecFunctionalityId ;
      private string[] BC000E5_A130SecFunctionalityKey ;
      private bool[] BC000E5_n130SecFunctionalityKey ;
      private string[] BC000E5_A135SecFunctionalityDescription ;
      private bool[] BC000E5_n135SecFunctionalityDescription ;
      private string[] BC000E5_A789SecFunctionalityModule ;
      private bool[] BC000E5_n789SecFunctionalityModule ;
      private short[] BC000E5_A136SecFunctionalityType ;
      private bool[] BC000E5_n136SecFunctionalityType ;
      private string[] BC000E5_A138SecParentFunctionalityDescription ;
      private bool[] BC000E5_n138SecParentFunctionalityDescription ;
      private bool[] BC000E5_A134SecFunctionalityActive ;
      private bool[] BC000E5_n134SecFunctionalityActive ;
      private long[] BC000E5_A129SecParentFunctionalityId ;
      private bool[] BC000E5_n129SecParentFunctionalityId ;
      private string[] BC000E6_A130SecFunctionalityKey ;
      private bool[] BC000E6_n130SecFunctionalityKey ;
      private string[] BC000E4_A138SecParentFunctionalityDescription ;
      private bool[] BC000E4_n138SecParentFunctionalityDescription ;
      private long[] BC000E7_A128SecFunctionalityId ;
      private long[] BC000E3_A128SecFunctionalityId ;
      private string[] BC000E3_A130SecFunctionalityKey ;
      private bool[] BC000E3_n130SecFunctionalityKey ;
      private string[] BC000E3_A135SecFunctionalityDescription ;
      private bool[] BC000E3_n135SecFunctionalityDescription ;
      private string[] BC000E3_A789SecFunctionalityModule ;
      private bool[] BC000E3_n789SecFunctionalityModule ;
      private short[] BC000E3_A136SecFunctionalityType ;
      private bool[] BC000E3_n136SecFunctionalityType ;
      private bool[] BC000E3_A134SecFunctionalityActive ;
      private bool[] BC000E3_n134SecFunctionalityActive ;
      private long[] BC000E3_A129SecParentFunctionalityId ;
      private bool[] BC000E3_n129SecParentFunctionalityId ;
      private long[] BC000E2_A128SecFunctionalityId ;
      private string[] BC000E2_A130SecFunctionalityKey ;
      private bool[] BC000E2_n130SecFunctionalityKey ;
      private string[] BC000E2_A135SecFunctionalityDescription ;
      private bool[] BC000E2_n135SecFunctionalityDescription ;
      private string[] BC000E2_A789SecFunctionalityModule ;
      private bool[] BC000E2_n789SecFunctionalityModule ;
      private short[] BC000E2_A136SecFunctionalityType ;
      private bool[] BC000E2_n136SecFunctionalityType ;
      private bool[] BC000E2_A134SecFunctionalityActive ;
      private bool[] BC000E2_n134SecFunctionalityActive ;
      private long[] BC000E2_A129SecParentFunctionalityId ;
      private bool[] BC000E2_n129SecParentFunctionalityId ;
      private long[] BC000E9_A128SecFunctionalityId ;
      private string[] BC000E12_A138SecParentFunctionalityDescription ;
      private bool[] BC000E12_n138SecParentFunctionalityDescription ;
      private long[] BC000E13_A129SecParentFunctionalityId ;
      private bool[] BC000E13_n129SecParentFunctionalityId ;
      private string[] BC000E14_A132SecObjectName ;
      private long[] BC000E14_A128SecFunctionalityId ;
      private long[] BC000E15_A128SecFunctionalityId ;
      private short[] BC000E15_A131SecRoleId ;
      private long[] BC000E16_A128SecFunctionalityId ;
      private string[] BC000E16_A130SecFunctionalityKey ;
      private bool[] BC000E16_n130SecFunctionalityKey ;
      private string[] BC000E16_A135SecFunctionalityDescription ;
      private bool[] BC000E16_n135SecFunctionalityDescription ;
      private string[] BC000E16_A789SecFunctionalityModule ;
      private bool[] BC000E16_n789SecFunctionalityModule ;
      private short[] BC000E16_A136SecFunctionalityType ;
      private bool[] BC000E16_n136SecFunctionalityType ;
      private string[] BC000E16_A138SecParentFunctionalityDescription ;
      private bool[] BC000E16_n138SecParentFunctionalityDescription ;
      private bool[] BC000E16_A134SecFunctionalityActive ;
      private bool[] BC000E16_n134SecFunctionalityActive ;
      private long[] BC000E16_A129SecParentFunctionalityId ;
      private bool[] BC000E16_n129SecParentFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality bcwwpbaseobjects_SecFunctionality ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secfunctionality_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000E2;
          prmBC000E2 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E3;
          prmBC000E3 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E4;
          prmBC000E4 = new Object[] {
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC000E5;
          prmBC000E5 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E6;
          prmBC000E6 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E7;
          prmBC000E7 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E8;
          prmBC000E8 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityDescription",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityModule",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityType",GXType.Int16,2,0){Nullable=true} ,
          new ParDef("SecFunctionalityActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC000E9;
          prmBC000E9 = new Object[] {
          };
          Object[] prmBC000E10;
          prmBC000E10 = new Object[] {
          new ParDef("SecFunctionalityKey",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityDescription",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityModule",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityType",GXType.Int16,2,0){Nullable=true} ,
          new ParDef("SecFunctionalityActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E11;
          prmBC000E11 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E12;
          prmBC000E12 = new Object[] {
          new ParDef("SecParentFunctionalityId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC000E13;
          prmBC000E13 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E14;
          prmBC000E14 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E15;
          prmBC000E15 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000E16;
          prmBC000E16 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000E2", "SELECT SecFunctionalityId, SecFunctionalityKey, SecFunctionalityDescription, SecFunctionalityModule, SecFunctionalityType, SecFunctionalityActive, SecParentFunctionalityId FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId  FOR UPDATE OF SecFunctionality",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E3", "SELECT SecFunctionalityId, SecFunctionalityKey, SecFunctionalityDescription, SecFunctionalityModule, SecFunctionalityType, SecFunctionalityActive, SecParentFunctionalityId FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E4", "SELECT SecFunctionalityDescription AS SecParentFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E5", "SELECT TM1.SecFunctionalityId, TM1.SecFunctionalityKey, TM1.SecFunctionalityDescription, TM1.SecFunctionalityModule, TM1.SecFunctionalityType, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, TM1.SecFunctionalityActive, TM1.SecParentFunctionalityId AS SecParentFunctionalityId FROM (SecFunctionality TM1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = TM1.SecParentFunctionalityId) WHERE TM1.SecFunctionalityId = :SecFunctionalityId ORDER BY TM1.SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E6", "SELECT SecFunctionalityKey FROM SecFunctionality WHERE (SecFunctionalityKey = :SecFunctionalityKey) AND (Not ( SecFunctionalityId = :SecFunctionalityId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E7", "SELECT SecFunctionalityId FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E8", "SAVEPOINT gxupdate;INSERT INTO SecFunctionality(SecFunctionalityKey, SecFunctionalityDescription, SecFunctionalityModule, SecFunctionalityType, SecFunctionalityActive, SecParentFunctionalityId) VALUES(:SecFunctionalityKey, :SecFunctionalityDescription, :SecFunctionalityModule, :SecFunctionalityType, :SecFunctionalityActive, :SecParentFunctionalityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000E8)
             ,new CursorDef("BC000E9", "SELECT currval('SecFunctionalityId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E10", "SAVEPOINT gxupdate;UPDATE SecFunctionality SET SecFunctionalityKey=:SecFunctionalityKey, SecFunctionalityDescription=:SecFunctionalityDescription, SecFunctionalityModule=:SecFunctionalityModule, SecFunctionalityType=:SecFunctionalityType, SecFunctionalityActive=:SecFunctionalityActive, SecParentFunctionalityId=:SecParentFunctionalityId  WHERE SecFunctionalityId = :SecFunctionalityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E10)
             ,new CursorDef("BC000E11", "SAVEPOINT gxupdate;DELETE FROM SecFunctionality  WHERE SecFunctionalityId = :SecFunctionalityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E11)
             ,new CursorDef("BC000E12", "SELECT SecFunctionalityDescription AS SecParentFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecParentFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E13", "SELECT SecFunctionalityId AS SecParentFunctionalityId FROM SecFunctionality WHERE SecParentFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000E14", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000E15", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000E16", "SELECT TM1.SecFunctionalityId, TM1.SecFunctionalityKey, TM1.SecFunctionalityDescription, TM1.SecFunctionalityModule, TM1.SecFunctionalityType, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, TM1.SecFunctionalityActive, TM1.SecParentFunctionalityId AS SecParentFunctionalityId FROM (SecFunctionality TM1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = TM1.SecParentFunctionalityId) WHERE TM1.SecFunctionalityId = :SecFunctionalityId ORDER BY TM1.SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E16,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((long[]) buf[13])[0] = rslt.getLong(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((long[]) buf[13])[0] = rslt.getLong(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
