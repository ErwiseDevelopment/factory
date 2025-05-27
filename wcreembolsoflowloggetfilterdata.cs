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
   public class wcreembolsoflowloggetfilterdata : GXProcedure
   {
      public wcreembolsoflowloggetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcreembolsoflowloggetfilterdata( IGxContext context )
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
         this.AV52DDOName = aP0_DDOName;
         this.AV53SearchTxtParms = aP1_SearchTxtParms;
         this.AV54SearchTxtTo = aP2_SearchTxtTo;
         this.AV55OptionsJson = "" ;
         this.AV56OptionsDescJson = "" ;
         this.AV57OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV55OptionsJson;
         aP4_OptionsDescJson=this.AV56OptionsDescJson;
         aP5_OptionIndexesJson=this.AV57OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV57OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV52DDOName = aP0_DDOName;
         this.AV53SearchTxtParms = aP1_SearchTxtParms;
         this.AV54SearchTxtTo = aP2_SearchTxtTo;
         this.AV55OptionsJson = "" ;
         this.AV56OptionsDescJson = "" ;
         this.AV57OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV55OptionsJson;
         aP4_OptionsDescJson=this.AV56OptionsDescJson;
         aP5_OptionIndexesJson=this.AV57OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV42Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV44OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39MaxItems = 10;
         AV38PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV53SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV53SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV36SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV53SearchTxtParms)) ? "" : StringUtil.Substring( AV53SearchTxtParms, 3, -1));
         AV37SkipItems = (short)(AV38PageIndex*AV39MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_LOGWORKFLOWCONVENIODESC") == 0 )
         {
            /* Execute user subroutine: 'LOADLOGWORKFLOWCONVENIODESCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_REEMBOLSOLOGPROTOCOLO") == 0 )
         {
            /* Execute user subroutine: 'LOADREEMBOLSOLOGPROTOCOLOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV55OptionsJson = AV42Options.ToJSonString(false);
         AV56OptionsDescJson = AV44OptionsDesc.ToJSonString(false);
         AV57OptionIndexesJson = AV45OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV47Session.Get("WcReembolsoFlowLogGridState"), "") == 0 )
         {
            AV49GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcReembolsoFlowLogGridState"), null, "", "");
         }
         else
         {
            AV49GridState.FromXml(AV47Session.Get("WcReembolsoFlowLogGridState"), null, "", "");
         }
         AV86GXV1 = 1;
         while ( AV86GXV1 <= AV49GridState.gxTpr_Filtervalues.Count )
         {
            AV50GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV49GridState.gxTpr_Filtervalues.Item(AV86GXV1));
            if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV58FilterFullText = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV81TFReembolsoPropostaPacienteClienteRazaoSocial = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC") == 0 )
            {
               AV14TFLogWorkflowConvenioDesc = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV15TFLogWorkflowConvenioDesc_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOFLOWLOGDATE") == 0 )
            {
               AV20TFReembolsoFlowLogDate = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Value, 4);
               AV21TFReembolsoFlowLogDate_To = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFLOGREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV73TFLogReembolsoStatusAtual_F_SelsJson = AV50GridStateFilterValue.gxTpr_Value;
               AV74TFLogReembolsoStatusAtual_F_Sels.FromJSonString(AV73TFLogReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOFLOWLOGDATASLA_F") == 0 )
            {
               AV32TFReembolsoFlowLogDataSLA_F = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Value, 4);
               AV33TFReembolsoFlowLogDataSLA_F_To = context.localUtil.CToT( AV50GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOLOGPROTOCOLO") == 0 )
            {
               AV75TFReembolsoLogProtocolo = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOLOGPROTOCOLO_SEL") == 0 )
            {
               AV76TFReembolsoLogProtocolo_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            AV86GXV1 = (int)(AV86GXV1+1);
         }
         if ( AV49GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV51GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV49GridState.gxTpr_Dynamicfilters.Item(1));
            AV59DynamicFiltersSelector1 = AV51GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV59DynamicFiltersSelector1, "LOGWORKFLOWCONVENIODESC") == 0 )
            {
               AV60DynamicFiltersOperator1 = AV51GridStateDynamicFilter.gxTpr_Operator;
               AV61LogWorkflowConvenioDesc1 = AV51GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
            {
               AV60DynamicFiltersOperator1 = AV51GridStateDynamicFilter.gxTpr_Operator;
               AV62ReembolsoFlowLogUserNome1 = AV51GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector1, "REEMBOLSOPACIENTE") == 0 )
            {
               AV60DynamicFiltersOperator1 = AV51GridStateDynamicFilter.gxTpr_Operator;
               AV83ReembolsoPaciente1 = AV51GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV49GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV63DynamicFiltersEnabled2 = true;
               AV51GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV49GridState.gxTpr_Dynamicfilters.Item(2));
               AV64DynamicFiltersSelector2 = AV51GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV64DynamicFiltersSelector2, "LOGWORKFLOWCONVENIODESC") == 0 )
               {
                  AV65DynamicFiltersOperator2 = AV51GridStateDynamicFilter.gxTpr_Operator;
                  AV66LogWorkflowConvenioDesc2 = AV51GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV64DynamicFiltersSelector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
               {
                  AV65DynamicFiltersOperator2 = AV51GridStateDynamicFilter.gxTpr_Operator;
                  AV67ReembolsoFlowLogUserNome2 = AV51GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV64DynamicFiltersSelector2, "REEMBOLSOPACIENTE") == 0 )
               {
                  AV65DynamicFiltersOperator2 = AV51GridStateDynamicFilter.gxTpr_Operator;
                  AV84ReembolsoPaciente2 = AV51GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV49GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV68DynamicFiltersEnabled3 = true;
                  AV51GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV49GridState.gxTpr_Dynamicfilters.Item(3));
                  AV69DynamicFiltersSelector3 = AV51GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "LOGWORKFLOWCONVENIODESC") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV51GridStateDynamicFilter.gxTpr_Operator;
                     AV71LogWorkflowConvenioDesc3 = AV51GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV51GridStateDynamicFilter.gxTpr_Operator;
                     AV72ReembolsoFlowLogUserNome3 = AV51GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "REEMBOLSOPACIENTE") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV51GridStateDynamicFilter.gxTpr_Operator;
                     AV85ReembolsoPaciente3 = AV51GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV81TFReembolsoPropostaPacienteClienteRazaoSocial = AV36SearchTxt;
         AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV88Wcreembolsoflowlogds_1_filterfulltext = AV58FilterFullText;
         AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV59DynamicFiltersSelector1;
         AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV60DynamicFiltersOperator1;
         AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV61LogWorkflowConvenioDesc1;
         AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV62ReembolsoFlowLogUserNome1;
         AV93Wcreembolsoflowlogds_6_reembolsopaciente1 = AV83ReembolsoPaciente1;
         AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV63DynamicFiltersEnabled2;
         AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV64DynamicFiltersSelector2;
         AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV65DynamicFiltersOperator2;
         AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV66LogWorkflowConvenioDesc2;
         AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV67ReembolsoFlowLogUserNome2;
         AV99Wcreembolsoflowlogds_12_reembolsopaciente2 = AV84ReembolsoPaciente2;
         AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV68DynamicFiltersEnabled3;
         AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV69DynamicFiltersSelector3;
         AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV70DynamicFiltersOperator3;
         AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV71LogWorkflowConvenioDesc3;
         AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV72ReembolsoFlowLogUserNome3;
         AV105Wcreembolsoflowlogds_18_reembolsopaciente3 = AV85ReembolsoPaciente3;
         AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV81TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV14TFLogWorkflowConvenioDesc;
         AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV15TFLogWorkflowConvenioDesc_Sel;
         AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV20TFReembolsoFlowLogDate;
         AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV21TFReembolsoFlowLogDate_To;
         AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV74TFLogReembolsoStatusAtual_F_Sels;
         AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV32TFReembolsoFlowLogDataSLA_F;
         AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV33TFReembolsoFlowLogDataSLA_F_To;
         AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV75TFReembolsoLogProtocolo;
         AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV76TFReembolsoLogProtocolo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A760LogReembolsoStatusAtual_F ,
                                              AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                              AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                              AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                              AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                              AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                              AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                              AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                              AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                              AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                              AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                              AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                              AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                              AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                              AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                              AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                              AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                              AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                              AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                              AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                              AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                              AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                              AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                              AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                              AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                              AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                              AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A752LogWorkflowConvenioDesc ,
                                              A745ReembolsoFlowLogUserNome ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A747ReembolsoFlowLogDate ,
                                              A754ReembolsoWorkflowConvenioSLA ,
                                              A763ReembolsoLogProtocolo ,
                                              A758ReembolsoPropostaClinicaId ,
                                              AV88Wcreembolsoflowlogds_1_filterfulltext ,
                                              AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count ,
                                              A755ReembolsoFlowLogDataSLA_F ,
                                              A749ReembolsoWorkFlowConvenioId ,
                                              A750LogWorkflowConvenioId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc), "%", "");
         lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = StringUtil.Concat( StringUtil.RTrim( AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo), "%", "");
         /* Using cursor P00CU4 */
         pr_default.execute(0, new Object[] {AV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count, lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial, AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc, AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate, AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to, AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f, AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to, lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo, AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, AV9WWPContext.gxTpr_Secuserclienteid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCU2 = false;
            A744ReembolsoFlowLogUser = P00CU4_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = P00CU4_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = P00CU4_A748ReembolsoLogId[0];
            n748ReembolsoLogId = P00CU4_n748ReembolsoLogId[0];
            A542ReembolsoPropostaId = P00CU4_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00CU4_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00CU4_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00CU4_n558ReembolsoPropostaPacienteClienteId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU4_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU4_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A758ReembolsoPropostaClinicaId = P00CU4_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = P00CU4_n758ReembolsoPropostaClinicaId[0];
            A750LogWorkflowConvenioId = P00CU4_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = P00CU4_n750LogWorkflowConvenioId[0];
            A749ReembolsoWorkFlowConvenioId = P00CU4_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = P00CU4_n749ReembolsoWorkFlowConvenioId[0];
            A755ReembolsoFlowLogDataSLA_F = P00CU4_A755ReembolsoFlowLogDataSLA_F[0];
            A745ReembolsoFlowLogUserNome = P00CU4_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = P00CU4_n745ReembolsoFlowLogUserNome[0];
            A763ReembolsoLogProtocolo = P00CU4_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = P00CU4_n763ReembolsoLogProtocolo[0];
            A752LogWorkflowConvenioDesc = P00CU4_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CU4_n752LogWorkflowConvenioDesc[0];
            A747ReembolsoFlowLogDate = P00CU4_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = P00CU4_n747ReembolsoFlowLogDate[0];
            A754ReembolsoWorkflowConvenioSLA = P00CU4_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = P00CU4_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = P00CU4_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = P00CU4_n760LogReembolsoStatusAtual_F[0];
            A746ReembolsoFlowLogId = P00CU4_A746ReembolsoFlowLogId[0];
            A745ReembolsoFlowLogUserNome = P00CU4_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = P00CU4_n745ReembolsoFlowLogUserNome[0];
            A542ReembolsoPropostaId = P00CU4_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00CU4_n542ReembolsoPropostaId[0];
            A749ReembolsoWorkFlowConvenioId = P00CU4_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = P00CU4_n749ReembolsoWorkFlowConvenioId[0];
            A763ReembolsoLogProtocolo = P00CU4_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = P00CU4_n763ReembolsoLogProtocolo[0];
            A558ReembolsoPropostaPacienteClienteId = P00CU4_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00CU4_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = P00CU4_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = P00CU4_n758ReembolsoPropostaClinicaId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU4_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU4_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A754ReembolsoWorkflowConvenioSLA = P00CU4_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = P00CU4_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = P00CU4_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = P00CU4_n760LogReembolsoStatusAtual_F[0];
            A752LogWorkflowConvenioDesc = P00CU4_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CU4_n752LogWorkflowConvenioDesc[0];
            AV46count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CU4_A550ReembolsoPropostaPacienteClienteRazaoSocial[0], A550ReembolsoPropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRKCU2 = false;
               A748ReembolsoLogId = P00CU4_A748ReembolsoLogId[0];
               n748ReembolsoLogId = P00CU4_n748ReembolsoLogId[0];
               A542ReembolsoPropostaId = P00CU4_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = P00CU4_n542ReembolsoPropostaId[0];
               A558ReembolsoPropostaPacienteClienteId = P00CU4_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00CU4_n558ReembolsoPropostaPacienteClienteId[0];
               A746ReembolsoFlowLogId = P00CU4_A746ReembolsoFlowLogId[0];
               A542ReembolsoPropostaId = P00CU4_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = P00CU4_n542ReembolsoPropostaId[0];
               A558ReembolsoPropostaPacienteClienteId = P00CU4_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00CU4_n558ReembolsoPropostaPacienteClienteId[0];
               AV46count = (long)(AV46count+1);
               BRKCU2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV37SkipItems) )
            {
               AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A550ReembolsoPropostaPacienteClienteRazaoSocial)) ? "<#Empty#>" : A550ReembolsoPropostaPacienteClienteRazaoSocial);
               AV42Options.Add(AV41Option, 0);
               AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV42Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV37SkipItems = (short)(AV37SkipItems-1);
            }
            if ( ! BRKCU2 )
            {
               BRKCU2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLOGWORKFLOWCONVENIODESCOPTIONS' Routine */
         returnInSub = false;
         AV14TFLogWorkflowConvenioDesc = AV36SearchTxt;
         AV15TFLogWorkflowConvenioDesc_Sel = "";
         AV88Wcreembolsoflowlogds_1_filterfulltext = AV58FilterFullText;
         AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV59DynamicFiltersSelector1;
         AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV60DynamicFiltersOperator1;
         AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV61LogWorkflowConvenioDesc1;
         AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV62ReembolsoFlowLogUserNome1;
         AV93Wcreembolsoflowlogds_6_reembolsopaciente1 = AV83ReembolsoPaciente1;
         AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV63DynamicFiltersEnabled2;
         AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV64DynamicFiltersSelector2;
         AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV65DynamicFiltersOperator2;
         AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV66LogWorkflowConvenioDesc2;
         AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV67ReembolsoFlowLogUserNome2;
         AV99Wcreembolsoflowlogds_12_reembolsopaciente2 = AV84ReembolsoPaciente2;
         AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV68DynamicFiltersEnabled3;
         AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV69DynamicFiltersSelector3;
         AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV70DynamicFiltersOperator3;
         AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV71LogWorkflowConvenioDesc3;
         AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV72ReembolsoFlowLogUserNome3;
         AV105Wcreembolsoflowlogds_18_reembolsopaciente3 = AV85ReembolsoPaciente3;
         AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV81TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV14TFLogWorkflowConvenioDesc;
         AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV15TFLogWorkflowConvenioDesc_Sel;
         AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV20TFReembolsoFlowLogDate;
         AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV21TFReembolsoFlowLogDate_To;
         AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV74TFLogReembolsoStatusAtual_F_Sels;
         AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV32TFReembolsoFlowLogDataSLA_F;
         AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV33TFReembolsoFlowLogDataSLA_F_To;
         AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV75TFReembolsoLogProtocolo;
         AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV76TFReembolsoLogProtocolo_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A760LogReembolsoStatusAtual_F ,
                                              AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                              AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                              AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                              AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                              AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                              AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                              AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                              AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                              AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                              AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                              AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                              AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                              AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                              AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                              AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                              AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                              AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                              AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                              AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                              AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                              AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                              AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                              AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                              AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                              AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                              AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A752LogWorkflowConvenioDesc ,
                                              A745ReembolsoFlowLogUserNome ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A747ReembolsoFlowLogDate ,
                                              A754ReembolsoWorkflowConvenioSLA ,
                                              A763ReembolsoLogProtocolo ,
                                              A758ReembolsoPropostaClinicaId ,
                                              AV88Wcreembolsoflowlogds_1_filterfulltext ,
                                              AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count ,
                                              A755ReembolsoFlowLogDataSLA_F ,
                                              A749ReembolsoWorkFlowConvenioId ,
                                              A750LogWorkflowConvenioId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc), "%", "");
         lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = StringUtil.Concat( StringUtil.RTrim( AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo), "%", "");
         /* Using cursor P00CU7 */
         pr_default.execute(1, new Object[] {AV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count, lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial, AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc, AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate, AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to, AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f, AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to, lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo, AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, AV9WWPContext.gxTpr_Secuserclienteid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCU4 = false;
            A744ReembolsoFlowLogUser = P00CU7_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = P00CU7_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = P00CU7_A748ReembolsoLogId[0];
            n748ReembolsoLogId = P00CU7_n748ReembolsoLogId[0];
            A542ReembolsoPropostaId = P00CU7_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00CU7_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00CU7_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00CU7_n558ReembolsoPropostaPacienteClienteId[0];
            A750LogWorkflowConvenioId = P00CU7_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = P00CU7_n750LogWorkflowConvenioId[0];
            A758ReembolsoPropostaClinicaId = P00CU7_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = P00CU7_n758ReembolsoPropostaClinicaId[0];
            A749ReembolsoWorkFlowConvenioId = P00CU7_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = P00CU7_n749ReembolsoWorkFlowConvenioId[0];
            A755ReembolsoFlowLogDataSLA_F = P00CU7_A755ReembolsoFlowLogDataSLA_F[0];
            A745ReembolsoFlowLogUserNome = P00CU7_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = P00CU7_n745ReembolsoFlowLogUserNome[0];
            A763ReembolsoLogProtocolo = P00CU7_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = P00CU7_n763ReembolsoLogProtocolo[0];
            A752LogWorkflowConvenioDesc = P00CU7_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CU7_n752LogWorkflowConvenioDesc[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU7_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU7_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A747ReembolsoFlowLogDate = P00CU7_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = P00CU7_n747ReembolsoFlowLogDate[0];
            A754ReembolsoWorkflowConvenioSLA = P00CU7_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = P00CU7_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = P00CU7_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = P00CU7_n760LogReembolsoStatusAtual_F[0];
            A746ReembolsoFlowLogId = P00CU7_A746ReembolsoFlowLogId[0];
            A745ReembolsoFlowLogUserNome = P00CU7_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = P00CU7_n745ReembolsoFlowLogUserNome[0];
            A542ReembolsoPropostaId = P00CU7_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00CU7_n542ReembolsoPropostaId[0];
            A749ReembolsoWorkFlowConvenioId = P00CU7_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = P00CU7_n749ReembolsoWorkFlowConvenioId[0];
            A763ReembolsoLogProtocolo = P00CU7_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = P00CU7_n763ReembolsoLogProtocolo[0];
            A558ReembolsoPropostaPacienteClienteId = P00CU7_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00CU7_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = P00CU7_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = P00CU7_n758ReembolsoPropostaClinicaId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU7_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU7_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A754ReembolsoWorkflowConvenioSLA = P00CU7_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = P00CU7_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = P00CU7_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = P00CU7_n760LogReembolsoStatusAtual_F[0];
            A752LogWorkflowConvenioDesc = P00CU7_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CU7_n752LogWorkflowConvenioDesc[0];
            AV46count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00CU7_A750LogWorkflowConvenioId[0] == A750LogWorkflowConvenioId ) )
            {
               BRKCU4 = false;
               A746ReembolsoFlowLogId = P00CU7_A746ReembolsoFlowLogId[0];
               AV46count = (long)(AV46count+1);
               BRKCU4 = true;
               pr_default.readNext(1);
            }
            AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A752LogWorkflowConvenioDesc)) ? "<#Empty#>" : A752LogWorkflowConvenioDesc);
            AV40InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV41Option, "<#Empty#>") != 0 ) && ( AV40InsertIndex <= AV42Options.Count ) && ( ( StringUtil.StrCmp(((string)AV42Options.Item(AV40InsertIndex)), AV41Option) < 0 ) || ( StringUtil.StrCmp(((string)AV42Options.Item(AV40InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV40InsertIndex = (int)(AV40InsertIndex+1);
            }
            AV42Options.Add(AV41Option, AV40InsertIndex);
            AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), AV40InsertIndex);
            if ( AV42Options.Count == AV37SkipItems + 11 )
            {
               AV42Options.RemoveItem(AV42Options.Count);
               AV45OptionIndexes.RemoveItem(AV45OptionIndexes.Count);
            }
            if ( ! BRKCU4 )
            {
               BRKCU4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV37SkipItems > 0 )
         {
            AV42Options.RemoveItem(1);
            AV45OptionIndexes.RemoveItem(1);
            AV37SkipItems = (short)(AV37SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADREEMBOLSOLOGPROTOCOLOOPTIONS' Routine */
         returnInSub = false;
         AV75TFReembolsoLogProtocolo = AV36SearchTxt;
         AV76TFReembolsoLogProtocolo_Sel = "";
         AV88Wcreembolsoflowlogds_1_filterfulltext = AV58FilterFullText;
         AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV59DynamicFiltersSelector1;
         AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV60DynamicFiltersOperator1;
         AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV61LogWorkflowConvenioDesc1;
         AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV62ReembolsoFlowLogUserNome1;
         AV93Wcreembolsoflowlogds_6_reembolsopaciente1 = AV83ReembolsoPaciente1;
         AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV63DynamicFiltersEnabled2;
         AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV64DynamicFiltersSelector2;
         AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV65DynamicFiltersOperator2;
         AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV66LogWorkflowConvenioDesc2;
         AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV67ReembolsoFlowLogUserNome2;
         AV99Wcreembolsoflowlogds_12_reembolsopaciente2 = AV84ReembolsoPaciente2;
         AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV68DynamicFiltersEnabled3;
         AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV69DynamicFiltersSelector3;
         AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV70DynamicFiltersOperator3;
         AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV71LogWorkflowConvenioDesc3;
         AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV72ReembolsoFlowLogUserNome3;
         AV105Wcreembolsoflowlogds_18_reembolsopaciente3 = AV85ReembolsoPaciente3;
         AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV81TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV14TFLogWorkflowConvenioDesc;
         AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV15TFLogWorkflowConvenioDesc_Sel;
         AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV20TFReembolsoFlowLogDate;
         AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV21TFReembolsoFlowLogDate_To;
         AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV74TFLogReembolsoStatusAtual_F_Sels;
         AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV32TFReembolsoFlowLogDataSLA_F;
         AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV33TFReembolsoFlowLogDataSLA_F_To;
         AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV75TFReembolsoLogProtocolo;
         AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV76TFReembolsoLogProtocolo_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A760LogReembolsoStatusAtual_F ,
                                              AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                              AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                              AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                              AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                              AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                              AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                              AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                              AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                              AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                              AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                              AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                              AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                              AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                              AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                              AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                              AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                              AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                              AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                              AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                              AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                              AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                              AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                              AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                              AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                              AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                              AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A752LogWorkflowConvenioDesc ,
                                              A745ReembolsoFlowLogUserNome ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A747ReembolsoFlowLogDate ,
                                              A754ReembolsoWorkflowConvenioSLA ,
                                              A763ReembolsoLogProtocolo ,
                                              A758ReembolsoPropostaClinicaId ,
                                              AV88Wcreembolsoflowlogds_1_filterfulltext ,
                                              AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count ,
                                              A755ReembolsoFlowLogDataSLA_F ,
                                              A749ReembolsoWorkFlowConvenioId ,
                                              A750LogWorkflowConvenioId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV88Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc), "%", "");
         lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = StringUtil.Concat( StringUtil.RTrim( AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo), "%", "");
         /* Using cursor P00CU10 */
         pr_default.execute(2, new Object[] {AV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, lV88Wcreembolsoflowlogds_1_filterfulltext, AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count, lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial, AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc, AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate, AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to, AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f, AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to, lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo, AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, AV9WWPContext.gxTpr_Secuserclienteid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKCU6 = false;
            A744ReembolsoFlowLogUser = P00CU10_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = P00CU10_n744ReembolsoFlowLogUser[0];
            A748ReembolsoLogId = P00CU10_A748ReembolsoLogId[0];
            n748ReembolsoLogId = P00CU10_n748ReembolsoLogId[0];
            A542ReembolsoPropostaId = P00CU10_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00CU10_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00CU10_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00CU10_n558ReembolsoPropostaPacienteClienteId[0];
            A763ReembolsoLogProtocolo = P00CU10_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = P00CU10_n763ReembolsoLogProtocolo[0];
            A758ReembolsoPropostaClinicaId = P00CU10_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = P00CU10_n758ReembolsoPropostaClinicaId[0];
            A750LogWorkflowConvenioId = P00CU10_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = P00CU10_n750LogWorkflowConvenioId[0];
            A749ReembolsoWorkFlowConvenioId = P00CU10_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = P00CU10_n749ReembolsoWorkFlowConvenioId[0];
            A755ReembolsoFlowLogDataSLA_F = P00CU10_A755ReembolsoFlowLogDataSLA_F[0];
            A745ReembolsoFlowLogUserNome = P00CU10_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = P00CU10_n745ReembolsoFlowLogUserNome[0];
            A752LogWorkflowConvenioDesc = P00CU10_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CU10_n752LogWorkflowConvenioDesc[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU10_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU10_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A747ReembolsoFlowLogDate = P00CU10_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = P00CU10_n747ReembolsoFlowLogDate[0];
            A754ReembolsoWorkflowConvenioSLA = P00CU10_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = P00CU10_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = P00CU10_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = P00CU10_n760LogReembolsoStatusAtual_F[0];
            A746ReembolsoFlowLogId = P00CU10_A746ReembolsoFlowLogId[0];
            A745ReembolsoFlowLogUserNome = P00CU10_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = P00CU10_n745ReembolsoFlowLogUserNome[0];
            A542ReembolsoPropostaId = P00CU10_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00CU10_n542ReembolsoPropostaId[0];
            A763ReembolsoLogProtocolo = P00CU10_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = P00CU10_n763ReembolsoLogProtocolo[0];
            A749ReembolsoWorkFlowConvenioId = P00CU10_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = P00CU10_n749ReembolsoWorkFlowConvenioId[0];
            A558ReembolsoPropostaPacienteClienteId = P00CU10_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00CU10_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = P00CU10_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = P00CU10_n758ReembolsoPropostaClinicaId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU10_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CU10_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A754ReembolsoWorkflowConvenioSLA = P00CU10_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = P00CU10_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = P00CU10_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = P00CU10_n760LogReembolsoStatusAtual_F[0];
            A752LogWorkflowConvenioDesc = P00CU10_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = P00CU10_n752LogWorkflowConvenioDesc[0];
            AV46count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00CU10_A763ReembolsoLogProtocolo[0], A763ReembolsoLogProtocolo) == 0 ) )
            {
               BRKCU6 = false;
               A748ReembolsoLogId = P00CU10_A748ReembolsoLogId[0];
               n748ReembolsoLogId = P00CU10_n748ReembolsoLogId[0];
               A746ReembolsoFlowLogId = P00CU10_A746ReembolsoFlowLogId[0];
               AV46count = (long)(AV46count+1);
               BRKCU6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV37SkipItems) )
            {
               AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A763ReembolsoLogProtocolo)) ? "<#Empty#>" : A763ReembolsoLogProtocolo);
               AV42Options.Add(AV41Option, 0);
               AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV42Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV37SkipItems = (short)(AV37SkipItems-1);
            }
            if ( ! BRKCU6 )
            {
               BRKCU6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV55OptionsJson = "";
         AV56OptionsDescJson = "";
         AV57OptionIndexesJson = "";
         AV42Options = new GxSimpleCollection<string>();
         AV44OptionsDesc = new GxSimpleCollection<string>();
         AV45OptionIndexes = new GxSimpleCollection<string>();
         AV36SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Session = context.GetSession();
         AV49GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV50GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV58FilterFullText = "";
         AV81TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV14TFLogWorkflowConvenioDesc = "";
         AV15TFLogWorkflowConvenioDesc_Sel = "";
         AV20TFReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         AV21TFReembolsoFlowLogDate_To = (DateTime)(DateTime.MinValue);
         AV73TFLogReembolsoStatusAtual_F_SelsJson = "";
         AV74TFLogReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV32TFReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         AV33TFReembolsoFlowLogDataSLA_F_To = (DateTime)(DateTime.MinValue);
         AV75TFReembolsoLogProtocolo = "";
         AV76TFReembolsoLogProtocolo_Sel = "";
         AV51GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV59DynamicFiltersSelector1 = "";
         AV61LogWorkflowConvenioDesc1 = "";
         AV62ReembolsoFlowLogUserNome1 = "";
         AV83ReembolsoPaciente1 = "";
         AV64DynamicFiltersSelector2 = "";
         AV66LogWorkflowConvenioDesc2 = "";
         AV67ReembolsoFlowLogUserNome2 = "";
         AV84ReembolsoPaciente2 = "";
         AV69DynamicFiltersSelector3 = "";
         AV71LogWorkflowConvenioDesc3 = "";
         AV72ReembolsoFlowLogUserNome3 = "";
         AV85ReembolsoPaciente3 = "";
         AV88Wcreembolsoflowlogds_1_filterfulltext = "";
         AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 = "";
         AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = "";
         AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = "";
         AV93Wcreembolsoflowlogds_6_reembolsopaciente1 = "";
         AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 = "";
         AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = "";
         AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = "";
         AV99Wcreembolsoflowlogds_12_reembolsopaciente2 = "";
         AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 = "";
         AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = "";
         AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = "";
         AV105Wcreembolsoflowlogds_18_reembolsopaciente3 = "";
         AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = "";
         AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = "";
         AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = "";
         AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = "";
         AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = (DateTime)(DateTime.MinValue);
         AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = (DateTime)(DateTime.MinValue);
         AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = (DateTime)(DateTime.MinValue);
         AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = (DateTime)(DateTime.MinValue);
         AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = "";
         AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = "";
         lV88Wcreembolsoflowlogds_1_filterfulltext = "";
         lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = "";
         lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = "";
         lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = "";
         lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = "";
         lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = "";
         lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = "";
         lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = "";
         lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = "";
         lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo = "";
         A760LogReembolsoStatusAtual_F = "";
         A752LogWorkflowConvenioDesc = "";
         A745ReembolsoFlowLogUserNome = "";
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         A763ReembolsoLogProtocolo = "";
         A755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         P00CU4_A744ReembolsoFlowLogUser = new short[1] ;
         P00CU4_n744ReembolsoFlowLogUser = new bool[] {false} ;
         P00CU4_A748ReembolsoLogId = new int[1] ;
         P00CU4_n748ReembolsoLogId = new bool[] {false} ;
         P00CU4_A542ReembolsoPropostaId = new int[1] ;
         P00CU4_n542ReembolsoPropostaId = new bool[] {false} ;
         P00CU4_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00CU4_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00CU4_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00CU4_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00CU4_A758ReembolsoPropostaClinicaId = new int[1] ;
         P00CU4_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         P00CU4_A750LogWorkflowConvenioId = new int[1] ;
         P00CU4_n750LogWorkflowConvenioId = new bool[] {false} ;
         P00CU4_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         P00CU4_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         P00CU4_A755ReembolsoFlowLogDataSLA_F = new DateTime[] {DateTime.MinValue} ;
         P00CU4_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         P00CU4_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         P00CU4_A763ReembolsoLogProtocolo = new string[] {""} ;
         P00CU4_n763ReembolsoLogProtocolo = new bool[] {false} ;
         P00CU4_A752LogWorkflowConvenioDesc = new string[] {""} ;
         P00CU4_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         P00CU4_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CU4_n747ReembolsoFlowLogDate = new bool[] {false} ;
         P00CU4_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         P00CU4_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         P00CU4_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         P00CU4_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         P00CU4_A746ReembolsoFlowLogId = new int[1] ;
         AV41Option = "";
         P00CU7_A744ReembolsoFlowLogUser = new short[1] ;
         P00CU7_n744ReembolsoFlowLogUser = new bool[] {false} ;
         P00CU7_A748ReembolsoLogId = new int[1] ;
         P00CU7_n748ReembolsoLogId = new bool[] {false} ;
         P00CU7_A542ReembolsoPropostaId = new int[1] ;
         P00CU7_n542ReembolsoPropostaId = new bool[] {false} ;
         P00CU7_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00CU7_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00CU7_A750LogWorkflowConvenioId = new int[1] ;
         P00CU7_n750LogWorkflowConvenioId = new bool[] {false} ;
         P00CU7_A758ReembolsoPropostaClinicaId = new int[1] ;
         P00CU7_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         P00CU7_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         P00CU7_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         P00CU7_A755ReembolsoFlowLogDataSLA_F = new DateTime[] {DateTime.MinValue} ;
         P00CU7_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         P00CU7_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         P00CU7_A763ReembolsoLogProtocolo = new string[] {""} ;
         P00CU7_n763ReembolsoLogProtocolo = new bool[] {false} ;
         P00CU7_A752LogWorkflowConvenioDesc = new string[] {""} ;
         P00CU7_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         P00CU7_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00CU7_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00CU7_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CU7_n747ReembolsoFlowLogDate = new bool[] {false} ;
         P00CU7_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         P00CU7_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         P00CU7_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         P00CU7_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         P00CU7_A746ReembolsoFlowLogId = new int[1] ;
         P00CU10_A744ReembolsoFlowLogUser = new short[1] ;
         P00CU10_n744ReembolsoFlowLogUser = new bool[] {false} ;
         P00CU10_A748ReembolsoLogId = new int[1] ;
         P00CU10_n748ReembolsoLogId = new bool[] {false} ;
         P00CU10_A542ReembolsoPropostaId = new int[1] ;
         P00CU10_n542ReembolsoPropostaId = new bool[] {false} ;
         P00CU10_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00CU10_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00CU10_A763ReembolsoLogProtocolo = new string[] {""} ;
         P00CU10_n763ReembolsoLogProtocolo = new bool[] {false} ;
         P00CU10_A758ReembolsoPropostaClinicaId = new int[1] ;
         P00CU10_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         P00CU10_A750LogWorkflowConvenioId = new int[1] ;
         P00CU10_n750LogWorkflowConvenioId = new bool[] {false} ;
         P00CU10_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         P00CU10_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         P00CU10_A755ReembolsoFlowLogDataSLA_F = new DateTime[] {DateTime.MinValue} ;
         P00CU10_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         P00CU10_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         P00CU10_A752LogWorkflowConvenioDesc = new string[] {""} ;
         P00CU10_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         P00CU10_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00CU10_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00CU10_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         P00CU10_n747ReembolsoFlowLogDate = new bool[] {false} ;
         P00CU10_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         P00CU10_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         P00CU10_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         P00CU10_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         P00CU10_A746ReembolsoFlowLogId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcreembolsoflowloggetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CU4_A744ReembolsoFlowLogUser, P00CU4_n744ReembolsoFlowLogUser, P00CU4_A748ReembolsoLogId, P00CU4_n748ReembolsoLogId, P00CU4_A542ReembolsoPropostaId, P00CU4_n542ReembolsoPropostaId, P00CU4_A558ReembolsoPropostaPacienteClienteId, P00CU4_n558ReembolsoPropostaPacienteClienteId, P00CU4_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00CU4_n550ReembolsoPropostaPacienteClienteRazaoSocial,
               P00CU4_A758ReembolsoPropostaClinicaId, P00CU4_n758ReembolsoPropostaClinicaId, P00CU4_A750LogWorkflowConvenioId, P00CU4_n750LogWorkflowConvenioId, P00CU4_A749ReembolsoWorkFlowConvenioId, P00CU4_n749ReembolsoWorkFlowConvenioId, P00CU4_A755ReembolsoFlowLogDataSLA_F, P00CU4_A745ReembolsoFlowLogUserNome, P00CU4_n745ReembolsoFlowLogUserNome, P00CU4_A763ReembolsoLogProtocolo,
               P00CU4_n763ReembolsoLogProtocolo, P00CU4_A752LogWorkflowConvenioDesc, P00CU4_n752LogWorkflowConvenioDesc, P00CU4_A747ReembolsoFlowLogDate, P00CU4_n747ReembolsoFlowLogDate, P00CU4_A754ReembolsoWorkflowConvenioSLA, P00CU4_n754ReembolsoWorkflowConvenioSLA, P00CU4_A760LogReembolsoStatusAtual_F, P00CU4_n760LogReembolsoStatusAtual_F, P00CU4_A746ReembolsoFlowLogId
               }
               , new Object[] {
               P00CU7_A744ReembolsoFlowLogUser, P00CU7_n744ReembolsoFlowLogUser, P00CU7_A748ReembolsoLogId, P00CU7_n748ReembolsoLogId, P00CU7_A542ReembolsoPropostaId, P00CU7_n542ReembolsoPropostaId, P00CU7_A558ReembolsoPropostaPacienteClienteId, P00CU7_n558ReembolsoPropostaPacienteClienteId, P00CU7_A750LogWorkflowConvenioId, P00CU7_n750LogWorkflowConvenioId,
               P00CU7_A758ReembolsoPropostaClinicaId, P00CU7_n758ReembolsoPropostaClinicaId, P00CU7_A749ReembolsoWorkFlowConvenioId, P00CU7_n749ReembolsoWorkFlowConvenioId, P00CU7_A755ReembolsoFlowLogDataSLA_F, P00CU7_A745ReembolsoFlowLogUserNome, P00CU7_n745ReembolsoFlowLogUserNome, P00CU7_A763ReembolsoLogProtocolo, P00CU7_n763ReembolsoLogProtocolo, P00CU7_A752LogWorkflowConvenioDesc,
               P00CU7_n752LogWorkflowConvenioDesc, P00CU7_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00CU7_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00CU7_A747ReembolsoFlowLogDate, P00CU7_n747ReembolsoFlowLogDate, P00CU7_A754ReembolsoWorkflowConvenioSLA, P00CU7_n754ReembolsoWorkflowConvenioSLA, P00CU7_A760LogReembolsoStatusAtual_F, P00CU7_n760LogReembolsoStatusAtual_F, P00CU7_A746ReembolsoFlowLogId
               }
               , new Object[] {
               P00CU10_A744ReembolsoFlowLogUser, P00CU10_n744ReembolsoFlowLogUser, P00CU10_A748ReembolsoLogId, P00CU10_n748ReembolsoLogId, P00CU10_A542ReembolsoPropostaId, P00CU10_n542ReembolsoPropostaId, P00CU10_A558ReembolsoPropostaPacienteClienteId, P00CU10_n558ReembolsoPropostaPacienteClienteId, P00CU10_A763ReembolsoLogProtocolo, P00CU10_n763ReembolsoLogProtocolo,
               P00CU10_A758ReembolsoPropostaClinicaId, P00CU10_n758ReembolsoPropostaClinicaId, P00CU10_A750LogWorkflowConvenioId, P00CU10_n750LogWorkflowConvenioId, P00CU10_A749ReembolsoWorkFlowConvenioId, P00CU10_n749ReembolsoWorkFlowConvenioId, P00CU10_A755ReembolsoFlowLogDataSLA_F, P00CU10_A745ReembolsoFlowLogUserNome, P00CU10_n745ReembolsoFlowLogUserNome, P00CU10_A752LogWorkflowConvenioDesc,
               P00CU10_n752LogWorkflowConvenioDesc, P00CU10_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00CU10_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00CU10_A747ReembolsoFlowLogDate, P00CU10_n747ReembolsoFlowLogDate, P00CU10_A754ReembolsoWorkflowConvenioSLA, P00CU10_n754ReembolsoWorkflowConvenioSLA, P00CU10_A760LogReembolsoStatusAtual_F, P00CU10_n760LogReembolsoStatusAtual_F, P00CU10_A746ReembolsoFlowLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV39MaxItems ;
      private short AV38PageIndex ;
      private short AV37SkipItems ;
      private short AV60DynamicFiltersOperator1 ;
      private short AV65DynamicFiltersOperator2 ;
      private short AV70DynamicFiltersOperator3 ;
      private short AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ;
      private short AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ;
      private short AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A754ReembolsoWorkflowConvenioSLA ;
      private short A744ReembolsoFlowLogUser ;
      private int AV86GXV1 ;
      private int AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ;
      private int A758ReembolsoPropostaClinicaId ;
      private int A749ReembolsoWorkFlowConvenioId ;
      private int A750LogWorkflowConvenioId ;
      private int A748ReembolsoLogId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A746ReembolsoFlowLogId ;
      private int AV40InsertIndex ;
      private long AV46count ;
      private DateTime AV20TFReembolsoFlowLogDate ;
      private DateTime AV21TFReembolsoFlowLogDate_To ;
      private DateTime AV32TFReembolsoFlowLogDataSLA_F ;
      private DateTime AV33TFReembolsoFlowLogDataSLA_F_To ;
      private DateTime AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ;
      private DateTime AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ;
      private DateTime AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ;
      private DateTime AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ;
      private DateTime A747ReembolsoFlowLogDate ;
      private DateTime A755ReembolsoFlowLogDataSLA_F ;
      private bool returnInSub ;
      private bool AV63DynamicFiltersEnabled2 ;
      private bool AV68DynamicFiltersEnabled3 ;
      private bool AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ;
      private bool AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ;
      private bool BRKCU2 ;
      private bool n744ReembolsoFlowLogUser ;
      private bool n748ReembolsoLogId ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n758ReembolsoPropostaClinicaId ;
      private bool n750LogWorkflowConvenioId ;
      private bool n749ReembolsoWorkFlowConvenioId ;
      private bool n745ReembolsoFlowLogUserNome ;
      private bool n763ReembolsoLogProtocolo ;
      private bool n752LogWorkflowConvenioDesc ;
      private bool n747ReembolsoFlowLogDate ;
      private bool n754ReembolsoWorkflowConvenioSLA ;
      private bool n760LogReembolsoStatusAtual_F ;
      private bool BRKCU4 ;
      private bool BRKCU6 ;
      private string AV55OptionsJson ;
      private string AV56OptionsDescJson ;
      private string AV57OptionIndexesJson ;
      private string AV73TFLogReembolsoStatusAtual_F_SelsJson ;
      private string AV52DDOName ;
      private string AV53SearchTxtParms ;
      private string AV54SearchTxtTo ;
      private string AV36SearchTxt ;
      private string AV58FilterFullText ;
      private string AV81TFReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV82TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV14TFLogWorkflowConvenioDesc ;
      private string AV15TFLogWorkflowConvenioDesc_Sel ;
      private string AV75TFReembolsoLogProtocolo ;
      private string AV76TFReembolsoLogProtocolo_Sel ;
      private string AV59DynamicFiltersSelector1 ;
      private string AV61LogWorkflowConvenioDesc1 ;
      private string AV62ReembolsoFlowLogUserNome1 ;
      private string AV83ReembolsoPaciente1 ;
      private string AV64DynamicFiltersSelector2 ;
      private string AV66LogWorkflowConvenioDesc2 ;
      private string AV67ReembolsoFlowLogUserNome2 ;
      private string AV84ReembolsoPaciente2 ;
      private string AV69DynamicFiltersSelector3 ;
      private string AV71LogWorkflowConvenioDesc3 ;
      private string AV72ReembolsoFlowLogUserNome3 ;
      private string AV85ReembolsoPaciente3 ;
      private string AV88Wcreembolsoflowlogds_1_filterfulltext ;
      private string AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ;
      private string AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ;
      private string AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ;
      private string AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ;
      private string AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ;
      private string AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ;
      private string AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ;
      private string AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ;
      private string AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ;
      private string AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ;
      private string AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ;
      private string AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ;
      private string AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ;
      private string AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ;
      private string AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ;
      private string AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ;
      private string AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ;
      private string AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ;
      private string lV88Wcreembolsoflowlogds_1_filterfulltext ;
      private string lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ;
      private string lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ;
      private string lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ;
      private string lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ;
      private string lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ;
      private string lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ;
      private string lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ;
      private string lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ;
      private string lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ;
      private string A760LogReembolsoStatusAtual_F ;
      private string A752LogWorkflowConvenioDesc ;
      private string A745ReembolsoFlowLogUserNome ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A763ReembolsoLogProtocolo ;
      private string AV41Option ;
      private IGxSession AV47Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV42Options ;
      private GxSimpleCollection<string> AV44OptionsDesc ;
      private GxSimpleCollection<string> AV45OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV49GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV50GridStateFilterValue ;
      private GxSimpleCollection<string> AV74TFLogReembolsoStatusAtual_F_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV51GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00CU4_A744ReembolsoFlowLogUser ;
      private bool[] P00CU4_n744ReembolsoFlowLogUser ;
      private int[] P00CU4_A748ReembolsoLogId ;
      private bool[] P00CU4_n748ReembolsoLogId ;
      private int[] P00CU4_A542ReembolsoPropostaId ;
      private bool[] P00CU4_n542ReembolsoPropostaId ;
      private int[] P00CU4_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00CU4_n558ReembolsoPropostaPacienteClienteId ;
      private string[] P00CU4_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00CU4_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00CU4_A758ReembolsoPropostaClinicaId ;
      private bool[] P00CU4_n758ReembolsoPropostaClinicaId ;
      private int[] P00CU4_A750LogWorkflowConvenioId ;
      private bool[] P00CU4_n750LogWorkflowConvenioId ;
      private int[] P00CU4_A749ReembolsoWorkFlowConvenioId ;
      private bool[] P00CU4_n749ReembolsoWorkFlowConvenioId ;
      private DateTime[] P00CU4_A755ReembolsoFlowLogDataSLA_F ;
      private string[] P00CU4_A745ReembolsoFlowLogUserNome ;
      private bool[] P00CU4_n745ReembolsoFlowLogUserNome ;
      private string[] P00CU4_A763ReembolsoLogProtocolo ;
      private bool[] P00CU4_n763ReembolsoLogProtocolo ;
      private string[] P00CU4_A752LogWorkflowConvenioDesc ;
      private bool[] P00CU4_n752LogWorkflowConvenioDesc ;
      private DateTime[] P00CU4_A747ReembolsoFlowLogDate ;
      private bool[] P00CU4_n747ReembolsoFlowLogDate ;
      private short[] P00CU4_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] P00CU4_n754ReembolsoWorkflowConvenioSLA ;
      private string[] P00CU4_A760LogReembolsoStatusAtual_F ;
      private bool[] P00CU4_n760LogReembolsoStatusAtual_F ;
      private int[] P00CU4_A746ReembolsoFlowLogId ;
      private short[] P00CU7_A744ReembolsoFlowLogUser ;
      private bool[] P00CU7_n744ReembolsoFlowLogUser ;
      private int[] P00CU7_A748ReembolsoLogId ;
      private bool[] P00CU7_n748ReembolsoLogId ;
      private int[] P00CU7_A542ReembolsoPropostaId ;
      private bool[] P00CU7_n542ReembolsoPropostaId ;
      private int[] P00CU7_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00CU7_n558ReembolsoPropostaPacienteClienteId ;
      private int[] P00CU7_A750LogWorkflowConvenioId ;
      private bool[] P00CU7_n750LogWorkflowConvenioId ;
      private int[] P00CU7_A758ReembolsoPropostaClinicaId ;
      private bool[] P00CU7_n758ReembolsoPropostaClinicaId ;
      private int[] P00CU7_A749ReembolsoWorkFlowConvenioId ;
      private bool[] P00CU7_n749ReembolsoWorkFlowConvenioId ;
      private DateTime[] P00CU7_A755ReembolsoFlowLogDataSLA_F ;
      private string[] P00CU7_A745ReembolsoFlowLogUserNome ;
      private bool[] P00CU7_n745ReembolsoFlowLogUserNome ;
      private string[] P00CU7_A763ReembolsoLogProtocolo ;
      private bool[] P00CU7_n763ReembolsoLogProtocolo ;
      private string[] P00CU7_A752LogWorkflowConvenioDesc ;
      private bool[] P00CU7_n752LogWorkflowConvenioDesc ;
      private string[] P00CU7_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00CU7_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private DateTime[] P00CU7_A747ReembolsoFlowLogDate ;
      private bool[] P00CU7_n747ReembolsoFlowLogDate ;
      private short[] P00CU7_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] P00CU7_n754ReembolsoWorkflowConvenioSLA ;
      private string[] P00CU7_A760LogReembolsoStatusAtual_F ;
      private bool[] P00CU7_n760LogReembolsoStatusAtual_F ;
      private int[] P00CU7_A746ReembolsoFlowLogId ;
      private short[] P00CU10_A744ReembolsoFlowLogUser ;
      private bool[] P00CU10_n744ReembolsoFlowLogUser ;
      private int[] P00CU10_A748ReembolsoLogId ;
      private bool[] P00CU10_n748ReembolsoLogId ;
      private int[] P00CU10_A542ReembolsoPropostaId ;
      private bool[] P00CU10_n542ReembolsoPropostaId ;
      private int[] P00CU10_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00CU10_n558ReembolsoPropostaPacienteClienteId ;
      private string[] P00CU10_A763ReembolsoLogProtocolo ;
      private bool[] P00CU10_n763ReembolsoLogProtocolo ;
      private int[] P00CU10_A758ReembolsoPropostaClinicaId ;
      private bool[] P00CU10_n758ReembolsoPropostaClinicaId ;
      private int[] P00CU10_A750LogWorkflowConvenioId ;
      private bool[] P00CU10_n750LogWorkflowConvenioId ;
      private int[] P00CU10_A749ReembolsoWorkFlowConvenioId ;
      private bool[] P00CU10_n749ReembolsoWorkFlowConvenioId ;
      private DateTime[] P00CU10_A755ReembolsoFlowLogDataSLA_F ;
      private string[] P00CU10_A745ReembolsoFlowLogUserNome ;
      private bool[] P00CU10_n745ReembolsoFlowLogUserNome ;
      private string[] P00CU10_A752LogWorkflowConvenioDesc ;
      private bool[] P00CU10_n752LogWorkflowConvenioDesc ;
      private string[] P00CU10_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00CU10_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private DateTime[] P00CU10_A747ReembolsoFlowLogDate ;
      private bool[] P00CU10_n747ReembolsoFlowLogDate ;
      private short[] P00CU10_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] P00CU10_n754ReembolsoWorkflowConvenioSLA ;
      private string[] P00CU10_A760LogReembolsoStatusAtual_F ;
      private bool[] P00CU10_n760LogReembolsoStatusAtual_F ;
      private int[] P00CU10_A746ReembolsoFlowLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcreembolsoflowloggetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CU4( IGxContext context ,
                                             string A760LogReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                             string AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                             short AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                             string AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                             string AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                             string AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                             bool AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                             string AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                             short AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                             string AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                             string AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                             string AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                             bool AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                             string AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                             short AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                             string AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                             string AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                             string AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                             string AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                             string AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                             DateTime AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                             DateTime AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                             DateTime AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                             DateTime AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                             string AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                             string AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             string A752LogWorkflowConvenioDesc ,
                                             string A745ReembolsoFlowLogUserNome ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             short A754ReembolsoWorkflowConvenioSLA ,
                                             string A763ReembolsoLogProtocolo ,
                                             int A758ReembolsoPropostaClinicaId ,
                                             string AV88Wcreembolsoflowlogds_1_filterfulltext ,
                                             int AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ,
                                             DateTime A755ReembolsoFlowLogDataSLA_F ,
                                             int A749ReembolsoWorkFlowConvenioId ,
                                             int A750LogWorkflowConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[32];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, T1.ReembolsoLogId AS ReembolsoLogId, T3.ReembolsoPropostaId AS ReembolsoPropostaId, T4.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T5.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T4.PropostaClinicaId AS ReembolsoPropostaClinicaId, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T3.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, (COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T6.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) AS ReembolsoFlowLogDataSLA_F, T2.SecUserName AS ReembolsoFlowLogUserNome, T3.ReembolsoProtocolo AS ReembolsoLogProtocolo, T8.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T1.ReembolsoFlowLogDate, T6.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, COALESCE( T7.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F, T1.ReembolsoFlowLogId FROM (((((((ReembolsoFlowLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN Proposta T4 ON T4.PropostaId = T3.ReembolsoPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T6 ON T6.WorkflowConvenioId = T3.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoId FROM (ReembolsoEtapa T9 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T9.ReembolsoId) WHERE (T1.ReembolsoLogId = T9.ReembolsoId) AND (T9.ReembolsoEtapaCreatedAt";
         scmdbuf += " = COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoId ) T7 ON T7.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN WorkflowConvenio T8 ON T8.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV88Wcreembolsoflowlogds_1_filterfulltext))=0) or ( ( T5.ClienteRazaoSocial like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext) or ( T8.WorkflowConvenioDesc like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( '')) or ( T3.ReembolsoProtocolo like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV112WcrCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels, "COALESCE( T7.LogReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "((COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T6.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) < NOW())");
         AddWhere(sWhereString, "(T3.WorkflowConvenioId = T1.LogWorkflowConvenioId)");
         AddWhere(sWhereString, "(COALESCE( T7.LogReembolsoStatusAtual_F, '') <> ( 'FINALIZADO'))");
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc = ( :AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( StringUtil.StrCmp(AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T8.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T6.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) >= :AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T6.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) <= :AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo like :lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ! ( StringUtil.StrCmp(AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo = ( :AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel))");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( StringUtil.StrCmp(AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T3.ReembolsoProtocolo))=0))");
         }
         if ( ! (0==AV9WWPContext_gxTpr_Secuserclienteid) )
         {
            AddWhere(sWhereString, "(T4.PropostaClinicaId = :AV9WWPCo_2Secuserclienteid)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CU7( IGxContext context ,
                                             string A760LogReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                             string AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                             short AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                             string AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                             string AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                             string AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                             bool AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                             string AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                             short AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                             string AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                             string AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                             string AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                             bool AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                             string AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                             short AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                             string AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                             string AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                             string AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                             string AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                             string AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                             DateTime AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                             DateTime AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                             DateTime AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                             DateTime AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                             string AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                             string AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             string A752LogWorkflowConvenioDesc ,
                                             string A745ReembolsoFlowLogUserNome ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             short A754ReembolsoWorkflowConvenioSLA ,
                                             string A763ReembolsoLogProtocolo ,
                                             int A758ReembolsoPropostaClinicaId ,
                                             string AV88Wcreembolsoflowlogds_1_filterfulltext ,
                                             int AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ,
                                             DateTime A755ReembolsoFlowLogDataSLA_F ,
                                             int A749ReembolsoWorkFlowConvenioId ,
                                             int A750LogWorkflowConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[32];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, T1.ReembolsoLogId AS ReembolsoLogId, T3.ReembolsoPropostaId AS ReembolsoPropostaId, T4.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T4.PropostaClinicaId AS ReembolsoPropostaClinicaId, T3.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, (COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T6.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) AS ReembolsoFlowLogDataSLA_F, T2.SecUserName AS ReembolsoFlowLogUserNome, T3.ReembolsoProtocolo AS ReembolsoLogProtocolo, T8.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T5.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoFlowLogDate, T6.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, COALESCE( T7.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F, T1.ReembolsoFlowLogId FROM (((((((ReembolsoFlowLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN Proposta T4 ON T4.PropostaId = T3.ReembolsoPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T6 ON T6.WorkflowConvenioId = T3.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoId FROM (ReembolsoEtapa T9 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T9.ReembolsoId) WHERE (T1.ReembolsoLogId = T9.ReembolsoId) AND (T9.ReembolsoEtapaCreatedAt";
         scmdbuf += " = COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoId ) T7 ON T7.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN WorkflowConvenio T8 ON T8.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV88Wcreembolsoflowlogds_1_filterfulltext))=0) or ( ( T5.ClienteRazaoSocial like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext) or ( T8.WorkflowConvenioDesc like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( '')) or ( T3.ReembolsoProtocolo like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV112WcrCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels, "COALESCE( T7.LogReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "((COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T6.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) < NOW())");
         AddWhere(sWhereString, "(T3.WorkflowConvenioId = T1.LogWorkflowConvenioId)");
         AddWhere(sWhereString, "(COALESCE( T7.LogReembolsoStatusAtual_F, '') <> ( 'FINALIZADO'))");
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc = ( :AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( StringUtil.StrCmp(AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T8.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T6.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) >= :AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T6.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) <= :AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo like :lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ! ( StringUtil.StrCmp(AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo = ( :AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel))");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( StringUtil.StrCmp(AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T3.ReembolsoProtocolo))=0))");
         }
         if ( ! (0==AV9WWPContext_gxTpr_Secuserclienteid) )
         {
            AddWhere(sWhereString, "(T4.PropostaClinicaId = :AV9WWPCo_2Secuserclienteid)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LogWorkflowConvenioId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00CU10( IGxContext context ,
                                              string A760LogReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                              string AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                              short AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                              string AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                              string AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                              string AV93Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                              bool AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                              string AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                              short AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                              string AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                              string AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                              string AV99Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                              bool AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                              string AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                              short AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                              string AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                              string AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                              string AV105Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                              string AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              string AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                              string AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                              string AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                              DateTime AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                              DateTime AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                              DateTime AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                              DateTime AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                              string AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                              string AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              string A752LogWorkflowConvenioDesc ,
                                              string A745ReembolsoFlowLogUserNome ,
                                              string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              DateTime A747ReembolsoFlowLogDate ,
                                              short A754ReembolsoWorkflowConvenioSLA ,
                                              string A763ReembolsoLogProtocolo ,
                                              int A758ReembolsoPropostaClinicaId ,
                                              string AV88Wcreembolsoflowlogds_1_filterfulltext ,
                                              int AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ,
                                              DateTime A755ReembolsoFlowLogDataSLA_F ,
                                              int A749ReembolsoWorkFlowConvenioId ,
                                              int A750LogWorkflowConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[32];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, T1.ReembolsoLogId AS ReembolsoLogId, T3.ReembolsoPropostaId AS ReembolsoPropostaId, T4.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T3.ReembolsoProtocolo AS ReembolsoLogProtocolo, T4.PropostaClinicaId AS ReembolsoPropostaClinicaId, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T3.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, (COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T6.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) AS ReembolsoFlowLogDataSLA_F, T2.SecUserName AS ReembolsoFlowLogUserNome, T8.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T5.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoFlowLogDate, T6.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, COALESCE( T7.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F, T1.ReembolsoFlowLogId FROM (((((((ReembolsoFlowLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN Proposta T4 ON T4.PropostaId = T3.ReembolsoPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T6 ON T6.WorkflowConvenioId = T3.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoId FROM (ReembolsoEtapa T9 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T9.ReembolsoId) WHERE (T1.ReembolsoLogId = T9.ReembolsoId) AND (T9.ReembolsoEtapaCreatedAt";
         scmdbuf += " = COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoId ) T7 ON T7.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN WorkflowConvenio T8 ON T8.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV88Wcreembolsoflowlogds_1_filterfulltext))=0) or ( ( T5.ClienteRazaoSocial like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext) or ( T8.WorkflowConvenioDesc like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV88Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T7.LogReembolsoStatusAtual_F, '') = ( '')) or ( T3.ReembolsoProtocolo like '%' || :lV88Wcreembolsoflowlogds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV112WcrCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels, "COALESCE( T7.LogReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "((COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T6.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) < NOW())");
         AddWhere(sWhereString, "(T3.WorkflowConvenioId = T1.LogWorkflowConvenioId)");
         AddWhere(sWhereString, "(COALESCE( T7.LogReembolsoStatusAtual_F, '') <> ( 'FINALIZADO'))");
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV90Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV94Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV96Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV100Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV101Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV102Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc = ( :AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( StringUtil.StrCmp(AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T8.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T6.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) >= :AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T6.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) <= :AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo like :lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ! ( StringUtil.StrCmp(AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo = ( :AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel))");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( StringUtil.StrCmp(AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T3.ReembolsoProtocolo))=0))");
         }
         if ( ! (0==AV9WWPContext_gxTpr_Secuserclienteid) )
         {
            AddWhere(sWhereString, "(T4.PropostaClinicaId = :AV9WWPCo_2Secuserclienteid)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ReembolsoProtocolo";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CU4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (DateTime)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
               case 1 :
                     return conditional_P00CU7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (DateTime)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
               case 2 :
                     return conditional_P00CU10(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (DateTime)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CU4;
          prmP00CU4 = new Object[] {
          new ParDef("AV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112WcrCount",GXType.Int32,9,0) ,
          new ParDef("lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f",GXType.DateTime,8,5) ,
          new ParDef("AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to",GXType.DateTime,8,5) ,
          new ParDef("lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0)
          };
          Object[] prmP00CU7;
          prmP00CU7 = new Object[] {
          new ParDef("AV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112WcrCount",GXType.Int32,9,0) ,
          new ParDef("lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f",GXType.DateTime,8,5) ,
          new ParDef("AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to",GXType.DateTime,8,5) ,
          new ParDef("lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0)
          };
          Object[] prmP00CU10;
          prmP00CU10 = new Object[] {
          new ParDef("AV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112WcrCount",GXType.Int32,9,0) ,
          new ParDef("lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV91Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV97Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV103Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV104Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV106Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("AV107Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_21_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV109Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV110Wcreembolsoflowlogds_23_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV111Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV113Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f",GXType.DateTime,8,5) ,
          new ParDef("AV114Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to",GXType.DateTime,8,5) ,
          new ParDef("lV115Wcreembolsoflowlogds_28_tfreembolsologprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV116Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CU7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CU10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CU10,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                return;
       }
    }

 }

}
