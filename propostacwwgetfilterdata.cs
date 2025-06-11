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
   public class propostacwwgetfilterdata : GXProcedure
   {
      public propostacwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(AV39Session.Get("PropostaCWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaCWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("PropostaCWWGridState"), null, "", "");
         }
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV87GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV81TFProcedimentosMedicosNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV82TFProcedimentosMedicosNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV22TFPropostaStatus_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV23TFPropostaStatus_Sels.FromJSonString(AV22TFPropostaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV62TFContratoNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV63TFContratoNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAQUANTIDADEAPROVADORES") == 0 )
            {
               AV26TFPropostaQuantidadeAprovadores = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV27TFPropostaQuantidadeAprovadores_To = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAAPROVACOES_F") == 0 )
            {
               AV72TFPropostaAprovacoes_F = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV73TFPropostaAprovacoes_F_To = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAREPROVACOES_F") == 0 )
            {
               AV74TFPropostaReprovacoes_F = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV75TFPropostaReprovacoes_F_To = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV85TFPropostaPacienteClienteRazaoSocial = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV86TFPropostaPacienteClienteRazaoSocial_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV87GXV1 = (int)(AV87GXV1+1);
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
               AV76ContratoNome1 = AV43GridStateDynamicFilter.gxTpr_Value;
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
                  AV77ContratoNome2 = AV43GridStateDynamicFilter.gxTpr_Value;
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
                     AV78ContratoNome3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROCEDIMENTOSMEDICOSNOMEOPTIONS' Routine */
         returnInSub = false;
         AV81TFProcedimentosMedicosNome = AV28SearchTxt;
         AV82TFProcedimentosMedicosNome_Sel = "";
         AV89Propostacwwds_1_filterfulltext = AV50FilterFullText;
         AV90Propostacwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV91Propostacwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV92Propostacwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV93Propostacwwds_5_contratonome1 = AV76ContratoNome1;
         AV94Propostacwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV95Propostacwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV96Propostacwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV97Propostacwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV98Propostacwwds_10_contratonome2 = AV77ContratoNome2;
         AV99Propostacwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV100Propostacwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV101Propostacwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV102Propostacwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV103Propostacwwds_15_contratonome3 = AV78ContratoNome3;
         AV104Propostacwwds_16_tfprocedimentosmedicosnome = AV81TFProcedimentosMedicosNome;
         AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel = AV82TFProcedimentosMedicosNome_Sel;
         AV106Propostacwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV107Propostacwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV108Propostacwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV109Propostacwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV110Propostacwwds_22_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         AV111Propostacwwds_23_tfcontratonome = AV62TFContratoNome;
         AV112Propostacwwds_24_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV113Propostacwwds_25_tfpropostaquantidadeaprovadores = AV26TFPropostaQuantidadeAprovadores;
         AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to = AV27TFPropostaQuantidadeAprovadores_To;
         AV115Propostacwwds_27_tfpropostaaprovacoes_f = AV72TFPropostaAprovacoes_F;
         AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = AV73TFPropostaAprovacoes_F_To;
         AV117Propostacwwds_29_tfpropostareprovacoes_f = AV74TFPropostaReprovacoes_F;
         AV118Propostacwwds_30_tfpropostareprovacoes_f_to = AV75TFPropostaReprovacoes_F_To;
         AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = AV85TFPropostaPacienteClienteRazaoSocial;
         AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = AV86TFPropostaPacienteClienteRazaoSocial_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels ,
                                              AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                              AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                              AV92Propostacwwds_4_propostatitulo1 ,
                                              AV93Propostacwwds_5_contratonome1 ,
                                              AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                              AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                              AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                              AV97Propostacwwds_9_propostatitulo2 ,
                                              AV98Propostacwwds_10_contratonome2 ,
                                              AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                              AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                              AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                              AV102Propostacwwds_14_propostatitulo3 ,
                                              AV103Propostacwwds_15_contratonome3 ,
                                              AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                              AV106Propostacwwds_18_tfpropostadescricao ,
                                              AV108Propostacwwds_20_tfpropostavalor ,
                                              AV109Propostacwwds_21_tfpropostavalor_to ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels.Count ,
                                              AV112Propostacwwds_24_tfcontratonome_sel ,
                                              AV111Propostacwwds_23_tfcontratonome ,
                                              AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A330PropostaQuantidadeAprovadores ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV89Propostacwwds_1_filterfulltext ,
                                              A341PropostaAprovacoes_F ,
                                              A342PropostaReprovacoes_F ,
                                              AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                              AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV104Propostacwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV106Propostacwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao), "%", "");
         lV111Propostacwwds_23_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome), "%", "");
         lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P009L4 */
         pr_default.execute(0, new Object[] {AV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV92Propostacwwds_4_propostatitulo1, lV92Propostacwwds_4_propostatitulo1, lV93Propostacwwds_5_contratonome1, lV93Propostacwwds_5_contratonome1, lV97Propostacwwds_9_propostatitulo2, lV97Propostacwwds_9_propostatitulo2, lV98Propostacwwds_10_contratonome2, lV98Propostacwwds_10_contratonome2, lV102Propostacwwds_14_propostatitulo3, lV102Propostacwwds_14_propostatitulo3, lV103Propostacwwds_15_contratonome3, lV103Propostacwwds_15_contratonome3, lV104Propostacwwds_16_tfprocedimentosmedicosnome, AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, lV106Propostacwwds_18_tfpropostadescricao, AV107Propostacwwds_19_tfpropostadescricao_sel, AV108Propostacwwds_20_tfpropostavalor, AV109Propostacwwds_21_tfpropostavalor_to, lV111Propostacwwds_23_tfcontratonome, AV112Propostacwwds_24_tfcontratonome_sel, AV113Propostacwwds_25_tfpropostaquantidadeaprovadores, AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to, lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial, AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9L2 = false;
            A227ContratoId = P009L4_A227ContratoId[0];
            n227ContratoId = P009L4_n227ContratoId[0];
            A376ProcedimentosMedicosId = P009L4_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P009L4_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P009L4_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009L4_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P009L4_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P009L4_n504PropostaPacienteClienteId[0];
            A323PropostaId = P009L4_A323PropostaId[0];
            n323PropostaId = P009L4_n323PropostaId[0];
            A377ProcedimentosMedicosNome = P009L4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L4_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P009L4_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L4_n210SecUserClienteId[0];
            A642PropostaClinicaId = P009L4_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P009L4_n642PropostaClinicaId[0];
            A330PropostaQuantidadeAprovadores = P009L4_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = P009L4_n330PropostaQuantidadeAprovadores[0];
            A326PropostaValor = P009L4_A326PropostaValor[0];
            n326PropostaValor = P009L4_n326PropostaValor[0];
            A324PropostaTitulo = P009L4_A324PropostaTitulo[0];
            n324PropostaTitulo = P009L4_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P009L4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L4_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P009L4_A228ContratoNome[0];
            n228ContratoNome = P009L4_n228ContratoNome[0];
            A329PropostaStatus = P009L4_A329PropostaStatus[0];
            n329PropostaStatus = P009L4_n329PropostaStatus[0];
            A325PropostaDescricao = P009L4_A325PropostaDescricao[0];
            n325PropostaDescricao = P009L4_n325PropostaDescricao[0];
            A342PropostaReprovacoes_F = P009L4_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L4_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L4_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L4_n341PropostaAprovacoes_F[0];
            A228ContratoNome = P009L4_A228ContratoNome[0];
            n228ContratoNome = P009L4_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P009L4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L4_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P009L4_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L4_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P009L4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L4_n505PropostaPacienteClienteRazaoSocial[0];
            A342PropostaReprovacoes_F = P009L4_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L4_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L4_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L4_n341PropostaAprovacoes_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009L4_A377ProcedimentosMedicosNome[0], A377ProcedimentosMedicosNome) == 0 ) )
            {
               BRK9L2 = false;
               A376ProcedimentosMedicosId = P009L4_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = P009L4_n376ProcedimentosMedicosId[0];
               A323PropostaId = P009L4_A323PropostaId[0];
               n323PropostaId = P009L4_n323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRK9L2 = true;
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
            if ( ! BRK9L2 )
            {
               BRK9L2 = true;
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
         AV89Propostacwwds_1_filterfulltext = AV50FilterFullText;
         AV90Propostacwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV91Propostacwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV92Propostacwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV93Propostacwwds_5_contratonome1 = AV76ContratoNome1;
         AV94Propostacwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV95Propostacwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV96Propostacwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV97Propostacwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV98Propostacwwds_10_contratonome2 = AV77ContratoNome2;
         AV99Propostacwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV100Propostacwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV101Propostacwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV102Propostacwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV103Propostacwwds_15_contratonome3 = AV78ContratoNome3;
         AV104Propostacwwds_16_tfprocedimentosmedicosnome = AV81TFProcedimentosMedicosNome;
         AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel = AV82TFProcedimentosMedicosNome_Sel;
         AV106Propostacwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV107Propostacwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV108Propostacwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV109Propostacwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV110Propostacwwds_22_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         AV111Propostacwwds_23_tfcontratonome = AV62TFContratoNome;
         AV112Propostacwwds_24_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV113Propostacwwds_25_tfpropostaquantidadeaprovadores = AV26TFPropostaQuantidadeAprovadores;
         AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to = AV27TFPropostaQuantidadeAprovadores_To;
         AV115Propostacwwds_27_tfpropostaaprovacoes_f = AV72TFPropostaAprovacoes_F;
         AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = AV73TFPropostaAprovacoes_F_To;
         AV117Propostacwwds_29_tfpropostareprovacoes_f = AV74TFPropostaReprovacoes_F;
         AV118Propostacwwds_30_tfpropostareprovacoes_f_to = AV75TFPropostaReprovacoes_F_To;
         AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = AV85TFPropostaPacienteClienteRazaoSocial;
         AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = AV86TFPropostaPacienteClienteRazaoSocial_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels ,
                                              AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                              AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                              AV92Propostacwwds_4_propostatitulo1 ,
                                              AV93Propostacwwds_5_contratonome1 ,
                                              AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                              AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                              AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                              AV97Propostacwwds_9_propostatitulo2 ,
                                              AV98Propostacwwds_10_contratonome2 ,
                                              AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                              AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                              AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                              AV102Propostacwwds_14_propostatitulo3 ,
                                              AV103Propostacwwds_15_contratonome3 ,
                                              AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                              AV106Propostacwwds_18_tfpropostadescricao ,
                                              AV108Propostacwwds_20_tfpropostavalor ,
                                              AV109Propostacwwds_21_tfpropostavalor_to ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels.Count ,
                                              AV112Propostacwwds_24_tfcontratonome_sel ,
                                              AV111Propostacwwds_23_tfcontratonome ,
                                              AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A330PropostaQuantidadeAprovadores ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV89Propostacwwds_1_filterfulltext ,
                                              A341PropostaAprovacoes_F ,
                                              A342PropostaReprovacoes_F ,
                                              AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                              AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV104Propostacwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV106Propostacwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao), "%", "");
         lV111Propostacwwds_23_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome), "%", "");
         lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P009L7 */
         pr_default.execute(1, new Object[] {AV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV92Propostacwwds_4_propostatitulo1, lV92Propostacwwds_4_propostatitulo1, lV93Propostacwwds_5_contratonome1, lV93Propostacwwds_5_contratonome1, lV97Propostacwwds_9_propostatitulo2, lV97Propostacwwds_9_propostatitulo2, lV98Propostacwwds_10_contratonome2, lV98Propostacwwds_10_contratonome2, lV102Propostacwwds_14_propostatitulo3, lV102Propostacwwds_14_propostatitulo3, lV103Propostacwwds_15_contratonome3, lV103Propostacwwds_15_contratonome3, lV104Propostacwwds_16_tfprocedimentosmedicosnome, AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, lV106Propostacwwds_18_tfpropostadescricao, AV107Propostacwwds_19_tfpropostadescricao_sel, AV108Propostacwwds_20_tfpropostavalor, AV109Propostacwwds_21_tfpropostavalor_to, lV111Propostacwwds_23_tfcontratonome, AV112Propostacwwds_24_tfcontratonome_sel, AV113Propostacwwds_25_tfpropostaquantidadeaprovadores, AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to, lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial, AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9L4 = false;
            A227ContratoId = P009L7_A227ContratoId[0];
            n227ContratoId = P009L7_n227ContratoId[0];
            A376ProcedimentosMedicosId = P009L7_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P009L7_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P009L7_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009L7_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P009L7_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P009L7_n504PropostaPacienteClienteId[0];
            A323PropostaId = P009L7_A323PropostaId[0];
            n323PropostaId = P009L7_n323PropostaId[0];
            A325PropostaDescricao = P009L7_A325PropostaDescricao[0];
            n325PropostaDescricao = P009L7_n325PropostaDescricao[0];
            A210SecUserClienteId = P009L7_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L7_n210SecUserClienteId[0];
            A642PropostaClinicaId = P009L7_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P009L7_n642PropostaClinicaId[0];
            A330PropostaQuantidadeAprovadores = P009L7_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = P009L7_n330PropostaQuantidadeAprovadores[0];
            A326PropostaValor = P009L7_A326PropostaValor[0];
            n326PropostaValor = P009L7_n326PropostaValor[0];
            A324PropostaTitulo = P009L7_A324PropostaTitulo[0];
            n324PropostaTitulo = P009L7_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P009L7_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L7_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P009L7_A228ContratoNome[0];
            n228ContratoNome = P009L7_n228ContratoNome[0];
            A329PropostaStatus = P009L7_A329PropostaStatus[0];
            n329PropostaStatus = P009L7_n329PropostaStatus[0];
            A377ProcedimentosMedicosNome = P009L7_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L7_n377ProcedimentosMedicosNome[0];
            A342PropostaReprovacoes_F = P009L7_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L7_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L7_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L7_n341PropostaAprovacoes_F[0];
            A228ContratoNome = P009L7_A228ContratoNome[0];
            n228ContratoNome = P009L7_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P009L7_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L7_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P009L7_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L7_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P009L7_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L7_n505PropostaPacienteClienteRazaoSocial[0];
            A342PropostaReprovacoes_F = P009L7_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L7_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L7_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L7_n341PropostaAprovacoes_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P009L7_A325PropostaDescricao[0], A325PropostaDescricao) == 0 ) )
            {
               BRK9L4 = false;
               A323PropostaId = P009L7_A323PropostaId[0];
               n323PropostaId = P009L7_n323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRK9L4 = true;
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
            if ( ! BRK9L4 )
            {
               BRK9L4 = true;
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
         AV89Propostacwwds_1_filterfulltext = AV50FilterFullText;
         AV90Propostacwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV91Propostacwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV92Propostacwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV93Propostacwwds_5_contratonome1 = AV76ContratoNome1;
         AV94Propostacwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV95Propostacwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV96Propostacwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV97Propostacwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV98Propostacwwds_10_contratonome2 = AV77ContratoNome2;
         AV99Propostacwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV100Propostacwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV101Propostacwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV102Propostacwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV103Propostacwwds_15_contratonome3 = AV78ContratoNome3;
         AV104Propostacwwds_16_tfprocedimentosmedicosnome = AV81TFProcedimentosMedicosNome;
         AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel = AV82TFProcedimentosMedicosNome_Sel;
         AV106Propostacwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV107Propostacwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV108Propostacwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV109Propostacwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV110Propostacwwds_22_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         AV111Propostacwwds_23_tfcontratonome = AV62TFContratoNome;
         AV112Propostacwwds_24_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV113Propostacwwds_25_tfpropostaquantidadeaprovadores = AV26TFPropostaQuantidadeAprovadores;
         AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to = AV27TFPropostaQuantidadeAprovadores_To;
         AV115Propostacwwds_27_tfpropostaaprovacoes_f = AV72TFPropostaAprovacoes_F;
         AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = AV73TFPropostaAprovacoes_F_To;
         AV117Propostacwwds_29_tfpropostareprovacoes_f = AV74TFPropostaReprovacoes_F;
         AV118Propostacwwds_30_tfpropostareprovacoes_f_to = AV75TFPropostaReprovacoes_F_To;
         AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = AV85TFPropostaPacienteClienteRazaoSocial;
         AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = AV86TFPropostaPacienteClienteRazaoSocial_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels ,
                                              AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                              AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                              AV92Propostacwwds_4_propostatitulo1 ,
                                              AV93Propostacwwds_5_contratonome1 ,
                                              AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                              AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                              AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                              AV97Propostacwwds_9_propostatitulo2 ,
                                              AV98Propostacwwds_10_contratonome2 ,
                                              AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                              AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                              AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                              AV102Propostacwwds_14_propostatitulo3 ,
                                              AV103Propostacwwds_15_contratonome3 ,
                                              AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                              AV106Propostacwwds_18_tfpropostadescricao ,
                                              AV108Propostacwwds_20_tfpropostavalor ,
                                              AV109Propostacwwds_21_tfpropostavalor_to ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels.Count ,
                                              AV112Propostacwwds_24_tfcontratonome_sel ,
                                              AV111Propostacwwds_23_tfcontratonome ,
                                              AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A330PropostaQuantidadeAprovadores ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV89Propostacwwds_1_filterfulltext ,
                                              A341PropostaAprovacoes_F ,
                                              A342PropostaReprovacoes_F ,
                                              AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                              AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV104Propostacwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV106Propostacwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao), "%", "");
         lV111Propostacwwds_23_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome), "%", "");
         lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P009L10 */
         pr_default.execute(2, new Object[] {AV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV92Propostacwwds_4_propostatitulo1, lV92Propostacwwds_4_propostatitulo1, lV93Propostacwwds_5_contratonome1, lV93Propostacwwds_5_contratonome1, lV97Propostacwwds_9_propostatitulo2, lV97Propostacwwds_9_propostatitulo2, lV98Propostacwwds_10_contratonome2, lV98Propostacwwds_10_contratonome2, lV102Propostacwwds_14_propostatitulo3, lV102Propostacwwds_14_propostatitulo3, lV103Propostacwwds_15_contratonome3, lV103Propostacwwds_15_contratonome3, lV104Propostacwwds_16_tfprocedimentosmedicosnome, AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, lV106Propostacwwds_18_tfpropostadescricao, AV107Propostacwwds_19_tfpropostadescricao_sel, AV108Propostacwwds_20_tfpropostavalor, AV109Propostacwwds_21_tfpropostavalor_to, lV111Propostacwwds_23_tfcontratonome, AV112Propostacwwds_24_tfcontratonome_sel, AV113Propostacwwds_25_tfpropostaquantidadeaprovadores, AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to, lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial, AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK9L6 = false;
            A376ProcedimentosMedicosId = P009L10_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P009L10_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P009L10_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009L10_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P009L10_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P009L10_n504PropostaPacienteClienteId[0];
            A323PropostaId = P009L10_A323PropostaId[0];
            n323PropostaId = P009L10_n323PropostaId[0];
            A227ContratoId = P009L10_A227ContratoId[0];
            n227ContratoId = P009L10_n227ContratoId[0];
            A210SecUserClienteId = P009L10_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L10_n210SecUserClienteId[0];
            A642PropostaClinicaId = P009L10_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P009L10_n642PropostaClinicaId[0];
            A330PropostaQuantidadeAprovadores = P009L10_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = P009L10_n330PropostaQuantidadeAprovadores[0];
            A326PropostaValor = P009L10_A326PropostaValor[0];
            n326PropostaValor = P009L10_n326PropostaValor[0];
            A324PropostaTitulo = P009L10_A324PropostaTitulo[0];
            n324PropostaTitulo = P009L10_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P009L10_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L10_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P009L10_A228ContratoNome[0];
            n228ContratoNome = P009L10_n228ContratoNome[0];
            A329PropostaStatus = P009L10_A329PropostaStatus[0];
            n329PropostaStatus = P009L10_n329PropostaStatus[0];
            A325PropostaDescricao = P009L10_A325PropostaDescricao[0];
            n325PropostaDescricao = P009L10_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P009L10_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L10_n377ProcedimentosMedicosNome[0];
            A342PropostaReprovacoes_F = P009L10_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L10_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L10_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L10_n341PropostaAprovacoes_F[0];
            A377ProcedimentosMedicosNome = P009L10_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L10_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P009L10_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L10_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P009L10_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L10_n505PropostaPacienteClienteRazaoSocial[0];
            A342PropostaReprovacoes_F = P009L10_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L10_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L10_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L10_n341PropostaAprovacoes_F[0];
            A228ContratoNome = P009L10_A228ContratoNome[0];
            n228ContratoNome = P009L10_n228ContratoNome[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P009L10_A227ContratoId[0] == A227ContratoId ) )
            {
               BRK9L6 = false;
               A323PropostaId = P009L10_A323PropostaId[0];
               n323PropostaId = P009L10_n323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRK9L6 = true;
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
            if ( ! BRK9L6 )
            {
               BRK9L6 = true;
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
         AV85TFPropostaPacienteClienteRazaoSocial = AV28SearchTxt;
         AV86TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV89Propostacwwds_1_filterfulltext = AV50FilterFullText;
         AV90Propostacwwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV91Propostacwwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV92Propostacwwds_4_propostatitulo1 = AV53PropostaTitulo1;
         AV93Propostacwwds_5_contratonome1 = AV76ContratoNome1;
         AV94Propostacwwds_6_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV95Propostacwwds_7_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV96Propostacwwds_8_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV97Propostacwwds_9_propostatitulo2 = AV57PropostaTitulo2;
         AV98Propostacwwds_10_contratonome2 = AV77ContratoNome2;
         AV99Propostacwwds_11_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV100Propostacwwds_12_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV101Propostacwwds_13_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV102Propostacwwds_14_propostatitulo3 = AV61PropostaTitulo3;
         AV103Propostacwwds_15_contratonome3 = AV78ContratoNome3;
         AV104Propostacwwds_16_tfprocedimentosmedicosnome = AV81TFProcedimentosMedicosNome;
         AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel = AV82TFProcedimentosMedicosNome_Sel;
         AV106Propostacwwds_18_tfpropostadescricao = AV14TFPropostaDescricao;
         AV107Propostacwwds_19_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV108Propostacwwds_20_tfpropostavalor = AV16TFPropostaValor;
         AV109Propostacwwds_21_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV110Propostacwwds_22_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         AV111Propostacwwds_23_tfcontratonome = AV62TFContratoNome;
         AV112Propostacwwds_24_tfcontratonome_sel = AV63TFContratoNome_Sel;
         AV113Propostacwwds_25_tfpropostaquantidadeaprovadores = AV26TFPropostaQuantidadeAprovadores;
         AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to = AV27TFPropostaQuantidadeAprovadores_To;
         AV115Propostacwwds_27_tfpropostaaprovacoes_f = AV72TFPropostaAprovacoes_F;
         AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = AV73TFPropostaAprovacoes_F_To;
         AV117Propostacwwds_29_tfpropostareprovacoes_f = AV74TFPropostaReprovacoes_F;
         AV118Propostacwwds_30_tfpropostareprovacoes_f_to = AV75TFPropostaReprovacoes_F_To;
         AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = AV85TFPropostaPacienteClienteRazaoSocial;
         AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = AV86TFPropostaPacienteClienteRazaoSocial_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels ,
                                              AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                              AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                              AV92Propostacwwds_4_propostatitulo1 ,
                                              AV93Propostacwwds_5_contratonome1 ,
                                              AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                              AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                              AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                              AV97Propostacwwds_9_propostatitulo2 ,
                                              AV98Propostacwwds_10_contratonome2 ,
                                              AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                              AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                              AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                              AV102Propostacwwds_14_propostatitulo3 ,
                                              AV103Propostacwwds_15_contratonome3 ,
                                              AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                              AV106Propostacwwds_18_tfpropostadescricao ,
                                              AV108Propostacwwds_20_tfpropostavalor ,
                                              AV109Propostacwwds_21_tfpropostavalor_to ,
                                              AV110Propostacwwds_22_tfpropostastatus_sels.Count ,
                                              AV112Propostacwwds_24_tfcontratonome_sel ,
                                              AV111Propostacwwds_23_tfcontratonome ,
                                              AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A330PropostaQuantidadeAprovadores ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV89Propostacwwds_1_filterfulltext ,
                                              A341PropostaAprovacoes_F ,
                                              A342PropostaReprovacoes_F ,
                                              AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                              AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV89Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV89Propostacwwds_1_filterfulltext), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV92Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV93Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV93Propostacwwds_5_contratonome1), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV97Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV98Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Propostacwwds_10_contratonome2), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV102Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV103Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV103Propostacwwds_15_contratonome3), "%", "");
         lV104Propostacwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV106Propostacwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao), "%", "");
         lV111Propostacwwds_23_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome), "%", "");
         lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P009L13 */
         pr_default.execute(3, new Object[] {AV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, lV89Propostacwwds_1_filterfulltext, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV115Propostacwwds_27_tfpropostaaprovacoes_f, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV116Propostacwwds_28_tfpropostaaprovacoes_f_to, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV117Propostacwwds_29_tfpropostareprovacoes_f, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, AV118Propostacwwds_30_tfpropostareprovacoes_f_to, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV92Propostacwwds_4_propostatitulo1, lV92Propostacwwds_4_propostatitulo1, lV93Propostacwwds_5_contratonome1, lV93Propostacwwds_5_contratonome1, lV97Propostacwwds_9_propostatitulo2, lV97Propostacwwds_9_propostatitulo2, lV98Propostacwwds_10_contratonome2, lV98Propostacwwds_10_contratonome2, lV102Propostacwwds_14_propostatitulo3, lV102Propostacwwds_14_propostatitulo3, lV103Propostacwwds_15_contratonome3, lV103Propostacwwds_15_contratonome3, lV104Propostacwwds_16_tfprocedimentosmedicosnome, AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, lV106Propostacwwds_18_tfpropostadescricao, AV107Propostacwwds_19_tfpropostadescricao_sel, AV108Propostacwwds_20_tfpropostavalor, AV109Propostacwwds_21_tfpropostavalor_to, lV111Propostacwwds_23_tfcontratonome, AV112Propostacwwds_24_tfcontratonome_sel, AV113Propostacwwds_25_tfpropostaquantidadeaprovadores, AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to, lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial, AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK9L8 = false;
            A227ContratoId = P009L13_A227ContratoId[0];
            n227ContratoId = P009L13_n227ContratoId[0];
            A376ProcedimentosMedicosId = P009L13_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P009L13_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P009L13_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009L13_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P009L13_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P009L13_n504PropostaPacienteClienteId[0];
            A323PropostaId = P009L13_A323PropostaId[0];
            n323PropostaId = P009L13_n323PropostaId[0];
            A505PropostaPacienteClienteRazaoSocial = P009L13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L13_n505PropostaPacienteClienteRazaoSocial[0];
            A210SecUserClienteId = P009L13_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L13_n210SecUserClienteId[0];
            A642PropostaClinicaId = P009L13_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P009L13_n642PropostaClinicaId[0];
            A330PropostaQuantidadeAprovadores = P009L13_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = P009L13_n330PropostaQuantidadeAprovadores[0];
            A326PropostaValor = P009L13_A326PropostaValor[0];
            n326PropostaValor = P009L13_n326PropostaValor[0];
            A324PropostaTitulo = P009L13_A324PropostaTitulo[0];
            n324PropostaTitulo = P009L13_n324PropostaTitulo[0];
            A228ContratoNome = P009L13_A228ContratoNome[0];
            n228ContratoNome = P009L13_n228ContratoNome[0];
            A329PropostaStatus = P009L13_A329PropostaStatus[0];
            n329PropostaStatus = P009L13_n329PropostaStatus[0];
            A325PropostaDescricao = P009L13_A325PropostaDescricao[0];
            n325PropostaDescricao = P009L13_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P009L13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L13_n377ProcedimentosMedicosNome[0];
            A342PropostaReprovacoes_F = P009L13_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L13_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L13_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L13_n341PropostaAprovacoes_F[0];
            A228ContratoNome = P009L13_A228ContratoNome[0];
            n228ContratoNome = P009L13_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P009L13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009L13_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P009L13_A210SecUserClienteId[0];
            n210SecUserClienteId = P009L13_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P009L13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009L13_n505PropostaPacienteClienteRazaoSocial[0];
            A342PropostaReprovacoes_F = P009L13_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009L13_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009L13_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009L13_n341PropostaAprovacoes_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P009L13_A505PropostaPacienteClienteRazaoSocial[0], A505PropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRK9L8 = false;
               A504PropostaPacienteClienteId = P009L13_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = P009L13_n504PropostaPacienteClienteId[0];
               A323PropostaId = P009L13_A323PropostaId[0];
               n323PropostaId = P009L13_n323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRK9L8 = true;
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
            if ( ! BRK9L8 )
            {
               BRK9L8 = true;
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
         AV81TFProcedimentosMedicosNome = "";
         AV82TFProcedimentosMedicosNome_Sel = "";
         AV14TFPropostaDescricao = "";
         AV15TFPropostaDescricao_Sel = "";
         AV22TFPropostaStatus_SelsJson = "";
         AV23TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV62TFContratoNome = "";
         AV63TFContratoNome_Sel = "";
         AV85TFPropostaPacienteClienteRazaoSocial = "";
         AV86TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV51DynamicFiltersSelector1 = "";
         AV53PropostaTitulo1 = "";
         AV76ContratoNome1 = "";
         AV55DynamicFiltersSelector2 = "";
         AV57PropostaTitulo2 = "";
         AV77ContratoNome2 = "";
         AV59DynamicFiltersSelector3 = "";
         AV61PropostaTitulo3 = "";
         AV78ContratoNome3 = "";
         AV89Propostacwwds_1_filterfulltext = "";
         AV90Propostacwwds_2_dynamicfiltersselector1 = "";
         AV92Propostacwwds_4_propostatitulo1 = "";
         AV93Propostacwwds_5_contratonome1 = "";
         AV95Propostacwwds_7_dynamicfiltersselector2 = "";
         AV97Propostacwwds_9_propostatitulo2 = "";
         AV98Propostacwwds_10_contratonome2 = "";
         AV100Propostacwwds_12_dynamicfiltersselector3 = "";
         AV102Propostacwwds_14_propostatitulo3 = "";
         AV103Propostacwwds_15_contratonome3 = "";
         AV104Propostacwwds_16_tfprocedimentosmedicosnome = "";
         AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel = "";
         AV106Propostacwwds_18_tfpropostadescricao = "";
         AV107Propostacwwds_19_tfpropostadescricao_sel = "";
         AV110Propostacwwds_22_tfpropostastatus_sels = new GxSimpleCollection<string>();
         AV111Propostacwwds_23_tfcontratonome = "";
         AV112Propostacwwds_24_tfcontratonome_sel = "";
         AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = "";
         AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = "";
         lV89Propostacwwds_1_filterfulltext = "";
         lV92Propostacwwds_4_propostatitulo1 = "";
         lV93Propostacwwds_5_contratonome1 = "";
         lV97Propostacwwds_9_propostatitulo2 = "";
         lV98Propostacwwds_10_contratonome2 = "";
         lV102Propostacwwds_14_propostatitulo3 = "";
         lV103Propostacwwds_15_contratonome3 = "";
         lV104Propostacwwds_16_tfprocedimentosmedicosnome = "";
         lV106Propostacwwds_18_tfpropostadescricao = "";
         lV111Propostacwwds_23_tfcontratonome = "";
         lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial = "";
         A329PropostaStatus = "";
         A324PropostaTitulo = "";
         A228ContratoNome = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         P009L4_A227ContratoId = new int[1] ;
         P009L4_n227ContratoId = new bool[] {false} ;
         P009L4_A376ProcedimentosMedicosId = new int[1] ;
         P009L4_n376ProcedimentosMedicosId = new bool[] {false} ;
         P009L4_A328PropostaCratedBy = new short[1] ;
         P009L4_n328PropostaCratedBy = new bool[] {false} ;
         P009L4_A504PropostaPacienteClienteId = new int[1] ;
         P009L4_n504PropostaPacienteClienteId = new bool[] {false} ;
         P009L4_A323PropostaId = new int[1] ;
         P009L4_n323PropostaId = new bool[] {false} ;
         P009L4_A377ProcedimentosMedicosNome = new string[] {""} ;
         P009L4_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P009L4_A210SecUserClienteId = new short[1] ;
         P009L4_n210SecUserClienteId = new bool[] {false} ;
         P009L4_A642PropostaClinicaId = new int[1] ;
         P009L4_n642PropostaClinicaId = new bool[] {false} ;
         P009L4_A330PropostaQuantidadeAprovadores = new short[1] ;
         P009L4_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         P009L4_A326PropostaValor = new decimal[1] ;
         P009L4_n326PropostaValor = new bool[] {false} ;
         P009L4_A324PropostaTitulo = new string[] {""} ;
         P009L4_n324PropostaTitulo = new bool[] {false} ;
         P009L4_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P009L4_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P009L4_A228ContratoNome = new string[] {""} ;
         P009L4_n228ContratoNome = new bool[] {false} ;
         P009L4_A329PropostaStatus = new string[] {""} ;
         P009L4_n329PropostaStatus = new bool[] {false} ;
         P009L4_A325PropostaDescricao = new string[] {""} ;
         P009L4_n325PropostaDescricao = new bool[] {false} ;
         P009L4_A342PropostaReprovacoes_F = new short[1] ;
         P009L4_n342PropostaReprovacoes_F = new bool[] {false} ;
         P009L4_A341PropostaAprovacoes_F = new short[1] ;
         P009L4_n341PropostaAprovacoes_F = new bool[] {false} ;
         AV33Option = "";
         P009L7_A227ContratoId = new int[1] ;
         P009L7_n227ContratoId = new bool[] {false} ;
         P009L7_A376ProcedimentosMedicosId = new int[1] ;
         P009L7_n376ProcedimentosMedicosId = new bool[] {false} ;
         P009L7_A328PropostaCratedBy = new short[1] ;
         P009L7_n328PropostaCratedBy = new bool[] {false} ;
         P009L7_A504PropostaPacienteClienteId = new int[1] ;
         P009L7_n504PropostaPacienteClienteId = new bool[] {false} ;
         P009L7_A323PropostaId = new int[1] ;
         P009L7_n323PropostaId = new bool[] {false} ;
         P009L7_A325PropostaDescricao = new string[] {""} ;
         P009L7_n325PropostaDescricao = new bool[] {false} ;
         P009L7_A210SecUserClienteId = new short[1] ;
         P009L7_n210SecUserClienteId = new bool[] {false} ;
         P009L7_A642PropostaClinicaId = new int[1] ;
         P009L7_n642PropostaClinicaId = new bool[] {false} ;
         P009L7_A330PropostaQuantidadeAprovadores = new short[1] ;
         P009L7_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         P009L7_A326PropostaValor = new decimal[1] ;
         P009L7_n326PropostaValor = new bool[] {false} ;
         P009L7_A324PropostaTitulo = new string[] {""} ;
         P009L7_n324PropostaTitulo = new bool[] {false} ;
         P009L7_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P009L7_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P009L7_A228ContratoNome = new string[] {""} ;
         P009L7_n228ContratoNome = new bool[] {false} ;
         P009L7_A329PropostaStatus = new string[] {""} ;
         P009L7_n329PropostaStatus = new bool[] {false} ;
         P009L7_A377ProcedimentosMedicosNome = new string[] {""} ;
         P009L7_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P009L7_A342PropostaReprovacoes_F = new short[1] ;
         P009L7_n342PropostaReprovacoes_F = new bool[] {false} ;
         P009L7_A341PropostaAprovacoes_F = new short[1] ;
         P009L7_n341PropostaAprovacoes_F = new bool[] {false} ;
         P009L10_A376ProcedimentosMedicosId = new int[1] ;
         P009L10_n376ProcedimentosMedicosId = new bool[] {false} ;
         P009L10_A328PropostaCratedBy = new short[1] ;
         P009L10_n328PropostaCratedBy = new bool[] {false} ;
         P009L10_A504PropostaPacienteClienteId = new int[1] ;
         P009L10_n504PropostaPacienteClienteId = new bool[] {false} ;
         P009L10_A323PropostaId = new int[1] ;
         P009L10_n323PropostaId = new bool[] {false} ;
         P009L10_A227ContratoId = new int[1] ;
         P009L10_n227ContratoId = new bool[] {false} ;
         P009L10_A210SecUserClienteId = new short[1] ;
         P009L10_n210SecUserClienteId = new bool[] {false} ;
         P009L10_A642PropostaClinicaId = new int[1] ;
         P009L10_n642PropostaClinicaId = new bool[] {false} ;
         P009L10_A330PropostaQuantidadeAprovadores = new short[1] ;
         P009L10_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         P009L10_A326PropostaValor = new decimal[1] ;
         P009L10_n326PropostaValor = new bool[] {false} ;
         P009L10_A324PropostaTitulo = new string[] {""} ;
         P009L10_n324PropostaTitulo = new bool[] {false} ;
         P009L10_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P009L10_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P009L10_A228ContratoNome = new string[] {""} ;
         P009L10_n228ContratoNome = new bool[] {false} ;
         P009L10_A329PropostaStatus = new string[] {""} ;
         P009L10_n329PropostaStatus = new bool[] {false} ;
         P009L10_A325PropostaDescricao = new string[] {""} ;
         P009L10_n325PropostaDescricao = new bool[] {false} ;
         P009L10_A377ProcedimentosMedicosNome = new string[] {""} ;
         P009L10_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P009L10_A342PropostaReprovacoes_F = new short[1] ;
         P009L10_n342PropostaReprovacoes_F = new bool[] {false} ;
         P009L10_A341PropostaAprovacoes_F = new short[1] ;
         P009L10_n341PropostaAprovacoes_F = new bool[] {false} ;
         P009L13_A227ContratoId = new int[1] ;
         P009L13_n227ContratoId = new bool[] {false} ;
         P009L13_A376ProcedimentosMedicosId = new int[1] ;
         P009L13_n376ProcedimentosMedicosId = new bool[] {false} ;
         P009L13_A328PropostaCratedBy = new short[1] ;
         P009L13_n328PropostaCratedBy = new bool[] {false} ;
         P009L13_A504PropostaPacienteClienteId = new int[1] ;
         P009L13_n504PropostaPacienteClienteId = new bool[] {false} ;
         P009L13_A323PropostaId = new int[1] ;
         P009L13_n323PropostaId = new bool[] {false} ;
         P009L13_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P009L13_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P009L13_A210SecUserClienteId = new short[1] ;
         P009L13_n210SecUserClienteId = new bool[] {false} ;
         P009L13_A642PropostaClinicaId = new int[1] ;
         P009L13_n642PropostaClinicaId = new bool[] {false} ;
         P009L13_A330PropostaQuantidadeAprovadores = new short[1] ;
         P009L13_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         P009L13_A326PropostaValor = new decimal[1] ;
         P009L13_n326PropostaValor = new bool[] {false} ;
         P009L13_A324PropostaTitulo = new string[] {""} ;
         P009L13_n324PropostaTitulo = new bool[] {false} ;
         P009L13_A228ContratoNome = new string[] {""} ;
         P009L13_n228ContratoNome = new bool[] {false} ;
         P009L13_A329PropostaStatus = new string[] {""} ;
         P009L13_n329PropostaStatus = new bool[] {false} ;
         P009L13_A325PropostaDescricao = new string[] {""} ;
         P009L13_n325PropostaDescricao = new bool[] {false} ;
         P009L13_A377ProcedimentosMedicosNome = new string[] {""} ;
         P009L13_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P009L13_A342PropostaReprovacoes_F = new short[1] ;
         P009L13_n342PropostaReprovacoes_F = new bool[] {false} ;
         P009L13_A341PropostaAprovacoes_F = new short[1] ;
         P009L13_n341PropostaAprovacoes_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009L4_A227ContratoId, P009L4_n227ContratoId, P009L4_A376ProcedimentosMedicosId, P009L4_n376ProcedimentosMedicosId, P009L4_A328PropostaCratedBy, P009L4_n328PropostaCratedBy, P009L4_A504PropostaPacienteClienteId, P009L4_n504PropostaPacienteClienteId, P009L4_A323PropostaId, P009L4_A377ProcedimentosMedicosNome,
               P009L4_n377ProcedimentosMedicosNome, P009L4_A210SecUserClienteId, P009L4_n210SecUserClienteId, P009L4_A642PropostaClinicaId, P009L4_n642PropostaClinicaId, P009L4_A330PropostaQuantidadeAprovadores, P009L4_n330PropostaQuantidadeAprovadores, P009L4_A326PropostaValor, P009L4_n326PropostaValor, P009L4_A324PropostaTitulo,
               P009L4_n324PropostaTitulo, P009L4_A505PropostaPacienteClienteRazaoSocial, P009L4_n505PropostaPacienteClienteRazaoSocial, P009L4_A228ContratoNome, P009L4_n228ContratoNome, P009L4_A329PropostaStatus, P009L4_n329PropostaStatus, P009L4_A325PropostaDescricao, P009L4_n325PropostaDescricao, P009L4_A342PropostaReprovacoes_F,
               P009L4_n342PropostaReprovacoes_F, P009L4_A341PropostaAprovacoes_F, P009L4_n341PropostaAprovacoes_F
               }
               , new Object[] {
               P009L7_A227ContratoId, P009L7_n227ContratoId, P009L7_A376ProcedimentosMedicosId, P009L7_n376ProcedimentosMedicosId, P009L7_A328PropostaCratedBy, P009L7_n328PropostaCratedBy, P009L7_A504PropostaPacienteClienteId, P009L7_n504PropostaPacienteClienteId, P009L7_A323PropostaId, P009L7_A325PropostaDescricao,
               P009L7_n325PropostaDescricao, P009L7_A210SecUserClienteId, P009L7_n210SecUserClienteId, P009L7_A642PropostaClinicaId, P009L7_n642PropostaClinicaId, P009L7_A330PropostaQuantidadeAprovadores, P009L7_n330PropostaQuantidadeAprovadores, P009L7_A326PropostaValor, P009L7_n326PropostaValor, P009L7_A324PropostaTitulo,
               P009L7_n324PropostaTitulo, P009L7_A505PropostaPacienteClienteRazaoSocial, P009L7_n505PropostaPacienteClienteRazaoSocial, P009L7_A228ContratoNome, P009L7_n228ContratoNome, P009L7_A329PropostaStatus, P009L7_n329PropostaStatus, P009L7_A377ProcedimentosMedicosNome, P009L7_n377ProcedimentosMedicosNome, P009L7_A342PropostaReprovacoes_F,
               P009L7_n342PropostaReprovacoes_F, P009L7_A341PropostaAprovacoes_F, P009L7_n341PropostaAprovacoes_F
               }
               , new Object[] {
               P009L10_A376ProcedimentosMedicosId, P009L10_n376ProcedimentosMedicosId, P009L10_A328PropostaCratedBy, P009L10_n328PropostaCratedBy, P009L10_A504PropostaPacienteClienteId, P009L10_n504PropostaPacienteClienteId, P009L10_A323PropostaId, P009L10_A227ContratoId, P009L10_n227ContratoId, P009L10_A210SecUserClienteId,
               P009L10_n210SecUserClienteId, P009L10_A642PropostaClinicaId, P009L10_n642PropostaClinicaId, P009L10_A330PropostaQuantidadeAprovadores, P009L10_n330PropostaQuantidadeAprovadores, P009L10_A326PropostaValor, P009L10_n326PropostaValor, P009L10_A324PropostaTitulo, P009L10_n324PropostaTitulo, P009L10_A505PropostaPacienteClienteRazaoSocial,
               P009L10_n505PropostaPacienteClienteRazaoSocial, P009L10_A228ContratoNome, P009L10_n228ContratoNome, P009L10_A329PropostaStatus, P009L10_n329PropostaStatus, P009L10_A325PropostaDescricao, P009L10_n325PropostaDescricao, P009L10_A377ProcedimentosMedicosNome, P009L10_n377ProcedimentosMedicosNome, P009L10_A342PropostaReprovacoes_F,
               P009L10_n342PropostaReprovacoes_F, P009L10_A341PropostaAprovacoes_F, P009L10_n341PropostaAprovacoes_F
               }
               , new Object[] {
               P009L13_A227ContratoId, P009L13_n227ContratoId, P009L13_A376ProcedimentosMedicosId, P009L13_n376ProcedimentosMedicosId, P009L13_A328PropostaCratedBy, P009L13_n328PropostaCratedBy, P009L13_A504PropostaPacienteClienteId, P009L13_n504PropostaPacienteClienteId, P009L13_A323PropostaId, P009L13_A505PropostaPacienteClienteRazaoSocial,
               P009L13_n505PropostaPacienteClienteRazaoSocial, P009L13_A210SecUserClienteId, P009L13_n210SecUserClienteId, P009L13_A642PropostaClinicaId, P009L13_n642PropostaClinicaId, P009L13_A330PropostaQuantidadeAprovadores, P009L13_n330PropostaQuantidadeAprovadores, P009L13_A326PropostaValor, P009L13_n326PropostaValor, P009L13_A324PropostaTitulo,
               P009L13_n324PropostaTitulo, P009L13_A228ContratoNome, P009L13_n228ContratoNome, P009L13_A329PropostaStatus, P009L13_n329PropostaStatus, P009L13_A325PropostaDescricao, P009L13_n325PropostaDescricao, P009L13_A377ProcedimentosMedicosNome, P009L13_n377ProcedimentosMedicosNome, P009L13_A342PropostaReprovacoes_F,
               P009L13_n342PropostaReprovacoes_F, P009L13_A341PropostaAprovacoes_F, P009L13_n341PropostaAprovacoes_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private short AV26TFPropostaQuantidadeAprovadores ;
      private short AV27TFPropostaQuantidadeAprovadores_To ;
      private short AV72TFPropostaAprovacoes_F ;
      private short AV73TFPropostaAprovacoes_F_To ;
      private short AV74TFPropostaReprovacoes_F ;
      private short AV75TFPropostaReprovacoes_F_To ;
      private short AV52DynamicFiltersOperator1 ;
      private short AV56DynamicFiltersOperator2 ;
      private short AV60DynamicFiltersOperator3 ;
      private short AV91Propostacwwds_3_dynamicfiltersoperator1 ;
      private short AV96Propostacwwds_8_dynamicfiltersoperator2 ;
      private short AV101Propostacwwds_13_dynamicfiltersoperator3 ;
      private short AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ;
      private short AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ;
      private short AV115Propostacwwds_27_tfpropostaaprovacoes_f ;
      private short AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ;
      private short AV117Propostacwwds_29_tfpropostareprovacoes_f ;
      private short AV118Propostacwwds_30_tfpropostareprovacoes_f_to ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A330PropostaQuantidadeAprovadores ;
      private short A341PropostaAprovacoes_F ;
      private short A342PropostaReprovacoes_F ;
      private short A133SecUserId ;
      private short A210SecUserClienteId ;
      private short A328PropostaCratedBy ;
      private int AV87GXV1 ;
      private int AV110Propostacwwds_22_tfpropostastatus_sels_Count ;
      private int A642PropostaClinicaId ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int AV32InsertIndex ;
      private long AV38count ;
      private decimal AV16TFPropostaValor ;
      private decimal AV17TFPropostaValor_To ;
      private decimal AV108Propostacwwds_20_tfpropostavalor ;
      private decimal AV109Propostacwwds_21_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private bool returnInSub ;
      private bool AV54DynamicFiltersEnabled2 ;
      private bool AV58DynamicFiltersEnabled3 ;
      private bool AV94Propostacwwds_6_dynamicfiltersenabled2 ;
      private bool AV99Propostacwwds_11_dynamicfiltersenabled3 ;
      private bool BRK9L2 ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n323PropostaId ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n210SecUserClienteId ;
      private bool n642PropostaClinicaId ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n326PropostaValor ;
      private bool n324PropostaTitulo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n228ContratoNome ;
      private bool n329PropostaStatus ;
      private bool n325PropostaDescricao ;
      private bool n342PropostaReprovacoes_F ;
      private bool n341PropostaAprovacoes_F ;
      private bool BRK9L4 ;
      private bool BRK9L6 ;
      private bool BRK9L8 ;
      private string AV47OptionsJson ;
      private string AV48OptionsDescJson ;
      private string AV49OptionIndexesJson ;
      private string AV22TFPropostaStatus_SelsJson ;
      private string AV44DDOName ;
      private string AV45SearchTxtParms ;
      private string AV46SearchTxtTo ;
      private string AV28SearchTxt ;
      private string AV50FilterFullText ;
      private string AV81TFProcedimentosMedicosNome ;
      private string AV82TFProcedimentosMedicosNome_Sel ;
      private string AV14TFPropostaDescricao ;
      private string AV15TFPropostaDescricao_Sel ;
      private string AV62TFContratoNome ;
      private string AV63TFContratoNome_Sel ;
      private string AV85TFPropostaPacienteClienteRazaoSocial ;
      private string AV86TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV51DynamicFiltersSelector1 ;
      private string AV53PropostaTitulo1 ;
      private string AV76ContratoNome1 ;
      private string AV55DynamicFiltersSelector2 ;
      private string AV57PropostaTitulo2 ;
      private string AV77ContratoNome2 ;
      private string AV59DynamicFiltersSelector3 ;
      private string AV61PropostaTitulo3 ;
      private string AV78ContratoNome3 ;
      private string AV89Propostacwwds_1_filterfulltext ;
      private string AV90Propostacwwds_2_dynamicfiltersselector1 ;
      private string AV92Propostacwwds_4_propostatitulo1 ;
      private string AV93Propostacwwds_5_contratonome1 ;
      private string AV95Propostacwwds_7_dynamicfiltersselector2 ;
      private string AV97Propostacwwds_9_propostatitulo2 ;
      private string AV98Propostacwwds_10_contratonome2 ;
      private string AV100Propostacwwds_12_dynamicfiltersselector3 ;
      private string AV102Propostacwwds_14_propostatitulo3 ;
      private string AV103Propostacwwds_15_contratonome3 ;
      private string AV104Propostacwwds_16_tfprocedimentosmedicosnome ;
      private string AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ;
      private string AV106Propostacwwds_18_tfpropostadescricao ;
      private string AV107Propostacwwds_19_tfpropostadescricao_sel ;
      private string AV111Propostacwwds_23_tfcontratonome ;
      private string AV112Propostacwwds_24_tfcontratonome_sel ;
      private string AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ;
      private string AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ;
      private string lV89Propostacwwds_1_filterfulltext ;
      private string lV92Propostacwwds_4_propostatitulo1 ;
      private string lV93Propostacwwds_5_contratonome1 ;
      private string lV97Propostacwwds_9_propostatitulo2 ;
      private string lV98Propostacwwds_10_contratonome2 ;
      private string lV102Propostacwwds_14_propostatitulo3 ;
      private string lV103Propostacwwds_15_contratonome3 ;
      private string lV104Propostacwwds_16_tfprocedimentosmedicosnome ;
      private string lV106Propostacwwds_18_tfpropostadescricao ;
      private string lV111Propostacwwds_23_tfcontratonome ;
      private string lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ;
      private string A329PropostaStatus ;
      private string A324PropostaTitulo ;
      private string A228ContratoNome ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string AV33Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV34Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV37OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GxSimpleCollection<string> AV23TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV43GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV110Propostacwwds_22_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P009L4_A227ContratoId ;
      private bool[] P009L4_n227ContratoId ;
      private int[] P009L4_A376ProcedimentosMedicosId ;
      private bool[] P009L4_n376ProcedimentosMedicosId ;
      private short[] P009L4_A328PropostaCratedBy ;
      private bool[] P009L4_n328PropostaCratedBy ;
      private int[] P009L4_A504PropostaPacienteClienteId ;
      private bool[] P009L4_n504PropostaPacienteClienteId ;
      private int[] P009L4_A323PropostaId ;
      private bool[] P009L4_n323PropostaId ;
      private string[] P009L4_A377ProcedimentosMedicosNome ;
      private bool[] P009L4_n377ProcedimentosMedicosNome ;
      private short[] P009L4_A210SecUserClienteId ;
      private bool[] P009L4_n210SecUserClienteId ;
      private int[] P009L4_A642PropostaClinicaId ;
      private bool[] P009L4_n642PropostaClinicaId ;
      private short[] P009L4_A330PropostaQuantidadeAprovadores ;
      private bool[] P009L4_n330PropostaQuantidadeAprovadores ;
      private decimal[] P009L4_A326PropostaValor ;
      private bool[] P009L4_n326PropostaValor ;
      private string[] P009L4_A324PropostaTitulo ;
      private bool[] P009L4_n324PropostaTitulo ;
      private string[] P009L4_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P009L4_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P009L4_A228ContratoNome ;
      private bool[] P009L4_n228ContratoNome ;
      private string[] P009L4_A329PropostaStatus ;
      private bool[] P009L4_n329PropostaStatus ;
      private string[] P009L4_A325PropostaDescricao ;
      private bool[] P009L4_n325PropostaDescricao ;
      private short[] P009L4_A342PropostaReprovacoes_F ;
      private bool[] P009L4_n342PropostaReprovacoes_F ;
      private short[] P009L4_A341PropostaAprovacoes_F ;
      private bool[] P009L4_n341PropostaAprovacoes_F ;
      private int[] P009L7_A227ContratoId ;
      private bool[] P009L7_n227ContratoId ;
      private int[] P009L7_A376ProcedimentosMedicosId ;
      private bool[] P009L7_n376ProcedimentosMedicosId ;
      private short[] P009L7_A328PropostaCratedBy ;
      private bool[] P009L7_n328PropostaCratedBy ;
      private int[] P009L7_A504PropostaPacienteClienteId ;
      private bool[] P009L7_n504PropostaPacienteClienteId ;
      private int[] P009L7_A323PropostaId ;
      private bool[] P009L7_n323PropostaId ;
      private string[] P009L7_A325PropostaDescricao ;
      private bool[] P009L7_n325PropostaDescricao ;
      private short[] P009L7_A210SecUserClienteId ;
      private bool[] P009L7_n210SecUserClienteId ;
      private int[] P009L7_A642PropostaClinicaId ;
      private bool[] P009L7_n642PropostaClinicaId ;
      private short[] P009L7_A330PropostaQuantidadeAprovadores ;
      private bool[] P009L7_n330PropostaQuantidadeAprovadores ;
      private decimal[] P009L7_A326PropostaValor ;
      private bool[] P009L7_n326PropostaValor ;
      private string[] P009L7_A324PropostaTitulo ;
      private bool[] P009L7_n324PropostaTitulo ;
      private string[] P009L7_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P009L7_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P009L7_A228ContratoNome ;
      private bool[] P009L7_n228ContratoNome ;
      private string[] P009L7_A329PropostaStatus ;
      private bool[] P009L7_n329PropostaStatus ;
      private string[] P009L7_A377ProcedimentosMedicosNome ;
      private bool[] P009L7_n377ProcedimentosMedicosNome ;
      private short[] P009L7_A342PropostaReprovacoes_F ;
      private bool[] P009L7_n342PropostaReprovacoes_F ;
      private short[] P009L7_A341PropostaAprovacoes_F ;
      private bool[] P009L7_n341PropostaAprovacoes_F ;
      private int[] P009L10_A376ProcedimentosMedicosId ;
      private bool[] P009L10_n376ProcedimentosMedicosId ;
      private short[] P009L10_A328PropostaCratedBy ;
      private bool[] P009L10_n328PropostaCratedBy ;
      private int[] P009L10_A504PropostaPacienteClienteId ;
      private bool[] P009L10_n504PropostaPacienteClienteId ;
      private int[] P009L10_A323PropostaId ;
      private bool[] P009L10_n323PropostaId ;
      private int[] P009L10_A227ContratoId ;
      private bool[] P009L10_n227ContratoId ;
      private short[] P009L10_A210SecUserClienteId ;
      private bool[] P009L10_n210SecUserClienteId ;
      private int[] P009L10_A642PropostaClinicaId ;
      private bool[] P009L10_n642PropostaClinicaId ;
      private short[] P009L10_A330PropostaQuantidadeAprovadores ;
      private bool[] P009L10_n330PropostaQuantidadeAprovadores ;
      private decimal[] P009L10_A326PropostaValor ;
      private bool[] P009L10_n326PropostaValor ;
      private string[] P009L10_A324PropostaTitulo ;
      private bool[] P009L10_n324PropostaTitulo ;
      private string[] P009L10_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P009L10_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P009L10_A228ContratoNome ;
      private bool[] P009L10_n228ContratoNome ;
      private string[] P009L10_A329PropostaStatus ;
      private bool[] P009L10_n329PropostaStatus ;
      private string[] P009L10_A325PropostaDescricao ;
      private bool[] P009L10_n325PropostaDescricao ;
      private string[] P009L10_A377ProcedimentosMedicosNome ;
      private bool[] P009L10_n377ProcedimentosMedicosNome ;
      private short[] P009L10_A342PropostaReprovacoes_F ;
      private bool[] P009L10_n342PropostaReprovacoes_F ;
      private short[] P009L10_A341PropostaAprovacoes_F ;
      private bool[] P009L10_n341PropostaAprovacoes_F ;
      private int[] P009L13_A227ContratoId ;
      private bool[] P009L13_n227ContratoId ;
      private int[] P009L13_A376ProcedimentosMedicosId ;
      private bool[] P009L13_n376ProcedimentosMedicosId ;
      private short[] P009L13_A328PropostaCratedBy ;
      private bool[] P009L13_n328PropostaCratedBy ;
      private int[] P009L13_A504PropostaPacienteClienteId ;
      private bool[] P009L13_n504PropostaPacienteClienteId ;
      private int[] P009L13_A323PropostaId ;
      private bool[] P009L13_n323PropostaId ;
      private string[] P009L13_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P009L13_n505PropostaPacienteClienteRazaoSocial ;
      private short[] P009L13_A210SecUserClienteId ;
      private bool[] P009L13_n210SecUserClienteId ;
      private int[] P009L13_A642PropostaClinicaId ;
      private bool[] P009L13_n642PropostaClinicaId ;
      private short[] P009L13_A330PropostaQuantidadeAprovadores ;
      private bool[] P009L13_n330PropostaQuantidadeAprovadores ;
      private decimal[] P009L13_A326PropostaValor ;
      private bool[] P009L13_n326PropostaValor ;
      private string[] P009L13_A324PropostaTitulo ;
      private bool[] P009L13_n324PropostaTitulo ;
      private string[] P009L13_A228ContratoNome ;
      private bool[] P009L13_n228ContratoNome ;
      private string[] P009L13_A329PropostaStatus ;
      private bool[] P009L13_n329PropostaStatus ;
      private string[] P009L13_A325PropostaDescricao ;
      private bool[] P009L13_n325PropostaDescricao ;
      private string[] P009L13_A377ProcedimentosMedicosNome ;
      private bool[] P009L13_n377ProcedimentosMedicosNome ;
      private short[] P009L13_A342PropostaReprovacoes_F ;
      private bool[] P009L13_n342PropostaReprovacoes_F ;
      private short[] P009L13_A341PropostaAprovacoes_F ;
      private bool[] P009L13_n341PropostaAprovacoes_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class propostacwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009L4( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV110Propostacwwds_22_tfpropostastatus_sels ,
                                             string AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                             short AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                             string AV92Propostacwwds_4_propostatitulo1 ,
                                             string AV93Propostacwwds_5_contratonome1 ,
                                             bool AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                             string AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                             short AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                             string AV97Propostacwwds_9_propostatitulo2 ,
                                             string AV98Propostacwwds_10_contratonome2 ,
                                             bool AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                             string AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                             short AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                             string AV102Propostacwwds_14_propostatitulo3 ,
                                             string AV103Propostacwwds_15_contratonome3 ,
                                             string AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                             string AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                             string AV106Propostacwwds_18_tfpropostadescricao ,
                                             decimal AV108Propostacwwds_20_tfpropostavalor ,
                                             decimal AV109Propostacwwds_21_tfpropostavalor_to ,
                                             int AV110Propostacwwds_22_tfpropostastatus_sels_Count ,
                                             string AV112Propostacwwds_24_tfcontratonome_sel ,
                                             string AV111Propostacwwds_23_tfcontratonome ,
                                             short AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                             short AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                             string AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             short A330PropostaQuantidadeAprovadores ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string AV89Propostacwwds_1_filterfulltext ,
                                             short A341PropostaAprovacoes_F ,
                                             short A342PropostaReprovacoes_F ,
                                             short AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                             short AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                             short AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                             short AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                             int A642PropostaClinicaId ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             short A133SecUserId ,
                                             short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[51];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T3.ProcedimentosMedicosNome, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaQuantidadeAprovadores, T1.PropostaValor, T1.PropostaTitulo, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaStatus, T1.PropostaDescricao, COALESCE( T6.PropostaReprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T7.PropostaReprovacoes_F, 0) AS PropostaAprovacoes_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T7 ON T7.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV89Propostacwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T2.ContratoNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaQuantidadeAprovadores,'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV89Propostacwwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV115Propostacwwds_27_tfpropostaaprovacoes_f = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) >= :AV115Propostacwwds_27_tfpropostaaprovacoes_f))");
         AddWhere(sWhereString, "((:AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) <= :AV116Propostacwwds_28_tfpropostaaprovacoes_f_to))");
         AddWhere(sWhereString, "((:AV117Propostacwwds_29_tfpropostareprovacoes_f = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) >= :AV117Propostacwwds_29_tfpropostareprovacoes_f))");
         AddWhere(sWhereString, "((:AV118Propostacwwds_30_tfpropostareprovacoes_f_to = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) <= :AV118Propostacwwds_30_tfpropostareprovacoes_f_to))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_1Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV104Propostacwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV106Propostacwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV107Propostacwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV108Propostacwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV108Propostacwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV109Propostacwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV109Propostacwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( AV110Propostacwwds_22_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV110Propostacwwds_22_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV111Propostacwwds_23_tfcontratonome)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV112Propostacwwds_24_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (0==AV113Propostacwwds_25_tfpropostaquantidadeaprovadores) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores >= :AV113Propostacwwds_25_tfpropostaquantidadeaprovadores)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( ! (0==AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores <= :AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009L7( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV110Propostacwwds_22_tfpropostastatus_sels ,
                                             string AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                             short AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                             string AV92Propostacwwds_4_propostatitulo1 ,
                                             string AV93Propostacwwds_5_contratonome1 ,
                                             bool AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                             string AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                             short AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                             string AV97Propostacwwds_9_propostatitulo2 ,
                                             string AV98Propostacwwds_10_contratonome2 ,
                                             bool AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                             string AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                             short AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                             string AV102Propostacwwds_14_propostatitulo3 ,
                                             string AV103Propostacwwds_15_contratonome3 ,
                                             string AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                             string AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                             string AV106Propostacwwds_18_tfpropostadescricao ,
                                             decimal AV108Propostacwwds_20_tfpropostavalor ,
                                             decimal AV109Propostacwwds_21_tfpropostavalor_to ,
                                             int AV110Propostacwwds_22_tfpropostastatus_sels_Count ,
                                             string AV112Propostacwwds_24_tfcontratonome_sel ,
                                             string AV111Propostacwwds_23_tfcontratonome ,
                                             short AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                             short AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                             string AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             short A330PropostaQuantidadeAprovadores ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string AV89Propostacwwds_1_filterfulltext ,
                                             short A341PropostaAprovacoes_F ,
                                             short A342PropostaReprovacoes_F ,
                                             short AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                             short AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                             short AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                             short AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                             int A642PropostaClinicaId ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             short A133SecUserId ,
                                             short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[51];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T1.PropostaDescricao, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaQuantidadeAprovadores, T1.PropostaValor, T1.PropostaTitulo, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaStatus, T3.ProcedimentosMedicosNome, COALESCE( T6.PropostaReprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T7.PropostaReprovacoes_F, 0) AS PropostaAprovacoes_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T7 ON T7.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV89Propostacwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T2.ContratoNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaQuantidadeAprovadores,'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV89Propostacwwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV115Propostacwwds_27_tfpropostaaprovacoes_f = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) >= :AV115Propostacwwds_27_tfpropostaaprovacoes_f))");
         AddWhere(sWhereString, "((:AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) <= :AV116Propostacwwds_28_tfpropostaaprovacoes_f_to))");
         AddWhere(sWhereString, "((:AV117Propostacwwds_29_tfpropostareprovacoes_f = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) >= :AV117Propostacwwds_29_tfpropostareprovacoes_f))");
         AddWhere(sWhereString, "((:AV118Propostacwwds_30_tfpropostareprovacoes_f_to = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) <= :AV118Propostacwwds_30_tfpropostareprovacoes_f_to))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_1Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV104Propostacwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV106Propostacwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV107Propostacwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV108Propostacwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV108Propostacwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV109Propostacwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV109Propostacwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV110Propostacwwds_22_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV110Propostacwwds_22_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV111Propostacwwds_23_tfcontratonome)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV112Propostacwwds_24_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (0==AV113Propostacwwds_25_tfpropostaquantidadeaprovadores) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores >= :AV113Propostacwwds_25_tfpropostaquantidadeaprovadores)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (0==AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores <= :AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P009L10( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV110Propostacwwds_22_tfpropostastatus_sels ,
                                              string AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                              short AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                              string AV92Propostacwwds_4_propostatitulo1 ,
                                              string AV93Propostacwwds_5_contratonome1 ,
                                              bool AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                              string AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                              short AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                              string AV97Propostacwwds_9_propostatitulo2 ,
                                              string AV98Propostacwwds_10_contratonome2 ,
                                              bool AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                              string AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                              short AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                              string AV102Propostacwwds_14_propostatitulo3 ,
                                              string AV103Propostacwwds_15_contratonome3 ,
                                              string AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              string AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                              string AV106Propostacwwds_18_tfpropostadescricao ,
                                              decimal AV108Propostacwwds_20_tfpropostavalor ,
                                              decimal AV109Propostacwwds_21_tfpropostavalor_to ,
                                              int AV110Propostacwwds_22_tfpropostastatus_sels_Count ,
                                              string AV112Propostacwwds_24_tfcontratonome_sel ,
                                              string AV111Propostacwwds_23_tfcontratonome ,
                                              short AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              short AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              string AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              short A330PropostaQuantidadeAprovadores ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV89Propostacwwds_1_filterfulltext ,
                                              short A341PropostaAprovacoes_F ,
                                              short A342PropostaReprovacoes_F ,
                                              short AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              short AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              short AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                              short AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              int A642PropostaClinicaId ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              short A133SecUserId ,
                                              short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[51];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T1.ContratoId, T3.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaQuantidadeAprovadores, T1.PropostaValor, T1.PropostaTitulo, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T7.ContratoNome, T1.PropostaStatus, T1.PropostaDescricao, T2.ProcedimentosMedicosNome, COALESCE( T5.PropostaReprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T6.PropostaReprovacoes_F, 0) AS PropostaAprovacoes_F FROM ((((((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T5 ON T5.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN Contrato T7 ON T7.ContratoId = T1.ContratoId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV89Propostacwwds_1_filterfulltext))=0) or ( ( T2.ProcedimentosMedicosNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T7.ContratoNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaQuantidadeAprovadores,'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T5.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV89Propostacwwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV115Propostacwwds_27_tfpropostaaprovacoes_f = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) >= :AV115Propostacwwds_27_tfpropostaaprovacoes_f))");
         AddWhere(sWhereString, "((:AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) <= :AV116Propostacwwds_28_tfpropostaaprovacoes_f_to))");
         AddWhere(sWhereString, "((:AV117Propostacwwds_29_tfpropostareprovacoes_f = 0) or ( COALESCE( T5.PropostaReprovacoes_F, 0) >= :AV117Propostacwwds_29_tfpropostareprovacoes_f))");
         AddWhere(sWhereString, "((:AV118Propostacwwds_30_tfpropostareprovacoes_f_to = 0) or ( COALESCE( T5.PropostaReprovacoes_F, 0) <= :AV118Propostacwwds_30_tfpropostareprovacoes_f_to))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_1Secuserclienteid = 0) THEN :SecUserId ELSE T3.SecUserClienteId END)");
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like '%' || :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like '%' || :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like '%' || :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T2.ProcedimentosMedicosNome like :lV104Propostacwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProcedimentosMedicosNome = ( :AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV106Propostacwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV107Propostacwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV108Propostacwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV108Propostacwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV109Propostacwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV109Propostacwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( AV110Propostacwwds_22_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV110Propostacwwds_22_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome like :lV111Propostacwwds_23_tfcontratonome)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.ContratoNome = ( :AV112Propostacwwds_24_tfcontratonome_sel))");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T7.ContratoNome))=0))");
         }
         if ( ! (0==AV113Propostacwwds_25_tfpropostaquantidadeaprovadores) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores >= :AV113Propostacwwds_25_tfpropostaquantidadeaprovadores)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( ! (0==AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores <= :AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P009L13( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV110Propostacwwds_22_tfpropostastatus_sels ,
                                              string AV90Propostacwwds_2_dynamicfiltersselector1 ,
                                              short AV91Propostacwwds_3_dynamicfiltersoperator1 ,
                                              string AV92Propostacwwds_4_propostatitulo1 ,
                                              string AV93Propostacwwds_5_contratonome1 ,
                                              bool AV94Propostacwwds_6_dynamicfiltersenabled2 ,
                                              string AV95Propostacwwds_7_dynamicfiltersselector2 ,
                                              short AV96Propostacwwds_8_dynamicfiltersoperator2 ,
                                              string AV97Propostacwwds_9_propostatitulo2 ,
                                              string AV98Propostacwwds_10_contratonome2 ,
                                              bool AV99Propostacwwds_11_dynamicfiltersenabled3 ,
                                              string AV100Propostacwwds_12_dynamicfiltersselector3 ,
                                              short AV101Propostacwwds_13_dynamicfiltersoperator3 ,
                                              string AV102Propostacwwds_14_propostatitulo3 ,
                                              string AV103Propostacwwds_15_contratonome3 ,
                                              string AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV104Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              string AV107Propostacwwds_19_tfpropostadescricao_sel ,
                                              string AV106Propostacwwds_18_tfpropostadescricao ,
                                              decimal AV108Propostacwwds_20_tfpropostavalor ,
                                              decimal AV109Propostacwwds_21_tfpropostavalor_to ,
                                              int AV110Propostacwwds_22_tfpropostastatus_sels_Count ,
                                              string AV112Propostacwwds_24_tfcontratonome_sel ,
                                              string AV111Propostacwwds_23_tfcontratonome ,
                                              short AV113Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              short AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              string AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              short A330PropostaQuantidadeAprovadores ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string AV89Propostacwwds_1_filterfulltext ,
                                              short A341PropostaAprovacoes_F ,
                                              short A342PropostaReprovacoes_F ,
                                              short AV115Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              short AV116Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              short AV117Propostacwwds_29_tfpropostareprovacoes_f ,
                                              short AV118Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              int A642PropostaClinicaId ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              short A133SecUserId ,
                                              short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[51];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaQuantidadeAprovadores, T1.PropostaValor, T1.PropostaTitulo, T2.ContratoNome, T1.PropostaStatus, T1.PropostaDescricao, T3.ProcedimentosMedicosNome, COALESCE( T6.PropostaReprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T7.PropostaReprovacoes_F, 0) AS PropostaAprovacoes_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T7 ON T7.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV89Propostacwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV89Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T2.ContratoNome like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaQuantidadeAprovadores,'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV89Propostacwwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV89Propostacwwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV115Propostacwwds_27_tfpropostaaprovacoes_f = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) >= :AV115Propostacwwds_27_tfpropostaaprovacoes_f))");
         AddWhere(sWhereString, "((:AV116Propostacwwds_28_tfpropostaaprovacoes_f_to = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) <= :AV116Propostacwwds_28_tfpropostaaprovacoes_f_to))");
         AddWhere(sWhereString, "((:AV117Propostacwwds_29_tfpropostareprovacoes_f = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) >= :AV117Propostacwwds_29_tfpropostareprovacoes_f))");
         AddWhere(sWhereString, "((:AV118Propostacwwds_30_tfpropostareprovacoes_f_to = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) <= :AV118Propostacwwds_30_tfpropostareprovacoes_f_to))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_1Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV92Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV93Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV97Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( AV94Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV96Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV98Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV102Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( AV99Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV101Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV103Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV104Propostacwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV106Propostacwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostacwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV107Propostacwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( StringUtil.StrCmp(AV107Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV108Propostacwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV108Propostacwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV109Propostacwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV109Propostacwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( AV110Propostacwwds_22_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV110Propostacwwds_22_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacwwds_23_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV111Propostacwwds_23_tfcontratonome)");
         }
         else
         {
            GXv_int7[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_24_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV112Propostacwwds_24_tfcontratonome_sel))");
         }
         else
         {
            GXv_int7[46] = 1;
         }
         if ( StringUtil.StrCmp(AV112Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (0==AV113Propostacwwds_25_tfpropostaquantidadeaprovadores) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores >= :AV113Propostacwwds_25_tfpropostaquantidadeaprovadores)");
         }
         else
         {
            GXv_int7[47] = 1;
         }
         if ( ! (0==AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores <= :AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to)");
         }
         else
         {
            GXv_int7[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int7[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[50] = 1;
         }
         if ( StringUtil.StrCmp(AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
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
                     return conditional_P009L4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] , (int)dynConstraints[43] , (short)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] );
               case 1 :
                     return conditional_P009L7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] , (int)dynConstraints[43] , (short)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] );
               case 2 :
                     return conditional_P009L10(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] , (int)dynConstraints[43] , (short)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] );
               case 3 :
                     return conditional_P009L13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] , (int)dynConstraints[43] , (short)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] );
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
          Object[] prmP009L4;
          prmP009L4 = new Object[] {
          new ParDef("AV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV106Propostacwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV107Propostacwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV108Propostacwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV109Propostacwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV111Propostacwwds_23_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV112Propostacwwds_24_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacwwds_25_tfpropostaquantidadeaprovadores",GXType.Int16,4,0) ,
          new ParDef("AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to",GXType.Int16,4,0) ,
          new ParDef("lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP009L7;
          prmP009L7 = new Object[] {
          new ParDef("AV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV106Propostacwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV107Propostacwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV108Propostacwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV109Propostacwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV111Propostacwwds_23_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV112Propostacwwds_24_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacwwds_25_tfpropostaquantidadeaprovadores",GXType.Int16,4,0) ,
          new ParDef("AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to",GXType.Int16,4,0) ,
          new ParDef("lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP009L10;
          prmP009L10 = new Object[] {
          new ParDef("AV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV106Propostacwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV107Propostacwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV108Propostacwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV109Propostacwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV111Propostacwwds_23_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV112Propostacwwds_24_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacwwds_25_tfpropostaquantidadeaprovadores",GXType.Int16,4,0) ,
          new ParDef("AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to",GXType.Int16,4,0) ,
          new ParDef("lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP009L13;
          prmP009L13 = new Object[] {
          new ParDef("AV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV89Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV115Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV116Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV117Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV118Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV92Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV93Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV97Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV98Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV102Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV103Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV105Propostacwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV106Propostacwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV107Propostacwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV108Propostacwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV109Propostacwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV111Propostacwwds_23_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV112Propostacwwds_24_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV113Propostacwwds_25_tfpropostaquantidadeaprovadores",GXType.Int16,4,0) ,
          new ParDef("AV114Propostacwwds_26_tfpropostaquantidadeaprovadores_to",GXType.Int16,4,0) ,
          new ParDef("lV119Propostacwwds_31_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV120Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009L4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L13,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
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
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
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
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
