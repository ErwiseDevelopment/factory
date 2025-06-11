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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class workflowconveniowwgetfilterdata : GXProcedure
   {
      public workflowconveniowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workflowconveniowwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_WORKFLOWCONVENIODESC") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKFLOWCONVENIODESCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("WorkflowConvenioWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkflowConvenioWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("WorkflowConvenioWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV10TFWorkflowConvenioDesc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV11TFWorkflowConvenioDesc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSTATUS_SEL") == 0 )
            {
               AV12TFWorkflowConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOCREATEDAT") == 0 )
            {
               AV13TFWorkflowConvenioCreatedAt = context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Value, 4);
               AV14TFWorkflowConvenioCreatedAt_To = context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSLA") == 0 )
            {
               AV49TFWorkflowConvenioSLA = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV50TFWorkflowConvenioSLA_To = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40WorkflowConvenioDesc1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44WorkflowConvenioDesc2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48WorkflowConvenioDesc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADWORKFLOWCONVENIODESCOPTIONS' Routine */
         returnInSub = false;
         AV10TFWorkflowConvenioDesc = AV15SearchTxt;
         AV11TFWorkflowConvenioDesc_Sel = "";
         AV53Workflowconveniowwds_1_filterfulltext = AV37FilterFullText;
         AV54Workflowconveniowwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV55Workflowconveniowwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV56Workflowconveniowwds_4_workflowconveniodesc1 = AV40WorkflowConvenioDesc1;
         AV57Workflowconveniowwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV58Workflowconveniowwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV59Workflowconveniowwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV60Workflowconveniowwds_8_workflowconveniodesc2 = AV44WorkflowConvenioDesc2;
         AV61Workflowconveniowwds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV62Workflowconveniowwds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV63Workflowconveniowwds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV64Workflowconveniowwds_12_workflowconveniodesc3 = AV48WorkflowConvenioDesc3;
         AV65Workflowconveniowwds_13_tfworkflowconveniodesc = AV10TFWorkflowConvenioDesc;
         AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV11TFWorkflowConvenioDesc_Sel;
         AV67Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV12TFWorkflowConvenioStatus_Sel;
         AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV13TFWorkflowConvenioCreatedAt;
         AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV14TFWorkflowConvenioCreatedAt_To;
         AV70Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV71Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Workflowconveniowwds_1_filterfulltext ,
                                              AV54Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                              AV55Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                              AV56Workflowconveniowwds_4_workflowconveniodesc1 ,
                                              AV57Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                              AV58Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                              AV59Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                              AV60Workflowconveniowwds_8_workflowconveniodesc2 ,
                                              AV61Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                              AV62Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                              AV63Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                              AV64Workflowconveniowwds_12_workflowconveniodesc3 ,
                                              AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                              AV65Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                              AV67Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                              AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                              AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                              AV70Workflowconveniowwds_18_tfworkflowconveniosla ,
                                              AV71Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                              A736WorkflowConvenioDesc ,
                                              A737WorkflowConvenioStatus ,
                                              A753WorkflowConvenioSLA ,
                                              A743WorkflowConvenioCreatedAt } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV53Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Workflowconveniowwds_1_filterfulltext), "%", "");
         lV53Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Workflowconveniowwds_1_filterfulltext), "%", "");
         lV53Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Workflowconveniowwds_1_filterfulltext), "%", "");
         lV53Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Workflowconveniowwds_1_filterfulltext), "%", "");
         lV56Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV56Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV56Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV56Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV60Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV60Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV60Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV60Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV64Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV64Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV64Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV64Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV65Workflowconveniowwds_13_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV65Workflowconveniowwds_13_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00CQ2 */
         pr_default.execute(0, new Object[] {lV53Workflowconveniowwds_1_filterfulltext, lV53Workflowconveniowwds_1_filterfulltext, lV53Workflowconveniowwds_1_filterfulltext, lV53Workflowconveniowwds_1_filterfulltext, lV56Workflowconveniowwds_4_workflowconveniodesc1, lV56Workflowconveniowwds_4_workflowconveniodesc1, lV60Workflowconveniowwds_8_workflowconveniodesc2, lV60Workflowconveniowwds_8_workflowconveniodesc2, lV64Workflowconveniowwds_12_workflowconveniodesc3, lV64Workflowconveniowwds_12_workflowconveniodesc3, lV65Workflowconveniowwds_13_tfworkflowconveniodesc, AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel, AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat, AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to, AV70Workflowconveniowwds_18_tfworkflowconveniosla, AV71Workflowconveniowwds_19_tfworkflowconveniosla_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCQ2 = false;
            A736WorkflowConvenioDesc = P00CQ2_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00CQ2_n736WorkflowConvenioDesc[0];
            A753WorkflowConvenioSLA = P00CQ2_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = P00CQ2_n753WorkflowConvenioSLA[0];
            A743WorkflowConvenioCreatedAt = P00CQ2_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = P00CQ2_n743WorkflowConvenioCreatedAt[0];
            A737WorkflowConvenioStatus = P00CQ2_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = P00CQ2_n737WorkflowConvenioStatus[0];
            A742WorkflowConvenioId = P00CQ2_A742WorkflowConvenioId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CQ2_A736WorkflowConvenioDesc[0], A736WorkflowConvenioDesc) == 0 ) )
            {
               BRKCQ2 = false;
               A742WorkflowConvenioId = P00CQ2_A742WorkflowConvenioId[0];
               AV25count = (long)(AV25count+1);
               BRKCQ2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) ? "<#Empty#>" : A736WorkflowConvenioDesc);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRKCQ2 )
            {
               BRKCQ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV10TFWorkflowConvenioDesc = "";
         AV11TFWorkflowConvenioDesc_Sel = "";
         AV13TFWorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         AV14TFWorkflowConvenioCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40WorkflowConvenioDesc1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44WorkflowConvenioDesc2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48WorkflowConvenioDesc3 = "";
         AV53Workflowconveniowwds_1_filterfulltext = "";
         AV54Workflowconveniowwds_2_dynamicfiltersselector1 = "";
         AV56Workflowconveniowwds_4_workflowconveniodesc1 = "";
         AV58Workflowconveniowwds_6_dynamicfiltersselector2 = "";
         AV60Workflowconveniowwds_8_workflowconveniodesc2 = "";
         AV62Workflowconveniowwds_10_dynamicfiltersselector3 = "";
         AV64Workflowconveniowwds_12_workflowconveniodesc3 = "";
         AV65Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel = "";
         AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat = (DateTime)(DateTime.MinValue);
         AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = (DateTime)(DateTime.MinValue);
         lV53Workflowconveniowwds_1_filterfulltext = "";
         lV56Workflowconveniowwds_4_workflowconveniodesc1 = "";
         lV60Workflowconveniowwds_8_workflowconveniodesc2 = "";
         lV64Workflowconveniowwds_12_workflowconveniodesc3 = "";
         lV65Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         A736WorkflowConvenioDesc = "";
         A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         P00CQ2_A736WorkflowConvenioDesc = new string[] {""} ;
         P00CQ2_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00CQ2_A753WorkflowConvenioSLA = new short[1] ;
         P00CQ2_n753WorkflowConvenioSLA = new bool[] {false} ;
         P00CQ2_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CQ2_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         P00CQ2_A737WorkflowConvenioStatus = new bool[] {false} ;
         P00CQ2_n737WorkflowConvenioStatus = new bool[] {false} ;
         P00CQ2_A742WorkflowConvenioId = new int[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workflowconveniowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CQ2_A736WorkflowConvenioDesc, P00CQ2_n736WorkflowConvenioDesc, P00CQ2_A753WorkflowConvenioSLA, P00CQ2_n753WorkflowConvenioSLA, P00CQ2_A743WorkflowConvenioCreatedAt, P00CQ2_n743WorkflowConvenioCreatedAt, P00CQ2_A737WorkflowConvenioStatus, P00CQ2_n737WorkflowConvenioStatus, P00CQ2_A742WorkflowConvenioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV12TFWorkflowConvenioStatus_Sel ;
      private short AV49TFWorkflowConvenioSLA ;
      private short AV50TFWorkflowConvenioSLA_To ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV55Workflowconveniowwds_3_dynamicfiltersoperator1 ;
      private short AV59Workflowconveniowwds_7_dynamicfiltersoperator2 ;
      private short AV63Workflowconveniowwds_11_dynamicfiltersoperator3 ;
      private short AV67Workflowconveniowwds_15_tfworkflowconveniostatus_sel ;
      private short AV70Workflowconveniowwds_18_tfworkflowconveniosla ;
      private short AV71Workflowconveniowwds_19_tfworkflowconveniosla_to ;
      private short A753WorkflowConvenioSLA ;
      private int AV51GXV1 ;
      private int A742WorkflowConvenioId ;
      private long AV25count ;
      private DateTime AV13TFWorkflowConvenioCreatedAt ;
      private DateTime AV14TFWorkflowConvenioCreatedAt_To ;
      private DateTime AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat ;
      private DateTime AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ;
      private DateTime A743WorkflowConvenioCreatedAt ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV57Workflowconveniowwds_5_dynamicfiltersenabled2 ;
      private bool AV61Workflowconveniowwds_9_dynamicfiltersenabled3 ;
      private bool A737WorkflowConvenioStatus ;
      private bool BRKCQ2 ;
      private bool n736WorkflowConvenioDesc ;
      private bool n753WorkflowConvenioSLA ;
      private bool n743WorkflowConvenioCreatedAt ;
      private bool n737WorkflowConvenioStatus ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV10TFWorkflowConvenioDesc ;
      private string AV11TFWorkflowConvenioDesc_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40WorkflowConvenioDesc1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44WorkflowConvenioDesc2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48WorkflowConvenioDesc3 ;
      private string AV53Workflowconveniowwds_1_filterfulltext ;
      private string AV54Workflowconveniowwds_2_dynamicfiltersselector1 ;
      private string AV56Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string AV58Workflowconveniowwds_6_dynamicfiltersselector2 ;
      private string AV60Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string AV62Workflowconveniowwds_10_dynamicfiltersselector3 ;
      private string AV64Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string AV65Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel ;
      private string lV53Workflowconveniowwds_1_filterfulltext ;
      private string lV56Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string lV60Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string lV64Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string lV65Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string A736WorkflowConvenioDesc ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00CQ2_A736WorkflowConvenioDesc ;
      private bool[] P00CQ2_n736WorkflowConvenioDesc ;
      private short[] P00CQ2_A753WorkflowConvenioSLA ;
      private bool[] P00CQ2_n753WorkflowConvenioSLA ;
      private DateTime[] P00CQ2_A743WorkflowConvenioCreatedAt ;
      private bool[] P00CQ2_n743WorkflowConvenioCreatedAt ;
      private bool[] P00CQ2_A737WorkflowConvenioStatus ;
      private bool[] P00CQ2_n737WorkflowConvenioStatus ;
      private int[] P00CQ2_A742WorkflowConvenioId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class workflowconveniowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CQ2( IGxContext context ,
                                             string AV53Workflowconveniowwds_1_filterfulltext ,
                                             string AV54Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                             short AV55Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Workflowconveniowwds_4_workflowconveniodesc1 ,
                                             bool AV57Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                             short AV59Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Workflowconveniowwds_8_workflowconveniodesc2 ,
                                             bool AV61Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                             short AV63Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Workflowconveniowwds_12_workflowconveniodesc3 ,
                                             string AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                             string AV65Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                             short AV67Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                             DateTime AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                             DateTime AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                             short AV70Workflowconveniowwds_18_tfworkflowconveniosla ,
                                             short AV71Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                             string A736WorkflowConvenioDesc ,
                                             bool A737WorkflowConvenioStatus ,
                                             short A753WorkflowConvenioSLA ,
                                             DateTime A743WorkflowConvenioCreatedAt )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WorkflowConvenioDesc, WorkflowConvenioSLA, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioId FROM WorkflowConvenio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Workflowconveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WorkflowConvenioDesc like '%' || :lV53Workflowconveniowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = FALSE) or ( SUBSTR(TO_CHAR(WorkflowConvenioSLA,'9999'), 2) like '%' || :lV53Workflowconveniowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV55Workflowconveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV56Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV55Workflowconveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV56Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV57Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV59Workflowconveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV60Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV57Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV59Workflowconveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV60Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV61Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV63Workflowconveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV64Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV61Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV63Workflowconveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV64Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workflowconveniowwds_13_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV65Workflowconveniowwds_13_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc = ( :AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from WorkflowConvenioDesc))=0))");
         }
         if ( AV67Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = TRUE)");
         }
         if ( AV67Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt >= :AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt <= :AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV70Workflowconveniowwds_18_tfworkflowconveniosla) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA >= :AV70Workflowconveniowwds_18_tfworkflowconveniosla)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV71Workflowconveniowwds_19_tfworkflowconveniosla_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA <= :AV71Workflowconveniowwds_19_tfworkflowconveniosla_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WorkflowConvenioDesc";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CQ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (short)dynConstraints[21] , (DateTime)dynConstraints[22] );
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
          Object[] prmP00CQ2;
          prmP00CQ2 = new Object[] {
          new ParDef("lV53Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV56Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV60Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV60Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV64Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV64Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV65Workflowconveniowwds_13_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV66Workflowconveniowwds_14_tfworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV68Workflowconveniowwds_16_tfworkflowconveniocreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV69Workflowconveniowwds_17_tfworkflowconveniocreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV70Workflowconveniowwds_18_tfworkflowconveniosla",GXType.Int16,4,0) ,
          new ParDef("AV71Workflowconveniowwds_19_tfworkflowconveniosla_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CQ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
