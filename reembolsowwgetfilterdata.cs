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
   public class reembolsowwgetfilterdata : GXProcedure
   {
      public reembolsowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsowwgetfilterdata( IGxContext context )
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
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV45OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27MaxItems = 10;
         AV26PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV41SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? "" : StringUtil.Substring( AV41SearchTxtParms, 3, -1));
         AV25SkipItems = (short)(AV26PageIndex*AV27MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_REEMBOLSOPROTOCOLO") == 0 )
         {
            /* Execute user subroutine: 'LOADREEMBOLSOPROTOCOLOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_WORKFLOWCONVENIODESC") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKFLOWCONVENIODESCOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV43OptionsJson = AV30Options.ToJSonString(false);
         AV44OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV45OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("ReembolsoWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ReembolsoWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("ReembolsoWWGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFReembolsoPropostaPacienteClienteRazaoSocial = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROTOCOLO") == 0 )
            {
               AV12TFReembolsoProtocolo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROTOCOLO_SEL") == 0 )
            {
               AV13TFReembolsoProtocolo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOCREATEDAT") == 0 )
            {
               AV14TFReembolsoCreatedAt = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, 4);
               AV15TFReembolsoCreatedAt_To = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAVALOR") == 0 )
            {
               AV16TFReembolsoPropostaValor = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV17TFReembolsoPropostaValor_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSODATAABERTURACONVENIO") == 0 )
            {
               AV18TFReembolsoDataAberturaConvenio = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, 4);
               AV19TFReembolsoDataAberturaConvenio_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV22TFReembolsoStatusAtual_F_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV23TFReembolsoStatusAtual_F_Sels.FromJSonString(AV22TFReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV58TFWorkflowConvenioDesc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV59TFWorkflowConvenioDesc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV47DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV47DynamicFiltersSelector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV48DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV49ReembolsoPropostaPacienteClienteRazaoSocial1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV48DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV60WorkflowConvenioDesc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV50DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV53ReembolsoPropostaPacienteClienteRazaoSocial2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV61WorkflowConvenioDesc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV54DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV55DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV57ReembolsoPropostaPacienteClienteRazaoSocial3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV62WorkflowConvenioDesc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFReembolsoPropostaPacienteClienteRazaoSocial = AV24SearchTxt;
         AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV65Reembolsowwds_1_filterfulltext = AV46FilterFullText;
         AV66Reembolsowwds_2_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV67Reembolsowwds_3_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV49ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV69Reembolsowwds_5_workflowconveniodesc1 = AV60WorkflowConvenioDesc1;
         AV70Reembolsowwds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV71Reembolsowwds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV72Reembolsowwds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV53ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV74Reembolsowwds_10_workflowconveniodesc2 = AV61WorkflowConvenioDesc2;
         AV75Reembolsowwds_11_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV76Reembolsowwds_12_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV77Reembolsowwds_13_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV57ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV79Reembolsowwds_15_workflowconveniodesc3 = AV62WorkflowConvenioDesc3;
         AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV10TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV82Reembolsowwds_18_tfreembolsoprotocolo = AV12TFReembolsoProtocolo;
         AV83Reembolsowwds_19_tfreembolsoprotocolo_sel = AV13TFReembolsoProtocolo_Sel;
         AV84Reembolsowwds_20_tfreembolsocreatedat = AV14TFReembolsoCreatedAt;
         AV85Reembolsowwds_21_tfreembolsocreatedat_to = AV15TFReembolsoCreatedAt_To;
         AV86Reembolsowwds_22_tfreembolsopropostavalor = AV16TFReembolsoPropostaValor;
         AV87Reembolsowwds_23_tfreembolsopropostavalor_to = AV17TFReembolsoPropostaValor_To;
         AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV18TFReembolsoDataAberturaConvenio;
         AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV19TFReembolsoDataAberturaConvenio_To;
         AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV23TFReembolsoStatusAtual_F_Sels;
         AV91Reembolsowwds_27_tfworkflowconveniodesc = AV58TFWorkflowConvenioDesc;
         AV92Reembolsowwds_28_tfworkflowconveniodesc_sel = AV59TFWorkflowConvenioDesc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV66Reembolsowwds_2_dynamicfiltersselector1 ,
                                              AV67Reembolsowwds_3_dynamicfiltersoperator1 ,
                                              AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                              AV69Reembolsowwds_5_workflowconveniodesc1 ,
                                              AV70Reembolsowwds_6_dynamicfiltersenabled2 ,
                                              AV71Reembolsowwds_7_dynamicfiltersselector2 ,
                                              AV72Reembolsowwds_8_dynamicfiltersoperator2 ,
                                              AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                              AV74Reembolsowwds_10_workflowconveniodesc2 ,
                                              AV75Reembolsowwds_11_dynamicfiltersenabled3 ,
                                              AV76Reembolsowwds_12_dynamicfiltersselector3 ,
                                              AV77Reembolsowwds_13_dynamicfiltersoperator3 ,
                                              AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                              AV79Reembolsowwds_15_workflowconveniodesc3 ,
                                              AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                              AV82Reembolsowwds_18_tfreembolsoprotocolo ,
                                              AV84Reembolsowwds_20_tfreembolsocreatedat ,
                                              AV85Reembolsowwds_21_tfreembolsocreatedat_to ,
                                              AV86Reembolsowwds_22_tfreembolsopropostavalor ,
                                              AV87Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                              AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                              AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                              AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                              AV91Reembolsowwds_27_tfworkflowconveniodesc ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A736WorkflowConvenioDesc ,
                                              A546ReembolsoProtocolo ,
                                              A522ReembolsoCreatedAt ,
                                              A543ReembolsoPropostaValor ,
                                              A525ReembolsoDataAberturaConvenio ,
                                              AV65Reembolsowwds_1_filterfulltext ,
                                              AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV69Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV69Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV74Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV74Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV79Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV79Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV82Reembolsowwds_18_tfreembolsoprotocolo = StringUtil.Concat( StringUtil.RTrim( AV82Reembolsowwds_18_tfreembolsoprotocolo), "%", "");
         lV91Reembolsowwds_27_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV91Reembolsowwds_27_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00C12 */
         pr_default.execute(0, new Object[] {AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count, lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV69Reembolsowwds_5_workflowconveniodesc1, lV69Reembolsowwds_5_workflowconveniodesc1, lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV74Reembolsowwds_10_workflowconveniodesc2, lV74Reembolsowwds_10_workflowconveniodesc2, lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV79Reembolsowwds_15_workflowconveniodesc3, lV79Reembolsowwds_15_workflowconveniodesc3, lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial, AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, lV82Reembolsowwds_18_tfreembolsoprotocolo, AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, AV84Reembolsowwds_20_tfreembolsocreatedat, AV85Reembolsowwds_21_tfreembolsocreatedat_to, AV86Reembolsowwds_22_tfreembolsopropostavalor, AV87Reembolsowwds_23_tfreembolsopropostavalor_to, AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio, AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to, lV91Reembolsowwds_27_tfworkflowconveniodesc, AV92Reembolsowwds_28_tfworkflowconveniodesc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKC12 = false;
            A742WorkflowConvenioId = P00C12_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = P00C12_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = P00C12_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00C12_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C12_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C12_n558ReembolsoPropostaPacienteClienteId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C12_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C12_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A525ReembolsoDataAberturaConvenio = P00C12_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = P00C12_n525ReembolsoDataAberturaConvenio[0];
            A543ReembolsoPropostaValor = P00C12_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C12_n543ReembolsoPropostaValor[0];
            A522ReembolsoCreatedAt = P00C12_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = P00C12_n522ReembolsoCreatedAt[0];
            A736WorkflowConvenioDesc = P00C12_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C12_n736WorkflowConvenioDesc[0];
            A546ReembolsoProtocolo = P00C12_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = P00C12_n546ReembolsoProtocolo[0];
            A518ReembolsoId = P00C12_A518ReembolsoId[0];
            n518ReembolsoId = P00C12_n518ReembolsoId[0];
            A736WorkflowConvenioDesc = P00C12_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C12_n736WorkflowConvenioDesc[0];
            A558ReembolsoPropostaPacienteClienteId = P00C12_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C12_n558ReembolsoPropostaPacienteClienteId[0];
            A543ReembolsoPropostaValor = P00C12_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C12_n543ReembolsoPropostaValor[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C12_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C12_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00C12_A550ReembolsoPropostaPacienteClienteRazaoSocial[0], A550ReembolsoPropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRKC12 = false;
               A542ReembolsoPropostaId = P00C12_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = P00C12_n542ReembolsoPropostaId[0];
               A558ReembolsoPropostaPacienteClienteId = P00C12_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00C12_n558ReembolsoPropostaPacienteClienteId[0];
               A518ReembolsoId = P00C12_A518ReembolsoId[0];
               n518ReembolsoId = P00C12_n518ReembolsoId[0];
               A558ReembolsoPropostaPacienteClienteId = P00C12_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00C12_n558ReembolsoPropostaPacienteClienteId[0];
               AV34count = (long)(AV34count+1);
               BRKC12 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A550ReembolsoPropostaPacienteClienteRazaoSocial)) ? "<#Empty#>" : A550ReembolsoPropostaPacienteClienteRazaoSocial);
               AV30Options.Add(AV29Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV25SkipItems = (short)(AV25SkipItems-1);
            }
            if ( ! BRKC12 )
            {
               BRKC12 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADREEMBOLSOPROTOCOLOOPTIONS' Routine */
         returnInSub = false;
         AV12TFReembolsoProtocolo = AV24SearchTxt;
         AV13TFReembolsoProtocolo_Sel = "";
         AV65Reembolsowwds_1_filterfulltext = AV46FilterFullText;
         AV66Reembolsowwds_2_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV67Reembolsowwds_3_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV49ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV69Reembolsowwds_5_workflowconveniodesc1 = AV60WorkflowConvenioDesc1;
         AV70Reembolsowwds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV71Reembolsowwds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV72Reembolsowwds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV53ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV74Reembolsowwds_10_workflowconveniodesc2 = AV61WorkflowConvenioDesc2;
         AV75Reembolsowwds_11_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV76Reembolsowwds_12_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV77Reembolsowwds_13_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV57ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV79Reembolsowwds_15_workflowconveniodesc3 = AV62WorkflowConvenioDesc3;
         AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV10TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV82Reembolsowwds_18_tfreembolsoprotocolo = AV12TFReembolsoProtocolo;
         AV83Reembolsowwds_19_tfreembolsoprotocolo_sel = AV13TFReembolsoProtocolo_Sel;
         AV84Reembolsowwds_20_tfreembolsocreatedat = AV14TFReembolsoCreatedAt;
         AV85Reembolsowwds_21_tfreembolsocreatedat_to = AV15TFReembolsoCreatedAt_To;
         AV86Reembolsowwds_22_tfreembolsopropostavalor = AV16TFReembolsoPropostaValor;
         AV87Reembolsowwds_23_tfreembolsopropostavalor_to = AV17TFReembolsoPropostaValor_To;
         AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV18TFReembolsoDataAberturaConvenio;
         AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV19TFReembolsoDataAberturaConvenio_To;
         AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV23TFReembolsoStatusAtual_F_Sels;
         AV91Reembolsowwds_27_tfworkflowconveniodesc = AV58TFWorkflowConvenioDesc;
         AV92Reembolsowwds_28_tfworkflowconveniodesc_sel = AV59TFWorkflowConvenioDesc_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV66Reembolsowwds_2_dynamicfiltersselector1 ,
                                              AV67Reembolsowwds_3_dynamicfiltersoperator1 ,
                                              AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                              AV69Reembolsowwds_5_workflowconveniodesc1 ,
                                              AV70Reembolsowwds_6_dynamicfiltersenabled2 ,
                                              AV71Reembolsowwds_7_dynamicfiltersselector2 ,
                                              AV72Reembolsowwds_8_dynamicfiltersoperator2 ,
                                              AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                              AV74Reembolsowwds_10_workflowconveniodesc2 ,
                                              AV75Reembolsowwds_11_dynamicfiltersenabled3 ,
                                              AV76Reembolsowwds_12_dynamicfiltersselector3 ,
                                              AV77Reembolsowwds_13_dynamicfiltersoperator3 ,
                                              AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                              AV79Reembolsowwds_15_workflowconveniodesc3 ,
                                              AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                              AV82Reembolsowwds_18_tfreembolsoprotocolo ,
                                              AV84Reembolsowwds_20_tfreembolsocreatedat ,
                                              AV85Reembolsowwds_21_tfreembolsocreatedat_to ,
                                              AV86Reembolsowwds_22_tfreembolsopropostavalor ,
                                              AV87Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                              AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                              AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                              AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                              AV91Reembolsowwds_27_tfworkflowconveniodesc ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A736WorkflowConvenioDesc ,
                                              A546ReembolsoProtocolo ,
                                              A522ReembolsoCreatedAt ,
                                              A543ReembolsoPropostaValor ,
                                              A525ReembolsoDataAberturaConvenio ,
                                              AV65Reembolsowwds_1_filterfulltext ,
                                              AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV69Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV69Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV74Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV74Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV79Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV79Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV82Reembolsowwds_18_tfreembolsoprotocolo = StringUtil.Concat( StringUtil.RTrim( AV82Reembolsowwds_18_tfreembolsoprotocolo), "%", "");
         lV91Reembolsowwds_27_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV91Reembolsowwds_27_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00C13 */
         pr_default.execute(1, new Object[] {AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count, lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV69Reembolsowwds_5_workflowconveniodesc1, lV69Reembolsowwds_5_workflowconveniodesc1, lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV74Reembolsowwds_10_workflowconveniodesc2, lV74Reembolsowwds_10_workflowconveniodesc2, lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV79Reembolsowwds_15_workflowconveniodesc3, lV79Reembolsowwds_15_workflowconveniodesc3, lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial, AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, lV82Reembolsowwds_18_tfreembolsoprotocolo, AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, AV84Reembolsowwds_20_tfreembolsocreatedat, AV85Reembolsowwds_21_tfreembolsocreatedat_to, AV86Reembolsowwds_22_tfreembolsopropostavalor, AV87Reembolsowwds_23_tfreembolsopropostavalor_to, AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio, AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to, lV91Reembolsowwds_27_tfworkflowconveniodesc, AV92Reembolsowwds_28_tfworkflowconveniodesc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKC14 = false;
            A742WorkflowConvenioId = P00C13_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = P00C13_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = P00C13_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00C13_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C13_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C13_n558ReembolsoPropostaPacienteClienteId[0];
            A546ReembolsoProtocolo = P00C13_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = P00C13_n546ReembolsoProtocolo[0];
            A525ReembolsoDataAberturaConvenio = P00C13_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = P00C13_n525ReembolsoDataAberturaConvenio[0];
            A543ReembolsoPropostaValor = P00C13_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C13_n543ReembolsoPropostaValor[0];
            A522ReembolsoCreatedAt = P00C13_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = P00C13_n522ReembolsoCreatedAt[0];
            A736WorkflowConvenioDesc = P00C13_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C13_n736WorkflowConvenioDesc[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C13_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C13_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A518ReembolsoId = P00C13_A518ReembolsoId[0];
            n518ReembolsoId = P00C13_n518ReembolsoId[0];
            A736WorkflowConvenioDesc = P00C13_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C13_n736WorkflowConvenioDesc[0];
            A558ReembolsoPropostaPacienteClienteId = P00C13_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C13_n558ReembolsoPropostaPacienteClienteId[0];
            A543ReembolsoPropostaValor = P00C13_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C13_n543ReembolsoPropostaValor[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C13_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C13_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00C13_A546ReembolsoProtocolo[0], A546ReembolsoProtocolo) == 0 ) )
            {
               BRKC14 = false;
               A518ReembolsoId = P00C13_A518ReembolsoId[0];
               n518ReembolsoId = P00C13_n518ReembolsoId[0];
               AV34count = (long)(AV34count+1);
               BRKC14 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A546ReembolsoProtocolo)) ? "<#Empty#>" : A546ReembolsoProtocolo);
               AV30Options.Add(AV29Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV25SkipItems = (short)(AV25SkipItems-1);
            }
            if ( ! BRKC14 )
            {
               BRKC14 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADWORKFLOWCONVENIODESCOPTIONS' Routine */
         returnInSub = false;
         AV58TFWorkflowConvenioDesc = AV24SearchTxt;
         AV59TFWorkflowConvenioDesc_Sel = "";
         AV65Reembolsowwds_1_filterfulltext = AV46FilterFullText;
         AV66Reembolsowwds_2_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV67Reembolsowwds_3_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV49ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV69Reembolsowwds_5_workflowconveniodesc1 = AV60WorkflowConvenioDesc1;
         AV70Reembolsowwds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV71Reembolsowwds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV72Reembolsowwds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV53ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV74Reembolsowwds_10_workflowconveniodesc2 = AV61WorkflowConvenioDesc2;
         AV75Reembolsowwds_11_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV76Reembolsowwds_12_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV77Reembolsowwds_13_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV57ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV79Reembolsowwds_15_workflowconveniodesc3 = AV62WorkflowConvenioDesc3;
         AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV10TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV82Reembolsowwds_18_tfreembolsoprotocolo = AV12TFReembolsoProtocolo;
         AV83Reembolsowwds_19_tfreembolsoprotocolo_sel = AV13TFReembolsoProtocolo_Sel;
         AV84Reembolsowwds_20_tfreembolsocreatedat = AV14TFReembolsoCreatedAt;
         AV85Reembolsowwds_21_tfreembolsocreatedat_to = AV15TFReembolsoCreatedAt_To;
         AV86Reembolsowwds_22_tfreembolsopropostavalor = AV16TFReembolsoPropostaValor;
         AV87Reembolsowwds_23_tfreembolsopropostavalor_to = AV17TFReembolsoPropostaValor_To;
         AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV18TFReembolsoDataAberturaConvenio;
         AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV19TFReembolsoDataAberturaConvenio_To;
         AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV23TFReembolsoStatusAtual_F_Sels;
         AV91Reembolsowwds_27_tfworkflowconveniodesc = AV58TFWorkflowConvenioDesc;
         AV92Reembolsowwds_28_tfworkflowconveniodesc_sel = AV59TFWorkflowConvenioDesc_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV66Reembolsowwds_2_dynamicfiltersselector1 ,
                                              AV67Reembolsowwds_3_dynamicfiltersoperator1 ,
                                              AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                              AV69Reembolsowwds_5_workflowconveniodesc1 ,
                                              AV70Reembolsowwds_6_dynamicfiltersenabled2 ,
                                              AV71Reembolsowwds_7_dynamicfiltersselector2 ,
                                              AV72Reembolsowwds_8_dynamicfiltersoperator2 ,
                                              AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                              AV74Reembolsowwds_10_workflowconveniodesc2 ,
                                              AV75Reembolsowwds_11_dynamicfiltersenabled3 ,
                                              AV76Reembolsowwds_12_dynamicfiltersselector3 ,
                                              AV77Reembolsowwds_13_dynamicfiltersoperator3 ,
                                              AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                              AV79Reembolsowwds_15_workflowconveniodesc3 ,
                                              AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                              AV82Reembolsowwds_18_tfreembolsoprotocolo ,
                                              AV84Reembolsowwds_20_tfreembolsocreatedat ,
                                              AV85Reembolsowwds_21_tfreembolsocreatedat_to ,
                                              AV86Reembolsowwds_22_tfreembolsopropostavalor ,
                                              AV87Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                              AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                              AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                              AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                              AV91Reembolsowwds_27_tfworkflowconveniodesc ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A736WorkflowConvenioDesc ,
                                              A546ReembolsoProtocolo ,
                                              A522ReembolsoCreatedAt ,
                                              A543ReembolsoPropostaValor ,
                                              A525ReembolsoDataAberturaConvenio ,
                                              AV65Reembolsowwds_1_filterfulltext ,
                                              AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV69Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV69Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV74Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV74Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV79Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV79Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV82Reembolsowwds_18_tfreembolsoprotocolo = StringUtil.Concat( StringUtil.RTrim( AV82Reembolsowwds_18_tfreembolsoprotocolo), "%", "");
         lV91Reembolsowwds_27_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV91Reembolsowwds_27_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00C14 */
         pr_default.execute(2, new Object[] {AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count, lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV69Reembolsowwds_5_workflowconveniodesc1, lV69Reembolsowwds_5_workflowconveniodesc1, lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV74Reembolsowwds_10_workflowconveniodesc2, lV74Reembolsowwds_10_workflowconveniodesc2, lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV79Reembolsowwds_15_workflowconveniodesc3, lV79Reembolsowwds_15_workflowconveniodesc3, lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial, AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, lV82Reembolsowwds_18_tfreembolsoprotocolo, AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, AV84Reembolsowwds_20_tfreembolsocreatedat, AV85Reembolsowwds_21_tfreembolsocreatedat_to, AV86Reembolsowwds_22_tfreembolsopropostavalor, AV87Reembolsowwds_23_tfreembolsopropostavalor_to, AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio, AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to, lV91Reembolsowwds_27_tfworkflowconveniodesc, AV92Reembolsowwds_28_tfworkflowconveniodesc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKC16 = false;
            A542ReembolsoPropostaId = P00C14_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00C14_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C14_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C14_n558ReembolsoPropostaPacienteClienteId[0];
            A742WorkflowConvenioId = P00C14_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = P00C14_n742WorkflowConvenioId[0];
            A525ReembolsoDataAberturaConvenio = P00C14_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = P00C14_n525ReembolsoDataAberturaConvenio[0];
            A543ReembolsoPropostaValor = P00C14_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C14_n543ReembolsoPropostaValor[0];
            A522ReembolsoCreatedAt = P00C14_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = P00C14_n522ReembolsoCreatedAt[0];
            A736WorkflowConvenioDesc = P00C14_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C14_n736WorkflowConvenioDesc[0];
            A546ReembolsoProtocolo = P00C14_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = P00C14_n546ReembolsoProtocolo[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C14_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C14_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A518ReembolsoId = P00C14_A518ReembolsoId[0];
            n518ReembolsoId = P00C14_n518ReembolsoId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C14_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C14_n558ReembolsoPropostaPacienteClienteId[0];
            A543ReembolsoPropostaValor = P00C14_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C14_n543ReembolsoPropostaValor[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C14_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C14_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A736WorkflowConvenioDesc = P00C14_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C14_n736WorkflowConvenioDesc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00C14_A742WorkflowConvenioId[0] == A742WorkflowConvenioId ) )
            {
               BRKC16 = false;
               A518ReembolsoId = P00C14_A518ReembolsoId[0];
               n518ReembolsoId = P00C14_n518ReembolsoId[0];
               AV34count = (long)(AV34count+1);
               BRKC16 = true;
               pr_default.readNext(2);
            }
            AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) ? "<#Empty#>" : A736WorkflowConvenioDesc);
            AV28InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV29Option, "<#Empty#>") != 0 ) && ( AV28InsertIndex <= AV30Options.Count ) && ( ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) < 0 ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV28InsertIndex = (int)(AV28InsertIndex+1);
            }
            AV30Options.Add(AV29Option, AV28InsertIndex);
            AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), AV28InsertIndex);
            if ( AV30Options.Count == AV25SkipItems + 11 )
            {
               AV30Options.RemoveItem(AV30Options.Count);
               AV33OptionIndexes.RemoveItem(AV33OptionIndexes.Count);
            }
            if ( ! BRKC16 )
            {
               BRKC16 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV25SkipItems > 0 )
         {
            AV30Options.RemoveItem(1);
            AV33OptionIndexes.RemoveItem(1);
            AV25SkipItems = (short)(AV25SkipItems-1);
         }
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
         AV43OptionsJson = "";
         AV44OptionsDescJson = "";
         AV45OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV10TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV12TFReembolsoProtocolo = "";
         AV13TFReembolsoProtocolo_Sel = "";
         AV14TFReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         AV15TFReembolsoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV18TFReembolsoDataAberturaConvenio = DateTime.MinValue;
         AV19TFReembolsoDataAberturaConvenio_To = DateTime.MinValue;
         AV22TFReembolsoStatusAtual_F_SelsJson = "";
         AV23TFReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV58TFWorkflowConvenioDesc = "";
         AV59TFWorkflowConvenioDesc_Sel = "";
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV47DynamicFiltersSelector1 = "";
         AV49ReembolsoPropostaPacienteClienteRazaoSocial1 = "";
         AV60WorkflowConvenioDesc1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV53ReembolsoPropostaPacienteClienteRazaoSocial2 = "";
         AV61WorkflowConvenioDesc2 = "";
         AV55DynamicFiltersSelector3 = "";
         AV57ReembolsoPropostaPacienteClienteRazaoSocial3 = "";
         AV62WorkflowConvenioDesc3 = "";
         AV65Reembolsowwds_1_filterfulltext = "";
         AV66Reembolsowwds_2_dynamicfiltersselector1 = "";
         AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = "";
         AV69Reembolsowwds_5_workflowconveniodesc1 = "";
         AV71Reembolsowwds_7_dynamicfiltersselector2 = "";
         AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = "";
         AV74Reembolsowwds_10_workflowconveniodesc2 = "";
         AV76Reembolsowwds_12_dynamicfiltersselector3 = "";
         AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = "";
         AV79Reembolsowwds_15_workflowconveniodesc3 = "";
         AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = "";
         AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = "";
         AV82Reembolsowwds_18_tfreembolsoprotocolo = "";
         AV83Reembolsowwds_19_tfreembolsoprotocolo_sel = "";
         AV84Reembolsowwds_20_tfreembolsocreatedat = (DateTime)(DateTime.MinValue);
         AV85Reembolsowwds_21_tfreembolsocreatedat_to = (DateTime)(DateTime.MinValue);
         AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio = DateTime.MinValue;
         AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = DateTime.MinValue;
         AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV91Reembolsowwds_27_tfworkflowconveniodesc = "";
         AV92Reembolsowwds_28_tfworkflowconveniodesc_sel = "";
         lV65Reembolsowwds_1_filterfulltext = "";
         lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = "";
         lV69Reembolsowwds_5_workflowconveniodesc1 = "";
         lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = "";
         lV74Reembolsowwds_10_workflowconveniodesc2 = "";
         lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = "";
         lV79Reembolsowwds_15_workflowconveniodesc3 = "";
         lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = "";
         lV82Reembolsowwds_18_tfreembolsoprotocolo = "";
         lV91Reembolsowwds_27_tfworkflowconveniodesc = "";
         A548ReembolsoStatusAtual_F = "";
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A736WorkflowConvenioDesc = "";
         A546ReembolsoProtocolo = "";
         A522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         P00C12_A742WorkflowConvenioId = new int[1] ;
         P00C12_n742WorkflowConvenioId = new bool[] {false} ;
         P00C12_A542ReembolsoPropostaId = new int[1] ;
         P00C12_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C12_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C12_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C12_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C12_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C12_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         P00C12_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         P00C12_A543ReembolsoPropostaValor = new decimal[1] ;
         P00C12_n543ReembolsoPropostaValor = new bool[] {false} ;
         P00C12_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00C12_n522ReembolsoCreatedAt = new bool[] {false} ;
         P00C12_A736WorkflowConvenioDesc = new string[] {""} ;
         P00C12_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00C12_A546ReembolsoProtocolo = new string[] {""} ;
         P00C12_n546ReembolsoProtocolo = new bool[] {false} ;
         P00C12_A518ReembolsoId = new int[1] ;
         P00C12_n518ReembolsoId = new bool[] {false} ;
         AV29Option = "";
         P00C13_A742WorkflowConvenioId = new int[1] ;
         P00C13_n742WorkflowConvenioId = new bool[] {false} ;
         P00C13_A542ReembolsoPropostaId = new int[1] ;
         P00C13_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C13_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C13_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C13_A546ReembolsoProtocolo = new string[] {""} ;
         P00C13_n546ReembolsoProtocolo = new bool[] {false} ;
         P00C13_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         P00C13_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         P00C13_A543ReembolsoPropostaValor = new decimal[1] ;
         P00C13_n543ReembolsoPropostaValor = new bool[] {false} ;
         P00C13_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00C13_n522ReembolsoCreatedAt = new bool[] {false} ;
         P00C13_A736WorkflowConvenioDesc = new string[] {""} ;
         P00C13_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00C13_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C13_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C13_A518ReembolsoId = new int[1] ;
         P00C13_n518ReembolsoId = new bool[] {false} ;
         P00C14_A542ReembolsoPropostaId = new int[1] ;
         P00C14_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C14_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C14_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C14_A742WorkflowConvenioId = new int[1] ;
         P00C14_n742WorkflowConvenioId = new bool[] {false} ;
         P00C14_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         P00C14_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         P00C14_A543ReembolsoPropostaValor = new decimal[1] ;
         P00C14_n543ReembolsoPropostaValor = new bool[] {false} ;
         P00C14_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00C14_n522ReembolsoCreatedAt = new bool[] {false} ;
         P00C14_A736WorkflowConvenioDesc = new string[] {""} ;
         P00C14_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00C14_A546ReembolsoProtocolo = new string[] {""} ;
         P00C14_n546ReembolsoProtocolo = new bool[] {false} ;
         P00C14_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C14_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C14_A518ReembolsoId = new int[1] ;
         P00C14_n518ReembolsoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C12_A742WorkflowConvenioId, P00C12_n742WorkflowConvenioId, P00C12_A542ReembolsoPropostaId, P00C12_n542ReembolsoPropostaId, P00C12_A558ReembolsoPropostaPacienteClienteId, P00C12_n558ReembolsoPropostaPacienteClienteId, P00C12_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C12_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00C12_A525ReembolsoDataAberturaConvenio, P00C12_n525ReembolsoDataAberturaConvenio,
               P00C12_A543ReembolsoPropostaValor, P00C12_n543ReembolsoPropostaValor, P00C12_A522ReembolsoCreatedAt, P00C12_n522ReembolsoCreatedAt, P00C12_A736WorkflowConvenioDesc, P00C12_n736WorkflowConvenioDesc, P00C12_A546ReembolsoProtocolo, P00C12_n546ReembolsoProtocolo, P00C12_A518ReembolsoId
               }
               , new Object[] {
               P00C13_A742WorkflowConvenioId, P00C13_n742WorkflowConvenioId, P00C13_A542ReembolsoPropostaId, P00C13_n542ReembolsoPropostaId, P00C13_A558ReembolsoPropostaPacienteClienteId, P00C13_n558ReembolsoPropostaPacienteClienteId, P00C13_A546ReembolsoProtocolo, P00C13_n546ReembolsoProtocolo, P00C13_A525ReembolsoDataAberturaConvenio, P00C13_n525ReembolsoDataAberturaConvenio,
               P00C13_A543ReembolsoPropostaValor, P00C13_n543ReembolsoPropostaValor, P00C13_A522ReembolsoCreatedAt, P00C13_n522ReembolsoCreatedAt, P00C13_A736WorkflowConvenioDesc, P00C13_n736WorkflowConvenioDesc, P00C13_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C13_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00C13_A518ReembolsoId
               }
               , new Object[] {
               P00C14_A542ReembolsoPropostaId, P00C14_n542ReembolsoPropostaId, P00C14_A558ReembolsoPropostaPacienteClienteId, P00C14_n558ReembolsoPropostaPacienteClienteId, P00C14_A742WorkflowConvenioId, P00C14_n742WorkflowConvenioId, P00C14_A525ReembolsoDataAberturaConvenio, P00C14_n525ReembolsoDataAberturaConvenio, P00C14_A543ReembolsoPropostaValor, P00C14_n543ReembolsoPropostaValor,
               P00C14_A522ReembolsoCreatedAt, P00C14_n522ReembolsoCreatedAt, P00C14_A736WorkflowConvenioDesc, P00C14_n736WorkflowConvenioDesc, P00C14_A546ReembolsoProtocolo, P00C14_n546ReembolsoProtocolo, P00C14_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C14_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00C14_A518ReembolsoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private short AV48DynamicFiltersOperator1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV56DynamicFiltersOperator3 ;
      private short AV67Reembolsowwds_3_dynamicfiltersoperator1 ;
      private short AV72Reembolsowwds_8_dynamicfiltersoperator2 ;
      private short AV77Reembolsowwds_13_dynamicfiltersoperator3 ;
      private int AV63GXV1 ;
      private int AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int A742WorkflowConvenioId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A518ReembolsoId ;
      private int AV28InsertIndex ;
      private long AV34count ;
      private decimal AV16TFReembolsoPropostaValor ;
      private decimal AV17TFReembolsoPropostaValor_To ;
      private decimal AV86Reembolsowwds_22_tfreembolsopropostavalor ;
      private decimal AV87Reembolsowwds_23_tfreembolsopropostavalor_to ;
      private decimal A543ReembolsoPropostaValor ;
      private DateTime AV14TFReembolsoCreatedAt ;
      private DateTime AV15TFReembolsoCreatedAt_To ;
      private DateTime AV84Reembolsowwds_20_tfreembolsocreatedat ;
      private DateTime AV85Reembolsowwds_21_tfreembolsocreatedat_to ;
      private DateTime A522ReembolsoCreatedAt ;
      private DateTime AV18TFReembolsoDataAberturaConvenio ;
      private DateTime AV19TFReembolsoDataAberturaConvenio_To ;
      private DateTime AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ;
      private DateTime AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private bool returnInSub ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV54DynamicFiltersEnabled3 ;
      private bool AV70Reembolsowwds_6_dynamicfiltersenabled2 ;
      private bool AV75Reembolsowwds_11_dynamicfiltersenabled3 ;
      private bool BRKC12 ;
      private bool n742WorkflowConvenioId ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n543ReembolsoPropostaValor ;
      private bool n522ReembolsoCreatedAt ;
      private bool n736WorkflowConvenioDesc ;
      private bool n546ReembolsoProtocolo ;
      private bool n518ReembolsoId ;
      private bool BRKC14 ;
      private bool BRKC16 ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV22TFReembolsoStatusAtual_F_SelsJson ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV46FilterFullText ;
      private string AV10TFReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV11TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV12TFReembolsoProtocolo ;
      private string AV13TFReembolsoProtocolo_Sel ;
      private string AV58TFWorkflowConvenioDesc ;
      private string AV59TFWorkflowConvenioDesc_Sel ;
      private string AV47DynamicFiltersSelector1 ;
      private string AV49ReembolsoPropostaPacienteClienteRazaoSocial1 ;
      private string AV60WorkflowConvenioDesc1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV53ReembolsoPropostaPacienteClienteRazaoSocial2 ;
      private string AV61WorkflowConvenioDesc2 ;
      private string AV55DynamicFiltersSelector3 ;
      private string AV57ReembolsoPropostaPacienteClienteRazaoSocial3 ;
      private string AV62WorkflowConvenioDesc3 ;
      private string AV65Reembolsowwds_1_filterfulltext ;
      private string AV66Reembolsowwds_2_dynamicfiltersselector1 ;
      private string AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ;
      private string AV69Reembolsowwds_5_workflowconveniodesc1 ;
      private string AV71Reembolsowwds_7_dynamicfiltersselector2 ;
      private string AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ;
      private string AV74Reembolsowwds_10_workflowconveniodesc2 ;
      private string AV76Reembolsowwds_12_dynamicfiltersselector3 ;
      private string AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ;
      private string AV79Reembolsowwds_15_workflowconveniodesc3 ;
      private string AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ;
      private string AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ;
      private string AV82Reembolsowwds_18_tfreembolsoprotocolo ;
      private string AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ;
      private string AV91Reembolsowwds_27_tfworkflowconveniodesc ;
      private string AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ;
      private string lV65Reembolsowwds_1_filterfulltext ;
      private string lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ;
      private string lV69Reembolsowwds_5_workflowconveniodesc1 ;
      private string lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ;
      private string lV74Reembolsowwds_10_workflowconveniodesc2 ;
      private string lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ;
      private string lV79Reembolsowwds_15_workflowconveniodesc3 ;
      private string lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ;
      private string lV82Reembolsowwds_18_tfreembolsoprotocolo ;
      private string lV91Reembolsowwds_27_tfworkflowconveniodesc ;
      private string A548ReembolsoStatusAtual_F ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A736WorkflowConvenioDesc ;
      private string A546ReembolsoProtocolo ;
      private string AV29Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GxSimpleCollection<string> AV23TFReembolsoStatusAtual_F_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00C12_A742WorkflowConvenioId ;
      private bool[] P00C12_n742WorkflowConvenioId ;
      private int[] P00C12_A542ReembolsoPropostaId ;
      private bool[] P00C12_n542ReembolsoPropostaId ;
      private int[] P00C12_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C12_n558ReembolsoPropostaPacienteClienteId ;
      private string[] P00C12_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C12_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private DateTime[] P00C12_A525ReembolsoDataAberturaConvenio ;
      private bool[] P00C12_n525ReembolsoDataAberturaConvenio ;
      private decimal[] P00C12_A543ReembolsoPropostaValor ;
      private bool[] P00C12_n543ReembolsoPropostaValor ;
      private DateTime[] P00C12_A522ReembolsoCreatedAt ;
      private bool[] P00C12_n522ReembolsoCreatedAt ;
      private string[] P00C12_A736WorkflowConvenioDesc ;
      private bool[] P00C12_n736WorkflowConvenioDesc ;
      private string[] P00C12_A546ReembolsoProtocolo ;
      private bool[] P00C12_n546ReembolsoProtocolo ;
      private int[] P00C12_A518ReembolsoId ;
      private bool[] P00C12_n518ReembolsoId ;
      private int[] P00C13_A742WorkflowConvenioId ;
      private bool[] P00C13_n742WorkflowConvenioId ;
      private int[] P00C13_A542ReembolsoPropostaId ;
      private bool[] P00C13_n542ReembolsoPropostaId ;
      private int[] P00C13_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C13_n558ReembolsoPropostaPacienteClienteId ;
      private string[] P00C13_A546ReembolsoProtocolo ;
      private bool[] P00C13_n546ReembolsoProtocolo ;
      private DateTime[] P00C13_A525ReembolsoDataAberturaConvenio ;
      private bool[] P00C13_n525ReembolsoDataAberturaConvenio ;
      private decimal[] P00C13_A543ReembolsoPropostaValor ;
      private bool[] P00C13_n543ReembolsoPropostaValor ;
      private DateTime[] P00C13_A522ReembolsoCreatedAt ;
      private bool[] P00C13_n522ReembolsoCreatedAt ;
      private string[] P00C13_A736WorkflowConvenioDesc ;
      private bool[] P00C13_n736WorkflowConvenioDesc ;
      private string[] P00C13_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C13_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00C13_A518ReembolsoId ;
      private bool[] P00C13_n518ReembolsoId ;
      private int[] P00C14_A542ReembolsoPropostaId ;
      private bool[] P00C14_n542ReembolsoPropostaId ;
      private int[] P00C14_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C14_n558ReembolsoPropostaPacienteClienteId ;
      private int[] P00C14_A742WorkflowConvenioId ;
      private bool[] P00C14_n742WorkflowConvenioId ;
      private DateTime[] P00C14_A525ReembolsoDataAberturaConvenio ;
      private bool[] P00C14_n525ReembolsoDataAberturaConvenio ;
      private decimal[] P00C14_A543ReembolsoPropostaValor ;
      private bool[] P00C14_n543ReembolsoPropostaValor ;
      private DateTime[] P00C14_A522ReembolsoCreatedAt ;
      private bool[] P00C14_n522ReembolsoCreatedAt ;
      private string[] P00C14_A736WorkflowConvenioDesc ;
      private bool[] P00C14_n736WorkflowConvenioDesc ;
      private string[] P00C14_A546ReembolsoProtocolo ;
      private bool[] P00C14_n546ReembolsoProtocolo ;
      private string[] P00C14_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C14_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00C14_A518ReembolsoId ;
      private bool[] P00C14_n518ReembolsoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class reembolsowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C12( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV66Reembolsowwds_2_dynamicfiltersselector1 ,
                                             short AV67Reembolsowwds_3_dynamicfiltersoperator1 ,
                                             string AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                             string AV69Reembolsowwds_5_workflowconveniodesc1 ,
                                             bool AV70Reembolsowwds_6_dynamicfiltersenabled2 ,
                                             string AV71Reembolsowwds_7_dynamicfiltersselector2 ,
                                             short AV72Reembolsowwds_8_dynamicfiltersoperator2 ,
                                             string AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                             string AV74Reembolsowwds_10_workflowconveniodesc2 ,
                                             bool AV75Reembolsowwds_11_dynamicfiltersenabled3 ,
                                             string AV76Reembolsowwds_12_dynamicfiltersselector3 ,
                                             short AV77Reembolsowwds_13_dynamicfiltersoperator3 ,
                                             string AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                             string AV79Reembolsowwds_15_workflowconveniodesc3 ,
                                             string AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                             string AV82Reembolsowwds_18_tfreembolsoprotocolo ,
                                             DateTime AV84Reembolsowwds_20_tfreembolsocreatedat ,
                                             DateTime AV85Reembolsowwds_21_tfreembolsocreatedat_to ,
                                             decimal AV86Reembolsowwds_22_tfreembolsopropostavalor ,
                                             decimal AV87Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                             DateTime AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                             DateTime AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                             string AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                             string AV91Reembolsowwds_27_tfworkflowconveniodesc ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             string A736WorkflowConvenioDesc ,
                                             string A546ReembolsoProtocolo ,
                                             DateTime A522ReembolsoCreatedAt ,
                                             decimal A543ReembolsoPropostaValor ,
                                             DateTime A525ReembolsoDataAberturaConvenio ,
                                             string AV65Reembolsowwds_1_filterfulltext ,
                                             int AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[25];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.WorkflowConvenioId, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoDataAberturaConvenio, T3.PropostaValor AS ReembolsoPropostaValor, T1.ReembolsoCreatedAt, T2.WorkflowConvenioDesc, T1.ReembolsoProtocolo, T1.ReembolsoId FROM (((Reembolso T1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.WorkflowConvenioId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId)";
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV69Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV69Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV74Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV74Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV79Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV79Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reembolsowwds_18_tfreembolsoprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo like :lV82Reembolsowwds_18_tfreembolsoprotocolo)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ! ( StringUtil.StrCmp(AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo = ( :AV83Reembolsowwds_19_tfreembolsoprotocolo_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoProtocolo))=0))");
         }
         if ( ! (DateTime.MinValue==AV84Reembolsowwds_20_tfreembolsocreatedat) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt >= :AV84Reembolsowwds_20_tfreembolsocreatedat)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Reembolsowwds_21_tfreembolsocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt <= :AV85Reembolsowwds_21_tfreembolsocreatedat_to)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Reembolsowwds_22_tfreembolsopropostavalor) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor >= :AV86Reembolsowwds_22_tfreembolsopropostavalor)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Reembolsowwds_23_tfreembolsopropostavalor_to) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor <= :AV87Reembolsowwds_23_tfreembolsopropostavalor_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio >= :AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio <= :AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reembolsowwds_27_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV91Reembolsowwds_27_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV92Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV92Reembolsowwds_28_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV92Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00C13( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV66Reembolsowwds_2_dynamicfiltersselector1 ,
                                             short AV67Reembolsowwds_3_dynamicfiltersoperator1 ,
                                             string AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                             string AV69Reembolsowwds_5_workflowconveniodesc1 ,
                                             bool AV70Reembolsowwds_6_dynamicfiltersenabled2 ,
                                             string AV71Reembolsowwds_7_dynamicfiltersselector2 ,
                                             short AV72Reembolsowwds_8_dynamicfiltersoperator2 ,
                                             string AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                             string AV74Reembolsowwds_10_workflowconveniodesc2 ,
                                             bool AV75Reembolsowwds_11_dynamicfiltersenabled3 ,
                                             string AV76Reembolsowwds_12_dynamicfiltersselector3 ,
                                             short AV77Reembolsowwds_13_dynamicfiltersoperator3 ,
                                             string AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                             string AV79Reembolsowwds_15_workflowconveniodesc3 ,
                                             string AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                             string AV82Reembolsowwds_18_tfreembolsoprotocolo ,
                                             DateTime AV84Reembolsowwds_20_tfreembolsocreatedat ,
                                             DateTime AV85Reembolsowwds_21_tfreembolsocreatedat_to ,
                                             decimal AV86Reembolsowwds_22_tfreembolsopropostavalor ,
                                             decimal AV87Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                             DateTime AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                             DateTime AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                             string AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                             string AV91Reembolsowwds_27_tfworkflowconveniodesc ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             string A736WorkflowConvenioDesc ,
                                             string A546ReembolsoProtocolo ,
                                             DateTime A522ReembolsoCreatedAt ,
                                             decimal A543ReembolsoPropostaValor ,
                                             DateTime A525ReembolsoDataAberturaConvenio ,
                                             string AV65Reembolsowwds_1_filterfulltext ,
                                             int AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[25];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.WorkflowConvenioId, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.ReembolsoProtocolo, T1.ReembolsoDataAberturaConvenio, T3.PropostaValor AS ReembolsoPropostaValor, T1.ReembolsoCreatedAt, T2.WorkflowConvenioDesc, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoId FROM (((Reembolso T1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.WorkflowConvenioId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId)";
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV69Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV69Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV74Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV74Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV79Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV79Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reembolsowwds_18_tfreembolsoprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo like :lV82Reembolsowwds_18_tfreembolsoprotocolo)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ! ( StringUtil.StrCmp(AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo = ( :AV83Reembolsowwds_19_tfreembolsoprotocolo_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoProtocolo))=0))");
         }
         if ( ! (DateTime.MinValue==AV84Reembolsowwds_20_tfreembolsocreatedat) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt >= :AV84Reembolsowwds_20_tfreembolsocreatedat)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Reembolsowwds_21_tfreembolsocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt <= :AV85Reembolsowwds_21_tfreembolsocreatedat_to)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Reembolsowwds_22_tfreembolsopropostavalor) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor >= :AV86Reembolsowwds_22_tfreembolsopropostavalor)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Reembolsowwds_23_tfreembolsopropostavalor_to) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor <= :AV87Reembolsowwds_23_tfreembolsopropostavalor_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio >= :AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio <= :AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reembolsowwds_27_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV91Reembolsowwds_27_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV92Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV92Reembolsowwds_28_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV92Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ReembolsoProtocolo";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00C14( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV66Reembolsowwds_2_dynamicfiltersselector1 ,
                                             short AV67Reembolsowwds_3_dynamicfiltersoperator1 ,
                                             string AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                             string AV69Reembolsowwds_5_workflowconveniodesc1 ,
                                             bool AV70Reembolsowwds_6_dynamicfiltersenabled2 ,
                                             string AV71Reembolsowwds_7_dynamicfiltersselector2 ,
                                             short AV72Reembolsowwds_8_dynamicfiltersoperator2 ,
                                             string AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                             string AV74Reembolsowwds_10_workflowconveniodesc2 ,
                                             bool AV75Reembolsowwds_11_dynamicfiltersenabled3 ,
                                             string AV76Reembolsowwds_12_dynamicfiltersselector3 ,
                                             short AV77Reembolsowwds_13_dynamicfiltersoperator3 ,
                                             string AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                             string AV79Reembolsowwds_15_workflowconveniodesc3 ,
                                             string AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV83Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                             string AV82Reembolsowwds_18_tfreembolsoprotocolo ,
                                             DateTime AV84Reembolsowwds_20_tfreembolsocreatedat ,
                                             DateTime AV85Reembolsowwds_21_tfreembolsocreatedat_to ,
                                             decimal AV86Reembolsowwds_22_tfreembolsopropostavalor ,
                                             decimal AV87Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                             DateTime AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                             DateTime AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                             string AV92Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                             string AV91Reembolsowwds_27_tfworkflowconveniodesc ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             string A736WorkflowConvenioDesc ,
                                             string A546ReembolsoProtocolo ,
                                             DateTime A522ReembolsoCreatedAt ,
                                             decimal A543ReembolsoPropostaValor ,
                                             DateTime A525ReembolsoDataAberturaConvenio ,
                                             string AV65Reembolsowwds_1_filterfulltext ,
                                             int AV90Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[25];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ReembolsoPropostaId AS ReembolsoPropostaId, T2.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.WorkflowConvenioId, T1.ReembolsoDataAberturaConvenio, T2.PropostaValor AS ReembolsoPropostaValor, T1.ReembolsoCreatedAt, T4.WorkflowConvenioDesc, T1.ReembolsoProtocolo, T3.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoId FROM (((Reembolso T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T4 ON T4.WorkflowConvenioId = T1.WorkflowConvenioId)";
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like '%' || :lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like :lV69Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV67Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like '%' || :lV69Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like '%' || :lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like :lV74Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV70Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV72Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like '%' || :lV74Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like '%' || :lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like :lV79Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV75Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV77Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like '%' || :lV79Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reembolsowwds_18_tfreembolsoprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo like :lV82Reembolsowwds_18_tfreembolsoprotocolo)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ! ( StringUtil.StrCmp(AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo = ( :AV83Reembolsowwds_19_tfreembolsoprotocolo_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV83Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoProtocolo))=0))");
         }
         if ( ! (DateTime.MinValue==AV84Reembolsowwds_20_tfreembolsocreatedat) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt >= :AV84Reembolsowwds_20_tfreembolsocreatedat)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Reembolsowwds_21_tfreembolsocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt <= :AV85Reembolsowwds_21_tfreembolsocreatedat_to)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Reembolsowwds_22_tfreembolsopropostavalor) )
         {
            AddWhere(sWhereString, "(T2.PropostaValor >= :AV86Reembolsowwds_22_tfreembolsopropostavalor)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Reembolsowwds_23_tfreembolsopropostavalor_to) )
         {
            AddWhere(sWhereString, "(T2.PropostaValor <= :AV87Reembolsowwds_23_tfreembolsopropostavalor_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio >= :AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio <= :AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reembolsowwds_27_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like :lV91Reembolsowwds_27_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV92Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc = ( :AV92Reembolsowwds_28_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV92Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T4.WorkflowConvenioDesc))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkflowConvenioId";
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
                     return conditional_P00C12(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (decimal)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] );
               case 1 :
                     return conditional_P00C13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (decimal)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] );
               case 2 :
                     return conditional_P00C14(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (decimal)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] );
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
          Object[] prmP00C12;
          prmP00C12 = new Object[] {
          new ParDef("AV90ReemCount",GXType.Int32,9,0) ,
          new ParDef("lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV69Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV69Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV74Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV74Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV79Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV79Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV82Reembolsowwds_18_tfreembolsoprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV83Reembolsowwds_19_tfreembolsoprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV84Reembolsowwds_20_tfreembolsocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV85Reembolsowwds_21_tfreembolsocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV86Reembolsowwds_22_tfreembolsopropostavalor",GXType.Number,18,2) ,
          new ParDef("AV87Reembolsowwds_23_tfreembolsopropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio",GXType.Date,8,0) ,
          new ParDef("AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to",GXType.Date,8,0) ,
          new ParDef("lV91Reembolsowwds_27_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV92Reembolsowwds_28_tfworkflowconveniodesc_sel",GXType.VarChar,60,0)
          };
          Object[] prmP00C13;
          prmP00C13 = new Object[] {
          new ParDef("AV90ReemCount",GXType.Int32,9,0) ,
          new ParDef("lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV69Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV69Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV74Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV74Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV79Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV79Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV82Reembolsowwds_18_tfreembolsoprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV83Reembolsowwds_19_tfreembolsoprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV84Reembolsowwds_20_tfreembolsocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV85Reembolsowwds_21_tfreembolsocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV86Reembolsowwds_22_tfreembolsopropostavalor",GXType.Number,18,2) ,
          new ParDef("AV87Reembolsowwds_23_tfreembolsopropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio",GXType.Date,8,0) ,
          new ParDef("AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to",GXType.Date,8,0) ,
          new ParDef("lV91Reembolsowwds_27_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV92Reembolsowwds_28_tfworkflowconveniodesc_sel",GXType.VarChar,60,0)
          };
          Object[] prmP00C14;
          prmP00C14 = new Object[] {
          new ParDef("AV90ReemCount",GXType.Int32,9,0) ,
          new ParDef("lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV68Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV69Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV69Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV73Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV74Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV74Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV78Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV79Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV79Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV80Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("AV81Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV82Reembolsowwds_18_tfreembolsoprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV83Reembolsowwds_19_tfreembolsoprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV84Reembolsowwds_20_tfreembolsocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV85Reembolsowwds_21_tfreembolsocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV86Reembolsowwds_22_tfreembolsopropostavalor",GXType.Number,18,2) ,
          new ParDef("AV87Reembolsowwds_23_tfreembolsopropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Reembolsowwds_24_tfreembolsodataaberturaconvenio",GXType.Date,8,0) ,
          new ParDef("AV89Reembolsowwds_25_tfreembolsodataaberturaconvenio_to",GXType.Date,8,0) ,
          new ParDef("lV91Reembolsowwds_27_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV92Reembolsowwds_28_tfworkflowconveniodesc_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C14,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
