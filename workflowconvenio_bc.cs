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
   public class workflowconvenio_bc : GxSilentTrn, IGxSilentTrn
   {
      public workflowconvenio_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workflowconvenio_bc( IGxContext context )
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
         ReadRow2M91( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2M91( ) ;
         standaloneModal( ) ;
         AddRow2M91( ) ;
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
            E112M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z742WorkflowConvenioId = A742WorkflowConvenioId;
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

      protected void CONFIRM_2M0( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2M91( ) ;
            }
            else
            {
               CheckExtendedTable2M91( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2M91( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E112M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2M91( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z743WorkflowConvenioCreatedAt = A743WorkflowConvenioCreatedAt;
            Z737WorkflowConvenioStatus = A737WorkflowConvenioStatus;
            Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
            Z753WorkflowConvenioSLA = A753WorkflowConvenioSLA;
         }
         if ( GX_JID == -6 )
         {
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            Z743WorkflowConvenioCreatedAt = A743WorkflowConvenioCreatedAt;
            Z737WorkflowConvenioStatus = A737WorkflowConvenioStatus;
            Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
            Z753WorkflowConvenioSLA = A753WorkflowConvenioSLA;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A737WorkflowConvenioStatus = true;
            n737WorkflowConvenioStatus = false;
         }
         if ( IsIns( )  )
         {
            A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n743WorkflowConvenioCreatedAt = false;
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A743WorkflowConvenioCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n743WorkflowConvenioCreatedAt = false;
            }
         }
      }

      protected void Load2M91( )
      {
         /* Using cursor BC002M4 */
         pr_default.execute(2, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound91 = 1;
            A743WorkflowConvenioCreatedAt = BC002M4_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = BC002M4_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = BC002M4_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = BC002M4_n737WorkflowConvenioStatus[0];
            A736WorkflowConvenioDesc = BC002M4_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC002M4_n736WorkflowConvenioDesc[0];
            A753WorkflowConvenioSLA = BC002M4_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = BC002M4_n753WorkflowConvenioSLA[0];
            ZM2M91( -6) ;
         }
         pr_default.close(2);
         OnLoadActions2M91( ) ;
      }

      protected void OnLoadActions2M91( )
      {
      }

      protected void CheckExtendedTable2M91( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Passo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( A753WorkflowConvenioSLA < 0 )
         {
            GX_msglist.addItem("SLA não pode ser menor que 0", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2M91( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2M91( )
      {
         /* Using cursor BC002M5 */
         pr_default.execute(3, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound91 = 1;
         }
         else
         {
            RcdFound91 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002M3 */
         pr_default.execute(1, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2M91( 6) ;
            RcdFound91 = 1;
            A742WorkflowConvenioId = BC002M3_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC002M3_n742WorkflowConvenioId[0];
            A743WorkflowConvenioCreatedAt = BC002M3_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = BC002M3_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = BC002M3_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = BC002M3_n737WorkflowConvenioStatus[0];
            A736WorkflowConvenioDesc = BC002M3_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC002M3_n736WorkflowConvenioDesc[0];
            A753WorkflowConvenioSLA = BC002M3_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = BC002M3_n753WorkflowConvenioSLA[0];
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            sMode91 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2M91( ) ;
            if ( AnyError == 1 )
            {
               RcdFound91 = 0;
               InitializeNonKey2M91( ) ;
            }
            Gx_mode = sMode91;
         }
         else
         {
            RcdFound91 = 0;
            InitializeNonKey2M91( ) ;
            sMode91 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode91;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2M91( ) ;
         if ( RcdFound91 == 0 )
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
         CONFIRM_2M0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2M91( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002M2 */
            pr_default.execute(0, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkflowConvenio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z743WorkflowConvenioCreatedAt != BC002M2_A743WorkflowConvenioCreatedAt[0] ) || ( Z737WorkflowConvenioStatus != BC002M2_A737WorkflowConvenioStatus[0] ) || ( StringUtil.StrCmp(Z736WorkflowConvenioDesc, BC002M2_A736WorkflowConvenioDesc[0]) != 0 ) || ( Z753WorkflowConvenioSLA != BC002M2_A753WorkflowConvenioSLA[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WorkflowConvenio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2M91( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2M91( 0) ;
            CheckOptimisticConcurrency2M91( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2M91( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2M91( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002M6 */
                     pr_default.execute(4, new Object[] {n743WorkflowConvenioCreatedAt, A743WorkflowConvenioCreatedAt, n737WorkflowConvenioStatus, A737WorkflowConvenioStatus, n736WorkflowConvenioDesc, A736WorkflowConvenioDesc, n753WorkflowConvenioSLA, A753WorkflowConvenioSLA});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002M7 */
                     pr_default.execute(5);
                     A742WorkflowConvenioId = BC002M7_A742WorkflowConvenioId[0];
                     n742WorkflowConvenioId = BC002M7_n742WorkflowConvenioId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WorkflowConvenio");
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
               Load2M91( ) ;
            }
            EndLevel2M91( ) ;
         }
         CloseExtendedTableCursors2M91( ) ;
      }

      protected void Update2M91( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2M91( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2M91( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2M91( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002M8 */
                     pr_default.execute(6, new Object[] {n743WorkflowConvenioCreatedAt, A743WorkflowConvenioCreatedAt, n737WorkflowConvenioStatus, A737WorkflowConvenioStatus, n736WorkflowConvenioDesc, A736WorkflowConvenioDesc, n753WorkflowConvenioSLA, A753WorkflowConvenioSLA, n742WorkflowConvenioId, A742WorkflowConvenioId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WorkflowConvenio");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkflowConvenio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2M91( ) ;
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
            EndLevel2M91( ) ;
         }
         CloseExtendedTableCursors2M91( ) ;
      }

      protected void DeferredUpdate2M91( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2M91( ) ;
            AfterConfirm2M91( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2M91( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002M9 */
                  pr_default.execute(7, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WorkflowConvenio");
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
         sMode91 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2M91( ) ;
         Gx_mode = sMode91;
      }

      protected void OnDeleteControls2M91( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC002M10 */
            pr_default.execute(8, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC002M11 */
            pr_default.execute(9, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel2M91( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2M91( ) ;
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

      public void ScanKeyStart2M91( )
      {
         /* Scan By routine */
         /* Using cursor BC002M12 */
         pr_default.execute(10, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         RcdFound91 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound91 = 1;
            A742WorkflowConvenioId = BC002M12_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC002M12_n742WorkflowConvenioId[0];
            A743WorkflowConvenioCreatedAt = BC002M12_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = BC002M12_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = BC002M12_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = BC002M12_n737WorkflowConvenioStatus[0];
            A736WorkflowConvenioDesc = BC002M12_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC002M12_n736WorkflowConvenioDesc[0];
            A753WorkflowConvenioSLA = BC002M12_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = BC002M12_n753WorkflowConvenioSLA[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2M91( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound91 = 0;
         ScanKeyLoad2M91( ) ;
      }

      protected void ScanKeyLoad2M91( )
      {
         sMode91 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound91 = 1;
            A742WorkflowConvenioId = BC002M12_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC002M12_n742WorkflowConvenioId[0];
            A743WorkflowConvenioCreatedAt = BC002M12_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = BC002M12_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = BC002M12_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = BC002M12_n737WorkflowConvenioStatus[0];
            A736WorkflowConvenioDesc = BC002M12_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC002M12_n736WorkflowConvenioDesc[0];
            A753WorkflowConvenioSLA = BC002M12_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = BC002M12_n753WorkflowConvenioSLA[0];
         }
         Gx_mode = sMode91;
      }

      protected void ScanKeyEnd2M91( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2M91( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2M91( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2M91( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2M91( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2M91( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2M91( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2M91( )
      {
      }

      protected void send_integrity_lvl_hashes2M91( )
      {
      }

      protected void AddRow2M91( )
      {
         VarsToRow91( bcWorkflowConvenio) ;
      }

      protected void ReadRow2M91( )
      {
         RowToVars91( bcWorkflowConvenio, 1) ;
      }

      protected void InitializeNonKey2M91( )
      {
         A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         A737WorkflowConvenioStatus = false;
         n737WorkflowConvenioStatus = false;
         A736WorkflowConvenioDesc = "";
         n736WorkflowConvenioDesc = false;
         A753WorkflowConvenioSLA = 0;
         n753WorkflowConvenioSLA = false;
         Z743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         Z737WorkflowConvenioStatus = false;
         Z736WorkflowConvenioDesc = "";
         Z753WorkflowConvenioSLA = 0;
      }

      protected void InitAll2M91( )
      {
         A742WorkflowConvenioId = 0;
         n742WorkflowConvenioId = false;
         InitializeNonKey2M91( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A737WorkflowConvenioStatus = i737WorkflowConvenioStatus;
         n737WorkflowConvenioStatus = false;
         A743WorkflowConvenioCreatedAt = i743WorkflowConvenioCreatedAt;
         n743WorkflowConvenioCreatedAt = false;
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

      public void VarsToRow91( SdtWorkflowConvenio obj91 )
      {
         obj91.gxTpr_Mode = Gx_mode;
         obj91.gxTpr_Workflowconveniocreatedat = A743WorkflowConvenioCreatedAt;
         obj91.gxTpr_Workflowconveniostatus = A737WorkflowConvenioStatus;
         obj91.gxTpr_Workflowconveniodesc = A736WorkflowConvenioDesc;
         obj91.gxTpr_Workflowconveniosla = A753WorkflowConvenioSLA;
         obj91.gxTpr_Workflowconvenioid = A742WorkflowConvenioId;
         obj91.gxTpr_Workflowconvenioid_Z = Z742WorkflowConvenioId;
         obj91.gxTpr_Workflowconveniodesc_Z = Z736WorkflowConvenioDesc;
         obj91.gxTpr_Workflowconveniostatus_Z = Z737WorkflowConvenioStatus;
         obj91.gxTpr_Workflowconveniocreatedat_Z = Z743WorkflowConvenioCreatedAt;
         obj91.gxTpr_Workflowconveniosla_Z = Z753WorkflowConvenioSLA;
         obj91.gxTpr_Workflowconvenioid_N = (short)(Convert.ToInt16(n742WorkflowConvenioId));
         obj91.gxTpr_Workflowconveniodesc_N = (short)(Convert.ToInt16(n736WorkflowConvenioDesc));
         obj91.gxTpr_Workflowconveniostatus_N = (short)(Convert.ToInt16(n737WorkflowConvenioStatus));
         obj91.gxTpr_Workflowconveniocreatedat_N = (short)(Convert.ToInt16(n743WorkflowConvenioCreatedAt));
         obj91.gxTpr_Workflowconveniosla_N = (short)(Convert.ToInt16(n753WorkflowConvenioSLA));
         obj91.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow91( SdtWorkflowConvenio obj91 )
      {
         obj91.gxTpr_Workflowconvenioid = A742WorkflowConvenioId;
         return  ;
      }

      public void RowToVars91( SdtWorkflowConvenio obj91 ,
                               int forceLoad )
      {
         Gx_mode = obj91.gxTpr_Mode;
         A743WorkflowConvenioCreatedAt = obj91.gxTpr_Workflowconveniocreatedat;
         n743WorkflowConvenioCreatedAt = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A737WorkflowConvenioStatus = obj91.gxTpr_Workflowconveniostatus;
            n737WorkflowConvenioStatus = false;
         }
         A736WorkflowConvenioDesc = obj91.gxTpr_Workflowconveniodesc;
         n736WorkflowConvenioDesc = false;
         A753WorkflowConvenioSLA = obj91.gxTpr_Workflowconveniosla;
         n753WorkflowConvenioSLA = false;
         A742WorkflowConvenioId = obj91.gxTpr_Workflowconvenioid;
         n742WorkflowConvenioId = false;
         Z742WorkflowConvenioId = obj91.gxTpr_Workflowconvenioid_Z;
         Z736WorkflowConvenioDesc = obj91.gxTpr_Workflowconveniodesc_Z;
         Z737WorkflowConvenioStatus = obj91.gxTpr_Workflowconveniostatus_Z;
         Z743WorkflowConvenioCreatedAt = obj91.gxTpr_Workflowconveniocreatedat_Z;
         Z753WorkflowConvenioSLA = obj91.gxTpr_Workflowconveniosla_Z;
         n742WorkflowConvenioId = (bool)(Convert.ToBoolean(obj91.gxTpr_Workflowconvenioid_N));
         n736WorkflowConvenioDesc = (bool)(Convert.ToBoolean(obj91.gxTpr_Workflowconveniodesc_N));
         n737WorkflowConvenioStatus = (bool)(Convert.ToBoolean(obj91.gxTpr_Workflowconveniostatus_N));
         n743WorkflowConvenioCreatedAt = (bool)(Convert.ToBoolean(obj91.gxTpr_Workflowconveniocreatedat_N));
         n753WorkflowConvenioSLA = (bool)(Convert.ToBoolean(obj91.gxTpr_Workflowconveniosla_N));
         Gx_mode = obj91.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A742WorkflowConvenioId = (int)getParm(obj,0);
         n742WorkflowConvenioId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2M91( ) ;
         ScanKeyStart2M91( ) ;
         if ( RcdFound91 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
         }
         ZM2M91( -6) ;
         OnLoadActions2M91( ) ;
         AddRow2M91( ) ;
         ScanKeyEnd2M91( ) ;
         if ( RcdFound91 == 0 )
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
         RowToVars91( bcWorkflowConvenio, 0) ;
         ScanKeyStart2M91( ) ;
         if ( RcdFound91 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
         }
         ZM2M91( -6) ;
         OnLoadActions2M91( ) ;
         AddRow2M91( ) ;
         ScanKeyEnd2M91( ) ;
         if ( RcdFound91 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2M91( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2M91( ) ;
         }
         else
         {
            if ( RcdFound91 == 1 )
            {
               if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
               {
                  A742WorkflowConvenioId = Z742WorkflowConvenioId;
                  n742WorkflowConvenioId = false;
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
                  Update2M91( ) ;
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
                  if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
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
                        Insert2M91( ) ;
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
                        Insert2M91( ) ;
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
         RowToVars91( bcWorkflowConvenio, 1) ;
         SaveImpl( ) ;
         VarsToRow91( bcWorkflowConvenio) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars91( bcWorkflowConvenio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2M91( ) ;
         AfterTrn( ) ;
         VarsToRow91( bcWorkflowConvenio) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow91( bcWorkflowConvenio) ;
         }
         else
         {
            SdtWorkflowConvenio auxBC = new SdtWorkflowConvenio(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A742WorkflowConvenioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcWorkflowConvenio);
               auxBC.Save();
               bcWorkflowConvenio.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars91( bcWorkflowConvenio, 1) ;
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
         RowToVars91( bcWorkflowConvenio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2M91( ) ;
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
               VarsToRow91( bcWorkflowConvenio) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow91( bcWorkflowConvenio) ;
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
         RowToVars91( bcWorkflowConvenio, 0) ;
         GetKey2M91( ) ;
         if ( RcdFound91 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
            {
               A742WorkflowConvenioId = Z742WorkflowConvenioId;
               n742WorkflowConvenioId = false;
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
            if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
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
         context.RollbackDataStores("workflowconvenio_bc",pr_default);
         VarsToRow91( bcWorkflowConvenio) ;
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
         Gx_mode = bcWorkflowConvenio.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcWorkflowConvenio.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcWorkflowConvenio )
         {
            bcWorkflowConvenio = (SdtWorkflowConvenio)(sdt);
            if ( StringUtil.StrCmp(bcWorkflowConvenio.gxTpr_Mode, "") == 0 )
            {
               bcWorkflowConvenio.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow91( bcWorkflowConvenio) ;
            }
            else
            {
               RowToVars91( bcWorkflowConvenio, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcWorkflowConvenio.gxTpr_Mode, "") == 0 )
            {
               bcWorkflowConvenio.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars91( bcWorkflowConvenio, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWorkflowConvenio WorkflowConvenio_BC
      {
         get {
            return bcWorkflowConvenio ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         Z736WorkflowConvenioDesc = "";
         A736WorkflowConvenioDesc = "";
         BC002M4_A742WorkflowConvenioId = new int[1] ;
         BC002M4_n742WorkflowConvenioId = new bool[] {false} ;
         BC002M4_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002M4_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         BC002M4_A737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M4_n737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M4_A736WorkflowConvenioDesc = new string[] {""} ;
         BC002M4_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC002M4_A753WorkflowConvenioSLA = new short[1] ;
         BC002M4_n753WorkflowConvenioSLA = new bool[] {false} ;
         BC002M5_A742WorkflowConvenioId = new int[1] ;
         BC002M5_n742WorkflowConvenioId = new bool[] {false} ;
         BC002M3_A742WorkflowConvenioId = new int[1] ;
         BC002M3_n742WorkflowConvenioId = new bool[] {false} ;
         BC002M3_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002M3_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         BC002M3_A737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M3_n737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M3_A736WorkflowConvenioDesc = new string[] {""} ;
         BC002M3_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC002M3_A753WorkflowConvenioSLA = new short[1] ;
         BC002M3_n753WorkflowConvenioSLA = new bool[] {false} ;
         sMode91 = "";
         BC002M2_A742WorkflowConvenioId = new int[1] ;
         BC002M2_n742WorkflowConvenioId = new bool[] {false} ;
         BC002M2_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002M2_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         BC002M2_A737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M2_n737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M2_A736WorkflowConvenioDesc = new string[] {""} ;
         BC002M2_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC002M2_A753WorkflowConvenioSLA = new short[1] ;
         BC002M2_n753WorkflowConvenioSLA = new bool[] {false} ;
         BC002M7_A742WorkflowConvenioId = new int[1] ;
         BC002M7_n742WorkflowConvenioId = new bool[] {false} ;
         BC002M10_A746ReembolsoFlowLogId = new int[1] ;
         BC002M11_A518ReembolsoId = new int[1] ;
         BC002M12_A742WorkflowConvenioId = new int[1] ;
         BC002M12_n742WorkflowConvenioId = new bool[] {false} ;
         BC002M12_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002M12_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         BC002M12_A737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M12_n737WorkflowConvenioStatus = new bool[] {false} ;
         BC002M12_A736WorkflowConvenioDesc = new string[] {""} ;
         BC002M12_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC002M12_A753WorkflowConvenioSLA = new short[1] ;
         BC002M12_n753WorkflowConvenioSLA = new bool[] {false} ;
         i743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workflowconvenio_bc__default(),
            new Object[][] {
                new Object[] {
               BC002M2_A742WorkflowConvenioId, BC002M2_A743WorkflowConvenioCreatedAt, BC002M2_n743WorkflowConvenioCreatedAt, BC002M2_A737WorkflowConvenioStatus, BC002M2_n737WorkflowConvenioStatus, BC002M2_A736WorkflowConvenioDesc, BC002M2_n736WorkflowConvenioDesc, BC002M2_A753WorkflowConvenioSLA, BC002M2_n753WorkflowConvenioSLA
               }
               , new Object[] {
               BC002M3_A742WorkflowConvenioId, BC002M3_A743WorkflowConvenioCreatedAt, BC002M3_n743WorkflowConvenioCreatedAt, BC002M3_A737WorkflowConvenioStatus, BC002M3_n737WorkflowConvenioStatus, BC002M3_A736WorkflowConvenioDesc, BC002M3_n736WorkflowConvenioDesc, BC002M3_A753WorkflowConvenioSLA, BC002M3_n753WorkflowConvenioSLA
               }
               , new Object[] {
               BC002M4_A742WorkflowConvenioId, BC002M4_A743WorkflowConvenioCreatedAt, BC002M4_n743WorkflowConvenioCreatedAt, BC002M4_A737WorkflowConvenioStatus, BC002M4_n737WorkflowConvenioStatus, BC002M4_A736WorkflowConvenioDesc, BC002M4_n736WorkflowConvenioDesc, BC002M4_A753WorkflowConvenioSLA, BC002M4_n753WorkflowConvenioSLA
               }
               , new Object[] {
               BC002M5_A742WorkflowConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002M7_A742WorkflowConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002M10_A746ReembolsoFlowLogId
               }
               , new Object[] {
               BC002M11_A518ReembolsoId
               }
               , new Object[] {
               BC002M12_A742WorkflowConvenioId, BC002M12_A743WorkflowConvenioCreatedAt, BC002M12_n743WorkflowConvenioCreatedAt, BC002M12_A737WorkflowConvenioStatus, BC002M12_n737WorkflowConvenioStatus, BC002M12_A736WorkflowConvenioDesc, BC002M12_n736WorkflowConvenioDesc, BC002M12_A753WorkflowConvenioSLA, BC002M12_n753WorkflowConvenioSLA
               }
            }
         );
         Z743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         i743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122M2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z753WorkflowConvenioSLA ;
      private short A753WorkflowConvenioSLA ;
      private short Gx_BScreen ;
      private short RcdFound91 ;
      private int trnEnded ;
      private int Z742WorkflowConvenioId ;
      private int A742WorkflowConvenioId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode91 ;
      private DateTime Z743WorkflowConvenioCreatedAt ;
      private DateTime A743WorkflowConvenioCreatedAt ;
      private DateTime i743WorkflowConvenioCreatedAt ;
      private bool returnInSub ;
      private bool Z737WorkflowConvenioStatus ;
      private bool A737WorkflowConvenioStatus ;
      private bool n737WorkflowConvenioStatus ;
      private bool n743WorkflowConvenioCreatedAt ;
      private bool n742WorkflowConvenioId ;
      private bool n736WorkflowConvenioDesc ;
      private bool n753WorkflowConvenioSLA ;
      private bool i737WorkflowConvenioStatus ;
      private string Z736WorkflowConvenioDesc ;
      private string A736WorkflowConvenioDesc ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC002M4_A742WorkflowConvenioId ;
      private bool[] BC002M4_n742WorkflowConvenioId ;
      private DateTime[] BC002M4_A743WorkflowConvenioCreatedAt ;
      private bool[] BC002M4_n743WorkflowConvenioCreatedAt ;
      private bool[] BC002M4_A737WorkflowConvenioStatus ;
      private bool[] BC002M4_n737WorkflowConvenioStatus ;
      private string[] BC002M4_A736WorkflowConvenioDesc ;
      private bool[] BC002M4_n736WorkflowConvenioDesc ;
      private short[] BC002M4_A753WorkflowConvenioSLA ;
      private bool[] BC002M4_n753WorkflowConvenioSLA ;
      private int[] BC002M5_A742WorkflowConvenioId ;
      private bool[] BC002M5_n742WorkflowConvenioId ;
      private int[] BC002M3_A742WorkflowConvenioId ;
      private bool[] BC002M3_n742WorkflowConvenioId ;
      private DateTime[] BC002M3_A743WorkflowConvenioCreatedAt ;
      private bool[] BC002M3_n743WorkflowConvenioCreatedAt ;
      private bool[] BC002M3_A737WorkflowConvenioStatus ;
      private bool[] BC002M3_n737WorkflowConvenioStatus ;
      private string[] BC002M3_A736WorkflowConvenioDesc ;
      private bool[] BC002M3_n736WorkflowConvenioDesc ;
      private short[] BC002M3_A753WorkflowConvenioSLA ;
      private bool[] BC002M3_n753WorkflowConvenioSLA ;
      private int[] BC002M2_A742WorkflowConvenioId ;
      private bool[] BC002M2_n742WorkflowConvenioId ;
      private DateTime[] BC002M2_A743WorkflowConvenioCreatedAt ;
      private bool[] BC002M2_n743WorkflowConvenioCreatedAt ;
      private bool[] BC002M2_A737WorkflowConvenioStatus ;
      private bool[] BC002M2_n737WorkflowConvenioStatus ;
      private string[] BC002M2_A736WorkflowConvenioDesc ;
      private bool[] BC002M2_n736WorkflowConvenioDesc ;
      private short[] BC002M2_A753WorkflowConvenioSLA ;
      private bool[] BC002M2_n753WorkflowConvenioSLA ;
      private int[] BC002M7_A742WorkflowConvenioId ;
      private bool[] BC002M7_n742WorkflowConvenioId ;
      private int[] BC002M10_A746ReembolsoFlowLogId ;
      private int[] BC002M11_A518ReembolsoId ;
      private int[] BC002M12_A742WorkflowConvenioId ;
      private bool[] BC002M12_n742WorkflowConvenioId ;
      private DateTime[] BC002M12_A743WorkflowConvenioCreatedAt ;
      private bool[] BC002M12_n743WorkflowConvenioCreatedAt ;
      private bool[] BC002M12_A737WorkflowConvenioStatus ;
      private bool[] BC002M12_n737WorkflowConvenioStatus ;
      private string[] BC002M12_A736WorkflowConvenioDesc ;
      private bool[] BC002M12_n736WorkflowConvenioDesc ;
      private short[] BC002M12_A753WorkflowConvenioSLA ;
      private bool[] BC002M12_n753WorkflowConvenioSLA ;
      private SdtWorkflowConvenio bcWorkflowConvenio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workflowconvenio_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002M2;
          prmBC002M2 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M3;
          prmBC002M3 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M4;
          prmBC002M4 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M5;
          prmBC002M5 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M6;
          prmBC002M6 = new Object[] {
          new ParDef("WorkflowConvenioCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WorkflowConvenioStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WorkflowConvenioDesc",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("WorkflowConvenioSLA",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002M7;
          prmBC002M7 = new Object[] {
          };
          Object[] prmBC002M8;
          prmBC002M8 = new Object[] {
          new ParDef("WorkflowConvenioCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WorkflowConvenioStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WorkflowConvenioDesc",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("WorkflowConvenioSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M9;
          prmBC002M9 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M10;
          prmBC002M10 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M11;
          prmBC002M11 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002M12;
          prmBC002M12 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC002M2", "SELECT WorkflowConvenioId, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId  FOR UPDATE OF WorkflowConvenio",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002M3", "SELECT WorkflowConvenioId, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002M4", "SELECT TM1.WorkflowConvenioId, TM1.WorkflowConvenioCreatedAt, TM1.WorkflowConvenioStatus, TM1.WorkflowConvenioDesc, TM1.WorkflowConvenioSLA FROM WorkflowConvenio TM1 WHERE TM1.WorkflowConvenioId = :WorkflowConvenioId ORDER BY TM1.WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002M5", "SELECT WorkflowConvenioId FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002M6", "SAVEPOINT gxupdate;INSERT INTO WorkflowConvenio(WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioSLA) VALUES(:WorkflowConvenioCreatedAt, :WorkflowConvenioStatus, :WorkflowConvenioDesc, :WorkflowConvenioSLA);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002M6)
             ,new CursorDef("BC002M7", "SELECT currval('WorkflowConvenioId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002M8", "SAVEPOINT gxupdate;UPDATE WorkflowConvenio SET WorkflowConvenioCreatedAt=:WorkflowConvenioCreatedAt, WorkflowConvenioStatus=:WorkflowConvenioStatus, WorkflowConvenioDesc=:WorkflowConvenioDesc, WorkflowConvenioSLA=:WorkflowConvenioSLA  WHERE WorkflowConvenioId = :WorkflowConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002M8)
             ,new CursorDef("BC002M9", "SAVEPOINT gxupdate;DELETE FROM WorkflowConvenio  WHERE WorkflowConvenioId = :WorkflowConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002M9)
             ,new CursorDef("BC002M10", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE LogWorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002M11", "SELECT ReembolsoId FROM Reembolso WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002M12", "SELECT TM1.WorkflowConvenioId, TM1.WorkflowConvenioCreatedAt, TM1.WorkflowConvenioStatus, TM1.WorkflowConvenioDesc, TM1.WorkflowConvenioSLA FROM WorkflowConvenio TM1 WHERE TM1.WorkflowConvenioId = :WorkflowConvenioId ORDER BY TM1.WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002M12,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
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
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
