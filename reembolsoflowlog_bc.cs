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
   public class reembolsoflowlog_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolsoflowlog_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoflowlog_bc( IGxContext context )
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
         ReadRow2K92( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2K92( ) ;
         standaloneModal( ) ;
         AddRow2K92( ) ;
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
            E112K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
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

      protected void CONFIRM_2K0( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2K92( ) ;
            }
            else
            {
               CheckExtendedTable2K92( ) ;
               if ( AnyError == 0 )
               {
                  ZM2K92( 6) ;
                  ZM2K92( 7) ;
                  ZM2K92( 8) ;
                  ZM2K92( 9) ;
                  ZM2K92( 10) ;
               }
               CloseExtendedTableCursors2K92( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV28Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV29GXV1 = 1;
            while ( AV29GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "LogWorkflowConvenioId") == 0 )
               {
                  AV11Insert_LogWorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ReembolsoFlowLogUser") == 0 )
               {
                  AV12Insert_ReembolsoFlowLogUser = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ReembolsoLogId") == 0 )
               {
                  AV13Insert_ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV29GXV1 = (int)(AV29GXV1+1);
            }
         }
      }

      protected void E112K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2K92( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z747ReembolsoFlowLogDate = A747ReembolsoFlowLogDate;
            Z761ReembolsoFlowLogDataFinal = A761ReembolsoFlowLogDataFinal;
            Z750LogWorkflowConvenioId = A750LogWorkflowConvenioId;
            Z744ReembolsoFlowLogUser = A744ReembolsoFlowLogUser;
            Z748ReembolsoLogId = A748ReembolsoLogId;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
            Z755ReembolsoFlowLogDataSLA_F = A755ReembolsoFlowLogDataSLA_F;
            Z764ReembolsoPaciente = A764ReembolsoPaciente;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z752LogWorkflowConvenioDesc = A752LogWorkflowConvenioDesc;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
            Z755ReembolsoFlowLogDataSLA_F = A755ReembolsoFlowLogDataSLA_F;
            Z764ReembolsoPaciente = A764ReembolsoPaciente;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z745ReembolsoFlowLogUserNome = A745ReembolsoFlowLogUserNome;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
            Z755ReembolsoFlowLogDataSLA_F = A755ReembolsoFlowLogDataSLA_F;
            Z764ReembolsoPaciente = A764ReembolsoPaciente;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z763ReembolsoLogProtocolo = A763ReembolsoLogProtocolo;
            Z749ReembolsoWorkFlowConvenioId = A749ReembolsoWorkFlowConvenioId;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
            Z755ReembolsoFlowLogDataSLA_F = A755ReembolsoFlowLogDataSLA_F;
            Z764ReembolsoPaciente = A764ReembolsoPaciente;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z754ReembolsoWorkflowConvenioSLA = A754ReembolsoWorkflowConvenioSLA;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
            Z755ReembolsoFlowLogDataSLA_F = A755ReembolsoFlowLogDataSLA_F;
            Z764ReembolsoPaciente = A764ReembolsoPaciente;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
            Z755ReembolsoFlowLogDataSLA_F = A755ReembolsoFlowLogDataSLA_F;
            Z764ReembolsoPaciente = A764ReembolsoPaciente;
         }
         if ( GX_JID == -5 )
         {
            Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
            Z747ReembolsoFlowLogDate = A747ReembolsoFlowLogDate;
            Z761ReembolsoFlowLogDataFinal = A761ReembolsoFlowLogDataFinal;
            Z750LogWorkflowConvenioId = A750LogWorkflowConvenioId;
            Z744ReembolsoFlowLogUser = A744ReembolsoFlowLogUser;
            Z748ReembolsoLogId = A748ReembolsoLogId;
            Z752LogWorkflowConvenioDesc = A752LogWorkflowConvenioDesc;
            Z745ReembolsoFlowLogUserNome = A745ReembolsoFlowLogUserNome;
            Z763ReembolsoLogProtocolo = A763ReembolsoLogProtocolo;
            Z749ReembolsoWorkFlowConvenioId = A749ReembolsoWorkFlowConvenioId;
            Z754ReembolsoWorkflowConvenioSLA = A754ReembolsoWorkflowConvenioSLA;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
         }
      }

      protected void standaloneNotModal( )
      {
         AV28Pgmname = "ReembolsoFlowLog_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2K92( )
      {
         /* Using cursor BC002K13 */
         pr_default.execute(7, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound92 = 1;
            A752LogWorkflowConvenioDesc = BC002K13_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = BC002K13_n752LogWorkflowConvenioDesc[0];
            A747ReembolsoFlowLogDate = BC002K13_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = BC002K13_n747ReembolsoFlowLogDate[0];
            A745ReembolsoFlowLogUserNome = BC002K13_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = BC002K13_n745ReembolsoFlowLogUserNome[0];
            A754ReembolsoWorkflowConvenioSLA = BC002K13_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = BC002K13_n754ReembolsoWorkflowConvenioSLA[0];
            A763ReembolsoLogProtocolo = BC002K13_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = BC002K13_n763ReembolsoLogProtocolo[0];
            A761ReembolsoFlowLogDataFinal = BC002K13_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = BC002K13_n761ReembolsoFlowLogDataFinal[0];
            A750LogWorkflowConvenioId = BC002K13_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = BC002K13_n750LogWorkflowConvenioId[0];
            A744ReembolsoFlowLogUser = BC002K13_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = BC002K13_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = BC002K13_A748ReembolsoLogId[0];
            n748ReembolsoLogId = BC002K13_n748ReembolsoLogId[0];
            A749ReembolsoWorkFlowConvenioId = BC002K13_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = BC002K13_n749ReembolsoWorkFlowConvenioId[0];
            A760LogReembolsoStatusAtual_F = BC002K13_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = BC002K13_n760LogReembolsoStatusAtual_F[0];
            ZM2K92( -5) ;
         }
         pr_default.close(7);
         OnLoadActions2K92( ) ;
      }

      protected void OnLoadActions2K92( )
      {
         if ( (0==A744ReembolsoFlowLogUser) )
         {
            A744ReembolsoFlowLogUser = 0;
            n744ReembolsoFlowLogUser = false;
            n744ReembolsoFlowLogUser = true;
            n744ReembolsoFlowLogUser = true;
         }
         A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
      }

      protected void CheckExtendedTable2K92( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002K4 */
         pr_default.execute(2, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A750LogWorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Flow Log'.", "ForeignKeyNotFound", 1, "LOGWORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A752LogWorkflowConvenioDesc = BC002K4_A752LogWorkflowConvenioDesc[0];
         n752LogWorkflowConvenioDesc = BC002K4_n752LogWorkflowConvenioDesc[0];
         pr_default.close(2);
         if ( (0==A744ReembolsoFlowLogUser) )
         {
            A744ReembolsoFlowLogUser = 0;
            n744ReembolsoFlowLogUser = false;
            n744ReembolsoFlowLogUser = true;
            n744ReembolsoFlowLogUser = true;
         }
         /* Using cursor BC002K5 */
         pr_default.execute(3, new Object[] {n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A744ReembolsoFlowLogUser) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso Flow Log Sec User'.", "ForeignKeyNotFound", 1, "REEMBOLSOFLOWLOGUSER");
               AnyError = 1;
            }
         }
         A745ReembolsoFlowLogUserNome = BC002K5_A745ReembolsoFlowLogUserNome[0];
         n745ReembolsoFlowLogUserNome = BC002K5_n745ReembolsoFlowLogUserNome[0];
         pr_default.close(3);
         /* Using cursor BC002K6 */
         pr_default.execute(4, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A748ReembolsoLogId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOLOGID");
               AnyError = 1;
            }
         }
         A763ReembolsoLogProtocolo = BC002K6_A763ReembolsoLogProtocolo[0];
         n763ReembolsoLogProtocolo = BC002K6_n763ReembolsoLogProtocolo[0];
         A749ReembolsoWorkFlowConvenioId = BC002K6_A749ReembolsoWorkFlowConvenioId[0];
         n749ReembolsoWorkFlowConvenioId = BC002K6_n749ReembolsoWorkFlowConvenioId[0];
         pr_default.close(4);
         /* Using cursor BC002K7 */
         pr_default.execute(5, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A749ReembolsoWorkFlowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOWORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A754ReembolsoWorkflowConvenioSLA = BC002K7_A754ReembolsoWorkflowConvenioSLA[0];
         n754ReembolsoWorkflowConvenioSLA = BC002K7_n754ReembolsoWorkflowConvenioSLA[0];
         pr_default.close(5);
         A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
         /* Using cursor BC002K10 */
         pr_default.execute(6, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A760LogReembolsoStatusAtual_F = BC002K10_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = BC002K10_n760LogReembolsoStatusAtual_F[0];
         }
         else
         {
            A760LogReembolsoStatusAtual_F = "";
            n760LogReembolsoStatusAtual_F = false;
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors2K92( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2K92( )
      {
         /* Using cursor BC002K14 */
         pr_default.execute(8, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound92 = 1;
         }
         else
         {
            RcdFound92 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002K3 */
         pr_default.execute(1, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2K92( 5) ;
            RcdFound92 = 1;
            A746ReembolsoFlowLogId = BC002K3_A746ReembolsoFlowLogId[0];
            A747ReembolsoFlowLogDate = BC002K3_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = BC002K3_n747ReembolsoFlowLogDate[0];
            A761ReembolsoFlowLogDataFinal = BC002K3_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = BC002K3_n761ReembolsoFlowLogDataFinal[0];
            A750LogWorkflowConvenioId = BC002K3_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = BC002K3_n750LogWorkflowConvenioId[0];
            A744ReembolsoFlowLogUser = BC002K3_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = BC002K3_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = BC002K3_A748ReembolsoLogId[0];
            n748ReembolsoLogId = BC002K3_n748ReembolsoLogId[0];
            Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2K92( ) ;
            if ( AnyError == 1 )
            {
               RcdFound92 = 0;
               InitializeNonKey2K92( ) ;
            }
            Gx_mode = sMode92;
         }
         else
         {
            RcdFound92 = 0;
            InitializeNonKey2K92( ) ;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode92;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2K92( ) ;
         if ( RcdFound92 == 0 )
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
         CONFIRM_2K0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2K92( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002K2 */
            pr_default.execute(0, new Object[] {A746ReembolsoFlowLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoFlowLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z747ReembolsoFlowLogDate != BC002K2_A747ReembolsoFlowLogDate[0] ) || ( Z761ReembolsoFlowLogDataFinal != BC002K2_A761ReembolsoFlowLogDataFinal[0] ) || ( Z750LogWorkflowConvenioId != BC002K2_A750LogWorkflowConvenioId[0] ) || ( Z744ReembolsoFlowLogUser != BC002K2_A744ReembolsoFlowLogUser[0] ) || ( Z748ReembolsoLogId != BC002K2_A748ReembolsoLogId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoFlowLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K92( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K92( 0) ;
            CheckOptimisticConcurrency2K92( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K92( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K92( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K15 */
                     pr_default.execute(9, new Object[] {n747ReembolsoFlowLogDate, A747ReembolsoFlowLogDate, n761ReembolsoFlowLogDataFinal, A761ReembolsoFlowLogDataFinal, n750LogWorkflowConvenioId, A750LogWorkflowConvenioId, n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser, n748ReembolsoLogId, A748ReembolsoLogId});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002K16 */
                     pr_default.execute(10);
                     A746ReembolsoFlowLogId = BC002K16_A746ReembolsoFlowLogId[0];
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
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
               Load2K92( ) ;
            }
            EndLevel2K92( ) ;
         }
         CloseExtendedTableCursors2K92( ) ;
      }

      protected void Update2K92( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K92( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K92( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K92( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002K17 */
                     pr_default.execute(11, new Object[] {n747ReembolsoFlowLogDate, A747ReembolsoFlowLogDate, n761ReembolsoFlowLogDataFinal, A761ReembolsoFlowLogDataFinal, n750LogWorkflowConvenioId, A750LogWorkflowConvenioId, n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser, n748ReembolsoLogId, A748ReembolsoLogId, A746ReembolsoFlowLogId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoFlowLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K92( ) ;
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
            EndLevel2K92( ) ;
         }
         CloseExtendedTableCursors2K92( ) ;
      }

      protected void DeferredUpdate2K92( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K92( ) ;
            AfterConfirm2K92( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K92( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002K18 */
                  pr_default.execute(12, new Object[] {A746ReembolsoFlowLogId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
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
         sMode92 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2K92( ) ;
         Gx_mode = sMode92;
      }

      protected void OnDeleteControls2K92( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002K19 */
            pr_default.execute(13, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
            A752LogWorkflowConvenioDesc = BC002K19_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = BC002K19_n752LogWorkflowConvenioDesc[0];
            pr_default.close(13);
            /* Using cursor BC002K20 */
            pr_default.execute(14, new Object[] {n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser});
            A745ReembolsoFlowLogUserNome = BC002K20_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = BC002K20_n745ReembolsoFlowLogUserNome[0];
            pr_default.close(14);
            /* Using cursor BC002K21 */
            pr_default.execute(15, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
            A763ReembolsoLogProtocolo = BC002K21_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = BC002K21_n763ReembolsoLogProtocolo[0];
            A749ReembolsoWorkFlowConvenioId = BC002K21_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = BC002K21_n749ReembolsoWorkFlowConvenioId[0];
            pr_default.close(15);
            /* Using cursor BC002K22 */
            pr_default.execute(16, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
            A754ReembolsoWorkflowConvenioSLA = BC002K22_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = BC002K22_n754ReembolsoWorkflowConvenioSLA[0];
            pr_default.close(16);
            A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
            /* Using cursor BC002K25 */
            pr_default.execute(17, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A760LogReembolsoStatusAtual_F = BC002K25_A760LogReembolsoStatusAtual_F[0];
               n760LogReembolsoStatusAtual_F = BC002K25_n760LogReembolsoStatusAtual_F[0];
            }
            else
            {
               A760LogReembolsoStatusAtual_F = "";
               n760LogReembolsoStatusAtual_F = false;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel2K92( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2K92( ) ;
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

      public void ScanKeyStart2K92( )
      {
         /* Scan By routine */
         /* Using cursor BC002K28 */
         pr_default.execute(18, new Object[] {A746ReembolsoFlowLogId});
         RcdFound92 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound92 = 1;
            A746ReembolsoFlowLogId = BC002K28_A746ReembolsoFlowLogId[0];
            A752LogWorkflowConvenioDesc = BC002K28_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = BC002K28_n752LogWorkflowConvenioDesc[0];
            A747ReembolsoFlowLogDate = BC002K28_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = BC002K28_n747ReembolsoFlowLogDate[0];
            A745ReembolsoFlowLogUserNome = BC002K28_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = BC002K28_n745ReembolsoFlowLogUserNome[0];
            A754ReembolsoWorkflowConvenioSLA = BC002K28_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = BC002K28_n754ReembolsoWorkflowConvenioSLA[0];
            A763ReembolsoLogProtocolo = BC002K28_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = BC002K28_n763ReembolsoLogProtocolo[0];
            A761ReembolsoFlowLogDataFinal = BC002K28_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = BC002K28_n761ReembolsoFlowLogDataFinal[0];
            A750LogWorkflowConvenioId = BC002K28_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = BC002K28_n750LogWorkflowConvenioId[0];
            A744ReembolsoFlowLogUser = BC002K28_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = BC002K28_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = BC002K28_A748ReembolsoLogId[0];
            n748ReembolsoLogId = BC002K28_n748ReembolsoLogId[0];
            A749ReembolsoWorkFlowConvenioId = BC002K28_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = BC002K28_n749ReembolsoWorkFlowConvenioId[0];
            A760LogReembolsoStatusAtual_F = BC002K28_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = BC002K28_n760LogReembolsoStatusAtual_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2K92( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound92 = 0;
         ScanKeyLoad2K92( ) ;
      }

      protected void ScanKeyLoad2K92( )
      {
         sMode92 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound92 = 1;
            A746ReembolsoFlowLogId = BC002K28_A746ReembolsoFlowLogId[0];
            A752LogWorkflowConvenioDesc = BC002K28_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = BC002K28_n752LogWorkflowConvenioDesc[0];
            A747ReembolsoFlowLogDate = BC002K28_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = BC002K28_n747ReembolsoFlowLogDate[0];
            A745ReembolsoFlowLogUserNome = BC002K28_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = BC002K28_n745ReembolsoFlowLogUserNome[0];
            A754ReembolsoWorkflowConvenioSLA = BC002K28_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = BC002K28_n754ReembolsoWorkflowConvenioSLA[0];
            A763ReembolsoLogProtocolo = BC002K28_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = BC002K28_n763ReembolsoLogProtocolo[0];
            A761ReembolsoFlowLogDataFinal = BC002K28_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = BC002K28_n761ReembolsoFlowLogDataFinal[0];
            A750LogWorkflowConvenioId = BC002K28_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = BC002K28_n750LogWorkflowConvenioId[0];
            A744ReembolsoFlowLogUser = BC002K28_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = BC002K28_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = BC002K28_A748ReembolsoLogId[0];
            n748ReembolsoLogId = BC002K28_n748ReembolsoLogId[0];
            A749ReembolsoWorkFlowConvenioId = BC002K28_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = BC002K28_n749ReembolsoWorkFlowConvenioId[0];
            A760LogReembolsoStatusAtual_F = BC002K28_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = BC002K28_n760LogReembolsoStatusAtual_F[0];
         }
         Gx_mode = sMode92;
      }

      protected void ScanKeyEnd2K92( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2K92( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K92( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K92( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K92( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K92( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K92( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K92( )
      {
      }

      protected void send_integrity_lvl_hashes2K92( )
      {
      }

      protected void AddRow2K92( )
      {
         VarsToRow92( bcReembolsoFlowLog) ;
      }

      protected void ReadRow2K92( )
      {
         RowToVars92( bcReembolsoFlowLog, 1) ;
      }

      protected void InitializeNonKey2K92( )
      {
         A755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         A750LogWorkflowConvenioId = 0;
         n750LogWorkflowConvenioId = false;
         A752LogWorkflowConvenioDesc = "";
         n752LogWorkflowConvenioDesc = false;
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         n747ReembolsoFlowLogDate = false;
         A744ReembolsoFlowLogUser = 0;
         n744ReembolsoFlowLogUser = false;
         A745ReembolsoFlowLogUserNome = "";
         n745ReembolsoFlowLogUserNome = false;
         A748ReembolsoLogId = 0;
         n748ReembolsoLogId = false;
         A749ReembolsoWorkFlowConvenioId = 0;
         n749ReembolsoWorkFlowConvenioId = false;
         A754ReembolsoWorkflowConvenioSLA = 0;
         n754ReembolsoWorkflowConvenioSLA = false;
         A760LogReembolsoStatusAtual_F = "";
         n760LogReembolsoStatusAtual_F = false;
         A763ReembolsoLogProtocolo = "";
         n763ReembolsoLogProtocolo = false;
         A764ReembolsoPaciente = "";
         A761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         n761ReembolsoFlowLogDataFinal = false;
         Z747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         Z761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         Z750LogWorkflowConvenioId = 0;
         Z744ReembolsoFlowLogUser = 0;
         Z748ReembolsoLogId = 0;
      }

      protected void InitAll2K92( )
      {
         A746ReembolsoFlowLogId = 0;
         InitializeNonKey2K92( ) ;
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

      public void VarsToRow92( SdtReembolsoFlowLog obj92 )
      {
         obj92.gxTpr_Mode = Gx_mode;
         obj92.gxTpr_Reembolsoflowlogdatasla_f = A755ReembolsoFlowLogDataSLA_F;
         obj92.gxTpr_Logworkflowconvenioid = A750LogWorkflowConvenioId;
         obj92.gxTpr_Logworkflowconveniodesc = A752LogWorkflowConvenioDesc;
         obj92.gxTpr_Reembolsoflowlogdate = A747ReembolsoFlowLogDate;
         obj92.gxTpr_Reembolsoflowloguser = A744ReembolsoFlowLogUser;
         obj92.gxTpr_Reembolsoflowlogusernome = A745ReembolsoFlowLogUserNome;
         obj92.gxTpr_Reembolsologid = A748ReembolsoLogId;
         obj92.gxTpr_Reembolsoworkflowconvenioid = A749ReembolsoWorkFlowConvenioId;
         obj92.gxTpr_Reembolsoworkflowconveniosla = A754ReembolsoWorkflowConvenioSLA;
         obj92.gxTpr_Logreembolsostatusatual_f = A760LogReembolsoStatusAtual_F;
         obj92.gxTpr_Reembolsologprotocolo = A763ReembolsoLogProtocolo;
         obj92.gxTpr_Reembolsopaciente = A764ReembolsoPaciente;
         obj92.gxTpr_Reembolsoflowlogdatafinal = A761ReembolsoFlowLogDataFinal;
         obj92.gxTpr_Reembolsoflowlogid = A746ReembolsoFlowLogId;
         obj92.gxTpr_Reembolsoflowlogid_Z = Z746ReembolsoFlowLogId;
         obj92.gxTpr_Logworkflowconvenioid_Z = Z750LogWorkflowConvenioId;
         obj92.gxTpr_Logworkflowconveniodesc_Z = Z752LogWorkflowConvenioDesc;
         obj92.gxTpr_Reembolsoflowlogdate_Z = Z747ReembolsoFlowLogDate;
         obj92.gxTpr_Reembolsoflowloguser_Z = Z744ReembolsoFlowLogUser;
         obj92.gxTpr_Reembolsoflowlogusernome_Z = Z745ReembolsoFlowLogUserNome;
         obj92.gxTpr_Reembolsologid_Z = Z748ReembolsoLogId;
         obj92.gxTpr_Reembolsoworkflowconvenioid_Z = Z749ReembolsoWorkFlowConvenioId;
         obj92.gxTpr_Reembolsoworkflowconveniosla_Z = Z754ReembolsoWorkflowConvenioSLA;
         obj92.gxTpr_Logreembolsostatusatual_f_Z = Z760LogReembolsoStatusAtual_F;
         obj92.gxTpr_Reembolsoflowlogdatasla_f_Z = Z755ReembolsoFlowLogDataSLA_F;
         obj92.gxTpr_Reembolsologprotocolo_Z = Z763ReembolsoLogProtocolo;
         obj92.gxTpr_Reembolsopaciente_Z = Z764ReembolsoPaciente;
         obj92.gxTpr_Reembolsoflowlogdatafinal_Z = Z761ReembolsoFlowLogDataFinal;
         obj92.gxTpr_Logworkflowconvenioid_N = (short)(Convert.ToInt16(n750LogWorkflowConvenioId));
         obj92.gxTpr_Logworkflowconveniodesc_N = (short)(Convert.ToInt16(n752LogWorkflowConvenioDesc));
         obj92.gxTpr_Reembolsoflowlogdate_N = (short)(Convert.ToInt16(n747ReembolsoFlowLogDate));
         obj92.gxTpr_Reembolsoflowloguser_N = (short)(Convert.ToInt16(n744ReembolsoFlowLogUser));
         obj92.gxTpr_Reembolsoflowlogusernome_N = (short)(Convert.ToInt16(n745ReembolsoFlowLogUserNome));
         obj92.gxTpr_Reembolsologid_N = (short)(Convert.ToInt16(n748ReembolsoLogId));
         obj92.gxTpr_Reembolsoworkflowconvenioid_N = (short)(Convert.ToInt16(n749ReembolsoWorkFlowConvenioId));
         obj92.gxTpr_Reembolsoworkflowconveniosla_N = (short)(Convert.ToInt16(n754ReembolsoWorkflowConvenioSLA));
         obj92.gxTpr_Logreembolsostatusatual_f_N = (short)(Convert.ToInt16(n760LogReembolsoStatusAtual_F));
         obj92.gxTpr_Reembolsologprotocolo_N = (short)(Convert.ToInt16(n763ReembolsoLogProtocolo));
         obj92.gxTpr_Reembolsoflowlogdatafinal_N = (short)(Convert.ToInt16(n761ReembolsoFlowLogDataFinal));
         obj92.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow92( SdtReembolsoFlowLog obj92 )
      {
         obj92.gxTpr_Reembolsoflowlogid = A746ReembolsoFlowLogId;
         return  ;
      }

      public void RowToVars92( SdtReembolsoFlowLog obj92 ,
                               int forceLoad )
      {
         Gx_mode = obj92.gxTpr_Mode;
         A755ReembolsoFlowLogDataSLA_F = obj92.gxTpr_Reembolsoflowlogdatasla_f;
         A750LogWorkflowConvenioId = obj92.gxTpr_Logworkflowconvenioid;
         n750LogWorkflowConvenioId = false;
         A752LogWorkflowConvenioDesc = obj92.gxTpr_Logworkflowconveniodesc;
         n752LogWorkflowConvenioDesc = false;
         A747ReembolsoFlowLogDate = obj92.gxTpr_Reembolsoflowlogdate;
         n747ReembolsoFlowLogDate = false;
         A744ReembolsoFlowLogUser = obj92.gxTpr_Reembolsoflowloguser;
         n744ReembolsoFlowLogUser = false;
         A745ReembolsoFlowLogUserNome = obj92.gxTpr_Reembolsoflowlogusernome;
         n745ReembolsoFlowLogUserNome = false;
         A748ReembolsoLogId = obj92.gxTpr_Reembolsologid;
         n748ReembolsoLogId = false;
         A749ReembolsoWorkFlowConvenioId = obj92.gxTpr_Reembolsoworkflowconvenioid;
         n749ReembolsoWorkFlowConvenioId = false;
         A754ReembolsoWorkflowConvenioSLA = obj92.gxTpr_Reembolsoworkflowconveniosla;
         n754ReembolsoWorkflowConvenioSLA = false;
         A760LogReembolsoStatusAtual_F = obj92.gxTpr_Logreembolsostatusatual_f;
         n760LogReembolsoStatusAtual_F = false;
         A763ReembolsoLogProtocolo = obj92.gxTpr_Reembolsologprotocolo;
         n763ReembolsoLogProtocolo = false;
         A764ReembolsoPaciente = obj92.gxTpr_Reembolsopaciente;
         A761ReembolsoFlowLogDataFinal = obj92.gxTpr_Reembolsoflowlogdatafinal;
         n761ReembolsoFlowLogDataFinal = false;
         A746ReembolsoFlowLogId = obj92.gxTpr_Reembolsoflowlogid;
         Z746ReembolsoFlowLogId = obj92.gxTpr_Reembolsoflowlogid_Z;
         Z750LogWorkflowConvenioId = obj92.gxTpr_Logworkflowconvenioid_Z;
         Z752LogWorkflowConvenioDesc = obj92.gxTpr_Logworkflowconveniodesc_Z;
         Z747ReembolsoFlowLogDate = obj92.gxTpr_Reembolsoflowlogdate_Z;
         Z744ReembolsoFlowLogUser = obj92.gxTpr_Reembolsoflowloguser_Z;
         Z745ReembolsoFlowLogUserNome = obj92.gxTpr_Reembolsoflowlogusernome_Z;
         Z748ReembolsoLogId = obj92.gxTpr_Reembolsologid_Z;
         Z749ReembolsoWorkFlowConvenioId = obj92.gxTpr_Reembolsoworkflowconvenioid_Z;
         Z754ReembolsoWorkflowConvenioSLA = obj92.gxTpr_Reembolsoworkflowconveniosla_Z;
         Z760LogReembolsoStatusAtual_F = obj92.gxTpr_Logreembolsostatusatual_f_Z;
         Z755ReembolsoFlowLogDataSLA_F = obj92.gxTpr_Reembolsoflowlogdatasla_f_Z;
         Z763ReembolsoLogProtocolo = obj92.gxTpr_Reembolsologprotocolo_Z;
         Z764ReembolsoPaciente = obj92.gxTpr_Reembolsopaciente_Z;
         Z761ReembolsoFlowLogDataFinal = obj92.gxTpr_Reembolsoflowlogdatafinal_Z;
         n750LogWorkflowConvenioId = (bool)(Convert.ToBoolean(obj92.gxTpr_Logworkflowconvenioid_N));
         n752LogWorkflowConvenioDesc = (bool)(Convert.ToBoolean(obj92.gxTpr_Logworkflowconveniodesc_N));
         n747ReembolsoFlowLogDate = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsoflowlogdate_N));
         n744ReembolsoFlowLogUser = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsoflowloguser_N));
         n745ReembolsoFlowLogUserNome = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsoflowlogusernome_N));
         n748ReembolsoLogId = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsologid_N));
         n749ReembolsoWorkFlowConvenioId = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsoworkflowconvenioid_N));
         n754ReembolsoWorkflowConvenioSLA = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsoworkflowconveniosla_N));
         n760LogReembolsoStatusAtual_F = (bool)(Convert.ToBoolean(obj92.gxTpr_Logreembolsostatusatual_f_N));
         n763ReembolsoLogProtocolo = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsologprotocolo_N));
         n761ReembolsoFlowLogDataFinal = (bool)(Convert.ToBoolean(obj92.gxTpr_Reembolsoflowlogdatafinal_N));
         Gx_mode = obj92.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A746ReembolsoFlowLogId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2K92( ) ;
         ScanKeyStart2K92( ) ;
         if ( RcdFound92 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
         }
         ZM2K92( -5) ;
         OnLoadActions2K92( ) ;
         AddRow2K92( ) ;
         ScanKeyEnd2K92( ) ;
         if ( RcdFound92 == 0 )
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
         RowToVars92( bcReembolsoFlowLog, 0) ;
         ScanKeyStart2K92( ) ;
         if ( RcdFound92 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
         }
         ZM2K92( -5) ;
         OnLoadActions2K92( ) ;
         AddRow2K92( ) ;
         ScanKeyEnd2K92( ) ;
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2K92( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2K92( ) ;
         }
         else
         {
            if ( RcdFound92 == 1 )
            {
               if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
               {
                  A746ReembolsoFlowLogId = Z746ReembolsoFlowLogId;
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
                  Update2K92( ) ;
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
                  if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
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
                        Insert2K92( ) ;
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
                        Insert2K92( ) ;
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
         RowToVars92( bcReembolsoFlowLog, 1) ;
         SaveImpl( ) ;
         VarsToRow92( bcReembolsoFlowLog) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars92( bcReembolsoFlowLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2K92( ) ;
         AfterTrn( ) ;
         VarsToRow92( bcReembolsoFlowLog) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow92( bcReembolsoFlowLog) ;
         }
         else
         {
            SdtReembolsoFlowLog auxBC = new SdtReembolsoFlowLog(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A746ReembolsoFlowLogId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolsoFlowLog);
               auxBC.Save();
               bcReembolsoFlowLog.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars92( bcReembolsoFlowLog, 1) ;
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
         RowToVars92( bcReembolsoFlowLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2K92( ) ;
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
               VarsToRow92( bcReembolsoFlowLog) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow92( bcReembolsoFlowLog) ;
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
         RowToVars92( bcReembolsoFlowLog, 0) ;
         GetKey2K92( ) ;
         if ( RcdFound92 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
            {
               A746ReembolsoFlowLogId = Z746ReembolsoFlowLogId;
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
            if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
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
         context.RollbackDataStores("reembolsoflowlog_bc",pr_default);
         VarsToRow92( bcReembolsoFlowLog) ;
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
         Gx_mode = bcReembolsoFlowLog.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolsoFlowLog.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolsoFlowLog )
         {
            bcReembolsoFlowLog = (SdtReembolsoFlowLog)(sdt);
            if ( StringUtil.StrCmp(bcReembolsoFlowLog.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoFlowLog.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow92( bcReembolsoFlowLog) ;
            }
            else
            {
               RowToVars92( bcReembolsoFlowLog, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolsoFlowLog.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoFlowLog.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars92( bcReembolsoFlowLog, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolsoFlowLog ReembolsoFlowLog_BC
      {
         get {
            return bcReembolsoFlowLog ;
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
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV28Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         Z761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         A761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         Z760LogReembolsoStatusAtual_F = "";
         A760LogReembolsoStatusAtual_F = "";
         Z755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         A755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         Z764ReembolsoPaciente = "";
         A764ReembolsoPaciente = "";
         Z752LogWorkflowConvenioDesc = "";
         A752LogWorkflowConvenioDesc = "";
         Z745ReembolsoFlowLogUserNome = "";
         A745ReembolsoFlowLogUserNome = "";
         Z763ReembolsoLogProtocolo = "";
         A763ReembolsoLogProtocolo = "";
         BC002K13_A746ReembolsoFlowLogId = new int[1] ;
         BC002K13_A752LogWorkflowConvenioDesc = new string[] {""} ;
         BC002K13_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         BC002K13_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         BC002K13_n747ReembolsoFlowLogDate = new bool[] {false} ;
         BC002K13_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         BC002K13_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         BC002K13_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         BC002K13_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         BC002K13_A763ReembolsoLogProtocolo = new string[] {""} ;
         BC002K13_n763ReembolsoLogProtocolo = new bool[] {false} ;
         BC002K13_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC002K13_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         BC002K13_A750LogWorkflowConvenioId = new int[1] ;
         BC002K13_n750LogWorkflowConvenioId = new bool[] {false} ;
         BC002K13_A744ReembolsoFlowLogUser = new short[1] ;
         BC002K13_n744ReembolsoFlowLogUser = new bool[] {false} ;
         BC002K13_A748ReembolsoLogId = new int[1] ;
         BC002K13_n748ReembolsoLogId = new bool[] {false} ;
         BC002K13_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         BC002K13_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         BC002K13_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         BC002K13_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         BC002K4_A752LogWorkflowConvenioDesc = new string[] {""} ;
         BC002K4_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         BC002K5_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         BC002K5_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         BC002K6_A763ReembolsoLogProtocolo = new string[] {""} ;
         BC002K6_n763ReembolsoLogProtocolo = new bool[] {false} ;
         BC002K6_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         BC002K6_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         BC002K7_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         BC002K7_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         BC002K10_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         BC002K10_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         BC002K14_A746ReembolsoFlowLogId = new int[1] ;
         BC002K3_A746ReembolsoFlowLogId = new int[1] ;
         BC002K3_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         BC002K3_n747ReembolsoFlowLogDate = new bool[] {false} ;
         BC002K3_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC002K3_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         BC002K3_A750LogWorkflowConvenioId = new int[1] ;
         BC002K3_n750LogWorkflowConvenioId = new bool[] {false} ;
         BC002K3_A744ReembolsoFlowLogUser = new short[1] ;
         BC002K3_n744ReembolsoFlowLogUser = new bool[] {false} ;
         BC002K3_A748ReembolsoLogId = new int[1] ;
         BC002K3_n748ReembolsoLogId = new bool[] {false} ;
         sMode92 = "";
         BC002K2_A746ReembolsoFlowLogId = new int[1] ;
         BC002K2_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         BC002K2_n747ReembolsoFlowLogDate = new bool[] {false} ;
         BC002K2_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC002K2_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         BC002K2_A750LogWorkflowConvenioId = new int[1] ;
         BC002K2_n750LogWorkflowConvenioId = new bool[] {false} ;
         BC002K2_A744ReembolsoFlowLogUser = new short[1] ;
         BC002K2_n744ReembolsoFlowLogUser = new bool[] {false} ;
         BC002K2_A748ReembolsoLogId = new int[1] ;
         BC002K2_n748ReembolsoLogId = new bool[] {false} ;
         BC002K16_A746ReembolsoFlowLogId = new int[1] ;
         BC002K19_A752LogWorkflowConvenioDesc = new string[] {""} ;
         BC002K19_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         BC002K20_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         BC002K20_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         BC002K21_A763ReembolsoLogProtocolo = new string[] {""} ;
         BC002K21_n763ReembolsoLogProtocolo = new bool[] {false} ;
         BC002K21_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         BC002K21_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         BC002K22_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         BC002K22_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         BC002K25_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         BC002K25_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         BC002K28_A746ReembolsoFlowLogId = new int[1] ;
         BC002K28_A752LogWorkflowConvenioDesc = new string[] {""} ;
         BC002K28_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         BC002K28_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         BC002K28_n747ReembolsoFlowLogDate = new bool[] {false} ;
         BC002K28_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         BC002K28_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         BC002K28_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         BC002K28_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         BC002K28_A763ReembolsoLogProtocolo = new string[] {""} ;
         BC002K28_n763ReembolsoLogProtocolo = new bool[] {false} ;
         BC002K28_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC002K28_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         BC002K28_A750LogWorkflowConvenioId = new int[1] ;
         BC002K28_n750LogWorkflowConvenioId = new bool[] {false} ;
         BC002K28_A744ReembolsoFlowLogUser = new short[1] ;
         BC002K28_n744ReembolsoFlowLogUser = new bool[] {false} ;
         BC002K28_A748ReembolsoLogId = new int[1] ;
         BC002K28_n748ReembolsoLogId = new bool[] {false} ;
         BC002K28_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         BC002K28_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         BC002K28_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         BC002K28_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoflowlog_bc__default(),
            new Object[][] {
                new Object[] {
               BC002K2_A746ReembolsoFlowLogId, BC002K2_A747ReembolsoFlowLogDate, BC002K2_n747ReembolsoFlowLogDate, BC002K2_A761ReembolsoFlowLogDataFinal, BC002K2_n761ReembolsoFlowLogDataFinal, BC002K2_A750LogWorkflowConvenioId, BC002K2_n750LogWorkflowConvenioId, BC002K2_A744ReembolsoFlowLogUser, BC002K2_n744ReembolsoFlowLogUser, BC002K2_A748ReembolsoLogId,
               BC002K2_n748ReembolsoLogId
               }
               , new Object[] {
               BC002K3_A746ReembolsoFlowLogId, BC002K3_A747ReembolsoFlowLogDate, BC002K3_n747ReembolsoFlowLogDate, BC002K3_A761ReembolsoFlowLogDataFinal, BC002K3_n761ReembolsoFlowLogDataFinal, BC002K3_A750LogWorkflowConvenioId, BC002K3_n750LogWorkflowConvenioId, BC002K3_A744ReembolsoFlowLogUser, BC002K3_n744ReembolsoFlowLogUser, BC002K3_A748ReembolsoLogId,
               BC002K3_n748ReembolsoLogId
               }
               , new Object[] {
               BC002K4_A752LogWorkflowConvenioDesc, BC002K4_n752LogWorkflowConvenioDesc
               }
               , new Object[] {
               BC002K5_A745ReembolsoFlowLogUserNome, BC002K5_n745ReembolsoFlowLogUserNome
               }
               , new Object[] {
               BC002K6_A763ReembolsoLogProtocolo, BC002K6_n763ReembolsoLogProtocolo, BC002K6_A749ReembolsoWorkFlowConvenioId, BC002K6_n749ReembolsoWorkFlowConvenioId
               }
               , new Object[] {
               BC002K7_A754ReembolsoWorkflowConvenioSLA, BC002K7_n754ReembolsoWorkflowConvenioSLA
               }
               , new Object[] {
               BC002K10_A760LogReembolsoStatusAtual_F, BC002K10_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               BC002K13_A746ReembolsoFlowLogId, BC002K13_A752LogWorkflowConvenioDesc, BC002K13_n752LogWorkflowConvenioDesc, BC002K13_A747ReembolsoFlowLogDate, BC002K13_n747ReembolsoFlowLogDate, BC002K13_A745ReembolsoFlowLogUserNome, BC002K13_n745ReembolsoFlowLogUserNome, BC002K13_A754ReembolsoWorkflowConvenioSLA, BC002K13_n754ReembolsoWorkflowConvenioSLA, BC002K13_A763ReembolsoLogProtocolo,
               BC002K13_n763ReembolsoLogProtocolo, BC002K13_A761ReembolsoFlowLogDataFinal, BC002K13_n761ReembolsoFlowLogDataFinal, BC002K13_A750LogWorkflowConvenioId, BC002K13_n750LogWorkflowConvenioId, BC002K13_A744ReembolsoFlowLogUser, BC002K13_n744ReembolsoFlowLogUser, BC002K13_A748ReembolsoLogId, BC002K13_n748ReembolsoLogId, BC002K13_A749ReembolsoWorkFlowConvenioId,
               BC002K13_n749ReembolsoWorkFlowConvenioId, BC002K13_A760LogReembolsoStatusAtual_F, BC002K13_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               BC002K14_A746ReembolsoFlowLogId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002K16_A746ReembolsoFlowLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002K19_A752LogWorkflowConvenioDesc, BC002K19_n752LogWorkflowConvenioDesc
               }
               , new Object[] {
               BC002K20_A745ReembolsoFlowLogUserNome, BC002K20_n745ReembolsoFlowLogUserNome
               }
               , new Object[] {
               BC002K21_A763ReembolsoLogProtocolo, BC002K21_n763ReembolsoLogProtocolo, BC002K21_A749ReembolsoWorkFlowConvenioId, BC002K21_n749ReembolsoWorkFlowConvenioId
               }
               , new Object[] {
               BC002K22_A754ReembolsoWorkflowConvenioSLA, BC002K22_n754ReembolsoWorkflowConvenioSLA
               }
               , new Object[] {
               BC002K25_A760LogReembolsoStatusAtual_F, BC002K25_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               BC002K28_A746ReembolsoFlowLogId, BC002K28_A752LogWorkflowConvenioDesc, BC002K28_n752LogWorkflowConvenioDesc, BC002K28_A747ReembolsoFlowLogDate, BC002K28_n747ReembolsoFlowLogDate, BC002K28_A745ReembolsoFlowLogUserNome, BC002K28_n745ReembolsoFlowLogUserNome, BC002K28_A754ReembolsoWorkflowConvenioSLA, BC002K28_n754ReembolsoWorkflowConvenioSLA, BC002K28_A763ReembolsoLogProtocolo,
               BC002K28_n763ReembolsoLogProtocolo, BC002K28_A761ReembolsoFlowLogDataFinal, BC002K28_n761ReembolsoFlowLogDataFinal, BC002K28_A750LogWorkflowConvenioId, BC002K28_n750LogWorkflowConvenioId, BC002K28_A744ReembolsoFlowLogUser, BC002K28_n744ReembolsoFlowLogUser, BC002K28_A748ReembolsoLogId, BC002K28_n748ReembolsoLogId, BC002K28_A749ReembolsoWorkFlowConvenioId,
               BC002K28_n749ReembolsoWorkFlowConvenioId, BC002K28_A760LogReembolsoStatusAtual_F, BC002K28_n760LogReembolsoStatusAtual_F
               }
            }
         );
         AV28Pgmname = "ReembolsoFlowLog_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122K2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV12Insert_ReembolsoFlowLogUser ;
      private short Z744ReembolsoFlowLogUser ;
      private short A744ReembolsoFlowLogUser ;
      private short Z754ReembolsoWorkflowConvenioSLA ;
      private short A754ReembolsoWorkflowConvenioSLA ;
      private short RcdFound92 ;
      private int trnEnded ;
      private int Z746ReembolsoFlowLogId ;
      private int A746ReembolsoFlowLogId ;
      private int AV29GXV1 ;
      private int AV11Insert_LogWorkflowConvenioId ;
      private int AV13Insert_ReembolsoLogId ;
      private int Z750LogWorkflowConvenioId ;
      private int A750LogWorkflowConvenioId ;
      private int Z748ReembolsoLogId ;
      private int A748ReembolsoLogId ;
      private int Z749ReembolsoWorkFlowConvenioId ;
      private int A749ReembolsoWorkFlowConvenioId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV28Pgmname ;
      private string sMode92 ;
      private DateTime Z747ReembolsoFlowLogDate ;
      private DateTime A747ReembolsoFlowLogDate ;
      private DateTime Z761ReembolsoFlowLogDataFinal ;
      private DateTime A761ReembolsoFlowLogDataFinal ;
      private DateTime Z755ReembolsoFlowLogDataSLA_F ;
      private DateTime A755ReembolsoFlowLogDataSLA_F ;
      private bool returnInSub ;
      private bool n752LogWorkflowConvenioDesc ;
      private bool n747ReembolsoFlowLogDate ;
      private bool n745ReembolsoFlowLogUserNome ;
      private bool n754ReembolsoWorkflowConvenioSLA ;
      private bool n763ReembolsoLogProtocolo ;
      private bool n761ReembolsoFlowLogDataFinal ;
      private bool n750LogWorkflowConvenioId ;
      private bool n744ReembolsoFlowLogUser ;
      private bool n748ReembolsoLogId ;
      private bool n749ReembolsoWorkFlowConvenioId ;
      private bool n760LogReembolsoStatusAtual_F ;
      private string Z760LogReembolsoStatusAtual_F ;
      private string A760LogReembolsoStatusAtual_F ;
      private string Z764ReembolsoPaciente ;
      private string A764ReembolsoPaciente ;
      private string Z752LogWorkflowConvenioDesc ;
      private string A752LogWorkflowConvenioDesc ;
      private string Z745ReembolsoFlowLogUserNome ;
      private string A745ReembolsoFlowLogUserNome ;
      private string Z763ReembolsoLogProtocolo ;
      private string A763ReembolsoLogProtocolo ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002K13_A746ReembolsoFlowLogId ;
      private string[] BC002K13_A752LogWorkflowConvenioDesc ;
      private bool[] BC002K13_n752LogWorkflowConvenioDesc ;
      private DateTime[] BC002K13_A747ReembolsoFlowLogDate ;
      private bool[] BC002K13_n747ReembolsoFlowLogDate ;
      private string[] BC002K13_A745ReembolsoFlowLogUserNome ;
      private bool[] BC002K13_n745ReembolsoFlowLogUserNome ;
      private short[] BC002K13_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] BC002K13_n754ReembolsoWorkflowConvenioSLA ;
      private string[] BC002K13_A763ReembolsoLogProtocolo ;
      private bool[] BC002K13_n763ReembolsoLogProtocolo ;
      private DateTime[] BC002K13_A761ReembolsoFlowLogDataFinal ;
      private bool[] BC002K13_n761ReembolsoFlowLogDataFinal ;
      private int[] BC002K13_A750LogWorkflowConvenioId ;
      private bool[] BC002K13_n750LogWorkflowConvenioId ;
      private short[] BC002K13_A744ReembolsoFlowLogUser ;
      private bool[] BC002K13_n744ReembolsoFlowLogUser ;
      private int[] BC002K13_A748ReembolsoLogId ;
      private bool[] BC002K13_n748ReembolsoLogId ;
      private int[] BC002K13_A749ReembolsoWorkFlowConvenioId ;
      private bool[] BC002K13_n749ReembolsoWorkFlowConvenioId ;
      private string[] BC002K13_A760LogReembolsoStatusAtual_F ;
      private bool[] BC002K13_n760LogReembolsoStatusAtual_F ;
      private string[] BC002K4_A752LogWorkflowConvenioDesc ;
      private bool[] BC002K4_n752LogWorkflowConvenioDesc ;
      private string[] BC002K5_A745ReembolsoFlowLogUserNome ;
      private bool[] BC002K5_n745ReembolsoFlowLogUserNome ;
      private string[] BC002K6_A763ReembolsoLogProtocolo ;
      private bool[] BC002K6_n763ReembolsoLogProtocolo ;
      private int[] BC002K6_A749ReembolsoWorkFlowConvenioId ;
      private bool[] BC002K6_n749ReembolsoWorkFlowConvenioId ;
      private short[] BC002K7_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] BC002K7_n754ReembolsoWorkflowConvenioSLA ;
      private string[] BC002K10_A760LogReembolsoStatusAtual_F ;
      private bool[] BC002K10_n760LogReembolsoStatusAtual_F ;
      private int[] BC002K14_A746ReembolsoFlowLogId ;
      private int[] BC002K3_A746ReembolsoFlowLogId ;
      private DateTime[] BC002K3_A747ReembolsoFlowLogDate ;
      private bool[] BC002K3_n747ReembolsoFlowLogDate ;
      private DateTime[] BC002K3_A761ReembolsoFlowLogDataFinal ;
      private bool[] BC002K3_n761ReembolsoFlowLogDataFinal ;
      private int[] BC002K3_A750LogWorkflowConvenioId ;
      private bool[] BC002K3_n750LogWorkflowConvenioId ;
      private short[] BC002K3_A744ReembolsoFlowLogUser ;
      private bool[] BC002K3_n744ReembolsoFlowLogUser ;
      private int[] BC002K3_A748ReembolsoLogId ;
      private bool[] BC002K3_n748ReembolsoLogId ;
      private int[] BC002K2_A746ReembolsoFlowLogId ;
      private DateTime[] BC002K2_A747ReembolsoFlowLogDate ;
      private bool[] BC002K2_n747ReembolsoFlowLogDate ;
      private DateTime[] BC002K2_A761ReembolsoFlowLogDataFinal ;
      private bool[] BC002K2_n761ReembolsoFlowLogDataFinal ;
      private int[] BC002K2_A750LogWorkflowConvenioId ;
      private bool[] BC002K2_n750LogWorkflowConvenioId ;
      private short[] BC002K2_A744ReembolsoFlowLogUser ;
      private bool[] BC002K2_n744ReembolsoFlowLogUser ;
      private int[] BC002K2_A748ReembolsoLogId ;
      private bool[] BC002K2_n748ReembolsoLogId ;
      private int[] BC002K16_A746ReembolsoFlowLogId ;
      private string[] BC002K19_A752LogWorkflowConvenioDesc ;
      private bool[] BC002K19_n752LogWorkflowConvenioDesc ;
      private string[] BC002K20_A745ReembolsoFlowLogUserNome ;
      private bool[] BC002K20_n745ReembolsoFlowLogUserNome ;
      private string[] BC002K21_A763ReembolsoLogProtocolo ;
      private bool[] BC002K21_n763ReembolsoLogProtocolo ;
      private int[] BC002K21_A749ReembolsoWorkFlowConvenioId ;
      private bool[] BC002K21_n749ReembolsoWorkFlowConvenioId ;
      private short[] BC002K22_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] BC002K22_n754ReembolsoWorkflowConvenioSLA ;
      private string[] BC002K25_A760LogReembolsoStatusAtual_F ;
      private bool[] BC002K25_n760LogReembolsoStatusAtual_F ;
      private int[] BC002K28_A746ReembolsoFlowLogId ;
      private string[] BC002K28_A752LogWorkflowConvenioDesc ;
      private bool[] BC002K28_n752LogWorkflowConvenioDesc ;
      private DateTime[] BC002K28_A747ReembolsoFlowLogDate ;
      private bool[] BC002K28_n747ReembolsoFlowLogDate ;
      private string[] BC002K28_A745ReembolsoFlowLogUserNome ;
      private bool[] BC002K28_n745ReembolsoFlowLogUserNome ;
      private short[] BC002K28_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] BC002K28_n754ReembolsoWorkflowConvenioSLA ;
      private string[] BC002K28_A763ReembolsoLogProtocolo ;
      private bool[] BC002K28_n763ReembolsoLogProtocolo ;
      private DateTime[] BC002K28_A761ReembolsoFlowLogDataFinal ;
      private bool[] BC002K28_n761ReembolsoFlowLogDataFinal ;
      private int[] BC002K28_A750LogWorkflowConvenioId ;
      private bool[] BC002K28_n750LogWorkflowConvenioId ;
      private short[] BC002K28_A744ReembolsoFlowLogUser ;
      private bool[] BC002K28_n744ReembolsoFlowLogUser ;
      private int[] BC002K28_A748ReembolsoLogId ;
      private bool[] BC002K28_n748ReembolsoLogId ;
      private int[] BC002K28_A749ReembolsoWorkFlowConvenioId ;
      private bool[] BC002K28_n749ReembolsoWorkFlowConvenioId ;
      private string[] BC002K28_A760LogReembolsoStatusAtual_F ;
      private bool[] BC002K28_n760LogReembolsoStatusAtual_F ;
      private SdtReembolsoFlowLog bcReembolsoFlowLog ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoflowlog_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002K2;
          prmBC002K2 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002K3;
          prmBC002K3 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002K4;
          prmBC002K4 = new Object[] {
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K5;
          prmBC002K5 = new Object[] {
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002K6;
          prmBC002K6 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K7;
          prmBC002K7 = new Object[] {
          new ParDef("ReembolsoWorkFlowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K10;
          prmBC002K10 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K13;
          prmBC002K13 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002K14;
          prmBC002K14 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002K15;
          prmBC002K15 = new Object[] {
          new ParDef("ReembolsoFlowLogDate",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoFlowLogDataFinal",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K16;
          prmBC002K16 = new Object[] {
          };
          Object[] prmBC002K17;
          prmBC002K17 = new Object[] {
          new ParDef("ReembolsoFlowLogDate",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoFlowLogDataFinal",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002K18;
          prmBC002K18 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002K19;
          prmBC002K19 = new Object[] {
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K20;
          prmBC002K20 = new Object[] {
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002K21;
          prmBC002K21 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K22;
          prmBC002K22 = new Object[] {
          new ParDef("ReembolsoWorkFlowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K25;
          prmBC002K25 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002K28;
          prmBC002K28 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002K2", "SELECT ReembolsoFlowLogId, ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal, LogWorkflowConvenioId, ReembolsoFlowLogUser, ReembolsoLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId  FOR UPDATE OF ReembolsoFlowLog",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K3", "SELECT ReembolsoFlowLogId, ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal, LogWorkflowConvenioId, ReembolsoFlowLogUser, ReembolsoLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K4", "SELECT WorkflowConvenioDesc AS LogWorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :LogWorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K5", "SELECT SecUserName AS ReembolsoFlowLogUserNome FROM SecUser WHERE SecUserId = :ReembolsoFlowLogUser ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K6", "SELECT ReembolsoProtocolo AS ReembolsoLogProtocolo, WorkflowConvenioId AS ReembolsoWorkFlowConvenioId FROM Reembolso WHERE ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K7", "SELECT WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :ReembolsoWorkFlowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K10", "SELECT COALESCE( T1.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T2.ReembolsoId FROM (ReembolsoEtapa T2 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T3.ReembolsoEtapaUltimo_F, T2.ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K13", "SELECT TM1.ReembolsoFlowLogId, T2.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, TM1.ReembolsoFlowLogDate, T3.SecUserName AS ReembolsoFlowLogUserNome, T5.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, T4.ReembolsoProtocolo AS ReembolsoLogProtocolo, TM1.ReembolsoFlowLogDataFinal, TM1.LogWorkflowConvenioId AS LogWorkflowConvenioId, TM1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, TM1.ReembolsoLogId AS ReembolsoLogId, T4.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, COALESCE( T6.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (((((ReembolsoFlowLog TM1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = TM1.LogWorkflowConvenioId) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.ReembolsoFlowLogUser) LEFT JOIN Reembolso T4 ON T4.ReembolsoId = TM1.ReembolsoLogId) LEFT JOIN WorkflowConvenio T5 ON T5.WorkflowConvenioId = T4.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T7.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoId FROM (ReembolsoEtapa T7 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T7.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T7.ReembolsoId) WHERE (TM1.ReembolsoLogId = T7.ReembolsoId) AND (T7.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoId ) T6 ON T6.ReembolsoId = TM1.ReembolsoLogId) WHERE TM1.ReembolsoFlowLogId = :ReembolsoFlowLogId ORDER BY TM1.ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K14", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K15", "SAVEPOINT gxupdate;INSERT INTO ReembolsoFlowLog(ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal, LogWorkflowConvenioId, ReembolsoFlowLogUser, ReembolsoLogId) VALUES(:ReembolsoFlowLogDate, :ReembolsoFlowLogDataFinal, :LogWorkflowConvenioId, :ReembolsoFlowLogUser, :ReembolsoLogId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002K15)
             ,new CursorDef("BC002K16", "SELECT currval('ReembolsoFlowLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K17", "SAVEPOINT gxupdate;UPDATE ReembolsoFlowLog SET ReembolsoFlowLogDate=:ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal=:ReembolsoFlowLogDataFinal, LogWorkflowConvenioId=:LogWorkflowConvenioId, ReembolsoFlowLogUser=:ReembolsoFlowLogUser, ReembolsoLogId=:ReembolsoLogId  WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002K17)
             ,new CursorDef("BC002K18", "SAVEPOINT gxupdate;DELETE FROM ReembolsoFlowLog  WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002K18)
             ,new CursorDef("BC002K19", "SELECT WorkflowConvenioDesc AS LogWorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :LogWorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K20", "SELECT SecUserName AS ReembolsoFlowLogUserNome FROM SecUser WHERE SecUserId = :ReembolsoFlowLogUser ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K21", "SELECT ReembolsoProtocolo AS ReembolsoLogProtocolo, WorkflowConvenioId AS ReembolsoWorkFlowConvenioId FROM Reembolso WHERE ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K22", "SELECT WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :ReembolsoWorkFlowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K25", "SELECT COALESCE( T1.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T2.ReembolsoId FROM (ReembolsoEtapa T2 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T3.ReembolsoEtapaUltimo_F, T2.ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002K28", "SELECT TM1.ReembolsoFlowLogId, T2.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, TM1.ReembolsoFlowLogDate, T3.SecUserName AS ReembolsoFlowLogUserNome, T5.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, T4.ReembolsoProtocolo AS ReembolsoLogProtocolo, TM1.ReembolsoFlowLogDataFinal, TM1.LogWorkflowConvenioId AS LogWorkflowConvenioId, TM1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, TM1.ReembolsoLogId AS ReembolsoLogId, T4.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, COALESCE( T6.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (((((ReembolsoFlowLog TM1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = TM1.LogWorkflowConvenioId) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.ReembolsoFlowLogUser) LEFT JOIN Reembolso T4 ON T4.ReembolsoId = TM1.ReembolsoLogId) LEFT JOIN WorkflowConvenio T5 ON T5.WorkflowConvenioId = T4.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T7.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoId FROM (ReembolsoEtapa T7 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T7.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T7.ReembolsoId) WHERE (TM1.ReembolsoLogId = T7.ReembolsoId) AND (T7.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoId ) T6 ON T6.ReembolsoId = TM1.ReembolsoLogId) WHERE TM1.ReembolsoFlowLogId = :ReembolsoFlowLogId ORDER BY TM1.ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002K28,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
