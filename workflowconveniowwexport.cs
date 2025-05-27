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
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class workflowconveniowwexport : GXProcedure
   {
      public workflowconveniowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workflowconveniowwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13CellRow = 1;
         AV14FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S191 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV11Filename = GXt_char1 + "WorkflowConvenioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV18FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21WorkflowConvenioDesc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21WorkflowConvenioDesc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21WorkflowConvenioDesc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25WorkflowConvenioDesc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25WorkflowConvenioDesc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25WorkflowConvenioDesc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29WorkflowConvenioDesc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29WorkflowConvenioDesc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29WorkflowConvenioDesc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWorkflowConvenioDesc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Passo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWorkflowConvenioDesc_Sel)) ? "(Vazio)" : AV36TFWorkflowConvenioDesc_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWorkflowConvenioDesc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Passo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFWorkflowConvenioDesc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV37TFWorkflowConvenioStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV37TFWorkflowConvenioStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV37TFWorkflowConvenioStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (DateTime.MinValue==AV38TFWorkflowConvenioCreatedAt) && (DateTime.MinValue==AV39TFWorkflowConvenioCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Created At") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV38TFWorkflowConvenioCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV39TFWorkflowConvenioCreatedAt_To;
         }
         if ( ! ( (0==AV40TFWorkflowConvenioSLA) && (0==AV41TFWorkflowConvenioSLA_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "SLA") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV40TFWorkflowConvenioSLA;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV41TFWorkflowConvenioSLA_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Passo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Created At";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "SLA";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV43Workflowconveniowwds_1_filterfulltext = AV18FilterFullText;
         AV44Workflowconveniowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV45Workflowconveniowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV46Workflowconveniowwds_4_workflowconveniodesc1 = AV21WorkflowConvenioDesc1;
         AV47Workflowconveniowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV48Workflowconveniowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV49Workflowconveniowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV50Workflowconveniowwds_8_workflowconveniodesc2 = AV25WorkflowConvenioDesc2;
         AV51Workflowconveniowwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV52Workflowconveniowwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV53Workflowconveniowwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV54Workflowconveniowwds_12_workflowconveniodesc3 = AV29WorkflowConvenioDesc3;
         AV55Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV57Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV60Workflowconveniowwds_18_tfworkflowconveniosla = AV40TFWorkflowConvenioSLA;
         AV61Workflowconveniowwds_19_tfworkflowconveniosla_to = AV41TFWorkflowConvenioSLA_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Workflowconveniowwds_1_filterfulltext ,
                                              AV44Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                              AV45Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                              AV46Workflowconveniowwds_4_workflowconveniodesc1 ,
                                              AV47Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                              AV48Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                              AV49Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                              AV50Workflowconveniowwds_8_workflowconveniodesc2 ,
                                              AV51Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                              AV52Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                              AV53Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                              AV54Workflowconveniowwds_12_workflowconveniodesc3 ,
                                              AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                              AV55Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                              AV57Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                              AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                              AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                              AV60Workflowconveniowwds_18_tfworkflowconveniosla ,
                                              AV61Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                              A736WorkflowConvenioDesc ,
                                              A737WorkflowConvenioStatus ,
                                              A753WorkflowConvenioSLA ,
                                              A743WorkflowConvenioCreatedAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workflowconveniowwds_1_filterfulltext), "%", "");
         lV43Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workflowconveniowwds_1_filterfulltext), "%", "");
         lV43Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workflowconveniowwds_1_filterfulltext), "%", "");
         lV43Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workflowconveniowwds_1_filterfulltext), "%", "");
         lV46Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV46Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV46Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV46Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV50Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV50Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV50Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV50Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV54Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV54Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV54Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV54Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV55Workflowconveniowwds_13_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV55Workflowconveniowwds_13_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00CR2 */
         pr_default.execute(0, new Object[] {lV43Workflowconveniowwds_1_filterfulltext, lV43Workflowconveniowwds_1_filterfulltext, lV43Workflowconveniowwds_1_filterfulltext, lV43Workflowconveniowwds_1_filterfulltext, lV46Workflowconveniowwds_4_workflowconveniodesc1, lV46Workflowconveniowwds_4_workflowconveniodesc1, lV50Workflowconveniowwds_8_workflowconveniodesc2, lV50Workflowconveniowwds_8_workflowconveniodesc2, lV54Workflowconveniowwds_12_workflowconveniodesc3, lV54Workflowconveniowwds_12_workflowconveniodesc3, lV55Workflowconveniowwds_13_tfworkflowconveniodesc, AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel, AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat, AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to, AV60Workflowconveniowwds_18_tfworkflowconveniosla, AV61Workflowconveniowwds_19_tfworkflowconveniosla_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A753WorkflowConvenioSLA = P00CR2_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = P00CR2_n753WorkflowConvenioSLA[0];
            A743WorkflowConvenioCreatedAt = P00CR2_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = P00CR2_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = P00CR2_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = P00CR2_n737WorkflowConvenioStatus[0];
            A736WorkflowConvenioDesc = P00CR2_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00CR2_n736WorkflowConvenioDesc[0];
            A742WorkflowConvenioId = P00CR2_A742WorkflowConvenioId[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A736WorkflowConvenioDesc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A737WorkflowConvenioStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A737WorkflowConvenioStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
            }
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = A743WorkflowConvenioCreatedAt;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A753WorkflowConvenioSLA;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
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

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "WorkflowConvenioWWExport.xlsx");
         AV11Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("WorkflowConvenioWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkflowConvenioWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("WorkflowConvenioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV35TFWorkflowConvenioDesc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV36TFWorkflowConvenioDesc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSTATUS_SEL") == 0 )
            {
               AV37TFWorkflowConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOCREATEDAT") == 0 )
            {
               AV38TFWorkflowConvenioCreatedAt = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV39TFWorkflowConvenioCreatedAt_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSLA") == 0 )
            {
               AV40TFWorkflowConvenioSLA = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV41TFWorkflowConvenioSLA_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV18FilterFullText = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV21WorkflowConvenioDesc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25WorkflowConvenioDesc2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29WorkflowConvenioDesc3 = "";
         AV36TFWorkflowConvenioDesc_Sel = "";
         AV35TFWorkflowConvenioDesc = "";
         AV38TFWorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         AV39TFWorkflowConvenioCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV43Workflowconveniowwds_1_filterfulltext = "";
         AV44Workflowconveniowwds_2_dynamicfiltersselector1 = "";
         AV46Workflowconveniowwds_4_workflowconveniodesc1 = "";
         AV48Workflowconveniowwds_6_dynamicfiltersselector2 = "";
         AV50Workflowconveniowwds_8_workflowconveniodesc2 = "";
         AV52Workflowconveniowwds_10_dynamicfiltersselector3 = "";
         AV54Workflowconveniowwds_12_workflowconveniodesc3 = "";
         AV55Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel = "";
         AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat = (DateTime)(DateTime.MinValue);
         AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = (DateTime)(DateTime.MinValue);
         lV43Workflowconveniowwds_1_filterfulltext = "";
         lV46Workflowconveniowwds_4_workflowconveniodesc1 = "";
         lV50Workflowconveniowwds_8_workflowconveniodesc2 = "";
         lV54Workflowconveniowwds_12_workflowconveniodesc3 = "";
         lV55Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         A736WorkflowConvenioDesc = "";
         A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         P00CR2_A753WorkflowConvenioSLA = new short[1] ;
         P00CR2_n753WorkflowConvenioSLA = new bool[] {false} ;
         P00CR2_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CR2_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         P00CR2_A737WorkflowConvenioStatus = new bool[] {false} ;
         P00CR2_n737WorkflowConvenioStatus = new bool[] {false} ;
         P00CR2_A736WorkflowConvenioDesc = new string[] {""} ;
         P00CR2_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00CR2_A742WorkflowConvenioId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workflowconveniowwexport__default(),
            new Object[][] {
                new Object[] {
               P00CR2_A753WorkflowConvenioSLA, P00CR2_n753WorkflowConvenioSLA, P00CR2_A743WorkflowConvenioCreatedAt, P00CR2_n743WorkflowConvenioCreatedAt, P00CR2_A737WorkflowConvenioStatus, P00CR2_n737WorkflowConvenioStatus, P00CR2_A736WorkflowConvenioDesc, P00CR2_n736WorkflowConvenioDesc, P00CR2_A742WorkflowConvenioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV37TFWorkflowConvenioStatus_Sel ;
      private short AV40TFWorkflowConvenioSLA ;
      private short AV41TFWorkflowConvenioSLA_To ;
      private short GXt_int2 ;
      private short AV45Workflowconveniowwds_3_dynamicfiltersoperator1 ;
      private short AV49Workflowconveniowwds_7_dynamicfiltersoperator2 ;
      private short AV53Workflowconveniowwds_11_dynamicfiltersoperator3 ;
      private short AV57Workflowconveniowwds_15_tfworkflowconveniostatus_sel ;
      private short AV60Workflowconveniowwds_18_tfworkflowconveniosla ;
      private short AV61Workflowconveniowwds_19_tfworkflowconveniosla_to ;
      private short A753WorkflowConvenioSLA ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A742WorkflowConvenioId ;
      private int AV62GXV1 ;
      private string GXt_char1 ;
      private DateTime AV38TFWorkflowConvenioCreatedAt ;
      private DateTime AV39TFWorkflowConvenioCreatedAt_To ;
      private DateTime AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat ;
      private DateTime AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ;
      private DateTime A743WorkflowConvenioCreatedAt ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV47Workflowconveniowwds_5_dynamicfiltersenabled2 ;
      private bool AV51Workflowconveniowwds_9_dynamicfiltersenabled3 ;
      private bool A737WorkflowConvenioStatus ;
      private bool AV17OrderedDsc ;
      private bool n753WorkflowConvenioSLA ;
      private bool n743WorkflowConvenioCreatedAt ;
      private bool n737WorkflowConvenioStatus ;
      private bool n736WorkflowConvenioDesc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21WorkflowConvenioDesc1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25WorkflowConvenioDesc2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29WorkflowConvenioDesc3 ;
      private string AV36TFWorkflowConvenioDesc_Sel ;
      private string AV35TFWorkflowConvenioDesc ;
      private string AV43Workflowconveniowwds_1_filterfulltext ;
      private string AV44Workflowconveniowwds_2_dynamicfiltersselector1 ;
      private string AV46Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string AV48Workflowconveniowwds_6_dynamicfiltersselector2 ;
      private string AV50Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string AV52Workflowconveniowwds_10_dynamicfiltersselector3 ;
      private string AV54Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string AV55Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel ;
      private string lV43Workflowconveniowwds_1_filterfulltext ;
      private string lV46Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string lV50Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string lV54Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string lV55Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string A736WorkflowConvenioDesc ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00CR2_A753WorkflowConvenioSLA ;
      private bool[] P00CR2_n753WorkflowConvenioSLA ;
      private DateTime[] P00CR2_A743WorkflowConvenioCreatedAt ;
      private bool[] P00CR2_n743WorkflowConvenioCreatedAt ;
      private bool[] P00CR2_A737WorkflowConvenioStatus ;
      private bool[] P00CR2_n737WorkflowConvenioStatus ;
      private string[] P00CR2_A736WorkflowConvenioDesc ;
      private bool[] P00CR2_n736WorkflowConvenioDesc ;
      private int[] P00CR2_A742WorkflowConvenioId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class workflowconveniowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CR2( IGxContext context ,
                                             string AV43Workflowconveniowwds_1_filterfulltext ,
                                             string AV44Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                             short AV45Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV46Workflowconveniowwds_4_workflowconveniodesc1 ,
                                             bool AV47Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV48Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                             short AV49Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV50Workflowconveniowwds_8_workflowconveniodesc2 ,
                                             bool AV51Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV52Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                             short AV53Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV54Workflowconveniowwds_12_workflowconveniodesc3 ,
                                             string AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                             string AV55Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                             short AV57Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                             DateTime AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                             DateTime AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                             short AV60Workflowconveniowwds_18_tfworkflowconveniosla ,
                                             short AV61Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                             string A736WorkflowConvenioDesc ,
                                             bool A737WorkflowConvenioStatus ,
                                             short A753WorkflowConvenioSLA ,
                                             DateTime A743WorkflowConvenioCreatedAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT WorkflowConvenioSLA, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioId FROM WorkflowConvenio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Workflowconveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WorkflowConvenioDesc like '%' || :lV43Workflowconveniowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV43Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV43Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = FALSE) or ( SUBSTR(TO_CHAR(WorkflowConvenioSLA,'9999'), 2) like '%' || :lV43Workflowconveniowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV45Workflowconveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV46Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV45Workflowconveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV46Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV47Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV49Workflowconveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV50Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV47Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV49Workflowconveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV50Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV51Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV53Workflowconveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV54Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV51Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV53Workflowconveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV54Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workflowconveniowwds_13_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV55Workflowconveniowwds_13_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc = ( :AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from WorkflowConvenioDesc))=0))");
         }
         if ( AV57Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = TRUE)");
         }
         if ( AV57Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt >= :AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt <= :AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV60Workflowconveniowwds_18_tfworkflowconveniosla) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA >= :AV60Workflowconveniowwds_18_tfworkflowconveniosla)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV61Workflowconveniowwds_19_tfworkflowconveniosla_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA <= :AV61Workflowconveniowwds_19_tfworkflowconveniosla_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioDesc";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioDesc DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioStatus";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioStatus DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioCreatedAt";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WorkflowConvenioSLA";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WorkflowConvenioSLA DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CR2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (short)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00CR2;
          prmP00CR2 = new Object[] {
          new ParDef("lV43Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV46Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV50Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV50Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV54Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV54Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV55Workflowconveniowwds_13_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV56Workflowconveniowwds_14_tfworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV58Workflowconveniowwds_16_tfworkflowconveniocreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV59Workflowconveniowwds_17_tfworkflowconveniocreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV60Workflowconveniowwds_18_tfworkflowconveniosla",GXType.Int16,4,0) ,
          new ParDef("AV61Workflowconveniowwds_19_tfworkflowconveniosla_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR2,100, GxCacheFrequency.OFF ,true,false )
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
