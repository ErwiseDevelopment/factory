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
   public class propostacontratowwgetfilterdata : GXProcedure
   {
      public propostacontratowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratowwgetfilterdata( IGxContext context )
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
         this.AV44DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV46SearchTxtTo = aP2_SearchTxtTo;
         this.AV47OptionsJson = "" ;
         this.AV48OptionsDescJson = "" ;
         this.AV49OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV47OptionsJson;
         aP4_OptionsDescJson=this.AV48OptionsDescJson;
         aP5_OptionIndexesJson=this.AV49OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV49OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV44DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV46SearchTxtTo = aP2_SearchTxtTo;
         this.AV47OptionsJson = "" ;
         this.AV48OptionsDescJson = "" ;
         this.AV49OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV47OptionsJson;
         aP4_OptionsDescJson=this.AV48OptionsDescJson;
         aP5_OptionIndexesJson=this.AV49OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV34Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31MaxItems = 10;
         AV30PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV45SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV28SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? "" : StringUtil.Substring( AV45SearchTxtParms, 3, -1));
         AV29SkipItems = (short)(AV30PageIndex*AV31MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_PROCEDIMENTOSMEDICOSNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROCEDIMENTOSMEDICOSNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_PROPOSTADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTADESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_CONTRATONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTRATONOMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_WORKFLOWPASSO_F") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKFLOWPASSO_FOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV47OptionsJson = AV34Options.ToJSonString(false);
         AV48OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV49OptionIndexesJson = AV37OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("PropostaContratoWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaContratoWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("PropostaContratoWWGridState"), null, "", "");
         }
         AV89GXV1 = 1;
         while ( AV89GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV89GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV79TFProcedimentosMedicosNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV80TFProcedimentosMedicosNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV14TFPropostaDescricao = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV15TFPropostaDescricao_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV16TFPropostaValor = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV17TFPropostaValor_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV62TFContratoNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV63TFContratoNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV81TFPropostaPacienteClienteRazaoSocial = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV82TFPropostaPacienteClienteRazaoSocial_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV83TFReembolsoStatusAtual_F_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV84TFReembolsoStatusAtual_F_Sels.FromJSonString(AV83TFReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWORKFLOWPASSO_F") == 0 )
            {
               AV87TFWorkFlowPasso_F = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWORKFLOWPASSO_F_SEL") == 0 )
            {
               AV88TFWorkFlowPasso_F_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV89GXV1 = (int)(AV89GXV1+1);
         }
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV51DynamicFiltersSelector1 = AV43GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "PROPOSTATITULO") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV53PropostaTitulo1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV74ContratoNome1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV54DynamicFiltersEnabled2 = true;
               AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV55DynamicFiltersSelector2 = AV43GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "PROPOSTATITULO") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV57PropostaTitulo2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV75ContratoNome2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV58DynamicFiltersEnabled3 = true;
                  AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV59DynamicFiltersSelector3 = AV43GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "PROPOSTATITULO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV61PropostaTitulo3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV76ContratoNome3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROCEDIMENTOSMEDICOSNOMEOPTIONS' Routine */
         returnInSub = false;
         AV79TFProcedimentosMedicosNome = AV28SearchTxt;
         AV80TFProcedimentosMedicosNome_Sel = "";
         AV91Propostacontratowwds_1_filterfulltext = AV50FilterFullText;
         AV92Propostacontratowwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV93Propostacontratowwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV94Propostacontratowwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV95Propostacontratowwds_5_contratonome1 = AV74ContratoNome1;
         AV96Propostacontratowwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV97Propostacontratowwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV98Propostacontratowwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV99Propostacontratowwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV100Propostacontratowwds_10_contratonome2 = AV75ContratoNome2;
         AV101Propostacontratowwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV102Propostacontratowwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV103Propostacontratowwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV104Propostacontratowwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV105Propostacontratowwds_15_contratonome3 = AV76ContratoNome3;
         AV106Propostacontratowwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV108Propostacontratowwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV109Propostacontratowwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV110Propostacontratowwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV111Propostacontratowwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV112Propostacontratowwds_22_tfcontratonome = AV62TFContratoNome;
         AV113Propostacontratowwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         AV117Propostacontratowwds_27_tfworkflowpasso_f = AV87TFWorkFlowPasso_F;
         AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = AV88TFWorkFlowPasso_F_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              AV94Propostacontratowwds_4_propostatitulo1 ,
                                              AV95Propostacontratowwds_5_contratonome1 ,
                                              AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              AV99Propostacontratowwds_9_propostatitulo2 ,
                                              AV100Propostacontratowwds_10_contratonome2 ,
                                              AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              AV104Propostacontratowwds_14_propostatitulo3 ,
                                              AV105Propostacontratowwds_15_contratonome3 ,
                                              AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              AV110Propostacontratowwds_20_tfpropostavalor ,
                                              AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              AV112Propostacontratowwds_22_tfcontratonome ,
                                              AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV91Propostacontratowwds_1_filterfulltext ,
                                              A792WorkFlowPasso_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV117Propostacontratowwds_27_tfworkflowpasso_f = StringUtil.Concat( StringUtil.RTrim( AV117Propostacontratowwds_27_tfworkflowpasso_f), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV106Propostacontratowwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome), "%", "");
         lV108Propostacontratowwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao), "%", "");
         lV112Propostacontratowwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome), "%", "");
         lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00AP5 */
         pr_default.execute(0, new Object[] {AV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV117Propostacontratowwds_27_tfworkflowpasso_f, lV117Propostacontratowwds_27_tfworkflowpasso_f, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV94Propostacontratowwds_4_propostatitulo1, lV94Propostacontratowwds_4_propostatitulo1, lV95Propostacontratowwds_5_contratonome1, lV95Propostacontratowwds_5_contratonome1, lV99Propostacontratowwds_9_propostatitulo2, lV99Propostacontratowwds_9_propostatitulo2, lV100Propostacontratowwds_10_contratonome2, lV100Propostacontratowwds_10_contratonome2, lV104Propostacontratowwds_14_propostatitulo3, lV104Propostacontratowwds_14_propostatitulo3, lV105Propostacontratowwds_15_contratonome3, lV105Propostacontratowwds_15_contratonome3, lV106Propostacontratowwds_16_tfprocedimentosmedicosnome, AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, lV108Propostacontratowwds_18_tfpropostadescricao, AV109Propostacontratowwds_19_tfpropostadescricao_sel, AV110Propostacontratowwds_20_tfpropostavalor, AV111Propostacontratowwds_21_tfpropostavalor_to, lV112Propostacontratowwds_22_tfcontratonome, AV113Propostacontratowwds_23_tfcontratonome_sel, lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial, AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAP2 = false;
            A227ContratoId = P00AP5_A227ContratoId[0];
            n227ContratoId = P00AP5_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00AP5_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00AP5_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P00AP5_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AP5_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AP5_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AP5_n504PropostaPacienteClienteId[0];
            A329PropostaStatus = P00AP5_A329PropostaStatus[0];
            n329PropostaStatus = P00AP5_n329PropostaStatus[0];
            A377ProcedimentosMedicosNome = P00AP5_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP5_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P00AP5_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP5_n210SecUserClienteId[0];
            A642PropostaClinicaId = P00AP5_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AP5_n642PropostaClinicaId[0];
            A326PropostaValor = P00AP5_A326PropostaValor[0];
            n326PropostaValor = P00AP5_n326PropostaValor[0];
            A324PropostaTitulo = P00AP5_A324PropostaTitulo[0];
            n324PropostaTitulo = P00AP5_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP5_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00AP5_A228ContratoNome[0];
            n228ContratoNome = P00AP5_n228ContratoNome[0];
            A325PropostaDescricao = P00AP5_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AP5_n325PropostaDescricao[0];
            A792WorkFlowPasso_F = P00AP5_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP5_n792WorkFlowPasso_F[0];
            A323PropostaId = P00AP5_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00AP5_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP5_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00AP5_A228ContratoNome[0];
            n228ContratoNome = P00AP5_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00AP5_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP5_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P00AP5_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP5_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP5_n505PropostaPacienteClienteRazaoSocial[0];
            A792WorkFlowPasso_F = P00AP5_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP5_n792WorkFlowPasso_F[0];
            A548ReembolsoStatusAtual_F = P00AP5_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP5_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AP5_A377ProcedimentosMedicosNome[0], A377ProcedimentosMedicosNome) == 0 ) )
            {
               BRKAP2 = false;
               A376ProcedimentosMedicosId = P00AP5_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = P00AP5_n376ProcedimentosMedicosId[0];
               A323PropostaId = P00AP5_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKAP2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A377ProcedimentosMedicosNome)) ? "<#Empty#>" : A377ProcedimentosMedicosNome);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKAP2 )
            {
               BRKAP2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROPOSTADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV14TFPropostaDescricao = AV28SearchTxt;
         AV15TFPropostaDescricao_Sel = "";
         AV91Propostacontratowwds_1_filterfulltext = AV50FilterFullText;
         AV92Propostacontratowwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV93Propostacontratowwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV94Propostacontratowwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV95Propostacontratowwds_5_contratonome1 = AV74ContratoNome1;
         AV96Propostacontratowwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV97Propostacontratowwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV98Propostacontratowwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV99Propostacontratowwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV100Propostacontratowwds_10_contratonome2 = AV75ContratoNome2;
         AV101Propostacontratowwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV102Propostacontratowwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV103Propostacontratowwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV104Propostacontratowwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV105Propostacontratowwds_15_contratonome3 = AV76ContratoNome3;
         AV106Propostacontratowwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV108Propostacontratowwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV109Propostacontratowwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV110Propostacontratowwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV111Propostacontratowwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV112Propostacontratowwds_22_tfcontratonome = AV62TFContratoNome;
         AV113Propostacontratowwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         AV117Propostacontratowwds_27_tfworkflowpasso_f = AV87TFWorkFlowPasso_F;
         AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = AV88TFWorkFlowPasso_F_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              AV94Propostacontratowwds_4_propostatitulo1 ,
                                              AV95Propostacontratowwds_5_contratonome1 ,
                                              AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              AV99Propostacontratowwds_9_propostatitulo2 ,
                                              AV100Propostacontratowwds_10_contratonome2 ,
                                              AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              AV104Propostacontratowwds_14_propostatitulo3 ,
                                              AV105Propostacontratowwds_15_contratonome3 ,
                                              AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              AV110Propostacontratowwds_20_tfpropostavalor ,
                                              AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              AV112Propostacontratowwds_22_tfcontratonome ,
                                              AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV91Propostacontratowwds_1_filterfulltext ,
                                              A792WorkFlowPasso_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV117Propostacontratowwds_27_tfworkflowpasso_f = StringUtil.Concat( StringUtil.RTrim( AV117Propostacontratowwds_27_tfworkflowpasso_f), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV106Propostacontratowwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome), "%", "");
         lV108Propostacontratowwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao), "%", "");
         lV112Propostacontratowwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome), "%", "");
         lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00AP9 */
         pr_default.execute(1, new Object[] {AV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV117Propostacontratowwds_27_tfworkflowpasso_f, lV117Propostacontratowwds_27_tfworkflowpasso_f, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV94Propostacontratowwds_4_propostatitulo1, lV94Propostacontratowwds_4_propostatitulo1, lV95Propostacontratowwds_5_contratonome1, lV95Propostacontratowwds_5_contratonome1, lV99Propostacontratowwds_9_propostatitulo2, lV99Propostacontratowwds_9_propostatitulo2, lV100Propostacontratowwds_10_contratonome2, lV100Propostacontratowwds_10_contratonome2, lV104Propostacontratowwds_14_propostatitulo3, lV104Propostacontratowwds_14_propostatitulo3, lV105Propostacontratowwds_15_contratonome3, lV105Propostacontratowwds_15_contratonome3, lV106Propostacontratowwds_16_tfprocedimentosmedicosnome, AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, lV108Propostacontratowwds_18_tfpropostadescricao, AV109Propostacontratowwds_19_tfpropostadescricao_sel, AV110Propostacontratowwds_20_tfpropostavalor, AV111Propostacontratowwds_21_tfpropostavalor_to, lV112Propostacontratowwds_22_tfcontratonome, AV113Propostacontratowwds_23_tfcontratonome_sel, lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial, AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAP4 = false;
            A227ContratoId = P00AP9_A227ContratoId[0];
            n227ContratoId = P00AP9_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00AP9_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00AP9_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P00AP9_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AP9_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AP9_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AP9_n504PropostaPacienteClienteId[0];
            A329PropostaStatus = P00AP9_A329PropostaStatus[0];
            n329PropostaStatus = P00AP9_n329PropostaStatus[0];
            A325PropostaDescricao = P00AP9_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AP9_n325PropostaDescricao[0];
            A210SecUserClienteId = P00AP9_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP9_n210SecUserClienteId[0];
            A642PropostaClinicaId = P00AP9_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AP9_n642PropostaClinicaId[0];
            A326PropostaValor = P00AP9_A326PropostaValor[0];
            n326PropostaValor = P00AP9_n326PropostaValor[0];
            A324PropostaTitulo = P00AP9_A324PropostaTitulo[0];
            n324PropostaTitulo = P00AP9_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP9_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP9_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00AP9_A228ContratoNome[0];
            n228ContratoNome = P00AP9_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00AP9_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP9_n377ProcedimentosMedicosNome[0];
            A792WorkFlowPasso_F = P00AP9_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP9_n792WorkFlowPasso_F[0];
            A323PropostaId = P00AP9_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00AP9_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP9_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00AP9_A228ContratoNome[0];
            n228ContratoNome = P00AP9_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00AP9_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP9_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P00AP9_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP9_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP9_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP9_n505PropostaPacienteClienteRazaoSocial[0];
            A792WorkFlowPasso_F = P00AP9_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP9_n792WorkFlowPasso_F[0];
            A548ReembolsoStatusAtual_F = P00AP9_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP9_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AP9_A325PropostaDescricao[0], A325PropostaDescricao) == 0 ) )
            {
               BRKAP4 = false;
               A323PropostaId = P00AP9_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKAP4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? "<#Empty#>" : A325PropostaDescricao);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKAP4 )
            {
               BRKAP4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCONTRATONOMEOPTIONS' Routine */
         returnInSub = false;
         AV62TFContratoNome = AV28SearchTxt;
         AV63TFContratoNome_Sel = "";
         AV91Propostacontratowwds_1_filterfulltext = AV50FilterFullText;
         AV92Propostacontratowwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV93Propostacontratowwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV94Propostacontratowwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV95Propostacontratowwds_5_contratonome1 = AV74ContratoNome1;
         AV96Propostacontratowwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV97Propostacontratowwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV98Propostacontratowwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV99Propostacontratowwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV100Propostacontratowwds_10_contratonome2 = AV75ContratoNome2;
         AV101Propostacontratowwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV102Propostacontratowwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV103Propostacontratowwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV104Propostacontratowwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV105Propostacontratowwds_15_contratonome3 = AV76ContratoNome3;
         AV106Propostacontratowwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV108Propostacontratowwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV109Propostacontratowwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV110Propostacontratowwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV111Propostacontratowwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV112Propostacontratowwds_22_tfcontratonome = AV62TFContratoNome;
         AV113Propostacontratowwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         AV117Propostacontratowwds_27_tfworkflowpasso_f = AV87TFWorkFlowPasso_F;
         AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = AV88TFWorkFlowPasso_F_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              AV94Propostacontratowwds_4_propostatitulo1 ,
                                              AV95Propostacontratowwds_5_contratonome1 ,
                                              AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              AV99Propostacontratowwds_9_propostatitulo2 ,
                                              AV100Propostacontratowwds_10_contratonome2 ,
                                              AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              AV104Propostacontratowwds_14_propostatitulo3 ,
                                              AV105Propostacontratowwds_15_contratonome3 ,
                                              AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              AV110Propostacontratowwds_20_tfpropostavalor ,
                                              AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              AV112Propostacontratowwds_22_tfcontratonome ,
                                              AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV91Propostacontratowwds_1_filterfulltext ,
                                              A792WorkFlowPasso_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV117Propostacontratowwds_27_tfworkflowpasso_f = StringUtil.Concat( StringUtil.RTrim( AV117Propostacontratowwds_27_tfworkflowpasso_f), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV106Propostacontratowwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome), "%", "");
         lV108Propostacontratowwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao), "%", "");
         lV112Propostacontratowwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome), "%", "");
         lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00AP13 */
         pr_default.execute(2, new Object[] {AV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV117Propostacontratowwds_27_tfworkflowpasso_f, lV117Propostacontratowwds_27_tfworkflowpasso_f, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV94Propostacontratowwds_4_propostatitulo1, lV94Propostacontratowwds_4_propostatitulo1, lV95Propostacontratowwds_5_contratonome1, lV95Propostacontratowwds_5_contratonome1, lV99Propostacontratowwds_9_propostatitulo2, lV99Propostacontratowwds_9_propostatitulo2, lV100Propostacontratowwds_10_contratonome2, lV100Propostacontratowwds_10_contratonome2, lV104Propostacontratowwds_14_propostatitulo3, lV104Propostacontratowwds_14_propostatitulo3, lV105Propostacontratowwds_15_contratonome3, lV105Propostacontratowwds_15_contratonome3, lV106Propostacontratowwds_16_tfprocedimentosmedicosnome, AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, lV108Propostacontratowwds_18_tfpropostadescricao, AV109Propostacontratowwds_19_tfpropostadescricao_sel, AV110Propostacontratowwds_20_tfpropostavalor, AV111Propostacontratowwds_21_tfpropostavalor_to, lV112Propostacontratowwds_22_tfcontratonome, AV113Propostacontratowwds_23_tfcontratonome_sel, lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial, AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAP6 = false;
            A376ProcedimentosMedicosId = P00AP13_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00AP13_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P00AP13_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AP13_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AP13_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AP13_n504PropostaPacienteClienteId[0];
            A227ContratoId = P00AP13_A227ContratoId[0];
            n227ContratoId = P00AP13_n227ContratoId[0];
            A329PropostaStatus = P00AP13_A329PropostaStatus[0];
            n329PropostaStatus = P00AP13_n329PropostaStatus[0];
            A210SecUserClienteId = P00AP13_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP13_n210SecUserClienteId[0];
            A642PropostaClinicaId = P00AP13_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AP13_n642PropostaClinicaId[0];
            A326PropostaValor = P00AP13_A326PropostaValor[0];
            n326PropostaValor = P00AP13_n326PropostaValor[0];
            A324PropostaTitulo = P00AP13_A324PropostaTitulo[0];
            n324PropostaTitulo = P00AP13_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP13_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00AP13_A228ContratoNome[0];
            n228ContratoNome = P00AP13_n228ContratoNome[0];
            A325PropostaDescricao = P00AP13_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AP13_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P00AP13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP13_n377ProcedimentosMedicosNome[0];
            A792WorkFlowPasso_F = P00AP13_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP13_n792WorkFlowPasso_F[0];
            A323PropostaId = P00AP13_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00AP13_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP13_n548ReembolsoStatusAtual_F[0];
            A377ProcedimentosMedicosNome = P00AP13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP13_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P00AP13_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP13_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP13_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00AP13_A228ContratoNome[0];
            n228ContratoNome = P00AP13_n228ContratoNome[0];
            A792WorkFlowPasso_F = P00AP13_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP13_n792WorkFlowPasso_F[0];
            A548ReembolsoStatusAtual_F = P00AP13_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP13_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00AP13_A227ContratoId[0] == A227ContratoId ) )
            {
               BRKAP6 = false;
               A323PropostaId = P00AP13_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKAP6 = true;
               pr_default.readNext(2);
            }
            AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? "<#Empty#>" : A228ContratoNome);
            AV32InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV33Option, "<#Empty#>") != 0 ) && ( AV32InsertIndex <= AV34Options.Count ) && ( ( StringUtil.StrCmp(((string)AV34Options.Item(AV32InsertIndex)), AV33Option) < 0 ) || ( StringUtil.StrCmp(((string)AV34Options.Item(AV32InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV32InsertIndex = (int)(AV32InsertIndex+1);
            }
            AV34Options.Add(AV33Option, AV32InsertIndex);
            AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), AV32InsertIndex);
            if ( AV34Options.Count == AV29SkipItems + 11 )
            {
               AV34Options.RemoveItem(AV34Options.Count);
               AV37OptionIndexes.RemoveItem(AV37OptionIndexes.Count);
            }
            if ( ! BRKAP6 )
            {
               BRKAP6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV29SkipItems > 0 )
         {
            AV34Options.RemoveItem(1);
            AV37OptionIndexes.RemoveItem(1);
            AV29SkipItems = (short)(AV29SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV81TFPropostaPacienteClienteRazaoSocial = AV28SearchTxt;
         AV82TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV91Propostacontratowwds_1_filterfulltext = AV50FilterFullText;
         AV92Propostacontratowwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV93Propostacontratowwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV94Propostacontratowwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV95Propostacontratowwds_5_contratonome1 = AV74ContratoNome1;
         AV96Propostacontratowwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV97Propostacontratowwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV98Propostacontratowwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV99Propostacontratowwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV100Propostacontratowwds_10_contratonome2 = AV75ContratoNome2;
         AV101Propostacontratowwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV102Propostacontratowwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV103Propostacontratowwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV104Propostacontratowwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV105Propostacontratowwds_15_contratonome3 = AV76ContratoNome3;
         AV106Propostacontratowwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV108Propostacontratowwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV109Propostacontratowwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV110Propostacontratowwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV111Propostacontratowwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV112Propostacontratowwds_22_tfcontratonome = AV62TFContratoNome;
         AV113Propostacontratowwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         AV117Propostacontratowwds_27_tfworkflowpasso_f = AV87TFWorkFlowPasso_F;
         AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = AV88TFWorkFlowPasso_F_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              AV94Propostacontratowwds_4_propostatitulo1 ,
                                              AV95Propostacontratowwds_5_contratonome1 ,
                                              AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              AV99Propostacontratowwds_9_propostatitulo2 ,
                                              AV100Propostacontratowwds_10_contratonome2 ,
                                              AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              AV104Propostacontratowwds_14_propostatitulo3 ,
                                              AV105Propostacontratowwds_15_contratonome3 ,
                                              AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              AV110Propostacontratowwds_20_tfpropostavalor ,
                                              AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              AV112Propostacontratowwds_22_tfcontratonome ,
                                              AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV91Propostacontratowwds_1_filterfulltext ,
                                              A792WorkFlowPasso_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV117Propostacontratowwds_27_tfworkflowpasso_f = StringUtil.Concat( StringUtil.RTrim( AV117Propostacontratowwds_27_tfworkflowpasso_f), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV106Propostacontratowwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome), "%", "");
         lV108Propostacontratowwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao), "%", "");
         lV112Propostacontratowwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome), "%", "");
         lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00AP17 */
         pr_default.execute(3, new Object[] {AV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV117Propostacontratowwds_27_tfworkflowpasso_f, lV117Propostacontratowwds_27_tfworkflowpasso_f, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV94Propostacontratowwds_4_propostatitulo1, lV94Propostacontratowwds_4_propostatitulo1, lV95Propostacontratowwds_5_contratonome1, lV95Propostacontratowwds_5_contratonome1, lV99Propostacontratowwds_9_propostatitulo2, lV99Propostacontratowwds_9_propostatitulo2, lV100Propostacontratowwds_10_contratonome2, lV100Propostacontratowwds_10_contratonome2, lV104Propostacontratowwds_14_propostatitulo3, lV104Propostacontratowwds_14_propostatitulo3, lV105Propostacontratowwds_15_contratonome3, lV105Propostacontratowwds_15_contratonome3, lV106Propostacontratowwds_16_tfprocedimentosmedicosnome, AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, lV108Propostacontratowwds_18_tfpropostadescricao, AV109Propostacontratowwds_19_tfpropostadescricao_sel, AV110Propostacontratowwds_20_tfpropostavalor, AV111Propostacontratowwds_21_tfpropostavalor_to, lV112Propostacontratowwds_22_tfcontratonome, AV113Propostacontratowwds_23_tfcontratonome_sel, lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial, AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKAP8 = false;
            A227ContratoId = P00AP17_A227ContratoId[0];
            n227ContratoId = P00AP17_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00AP17_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00AP17_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P00AP17_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AP17_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AP17_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AP17_n504PropostaPacienteClienteId[0];
            A329PropostaStatus = P00AP17_A329PropostaStatus[0];
            n329PropostaStatus = P00AP17_n329PropostaStatus[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP17_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP17_n505PropostaPacienteClienteRazaoSocial[0];
            A210SecUserClienteId = P00AP17_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP17_n210SecUserClienteId[0];
            A642PropostaClinicaId = P00AP17_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AP17_n642PropostaClinicaId[0];
            A326PropostaValor = P00AP17_A326PropostaValor[0];
            n326PropostaValor = P00AP17_n326PropostaValor[0];
            A324PropostaTitulo = P00AP17_A324PropostaTitulo[0];
            n324PropostaTitulo = P00AP17_n324PropostaTitulo[0];
            A228ContratoNome = P00AP17_A228ContratoNome[0];
            n228ContratoNome = P00AP17_n228ContratoNome[0];
            A325PropostaDescricao = P00AP17_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AP17_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P00AP17_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP17_n377ProcedimentosMedicosNome[0];
            A792WorkFlowPasso_F = P00AP17_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP17_n792WorkFlowPasso_F[0];
            A323PropostaId = P00AP17_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00AP17_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP17_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00AP17_A228ContratoNome[0];
            n228ContratoNome = P00AP17_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00AP17_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP17_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P00AP17_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP17_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP17_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP17_n505PropostaPacienteClienteRazaoSocial[0];
            A792WorkFlowPasso_F = P00AP17_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP17_n792WorkFlowPasso_F[0];
            A548ReembolsoStatusAtual_F = P00AP17_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP17_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00AP17_A505PropostaPacienteClienteRazaoSocial[0], A505PropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRKAP8 = false;
               A504PropostaPacienteClienteId = P00AP17_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = P00AP17_n504PropostaPacienteClienteId[0];
               A323PropostaId = P00AP17_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKAP8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A505PropostaPacienteClienteRazaoSocial)) ? "<#Empty#>" : A505PropostaPacienteClienteRazaoSocial);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKAP8 )
            {
               BRKAP8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADWORKFLOWPASSO_FOPTIONS' Routine */
         returnInSub = false;
         AV87TFWorkFlowPasso_F = AV28SearchTxt;
         AV88TFWorkFlowPasso_F_Sel = "";
         AV91Propostacontratowwds_1_filterfulltext = AV50FilterFullText;
         AV92Propostacontratowwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV93Propostacontratowwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV94Propostacontratowwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV95Propostacontratowwds_5_contratonome1 = AV74ContratoNome1;
         AV96Propostacontratowwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV97Propostacontratowwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV98Propostacontratowwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV99Propostacontratowwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV100Propostacontratowwds_10_contratonome2 = AV75ContratoNome2;
         AV101Propostacontratowwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV102Propostacontratowwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV103Propostacontratowwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV104Propostacontratowwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV105Propostacontratowwds_15_contratonome3 = AV76ContratoNome3;
         AV106Propostacontratowwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV108Propostacontratowwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV109Propostacontratowwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV110Propostacontratowwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV111Propostacontratowwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV112Propostacontratowwds_22_tfcontratonome = AV62TFContratoNome;
         AV113Propostacontratowwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         AV117Propostacontratowwds_27_tfworkflowpasso_f = AV87TFWorkFlowPasso_F;
         AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = AV88TFWorkFlowPasso_F_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              AV94Propostacontratowwds_4_propostatitulo1 ,
                                              AV95Propostacontratowwds_5_contratonome1 ,
                                              AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              AV99Propostacontratowwds_9_propostatitulo2 ,
                                              AV100Propostacontratowwds_10_contratonome2 ,
                                              AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              AV104Propostacontratowwds_14_propostatitulo3 ,
                                              AV105Propostacontratowwds_15_contratonome3 ,
                                              AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              AV110Propostacontratowwds_20_tfpropostavalor ,
                                              AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              AV112Propostacontratowwds_22_tfcontratonome ,
                                              AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV91Propostacontratowwds_1_filterfulltext ,
                                              A792WorkFlowPasso_F ,
                                              AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV91Propostacontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratowwds_1_filterfulltext), "%", "");
         lV117Propostacontratowwds_27_tfworkflowpasso_f = StringUtil.Concat( StringUtil.RTrim( AV117Propostacontratowwds_27_tfworkflowpasso_f), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV94Propostacontratowwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV95Propostacontratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV99Propostacontratowwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV100Propostacontratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV104Propostacontratowwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV105Propostacontratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3), "%", "");
         lV106Propostacontratowwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome), "%", "");
         lV108Propostacontratowwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao), "%", "");
         lV112Propostacontratowwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome), "%", "");
         lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00AP21 */
         pr_default.execute(4, new Object[] {AV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, lV91Propostacontratowwds_1_filterfulltext, AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels.Count, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV117Propostacontratowwds_27_tfworkflowpasso_f, lV117Propostacontratowwds_27_tfworkflowpasso_f, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, AV118Propostacontratowwds_28_tfworkflowpasso_f_sel, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV94Propostacontratowwds_4_propostatitulo1, lV94Propostacontratowwds_4_propostatitulo1, lV95Propostacontratowwds_5_contratonome1, lV95Propostacontratowwds_5_contratonome1, lV99Propostacontratowwds_9_propostatitulo2, lV99Propostacontratowwds_9_propostatitulo2, lV100Propostacontratowwds_10_contratonome2, lV100Propostacontratowwds_10_contratonome2, lV104Propostacontratowwds_14_propostatitulo3, lV104Propostacontratowwds_14_propostatitulo3, lV105Propostacontratowwds_15_contratonome3, lV105Propostacontratowwds_15_contratonome3, lV106Propostacontratowwds_16_tfprocedimentosmedicosnome, AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, lV108Propostacontratowwds_18_tfpropostadescricao, AV109Propostacontratowwds_19_tfpropostadescricao_sel, AV110Propostacontratowwds_20_tfpropostavalor, AV111Propostacontratowwds_21_tfpropostavalor_to, lV112Propostacontratowwds_22_tfcontratonome, AV113Propostacontratowwds_23_tfcontratonome_sel, lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial, AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A227ContratoId = P00AP21_A227ContratoId[0];
            n227ContratoId = P00AP21_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00AP21_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00AP21_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P00AP21_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AP21_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AP21_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AP21_n504PropostaPacienteClienteId[0];
            A329PropostaStatus = P00AP21_A329PropostaStatus[0];
            n329PropostaStatus = P00AP21_n329PropostaStatus[0];
            A210SecUserClienteId = P00AP21_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP21_n210SecUserClienteId[0];
            A642PropostaClinicaId = P00AP21_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AP21_n642PropostaClinicaId[0];
            A326PropostaValor = P00AP21_A326PropostaValor[0];
            n326PropostaValor = P00AP21_n326PropostaValor[0];
            A324PropostaTitulo = P00AP21_A324PropostaTitulo[0];
            n324PropostaTitulo = P00AP21_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP21_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP21_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00AP21_A228ContratoNome[0];
            n228ContratoNome = P00AP21_n228ContratoNome[0];
            A325PropostaDescricao = P00AP21_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AP21_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P00AP21_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP21_n377ProcedimentosMedicosNome[0];
            A792WorkFlowPasso_F = P00AP21_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP21_n792WorkFlowPasso_F[0];
            A323PropostaId = P00AP21_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00AP21_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP21_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00AP21_A228ContratoNome[0];
            n228ContratoNome = P00AP21_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00AP21_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00AP21_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P00AP21_A210SecUserClienteId[0];
            n210SecUserClienteId = P00AP21_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P00AP21_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AP21_n505PropostaPacienteClienteRazaoSocial[0];
            A792WorkFlowPasso_F = P00AP21_A792WorkFlowPasso_F[0];
            n792WorkFlowPasso_F = P00AP21_n792WorkFlowPasso_F[0];
            A548ReembolsoStatusAtual_F = P00AP21_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00AP21_n548ReembolsoStatusAtual_F[0];
            AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A792WorkFlowPasso_F)) ? "<#Empty#>" : A792WorkFlowPasso_F);
            AV32InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV33Option, "<#Empty#>") != 0 ) && ( AV32InsertIndex <= AV34Options.Count ) && ( ( StringUtil.StrCmp(((string)AV34Options.Item(AV32InsertIndex)), AV33Option) < 0 ) || ( StringUtil.StrCmp(((string)AV34Options.Item(AV32InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV32InsertIndex = (int)(AV32InsertIndex+1);
            }
            if ( ( AV32InsertIndex <= AV34Options.Count ) && ( StringUtil.StrCmp(((string)AV34Options.Item(AV32InsertIndex)), AV33Option) == 0 ) )
            {
               AV38count = (long)(Math.Round(NumberUtil.Val( ((string)AV37OptionIndexes.Item(AV32InsertIndex)), "."), 18, MidpointRounding.ToEven));
               AV38count = (long)(AV38count+1);
               AV37OptionIndexes.RemoveItem(AV32InsertIndex);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), AV32InsertIndex);
            }
            else
            {
               AV34Options.Add(AV33Option, AV32InsertIndex);
               AV37OptionIndexes.Add("1", AV32InsertIndex);
            }
            if ( AV34Options.Count == AV29SkipItems + 11 )
            {
               AV34Options.RemoveItem(AV34Options.Count);
               AV37OptionIndexes.RemoveItem(AV37OptionIndexes.Count);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         while ( AV29SkipItems > 0 )
         {
            AV34Options.RemoveItem(1);
            AV37OptionIndexes.RemoveItem(1);
            AV29SkipItems = (short)(AV29SkipItems-1);
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
         AV47OptionsJson = "";
         AV48OptionsDescJson = "";
         AV49OptionIndexesJson = "";
         AV34Options = new GxSimpleCollection<string>();
         AV36OptionsDesc = new GxSimpleCollection<string>();
         AV37OptionIndexes = new GxSimpleCollection<string>();
         AV28SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50FilterFullText = "";
         AV79TFProcedimentosMedicosNome = "";
         AV80TFProcedimentosMedicosNome_Sel = "";
         AV14TFPropostaDescricao = "";
         AV15TFPropostaDescricao_Sel = "";
         AV62TFContratoNome = "";
         AV63TFContratoNome_Sel = "";
         AV81TFPropostaPacienteClienteRazaoSocial = "";
         AV82TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV83TFReembolsoStatusAtual_F_SelsJson = "";
         AV84TFReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV87TFWorkFlowPasso_F = "";
         AV88TFWorkFlowPasso_F_Sel = "";
         AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV51DynamicFiltersSelector1 = "";
         AV53PropostaTitulo1 = "";
         AV74ContratoNome1 = "";
         AV55DynamicFiltersSelector2 = "";
         AV57PropostaTitulo2 = "";
         AV75ContratoNome2 = "";
         AV59DynamicFiltersSelector3 = "";
         AV61PropostaTitulo3 = "";
         AV76ContratoNome3 = "";
         AV91Propostacontratowwds_1_filterfulltext = "";
         AV92Propostacontratowwds_2_dynamicfiltersselector1 = "";
         AV94Propostacontratowwds_4_propostatitulo1 = "";
         AV95Propostacontratowwds_5_contratonome1 = "";
         AV97Propostacontratowwds_7_dynamicfiltersselector2 = "";
         AV99Propostacontratowwds_9_propostatitulo2 = "";
         AV100Propostacontratowwds_10_contratonome2 = "";
         AV102Propostacontratowwds_12_dynamicfiltersselector3 = "";
         AV104Propostacontratowwds_14_propostatitulo3 = "";
         AV105Propostacontratowwds_15_contratonome3 = "";
         AV106Propostacontratowwds_16_tfprocedimentosmedicosnome = "";
         AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel = "";
         AV108Propostacontratowwds_18_tfpropostadescricao = "";
         AV109Propostacontratowwds_19_tfpropostadescricao_sel = "";
         AV112Propostacontratowwds_22_tfcontratonome = "";
         AV113Propostacontratowwds_23_tfcontratonome_sel = "";
         AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = "";
         AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel = "";
         AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV117Propostacontratowwds_27_tfworkflowpasso_f = "";
         AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = "";
         lV91Propostacontratowwds_1_filterfulltext = "";
         lV117Propostacontratowwds_27_tfworkflowpasso_f = "";
         lV94Propostacontratowwds_4_propostatitulo1 = "";
         lV95Propostacontratowwds_5_contratonome1 = "";
         lV99Propostacontratowwds_9_propostatitulo2 = "";
         lV100Propostacontratowwds_10_contratonome2 = "";
         lV104Propostacontratowwds_14_propostatitulo3 = "";
         lV105Propostacontratowwds_15_contratonome3 = "";
         lV106Propostacontratowwds_16_tfprocedimentosmedicosnome = "";
         lV108Propostacontratowwds_18_tfpropostadescricao = "";
         lV112Propostacontratowwds_22_tfcontratonome = "";
         lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial = "";
         A548ReembolsoStatusAtual_F = "";
         A324PropostaTitulo = "";
         A228ContratoNome = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A792WorkFlowPasso_F = "";
         A329PropostaStatus = "";
         P00AP5_A227ContratoId = new int[1] ;
         P00AP5_n227ContratoId = new bool[] {false} ;
         P00AP5_A376ProcedimentosMedicosId = new int[1] ;
         P00AP5_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00AP5_A328PropostaCratedBy = new short[1] ;
         P00AP5_n328PropostaCratedBy = new bool[] {false} ;
         P00AP5_A504PropostaPacienteClienteId = new int[1] ;
         P00AP5_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AP5_A329PropostaStatus = new string[] {""} ;
         P00AP5_n329PropostaStatus = new bool[] {false} ;
         P00AP5_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00AP5_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00AP5_A210SecUserClienteId = new short[1] ;
         P00AP5_n210SecUserClienteId = new bool[] {false} ;
         P00AP5_A642PropostaClinicaId = new int[1] ;
         P00AP5_n642PropostaClinicaId = new bool[] {false} ;
         P00AP5_A326PropostaValor = new decimal[1] ;
         P00AP5_n326PropostaValor = new bool[] {false} ;
         P00AP5_A324PropostaTitulo = new string[] {""} ;
         P00AP5_n324PropostaTitulo = new bool[] {false} ;
         P00AP5_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AP5_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AP5_A228ContratoNome = new string[] {""} ;
         P00AP5_n228ContratoNome = new bool[] {false} ;
         P00AP5_A325PropostaDescricao = new string[] {""} ;
         P00AP5_n325PropostaDescricao = new bool[] {false} ;
         P00AP5_A792WorkFlowPasso_F = new string[] {""} ;
         P00AP5_n792WorkFlowPasso_F = new bool[] {false} ;
         P00AP5_A323PropostaId = new int[1] ;
         P00AP5_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00AP5_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         AV33Option = "";
         P00AP9_A227ContratoId = new int[1] ;
         P00AP9_n227ContratoId = new bool[] {false} ;
         P00AP9_A376ProcedimentosMedicosId = new int[1] ;
         P00AP9_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00AP9_A328PropostaCratedBy = new short[1] ;
         P00AP9_n328PropostaCratedBy = new bool[] {false} ;
         P00AP9_A504PropostaPacienteClienteId = new int[1] ;
         P00AP9_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AP9_A329PropostaStatus = new string[] {""} ;
         P00AP9_n329PropostaStatus = new bool[] {false} ;
         P00AP9_A325PropostaDescricao = new string[] {""} ;
         P00AP9_n325PropostaDescricao = new bool[] {false} ;
         P00AP9_A210SecUserClienteId = new short[1] ;
         P00AP9_n210SecUserClienteId = new bool[] {false} ;
         P00AP9_A642PropostaClinicaId = new int[1] ;
         P00AP9_n642PropostaClinicaId = new bool[] {false} ;
         P00AP9_A326PropostaValor = new decimal[1] ;
         P00AP9_n326PropostaValor = new bool[] {false} ;
         P00AP9_A324PropostaTitulo = new string[] {""} ;
         P00AP9_n324PropostaTitulo = new bool[] {false} ;
         P00AP9_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AP9_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AP9_A228ContratoNome = new string[] {""} ;
         P00AP9_n228ContratoNome = new bool[] {false} ;
         P00AP9_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00AP9_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00AP9_A792WorkFlowPasso_F = new string[] {""} ;
         P00AP9_n792WorkFlowPasso_F = new bool[] {false} ;
         P00AP9_A323PropostaId = new int[1] ;
         P00AP9_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00AP9_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         P00AP13_A376ProcedimentosMedicosId = new int[1] ;
         P00AP13_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00AP13_A328PropostaCratedBy = new short[1] ;
         P00AP13_n328PropostaCratedBy = new bool[] {false} ;
         P00AP13_A504PropostaPacienteClienteId = new int[1] ;
         P00AP13_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AP13_A227ContratoId = new int[1] ;
         P00AP13_n227ContratoId = new bool[] {false} ;
         P00AP13_A329PropostaStatus = new string[] {""} ;
         P00AP13_n329PropostaStatus = new bool[] {false} ;
         P00AP13_A210SecUserClienteId = new short[1] ;
         P00AP13_n210SecUserClienteId = new bool[] {false} ;
         P00AP13_A642PropostaClinicaId = new int[1] ;
         P00AP13_n642PropostaClinicaId = new bool[] {false} ;
         P00AP13_A326PropostaValor = new decimal[1] ;
         P00AP13_n326PropostaValor = new bool[] {false} ;
         P00AP13_A324PropostaTitulo = new string[] {""} ;
         P00AP13_n324PropostaTitulo = new bool[] {false} ;
         P00AP13_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AP13_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AP13_A228ContratoNome = new string[] {""} ;
         P00AP13_n228ContratoNome = new bool[] {false} ;
         P00AP13_A325PropostaDescricao = new string[] {""} ;
         P00AP13_n325PropostaDescricao = new bool[] {false} ;
         P00AP13_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00AP13_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00AP13_A792WorkFlowPasso_F = new string[] {""} ;
         P00AP13_n792WorkFlowPasso_F = new bool[] {false} ;
         P00AP13_A323PropostaId = new int[1] ;
         P00AP13_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00AP13_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         P00AP17_A227ContratoId = new int[1] ;
         P00AP17_n227ContratoId = new bool[] {false} ;
         P00AP17_A376ProcedimentosMedicosId = new int[1] ;
         P00AP17_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00AP17_A328PropostaCratedBy = new short[1] ;
         P00AP17_n328PropostaCratedBy = new bool[] {false} ;
         P00AP17_A504PropostaPacienteClienteId = new int[1] ;
         P00AP17_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AP17_A329PropostaStatus = new string[] {""} ;
         P00AP17_n329PropostaStatus = new bool[] {false} ;
         P00AP17_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AP17_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AP17_A210SecUserClienteId = new short[1] ;
         P00AP17_n210SecUserClienteId = new bool[] {false} ;
         P00AP17_A642PropostaClinicaId = new int[1] ;
         P00AP17_n642PropostaClinicaId = new bool[] {false} ;
         P00AP17_A326PropostaValor = new decimal[1] ;
         P00AP17_n326PropostaValor = new bool[] {false} ;
         P00AP17_A324PropostaTitulo = new string[] {""} ;
         P00AP17_n324PropostaTitulo = new bool[] {false} ;
         P00AP17_A228ContratoNome = new string[] {""} ;
         P00AP17_n228ContratoNome = new bool[] {false} ;
         P00AP17_A325PropostaDescricao = new string[] {""} ;
         P00AP17_n325PropostaDescricao = new bool[] {false} ;
         P00AP17_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00AP17_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00AP17_A792WorkFlowPasso_F = new string[] {""} ;
         P00AP17_n792WorkFlowPasso_F = new bool[] {false} ;
         P00AP17_A323PropostaId = new int[1] ;
         P00AP17_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00AP17_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         P00AP21_A227ContratoId = new int[1] ;
         P00AP21_n227ContratoId = new bool[] {false} ;
         P00AP21_A376ProcedimentosMedicosId = new int[1] ;
         P00AP21_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00AP21_A328PropostaCratedBy = new short[1] ;
         P00AP21_n328PropostaCratedBy = new bool[] {false} ;
         P00AP21_A504PropostaPacienteClienteId = new int[1] ;
         P00AP21_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AP21_A329PropostaStatus = new string[] {""} ;
         P00AP21_n329PropostaStatus = new bool[] {false} ;
         P00AP21_A210SecUserClienteId = new short[1] ;
         P00AP21_n210SecUserClienteId = new bool[] {false} ;
         P00AP21_A642PropostaClinicaId = new int[1] ;
         P00AP21_n642PropostaClinicaId = new bool[] {false} ;
         P00AP21_A326PropostaValor = new decimal[1] ;
         P00AP21_n326PropostaValor = new bool[] {false} ;
         P00AP21_A324PropostaTitulo = new string[] {""} ;
         P00AP21_n324PropostaTitulo = new bool[] {false} ;
         P00AP21_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AP21_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AP21_A228ContratoNome = new string[] {""} ;
         P00AP21_n228ContratoNome = new bool[] {false} ;
         P00AP21_A325PropostaDescricao = new string[] {""} ;
         P00AP21_n325PropostaDescricao = new bool[] {false} ;
         P00AP21_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00AP21_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00AP21_A792WorkFlowPasso_F = new string[] {""} ;
         P00AP21_n792WorkFlowPasso_F = new bool[] {false} ;
         P00AP21_A323PropostaId = new int[1] ;
         P00AP21_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00AP21_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AP5_A227ContratoId, P00AP5_n227ContratoId, P00AP5_A376ProcedimentosMedicosId, P00AP5_n376ProcedimentosMedicosId, P00AP5_A328PropostaCratedBy, P00AP5_n328PropostaCratedBy, P00AP5_A504PropostaPacienteClienteId, P00AP5_n504PropostaPacienteClienteId, P00AP5_A329PropostaStatus, P00AP5_n329PropostaStatus,
               P00AP5_A377ProcedimentosMedicosNome, P00AP5_n377ProcedimentosMedicosNome, P00AP5_A210SecUserClienteId, P00AP5_n210SecUserClienteId, P00AP5_A642PropostaClinicaId, P00AP5_n642PropostaClinicaId, P00AP5_A326PropostaValor, P00AP5_n326PropostaValor, P00AP5_A324PropostaTitulo, P00AP5_n324PropostaTitulo,
               P00AP5_A505PropostaPacienteClienteRazaoSocial, P00AP5_n505PropostaPacienteClienteRazaoSocial, P00AP5_A228ContratoNome, P00AP5_n228ContratoNome, P00AP5_A325PropostaDescricao, P00AP5_n325PropostaDescricao, P00AP5_A792WorkFlowPasso_F, P00AP5_n792WorkFlowPasso_F, P00AP5_A323PropostaId, P00AP5_A548ReembolsoStatusAtual_F,
               P00AP5_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00AP9_A227ContratoId, P00AP9_n227ContratoId, P00AP9_A376ProcedimentosMedicosId, P00AP9_n376ProcedimentosMedicosId, P00AP9_A328PropostaCratedBy, P00AP9_n328PropostaCratedBy, P00AP9_A504PropostaPacienteClienteId, P00AP9_n504PropostaPacienteClienteId, P00AP9_A329PropostaStatus, P00AP9_n329PropostaStatus,
               P00AP9_A325PropostaDescricao, P00AP9_n325PropostaDescricao, P00AP9_A210SecUserClienteId, P00AP9_n210SecUserClienteId, P00AP9_A642PropostaClinicaId, P00AP9_n642PropostaClinicaId, P00AP9_A326PropostaValor, P00AP9_n326PropostaValor, P00AP9_A324PropostaTitulo, P00AP9_n324PropostaTitulo,
               P00AP9_A505PropostaPacienteClienteRazaoSocial, P00AP9_n505PropostaPacienteClienteRazaoSocial, P00AP9_A228ContratoNome, P00AP9_n228ContratoNome, P00AP9_A377ProcedimentosMedicosNome, P00AP9_n377ProcedimentosMedicosNome, P00AP9_A792WorkFlowPasso_F, P00AP9_n792WorkFlowPasso_F, P00AP9_A323PropostaId, P00AP9_A548ReembolsoStatusAtual_F,
               P00AP9_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00AP13_A376ProcedimentosMedicosId, P00AP13_n376ProcedimentosMedicosId, P00AP13_A328PropostaCratedBy, P00AP13_n328PropostaCratedBy, P00AP13_A504PropostaPacienteClienteId, P00AP13_n504PropostaPacienteClienteId, P00AP13_A227ContratoId, P00AP13_n227ContratoId, P00AP13_A329PropostaStatus, P00AP13_n329PropostaStatus,
               P00AP13_A210SecUserClienteId, P00AP13_n210SecUserClienteId, P00AP13_A642PropostaClinicaId, P00AP13_n642PropostaClinicaId, P00AP13_A326PropostaValor, P00AP13_n326PropostaValor, P00AP13_A324PropostaTitulo, P00AP13_n324PropostaTitulo, P00AP13_A505PropostaPacienteClienteRazaoSocial, P00AP13_n505PropostaPacienteClienteRazaoSocial,
               P00AP13_A228ContratoNome, P00AP13_n228ContratoNome, P00AP13_A325PropostaDescricao, P00AP13_n325PropostaDescricao, P00AP13_A377ProcedimentosMedicosNome, P00AP13_n377ProcedimentosMedicosNome, P00AP13_A792WorkFlowPasso_F, P00AP13_n792WorkFlowPasso_F, P00AP13_A323PropostaId, P00AP13_A548ReembolsoStatusAtual_F,
               P00AP13_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00AP17_A227ContratoId, P00AP17_n227ContratoId, P00AP17_A376ProcedimentosMedicosId, P00AP17_n376ProcedimentosMedicosId, P00AP17_A328PropostaCratedBy, P00AP17_n328PropostaCratedBy, P00AP17_A504PropostaPacienteClienteId, P00AP17_n504PropostaPacienteClienteId, P00AP17_A329PropostaStatus, P00AP17_n329PropostaStatus,
               P00AP17_A505PropostaPacienteClienteRazaoSocial, P00AP17_n505PropostaPacienteClienteRazaoSocial, P00AP17_A210SecUserClienteId, P00AP17_n210SecUserClienteId, P00AP17_A642PropostaClinicaId, P00AP17_n642PropostaClinicaId, P00AP17_A326PropostaValor, P00AP17_n326PropostaValor, P00AP17_A324PropostaTitulo, P00AP17_n324PropostaTitulo,
               P00AP17_A228ContratoNome, P00AP17_n228ContratoNome, P00AP17_A325PropostaDescricao, P00AP17_n325PropostaDescricao, P00AP17_A377ProcedimentosMedicosNome, P00AP17_n377ProcedimentosMedicosNome, P00AP17_A792WorkFlowPasso_F, P00AP17_n792WorkFlowPasso_F, P00AP17_A323PropostaId, P00AP17_A548ReembolsoStatusAtual_F,
               P00AP17_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00AP21_A227ContratoId, P00AP21_n227ContratoId, P00AP21_A376ProcedimentosMedicosId, P00AP21_n376ProcedimentosMedicosId, P00AP21_A328PropostaCratedBy, P00AP21_n328PropostaCratedBy, P00AP21_A504PropostaPacienteClienteId, P00AP21_n504PropostaPacienteClienteId, P00AP21_A329PropostaStatus, P00AP21_n329PropostaStatus,
               P00AP21_A210SecUserClienteId, P00AP21_n210SecUserClienteId, P00AP21_A642PropostaClinicaId, P00AP21_n642PropostaClinicaId, P00AP21_A326PropostaValor, P00AP21_n326PropostaValor, P00AP21_A324PropostaTitulo, P00AP21_n324PropostaTitulo, P00AP21_A505PropostaPacienteClienteRazaoSocial, P00AP21_n505PropostaPacienteClienteRazaoSocial,
               P00AP21_A228ContratoNome, P00AP21_n228ContratoNome, P00AP21_A325PropostaDescricao, P00AP21_n325PropostaDescricao, P00AP21_A377ProcedimentosMedicosNome, P00AP21_n377ProcedimentosMedicosNome, P00AP21_A792WorkFlowPasso_F, P00AP21_n792WorkFlowPasso_F, P00AP21_A323PropostaId, P00AP21_A548ReembolsoStatusAtual_F,
               P00AP21_n548ReembolsoStatusAtual_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private short AV52DynamicFiltersOperator1 ;
      private short AV56DynamicFiltersOperator2 ;
      private short AV60DynamicFiltersOperator3 ;
      private short AV93Propostacontratowwds_3_dynamicfiltersoperator1 ;
      private short AV98Propostacontratowwds_8_dynamicfiltersoperator2 ;
      private short AV103Propostacontratowwds_13_dynamicfiltersoperator3 ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A133SecUserId ;
      private short A210SecUserClienteId ;
      private short A328PropostaCratedBy ;
      private int AV89GXV1 ;
      private int AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int A642PropostaClinicaId ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int AV32InsertIndex ;
      private long AV38count ;
      private decimal AV16TFPropostaValor ;
      private decimal AV17TFPropostaValor_To ;
      private decimal AV110Propostacontratowwds_20_tfpropostavalor ;
      private decimal AV111Propostacontratowwds_21_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private bool returnInSub ;
      private bool AV54DynamicFiltersEnabled2 ;
      private bool AV58DynamicFiltersEnabled3 ;
      private bool AV96Propostacontratowwds_6_dynamicfiltersenabled2 ;
      private bool AV101Propostacontratowwds_11_dynamicfiltersenabled3 ;
      private bool BRKAP2 ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n329PropostaStatus ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n210SecUserClienteId ;
      private bool n642PropostaClinicaId ;
      private bool n326PropostaValor ;
      private bool n324PropostaTitulo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n228ContratoNome ;
      private bool n325PropostaDescricao ;
      private bool n792WorkFlowPasso_F ;
      private bool n548ReembolsoStatusAtual_F ;
      private bool BRKAP4 ;
      private bool BRKAP6 ;
      private bool BRKAP8 ;
      private string AV47OptionsJson ;
      private string AV48OptionsDescJson ;
      private string AV49OptionIndexesJson ;
      private string AV83TFReembolsoStatusAtual_F_SelsJson ;
      private string AV44DDOName ;
      private string AV45SearchTxtParms ;
      private string AV46SearchTxtTo ;
      private string AV28SearchTxt ;
      private string AV50FilterFullText ;
      private string AV79TFProcedimentosMedicosNome ;
      private string AV80TFProcedimentosMedicosNome_Sel ;
      private string AV14TFPropostaDescricao ;
      private string AV15TFPropostaDescricao_Sel ;
      private string AV62TFContratoNome ;
      private string AV63TFContratoNome_Sel ;
      private string AV81TFPropostaPacienteClienteRazaoSocial ;
      private string AV82TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV87TFWorkFlowPasso_F ;
      private string AV88TFWorkFlowPasso_F_Sel ;
      private string AV51DynamicFiltersSelector1 ;
      private string AV53PropostaTitulo1 ;
      private string AV74ContratoNome1 ;
      private string AV55DynamicFiltersSelector2 ;
      private string AV57PropostaTitulo2 ;
      private string AV75ContratoNome2 ;
      private string AV59DynamicFiltersSelector3 ;
      private string AV61PropostaTitulo3 ;
      private string AV76ContratoNome3 ;
      private string AV91Propostacontratowwds_1_filterfulltext ;
      private string AV92Propostacontratowwds_2_dynamicfiltersselector1 ;
      private string AV94Propostacontratowwds_4_propostatitulo1 ;
      private string AV95Propostacontratowwds_5_contratonome1 ;
      private string AV97Propostacontratowwds_7_dynamicfiltersselector2 ;
      private string AV99Propostacontratowwds_9_propostatitulo2 ;
      private string AV100Propostacontratowwds_10_contratonome2 ;
      private string AV102Propostacontratowwds_12_dynamicfiltersselector3 ;
      private string AV104Propostacontratowwds_14_propostatitulo3 ;
      private string AV105Propostacontratowwds_15_contratonome3 ;
      private string AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ;
      private string AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ;
      private string AV108Propostacontratowwds_18_tfpropostadescricao ;
      private string AV109Propostacontratowwds_19_tfpropostadescricao_sel ;
      private string AV112Propostacontratowwds_22_tfcontratonome ;
      private string AV113Propostacontratowwds_23_tfcontratonome_sel ;
      private string AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ;
      private string AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ;
      private string AV117Propostacontratowwds_27_tfworkflowpasso_f ;
      private string AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ;
      private string lV91Propostacontratowwds_1_filterfulltext ;
      private string lV117Propostacontratowwds_27_tfworkflowpasso_f ;
      private string lV94Propostacontratowwds_4_propostatitulo1 ;
      private string lV95Propostacontratowwds_5_contratonome1 ;
      private string lV99Propostacontratowwds_9_propostatitulo2 ;
      private string lV100Propostacontratowwds_10_contratonome2 ;
      private string lV104Propostacontratowwds_14_propostatitulo3 ;
      private string lV105Propostacontratowwds_15_contratonome3 ;
      private string lV106Propostacontratowwds_16_tfprocedimentosmedicosnome ;
      private string lV108Propostacontratowwds_18_tfpropostadescricao ;
      private string lV112Propostacontratowwds_22_tfcontratonome ;
      private string lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ;
      private string A548ReembolsoStatusAtual_F ;
      private string A324PropostaTitulo ;
      private string A228ContratoNome ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A792WorkFlowPasso_F ;
      private string A329PropostaStatus ;
      private string AV33Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV34Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV37OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GxSimpleCollection<string> AV84TFReembolsoStatusAtual_F_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV43GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00AP5_A227ContratoId ;
      private bool[] P00AP5_n227ContratoId ;
      private int[] P00AP5_A376ProcedimentosMedicosId ;
      private bool[] P00AP5_n376ProcedimentosMedicosId ;
      private short[] P00AP5_A328PropostaCratedBy ;
      private bool[] P00AP5_n328PropostaCratedBy ;
      private int[] P00AP5_A504PropostaPacienteClienteId ;
      private bool[] P00AP5_n504PropostaPacienteClienteId ;
      private string[] P00AP5_A329PropostaStatus ;
      private bool[] P00AP5_n329PropostaStatus ;
      private string[] P00AP5_A377ProcedimentosMedicosNome ;
      private bool[] P00AP5_n377ProcedimentosMedicosNome ;
      private short[] P00AP5_A210SecUserClienteId ;
      private bool[] P00AP5_n210SecUserClienteId ;
      private int[] P00AP5_A642PropostaClinicaId ;
      private bool[] P00AP5_n642PropostaClinicaId ;
      private decimal[] P00AP5_A326PropostaValor ;
      private bool[] P00AP5_n326PropostaValor ;
      private string[] P00AP5_A324PropostaTitulo ;
      private bool[] P00AP5_n324PropostaTitulo ;
      private string[] P00AP5_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AP5_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00AP5_A228ContratoNome ;
      private bool[] P00AP5_n228ContratoNome ;
      private string[] P00AP5_A325PropostaDescricao ;
      private bool[] P00AP5_n325PropostaDescricao ;
      private string[] P00AP5_A792WorkFlowPasso_F ;
      private bool[] P00AP5_n792WorkFlowPasso_F ;
      private int[] P00AP5_A323PropostaId ;
      private string[] P00AP5_A548ReembolsoStatusAtual_F ;
      private bool[] P00AP5_n548ReembolsoStatusAtual_F ;
      private int[] P00AP9_A227ContratoId ;
      private bool[] P00AP9_n227ContratoId ;
      private int[] P00AP9_A376ProcedimentosMedicosId ;
      private bool[] P00AP9_n376ProcedimentosMedicosId ;
      private short[] P00AP9_A328PropostaCratedBy ;
      private bool[] P00AP9_n328PropostaCratedBy ;
      private int[] P00AP9_A504PropostaPacienteClienteId ;
      private bool[] P00AP9_n504PropostaPacienteClienteId ;
      private string[] P00AP9_A329PropostaStatus ;
      private bool[] P00AP9_n329PropostaStatus ;
      private string[] P00AP9_A325PropostaDescricao ;
      private bool[] P00AP9_n325PropostaDescricao ;
      private short[] P00AP9_A210SecUserClienteId ;
      private bool[] P00AP9_n210SecUserClienteId ;
      private int[] P00AP9_A642PropostaClinicaId ;
      private bool[] P00AP9_n642PropostaClinicaId ;
      private decimal[] P00AP9_A326PropostaValor ;
      private bool[] P00AP9_n326PropostaValor ;
      private string[] P00AP9_A324PropostaTitulo ;
      private bool[] P00AP9_n324PropostaTitulo ;
      private string[] P00AP9_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AP9_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00AP9_A228ContratoNome ;
      private bool[] P00AP9_n228ContratoNome ;
      private string[] P00AP9_A377ProcedimentosMedicosNome ;
      private bool[] P00AP9_n377ProcedimentosMedicosNome ;
      private string[] P00AP9_A792WorkFlowPasso_F ;
      private bool[] P00AP9_n792WorkFlowPasso_F ;
      private int[] P00AP9_A323PropostaId ;
      private string[] P00AP9_A548ReembolsoStatusAtual_F ;
      private bool[] P00AP9_n548ReembolsoStatusAtual_F ;
      private int[] P00AP13_A376ProcedimentosMedicosId ;
      private bool[] P00AP13_n376ProcedimentosMedicosId ;
      private short[] P00AP13_A328PropostaCratedBy ;
      private bool[] P00AP13_n328PropostaCratedBy ;
      private int[] P00AP13_A504PropostaPacienteClienteId ;
      private bool[] P00AP13_n504PropostaPacienteClienteId ;
      private int[] P00AP13_A227ContratoId ;
      private bool[] P00AP13_n227ContratoId ;
      private string[] P00AP13_A329PropostaStatus ;
      private bool[] P00AP13_n329PropostaStatus ;
      private short[] P00AP13_A210SecUserClienteId ;
      private bool[] P00AP13_n210SecUserClienteId ;
      private int[] P00AP13_A642PropostaClinicaId ;
      private bool[] P00AP13_n642PropostaClinicaId ;
      private decimal[] P00AP13_A326PropostaValor ;
      private bool[] P00AP13_n326PropostaValor ;
      private string[] P00AP13_A324PropostaTitulo ;
      private bool[] P00AP13_n324PropostaTitulo ;
      private string[] P00AP13_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AP13_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00AP13_A228ContratoNome ;
      private bool[] P00AP13_n228ContratoNome ;
      private string[] P00AP13_A325PropostaDescricao ;
      private bool[] P00AP13_n325PropostaDescricao ;
      private string[] P00AP13_A377ProcedimentosMedicosNome ;
      private bool[] P00AP13_n377ProcedimentosMedicosNome ;
      private string[] P00AP13_A792WorkFlowPasso_F ;
      private bool[] P00AP13_n792WorkFlowPasso_F ;
      private int[] P00AP13_A323PropostaId ;
      private string[] P00AP13_A548ReembolsoStatusAtual_F ;
      private bool[] P00AP13_n548ReembolsoStatusAtual_F ;
      private int[] P00AP17_A227ContratoId ;
      private bool[] P00AP17_n227ContratoId ;
      private int[] P00AP17_A376ProcedimentosMedicosId ;
      private bool[] P00AP17_n376ProcedimentosMedicosId ;
      private short[] P00AP17_A328PropostaCratedBy ;
      private bool[] P00AP17_n328PropostaCratedBy ;
      private int[] P00AP17_A504PropostaPacienteClienteId ;
      private bool[] P00AP17_n504PropostaPacienteClienteId ;
      private string[] P00AP17_A329PropostaStatus ;
      private bool[] P00AP17_n329PropostaStatus ;
      private string[] P00AP17_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AP17_n505PropostaPacienteClienteRazaoSocial ;
      private short[] P00AP17_A210SecUserClienteId ;
      private bool[] P00AP17_n210SecUserClienteId ;
      private int[] P00AP17_A642PropostaClinicaId ;
      private bool[] P00AP17_n642PropostaClinicaId ;
      private decimal[] P00AP17_A326PropostaValor ;
      private bool[] P00AP17_n326PropostaValor ;
      private string[] P00AP17_A324PropostaTitulo ;
      private bool[] P00AP17_n324PropostaTitulo ;
      private string[] P00AP17_A228ContratoNome ;
      private bool[] P00AP17_n228ContratoNome ;
      private string[] P00AP17_A325PropostaDescricao ;
      private bool[] P00AP17_n325PropostaDescricao ;
      private string[] P00AP17_A377ProcedimentosMedicosNome ;
      private bool[] P00AP17_n377ProcedimentosMedicosNome ;
      private string[] P00AP17_A792WorkFlowPasso_F ;
      private bool[] P00AP17_n792WorkFlowPasso_F ;
      private int[] P00AP17_A323PropostaId ;
      private string[] P00AP17_A548ReembolsoStatusAtual_F ;
      private bool[] P00AP17_n548ReembolsoStatusAtual_F ;
      private int[] P00AP21_A227ContratoId ;
      private bool[] P00AP21_n227ContratoId ;
      private int[] P00AP21_A376ProcedimentosMedicosId ;
      private bool[] P00AP21_n376ProcedimentosMedicosId ;
      private short[] P00AP21_A328PropostaCratedBy ;
      private bool[] P00AP21_n328PropostaCratedBy ;
      private int[] P00AP21_A504PropostaPacienteClienteId ;
      private bool[] P00AP21_n504PropostaPacienteClienteId ;
      private string[] P00AP21_A329PropostaStatus ;
      private bool[] P00AP21_n329PropostaStatus ;
      private short[] P00AP21_A210SecUserClienteId ;
      private bool[] P00AP21_n210SecUserClienteId ;
      private int[] P00AP21_A642PropostaClinicaId ;
      private bool[] P00AP21_n642PropostaClinicaId ;
      private decimal[] P00AP21_A326PropostaValor ;
      private bool[] P00AP21_n326PropostaValor ;
      private string[] P00AP21_A324PropostaTitulo ;
      private bool[] P00AP21_n324PropostaTitulo ;
      private string[] P00AP21_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AP21_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00AP21_A228ContratoNome ;
      private bool[] P00AP21_n228ContratoNome ;
      private string[] P00AP21_A325PropostaDescricao ;
      private bool[] P00AP21_n325PropostaDescricao ;
      private string[] P00AP21_A377ProcedimentosMedicosNome ;
      private bool[] P00AP21_n377ProcedimentosMedicosNome ;
      private string[] P00AP21_A792WorkFlowPasso_F ;
      private bool[] P00AP21_n792WorkFlowPasso_F ;
      private int[] P00AP21_A323PropostaId ;
      private string[] P00AP21_A548ReembolsoStatusAtual_F ;
      private bool[] P00AP21_n548ReembolsoStatusAtual_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class propostacontratowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AP5( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                             short AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV94Propostacontratowwds_4_propostatitulo1 ,
                                             string AV95Propostacontratowwds_5_contratonome1 ,
                                             bool AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                             string AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                             short AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                             string AV99Propostacontratowwds_9_propostatitulo2 ,
                                             string AV100Propostacontratowwds_10_contratonome2 ,
                                             bool AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                             string AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                             short AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                             string AV104Propostacontratowwds_14_propostatitulo3 ,
                                             string AV105Propostacontratowwds_15_contratonome3 ,
                                             string AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                             string AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                             string AV108Propostacontratowwds_18_tfpropostadescricao ,
                                             decimal AV110Propostacontratowwds_20_tfpropostavalor ,
                                             decimal AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                             string AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                             string AV112Propostacontratowwds_22_tfcontratonome ,
                                             string AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string AV91Propostacontratowwds_1_filterfulltext ,
                                             string A792WorkFlowPasso_F ,
                                             int AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels_Count ,
                                             string AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                             string AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                             int A642PropostaClinicaId ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             short A133SecUserId ,
                                             short A210SecUserClienteId ,
                                             string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[43];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaStatus, T3.ProcedimentosMedicosNome, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaValor, T1.PropostaTitulo, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaDescricao, COALESCE( T6.WorkFlowPasso_F, '') AS WorkFlowPasso_F, T1.PropostaId, COALESCE( T7.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T9.WorkflowConvenioDesc) AS WorkFlowPasso_F, T8.ReembolsoPropostaId FROM (Reembolso T8 LEFT JOIN WorkflowConvenio T9 ON T9.WorkflowConvenioId = T8.WorkflowConvenioId),  Proposta T10 WHERE (T1.PropostaId = T8.ReembolsoPropostaId) AND (T8.ReembolsoPropostaId = T10.PropostaId) GROUP BY T8.ReembolsoPropostaId ) T6 ON T6.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T8.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId FROM ((ReembolsoEtapa T8 LEFT JOIN Reembolso T9 ON T9.ReembolsoId = T8.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T8.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T8.ReembolsoId) WHERE (T1.PropostaId = T9.ReembolsoPropostaId) AND (T8.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F,";
         scmdbuf += " DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV91Propostacontratowwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( '')) or ( COALESCE( T6.WorkFlowPasso_F, '') like '%' || :lV91Propostacontratowwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV116ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T7.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV117Propostacontratowwds_27_tfworkflowpasso_f))=0))) or ( COALESCE( T6.WorkFlowPasso_F, '') like :lV117Propostacontratowwds_27_tfworkflowpasso_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and Not :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.WorkFlowPasso_F, '') = ( :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel)))");
         AddWhere(sWhereString, "(:AV118Propostacontratowwds_28_tfworkflowpasso_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.WorkFlowPasso_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_2Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV106Propostacontratowwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV108Propostacontratowwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV109Propostacontratowwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Propostacontratowwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Propostacontratowwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Propostacontratowwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Propostacontratowwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV112Propostacontratowwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV113Propostacontratowwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci))");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AP9( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                             short AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV94Propostacontratowwds_4_propostatitulo1 ,
                                             string AV95Propostacontratowwds_5_contratonome1 ,
                                             bool AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                             string AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                             short AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                             string AV99Propostacontratowwds_9_propostatitulo2 ,
                                             string AV100Propostacontratowwds_10_contratonome2 ,
                                             bool AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                             string AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                             short AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                             string AV104Propostacontratowwds_14_propostatitulo3 ,
                                             string AV105Propostacontratowwds_15_contratonome3 ,
                                             string AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                             string AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                             string AV108Propostacontratowwds_18_tfpropostadescricao ,
                                             decimal AV110Propostacontratowwds_20_tfpropostavalor ,
                                             decimal AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                             string AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                             string AV112Propostacontratowwds_22_tfcontratonome ,
                                             string AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string AV91Propostacontratowwds_1_filterfulltext ,
                                             string A792WorkFlowPasso_F ,
                                             int AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels_Count ,
                                             string AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                             string AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                             int A642PropostaClinicaId ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             short A133SecUserId ,
                                             short A210SecUserClienteId ,
                                             string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[43];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaStatus, T1.PropostaDescricao, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaValor, T1.PropostaTitulo, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T3.ProcedimentosMedicosNome, COALESCE( T6.WorkFlowPasso_F, '') AS WorkFlowPasso_F, T1.PropostaId, COALESCE( T7.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T9.WorkflowConvenioDesc) AS WorkFlowPasso_F, T8.ReembolsoPropostaId FROM (Reembolso T8 LEFT JOIN WorkflowConvenio T9 ON T9.WorkflowConvenioId = T8.WorkflowConvenioId),  Proposta T10 WHERE (T1.PropostaId = T8.ReembolsoPropostaId) AND (T8.ReembolsoPropostaId = T10.PropostaId) GROUP BY T8.ReembolsoPropostaId ) T6 ON T6.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T8.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId FROM ((ReembolsoEtapa T8 LEFT JOIN Reembolso T9 ON T9.ReembolsoId = T8.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T8.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T8.ReembolsoId) WHERE (T1.PropostaId = T9.ReembolsoPropostaId) AND (T8.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F,";
         scmdbuf += " DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV91Propostacontratowwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( '')) or ( COALESCE( T6.WorkFlowPasso_F, '') like '%' || :lV91Propostacontratowwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV116ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T7.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV117Propostacontratowwds_27_tfworkflowpasso_f))=0))) or ( COALESCE( T6.WorkFlowPasso_F, '') like :lV117Propostacontratowwds_27_tfworkflowpasso_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and Not :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.WorkFlowPasso_F, '') = ( :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel)))");
         AddWhere(sWhereString, "(:AV118Propostacontratowwds_28_tfworkflowpasso_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.WorkFlowPasso_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_2Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV106Propostacontratowwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV108Propostacontratowwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV109Propostacontratowwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Propostacontratowwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Propostacontratowwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Propostacontratowwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Propostacontratowwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV112Propostacontratowwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV113Propostacontratowwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AP13( IGxContext context ,
                                              string A548ReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              string AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              short AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              string AV94Propostacontratowwds_4_propostatitulo1 ,
                                              string AV95Propostacontratowwds_5_contratonome1 ,
                                              bool AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              string AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              short AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              string AV99Propostacontratowwds_9_propostatitulo2 ,
                                              string AV100Propostacontratowwds_10_contratonome2 ,
                                              bool AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              string AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              short AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              string AV104Propostacontratowwds_14_propostatitulo3 ,
                                              string AV105Propostacontratowwds_15_contratonome3 ,
                                              string AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              string AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              string AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              decimal AV110Propostacontratowwds_20_tfpropostavalor ,
                                              decimal AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              string AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              string AV112Propostacontratowwds_22_tfcontratonome ,
                                              string AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV91Propostacontratowwds_1_filterfulltext ,
                                              string A792WorkFlowPasso_F ,
                                              int AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels_Count ,
                                              string AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              string AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              int A642PropostaClinicaId ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              short A133SecUserId ,
                                              short A210SecUserClienteId ,
                                              string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[43];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.ContratoId, T1.PropostaStatus, T3.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaValor, T1.PropostaTitulo, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T5.ContratoNome, T1.PropostaDescricao, T2.ProcedimentosMedicosNome, COALESCE( T6.WorkFlowPasso_F, '') AS WorkFlowPasso_F, T1.PropostaId, COALESCE( T7.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Contrato T5 ON T5.ContratoId = T1.ContratoId) LEFT JOIN LATERAL (SELECT MIN(T9.WorkflowConvenioDesc) AS WorkFlowPasso_F, T8.ReembolsoPropostaId FROM (Reembolso T8 LEFT JOIN WorkflowConvenio T9 ON T9.WorkflowConvenioId = T8.WorkflowConvenioId),  Proposta T10 WHERE (T1.PropostaId = T8.ReembolsoPropostaId) AND (T8.ReembolsoPropostaId = T10.PropostaId) GROUP BY T8.ReembolsoPropostaId ) T6 ON T6.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T8.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId FROM ((ReembolsoEtapa T8 LEFT JOIN Reembolso T9 ON T9.ReembolsoId = T8.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T8.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T8.ReembolsoId) WHERE (T1.PropostaId = T9.ReembolsoPropostaId) AND (T8.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F,";
         scmdbuf += " DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV91Propostacontratowwds_1_filterfulltext))=0) or ( ( T2.ProcedimentosMedicosNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T5.ContratoNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( '')) or ( COALESCE( T6.WorkFlowPasso_F, '') like '%' || :lV91Propostacontratowwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV116ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T7.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV117Propostacontratowwds_27_tfworkflowpasso_f))=0))) or ( COALESCE( T6.WorkFlowPasso_F, '') like :lV117Propostacontratowwds_27_tfworkflowpasso_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and Not :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.WorkFlowPasso_F, '') = ( :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel)))");
         AddWhere(sWhereString, "(:AV118Propostacontratowwds_28_tfworkflowpasso_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.WorkFlowPasso_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_2Secuserclienteid = 0) THEN :SecUserId ELSE T3.SecUserClienteId END)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like '%' || :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T2.ProcedimentosMedicosNome like :lV106Propostacontratowwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProcedimentosMedicosNome = ( :AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV108Propostacontratowwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV109Propostacontratowwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Propostacontratowwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Propostacontratowwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Propostacontratowwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Propostacontratowwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome like :lV112Propostacontratowwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ContratoNome = ( :AV113Propostacontratowwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T5.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci))");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00AP17( IGxContext context ,
                                              string A548ReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              string AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              short AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              string AV94Propostacontratowwds_4_propostatitulo1 ,
                                              string AV95Propostacontratowwds_5_contratonome1 ,
                                              bool AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              string AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              short AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              string AV99Propostacontratowwds_9_propostatitulo2 ,
                                              string AV100Propostacontratowwds_10_contratonome2 ,
                                              bool AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              string AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              short AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              string AV104Propostacontratowwds_14_propostatitulo3 ,
                                              string AV105Propostacontratowwds_15_contratonome3 ,
                                              string AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              string AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              string AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              decimal AV110Propostacontratowwds_20_tfpropostavalor ,
                                              decimal AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              string AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              string AV112Propostacontratowwds_22_tfcontratonome ,
                                              string AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV91Propostacontratowwds_1_filterfulltext ,
                                              string A792WorkFlowPasso_F ,
                                              int AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels_Count ,
                                              string AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              string AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              int A642PropostaClinicaId ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              short A133SecUserId ,
                                              short A210SecUserClienteId ,
                                              string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[43];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaStatus, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaValor, T1.PropostaTitulo, T2.ContratoNome, T1.PropostaDescricao, T3.ProcedimentosMedicosNome, COALESCE( T6.WorkFlowPasso_F, '') AS WorkFlowPasso_F, T1.PropostaId, COALESCE( T7.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T9.WorkflowConvenioDesc) AS WorkFlowPasso_F, T8.ReembolsoPropostaId FROM (Reembolso T8 LEFT JOIN WorkflowConvenio T9 ON T9.WorkflowConvenioId = T8.WorkflowConvenioId),  Proposta T10 WHERE (T1.PropostaId = T8.ReembolsoPropostaId) AND (T8.ReembolsoPropostaId = T10.PropostaId) GROUP BY T8.ReembolsoPropostaId ) T6 ON T6.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T8.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId FROM ((ReembolsoEtapa T8 LEFT JOIN Reembolso T9 ON T9.ReembolsoId = T8.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T8.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T8.ReembolsoId) WHERE (T1.PropostaId = T9.ReembolsoPropostaId) AND (T8.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F,";
         scmdbuf += " DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV91Propostacontratowwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( '')) or ( COALESCE( T6.WorkFlowPasso_F, '') like '%' || :lV91Propostacontratowwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV116ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T7.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV117Propostacontratowwds_27_tfworkflowpasso_f))=0))) or ( COALESCE( T6.WorkFlowPasso_F, '') like :lV117Propostacontratowwds_27_tfworkflowpasso_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and Not :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.WorkFlowPasso_F, '') = ( :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel)))");
         AddWhere(sWhereString, "(:AV118Propostacontratowwds_28_tfworkflowpasso_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.WorkFlowPasso_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_2Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV106Propostacontratowwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV108Propostacontratowwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV109Propostacontratowwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Propostacontratowwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Propostacontratowwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Propostacontratowwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Propostacontratowwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV112Propostacontratowwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV113Propostacontratowwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci))");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00AP21( IGxContext context ,
                                              string A548ReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels ,
                                              string AV92Propostacontratowwds_2_dynamicfiltersselector1 ,
                                              short AV93Propostacontratowwds_3_dynamicfiltersoperator1 ,
                                              string AV94Propostacontratowwds_4_propostatitulo1 ,
                                              string AV95Propostacontratowwds_5_contratonome1 ,
                                              bool AV96Propostacontratowwds_6_dynamicfiltersenabled2 ,
                                              string AV97Propostacontratowwds_7_dynamicfiltersselector2 ,
                                              short AV98Propostacontratowwds_8_dynamicfiltersoperator2 ,
                                              string AV99Propostacontratowwds_9_propostatitulo2 ,
                                              string AV100Propostacontratowwds_10_contratonome2 ,
                                              bool AV101Propostacontratowwds_11_dynamicfiltersenabled3 ,
                                              string AV102Propostacontratowwds_12_dynamicfiltersselector3 ,
                                              short AV103Propostacontratowwds_13_dynamicfiltersoperator3 ,
                                              string AV104Propostacontratowwds_14_propostatitulo3 ,
                                              string AV105Propostacontratowwds_15_contratonome3 ,
                                              string AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV106Propostacontratowwds_16_tfprocedimentosmedicosnome ,
                                              string AV109Propostacontratowwds_19_tfpropostadescricao_sel ,
                                              string AV108Propostacontratowwds_18_tfpropostadescricao ,
                                              decimal AV110Propostacontratowwds_20_tfpropostavalor ,
                                              decimal AV111Propostacontratowwds_21_tfpropostavalor_to ,
                                              string AV113Propostacontratowwds_23_tfcontratonome_sel ,
                                              string AV112Propostacontratowwds_22_tfcontratonome ,
                                              string AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV91Propostacontratowwds_1_filterfulltext ,
                                              string A792WorkFlowPasso_F ,
                                              int AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels_Count ,
                                              string AV118Propostacontratowwds_28_tfworkflowpasso_f_sel ,
                                              string AV117Propostacontratowwds_27_tfworkflowpasso_f ,
                                              int A642PropostaClinicaId ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              short A133SecUserId ,
                                              short A210SecUserClienteId ,
                                              string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[43];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaStatus, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaValor, T1.PropostaTitulo, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaDescricao, T3.ProcedimentosMedicosNome, COALESCE( T6.WorkFlowPasso_F, '') AS WorkFlowPasso_F, T1.PropostaId, COALESCE( T7.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T9.WorkflowConvenioDesc) AS WorkFlowPasso_F, T8.ReembolsoPropostaId FROM (Reembolso T8 LEFT JOIN WorkflowConvenio T9 ON T9.WorkflowConvenioId = T8.WorkflowConvenioId),  Proposta T10 WHERE (T1.PropostaId = T8.ReembolsoPropostaId) AND (T8.ReembolsoPropostaId = T10.PropostaId) GROUP BY T8.ReembolsoPropostaId ) T6 ON T6.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T8.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId FROM ((ReembolsoEtapa T8 LEFT JOIN Reembolso T9 ON T9.ReembolsoId = T8.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T8.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T8.ReembolsoId) WHERE (T1.PropostaId = T9.ReembolsoPropostaId) AND (T8.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F,";
         scmdbuf += " DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV91Propostacontratowwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV91Propostacontratowwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV91Propostacontratowwds_1_filterfulltext) and COALESCE( T7.ReembolsoStatusAtual_F, '') = ( '')) or ( COALESCE( T6.WorkFlowPasso_F, '') like '%' || :lV91Propostacontratowwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV116ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Propostacontratowwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T7.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV117Propostacontratowwds_27_tfworkflowpasso_f))=0))) or ( COALESCE( T6.WorkFlowPasso_F, '') like :lV117Propostacontratowwds_27_tfworkflowpasso_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel))=0) and Not :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel = ( '<#Empty#>')) or ( COALESCE( T6.WorkFlowPasso_F, '') = ( :AV118Propostacontratowwds_28_tfworkflowpasso_f_sel)))");
         AddWhere(sWhereString, "(:AV118Propostacontratowwds_28_tfworkflowpasso_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T6.WorkFlowPasso_F, '')))=0)))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_2Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratowwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV94Propostacontratowwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Propostacontratowwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV93Propostacontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV95Propostacontratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratowwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV99Propostacontratowwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( AV96Propostacontratowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Propostacontratowwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV98Propostacontratowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV100Propostacontratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratowwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV104Propostacontratowwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( AV101Propostacontratowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Propostacontratowwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV103Propostacontratowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV105Propostacontratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratowwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV106Propostacontratowwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratowwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV108Propostacontratowwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratowwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV109Propostacontratowwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int9[36] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratowwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Propostacontratowwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Propostacontratowwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int9[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Propostacontratowwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Propostacontratowwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int9[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratowwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV112Propostacontratowwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int9[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratowwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV113Propostacontratowwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int9[40] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratowwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratowwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int9[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci))");
         }
         else
         {
            GXv_int9[42] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaId";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AP5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (string)dynConstraints[41] );
               case 1 :
                     return conditional_P00AP9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (string)dynConstraints[41] );
               case 2 :
                     return conditional_P00AP13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (string)dynConstraints[41] );
               case 3 :
                     return conditional_P00AP17(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (string)dynConstraints[41] );
               case 4 :
                     return conditional_P00AP21(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (string)dynConstraints[41] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AP5;
          prmP00AP5 = new Object[] {
          new ParDef("AV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV116ProCount",GXType.Int32,9,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("lV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratowwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV108Propostacontratowwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV109Propostacontratowwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV110Propostacontratowwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Propostacontratowwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostacontratowwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacontratowwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0)
          };
          Object[] prmP00AP9;
          prmP00AP9 = new Object[] {
          new ParDef("AV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV116ProCount",GXType.Int32,9,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("lV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratowwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV108Propostacontratowwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV109Propostacontratowwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV110Propostacontratowwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Propostacontratowwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostacontratowwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacontratowwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0)
          };
          Object[] prmP00AP13;
          prmP00AP13 = new Object[] {
          new ParDef("AV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV116ProCount",GXType.Int32,9,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("lV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratowwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV108Propostacontratowwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV109Propostacontratowwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV110Propostacontratowwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Propostacontratowwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostacontratowwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacontratowwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0)
          };
          Object[] prmP00AP17;
          prmP00AP17 = new Object[] {
          new ParDef("AV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV116ProCount",GXType.Int32,9,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("lV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratowwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV108Propostacontratowwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV109Propostacontratowwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV110Propostacontratowwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Propostacontratowwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostacontratowwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacontratowwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0)
          };
          Object[] prmP00AP21;
          prmP00AP21 = new Object[] {
          new ParDef("AV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Propostacontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV116ProCount",GXType.Int32,9,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("lV117Propostacontratowwds_27_tfworkflowpasso_f",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV118Propostacontratowwds_28_tfworkflowpasso_f_sel",GXType.VarChar,40,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV94Propostacontratowwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV99Propostacontratowwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV104Propostacontratowwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratowwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV107Propostacontratowwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV108Propostacontratowwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV109Propostacontratowwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV110Propostacontratowwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Propostacontratowwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostacontratowwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacontratowwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV114Propostacontratowwds_24_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratowwds_25_tfpropostapacienteclienterazaosoci",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AP5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP21", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP21,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
       }
    }

 }

}
