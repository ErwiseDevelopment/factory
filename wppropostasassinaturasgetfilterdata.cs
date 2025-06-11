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
   public class wppropostasassinaturasgetfilterdata : GXProcedure
   {
      public wppropostasassinaturasgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wppropostasassinaturasgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PROCEDIMENTOSMEDICOSNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROCEDIMENTOSMEDICOSNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAPACIENTECLIENTEDOCUMENTOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("WpPropostasAssinaturasGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpPropostasAssinaturasGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("WpPropostasAssinaturasGridState"), null, "", "");
         }
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV10TFProcedimentosMedicosNome = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV11TFProcedimentosMedicosNome_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV14TFPropostaValor = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV15TFPropostaValor_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV61TFPropostaPacienteClienteRazaoSocial = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV62TFPropostaPacienteClienteRazaoSocial_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV63TFPropostaPacienteClienteDocumento = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV64TFPropostaPacienteClienteDocumento_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV16TFPropostaStatus_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV17TFPropostaStatus_Sels.FromJSonString(AV16TFPropostaStatus_SelsJson, null);
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV67PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV68PropostaResponsavelDocumento1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV43PropostaPacienteClienteRazaoSocial1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV44PropostaPacienteClienteDocumento1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV69PropostaClinicaDocumento1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV45ContratoNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV46ConvenioCategoriaDescricao1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV70PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV71PropostaResponsavelDocumento2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV50PropostaPacienteClienteRazaoSocial2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV51PropostaPacienteClienteDocumento2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV72PropostaClinicaDocumento2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV52ContratoNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV53ConvenioCategoriaDescricao2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV54DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV55DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV73PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV74PropostaResponsavelDocumento3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV57PropostaPacienteClienteRazaoSocial3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV58PropostaPacienteClienteDocumento3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV75PropostaClinicaDocumento3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV59ContratoNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV60ConvenioCategoriaDescricao3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROCEDIMENTOSMEDICOSNOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFProcedimentosMedicosNome = AV18SearchTxt;
         AV11TFProcedimentosMedicosNome_Sel = "";
         AV78Wppropostasassinaturasds_1_filterfulltext = AV40FilterFullText;
         AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV67PropostaMaxReembolsoId_F1;
         AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV68PropostaResponsavelDocumento1;
         AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV43PropostaPacienteClienteRazaoSocial1;
         AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV44PropostaPacienteClienteDocumento1;
         AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV69PropostaClinicaDocumento1;
         AV86Wppropostasassinaturasds_9_contratonome1 = AV45ContratoNome1;
         AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV46ConvenioCategoriaDescricao1;
         AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV70PropostaMaxReembolsoId_F2;
         AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV71PropostaResponsavelDocumento2;
         AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV50PropostaPacienteClienteRazaoSocial2;
         AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV51PropostaPacienteClienteDocumento2;
         AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV72PropostaClinicaDocumento2;
         AV96Wppropostasassinaturasds_19_contratonome2 = AV52ContratoNome2;
         AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV53ConvenioCategoriaDescricao2;
         AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV73PropostaMaxReembolsoId_F3;
         AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV74PropostaResponsavelDocumento3;
         AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV57PropostaPacienteClienteRazaoSocial3;
         AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV58PropostaPacienteClienteDocumento3;
         AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV75PropostaClinicaDocumento3;
         AV106Wppropostasassinaturasds_29_contratonome3 = AV59ContratoNome3;
         AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV60ConvenioCategoriaDescricao3;
         AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV10TFProcedimentosMedicosNome;
         AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV11TFProcedimentosMedicosNome_Sel;
         AV110Wppropostasassinaturasds_33_tfpropostavalor = AV14TFPropostaValor;
         AV111Wppropostasassinaturasds_34_tfpropostavalor_to = AV15TFPropostaValor_To;
         AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV61TFPropostaPacienteClienteRazaoSocial;
         AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV62TFPropostaPacienteClienteRazaoSocial_Sel;
         AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV63TFPropostaPacienteClienteDocumento;
         AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV64TFPropostaPacienteClienteDocumento_Sel;
         AV116Wppropostasassinaturasds_39_tfpropostastatus_sels = AV17TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                              AV78Wppropostasassinaturasds_1_filterfulltext ,
                                              AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                              AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                              AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                              AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                              AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                              AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                              AV86Wppropostasassinaturasds_9_contratonome1 ,
                                              AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                              AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                              AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                              AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                              AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                              AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                              AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                              AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                              AV96Wppropostasassinaturasds_19_contratonome2 ,
                                              AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                              AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                              AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                              AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                              AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                              AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                              AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                              AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                              AV106Wppropostasassinaturasds_29_contratonome3 ,
                                              AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                              AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                              AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                              AV110Wppropostasassinaturasds_33_tfpropostavalor ,
                                              AV111Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                              AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                              AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                              AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                              AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                              AV116Wppropostasassinaturasds_39_tfpropostastatus_sels.Count ,
                                              A377ProcedimentosMedicosNome ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A580PropostaResponsavelDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                              AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV86Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV86Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV96Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV96Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV106Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV106Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome), "%", "");
         lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial), "%", "");
         lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento), "%", "");
         /* Using cursor P00B13 */
         pr_default.execute(0, new Object[] {AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV85Wppropostasassinaturasds_8_propostaclinicadocumento1, lV85Wppropostasassinaturasds_8_propostaclinicadocumento1, lV86Wppropostasassinaturasds_9_contratonome1, lV86Wppropostasassinaturasds_9_contratonome1, lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV95Wppropostasassinaturasds_18_propostaclinicadocumento2, lV95Wppropostasassinaturasds_18_propostaclinicadocumento2, lV96Wppropostasassinaturasds_19_contratonome2, lV96Wppropostasassinaturasds_19_contratonome2, lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV105Wppropostasassinaturasds_28_propostaclinicadocumento3, lV105Wppropostasassinaturasds_28_propostaclinicadocumento3, lV106Wppropostasassinaturasds_29_contratonome3, lV106Wppropostasassinaturasds_29_contratonome3, lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome, AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, AV110Wppropostasassinaturasds_33_tfpropostavalor, AV111Wppropostasassinaturasds_34_tfpropostavalor_to, lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial, AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento, AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKB12 = false;
            A227ContratoId = P00B13_A227ContratoId[0];
            n227ContratoId = P00B13_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00B13_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00B13_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = P00B13_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00B13_n493ConvenioCategoriaId[0];
            A504PropostaPacienteClienteId = P00B13_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00B13_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00B13_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00B13_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00B13_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00B13_n642PropostaClinicaId[0];
            A329PropostaStatus = P00B13_A329PropostaStatus[0];
            n329PropostaStatus = P00B13_n329PropostaStatus[0];
            A377ProcedimentosMedicosNome = P00B13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B13_n377ProcedimentosMedicosNome[0];
            A326PropostaValor = P00B13_A326PropostaValor[0];
            n326PropostaValor = P00B13_n326PropostaValor[0];
            A494ConvenioCategoriaDescricao = P00B13_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B13_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00B13_A228ContratoNome[0];
            n228ContratoNome = P00B13_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00B13_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B13_n652PropostaClinicaDocumento[0];
            A580PropostaResponsavelDocumento = P00B13_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B13_n580PropostaResponsavelDocumento[0];
            A540PropostaPacienteClienteDocumento = P00B13_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B13_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00B13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B13_n505PropostaPacienteClienteRazaoSocial[0];
            A323PropostaId = P00B13_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00B13_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B13_n649PropostaMaxReembolsoId_F[0];
            A228ContratoNome = P00B13_A228ContratoNome[0];
            n228ContratoNome = P00B13_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00B13_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B13_n377ProcedimentosMedicosNome[0];
            A494ConvenioCategoriaDescricao = P00B13_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B13_n494ConvenioCategoriaDescricao[0];
            A540PropostaPacienteClienteDocumento = P00B13_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B13_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00B13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B13_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P00B13_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B13_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00B13_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B13_n652PropostaClinicaDocumento[0];
            A649PropostaMaxReembolsoId_F = P00B13_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B13_n649PropostaMaxReembolsoId_F[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B13_A377ProcedimentosMedicosNome[0], A377ProcedimentosMedicosNome) == 0 ) )
            {
               BRKB12 = false;
               A376ProcedimentosMedicosId = P00B13_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = P00B13_n376ProcedimentosMedicosId[0];
               A323PropostaId = P00B13_A323PropostaId[0];
               AV28count = (long)(AV28count+1);
               BRKB12 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A377ProcedimentosMedicosNome)) ? "<#Empty#>" : A377ProcedimentosMedicosNome);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKB12 )
            {
               BRKB12 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV61TFPropostaPacienteClienteRazaoSocial = AV18SearchTxt;
         AV62TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV78Wppropostasassinaturasds_1_filterfulltext = AV40FilterFullText;
         AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV67PropostaMaxReembolsoId_F1;
         AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV68PropostaResponsavelDocumento1;
         AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV43PropostaPacienteClienteRazaoSocial1;
         AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV44PropostaPacienteClienteDocumento1;
         AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV69PropostaClinicaDocumento1;
         AV86Wppropostasassinaturasds_9_contratonome1 = AV45ContratoNome1;
         AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV46ConvenioCategoriaDescricao1;
         AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV70PropostaMaxReembolsoId_F2;
         AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV71PropostaResponsavelDocumento2;
         AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV50PropostaPacienteClienteRazaoSocial2;
         AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV51PropostaPacienteClienteDocumento2;
         AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV72PropostaClinicaDocumento2;
         AV96Wppropostasassinaturasds_19_contratonome2 = AV52ContratoNome2;
         AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV53ConvenioCategoriaDescricao2;
         AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV73PropostaMaxReembolsoId_F3;
         AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV74PropostaResponsavelDocumento3;
         AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV57PropostaPacienteClienteRazaoSocial3;
         AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV58PropostaPacienteClienteDocumento3;
         AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV75PropostaClinicaDocumento3;
         AV106Wppropostasassinaturasds_29_contratonome3 = AV59ContratoNome3;
         AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV60ConvenioCategoriaDescricao3;
         AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV10TFProcedimentosMedicosNome;
         AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV11TFProcedimentosMedicosNome_Sel;
         AV110Wppropostasassinaturasds_33_tfpropostavalor = AV14TFPropostaValor;
         AV111Wppropostasassinaturasds_34_tfpropostavalor_to = AV15TFPropostaValor_To;
         AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV61TFPropostaPacienteClienteRazaoSocial;
         AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV62TFPropostaPacienteClienteRazaoSocial_Sel;
         AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV63TFPropostaPacienteClienteDocumento;
         AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV64TFPropostaPacienteClienteDocumento_Sel;
         AV116Wppropostasassinaturasds_39_tfpropostastatus_sels = AV17TFPropostaStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                              AV78Wppropostasassinaturasds_1_filterfulltext ,
                                              AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                              AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                              AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                              AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                              AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                              AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                              AV86Wppropostasassinaturasds_9_contratonome1 ,
                                              AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                              AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                              AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                              AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                              AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                              AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                              AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                              AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                              AV96Wppropostasassinaturasds_19_contratonome2 ,
                                              AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                              AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                              AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                              AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                              AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                              AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                              AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                              AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                              AV106Wppropostasassinaturasds_29_contratonome3 ,
                                              AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                              AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                              AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                              AV110Wppropostasassinaturasds_33_tfpropostavalor ,
                                              AV111Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                              AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                              AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                              AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                              AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                              AV116Wppropostasassinaturasds_39_tfpropostastatus_sels.Count ,
                                              A377ProcedimentosMedicosNome ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A580PropostaResponsavelDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                              AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV86Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV86Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV96Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV96Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV106Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV106Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome), "%", "");
         lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial), "%", "");
         lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento), "%", "");
         /* Using cursor P00B15 */
         pr_default.execute(1, new Object[] {AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV85Wppropostasassinaturasds_8_propostaclinicadocumento1, lV85Wppropostasassinaturasds_8_propostaclinicadocumento1, lV86Wppropostasassinaturasds_9_contratonome1, lV86Wppropostasassinaturasds_9_contratonome1, lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV95Wppropostasassinaturasds_18_propostaclinicadocumento2, lV95Wppropostasassinaturasds_18_propostaclinicadocumento2, lV96Wppropostasassinaturasds_19_contratonome2, lV96Wppropostasassinaturasds_19_contratonome2, lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV105Wppropostasassinaturasds_28_propostaclinicadocumento3, lV105Wppropostasassinaturasds_28_propostaclinicadocumento3, lV106Wppropostasassinaturasds_29_contratonome3, lV106Wppropostasassinaturasds_29_contratonome3, lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome, AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, AV110Wppropostasassinaturasds_33_tfpropostavalor, AV111Wppropostasassinaturasds_34_tfpropostavalor_to, lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial, AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento, AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKB14 = false;
            A227ContratoId = P00B15_A227ContratoId[0];
            n227ContratoId = P00B15_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00B15_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00B15_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = P00B15_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00B15_n493ConvenioCategoriaId[0];
            A504PropostaPacienteClienteId = P00B15_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00B15_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00B15_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00B15_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00B15_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00B15_n642PropostaClinicaId[0];
            A329PropostaStatus = P00B15_A329PropostaStatus[0];
            n329PropostaStatus = P00B15_n329PropostaStatus[0];
            A505PropostaPacienteClienteRazaoSocial = P00B15_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B15_n505PropostaPacienteClienteRazaoSocial[0];
            A326PropostaValor = P00B15_A326PropostaValor[0];
            n326PropostaValor = P00B15_n326PropostaValor[0];
            A494ConvenioCategoriaDescricao = P00B15_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B15_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00B15_A228ContratoNome[0];
            n228ContratoNome = P00B15_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00B15_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B15_n652PropostaClinicaDocumento[0];
            A580PropostaResponsavelDocumento = P00B15_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B15_n580PropostaResponsavelDocumento[0];
            A540PropostaPacienteClienteDocumento = P00B15_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B15_n540PropostaPacienteClienteDocumento[0];
            A377ProcedimentosMedicosNome = P00B15_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B15_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00B15_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00B15_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B15_n649PropostaMaxReembolsoId_F[0];
            A228ContratoNome = P00B15_A228ContratoNome[0];
            n228ContratoNome = P00B15_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00B15_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B15_n377ProcedimentosMedicosNome[0];
            A494ConvenioCategoriaDescricao = P00B15_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B15_n494ConvenioCategoriaDescricao[0];
            A505PropostaPacienteClienteRazaoSocial = P00B15_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B15_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = P00B15_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B15_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P00B15_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B15_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00B15_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B15_n652PropostaClinicaDocumento[0];
            A649PropostaMaxReembolsoId_F = P00B15_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B15_n649PropostaMaxReembolsoId_F[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00B15_A505PropostaPacienteClienteRazaoSocial[0], A505PropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRKB14 = false;
               A504PropostaPacienteClienteId = P00B15_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = P00B15_n504PropostaPacienteClienteId[0];
               A323PropostaId = P00B15_A323PropostaId[0];
               AV28count = (long)(AV28count+1);
               BRKB14 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A505PropostaPacienteClienteRazaoSocial)) ? "<#Empty#>" : A505PropostaPacienteClienteRazaoSocial);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKB14 )
            {
               BRKB14 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROPOSTAPACIENTECLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV63TFPropostaPacienteClienteDocumento = AV18SearchTxt;
         AV64TFPropostaPacienteClienteDocumento_Sel = "";
         AV78Wppropostasassinaturasds_1_filterfulltext = AV40FilterFullText;
         AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV67PropostaMaxReembolsoId_F1;
         AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV68PropostaResponsavelDocumento1;
         AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV43PropostaPacienteClienteRazaoSocial1;
         AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV44PropostaPacienteClienteDocumento1;
         AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV69PropostaClinicaDocumento1;
         AV86Wppropostasassinaturasds_9_contratonome1 = AV45ContratoNome1;
         AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV46ConvenioCategoriaDescricao1;
         AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV70PropostaMaxReembolsoId_F2;
         AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV71PropostaResponsavelDocumento2;
         AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV50PropostaPacienteClienteRazaoSocial2;
         AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV51PropostaPacienteClienteDocumento2;
         AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV72PropostaClinicaDocumento2;
         AV96Wppropostasassinaturasds_19_contratonome2 = AV52ContratoNome2;
         AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV53ConvenioCategoriaDescricao2;
         AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV73PropostaMaxReembolsoId_F3;
         AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV74PropostaResponsavelDocumento3;
         AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV57PropostaPacienteClienteRazaoSocial3;
         AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV58PropostaPacienteClienteDocumento3;
         AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV75PropostaClinicaDocumento3;
         AV106Wppropostasassinaturasds_29_contratonome3 = AV59ContratoNome3;
         AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV60ConvenioCategoriaDescricao3;
         AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV10TFProcedimentosMedicosNome;
         AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV11TFProcedimentosMedicosNome_Sel;
         AV110Wppropostasassinaturasds_33_tfpropostavalor = AV14TFPropostaValor;
         AV111Wppropostasassinaturasds_34_tfpropostavalor_to = AV15TFPropostaValor_To;
         AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV61TFPropostaPacienteClienteRazaoSocial;
         AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV62TFPropostaPacienteClienteRazaoSocial_Sel;
         AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV63TFPropostaPacienteClienteDocumento;
         AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV64TFPropostaPacienteClienteDocumento_Sel;
         AV116Wppropostasassinaturasds_39_tfpropostastatus_sels = AV17TFPropostaStatus_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                              AV78Wppropostasassinaturasds_1_filterfulltext ,
                                              AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                              AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                              AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                              AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                              AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                              AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                              AV86Wppropostasassinaturasds_9_contratonome1 ,
                                              AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                              AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                              AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                              AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                              AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                              AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                              AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                              AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                              AV96Wppropostasassinaturasds_19_contratonome2 ,
                                              AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                              AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                              AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                              AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                              AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                              AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                              AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                              AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                              AV106Wppropostasassinaturasds_29_contratonome3 ,
                                              AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                              AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                              AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                              AV110Wppropostasassinaturasds_33_tfpropostavalor ,
                                              AV111Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                              AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                              AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                              AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                              AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                              AV116Wppropostasassinaturasds_39_tfpropostastatus_sels.Count ,
                                              A377ProcedimentosMedicosNome ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A580PropostaResponsavelDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                              AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV78Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV86Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV86Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV96Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV96Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV106Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV106Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome), "%", "");
         lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial), "%", "");
         lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento), "%", "");
         /* Using cursor P00B17 */
         pr_default.execute(2, new Object[] {AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV78Wppropostasassinaturasds_1_filterfulltext, lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV85Wppropostasassinaturasds_8_propostaclinicadocumento1, lV85Wppropostasassinaturasds_8_propostaclinicadocumento1, lV86Wppropostasassinaturasds_9_contratonome1, lV86Wppropostasassinaturasds_9_contratonome1, lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV95Wppropostasassinaturasds_18_propostaclinicadocumento2, lV95Wppropostasassinaturasds_18_propostaclinicadocumento2, lV96Wppropostasassinaturasds_19_contratonome2, lV96Wppropostasassinaturasds_19_contratonome2, lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV105Wppropostasassinaturasds_28_propostaclinicadocumento3, lV105Wppropostasassinaturasds_28_propostaclinicadocumento3, lV106Wppropostasassinaturasds_29_contratonome3, lV106Wppropostasassinaturasds_29_contratonome3, lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome, AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, AV110Wppropostasassinaturasds_33_tfpropostavalor, AV111Wppropostasassinaturasds_34_tfpropostavalor_to, lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial, AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento, AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKB16 = false;
            A227ContratoId = P00B17_A227ContratoId[0];
            n227ContratoId = P00B17_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00B17_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00B17_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = P00B17_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00B17_n493ConvenioCategoriaId[0];
            A553PropostaResponsavelId = P00B17_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00B17_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00B17_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00B17_n642PropostaClinicaId[0];
            A504PropostaPacienteClienteId = P00B17_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00B17_n504PropostaPacienteClienteId[0];
            A326PropostaValor = P00B17_A326PropostaValor[0];
            n326PropostaValor = P00B17_n326PropostaValor[0];
            A494ConvenioCategoriaDescricao = P00B17_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B17_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00B17_A228ContratoNome[0];
            n228ContratoNome = P00B17_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00B17_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B17_n652PropostaClinicaDocumento[0];
            A580PropostaResponsavelDocumento = P00B17_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B17_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P00B17_A329PropostaStatus[0];
            n329PropostaStatus = P00B17_n329PropostaStatus[0];
            A540PropostaPacienteClienteDocumento = P00B17_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B17_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00B17_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B17_n505PropostaPacienteClienteRazaoSocial[0];
            A377ProcedimentosMedicosNome = P00B17_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B17_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00B17_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00B17_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B17_n649PropostaMaxReembolsoId_F[0];
            A228ContratoNome = P00B17_A228ContratoNome[0];
            n228ContratoNome = P00B17_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00B17_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B17_n377ProcedimentosMedicosNome[0];
            A494ConvenioCategoriaDescricao = P00B17_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B17_n494ConvenioCategoriaDescricao[0];
            A580PropostaResponsavelDocumento = P00B17_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B17_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00B17_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B17_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P00B17_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B17_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00B17_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B17_n505PropostaPacienteClienteRazaoSocial[0];
            A649PropostaMaxReembolsoId_F = P00B17_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B17_n649PropostaMaxReembolsoId_F[0];
            AV28count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00B17_A504PropostaPacienteClienteId[0] == A504PropostaPacienteClienteId ) )
            {
               BRKB16 = false;
               A323PropostaId = P00B17_A323PropostaId[0];
               AV28count = (long)(AV28count+1);
               BRKB16 = true;
               pr_default.readNext(2);
            }
            AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A540PropostaPacienteClienteDocumento)) ? "<#Empty#>" : A540PropostaPacienteClienteDocumento);
            AV22InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV23Option, "<#Empty#>") != 0 ) && ( AV22InsertIndex <= AV24Options.Count ) && ( ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), AV23Option) < 0 ) || ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV22InsertIndex = (int)(AV22InsertIndex+1);
            }
            AV24Options.Add(AV23Option, AV22InsertIndex);
            AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), AV22InsertIndex);
            if ( AV24Options.Count == AV19SkipItems + 11 )
            {
               AV24Options.RemoveItem(AV24Options.Count);
               AV27OptionIndexes.RemoveItem(AV27OptionIndexes.Count);
            }
            if ( ! BRKB16 )
            {
               BRKB16 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV19SkipItems > 0 )
         {
            AV24Options.RemoveItem(1);
            AV27OptionIndexes.RemoveItem(1);
            AV19SkipItems = (short)(AV19SkipItems-1);
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV10TFProcedimentosMedicosNome = "";
         AV11TFProcedimentosMedicosNome_Sel = "";
         AV61TFPropostaPacienteClienteRazaoSocial = "";
         AV62TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV63TFPropostaPacienteClienteDocumento = "";
         AV64TFPropostaPacienteClienteDocumento_Sel = "";
         AV16TFPropostaStatus_SelsJson = "";
         AV17TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV68PropostaResponsavelDocumento1 = "";
         AV43PropostaPacienteClienteRazaoSocial1 = "";
         AV44PropostaPacienteClienteDocumento1 = "";
         AV69PropostaClinicaDocumento1 = "";
         AV45ContratoNome1 = "";
         AV46ConvenioCategoriaDescricao1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV71PropostaResponsavelDocumento2 = "";
         AV50PropostaPacienteClienteRazaoSocial2 = "";
         AV51PropostaPacienteClienteDocumento2 = "";
         AV72PropostaClinicaDocumento2 = "";
         AV52ContratoNome2 = "";
         AV53ConvenioCategoriaDescricao2 = "";
         AV55DynamicFiltersSelector3 = "";
         AV74PropostaResponsavelDocumento3 = "";
         AV57PropostaPacienteClienteRazaoSocial3 = "";
         AV58PropostaPacienteClienteDocumento3 = "";
         AV75PropostaClinicaDocumento3 = "";
         AV59ContratoNome3 = "";
         AV60ConvenioCategoriaDescricao3 = "";
         AV78Wppropostasassinaturasds_1_filterfulltext = "";
         AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = "";
         AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = "";
         AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = "";
         AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = "";
         AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = "";
         AV86Wppropostasassinaturasds_9_contratonome1 = "";
         AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = "";
         AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = "";
         AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = "";
         AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = "";
         AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = "";
         AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = "";
         AV96Wppropostasassinaturasds_19_contratonome2 = "";
         AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = "";
         AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = "";
         AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = "";
         AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = "";
         AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = "";
         AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = "";
         AV106Wppropostasassinaturasds_29_contratonome3 = "";
         AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = "";
         AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = "";
         AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = "";
         AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = "";
         AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = "";
         AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = "";
         AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = "";
         AV116Wppropostasassinaturasds_39_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV78Wppropostasassinaturasds_1_filterfulltext = "";
         lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = "";
         lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = "";
         lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = "";
         lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 = "";
         lV86Wppropostasassinaturasds_9_contratonome1 = "";
         lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 = "";
         lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = "";
         lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = "";
         lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = "";
         lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 = "";
         lV96Wppropostasassinaturasds_19_contratonome2 = "";
         lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 = "";
         lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = "";
         lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = "";
         lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = "";
         lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 = "";
         lV106Wppropostasassinaturasds_29_contratonome3 = "";
         lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 = "";
         lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = "";
         lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = "";
         lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = "";
         A329PropostaStatus = "";
         A377ProcedimentosMedicosNome = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A580PropostaResponsavelDocumento = "";
         A652PropostaClinicaDocumento = "";
         A228ContratoNome = "";
         A494ConvenioCategoriaDescricao = "";
         P00B13_A227ContratoId = new int[1] ;
         P00B13_n227ContratoId = new bool[] {false} ;
         P00B13_A376ProcedimentosMedicosId = new int[1] ;
         P00B13_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00B13_A493ConvenioCategoriaId = new int[1] ;
         P00B13_n493ConvenioCategoriaId = new bool[] {false} ;
         P00B13_A504PropostaPacienteClienteId = new int[1] ;
         P00B13_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00B13_A553PropostaResponsavelId = new int[1] ;
         P00B13_n553PropostaResponsavelId = new bool[] {false} ;
         P00B13_A642PropostaClinicaId = new int[1] ;
         P00B13_n642PropostaClinicaId = new bool[] {false} ;
         P00B13_A329PropostaStatus = new string[] {""} ;
         P00B13_n329PropostaStatus = new bool[] {false} ;
         P00B13_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00B13_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00B13_A326PropostaValor = new decimal[1] ;
         P00B13_n326PropostaValor = new bool[] {false} ;
         P00B13_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00B13_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00B13_A228ContratoNome = new string[] {""} ;
         P00B13_n228ContratoNome = new bool[] {false} ;
         P00B13_A652PropostaClinicaDocumento = new string[] {""} ;
         P00B13_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00B13_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00B13_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00B13_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00B13_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00B13_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00B13_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00B13_A323PropostaId = new int[1] ;
         P00B13_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00B13_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         AV23Option = "";
         P00B15_A227ContratoId = new int[1] ;
         P00B15_n227ContratoId = new bool[] {false} ;
         P00B15_A376ProcedimentosMedicosId = new int[1] ;
         P00B15_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00B15_A493ConvenioCategoriaId = new int[1] ;
         P00B15_n493ConvenioCategoriaId = new bool[] {false} ;
         P00B15_A504PropostaPacienteClienteId = new int[1] ;
         P00B15_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00B15_A553PropostaResponsavelId = new int[1] ;
         P00B15_n553PropostaResponsavelId = new bool[] {false} ;
         P00B15_A642PropostaClinicaId = new int[1] ;
         P00B15_n642PropostaClinicaId = new bool[] {false} ;
         P00B15_A329PropostaStatus = new string[] {""} ;
         P00B15_n329PropostaStatus = new bool[] {false} ;
         P00B15_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00B15_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00B15_A326PropostaValor = new decimal[1] ;
         P00B15_n326PropostaValor = new bool[] {false} ;
         P00B15_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00B15_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00B15_A228ContratoNome = new string[] {""} ;
         P00B15_n228ContratoNome = new bool[] {false} ;
         P00B15_A652PropostaClinicaDocumento = new string[] {""} ;
         P00B15_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00B15_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00B15_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00B15_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00B15_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00B15_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00B15_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00B15_A323PropostaId = new int[1] ;
         P00B15_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00B15_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P00B17_A227ContratoId = new int[1] ;
         P00B17_n227ContratoId = new bool[] {false} ;
         P00B17_A376ProcedimentosMedicosId = new int[1] ;
         P00B17_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00B17_A493ConvenioCategoriaId = new int[1] ;
         P00B17_n493ConvenioCategoriaId = new bool[] {false} ;
         P00B17_A553PropostaResponsavelId = new int[1] ;
         P00B17_n553PropostaResponsavelId = new bool[] {false} ;
         P00B17_A642PropostaClinicaId = new int[1] ;
         P00B17_n642PropostaClinicaId = new bool[] {false} ;
         P00B17_A504PropostaPacienteClienteId = new int[1] ;
         P00B17_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00B17_A326PropostaValor = new decimal[1] ;
         P00B17_n326PropostaValor = new bool[] {false} ;
         P00B17_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00B17_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00B17_A228ContratoNome = new string[] {""} ;
         P00B17_n228ContratoNome = new bool[] {false} ;
         P00B17_A652PropostaClinicaDocumento = new string[] {""} ;
         P00B17_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00B17_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00B17_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00B17_A329PropostaStatus = new string[] {""} ;
         P00B17_n329PropostaStatus = new bool[] {false} ;
         P00B17_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00B17_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00B17_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00B17_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00B17_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00B17_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00B17_A323PropostaId = new int[1] ;
         P00B17_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00B17_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppropostasassinaturasgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00B13_A227ContratoId, P00B13_n227ContratoId, P00B13_A376ProcedimentosMedicosId, P00B13_n376ProcedimentosMedicosId, P00B13_A493ConvenioCategoriaId, P00B13_n493ConvenioCategoriaId, P00B13_A504PropostaPacienteClienteId, P00B13_n504PropostaPacienteClienteId, P00B13_A553PropostaResponsavelId, P00B13_n553PropostaResponsavelId,
               P00B13_A642PropostaClinicaId, P00B13_n642PropostaClinicaId, P00B13_A329PropostaStatus, P00B13_n329PropostaStatus, P00B13_A377ProcedimentosMedicosNome, P00B13_n377ProcedimentosMedicosNome, P00B13_A326PropostaValor, P00B13_n326PropostaValor, P00B13_A494ConvenioCategoriaDescricao, P00B13_n494ConvenioCategoriaDescricao,
               P00B13_A228ContratoNome, P00B13_n228ContratoNome, P00B13_A652PropostaClinicaDocumento, P00B13_n652PropostaClinicaDocumento, P00B13_A580PropostaResponsavelDocumento, P00B13_n580PropostaResponsavelDocumento, P00B13_A540PropostaPacienteClienteDocumento, P00B13_n540PropostaPacienteClienteDocumento, P00B13_A505PropostaPacienteClienteRazaoSocial, P00B13_n505PropostaPacienteClienteRazaoSocial,
               P00B13_A323PropostaId, P00B13_A649PropostaMaxReembolsoId_F, P00B13_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00B15_A227ContratoId, P00B15_n227ContratoId, P00B15_A376ProcedimentosMedicosId, P00B15_n376ProcedimentosMedicosId, P00B15_A493ConvenioCategoriaId, P00B15_n493ConvenioCategoriaId, P00B15_A504PropostaPacienteClienteId, P00B15_n504PropostaPacienteClienteId, P00B15_A553PropostaResponsavelId, P00B15_n553PropostaResponsavelId,
               P00B15_A642PropostaClinicaId, P00B15_n642PropostaClinicaId, P00B15_A329PropostaStatus, P00B15_n329PropostaStatus, P00B15_A505PropostaPacienteClienteRazaoSocial, P00B15_n505PropostaPacienteClienteRazaoSocial, P00B15_A326PropostaValor, P00B15_n326PropostaValor, P00B15_A494ConvenioCategoriaDescricao, P00B15_n494ConvenioCategoriaDescricao,
               P00B15_A228ContratoNome, P00B15_n228ContratoNome, P00B15_A652PropostaClinicaDocumento, P00B15_n652PropostaClinicaDocumento, P00B15_A580PropostaResponsavelDocumento, P00B15_n580PropostaResponsavelDocumento, P00B15_A540PropostaPacienteClienteDocumento, P00B15_n540PropostaPacienteClienteDocumento, P00B15_A377ProcedimentosMedicosNome, P00B15_n377ProcedimentosMedicosNome,
               P00B15_A323PropostaId, P00B15_A649PropostaMaxReembolsoId_F, P00B15_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P00B17_A227ContratoId, P00B17_n227ContratoId, P00B17_A376ProcedimentosMedicosId, P00B17_n376ProcedimentosMedicosId, P00B17_A493ConvenioCategoriaId, P00B17_n493ConvenioCategoriaId, P00B17_A553PropostaResponsavelId, P00B17_n553PropostaResponsavelId, P00B17_A642PropostaClinicaId, P00B17_n642PropostaClinicaId,
               P00B17_A504PropostaPacienteClienteId, P00B17_n504PropostaPacienteClienteId, P00B17_A326PropostaValor, P00B17_n326PropostaValor, P00B17_A494ConvenioCategoriaDescricao, P00B17_n494ConvenioCategoriaDescricao, P00B17_A228ContratoNome, P00B17_n228ContratoNome, P00B17_A652PropostaClinicaDocumento, P00B17_n652PropostaClinicaDocumento,
               P00B17_A580PropostaResponsavelDocumento, P00B17_n580PropostaResponsavelDocumento, P00B17_A329PropostaStatus, P00B17_n329PropostaStatus, P00B17_A540PropostaPacienteClienteDocumento, P00B17_n540PropostaPacienteClienteDocumento, P00B17_A505PropostaPacienteClienteRazaoSocial, P00B17_n505PropostaPacienteClienteRazaoSocial, P00B17_A377ProcedimentosMedicosNome, P00B17_n377ProcedimentosMedicosNome,
               P00B17_A323PropostaId, P00B17_A649PropostaMaxReembolsoId_F, P00B17_n649PropostaMaxReembolsoId_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV49DynamicFiltersOperator2 ;
      private short AV56DynamicFiltersOperator3 ;
      private short AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ;
      private short AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ;
      private short AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ;
      private int AV76GXV1 ;
      private int AV67PropostaMaxReembolsoId_F1 ;
      private int AV70PropostaMaxReembolsoId_F2 ;
      private int AV73PropostaMaxReembolsoId_F3 ;
      private int AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ;
      private int AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ;
      private int AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 ;
      private int AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A323PropostaId ;
      private int AV22InsertIndex ;
      private long AV28count ;
      private decimal AV14TFPropostaValor ;
      private decimal AV15TFPropostaValor_To ;
      private decimal AV110Wppropostasassinaturasds_33_tfpropostavalor ;
      private decimal AV111Wppropostasassinaturasds_34_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV54DynamicFiltersEnabled3 ;
      private bool AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ;
      private bool AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ;
      private bool BRKB12 ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n493ConvenioCategoriaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n329PropostaStatus ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n326PropostaValor ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n228ContratoNome ;
      private bool n652PropostaClinicaDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool BRKB14 ;
      private bool BRKB16 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV16TFPropostaStatus_SelsJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV10TFProcedimentosMedicosNome ;
      private string AV11TFProcedimentosMedicosNome_Sel ;
      private string AV61TFPropostaPacienteClienteRazaoSocial ;
      private string AV62TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV63TFPropostaPacienteClienteDocumento ;
      private string AV64TFPropostaPacienteClienteDocumento_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV68PropostaResponsavelDocumento1 ;
      private string AV43PropostaPacienteClienteRazaoSocial1 ;
      private string AV44PropostaPacienteClienteDocumento1 ;
      private string AV69PropostaClinicaDocumento1 ;
      private string AV45ContratoNome1 ;
      private string AV46ConvenioCategoriaDescricao1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV71PropostaResponsavelDocumento2 ;
      private string AV50PropostaPacienteClienteRazaoSocial2 ;
      private string AV51PropostaPacienteClienteDocumento2 ;
      private string AV72PropostaClinicaDocumento2 ;
      private string AV52ContratoNome2 ;
      private string AV53ConvenioCategoriaDescricao2 ;
      private string AV55DynamicFiltersSelector3 ;
      private string AV74PropostaResponsavelDocumento3 ;
      private string AV57PropostaPacienteClienteRazaoSocial3 ;
      private string AV58PropostaPacienteClienteDocumento3 ;
      private string AV75PropostaClinicaDocumento3 ;
      private string AV59ContratoNome3 ;
      private string AV60ConvenioCategoriaDescricao3 ;
      private string AV78Wppropostasassinaturasds_1_filterfulltext ;
      private string AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ;
      private string AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ;
      private string AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ;
      private string AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ;
      private string AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ;
      private string AV86Wppropostasassinaturasds_9_contratonome1 ;
      private string AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ;
      private string AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ;
      private string AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ;
      private string AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ;
      private string AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ;
      private string AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ;
      private string AV96Wppropostasassinaturasds_19_contratonome2 ;
      private string AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ;
      private string AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ;
      private string AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ;
      private string AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ;
      private string AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ;
      private string AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ;
      private string AV106Wppropostasassinaturasds_29_contratonome3 ;
      private string AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ;
      private string AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ;
      private string AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ;
      private string AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ;
      private string AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ;
      private string AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ;
      private string AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ;
      private string lV78Wppropostasassinaturasds_1_filterfulltext ;
      private string lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ;
      private string lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ;
      private string lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ;
      private string lV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ;
      private string lV86Wppropostasassinaturasds_9_contratonome1 ;
      private string lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ;
      private string lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ;
      private string lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ;
      private string lV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ;
      private string lV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ;
      private string lV96Wppropostasassinaturasds_19_contratonome2 ;
      private string lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ;
      private string lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ;
      private string lV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ;
      private string lV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ;
      private string lV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ;
      private string lV106Wppropostasassinaturasds_29_contratonome3 ;
      private string lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ;
      private string lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ;
      private string lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ;
      private string lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ;
      private string A329PropostaStatus ;
      private string A377ProcedimentosMedicosNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A580PropostaResponsavelDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A228ContratoNome ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GxSimpleCollection<string> AV17TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00B13_A227ContratoId ;
      private bool[] P00B13_n227ContratoId ;
      private int[] P00B13_A376ProcedimentosMedicosId ;
      private bool[] P00B13_n376ProcedimentosMedicosId ;
      private int[] P00B13_A493ConvenioCategoriaId ;
      private bool[] P00B13_n493ConvenioCategoriaId ;
      private int[] P00B13_A504PropostaPacienteClienteId ;
      private bool[] P00B13_n504PropostaPacienteClienteId ;
      private int[] P00B13_A553PropostaResponsavelId ;
      private bool[] P00B13_n553PropostaResponsavelId ;
      private int[] P00B13_A642PropostaClinicaId ;
      private bool[] P00B13_n642PropostaClinicaId ;
      private string[] P00B13_A329PropostaStatus ;
      private bool[] P00B13_n329PropostaStatus ;
      private string[] P00B13_A377ProcedimentosMedicosNome ;
      private bool[] P00B13_n377ProcedimentosMedicosNome ;
      private decimal[] P00B13_A326PropostaValor ;
      private bool[] P00B13_n326PropostaValor ;
      private string[] P00B13_A494ConvenioCategoriaDescricao ;
      private bool[] P00B13_n494ConvenioCategoriaDescricao ;
      private string[] P00B13_A228ContratoNome ;
      private bool[] P00B13_n228ContratoNome ;
      private string[] P00B13_A652PropostaClinicaDocumento ;
      private bool[] P00B13_n652PropostaClinicaDocumento ;
      private string[] P00B13_A580PropostaResponsavelDocumento ;
      private bool[] P00B13_n580PropostaResponsavelDocumento ;
      private string[] P00B13_A540PropostaPacienteClienteDocumento ;
      private bool[] P00B13_n540PropostaPacienteClienteDocumento ;
      private string[] P00B13_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00B13_n505PropostaPacienteClienteRazaoSocial ;
      private int[] P00B13_A323PropostaId ;
      private int[] P00B13_A649PropostaMaxReembolsoId_F ;
      private bool[] P00B13_n649PropostaMaxReembolsoId_F ;
      private int[] P00B15_A227ContratoId ;
      private bool[] P00B15_n227ContratoId ;
      private int[] P00B15_A376ProcedimentosMedicosId ;
      private bool[] P00B15_n376ProcedimentosMedicosId ;
      private int[] P00B15_A493ConvenioCategoriaId ;
      private bool[] P00B15_n493ConvenioCategoriaId ;
      private int[] P00B15_A504PropostaPacienteClienteId ;
      private bool[] P00B15_n504PropostaPacienteClienteId ;
      private int[] P00B15_A553PropostaResponsavelId ;
      private bool[] P00B15_n553PropostaResponsavelId ;
      private int[] P00B15_A642PropostaClinicaId ;
      private bool[] P00B15_n642PropostaClinicaId ;
      private string[] P00B15_A329PropostaStatus ;
      private bool[] P00B15_n329PropostaStatus ;
      private string[] P00B15_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00B15_n505PropostaPacienteClienteRazaoSocial ;
      private decimal[] P00B15_A326PropostaValor ;
      private bool[] P00B15_n326PropostaValor ;
      private string[] P00B15_A494ConvenioCategoriaDescricao ;
      private bool[] P00B15_n494ConvenioCategoriaDescricao ;
      private string[] P00B15_A228ContratoNome ;
      private bool[] P00B15_n228ContratoNome ;
      private string[] P00B15_A652PropostaClinicaDocumento ;
      private bool[] P00B15_n652PropostaClinicaDocumento ;
      private string[] P00B15_A580PropostaResponsavelDocumento ;
      private bool[] P00B15_n580PropostaResponsavelDocumento ;
      private string[] P00B15_A540PropostaPacienteClienteDocumento ;
      private bool[] P00B15_n540PropostaPacienteClienteDocumento ;
      private string[] P00B15_A377ProcedimentosMedicosNome ;
      private bool[] P00B15_n377ProcedimentosMedicosNome ;
      private int[] P00B15_A323PropostaId ;
      private int[] P00B15_A649PropostaMaxReembolsoId_F ;
      private bool[] P00B15_n649PropostaMaxReembolsoId_F ;
      private int[] P00B17_A227ContratoId ;
      private bool[] P00B17_n227ContratoId ;
      private int[] P00B17_A376ProcedimentosMedicosId ;
      private bool[] P00B17_n376ProcedimentosMedicosId ;
      private int[] P00B17_A493ConvenioCategoriaId ;
      private bool[] P00B17_n493ConvenioCategoriaId ;
      private int[] P00B17_A553PropostaResponsavelId ;
      private bool[] P00B17_n553PropostaResponsavelId ;
      private int[] P00B17_A642PropostaClinicaId ;
      private bool[] P00B17_n642PropostaClinicaId ;
      private int[] P00B17_A504PropostaPacienteClienteId ;
      private bool[] P00B17_n504PropostaPacienteClienteId ;
      private decimal[] P00B17_A326PropostaValor ;
      private bool[] P00B17_n326PropostaValor ;
      private string[] P00B17_A494ConvenioCategoriaDescricao ;
      private bool[] P00B17_n494ConvenioCategoriaDescricao ;
      private string[] P00B17_A228ContratoNome ;
      private bool[] P00B17_n228ContratoNome ;
      private string[] P00B17_A652PropostaClinicaDocumento ;
      private bool[] P00B17_n652PropostaClinicaDocumento ;
      private string[] P00B17_A580PropostaResponsavelDocumento ;
      private bool[] P00B17_n580PropostaResponsavelDocumento ;
      private string[] P00B17_A329PropostaStatus ;
      private bool[] P00B17_n329PropostaStatus ;
      private string[] P00B17_A540PropostaPacienteClienteDocumento ;
      private bool[] P00B17_n540PropostaPacienteClienteDocumento ;
      private string[] P00B17_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00B17_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00B17_A377ProcedimentosMedicosNome ;
      private bool[] P00B17_n377ProcedimentosMedicosNome ;
      private int[] P00B17_A323PropostaId ;
      private int[] P00B17_A649PropostaMaxReembolsoId_F ;
      private bool[] P00B17_n649PropostaMaxReembolsoId_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wppropostasassinaturasgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B13( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                             string AV78Wppropostasassinaturasds_1_filterfulltext ,
                                             string AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                             short AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                             string AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                             string AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                             string AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                             string AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                             string AV86Wppropostasassinaturasds_9_contratonome1 ,
                                             string AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                             bool AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                             string AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                             short AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                             string AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                             string AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                             string AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                             string AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                             string AV96Wppropostasassinaturasds_19_contratonome2 ,
                                             string AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                             bool AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                             string AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                             short AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                             string AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                             string AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                             string AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                             string AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                             string AV106Wppropostasassinaturasds_29_contratonome3 ,
                                             string AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                             string AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                             string AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                             decimal AV110Wppropostasassinaturasds_33_tfpropostavalor ,
                                             decimal AV111Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                             string AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                             string AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                             string AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                             int AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ,
                                             string A377ProcedimentosMedicosNome ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             int AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                             int AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[98];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaStatus, T3.ProcedimentosMedicosNome, T1.PropostaValor, T4.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T4 ON T4.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 0 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 1 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 2 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 0 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 1 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 2 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ProcedimentosMedicosNome like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteDocumento like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')))");
         }
         else
         {
            GXv_int1[42] = 1;
            GXv_int1[43] = 1;
            GXv_int1[44] = 1;
            GXv_int1[45] = 1;
            GXv_int1[46] = 1;
            GXv_int1[47] = 1;
            GXv_int1[48] = 1;
            GXv_int1[49] = 1;
            GXv_int1[50] = 1;
            GXv_int1[51] = 1;
            GXv_int1[52] = 1;
            GXv_int1[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV85Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int1[60] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV85Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int1[61] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV86Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int1[62] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV86Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int1[69] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV94Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int1[70] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV94Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int1[71] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV95Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int1[72] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV95Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int1[73] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int1[74] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int1[75] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int1[76] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int1[77] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int1[78] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int1[79] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int1[80] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int1[81] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int1[82] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int1[83] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV105Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int1[84] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV105Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int1[85] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV106Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int1[86] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV106Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int1[87] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int1[88] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int1[89] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int1[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int1[91] = 1;
         }
         if ( StringUtil.StrCmp(AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Wppropostasassinaturasds_33_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Wppropostasassinaturasds_33_tfpropostavalor)");
         }
         else
         {
            GXv_int1[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wppropostasassinaturasds_34_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Wppropostasassinaturasds_34_tfpropostavalor_to)");
         }
         else
         {
            GXv_int1[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazao)");
         }
         else
         {
            GXv_int1[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazao))");
         }
         else
         {
            GXv_int1[95] = 1;
         }
         if ( StringUtil.StrCmp(AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocum)");
         }
         else
         {
            GXv_int1[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento = ( :AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocum))");
         }
         else
         {
            GXv_int1[97] = 1;
         }
         if ( StringUtil.StrCmp(AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T5.ClienteDocumento))=0))");
         }
         if ( AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Wppropostasassinaturasds_39_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00B15( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                             string AV78Wppropostasassinaturasds_1_filterfulltext ,
                                             string AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                             short AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                             string AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                             string AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                             string AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                             string AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                             string AV86Wppropostasassinaturasds_9_contratonome1 ,
                                             string AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                             bool AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                             string AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                             short AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                             string AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                             string AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                             string AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                             string AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                             string AV96Wppropostasassinaturasds_19_contratonome2 ,
                                             string AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                             bool AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                             string AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                             short AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                             string AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                             string AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                             string AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                             string AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                             string AV106Wppropostasassinaturasds_29_contratonome3 ,
                                             string AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                             string AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                             string AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                             decimal AV110Wppropostasassinaturasds_33_tfpropostavalor ,
                                             decimal AV111Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                             string AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                             string AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                             string AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                             int AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ,
                                             string A377ProcedimentosMedicosNome ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             int AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                             int AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[98];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaStatus, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaValor, T4.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T4 ON T4.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 0 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 1 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 2 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 0 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 1 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 2 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ProcedimentosMedicosNome like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteDocumento like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')))");
         }
         else
         {
            GXv_int3[42] = 1;
            GXv_int3[43] = 1;
            GXv_int3[44] = 1;
            GXv_int3[45] = 1;
            GXv_int3[46] = 1;
            GXv_int3[47] = 1;
            GXv_int3[48] = 1;
            GXv_int3[49] = 1;
            GXv_int3[50] = 1;
            GXv_int3[51] = 1;
            GXv_int3[52] = 1;
            GXv_int3[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV85Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV85Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV86Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV86Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV94Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV94Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV95Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV95Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int3[83] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV105Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[84] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV105Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[85] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV106Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int3[86] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV106Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int3[87] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[88] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[89] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[91] = 1;
         }
         if ( StringUtil.StrCmp(AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Wppropostasassinaturasds_33_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Wppropostasassinaturasds_33_tfpropostavalor)");
         }
         else
         {
            GXv_int3[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wppropostasassinaturasds_34_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Wppropostasassinaturasds_34_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazao)");
         }
         else
         {
            GXv_int3[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazao))");
         }
         else
         {
            GXv_int3[95] = 1;
         }
         if ( StringUtil.StrCmp(AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocum)");
         }
         else
         {
            GXv_int3[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento = ( :AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocum))");
         }
         else
         {
            GXv_int3[97] = 1;
         }
         if ( StringUtil.StrCmp(AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T5.ClienteDocumento))=0))");
         }
         if ( AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Wppropostasassinaturasds_39_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00B17( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV116Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                             string AV78Wppropostasassinaturasds_1_filterfulltext ,
                                             string AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                             short AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                             string AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                             string AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                             string AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                             string AV85Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                             string AV86Wppropostasassinaturasds_9_contratonome1 ,
                                             string AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                             bool AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                             string AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                             short AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                             string AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                             string AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                             string AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                             string AV95Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                             string AV96Wppropostasassinaturasds_19_contratonome2 ,
                                             string AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                             bool AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                             string AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                             short AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                             string AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                             string AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                             string AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                             string AV105Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                             string AV106Wppropostasassinaturasds_29_contratonome3 ,
                                             string AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                             string AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                             string AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                             decimal AV110Wppropostasassinaturasds_33_tfpropostavalor ,
                                             decimal AV111Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                             string AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                             string AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                             string AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                             int AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ,
                                             string A377ProcedimentosMedicosNome ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             int AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                             int AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[98];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.ConvenioCategoriaId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaValor, T4.ConvenioCategoriaDescricao, T2.ContratoNome, T6.ClienteDocumento AS PropostaClinicaDocumento, T5.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T7.ClienteDocumento AS PropostaPacienteClienteDocumento, T7.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T4 ON T4.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaClinicaId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV79Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 0 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 1 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV89Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 2 and ( Not (:AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 0 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 1 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV99Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 2 and ( Not (:AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wppropostasassinaturasds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ProcedimentosMedicosNome like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( T7.ClienteRazaoSocial like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( T7.ClienteDocumento like '%' || :lV78Wppropostasassinaturasds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV78Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')))");
         }
         else
         {
            GXv_int5[42] = 1;
            GXv_int5[43] = 1;
            GXv_int5[44] = 1;
            GXv_int5[45] = 1;
            GXv_int5[46] = 1;
            GXv_int5[47] = 1;
            GXv_int5[48] = 1;
            GXv_int5[49] = 1;
            GXv_int5[50] = 1;
            GXv_int5[51] = 1;
            GXv_int5[52] = 1;
            GXv_int5[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV85Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV85Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV86Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV86Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int5[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int5[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int5[65] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int5[66] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int5[67] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int5[68] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int5[69] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV94Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int5[70] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV94Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int5[71] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV95Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int5[72] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV95Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int5[73] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int5[74] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int5[75] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int5[76] = 1;
         }
         if ( AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int5[77] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int5[78] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int5[79] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int5[80] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like '%' || :lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int5[81] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int5[82] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int5[83] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV105Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int5[84] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV105Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int5[85] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV106Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int5[86] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV106Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int5[87] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int5[88] = 1;
         }
         if ( AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int5[89] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int5[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int5[91] = 1;
         }
         if ( StringUtil.StrCmp(AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV110Wppropostasassinaturasds_33_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV110Wppropostasassinaturasds_33_tfpropostavalor)");
         }
         else
         {
            GXv_int5[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wppropostasassinaturasds_34_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV111Wppropostasassinaturasds_34_tfpropostavalor_to)");
         }
         else
         {
            GXv_int5[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial like :lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazao)");
         }
         else
         {
            GXv_int5[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial = ( :AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazao))");
         }
         else
         {
            GXv_int5[95] = 1;
         }
         if ( StringUtil.StrCmp(AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T7.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocum)");
         }
         else
         {
            GXv_int5[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento = ( :AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocum))");
         }
         else
         {
            GXv_int5[97] = 1;
         }
         if ( StringUtil.StrCmp(AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T7.ClienteDocumento))=0))");
         }
         if ( AV116Wppropostasassinaturasds_39_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV116Wppropostasassinaturasds_39_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaPacienteClienteId";
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
                     return conditional_P00B13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] );
               case 1 :
                     return conditional_P00B15(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] );
               case 2 :
                     return conditional_P00B17(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] );
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
          Object[] prmP00B13;
          prmP00B13 = new Object[] {
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV86Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV86Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV94Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV94Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV96Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV105Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV105Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV106Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("AV110Wppropostasassinaturasds_33_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Wppropostasassinaturasds_34_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocum",GXType.VarChar,20,0)
          };
          Object[] prmP00B15;
          prmP00B15 = new Object[] {
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV86Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV86Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV94Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV94Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV96Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV105Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV105Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV106Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("AV110Wppropostasassinaturasds_33_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Wppropostasassinaturasds_34_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocum",GXType.VarChar,20,0)
          };
          Object[] prmP00B17;
          prmP00B17 = new Object[] {
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV79Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV80Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV88Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV89Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV90Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV98Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV99Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV100Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV101Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV82Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV83Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV84Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV86Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV86Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV87Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV92Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV93Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV94Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV94Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV96Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV96Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV97Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV102Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV103Wppropostasassinaturasds_26_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV104Wppropostasassinaturasds_27_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV105Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV105Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV106Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV106Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV107Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV108Wppropostasassinaturasds_31_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV109Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("AV110Wppropostasassinaturasds_33_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV111Wppropostasassinaturasds_34_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV112Wppropostasassinaturasds_35_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("AV113Wppropostasassinaturasds_36_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV114Wppropostasassinaturasds_37_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("AV115Wppropostasassinaturasds_38_tfpropostapacienteclientedocum",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B15", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B17,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
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
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
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
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
