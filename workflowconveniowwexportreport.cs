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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class workflowconveniowwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public workflowconveniowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workflowconveniowwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("WorkflowConvenioWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV50Title = "Lista de Workflow Convenio";
            GXt_char1 = AV55Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV55Companyname = GXt_char1;
            GXt_char1 = AV49Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV49Phone = GXt_char1;
            GXt_char1 = AV47Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV47Mail = GXt_char1;
            GXt_char1 = AV51Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV51Website = GXt_char1;
            GXt_char1 = AV40AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV40AddressLine1 = GXt_char1;
            GXt_char1 = AV41AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV41AddressLine2 = GXt_char1;
            GXt_char1 = AV42AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV42AddressLine3 = GXt_char1;
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCS0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) )
         {
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15WorkflowConvenioDesc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15WorkflowConvenioDesc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterWorkflowConvenioDescDescription = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterWorkflowConvenioDescDescription = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17WorkflowConvenioDesc = AV15WorkflowConvenioDesc1;
                  HCS0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterWorkflowConvenioDescDescription, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17WorkflowConvenioDesc, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21WorkflowConvenioDesc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21WorkflowConvenioDesc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterWorkflowConvenioDescDescription = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterWorkflowConvenioDescDescription = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17WorkflowConvenioDesc = AV21WorkflowConvenioDesc2;
                     HCS0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterWorkflowConvenioDescDescription, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17WorkflowConvenioDesc, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25WorkflowConvenioDesc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25WorkflowConvenioDesc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterWorkflowConvenioDescDescription = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterWorkflowConvenioDescDescription = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17WorkflowConvenioDesc = AV25WorkflowConvenioDesc3;
                        HCS0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterWorkflowConvenioDescDescription, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17WorkflowConvenioDesc, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFWorkflowConvenioDesc_Sel)) )
         {
            AV39TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFWorkflowConvenioDesc_Sel, "<#Empty#>")==0)));
            AV33TFWorkflowConvenioDesc_Sel = (AV39TempBoolean ? "(Vazio)" : AV33TFWorkflowConvenioDesc_Sel);
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Passo", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFWorkflowConvenioDesc_Sel, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFWorkflowConvenioDesc_Sel = (AV39TempBoolean ? "<#Empty#>" : AV33TFWorkflowConvenioDesc_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFWorkflowConvenioDesc)) )
            {
               HCS0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Passo", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFWorkflowConvenioDesc, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV34TFWorkflowConvenioStatus_Sel) )
         {
            if ( AV34TFWorkflowConvenioStatus_Sel == 1 )
            {
               AV37FilterTFWorkflowConvenioStatus_SelValueDescription = "Marcado";
            }
            else if ( AV34TFWorkflowConvenioStatus_Sel == 2 )
            {
               AV37FilterTFWorkflowConvenioStatus_SelValueDescription = "Desmarcado";
            }
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37FilterTFWorkflowConvenioStatus_SelValueDescription, "")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV35TFWorkflowConvenioCreatedAt) && (DateTime.MinValue==AV36TFWorkflowConvenioCreatedAt_To) ) )
         {
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Created At", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV35TFWorkflowConvenioCreatedAt, "99/99/99 99:99"), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFWorkflowConvenioCreatedAt_To_Description = StringUtil.Format( "%1 (%2)", "Created At", "Até", "", "", "", "", "", "", "");
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFWorkflowConvenioCreatedAt_To_Description, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV36TFWorkflowConvenioCreatedAt_To, "99/99/99 99:99"), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV52TFWorkflowConvenioSLA) && (0==AV53TFWorkflowConvenioSLA_To) ) )
         {
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("SLA", 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV52TFWorkflowConvenioSLA), "ZZZ9")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV54TFWorkflowConvenioSLA_To_Description = StringUtil.Format( "%1 (%2)", "SLA", "Até", "", "", "", "", "", "", "");
            HCS0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFWorkflowConvenioSLA_To_Description, "")), 25, Gx_line+0, 159, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV53TFWorkflowConvenioSLA_To), "ZZZ9")), 159, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HCS0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HCS0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Passo", 30, Gx_line+10, 278, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 282, Gx_line+10, 530, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Created At", 534, Gx_line+10, 658, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("SLA", 662, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV59Workflowconveniowwds_1_filterfulltext = AV12FilterFullText;
         AV60Workflowconveniowwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV61Workflowconveniowwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV62Workflowconveniowwds_4_workflowconveniodesc1 = AV15WorkflowConvenioDesc1;
         AV63Workflowconveniowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV64Workflowconveniowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV65Workflowconveniowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV66Workflowconveniowwds_8_workflowconveniodesc2 = AV21WorkflowConvenioDesc2;
         AV67Workflowconveniowwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV68Workflowconveniowwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV69Workflowconveniowwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV70Workflowconveniowwds_12_workflowconveniodesc3 = AV25WorkflowConvenioDesc3;
         AV71Workflowconveniowwds_13_tfworkflowconveniodesc = AV32TFWorkflowConvenioDesc;
         AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV33TFWorkflowConvenioDesc_Sel;
         AV73Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV34TFWorkflowConvenioStatus_Sel;
         AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV35TFWorkflowConvenioCreatedAt;
         AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV36TFWorkflowConvenioCreatedAt_To;
         AV76Workflowconveniowwds_18_tfworkflowconveniosla = AV52TFWorkflowConvenioSLA;
         AV77Workflowconveniowwds_19_tfworkflowconveniosla_to = AV53TFWorkflowConvenioSLA_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV59Workflowconveniowwds_1_filterfulltext ,
                                              AV60Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                              AV61Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                              AV62Workflowconveniowwds_4_workflowconveniodesc1 ,
                                              AV63Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                              AV64Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                              AV65Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                              AV66Workflowconveniowwds_8_workflowconveniodesc2 ,
                                              AV67Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                              AV68Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                              AV69Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                              AV70Workflowconveniowwds_12_workflowconveniodesc3 ,
                                              AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                              AV71Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                              AV73Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                              AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                              AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                              AV76Workflowconveniowwds_18_tfworkflowconveniosla ,
                                              AV77Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                              A736WorkflowConvenioDesc ,
                                              A737WorkflowConvenioStatus ,
                                              A753WorkflowConvenioSLA ,
                                              A743WorkflowConvenioCreatedAt ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_1_filterfulltext), "%", "");
         lV59Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_1_filterfulltext), "%", "");
         lV59Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_1_filterfulltext), "%", "");
         lV59Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_1_filterfulltext), "%", "");
         lV62Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV62Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV62Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV62Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV66Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV66Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV66Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV66Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV70Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV70Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV70Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV70Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV71Workflowconveniowwds_13_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV71Workflowconveniowwds_13_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00CS2 */
         pr_default.execute(0, new Object[] {lV59Workflowconveniowwds_1_filterfulltext, lV59Workflowconveniowwds_1_filterfulltext, lV59Workflowconveniowwds_1_filterfulltext, lV59Workflowconveniowwds_1_filterfulltext, lV62Workflowconveniowwds_4_workflowconveniodesc1, lV62Workflowconveniowwds_4_workflowconveniodesc1, lV66Workflowconveniowwds_8_workflowconveniodesc2, lV66Workflowconveniowwds_8_workflowconveniodesc2, lV70Workflowconveniowwds_12_workflowconveniodesc3, lV70Workflowconveniowwds_12_workflowconveniodesc3, lV71Workflowconveniowwds_13_tfworkflowconveniodesc, AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel, AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat, AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to, AV76Workflowconveniowwds_18_tfworkflowconveniosla, AV77Workflowconveniowwds_19_tfworkflowconveniosla_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A753WorkflowConvenioSLA = P00CS2_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = P00CS2_n753WorkflowConvenioSLA[0];
            A743WorkflowConvenioCreatedAt = P00CS2_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = P00CS2_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = P00CS2_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = P00CS2_n737WorkflowConvenioStatus[0];
            A736WorkflowConvenioDesc = P00CS2_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00CS2_n736WorkflowConvenioDesc[0];
            A742WorkflowConvenioId = P00CS2_A742WorkflowConvenioId[0];
            AV27WorkflowConvenioStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A737WorkflowConvenioStatus)), "true") == 0 )
            {
               AV27WorkflowConvenioStatusDescription = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A737WorkflowConvenioStatus)), "false") == 0 )
            {
               AV27WorkflowConvenioStatusDescription = "Inativo";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HCS0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A736WorkflowConvenioDesc, "")), 30, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27WorkflowConvenioStatusDescription, "")), 282, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A743WorkflowConvenioCreatedAt, "99/99/99 99:99"), 534, Gx_line+10, 658, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A753WorkflowConvenioSLA), "ZZZ9")), 662, Gx_line+10, 787, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("WorkflowConvenioWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkflowConvenioWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WorkflowConvenioWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV78GXV1 = 1;
         while ( AV78GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV78GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV32TFWorkflowConvenioDesc = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV33TFWorkflowConvenioDesc_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSTATUS_SEL") == 0 )
            {
               AV34TFWorkflowConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOCREATEDAT") == 0 )
            {
               AV35TFWorkflowConvenioCreatedAt = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV36TFWorkflowConvenioCreatedAt_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSLA") == 0 )
            {
               AV52TFWorkflowConvenioSLA = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV53TFWorkflowConvenioSLA_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV78GXV1 = (int)(AV78GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void HCS0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV48PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV45DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+109, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+129);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV50Title = "";
         AV55Companyname = "";
         AV49Phone = "";
         AV47Mail = "";
         AV51Website = "";
         AV40AddressLine1 = "";
         AV41AddressLine2 = "";
         AV42AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15WorkflowConvenioDesc1 = "";
         AV16FilterWorkflowConvenioDescDescription = "";
         AV17WorkflowConvenioDesc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21WorkflowConvenioDesc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25WorkflowConvenioDesc3 = "";
         AV33TFWorkflowConvenioDesc_Sel = "";
         AV32TFWorkflowConvenioDesc = "";
         AV37FilterTFWorkflowConvenioStatus_SelValueDescription = "";
         AV35TFWorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         AV36TFWorkflowConvenioCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV38TFWorkflowConvenioCreatedAt_To_Description = "";
         AV54TFWorkflowConvenioSLA_To_Description = "";
         AV59Workflowconveniowwds_1_filterfulltext = "";
         AV60Workflowconveniowwds_2_dynamicfiltersselector1 = "";
         AV62Workflowconveniowwds_4_workflowconveniodesc1 = "";
         AV64Workflowconveniowwds_6_dynamicfiltersselector2 = "";
         AV66Workflowconveniowwds_8_workflowconveniodesc2 = "";
         AV68Workflowconveniowwds_10_dynamicfiltersselector3 = "";
         AV70Workflowconveniowwds_12_workflowconveniodesc3 = "";
         AV71Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel = "";
         AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat = (DateTime)(DateTime.MinValue);
         AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = (DateTime)(DateTime.MinValue);
         lV59Workflowconveniowwds_1_filterfulltext = "";
         lV62Workflowconveniowwds_4_workflowconveniodesc1 = "";
         lV66Workflowconveniowwds_8_workflowconveniodesc2 = "";
         lV70Workflowconveniowwds_12_workflowconveniodesc3 = "";
         lV71Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         A736WorkflowConvenioDesc = "";
         A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         P00CS2_A753WorkflowConvenioSLA = new short[1] ;
         P00CS2_n753WorkflowConvenioSLA = new bool[] {false} ;
         P00CS2_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CS2_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         P00CS2_A737WorkflowConvenioStatus = new bool[] {false} ;
         P00CS2_n737WorkflowConvenioStatus = new bool[] {false} ;
         P00CS2_A736WorkflowConvenioDesc = new string[] {""} ;
         P00CS2_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00CS2_A742WorkflowConvenioId = new int[1] ;
         AV27WorkflowConvenioStatusDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48PageInfo = "";
         AV45DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV43AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workflowconveniowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00CS2_A753WorkflowConvenioSLA, P00CS2_n753WorkflowConvenioSLA, P00CS2_A743WorkflowConvenioCreatedAt, P00CS2_n743WorkflowConvenioCreatedAt, P00CS2_A737WorkflowConvenioStatus, P00CS2_n737WorkflowConvenioStatus, P00CS2_A736WorkflowConvenioDesc, P00CS2_n736WorkflowConvenioDesc, P00CS2_A742WorkflowConvenioId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV34TFWorkflowConvenioStatus_Sel ;
      private short AV52TFWorkflowConvenioSLA ;
      private short AV53TFWorkflowConvenioSLA_To ;
      private short AV61Workflowconveniowwds_3_dynamicfiltersoperator1 ;
      private short AV65Workflowconveniowwds_7_dynamicfiltersoperator2 ;
      private short AV69Workflowconveniowwds_11_dynamicfiltersoperator3 ;
      private short AV73Workflowconveniowwds_15_tfworkflowconveniostatus_sel ;
      private short AV76Workflowconveniowwds_18_tfworkflowconveniosla ;
      private short AV77Workflowconveniowwds_19_tfworkflowconveniosla_to ;
      private short A753WorkflowConvenioSLA ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A742WorkflowConvenioId ;
      private int AV78GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime AV35TFWorkflowConvenioCreatedAt ;
      private DateTime AV36TFWorkflowConvenioCreatedAt_To ;
      private DateTime AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat ;
      private DateTime AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ;
      private DateTime A743WorkflowConvenioCreatedAt ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV39TempBoolean ;
      private bool AV63Workflowconveniowwds_5_dynamicfiltersenabled2 ;
      private bool AV67Workflowconveniowwds_9_dynamicfiltersenabled3 ;
      private bool A737WorkflowConvenioStatus ;
      private bool AV11OrderedDsc ;
      private bool n753WorkflowConvenioSLA ;
      private bool n743WorkflowConvenioCreatedAt ;
      private bool n737WorkflowConvenioStatus ;
      private bool n736WorkflowConvenioDesc ;
      private string AV55Companyname ;
      private string AV50Title ;
      private string AV49Phone ;
      private string AV47Mail ;
      private string AV51Website ;
      private string AV40AddressLine1 ;
      private string AV41AddressLine2 ;
      private string AV42AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15WorkflowConvenioDesc1 ;
      private string AV16FilterWorkflowConvenioDescDescription ;
      private string AV17WorkflowConvenioDesc ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21WorkflowConvenioDesc2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25WorkflowConvenioDesc3 ;
      private string AV33TFWorkflowConvenioDesc_Sel ;
      private string AV32TFWorkflowConvenioDesc ;
      private string AV37FilterTFWorkflowConvenioStatus_SelValueDescription ;
      private string AV38TFWorkflowConvenioCreatedAt_To_Description ;
      private string AV54TFWorkflowConvenioSLA_To_Description ;
      private string AV59Workflowconveniowwds_1_filterfulltext ;
      private string AV60Workflowconveniowwds_2_dynamicfiltersselector1 ;
      private string AV62Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string AV64Workflowconveniowwds_6_dynamicfiltersselector2 ;
      private string AV66Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string AV68Workflowconveniowwds_10_dynamicfiltersselector3 ;
      private string AV70Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string AV71Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel ;
      private string lV59Workflowconveniowwds_1_filterfulltext ;
      private string lV62Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string lV66Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string lV70Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string lV71Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string A736WorkflowConvenioDesc ;
      private string AV27WorkflowConvenioStatusDescription ;
      private string AV48PageInfo ;
      private string AV45DateInfo ;
      private string AV43AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00CS2_A753WorkflowConvenioSLA ;
      private bool[] P00CS2_n753WorkflowConvenioSLA ;
      private DateTime[] P00CS2_A743WorkflowConvenioCreatedAt ;
      private bool[] P00CS2_n743WorkflowConvenioCreatedAt ;
      private bool[] P00CS2_A737WorkflowConvenioStatus ;
      private bool[] P00CS2_n737WorkflowConvenioStatus ;
      private string[] P00CS2_A736WorkflowConvenioDesc ;
      private bool[] P00CS2_n736WorkflowConvenioDesc ;
      private int[] P00CS2_A742WorkflowConvenioId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class workflowconveniowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CS2( IGxContext context ,
                                             string AV59Workflowconveniowwds_1_filterfulltext ,
                                             string AV60Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                             short AV61Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV62Workflowconveniowwds_4_workflowconveniodesc1 ,
                                             bool AV63Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV64Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                             short AV65Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV66Workflowconveniowwds_8_workflowconveniodesc2 ,
                                             bool AV67Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV68Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                             short AV69Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV70Workflowconveniowwds_12_workflowconveniodesc3 ,
                                             string AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                             string AV71Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                             short AV73Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                             DateTime AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                             DateTime AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                             short AV76Workflowconveniowwds_18_tfworkflowconveniosla ,
                                             short AV77Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                             string A736WorkflowConvenioDesc ,
                                             bool A737WorkflowConvenioStatus ,
                                             short A753WorkflowConvenioSLA ,
                                             DateTime A743WorkflowConvenioCreatedAt ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[16];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT WorkflowConvenioSLA, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioId FROM WorkflowConvenio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workflowconveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WorkflowConvenioDesc like '%' || :lV59Workflowconveniowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV59Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV59Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = FALSE) or ( SUBSTR(TO_CHAR(WorkflowConvenioSLA,'9999'), 2) like '%' || :lV59Workflowconveniowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV61Workflowconveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV62Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV61Workflowconveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV62Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV63Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV65Workflowconveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV66Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV63Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV65Workflowconveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV66Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV67Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV69Workflowconveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV70Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV67Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV69Workflowconveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV70Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Workflowconveniowwds_13_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV71Workflowconveniowwds_13_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc = ( :AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from WorkflowConvenioDesc))=0))");
         }
         if ( AV73Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = TRUE)");
         }
         if ( AV73Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt >= :AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt <= :AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV76Workflowconveniowwds_18_tfworkflowconveniosla) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA >= :AV76Workflowconveniowwds_18_tfworkflowconveniosla)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (0==AV77Workflowconveniowwds_19_tfworkflowconveniosla_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA <= :AV77Workflowconveniowwds_19_tfworkflowconveniosla_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioDesc";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioDesc DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioStatus";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioStatus DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioCreatedAt";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioCreatedAt DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioSLA";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioSLA DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CS2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (short)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CS2;
          prmP00CS2 = new Object[] {
          new ParDef("lV59Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV62Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV66Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV66Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV70Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV70Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV71Workflowconveniowwds_13_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV72Workflowconveniowwds_14_tfworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV74Workflowconveniowwds_16_tfworkflowconveniocreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV75Workflowconveniowwds_17_tfworkflowconveniocreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV76Workflowconveniowwds_18_tfworkflowconveniosla",GXType.Int16,4,0) ,
          new ParDef("AV77Workflowconveniowwds_19_tfworkflowconveniosla_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CS2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
