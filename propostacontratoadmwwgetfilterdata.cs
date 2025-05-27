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
   public class propostacontratoadmwwgetfilterdata : GXProcedure
   {
      public propostacontratoadmwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratoadmwwgetfilterdata( IGxContext context )
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
         AV47OptionsJson = AV34Options.ToJSonString(false);
         AV48OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV49OptionIndexesJson = AV37OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("PropostaContratoAdmWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaContratoAdmWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("PropostaContratoAdmWWGridState"), null, "", "");
         }
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV85GXV1));
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
            AV85GXV1 = (int)(AV85GXV1+1);
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
         AV87Propostacontratoadmwwds_1_filterfulltext = AV50FilterFullText;
         AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV90Propostacontratoadmwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV91Propostacontratoadmwwds_5_contratonome1 = AV74ContratoNome1;
         AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV95Propostacontratoadmwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV96Propostacontratoadmwwds_10_contratonome2 = AV75ContratoNome2;
         AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV100Propostacontratoadmwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV101Propostacontratoadmwwds_15_contratonome3 = AV76ContratoNome3;
         AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV104Propostacontratoadmwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV106Propostacontratoadmwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV107Propostacontratoadmwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV108Propostacontratoadmwwds_22_tfcontratonome = AV62TFContratoNome;
         AV109Propostacontratoadmwwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                              AV91Propostacontratoadmwwds_5_contratonome1 ,
                                              AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                              AV96Propostacontratoadmwwds_10_contratonome2 ,
                                              AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                              AV101Propostacontratoadmwwds_15_contratonome3 ,
                                              AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                              AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                              AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV87Propostacontratoadmwwds_1_filterfulltext ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV104Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
         lV108Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome), "%", "");
         lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00BY4 */
         pr_default.execute(0, new Object[] {AV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, AV9WWPContext.gxTpr_Secuserclienteid, lV90Propostacontratoadmwwds_4_propostatitulo1, lV90Propostacontratoadmwwds_4_propostatitulo1, lV91Propostacontratoadmwwds_5_contratonome1, lV91Propostacontratoadmwwds_5_contratonome1, lV95Propostacontratoadmwwds_9_propostatitulo2, lV95Propostacontratoadmwwds_9_propostatitulo2, lV96Propostacontratoadmwwds_10_contratonome2, lV96Propostacontratoadmwwds_10_contratonome2, lV100Propostacontratoadmwwds_14_propostatitulo3, lV100Propostacontratoadmwwds_14_propostatitulo3, lV101Propostacontratoadmwwds_15_contratonome3, lV101Propostacontratoadmwwds_15_contratonome3, lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV104Propostacontratoadmwwds_18_tfpropostadescricao, AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV106Propostacontratoadmwwds_20_tfpropostavalor, AV107Propostacontratoadmwwds_21_tfpropostavalor_to, lV108Propostacontratoadmwwds_22_tfcontratonome, AV109Propostacontratoadmwwds_23_tfcontratonome_sel, lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBY2 = false;
            A227ContratoId = P00BY4_A227ContratoId[0];
            n227ContratoId = P00BY4_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00BY4_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00BY4_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = P00BY4_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00BY4_n504PropostaPacienteClienteId[0];
            A328PropostaCratedBy = P00BY4_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00BY4_n328PropostaCratedBy[0];
            A329PropostaStatus = P00BY4_A329PropostaStatus[0];
            n329PropostaStatus = P00BY4_n329PropostaStatus[0];
            A377ProcedimentosMedicosNome = P00BY4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY4_n377ProcedimentosMedicosNome[0];
            A326PropostaValor = P00BY4_A326PropostaValor[0];
            n326PropostaValor = P00BY4_n326PropostaValor[0];
            A324PropostaTitulo = P00BY4_A324PropostaTitulo[0];
            n324PropostaTitulo = P00BY4_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY4_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00BY4_A228ContratoNome[0];
            n228ContratoNome = P00BY4_n228ContratoNome[0];
            A325PropostaDescricao = P00BY4_A325PropostaDescricao[0];
            n325PropostaDescricao = P00BY4_n325PropostaDescricao[0];
            A323PropostaId = P00BY4_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00BY4_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY4_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00BY4_A228ContratoNome[0];
            n228ContratoNome = P00BY4_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00BY4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY4_n377ProcedimentosMedicosNome[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY4_n505PropostaPacienteClienteRazaoSocial[0];
            A548ReembolsoStatusAtual_F = P00BY4_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY4_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BY4_A377ProcedimentosMedicosNome[0], A377ProcedimentosMedicosNome) == 0 ) )
            {
               BRKBY2 = false;
               A376ProcedimentosMedicosId = P00BY4_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = P00BY4_n376ProcedimentosMedicosId[0];
               A323PropostaId = P00BY4_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKBY2 = true;
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
            if ( ! BRKBY2 )
            {
               BRKBY2 = true;
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
         AV87Propostacontratoadmwwds_1_filterfulltext = AV50FilterFullText;
         AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV90Propostacontratoadmwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV91Propostacontratoadmwwds_5_contratonome1 = AV74ContratoNome1;
         AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV95Propostacontratoadmwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV96Propostacontratoadmwwds_10_contratonome2 = AV75ContratoNome2;
         AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV100Propostacontratoadmwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV101Propostacontratoadmwwds_15_contratonome3 = AV76ContratoNome3;
         AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV104Propostacontratoadmwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV106Propostacontratoadmwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV107Propostacontratoadmwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV108Propostacontratoadmwwds_22_tfcontratonome = AV62TFContratoNome;
         AV109Propostacontratoadmwwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                              AV91Propostacontratoadmwwds_5_contratonome1 ,
                                              AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                              AV96Propostacontratoadmwwds_10_contratonome2 ,
                                              AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                              AV101Propostacontratoadmwwds_15_contratonome3 ,
                                              AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                              AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                              AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV87Propostacontratoadmwwds_1_filterfulltext ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV104Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
         lV108Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome), "%", "");
         lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00BY7 */
         pr_default.execute(1, new Object[] {AV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, AV9WWPContext.gxTpr_Secuserclienteid, lV90Propostacontratoadmwwds_4_propostatitulo1, lV90Propostacontratoadmwwds_4_propostatitulo1, lV91Propostacontratoadmwwds_5_contratonome1, lV91Propostacontratoadmwwds_5_contratonome1, lV95Propostacontratoadmwwds_9_propostatitulo2, lV95Propostacontratoadmwwds_9_propostatitulo2, lV96Propostacontratoadmwwds_10_contratonome2, lV96Propostacontratoadmwwds_10_contratonome2, lV100Propostacontratoadmwwds_14_propostatitulo3, lV100Propostacontratoadmwwds_14_propostatitulo3, lV101Propostacontratoadmwwds_15_contratonome3, lV101Propostacontratoadmwwds_15_contratonome3, lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV104Propostacontratoadmwwds_18_tfpropostadescricao, AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV106Propostacontratoadmwwds_20_tfpropostavalor, AV107Propostacontratoadmwwds_21_tfpropostavalor_to, lV108Propostacontratoadmwwds_22_tfcontratonome, AV109Propostacontratoadmwwds_23_tfcontratonome_sel, lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBY4 = false;
            A227ContratoId = P00BY7_A227ContratoId[0];
            n227ContratoId = P00BY7_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00BY7_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00BY7_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = P00BY7_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00BY7_n504PropostaPacienteClienteId[0];
            A328PropostaCratedBy = P00BY7_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00BY7_n328PropostaCratedBy[0];
            A329PropostaStatus = P00BY7_A329PropostaStatus[0];
            n329PropostaStatus = P00BY7_n329PropostaStatus[0];
            A325PropostaDescricao = P00BY7_A325PropostaDescricao[0];
            n325PropostaDescricao = P00BY7_n325PropostaDescricao[0];
            A326PropostaValor = P00BY7_A326PropostaValor[0];
            n326PropostaValor = P00BY7_n326PropostaValor[0];
            A324PropostaTitulo = P00BY7_A324PropostaTitulo[0];
            n324PropostaTitulo = P00BY7_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY7_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY7_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00BY7_A228ContratoNome[0];
            n228ContratoNome = P00BY7_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00BY7_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY7_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00BY7_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00BY7_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY7_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00BY7_A228ContratoNome[0];
            n228ContratoNome = P00BY7_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00BY7_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY7_n377ProcedimentosMedicosNome[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY7_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY7_n505PropostaPacienteClienteRazaoSocial[0];
            A548ReembolsoStatusAtual_F = P00BY7_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY7_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BY7_A325PropostaDescricao[0], A325PropostaDescricao) == 0 ) )
            {
               BRKBY4 = false;
               A323PropostaId = P00BY7_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKBY4 = true;
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
            if ( ! BRKBY4 )
            {
               BRKBY4 = true;
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
         AV87Propostacontratoadmwwds_1_filterfulltext = AV50FilterFullText;
         AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV90Propostacontratoadmwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV91Propostacontratoadmwwds_5_contratonome1 = AV74ContratoNome1;
         AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV95Propostacontratoadmwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV96Propostacontratoadmwwds_10_contratonome2 = AV75ContratoNome2;
         AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV100Propostacontratoadmwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV101Propostacontratoadmwwds_15_contratonome3 = AV76ContratoNome3;
         AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV104Propostacontratoadmwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV106Propostacontratoadmwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV107Propostacontratoadmwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV108Propostacontratoadmwwds_22_tfcontratonome = AV62TFContratoNome;
         AV109Propostacontratoadmwwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                              AV91Propostacontratoadmwwds_5_contratonome1 ,
                                              AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                              AV96Propostacontratoadmwwds_10_contratonome2 ,
                                              AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                              AV101Propostacontratoadmwwds_15_contratonome3 ,
                                              AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                              AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                              AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV87Propostacontratoadmwwds_1_filterfulltext ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV104Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
         lV108Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome), "%", "");
         lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00BY10 */
         pr_default.execute(2, new Object[] {AV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, AV9WWPContext.gxTpr_Secuserclienteid, lV90Propostacontratoadmwwds_4_propostatitulo1, lV90Propostacontratoadmwwds_4_propostatitulo1, lV91Propostacontratoadmwwds_5_contratonome1, lV91Propostacontratoadmwwds_5_contratonome1, lV95Propostacontratoadmwwds_9_propostatitulo2, lV95Propostacontratoadmwwds_9_propostatitulo2, lV96Propostacontratoadmwwds_10_contratonome2, lV96Propostacontratoadmwwds_10_contratonome2, lV100Propostacontratoadmwwds_14_propostatitulo3, lV100Propostacontratoadmwwds_14_propostatitulo3, lV101Propostacontratoadmwwds_15_contratonome3, lV101Propostacontratoadmwwds_15_contratonome3, lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV104Propostacontratoadmwwds_18_tfpropostadescricao, AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV106Propostacontratoadmwwds_20_tfpropostavalor, AV107Propostacontratoadmwwds_21_tfpropostavalor_to, lV108Propostacontratoadmwwds_22_tfcontratonome, AV109Propostacontratoadmwwds_23_tfcontratonome_sel, lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBY6 = false;
            A376ProcedimentosMedicosId = P00BY10_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00BY10_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = P00BY10_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00BY10_n504PropostaPacienteClienteId[0];
            A227ContratoId = P00BY10_A227ContratoId[0];
            n227ContratoId = P00BY10_n227ContratoId[0];
            A329PropostaStatus = P00BY10_A329PropostaStatus[0];
            n329PropostaStatus = P00BY10_n329PropostaStatus[0];
            A328PropostaCratedBy = P00BY10_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00BY10_n328PropostaCratedBy[0];
            A326PropostaValor = P00BY10_A326PropostaValor[0];
            n326PropostaValor = P00BY10_n326PropostaValor[0];
            A324PropostaTitulo = P00BY10_A324PropostaTitulo[0];
            n324PropostaTitulo = P00BY10_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY10_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY10_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00BY10_A228ContratoNome[0];
            n228ContratoNome = P00BY10_n228ContratoNome[0];
            A325PropostaDescricao = P00BY10_A325PropostaDescricao[0];
            n325PropostaDescricao = P00BY10_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P00BY10_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY10_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00BY10_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00BY10_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY10_n548ReembolsoStatusAtual_F[0];
            A377ProcedimentosMedicosNome = P00BY10_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY10_n377ProcedimentosMedicosNome[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY10_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY10_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00BY10_A228ContratoNome[0];
            n228ContratoNome = P00BY10_n228ContratoNome[0];
            A548ReembolsoStatusAtual_F = P00BY10_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY10_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00BY10_A227ContratoId[0] == A227ContratoId ) )
            {
               BRKBY6 = false;
               A323PropostaId = P00BY10_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKBY6 = true;
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
            if ( ! BRKBY6 )
            {
               BRKBY6 = true;
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
         AV87Propostacontratoadmwwds_1_filterfulltext = AV50FilterFullText;
         AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV90Propostacontratoadmwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV91Propostacontratoadmwwds_5_contratonome1 = AV74ContratoNome1;
         AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV95Propostacontratoadmwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV96Propostacontratoadmwwds_10_contratonome2 = AV75ContratoNome2;
         AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV100Propostacontratoadmwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV101Propostacontratoadmwwds_15_contratonome3 = AV76ContratoNome3;
         AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV79TFProcedimentosMedicosNome;
         AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV80TFProcedimentosMedicosNome_Sel;
         AV104Propostacontratoadmwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV106Propostacontratoadmwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV107Propostacontratoadmwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV108Propostacontratoadmwwds_22_tfcontratonome = AV62TFContratoNome;
         AV109Propostacontratoadmwwds_23_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV81TFPropostaPacienteClienteRazaoSocial;
         AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV82TFPropostaPacienteClienteRazaoSocial_Sel;
         AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV84TFReembolsoStatusAtual_F_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                              AV91Propostacontratoadmwwds_5_contratonome1 ,
                                              AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                              AV96Propostacontratoadmwwds_10_contratonome2 ,
                                              AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                              AV101Propostacontratoadmwwds_15_contratonome3 ,
                                              AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                              AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                              AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV87Propostacontratoadmwwds_1_filterfulltext ,
                                              AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV87Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV87Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV90Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV91Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV95Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV96Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV100Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV101Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV104Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
         lV108Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome), "%", "");
         lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00BY13 */
         pr_default.execute(3, new Object[] {AV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, lV87Propostacontratoadmwwds_1_filterfulltext, AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, AV9WWPContext.gxTpr_Secuserclienteid, lV90Propostacontratoadmwwds_4_propostatitulo1, lV90Propostacontratoadmwwds_4_propostatitulo1, lV91Propostacontratoadmwwds_5_contratonome1, lV91Propostacontratoadmwwds_5_contratonome1, lV95Propostacontratoadmwwds_9_propostatitulo2, lV95Propostacontratoadmwwds_9_propostatitulo2, lV96Propostacontratoadmwwds_10_contratonome2, lV96Propostacontratoadmwwds_10_contratonome2, lV100Propostacontratoadmwwds_14_propostatitulo3, lV100Propostacontratoadmwwds_14_propostatitulo3, lV101Propostacontratoadmwwds_15_contratonome3, lV101Propostacontratoadmwwds_15_contratonome3, lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV104Propostacontratoadmwwds_18_tfpropostadescricao, AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV106Propostacontratoadmwwds_20_tfpropostavalor, AV107Propostacontratoadmwwds_21_tfpropostavalor_to, lV108Propostacontratoadmwwds_22_tfcontratonome, AV109Propostacontratoadmwwds_23_tfcontratonome_sel, lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKBY8 = false;
            A227ContratoId = P00BY13_A227ContratoId[0];
            n227ContratoId = P00BY13_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00BY13_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00BY13_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = P00BY13_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00BY13_n504PropostaPacienteClienteId[0];
            A328PropostaCratedBy = P00BY13_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00BY13_n328PropostaCratedBy[0];
            A329PropostaStatus = P00BY13_A329PropostaStatus[0];
            n329PropostaStatus = P00BY13_n329PropostaStatus[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY13_n505PropostaPacienteClienteRazaoSocial[0];
            A326PropostaValor = P00BY13_A326PropostaValor[0];
            n326PropostaValor = P00BY13_n326PropostaValor[0];
            A324PropostaTitulo = P00BY13_A324PropostaTitulo[0];
            n324PropostaTitulo = P00BY13_n324PropostaTitulo[0];
            A228ContratoNome = P00BY13_A228ContratoNome[0];
            n228ContratoNome = P00BY13_n228ContratoNome[0];
            A325PropostaDescricao = P00BY13_A325PropostaDescricao[0];
            n325PropostaDescricao = P00BY13_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P00BY13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY13_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00BY13_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00BY13_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY13_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00BY13_A228ContratoNome[0];
            n228ContratoNome = P00BY13_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00BY13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BY13_n377ProcedimentosMedicosNome[0];
            A505PropostaPacienteClienteRazaoSocial = P00BY13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BY13_n505PropostaPacienteClienteRazaoSocial[0];
            A548ReembolsoStatusAtual_F = P00BY13_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BY13_n548ReembolsoStatusAtual_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00BY13_A505PropostaPacienteClienteRazaoSocial[0], A505PropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRKBY8 = false;
               A504PropostaPacienteClienteId = P00BY13_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = P00BY13_n504PropostaPacienteClienteId[0];
               A323PropostaId = P00BY13_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRKBY8 = true;
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
            if ( ! BRKBY8 )
            {
               BRKBY8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV87Propostacontratoadmwwds_1_filterfulltext = "";
         AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 = "";
         AV90Propostacontratoadmwwds_4_propostatitulo1 = "";
         AV91Propostacontratoadmwwds_5_contratonome1 = "";
         AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 = "";
         AV95Propostacontratoadmwwds_9_propostatitulo2 = "";
         AV96Propostacontratoadmwwds_10_contratonome2 = "";
         AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 = "";
         AV100Propostacontratoadmwwds_14_propostatitulo3 = "";
         AV101Propostacontratoadmwwds_15_contratonome3 = "";
         AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = "";
         AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = "";
         AV104Propostacontratoadmwwds_18_tfpropostadescricao = "";
         AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel = "";
         AV108Propostacontratoadmwwds_22_tfcontratonome = "";
         AV109Propostacontratoadmwwds_23_tfcontratonome_sel = "";
         AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = "";
         AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = "";
         AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         lV87Propostacontratoadmwwds_1_filterfulltext = "";
         lV90Propostacontratoadmwwds_4_propostatitulo1 = "";
         lV91Propostacontratoadmwwds_5_contratonome1 = "";
         lV95Propostacontratoadmwwds_9_propostatitulo2 = "";
         lV96Propostacontratoadmwwds_10_contratonome2 = "";
         lV100Propostacontratoadmwwds_14_propostatitulo3 = "";
         lV101Propostacontratoadmwwds_15_contratonome3 = "";
         lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = "";
         lV104Propostacontratoadmwwds_18_tfpropostadescricao = "";
         lV108Propostacontratoadmwwds_22_tfcontratonome = "";
         lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = "";
         A548ReembolsoStatusAtual_F = "";
         A324PropostaTitulo = "";
         A228ContratoNome = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A329PropostaStatus = "";
         P00BY4_A227ContratoId = new int[1] ;
         P00BY4_n227ContratoId = new bool[] {false} ;
         P00BY4_A376ProcedimentosMedicosId = new int[1] ;
         P00BY4_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00BY4_A504PropostaPacienteClienteId = new int[1] ;
         P00BY4_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00BY4_A328PropostaCratedBy = new short[1] ;
         P00BY4_n328PropostaCratedBy = new bool[] {false} ;
         P00BY4_A329PropostaStatus = new string[] {""} ;
         P00BY4_n329PropostaStatus = new bool[] {false} ;
         P00BY4_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00BY4_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00BY4_A326PropostaValor = new decimal[1] ;
         P00BY4_n326PropostaValor = new bool[] {false} ;
         P00BY4_A324PropostaTitulo = new string[] {""} ;
         P00BY4_n324PropostaTitulo = new bool[] {false} ;
         P00BY4_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00BY4_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00BY4_A228ContratoNome = new string[] {""} ;
         P00BY4_n228ContratoNome = new bool[] {false} ;
         P00BY4_A325PropostaDescricao = new string[] {""} ;
         P00BY4_n325PropostaDescricao = new bool[] {false} ;
         P00BY4_A323PropostaId = new int[1] ;
         P00BY4_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00BY4_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         AV33Option = "";
         P00BY7_A227ContratoId = new int[1] ;
         P00BY7_n227ContratoId = new bool[] {false} ;
         P00BY7_A376ProcedimentosMedicosId = new int[1] ;
         P00BY7_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00BY7_A504PropostaPacienteClienteId = new int[1] ;
         P00BY7_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00BY7_A328PropostaCratedBy = new short[1] ;
         P00BY7_n328PropostaCratedBy = new bool[] {false} ;
         P00BY7_A329PropostaStatus = new string[] {""} ;
         P00BY7_n329PropostaStatus = new bool[] {false} ;
         P00BY7_A325PropostaDescricao = new string[] {""} ;
         P00BY7_n325PropostaDescricao = new bool[] {false} ;
         P00BY7_A326PropostaValor = new decimal[1] ;
         P00BY7_n326PropostaValor = new bool[] {false} ;
         P00BY7_A324PropostaTitulo = new string[] {""} ;
         P00BY7_n324PropostaTitulo = new bool[] {false} ;
         P00BY7_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00BY7_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00BY7_A228ContratoNome = new string[] {""} ;
         P00BY7_n228ContratoNome = new bool[] {false} ;
         P00BY7_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00BY7_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00BY7_A323PropostaId = new int[1] ;
         P00BY7_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00BY7_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         P00BY10_A376ProcedimentosMedicosId = new int[1] ;
         P00BY10_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00BY10_A504PropostaPacienteClienteId = new int[1] ;
         P00BY10_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00BY10_A227ContratoId = new int[1] ;
         P00BY10_n227ContratoId = new bool[] {false} ;
         P00BY10_A329PropostaStatus = new string[] {""} ;
         P00BY10_n329PropostaStatus = new bool[] {false} ;
         P00BY10_A328PropostaCratedBy = new short[1] ;
         P00BY10_n328PropostaCratedBy = new bool[] {false} ;
         P00BY10_A326PropostaValor = new decimal[1] ;
         P00BY10_n326PropostaValor = new bool[] {false} ;
         P00BY10_A324PropostaTitulo = new string[] {""} ;
         P00BY10_n324PropostaTitulo = new bool[] {false} ;
         P00BY10_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00BY10_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00BY10_A228ContratoNome = new string[] {""} ;
         P00BY10_n228ContratoNome = new bool[] {false} ;
         P00BY10_A325PropostaDescricao = new string[] {""} ;
         P00BY10_n325PropostaDescricao = new bool[] {false} ;
         P00BY10_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00BY10_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00BY10_A323PropostaId = new int[1] ;
         P00BY10_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00BY10_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         P00BY13_A227ContratoId = new int[1] ;
         P00BY13_n227ContratoId = new bool[] {false} ;
         P00BY13_A376ProcedimentosMedicosId = new int[1] ;
         P00BY13_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00BY13_A504PropostaPacienteClienteId = new int[1] ;
         P00BY13_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00BY13_A328PropostaCratedBy = new short[1] ;
         P00BY13_n328PropostaCratedBy = new bool[] {false} ;
         P00BY13_A329PropostaStatus = new string[] {""} ;
         P00BY13_n329PropostaStatus = new bool[] {false} ;
         P00BY13_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00BY13_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00BY13_A326PropostaValor = new decimal[1] ;
         P00BY13_n326PropostaValor = new bool[] {false} ;
         P00BY13_A324PropostaTitulo = new string[] {""} ;
         P00BY13_n324PropostaTitulo = new bool[] {false} ;
         P00BY13_A228ContratoNome = new string[] {""} ;
         P00BY13_n228ContratoNome = new bool[] {false} ;
         P00BY13_A325PropostaDescricao = new string[] {""} ;
         P00BY13_n325PropostaDescricao = new bool[] {false} ;
         P00BY13_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00BY13_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00BY13_A323PropostaId = new int[1] ;
         P00BY13_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00BY13_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratoadmwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BY4_A227ContratoId, P00BY4_n227ContratoId, P00BY4_A376ProcedimentosMedicosId, P00BY4_n376ProcedimentosMedicosId, P00BY4_A504PropostaPacienteClienteId, P00BY4_n504PropostaPacienteClienteId, P00BY4_A328PropostaCratedBy, P00BY4_n328PropostaCratedBy, P00BY4_A329PropostaStatus, P00BY4_n329PropostaStatus,
               P00BY4_A377ProcedimentosMedicosNome, P00BY4_n377ProcedimentosMedicosNome, P00BY4_A326PropostaValor, P00BY4_n326PropostaValor, P00BY4_A324PropostaTitulo, P00BY4_n324PropostaTitulo, P00BY4_A505PropostaPacienteClienteRazaoSocial, P00BY4_n505PropostaPacienteClienteRazaoSocial, P00BY4_A228ContratoNome, P00BY4_n228ContratoNome,
               P00BY4_A325PropostaDescricao, P00BY4_n325PropostaDescricao, P00BY4_A323PropostaId, P00BY4_A548ReembolsoStatusAtual_F, P00BY4_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00BY7_A227ContratoId, P00BY7_n227ContratoId, P00BY7_A376ProcedimentosMedicosId, P00BY7_n376ProcedimentosMedicosId, P00BY7_A504PropostaPacienteClienteId, P00BY7_n504PropostaPacienteClienteId, P00BY7_A328PropostaCratedBy, P00BY7_n328PropostaCratedBy, P00BY7_A329PropostaStatus, P00BY7_n329PropostaStatus,
               P00BY7_A325PropostaDescricao, P00BY7_n325PropostaDescricao, P00BY7_A326PropostaValor, P00BY7_n326PropostaValor, P00BY7_A324PropostaTitulo, P00BY7_n324PropostaTitulo, P00BY7_A505PropostaPacienteClienteRazaoSocial, P00BY7_n505PropostaPacienteClienteRazaoSocial, P00BY7_A228ContratoNome, P00BY7_n228ContratoNome,
               P00BY7_A377ProcedimentosMedicosNome, P00BY7_n377ProcedimentosMedicosNome, P00BY7_A323PropostaId, P00BY7_A548ReembolsoStatusAtual_F, P00BY7_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00BY10_A376ProcedimentosMedicosId, P00BY10_n376ProcedimentosMedicosId, P00BY10_A504PropostaPacienteClienteId, P00BY10_n504PropostaPacienteClienteId, P00BY10_A227ContratoId, P00BY10_n227ContratoId, P00BY10_A329PropostaStatus, P00BY10_n329PropostaStatus, P00BY10_A328PropostaCratedBy, P00BY10_n328PropostaCratedBy,
               P00BY10_A326PropostaValor, P00BY10_n326PropostaValor, P00BY10_A324PropostaTitulo, P00BY10_n324PropostaTitulo, P00BY10_A505PropostaPacienteClienteRazaoSocial, P00BY10_n505PropostaPacienteClienteRazaoSocial, P00BY10_A228ContratoNome, P00BY10_n228ContratoNome, P00BY10_A325PropostaDescricao, P00BY10_n325PropostaDescricao,
               P00BY10_A377ProcedimentosMedicosNome, P00BY10_n377ProcedimentosMedicosNome, P00BY10_A323PropostaId, P00BY10_A548ReembolsoStatusAtual_F, P00BY10_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               P00BY13_A227ContratoId, P00BY13_n227ContratoId, P00BY13_A376ProcedimentosMedicosId, P00BY13_n376ProcedimentosMedicosId, P00BY13_A504PropostaPacienteClienteId, P00BY13_n504PropostaPacienteClienteId, P00BY13_A328PropostaCratedBy, P00BY13_n328PropostaCratedBy, P00BY13_A329PropostaStatus, P00BY13_n329PropostaStatus,
               P00BY13_A505PropostaPacienteClienteRazaoSocial, P00BY13_n505PropostaPacienteClienteRazaoSocial, P00BY13_A326PropostaValor, P00BY13_n326PropostaValor, P00BY13_A324PropostaTitulo, P00BY13_n324PropostaTitulo, P00BY13_A228ContratoNome, P00BY13_n228ContratoNome, P00BY13_A325PropostaDescricao, P00BY13_n325PropostaDescricao,
               P00BY13_A377ProcedimentosMedicosNome, P00BY13_n377ProcedimentosMedicosNome, P00BY13_A323PropostaId, P00BY13_A548ReembolsoStatusAtual_F, P00BY13_n548ReembolsoStatusAtual_F
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
      private short AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ;
      private short AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ;
      private short AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A328PropostaCratedBy ;
      private int AV85GXV1 ;
      private int AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int AV32InsertIndex ;
      private long AV38count ;
      private decimal AV16TFPropostaValor ;
      private decimal AV17TFPropostaValor_To ;
      private decimal AV106Propostacontratoadmwwds_20_tfpropostavalor ;
      private decimal AV107Propostacontratoadmwwds_21_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private bool returnInSub ;
      private bool AV54DynamicFiltersEnabled2 ;
      private bool AV58DynamicFiltersEnabled3 ;
      private bool AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ;
      private bool AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ;
      private bool BRKBY2 ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n328PropostaCratedBy ;
      private bool n329PropostaStatus ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n326PropostaValor ;
      private bool n324PropostaTitulo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n228ContratoNome ;
      private bool n325PropostaDescricao ;
      private bool n548ReembolsoStatusAtual_F ;
      private bool BRKBY4 ;
      private bool BRKBY6 ;
      private bool BRKBY8 ;
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
      private string AV51DynamicFiltersSelector1 ;
      private string AV53PropostaTitulo1 ;
      private string AV74ContratoNome1 ;
      private string AV55DynamicFiltersSelector2 ;
      private string AV57PropostaTitulo2 ;
      private string AV75ContratoNome2 ;
      private string AV59DynamicFiltersSelector3 ;
      private string AV61PropostaTitulo3 ;
      private string AV76ContratoNome3 ;
      private string AV87Propostacontratoadmwwds_1_filterfulltext ;
      private string AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ;
      private string AV90Propostacontratoadmwwds_4_propostatitulo1 ;
      private string AV91Propostacontratoadmwwds_5_contratonome1 ;
      private string AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ;
      private string AV95Propostacontratoadmwwds_9_propostatitulo2 ;
      private string AV96Propostacontratoadmwwds_10_contratonome2 ;
      private string AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ;
      private string AV100Propostacontratoadmwwds_14_propostatitulo3 ;
      private string AV101Propostacontratoadmwwds_15_contratonome3 ;
      private string AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ;
      private string AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ;
      private string AV104Propostacontratoadmwwds_18_tfpropostadescricao ;
      private string AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ;
      private string AV108Propostacontratoadmwwds_22_tfcontratonome ;
      private string AV109Propostacontratoadmwwds_23_tfcontratonome_sel ;
      private string AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ;
      private string AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ;
      private string lV87Propostacontratoadmwwds_1_filterfulltext ;
      private string lV90Propostacontratoadmwwds_4_propostatitulo1 ;
      private string lV91Propostacontratoadmwwds_5_contratonome1 ;
      private string lV95Propostacontratoadmwwds_9_propostatitulo2 ;
      private string lV96Propostacontratoadmwwds_10_contratonome2 ;
      private string lV100Propostacontratoadmwwds_14_propostatitulo3 ;
      private string lV101Propostacontratoadmwwds_15_contratonome3 ;
      private string lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ;
      private string lV104Propostacontratoadmwwds_18_tfpropostadescricao ;
      private string lV108Propostacontratoadmwwds_22_tfcontratonome ;
      private string lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ;
      private string A548ReembolsoStatusAtual_F ;
      private string A324PropostaTitulo ;
      private string A228ContratoNome ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
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
      private GxSimpleCollection<string> AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00BY4_A227ContratoId ;
      private bool[] P00BY4_n227ContratoId ;
      private int[] P00BY4_A376ProcedimentosMedicosId ;
      private bool[] P00BY4_n376ProcedimentosMedicosId ;
      private int[] P00BY4_A504PropostaPacienteClienteId ;
      private bool[] P00BY4_n504PropostaPacienteClienteId ;
      private short[] P00BY4_A328PropostaCratedBy ;
      private bool[] P00BY4_n328PropostaCratedBy ;
      private string[] P00BY4_A329PropostaStatus ;
      private bool[] P00BY4_n329PropostaStatus ;
      private string[] P00BY4_A377ProcedimentosMedicosNome ;
      private bool[] P00BY4_n377ProcedimentosMedicosNome ;
      private decimal[] P00BY4_A326PropostaValor ;
      private bool[] P00BY4_n326PropostaValor ;
      private string[] P00BY4_A324PropostaTitulo ;
      private bool[] P00BY4_n324PropostaTitulo ;
      private string[] P00BY4_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00BY4_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00BY4_A228ContratoNome ;
      private bool[] P00BY4_n228ContratoNome ;
      private string[] P00BY4_A325PropostaDescricao ;
      private bool[] P00BY4_n325PropostaDescricao ;
      private int[] P00BY4_A323PropostaId ;
      private string[] P00BY4_A548ReembolsoStatusAtual_F ;
      private bool[] P00BY4_n548ReembolsoStatusAtual_F ;
      private int[] P00BY7_A227ContratoId ;
      private bool[] P00BY7_n227ContratoId ;
      private int[] P00BY7_A376ProcedimentosMedicosId ;
      private bool[] P00BY7_n376ProcedimentosMedicosId ;
      private int[] P00BY7_A504PropostaPacienteClienteId ;
      private bool[] P00BY7_n504PropostaPacienteClienteId ;
      private short[] P00BY7_A328PropostaCratedBy ;
      private bool[] P00BY7_n328PropostaCratedBy ;
      private string[] P00BY7_A329PropostaStatus ;
      private bool[] P00BY7_n329PropostaStatus ;
      private string[] P00BY7_A325PropostaDescricao ;
      private bool[] P00BY7_n325PropostaDescricao ;
      private decimal[] P00BY7_A326PropostaValor ;
      private bool[] P00BY7_n326PropostaValor ;
      private string[] P00BY7_A324PropostaTitulo ;
      private bool[] P00BY7_n324PropostaTitulo ;
      private string[] P00BY7_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00BY7_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00BY7_A228ContratoNome ;
      private bool[] P00BY7_n228ContratoNome ;
      private string[] P00BY7_A377ProcedimentosMedicosNome ;
      private bool[] P00BY7_n377ProcedimentosMedicosNome ;
      private int[] P00BY7_A323PropostaId ;
      private string[] P00BY7_A548ReembolsoStatusAtual_F ;
      private bool[] P00BY7_n548ReembolsoStatusAtual_F ;
      private int[] P00BY10_A376ProcedimentosMedicosId ;
      private bool[] P00BY10_n376ProcedimentosMedicosId ;
      private int[] P00BY10_A504PropostaPacienteClienteId ;
      private bool[] P00BY10_n504PropostaPacienteClienteId ;
      private int[] P00BY10_A227ContratoId ;
      private bool[] P00BY10_n227ContratoId ;
      private string[] P00BY10_A329PropostaStatus ;
      private bool[] P00BY10_n329PropostaStatus ;
      private short[] P00BY10_A328PropostaCratedBy ;
      private bool[] P00BY10_n328PropostaCratedBy ;
      private decimal[] P00BY10_A326PropostaValor ;
      private bool[] P00BY10_n326PropostaValor ;
      private string[] P00BY10_A324PropostaTitulo ;
      private bool[] P00BY10_n324PropostaTitulo ;
      private string[] P00BY10_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00BY10_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00BY10_A228ContratoNome ;
      private bool[] P00BY10_n228ContratoNome ;
      private string[] P00BY10_A325PropostaDescricao ;
      private bool[] P00BY10_n325PropostaDescricao ;
      private string[] P00BY10_A377ProcedimentosMedicosNome ;
      private bool[] P00BY10_n377ProcedimentosMedicosNome ;
      private int[] P00BY10_A323PropostaId ;
      private string[] P00BY10_A548ReembolsoStatusAtual_F ;
      private bool[] P00BY10_n548ReembolsoStatusAtual_F ;
      private int[] P00BY13_A227ContratoId ;
      private bool[] P00BY13_n227ContratoId ;
      private int[] P00BY13_A376ProcedimentosMedicosId ;
      private bool[] P00BY13_n376ProcedimentosMedicosId ;
      private int[] P00BY13_A504PropostaPacienteClienteId ;
      private bool[] P00BY13_n504PropostaPacienteClienteId ;
      private short[] P00BY13_A328PropostaCratedBy ;
      private bool[] P00BY13_n328PropostaCratedBy ;
      private string[] P00BY13_A329PropostaStatus ;
      private bool[] P00BY13_n329PropostaStatus ;
      private string[] P00BY13_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00BY13_n505PropostaPacienteClienteRazaoSocial ;
      private decimal[] P00BY13_A326PropostaValor ;
      private bool[] P00BY13_n326PropostaValor ;
      private string[] P00BY13_A324PropostaTitulo ;
      private bool[] P00BY13_n324PropostaTitulo ;
      private string[] P00BY13_A228ContratoNome ;
      private bool[] P00BY13_n228ContratoNome ;
      private string[] P00BY13_A325PropostaDescricao ;
      private bool[] P00BY13_n325PropostaDescricao ;
      private string[] P00BY13_A377ProcedimentosMedicosNome ;
      private bool[] P00BY13_n377ProcedimentosMedicosNome ;
      private int[] P00BY13_A323PropostaId ;
      private string[] P00BY13_A548ReembolsoStatusAtual_F ;
      private bool[] P00BY13_n548ReembolsoStatusAtual_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class propostacontratoadmwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BY4( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                             short AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                             string AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                             string AV91Propostacontratoadmwwds_5_contratonome1 ,
                                             bool AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                             string AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                             short AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                             string AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                             string AV96Propostacontratoadmwwds_10_contratonome2 ,
                                             bool AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                             string AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                             short AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                             string AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                             string AV101Propostacontratoadmwwds_15_contratonome3 ,
                                             string AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                             string AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                             string AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                             decimal AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                             decimal AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                             string AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                             string AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                             string AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string AV87Propostacontratoadmwwds_1_filterfulltext ,
                                             int AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                             short A328PropostaCratedBy ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[34];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaCratedBy, T1.PropostaStatus, T3.ProcedimentosMedicosNome, T1.PropostaValor, T1.PropostaTitulo, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaDescricao, T1.PropostaId, COALESCE( T5.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T6.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId FROM ((ReembolsoEtapa T6 LEFT JOIN Reembolso T7 ON T7.ReembolsoId = T6.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T6.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T6.ReembolsoId) WHERE (T1.PropostaId = T7.ReembolsoPropostaId) AND (T6.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV87Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV112ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_2Secuserclienteid)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV104Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV106Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV106Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV107Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV107Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV108Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV109Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00BY7( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                             short AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                             string AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                             string AV91Propostacontratoadmwwds_5_contratonome1 ,
                                             bool AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                             string AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                             short AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                             string AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                             string AV96Propostacontratoadmwwds_10_contratonome2 ,
                                             bool AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                             string AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                             short AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                             string AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                             string AV101Propostacontratoadmwwds_15_contratonome3 ,
                                             string AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                             string AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                             string AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                             decimal AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                             decimal AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                             string AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                             string AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                             string AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string AV87Propostacontratoadmwwds_1_filterfulltext ,
                                             int AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                             short A328PropostaCratedBy ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[34];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaCratedBy, T1.PropostaStatus, T1.PropostaDescricao, T1.PropostaValor, T1.PropostaTitulo, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T5.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T6.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId FROM ((ReembolsoEtapa T6 LEFT JOIN Reembolso T7 ON T7.ReembolsoId = T6.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T6.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T6.ReembolsoId) WHERE (T1.PropostaId = T7.ReembolsoPropostaId) AND (T6.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV87Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV112ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_2Secuserclienteid)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV104Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV106Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV106Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV107Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV107Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV108Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV109Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00BY10( IGxContext context ,
                                              string A548ReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              string AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              short AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              string AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                              string AV91Propostacontratoadmwwds_5_contratonome1 ,
                                              bool AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              string AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              short AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              string AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                              string AV96Propostacontratoadmwwds_10_contratonome2 ,
                                              bool AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              string AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              short AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              string AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                              string AV101Propostacontratoadmwwds_15_contratonome3 ,
                                              string AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              string AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              string AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              decimal AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                              decimal AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              string AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              string AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                              string AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV87Propostacontratoadmwwds_1_filterfulltext ,
                                              int AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                              short A328PropostaCratedBy ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[34];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.ContratoId, T1.PropostaStatus, T1.PropostaCratedBy, T1.PropostaValor, T1.PropostaTitulo, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T4.ContratoNome, T1.PropostaDescricao, T2.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T5.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Contrato T4 ON T4.ContratoId = T1.ContratoId) LEFT JOIN LATERAL (SELECT MIN(T6.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId FROM ((ReembolsoEtapa T6 LEFT JOIN Reembolso T7 ON T7.ReembolsoId = T6.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T6.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T6.ReembolsoId) WHERE (T1.PropostaId = T7.ReembolsoPropostaId) AND (T6.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV87Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T2.ProcedimentosMedicosNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T4.ContratoNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV112ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_2Secuserclienteid)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like '%' || :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like '%' || :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like '%' || :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T2.ProcedimentosMedicosNome like :lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProcedimentosMedicosNome = ( :AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV104Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV106Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV106Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV107Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV107Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome like :lV108Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ContratoNome = ( :AV109Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T4.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00BY13( IGxContext context ,
                                              string A548ReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              string AV88Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              short AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              string AV90Propostacontratoadmwwds_4_propostatitulo1 ,
                                              string AV91Propostacontratoadmwwds_5_contratonome1 ,
                                              bool AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              string AV93Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              short AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              string AV95Propostacontratoadmwwds_9_propostatitulo2 ,
                                              string AV96Propostacontratoadmwwds_10_contratonome2 ,
                                              bool AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              string AV98Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              short AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              string AV100Propostacontratoadmwwds_14_propostatitulo3 ,
                                              string AV101Propostacontratoadmwwds_15_contratonome3 ,
                                              string AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              string AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              string AV104Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              decimal AV106Propostacontratoadmwwds_20_tfpropostavalor ,
                                              decimal AV107Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              string AV109Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              string AV108Propostacontratoadmwwds_22_tfcontratonome ,
                                              string AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV87Propostacontratoadmwwds_1_filterfulltext ,
                                              int AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                              short A328PropostaCratedBy ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[34];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaCratedBy, T1.PropostaStatus, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaValor, T1.PropostaTitulo, T2.ContratoNome, T1.PropostaDescricao, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T5.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T6.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId FROM ((ReembolsoEtapa T6 LEFT JOIN Reembolso T7 ON T7.ReembolsoId = T6.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T6.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T6.ReembolsoId) WHERE (T1.PropostaId = T7.ReembolsoPropostaId) AND (T6.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV87Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV87Propostacontratoadmwwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV87Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV112ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV112Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_2Secuserclienteid)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV90Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV88Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV89Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV91Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV95Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV92Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV94Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV100Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV97Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV101Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV104Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV106Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV106Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV107Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV107Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV108Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV109Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( StringUtil.StrCmp(AV109Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.ClienteRazaoSocial";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BY4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (int)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] );
               case 1 :
                     return conditional_P00BY7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (int)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] );
               case 2 :
                     return conditional_P00BY10(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (int)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] );
               case 3 :
                     return conditional_P00BY13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (int)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BY4;
          prmP00BY4 = new Object[] {
          new ParDef("AV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112ProCount",GXType.Int32,9,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV104Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV106Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV107Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV108Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV109Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0)
          };
          Object[] prmP00BY7;
          prmP00BY7 = new Object[] {
          new ParDef("AV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112ProCount",GXType.Int32,9,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV104Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV106Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV107Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV108Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV109Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0)
          };
          Object[] prmP00BY10;
          prmP00BY10 = new Object[] {
          new ParDef("AV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112ProCount",GXType.Int32,9,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV104Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV106Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV107Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV108Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV109Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0)
          };
          Object[] prmP00BY13;
          prmP00BY13 = new Object[] {
          new ParDef("AV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV112ProCount",GXType.Int32,9,0) ,
          new ParDef("AV9WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV90Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV91Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV101Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV103Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV104Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV105Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV106Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV107Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV108Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV109Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV110Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV111Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BY4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BY7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BY10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BY13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY13,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
