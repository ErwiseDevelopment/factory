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
   public class wpregistrartitulogetfilterdata : GXProcedure
   {
      public wpregistrartitulogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpregistrartitulogetfilterdata( IGxContext context )
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
         this.AV108DDOName = aP0_DDOName;
         this.AV109SearchTxtParms = aP1_SearchTxtParms;
         this.AV110SearchTxtTo = aP2_SearchTxtTo;
         this.AV111OptionsJson = "" ;
         this.AV112OptionsDescJson = "" ;
         this.AV113OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV111OptionsJson;
         aP4_OptionsDescJson=this.AV112OptionsDescJson;
         aP5_OptionIndexesJson=this.AV113OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV113OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV108DDOName = aP0_DDOName;
         this.AV109SearchTxtParms = aP1_SearchTxtParms;
         this.AV110SearchTxtTo = aP2_SearchTxtTo;
         this.AV111OptionsJson = "" ;
         this.AV112OptionsDescJson = "" ;
         this.AV113OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV111OptionsJson;
         aP4_OptionsDescJson=this.AV112OptionsDescJson;
         aP5_OptionIndexesJson=this.AV113OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV98Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV100OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV101OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV95MaxItems = 10;
         AV94PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV109SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV109SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV92SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV109SearchTxtParms)) ? "" : StringUtil.Substring( AV109SearchTxtParms, 3, -1));
         AV93SkipItems = (short)(AV94PageIndex*AV95MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV108DDOName), "DDO_TITULOCLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV108DDOName), "DDO_TITULOPROPOSTADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOPROPOSTADESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV108DDOName), "DDO_TITULOCOMPETENCIA_F") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOCOMPETENCIA_FOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV108DDOName), "DDO_NOTAFISCALNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALNUMEROOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV111OptionsJson = AV98Options.ToJSonString(false);
         AV112OptionsDescJson = AV100OptionsDesc.ToJSonString(false);
         AV113OptionIndexesJson = AV101OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV103Session.Get("WPRegistrarTituloGridState"), "") == 0 )
         {
            AV105GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WPRegistrarTituloGridState"), null, "", "");
         }
         else
         {
            AV105GridState.FromXml(AV103Session.Get("WPRegistrarTituloGridState"), null, "", "");
         }
         AV135GXV1 = 1;
         while ( AV135GXV1 <= AV105GridState.gxTpr_Filtervalues.Count )
         {
            AV106GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV105GridState.gxTpr_Filtervalues.Item(AV135GXV1));
            if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV114FilterFullText = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL") == 0 )
            {
               AV133TFTituloCLienteRazaoSocial = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV134TFTituloCLienteRazaoSocial_Sel = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO") == 0 )
            {
               AV131TFTituloPropostaDescricao = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV132TFTituloPropostaDescricao_Sel = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTATIPO_SEL") == 0 )
            {
               AV80TFTituloPropostaTipo_SelsJson = AV106GridStateFilterValue.gxTpr_Value;
               AV81TFTituloPropostaTipo_Sels.FromJSonString(AV80TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV16TFTituloValor = NumberUtil.Val( AV106GridStateFilterValue.gxTpr_Value, ".");
               AV17TFTituloValor_To = NumberUtil.Val( AV106GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV18TFTituloDesconto = NumberUtil.Val( AV106GridStateFilterValue.gxTpr_Value, ".");
               AV19TFTituloDesconto_To = NumberUtil.Val( AV106GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV28TFTituloCompetencia_F = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV29TFTituloCompetencia_F_Sel = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV30TFTituloProrrogacao = context.localUtil.CToD( AV106GridStateFilterValue.gxTpr_Value, 4);
               AV31TFTituloProrrogacao_To = context.localUtil.CToD( AV106GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFTITULOJUROSMORA") == 0 )
            {
               AV44TFTituloJurosMora = NumberUtil.Val( AV106GridStateFilterValue.gxTpr_Value, ".");
               AV45TFTituloJurosMora_To = NumberUtil.Val( AV106GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV129TFNotaFiscalNumero = AV106GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV106GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV130TFNotaFiscalNumero_Sel = AV106GridStateFilterValue.gxTpr_Value;
            }
            AV135GXV1 = (int)(AV135GXV1+1);
         }
         if ( AV105GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV107GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV105GridState.gxTpr_Dynamicfilters.Item(1));
            AV115DynamicFiltersSelector1 = AV107GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV115DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV116DynamicFiltersOperator1 = AV107GridStateDynamicFilter.gxTpr_Operator;
               AV117TituloValor1 = NumberUtil.Val( AV107GridStateDynamicFilter.gxTpr_Value, ".");
            }
            else if ( StringUtil.StrCmp(AV115DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV116DynamicFiltersOperator1 = AV107GridStateDynamicFilter.gxTpr_Operator;
               AV118ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV107GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            if ( AV105GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV119DynamicFiltersEnabled2 = true;
               AV107GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV105GridState.gxTpr_Dynamicfilters.Item(2));
               AV120DynamicFiltersSelector2 = AV107GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV120DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV121DynamicFiltersOperator2 = AV107GridStateDynamicFilter.gxTpr_Operator;
                  AV122TituloValor2 = NumberUtil.Val( AV107GridStateDynamicFilter.gxTpr_Value, ".");
               }
               else if ( StringUtil.StrCmp(AV120DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV121DynamicFiltersOperator2 = AV107GridStateDynamicFilter.gxTpr_Operator;
                  AV123ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV107GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               if ( AV105GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV124DynamicFiltersEnabled3 = true;
                  AV107GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV105GridState.gxTpr_Dynamicfilters.Item(3));
                  AV125DynamicFiltersSelector3 = AV107GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV125DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV126DynamicFiltersOperator3 = AV107GridStateDynamicFilter.gxTpr_Operator;
                     AV127TituloValor3 = NumberUtil.Val( AV107GridStateDynamicFilter.gxTpr_Value, ".");
                  }
                  else if ( StringUtil.StrCmp(AV125DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV126DynamicFiltersOperator3 = AV107GridStateDynamicFilter.gxTpr_Operator;
                     AV128ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV107GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTITULOCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV133TFTituloCLienteRazaoSocial = AV92SearchTxt;
         AV134TFTituloCLienteRazaoSocial_Sel = "";
         AV137Wpregistrartitulods_1_filterfulltext = AV114FilterFullText;
         AV138Wpregistrartitulods_2_dynamicfiltersselector1 = AV115DynamicFiltersSelector1;
         AV139Wpregistrartitulods_3_dynamicfiltersoperator1 = AV116DynamicFiltersOperator1;
         AV140Wpregistrartitulods_4_titulovalor1 = AV117TituloValor1;
         AV141Wpregistrartitulods_5_contabancarianumero1 = AV118ContaBancariaNumero1;
         AV142Wpregistrartitulods_6_dynamicfiltersenabled2 = AV119DynamicFiltersEnabled2;
         AV143Wpregistrartitulods_7_dynamicfiltersselector2 = AV120DynamicFiltersSelector2;
         AV144Wpregistrartitulods_8_dynamicfiltersoperator2 = AV121DynamicFiltersOperator2;
         AV145Wpregistrartitulods_9_titulovalor2 = AV122TituloValor2;
         AV146Wpregistrartitulods_10_contabancarianumero2 = AV123ContaBancariaNumero2;
         AV147Wpregistrartitulods_11_dynamicfiltersenabled3 = AV124DynamicFiltersEnabled3;
         AV148Wpregistrartitulods_12_dynamicfiltersselector3 = AV125DynamicFiltersSelector3;
         AV149Wpregistrartitulods_13_dynamicfiltersoperator3 = AV126DynamicFiltersOperator3;
         AV150Wpregistrartitulods_14_titulovalor3 = AV127TituloValor3;
         AV151Wpregistrartitulods_15_contabancarianumero3 = AV128ContaBancariaNumero3;
         AV152Wpregistrartitulods_16_tftituloclienterazaosocial = AV133TFTituloCLienteRazaoSocial;
         AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV134TFTituloCLienteRazaoSocial_Sel;
         AV154Wpregistrartitulods_18_tftitulopropostadescricao = AV131TFTituloPropostaDescricao;
         AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV132TFTituloPropostaDescricao_Sel;
         AV156Wpregistrartitulods_20_tftitulopropostatipo_sels = AV81TFTituloPropostaTipo_Sels;
         AV157Wpregistrartitulods_21_tftitulovalor = AV16TFTituloValor;
         AV158Wpregistrartitulods_22_tftitulovalor_to = AV17TFTituloValor_To;
         AV159Wpregistrartitulods_23_tftitulodesconto = AV18TFTituloDesconto;
         AV160Wpregistrartitulods_24_tftitulodesconto_to = AV19TFTituloDesconto_To;
         AV161Wpregistrartitulods_25_tftitulocompetencia_f = AV28TFTituloCompetencia_F;
         AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV29TFTituloCompetencia_F_Sel;
         AV163Wpregistrartitulods_27_tftituloprorrogacao = AV30TFTituloProrrogacao;
         AV164Wpregistrartitulods_28_tftituloprorrogacao_to = AV31TFTituloProrrogacao_To;
         AV165Wpregistrartitulods_29_tftitulojurosmora = AV44TFTituloJurosMora;
         AV166Wpregistrartitulods_30_tftitulojurosmora_to = AV45TFTituloJurosMora_To;
         AV167Wpregistrartitulods_31_tfnotafiscalnumero = AV129TFNotaFiscalNumero;
         AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV130TFNotaFiscalNumero_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV140Wpregistrartitulods_4_titulovalor1 ,
                                              AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV145Wpregistrartitulods_9_titulovalor2 ,
                                              AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV150Wpregistrartitulods_14_titulovalor3 ,
                                              AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV157Wpregistrartitulods_21_tftitulovalor ,
                                              AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV159Wpregistrartitulods_23_tftitulodesconto ,
                                              AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV137Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A275TituloSaldo_F ,
                                              A283TituloTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV152Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV154Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV167Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor P00EW4 */
         pr_default.execute(0, new Object[] {AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, lV152Wpregistrartitulods_16_tftituloclienterazaosocial, AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV154Wpregistrartitulods_18_tftitulopropostadescricao, AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV157Wpregistrartitulods_21_tftitulovalor, AV158Wpregistrartitulods_22_tftitulovalor_to, AV159Wpregistrartitulods_23_tftitulodesconto, AV160Wpregistrartitulods_24_tftitulodesconto_to, AV163Wpregistrartitulods_27_tftituloprorrogacao, AV164Wpregistrartitulods_28_tftituloprorrogacao_to, AV165Wpregistrartitulods_29_tftitulojurosmora, AV166Wpregistrartitulods_30_tftitulojurosmora_to, lV167Wpregistrartitulods_31_tfnotafiscalnumero, AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEW2 = false;
            A890NotaFiscalParcelamentoID = P00EW4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00EW4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00EW4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW4_n794NotaFiscalId[0];
            A419TituloPropostaId = P00EW4_A419TituloPropostaId[0];
            n419TituloPropostaId = P00EW4_n419TituloPropostaId[0];
            A420TituloClienteId = P00EW4_A420TituloClienteId[0];
            n420TituloClienteId = P00EW4_n420TituloClienteId[0];
            A261TituloId = P00EW4_A261TituloId[0];
            n261TituloId = P00EW4_n261TituloId[0];
            A283TituloTipo = P00EW4_A283TituloTipo[0];
            n283TituloTipo = P00EW4_n283TituloTipo[0];
            A972TituloCLienteRazaoSocial = P00EW4_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW4_n972TituloCLienteRazaoSocial[0];
            A314TituloArchived = P00EW4_A314TituloArchived[0];
            n314TituloArchived = P00EW4_n314TituloArchived[0];
            A284TituloDeleted = P00EW4_A284TituloDeleted[0];
            n284TituloDeleted = P00EW4_n284TituloDeleted[0];
            A951ContaBancariaId = P00EW4_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EW4_n951ContaBancariaId[0];
            A498TituloJurosMora = P00EW4_A498TituloJurosMora[0];
            n498TituloJurosMora = P00EW4_n498TituloJurosMora[0];
            A264TituloProrrogacao = P00EW4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00EW4_n264TituloProrrogacao[0];
            A276TituloDesconto = P00EW4_A276TituloDesconto[0];
            n276TituloDesconto = P00EW4_n276TituloDesconto[0];
            A952ContaBancariaNumero = P00EW4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW4_n952ContaBancariaNumero[0];
            A262TituloValor = P00EW4_A262TituloValor[0];
            n262TituloValor = P00EW4_n262TituloValor[0];
            A799NotaFiscalNumero = P00EW4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW4_n799NotaFiscalNumero[0];
            A648TituloPropostaTipo = P00EW4_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00EW4_n648TituloPropostaTipo[0];
            A971TituloPropostaDescricao = P00EW4_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW4_n971TituloPropostaDescricao[0];
            A275TituloSaldo_F = P00EW4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW4_n275TituloSaldo_F[0];
            A286TituloCompetenciaAno = P00EW4_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00EW4_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00EW4_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00EW4_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00EW4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW4_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00EW4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW4_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00EW4_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW4_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EW4_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW4_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW4_n275TituloSaldo_F[0];
            A952ContaBancariaNumero = P00EW4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW4_n952ContaBancariaNumero[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV161Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV102count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EW4_A972TituloCLienteRazaoSocial[0], A972TituloCLienteRazaoSocial) == 0 ) )
                        {
                           BRKEW2 = false;
                           A420TituloClienteId = P00EW4_A420TituloClienteId[0];
                           n420TituloClienteId = P00EW4_n420TituloClienteId[0];
                           A261TituloId = P00EW4_A261TituloId[0];
                           n261TituloId = P00EW4_n261TituloId[0];
                           AV102count = (long)(AV102count+1);
                           BRKEW2 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV93SkipItems) )
                        {
                           AV97Option = (String.IsNullOrEmpty(StringUtil.RTrim( A972TituloCLienteRazaoSocial)) ? "<#Empty#>" : A972TituloCLienteRazaoSocial);
                           AV98Options.Add(AV97Option, 0);
                           AV101OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV102count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV98Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV93SkipItems = (short)(AV93SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKEW2 )
            {
               BRKEW2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTITULOPROPOSTADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV131TFTituloPropostaDescricao = AV92SearchTxt;
         AV132TFTituloPropostaDescricao_Sel = "";
         AV137Wpregistrartitulods_1_filterfulltext = AV114FilterFullText;
         AV138Wpregistrartitulods_2_dynamicfiltersselector1 = AV115DynamicFiltersSelector1;
         AV139Wpregistrartitulods_3_dynamicfiltersoperator1 = AV116DynamicFiltersOperator1;
         AV140Wpregistrartitulods_4_titulovalor1 = AV117TituloValor1;
         AV141Wpregistrartitulods_5_contabancarianumero1 = AV118ContaBancariaNumero1;
         AV142Wpregistrartitulods_6_dynamicfiltersenabled2 = AV119DynamicFiltersEnabled2;
         AV143Wpregistrartitulods_7_dynamicfiltersselector2 = AV120DynamicFiltersSelector2;
         AV144Wpregistrartitulods_8_dynamicfiltersoperator2 = AV121DynamicFiltersOperator2;
         AV145Wpregistrartitulods_9_titulovalor2 = AV122TituloValor2;
         AV146Wpregistrartitulods_10_contabancarianumero2 = AV123ContaBancariaNumero2;
         AV147Wpregistrartitulods_11_dynamicfiltersenabled3 = AV124DynamicFiltersEnabled3;
         AV148Wpregistrartitulods_12_dynamicfiltersselector3 = AV125DynamicFiltersSelector3;
         AV149Wpregistrartitulods_13_dynamicfiltersoperator3 = AV126DynamicFiltersOperator3;
         AV150Wpregistrartitulods_14_titulovalor3 = AV127TituloValor3;
         AV151Wpregistrartitulods_15_contabancarianumero3 = AV128ContaBancariaNumero3;
         AV152Wpregistrartitulods_16_tftituloclienterazaosocial = AV133TFTituloCLienteRazaoSocial;
         AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV134TFTituloCLienteRazaoSocial_Sel;
         AV154Wpregistrartitulods_18_tftitulopropostadescricao = AV131TFTituloPropostaDescricao;
         AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV132TFTituloPropostaDescricao_Sel;
         AV156Wpregistrartitulods_20_tftitulopropostatipo_sels = AV81TFTituloPropostaTipo_Sels;
         AV157Wpregistrartitulods_21_tftitulovalor = AV16TFTituloValor;
         AV158Wpregistrartitulods_22_tftitulovalor_to = AV17TFTituloValor_To;
         AV159Wpregistrartitulods_23_tftitulodesconto = AV18TFTituloDesconto;
         AV160Wpregistrartitulods_24_tftitulodesconto_to = AV19TFTituloDesconto_To;
         AV161Wpregistrartitulods_25_tftitulocompetencia_f = AV28TFTituloCompetencia_F;
         AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV29TFTituloCompetencia_F_Sel;
         AV163Wpregistrartitulods_27_tftituloprorrogacao = AV30TFTituloProrrogacao;
         AV164Wpregistrartitulods_28_tftituloprorrogacao_to = AV31TFTituloProrrogacao_To;
         AV165Wpregistrartitulods_29_tftitulojurosmora = AV44TFTituloJurosMora;
         AV166Wpregistrartitulods_30_tftitulojurosmora_to = AV45TFTituloJurosMora_To;
         AV167Wpregistrartitulods_31_tfnotafiscalnumero = AV129TFNotaFiscalNumero;
         AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV130TFNotaFiscalNumero_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV140Wpregistrartitulods_4_titulovalor1 ,
                                              AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV145Wpregistrartitulods_9_titulovalor2 ,
                                              AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV150Wpregistrartitulods_14_titulovalor3 ,
                                              AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV157Wpregistrartitulods_21_tftitulovalor ,
                                              AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV159Wpregistrartitulods_23_tftitulodesconto ,
                                              AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV137Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A275TituloSaldo_F ,
                                              A283TituloTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV152Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV154Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV167Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor P00EW7 */
         pr_default.execute(1, new Object[] {AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, lV152Wpregistrartitulods_16_tftituloclienterazaosocial, AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV154Wpregistrartitulods_18_tftitulopropostadescricao, AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV157Wpregistrartitulods_21_tftitulovalor, AV158Wpregistrartitulods_22_tftitulovalor_to, AV159Wpregistrartitulods_23_tftitulodesconto, AV160Wpregistrartitulods_24_tftitulodesconto_to, AV163Wpregistrartitulods_27_tftituloprorrogacao, AV164Wpregistrartitulods_28_tftituloprorrogacao_to, AV165Wpregistrartitulods_29_tftitulojurosmora, AV166Wpregistrartitulods_30_tftitulojurosmora_to, lV167Wpregistrartitulods_31_tfnotafiscalnumero, AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEW4 = false;
            A890NotaFiscalParcelamentoID = P00EW7_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00EW7_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00EW7_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW7_n794NotaFiscalId[0];
            A419TituloPropostaId = P00EW7_A419TituloPropostaId[0];
            n419TituloPropostaId = P00EW7_n419TituloPropostaId[0];
            A420TituloClienteId = P00EW7_A420TituloClienteId[0];
            n420TituloClienteId = P00EW7_n420TituloClienteId[0];
            A261TituloId = P00EW7_A261TituloId[0];
            n261TituloId = P00EW7_n261TituloId[0];
            A283TituloTipo = P00EW7_A283TituloTipo[0];
            n283TituloTipo = P00EW7_n283TituloTipo[0];
            A971TituloPropostaDescricao = P00EW7_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW7_n971TituloPropostaDescricao[0];
            A314TituloArchived = P00EW7_A314TituloArchived[0];
            n314TituloArchived = P00EW7_n314TituloArchived[0];
            A284TituloDeleted = P00EW7_A284TituloDeleted[0];
            n284TituloDeleted = P00EW7_n284TituloDeleted[0];
            A951ContaBancariaId = P00EW7_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EW7_n951ContaBancariaId[0];
            A498TituloJurosMora = P00EW7_A498TituloJurosMora[0];
            n498TituloJurosMora = P00EW7_n498TituloJurosMora[0];
            A264TituloProrrogacao = P00EW7_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00EW7_n264TituloProrrogacao[0];
            A276TituloDesconto = P00EW7_A276TituloDesconto[0];
            n276TituloDesconto = P00EW7_n276TituloDesconto[0];
            A952ContaBancariaNumero = P00EW7_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW7_n952ContaBancariaNumero[0];
            A262TituloValor = P00EW7_A262TituloValor[0];
            n262TituloValor = P00EW7_n262TituloValor[0];
            A799NotaFiscalNumero = P00EW7_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW7_n799NotaFiscalNumero[0];
            A648TituloPropostaTipo = P00EW7_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00EW7_n648TituloPropostaTipo[0];
            A972TituloCLienteRazaoSocial = P00EW7_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW7_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW7_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW7_n275TituloSaldo_F[0];
            A286TituloCompetenciaAno = P00EW7_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00EW7_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00EW7_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00EW7_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00EW7_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW7_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00EW7_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW7_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00EW7_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW7_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EW7_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW7_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW7_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW7_n275TituloSaldo_F[0];
            A952ContaBancariaNumero = P00EW7_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW7_n952ContaBancariaNumero[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV161Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV102count = 0;
                        while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EW7_A971TituloPropostaDescricao[0], A971TituloPropostaDescricao) == 0 ) )
                        {
                           BRKEW4 = false;
                           A419TituloPropostaId = P00EW7_A419TituloPropostaId[0];
                           n419TituloPropostaId = P00EW7_n419TituloPropostaId[0];
                           A261TituloId = P00EW7_A261TituloId[0];
                           n261TituloId = P00EW7_n261TituloId[0];
                           AV102count = (long)(AV102count+1);
                           BRKEW4 = true;
                           pr_default.readNext(1);
                        }
                        if ( (0==AV93SkipItems) )
                        {
                           AV97Option = (String.IsNullOrEmpty(StringUtil.RTrim( A971TituloPropostaDescricao)) ? "<#Empty#>" : A971TituloPropostaDescricao);
                           AV98Options.Add(AV97Option, 0);
                           AV101OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV102count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV98Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV93SkipItems = (short)(AV93SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKEW4 )
            {
               BRKEW4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTITULOCOMPETENCIA_FOPTIONS' Routine */
         returnInSub = false;
         AV28TFTituloCompetencia_F = AV92SearchTxt;
         AV29TFTituloCompetencia_F_Sel = "";
         AV137Wpregistrartitulods_1_filterfulltext = AV114FilterFullText;
         AV138Wpregistrartitulods_2_dynamicfiltersselector1 = AV115DynamicFiltersSelector1;
         AV139Wpregistrartitulods_3_dynamicfiltersoperator1 = AV116DynamicFiltersOperator1;
         AV140Wpregistrartitulods_4_titulovalor1 = AV117TituloValor1;
         AV141Wpregistrartitulods_5_contabancarianumero1 = AV118ContaBancariaNumero1;
         AV142Wpregistrartitulods_6_dynamicfiltersenabled2 = AV119DynamicFiltersEnabled2;
         AV143Wpregistrartitulods_7_dynamicfiltersselector2 = AV120DynamicFiltersSelector2;
         AV144Wpregistrartitulods_8_dynamicfiltersoperator2 = AV121DynamicFiltersOperator2;
         AV145Wpregistrartitulods_9_titulovalor2 = AV122TituloValor2;
         AV146Wpregistrartitulods_10_contabancarianumero2 = AV123ContaBancariaNumero2;
         AV147Wpregistrartitulods_11_dynamicfiltersenabled3 = AV124DynamicFiltersEnabled3;
         AV148Wpregistrartitulods_12_dynamicfiltersselector3 = AV125DynamicFiltersSelector3;
         AV149Wpregistrartitulods_13_dynamicfiltersoperator3 = AV126DynamicFiltersOperator3;
         AV150Wpregistrartitulods_14_titulovalor3 = AV127TituloValor3;
         AV151Wpregistrartitulods_15_contabancarianumero3 = AV128ContaBancariaNumero3;
         AV152Wpregistrartitulods_16_tftituloclienterazaosocial = AV133TFTituloCLienteRazaoSocial;
         AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV134TFTituloCLienteRazaoSocial_Sel;
         AV154Wpregistrartitulods_18_tftitulopropostadescricao = AV131TFTituloPropostaDescricao;
         AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV132TFTituloPropostaDescricao_Sel;
         AV156Wpregistrartitulods_20_tftitulopropostatipo_sels = AV81TFTituloPropostaTipo_Sels;
         AV157Wpregistrartitulods_21_tftitulovalor = AV16TFTituloValor;
         AV158Wpregistrartitulods_22_tftitulovalor_to = AV17TFTituloValor_To;
         AV159Wpregistrartitulods_23_tftitulodesconto = AV18TFTituloDesconto;
         AV160Wpregistrartitulods_24_tftitulodesconto_to = AV19TFTituloDesconto_To;
         AV161Wpregistrartitulods_25_tftitulocompetencia_f = AV28TFTituloCompetencia_F;
         AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV29TFTituloCompetencia_F_Sel;
         AV163Wpregistrartitulods_27_tftituloprorrogacao = AV30TFTituloProrrogacao;
         AV164Wpregistrartitulods_28_tftituloprorrogacao_to = AV31TFTituloProrrogacao_To;
         AV165Wpregistrartitulods_29_tftitulojurosmora = AV44TFTituloJurosMora;
         AV166Wpregistrartitulods_30_tftitulojurosmora_to = AV45TFTituloJurosMora_To;
         AV167Wpregistrartitulods_31_tfnotafiscalnumero = AV129TFNotaFiscalNumero;
         AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV130TFNotaFiscalNumero_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV140Wpregistrartitulods_4_titulovalor1 ,
                                              AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV145Wpregistrartitulods_9_titulovalor2 ,
                                              AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV150Wpregistrartitulods_14_titulovalor3 ,
                                              AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV157Wpregistrartitulods_21_tftitulovalor ,
                                              AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV159Wpregistrartitulods_23_tftitulodesconto ,
                                              AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV137Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A275TituloSaldo_F ,
                                              A283TituloTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV152Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV154Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV167Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor P00EW10 */
         pr_default.execute(2, new Object[] {AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, lV152Wpregistrartitulods_16_tftituloclienterazaosocial, AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV154Wpregistrartitulods_18_tftitulopropostadescricao, AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV157Wpregistrartitulods_21_tftitulovalor, AV158Wpregistrartitulods_22_tftitulovalor_to, AV159Wpregistrartitulods_23_tftitulodesconto, AV160Wpregistrartitulods_24_tftitulodesconto_to, AV163Wpregistrartitulods_27_tftituloprorrogacao, AV164Wpregistrartitulods_28_tftituloprorrogacao_to, AV165Wpregistrartitulods_29_tftitulojurosmora, AV166Wpregistrartitulods_30_tftitulojurosmora_to, lV167Wpregistrartitulods_31_tfnotafiscalnumero, AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00EW10_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00EW10_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00EW10_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW10_n794NotaFiscalId[0];
            A419TituloPropostaId = P00EW10_A419TituloPropostaId[0];
            n419TituloPropostaId = P00EW10_n419TituloPropostaId[0];
            A420TituloClienteId = P00EW10_A420TituloClienteId[0];
            n420TituloClienteId = P00EW10_n420TituloClienteId[0];
            A261TituloId = P00EW10_A261TituloId[0];
            n261TituloId = P00EW10_n261TituloId[0];
            A283TituloTipo = P00EW10_A283TituloTipo[0];
            n283TituloTipo = P00EW10_n283TituloTipo[0];
            A314TituloArchived = P00EW10_A314TituloArchived[0];
            n314TituloArchived = P00EW10_n314TituloArchived[0];
            A284TituloDeleted = P00EW10_A284TituloDeleted[0];
            n284TituloDeleted = P00EW10_n284TituloDeleted[0];
            A951ContaBancariaId = P00EW10_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EW10_n951ContaBancariaId[0];
            A498TituloJurosMora = P00EW10_A498TituloJurosMora[0];
            n498TituloJurosMora = P00EW10_n498TituloJurosMora[0];
            A264TituloProrrogacao = P00EW10_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00EW10_n264TituloProrrogacao[0];
            A276TituloDesconto = P00EW10_A276TituloDesconto[0];
            n276TituloDesconto = P00EW10_n276TituloDesconto[0];
            A952ContaBancariaNumero = P00EW10_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW10_n952ContaBancariaNumero[0];
            A262TituloValor = P00EW10_A262TituloValor[0];
            n262TituloValor = P00EW10_n262TituloValor[0];
            A799NotaFiscalNumero = P00EW10_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW10_n799NotaFiscalNumero[0];
            A648TituloPropostaTipo = P00EW10_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00EW10_n648TituloPropostaTipo[0];
            A971TituloPropostaDescricao = P00EW10_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW10_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EW10_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW10_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW10_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW10_n275TituloSaldo_F[0];
            A286TituloCompetenciaAno = P00EW10_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00EW10_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00EW10_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00EW10_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00EW10_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW10_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00EW10_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW10_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00EW10_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW10_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EW10_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW10_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW10_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW10_n275TituloSaldo_F[0];
            A952ContaBancariaNumero = P00EW10_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW10_n952ContaBancariaNumero[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV161Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV97Option = (String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ? "<#Empty#>" : A295TituloCompetencia_F);
                        AV96InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV97Option, "<#Empty#>") != 0 ) && ( AV96InsertIndex <= AV98Options.Count ) && ( ( StringUtil.StrCmp(((string)AV98Options.Item(AV96InsertIndex)), AV97Option) < 0 ) || ( StringUtil.StrCmp(((string)AV98Options.Item(AV96InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV96InsertIndex = (int)(AV96InsertIndex+1);
                        }
                        if ( ( AV96InsertIndex <= AV98Options.Count ) && ( StringUtil.StrCmp(((string)AV98Options.Item(AV96InsertIndex)), AV97Option) == 0 ) )
                        {
                           AV102count = (long)(Math.Round(NumberUtil.Val( ((string)AV101OptionIndexes.Item(AV96InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV102count = (long)(AV102count+1);
                           AV101OptionIndexes.RemoveItem(AV96InsertIndex);
                           AV101OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV102count), "Z,ZZZ,ZZZ,ZZ9")), AV96InsertIndex);
                        }
                        else
                        {
                           AV98Options.Add(AV97Option, AV96InsertIndex);
                           AV101OptionIndexes.Add("1", AV96InsertIndex);
                        }
                        if ( AV98Options.Count == AV93SkipItems + 11 )
                        {
                           AV98Options.RemoveItem(AV98Options.Count);
                           AV101OptionIndexes.RemoveItem(AV101OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV93SkipItems > 0 )
         {
            AV98Options.RemoveItem(1);
            AV101OptionIndexes.RemoveItem(1);
            AV93SkipItems = (short)(AV93SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADNOTAFISCALNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV129TFNotaFiscalNumero = AV92SearchTxt;
         AV130TFNotaFiscalNumero_Sel = "";
         AV137Wpregistrartitulods_1_filterfulltext = AV114FilterFullText;
         AV138Wpregistrartitulods_2_dynamicfiltersselector1 = AV115DynamicFiltersSelector1;
         AV139Wpregistrartitulods_3_dynamicfiltersoperator1 = AV116DynamicFiltersOperator1;
         AV140Wpregistrartitulods_4_titulovalor1 = AV117TituloValor1;
         AV141Wpregistrartitulods_5_contabancarianumero1 = AV118ContaBancariaNumero1;
         AV142Wpregistrartitulods_6_dynamicfiltersenabled2 = AV119DynamicFiltersEnabled2;
         AV143Wpregistrartitulods_7_dynamicfiltersselector2 = AV120DynamicFiltersSelector2;
         AV144Wpregistrartitulods_8_dynamicfiltersoperator2 = AV121DynamicFiltersOperator2;
         AV145Wpregistrartitulods_9_titulovalor2 = AV122TituloValor2;
         AV146Wpregistrartitulods_10_contabancarianumero2 = AV123ContaBancariaNumero2;
         AV147Wpregistrartitulods_11_dynamicfiltersenabled3 = AV124DynamicFiltersEnabled3;
         AV148Wpregistrartitulods_12_dynamicfiltersselector3 = AV125DynamicFiltersSelector3;
         AV149Wpregistrartitulods_13_dynamicfiltersoperator3 = AV126DynamicFiltersOperator3;
         AV150Wpregistrartitulods_14_titulovalor3 = AV127TituloValor3;
         AV151Wpregistrartitulods_15_contabancarianumero3 = AV128ContaBancariaNumero3;
         AV152Wpregistrartitulods_16_tftituloclienterazaosocial = AV133TFTituloCLienteRazaoSocial;
         AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV134TFTituloCLienteRazaoSocial_Sel;
         AV154Wpregistrartitulods_18_tftitulopropostadescricao = AV131TFTituloPropostaDescricao;
         AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV132TFTituloPropostaDescricao_Sel;
         AV156Wpregistrartitulods_20_tftitulopropostatipo_sels = AV81TFTituloPropostaTipo_Sels;
         AV157Wpregistrartitulods_21_tftitulovalor = AV16TFTituloValor;
         AV158Wpregistrartitulods_22_tftitulovalor_to = AV17TFTituloValor_To;
         AV159Wpregistrartitulods_23_tftitulodesconto = AV18TFTituloDesconto;
         AV160Wpregistrartitulods_24_tftitulodesconto_to = AV19TFTituloDesconto_To;
         AV161Wpregistrartitulods_25_tftitulocompetencia_f = AV28TFTituloCompetencia_F;
         AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV29TFTituloCompetencia_F_Sel;
         AV163Wpregistrartitulods_27_tftituloprorrogacao = AV30TFTituloProrrogacao;
         AV164Wpregistrartitulods_28_tftituloprorrogacao_to = AV31TFTituloProrrogacao_To;
         AV165Wpregistrartitulods_29_tftitulojurosmora = AV44TFTituloJurosMora;
         AV166Wpregistrartitulods_30_tftitulojurosmora_to = AV45TFTituloJurosMora_To;
         AV167Wpregistrartitulods_31_tfnotafiscalnumero = AV129TFNotaFiscalNumero;
         AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV130TFNotaFiscalNumero_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV140Wpregistrartitulods_4_titulovalor1 ,
                                              AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV145Wpregistrartitulods_9_titulovalor2 ,
                                              AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV150Wpregistrartitulods_14_titulovalor3 ,
                                              AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV156Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV157Wpregistrartitulods_21_tftitulovalor ,
                                              AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV159Wpregistrartitulods_23_tftitulodesconto ,
                                              AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV137Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A275TituloSaldo_F ,
                                              A283TituloTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV152Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV154Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV167Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor P00EW13 */
         pr_default.execute(3, new Object[] {AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV140Wpregistrartitulods_4_titulovalor1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV141Wpregistrartitulods_5_contabancarianumero1, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV145Wpregistrartitulods_9_titulovalor2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV146Wpregistrartitulods_10_contabancarianumero2, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV150Wpregistrartitulods_14_titulovalor3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, AV151Wpregistrartitulods_15_contabancarianumero3, lV152Wpregistrartitulods_16_tftituloclienterazaosocial, AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV154Wpregistrartitulods_18_tftitulopropostadescricao, AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV157Wpregistrartitulods_21_tftitulovalor, AV158Wpregistrartitulods_22_tftitulovalor_to, AV159Wpregistrartitulods_23_tftitulodesconto, AV160Wpregistrartitulods_24_tftitulodesconto_to, AV163Wpregistrartitulods_27_tftituloprorrogacao, AV164Wpregistrartitulods_28_tftituloprorrogacao_to, AV165Wpregistrartitulods_29_tftitulojurosmora, AV166Wpregistrartitulods_30_tftitulojurosmora_to, lV167Wpregistrartitulods_31_tfnotafiscalnumero, AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKEW7 = false;
            A890NotaFiscalParcelamentoID = P00EW13_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00EW13_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00EW13_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW13_n794NotaFiscalId[0];
            A419TituloPropostaId = P00EW13_A419TituloPropostaId[0];
            n419TituloPropostaId = P00EW13_n419TituloPropostaId[0];
            A420TituloClienteId = P00EW13_A420TituloClienteId[0];
            n420TituloClienteId = P00EW13_n420TituloClienteId[0];
            A261TituloId = P00EW13_A261TituloId[0];
            n261TituloId = P00EW13_n261TituloId[0];
            A283TituloTipo = P00EW13_A283TituloTipo[0];
            n283TituloTipo = P00EW13_n283TituloTipo[0];
            A799NotaFiscalNumero = P00EW13_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW13_n799NotaFiscalNumero[0];
            A314TituloArchived = P00EW13_A314TituloArchived[0];
            n314TituloArchived = P00EW13_n314TituloArchived[0];
            A284TituloDeleted = P00EW13_A284TituloDeleted[0];
            n284TituloDeleted = P00EW13_n284TituloDeleted[0];
            A951ContaBancariaId = P00EW13_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EW13_n951ContaBancariaId[0];
            A498TituloJurosMora = P00EW13_A498TituloJurosMora[0];
            n498TituloJurosMora = P00EW13_n498TituloJurosMora[0];
            A264TituloProrrogacao = P00EW13_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00EW13_n264TituloProrrogacao[0];
            A276TituloDesconto = P00EW13_A276TituloDesconto[0];
            n276TituloDesconto = P00EW13_n276TituloDesconto[0];
            A952ContaBancariaNumero = P00EW13_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW13_n952ContaBancariaNumero[0];
            A262TituloValor = P00EW13_A262TituloValor[0];
            n262TituloValor = P00EW13_n262TituloValor[0];
            A648TituloPropostaTipo = P00EW13_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00EW13_n648TituloPropostaTipo[0];
            A971TituloPropostaDescricao = P00EW13_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW13_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EW13_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW13_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW13_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW13_n275TituloSaldo_F[0];
            A286TituloCompetenciaAno = P00EW13_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00EW13_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00EW13_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00EW13_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00EW13_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EW13_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00EW13_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EW13_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00EW13_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EW13_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EW13_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EW13_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EW13_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EW13_n275TituloSaldo_F[0];
            A952ContaBancariaNumero = P00EW13_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EW13_n952ContaBancariaNumero[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV137Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV137Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV161Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV102count = 0;
                        while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00EW13_A799NotaFiscalNumero[0], A799NotaFiscalNumero) == 0 ) )
                        {
                           BRKEW7 = false;
                           A890NotaFiscalParcelamentoID = P00EW13_A890NotaFiscalParcelamentoID[0];
                           n890NotaFiscalParcelamentoID = P00EW13_n890NotaFiscalParcelamentoID[0];
                           A794NotaFiscalId = P00EW13_A794NotaFiscalId[0];
                           n794NotaFiscalId = P00EW13_n794NotaFiscalId[0];
                           A261TituloId = P00EW13_A261TituloId[0];
                           n261TituloId = P00EW13_n261TituloId[0];
                           A794NotaFiscalId = P00EW13_A794NotaFiscalId[0];
                           n794NotaFiscalId = P00EW13_n794NotaFiscalId[0];
                           AV102count = (long)(AV102count+1);
                           BRKEW7 = true;
                           pr_default.readNext(3);
                        }
                        if ( (0==AV93SkipItems) )
                        {
                           AV97Option = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? "<#Empty#>" : A799NotaFiscalNumero);
                           AV98Options.Add(AV97Option, 0);
                           AV101OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV102count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV98Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV93SkipItems = (short)(AV93SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKEW7 )
            {
               BRKEW7 = true;
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
         AV111OptionsJson = "";
         AV112OptionsDescJson = "";
         AV113OptionIndexesJson = "";
         AV98Options = new GxSimpleCollection<string>();
         AV100OptionsDesc = new GxSimpleCollection<string>();
         AV101OptionIndexes = new GxSimpleCollection<string>();
         AV92SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV103Session = context.GetSession();
         AV105GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV106GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV114FilterFullText = "";
         AV133TFTituloCLienteRazaoSocial = "";
         AV134TFTituloCLienteRazaoSocial_Sel = "";
         AV131TFTituloPropostaDescricao = "";
         AV132TFTituloPropostaDescricao_Sel = "";
         AV80TFTituloPropostaTipo_SelsJson = "";
         AV81TFTituloPropostaTipo_Sels = new GxSimpleCollection<string>();
         AV28TFTituloCompetencia_F = "";
         AV29TFTituloCompetencia_F_Sel = "";
         AV30TFTituloProrrogacao = DateTime.MinValue;
         AV31TFTituloProrrogacao_To = DateTime.MinValue;
         AV129TFNotaFiscalNumero = "";
         AV130TFNotaFiscalNumero_Sel = "";
         AV107GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV115DynamicFiltersSelector1 = "";
         AV120DynamicFiltersSelector2 = "";
         AV125DynamicFiltersSelector3 = "";
         AV137Wpregistrartitulods_1_filterfulltext = "";
         AV138Wpregistrartitulods_2_dynamicfiltersselector1 = "";
         AV143Wpregistrartitulods_7_dynamicfiltersselector2 = "";
         AV148Wpregistrartitulods_12_dynamicfiltersselector3 = "";
         AV152Wpregistrartitulods_16_tftituloclienterazaosocial = "";
         AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel = "";
         AV154Wpregistrartitulods_18_tftitulopropostadescricao = "";
         AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel = "";
         AV156Wpregistrartitulods_20_tftitulopropostatipo_sels = new GxSimpleCollection<string>();
         AV161Wpregistrartitulods_25_tftitulocompetencia_f = "";
         AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel = "";
         AV163Wpregistrartitulods_27_tftituloprorrogacao = DateTime.MinValue;
         AV164Wpregistrartitulods_28_tftituloprorrogacao_to = DateTime.MinValue;
         AV167Wpregistrartitulods_31_tfnotafiscalnumero = "";
         AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel = "";
         lV137Wpregistrartitulods_1_filterfulltext = "";
         lV152Wpregistrartitulods_16_tftituloclienterazaosocial = "";
         lV154Wpregistrartitulods_18_tftitulopropostadescricao = "";
         lV167Wpregistrartitulods_31_tfnotafiscalnumero = "";
         A648TituloPropostaTipo = "";
         A972TituloCLienteRazaoSocial = "";
         A971TituloPropostaDescricao = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A799NotaFiscalNumero = "";
         A295TituloCompetencia_F = "";
         A283TituloTipo = "";
         P00EW4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EW4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00EW4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EW4_n794NotaFiscalId = new bool[] {false} ;
         P00EW4_A419TituloPropostaId = new int[1] ;
         P00EW4_n419TituloPropostaId = new bool[] {false} ;
         P00EW4_A420TituloClienteId = new int[1] ;
         P00EW4_n420TituloClienteId = new bool[] {false} ;
         P00EW4_A261TituloId = new int[1] ;
         P00EW4_n261TituloId = new bool[] {false} ;
         P00EW4_A283TituloTipo = new string[] {""} ;
         P00EW4_n283TituloTipo = new bool[] {false} ;
         P00EW4_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00EW4_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00EW4_A314TituloArchived = new bool[] {false} ;
         P00EW4_n314TituloArchived = new bool[] {false} ;
         P00EW4_A284TituloDeleted = new bool[] {false} ;
         P00EW4_n284TituloDeleted = new bool[] {false} ;
         P00EW4_A951ContaBancariaId = new int[1] ;
         P00EW4_n951ContaBancariaId = new bool[] {false} ;
         P00EW4_A498TituloJurosMora = new decimal[1] ;
         P00EW4_n498TituloJurosMora = new bool[] {false} ;
         P00EW4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00EW4_n264TituloProrrogacao = new bool[] {false} ;
         P00EW4_A276TituloDesconto = new decimal[1] ;
         P00EW4_n276TituloDesconto = new bool[] {false} ;
         P00EW4_A952ContaBancariaNumero = new long[1] ;
         P00EW4_n952ContaBancariaNumero = new bool[] {false} ;
         P00EW4_A262TituloValor = new decimal[1] ;
         P00EW4_n262TituloValor = new bool[] {false} ;
         P00EW4_A799NotaFiscalNumero = new string[] {""} ;
         P00EW4_n799NotaFiscalNumero = new bool[] {false} ;
         P00EW4_A648TituloPropostaTipo = new string[] {""} ;
         P00EW4_n648TituloPropostaTipo = new bool[] {false} ;
         P00EW4_A971TituloPropostaDescricao = new string[] {""} ;
         P00EW4_n971TituloPropostaDescricao = new bool[] {false} ;
         P00EW4_A275TituloSaldo_F = new decimal[1] ;
         P00EW4_n275TituloSaldo_F = new bool[] {false} ;
         P00EW4_A286TituloCompetenciaAno = new short[1] ;
         P00EW4_n286TituloCompetenciaAno = new bool[] {false} ;
         P00EW4_A287TituloCompetenciaMes = new short[1] ;
         P00EW4_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         AV97Option = "";
         P00EW7_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EW7_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00EW7_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EW7_n794NotaFiscalId = new bool[] {false} ;
         P00EW7_A419TituloPropostaId = new int[1] ;
         P00EW7_n419TituloPropostaId = new bool[] {false} ;
         P00EW7_A420TituloClienteId = new int[1] ;
         P00EW7_n420TituloClienteId = new bool[] {false} ;
         P00EW7_A261TituloId = new int[1] ;
         P00EW7_n261TituloId = new bool[] {false} ;
         P00EW7_A283TituloTipo = new string[] {""} ;
         P00EW7_n283TituloTipo = new bool[] {false} ;
         P00EW7_A971TituloPropostaDescricao = new string[] {""} ;
         P00EW7_n971TituloPropostaDescricao = new bool[] {false} ;
         P00EW7_A314TituloArchived = new bool[] {false} ;
         P00EW7_n314TituloArchived = new bool[] {false} ;
         P00EW7_A284TituloDeleted = new bool[] {false} ;
         P00EW7_n284TituloDeleted = new bool[] {false} ;
         P00EW7_A951ContaBancariaId = new int[1] ;
         P00EW7_n951ContaBancariaId = new bool[] {false} ;
         P00EW7_A498TituloJurosMora = new decimal[1] ;
         P00EW7_n498TituloJurosMora = new bool[] {false} ;
         P00EW7_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00EW7_n264TituloProrrogacao = new bool[] {false} ;
         P00EW7_A276TituloDesconto = new decimal[1] ;
         P00EW7_n276TituloDesconto = new bool[] {false} ;
         P00EW7_A952ContaBancariaNumero = new long[1] ;
         P00EW7_n952ContaBancariaNumero = new bool[] {false} ;
         P00EW7_A262TituloValor = new decimal[1] ;
         P00EW7_n262TituloValor = new bool[] {false} ;
         P00EW7_A799NotaFiscalNumero = new string[] {""} ;
         P00EW7_n799NotaFiscalNumero = new bool[] {false} ;
         P00EW7_A648TituloPropostaTipo = new string[] {""} ;
         P00EW7_n648TituloPropostaTipo = new bool[] {false} ;
         P00EW7_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00EW7_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00EW7_A275TituloSaldo_F = new decimal[1] ;
         P00EW7_n275TituloSaldo_F = new bool[] {false} ;
         P00EW7_A286TituloCompetenciaAno = new short[1] ;
         P00EW7_n286TituloCompetenciaAno = new bool[] {false} ;
         P00EW7_A287TituloCompetenciaMes = new short[1] ;
         P00EW7_n287TituloCompetenciaMes = new bool[] {false} ;
         P00EW10_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EW10_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00EW10_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EW10_n794NotaFiscalId = new bool[] {false} ;
         P00EW10_A419TituloPropostaId = new int[1] ;
         P00EW10_n419TituloPropostaId = new bool[] {false} ;
         P00EW10_A420TituloClienteId = new int[1] ;
         P00EW10_n420TituloClienteId = new bool[] {false} ;
         P00EW10_A261TituloId = new int[1] ;
         P00EW10_n261TituloId = new bool[] {false} ;
         P00EW10_A283TituloTipo = new string[] {""} ;
         P00EW10_n283TituloTipo = new bool[] {false} ;
         P00EW10_A314TituloArchived = new bool[] {false} ;
         P00EW10_n314TituloArchived = new bool[] {false} ;
         P00EW10_A284TituloDeleted = new bool[] {false} ;
         P00EW10_n284TituloDeleted = new bool[] {false} ;
         P00EW10_A951ContaBancariaId = new int[1] ;
         P00EW10_n951ContaBancariaId = new bool[] {false} ;
         P00EW10_A498TituloJurosMora = new decimal[1] ;
         P00EW10_n498TituloJurosMora = new bool[] {false} ;
         P00EW10_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00EW10_n264TituloProrrogacao = new bool[] {false} ;
         P00EW10_A276TituloDesconto = new decimal[1] ;
         P00EW10_n276TituloDesconto = new bool[] {false} ;
         P00EW10_A952ContaBancariaNumero = new long[1] ;
         P00EW10_n952ContaBancariaNumero = new bool[] {false} ;
         P00EW10_A262TituloValor = new decimal[1] ;
         P00EW10_n262TituloValor = new bool[] {false} ;
         P00EW10_A799NotaFiscalNumero = new string[] {""} ;
         P00EW10_n799NotaFiscalNumero = new bool[] {false} ;
         P00EW10_A648TituloPropostaTipo = new string[] {""} ;
         P00EW10_n648TituloPropostaTipo = new bool[] {false} ;
         P00EW10_A971TituloPropostaDescricao = new string[] {""} ;
         P00EW10_n971TituloPropostaDescricao = new bool[] {false} ;
         P00EW10_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00EW10_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00EW10_A275TituloSaldo_F = new decimal[1] ;
         P00EW10_n275TituloSaldo_F = new bool[] {false} ;
         P00EW10_A286TituloCompetenciaAno = new short[1] ;
         P00EW10_n286TituloCompetenciaAno = new bool[] {false} ;
         P00EW10_A287TituloCompetenciaMes = new short[1] ;
         P00EW10_n287TituloCompetenciaMes = new bool[] {false} ;
         P00EW13_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EW13_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00EW13_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EW13_n794NotaFiscalId = new bool[] {false} ;
         P00EW13_A419TituloPropostaId = new int[1] ;
         P00EW13_n419TituloPropostaId = new bool[] {false} ;
         P00EW13_A420TituloClienteId = new int[1] ;
         P00EW13_n420TituloClienteId = new bool[] {false} ;
         P00EW13_A261TituloId = new int[1] ;
         P00EW13_n261TituloId = new bool[] {false} ;
         P00EW13_A283TituloTipo = new string[] {""} ;
         P00EW13_n283TituloTipo = new bool[] {false} ;
         P00EW13_A799NotaFiscalNumero = new string[] {""} ;
         P00EW13_n799NotaFiscalNumero = new bool[] {false} ;
         P00EW13_A314TituloArchived = new bool[] {false} ;
         P00EW13_n314TituloArchived = new bool[] {false} ;
         P00EW13_A284TituloDeleted = new bool[] {false} ;
         P00EW13_n284TituloDeleted = new bool[] {false} ;
         P00EW13_A951ContaBancariaId = new int[1] ;
         P00EW13_n951ContaBancariaId = new bool[] {false} ;
         P00EW13_A498TituloJurosMora = new decimal[1] ;
         P00EW13_n498TituloJurosMora = new bool[] {false} ;
         P00EW13_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00EW13_n264TituloProrrogacao = new bool[] {false} ;
         P00EW13_A276TituloDesconto = new decimal[1] ;
         P00EW13_n276TituloDesconto = new bool[] {false} ;
         P00EW13_A952ContaBancariaNumero = new long[1] ;
         P00EW13_n952ContaBancariaNumero = new bool[] {false} ;
         P00EW13_A262TituloValor = new decimal[1] ;
         P00EW13_n262TituloValor = new bool[] {false} ;
         P00EW13_A648TituloPropostaTipo = new string[] {""} ;
         P00EW13_n648TituloPropostaTipo = new bool[] {false} ;
         P00EW13_A971TituloPropostaDescricao = new string[] {""} ;
         P00EW13_n971TituloPropostaDescricao = new bool[] {false} ;
         P00EW13_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00EW13_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00EW13_A275TituloSaldo_F = new decimal[1] ;
         P00EW13_n275TituloSaldo_F = new bool[] {false} ;
         P00EW13_A286TituloCompetenciaAno = new short[1] ;
         P00EW13_n286TituloCompetenciaAno = new bool[] {false} ;
         P00EW13_A287TituloCompetenciaMes = new short[1] ;
         P00EW13_n287TituloCompetenciaMes = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistrartitulogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EW4_A890NotaFiscalParcelamentoID, P00EW4_n890NotaFiscalParcelamentoID, P00EW4_A794NotaFiscalId, P00EW4_n794NotaFiscalId, P00EW4_A419TituloPropostaId, P00EW4_n419TituloPropostaId, P00EW4_A420TituloClienteId, P00EW4_n420TituloClienteId, P00EW4_A261TituloId, P00EW4_A283TituloTipo,
               P00EW4_n283TituloTipo, P00EW4_A972TituloCLienteRazaoSocial, P00EW4_n972TituloCLienteRazaoSocial, P00EW4_A314TituloArchived, P00EW4_n314TituloArchived, P00EW4_A284TituloDeleted, P00EW4_n284TituloDeleted, P00EW4_A951ContaBancariaId, P00EW4_n951ContaBancariaId, P00EW4_A498TituloJurosMora,
               P00EW4_n498TituloJurosMora, P00EW4_A264TituloProrrogacao, P00EW4_n264TituloProrrogacao, P00EW4_A276TituloDesconto, P00EW4_n276TituloDesconto, P00EW4_A952ContaBancariaNumero, P00EW4_n952ContaBancariaNumero, P00EW4_A262TituloValor, P00EW4_n262TituloValor, P00EW4_A799NotaFiscalNumero,
               P00EW4_n799NotaFiscalNumero, P00EW4_A648TituloPropostaTipo, P00EW4_n648TituloPropostaTipo, P00EW4_A971TituloPropostaDescricao, P00EW4_n971TituloPropostaDescricao, P00EW4_A275TituloSaldo_F, P00EW4_n275TituloSaldo_F, P00EW4_A286TituloCompetenciaAno, P00EW4_n286TituloCompetenciaAno, P00EW4_A287TituloCompetenciaMes,
               P00EW4_n287TituloCompetenciaMes
               }
               , new Object[] {
               P00EW7_A890NotaFiscalParcelamentoID, P00EW7_n890NotaFiscalParcelamentoID, P00EW7_A794NotaFiscalId, P00EW7_n794NotaFiscalId, P00EW7_A419TituloPropostaId, P00EW7_n419TituloPropostaId, P00EW7_A420TituloClienteId, P00EW7_n420TituloClienteId, P00EW7_A261TituloId, P00EW7_A283TituloTipo,
               P00EW7_n283TituloTipo, P00EW7_A971TituloPropostaDescricao, P00EW7_n971TituloPropostaDescricao, P00EW7_A314TituloArchived, P00EW7_n314TituloArchived, P00EW7_A284TituloDeleted, P00EW7_n284TituloDeleted, P00EW7_A951ContaBancariaId, P00EW7_n951ContaBancariaId, P00EW7_A498TituloJurosMora,
               P00EW7_n498TituloJurosMora, P00EW7_A264TituloProrrogacao, P00EW7_n264TituloProrrogacao, P00EW7_A276TituloDesconto, P00EW7_n276TituloDesconto, P00EW7_A952ContaBancariaNumero, P00EW7_n952ContaBancariaNumero, P00EW7_A262TituloValor, P00EW7_n262TituloValor, P00EW7_A799NotaFiscalNumero,
               P00EW7_n799NotaFiscalNumero, P00EW7_A648TituloPropostaTipo, P00EW7_n648TituloPropostaTipo, P00EW7_A972TituloCLienteRazaoSocial, P00EW7_n972TituloCLienteRazaoSocial, P00EW7_A275TituloSaldo_F, P00EW7_n275TituloSaldo_F, P00EW7_A286TituloCompetenciaAno, P00EW7_n286TituloCompetenciaAno, P00EW7_A287TituloCompetenciaMes,
               P00EW7_n287TituloCompetenciaMes
               }
               , new Object[] {
               P00EW10_A890NotaFiscalParcelamentoID, P00EW10_n890NotaFiscalParcelamentoID, P00EW10_A794NotaFiscalId, P00EW10_n794NotaFiscalId, P00EW10_A419TituloPropostaId, P00EW10_n419TituloPropostaId, P00EW10_A420TituloClienteId, P00EW10_n420TituloClienteId, P00EW10_A261TituloId, P00EW10_A283TituloTipo,
               P00EW10_n283TituloTipo, P00EW10_A314TituloArchived, P00EW10_n314TituloArchived, P00EW10_A284TituloDeleted, P00EW10_n284TituloDeleted, P00EW10_A951ContaBancariaId, P00EW10_n951ContaBancariaId, P00EW10_A498TituloJurosMora, P00EW10_n498TituloJurosMora, P00EW10_A264TituloProrrogacao,
               P00EW10_n264TituloProrrogacao, P00EW10_A276TituloDesconto, P00EW10_n276TituloDesconto, P00EW10_A952ContaBancariaNumero, P00EW10_n952ContaBancariaNumero, P00EW10_A262TituloValor, P00EW10_n262TituloValor, P00EW10_A799NotaFiscalNumero, P00EW10_n799NotaFiscalNumero, P00EW10_A648TituloPropostaTipo,
               P00EW10_n648TituloPropostaTipo, P00EW10_A971TituloPropostaDescricao, P00EW10_n971TituloPropostaDescricao, P00EW10_A972TituloCLienteRazaoSocial, P00EW10_n972TituloCLienteRazaoSocial, P00EW10_A275TituloSaldo_F, P00EW10_n275TituloSaldo_F, P00EW10_A286TituloCompetenciaAno, P00EW10_n286TituloCompetenciaAno, P00EW10_A287TituloCompetenciaMes,
               P00EW10_n287TituloCompetenciaMes
               }
               , new Object[] {
               P00EW13_A890NotaFiscalParcelamentoID, P00EW13_n890NotaFiscalParcelamentoID, P00EW13_A794NotaFiscalId, P00EW13_n794NotaFiscalId, P00EW13_A419TituloPropostaId, P00EW13_n419TituloPropostaId, P00EW13_A420TituloClienteId, P00EW13_n420TituloClienteId, P00EW13_A261TituloId, P00EW13_A283TituloTipo,
               P00EW13_n283TituloTipo, P00EW13_A799NotaFiscalNumero, P00EW13_n799NotaFiscalNumero, P00EW13_A314TituloArchived, P00EW13_n314TituloArchived, P00EW13_A284TituloDeleted, P00EW13_n284TituloDeleted, P00EW13_A951ContaBancariaId, P00EW13_n951ContaBancariaId, P00EW13_A498TituloJurosMora,
               P00EW13_n498TituloJurosMora, P00EW13_A264TituloProrrogacao, P00EW13_n264TituloProrrogacao, P00EW13_A276TituloDesconto, P00EW13_n276TituloDesconto, P00EW13_A952ContaBancariaNumero, P00EW13_n952ContaBancariaNumero, P00EW13_A262TituloValor, P00EW13_n262TituloValor, P00EW13_A648TituloPropostaTipo,
               P00EW13_n648TituloPropostaTipo, P00EW13_A971TituloPropostaDescricao, P00EW13_n971TituloPropostaDescricao, P00EW13_A972TituloCLienteRazaoSocial, P00EW13_n972TituloCLienteRazaoSocial, P00EW13_A275TituloSaldo_F, P00EW13_n275TituloSaldo_F, P00EW13_A286TituloCompetenciaAno, P00EW13_n286TituloCompetenciaAno, P00EW13_A287TituloCompetenciaMes,
               P00EW13_n287TituloCompetenciaMes
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV95MaxItems ;
      private short AV94PageIndex ;
      private short AV93SkipItems ;
      private short AV116DynamicFiltersOperator1 ;
      private short AV121DynamicFiltersOperator2 ;
      private short AV126DynamicFiltersOperator3 ;
      private short AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ;
      private short AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ;
      private short AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV135GXV1 ;
      private int AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ;
      private int A951ContaBancariaId ;
      private int A419TituloPropostaId ;
      private int A420TituloClienteId ;
      private int A261TituloId ;
      private int AV96InsertIndex ;
      private long AV118ContaBancariaNumero1 ;
      private long AV123ContaBancariaNumero2 ;
      private long AV128ContaBancariaNumero3 ;
      private long AV141Wpregistrartitulods_5_contabancarianumero1 ;
      private long AV146Wpregistrartitulods_10_contabancarianumero2 ;
      private long AV151Wpregistrartitulods_15_contabancarianumero3 ;
      private long A952ContaBancariaNumero ;
      private long AV102count ;
      private decimal AV16TFTituloValor ;
      private decimal AV17TFTituloValor_To ;
      private decimal AV18TFTituloDesconto ;
      private decimal AV19TFTituloDesconto_To ;
      private decimal AV44TFTituloJurosMora ;
      private decimal AV45TFTituloJurosMora_To ;
      private decimal AV117TituloValor1 ;
      private decimal AV122TituloValor2 ;
      private decimal AV127TituloValor3 ;
      private decimal AV140Wpregistrartitulods_4_titulovalor1 ;
      private decimal AV145Wpregistrartitulods_9_titulovalor2 ;
      private decimal AV150Wpregistrartitulods_14_titulovalor3 ;
      private decimal AV157Wpregistrartitulods_21_tftitulovalor ;
      private decimal AV158Wpregistrartitulods_22_tftitulovalor_to ;
      private decimal AV159Wpregistrartitulods_23_tftitulodesconto ;
      private decimal AV160Wpregistrartitulods_24_tftitulodesconto_to ;
      private decimal AV165Wpregistrartitulods_29_tftitulojurosmora ;
      private decimal AV166Wpregistrartitulods_30_tftitulojurosmora_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A498TituloJurosMora ;
      private decimal A275TituloSaldo_F ;
      private DateTime AV30TFTituloProrrogacao ;
      private DateTime AV31TFTituloProrrogacao_To ;
      private DateTime AV163Wpregistrartitulods_27_tftituloprorrogacao ;
      private DateTime AV164Wpregistrartitulods_28_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool AV119DynamicFiltersEnabled2 ;
      private bool AV124DynamicFiltersEnabled3 ;
      private bool AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ;
      private bool AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ;
      private bool A284TituloDeleted ;
      private bool A314TituloArchived ;
      private bool BRKEW2 ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n419TituloPropostaId ;
      private bool n420TituloClienteId ;
      private bool n261TituloId ;
      private bool n283TituloTipo ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n314TituloArchived ;
      private bool n284TituloDeleted ;
      private bool n951ContaBancariaId ;
      private bool n498TituloJurosMora ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n952ContaBancariaNumero ;
      private bool n262TituloValor ;
      private bool n799NotaFiscalNumero ;
      private bool n648TituloPropostaTipo ;
      private bool n971TituloPropostaDescricao ;
      private bool n275TituloSaldo_F ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool BRKEW4 ;
      private bool BRKEW7 ;
      private string AV111OptionsJson ;
      private string AV112OptionsDescJson ;
      private string AV113OptionIndexesJson ;
      private string AV80TFTituloPropostaTipo_SelsJson ;
      private string AV108DDOName ;
      private string AV109SearchTxtParms ;
      private string AV110SearchTxtTo ;
      private string AV92SearchTxt ;
      private string AV114FilterFullText ;
      private string AV133TFTituloCLienteRazaoSocial ;
      private string AV134TFTituloCLienteRazaoSocial_Sel ;
      private string AV131TFTituloPropostaDescricao ;
      private string AV132TFTituloPropostaDescricao_Sel ;
      private string AV28TFTituloCompetencia_F ;
      private string AV29TFTituloCompetencia_F_Sel ;
      private string AV129TFNotaFiscalNumero ;
      private string AV130TFNotaFiscalNumero_Sel ;
      private string AV115DynamicFiltersSelector1 ;
      private string AV120DynamicFiltersSelector2 ;
      private string AV125DynamicFiltersSelector3 ;
      private string AV137Wpregistrartitulods_1_filterfulltext ;
      private string AV138Wpregistrartitulods_2_dynamicfiltersselector1 ;
      private string AV143Wpregistrartitulods_7_dynamicfiltersselector2 ;
      private string AV148Wpregistrartitulods_12_dynamicfiltersselector3 ;
      private string AV152Wpregistrartitulods_16_tftituloclienterazaosocial ;
      private string AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ;
      private string AV154Wpregistrartitulods_18_tftitulopropostadescricao ;
      private string AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ;
      private string AV161Wpregistrartitulods_25_tftitulocompetencia_f ;
      private string AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ;
      private string AV167Wpregistrartitulods_31_tfnotafiscalnumero ;
      private string AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ;
      private string lV137Wpregistrartitulods_1_filterfulltext ;
      private string lV152Wpregistrartitulods_16_tftituloclienterazaosocial ;
      private string lV154Wpregistrartitulods_18_tftitulopropostadescricao ;
      private string lV167Wpregistrartitulods_31_tfnotafiscalnumero ;
      private string A648TituloPropostaTipo ;
      private string A972TituloCLienteRazaoSocial ;
      private string A971TituloPropostaDescricao ;
      private string A799NotaFiscalNumero ;
      private string A295TituloCompetencia_F ;
      private string A283TituloTipo ;
      private string AV97Option ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV103Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV98Options ;
      private GxSimpleCollection<string> AV100OptionsDesc ;
      private GxSimpleCollection<string> AV101OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV105GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV106GridStateFilterValue ;
      private GxSimpleCollection<string> AV81TFTituloPropostaTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV107GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EW4_A890NotaFiscalParcelamentoID ;
      private bool[] P00EW4_n890NotaFiscalParcelamentoID ;
      private Guid[] P00EW4_A794NotaFiscalId ;
      private bool[] P00EW4_n794NotaFiscalId ;
      private int[] P00EW4_A419TituloPropostaId ;
      private bool[] P00EW4_n419TituloPropostaId ;
      private int[] P00EW4_A420TituloClienteId ;
      private bool[] P00EW4_n420TituloClienteId ;
      private int[] P00EW4_A261TituloId ;
      private bool[] P00EW4_n261TituloId ;
      private string[] P00EW4_A283TituloTipo ;
      private bool[] P00EW4_n283TituloTipo ;
      private string[] P00EW4_A972TituloCLienteRazaoSocial ;
      private bool[] P00EW4_n972TituloCLienteRazaoSocial ;
      private bool[] P00EW4_A314TituloArchived ;
      private bool[] P00EW4_n314TituloArchived ;
      private bool[] P00EW4_A284TituloDeleted ;
      private bool[] P00EW4_n284TituloDeleted ;
      private int[] P00EW4_A951ContaBancariaId ;
      private bool[] P00EW4_n951ContaBancariaId ;
      private decimal[] P00EW4_A498TituloJurosMora ;
      private bool[] P00EW4_n498TituloJurosMora ;
      private DateTime[] P00EW4_A264TituloProrrogacao ;
      private bool[] P00EW4_n264TituloProrrogacao ;
      private decimal[] P00EW4_A276TituloDesconto ;
      private bool[] P00EW4_n276TituloDesconto ;
      private long[] P00EW4_A952ContaBancariaNumero ;
      private bool[] P00EW4_n952ContaBancariaNumero ;
      private decimal[] P00EW4_A262TituloValor ;
      private bool[] P00EW4_n262TituloValor ;
      private string[] P00EW4_A799NotaFiscalNumero ;
      private bool[] P00EW4_n799NotaFiscalNumero ;
      private string[] P00EW4_A648TituloPropostaTipo ;
      private bool[] P00EW4_n648TituloPropostaTipo ;
      private string[] P00EW4_A971TituloPropostaDescricao ;
      private bool[] P00EW4_n971TituloPropostaDescricao ;
      private decimal[] P00EW4_A275TituloSaldo_F ;
      private bool[] P00EW4_n275TituloSaldo_F ;
      private short[] P00EW4_A286TituloCompetenciaAno ;
      private bool[] P00EW4_n286TituloCompetenciaAno ;
      private short[] P00EW4_A287TituloCompetenciaMes ;
      private bool[] P00EW4_n287TituloCompetenciaMes ;
      private Guid[] P00EW7_A890NotaFiscalParcelamentoID ;
      private bool[] P00EW7_n890NotaFiscalParcelamentoID ;
      private Guid[] P00EW7_A794NotaFiscalId ;
      private bool[] P00EW7_n794NotaFiscalId ;
      private int[] P00EW7_A419TituloPropostaId ;
      private bool[] P00EW7_n419TituloPropostaId ;
      private int[] P00EW7_A420TituloClienteId ;
      private bool[] P00EW7_n420TituloClienteId ;
      private int[] P00EW7_A261TituloId ;
      private bool[] P00EW7_n261TituloId ;
      private string[] P00EW7_A283TituloTipo ;
      private bool[] P00EW7_n283TituloTipo ;
      private string[] P00EW7_A971TituloPropostaDescricao ;
      private bool[] P00EW7_n971TituloPropostaDescricao ;
      private bool[] P00EW7_A314TituloArchived ;
      private bool[] P00EW7_n314TituloArchived ;
      private bool[] P00EW7_A284TituloDeleted ;
      private bool[] P00EW7_n284TituloDeleted ;
      private int[] P00EW7_A951ContaBancariaId ;
      private bool[] P00EW7_n951ContaBancariaId ;
      private decimal[] P00EW7_A498TituloJurosMora ;
      private bool[] P00EW7_n498TituloJurosMora ;
      private DateTime[] P00EW7_A264TituloProrrogacao ;
      private bool[] P00EW7_n264TituloProrrogacao ;
      private decimal[] P00EW7_A276TituloDesconto ;
      private bool[] P00EW7_n276TituloDesconto ;
      private long[] P00EW7_A952ContaBancariaNumero ;
      private bool[] P00EW7_n952ContaBancariaNumero ;
      private decimal[] P00EW7_A262TituloValor ;
      private bool[] P00EW7_n262TituloValor ;
      private string[] P00EW7_A799NotaFiscalNumero ;
      private bool[] P00EW7_n799NotaFiscalNumero ;
      private string[] P00EW7_A648TituloPropostaTipo ;
      private bool[] P00EW7_n648TituloPropostaTipo ;
      private string[] P00EW7_A972TituloCLienteRazaoSocial ;
      private bool[] P00EW7_n972TituloCLienteRazaoSocial ;
      private decimal[] P00EW7_A275TituloSaldo_F ;
      private bool[] P00EW7_n275TituloSaldo_F ;
      private short[] P00EW7_A286TituloCompetenciaAno ;
      private bool[] P00EW7_n286TituloCompetenciaAno ;
      private short[] P00EW7_A287TituloCompetenciaMes ;
      private bool[] P00EW7_n287TituloCompetenciaMes ;
      private Guid[] P00EW10_A890NotaFiscalParcelamentoID ;
      private bool[] P00EW10_n890NotaFiscalParcelamentoID ;
      private Guid[] P00EW10_A794NotaFiscalId ;
      private bool[] P00EW10_n794NotaFiscalId ;
      private int[] P00EW10_A419TituloPropostaId ;
      private bool[] P00EW10_n419TituloPropostaId ;
      private int[] P00EW10_A420TituloClienteId ;
      private bool[] P00EW10_n420TituloClienteId ;
      private int[] P00EW10_A261TituloId ;
      private bool[] P00EW10_n261TituloId ;
      private string[] P00EW10_A283TituloTipo ;
      private bool[] P00EW10_n283TituloTipo ;
      private bool[] P00EW10_A314TituloArchived ;
      private bool[] P00EW10_n314TituloArchived ;
      private bool[] P00EW10_A284TituloDeleted ;
      private bool[] P00EW10_n284TituloDeleted ;
      private int[] P00EW10_A951ContaBancariaId ;
      private bool[] P00EW10_n951ContaBancariaId ;
      private decimal[] P00EW10_A498TituloJurosMora ;
      private bool[] P00EW10_n498TituloJurosMora ;
      private DateTime[] P00EW10_A264TituloProrrogacao ;
      private bool[] P00EW10_n264TituloProrrogacao ;
      private decimal[] P00EW10_A276TituloDesconto ;
      private bool[] P00EW10_n276TituloDesconto ;
      private long[] P00EW10_A952ContaBancariaNumero ;
      private bool[] P00EW10_n952ContaBancariaNumero ;
      private decimal[] P00EW10_A262TituloValor ;
      private bool[] P00EW10_n262TituloValor ;
      private string[] P00EW10_A799NotaFiscalNumero ;
      private bool[] P00EW10_n799NotaFiscalNumero ;
      private string[] P00EW10_A648TituloPropostaTipo ;
      private bool[] P00EW10_n648TituloPropostaTipo ;
      private string[] P00EW10_A971TituloPropostaDescricao ;
      private bool[] P00EW10_n971TituloPropostaDescricao ;
      private string[] P00EW10_A972TituloCLienteRazaoSocial ;
      private bool[] P00EW10_n972TituloCLienteRazaoSocial ;
      private decimal[] P00EW10_A275TituloSaldo_F ;
      private bool[] P00EW10_n275TituloSaldo_F ;
      private short[] P00EW10_A286TituloCompetenciaAno ;
      private bool[] P00EW10_n286TituloCompetenciaAno ;
      private short[] P00EW10_A287TituloCompetenciaMes ;
      private bool[] P00EW10_n287TituloCompetenciaMes ;
      private Guid[] P00EW13_A890NotaFiscalParcelamentoID ;
      private bool[] P00EW13_n890NotaFiscalParcelamentoID ;
      private Guid[] P00EW13_A794NotaFiscalId ;
      private bool[] P00EW13_n794NotaFiscalId ;
      private int[] P00EW13_A419TituloPropostaId ;
      private bool[] P00EW13_n419TituloPropostaId ;
      private int[] P00EW13_A420TituloClienteId ;
      private bool[] P00EW13_n420TituloClienteId ;
      private int[] P00EW13_A261TituloId ;
      private bool[] P00EW13_n261TituloId ;
      private string[] P00EW13_A283TituloTipo ;
      private bool[] P00EW13_n283TituloTipo ;
      private string[] P00EW13_A799NotaFiscalNumero ;
      private bool[] P00EW13_n799NotaFiscalNumero ;
      private bool[] P00EW13_A314TituloArchived ;
      private bool[] P00EW13_n314TituloArchived ;
      private bool[] P00EW13_A284TituloDeleted ;
      private bool[] P00EW13_n284TituloDeleted ;
      private int[] P00EW13_A951ContaBancariaId ;
      private bool[] P00EW13_n951ContaBancariaId ;
      private decimal[] P00EW13_A498TituloJurosMora ;
      private bool[] P00EW13_n498TituloJurosMora ;
      private DateTime[] P00EW13_A264TituloProrrogacao ;
      private bool[] P00EW13_n264TituloProrrogacao ;
      private decimal[] P00EW13_A276TituloDesconto ;
      private bool[] P00EW13_n276TituloDesconto ;
      private long[] P00EW13_A952ContaBancariaNumero ;
      private bool[] P00EW13_n952ContaBancariaNumero ;
      private decimal[] P00EW13_A262TituloValor ;
      private bool[] P00EW13_n262TituloValor ;
      private string[] P00EW13_A648TituloPropostaTipo ;
      private bool[] P00EW13_n648TituloPropostaTipo ;
      private string[] P00EW13_A971TituloPropostaDescricao ;
      private bool[] P00EW13_n971TituloPropostaDescricao ;
      private string[] P00EW13_A972TituloCLienteRazaoSocial ;
      private bool[] P00EW13_n972TituloCLienteRazaoSocial ;
      private decimal[] P00EW13_A275TituloSaldo_F ;
      private bool[] P00EW13_n275TituloSaldo_F ;
      private short[] P00EW13_A286TituloCompetenciaAno ;
      private bool[] P00EW13_n286TituloCompetenciaAno ;
      private short[] P00EW13_A287TituloCompetenciaMes ;
      private bool[] P00EW13_n287TituloCompetenciaMes ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpregistrartitulogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EW4( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                             string AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                             short AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                             decimal AV140Wpregistrartitulods_4_titulovalor1 ,
                                             long AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                             bool AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                             string AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                             short AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                             decimal AV145Wpregistrartitulods_9_titulovalor2 ,
                                             long AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                             bool AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                             string AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                             short AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                             decimal AV150Wpregistrartitulods_14_titulovalor3 ,
                                             long AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                             string AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                             string AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                             string AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                             string AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                             int AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                             decimal AV157Wpregistrartitulods_21_tftitulovalor ,
                                             decimal AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                             decimal AV159Wpregistrartitulods_23_tftitulodesconto ,
                                             decimal AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                             DateTime AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                             DateTime AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                             decimal AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                             decimal AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                             string AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                             string AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                             decimal A262TituloValor ,
                                             long A952ContaBancariaNumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A971TituloPropostaDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             decimal A498TituloJurosMora ,
                                             string A799NotaFiscalNumero ,
                                             string AV137Wpregistrartitulods_1_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             string AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                             string AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                             int A951ContaBancariaId ,
                                             bool A284TituloDeleted ,
                                             bool A314TituloArchived ,
                                             decimal A275TituloSaldo_F ,
                                             string A283TituloTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[32];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloTipo, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloArchived, T1.TituloDeleted, T1.ContaBancariaId, T1.TituloJurosMora, T1.TituloProrrogacao, T1.TituloDesconto, T7.ContaBancariaNumero, T1.TituloValor, T3.NotaFiscalNumero, T1.TituloPropostaTipo, T4.PropostaDescricao AS TituloPropostaDescricao, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN ContaBancaria T7 ON T7.ContaBancariaId = T1.ContaBancariaId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(Not (COALESCE( T6.TituloSaldo_F, 0) = 0))");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV152Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV154Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV156Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV157Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV157Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV158Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV158Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV159Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV159Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV160Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV163Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV163Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV164Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV164Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV165Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV166Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV166Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV167Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00EW7( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                             string AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                             short AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                             decimal AV140Wpregistrartitulods_4_titulovalor1 ,
                                             long AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                             bool AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                             string AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                             short AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                             decimal AV145Wpregistrartitulods_9_titulovalor2 ,
                                             long AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                             bool AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                             string AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                             short AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                             decimal AV150Wpregistrartitulods_14_titulovalor3 ,
                                             long AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                             string AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                             string AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                             string AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                             string AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                             int AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                             decimal AV157Wpregistrartitulods_21_tftitulovalor ,
                                             decimal AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                             decimal AV159Wpregistrartitulods_23_tftitulodesconto ,
                                             decimal AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                             DateTime AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                             DateTime AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                             decimal AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                             decimal AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                             string AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                             string AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                             decimal A262TituloValor ,
                                             long A952ContaBancariaNumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A971TituloPropostaDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             decimal A498TituloJurosMora ,
                                             string A799NotaFiscalNumero ,
                                             string AV137Wpregistrartitulods_1_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             string AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                             string AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                             int A951ContaBancariaId ,
                                             bool A284TituloDeleted ,
                                             bool A314TituloArchived ,
                                             decimal A275TituloSaldo_F ,
                                             string A283TituloTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[32];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloTipo, T4.PropostaDescricao AS TituloPropostaDescricao, T1.TituloArchived, T1.TituloDeleted, T1.ContaBancariaId, T1.TituloJurosMora, T1.TituloProrrogacao, T1.TituloDesconto, T7.ContaBancariaNumero, T1.TituloValor, T3.NotaFiscalNumero, T1.TituloPropostaTipo, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN ContaBancaria T7 ON T7.ContaBancariaId = T1.ContaBancariaId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(Not (COALESCE( T6.TituloSaldo_F, 0) = 0))");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV152Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV154Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV156Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV157Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV157Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV158Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV158Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV159Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV159Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV160Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV163Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV163Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV164Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV164Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV165Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV166Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV166Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV167Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.PropostaDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00EW10( IGxContext context ,
                                              string A648TituloPropostaTipo ,
                                              GxSimpleCollection<string> AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              string AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              short AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              decimal AV140Wpregistrartitulods_4_titulovalor1 ,
                                              long AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                              bool AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              string AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              short AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              decimal AV145Wpregistrartitulods_9_titulovalor2 ,
                                              long AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                              bool AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              string AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              short AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              decimal AV150Wpregistrartitulods_14_titulovalor3 ,
                                              long AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                              string AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              string AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              string AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              string AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              int AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                              decimal AV157Wpregistrartitulods_21_tftitulovalor ,
                                              decimal AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                              decimal AV159Wpregistrartitulods_23_tftitulodesconto ,
                                              decimal AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                              DateTime AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                              DateTime AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              decimal AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                              decimal AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              string AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              string AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              decimal A262TituloValor ,
                                              long A952ContaBancariaNumero ,
                                              string A972TituloCLienteRazaoSocial ,
                                              string A971TituloPropostaDescricao ,
                                              decimal A276TituloDesconto ,
                                              DateTime A264TituloProrrogacao ,
                                              decimal A498TituloJurosMora ,
                                              string A799NotaFiscalNumero ,
                                              string AV137Wpregistrartitulods_1_filterfulltext ,
                                              string A295TituloCompetencia_F ,
                                              string AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              string AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              int A951ContaBancariaId ,
                                              bool A284TituloDeleted ,
                                              bool A314TituloArchived ,
                                              decimal A275TituloSaldo_F ,
                                              string A283TituloTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[32];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloTipo, T1.TituloArchived, T1.TituloDeleted, T1.ContaBancariaId, T1.TituloJurosMora, T1.TituloProrrogacao, T1.TituloDesconto, T7.ContaBancariaNumero, T1.TituloValor, T3.NotaFiscalNumero, T1.TituloPropostaTipo, T4.PropostaDescricao AS TituloPropostaDescricao, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN ContaBancaria T7 ON T7.ContaBancariaId = T1.ContaBancariaId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(Not (COALESCE( T6.TituloSaldo_F, 0) = 0))");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV152Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV154Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV156Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV157Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV157Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV158Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV158Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV159Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV159Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV160Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV163Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV163Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV164Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV164Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV165Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV166Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV166Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV167Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00EW13( IGxContext context ,
                                              string A648TituloPropostaTipo ,
                                              GxSimpleCollection<string> AV156Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              string AV138Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              short AV139Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              decimal AV140Wpregistrartitulods_4_titulovalor1 ,
                                              long AV141Wpregistrartitulods_5_contabancarianumero1 ,
                                              bool AV142Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              string AV143Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              short AV144Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              decimal AV145Wpregistrartitulods_9_titulovalor2 ,
                                              long AV146Wpregistrartitulods_10_contabancarianumero2 ,
                                              bool AV147Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              string AV148Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              short AV149Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              decimal AV150Wpregistrartitulods_14_titulovalor3 ,
                                              long AV151Wpregistrartitulods_15_contabancarianumero3 ,
                                              string AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              string AV152Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              string AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              string AV154Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              int AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                              decimal AV157Wpregistrartitulods_21_tftitulovalor ,
                                              decimal AV158Wpregistrartitulods_22_tftitulovalor_to ,
                                              decimal AV159Wpregistrartitulods_23_tftitulodesconto ,
                                              decimal AV160Wpregistrartitulods_24_tftitulodesconto_to ,
                                              DateTime AV163Wpregistrartitulods_27_tftituloprorrogacao ,
                                              DateTime AV164Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              decimal AV165Wpregistrartitulods_29_tftitulojurosmora ,
                                              decimal AV166Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              string AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              string AV167Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              decimal A262TituloValor ,
                                              long A952ContaBancariaNumero ,
                                              string A972TituloCLienteRazaoSocial ,
                                              string A971TituloPropostaDescricao ,
                                              decimal A276TituloDesconto ,
                                              DateTime A264TituloProrrogacao ,
                                              decimal A498TituloJurosMora ,
                                              string A799NotaFiscalNumero ,
                                              string AV137Wpregistrartitulods_1_filterfulltext ,
                                              string A295TituloCompetencia_F ,
                                              string AV162Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              string AV161Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              int A951ContaBancariaId ,
                                              bool A284TituloDeleted ,
                                              bool A314TituloArchived ,
                                              decimal A275TituloSaldo_F ,
                                              string A283TituloTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[32];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloTipo, T3.NotaFiscalNumero, T1.TituloArchived, T1.TituloDeleted, T1.ContaBancariaId, T1.TituloJurosMora, T1.TituloProrrogacao, T1.TituloDesconto, T7.ContaBancariaNumero, T1.TituloValor, T1.TituloPropostaTipo, T4.PropostaDescricao AS TituloPropostaDescricao, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN ContaBancaria T7 ON T7.ContaBancariaId = T1.ContaBancariaId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(Not (COALESCE( T6.TituloSaldo_F, 0) = 0))");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV140Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV140Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV138Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV139Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV141Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV141Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV145Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV145Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV142Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV143Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV144Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV146Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV146Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV150Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV150Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV147Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV149Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV151Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV152Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV154Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( AV156Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV156Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV157Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV157Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV158Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV158Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV159Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV159Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV160Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV163Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV163Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV164Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV164Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV165Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV165Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV166Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV166Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV167Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( StringUtil.StrCmp(AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.NotaFiscalNumero";
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
                     return conditional_P00EW4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (bool)dynConstraints[44] , (bool)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] );
               case 1 :
                     return conditional_P00EW7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (bool)dynConstraints[44] , (bool)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] );
               case 2 :
                     return conditional_P00EW10(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (bool)dynConstraints[44] , (bool)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] );
               case 3 :
                     return conditional_P00EW13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (bool)dynConstraints[44] , (bool)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] );
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
          Object[] prmP00EW4;
          prmP00EW4 = new Object[] {
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV152Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV154Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV157Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV158Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV159Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV163Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV164Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV165Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV166Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV167Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00EW7;
          prmP00EW7 = new Object[] {
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV152Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV154Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV157Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV158Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV159Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV163Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV164Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV165Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV166Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV167Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00EW10;
          prmP00EW10 = new Object[] {
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV152Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV154Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV157Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV158Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV159Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV163Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV164Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV165Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV166Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV167Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00EW13;
          prmP00EW13 = new Object[] {
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV141Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV146Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV150Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV151Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV152Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV153Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV154Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV155Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV157Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV158Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV159Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV160Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV163Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV164Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV165Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV166Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV167Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV168Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EW4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EW7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EW10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EW13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW13,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((long[]) buf[25])[0] = rslt.getLong(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((long[]) buf[25])[0] = rslt.getLong(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((long[]) buf[25])[0] = rslt.getLong(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
       }
    }

 }

}
