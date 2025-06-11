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
   public class secobject_bc : GxSilentTrn, IGxSilentTrn
   {
      public secobject_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secobject_bc( IGxContext context )
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
         ReadRow0G19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G19( ) ;
         standaloneModal( ) ;
         AddRow0G19( ) ;
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
               Z132SecObjectName = A132SecObjectName;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G19( ) ;
            }
            else
            {
               CheckExtendedTable0G19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0G19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode19 = Gx_mode;
            CONFIRM_0G20( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode19;
            }
            /* Restore parent mode. */
            Gx_mode = sMode19;
         }
      }

      protected void CONFIRM_0G20( )
      {
         nGXsfl_20_idx = 0;
         while ( nGXsfl_20_idx < bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Count )
         {
            ReadRow0G20( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound20 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_20 != 0 ) )
            {
               GetKey0G20( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound20 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0G20( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0G20( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0G20( 3) ;
                        }
                        CloseExtendedTableCursors0G20( ) ;
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
                  if ( RcdFound20 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0G20( ) ;
                        Load0G20( ) ;
                        BeforeValidate0G20( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0G20( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_20 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0G20( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0G20( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0G20( 3) ;
                              }
                              CloseExtendedTableCursors0G20( ) ;
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
               VarsToRow20( ((GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Item(nGXsfl_20_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM0G19( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z132SecObjectName = A132SecObjectName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0G19( )
      {
         /* Using cursor BC000G7 */
         pr_default.execute(5, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound19 = 1;
            ZM0G19( -1) ;
         }
         pr_default.close(5);
         OnLoadActions0G19( ) ;
      }

      protected void OnLoadActions0G19( )
      {
      }

      protected void CheckExtendedTable0G19( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0G19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G19( )
      {
         /* Using cursor BC000G8 */
         pr_default.execute(6, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G6 */
         pr_default.execute(4, new Object[] {A132SecObjectName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0G19( 1) ;
            RcdFound19 = 1;
            A132SecObjectName = BC000G6_A132SecObjectName[0];
            Z132SecObjectName = A132SecObjectName;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0G19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0G19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0G19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G5 */
            pr_default.execute(3, new Object[] {A132SecObjectName});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecObject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecObject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G19( )
      {
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G19( 0) ;
            CheckOptimisticConcurrency0G19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G9 */
                     pr_default.execute(7, new Object[] {A132SecObjectName});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecObject");
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
                           ProcessLevel0G19( ) ;
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
               Load0G19( ) ;
            }
            EndLevel0G19( ) ;
         }
         CloseExtendedTableCursors0G19( ) ;
      }

      protected void Update0G19( )
      {
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table SecObject */
                     DeferredUpdate0G19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0G19( ) ;
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
            EndLevel0G19( ) ;
         }
         CloseExtendedTableCursors0G19( ) ;
      }

      protected void DeferredUpdate0G19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G19( ) ;
            AfterConfirm0G19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G19( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0G20( ) ;
                  while ( RcdFound20 != 0 )
                  {
                     getByPrimaryKey0G20( ) ;
                     Delete0G20( ) ;
                     ScanKeyNext0G20( ) ;
                  }
                  ScanKeyEnd0G20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G10 */
                     pr_default.execute(8, new Object[] {A132SecObjectName});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("SecObject");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0G19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0G20( )
      {
         nGXsfl_20_idx = 0;
         while ( nGXsfl_20_idx < bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Count )
         {
            ReadRow0G20( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound20 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_20 != 0 ) )
            {
               standaloneNotModal0G20( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0G20( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0G20( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0G20( ) ;
                  }
               }
            }
            KeyVarsToRow20( ((GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Item(nGXsfl_20_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_20_idx = 0;
            while ( nGXsfl_20_idx < bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Count )
            {
               ReadRow0G20( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound20 == 0 )
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
                  bcwwpbaseobjects_SecObject.gxTpr_Functionalities.RemoveElement(nGXsfl_20_idx);
                  nGXsfl_20_idx = (int)(nGXsfl_20_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0G20( ) ;
                  VarsToRow20( ((GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Item(nGXsfl_20_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0G20( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_20 = 0;
         nIsMod_20 = 0;
      }

      protected void ProcessLevel0G19( )
      {
         /* Save parent mode. */
         sMode19 = Gx_mode;
         ProcessNestedLevel0G20( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode19;
         /* ' Update level parameters */
      }

      protected void EndLevel0G19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G19( ) ;
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

      public void ScanKeyStart0G19( )
      {
         /* Using cursor BC000G11 */
         pr_default.execute(9, new Object[] {A132SecObjectName});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A132SecObjectName = BC000G11_A132SecObjectName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G19( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound19 = 0;
         ScanKeyLoad0G19( ) ;
      }

      protected void ScanKeyLoad0G19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A132SecObjectName = BC000G11_A132SecObjectName[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0G19( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0G19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G19( )
      {
      }

      protected void ZM0G20( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
         }
         if ( GX_JID == -2 )
         {
            Z132SecObjectName = A132SecObjectName;
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
         }
      }

      protected void standaloneNotModal0G20( )
      {
      }

      protected void standaloneModal0G20( )
      {
      }

      protected void Load0G20( )
      {
         /* Using cursor BC000G12 */
         pr_default.execute(10, new Object[] {A132SecObjectName, A128SecFunctionalityId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A135SecFunctionalityDescription = BC000G12_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000G12_n135SecFunctionalityDescription[0];
            ZM0G20( -2) ;
         }
         pr_default.close(10);
         OnLoadActions0G20( ) ;
      }

      protected void OnLoadActions0G20( )
      {
      }

      protected void CheckExtendedTable0G20( )
      {
         Gx_BScreen = 1;
         standaloneModal0G20( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
         }
         A135SecFunctionalityDescription = BC000G4_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = BC000G4_n135SecFunctionalityDescription[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0G20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0G20( )
      {
      }

      protected void GetKey0G20( )
      {
         /* Using cursor BC000G13 */
         pr_default.execute(11, new Object[] {A132SecObjectName, A128SecFunctionalityId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey0G20( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {A132SecObjectName, A128SecFunctionalityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G20( 2) ;
            RcdFound20 = 1;
            InitializeNonKey0G20( ) ;
            A128SecFunctionalityId = BC000G3_A128SecFunctionalityId[0];
            Z132SecObjectName = A132SecObjectName;
            Z128SecFunctionalityId = A128SecFunctionalityId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0G20( ) ;
            Load0G20( ) ;
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0G20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0G20( ) ;
            Gx_mode = sMode20;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0G20( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0G20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {A132SecObjectName, A128SecFunctionalityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecObjectFunctionalities"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecObjectFunctionalities"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G20( )
      {
         BeforeValidate0G20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G20( 0) ;
            CheckOptimisticConcurrency0G20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G14 */
                     pr_default.execute(12, new Object[] {A132SecObjectName, A128SecFunctionalityId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
                     if ( (pr_default.getStatus(12) == 1) )
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
               Load0G20( ) ;
            }
            EndLevel0G20( ) ;
         }
         CloseExtendedTableCursors0G20( ) ;
      }

      protected void Update0G20( )
      {
         BeforeValidate0G20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table SecObjectFunctionalities */
                     DeferredUpdate0G20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0G20( ) ;
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
            EndLevel0G20( ) ;
         }
         CloseExtendedTableCursors0G20( ) ;
      }

      protected void DeferredUpdate0G20( )
      {
      }

      protected void Delete0G20( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G20( ) ;
            AfterConfirm0G20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G15 */
                  pr_default.execute(13, new Object[] {A132SecObjectName, A128SecFunctionalityId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0G20( )
      {
         standaloneModal0G20( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000G16 */
            pr_default.execute(14, new Object[] {A128SecFunctionalityId});
            A135SecFunctionalityDescription = BC000G16_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000G16_n135SecFunctionalityDescription[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel0G20( )
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

      public void ScanKeyStart0G20( )
      {
         /* Scan By routine */
         /* Using cursor BC000G17 */
         pr_default.execute(15, new Object[] {A132SecObjectName});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound20 = 1;
            A135SecFunctionalityDescription = BC000G17_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000G17_n135SecFunctionalityDescription[0];
            A128SecFunctionalityId = BC000G17_A128SecFunctionalityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G20( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound20 = 0;
         ScanKeyLoad0G20( ) ;
      }

      protected void ScanKeyLoad0G20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound20 = 1;
            A135SecFunctionalityDescription = BC000G17_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000G17_n135SecFunctionalityDescription[0];
            A128SecFunctionalityId = BC000G17_A128SecFunctionalityId[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0G20( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0G20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G20( )
      {
      }

      protected void send_integrity_lvl_hashes0G20( )
      {
      }

      protected void send_integrity_lvl_hashes0G19( )
      {
      }

      protected void AddRow0G19( )
      {
         VarsToRow19( bcwwpbaseobjects_SecObject) ;
      }

      protected void ReadRow0G19( )
      {
         RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
      }

      protected void AddRow0G20( )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities obj20;
         obj20 = new GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities(context);
         VarsToRow20( obj20) ;
         bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Add(obj20, 0);
         obj20.gxTpr_Mode = "UPD";
         obj20.gxTpr_Modified = 0;
      }

      protected void ReadRow0G20( )
      {
         nGXsfl_20_idx = (int)(nGXsfl_20_idx+1);
         RowToVars20( ((GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)bcwwpbaseobjects_SecObject.gxTpr_Functionalities.Item(nGXsfl_20_idx)), 1) ;
      }

      protected void InitializeNonKey0G19( )
      {
      }

      protected void InitAll0G19( )
      {
         A132SecObjectName = "";
         InitializeNonKey0G19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0G20( )
      {
         A135SecFunctionalityDescription = "";
         n135SecFunctionalityDescription = false;
      }

      protected void InitAll0G20( )
      {
         A128SecFunctionalityId = 0;
         InitializeNonKey0G20( ) ;
      }

      protected void StandaloneModalInsert0G20( )
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

      public void VarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtSecObject obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Secobjectname = A132SecObjectName;
         obj19.gxTpr_Secobjectname_Z = Z132SecObjectName;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtSecObject obj19 )
      {
         obj19.gxTpr_Secobjectname = A132SecObjectName;
         return  ;
      }

      public void RowToVars19( GeneXus.Programs.wwpbaseobjects.SdtSecObject obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A132SecObjectName = obj19.gxTpr_Secobjectname;
         Z132SecObjectName = obj19.gxTpr_Secobjectname_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow20( GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Secfunctionalitydescription = A135SecFunctionalityDescription;
         obj20.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
         obj20.gxTpr_Secfunctionalityid_Z = Z128SecFunctionalityId;
         obj20.gxTpr_Secfunctionalitydescription_Z = Z135SecFunctionalityDescription;
         obj20.gxTpr_Secfunctionalitydescription_N = (short)(Convert.ToInt16(n135SecFunctionalityDescription));
         obj20.gxTpr_Modified = nIsMod_20;
         return  ;
      }

      public void KeyVarsToRow20( GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities obj20 )
      {
         obj20.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
         return  ;
      }

      public void RowToVars20( GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A135SecFunctionalityDescription = obj20.gxTpr_Secfunctionalitydescription;
         n135SecFunctionalityDescription = false;
         A128SecFunctionalityId = obj20.gxTpr_Secfunctionalityid;
         Z128SecFunctionalityId = obj20.gxTpr_Secfunctionalityid_Z;
         Z135SecFunctionalityDescription = obj20.gxTpr_Secfunctionalitydescription_Z;
         n135SecFunctionalityDescription = (bool)(Convert.ToBoolean(obj20.gxTpr_Secfunctionalitydescription_N));
         nIsMod_20 = obj20.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A132SecObjectName = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G19( ) ;
         ScanKeyStart0G19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z132SecObjectName = A132SecObjectName;
         }
         ZM0G19( -1) ;
         OnLoadActions0G19( ) ;
         AddRow0G19( ) ;
         bcwwpbaseobjects_SecObject.gxTpr_Functionalities.ClearCollection();
         if ( RcdFound19 == 1 )
         {
            ScanKeyStart0G20( ) ;
            nGXsfl_20_idx = 1;
            while ( RcdFound20 != 0 )
            {
               Z132SecObjectName = A132SecObjectName;
               Z128SecFunctionalityId = A128SecFunctionalityId;
               ZM0G20( -2) ;
               OnLoadActions0G20( ) ;
               nRcdExists_20 = 1;
               nIsMod_20 = 0;
               AddRow0G20( ) ;
               nGXsfl_20_idx = (int)(nGXsfl_20_idx+1);
               ScanKeyNext0G20( ) ;
            }
            ScanKeyEnd0G20( ) ;
         }
         ScanKeyEnd0G19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcwwpbaseobjects_SecObject, 0) ;
         ScanKeyStart0G19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z132SecObjectName = A132SecObjectName;
         }
         ZM0G19( -1) ;
         OnLoadActions0G19( ) ;
         AddRow0G19( ) ;
         bcwwpbaseobjects_SecObject.gxTpr_Functionalities.ClearCollection();
         if ( RcdFound19 == 1 )
         {
            ScanKeyStart0G20( ) ;
            nGXsfl_20_idx = 1;
            while ( RcdFound20 != 0 )
            {
               Z132SecObjectName = A132SecObjectName;
               Z128SecFunctionalityId = A128SecFunctionalityId;
               ZM0G20( -2) ;
               OnLoadActions0G20( ) ;
               nRcdExists_20 = 1;
               nIsMod_20 = 0;
               AddRow0G20( ) ;
               nGXsfl_20_idx = (int)(nGXsfl_20_idx+1);
               ScanKeyNext0G20( ) ;
            }
            ScanKeyEnd0G20( ) ;
         }
         ScanKeyEnd0G19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0G19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
               {
                  A132SecObjectName = Z132SecObjectName;
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
                  Update0G19( ) ;
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
                  if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
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
                        Insert0G19( ) ;
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
                        Insert0G19( ) ;
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
         RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcwwpbaseobjects_SecObject) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcwwpbaseobjects_SecObject) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcwwpbaseobjects_SecObject) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecObject auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecObject(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A132SecObjectName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecObject);
               auxBC.Save();
               bcwwpbaseobjects_SecObject.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
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
         RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G19( ) ;
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
               VarsToRow19( bcwwpbaseobjects_SecObject) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcwwpbaseobjects_SecObject) ;
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
         RowToVars19( bcwwpbaseobjects_SecObject, 0) ;
         GetKey0G19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
            {
               A132SecObjectName = Z132SecObjectName;
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
            if ( StringUtil.StrCmp(A132SecObjectName, Z132SecObjectName) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.secobject_bc",pr_default);
         VarsToRow19( bcwwpbaseobjects_SecObject) ;
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
         Gx_mode = bcwwpbaseobjects_SecObject.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecObject.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecObject )
         {
            bcwwpbaseobjects_SecObject = (GeneXus.Programs.wwpbaseobjects.SdtSecObject)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecObject.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecObject.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcwwpbaseobjects_SecObject) ;
            }
            else
            {
               RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecObject.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecObject.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcwwpbaseobjects_SecObject, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecObject SecObject_BC
      {
         get {
            return bcwwpbaseobjects_SecObject ;
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
         pr_default.close(14);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z132SecObjectName = "";
         A132SecObjectName = "";
         sMode19 = "";
         BC000G7_A132SecObjectName = new string[] {""} ;
         BC000G8_A132SecObjectName = new string[] {""} ;
         BC000G6_A132SecObjectName = new string[] {""} ;
         BC000G5_A132SecObjectName = new string[] {""} ;
         BC000G11_A132SecObjectName = new string[] {""} ;
         Z135SecFunctionalityDescription = "";
         A135SecFunctionalityDescription = "";
         BC000G12_A132SecObjectName = new string[] {""} ;
         BC000G12_A135SecFunctionalityDescription = new string[] {""} ;
         BC000G12_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000G12_A128SecFunctionalityId = new long[1] ;
         BC000G4_A135SecFunctionalityDescription = new string[] {""} ;
         BC000G4_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000G13_A132SecObjectName = new string[] {""} ;
         BC000G13_A128SecFunctionalityId = new long[1] ;
         BC000G3_A132SecObjectName = new string[] {""} ;
         BC000G3_A128SecFunctionalityId = new long[1] ;
         sMode20 = "";
         BC000G2_A132SecObjectName = new string[] {""} ;
         BC000G2_A128SecFunctionalityId = new long[1] ;
         BC000G16_A135SecFunctionalityDescription = new string[] {""} ;
         BC000G16_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000G17_A132SecObjectName = new string[] {""} ;
         BC000G17_A135SecFunctionalityDescription = new string[] {""} ;
         BC000G17_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000G17_A128SecFunctionalityId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secobject_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A132SecObjectName, BC000G2_A128SecFunctionalityId
               }
               , new Object[] {
               BC000G3_A132SecObjectName, BC000G3_A128SecFunctionalityId
               }
               , new Object[] {
               BC000G4_A135SecFunctionalityDescription, BC000G4_n135SecFunctionalityDescription
               }
               , new Object[] {
               BC000G5_A132SecObjectName
               }
               , new Object[] {
               BC000G6_A132SecObjectName
               }
               , new Object[] {
               BC000G7_A132SecObjectName
               }
               , new Object[] {
               BC000G8_A132SecObjectName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G11_A132SecObjectName
               }
               , new Object[] {
               BC000G12_A132SecObjectName, BC000G12_A135SecFunctionalityDescription, BC000G12_n135SecFunctionalityDescription, BC000G12_A128SecFunctionalityId
               }
               , new Object[] {
               BC000G13_A132SecObjectName, BC000G13_A128SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G16_A135SecFunctionalityDescription, BC000G16_n135SecFunctionalityDescription
               }
               , new Object[] {
               BC000G17_A132SecObjectName, BC000G17_A135SecFunctionalityDescription, BC000G17_n135SecFunctionalityDescription, BC000G17_A128SecFunctionalityId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_20 ;
      private short RcdFound20 ;
      private short RcdFound19 ;
      private short nRcdExists_20 ;
      private short Gx_BScreen ;
      private short Gxremove20 ;
      private int trnEnded ;
      private int nGXsfl_20_idx=1 ;
      private long Z128SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode19 ;
      private string sMode20 ;
      private bool n135SecFunctionalityDescription ;
      private string Z132SecObjectName ;
      private string A132SecObjectName ;
      private string Z135SecFunctionalityDescription ;
      private string A135SecFunctionalityDescription ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecObject bcwwpbaseobjects_SecObject ;
      private IDataStoreProvider pr_default ;
      private string[] BC000G7_A132SecObjectName ;
      private string[] BC000G8_A132SecObjectName ;
      private string[] BC000G6_A132SecObjectName ;
      private string[] BC000G5_A132SecObjectName ;
      private string[] BC000G11_A132SecObjectName ;
      private string[] BC000G12_A132SecObjectName ;
      private string[] BC000G12_A135SecFunctionalityDescription ;
      private bool[] BC000G12_n135SecFunctionalityDescription ;
      private long[] BC000G12_A128SecFunctionalityId ;
      private string[] BC000G4_A135SecFunctionalityDescription ;
      private bool[] BC000G4_n135SecFunctionalityDescription ;
      private string[] BC000G13_A132SecObjectName ;
      private long[] BC000G13_A128SecFunctionalityId ;
      private string[] BC000G3_A132SecObjectName ;
      private long[] BC000G3_A128SecFunctionalityId ;
      private string[] BC000G2_A132SecObjectName ;
      private long[] BC000G2_A128SecFunctionalityId ;
      private string[] BC000G16_A135SecFunctionalityDescription ;
      private bool[] BC000G16_n135SecFunctionalityDescription ;
      private string[] BC000G17_A132SecObjectName ;
      private string[] BC000G17_A135SecFunctionalityDescription ;
      private bool[] BC000G17_n135SecFunctionalityDescription ;
      private long[] BC000G17_A128SecFunctionalityId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secobject_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000G2;
          prmBC000G2 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G3;
          prmBC000G3 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G4;
          prmBC000G4 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G5;
          prmBC000G5 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G6;
          prmBC000G6 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G7;
          prmBC000G7 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G8;
          prmBC000G8 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G9;
          prmBC000G9 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G10;
          prmBC000G10 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G11;
          prmBC000G11 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          Object[] prmBC000G12;
          prmBC000G12 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G13;
          prmBC000G13 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G14;
          prmBC000G14 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G15;
          prmBC000G15 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G16;
          prmBC000G16 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000G17;
          prmBC000G17 = new Object[] {
          new ParDef("SecObjectName",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000G2", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId  FOR UPDATE OF SecObjectFunctionalities",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G3", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G4", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G5", "SELECT SecObjectName FROM SecObject WHERE SecObjectName = :SecObjectName  FOR UPDATE OF SecObject",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G6", "SELECT SecObjectName FROM SecObject WHERE SecObjectName = :SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G7", "SELECT TM1.SecObjectName FROM SecObject TM1 WHERE TM1.SecObjectName = ( :SecObjectName) ORDER BY TM1.SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G8", "SELECT SecObjectName FROM SecObject WHERE SecObjectName = :SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G9", "SAVEPOINT gxupdate;INSERT INTO SecObject(SecObjectName) VALUES(:SecObjectName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000G9)
             ,new CursorDef("BC000G10", "SAVEPOINT gxupdate;DELETE FROM SecObject  WHERE SecObjectName = :SecObjectName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G10)
             ,new CursorDef("BC000G11", "SELECT TM1.SecObjectName FROM SecObject TM1 WHERE TM1.SecObjectName = ( :SecObjectName) ORDER BY TM1.SecObjectName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G12", "SELECT T1.SecObjectName, T2.SecFunctionalityDescription, T1.SecFunctionalityId FROM (SecObjectFunctionalities T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) WHERE T1.SecObjectName = ( :SecObjectName) and T1.SecFunctionalityId = :SecFunctionalityId ORDER BY T1.SecObjectName, T1.SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G12,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G13", "SELECT SecObjectName, SecFunctionalityId FROM SecObjectFunctionalities WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G14", "SAVEPOINT gxupdate;INSERT INTO SecObjectFunctionalities(SecObjectName, SecFunctionalityId) VALUES(:SecObjectName, :SecFunctionalityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000G14)
             ,new CursorDef("BC000G15", "SAVEPOINT gxupdate;DELETE FROM SecObjectFunctionalities  WHERE SecObjectName = :SecObjectName AND SecFunctionalityId = :SecFunctionalityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G15)
             ,new CursorDef("BC000G16", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G17", "SELECT T1.SecObjectName, T2.SecFunctionalityDescription, T1.SecFunctionalityId FROM (SecObjectFunctionalities T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) WHERE T1.SecObjectName = ( :SecObjectName) ORDER BY T1.SecObjectName, T1.SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G17,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
