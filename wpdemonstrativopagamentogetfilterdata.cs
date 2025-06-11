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
   public class wpdemonstrativopagamentogetfilterdata : GXProcedure
   {
      public wpdemonstrativopagamentogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdemonstrativopagamentogetfilterdata( IGxContext context )
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
         this.AV50DDOName = aP0_DDOName;
         this.AV51SearchTxtParms = aP1_SearchTxtParms;
         this.AV52SearchTxtTo = aP2_SearchTxtTo;
         this.AV53OptionsJson = "" ;
         this.AV54OptionsDescJson = "" ;
         this.AV55OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV53OptionsJson;
         aP4_OptionsDescJson=this.AV54OptionsDescJson;
         aP5_OptionIndexesJson=this.AV55OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV55OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV50DDOName = aP0_DDOName;
         this.AV51SearchTxtParms = aP1_SearchTxtParms;
         this.AV52SearchTxtTo = aP2_SearchTxtTo;
         this.AV53OptionsJson = "" ;
         this.AV54OptionsDescJson = "" ;
         this.AV55OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV53OptionsJson;
         aP4_OptionsDescJson=this.AV54OptionsDescJson;
         aP5_OptionIndexesJson=this.AV55OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV40Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV43OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37MaxItems = 10;
         AV36PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV51SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV51SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV34SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV51SearchTxtParms)) ? "" : StringUtil.Substring( AV51SearchTxtParms, 3, -1));
         AV35SkipItems = (short)(AV36PageIndex*AV37MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV50DDOName), "DDO_PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV50DDOName), "DDO_PROPOSTADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTADESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV50DDOName), "DDO_PROPOSTASECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTASECUSERNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV53OptionsJson = AV40Options.ToJSonString(false);
         AV54OptionsDescJson = AV42OptionsDesc.ToJSonString(false);
         AV55OptionIndexesJson = AV43OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV45Session.Get("WpDemonstrativoPagamentoGridState"), "") == 0 )
         {
            AV47GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpDemonstrativoPagamentoGridState"), null, "", "");
         }
         else
         {
            AV47GridState.FromXml(AV45Session.Get("WpDemonstrativoPagamentoGridState"), null, "", "");
         }
         AV94GXV1 = 1;
         while ( AV94GXV1 <= AV47GridState.gxTpr_Filtervalues.Count )
         {
            AV48GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV47GridState.gxTpr_Filtervalues.Item(AV94GXV1));
            if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV56FilterFullText = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFPropostaPacienteClienteRazaoSocial = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFPropostaPacienteClienteRazaoSocial_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV14TFPropostaDescricao = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV15TFPropostaDescricao_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV16TFPropostaValor = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, ".");
               AV17TFPropostaValor_To = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTATAXAADMINISTRATIVA") == 0 )
            {
               AV18TFPropostaTaxaAdministrativa = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, ".");
               AV19TFPropostaTaxaAdministrativa_To = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALORTAXA_F") == 0 )
            {
               AV76TFPropostaValorTaxa_F = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, ".");
               AV77TFPropostaValorTaxa_F_To = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTAJUROSMORA") == 0 )
            {
               AV22TFPropostaJurosMora = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, ".");
               AV23TFPropostaJurosMora_To = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTADATACREDITOCLIENTE_F") == 0 )
            {
               AV80TFPropostaDataCreditoCliente_F = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Value, 4);
               AV81TFPropostaDataCreditoCliente_F_To = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALORJUROSMORA_F") == 0 )
            {
               AV78TFPropostaValorJurosMora_F = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, ".");
               AV79TFPropostaValorJurosMora_F_To = NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTASECUSERNAME") == 0 )
            {
               AV74TFPropostaSecUserName = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTASECUSERNAME_SEL") == 0 )
            {
               AV75TFPropostaSecUserName_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV26TFPropostaStatus_SelsJson = AV48GridStateFilterValue.gxTpr_Value;
               AV27TFPropostaStatus_Sels.FromJSonString(AV26TFPropostaStatus_SelsJson, null);
            }
            AV94GXV1 = (int)(AV94GXV1+1);
         }
         if ( AV47GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV49GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV47GridState.gxTpr_Dynamicfilters.Item(1));
            AV57DynamicFiltersSelector1 = AV49GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV82PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV49GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV83PropostaResponsavelDocumento1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV84PropostaPacienteClienteDocumento1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV85PropostaClinicaDocumento1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV59PropostaPacienteClienteRazaoSocial1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV60ContratoNome1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV58DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV61ConvenioCategoriaDescricao1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV47GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV62DynamicFiltersEnabled2 = true;
               AV49GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV47GridState.gxTpr_Dynamicfilters.Item(2));
               AV63DynamicFiltersSelector2 = AV49GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV86PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV49GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV87PropostaResponsavelDocumento2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV88PropostaPacienteClienteDocumento2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV89PropostaClinicaDocumento2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV65PropostaPacienteClienteRazaoSocial2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV66ContratoNome2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV64DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV67ConvenioCategoriaDescricao2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV47GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV68DynamicFiltersEnabled3 = true;
                  AV49GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV47GridState.gxTpr_Dynamicfilters.Item(3));
                  AV69DynamicFiltersSelector3 = AV49GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV90PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV49GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV91PropostaResponsavelDocumento3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV92PropostaPacienteClienteDocumento3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV93PropostaClinicaDocumento3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV71PropostaPacienteClienteRazaoSocial3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV72ContratoNome3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV69DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV70DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV73ConvenioCategoriaDescricao3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFPropostaPacienteClienteRazaoSocial = AV34SearchTxt;
         AV11TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV96Wpdemonstrativopagamentods_1_filterfulltext = AV56FilterFullText;
         AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV57DynamicFiltersSelector1;
         AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV58DynamicFiltersOperator1;
         AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV82PropostaMaxReembolsoId_F1;
         AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV83PropostaResponsavelDocumento1;
         AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV84PropostaPacienteClienteDocumento1;
         AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV85PropostaClinicaDocumento1;
         AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV59PropostaPacienteClienteRazaoSocial1;
         AV104Wpdemonstrativopagamentods_9_contratonome1 = AV60ContratoNome1;
         AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV61ConvenioCategoriaDescricao1;
         AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV62DynamicFiltersEnabled2;
         AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV63DynamicFiltersSelector2;
         AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV64DynamicFiltersOperator2;
         AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV86PropostaMaxReembolsoId_F2;
         AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV87PropostaResponsavelDocumento2;
         AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV88PropostaPacienteClienteDocumento2;
         AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV89PropostaClinicaDocumento2;
         AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV65PropostaPacienteClienteRazaoSocial2;
         AV114Wpdemonstrativopagamentods_19_contratonome2 = AV66ContratoNome2;
         AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV67ConvenioCategoriaDescricao2;
         AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV68DynamicFiltersEnabled3;
         AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV69DynamicFiltersSelector3;
         AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV70DynamicFiltersOperator3;
         AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV90PropostaMaxReembolsoId_F3;
         AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV91PropostaResponsavelDocumento3;
         AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV92PropostaPacienteClienteDocumento3;
         AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV93PropostaClinicaDocumento3;
         AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV71PropostaPacienteClienteRazaoSocial3;
         AV124Wpdemonstrativopagamentods_29_contratonome3 = AV72ContratoNome3;
         AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV73ConvenioCategoriaDescricao3;
         AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV10TFPropostaPacienteClienteRazaoSocial;
         AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV11TFPropostaPacienteClienteRazaoSocial_Sel;
         AV128Wpdemonstrativopagamentods_33_tfpropostadescricao = AV14TFPropostaDescricao;
         AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV130Wpdemonstrativopagamentods_35_tfpropostavalor = AV16TFPropostaValor;
         AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV18TFPropostaTaxaAdministrativa;
         AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV19TFPropostaTaxaAdministrativa_To;
         AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV76TFPropostaValorTaxa_F;
         AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV77TFPropostaValorTaxa_F_To;
         AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV22TFPropostaJurosMora;
         AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV23TFPropostaJurosMora_To;
         AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV80TFPropostaDataCreditoCliente_F;
         AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV81TFPropostaDataCreditoCliente_F_To;
         AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV78TFPropostaValorJurosMora_F;
         AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV79TFPropostaValorJurosMora_F_To;
         AV142Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV27TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                              AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                              AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                              AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                              AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                              AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                              AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                              AV104Wpdemonstrativopagamentods_9_contratonome1 ,
                                              AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                              AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                              AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                              AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                              AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                              AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                              AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                              AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                              AV114Wpdemonstrativopagamentods_19_contratonome2 ,
                                              AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                              AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                              AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                              AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                              AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                              AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                              AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                              AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                              AV124Wpdemonstrativopagamentods_29_contratonome3 ,
                                              AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                              AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                              AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                              AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                              AV130Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                              AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                              AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                              AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                              AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                              AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                              AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                              AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                              AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                              AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                              AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels.Count ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A501PropostaTaxaAdministrativa ,
                                              A508PropostaJurosMora ,
                                              A512PropostaSecUserName ,
                                              AV96Wpdemonstrativopagamentods_1_filterfulltext ,
                                              A513PropostaValorTaxa_F ,
                                              A514PropostaValorJurosMora_F ,
                                              AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                              AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                              AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                              A515PropostaDataCreditoCliente_F ,
                                              AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                              AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                              AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV104Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV104Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV114Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV114Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV124Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV124Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial), "%", "");
         lV128Wpdemonstrativopagamentods_33_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_33_tfpropostadescricao), "%", "");
         lV142Wpdemonstrativopagamentods_47_tfpropostasecusername = StringUtil.Concat( StringUtil.RTrim( AV142Wpdemonstrativopagamentods_47_tfpropostasecusername), "%", "");
         /* Using cursor P00AK5 */
         pr_default.execute(0, new Object[] {AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV104Wpdemonstrativopagamentods_9_contratonome1, lV104Wpdemonstrativopagamentods_9_contratonome1, lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV114Wpdemonstrativopagamentods_19_contratonome2, lV114Wpdemonstrativopagamentods_19_contratonome2, lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV124Wpdemonstrativopagamentods_29_contratonome3, lV124Wpdemonstrativopagamentods_29_contratonome3, lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial, AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, lV128Wpdemonstrativopagamentods_33_tfpropostadescricao, AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, AV130Wpdemonstrativopagamentods_35_tfpropostavalor, AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to, AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa, AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to, AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f, AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to, AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora, AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to, lV142Wpdemonstrativopagamentods_47_tfpropostasecusername, AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAK2 = false;
            A227ContratoId = P00AK5_A227ContratoId[0];
            n227ContratoId = P00AK5_n227ContratoId[0];
            A493ConvenioCategoriaId = P00AK5_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00AK5_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = P00AK5_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AK5_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AK5_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AK5_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00AK5_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00AK5_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00AK5_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AK5_n642PropostaClinicaId[0];
            A505PropostaPacienteClienteRazaoSocial = P00AK5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AK5_n505PropostaPacienteClienteRazaoSocial[0];
            A513PropostaValorTaxa_F = P00AK5_A513PropostaValorTaxa_F[0];
            A494ConvenioCategoriaDescricao = P00AK5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AK5_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00AK5_A228ContratoNome[0];
            n228ContratoNome = P00AK5_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00AK5_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AK5_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P00AK5_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AK5_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P00AK5_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AK5_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P00AK5_A329PropostaStatus[0];
            n329PropostaStatus = P00AK5_n329PropostaStatus[0];
            A512PropostaSecUserName = P00AK5_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AK5_n512PropostaSecUserName[0];
            A325PropostaDescricao = P00AK5_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AK5_n325PropostaDescricao[0];
            A501PropostaTaxaAdministrativa = P00AK5_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = P00AK5_n501PropostaTaxaAdministrativa[0];
            A323PropostaId = P00AK5_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00AK5_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AK5_n649PropostaMaxReembolsoId_F[0];
            A326PropostaValor = P00AK5_A326PropostaValor[0];
            n326PropostaValor = P00AK5_n326PropostaValor[0];
            A508PropostaJurosMora = P00AK5_A508PropostaJurosMora[0];
            n508PropostaJurosMora = P00AK5_n508PropostaJurosMora[0];
            A507PropostaSLA = P00AK5_A507PropostaSLA[0];
            n507PropostaSLA = P00AK5_n507PropostaSLA[0];
            A515PropostaDataCreditoCliente_F = P00AK5_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AK5_n515PropostaDataCreditoCliente_F[0];
            A228ContratoNome = P00AK5_A228ContratoNome[0];
            n228ContratoNome = P00AK5_n228ContratoNome[0];
            A494ConvenioCategoriaDescricao = P00AK5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AK5_n494ConvenioCategoriaDescricao[0];
            A512PropostaSecUserName = P00AK5_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AK5_n512PropostaSecUserName[0];
            A505PropostaPacienteClienteRazaoSocial = P00AK5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AK5_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = P00AK5_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AK5_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P00AK5_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AK5_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00AK5_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AK5_n652PropostaClinicaDocumento[0];
            A515PropostaDataCreditoCliente_F = P00AK5_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AK5_n515PropostaDataCreditoCliente_F[0];
            A649PropostaMaxReembolsoId_F = P00AK5_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AK5_n649PropostaMaxReembolsoId_F[0];
            GXt_decimal1 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
            A514PropostaValorJurosMora_F = GXt_decimal1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wpdemonstrativopagamentods_1_filterfulltext)) || ( ( StringUtil.Like( A505PropostaPacienteClienteRazaoSocial , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A325PropostaDescricao , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A326PropostaValor, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A501PropostaTaxaAdministrativa, 16, 4) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A513PropostaValorTaxa_F, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A508PropostaJurosMora, 16, 4) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A514PropostaValorJurosMora_F, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A512PropostaSecUserName , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "pendente aprovação" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) ) || ( StringUtil.Like( "em análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) ) || ( StringUtil.Like( "revisão" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) ) || ( StringUtil.Like( "cancelado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) ) ||
            ( StringUtil.Like( "aguardando assinatura" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) ) || ( StringUtil.Like( "análise reprovada" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) ) )
            )
            {
               if ( (Convert.ToDecimal(0)==AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f) || ( ( A514PropostaValorJurosMora_F >= AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to) || ( ( A514PropostaValorJurosMora_F <= AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ) ) )
                  {
                     AV44count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AK5_A505PropostaPacienteClienteRazaoSocial[0], A505PropostaPacienteClienteRazaoSocial) == 0 ) )
                     {
                        BRKAK2 = false;
                        A504PropostaPacienteClienteId = P00AK5_A504PropostaPacienteClienteId[0];
                        n504PropostaPacienteClienteId = P00AK5_n504PropostaPacienteClienteId[0];
                        A323PropostaId = P00AK5_A323PropostaId[0];
                        AV44count = (long)(AV44count+1);
                        BRKAK2 = true;
                        pr_default.readNext(0);
                     }
                     if ( (0==AV35SkipItems) )
                     {
                        AV39Option = (String.IsNullOrEmpty(StringUtil.RTrim( A505PropostaPacienteClienteRazaoSocial)) ? "<#Empty#>" : A505PropostaPacienteClienteRazaoSocial);
                        AV40Options.Add(AV39Option, 0);
                        AV43OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV40Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV35SkipItems = (short)(AV35SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRKAK2 )
            {
               BRKAK2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROPOSTADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV14TFPropostaDescricao = AV34SearchTxt;
         AV15TFPropostaDescricao_Sel = "";
         AV96Wpdemonstrativopagamentods_1_filterfulltext = AV56FilterFullText;
         AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV57DynamicFiltersSelector1;
         AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV58DynamicFiltersOperator1;
         AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV82PropostaMaxReembolsoId_F1;
         AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV83PropostaResponsavelDocumento1;
         AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV84PropostaPacienteClienteDocumento1;
         AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV85PropostaClinicaDocumento1;
         AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV59PropostaPacienteClienteRazaoSocial1;
         AV104Wpdemonstrativopagamentods_9_contratonome1 = AV60ContratoNome1;
         AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV61ConvenioCategoriaDescricao1;
         AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV62DynamicFiltersEnabled2;
         AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV63DynamicFiltersSelector2;
         AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV64DynamicFiltersOperator2;
         AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV86PropostaMaxReembolsoId_F2;
         AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV87PropostaResponsavelDocumento2;
         AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV88PropostaPacienteClienteDocumento2;
         AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV89PropostaClinicaDocumento2;
         AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV65PropostaPacienteClienteRazaoSocial2;
         AV114Wpdemonstrativopagamentods_19_contratonome2 = AV66ContratoNome2;
         AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV67ConvenioCategoriaDescricao2;
         AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV68DynamicFiltersEnabled3;
         AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV69DynamicFiltersSelector3;
         AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV70DynamicFiltersOperator3;
         AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV90PropostaMaxReembolsoId_F3;
         AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV91PropostaResponsavelDocumento3;
         AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV92PropostaPacienteClienteDocumento3;
         AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV93PropostaClinicaDocumento3;
         AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV71PropostaPacienteClienteRazaoSocial3;
         AV124Wpdemonstrativopagamentods_29_contratonome3 = AV72ContratoNome3;
         AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV73ConvenioCategoriaDescricao3;
         AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV10TFPropostaPacienteClienteRazaoSocial;
         AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV11TFPropostaPacienteClienteRazaoSocial_Sel;
         AV128Wpdemonstrativopagamentods_33_tfpropostadescricao = AV14TFPropostaDescricao;
         AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV130Wpdemonstrativopagamentods_35_tfpropostavalor = AV16TFPropostaValor;
         AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV18TFPropostaTaxaAdministrativa;
         AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV19TFPropostaTaxaAdministrativa_To;
         AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV76TFPropostaValorTaxa_F;
         AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV77TFPropostaValorTaxa_F_To;
         AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV22TFPropostaJurosMora;
         AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV23TFPropostaJurosMora_To;
         AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV80TFPropostaDataCreditoCliente_F;
         AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV81TFPropostaDataCreditoCliente_F_To;
         AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV78TFPropostaValorJurosMora_F;
         AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV79TFPropostaValorJurosMora_F_To;
         AV142Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV27TFPropostaStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                              AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                              AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                              AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                              AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                              AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                              AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                              AV104Wpdemonstrativopagamentods_9_contratonome1 ,
                                              AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                              AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                              AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                              AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                              AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                              AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                              AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                              AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                              AV114Wpdemonstrativopagamentods_19_contratonome2 ,
                                              AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                              AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                              AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                              AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                              AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                              AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                              AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                              AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                              AV124Wpdemonstrativopagamentods_29_contratonome3 ,
                                              AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                              AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                              AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                              AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                              AV130Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                              AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                              AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                              AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                              AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                              AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                              AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                              AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                              AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                              AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                              AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels.Count ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A501PropostaTaxaAdministrativa ,
                                              A508PropostaJurosMora ,
                                              A512PropostaSecUserName ,
                                              AV96Wpdemonstrativopagamentods_1_filterfulltext ,
                                              A513PropostaValorTaxa_F ,
                                              A514PropostaValorJurosMora_F ,
                                              AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                              AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                              AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                              A515PropostaDataCreditoCliente_F ,
                                              AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                              AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                              AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV104Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV104Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV114Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV114Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV124Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV124Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial), "%", "");
         lV128Wpdemonstrativopagamentods_33_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_33_tfpropostadescricao), "%", "");
         lV142Wpdemonstrativopagamentods_47_tfpropostasecusername = StringUtil.Concat( StringUtil.RTrim( AV142Wpdemonstrativopagamentods_47_tfpropostasecusername), "%", "");
         /* Using cursor P00AK9 */
         pr_default.execute(1, new Object[] {AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV104Wpdemonstrativopagamentods_9_contratonome1, lV104Wpdemonstrativopagamentods_9_contratonome1, lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV114Wpdemonstrativopagamentods_19_contratonome2, lV114Wpdemonstrativopagamentods_19_contratonome2, lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV124Wpdemonstrativopagamentods_29_contratonome3, lV124Wpdemonstrativopagamentods_29_contratonome3, lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial, AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, lV128Wpdemonstrativopagamentods_33_tfpropostadescricao, AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, AV130Wpdemonstrativopagamentods_35_tfpropostavalor, AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to, AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa, AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to, AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f, AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to, AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora, AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to, lV142Wpdemonstrativopagamentods_47_tfpropostasecusername, AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAK4 = false;
            A227ContratoId = P00AK9_A227ContratoId[0];
            n227ContratoId = P00AK9_n227ContratoId[0];
            A493ConvenioCategoriaId = P00AK9_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00AK9_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = P00AK9_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AK9_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AK9_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AK9_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00AK9_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00AK9_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00AK9_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AK9_n642PropostaClinicaId[0];
            A325PropostaDescricao = P00AK9_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AK9_n325PropostaDescricao[0];
            A513PropostaValorTaxa_F = P00AK9_A513PropostaValorTaxa_F[0];
            A494ConvenioCategoriaDescricao = P00AK9_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AK9_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00AK9_A228ContratoNome[0];
            n228ContratoNome = P00AK9_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00AK9_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AK9_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P00AK9_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AK9_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P00AK9_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AK9_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P00AK9_A329PropostaStatus[0];
            n329PropostaStatus = P00AK9_n329PropostaStatus[0];
            A512PropostaSecUserName = P00AK9_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AK9_n512PropostaSecUserName[0];
            A505PropostaPacienteClienteRazaoSocial = P00AK9_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AK9_n505PropostaPacienteClienteRazaoSocial[0];
            A501PropostaTaxaAdministrativa = P00AK9_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = P00AK9_n501PropostaTaxaAdministrativa[0];
            A323PropostaId = P00AK9_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00AK9_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AK9_n649PropostaMaxReembolsoId_F[0];
            A326PropostaValor = P00AK9_A326PropostaValor[0];
            n326PropostaValor = P00AK9_n326PropostaValor[0];
            A508PropostaJurosMora = P00AK9_A508PropostaJurosMora[0];
            n508PropostaJurosMora = P00AK9_n508PropostaJurosMora[0];
            A507PropostaSLA = P00AK9_A507PropostaSLA[0];
            n507PropostaSLA = P00AK9_n507PropostaSLA[0];
            A515PropostaDataCreditoCliente_F = P00AK9_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AK9_n515PropostaDataCreditoCliente_F[0];
            A228ContratoNome = P00AK9_A228ContratoNome[0];
            n228ContratoNome = P00AK9_n228ContratoNome[0];
            A494ConvenioCategoriaDescricao = P00AK9_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AK9_n494ConvenioCategoriaDescricao[0];
            A512PropostaSecUserName = P00AK9_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AK9_n512PropostaSecUserName[0];
            A540PropostaPacienteClienteDocumento = P00AK9_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AK9_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00AK9_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AK9_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P00AK9_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AK9_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00AK9_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AK9_n652PropostaClinicaDocumento[0];
            A515PropostaDataCreditoCliente_F = P00AK9_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AK9_n515PropostaDataCreditoCliente_F[0];
            A649PropostaMaxReembolsoId_F = P00AK9_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AK9_n649PropostaMaxReembolsoId_F[0];
            GXt_decimal1 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
            A514PropostaValorJurosMora_F = GXt_decimal1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wpdemonstrativopagamentods_1_filterfulltext)) || ( ( StringUtil.Like( A505PropostaPacienteClienteRazaoSocial , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A325PropostaDescricao , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A326PropostaValor, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A501PropostaTaxaAdministrativa, 16, 4) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A513PropostaValorTaxa_F, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A508PropostaJurosMora, 16, 4) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A514PropostaValorJurosMora_F, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A512PropostaSecUserName , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "pendente aprovação" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) ) || ( StringUtil.Like( "em análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) ) || ( StringUtil.Like( "revisão" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) ) || ( StringUtil.Like( "cancelado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) ) ||
            ( StringUtil.Like( "aguardando assinatura" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) ) || ( StringUtil.Like( "análise reprovada" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) ) )
            )
            {
               if ( (Convert.ToDecimal(0)==AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f) || ( ( A514PropostaValorJurosMora_F >= AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to) || ( ( A514PropostaValorJurosMora_F <= AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ) ) )
                  {
                     AV44count = 0;
                     while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AK9_A325PropostaDescricao[0], A325PropostaDescricao) == 0 ) )
                     {
                        BRKAK4 = false;
                        A323PropostaId = P00AK9_A323PropostaId[0];
                        AV44count = (long)(AV44count+1);
                        BRKAK4 = true;
                        pr_default.readNext(1);
                     }
                     if ( (0==AV35SkipItems) )
                     {
                        AV39Option = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? "<#Empty#>" : A325PropostaDescricao);
                        AV40Options.Add(AV39Option, 0);
                        AV43OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV40Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV35SkipItems = (short)(AV35SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRKAK4 )
            {
               BRKAK4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROPOSTASECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV74TFPropostaSecUserName = AV34SearchTxt;
         AV75TFPropostaSecUserName_Sel = "";
         AV96Wpdemonstrativopagamentods_1_filterfulltext = AV56FilterFullText;
         AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV57DynamicFiltersSelector1;
         AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV58DynamicFiltersOperator1;
         AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV82PropostaMaxReembolsoId_F1;
         AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV83PropostaResponsavelDocumento1;
         AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV84PropostaPacienteClienteDocumento1;
         AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV85PropostaClinicaDocumento1;
         AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV59PropostaPacienteClienteRazaoSocial1;
         AV104Wpdemonstrativopagamentods_9_contratonome1 = AV60ContratoNome1;
         AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV61ConvenioCategoriaDescricao1;
         AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV62DynamicFiltersEnabled2;
         AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV63DynamicFiltersSelector2;
         AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV64DynamicFiltersOperator2;
         AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV86PropostaMaxReembolsoId_F2;
         AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV87PropostaResponsavelDocumento2;
         AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV88PropostaPacienteClienteDocumento2;
         AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV89PropostaClinicaDocumento2;
         AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV65PropostaPacienteClienteRazaoSocial2;
         AV114Wpdemonstrativopagamentods_19_contratonome2 = AV66ContratoNome2;
         AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV67ConvenioCategoriaDescricao2;
         AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV68DynamicFiltersEnabled3;
         AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV69DynamicFiltersSelector3;
         AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV70DynamicFiltersOperator3;
         AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV90PropostaMaxReembolsoId_F3;
         AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV91PropostaResponsavelDocumento3;
         AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV92PropostaPacienteClienteDocumento3;
         AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV93PropostaClinicaDocumento3;
         AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV71PropostaPacienteClienteRazaoSocial3;
         AV124Wpdemonstrativopagamentods_29_contratonome3 = AV72ContratoNome3;
         AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV73ConvenioCategoriaDescricao3;
         AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV10TFPropostaPacienteClienteRazaoSocial;
         AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV11TFPropostaPacienteClienteRazaoSocial_Sel;
         AV128Wpdemonstrativopagamentods_33_tfpropostadescricao = AV14TFPropostaDescricao;
         AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV15TFPropostaDescricao_Sel;
         AV130Wpdemonstrativopagamentods_35_tfpropostavalor = AV16TFPropostaValor;
         AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV17TFPropostaValor_To;
         AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV18TFPropostaTaxaAdministrativa;
         AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV19TFPropostaTaxaAdministrativa_To;
         AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV76TFPropostaValorTaxa_F;
         AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV77TFPropostaValorTaxa_F_To;
         AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV22TFPropostaJurosMora;
         AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV23TFPropostaJurosMora_To;
         AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV80TFPropostaDataCreditoCliente_F;
         AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV81TFPropostaDataCreditoCliente_F_To;
         AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV78TFPropostaValorJurosMora_F;
         AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV79TFPropostaValorJurosMora_F_To;
         AV142Wpdemonstrativopagamentods_47_tfpropostasecusername = AV74TFPropostaSecUserName;
         AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV75TFPropostaSecUserName_Sel;
         AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV27TFPropostaStatus_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                              AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                              AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                              AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                              AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                              AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                              AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                              AV104Wpdemonstrativopagamentods_9_contratonome1 ,
                                              AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                              AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                              AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                              AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                              AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                              AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                              AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                              AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                              AV114Wpdemonstrativopagamentods_19_contratonome2 ,
                                              AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                              AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                              AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                              AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                              AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                              AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                              AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                              AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                              AV124Wpdemonstrativopagamentods_29_contratonome3 ,
                                              AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                              AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                              AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                              AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                              AV130Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                              AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                              AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                              AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                              AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                              AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                              AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                              AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                              AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                              AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                              AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels.Count ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A501PropostaTaxaAdministrativa ,
                                              A508PropostaJurosMora ,
                                              A512PropostaSecUserName ,
                                              AV96Wpdemonstrativopagamentods_1_filterfulltext ,
                                              A513PropostaValorTaxa_F ,
                                              A514PropostaValorJurosMora_F ,
                                              AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                              AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                              AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                              A515PropostaDataCreditoCliente_F ,
                                              AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                              AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                              AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV104Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV104Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV114Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV114Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV124Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV124Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial), "%", "");
         lV128Wpdemonstrativopagamentods_33_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV128Wpdemonstrativopagamentods_33_tfpropostadescricao), "%", "");
         lV142Wpdemonstrativopagamentods_47_tfpropostasecusername = StringUtil.Concat( StringUtil.RTrim( AV142Wpdemonstrativopagamentods_47_tfpropostasecusername), "%", "");
         /* Using cursor P00AK13 */
         pr_default.execute(2, new Object[] {AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV104Wpdemonstrativopagamentods_9_contratonome1, lV104Wpdemonstrativopagamentods_9_contratonome1, lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV114Wpdemonstrativopagamentods_19_contratonome2, lV114Wpdemonstrativopagamentods_19_contratonome2, lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV124Wpdemonstrativopagamentods_29_contratonome3, lV124Wpdemonstrativopagamentods_29_contratonome3, lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial, AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, lV128Wpdemonstrativopagamentods_33_tfpropostadescricao, AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, AV130Wpdemonstrativopagamentods_35_tfpropostavalor, AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to, AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa, AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to, AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f, AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to, AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora, AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to, lV142Wpdemonstrativopagamentods_47_tfpropostasecusername, AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAK6 = false;
            A227ContratoId = P00AK13_A227ContratoId[0];
            n227ContratoId = P00AK13_n227ContratoId[0];
            A493ConvenioCategoriaId = P00AK13_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00AK13_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = P00AK13_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AK13_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AK13_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AK13_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00AK13_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00AK13_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00AK13_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AK13_n642PropostaClinicaId[0];
            A512PropostaSecUserName = P00AK13_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AK13_n512PropostaSecUserName[0];
            A513PropostaValorTaxa_F = P00AK13_A513PropostaValorTaxa_F[0];
            A494ConvenioCategoriaDescricao = P00AK13_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AK13_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00AK13_A228ContratoNome[0];
            n228ContratoNome = P00AK13_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00AK13_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AK13_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P00AK13_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AK13_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P00AK13_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AK13_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P00AK13_A329PropostaStatus[0];
            n329PropostaStatus = P00AK13_n329PropostaStatus[0];
            A325PropostaDescricao = P00AK13_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AK13_n325PropostaDescricao[0];
            A505PropostaPacienteClienteRazaoSocial = P00AK13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AK13_n505PropostaPacienteClienteRazaoSocial[0];
            A501PropostaTaxaAdministrativa = P00AK13_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = P00AK13_n501PropostaTaxaAdministrativa[0];
            A323PropostaId = P00AK13_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00AK13_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AK13_n649PropostaMaxReembolsoId_F[0];
            A326PropostaValor = P00AK13_A326PropostaValor[0];
            n326PropostaValor = P00AK13_n326PropostaValor[0];
            A508PropostaJurosMora = P00AK13_A508PropostaJurosMora[0];
            n508PropostaJurosMora = P00AK13_n508PropostaJurosMora[0];
            A507PropostaSLA = P00AK13_A507PropostaSLA[0];
            n507PropostaSLA = P00AK13_n507PropostaSLA[0];
            A515PropostaDataCreditoCliente_F = P00AK13_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AK13_n515PropostaDataCreditoCliente_F[0];
            A228ContratoNome = P00AK13_A228ContratoNome[0];
            n228ContratoNome = P00AK13_n228ContratoNome[0];
            A494ConvenioCategoriaDescricao = P00AK13_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AK13_n494ConvenioCategoriaDescricao[0];
            A512PropostaSecUserName = P00AK13_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AK13_n512PropostaSecUserName[0];
            A540PropostaPacienteClienteDocumento = P00AK13_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AK13_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00AK13_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AK13_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P00AK13_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AK13_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00AK13_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AK13_n652PropostaClinicaDocumento[0];
            A515PropostaDataCreditoCliente_F = P00AK13_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AK13_n515PropostaDataCreditoCliente_F[0];
            A649PropostaMaxReembolsoId_F = P00AK13_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AK13_n649PropostaMaxReembolsoId_F[0];
            GXt_decimal1 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
            A514PropostaValorJurosMora_F = GXt_decimal1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wpdemonstrativopagamentods_1_filterfulltext)) || ( ( StringUtil.Like( A505PropostaPacienteClienteRazaoSocial , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A325PropostaDescricao , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A326PropostaValor, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A501PropostaTaxaAdministrativa, 16, 4) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A513PropostaValorTaxa_F, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A508PropostaJurosMora, 16, 4) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A514PropostaValorJurosMora_F, 18, 2) , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A512PropostaSecUserName , StringUtil.PadR( "%" + AV96Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "pendente aprovação" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) ) || ( StringUtil.Like( "em análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) ) || ( StringUtil.Like( "revisão" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) ) || ( StringUtil.Like( "cancelado" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) ) ||
            ( StringUtil.Like( "aguardando assinatura" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) ) || ( StringUtil.Like( "análise reprovada" , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) ) )
            )
            {
               if ( (Convert.ToDecimal(0)==AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f) || ( ( A514PropostaValorJurosMora_F >= AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to) || ( ( A514PropostaValorJurosMora_F <= AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ) ) )
                  {
                     AV44count = 0;
                     while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AK13_A512PropostaSecUserName[0], A512PropostaSecUserName) == 0 ) )
                     {
                        BRKAK6 = false;
                        A328PropostaCratedBy = P00AK13_A328PropostaCratedBy[0];
                        n328PropostaCratedBy = P00AK13_n328PropostaCratedBy[0];
                        A323PropostaId = P00AK13_A323PropostaId[0];
                        AV44count = (long)(AV44count+1);
                        BRKAK6 = true;
                        pr_default.readNext(2);
                     }
                     if ( (0==AV35SkipItems) )
                     {
                        AV39Option = (String.IsNullOrEmpty(StringUtil.RTrim( A512PropostaSecUserName)) ? "<#Empty#>" : A512PropostaSecUserName);
                        AV40Options.Add(AV39Option, 0);
                        AV43OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV40Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV35SkipItems = (short)(AV35SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRKAK6 )
            {
               BRKAK6 = true;
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
         AV53OptionsJson = "";
         AV54OptionsDescJson = "";
         AV55OptionIndexesJson = "";
         AV40Options = new GxSimpleCollection<string>();
         AV42OptionsDesc = new GxSimpleCollection<string>();
         AV43OptionIndexes = new GxSimpleCollection<string>();
         AV34SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV45Session = context.GetSession();
         AV47GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV48GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56FilterFullText = "";
         AV10TFPropostaPacienteClienteRazaoSocial = "";
         AV11TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV14TFPropostaDescricao = "";
         AV15TFPropostaDescricao_Sel = "";
         AV80TFPropostaDataCreditoCliente_F = DateTime.MinValue;
         AV81TFPropostaDataCreditoCliente_F_To = DateTime.MinValue;
         AV74TFPropostaSecUserName = "";
         AV75TFPropostaSecUserName_Sel = "";
         AV26TFPropostaStatus_SelsJson = "";
         AV27TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV49GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV57DynamicFiltersSelector1 = "";
         AV83PropostaResponsavelDocumento1 = "";
         AV84PropostaPacienteClienteDocumento1 = "";
         AV85PropostaClinicaDocumento1 = "";
         AV59PropostaPacienteClienteRazaoSocial1 = "";
         AV60ContratoNome1 = "";
         AV61ConvenioCategoriaDescricao1 = "";
         AV63DynamicFiltersSelector2 = "";
         AV87PropostaResponsavelDocumento2 = "";
         AV88PropostaPacienteClienteDocumento2 = "";
         AV89PropostaClinicaDocumento2 = "";
         AV65PropostaPacienteClienteRazaoSocial2 = "";
         AV66ContratoNome2 = "";
         AV67ConvenioCategoriaDescricao2 = "";
         AV69DynamicFiltersSelector3 = "";
         AV91PropostaResponsavelDocumento3 = "";
         AV92PropostaPacienteClienteDocumento3 = "";
         AV93PropostaClinicaDocumento3 = "";
         AV71PropostaPacienteClienteRazaoSocial3 = "";
         AV72ContratoNome3 = "";
         AV73ConvenioCategoriaDescricao3 = "";
         AV96Wpdemonstrativopagamentods_1_filterfulltext = "";
         AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = "";
         AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = "";
         AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = "";
         AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = "";
         AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = "";
         AV104Wpdemonstrativopagamentods_9_contratonome1 = "";
         AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = "";
         AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = "";
         AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = "";
         AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = "";
         AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = "";
         AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = "";
         AV114Wpdemonstrativopagamentods_19_contratonome2 = "";
         AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = "";
         AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = "";
         AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = "";
         AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = "";
         AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = "";
         AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = "";
         AV124Wpdemonstrativopagamentods_29_contratonome3 = "";
         AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = "";
         AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = "";
         AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = "";
         AV128Wpdemonstrativopagamentods_33_tfpropostadescricao = "";
         AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = "";
         AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = DateTime.MinValue;
         AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = DateTime.MinValue;
         AV142Wpdemonstrativopagamentods_47_tfpropostasecusername = "";
         AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = "";
         AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV96Wpdemonstrativopagamentods_1_filterfulltext = "";
         lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = "";
         lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = "";
         lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = "";
         lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = "";
         lV104Wpdemonstrativopagamentods_9_contratonome1 = "";
         lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = "";
         lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = "";
         lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = "";
         lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = "";
         lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = "";
         lV114Wpdemonstrativopagamentods_19_contratonome2 = "";
         lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = "";
         lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = "";
         lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = "";
         lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = "";
         lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = "";
         lV124Wpdemonstrativopagamentods_29_contratonome3 = "";
         lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = "";
         lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = "";
         lV128Wpdemonstrativopagamentods_33_tfpropostadescricao = "";
         lV142Wpdemonstrativopagamentods_47_tfpropostasecusername = "";
         A329PropostaStatus = "";
         A580PropostaResponsavelDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         A652PropostaClinicaDocumento = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A228ContratoNome = "";
         A494ConvenioCategoriaDescricao = "";
         A325PropostaDescricao = "";
         A512PropostaSecUserName = "";
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         P00AK5_A227ContratoId = new int[1] ;
         P00AK5_n227ContratoId = new bool[] {false} ;
         P00AK5_A493ConvenioCategoriaId = new int[1] ;
         P00AK5_n493ConvenioCategoriaId = new bool[] {false} ;
         P00AK5_A328PropostaCratedBy = new short[1] ;
         P00AK5_n328PropostaCratedBy = new bool[] {false} ;
         P00AK5_A504PropostaPacienteClienteId = new int[1] ;
         P00AK5_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AK5_A553PropostaResponsavelId = new int[1] ;
         P00AK5_n553PropostaResponsavelId = new bool[] {false} ;
         P00AK5_A642PropostaClinicaId = new int[1] ;
         P00AK5_n642PropostaClinicaId = new bool[] {false} ;
         P00AK5_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AK5_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AK5_A513PropostaValorTaxa_F = new decimal[1] ;
         P00AK5_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00AK5_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00AK5_A228ContratoNome = new string[] {""} ;
         P00AK5_n228ContratoNome = new bool[] {false} ;
         P00AK5_A652PropostaClinicaDocumento = new string[] {""} ;
         P00AK5_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00AK5_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00AK5_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00AK5_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00AK5_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00AK5_A329PropostaStatus = new string[] {""} ;
         P00AK5_n329PropostaStatus = new bool[] {false} ;
         P00AK5_A512PropostaSecUserName = new string[] {""} ;
         P00AK5_n512PropostaSecUserName = new bool[] {false} ;
         P00AK5_A325PropostaDescricao = new string[] {""} ;
         P00AK5_n325PropostaDescricao = new bool[] {false} ;
         P00AK5_A501PropostaTaxaAdministrativa = new decimal[1] ;
         P00AK5_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         P00AK5_A323PropostaId = new int[1] ;
         P00AK5_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00AK5_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P00AK5_A326PropostaValor = new decimal[1] ;
         P00AK5_n326PropostaValor = new bool[] {false} ;
         P00AK5_A508PropostaJurosMora = new decimal[1] ;
         P00AK5_n508PropostaJurosMora = new bool[] {false} ;
         P00AK5_A507PropostaSLA = new short[1] ;
         P00AK5_n507PropostaSLA = new bool[] {false} ;
         P00AK5_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         P00AK5_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         AV39Option = "";
         P00AK9_A227ContratoId = new int[1] ;
         P00AK9_n227ContratoId = new bool[] {false} ;
         P00AK9_A493ConvenioCategoriaId = new int[1] ;
         P00AK9_n493ConvenioCategoriaId = new bool[] {false} ;
         P00AK9_A328PropostaCratedBy = new short[1] ;
         P00AK9_n328PropostaCratedBy = new bool[] {false} ;
         P00AK9_A504PropostaPacienteClienteId = new int[1] ;
         P00AK9_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AK9_A553PropostaResponsavelId = new int[1] ;
         P00AK9_n553PropostaResponsavelId = new bool[] {false} ;
         P00AK9_A642PropostaClinicaId = new int[1] ;
         P00AK9_n642PropostaClinicaId = new bool[] {false} ;
         P00AK9_A325PropostaDescricao = new string[] {""} ;
         P00AK9_n325PropostaDescricao = new bool[] {false} ;
         P00AK9_A513PropostaValorTaxa_F = new decimal[1] ;
         P00AK9_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00AK9_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00AK9_A228ContratoNome = new string[] {""} ;
         P00AK9_n228ContratoNome = new bool[] {false} ;
         P00AK9_A652PropostaClinicaDocumento = new string[] {""} ;
         P00AK9_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00AK9_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00AK9_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00AK9_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00AK9_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00AK9_A329PropostaStatus = new string[] {""} ;
         P00AK9_n329PropostaStatus = new bool[] {false} ;
         P00AK9_A512PropostaSecUserName = new string[] {""} ;
         P00AK9_n512PropostaSecUserName = new bool[] {false} ;
         P00AK9_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AK9_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AK9_A501PropostaTaxaAdministrativa = new decimal[1] ;
         P00AK9_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         P00AK9_A323PropostaId = new int[1] ;
         P00AK9_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00AK9_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P00AK9_A326PropostaValor = new decimal[1] ;
         P00AK9_n326PropostaValor = new bool[] {false} ;
         P00AK9_A508PropostaJurosMora = new decimal[1] ;
         P00AK9_n508PropostaJurosMora = new bool[] {false} ;
         P00AK9_A507PropostaSLA = new short[1] ;
         P00AK9_n507PropostaSLA = new bool[] {false} ;
         P00AK9_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         P00AK9_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         P00AK13_A227ContratoId = new int[1] ;
         P00AK13_n227ContratoId = new bool[] {false} ;
         P00AK13_A493ConvenioCategoriaId = new int[1] ;
         P00AK13_n493ConvenioCategoriaId = new bool[] {false} ;
         P00AK13_A328PropostaCratedBy = new short[1] ;
         P00AK13_n328PropostaCratedBy = new bool[] {false} ;
         P00AK13_A504PropostaPacienteClienteId = new int[1] ;
         P00AK13_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AK13_A553PropostaResponsavelId = new int[1] ;
         P00AK13_n553PropostaResponsavelId = new bool[] {false} ;
         P00AK13_A642PropostaClinicaId = new int[1] ;
         P00AK13_n642PropostaClinicaId = new bool[] {false} ;
         P00AK13_A512PropostaSecUserName = new string[] {""} ;
         P00AK13_n512PropostaSecUserName = new bool[] {false} ;
         P00AK13_A513PropostaValorTaxa_F = new decimal[1] ;
         P00AK13_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00AK13_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00AK13_A228ContratoNome = new string[] {""} ;
         P00AK13_n228ContratoNome = new bool[] {false} ;
         P00AK13_A652PropostaClinicaDocumento = new string[] {""} ;
         P00AK13_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00AK13_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00AK13_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00AK13_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00AK13_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00AK13_A329PropostaStatus = new string[] {""} ;
         P00AK13_n329PropostaStatus = new bool[] {false} ;
         P00AK13_A325PropostaDescricao = new string[] {""} ;
         P00AK13_n325PropostaDescricao = new bool[] {false} ;
         P00AK13_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AK13_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AK13_A501PropostaTaxaAdministrativa = new decimal[1] ;
         P00AK13_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         P00AK13_A323PropostaId = new int[1] ;
         P00AK13_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00AK13_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P00AK13_A326PropostaValor = new decimal[1] ;
         P00AK13_n326PropostaValor = new bool[] {false} ;
         P00AK13_A508PropostaJurosMora = new decimal[1] ;
         P00AK13_n508PropostaJurosMora = new bool[] {false} ;
         P00AK13_A507PropostaSLA = new short[1] ;
         P00AK13_n507PropostaSLA = new bool[] {false} ;
         P00AK13_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         P00AK13_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdemonstrativopagamentogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AK5_A227ContratoId, P00AK5_n227ContratoId, P00AK5_A493ConvenioCategoriaId, P00AK5_n493ConvenioCategoriaId, P00AK5_A328PropostaCratedBy, P00AK5_n328PropostaCratedBy, P00AK5_A504PropostaPacienteClienteId, P00AK5_n504PropostaPacienteClienteId, P00AK5_A553PropostaResponsavelId, P00AK5_n553PropostaResponsavelId,
               P00AK5_A642PropostaClinicaId, P00AK5_n642PropostaClinicaId, P00AK5_A505PropostaPacienteClienteRazaoSocial, P00AK5_n505PropostaPacienteClienteRazaoSocial, P00AK5_A513PropostaValorTaxa_F, P00AK5_A494ConvenioCategoriaDescricao, P00AK5_n494ConvenioCategoriaDescricao, P00AK5_A228ContratoNome, P00AK5_n228ContratoNome, P00AK5_A652PropostaClinicaDocumento,
               P00AK5_n652PropostaClinicaDocumento, P00AK5_A540PropostaPacienteClienteDocumento, P00AK5_n540PropostaPacienteClienteDocumento, P00AK5_A580PropostaResponsavelDocumento, P00AK5_n580PropostaResponsavelDocumento, P00AK5_A329PropostaStatus, P00AK5_n329PropostaStatus, P00AK5_A512PropostaSecUserName, P00AK5_n512PropostaSecUserName, P00AK5_A325PropostaDescricao,
               P00AK5_n325PropostaDescricao, P00AK5_A501PropostaTaxaAdministrativa, P00AK5_n501PropostaTaxaAdministrativa, P00AK5_A323PropostaId, P00AK5_A649PropostaMaxReembolsoId_F, P00AK5_n649PropostaMaxReembolsoId_F, P00AK5_A326PropostaValor, P00AK5_n326PropostaValor, P00AK5_A508PropostaJurosMora, P00AK5_n508PropostaJurosMora,
               P00AK5_A507PropostaSLA, P00AK5_n507PropostaSLA, P00AK5_A515PropostaDataCreditoCliente_F, P00AK5_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               P00AK9_A227ContratoId, P00AK9_n227ContratoId, P00AK9_A493ConvenioCategoriaId, P00AK9_n493ConvenioCategoriaId, P00AK9_A328PropostaCratedBy, P00AK9_n328PropostaCratedBy, P00AK9_A504PropostaPacienteClienteId, P00AK9_n504PropostaPacienteClienteId, P00AK9_A553PropostaResponsavelId, P00AK9_n553PropostaResponsavelId,
               P00AK9_A642PropostaClinicaId, P00AK9_n642PropostaClinicaId, P00AK9_A325PropostaDescricao, P00AK9_n325PropostaDescricao, P00AK9_A513PropostaValorTaxa_F, P00AK9_A494ConvenioCategoriaDescricao, P00AK9_n494ConvenioCategoriaDescricao, P00AK9_A228ContratoNome, P00AK9_n228ContratoNome, P00AK9_A652PropostaClinicaDocumento,
               P00AK9_n652PropostaClinicaDocumento, P00AK9_A540PropostaPacienteClienteDocumento, P00AK9_n540PropostaPacienteClienteDocumento, P00AK9_A580PropostaResponsavelDocumento, P00AK9_n580PropostaResponsavelDocumento, P00AK9_A329PropostaStatus, P00AK9_n329PropostaStatus, P00AK9_A512PropostaSecUserName, P00AK9_n512PropostaSecUserName, P00AK9_A505PropostaPacienteClienteRazaoSocial,
               P00AK9_n505PropostaPacienteClienteRazaoSocial, P00AK9_A501PropostaTaxaAdministrativa, P00AK9_n501PropostaTaxaAdministrativa, P00AK9_A323PropostaId, P00AK9_A649PropostaMaxReembolsoId_F, P00AK9_n649PropostaMaxReembolsoId_F, P00AK9_A326PropostaValor, P00AK9_n326PropostaValor, P00AK9_A508PropostaJurosMora, P00AK9_n508PropostaJurosMora,
               P00AK9_A507PropostaSLA, P00AK9_n507PropostaSLA, P00AK9_A515PropostaDataCreditoCliente_F, P00AK9_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               P00AK13_A227ContratoId, P00AK13_n227ContratoId, P00AK13_A493ConvenioCategoriaId, P00AK13_n493ConvenioCategoriaId, P00AK13_A328PropostaCratedBy, P00AK13_n328PropostaCratedBy, P00AK13_A504PropostaPacienteClienteId, P00AK13_n504PropostaPacienteClienteId, P00AK13_A553PropostaResponsavelId, P00AK13_n553PropostaResponsavelId,
               P00AK13_A642PropostaClinicaId, P00AK13_n642PropostaClinicaId, P00AK13_A512PropostaSecUserName, P00AK13_n512PropostaSecUserName, P00AK13_A513PropostaValorTaxa_F, P00AK13_A494ConvenioCategoriaDescricao, P00AK13_n494ConvenioCategoriaDescricao, P00AK13_A228ContratoNome, P00AK13_n228ContratoNome, P00AK13_A652PropostaClinicaDocumento,
               P00AK13_n652PropostaClinicaDocumento, P00AK13_A540PropostaPacienteClienteDocumento, P00AK13_n540PropostaPacienteClienteDocumento, P00AK13_A580PropostaResponsavelDocumento, P00AK13_n580PropostaResponsavelDocumento, P00AK13_A329PropostaStatus, P00AK13_n329PropostaStatus, P00AK13_A325PropostaDescricao, P00AK13_n325PropostaDescricao, P00AK13_A505PropostaPacienteClienteRazaoSocial,
               P00AK13_n505PropostaPacienteClienteRazaoSocial, P00AK13_A501PropostaTaxaAdministrativa, P00AK13_n501PropostaTaxaAdministrativa, P00AK13_A323PropostaId, P00AK13_A649PropostaMaxReembolsoId_F, P00AK13_n649PropostaMaxReembolsoId_F, P00AK13_A326PropostaValor, P00AK13_n326PropostaValor, P00AK13_A508PropostaJurosMora, P00AK13_n508PropostaJurosMora,
               P00AK13_A507PropostaSLA, P00AK13_n507PropostaSLA, P00AK13_A515PropostaDataCreditoCliente_F, P00AK13_n515PropostaDataCreditoCliente_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV37MaxItems ;
      private short AV36PageIndex ;
      private short AV35SkipItems ;
      private short AV58DynamicFiltersOperator1 ;
      private short AV64DynamicFiltersOperator2 ;
      private short AV70DynamicFiltersOperator3 ;
      private short AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ;
      private short AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ;
      private short AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ;
      private short A328PropostaCratedBy ;
      private short A507PropostaSLA ;
      private int AV94GXV1 ;
      private int AV82PropostaMaxReembolsoId_F1 ;
      private int AV86PropostaMaxReembolsoId_F2 ;
      private int AV90PropostaMaxReembolsoId_F3 ;
      private int AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ;
      private int AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ;
      private int AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ;
      private int AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A227ContratoId ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A323PropostaId ;
      private long AV44count ;
      private decimal AV16TFPropostaValor ;
      private decimal AV17TFPropostaValor_To ;
      private decimal AV18TFPropostaTaxaAdministrativa ;
      private decimal AV19TFPropostaTaxaAdministrativa_To ;
      private decimal AV76TFPropostaValorTaxa_F ;
      private decimal AV77TFPropostaValorTaxa_F_To ;
      private decimal AV22TFPropostaJurosMora ;
      private decimal AV23TFPropostaJurosMora_To ;
      private decimal AV78TFPropostaValorJurosMora_F ;
      private decimal AV79TFPropostaValorJurosMora_F_To ;
      private decimal AV130Wpdemonstrativopagamentods_35_tfpropostavalor ;
      private decimal AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ;
      private decimal AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ;
      private decimal AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ;
      private decimal AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ;
      private decimal AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ;
      private decimal AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ;
      private decimal AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ;
      private decimal AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ;
      private decimal AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ;
      private decimal A326PropostaValor ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A508PropostaJurosMora ;
      private decimal A513PropostaValorTaxa_F ;
      private decimal A514PropostaValorJurosMora_F ;
      private decimal GXt_decimal1 ;
      private DateTime AV80TFPropostaDataCreditoCliente_F ;
      private DateTime AV81TFPropostaDataCreditoCliente_F_To ;
      private DateTime AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ;
      private DateTime AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ;
      private DateTime A515PropostaDataCreditoCliente_F ;
      private bool returnInSub ;
      private bool AV62DynamicFiltersEnabled2 ;
      private bool AV68DynamicFiltersEnabled3 ;
      private bool AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ;
      private bool AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ;
      private bool BRKAK2 ;
      private bool n227ContratoId ;
      private bool n493ConvenioCategoriaId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n228ContratoNome ;
      private bool n652PropostaClinicaDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n329PropostaStatus ;
      private bool n512PropostaSecUserName ;
      private bool n325PropostaDescricao ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n326PropostaValor ;
      private bool n508PropostaJurosMora ;
      private bool n507PropostaSLA ;
      private bool n515PropostaDataCreditoCliente_F ;
      private bool BRKAK4 ;
      private bool BRKAK6 ;
      private string AV53OptionsJson ;
      private string AV54OptionsDescJson ;
      private string AV55OptionIndexesJson ;
      private string AV26TFPropostaStatus_SelsJson ;
      private string AV50DDOName ;
      private string AV51SearchTxtParms ;
      private string AV52SearchTxtTo ;
      private string AV34SearchTxt ;
      private string AV56FilterFullText ;
      private string AV10TFPropostaPacienteClienteRazaoSocial ;
      private string AV11TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV14TFPropostaDescricao ;
      private string AV15TFPropostaDescricao_Sel ;
      private string AV74TFPropostaSecUserName ;
      private string AV75TFPropostaSecUserName_Sel ;
      private string AV57DynamicFiltersSelector1 ;
      private string AV83PropostaResponsavelDocumento1 ;
      private string AV84PropostaPacienteClienteDocumento1 ;
      private string AV85PropostaClinicaDocumento1 ;
      private string AV59PropostaPacienteClienteRazaoSocial1 ;
      private string AV60ContratoNome1 ;
      private string AV61ConvenioCategoriaDescricao1 ;
      private string AV63DynamicFiltersSelector2 ;
      private string AV87PropostaResponsavelDocumento2 ;
      private string AV88PropostaPacienteClienteDocumento2 ;
      private string AV89PropostaClinicaDocumento2 ;
      private string AV65PropostaPacienteClienteRazaoSocial2 ;
      private string AV66ContratoNome2 ;
      private string AV67ConvenioCategoriaDescricao2 ;
      private string AV69DynamicFiltersSelector3 ;
      private string AV91PropostaResponsavelDocumento3 ;
      private string AV92PropostaPacienteClienteDocumento3 ;
      private string AV93PropostaClinicaDocumento3 ;
      private string AV71PropostaPacienteClienteRazaoSocial3 ;
      private string AV72ContratoNome3 ;
      private string AV73ConvenioCategoriaDescricao3 ;
      private string AV96Wpdemonstrativopagamentods_1_filterfulltext ;
      private string AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ;
      private string AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ;
      private string AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ;
      private string AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ;
      private string AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ;
      private string AV104Wpdemonstrativopagamentods_9_contratonome1 ;
      private string AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ;
      private string AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ;
      private string AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ;
      private string AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ;
      private string AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ;
      private string AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ;
      private string AV114Wpdemonstrativopagamentods_19_contratonome2 ;
      private string AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ;
      private string AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ;
      private string AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ;
      private string AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ;
      private string AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ;
      private string AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ;
      private string AV124Wpdemonstrativopagamentods_29_contratonome3 ;
      private string AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ;
      private string AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ;
      private string AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ;
      private string AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ;
      private string AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ;
      private string AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ;
      private string AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ;
      private string lV96Wpdemonstrativopagamentods_1_filterfulltext ;
      private string lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ;
      private string lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ;
      private string lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ;
      private string lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ;
      private string lV104Wpdemonstrativopagamentods_9_contratonome1 ;
      private string lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ;
      private string lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ;
      private string lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ;
      private string lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ;
      private string lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ;
      private string lV114Wpdemonstrativopagamentods_19_contratonome2 ;
      private string lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ;
      private string lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ;
      private string lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ;
      private string lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ;
      private string lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ;
      private string lV124Wpdemonstrativopagamentods_29_contratonome3 ;
      private string lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ;
      private string lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ;
      private string lV128Wpdemonstrativopagamentods_33_tfpropostadescricao ;
      private string lV142Wpdemonstrativopagamentods_47_tfpropostasecusername ;
      private string A329PropostaStatus ;
      private string A580PropostaResponsavelDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A228ContratoNome ;
      private string A494ConvenioCategoriaDescricao ;
      private string A325PropostaDescricao ;
      private string A512PropostaSecUserName ;
      private string AV39Option ;
      private IGxSession AV45Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV40Options ;
      private GxSimpleCollection<string> AV42OptionsDesc ;
      private GxSimpleCollection<string> AV43OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV47GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV48GridStateFilterValue ;
      private GxSimpleCollection<string> AV27TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV49GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00AK5_A227ContratoId ;
      private bool[] P00AK5_n227ContratoId ;
      private int[] P00AK5_A493ConvenioCategoriaId ;
      private bool[] P00AK5_n493ConvenioCategoriaId ;
      private short[] P00AK5_A328PropostaCratedBy ;
      private bool[] P00AK5_n328PropostaCratedBy ;
      private int[] P00AK5_A504PropostaPacienteClienteId ;
      private bool[] P00AK5_n504PropostaPacienteClienteId ;
      private int[] P00AK5_A553PropostaResponsavelId ;
      private bool[] P00AK5_n553PropostaResponsavelId ;
      private int[] P00AK5_A642PropostaClinicaId ;
      private bool[] P00AK5_n642PropostaClinicaId ;
      private string[] P00AK5_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AK5_n505PropostaPacienteClienteRazaoSocial ;
      private decimal[] P00AK5_A513PropostaValorTaxa_F ;
      private string[] P00AK5_A494ConvenioCategoriaDescricao ;
      private bool[] P00AK5_n494ConvenioCategoriaDescricao ;
      private string[] P00AK5_A228ContratoNome ;
      private bool[] P00AK5_n228ContratoNome ;
      private string[] P00AK5_A652PropostaClinicaDocumento ;
      private bool[] P00AK5_n652PropostaClinicaDocumento ;
      private string[] P00AK5_A540PropostaPacienteClienteDocumento ;
      private bool[] P00AK5_n540PropostaPacienteClienteDocumento ;
      private string[] P00AK5_A580PropostaResponsavelDocumento ;
      private bool[] P00AK5_n580PropostaResponsavelDocumento ;
      private string[] P00AK5_A329PropostaStatus ;
      private bool[] P00AK5_n329PropostaStatus ;
      private string[] P00AK5_A512PropostaSecUserName ;
      private bool[] P00AK5_n512PropostaSecUserName ;
      private string[] P00AK5_A325PropostaDescricao ;
      private bool[] P00AK5_n325PropostaDescricao ;
      private decimal[] P00AK5_A501PropostaTaxaAdministrativa ;
      private bool[] P00AK5_n501PropostaTaxaAdministrativa ;
      private int[] P00AK5_A323PropostaId ;
      private int[] P00AK5_A649PropostaMaxReembolsoId_F ;
      private bool[] P00AK5_n649PropostaMaxReembolsoId_F ;
      private decimal[] P00AK5_A326PropostaValor ;
      private bool[] P00AK5_n326PropostaValor ;
      private decimal[] P00AK5_A508PropostaJurosMora ;
      private bool[] P00AK5_n508PropostaJurosMora ;
      private short[] P00AK5_A507PropostaSLA ;
      private bool[] P00AK5_n507PropostaSLA ;
      private DateTime[] P00AK5_A515PropostaDataCreditoCliente_F ;
      private bool[] P00AK5_n515PropostaDataCreditoCliente_F ;
      private int[] P00AK9_A227ContratoId ;
      private bool[] P00AK9_n227ContratoId ;
      private int[] P00AK9_A493ConvenioCategoriaId ;
      private bool[] P00AK9_n493ConvenioCategoriaId ;
      private short[] P00AK9_A328PropostaCratedBy ;
      private bool[] P00AK9_n328PropostaCratedBy ;
      private int[] P00AK9_A504PropostaPacienteClienteId ;
      private bool[] P00AK9_n504PropostaPacienteClienteId ;
      private int[] P00AK9_A553PropostaResponsavelId ;
      private bool[] P00AK9_n553PropostaResponsavelId ;
      private int[] P00AK9_A642PropostaClinicaId ;
      private bool[] P00AK9_n642PropostaClinicaId ;
      private string[] P00AK9_A325PropostaDescricao ;
      private bool[] P00AK9_n325PropostaDescricao ;
      private decimal[] P00AK9_A513PropostaValorTaxa_F ;
      private string[] P00AK9_A494ConvenioCategoriaDescricao ;
      private bool[] P00AK9_n494ConvenioCategoriaDescricao ;
      private string[] P00AK9_A228ContratoNome ;
      private bool[] P00AK9_n228ContratoNome ;
      private string[] P00AK9_A652PropostaClinicaDocumento ;
      private bool[] P00AK9_n652PropostaClinicaDocumento ;
      private string[] P00AK9_A540PropostaPacienteClienteDocumento ;
      private bool[] P00AK9_n540PropostaPacienteClienteDocumento ;
      private string[] P00AK9_A580PropostaResponsavelDocumento ;
      private bool[] P00AK9_n580PropostaResponsavelDocumento ;
      private string[] P00AK9_A329PropostaStatus ;
      private bool[] P00AK9_n329PropostaStatus ;
      private string[] P00AK9_A512PropostaSecUserName ;
      private bool[] P00AK9_n512PropostaSecUserName ;
      private string[] P00AK9_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AK9_n505PropostaPacienteClienteRazaoSocial ;
      private decimal[] P00AK9_A501PropostaTaxaAdministrativa ;
      private bool[] P00AK9_n501PropostaTaxaAdministrativa ;
      private int[] P00AK9_A323PropostaId ;
      private int[] P00AK9_A649PropostaMaxReembolsoId_F ;
      private bool[] P00AK9_n649PropostaMaxReembolsoId_F ;
      private decimal[] P00AK9_A326PropostaValor ;
      private bool[] P00AK9_n326PropostaValor ;
      private decimal[] P00AK9_A508PropostaJurosMora ;
      private bool[] P00AK9_n508PropostaJurosMora ;
      private short[] P00AK9_A507PropostaSLA ;
      private bool[] P00AK9_n507PropostaSLA ;
      private DateTime[] P00AK9_A515PropostaDataCreditoCliente_F ;
      private bool[] P00AK9_n515PropostaDataCreditoCliente_F ;
      private int[] P00AK13_A227ContratoId ;
      private bool[] P00AK13_n227ContratoId ;
      private int[] P00AK13_A493ConvenioCategoriaId ;
      private bool[] P00AK13_n493ConvenioCategoriaId ;
      private short[] P00AK13_A328PropostaCratedBy ;
      private bool[] P00AK13_n328PropostaCratedBy ;
      private int[] P00AK13_A504PropostaPacienteClienteId ;
      private bool[] P00AK13_n504PropostaPacienteClienteId ;
      private int[] P00AK13_A553PropostaResponsavelId ;
      private bool[] P00AK13_n553PropostaResponsavelId ;
      private int[] P00AK13_A642PropostaClinicaId ;
      private bool[] P00AK13_n642PropostaClinicaId ;
      private string[] P00AK13_A512PropostaSecUserName ;
      private bool[] P00AK13_n512PropostaSecUserName ;
      private decimal[] P00AK13_A513PropostaValorTaxa_F ;
      private string[] P00AK13_A494ConvenioCategoriaDescricao ;
      private bool[] P00AK13_n494ConvenioCategoriaDescricao ;
      private string[] P00AK13_A228ContratoNome ;
      private bool[] P00AK13_n228ContratoNome ;
      private string[] P00AK13_A652PropostaClinicaDocumento ;
      private bool[] P00AK13_n652PropostaClinicaDocumento ;
      private string[] P00AK13_A540PropostaPacienteClienteDocumento ;
      private bool[] P00AK13_n540PropostaPacienteClienteDocumento ;
      private string[] P00AK13_A580PropostaResponsavelDocumento ;
      private bool[] P00AK13_n580PropostaResponsavelDocumento ;
      private string[] P00AK13_A329PropostaStatus ;
      private bool[] P00AK13_n329PropostaStatus ;
      private string[] P00AK13_A325PropostaDescricao ;
      private bool[] P00AK13_n325PropostaDescricao ;
      private string[] P00AK13_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AK13_n505PropostaPacienteClienteRazaoSocial ;
      private decimal[] P00AK13_A501PropostaTaxaAdministrativa ;
      private bool[] P00AK13_n501PropostaTaxaAdministrativa ;
      private int[] P00AK13_A323PropostaId ;
      private int[] P00AK13_A649PropostaMaxReembolsoId_F ;
      private bool[] P00AK13_n649PropostaMaxReembolsoId_F ;
      private decimal[] P00AK13_A326PropostaValor ;
      private bool[] P00AK13_n326PropostaValor ;
      private decimal[] P00AK13_A508PropostaJurosMora ;
      private bool[] P00AK13_n508PropostaJurosMora ;
      private short[] P00AK13_A507PropostaSLA ;
      private bool[] P00AK13_n507PropostaSLA ;
      private DateTime[] P00AK13_A515PropostaDataCreditoCliente_F ;
      private bool[] P00AK13_n515PropostaDataCreditoCliente_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpdemonstrativopagamentogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AK5( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                             string AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                             short AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                             string AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                             string AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                             string AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                             string AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                             string AV104Wpdemonstrativopagamentods_9_contratonome1 ,
                                             string AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                             bool AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                             string AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                             short AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                             string AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                             string AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                             string AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                             string AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                             string AV114Wpdemonstrativopagamentods_19_contratonome2 ,
                                             string AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                             bool AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                             string AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                             short AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                             string AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                             string AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                             string AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                             string AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                             string AV124Wpdemonstrativopagamentods_29_contratonome3 ,
                                             string AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                             string AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                             string AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                             string AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                             decimal AV130Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                             decimal AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                             decimal AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                             decimal AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                             decimal AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                             decimal AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                             decimal AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                             decimal AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                             string AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                             string AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                             int AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             decimal A501PropostaTaxaAdministrativa ,
                                             decimal A508PropostaJurosMora ,
                                             string A512PropostaSecUserName ,
                                             string AV96Wpdemonstrativopagamentods_1_filterfulltext ,
                                             decimal A513PropostaValorTaxa_F ,
                                             decimal A514PropostaValorJurosMora_F ,
                                             int AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                             int AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                             DateTime AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                             DateTime A515PropostaDataCreditoCliente_F ,
                                             DateTime AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                             decimal AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                             decimal AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[96];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ConvenioCategoriaId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, CAST(COALESCE( T1.PropostaValor, 0) * CAST(( CAST(COALESCE( T1.PropostaTaxaAdministrativa, 0) AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10)) AS PropostaValorTaxa_F, T3.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T4.SecUserFullName AS PropostaSecUserName, T1.PropostaDescricao, T1.PropostaTaxaAdministrativa, T1.PropostaId, COALESCE( T9.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, T1.PropostaValor, T1.PropostaJurosMora, T1.PropostaSLA, COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM ((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(COALESCE( T15.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T10.TituloPropostaId AS TituloPropostaId FROM ((((Titulo T10 LEFT JOIN NotaFiscalParcelamento T11 ON T11.NotaFiscalParcelamentoID = T10.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T12 ON T12.NotaFiscalId = T11.NotaFiscalId)";
         scmdbuf += " LEFT JOIN Proposta T13 ON T13.PropostaId = T10.TituloPropostaId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T10.TituloId = TituloId GROUP BY TituloId ) T15 ON T15.TituloId = T10.TituloId),  Proposta T14 WHERE (T1.PropostaId = T10.TituloPropostaId) AND (T12.ClienteId = T13.PropostaPacienteClienteId) AND (T10.TituloPropostaId = T14.PropostaId) AND (T10.TituloTipo = ( 'DEBITO')) GROUP BY T10.TituloPropostaId ) T8 ON T8.TituloPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T9 ON T9.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 0 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 1 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 2 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 0 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 1 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 2 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 0 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 1 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 2 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') >= :AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente))");
         AddWhere(sWhereString, "((:AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') <= :AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente))");
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV104Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV104Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int2[64] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int2[65] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV114Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int2[66] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV114Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int2[67] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int2[68] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int2[69] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int2[70] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int2[71] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int2[72] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int2[73] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int2[74] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int2[75] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int2[76] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int2[77] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV124Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int2[78] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV124Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int2[79] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int2[80] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int2[81] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz)");
         }
         else
         {
            GXv_int2[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz))");
         }
         else
         {
            GXv_int2[83] = 1;
         }
         if ( StringUtil.StrCmp(AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_33_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV128Wpdemonstrativopagamentods_33_tfpropostadescricao)");
         }
         else
         {
            GXv_int2[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int2[85] = 1;
         }
         if ( StringUtil.StrCmp(AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV130Wpdemonstrativopagamentods_35_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV130Wpdemonstrativopagamentods_35_tfpropostavalor)");
         }
         else
         {
            GXv_int2[86] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to)");
         }
         else
         {
            GXv_int2[87] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa >= :AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int2[88] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa <= :AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int2[89] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) >= :AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f)");
         }
         else
         {
            GXv_int2[90] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) <= :AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to)");
         }
         else
         {
            GXv_int2[91] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora >= :AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora)");
         }
         else
         {
            GXv_int2[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora <= :AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to)");
         }
         else
         {
            GXv_int2[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wpdemonstrativopagamentods_47_tfpropostasecusername)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName like :lV142Wpdemonstrativopagamentods_47_tfpropostasecusername)");
         }
         else
         {
            GXv_int2[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ! ( StringUtil.StrCmp(AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName = ( :AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel))");
         }
         else
         {
            GXv_int2[95] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T4.SecUserFullName))=0))");
         }
         if ( AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AK9( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                             string AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                             short AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                             string AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                             string AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                             string AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                             string AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                             string AV104Wpdemonstrativopagamentods_9_contratonome1 ,
                                             string AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                             bool AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                             string AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                             short AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                             string AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                             string AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                             string AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                             string AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                             string AV114Wpdemonstrativopagamentods_19_contratonome2 ,
                                             string AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                             bool AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                             string AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                             short AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                             string AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                             string AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                             string AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                             string AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                             string AV124Wpdemonstrativopagamentods_29_contratonome3 ,
                                             string AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                             string AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                             string AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                             string AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                             decimal AV130Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                             decimal AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                             decimal AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                             decimal AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                             decimal AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                             decimal AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                             decimal AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                             decimal AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                             string AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                             string AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                             int AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             decimal A501PropostaTaxaAdministrativa ,
                                             decimal A508PropostaJurosMora ,
                                             string A512PropostaSecUserName ,
                                             string AV96Wpdemonstrativopagamentods_1_filterfulltext ,
                                             decimal A513PropostaValorTaxa_F ,
                                             decimal A514PropostaValorJurosMora_F ,
                                             int AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                             int AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                             DateTime AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                             DateTime A515PropostaDataCreditoCliente_F ,
                                             DateTime AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                             decimal AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                             decimal AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[96];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ConvenioCategoriaId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaDescricao, CAST(COALESCE( T1.PropostaValor, 0) * CAST(( CAST(COALESCE( T1.PropostaTaxaAdministrativa, 0) AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10)) AS PropostaValorTaxa_F, T3.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T4.SecUserFullName AS PropostaSecUserName, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaTaxaAdministrativa, T1.PropostaId, COALESCE( T9.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, T1.PropostaValor, T1.PropostaJurosMora, T1.PropostaSLA, COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM ((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(COALESCE( T15.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T10.TituloPropostaId AS TituloPropostaId FROM ((((Titulo T10 LEFT JOIN NotaFiscalParcelamento T11 ON T11.NotaFiscalParcelamentoID = T10.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T12 ON T12.NotaFiscalId = T11.NotaFiscalId)";
         scmdbuf += " LEFT JOIN Proposta T13 ON T13.PropostaId = T10.TituloPropostaId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T10.TituloId = TituloId GROUP BY TituloId ) T15 ON T15.TituloId = T10.TituloId),  Proposta T14 WHERE (T1.PropostaId = T10.TituloPropostaId) AND (T12.ClienteId = T13.PropostaPacienteClienteId) AND (T10.TituloPropostaId = T14.PropostaId) AND (T10.TituloTipo = ( 'DEBITO')) GROUP BY T10.TituloPropostaId ) T8 ON T8.TituloPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T9 ON T9.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 0 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 1 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 2 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 0 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 1 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 2 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 0 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 1 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 2 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') >= :AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente))");
         AddWhere(sWhereString, "((:AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') <= :AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente))");
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int4[46] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int4[47] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int4[48] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int4[49] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int4[50] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int4[51] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int4[52] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int4[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV104Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int4[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV104Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int4[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int4[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int4[57] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int4[58] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int4[59] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int4[60] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int4[61] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int4[62] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int4[63] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int4[64] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int4[65] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV114Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int4[66] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV114Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int4[67] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int4[68] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int4[69] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int4[70] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int4[71] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int4[72] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int4[73] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int4[74] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int4[75] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int4[76] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int4[77] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV124Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int4[78] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV124Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int4[79] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int4[80] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int4[81] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz)");
         }
         else
         {
            GXv_int4[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz))");
         }
         else
         {
            GXv_int4[83] = 1;
         }
         if ( StringUtil.StrCmp(AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_33_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV128Wpdemonstrativopagamentods_33_tfpropostadescricao)");
         }
         else
         {
            GXv_int4[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int4[85] = 1;
         }
         if ( StringUtil.StrCmp(AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV130Wpdemonstrativopagamentods_35_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV130Wpdemonstrativopagamentods_35_tfpropostavalor)");
         }
         else
         {
            GXv_int4[86] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to)");
         }
         else
         {
            GXv_int4[87] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa >= :AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int4[88] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa <= :AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int4[89] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) >= :AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f)");
         }
         else
         {
            GXv_int4[90] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) <= :AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to)");
         }
         else
         {
            GXv_int4[91] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora >= :AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora)");
         }
         else
         {
            GXv_int4[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora <= :AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to)");
         }
         else
         {
            GXv_int4[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wpdemonstrativopagamentods_47_tfpropostasecusername)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName like :lV142Wpdemonstrativopagamentods_47_tfpropostasecusername)");
         }
         else
         {
            GXv_int4[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ! ( StringUtil.StrCmp(AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName = ( :AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel))");
         }
         else
         {
            GXv_int4[95] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T4.SecUserFullName))=0))");
         }
         if ( AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaDescricao";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AK13( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                              string AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                              short AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                              string AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                              string AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                              string AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                              string AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                              string AV104Wpdemonstrativopagamentods_9_contratonome1 ,
                                              string AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                              bool AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                              string AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                              short AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                              string AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                              string AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                              string AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                              string AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                              string AV114Wpdemonstrativopagamentods_19_contratonome2 ,
                                              string AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                              bool AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                              string AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                              short AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                              string AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                              string AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                              string AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                              string AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                              string AV124Wpdemonstrativopagamentods_29_contratonome3 ,
                                              string AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                              string AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                              string AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                              string AV128Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                              decimal AV130Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                              decimal AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                              decimal AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                              decimal AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                              decimal AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                              decimal AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                              decimal AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                              decimal AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                              string AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                              string AV142Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                              int AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ,
                                              string A580PropostaResponsavelDocumento ,
                                              string A540PropostaPacienteClienteDocumento ,
                                              string A652PropostaClinicaDocumento ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              string A228ContratoNome ,
                                              string A494ConvenioCategoriaDescricao ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              decimal A501PropostaTaxaAdministrativa ,
                                              decimal A508PropostaJurosMora ,
                                              string A512PropostaSecUserName ,
                                              string AV96Wpdemonstrativopagamentods_1_filterfulltext ,
                                              decimal A513PropostaValorTaxa_F ,
                                              decimal A514PropostaValorJurosMora_F ,
                                              int AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                              int A649PropostaMaxReembolsoId_F ,
                                              int AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                              int AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                              DateTime AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                              DateTime A515PropostaDataCreditoCliente_F ,
                                              DateTime AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                              decimal AV140Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                              decimal AV141Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[96];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ConvenioCategoriaId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T4.SecUserFullName AS PropostaSecUserName, CAST(COALESCE( T1.PropostaValor, 0) * CAST(( CAST(COALESCE( T1.PropostaTaxaAdministrativa, 0) AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10)) AS PropostaValorTaxa_F, T3.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T1.PropostaDescricao, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaTaxaAdministrativa, T1.PropostaId, COALESCE( T9.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, T1.PropostaValor, T1.PropostaJurosMora, T1.PropostaSLA, COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM ((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(COALESCE( T15.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T10.TituloPropostaId AS TituloPropostaId FROM ((((Titulo T10 LEFT JOIN NotaFiscalParcelamento T11 ON T11.NotaFiscalParcelamentoID = T10.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T12 ON T12.NotaFiscalId = T11.NotaFiscalId)";
         scmdbuf += " LEFT JOIN Proposta T13 ON T13.PropostaId = T10.TituloPropostaId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T10.TituloId = TituloId GROUP BY TituloId ) T15 ON T15.TituloId = T10.TituloId),  Proposta T14 WHERE (T1.PropostaId = T10.TituloPropostaId) AND (T12.ClienteId = T13.PropostaPacienteClienteId) AND (T10.TituloPropostaId = T14.PropostaId) AND (T10.TituloTipo = ( 'DEBITO')) GROUP BY T10.TituloPropostaId ) T8 ON T8.TituloPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T9 ON T9.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 0 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 1 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 2 and ( Not (:AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 0 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 1 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 2 and ( Not (:AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 0 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 1 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 2 and ( Not (:AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') >= :AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente))");
         AddWhere(sWhereString, "((:AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') <= :AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente))");
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int6[46] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int6[47] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int6[48] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume)");
         }
         else
         {
            GXv_int6[49] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int6[50] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int6[51] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int6[52] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos)");
         }
         else
         {
            GXv_int6[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV104Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int6[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV104Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int6[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int6[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int6[57] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int6[58] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int6[59] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int6[60] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int6[61] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int6[62] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int6[63] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int6[64] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int6[65] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV114Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int6[66] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV114Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int6[67] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int6[68] = 1;
         }
         if ( AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int6[69] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int6[70] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int6[71] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int6[72] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int6[73] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int6[74] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int6[75] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int6[76] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int6[77] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV124Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int6[78] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV124Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int6[79] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int6[80] = 1;
         }
         if ( AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int6[81] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz)");
         }
         else
         {
            GXv_int6[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz))");
         }
         else
         {
            GXv_int6[83] = 1;
         }
         if ( StringUtil.StrCmp(AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdemonstrativopagamentods_33_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV128Wpdemonstrativopagamentods_33_tfpropostadescricao)");
         }
         else
         {
            GXv_int6[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int6[85] = 1;
         }
         if ( StringUtil.StrCmp(AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV130Wpdemonstrativopagamentods_35_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV130Wpdemonstrativopagamentods_35_tfpropostavalor)");
         }
         else
         {
            GXv_int6[86] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to)");
         }
         else
         {
            GXv_int6[87] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa >= :AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int6[88] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa <= :AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int6[89] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) >= :AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f)");
         }
         else
         {
            GXv_int6[90] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) <= :AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to)");
         }
         else
         {
            GXv_int6[91] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora >= :AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora)");
         }
         else
         {
            GXv_int6[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora <= :AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to)");
         }
         else
         {
            GXv_int6[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wpdemonstrativopagamentods_47_tfpropostasecusername)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName like :lV142Wpdemonstrativopagamentods_47_tfpropostasecusername)");
         }
         else
         {
            GXv_int6[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ! ( StringUtil.StrCmp(AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName = ( :AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel))");
         }
         else
         {
            GXv_int6[95] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T4.SecUserFullName))=0))");
         }
         if ( AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV144Wpdemonstrativopagamentods_49_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.SecUserFullName";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AK5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (int)dynConstraints[57] , (int)dynConstraints[58] , (int)dynConstraints[59] , (int)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (DateTime)dynConstraints[63] , (decimal)dynConstraints[64] , (decimal)dynConstraints[65] );
               case 1 :
                     return conditional_P00AK9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (int)dynConstraints[57] , (int)dynConstraints[58] , (int)dynConstraints[59] , (int)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (DateTime)dynConstraints[63] , (decimal)dynConstraints[64] , (decimal)dynConstraints[65] );
               case 2 :
                     return conditional_P00AK13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (int)dynConstraints[57] , (int)dynConstraints[58] , (int)dynConstraints[59] , (int)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (DateTime)dynConstraints[63] , (decimal)dynConstraints[64] , (decimal)dynConstraints[65] );
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
          Object[] prmP00AK5;
          prmP00AK5 = new Object[] {
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_33_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV130Wpdemonstrativopagamentods_35_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f",GXType.Number,18,2) ,
          new ParDef("AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to",GXType.Number,18,2) ,
          new ParDef("AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora",GXType.Number,16,4) ,
          new ParDef("AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV142Wpdemonstrativopagamentods_47_tfpropostasecusername",GXType.VarChar,150,0) ,
          new ParDef("AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00AK9;
          prmP00AK9 = new Object[] {
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_33_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV130Wpdemonstrativopagamentods_35_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f",GXType.Number,18,2) ,
          new ParDef("AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to",GXType.Number,18,2) ,
          new ParDef("AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora",GXType.Number,16,4) ,
          new ParDef("AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV142Wpdemonstrativopagamentods_47_tfpropostasecusername",GXType.VarChar,150,0) ,
          new ParDef("AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00AK13;
          prmP00AK13 = new Object[] {
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV97Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV98Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV106Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV107Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV108Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV116Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV117Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV118Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV119Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV138Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV139Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV100Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV101Wpdemonstrativopagamentods_6_propostapacienteclientedocume",GXType.VarChar,20,0) ,
          new ParDef("lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV102Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_8_propostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV110Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV111Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV120Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV123Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV124Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV125Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV126Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("AV127Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("lV128Wpdemonstrativopagamentods_33_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV129Wpdemonstrativopagamentods_34_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV130Wpdemonstrativopagamentods_35_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV131Wpdemonstrativopagamentods_36_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV132Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV133Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV134Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f",GXType.Number,18,2) ,
          new ParDef("AV135Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to",GXType.Number,18,2) ,
          new ParDef("AV136Wpdemonstrativopagamentods_41_tfpropostajurosmora",GXType.Number,16,4) ,
          new ParDef("AV137Wpdemonstrativopagamentods_42_tfpropostajurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV142Wpdemonstrativopagamentods_47_tfpropostasecusername",GXType.VarChar,150,0) ,
          new ParDef("AV143Wpdemonstrativopagamentods_48_tfpropostasecusername_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AK5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AK9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AK13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK13,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((decimal[]) buf[36])[0] = rslt.getDecimal(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((short[]) buf[40])[0] = rslt.getShort(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((DateTime[]) buf[42])[0] = rslt.getGXDate(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
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
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((decimal[]) buf[36])[0] = rslt.getDecimal(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((short[]) buf[40])[0] = rslt.getShort(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((DateTime[]) buf[42])[0] = rslt.getGXDate(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((int[]) buf[33])[0] = rslt.getInt(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((decimal[]) buf[36])[0] = rslt.getDecimal(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((short[]) buf[40])[0] = rslt.getShort(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((DateTime[]) buf[42])[0] = rslt.getGXDate(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                return;
       }
    }

 }

}
