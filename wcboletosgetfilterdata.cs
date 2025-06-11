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
   public class wcboletosgetfilterdata : GXProcedure
   {
      public wcboletosgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcboletosgetfilterdata( IGxContext context )
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
         this.AV60DDOName = aP0_DDOName;
         this.AV61SearchTxtParms = aP1_SearchTxtParms;
         this.AV62SearchTxtTo = aP2_SearchTxtTo;
         this.AV63OptionsJson = "" ;
         this.AV64OptionsDescJson = "" ;
         this.AV65OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV63OptionsJson;
         aP4_OptionsDescJson=this.AV64OptionsDescJson;
         aP5_OptionIndexesJson=this.AV65OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV65OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV60DDOName = aP0_DDOName;
         this.AV61SearchTxtParms = aP1_SearchTxtParms;
         this.AV62SearchTxtTo = aP2_SearchTxtTo;
         this.AV63OptionsJson = "" ;
         this.AV64OptionsDescJson = "" ;
         this.AV65OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV63OptionsJson;
         aP4_OptionsDescJson=this.AV64OptionsDescJson;
         aP5_OptionIndexesJson=this.AV65OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV50Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV52OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV53OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV47MaxItems = 10;
         AV46PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV61SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV61SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV44SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV61SearchTxtParms)) ? "" : StringUtil.Substring( AV61SearchTxtParms, 3, -1));
         AV45SkipItems = (short)(AV46PageIndex*AV47MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_BOLETOSNOSSONUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADBOLETOSNOSSONUMEROOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_BOLETOSSEUNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADBOLETOSSEUNUMEROOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_BOLETOSNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADBOLETOSNUMEROOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_BOLETOSSACADONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADBOLETOSSACADONOMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_BOLETOSSACADODOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADBOLETOSSACADODOCUMENTOOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV63OptionsJson = AV50Options.ToJSonString(false);
         AV64OptionsDescJson = AV52OptionsDesc.ToJSonString(false);
         AV65OptionIndexesJson = AV53OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV55Session.Get("WcBoletosGridState"), "") == 0 )
         {
            AV57GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcBoletosGridState"), null, "", "");
         }
         else
         {
            AV57GridState.FromXml(AV55Session.Get("WcBoletosGridState"), null, "", "");
         }
         AV79GXV1 = 1;
         while ( AV79GXV1 <= AV57GridState.gxTpr_Filtervalues.Count )
         {
            AV58GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV57GridState.gxTpr_Filtervalues.Item(AV79GXV1));
            if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV66FilterFullText = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSNOSSONUMERO") == 0 )
            {
               AV10TFBoletosNossoNumero = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSNOSSONUMERO_SEL") == 0 )
            {
               AV11TFBoletosNossoNumero_Sel = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSEUNUMERO") == 0 )
            {
               AV12TFBoletosSeuNumero = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSEUNUMERO_SEL") == 0 )
            {
               AV13TFBoletosSeuNumero_Sel = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSNUMERO") == 0 )
            {
               AV14TFBoletosNumero = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSNUMERO_SEL") == 0 )
            {
               AV15TFBoletosNumero_Sel = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSTATUS_SEL") == 0 )
            {
               AV16TFBoletosStatus_SelsJson = AV58GridStateFilterValue.gxTpr_Value;
               AV17TFBoletosStatus_Sels.FromJSonString(AV16TFBoletosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAEMISSAO") == 0 )
            {
               AV18TFBoletosDataEmissao = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Value, 4);
               AV19TFBoletosDataEmissao_To = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAVENCIMENTO") == 0 )
            {
               AV20TFBoletosDataVencimento = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Value, 4);
               AV21TFBoletosDataVencimento_To = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAREGISTRO") == 0 )
            {
               AV22TFBoletosDataRegistro = context.localUtil.CToT( AV58GridStateFilterValue.gxTpr_Value, 4);
               AV23TFBoletosDataRegistro_To = context.localUtil.CToT( AV58GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAPAGAMENTO") == 0 )
            {
               AV24TFBoletosDataPagamento = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Value, 4);
               AV25TFBoletosDataPagamento_To = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATABAIXA") == 0 )
            {
               AV26TFBoletosDataBaixa = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Value, 4);
               AV27TFBoletosDataBaixa_To = context.localUtil.CToD( AV58GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORNOMINAL") == 0 )
            {
               AV28TFBoletosValorNominal = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Value, ".");
               AV29TFBoletosValorNominal_To = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORPAGO") == 0 )
            {
               AV30TFBoletosValorPago = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Value, ".");
               AV31TFBoletosValorPago_To = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORDESCONTO") == 0 )
            {
               AV32TFBoletosValorDesconto = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Value, ".");
               AV33TFBoletosValorDesconto_To = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORJUROS") == 0 )
            {
               AV34TFBoletosValorJuros = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Value, ".");
               AV35TFBoletosValorJuros_To = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORMULTA") == 0 )
            {
               AV36TFBoletosValorMulta = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Value, ".");
               AV37TFBoletosValorMulta_To = NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADONOME") == 0 )
            {
               AV38TFBoletosSacadoNome = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADONOME_SEL") == 0 )
            {
               AV39TFBoletosSacadoNome_Sel = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADODOCUMENTO") == 0 )
            {
               AV40TFBoletosSacadoDocumento = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADODOCUMENTO_SEL") == 0 )
            {
               AV41TFBoletosSacadoDocumento_Sel = AV58GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADOTIPODOCUMENTO_SEL") == 0 )
            {
               AV42TFBoletosSacadoTipoDocumento_SelsJson = AV58GridStateFilterValue.gxTpr_Value;
               AV43TFBoletosSacadoTipoDocumento_Sels.FromJSonString(AV42TFBoletosSacadoTipoDocumento_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV58GridStateFilterValue.gxTpr_Name, "PARM_&CARTEIRADECOBRANCAID") == 0 )
            {
               AV78CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV58GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV79GXV1 = (int)(AV79GXV1+1);
         }
         if ( AV57GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV59GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV57GridState.gxTpr_Dynamicfilters.Item(1));
            AV67DynamicFiltersSelector1 = AV59GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV67DynamicFiltersSelector1, "BOLETOSNOSSONUMERO") == 0 )
            {
               AV68DynamicFiltersOperator1 = AV59GridStateDynamicFilter.gxTpr_Operator;
               AV69BoletosNossoNumero1 = AV59GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV57GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV70DynamicFiltersEnabled2 = true;
               AV59GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV57GridState.gxTpr_Dynamicfilters.Item(2));
               AV71DynamicFiltersSelector2 = AV59GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "BOLETOSNOSSONUMERO") == 0 )
               {
                  AV72DynamicFiltersOperator2 = AV59GridStateDynamicFilter.gxTpr_Operator;
                  AV73BoletosNossoNumero2 = AV59GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV57GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV74DynamicFiltersEnabled3 = true;
                  AV59GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV57GridState.gxTpr_Dynamicfilters.Item(3));
                  AV75DynamicFiltersSelector3 = AV59GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV75DynamicFiltersSelector3, "BOLETOSNOSSONUMERO") == 0 )
                  {
                     AV76DynamicFiltersOperator3 = AV59GridStateDynamicFilter.gxTpr_Operator;
                     AV77BoletosNossoNumero3 = AV59GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADBOLETOSNOSSONUMEROOPTIONS' Routine */
         returnInSub = false;
         AV10TFBoletosNossoNumero = AV44SearchTxt;
         AV11TFBoletosNossoNumero_Sel = "";
         AV81Wcboletosds_1_carteiradecobrancaid = AV78CarteiraDeCobrancaId;
         AV82Wcboletosds_2_filterfulltext = AV66FilterFullText;
         AV83Wcboletosds_3_dynamicfiltersselector1 = AV67DynamicFiltersSelector1;
         AV84Wcboletosds_4_dynamicfiltersoperator1 = AV68DynamicFiltersOperator1;
         AV85Wcboletosds_5_boletosnossonumero1 = AV69BoletosNossoNumero1;
         AV86Wcboletosds_6_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV87Wcboletosds_7_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV88Wcboletosds_8_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV89Wcboletosds_9_boletosnossonumero2 = AV73BoletosNossoNumero2;
         AV90Wcboletosds_10_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV91Wcboletosds_11_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV92Wcboletosds_12_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV93Wcboletosds_13_boletosnossonumero3 = AV77BoletosNossoNumero3;
         AV94Wcboletosds_14_tfboletosnossonumero = AV10TFBoletosNossoNumero;
         AV95Wcboletosds_15_tfboletosnossonumero_sel = AV11TFBoletosNossoNumero_Sel;
         AV96Wcboletosds_16_tfboletosseunumero = AV12TFBoletosSeuNumero;
         AV97Wcboletosds_17_tfboletosseunumero_sel = AV13TFBoletosSeuNumero_Sel;
         AV98Wcboletosds_18_tfboletosnumero = AV14TFBoletosNumero;
         AV99Wcboletosds_19_tfboletosnumero_sel = AV15TFBoletosNumero_Sel;
         AV100Wcboletosds_20_tfboletosstatus_sels = AV17TFBoletosStatus_Sels;
         AV101Wcboletosds_21_tfboletosdataemissao = AV18TFBoletosDataEmissao;
         AV102Wcboletosds_22_tfboletosdataemissao_to = AV19TFBoletosDataEmissao_To;
         AV103Wcboletosds_23_tfboletosdatavencimento = AV20TFBoletosDataVencimento;
         AV104Wcboletosds_24_tfboletosdatavencimento_to = AV21TFBoletosDataVencimento_To;
         AV105Wcboletosds_25_tfboletosdataregistro = AV22TFBoletosDataRegistro;
         AV106Wcboletosds_26_tfboletosdataregistro_to = AV23TFBoletosDataRegistro_To;
         AV107Wcboletosds_27_tfboletosdatapagamento = AV24TFBoletosDataPagamento;
         AV108Wcboletosds_28_tfboletosdatapagamento_to = AV25TFBoletosDataPagamento_To;
         AV109Wcboletosds_29_tfboletosdatabaixa = AV26TFBoletosDataBaixa;
         AV110Wcboletosds_30_tfboletosdatabaixa_to = AV27TFBoletosDataBaixa_To;
         AV111Wcboletosds_31_tfboletosvalornominal = AV28TFBoletosValorNominal;
         AV112Wcboletosds_32_tfboletosvalornominal_to = AV29TFBoletosValorNominal_To;
         AV113Wcboletosds_33_tfboletosvalorpago = AV30TFBoletosValorPago;
         AV114Wcboletosds_34_tfboletosvalorpago_to = AV31TFBoletosValorPago_To;
         AV115Wcboletosds_35_tfboletosvalordesconto = AV32TFBoletosValorDesconto;
         AV116Wcboletosds_36_tfboletosvalordesconto_to = AV33TFBoletosValorDesconto_To;
         AV117Wcboletosds_37_tfboletosvalorjuros = AV34TFBoletosValorJuros;
         AV118Wcboletosds_38_tfboletosvalorjuros_to = AV35TFBoletosValorJuros_To;
         AV119Wcboletosds_39_tfboletosvalormulta = AV36TFBoletosValorMulta;
         AV120Wcboletosds_40_tfboletosvalormulta_to = AV37TFBoletosValorMulta_To;
         AV121Wcboletosds_41_tfboletossacadonome = AV38TFBoletosSacadoNome;
         AV122Wcboletosds_42_tfboletossacadonome_sel = AV39TFBoletosSacadoNome_Sel;
         AV123Wcboletosds_43_tfboletossacadodocumento = AV40TFBoletosSacadoDocumento;
         AV124Wcboletosds_44_tfboletossacadodocumento_sel = AV41TFBoletosSacadoDocumento_Sel;
         AV125Wcboletosds_45_tfboletossacadotipodocumento_sels = AV43TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                              AV82Wcboletosds_2_filterfulltext ,
                                              AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                              AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                              AV85Wcboletosds_5_boletosnossonumero1 ,
                                              AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                              AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                              AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                              AV89Wcboletosds_9_boletosnossonumero2 ,
                                              AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                              AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                              AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                              AV93Wcboletosds_13_boletosnossonumero3 ,
                                              AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                              AV94Wcboletosds_14_tfboletosnossonumero ,
                                              AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                              AV96Wcboletosds_16_tfboletosseunumero ,
                                              AV99Wcboletosds_19_tfboletosnumero_sel ,
                                              AV98Wcboletosds_18_tfboletosnumero ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels.Count ,
                                              AV101Wcboletosds_21_tfboletosdataemissao ,
                                              AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                              AV103Wcboletosds_23_tfboletosdatavencimento ,
                                              AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                              AV105Wcboletosds_25_tfboletosdataregistro ,
                                              AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                              AV107Wcboletosds_27_tfboletosdatapagamento ,
                                              AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                              AV109Wcboletosds_29_tfboletosdatabaixa ,
                                              AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                              AV111Wcboletosds_31_tfboletosvalornominal ,
                                              AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                              AV113Wcboletosds_33_tfboletosvalorpago ,
                                              AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                              AV115Wcboletosds_35_tfboletosvalordesconto ,
                                              AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                              AV117Wcboletosds_37_tfboletosvalorjuros ,
                                              AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                              AV119Wcboletosds_39_tfboletosvalormulta ,
                                              AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                              AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                              AV121Wcboletosds_41_tfboletossacadonome ,
                                              AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                              AV123Wcboletosds_43_tfboletossacadodocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV81Wcboletosds_1_carteiradecobrancaid ,
                                              A1069CarteiraDeCobrancaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV94Wcboletosds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero), "%", "");
         lV96Wcboletosds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero), "%", "");
         lV98Wcboletosds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero), "%", "");
         lV121Wcboletosds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome), "%", "");
         lV123Wcboletosds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor P00FP2 */
         pr_default.execute(0, new Object[] {AV81Wcboletosds_1_carteiradecobrancaid, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV85Wcboletosds_5_boletosnossonumero1, lV85Wcboletosds_5_boletosnossonumero1, lV89Wcboletosds_9_boletosnossonumero2, lV89Wcboletosds_9_boletosnossonumero2, lV93Wcboletosds_13_boletosnossonumero3, lV93Wcboletosds_13_boletosnossonumero3, lV94Wcboletosds_14_tfboletosnossonumero, AV95Wcboletosds_15_tfboletosnossonumero_sel, lV96Wcboletosds_16_tfboletosseunumero, AV97Wcboletosds_17_tfboletosseunumero_sel, lV98Wcboletosds_18_tfboletosnumero, AV99Wcboletosds_19_tfboletosnumero_sel, AV101Wcboletosds_21_tfboletosdataemissao, AV102Wcboletosds_22_tfboletosdataemissao_to, AV103Wcboletosds_23_tfboletosdatavencimento, AV104Wcboletosds_24_tfboletosdatavencimento_to, AV105Wcboletosds_25_tfboletosdataregistro, AV106Wcboletosds_26_tfboletosdataregistro_to, AV107Wcboletosds_27_tfboletosdatapagamento, AV108Wcboletosds_28_tfboletosdatapagamento_to, AV109Wcboletosds_29_tfboletosdatabaixa, AV110Wcboletosds_30_tfboletosdatabaixa_to, AV111Wcboletosds_31_tfboletosvalornominal, AV112Wcboletosds_32_tfboletosvalornominal_to, AV113Wcboletosds_33_tfboletosvalorpago, AV114Wcboletosds_34_tfboletosvalorpago_to, AV115Wcboletosds_35_tfboletosvalordesconto, AV116Wcboletosds_36_tfboletosvalordesconto_to, AV117Wcboletosds_37_tfboletosvalorjuros, AV118Wcboletosds_38_tfboletosvalorjuros_to, AV119Wcboletosds_39_tfboletosvalormulta, AV120Wcboletosds_40_tfboletosvalormulta_to, lV121Wcboletosds_41_tfboletossacadonome, AV122Wcboletosds_42_tfboletossacadonome_sel, lV123Wcboletosds_43_tfboletossacadodocumento, AV124Wcboletosds_44_tfboletossacadodocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFP2 = false;
            A1069CarteiraDeCobrancaId = P00FP2_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = P00FP2_n1069CarteiraDeCobrancaId[0];
            A1078BoletosNossoNumero = P00FP2_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = P00FP2_n1078BoletosNossoNumero[0];
            A1093BoletosValorMulta = P00FP2_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = P00FP2_n1093BoletosValorMulta[0];
            A1092BoletosValorJuros = P00FP2_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = P00FP2_n1092BoletosValorJuros[0];
            A1091BoletosValorDesconto = P00FP2_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = P00FP2_n1091BoletosValorDesconto[0];
            A1090BoletosValorPago = P00FP2_A1090BoletosValorPago[0];
            n1090BoletosValorPago = P00FP2_n1090BoletosValorPago[0];
            A1089BoletosValorNominal = P00FP2_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = P00FP2_n1089BoletosValorNominal[0];
            A1088BoletosDataBaixa = P00FP2_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = P00FP2_n1088BoletosDataBaixa[0];
            A1087BoletosDataPagamento = P00FP2_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = P00FP2_n1087BoletosDataPagamento[0];
            A1086BoletosDataRegistro = P00FP2_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = P00FP2_n1086BoletosDataRegistro[0];
            A1085BoletosDataVencimento = P00FP2_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = P00FP2_n1085BoletosDataVencimento[0];
            A1084BoletosDataEmissao = P00FP2_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = P00FP2_n1084BoletosDataEmissao[0];
            A1096BoletosSacadoTipoDocumento = P00FP2_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = P00FP2_n1096BoletosSacadoTipoDocumento[0];
            A1095BoletosSacadoDocumento = P00FP2_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = P00FP2_n1095BoletosSacadoDocumento[0];
            A1094BoletosSacadoNome = P00FP2_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = P00FP2_n1094BoletosSacadoNome[0];
            A1083BoletosStatus = P00FP2_A1083BoletosStatus[0];
            n1083BoletosStatus = P00FP2_n1083BoletosStatus[0];
            A1080BoletosNumero = P00FP2_A1080BoletosNumero[0];
            n1080BoletosNumero = P00FP2_n1080BoletosNumero[0];
            A1079BoletosSeuNumero = P00FP2_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = P00FP2_n1079BoletosSeuNumero[0];
            A1077BoletosId = P00FP2_A1077BoletosId[0];
            AV54count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00FP2_A1069CarteiraDeCobrancaId[0] == A1069CarteiraDeCobrancaId ) && ( StringUtil.StrCmp(P00FP2_A1078BoletosNossoNumero[0], A1078BoletosNossoNumero) == 0 ) )
            {
               BRKFP2 = false;
               A1077BoletosId = P00FP2_A1077BoletosId[0];
               AV54count = (long)(AV54count+1);
               BRKFP2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV45SkipItems) )
            {
               AV49Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1078BoletosNossoNumero)) ? "<#Empty#>" : A1078BoletosNossoNumero);
               AV50Options.Add(AV49Option, 0);
               AV53OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV54count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV50Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV45SkipItems = (short)(AV45SkipItems-1);
            }
            if ( ! BRKFP2 )
            {
               BRKFP2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADBOLETOSSEUNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV12TFBoletosSeuNumero = AV44SearchTxt;
         AV13TFBoletosSeuNumero_Sel = "";
         AV81Wcboletosds_1_carteiradecobrancaid = AV78CarteiraDeCobrancaId;
         AV82Wcboletosds_2_filterfulltext = AV66FilterFullText;
         AV83Wcboletosds_3_dynamicfiltersselector1 = AV67DynamicFiltersSelector1;
         AV84Wcboletosds_4_dynamicfiltersoperator1 = AV68DynamicFiltersOperator1;
         AV85Wcboletosds_5_boletosnossonumero1 = AV69BoletosNossoNumero1;
         AV86Wcboletosds_6_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV87Wcboletosds_7_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV88Wcboletosds_8_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV89Wcboletosds_9_boletosnossonumero2 = AV73BoletosNossoNumero2;
         AV90Wcboletosds_10_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV91Wcboletosds_11_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV92Wcboletosds_12_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV93Wcboletosds_13_boletosnossonumero3 = AV77BoletosNossoNumero3;
         AV94Wcboletosds_14_tfboletosnossonumero = AV10TFBoletosNossoNumero;
         AV95Wcboletosds_15_tfboletosnossonumero_sel = AV11TFBoletosNossoNumero_Sel;
         AV96Wcboletosds_16_tfboletosseunumero = AV12TFBoletosSeuNumero;
         AV97Wcboletosds_17_tfboletosseunumero_sel = AV13TFBoletosSeuNumero_Sel;
         AV98Wcboletosds_18_tfboletosnumero = AV14TFBoletosNumero;
         AV99Wcboletosds_19_tfboletosnumero_sel = AV15TFBoletosNumero_Sel;
         AV100Wcboletosds_20_tfboletosstatus_sels = AV17TFBoletosStatus_Sels;
         AV101Wcboletosds_21_tfboletosdataemissao = AV18TFBoletosDataEmissao;
         AV102Wcboletosds_22_tfboletosdataemissao_to = AV19TFBoletosDataEmissao_To;
         AV103Wcboletosds_23_tfboletosdatavencimento = AV20TFBoletosDataVencimento;
         AV104Wcboletosds_24_tfboletosdatavencimento_to = AV21TFBoletosDataVencimento_To;
         AV105Wcboletosds_25_tfboletosdataregistro = AV22TFBoletosDataRegistro;
         AV106Wcboletosds_26_tfboletosdataregistro_to = AV23TFBoletosDataRegistro_To;
         AV107Wcboletosds_27_tfboletosdatapagamento = AV24TFBoletosDataPagamento;
         AV108Wcboletosds_28_tfboletosdatapagamento_to = AV25TFBoletosDataPagamento_To;
         AV109Wcboletosds_29_tfboletosdatabaixa = AV26TFBoletosDataBaixa;
         AV110Wcboletosds_30_tfboletosdatabaixa_to = AV27TFBoletosDataBaixa_To;
         AV111Wcboletosds_31_tfboletosvalornominal = AV28TFBoletosValorNominal;
         AV112Wcboletosds_32_tfboletosvalornominal_to = AV29TFBoletosValorNominal_To;
         AV113Wcboletosds_33_tfboletosvalorpago = AV30TFBoletosValorPago;
         AV114Wcboletosds_34_tfboletosvalorpago_to = AV31TFBoletosValorPago_To;
         AV115Wcboletosds_35_tfboletosvalordesconto = AV32TFBoletosValorDesconto;
         AV116Wcboletosds_36_tfboletosvalordesconto_to = AV33TFBoletosValorDesconto_To;
         AV117Wcboletosds_37_tfboletosvalorjuros = AV34TFBoletosValorJuros;
         AV118Wcboletosds_38_tfboletosvalorjuros_to = AV35TFBoletosValorJuros_To;
         AV119Wcboletosds_39_tfboletosvalormulta = AV36TFBoletosValorMulta;
         AV120Wcboletosds_40_tfboletosvalormulta_to = AV37TFBoletosValorMulta_To;
         AV121Wcboletosds_41_tfboletossacadonome = AV38TFBoletosSacadoNome;
         AV122Wcboletosds_42_tfboletossacadonome_sel = AV39TFBoletosSacadoNome_Sel;
         AV123Wcboletosds_43_tfboletossacadodocumento = AV40TFBoletosSacadoDocumento;
         AV124Wcboletosds_44_tfboletossacadodocumento_sel = AV41TFBoletosSacadoDocumento_Sel;
         AV125Wcboletosds_45_tfboletossacadotipodocumento_sels = AV43TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                              AV82Wcboletosds_2_filterfulltext ,
                                              AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                              AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                              AV85Wcboletosds_5_boletosnossonumero1 ,
                                              AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                              AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                              AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                              AV89Wcboletosds_9_boletosnossonumero2 ,
                                              AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                              AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                              AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                              AV93Wcboletosds_13_boletosnossonumero3 ,
                                              AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                              AV94Wcboletosds_14_tfboletosnossonumero ,
                                              AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                              AV96Wcboletosds_16_tfboletosseunumero ,
                                              AV99Wcboletosds_19_tfboletosnumero_sel ,
                                              AV98Wcboletosds_18_tfboletosnumero ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels.Count ,
                                              AV101Wcboletosds_21_tfboletosdataemissao ,
                                              AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                              AV103Wcboletosds_23_tfboletosdatavencimento ,
                                              AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                              AV105Wcboletosds_25_tfboletosdataregistro ,
                                              AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                              AV107Wcboletosds_27_tfboletosdatapagamento ,
                                              AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                              AV109Wcboletosds_29_tfboletosdatabaixa ,
                                              AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                              AV111Wcboletosds_31_tfboletosvalornominal ,
                                              AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                              AV113Wcboletosds_33_tfboletosvalorpago ,
                                              AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                              AV115Wcboletosds_35_tfboletosvalordesconto ,
                                              AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                              AV117Wcboletosds_37_tfboletosvalorjuros ,
                                              AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                              AV119Wcboletosds_39_tfboletosvalormulta ,
                                              AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                              AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                              AV121Wcboletosds_41_tfboletossacadonome ,
                                              AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                              AV123Wcboletosds_43_tfboletossacadodocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV81Wcboletosds_1_carteiradecobrancaid ,
                                              A1069CarteiraDeCobrancaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV94Wcboletosds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero), "%", "");
         lV96Wcboletosds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero), "%", "");
         lV98Wcboletosds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero), "%", "");
         lV121Wcboletosds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome), "%", "");
         lV123Wcboletosds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor P00FP3 */
         pr_default.execute(1, new Object[] {AV81Wcboletosds_1_carteiradecobrancaid, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV85Wcboletosds_5_boletosnossonumero1, lV85Wcboletosds_5_boletosnossonumero1, lV89Wcboletosds_9_boletosnossonumero2, lV89Wcboletosds_9_boletosnossonumero2, lV93Wcboletosds_13_boletosnossonumero3, lV93Wcboletosds_13_boletosnossonumero3, lV94Wcboletosds_14_tfboletosnossonumero, AV95Wcboletosds_15_tfboletosnossonumero_sel, lV96Wcboletosds_16_tfboletosseunumero, AV97Wcboletosds_17_tfboletosseunumero_sel, lV98Wcboletosds_18_tfboletosnumero, AV99Wcboletosds_19_tfboletosnumero_sel, AV101Wcboletosds_21_tfboletosdataemissao, AV102Wcboletosds_22_tfboletosdataemissao_to, AV103Wcboletosds_23_tfboletosdatavencimento, AV104Wcboletosds_24_tfboletosdatavencimento_to, AV105Wcboletosds_25_tfboletosdataregistro, AV106Wcboletosds_26_tfboletosdataregistro_to, AV107Wcboletosds_27_tfboletosdatapagamento, AV108Wcboletosds_28_tfboletosdatapagamento_to, AV109Wcboletosds_29_tfboletosdatabaixa, AV110Wcboletosds_30_tfboletosdatabaixa_to, AV111Wcboletosds_31_tfboletosvalornominal, AV112Wcboletosds_32_tfboletosvalornominal_to, AV113Wcboletosds_33_tfboletosvalorpago, AV114Wcboletosds_34_tfboletosvalorpago_to, AV115Wcboletosds_35_tfboletosvalordesconto, AV116Wcboletosds_36_tfboletosvalordesconto_to, AV117Wcboletosds_37_tfboletosvalorjuros, AV118Wcboletosds_38_tfboletosvalorjuros_to, AV119Wcboletosds_39_tfboletosvalormulta, AV120Wcboletosds_40_tfboletosvalormulta_to, lV121Wcboletosds_41_tfboletossacadonome, AV122Wcboletosds_42_tfboletossacadonome_sel, lV123Wcboletosds_43_tfboletossacadodocumento, AV124Wcboletosds_44_tfboletossacadodocumento_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKFP4 = false;
            A1069CarteiraDeCobrancaId = P00FP3_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = P00FP3_n1069CarteiraDeCobrancaId[0];
            A1079BoletosSeuNumero = P00FP3_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = P00FP3_n1079BoletosSeuNumero[0];
            A1093BoletosValorMulta = P00FP3_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = P00FP3_n1093BoletosValorMulta[0];
            A1092BoletosValorJuros = P00FP3_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = P00FP3_n1092BoletosValorJuros[0];
            A1091BoletosValorDesconto = P00FP3_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = P00FP3_n1091BoletosValorDesconto[0];
            A1090BoletosValorPago = P00FP3_A1090BoletosValorPago[0];
            n1090BoletosValorPago = P00FP3_n1090BoletosValorPago[0];
            A1089BoletosValorNominal = P00FP3_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = P00FP3_n1089BoletosValorNominal[0];
            A1088BoletosDataBaixa = P00FP3_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = P00FP3_n1088BoletosDataBaixa[0];
            A1087BoletosDataPagamento = P00FP3_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = P00FP3_n1087BoletosDataPagamento[0];
            A1086BoletosDataRegistro = P00FP3_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = P00FP3_n1086BoletosDataRegistro[0];
            A1085BoletosDataVencimento = P00FP3_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = P00FP3_n1085BoletosDataVencimento[0];
            A1084BoletosDataEmissao = P00FP3_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = P00FP3_n1084BoletosDataEmissao[0];
            A1096BoletosSacadoTipoDocumento = P00FP3_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = P00FP3_n1096BoletosSacadoTipoDocumento[0];
            A1095BoletosSacadoDocumento = P00FP3_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = P00FP3_n1095BoletosSacadoDocumento[0];
            A1094BoletosSacadoNome = P00FP3_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = P00FP3_n1094BoletosSacadoNome[0];
            A1083BoletosStatus = P00FP3_A1083BoletosStatus[0];
            n1083BoletosStatus = P00FP3_n1083BoletosStatus[0];
            A1080BoletosNumero = P00FP3_A1080BoletosNumero[0];
            n1080BoletosNumero = P00FP3_n1080BoletosNumero[0];
            A1078BoletosNossoNumero = P00FP3_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = P00FP3_n1078BoletosNossoNumero[0];
            A1077BoletosId = P00FP3_A1077BoletosId[0];
            AV54count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00FP3_A1069CarteiraDeCobrancaId[0] == A1069CarteiraDeCobrancaId ) && ( StringUtil.StrCmp(P00FP3_A1079BoletosSeuNumero[0], A1079BoletosSeuNumero) == 0 ) )
            {
               BRKFP4 = false;
               A1077BoletosId = P00FP3_A1077BoletosId[0];
               AV54count = (long)(AV54count+1);
               BRKFP4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV45SkipItems) )
            {
               AV49Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1079BoletosSeuNumero)) ? "<#Empty#>" : A1079BoletosSeuNumero);
               AV50Options.Add(AV49Option, 0);
               AV53OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV54count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV50Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV45SkipItems = (short)(AV45SkipItems-1);
            }
            if ( ! BRKFP4 )
            {
               BRKFP4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADBOLETOSNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV14TFBoletosNumero = AV44SearchTxt;
         AV15TFBoletosNumero_Sel = "";
         AV81Wcboletosds_1_carteiradecobrancaid = AV78CarteiraDeCobrancaId;
         AV82Wcboletosds_2_filterfulltext = AV66FilterFullText;
         AV83Wcboletosds_3_dynamicfiltersselector1 = AV67DynamicFiltersSelector1;
         AV84Wcboletosds_4_dynamicfiltersoperator1 = AV68DynamicFiltersOperator1;
         AV85Wcboletosds_5_boletosnossonumero1 = AV69BoletosNossoNumero1;
         AV86Wcboletosds_6_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV87Wcboletosds_7_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV88Wcboletosds_8_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV89Wcboletosds_9_boletosnossonumero2 = AV73BoletosNossoNumero2;
         AV90Wcboletosds_10_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV91Wcboletosds_11_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV92Wcboletosds_12_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV93Wcboletosds_13_boletosnossonumero3 = AV77BoletosNossoNumero3;
         AV94Wcboletosds_14_tfboletosnossonumero = AV10TFBoletosNossoNumero;
         AV95Wcboletosds_15_tfboletosnossonumero_sel = AV11TFBoletosNossoNumero_Sel;
         AV96Wcboletosds_16_tfboletosseunumero = AV12TFBoletosSeuNumero;
         AV97Wcboletosds_17_tfboletosseunumero_sel = AV13TFBoletosSeuNumero_Sel;
         AV98Wcboletosds_18_tfboletosnumero = AV14TFBoletosNumero;
         AV99Wcboletosds_19_tfboletosnumero_sel = AV15TFBoletosNumero_Sel;
         AV100Wcboletosds_20_tfboletosstatus_sels = AV17TFBoletosStatus_Sels;
         AV101Wcboletosds_21_tfboletosdataemissao = AV18TFBoletosDataEmissao;
         AV102Wcboletosds_22_tfboletosdataemissao_to = AV19TFBoletosDataEmissao_To;
         AV103Wcboletosds_23_tfboletosdatavencimento = AV20TFBoletosDataVencimento;
         AV104Wcboletosds_24_tfboletosdatavencimento_to = AV21TFBoletosDataVencimento_To;
         AV105Wcboletosds_25_tfboletosdataregistro = AV22TFBoletosDataRegistro;
         AV106Wcboletosds_26_tfboletosdataregistro_to = AV23TFBoletosDataRegistro_To;
         AV107Wcboletosds_27_tfboletosdatapagamento = AV24TFBoletosDataPagamento;
         AV108Wcboletosds_28_tfboletosdatapagamento_to = AV25TFBoletosDataPagamento_To;
         AV109Wcboletosds_29_tfboletosdatabaixa = AV26TFBoletosDataBaixa;
         AV110Wcboletosds_30_tfboletosdatabaixa_to = AV27TFBoletosDataBaixa_To;
         AV111Wcboletosds_31_tfboletosvalornominal = AV28TFBoletosValorNominal;
         AV112Wcboletosds_32_tfboletosvalornominal_to = AV29TFBoletosValorNominal_To;
         AV113Wcboletosds_33_tfboletosvalorpago = AV30TFBoletosValorPago;
         AV114Wcboletosds_34_tfboletosvalorpago_to = AV31TFBoletosValorPago_To;
         AV115Wcboletosds_35_tfboletosvalordesconto = AV32TFBoletosValorDesconto;
         AV116Wcboletosds_36_tfboletosvalordesconto_to = AV33TFBoletosValorDesconto_To;
         AV117Wcboletosds_37_tfboletosvalorjuros = AV34TFBoletosValorJuros;
         AV118Wcboletosds_38_tfboletosvalorjuros_to = AV35TFBoletosValorJuros_To;
         AV119Wcboletosds_39_tfboletosvalormulta = AV36TFBoletosValorMulta;
         AV120Wcboletosds_40_tfboletosvalormulta_to = AV37TFBoletosValorMulta_To;
         AV121Wcboletosds_41_tfboletossacadonome = AV38TFBoletosSacadoNome;
         AV122Wcboletosds_42_tfboletossacadonome_sel = AV39TFBoletosSacadoNome_Sel;
         AV123Wcboletosds_43_tfboletossacadodocumento = AV40TFBoletosSacadoDocumento;
         AV124Wcboletosds_44_tfboletossacadodocumento_sel = AV41TFBoletosSacadoDocumento_Sel;
         AV125Wcboletosds_45_tfboletossacadotipodocumento_sels = AV43TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                              AV82Wcboletosds_2_filterfulltext ,
                                              AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                              AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                              AV85Wcboletosds_5_boletosnossonumero1 ,
                                              AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                              AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                              AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                              AV89Wcboletosds_9_boletosnossonumero2 ,
                                              AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                              AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                              AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                              AV93Wcboletosds_13_boletosnossonumero3 ,
                                              AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                              AV94Wcboletosds_14_tfboletosnossonumero ,
                                              AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                              AV96Wcboletosds_16_tfboletosseunumero ,
                                              AV99Wcboletosds_19_tfboletosnumero_sel ,
                                              AV98Wcboletosds_18_tfboletosnumero ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels.Count ,
                                              AV101Wcboletosds_21_tfboletosdataemissao ,
                                              AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                              AV103Wcboletosds_23_tfboletosdatavencimento ,
                                              AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                              AV105Wcboletosds_25_tfboletosdataregistro ,
                                              AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                              AV107Wcboletosds_27_tfboletosdatapagamento ,
                                              AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                              AV109Wcboletosds_29_tfboletosdatabaixa ,
                                              AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                              AV111Wcboletosds_31_tfboletosvalornominal ,
                                              AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                              AV113Wcboletosds_33_tfboletosvalorpago ,
                                              AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                              AV115Wcboletosds_35_tfboletosvalordesconto ,
                                              AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                              AV117Wcboletosds_37_tfboletosvalorjuros ,
                                              AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                              AV119Wcboletosds_39_tfboletosvalormulta ,
                                              AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                              AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                              AV121Wcboletosds_41_tfboletossacadonome ,
                                              AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                              AV123Wcboletosds_43_tfboletossacadodocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV81Wcboletosds_1_carteiradecobrancaid ,
                                              A1069CarteiraDeCobrancaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV94Wcboletosds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero), "%", "");
         lV96Wcboletosds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero), "%", "");
         lV98Wcboletosds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero), "%", "");
         lV121Wcboletosds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome), "%", "");
         lV123Wcboletosds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor P00FP4 */
         pr_default.execute(2, new Object[] {AV81Wcboletosds_1_carteiradecobrancaid, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV85Wcboletosds_5_boletosnossonumero1, lV85Wcboletosds_5_boletosnossonumero1, lV89Wcboletosds_9_boletosnossonumero2, lV89Wcboletosds_9_boletosnossonumero2, lV93Wcboletosds_13_boletosnossonumero3, lV93Wcboletosds_13_boletosnossonumero3, lV94Wcboletosds_14_tfboletosnossonumero, AV95Wcboletosds_15_tfboletosnossonumero_sel, lV96Wcboletosds_16_tfboletosseunumero, AV97Wcboletosds_17_tfboletosseunumero_sel, lV98Wcboletosds_18_tfboletosnumero, AV99Wcboletosds_19_tfboletosnumero_sel, AV101Wcboletosds_21_tfboletosdataemissao, AV102Wcboletosds_22_tfboletosdataemissao_to, AV103Wcboletosds_23_tfboletosdatavencimento, AV104Wcboletosds_24_tfboletosdatavencimento_to, AV105Wcboletosds_25_tfboletosdataregistro, AV106Wcboletosds_26_tfboletosdataregistro_to, AV107Wcboletosds_27_tfboletosdatapagamento, AV108Wcboletosds_28_tfboletosdatapagamento_to, AV109Wcboletosds_29_tfboletosdatabaixa, AV110Wcboletosds_30_tfboletosdatabaixa_to, AV111Wcboletosds_31_tfboletosvalornominal, AV112Wcboletosds_32_tfboletosvalornominal_to, AV113Wcboletosds_33_tfboletosvalorpago, AV114Wcboletosds_34_tfboletosvalorpago_to, AV115Wcboletosds_35_tfboletosvalordesconto, AV116Wcboletosds_36_tfboletosvalordesconto_to, AV117Wcboletosds_37_tfboletosvalorjuros, AV118Wcboletosds_38_tfboletosvalorjuros_to, AV119Wcboletosds_39_tfboletosvalormulta, AV120Wcboletosds_40_tfboletosvalormulta_to, lV121Wcboletosds_41_tfboletossacadonome, AV122Wcboletosds_42_tfboletossacadonome_sel, lV123Wcboletosds_43_tfboletossacadodocumento, AV124Wcboletosds_44_tfboletossacadodocumento_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKFP6 = false;
            A1069CarteiraDeCobrancaId = P00FP4_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = P00FP4_n1069CarteiraDeCobrancaId[0];
            A1080BoletosNumero = P00FP4_A1080BoletosNumero[0];
            n1080BoletosNumero = P00FP4_n1080BoletosNumero[0];
            A1093BoletosValorMulta = P00FP4_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = P00FP4_n1093BoletosValorMulta[0];
            A1092BoletosValorJuros = P00FP4_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = P00FP4_n1092BoletosValorJuros[0];
            A1091BoletosValorDesconto = P00FP4_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = P00FP4_n1091BoletosValorDesconto[0];
            A1090BoletosValorPago = P00FP4_A1090BoletosValorPago[0];
            n1090BoletosValorPago = P00FP4_n1090BoletosValorPago[0];
            A1089BoletosValorNominal = P00FP4_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = P00FP4_n1089BoletosValorNominal[0];
            A1088BoletosDataBaixa = P00FP4_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = P00FP4_n1088BoletosDataBaixa[0];
            A1087BoletosDataPagamento = P00FP4_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = P00FP4_n1087BoletosDataPagamento[0];
            A1086BoletosDataRegistro = P00FP4_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = P00FP4_n1086BoletosDataRegistro[0];
            A1085BoletosDataVencimento = P00FP4_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = P00FP4_n1085BoletosDataVencimento[0];
            A1084BoletosDataEmissao = P00FP4_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = P00FP4_n1084BoletosDataEmissao[0];
            A1096BoletosSacadoTipoDocumento = P00FP4_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = P00FP4_n1096BoletosSacadoTipoDocumento[0];
            A1095BoletosSacadoDocumento = P00FP4_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = P00FP4_n1095BoletosSacadoDocumento[0];
            A1094BoletosSacadoNome = P00FP4_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = P00FP4_n1094BoletosSacadoNome[0];
            A1083BoletosStatus = P00FP4_A1083BoletosStatus[0];
            n1083BoletosStatus = P00FP4_n1083BoletosStatus[0];
            A1079BoletosSeuNumero = P00FP4_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = P00FP4_n1079BoletosSeuNumero[0];
            A1078BoletosNossoNumero = P00FP4_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = P00FP4_n1078BoletosNossoNumero[0];
            A1077BoletosId = P00FP4_A1077BoletosId[0];
            AV54count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00FP4_A1069CarteiraDeCobrancaId[0] == A1069CarteiraDeCobrancaId ) && ( StringUtil.StrCmp(P00FP4_A1080BoletosNumero[0], A1080BoletosNumero) == 0 ) )
            {
               BRKFP6 = false;
               A1077BoletosId = P00FP4_A1077BoletosId[0];
               AV54count = (long)(AV54count+1);
               BRKFP6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV45SkipItems) )
            {
               AV49Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1080BoletosNumero)) ? "<#Empty#>" : A1080BoletosNumero);
               AV50Options.Add(AV49Option, 0);
               AV53OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV54count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV50Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV45SkipItems = (short)(AV45SkipItems-1);
            }
            if ( ! BRKFP6 )
            {
               BRKFP6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADBOLETOSSACADONOMEOPTIONS' Routine */
         returnInSub = false;
         AV38TFBoletosSacadoNome = AV44SearchTxt;
         AV39TFBoletosSacadoNome_Sel = "";
         AV81Wcboletosds_1_carteiradecobrancaid = AV78CarteiraDeCobrancaId;
         AV82Wcboletosds_2_filterfulltext = AV66FilterFullText;
         AV83Wcboletosds_3_dynamicfiltersselector1 = AV67DynamicFiltersSelector1;
         AV84Wcboletosds_4_dynamicfiltersoperator1 = AV68DynamicFiltersOperator1;
         AV85Wcboletosds_5_boletosnossonumero1 = AV69BoletosNossoNumero1;
         AV86Wcboletosds_6_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV87Wcboletosds_7_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV88Wcboletosds_8_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV89Wcboletosds_9_boletosnossonumero2 = AV73BoletosNossoNumero2;
         AV90Wcboletosds_10_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV91Wcboletosds_11_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV92Wcboletosds_12_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV93Wcboletosds_13_boletosnossonumero3 = AV77BoletosNossoNumero3;
         AV94Wcboletosds_14_tfboletosnossonumero = AV10TFBoletosNossoNumero;
         AV95Wcboletosds_15_tfboletosnossonumero_sel = AV11TFBoletosNossoNumero_Sel;
         AV96Wcboletosds_16_tfboletosseunumero = AV12TFBoletosSeuNumero;
         AV97Wcboletosds_17_tfboletosseunumero_sel = AV13TFBoletosSeuNumero_Sel;
         AV98Wcboletosds_18_tfboletosnumero = AV14TFBoletosNumero;
         AV99Wcboletosds_19_tfboletosnumero_sel = AV15TFBoletosNumero_Sel;
         AV100Wcboletosds_20_tfboletosstatus_sels = AV17TFBoletosStatus_Sels;
         AV101Wcboletosds_21_tfboletosdataemissao = AV18TFBoletosDataEmissao;
         AV102Wcboletosds_22_tfboletosdataemissao_to = AV19TFBoletosDataEmissao_To;
         AV103Wcboletosds_23_tfboletosdatavencimento = AV20TFBoletosDataVencimento;
         AV104Wcboletosds_24_tfboletosdatavencimento_to = AV21TFBoletosDataVencimento_To;
         AV105Wcboletosds_25_tfboletosdataregistro = AV22TFBoletosDataRegistro;
         AV106Wcboletosds_26_tfboletosdataregistro_to = AV23TFBoletosDataRegistro_To;
         AV107Wcboletosds_27_tfboletosdatapagamento = AV24TFBoletosDataPagamento;
         AV108Wcboletosds_28_tfboletosdatapagamento_to = AV25TFBoletosDataPagamento_To;
         AV109Wcboletosds_29_tfboletosdatabaixa = AV26TFBoletosDataBaixa;
         AV110Wcboletosds_30_tfboletosdatabaixa_to = AV27TFBoletosDataBaixa_To;
         AV111Wcboletosds_31_tfboletosvalornominal = AV28TFBoletosValorNominal;
         AV112Wcboletosds_32_tfboletosvalornominal_to = AV29TFBoletosValorNominal_To;
         AV113Wcboletosds_33_tfboletosvalorpago = AV30TFBoletosValorPago;
         AV114Wcboletosds_34_tfboletosvalorpago_to = AV31TFBoletosValorPago_To;
         AV115Wcboletosds_35_tfboletosvalordesconto = AV32TFBoletosValorDesconto;
         AV116Wcboletosds_36_tfboletosvalordesconto_to = AV33TFBoletosValorDesconto_To;
         AV117Wcboletosds_37_tfboletosvalorjuros = AV34TFBoletosValorJuros;
         AV118Wcboletosds_38_tfboletosvalorjuros_to = AV35TFBoletosValorJuros_To;
         AV119Wcboletosds_39_tfboletosvalormulta = AV36TFBoletosValorMulta;
         AV120Wcboletosds_40_tfboletosvalormulta_to = AV37TFBoletosValorMulta_To;
         AV121Wcboletosds_41_tfboletossacadonome = AV38TFBoletosSacadoNome;
         AV122Wcboletosds_42_tfboletossacadonome_sel = AV39TFBoletosSacadoNome_Sel;
         AV123Wcboletosds_43_tfboletossacadodocumento = AV40TFBoletosSacadoDocumento;
         AV124Wcboletosds_44_tfboletossacadodocumento_sel = AV41TFBoletosSacadoDocumento_Sel;
         AV125Wcboletosds_45_tfboletossacadotipodocumento_sels = AV43TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                              AV82Wcboletosds_2_filterfulltext ,
                                              AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                              AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                              AV85Wcboletosds_5_boletosnossonumero1 ,
                                              AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                              AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                              AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                              AV89Wcboletosds_9_boletosnossonumero2 ,
                                              AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                              AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                              AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                              AV93Wcboletosds_13_boletosnossonumero3 ,
                                              AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                              AV94Wcboletosds_14_tfboletosnossonumero ,
                                              AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                              AV96Wcboletosds_16_tfboletosseunumero ,
                                              AV99Wcboletosds_19_tfboletosnumero_sel ,
                                              AV98Wcboletosds_18_tfboletosnumero ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels.Count ,
                                              AV101Wcboletosds_21_tfboletosdataemissao ,
                                              AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                              AV103Wcboletosds_23_tfboletosdatavencimento ,
                                              AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                              AV105Wcboletosds_25_tfboletosdataregistro ,
                                              AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                              AV107Wcboletosds_27_tfboletosdatapagamento ,
                                              AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                              AV109Wcboletosds_29_tfboletosdatabaixa ,
                                              AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                              AV111Wcboletosds_31_tfboletosvalornominal ,
                                              AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                              AV113Wcboletosds_33_tfboletosvalorpago ,
                                              AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                              AV115Wcboletosds_35_tfboletosvalordesconto ,
                                              AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                              AV117Wcboletosds_37_tfboletosvalorjuros ,
                                              AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                              AV119Wcboletosds_39_tfboletosvalormulta ,
                                              AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                              AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                              AV121Wcboletosds_41_tfboletossacadonome ,
                                              AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                              AV123Wcboletosds_43_tfboletossacadodocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV81Wcboletosds_1_carteiradecobrancaid ,
                                              A1069CarteiraDeCobrancaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV94Wcboletosds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero), "%", "");
         lV96Wcboletosds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero), "%", "");
         lV98Wcboletosds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero), "%", "");
         lV121Wcboletosds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome), "%", "");
         lV123Wcboletosds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor P00FP5 */
         pr_default.execute(3, new Object[] {AV81Wcboletosds_1_carteiradecobrancaid, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV85Wcboletosds_5_boletosnossonumero1, lV85Wcboletosds_5_boletosnossonumero1, lV89Wcboletosds_9_boletosnossonumero2, lV89Wcboletosds_9_boletosnossonumero2, lV93Wcboletosds_13_boletosnossonumero3, lV93Wcboletosds_13_boletosnossonumero3, lV94Wcboletosds_14_tfboletosnossonumero, AV95Wcboletosds_15_tfboletosnossonumero_sel, lV96Wcboletosds_16_tfboletosseunumero, AV97Wcboletosds_17_tfboletosseunumero_sel, lV98Wcboletosds_18_tfboletosnumero, AV99Wcboletosds_19_tfboletosnumero_sel, AV101Wcboletosds_21_tfboletosdataemissao, AV102Wcboletosds_22_tfboletosdataemissao_to, AV103Wcboletosds_23_tfboletosdatavencimento, AV104Wcboletosds_24_tfboletosdatavencimento_to, AV105Wcboletosds_25_tfboletosdataregistro, AV106Wcboletosds_26_tfboletosdataregistro_to, AV107Wcboletosds_27_tfboletosdatapagamento, AV108Wcboletosds_28_tfboletosdatapagamento_to, AV109Wcboletosds_29_tfboletosdatabaixa, AV110Wcboletosds_30_tfboletosdatabaixa_to, AV111Wcboletosds_31_tfboletosvalornominal, AV112Wcboletosds_32_tfboletosvalornominal_to, AV113Wcboletosds_33_tfboletosvalorpago, AV114Wcboletosds_34_tfboletosvalorpago_to, AV115Wcboletosds_35_tfboletosvalordesconto, AV116Wcboletosds_36_tfboletosvalordesconto_to, AV117Wcboletosds_37_tfboletosvalorjuros, AV118Wcboletosds_38_tfboletosvalorjuros_to, AV119Wcboletosds_39_tfboletosvalormulta, AV120Wcboletosds_40_tfboletosvalormulta_to, lV121Wcboletosds_41_tfboletossacadonome, AV122Wcboletosds_42_tfboletossacadonome_sel, lV123Wcboletosds_43_tfboletossacadodocumento, AV124Wcboletosds_44_tfboletossacadodocumento_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKFP8 = false;
            A1069CarteiraDeCobrancaId = P00FP5_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = P00FP5_n1069CarteiraDeCobrancaId[0];
            A1094BoletosSacadoNome = P00FP5_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = P00FP5_n1094BoletosSacadoNome[0];
            A1093BoletosValorMulta = P00FP5_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = P00FP5_n1093BoletosValorMulta[0];
            A1092BoletosValorJuros = P00FP5_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = P00FP5_n1092BoletosValorJuros[0];
            A1091BoletosValorDesconto = P00FP5_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = P00FP5_n1091BoletosValorDesconto[0];
            A1090BoletosValorPago = P00FP5_A1090BoletosValorPago[0];
            n1090BoletosValorPago = P00FP5_n1090BoletosValorPago[0];
            A1089BoletosValorNominal = P00FP5_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = P00FP5_n1089BoletosValorNominal[0];
            A1088BoletosDataBaixa = P00FP5_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = P00FP5_n1088BoletosDataBaixa[0];
            A1087BoletosDataPagamento = P00FP5_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = P00FP5_n1087BoletosDataPagamento[0];
            A1086BoletosDataRegistro = P00FP5_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = P00FP5_n1086BoletosDataRegistro[0];
            A1085BoletosDataVencimento = P00FP5_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = P00FP5_n1085BoletosDataVencimento[0];
            A1084BoletosDataEmissao = P00FP5_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = P00FP5_n1084BoletosDataEmissao[0];
            A1096BoletosSacadoTipoDocumento = P00FP5_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = P00FP5_n1096BoletosSacadoTipoDocumento[0];
            A1095BoletosSacadoDocumento = P00FP5_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = P00FP5_n1095BoletosSacadoDocumento[0];
            A1083BoletosStatus = P00FP5_A1083BoletosStatus[0];
            n1083BoletosStatus = P00FP5_n1083BoletosStatus[0];
            A1080BoletosNumero = P00FP5_A1080BoletosNumero[0];
            n1080BoletosNumero = P00FP5_n1080BoletosNumero[0];
            A1079BoletosSeuNumero = P00FP5_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = P00FP5_n1079BoletosSeuNumero[0];
            A1078BoletosNossoNumero = P00FP5_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = P00FP5_n1078BoletosNossoNumero[0];
            A1077BoletosId = P00FP5_A1077BoletosId[0];
            AV54count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00FP5_A1069CarteiraDeCobrancaId[0] == A1069CarteiraDeCobrancaId ) && ( StringUtil.StrCmp(P00FP5_A1094BoletosSacadoNome[0], A1094BoletosSacadoNome) == 0 ) )
            {
               BRKFP8 = false;
               A1077BoletosId = P00FP5_A1077BoletosId[0];
               AV54count = (long)(AV54count+1);
               BRKFP8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV45SkipItems) )
            {
               AV49Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1094BoletosSacadoNome)) ? "<#Empty#>" : A1094BoletosSacadoNome);
               AV50Options.Add(AV49Option, 0);
               AV53OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV54count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV50Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV45SkipItems = (short)(AV45SkipItems-1);
            }
            if ( ! BRKFP8 )
            {
               BRKFP8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADBOLETOSSACADODOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV40TFBoletosSacadoDocumento = AV44SearchTxt;
         AV41TFBoletosSacadoDocumento_Sel = "";
         AV81Wcboletosds_1_carteiradecobrancaid = AV78CarteiraDeCobrancaId;
         AV82Wcboletosds_2_filterfulltext = AV66FilterFullText;
         AV83Wcboletosds_3_dynamicfiltersselector1 = AV67DynamicFiltersSelector1;
         AV84Wcboletosds_4_dynamicfiltersoperator1 = AV68DynamicFiltersOperator1;
         AV85Wcboletosds_5_boletosnossonumero1 = AV69BoletosNossoNumero1;
         AV86Wcboletosds_6_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV87Wcboletosds_7_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV88Wcboletosds_8_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV89Wcboletosds_9_boletosnossonumero2 = AV73BoletosNossoNumero2;
         AV90Wcboletosds_10_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV91Wcboletosds_11_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV92Wcboletosds_12_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV93Wcboletosds_13_boletosnossonumero3 = AV77BoletosNossoNumero3;
         AV94Wcboletosds_14_tfboletosnossonumero = AV10TFBoletosNossoNumero;
         AV95Wcboletosds_15_tfboletosnossonumero_sel = AV11TFBoletosNossoNumero_Sel;
         AV96Wcboletosds_16_tfboletosseunumero = AV12TFBoletosSeuNumero;
         AV97Wcboletosds_17_tfboletosseunumero_sel = AV13TFBoletosSeuNumero_Sel;
         AV98Wcboletosds_18_tfboletosnumero = AV14TFBoletosNumero;
         AV99Wcboletosds_19_tfboletosnumero_sel = AV15TFBoletosNumero_Sel;
         AV100Wcboletosds_20_tfboletosstatus_sels = AV17TFBoletosStatus_Sels;
         AV101Wcboletosds_21_tfboletosdataemissao = AV18TFBoletosDataEmissao;
         AV102Wcboletosds_22_tfboletosdataemissao_to = AV19TFBoletosDataEmissao_To;
         AV103Wcboletosds_23_tfboletosdatavencimento = AV20TFBoletosDataVencimento;
         AV104Wcboletosds_24_tfboletosdatavencimento_to = AV21TFBoletosDataVencimento_To;
         AV105Wcboletosds_25_tfboletosdataregistro = AV22TFBoletosDataRegistro;
         AV106Wcboletosds_26_tfboletosdataregistro_to = AV23TFBoletosDataRegistro_To;
         AV107Wcboletosds_27_tfboletosdatapagamento = AV24TFBoletosDataPagamento;
         AV108Wcboletosds_28_tfboletosdatapagamento_to = AV25TFBoletosDataPagamento_To;
         AV109Wcboletosds_29_tfboletosdatabaixa = AV26TFBoletosDataBaixa;
         AV110Wcboletosds_30_tfboletosdatabaixa_to = AV27TFBoletosDataBaixa_To;
         AV111Wcboletosds_31_tfboletosvalornominal = AV28TFBoletosValorNominal;
         AV112Wcboletosds_32_tfboletosvalornominal_to = AV29TFBoletosValorNominal_To;
         AV113Wcboletosds_33_tfboletosvalorpago = AV30TFBoletosValorPago;
         AV114Wcboletosds_34_tfboletosvalorpago_to = AV31TFBoletosValorPago_To;
         AV115Wcboletosds_35_tfboletosvalordesconto = AV32TFBoletosValorDesconto;
         AV116Wcboletosds_36_tfboletosvalordesconto_to = AV33TFBoletosValorDesconto_To;
         AV117Wcboletosds_37_tfboletosvalorjuros = AV34TFBoletosValorJuros;
         AV118Wcboletosds_38_tfboletosvalorjuros_to = AV35TFBoletosValorJuros_To;
         AV119Wcboletosds_39_tfboletosvalormulta = AV36TFBoletosValorMulta;
         AV120Wcboletosds_40_tfboletosvalormulta_to = AV37TFBoletosValorMulta_To;
         AV121Wcboletosds_41_tfboletossacadonome = AV38TFBoletosSacadoNome;
         AV122Wcboletosds_42_tfboletossacadonome_sel = AV39TFBoletosSacadoNome_Sel;
         AV123Wcboletosds_43_tfboletossacadodocumento = AV40TFBoletosSacadoDocumento;
         AV124Wcboletosds_44_tfboletossacadodocumento_sel = AV41TFBoletosSacadoDocumento_Sel;
         AV125Wcboletosds_45_tfboletossacadotipodocumento_sels = AV43TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                              AV82Wcboletosds_2_filterfulltext ,
                                              AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                              AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                              AV85Wcboletosds_5_boletosnossonumero1 ,
                                              AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                              AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                              AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                              AV89Wcboletosds_9_boletosnossonumero2 ,
                                              AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                              AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                              AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                              AV93Wcboletosds_13_boletosnossonumero3 ,
                                              AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                              AV94Wcboletosds_14_tfboletosnossonumero ,
                                              AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                              AV96Wcboletosds_16_tfboletosseunumero ,
                                              AV99Wcboletosds_19_tfboletosnumero_sel ,
                                              AV98Wcboletosds_18_tfboletosnumero ,
                                              AV100Wcboletosds_20_tfboletosstatus_sels.Count ,
                                              AV101Wcboletosds_21_tfboletosdataemissao ,
                                              AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                              AV103Wcboletosds_23_tfboletosdatavencimento ,
                                              AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                              AV105Wcboletosds_25_tfboletosdataregistro ,
                                              AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                              AV107Wcboletosds_27_tfboletosdatapagamento ,
                                              AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                              AV109Wcboletosds_29_tfboletosdatabaixa ,
                                              AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                              AV111Wcboletosds_31_tfboletosvalornominal ,
                                              AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                              AV113Wcboletosds_33_tfboletosvalorpago ,
                                              AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                              AV115Wcboletosds_35_tfboletosvalordesconto ,
                                              AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                              AV117Wcboletosds_37_tfboletosvalorjuros ,
                                              AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                              AV119Wcboletosds_39_tfboletosvalormulta ,
                                              AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                              AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                              AV121Wcboletosds_41_tfboletossacadonome ,
                                              AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                              AV123Wcboletosds_43_tfboletossacadodocumento ,
                                              AV125Wcboletosds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV81Wcboletosds_1_carteiradecobrancaid ,
                                              A1069CarteiraDeCobrancaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV82Wcboletosds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV85Wcboletosds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV89Wcboletosds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV93Wcboletosds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3), "%", "");
         lV94Wcboletosds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero), "%", "");
         lV96Wcboletosds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero), "%", "");
         lV98Wcboletosds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero), "%", "");
         lV121Wcboletosds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome), "%", "");
         lV123Wcboletosds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor P00FP6 */
         pr_default.execute(4, new Object[] {AV81Wcboletosds_1_carteiradecobrancaid, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV82Wcboletosds_2_filterfulltext, lV85Wcboletosds_5_boletosnossonumero1, lV85Wcboletosds_5_boletosnossonumero1, lV89Wcboletosds_9_boletosnossonumero2, lV89Wcboletosds_9_boletosnossonumero2, lV93Wcboletosds_13_boletosnossonumero3, lV93Wcboletosds_13_boletosnossonumero3, lV94Wcboletosds_14_tfboletosnossonumero, AV95Wcboletosds_15_tfboletosnossonumero_sel, lV96Wcboletosds_16_tfboletosseunumero, AV97Wcboletosds_17_tfboletosseunumero_sel, lV98Wcboletosds_18_tfboletosnumero, AV99Wcboletosds_19_tfboletosnumero_sel, AV101Wcboletosds_21_tfboletosdataemissao, AV102Wcboletosds_22_tfboletosdataemissao_to, AV103Wcboletosds_23_tfboletosdatavencimento, AV104Wcboletosds_24_tfboletosdatavencimento_to, AV105Wcboletosds_25_tfboletosdataregistro, AV106Wcboletosds_26_tfboletosdataregistro_to, AV107Wcboletosds_27_tfboletosdatapagamento, AV108Wcboletosds_28_tfboletosdatapagamento_to, AV109Wcboletosds_29_tfboletosdatabaixa, AV110Wcboletosds_30_tfboletosdatabaixa_to, AV111Wcboletosds_31_tfboletosvalornominal, AV112Wcboletosds_32_tfboletosvalornominal_to, AV113Wcboletosds_33_tfboletosvalorpago, AV114Wcboletosds_34_tfboletosvalorpago_to, AV115Wcboletosds_35_tfboletosvalordesconto, AV116Wcboletosds_36_tfboletosvalordesconto_to, AV117Wcboletosds_37_tfboletosvalorjuros, AV118Wcboletosds_38_tfboletosvalorjuros_to, AV119Wcboletosds_39_tfboletosvalormulta, AV120Wcboletosds_40_tfboletosvalormulta_to, lV121Wcboletosds_41_tfboletossacadonome, AV122Wcboletosds_42_tfboletossacadonome_sel, lV123Wcboletosds_43_tfboletossacadodocumento, AV124Wcboletosds_44_tfboletossacadodocumento_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKFP10 = false;
            A1069CarteiraDeCobrancaId = P00FP6_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = P00FP6_n1069CarteiraDeCobrancaId[0];
            A1095BoletosSacadoDocumento = P00FP6_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = P00FP6_n1095BoletosSacadoDocumento[0];
            A1093BoletosValorMulta = P00FP6_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = P00FP6_n1093BoletosValorMulta[0];
            A1092BoletosValorJuros = P00FP6_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = P00FP6_n1092BoletosValorJuros[0];
            A1091BoletosValorDesconto = P00FP6_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = P00FP6_n1091BoletosValorDesconto[0];
            A1090BoletosValorPago = P00FP6_A1090BoletosValorPago[0];
            n1090BoletosValorPago = P00FP6_n1090BoletosValorPago[0];
            A1089BoletosValorNominal = P00FP6_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = P00FP6_n1089BoletosValorNominal[0];
            A1088BoletosDataBaixa = P00FP6_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = P00FP6_n1088BoletosDataBaixa[0];
            A1087BoletosDataPagamento = P00FP6_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = P00FP6_n1087BoletosDataPagamento[0];
            A1086BoletosDataRegistro = P00FP6_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = P00FP6_n1086BoletosDataRegistro[0];
            A1085BoletosDataVencimento = P00FP6_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = P00FP6_n1085BoletosDataVencimento[0];
            A1084BoletosDataEmissao = P00FP6_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = P00FP6_n1084BoletosDataEmissao[0];
            A1096BoletosSacadoTipoDocumento = P00FP6_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = P00FP6_n1096BoletosSacadoTipoDocumento[0];
            A1094BoletosSacadoNome = P00FP6_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = P00FP6_n1094BoletosSacadoNome[0];
            A1083BoletosStatus = P00FP6_A1083BoletosStatus[0];
            n1083BoletosStatus = P00FP6_n1083BoletosStatus[0];
            A1080BoletosNumero = P00FP6_A1080BoletosNumero[0];
            n1080BoletosNumero = P00FP6_n1080BoletosNumero[0];
            A1079BoletosSeuNumero = P00FP6_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = P00FP6_n1079BoletosSeuNumero[0];
            A1078BoletosNossoNumero = P00FP6_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = P00FP6_n1078BoletosNossoNumero[0];
            A1077BoletosId = P00FP6_A1077BoletosId[0];
            AV54count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P00FP6_A1069CarteiraDeCobrancaId[0] == A1069CarteiraDeCobrancaId ) && ( StringUtil.StrCmp(P00FP6_A1095BoletosSacadoDocumento[0], A1095BoletosSacadoDocumento) == 0 ) )
            {
               BRKFP10 = false;
               A1077BoletosId = P00FP6_A1077BoletosId[0];
               AV54count = (long)(AV54count+1);
               BRKFP10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV45SkipItems) )
            {
               AV49Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1095BoletosSacadoDocumento)) ? "<#Empty#>" : A1095BoletosSacadoDocumento);
               AV50Options.Add(AV49Option, 0);
               AV53OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV54count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV50Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV45SkipItems = (short)(AV45SkipItems-1);
            }
            if ( ! BRKFP10 )
            {
               BRKFP10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV63OptionsJson = "";
         AV64OptionsDescJson = "";
         AV65OptionIndexesJson = "";
         AV50Options = new GxSimpleCollection<string>();
         AV52OptionsDesc = new GxSimpleCollection<string>();
         AV53OptionIndexes = new GxSimpleCollection<string>();
         AV44SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV55Session = context.GetSession();
         AV57GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV58GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV66FilterFullText = "";
         AV10TFBoletosNossoNumero = "";
         AV11TFBoletosNossoNumero_Sel = "";
         AV12TFBoletosSeuNumero = "";
         AV13TFBoletosSeuNumero_Sel = "";
         AV14TFBoletosNumero = "";
         AV15TFBoletosNumero_Sel = "";
         AV16TFBoletosStatus_SelsJson = "";
         AV17TFBoletosStatus_Sels = new GxSimpleCollection<string>();
         AV18TFBoletosDataEmissao = DateTime.MinValue;
         AV19TFBoletosDataEmissao_To = DateTime.MinValue;
         AV20TFBoletosDataVencimento = DateTime.MinValue;
         AV21TFBoletosDataVencimento_To = DateTime.MinValue;
         AV22TFBoletosDataRegistro = (DateTime)(DateTime.MinValue);
         AV23TFBoletosDataRegistro_To = (DateTime)(DateTime.MinValue);
         AV24TFBoletosDataPagamento = DateTime.MinValue;
         AV25TFBoletosDataPagamento_To = DateTime.MinValue;
         AV26TFBoletosDataBaixa = DateTime.MinValue;
         AV27TFBoletosDataBaixa_To = DateTime.MinValue;
         AV38TFBoletosSacadoNome = "";
         AV39TFBoletosSacadoNome_Sel = "";
         AV40TFBoletosSacadoDocumento = "";
         AV41TFBoletosSacadoDocumento_Sel = "";
         AV42TFBoletosSacadoTipoDocumento_SelsJson = "";
         AV43TFBoletosSacadoTipoDocumento_Sels = new GxSimpleCollection<string>();
         AV59GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV67DynamicFiltersSelector1 = "";
         AV69BoletosNossoNumero1 = "";
         AV71DynamicFiltersSelector2 = "";
         AV73BoletosNossoNumero2 = "";
         AV75DynamicFiltersSelector3 = "";
         AV77BoletosNossoNumero3 = "";
         AV82Wcboletosds_2_filterfulltext = "";
         AV83Wcboletosds_3_dynamicfiltersselector1 = "";
         AV85Wcboletosds_5_boletosnossonumero1 = "";
         AV87Wcboletosds_7_dynamicfiltersselector2 = "";
         AV89Wcboletosds_9_boletosnossonumero2 = "";
         AV91Wcboletosds_11_dynamicfiltersselector3 = "";
         AV93Wcboletosds_13_boletosnossonumero3 = "";
         AV94Wcboletosds_14_tfboletosnossonumero = "";
         AV95Wcboletosds_15_tfboletosnossonumero_sel = "";
         AV96Wcboletosds_16_tfboletosseunumero = "";
         AV97Wcboletosds_17_tfboletosseunumero_sel = "";
         AV98Wcboletosds_18_tfboletosnumero = "";
         AV99Wcboletosds_19_tfboletosnumero_sel = "";
         AV100Wcboletosds_20_tfboletosstatus_sels = new GxSimpleCollection<string>();
         AV101Wcboletosds_21_tfboletosdataemissao = DateTime.MinValue;
         AV102Wcboletosds_22_tfboletosdataemissao_to = DateTime.MinValue;
         AV103Wcboletosds_23_tfboletosdatavencimento = DateTime.MinValue;
         AV104Wcboletosds_24_tfboletosdatavencimento_to = DateTime.MinValue;
         AV105Wcboletosds_25_tfboletosdataregistro = (DateTime)(DateTime.MinValue);
         AV106Wcboletosds_26_tfboletosdataregistro_to = (DateTime)(DateTime.MinValue);
         AV107Wcboletosds_27_tfboletosdatapagamento = DateTime.MinValue;
         AV108Wcboletosds_28_tfboletosdatapagamento_to = DateTime.MinValue;
         AV109Wcboletosds_29_tfboletosdatabaixa = DateTime.MinValue;
         AV110Wcboletosds_30_tfboletosdatabaixa_to = DateTime.MinValue;
         AV121Wcboletosds_41_tfboletossacadonome = "";
         AV122Wcboletosds_42_tfboletossacadonome_sel = "";
         AV123Wcboletosds_43_tfboletossacadodocumento = "";
         AV124Wcboletosds_44_tfboletossacadodocumento_sel = "";
         AV125Wcboletosds_45_tfboletossacadotipodocumento_sels = new GxSimpleCollection<string>();
         lV82Wcboletosds_2_filterfulltext = "";
         lV85Wcboletosds_5_boletosnossonumero1 = "";
         lV89Wcboletosds_9_boletosnossonumero2 = "";
         lV93Wcboletosds_13_boletosnossonumero3 = "";
         lV94Wcboletosds_14_tfboletosnossonumero = "";
         lV96Wcboletosds_16_tfboletosseunumero = "";
         lV98Wcboletosds_18_tfboletosnumero = "";
         lV121Wcboletosds_41_tfboletossacadonome = "";
         lV123Wcboletosds_43_tfboletossacadodocumento = "";
         A1083BoletosStatus = "";
         A1096BoletosSacadoTipoDocumento = "";
         A1078BoletosNossoNumero = "";
         A1079BoletosSeuNumero = "";
         A1080BoletosNumero = "";
         A1094BoletosSacadoNome = "";
         A1095BoletosSacadoDocumento = "";
         A1084BoletosDataEmissao = DateTime.MinValue;
         A1085BoletosDataVencimento = DateTime.MinValue;
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         A1087BoletosDataPagamento = DateTime.MinValue;
         A1088BoletosDataBaixa = DateTime.MinValue;
         P00FP2_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FP2_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FP2_A1078BoletosNossoNumero = new string[] {""} ;
         P00FP2_n1078BoletosNossoNumero = new bool[] {false} ;
         P00FP2_A1093BoletosValorMulta = new decimal[1] ;
         P00FP2_n1093BoletosValorMulta = new bool[] {false} ;
         P00FP2_A1092BoletosValorJuros = new decimal[1] ;
         P00FP2_n1092BoletosValorJuros = new bool[] {false} ;
         P00FP2_A1091BoletosValorDesconto = new decimal[1] ;
         P00FP2_n1091BoletosValorDesconto = new bool[] {false} ;
         P00FP2_A1090BoletosValorPago = new decimal[1] ;
         P00FP2_n1090BoletosValorPago = new bool[] {false} ;
         P00FP2_A1089BoletosValorNominal = new decimal[1] ;
         P00FP2_n1089BoletosValorNominal = new bool[] {false} ;
         P00FP2_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         P00FP2_n1088BoletosDataBaixa = new bool[] {false} ;
         P00FP2_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         P00FP2_n1087BoletosDataPagamento = new bool[] {false} ;
         P00FP2_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         P00FP2_n1086BoletosDataRegistro = new bool[] {false} ;
         P00FP2_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00FP2_n1085BoletosDataVencimento = new bool[] {false} ;
         P00FP2_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00FP2_n1084BoletosDataEmissao = new bool[] {false} ;
         P00FP2_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         P00FP2_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         P00FP2_A1095BoletosSacadoDocumento = new string[] {""} ;
         P00FP2_n1095BoletosSacadoDocumento = new bool[] {false} ;
         P00FP2_A1094BoletosSacadoNome = new string[] {""} ;
         P00FP2_n1094BoletosSacadoNome = new bool[] {false} ;
         P00FP2_A1083BoletosStatus = new string[] {""} ;
         P00FP2_n1083BoletosStatus = new bool[] {false} ;
         P00FP2_A1080BoletosNumero = new string[] {""} ;
         P00FP2_n1080BoletosNumero = new bool[] {false} ;
         P00FP2_A1079BoletosSeuNumero = new string[] {""} ;
         P00FP2_n1079BoletosSeuNumero = new bool[] {false} ;
         P00FP2_A1077BoletosId = new int[1] ;
         AV49Option = "";
         P00FP3_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FP3_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FP3_A1079BoletosSeuNumero = new string[] {""} ;
         P00FP3_n1079BoletosSeuNumero = new bool[] {false} ;
         P00FP3_A1093BoletosValorMulta = new decimal[1] ;
         P00FP3_n1093BoletosValorMulta = new bool[] {false} ;
         P00FP3_A1092BoletosValorJuros = new decimal[1] ;
         P00FP3_n1092BoletosValorJuros = new bool[] {false} ;
         P00FP3_A1091BoletosValorDesconto = new decimal[1] ;
         P00FP3_n1091BoletosValorDesconto = new bool[] {false} ;
         P00FP3_A1090BoletosValorPago = new decimal[1] ;
         P00FP3_n1090BoletosValorPago = new bool[] {false} ;
         P00FP3_A1089BoletosValorNominal = new decimal[1] ;
         P00FP3_n1089BoletosValorNominal = new bool[] {false} ;
         P00FP3_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         P00FP3_n1088BoletosDataBaixa = new bool[] {false} ;
         P00FP3_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         P00FP3_n1087BoletosDataPagamento = new bool[] {false} ;
         P00FP3_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         P00FP3_n1086BoletosDataRegistro = new bool[] {false} ;
         P00FP3_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00FP3_n1085BoletosDataVencimento = new bool[] {false} ;
         P00FP3_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00FP3_n1084BoletosDataEmissao = new bool[] {false} ;
         P00FP3_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         P00FP3_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         P00FP3_A1095BoletosSacadoDocumento = new string[] {""} ;
         P00FP3_n1095BoletosSacadoDocumento = new bool[] {false} ;
         P00FP3_A1094BoletosSacadoNome = new string[] {""} ;
         P00FP3_n1094BoletosSacadoNome = new bool[] {false} ;
         P00FP3_A1083BoletosStatus = new string[] {""} ;
         P00FP3_n1083BoletosStatus = new bool[] {false} ;
         P00FP3_A1080BoletosNumero = new string[] {""} ;
         P00FP3_n1080BoletosNumero = new bool[] {false} ;
         P00FP3_A1078BoletosNossoNumero = new string[] {""} ;
         P00FP3_n1078BoletosNossoNumero = new bool[] {false} ;
         P00FP3_A1077BoletosId = new int[1] ;
         P00FP4_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FP4_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FP4_A1080BoletosNumero = new string[] {""} ;
         P00FP4_n1080BoletosNumero = new bool[] {false} ;
         P00FP4_A1093BoletosValorMulta = new decimal[1] ;
         P00FP4_n1093BoletosValorMulta = new bool[] {false} ;
         P00FP4_A1092BoletosValorJuros = new decimal[1] ;
         P00FP4_n1092BoletosValorJuros = new bool[] {false} ;
         P00FP4_A1091BoletosValorDesconto = new decimal[1] ;
         P00FP4_n1091BoletosValorDesconto = new bool[] {false} ;
         P00FP4_A1090BoletosValorPago = new decimal[1] ;
         P00FP4_n1090BoletosValorPago = new bool[] {false} ;
         P00FP4_A1089BoletosValorNominal = new decimal[1] ;
         P00FP4_n1089BoletosValorNominal = new bool[] {false} ;
         P00FP4_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         P00FP4_n1088BoletosDataBaixa = new bool[] {false} ;
         P00FP4_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         P00FP4_n1087BoletosDataPagamento = new bool[] {false} ;
         P00FP4_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         P00FP4_n1086BoletosDataRegistro = new bool[] {false} ;
         P00FP4_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00FP4_n1085BoletosDataVencimento = new bool[] {false} ;
         P00FP4_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00FP4_n1084BoletosDataEmissao = new bool[] {false} ;
         P00FP4_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         P00FP4_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         P00FP4_A1095BoletosSacadoDocumento = new string[] {""} ;
         P00FP4_n1095BoletosSacadoDocumento = new bool[] {false} ;
         P00FP4_A1094BoletosSacadoNome = new string[] {""} ;
         P00FP4_n1094BoletosSacadoNome = new bool[] {false} ;
         P00FP4_A1083BoletosStatus = new string[] {""} ;
         P00FP4_n1083BoletosStatus = new bool[] {false} ;
         P00FP4_A1079BoletosSeuNumero = new string[] {""} ;
         P00FP4_n1079BoletosSeuNumero = new bool[] {false} ;
         P00FP4_A1078BoletosNossoNumero = new string[] {""} ;
         P00FP4_n1078BoletosNossoNumero = new bool[] {false} ;
         P00FP4_A1077BoletosId = new int[1] ;
         P00FP5_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FP5_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FP5_A1094BoletosSacadoNome = new string[] {""} ;
         P00FP5_n1094BoletosSacadoNome = new bool[] {false} ;
         P00FP5_A1093BoletosValorMulta = new decimal[1] ;
         P00FP5_n1093BoletosValorMulta = new bool[] {false} ;
         P00FP5_A1092BoletosValorJuros = new decimal[1] ;
         P00FP5_n1092BoletosValorJuros = new bool[] {false} ;
         P00FP5_A1091BoletosValorDesconto = new decimal[1] ;
         P00FP5_n1091BoletosValorDesconto = new bool[] {false} ;
         P00FP5_A1090BoletosValorPago = new decimal[1] ;
         P00FP5_n1090BoletosValorPago = new bool[] {false} ;
         P00FP5_A1089BoletosValorNominal = new decimal[1] ;
         P00FP5_n1089BoletosValorNominal = new bool[] {false} ;
         P00FP5_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         P00FP5_n1088BoletosDataBaixa = new bool[] {false} ;
         P00FP5_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         P00FP5_n1087BoletosDataPagamento = new bool[] {false} ;
         P00FP5_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         P00FP5_n1086BoletosDataRegistro = new bool[] {false} ;
         P00FP5_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00FP5_n1085BoletosDataVencimento = new bool[] {false} ;
         P00FP5_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00FP5_n1084BoletosDataEmissao = new bool[] {false} ;
         P00FP5_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         P00FP5_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         P00FP5_A1095BoletosSacadoDocumento = new string[] {""} ;
         P00FP5_n1095BoletosSacadoDocumento = new bool[] {false} ;
         P00FP5_A1083BoletosStatus = new string[] {""} ;
         P00FP5_n1083BoletosStatus = new bool[] {false} ;
         P00FP5_A1080BoletosNumero = new string[] {""} ;
         P00FP5_n1080BoletosNumero = new bool[] {false} ;
         P00FP5_A1079BoletosSeuNumero = new string[] {""} ;
         P00FP5_n1079BoletosSeuNumero = new bool[] {false} ;
         P00FP5_A1078BoletosNossoNumero = new string[] {""} ;
         P00FP5_n1078BoletosNossoNumero = new bool[] {false} ;
         P00FP5_A1077BoletosId = new int[1] ;
         P00FP6_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FP6_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FP6_A1095BoletosSacadoDocumento = new string[] {""} ;
         P00FP6_n1095BoletosSacadoDocumento = new bool[] {false} ;
         P00FP6_A1093BoletosValorMulta = new decimal[1] ;
         P00FP6_n1093BoletosValorMulta = new bool[] {false} ;
         P00FP6_A1092BoletosValorJuros = new decimal[1] ;
         P00FP6_n1092BoletosValorJuros = new bool[] {false} ;
         P00FP6_A1091BoletosValorDesconto = new decimal[1] ;
         P00FP6_n1091BoletosValorDesconto = new bool[] {false} ;
         P00FP6_A1090BoletosValorPago = new decimal[1] ;
         P00FP6_n1090BoletosValorPago = new bool[] {false} ;
         P00FP6_A1089BoletosValorNominal = new decimal[1] ;
         P00FP6_n1089BoletosValorNominal = new bool[] {false} ;
         P00FP6_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         P00FP6_n1088BoletosDataBaixa = new bool[] {false} ;
         P00FP6_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         P00FP6_n1087BoletosDataPagamento = new bool[] {false} ;
         P00FP6_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         P00FP6_n1086BoletosDataRegistro = new bool[] {false} ;
         P00FP6_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00FP6_n1085BoletosDataVencimento = new bool[] {false} ;
         P00FP6_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00FP6_n1084BoletosDataEmissao = new bool[] {false} ;
         P00FP6_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         P00FP6_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         P00FP6_A1094BoletosSacadoNome = new string[] {""} ;
         P00FP6_n1094BoletosSacadoNome = new bool[] {false} ;
         P00FP6_A1083BoletosStatus = new string[] {""} ;
         P00FP6_n1083BoletosStatus = new bool[] {false} ;
         P00FP6_A1080BoletosNumero = new string[] {""} ;
         P00FP6_n1080BoletosNumero = new bool[] {false} ;
         P00FP6_A1079BoletosSeuNumero = new string[] {""} ;
         P00FP6_n1079BoletosSeuNumero = new bool[] {false} ;
         P00FP6_A1078BoletosNossoNumero = new string[] {""} ;
         P00FP6_n1078BoletosNossoNumero = new bool[] {false} ;
         P00FP6_A1077BoletosId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcboletosgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00FP2_A1069CarteiraDeCobrancaId, P00FP2_n1069CarteiraDeCobrancaId, P00FP2_A1078BoletosNossoNumero, P00FP2_n1078BoletosNossoNumero, P00FP2_A1093BoletosValorMulta, P00FP2_n1093BoletosValorMulta, P00FP2_A1092BoletosValorJuros, P00FP2_n1092BoletosValorJuros, P00FP2_A1091BoletosValorDesconto, P00FP2_n1091BoletosValorDesconto,
               P00FP2_A1090BoletosValorPago, P00FP2_n1090BoletosValorPago, P00FP2_A1089BoletosValorNominal, P00FP2_n1089BoletosValorNominal, P00FP2_A1088BoletosDataBaixa, P00FP2_n1088BoletosDataBaixa, P00FP2_A1087BoletosDataPagamento, P00FP2_n1087BoletosDataPagamento, P00FP2_A1086BoletosDataRegistro, P00FP2_n1086BoletosDataRegistro,
               P00FP2_A1085BoletosDataVencimento, P00FP2_n1085BoletosDataVencimento, P00FP2_A1084BoletosDataEmissao, P00FP2_n1084BoletosDataEmissao, P00FP2_A1096BoletosSacadoTipoDocumento, P00FP2_n1096BoletosSacadoTipoDocumento, P00FP2_A1095BoletosSacadoDocumento, P00FP2_n1095BoletosSacadoDocumento, P00FP2_A1094BoletosSacadoNome, P00FP2_n1094BoletosSacadoNome,
               P00FP2_A1083BoletosStatus, P00FP2_n1083BoletosStatus, P00FP2_A1080BoletosNumero, P00FP2_n1080BoletosNumero, P00FP2_A1079BoletosSeuNumero, P00FP2_n1079BoletosSeuNumero, P00FP2_A1077BoletosId
               }
               , new Object[] {
               P00FP3_A1069CarteiraDeCobrancaId, P00FP3_n1069CarteiraDeCobrancaId, P00FP3_A1079BoletosSeuNumero, P00FP3_n1079BoletosSeuNumero, P00FP3_A1093BoletosValorMulta, P00FP3_n1093BoletosValorMulta, P00FP3_A1092BoletosValorJuros, P00FP3_n1092BoletosValorJuros, P00FP3_A1091BoletosValorDesconto, P00FP3_n1091BoletosValorDesconto,
               P00FP3_A1090BoletosValorPago, P00FP3_n1090BoletosValorPago, P00FP3_A1089BoletosValorNominal, P00FP3_n1089BoletosValorNominal, P00FP3_A1088BoletosDataBaixa, P00FP3_n1088BoletosDataBaixa, P00FP3_A1087BoletosDataPagamento, P00FP3_n1087BoletosDataPagamento, P00FP3_A1086BoletosDataRegistro, P00FP3_n1086BoletosDataRegistro,
               P00FP3_A1085BoletosDataVencimento, P00FP3_n1085BoletosDataVencimento, P00FP3_A1084BoletosDataEmissao, P00FP3_n1084BoletosDataEmissao, P00FP3_A1096BoletosSacadoTipoDocumento, P00FP3_n1096BoletosSacadoTipoDocumento, P00FP3_A1095BoletosSacadoDocumento, P00FP3_n1095BoletosSacadoDocumento, P00FP3_A1094BoletosSacadoNome, P00FP3_n1094BoletosSacadoNome,
               P00FP3_A1083BoletosStatus, P00FP3_n1083BoletosStatus, P00FP3_A1080BoletosNumero, P00FP3_n1080BoletosNumero, P00FP3_A1078BoletosNossoNumero, P00FP3_n1078BoletosNossoNumero, P00FP3_A1077BoletosId
               }
               , new Object[] {
               P00FP4_A1069CarteiraDeCobrancaId, P00FP4_n1069CarteiraDeCobrancaId, P00FP4_A1080BoletosNumero, P00FP4_n1080BoletosNumero, P00FP4_A1093BoletosValorMulta, P00FP4_n1093BoletosValorMulta, P00FP4_A1092BoletosValorJuros, P00FP4_n1092BoletosValorJuros, P00FP4_A1091BoletosValorDesconto, P00FP4_n1091BoletosValorDesconto,
               P00FP4_A1090BoletosValorPago, P00FP4_n1090BoletosValorPago, P00FP4_A1089BoletosValorNominal, P00FP4_n1089BoletosValorNominal, P00FP4_A1088BoletosDataBaixa, P00FP4_n1088BoletosDataBaixa, P00FP4_A1087BoletosDataPagamento, P00FP4_n1087BoletosDataPagamento, P00FP4_A1086BoletosDataRegistro, P00FP4_n1086BoletosDataRegistro,
               P00FP4_A1085BoletosDataVencimento, P00FP4_n1085BoletosDataVencimento, P00FP4_A1084BoletosDataEmissao, P00FP4_n1084BoletosDataEmissao, P00FP4_A1096BoletosSacadoTipoDocumento, P00FP4_n1096BoletosSacadoTipoDocumento, P00FP4_A1095BoletosSacadoDocumento, P00FP4_n1095BoletosSacadoDocumento, P00FP4_A1094BoletosSacadoNome, P00FP4_n1094BoletosSacadoNome,
               P00FP4_A1083BoletosStatus, P00FP4_n1083BoletosStatus, P00FP4_A1079BoletosSeuNumero, P00FP4_n1079BoletosSeuNumero, P00FP4_A1078BoletosNossoNumero, P00FP4_n1078BoletosNossoNumero, P00FP4_A1077BoletosId
               }
               , new Object[] {
               P00FP5_A1069CarteiraDeCobrancaId, P00FP5_n1069CarteiraDeCobrancaId, P00FP5_A1094BoletosSacadoNome, P00FP5_n1094BoletosSacadoNome, P00FP5_A1093BoletosValorMulta, P00FP5_n1093BoletosValorMulta, P00FP5_A1092BoletosValorJuros, P00FP5_n1092BoletosValorJuros, P00FP5_A1091BoletosValorDesconto, P00FP5_n1091BoletosValorDesconto,
               P00FP5_A1090BoletosValorPago, P00FP5_n1090BoletosValorPago, P00FP5_A1089BoletosValorNominal, P00FP5_n1089BoletosValorNominal, P00FP5_A1088BoletosDataBaixa, P00FP5_n1088BoletosDataBaixa, P00FP5_A1087BoletosDataPagamento, P00FP5_n1087BoletosDataPagamento, P00FP5_A1086BoletosDataRegistro, P00FP5_n1086BoletosDataRegistro,
               P00FP5_A1085BoletosDataVencimento, P00FP5_n1085BoletosDataVencimento, P00FP5_A1084BoletosDataEmissao, P00FP5_n1084BoletosDataEmissao, P00FP5_A1096BoletosSacadoTipoDocumento, P00FP5_n1096BoletosSacadoTipoDocumento, P00FP5_A1095BoletosSacadoDocumento, P00FP5_n1095BoletosSacadoDocumento, P00FP5_A1083BoletosStatus, P00FP5_n1083BoletosStatus,
               P00FP5_A1080BoletosNumero, P00FP5_n1080BoletosNumero, P00FP5_A1079BoletosSeuNumero, P00FP5_n1079BoletosSeuNumero, P00FP5_A1078BoletosNossoNumero, P00FP5_n1078BoletosNossoNumero, P00FP5_A1077BoletosId
               }
               , new Object[] {
               P00FP6_A1069CarteiraDeCobrancaId, P00FP6_n1069CarteiraDeCobrancaId, P00FP6_A1095BoletosSacadoDocumento, P00FP6_n1095BoletosSacadoDocumento, P00FP6_A1093BoletosValorMulta, P00FP6_n1093BoletosValorMulta, P00FP6_A1092BoletosValorJuros, P00FP6_n1092BoletosValorJuros, P00FP6_A1091BoletosValorDesconto, P00FP6_n1091BoletosValorDesconto,
               P00FP6_A1090BoletosValorPago, P00FP6_n1090BoletosValorPago, P00FP6_A1089BoletosValorNominal, P00FP6_n1089BoletosValorNominal, P00FP6_A1088BoletosDataBaixa, P00FP6_n1088BoletosDataBaixa, P00FP6_A1087BoletosDataPagamento, P00FP6_n1087BoletosDataPagamento, P00FP6_A1086BoletosDataRegistro, P00FP6_n1086BoletosDataRegistro,
               P00FP6_A1085BoletosDataVencimento, P00FP6_n1085BoletosDataVencimento, P00FP6_A1084BoletosDataEmissao, P00FP6_n1084BoletosDataEmissao, P00FP6_A1096BoletosSacadoTipoDocumento, P00FP6_n1096BoletosSacadoTipoDocumento, P00FP6_A1094BoletosSacadoNome, P00FP6_n1094BoletosSacadoNome, P00FP6_A1083BoletosStatus, P00FP6_n1083BoletosStatus,
               P00FP6_A1080BoletosNumero, P00FP6_n1080BoletosNumero, P00FP6_A1079BoletosSeuNumero, P00FP6_n1079BoletosSeuNumero, P00FP6_A1078BoletosNossoNumero, P00FP6_n1078BoletosNossoNumero, P00FP6_A1077BoletosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV47MaxItems ;
      private short AV46PageIndex ;
      private short AV45SkipItems ;
      private short AV68DynamicFiltersOperator1 ;
      private short AV72DynamicFiltersOperator2 ;
      private short AV76DynamicFiltersOperator3 ;
      private short AV84Wcboletosds_4_dynamicfiltersoperator1 ;
      private short AV88Wcboletosds_8_dynamicfiltersoperator2 ;
      private short AV92Wcboletosds_12_dynamicfiltersoperator3 ;
      private int AV79GXV1 ;
      private int AV78CarteiraDeCobrancaId ;
      private int AV81Wcboletosds_1_carteiradecobrancaid ;
      private int AV100Wcboletosds_20_tfboletosstatus_sels_Count ;
      private int AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count ;
      private int A1069CarteiraDeCobrancaId ;
      private int A1077BoletosId ;
      private long AV54count ;
      private decimal AV28TFBoletosValorNominal ;
      private decimal AV29TFBoletosValorNominal_To ;
      private decimal AV30TFBoletosValorPago ;
      private decimal AV31TFBoletosValorPago_To ;
      private decimal AV32TFBoletosValorDesconto ;
      private decimal AV33TFBoletosValorDesconto_To ;
      private decimal AV34TFBoletosValorJuros ;
      private decimal AV35TFBoletosValorJuros_To ;
      private decimal AV36TFBoletosValorMulta ;
      private decimal AV37TFBoletosValorMulta_To ;
      private decimal AV111Wcboletosds_31_tfboletosvalornominal ;
      private decimal AV112Wcboletosds_32_tfboletosvalornominal_to ;
      private decimal AV113Wcboletosds_33_tfboletosvalorpago ;
      private decimal AV114Wcboletosds_34_tfboletosvalorpago_to ;
      private decimal AV115Wcboletosds_35_tfboletosvalordesconto ;
      private decimal AV116Wcboletosds_36_tfboletosvalordesconto_to ;
      private decimal AV117Wcboletosds_37_tfboletosvalorjuros ;
      private decimal AV118Wcboletosds_38_tfboletosvalorjuros_to ;
      private decimal AV119Wcboletosds_39_tfboletosvalormulta ;
      private decimal AV120Wcboletosds_40_tfboletosvalormulta_to ;
      private decimal A1089BoletosValorNominal ;
      private decimal A1090BoletosValorPago ;
      private decimal A1091BoletosValorDesconto ;
      private decimal A1092BoletosValorJuros ;
      private decimal A1093BoletosValorMulta ;
      private DateTime AV22TFBoletosDataRegistro ;
      private DateTime AV23TFBoletosDataRegistro_To ;
      private DateTime AV105Wcboletosds_25_tfboletosdataregistro ;
      private DateTime AV106Wcboletosds_26_tfboletosdataregistro_to ;
      private DateTime A1086BoletosDataRegistro ;
      private DateTime AV18TFBoletosDataEmissao ;
      private DateTime AV19TFBoletosDataEmissao_To ;
      private DateTime AV20TFBoletosDataVencimento ;
      private DateTime AV21TFBoletosDataVencimento_To ;
      private DateTime AV24TFBoletosDataPagamento ;
      private DateTime AV25TFBoletosDataPagamento_To ;
      private DateTime AV26TFBoletosDataBaixa ;
      private DateTime AV27TFBoletosDataBaixa_To ;
      private DateTime AV101Wcboletosds_21_tfboletosdataemissao ;
      private DateTime AV102Wcboletosds_22_tfboletosdataemissao_to ;
      private DateTime AV103Wcboletosds_23_tfboletosdatavencimento ;
      private DateTime AV104Wcboletosds_24_tfboletosdatavencimento_to ;
      private DateTime AV107Wcboletosds_27_tfboletosdatapagamento ;
      private DateTime AV108Wcboletosds_28_tfboletosdatapagamento_to ;
      private DateTime AV109Wcboletosds_29_tfboletosdatabaixa ;
      private DateTime AV110Wcboletosds_30_tfboletosdatabaixa_to ;
      private DateTime A1084BoletosDataEmissao ;
      private DateTime A1085BoletosDataVencimento ;
      private DateTime A1087BoletosDataPagamento ;
      private DateTime A1088BoletosDataBaixa ;
      private bool returnInSub ;
      private bool AV70DynamicFiltersEnabled2 ;
      private bool AV74DynamicFiltersEnabled3 ;
      private bool AV86Wcboletosds_6_dynamicfiltersenabled2 ;
      private bool AV90Wcboletosds_10_dynamicfiltersenabled3 ;
      private bool BRKFP2 ;
      private bool n1069CarteiraDeCobrancaId ;
      private bool n1078BoletosNossoNumero ;
      private bool n1093BoletosValorMulta ;
      private bool n1092BoletosValorJuros ;
      private bool n1091BoletosValorDesconto ;
      private bool n1090BoletosValorPago ;
      private bool n1089BoletosValorNominal ;
      private bool n1088BoletosDataBaixa ;
      private bool n1087BoletosDataPagamento ;
      private bool n1086BoletosDataRegistro ;
      private bool n1085BoletosDataVencimento ;
      private bool n1084BoletosDataEmissao ;
      private bool n1096BoletosSacadoTipoDocumento ;
      private bool n1095BoletosSacadoDocumento ;
      private bool n1094BoletosSacadoNome ;
      private bool n1083BoletosStatus ;
      private bool n1080BoletosNumero ;
      private bool n1079BoletosSeuNumero ;
      private bool BRKFP4 ;
      private bool BRKFP6 ;
      private bool BRKFP8 ;
      private bool BRKFP10 ;
      private string AV63OptionsJson ;
      private string AV64OptionsDescJson ;
      private string AV65OptionIndexesJson ;
      private string AV16TFBoletosStatus_SelsJson ;
      private string AV42TFBoletosSacadoTipoDocumento_SelsJson ;
      private string AV60DDOName ;
      private string AV61SearchTxtParms ;
      private string AV62SearchTxtTo ;
      private string AV44SearchTxt ;
      private string AV66FilterFullText ;
      private string AV10TFBoletosNossoNumero ;
      private string AV11TFBoletosNossoNumero_Sel ;
      private string AV12TFBoletosSeuNumero ;
      private string AV13TFBoletosSeuNumero_Sel ;
      private string AV14TFBoletosNumero ;
      private string AV15TFBoletosNumero_Sel ;
      private string AV38TFBoletosSacadoNome ;
      private string AV39TFBoletosSacadoNome_Sel ;
      private string AV40TFBoletosSacadoDocumento ;
      private string AV41TFBoletosSacadoDocumento_Sel ;
      private string AV67DynamicFiltersSelector1 ;
      private string AV69BoletosNossoNumero1 ;
      private string AV71DynamicFiltersSelector2 ;
      private string AV73BoletosNossoNumero2 ;
      private string AV75DynamicFiltersSelector3 ;
      private string AV77BoletosNossoNumero3 ;
      private string AV82Wcboletosds_2_filterfulltext ;
      private string AV83Wcboletosds_3_dynamicfiltersselector1 ;
      private string AV85Wcboletosds_5_boletosnossonumero1 ;
      private string AV87Wcboletosds_7_dynamicfiltersselector2 ;
      private string AV89Wcboletosds_9_boletosnossonumero2 ;
      private string AV91Wcboletosds_11_dynamicfiltersselector3 ;
      private string AV93Wcboletosds_13_boletosnossonumero3 ;
      private string AV94Wcboletosds_14_tfboletosnossonumero ;
      private string AV95Wcboletosds_15_tfboletosnossonumero_sel ;
      private string AV96Wcboletosds_16_tfboletosseunumero ;
      private string AV97Wcboletosds_17_tfboletosseunumero_sel ;
      private string AV98Wcboletosds_18_tfboletosnumero ;
      private string AV99Wcboletosds_19_tfboletosnumero_sel ;
      private string AV121Wcboletosds_41_tfboletossacadonome ;
      private string AV122Wcboletosds_42_tfboletossacadonome_sel ;
      private string AV123Wcboletosds_43_tfboletossacadodocumento ;
      private string AV124Wcboletosds_44_tfboletossacadodocumento_sel ;
      private string lV82Wcboletosds_2_filterfulltext ;
      private string lV85Wcboletosds_5_boletosnossonumero1 ;
      private string lV89Wcboletosds_9_boletosnossonumero2 ;
      private string lV93Wcboletosds_13_boletosnossonumero3 ;
      private string lV94Wcboletosds_14_tfboletosnossonumero ;
      private string lV96Wcboletosds_16_tfboletosseunumero ;
      private string lV98Wcboletosds_18_tfboletosnumero ;
      private string lV121Wcboletosds_41_tfboletossacadonome ;
      private string lV123Wcboletosds_43_tfboletossacadodocumento ;
      private string A1083BoletosStatus ;
      private string A1096BoletosSacadoTipoDocumento ;
      private string A1078BoletosNossoNumero ;
      private string A1079BoletosSeuNumero ;
      private string A1080BoletosNumero ;
      private string A1094BoletosSacadoNome ;
      private string A1095BoletosSacadoDocumento ;
      private string AV49Option ;
      private IGxSession AV55Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV50Options ;
      private GxSimpleCollection<string> AV52OptionsDesc ;
      private GxSimpleCollection<string> AV53OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV57GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV58GridStateFilterValue ;
      private GxSimpleCollection<string> AV17TFBoletosStatus_Sels ;
      private GxSimpleCollection<string> AV43TFBoletosSacadoTipoDocumento_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV59GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV100Wcboletosds_20_tfboletosstatus_sels ;
      private GxSimpleCollection<string> AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00FP2_A1069CarteiraDeCobrancaId ;
      private bool[] P00FP2_n1069CarteiraDeCobrancaId ;
      private string[] P00FP2_A1078BoletosNossoNumero ;
      private bool[] P00FP2_n1078BoletosNossoNumero ;
      private decimal[] P00FP2_A1093BoletosValorMulta ;
      private bool[] P00FP2_n1093BoletosValorMulta ;
      private decimal[] P00FP2_A1092BoletosValorJuros ;
      private bool[] P00FP2_n1092BoletosValorJuros ;
      private decimal[] P00FP2_A1091BoletosValorDesconto ;
      private bool[] P00FP2_n1091BoletosValorDesconto ;
      private decimal[] P00FP2_A1090BoletosValorPago ;
      private bool[] P00FP2_n1090BoletosValorPago ;
      private decimal[] P00FP2_A1089BoletosValorNominal ;
      private bool[] P00FP2_n1089BoletosValorNominal ;
      private DateTime[] P00FP2_A1088BoletosDataBaixa ;
      private bool[] P00FP2_n1088BoletosDataBaixa ;
      private DateTime[] P00FP2_A1087BoletosDataPagamento ;
      private bool[] P00FP2_n1087BoletosDataPagamento ;
      private DateTime[] P00FP2_A1086BoletosDataRegistro ;
      private bool[] P00FP2_n1086BoletosDataRegistro ;
      private DateTime[] P00FP2_A1085BoletosDataVencimento ;
      private bool[] P00FP2_n1085BoletosDataVencimento ;
      private DateTime[] P00FP2_A1084BoletosDataEmissao ;
      private bool[] P00FP2_n1084BoletosDataEmissao ;
      private string[] P00FP2_A1096BoletosSacadoTipoDocumento ;
      private bool[] P00FP2_n1096BoletosSacadoTipoDocumento ;
      private string[] P00FP2_A1095BoletosSacadoDocumento ;
      private bool[] P00FP2_n1095BoletosSacadoDocumento ;
      private string[] P00FP2_A1094BoletosSacadoNome ;
      private bool[] P00FP2_n1094BoletosSacadoNome ;
      private string[] P00FP2_A1083BoletosStatus ;
      private bool[] P00FP2_n1083BoletosStatus ;
      private string[] P00FP2_A1080BoletosNumero ;
      private bool[] P00FP2_n1080BoletosNumero ;
      private string[] P00FP2_A1079BoletosSeuNumero ;
      private bool[] P00FP2_n1079BoletosSeuNumero ;
      private int[] P00FP2_A1077BoletosId ;
      private int[] P00FP3_A1069CarteiraDeCobrancaId ;
      private bool[] P00FP3_n1069CarteiraDeCobrancaId ;
      private string[] P00FP3_A1079BoletosSeuNumero ;
      private bool[] P00FP3_n1079BoletosSeuNumero ;
      private decimal[] P00FP3_A1093BoletosValorMulta ;
      private bool[] P00FP3_n1093BoletosValorMulta ;
      private decimal[] P00FP3_A1092BoletosValorJuros ;
      private bool[] P00FP3_n1092BoletosValorJuros ;
      private decimal[] P00FP3_A1091BoletosValorDesconto ;
      private bool[] P00FP3_n1091BoletosValorDesconto ;
      private decimal[] P00FP3_A1090BoletosValorPago ;
      private bool[] P00FP3_n1090BoletosValorPago ;
      private decimal[] P00FP3_A1089BoletosValorNominal ;
      private bool[] P00FP3_n1089BoletosValorNominal ;
      private DateTime[] P00FP3_A1088BoletosDataBaixa ;
      private bool[] P00FP3_n1088BoletosDataBaixa ;
      private DateTime[] P00FP3_A1087BoletosDataPagamento ;
      private bool[] P00FP3_n1087BoletosDataPagamento ;
      private DateTime[] P00FP3_A1086BoletosDataRegistro ;
      private bool[] P00FP3_n1086BoletosDataRegistro ;
      private DateTime[] P00FP3_A1085BoletosDataVencimento ;
      private bool[] P00FP3_n1085BoletosDataVencimento ;
      private DateTime[] P00FP3_A1084BoletosDataEmissao ;
      private bool[] P00FP3_n1084BoletosDataEmissao ;
      private string[] P00FP3_A1096BoletosSacadoTipoDocumento ;
      private bool[] P00FP3_n1096BoletosSacadoTipoDocumento ;
      private string[] P00FP3_A1095BoletosSacadoDocumento ;
      private bool[] P00FP3_n1095BoletosSacadoDocumento ;
      private string[] P00FP3_A1094BoletosSacadoNome ;
      private bool[] P00FP3_n1094BoletosSacadoNome ;
      private string[] P00FP3_A1083BoletosStatus ;
      private bool[] P00FP3_n1083BoletosStatus ;
      private string[] P00FP3_A1080BoletosNumero ;
      private bool[] P00FP3_n1080BoletosNumero ;
      private string[] P00FP3_A1078BoletosNossoNumero ;
      private bool[] P00FP3_n1078BoletosNossoNumero ;
      private int[] P00FP3_A1077BoletosId ;
      private int[] P00FP4_A1069CarteiraDeCobrancaId ;
      private bool[] P00FP4_n1069CarteiraDeCobrancaId ;
      private string[] P00FP4_A1080BoletosNumero ;
      private bool[] P00FP4_n1080BoletosNumero ;
      private decimal[] P00FP4_A1093BoletosValorMulta ;
      private bool[] P00FP4_n1093BoletosValorMulta ;
      private decimal[] P00FP4_A1092BoletosValorJuros ;
      private bool[] P00FP4_n1092BoletosValorJuros ;
      private decimal[] P00FP4_A1091BoletosValorDesconto ;
      private bool[] P00FP4_n1091BoletosValorDesconto ;
      private decimal[] P00FP4_A1090BoletosValorPago ;
      private bool[] P00FP4_n1090BoletosValorPago ;
      private decimal[] P00FP4_A1089BoletosValorNominal ;
      private bool[] P00FP4_n1089BoletosValorNominal ;
      private DateTime[] P00FP4_A1088BoletosDataBaixa ;
      private bool[] P00FP4_n1088BoletosDataBaixa ;
      private DateTime[] P00FP4_A1087BoletosDataPagamento ;
      private bool[] P00FP4_n1087BoletosDataPagamento ;
      private DateTime[] P00FP4_A1086BoletosDataRegistro ;
      private bool[] P00FP4_n1086BoletosDataRegistro ;
      private DateTime[] P00FP4_A1085BoletosDataVencimento ;
      private bool[] P00FP4_n1085BoletosDataVencimento ;
      private DateTime[] P00FP4_A1084BoletosDataEmissao ;
      private bool[] P00FP4_n1084BoletosDataEmissao ;
      private string[] P00FP4_A1096BoletosSacadoTipoDocumento ;
      private bool[] P00FP4_n1096BoletosSacadoTipoDocumento ;
      private string[] P00FP4_A1095BoletosSacadoDocumento ;
      private bool[] P00FP4_n1095BoletosSacadoDocumento ;
      private string[] P00FP4_A1094BoletosSacadoNome ;
      private bool[] P00FP4_n1094BoletosSacadoNome ;
      private string[] P00FP4_A1083BoletosStatus ;
      private bool[] P00FP4_n1083BoletosStatus ;
      private string[] P00FP4_A1079BoletosSeuNumero ;
      private bool[] P00FP4_n1079BoletosSeuNumero ;
      private string[] P00FP4_A1078BoletosNossoNumero ;
      private bool[] P00FP4_n1078BoletosNossoNumero ;
      private int[] P00FP4_A1077BoletosId ;
      private int[] P00FP5_A1069CarteiraDeCobrancaId ;
      private bool[] P00FP5_n1069CarteiraDeCobrancaId ;
      private string[] P00FP5_A1094BoletosSacadoNome ;
      private bool[] P00FP5_n1094BoletosSacadoNome ;
      private decimal[] P00FP5_A1093BoletosValorMulta ;
      private bool[] P00FP5_n1093BoletosValorMulta ;
      private decimal[] P00FP5_A1092BoletosValorJuros ;
      private bool[] P00FP5_n1092BoletosValorJuros ;
      private decimal[] P00FP5_A1091BoletosValorDesconto ;
      private bool[] P00FP5_n1091BoletosValorDesconto ;
      private decimal[] P00FP5_A1090BoletosValorPago ;
      private bool[] P00FP5_n1090BoletosValorPago ;
      private decimal[] P00FP5_A1089BoletosValorNominal ;
      private bool[] P00FP5_n1089BoletosValorNominal ;
      private DateTime[] P00FP5_A1088BoletosDataBaixa ;
      private bool[] P00FP5_n1088BoletosDataBaixa ;
      private DateTime[] P00FP5_A1087BoletosDataPagamento ;
      private bool[] P00FP5_n1087BoletosDataPagamento ;
      private DateTime[] P00FP5_A1086BoletosDataRegistro ;
      private bool[] P00FP5_n1086BoletosDataRegistro ;
      private DateTime[] P00FP5_A1085BoletosDataVencimento ;
      private bool[] P00FP5_n1085BoletosDataVencimento ;
      private DateTime[] P00FP5_A1084BoletosDataEmissao ;
      private bool[] P00FP5_n1084BoletosDataEmissao ;
      private string[] P00FP5_A1096BoletosSacadoTipoDocumento ;
      private bool[] P00FP5_n1096BoletosSacadoTipoDocumento ;
      private string[] P00FP5_A1095BoletosSacadoDocumento ;
      private bool[] P00FP5_n1095BoletosSacadoDocumento ;
      private string[] P00FP5_A1083BoletosStatus ;
      private bool[] P00FP5_n1083BoletosStatus ;
      private string[] P00FP5_A1080BoletosNumero ;
      private bool[] P00FP5_n1080BoletosNumero ;
      private string[] P00FP5_A1079BoletosSeuNumero ;
      private bool[] P00FP5_n1079BoletosSeuNumero ;
      private string[] P00FP5_A1078BoletosNossoNumero ;
      private bool[] P00FP5_n1078BoletosNossoNumero ;
      private int[] P00FP5_A1077BoletosId ;
      private int[] P00FP6_A1069CarteiraDeCobrancaId ;
      private bool[] P00FP6_n1069CarteiraDeCobrancaId ;
      private string[] P00FP6_A1095BoletosSacadoDocumento ;
      private bool[] P00FP6_n1095BoletosSacadoDocumento ;
      private decimal[] P00FP6_A1093BoletosValorMulta ;
      private bool[] P00FP6_n1093BoletosValorMulta ;
      private decimal[] P00FP6_A1092BoletosValorJuros ;
      private bool[] P00FP6_n1092BoletosValorJuros ;
      private decimal[] P00FP6_A1091BoletosValorDesconto ;
      private bool[] P00FP6_n1091BoletosValorDesconto ;
      private decimal[] P00FP6_A1090BoletosValorPago ;
      private bool[] P00FP6_n1090BoletosValorPago ;
      private decimal[] P00FP6_A1089BoletosValorNominal ;
      private bool[] P00FP6_n1089BoletosValorNominal ;
      private DateTime[] P00FP6_A1088BoletosDataBaixa ;
      private bool[] P00FP6_n1088BoletosDataBaixa ;
      private DateTime[] P00FP6_A1087BoletosDataPagamento ;
      private bool[] P00FP6_n1087BoletosDataPagamento ;
      private DateTime[] P00FP6_A1086BoletosDataRegistro ;
      private bool[] P00FP6_n1086BoletosDataRegistro ;
      private DateTime[] P00FP6_A1085BoletosDataVencimento ;
      private bool[] P00FP6_n1085BoletosDataVencimento ;
      private DateTime[] P00FP6_A1084BoletosDataEmissao ;
      private bool[] P00FP6_n1084BoletosDataEmissao ;
      private string[] P00FP6_A1096BoletosSacadoTipoDocumento ;
      private bool[] P00FP6_n1096BoletosSacadoTipoDocumento ;
      private string[] P00FP6_A1094BoletosSacadoNome ;
      private bool[] P00FP6_n1094BoletosSacadoNome ;
      private string[] P00FP6_A1083BoletosStatus ;
      private bool[] P00FP6_n1083BoletosStatus ;
      private string[] P00FP6_A1080BoletosNumero ;
      private bool[] P00FP6_n1080BoletosNumero ;
      private string[] P00FP6_A1079BoletosSeuNumero ;
      private bool[] P00FP6_n1079BoletosSeuNumero ;
      private string[] P00FP6_A1078BoletosNossoNumero ;
      private bool[] P00FP6_n1078BoletosNossoNumero ;
      private int[] P00FP6_A1077BoletosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcboletosgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FP2( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV100Wcboletosds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                             string AV82Wcboletosds_2_filterfulltext ,
                                             string AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                             short AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                             string AV85Wcboletosds_5_boletosnossonumero1 ,
                                             bool AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                             string AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                             short AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                             string AV89Wcboletosds_9_boletosnossonumero2 ,
                                             bool AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                             string AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                             short AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                             string AV93Wcboletosds_13_boletosnossonumero3 ,
                                             string AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                             string AV94Wcboletosds_14_tfboletosnossonumero ,
                                             string AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                             string AV96Wcboletosds_16_tfboletosseunumero ,
                                             string AV99Wcboletosds_19_tfboletosnumero_sel ,
                                             string AV98Wcboletosds_18_tfboletosnumero ,
                                             int AV100Wcboletosds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV101Wcboletosds_21_tfboletosdataemissao ,
                                             DateTime AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                             DateTime AV103Wcboletosds_23_tfboletosdatavencimento ,
                                             DateTime AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                             DateTime AV105Wcboletosds_25_tfboletosdataregistro ,
                                             DateTime AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                             DateTime AV107Wcboletosds_27_tfboletosdatapagamento ,
                                             DateTime AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                             DateTime AV109Wcboletosds_29_tfboletosdatabaixa ,
                                             DateTime AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                             decimal AV111Wcboletosds_31_tfboletosvalornominal ,
                                             decimal AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                             decimal AV113Wcboletosds_33_tfboletosvalorpago ,
                                             decimal AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                             decimal AV115Wcboletosds_35_tfboletosvalordesconto ,
                                             decimal AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                             decimal AV117Wcboletosds_37_tfboletosvalorjuros ,
                                             decimal AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                             decimal AV119Wcboletosds_39_tfboletosvalormulta ,
                                             decimal AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                             string AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                             string AV121Wcboletosds_41_tfboletossacadonome ,
                                             string AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                             string AV123Wcboletosds_43_tfboletossacadodocumento ,
                                             int AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             int AV81Wcboletosds_1_carteiradecobrancaid ,
                                             int A1069CarteiraDeCobrancaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[55];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaId, BoletosNossoNumero, BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosSacadoTipoDocumento, BoletosSacadoDocumento, BoletosSacadoNome, BoletosStatus, BoletosNumero, BoletosSeuNumero, BoletosId FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV81Wcboletosds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
            GXv_int1[14] = 1;
            GXv_int1[15] = 1;
            GXv_int1[16] = 1;
            GXv_int1[17] = 1;
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV94Wcboletosds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV95Wcboletosds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV96Wcboletosds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV97Wcboletosds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV98Wcboletosds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV99Wcboletosds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV100Wcboletosds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wcboletosds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV101Wcboletosds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV101Wcboletosds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Wcboletosds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV102Wcboletosds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wcboletosds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV103Wcboletosds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wcboletosds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV104Wcboletosds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Wcboletosds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV105Wcboletosds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Wcboletosds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV106Wcboletosds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Wcboletosds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV107Wcboletosds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Wcboletosds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV108Wcboletosds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Wcboletosds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV109Wcboletosds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wcboletosds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV110Wcboletosds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wcboletosds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV111Wcboletosds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Wcboletosds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV112Wcboletosds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV113Wcboletosds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV113Wcboletosds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV114Wcboletosds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV114Wcboletosds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Wcboletosds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV115Wcboletosds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wcboletosds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV116Wcboletosds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wcboletosds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV117Wcboletosds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wcboletosds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV118Wcboletosds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wcboletosds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV119Wcboletosds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV120Wcboletosds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV120Wcboletosds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV121Wcboletosds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV122Wcboletosds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV123Wcboletosds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV124Wcboletosds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV125Wcboletosds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosNossoNumero";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00FP3( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV100Wcboletosds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                             string AV82Wcboletosds_2_filterfulltext ,
                                             string AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                             short AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                             string AV85Wcboletosds_5_boletosnossonumero1 ,
                                             bool AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                             string AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                             short AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                             string AV89Wcboletosds_9_boletosnossonumero2 ,
                                             bool AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                             string AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                             short AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                             string AV93Wcboletosds_13_boletosnossonumero3 ,
                                             string AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                             string AV94Wcboletosds_14_tfboletosnossonumero ,
                                             string AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                             string AV96Wcboletosds_16_tfboletosseunumero ,
                                             string AV99Wcboletosds_19_tfboletosnumero_sel ,
                                             string AV98Wcboletosds_18_tfboletosnumero ,
                                             int AV100Wcboletosds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV101Wcboletosds_21_tfboletosdataemissao ,
                                             DateTime AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                             DateTime AV103Wcboletosds_23_tfboletosdatavencimento ,
                                             DateTime AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                             DateTime AV105Wcboletosds_25_tfboletosdataregistro ,
                                             DateTime AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                             DateTime AV107Wcboletosds_27_tfboletosdatapagamento ,
                                             DateTime AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                             DateTime AV109Wcboletosds_29_tfboletosdatabaixa ,
                                             DateTime AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                             decimal AV111Wcboletosds_31_tfboletosvalornominal ,
                                             decimal AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                             decimal AV113Wcboletosds_33_tfboletosvalorpago ,
                                             decimal AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                             decimal AV115Wcboletosds_35_tfboletosvalordesconto ,
                                             decimal AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                             decimal AV117Wcboletosds_37_tfboletosvalorjuros ,
                                             decimal AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                             decimal AV119Wcboletosds_39_tfboletosvalormulta ,
                                             decimal AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                             string AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                             string AV121Wcboletosds_41_tfboletossacadonome ,
                                             string AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                             string AV123Wcboletosds_43_tfboletossacadodocumento ,
                                             int AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             int AV81Wcboletosds_1_carteiradecobrancaid ,
                                             int A1069CarteiraDeCobrancaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[55];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaId, BoletosSeuNumero, BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosSacadoTipoDocumento, BoletosSacadoDocumento, BoletosSacadoNome, BoletosStatus, BoletosNumero, BoletosNossoNumero, BoletosId FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV81Wcboletosds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
            GXv_int3[12] = 1;
            GXv_int3[13] = 1;
            GXv_int3[14] = 1;
            GXv_int3[15] = 1;
            GXv_int3[16] = 1;
            GXv_int3[17] = 1;
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV94Wcboletosds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV95Wcboletosds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV96Wcboletosds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV97Wcboletosds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV98Wcboletosds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV99Wcboletosds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV100Wcboletosds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wcboletosds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV101Wcboletosds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV101Wcboletosds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Wcboletosds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV102Wcboletosds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wcboletosds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV103Wcboletosds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wcboletosds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV104Wcboletosds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Wcboletosds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV105Wcboletosds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Wcboletosds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV106Wcboletosds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Wcboletosds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV107Wcboletosds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Wcboletosds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV108Wcboletosds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Wcboletosds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV109Wcboletosds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wcboletosds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV110Wcboletosds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wcboletosds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV111Wcboletosds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Wcboletosds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV112Wcboletosds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV113Wcboletosds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV113Wcboletosds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV114Wcboletosds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV114Wcboletosds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Wcboletosds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV115Wcboletosds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wcboletosds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV116Wcboletosds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wcboletosds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV117Wcboletosds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wcboletosds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV118Wcboletosds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wcboletosds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV119Wcboletosds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV120Wcboletosds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV120Wcboletosds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV121Wcboletosds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV122Wcboletosds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV123Wcboletosds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV124Wcboletosds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV125Wcboletosds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSeuNumero";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00FP4( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV100Wcboletosds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                             string AV82Wcboletosds_2_filterfulltext ,
                                             string AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                             short AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                             string AV85Wcboletosds_5_boletosnossonumero1 ,
                                             bool AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                             string AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                             short AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                             string AV89Wcboletosds_9_boletosnossonumero2 ,
                                             bool AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                             string AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                             short AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                             string AV93Wcboletosds_13_boletosnossonumero3 ,
                                             string AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                             string AV94Wcboletosds_14_tfboletosnossonumero ,
                                             string AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                             string AV96Wcboletosds_16_tfboletosseunumero ,
                                             string AV99Wcboletosds_19_tfboletosnumero_sel ,
                                             string AV98Wcboletosds_18_tfboletosnumero ,
                                             int AV100Wcboletosds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV101Wcboletosds_21_tfboletosdataemissao ,
                                             DateTime AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                             DateTime AV103Wcboletosds_23_tfboletosdatavencimento ,
                                             DateTime AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                             DateTime AV105Wcboletosds_25_tfboletosdataregistro ,
                                             DateTime AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                             DateTime AV107Wcboletosds_27_tfboletosdatapagamento ,
                                             DateTime AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                             DateTime AV109Wcboletosds_29_tfboletosdatabaixa ,
                                             DateTime AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                             decimal AV111Wcboletosds_31_tfboletosvalornominal ,
                                             decimal AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                             decimal AV113Wcboletosds_33_tfboletosvalorpago ,
                                             decimal AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                             decimal AV115Wcboletosds_35_tfboletosvalordesconto ,
                                             decimal AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                             decimal AV117Wcboletosds_37_tfboletosvalorjuros ,
                                             decimal AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                             decimal AV119Wcboletosds_39_tfboletosvalormulta ,
                                             decimal AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                             string AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                             string AV121Wcboletosds_41_tfboletossacadonome ,
                                             string AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                             string AV123Wcboletosds_43_tfboletossacadodocumento ,
                                             int AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             int AV81Wcboletosds_1_carteiradecobrancaid ,
                                             int A1069CarteiraDeCobrancaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[55];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaId, BoletosNumero, BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosSacadoTipoDocumento, BoletosSacadoDocumento, BoletosSacadoNome, BoletosStatus, BoletosSeuNumero, BoletosNossoNumero, BoletosId FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV81Wcboletosds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
            GXv_int5[17] = 1;
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV94Wcboletosds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV95Wcboletosds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV96Wcboletosds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV97Wcboletosds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV98Wcboletosds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV99Wcboletosds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV100Wcboletosds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wcboletosds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV101Wcboletosds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV101Wcboletosds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Wcboletosds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV102Wcboletosds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wcboletosds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV103Wcboletosds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wcboletosds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV104Wcboletosds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Wcboletosds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV105Wcboletosds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Wcboletosds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV106Wcboletosds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Wcboletosds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV107Wcboletosds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Wcboletosds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV108Wcboletosds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Wcboletosds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV109Wcboletosds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wcboletosds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV110Wcboletosds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wcboletosds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV111Wcboletosds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Wcboletosds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV112Wcboletosds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV113Wcboletosds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV113Wcboletosds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV114Wcboletosds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV114Wcboletosds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Wcboletosds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV115Wcboletosds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wcboletosds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV116Wcboletosds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wcboletosds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV117Wcboletosds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wcboletosds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV118Wcboletosds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wcboletosds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV119Wcboletosds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV120Wcboletosds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV120Wcboletosds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV121Wcboletosds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV122Wcboletosds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV123Wcboletosds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV124Wcboletosds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV125Wcboletosds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosNumero";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00FP5( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV100Wcboletosds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                             string AV82Wcboletosds_2_filterfulltext ,
                                             string AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                             short AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                             string AV85Wcboletosds_5_boletosnossonumero1 ,
                                             bool AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                             string AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                             short AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                             string AV89Wcboletosds_9_boletosnossonumero2 ,
                                             bool AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                             string AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                             short AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                             string AV93Wcboletosds_13_boletosnossonumero3 ,
                                             string AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                             string AV94Wcboletosds_14_tfboletosnossonumero ,
                                             string AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                             string AV96Wcboletosds_16_tfboletosseunumero ,
                                             string AV99Wcboletosds_19_tfboletosnumero_sel ,
                                             string AV98Wcboletosds_18_tfboletosnumero ,
                                             int AV100Wcboletosds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV101Wcboletosds_21_tfboletosdataemissao ,
                                             DateTime AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                             DateTime AV103Wcboletosds_23_tfboletosdatavencimento ,
                                             DateTime AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                             DateTime AV105Wcboletosds_25_tfboletosdataregistro ,
                                             DateTime AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                             DateTime AV107Wcboletosds_27_tfboletosdatapagamento ,
                                             DateTime AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                             DateTime AV109Wcboletosds_29_tfboletosdatabaixa ,
                                             DateTime AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                             decimal AV111Wcboletosds_31_tfboletosvalornominal ,
                                             decimal AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                             decimal AV113Wcboletosds_33_tfboletosvalorpago ,
                                             decimal AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                             decimal AV115Wcboletosds_35_tfboletosvalordesconto ,
                                             decimal AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                             decimal AV117Wcboletosds_37_tfboletosvalorjuros ,
                                             decimal AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                             decimal AV119Wcboletosds_39_tfboletosvalormulta ,
                                             decimal AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                             string AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                             string AV121Wcboletosds_41_tfboletossacadonome ,
                                             string AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                             string AV123Wcboletosds_43_tfboletossacadodocumento ,
                                             int AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             int AV81Wcboletosds_1_carteiradecobrancaid ,
                                             int A1069CarteiraDeCobrancaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[55];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaId, BoletosSacadoNome, BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosSacadoTipoDocumento, BoletosSacadoDocumento, BoletosStatus, BoletosNumero, BoletosSeuNumero, BoletosNossoNumero, BoletosId FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV81Wcboletosds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
            GXv_int7[15] = 1;
            GXv_int7[16] = 1;
            GXv_int7[17] = 1;
            GXv_int7[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV94Wcboletosds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV95Wcboletosds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV96Wcboletosds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV97Wcboletosds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV98Wcboletosds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV99Wcboletosds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV100Wcboletosds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wcboletosds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV101Wcboletosds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV101Wcboletosds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Wcboletosds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV102Wcboletosds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wcboletosds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV103Wcboletosds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wcboletosds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV104Wcboletosds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Wcboletosds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV105Wcboletosds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Wcboletosds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV106Wcboletosds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Wcboletosds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV107Wcboletosds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Wcboletosds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV108Wcboletosds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Wcboletosds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV109Wcboletosds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wcboletosds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV110Wcboletosds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wcboletosds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV111Wcboletosds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Wcboletosds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV112Wcboletosds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV113Wcboletosds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV113Wcboletosds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV114Wcboletosds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV114Wcboletosds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Wcboletosds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV115Wcboletosds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int7[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wcboletosds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV116Wcboletosds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int7[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wcboletosds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV117Wcboletosds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int7[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wcboletosds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV118Wcboletosds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int7[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wcboletosds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV119Wcboletosds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int7[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV120Wcboletosds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV120Wcboletosds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int7[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV121Wcboletosds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int7[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV122Wcboletosds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int7[52] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV123Wcboletosds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int7[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV124Wcboletosds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int7[54] = 1;
         }
         if ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV125Wcboletosds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoNome";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00FP6( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV100Wcboletosds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV125Wcboletosds_45_tfboletossacadotipodocumento_sels ,
                                             string AV82Wcboletosds_2_filterfulltext ,
                                             string AV83Wcboletosds_3_dynamicfiltersselector1 ,
                                             short AV84Wcboletosds_4_dynamicfiltersoperator1 ,
                                             string AV85Wcboletosds_5_boletosnossonumero1 ,
                                             bool AV86Wcboletosds_6_dynamicfiltersenabled2 ,
                                             string AV87Wcboletosds_7_dynamicfiltersselector2 ,
                                             short AV88Wcboletosds_8_dynamicfiltersoperator2 ,
                                             string AV89Wcboletosds_9_boletosnossonumero2 ,
                                             bool AV90Wcboletosds_10_dynamicfiltersenabled3 ,
                                             string AV91Wcboletosds_11_dynamicfiltersselector3 ,
                                             short AV92Wcboletosds_12_dynamicfiltersoperator3 ,
                                             string AV93Wcboletosds_13_boletosnossonumero3 ,
                                             string AV95Wcboletosds_15_tfboletosnossonumero_sel ,
                                             string AV94Wcboletosds_14_tfboletosnossonumero ,
                                             string AV97Wcboletosds_17_tfboletosseunumero_sel ,
                                             string AV96Wcboletosds_16_tfboletosseunumero ,
                                             string AV99Wcboletosds_19_tfboletosnumero_sel ,
                                             string AV98Wcboletosds_18_tfboletosnumero ,
                                             int AV100Wcboletosds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV101Wcboletosds_21_tfboletosdataemissao ,
                                             DateTime AV102Wcboletosds_22_tfboletosdataemissao_to ,
                                             DateTime AV103Wcboletosds_23_tfboletosdatavencimento ,
                                             DateTime AV104Wcboletosds_24_tfboletosdatavencimento_to ,
                                             DateTime AV105Wcboletosds_25_tfboletosdataregistro ,
                                             DateTime AV106Wcboletosds_26_tfboletosdataregistro_to ,
                                             DateTime AV107Wcboletosds_27_tfboletosdatapagamento ,
                                             DateTime AV108Wcboletosds_28_tfboletosdatapagamento_to ,
                                             DateTime AV109Wcboletosds_29_tfboletosdatabaixa ,
                                             DateTime AV110Wcboletosds_30_tfboletosdatabaixa_to ,
                                             decimal AV111Wcboletosds_31_tfboletosvalornominal ,
                                             decimal AV112Wcboletosds_32_tfboletosvalornominal_to ,
                                             decimal AV113Wcboletosds_33_tfboletosvalorpago ,
                                             decimal AV114Wcboletosds_34_tfboletosvalorpago_to ,
                                             decimal AV115Wcboletosds_35_tfboletosvalordesconto ,
                                             decimal AV116Wcboletosds_36_tfboletosvalordesconto_to ,
                                             decimal AV117Wcboletosds_37_tfboletosvalorjuros ,
                                             decimal AV118Wcboletosds_38_tfboletosvalorjuros_to ,
                                             decimal AV119Wcboletosds_39_tfboletosvalormulta ,
                                             decimal AV120Wcboletosds_40_tfboletosvalormulta_to ,
                                             string AV122Wcboletosds_42_tfboletossacadonome_sel ,
                                             string AV121Wcboletosds_41_tfboletossacadonome ,
                                             string AV124Wcboletosds_44_tfboletossacadodocumento_sel ,
                                             string AV123Wcboletosds_43_tfboletossacadodocumento ,
                                             int AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             int AV81Wcboletosds_1_carteiradecobrancaid ,
                                             int A1069CarteiraDeCobrancaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[55];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaId, BoletosSacadoDocumento, BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosSacadoTipoDocumento, BoletosSacadoNome, BoletosStatus, BoletosNumero, BoletosSeuNumero, BoletosNossoNumero, BoletosId FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV81Wcboletosds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcboletosds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosNumero like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV82Wcboletosds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV82Wcboletosds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV82Wcboletosds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
            GXv_int9[9] = 1;
            GXv_int9[10] = 1;
            GXv_int9[11] = 1;
            GXv_int9[12] = 1;
            GXv_int9[13] = 1;
            GXv_int9[14] = 1;
            GXv_int9[15] = 1;
            GXv_int9[16] = 1;
            GXv_int9[17] = 1;
            GXv_int9[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wcboletosds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV84Wcboletosds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcboletosds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV85Wcboletosds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( AV86Wcboletosds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Wcboletosds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV88Wcboletosds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcboletosds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV89Wcboletosds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( AV90Wcboletosds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Wcboletosds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV92Wcboletosds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wcboletosds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV93Wcboletosds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wcboletosds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV94Wcboletosds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wcboletosds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV95Wcboletosds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV95Wcboletosds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wcboletosds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV96Wcboletosds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wcboletosds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV97Wcboletosds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wcboletosds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wcboletosds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV98Wcboletosds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wcboletosds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV99Wcboletosds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wcboletosds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV100Wcboletosds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wcboletosds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV101Wcboletosds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV101Wcboletosds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Wcboletosds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV102Wcboletosds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wcboletosds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV103Wcboletosds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wcboletosds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV104Wcboletosds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Wcboletosds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV105Wcboletosds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Wcboletosds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV106Wcboletosds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int9[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Wcboletosds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV107Wcboletosds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int9[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Wcboletosds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV108Wcboletosds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int9[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Wcboletosds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV109Wcboletosds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int9[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wcboletosds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV110Wcboletosds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int9[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Wcboletosds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV111Wcboletosds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int9[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Wcboletosds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV112Wcboletosds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int9[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV113Wcboletosds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV113Wcboletosds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int9[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV114Wcboletosds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV114Wcboletosds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int9[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Wcboletosds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV115Wcboletosds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int9[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wcboletosds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV116Wcboletosds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int9[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wcboletosds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV117Wcboletosds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int9[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wcboletosds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV118Wcboletosds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int9[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wcboletosds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV119Wcboletosds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int9[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV120Wcboletosds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV120Wcboletosds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int9[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wcboletosds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV121Wcboletosds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int9[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wcboletosds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV122Wcboletosds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int9[52] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wcboletosds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wcboletosds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV123Wcboletosds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int9[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wcboletosds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV124Wcboletosds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int9[54] = 1;
         }
         if ( StringUtil.StrCmp(AV124Wcboletosds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV125Wcboletosds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV125Wcboletosds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoDocumento";
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
                     return conditional_P00FP2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (int)dynConstraints[63] , (int)dynConstraints[64] );
               case 1 :
                     return conditional_P00FP3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (int)dynConstraints[63] , (int)dynConstraints[64] );
               case 2 :
                     return conditional_P00FP4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (int)dynConstraints[63] , (int)dynConstraints[64] );
               case 3 :
                     return conditional_P00FP5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (int)dynConstraints[63] , (int)dynConstraints[64] );
               case 4 :
                     return conditional_P00FP6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (int)dynConstraints[63] , (int)dynConstraints[64] );
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
          Object[] prmP00FP2;
          prmP00FP2 = new Object[] {
          new ParDef("AV81Wcboletosds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV94Wcboletosds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV95Wcboletosds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV96Wcboletosds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV97Wcboletosds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV98Wcboletosds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV99Wcboletosds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV101Wcboletosds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV102Wcboletosds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV103Wcboletosds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV104Wcboletosds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV105Wcboletosds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV106Wcboletosds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV107Wcboletosds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV108Wcboletosds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV109Wcboletosds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV110Wcboletosds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV111Wcboletosds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV112Wcboletosds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV113Wcboletosds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV114Wcboletosds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV115Wcboletosds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV116Wcboletosds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV117Wcboletosds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV118Wcboletosds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV119Wcboletosds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV120Wcboletosds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV121Wcboletosds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV122Wcboletosds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV123Wcboletosds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV124Wcboletosds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00FP3;
          prmP00FP3 = new Object[] {
          new ParDef("AV81Wcboletosds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV94Wcboletosds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV95Wcboletosds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV96Wcboletosds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV97Wcboletosds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV98Wcboletosds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV99Wcboletosds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV101Wcboletosds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV102Wcboletosds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV103Wcboletosds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV104Wcboletosds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV105Wcboletosds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV106Wcboletosds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV107Wcboletosds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV108Wcboletosds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV109Wcboletosds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV110Wcboletosds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV111Wcboletosds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV112Wcboletosds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV113Wcboletosds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV114Wcboletosds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV115Wcboletosds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV116Wcboletosds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV117Wcboletosds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV118Wcboletosds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV119Wcboletosds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV120Wcboletosds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV121Wcboletosds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV122Wcboletosds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV123Wcboletosds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV124Wcboletosds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00FP4;
          prmP00FP4 = new Object[] {
          new ParDef("AV81Wcboletosds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV94Wcboletosds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV95Wcboletosds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV96Wcboletosds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV97Wcboletosds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV98Wcboletosds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV99Wcboletosds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV101Wcboletosds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV102Wcboletosds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV103Wcboletosds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV104Wcboletosds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV105Wcboletosds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV106Wcboletosds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV107Wcboletosds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV108Wcboletosds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV109Wcboletosds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV110Wcboletosds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV111Wcboletosds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV112Wcboletosds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV113Wcboletosds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV114Wcboletosds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV115Wcboletosds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV116Wcboletosds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV117Wcboletosds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV118Wcboletosds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV119Wcboletosds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV120Wcboletosds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV121Wcboletosds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV122Wcboletosds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV123Wcboletosds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV124Wcboletosds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00FP5;
          prmP00FP5 = new Object[] {
          new ParDef("AV81Wcboletosds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV94Wcboletosds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV95Wcboletosds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV96Wcboletosds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV97Wcboletosds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV98Wcboletosds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV99Wcboletosds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV101Wcboletosds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV102Wcboletosds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV103Wcboletosds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV104Wcboletosds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV105Wcboletosds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV106Wcboletosds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV107Wcboletosds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV108Wcboletosds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV109Wcboletosds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV110Wcboletosds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV111Wcboletosds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV112Wcboletosds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV113Wcboletosds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV114Wcboletosds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV115Wcboletosds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV116Wcboletosds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV117Wcboletosds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV118Wcboletosds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV119Wcboletosds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV120Wcboletosds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV121Wcboletosds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV122Wcboletosds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV123Wcboletosds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV124Wcboletosds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00FP6;
          prmP00FP6 = new Object[] {
          new ParDef("AV81Wcboletosds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcboletosds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV85Wcboletosds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV89Wcboletosds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV93Wcboletosds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV94Wcboletosds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV95Wcboletosds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV96Wcboletosds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV97Wcboletosds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV98Wcboletosds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV99Wcboletosds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV101Wcboletosds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV102Wcboletosds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV103Wcboletosds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV104Wcboletosds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV105Wcboletosds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV106Wcboletosds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV107Wcboletosds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV108Wcboletosds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV109Wcboletosds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV110Wcboletosds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV111Wcboletosds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV112Wcboletosds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV113Wcboletosds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV114Wcboletosds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV115Wcboletosds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV116Wcboletosds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV117Wcboletosds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV118Wcboletosds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV119Wcboletosds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV120Wcboletosds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV121Wcboletosds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV122Wcboletosds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV123Wcboletosds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV124Wcboletosds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FP4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FP5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FP6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                return;
       }
    }

 }

}
