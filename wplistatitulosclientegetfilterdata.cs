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
   public class wplistatitulosclientegetfilterdata : GXProcedure
   {
      public wplistatitulosclientegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistatitulosclientegetfilterdata( IGxContext context )
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
         this.AV77DDOName = aP0_DDOName;
         this.AV78SearchTxtParms = aP1_SearchTxtParms;
         this.AV79SearchTxtTo = aP2_SearchTxtTo;
         this.AV80OptionsJson = "" ;
         this.AV81OptionsDescJson = "" ;
         this.AV82OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV80OptionsJson;
         aP4_OptionsDescJson=this.AV81OptionsDescJson;
         aP5_OptionIndexesJson=this.AV82OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV82OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV77DDOName = aP0_DDOName;
         this.AV78SearchTxtParms = aP1_SearchTxtParms;
         this.AV79SearchTxtTo = aP2_SearchTxtTo;
         this.AV80OptionsJson = "" ;
         this.AV81OptionsDescJson = "" ;
         this.AV82OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV80OptionsJson;
         aP4_OptionsDescJson=this.AV81OptionsDescJson;
         aP5_OptionIndexesJson=this.AV82OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV67Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV69OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV70OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV64MaxItems = 10;
         AV63PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV78SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV78SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV61SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV78SearchTxtParms)) ? "" : StringUtil.Substring( AV78SearchTxtParms, 3, -1));
         AV62SkipItems = (short)(AV63PageIndex*AV64MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV77DDOName), "DDO_TITULOCOMPETENCIA_F") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOCOMPETENCIA_FOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV77DDOName), "DDO_TITULOSTATUS_F") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOSTATUS_FOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV80OptionsJson = AV67Options.ToJSonString(false);
         AV81OptionsDescJson = AV69OptionsDesc.ToJSonString(false);
         AV82OptionIndexesJson = AV70OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV72Session.Get("WpListaTitulosClienteGridState"), "") == 0 )
         {
            AV74GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpListaTitulosClienteGridState"), null, "", "");
         }
         else
         {
            AV74GridState.FromXml(AV72Session.Get("WpListaTitulosClienteGridState"), null, "", "");
         }
         AV99GXV1 = 1;
         while ( AV99GXV1 <= AV74GridState.gxTpr_Filtervalues.Count )
         {
            AV75GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV74GridState.gxTpr_Filtervalues.Item(AV99GXV1));
            if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV83FilterFullText = AV75GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOID") == 0 )
            {
               AV96TFTituloId = (int)(Math.Round(NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV97TFTituloId_To = (int)(Math.Round(NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV12TFTituloValor = NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Value, ".");
               AV13TFTituloValor_To = NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV14TFTituloDesconto = NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Value, ".");
               AV15TFTituloDesconto_To = NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV23TFTituloCompetencia_F = AV75GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV24TFTituloCompetencia_F_Sel = AV75GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV25TFTituloProrrogacao = context.localUtil.CToD( AV75GridStateFilterValue.gxTpr_Value, 4);
               AV26TFTituloProrrogacao_To = context.localUtil.CToD( AV75GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV39TFTituloTipo_SelsJson = AV75GridStateFilterValue.gxTpr_Value;
               AV40TFTituloTipo_Sels.FromJSonString(AV39TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOSALDO_F") == 0 )
            {
               AV45TFTituloSaldo_F = NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Value, ".");
               AV46TFTituloSaldo_F_To = NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F") == 0 )
            {
               AV47TFTituloStatus_F = AV75GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F_SEL") == 0 )
            {
               AV48TFTituloStatus_F_Sel = AV75GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV95ClienteId = (int)(Math.Round(NumberUtil.Val( AV75GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV75GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTERAZAOSOCIAL") == 0 )
            {
               AV98ClienteRazaoSocial = AV75GridStateFilterValue.gxTpr_Value;
            }
            AV99GXV1 = (int)(AV99GXV1+1);
         }
         if ( AV74GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV76GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV74GridState.gxTpr_Dynamicfilters.Item(1));
            AV84DynamicFiltersSelector1 = AV76GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV84DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV85DynamicFiltersOperator1 = AV76GridStateDynamicFilter.gxTpr_Operator;
               AV86TituloValor1 = NumberUtil.Val( AV76GridStateDynamicFilter.gxTpr_Value, ".");
            }
            if ( AV74GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV87DynamicFiltersEnabled2 = true;
               AV76GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV74GridState.gxTpr_Dynamicfilters.Item(2));
               AV88DynamicFiltersSelector2 = AV76GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV88DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV89DynamicFiltersOperator2 = AV76GridStateDynamicFilter.gxTpr_Operator;
                  AV90TituloValor2 = NumberUtil.Val( AV76GridStateDynamicFilter.gxTpr_Value, ".");
               }
               if ( AV74GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV91DynamicFiltersEnabled3 = true;
                  AV76GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV74GridState.gxTpr_Dynamicfilters.Item(3));
                  AV92DynamicFiltersSelector3 = AV76GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV92DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV93DynamicFiltersOperator3 = AV76GridStateDynamicFilter.gxTpr_Operator;
                     AV94TituloValor3 = NumberUtil.Val( AV76GridStateDynamicFilter.gxTpr_Value, ".");
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTITULOCOMPETENCIA_FOPTIONS' Routine */
         returnInSub = false;
         AV23TFTituloCompetencia_F = AV61SearchTxt;
         AV24TFTituloCompetencia_F_Sel = "";
         AV101Wplistatitulosclienteds_1_clienteid = AV95ClienteId;
         AV102Wplistatitulosclienteds_2_filterfulltext = AV83FilterFullText;
         AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV84DynamicFiltersSelector1;
         AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV85DynamicFiltersOperator1;
         AV105Wplistatitulosclienteds_5_titulovalor1 = AV86TituloValor1;
         AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV87DynamicFiltersEnabled2;
         AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV88DynamicFiltersSelector2;
         AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV89DynamicFiltersOperator2;
         AV109Wplistatitulosclienteds_9_titulovalor2 = AV90TituloValor2;
         AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV91DynamicFiltersEnabled3;
         AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV92DynamicFiltersSelector3;
         AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV93DynamicFiltersOperator3;
         AV113Wplistatitulosclienteds_13_titulovalor3 = AV94TituloValor3;
         AV114Wplistatitulosclienteds_14_tftituloid = AV96TFTituloId;
         AV115Wplistatitulosclienteds_15_tftituloid_to = AV97TFTituloId_To;
         AV116Wplistatitulosclienteds_16_tftitulovalor = AV12TFTituloValor;
         AV117Wplistatitulosclienteds_17_tftitulovalor_to = AV13TFTituloValor_To;
         AV118Wplistatitulosclienteds_18_tftitulodesconto = AV14TFTituloDesconto;
         AV119Wplistatitulosclienteds_19_tftitulodesconto_to = AV15TFTituloDesconto_To;
         AV120Wplistatitulosclienteds_20_tftitulocompetencia_f = AV23TFTituloCompetencia_F;
         AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV24TFTituloCompetencia_F_Sel;
         AV122Wplistatitulosclienteds_22_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV124Wplistatitulosclienteds_24_tftitulotipo_sels = AV40TFTituloTipo_Sels;
         AV125Wplistatitulosclienteds_25_tftitulosaldo_f = AV45TFTituloSaldo_F;
         AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV46TFTituloSaldo_F_To;
         AV127Wplistatitulosclienteds_27_tftitulostatus_f = AV47TFTituloStatus_F;
         AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV48TFTituloStatus_F_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV124Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                              AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                              AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                              AV105Wplistatitulosclienteds_5_titulovalor1 ,
                                              AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                              AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                              AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                              AV109Wplistatitulosclienteds_9_titulovalor2 ,
                                              AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                              AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                              AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                              AV113Wplistatitulosclienteds_13_titulovalor3 ,
                                              AV114Wplistatitulosclienteds_14_tftituloid ,
                                              AV115Wplistatitulosclienteds_15_tftituloid_to ,
                                              AV116Wplistatitulosclienteds_16_tftitulovalor ,
                                              AV117Wplistatitulosclienteds_17_tftitulovalor_to ,
                                              AV118Wplistatitulosclienteds_18_tftitulodesconto ,
                                              AV119Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                              AV122Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                              AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                              AV124Wplistatitulosclienteds_24_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A261TituloId ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV102Wplistatitulosclienteds_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                              AV120Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                              AV125Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                              AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                              AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                              AV127Wplistatitulosclienteds_27_tftitulostatus_f ,
                                              A284TituloDeleted ,
                                              A168ClienteId ,
                                              AV101Wplistatitulosclienteds_1_clienteid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV127Wplistatitulosclienteds_27_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV127Wplistatitulosclienteds_27_tftitulostatus_f), "%", "");
         /* Using cursor P008B4 */
         pr_default.execute(0, new Object[] {AV125Wplistatitulosclienteds_25_tftitulosaldo_f, AV125Wplistatitulosclienteds_25_tftitulosaldo_f, AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV127Wplistatitulosclienteds_27_tftitulostatus_f, lV127Wplistatitulosclienteds_27_tftitulostatus_f, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV101Wplistatitulosclienteds_1_clienteid, AV105Wplistatitulosclienteds_5_titulovalor1, AV105Wplistatitulosclienteds_5_titulovalor1, AV105Wplistatitulosclienteds_5_titulovalor1, AV109Wplistatitulosclienteds_9_titulovalor2, AV109Wplistatitulosclienteds_9_titulovalor2, AV109Wplistatitulosclienteds_9_titulovalor2, AV113Wplistatitulosclienteds_13_titulovalor3, AV113Wplistatitulosclienteds_13_titulovalor3, AV113Wplistatitulosclienteds_13_titulovalor3, AV114Wplistatitulosclienteds_14_tftituloid, AV115Wplistatitulosclienteds_15_tftituloid_to, AV116Wplistatitulosclienteds_16_tftitulovalor, AV117Wplistatitulosclienteds_17_tftitulovalor_to, AV118Wplistatitulosclienteds_18_tftitulodesconto, AV119Wplistatitulosclienteds_19_tftitulodesconto_to, AV122Wplistatitulosclienteds_22_tftituloprorrogacao, AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A890NotaFiscalParcelamentoID = P008B4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P008B4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P008B4_A794NotaFiscalId[0];
            n794NotaFiscalId = P008B4_n794NotaFiscalId[0];
            A284TituloDeleted = P008B4_A284TituloDeleted[0];
            n284TituloDeleted = P008B4_n284TituloDeleted[0];
            A264TituloProrrogacao = P008B4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P008B4_n264TituloProrrogacao[0];
            A276TituloDesconto = P008B4_A276TituloDesconto[0];
            n276TituloDesconto = P008B4_n276TituloDesconto[0];
            A261TituloId = P008B4_A261TituloId[0];
            n261TituloId = P008B4_n261TituloId[0];
            A282TituloStatus_F = P008B4_A282TituloStatus_F[0];
            A283TituloTipo = P008B4_A283TituloTipo[0];
            n283TituloTipo = P008B4_n283TituloTipo[0];
            A168ClienteId = P008B4_A168ClienteId[0];
            n168ClienteId = P008B4_n168ClienteId[0];
            A275TituloSaldo_F = P008B4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P008B4_n275TituloSaldo_F[0];
            A262TituloValor = P008B4_A262TituloValor[0];
            n262TituloValor = P008B4_n262TituloValor[0];
            A286TituloCompetenciaAno = P008B4_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P008B4_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P008B4_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P008B4_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P008B4_A794NotaFiscalId[0];
            n794NotaFiscalId = P008B4_n794NotaFiscalId[0];
            A168ClienteId = P008B4_A168ClienteId[0];
            n168ClienteId = P008B4_n168ClienteId[0];
            A275TituloSaldo_F = P008B4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P008B4_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wplistatitulosclienteds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A261TituloId), 9, 0) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV102Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV102Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wplistatitulosclienteds_20_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV120Wplistatitulosclienteds_20_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV66Option = (String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ? "<#Empty#>" : A295TituloCompetencia_F);
                        AV65InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV66Option, "<#Empty#>") != 0 ) && ( AV65InsertIndex <= AV67Options.Count ) && ( ( StringUtil.StrCmp(((string)AV67Options.Item(AV65InsertIndex)), AV66Option) < 0 ) || ( StringUtil.StrCmp(((string)AV67Options.Item(AV65InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV65InsertIndex = (int)(AV65InsertIndex+1);
                        }
                        if ( ( AV65InsertIndex <= AV67Options.Count ) && ( StringUtil.StrCmp(((string)AV67Options.Item(AV65InsertIndex)), AV66Option) == 0 ) )
                        {
                           AV71count = (long)(Math.Round(NumberUtil.Val( ((string)AV70OptionIndexes.Item(AV65InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV71count = (long)(AV71count+1);
                           AV70OptionIndexes.RemoveItem(AV65InsertIndex);
                           AV70OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV71count), "Z,ZZZ,ZZZ,ZZ9")), AV65InsertIndex);
                        }
                        else
                        {
                           AV67Options.Add(AV66Option, AV65InsertIndex);
                           AV70OptionIndexes.Add("1", AV65InsertIndex);
                        }
                        if ( AV67Options.Count == AV62SkipItems + 11 )
                        {
                           AV67Options.RemoveItem(AV67Options.Count);
                           AV70OptionIndexes.RemoveItem(AV70OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         while ( AV62SkipItems > 0 )
         {
            AV67Options.RemoveItem(1);
            AV70OptionIndexes.RemoveItem(1);
            AV62SkipItems = (short)(AV62SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADTITULOSTATUS_FOPTIONS' Routine */
         returnInSub = false;
         AV47TFTituloStatus_F = AV61SearchTxt;
         AV48TFTituloStatus_F_Sel = "";
         AV101Wplistatitulosclienteds_1_clienteid = AV95ClienteId;
         AV102Wplistatitulosclienteds_2_filterfulltext = AV83FilterFullText;
         AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV84DynamicFiltersSelector1;
         AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV85DynamicFiltersOperator1;
         AV105Wplistatitulosclienteds_5_titulovalor1 = AV86TituloValor1;
         AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV87DynamicFiltersEnabled2;
         AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV88DynamicFiltersSelector2;
         AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV89DynamicFiltersOperator2;
         AV109Wplistatitulosclienteds_9_titulovalor2 = AV90TituloValor2;
         AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV91DynamicFiltersEnabled3;
         AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV92DynamicFiltersSelector3;
         AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV93DynamicFiltersOperator3;
         AV113Wplistatitulosclienteds_13_titulovalor3 = AV94TituloValor3;
         AV114Wplistatitulosclienteds_14_tftituloid = AV96TFTituloId;
         AV115Wplistatitulosclienteds_15_tftituloid_to = AV97TFTituloId_To;
         AV116Wplistatitulosclienteds_16_tftitulovalor = AV12TFTituloValor;
         AV117Wplistatitulosclienteds_17_tftitulovalor_to = AV13TFTituloValor_To;
         AV118Wplistatitulosclienteds_18_tftitulodesconto = AV14TFTituloDesconto;
         AV119Wplistatitulosclienteds_19_tftitulodesconto_to = AV15TFTituloDesconto_To;
         AV120Wplistatitulosclienteds_20_tftitulocompetencia_f = AV23TFTituloCompetencia_F;
         AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV24TFTituloCompetencia_F_Sel;
         AV122Wplistatitulosclienteds_22_tftituloprorrogacao = AV25TFTituloProrrogacao;
         AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV26TFTituloProrrogacao_To;
         AV124Wplistatitulosclienteds_24_tftitulotipo_sels = AV40TFTituloTipo_Sels;
         AV125Wplistatitulosclienteds_25_tftitulosaldo_f = AV45TFTituloSaldo_F;
         AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV46TFTituloSaldo_F_To;
         AV127Wplistatitulosclienteds_27_tftitulostatus_f = AV47TFTituloStatus_F;
         AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV48TFTituloStatus_F_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV124Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                              AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                              AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                              AV105Wplistatitulosclienteds_5_titulovalor1 ,
                                              AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                              AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                              AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                              AV109Wplistatitulosclienteds_9_titulovalor2 ,
                                              AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                              AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                              AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                              AV113Wplistatitulosclienteds_13_titulovalor3 ,
                                              AV114Wplistatitulosclienteds_14_tftituloid ,
                                              AV115Wplistatitulosclienteds_15_tftituloid_to ,
                                              AV116Wplistatitulosclienteds_16_tftitulovalor ,
                                              AV117Wplistatitulosclienteds_17_tftitulovalor_to ,
                                              AV118Wplistatitulosclienteds_18_tftitulodesconto ,
                                              AV119Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                              AV122Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                              AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                              AV124Wplistatitulosclienteds_24_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A261TituloId ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV102Wplistatitulosclienteds_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                              AV120Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                              AV125Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                              AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                              AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                              AV127Wplistatitulosclienteds_27_tftitulostatus_f ,
                                              A284TituloDeleted ,
                                              A168ClienteId ,
                                              AV101Wplistatitulosclienteds_1_clienteid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV127Wplistatitulosclienteds_27_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV127Wplistatitulosclienteds_27_tftitulostatus_f), "%", "");
         /* Using cursor P008B7 */
         pr_default.execute(1, new Object[] {AV125Wplistatitulosclienteds_25_tftitulosaldo_f, AV125Wplistatitulosclienteds_25_tftitulosaldo_f, AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV127Wplistatitulosclienteds_27_tftitulostatus_f, lV127Wplistatitulosclienteds_27_tftitulostatus_f, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV101Wplistatitulosclienteds_1_clienteid, AV105Wplistatitulosclienteds_5_titulovalor1, AV105Wplistatitulosclienteds_5_titulovalor1, AV105Wplistatitulosclienteds_5_titulovalor1, AV109Wplistatitulosclienteds_9_titulovalor2, AV109Wplistatitulosclienteds_9_titulovalor2, AV109Wplistatitulosclienteds_9_titulovalor2, AV113Wplistatitulosclienteds_13_titulovalor3, AV113Wplistatitulosclienteds_13_titulovalor3, AV113Wplistatitulosclienteds_13_titulovalor3, AV114Wplistatitulosclienteds_14_tftituloid, AV115Wplistatitulosclienteds_15_tftituloid_to, AV116Wplistatitulosclienteds_16_tftitulovalor, AV117Wplistatitulosclienteds_17_tftitulovalor_to, AV118Wplistatitulosclienteds_18_tftitulodesconto, AV119Wplistatitulosclienteds_19_tftitulodesconto_to, AV122Wplistatitulosclienteds_22_tftituloprorrogacao, AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A890NotaFiscalParcelamentoID = P008B7_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P008B7_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P008B7_A794NotaFiscalId[0];
            n794NotaFiscalId = P008B7_n794NotaFiscalId[0];
            A284TituloDeleted = P008B7_A284TituloDeleted[0];
            n284TituloDeleted = P008B7_n284TituloDeleted[0];
            A264TituloProrrogacao = P008B7_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P008B7_n264TituloProrrogacao[0];
            A276TituloDesconto = P008B7_A276TituloDesconto[0];
            n276TituloDesconto = P008B7_n276TituloDesconto[0];
            A261TituloId = P008B7_A261TituloId[0];
            n261TituloId = P008B7_n261TituloId[0];
            A282TituloStatus_F = P008B7_A282TituloStatus_F[0];
            A283TituloTipo = P008B7_A283TituloTipo[0];
            n283TituloTipo = P008B7_n283TituloTipo[0];
            A168ClienteId = P008B7_A168ClienteId[0];
            n168ClienteId = P008B7_n168ClienteId[0];
            A275TituloSaldo_F = P008B7_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P008B7_n275TituloSaldo_F[0];
            A262TituloValor = P008B7_A262TituloValor[0];
            n262TituloValor = P008B7_n262TituloValor[0];
            A286TituloCompetenciaAno = P008B7_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P008B7_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P008B7_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P008B7_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P008B7_A794NotaFiscalId[0];
            n794NotaFiscalId = P008B7_n794NotaFiscalId[0];
            A168ClienteId = P008B7_A168ClienteId[0];
            n168ClienteId = P008B7_n168ClienteId[0];
            A275TituloSaldo_F = P008B7_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P008B7_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wplistatitulosclienteds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A261TituloId), 9, 0) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV102Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV102Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV102Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wplistatitulosclienteds_20_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV120Wplistatitulosclienteds_20_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV66Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282TituloStatus_F)) ? "<#Empty#>" : A282TituloStatus_F);
                        AV65InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV66Option, "<#Empty#>") != 0 ) && ( AV65InsertIndex <= AV67Options.Count ) && ( ( StringUtil.StrCmp(((string)AV67Options.Item(AV65InsertIndex)), AV66Option) < 0 ) || ( StringUtil.StrCmp(((string)AV67Options.Item(AV65InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV65InsertIndex = (int)(AV65InsertIndex+1);
                        }
                        if ( ( AV65InsertIndex <= AV67Options.Count ) && ( StringUtil.StrCmp(((string)AV67Options.Item(AV65InsertIndex)), AV66Option) == 0 ) )
                        {
                           AV71count = (long)(Math.Round(NumberUtil.Val( ((string)AV70OptionIndexes.Item(AV65InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV71count = (long)(AV71count+1);
                           AV70OptionIndexes.RemoveItem(AV65InsertIndex);
                           AV70OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV71count), "Z,ZZZ,ZZZ,ZZ9")), AV65InsertIndex);
                        }
                        else
                        {
                           AV67Options.Add(AV66Option, AV65InsertIndex);
                           AV70OptionIndexes.Add("1", AV65InsertIndex);
                        }
                        if ( AV67Options.Count == AV62SkipItems + 11 )
                        {
                           AV67Options.RemoveItem(AV67Options.Count);
                           AV70OptionIndexes.RemoveItem(AV70OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV62SkipItems > 0 )
         {
            AV67Options.RemoveItem(1);
            AV70OptionIndexes.RemoveItem(1);
            AV62SkipItems = (short)(AV62SkipItems-1);
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
         AV80OptionsJson = "";
         AV81OptionsDescJson = "";
         AV82OptionIndexesJson = "";
         AV67Options = new GxSimpleCollection<string>();
         AV69OptionsDesc = new GxSimpleCollection<string>();
         AV70OptionIndexes = new GxSimpleCollection<string>();
         AV61SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV72Session = context.GetSession();
         AV74GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV75GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV83FilterFullText = "";
         AV23TFTituloCompetencia_F = "";
         AV24TFTituloCompetencia_F_Sel = "";
         AV25TFTituloProrrogacao = DateTime.MinValue;
         AV26TFTituloProrrogacao_To = DateTime.MinValue;
         AV39TFTituloTipo_SelsJson = "";
         AV40TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV47TFTituloStatus_F = "";
         AV48TFTituloStatus_F_Sel = "";
         AV98ClienteRazaoSocial = "";
         AV76GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV84DynamicFiltersSelector1 = "";
         AV88DynamicFiltersSelector2 = "";
         AV92DynamicFiltersSelector3 = "";
         AV102Wplistatitulosclienteds_2_filterfulltext = "";
         AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 = "";
         AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 = "";
         AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 = "";
         AV120Wplistatitulosclienteds_20_tftitulocompetencia_f = "";
         AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = "";
         AV122Wplistatitulosclienteds_22_tftituloprorrogacao = DateTime.MinValue;
         AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to = DateTime.MinValue;
         AV124Wplistatitulosclienteds_24_tftitulotipo_sels = new GxSimpleCollection<string>();
         AV127Wplistatitulosclienteds_27_tftitulostatus_f = "";
         AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel = "";
         lV102Wplistatitulosclienteds_2_filterfulltext = "";
         lV127Wplistatitulosclienteds_27_tftitulostatus_f = "";
         A283TituloTipo = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A282TituloStatus_F = "";
         P008B4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P008B4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P008B4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P008B4_n794NotaFiscalId = new bool[] {false} ;
         P008B4_A284TituloDeleted = new bool[] {false} ;
         P008B4_n284TituloDeleted = new bool[] {false} ;
         P008B4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P008B4_n264TituloProrrogacao = new bool[] {false} ;
         P008B4_A276TituloDesconto = new decimal[1] ;
         P008B4_n276TituloDesconto = new bool[] {false} ;
         P008B4_A261TituloId = new int[1] ;
         P008B4_n261TituloId = new bool[] {false} ;
         P008B4_A282TituloStatus_F = new string[] {""} ;
         P008B4_A283TituloTipo = new string[] {""} ;
         P008B4_n283TituloTipo = new bool[] {false} ;
         P008B4_A168ClienteId = new int[1] ;
         P008B4_n168ClienteId = new bool[] {false} ;
         P008B4_A275TituloSaldo_F = new decimal[1] ;
         P008B4_n275TituloSaldo_F = new bool[] {false} ;
         P008B4_A262TituloValor = new decimal[1] ;
         P008B4_n262TituloValor = new bool[] {false} ;
         P008B4_A286TituloCompetenciaAno = new short[1] ;
         P008B4_n286TituloCompetenciaAno = new bool[] {false} ;
         P008B4_A287TituloCompetenciaMes = new short[1] ;
         P008B4_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         AV66Option = "";
         P008B7_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P008B7_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P008B7_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P008B7_n794NotaFiscalId = new bool[] {false} ;
         P008B7_A284TituloDeleted = new bool[] {false} ;
         P008B7_n284TituloDeleted = new bool[] {false} ;
         P008B7_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P008B7_n264TituloProrrogacao = new bool[] {false} ;
         P008B7_A276TituloDesconto = new decimal[1] ;
         P008B7_n276TituloDesconto = new bool[] {false} ;
         P008B7_A261TituloId = new int[1] ;
         P008B7_n261TituloId = new bool[] {false} ;
         P008B7_A282TituloStatus_F = new string[] {""} ;
         P008B7_A283TituloTipo = new string[] {""} ;
         P008B7_n283TituloTipo = new bool[] {false} ;
         P008B7_A168ClienteId = new int[1] ;
         P008B7_n168ClienteId = new bool[] {false} ;
         P008B7_A275TituloSaldo_F = new decimal[1] ;
         P008B7_n275TituloSaldo_F = new bool[] {false} ;
         P008B7_A262TituloValor = new decimal[1] ;
         P008B7_n262TituloValor = new bool[] {false} ;
         P008B7_A286TituloCompetenciaAno = new short[1] ;
         P008B7_n286TituloCompetenciaAno = new bool[] {false} ;
         P008B7_A287TituloCompetenciaMes = new short[1] ;
         P008B7_n287TituloCompetenciaMes = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistatitulosclientegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008B4_A890NotaFiscalParcelamentoID, P008B4_n890NotaFiscalParcelamentoID, P008B4_A794NotaFiscalId, P008B4_n794NotaFiscalId, P008B4_A284TituloDeleted, P008B4_n284TituloDeleted, P008B4_A264TituloProrrogacao, P008B4_n264TituloProrrogacao, P008B4_A276TituloDesconto, P008B4_n276TituloDesconto,
               P008B4_A261TituloId, P008B4_A282TituloStatus_F, P008B4_A283TituloTipo, P008B4_n283TituloTipo, P008B4_A168ClienteId, P008B4_n168ClienteId, P008B4_A275TituloSaldo_F, P008B4_n275TituloSaldo_F, P008B4_A262TituloValor, P008B4_n262TituloValor,
               P008B4_A286TituloCompetenciaAno, P008B4_n286TituloCompetenciaAno, P008B4_A287TituloCompetenciaMes, P008B4_n287TituloCompetenciaMes
               }
               , new Object[] {
               P008B7_A890NotaFiscalParcelamentoID, P008B7_n890NotaFiscalParcelamentoID, P008B7_A794NotaFiscalId, P008B7_n794NotaFiscalId, P008B7_A284TituloDeleted, P008B7_n284TituloDeleted, P008B7_A264TituloProrrogacao, P008B7_n264TituloProrrogacao, P008B7_A276TituloDesconto, P008B7_n276TituloDesconto,
               P008B7_A261TituloId, P008B7_A282TituloStatus_F, P008B7_A283TituloTipo, P008B7_n283TituloTipo, P008B7_A168ClienteId, P008B7_n168ClienteId, P008B7_A275TituloSaldo_F, P008B7_n275TituloSaldo_F, P008B7_A262TituloValor, P008B7_n262TituloValor,
               P008B7_A286TituloCompetenciaAno, P008B7_n286TituloCompetenciaAno, P008B7_A287TituloCompetenciaMes, P008B7_n287TituloCompetenciaMes
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV64MaxItems ;
      private short AV63PageIndex ;
      private short AV62SkipItems ;
      private short AV85DynamicFiltersOperator1 ;
      private short AV89DynamicFiltersOperator2 ;
      private short AV93DynamicFiltersOperator3 ;
      private short AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 ;
      private short AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 ;
      private short AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV99GXV1 ;
      private int AV96TFTituloId ;
      private int AV97TFTituloId_To ;
      private int AV95ClienteId ;
      private int AV101Wplistatitulosclienteds_1_clienteid ;
      private int AV114Wplistatitulosclienteds_14_tftituloid ;
      private int AV115Wplistatitulosclienteds_15_tftituloid_to ;
      private int AV124Wplistatitulosclienteds_24_tftitulotipo_sels_Count ;
      private int A261TituloId ;
      private int A168ClienteId ;
      private int AV65InsertIndex ;
      private long AV71count ;
      private decimal AV12TFTituloValor ;
      private decimal AV13TFTituloValor_To ;
      private decimal AV14TFTituloDesconto ;
      private decimal AV15TFTituloDesconto_To ;
      private decimal AV45TFTituloSaldo_F ;
      private decimal AV46TFTituloSaldo_F_To ;
      private decimal AV86TituloValor1 ;
      private decimal AV90TituloValor2 ;
      private decimal AV94TituloValor3 ;
      private decimal AV105Wplistatitulosclienteds_5_titulovalor1 ;
      private decimal AV109Wplistatitulosclienteds_9_titulovalor2 ;
      private decimal AV113Wplistatitulosclienteds_13_titulovalor3 ;
      private decimal AV116Wplistatitulosclienteds_16_tftitulovalor ;
      private decimal AV117Wplistatitulosclienteds_17_tftitulovalor_to ;
      private decimal AV118Wplistatitulosclienteds_18_tftitulodesconto ;
      private decimal AV119Wplistatitulosclienteds_19_tftitulodesconto_to ;
      private decimal AV125Wplistatitulosclienteds_25_tftitulosaldo_f ;
      private decimal AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A275TituloSaldo_F ;
      private DateTime AV25TFTituloProrrogacao ;
      private DateTime AV26TFTituloProrrogacao_To ;
      private DateTime AV122Wplistatitulosclienteds_22_tftituloprorrogacao ;
      private DateTime AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool AV87DynamicFiltersEnabled2 ;
      private bool AV91DynamicFiltersEnabled3 ;
      private bool AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 ;
      private bool AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 ;
      private bool A284TituloDeleted ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n284TituloDeleted ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n261TituloId ;
      private bool n283TituloTipo ;
      private bool n168ClienteId ;
      private bool n275TituloSaldo_F ;
      private bool n262TituloValor ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private string AV80OptionsJson ;
      private string AV81OptionsDescJson ;
      private string AV82OptionIndexesJson ;
      private string AV39TFTituloTipo_SelsJson ;
      private string AV77DDOName ;
      private string AV78SearchTxtParms ;
      private string AV79SearchTxtTo ;
      private string AV61SearchTxt ;
      private string AV83FilterFullText ;
      private string AV23TFTituloCompetencia_F ;
      private string AV24TFTituloCompetencia_F_Sel ;
      private string AV47TFTituloStatus_F ;
      private string AV48TFTituloStatus_F_Sel ;
      private string AV98ClienteRazaoSocial ;
      private string AV84DynamicFiltersSelector1 ;
      private string AV88DynamicFiltersSelector2 ;
      private string AV92DynamicFiltersSelector3 ;
      private string AV102Wplistatitulosclienteds_2_filterfulltext ;
      private string AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 ;
      private string AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 ;
      private string AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 ;
      private string AV120Wplistatitulosclienteds_20_tftitulocompetencia_f ;
      private string AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ;
      private string AV127Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel ;
      private string lV102Wplistatitulosclienteds_2_filterfulltext ;
      private string lV127Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string A283TituloTipo ;
      private string A295TituloCompetencia_F ;
      private string A282TituloStatus_F ;
      private string AV66Option ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV72Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV67Options ;
      private GxSimpleCollection<string> AV69OptionsDesc ;
      private GxSimpleCollection<string> AV70OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV74GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV75GridStateFilterValue ;
      private GxSimpleCollection<string> AV40TFTituloTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV76GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV124Wplistatitulosclienteds_24_tftitulotipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008B4_A890NotaFiscalParcelamentoID ;
      private bool[] P008B4_n890NotaFiscalParcelamentoID ;
      private Guid[] P008B4_A794NotaFiscalId ;
      private bool[] P008B4_n794NotaFiscalId ;
      private bool[] P008B4_A284TituloDeleted ;
      private bool[] P008B4_n284TituloDeleted ;
      private DateTime[] P008B4_A264TituloProrrogacao ;
      private bool[] P008B4_n264TituloProrrogacao ;
      private decimal[] P008B4_A276TituloDesconto ;
      private bool[] P008B4_n276TituloDesconto ;
      private int[] P008B4_A261TituloId ;
      private bool[] P008B4_n261TituloId ;
      private string[] P008B4_A282TituloStatus_F ;
      private string[] P008B4_A283TituloTipo ;
      private bool[] P008B4_n283TituloTipo ;
      private int[] P008B4_A168ClienteId ;
      private bool[] P008B4_n168ClienteId ;
      private decimal[] P008B4_A275TituloSaldo_F ;
      private bool[] P008B4_n275TituloSaldo_F ;
      private decimal[] P008B4_A262TituloValor ;
      private bool[] P008B4_n262TituloValor ;
      private short[] P008B4_A286TituloCompetenciaAno ;
      private bool[] P008B4_n286TituloCompetenciaAno ;
      private short[] P008B4_A287TituloCompetenciaMes ;
      private bool[] P008B4_n287TituloCompetenciaMes ;
      private Guid[] P008B7_A890NotaFiscalParcelamentoID ;
      private bool[] P008B7_n890NotaFiscalParcelamentoID ;
      private Guid[] P008B7_A794NotaFiscalId ;
      private bool[] P008B7_n794NotaFiscalId ;
      private bool[] P008B7_A284TituloDeleted ;
      private bool[] P008B7_n284TituloDeleted ;
      private DateTime[] P008B7_A264TituloProrrogacao ;
      private bool[] P008B7_n264TituloProrrogacao ;
      private decimal[] P008B7_A276TituloDesconto ;
      private bool[] P008B7_n276TituloDesconto ;
      private int[] P008B7_A261TituloId ;
      private bool[] P008B7_n261TituloId ;
      private string[] P008B7_A282TituloStatus_F ;
      private string[] P008B7_A283TituloTipo ;
      private bool[] P008B7_n283TituloTipo ;
      private int[] P008B7_A168ClienteId ;
      private bool[] P008B7_n168ClienteId ;
      private decimal[] P008B7_A275TituloSaldo_F ;
      private bool[] P008B7_n275TituloSaldo_F ;
      private decimal[] P008B7_A262TituloValor ;
      private bool[] P008B7_n262TituloValor ;
      private short[] P008B7_A286TituloCompetenciaAno ;
      private bool[] P008B7_n286TituloCompetenciaAno ;
      private short[] P008B7_A287TituloCompetenciaMes ;
      private bool[] P008B7_n287TituloCompetenciaMes ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wplistatitulosclientegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008B4( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV124Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                             string AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                             short AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                             decimal AV105Wplistatitulosclienteds_5_titulovalor1 ,
                                             bool AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                             string AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                             short AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                             decimal AV109Wplistatitulosclienteds_9_titulovalor2 ,
                                             bool AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                             string AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                             short AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                             decimal AV113Wplistatitulosclienteds_13_titulovalor3 ,
                                             int AV114Wplistatitulosclienteds_14_tftituloid ,
                                             int AV115Wplistatitulosclienteds_15_tftituloid_to ,
                                             decimal AV116Wplistatitulosclienteds_16_tftitulovalor ,
                                             decimal AV117Wplistatitulosclienteds_17_tftitulovalor_to ,
                                             decimal AV118Wplistatitulosclienteds_18_tftitulodesconto ,
                                             decimal AV119Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                             DateTime AV122Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                             DateTime AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                             int AV124Wplistatitulosclienteds_24_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             int A261TituloId ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV102Wplistatitulosclienteds_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                             string AV120Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                             decimal AV125Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                             decimal AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                             string AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                             string AV127Wplistatitulosclienteds_27_tftitulostatus_f ,
                                             bool A284TituloDeleted ,
                                             int A168ClienteId ,
                                             int AV101Wplistatitulosclienteds_1_clienteid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[29];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloDeleted, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloId, CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T3.ClienteId, COALESCE( T4.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) INNER JOIN (SELECT ( COALESCE( T5.TituloValor, 0) - COALESCE( T5.TituloDesconto, 0)) - COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T5.TituloId FROM (Titulo T5 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T5.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = T5.TituloId) ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV125Wplistatitulosclienteds_25_tftitulosaldo_f = 0) or ( COALESCE( T4.TituloSaldo_F, 0) >= :AV125Wplistatitulosclienteds_25_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to = 0) or ( COALESCE( T4.TituloSaldo_F, 0) <= :AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV127Wplistatitulosclienteds_27_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV127Wplistatitulosclienteds_27_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and Not :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(T3.ClienteId = :AV101Wplistatitulosclienteds_1_clienteid)");
         if ( ( StringUtil.StrCmp(AV103Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV105Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV105Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV103Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV105Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV105Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV103Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV105Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV105Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV109Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV109Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV109Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV109Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV109Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV109Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV113Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV113Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV113Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV113Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV113Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV113Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (0==AV114Wplistatitulosclienteds_14_tftituloid) )
         {
            AddWhere(sWhereString, "(T1.TituloId >= :AV114Wplistatitulosclienteds_14_tftituloid)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (0==AV115Wplistatitulosclienteds_15_tftituloid_to) )
         {
            AddWhere(sWhereString, "(T1.TituloId <= :AV115Wplistatitulosclienteds_15_tftituloid_to)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wplistatitulosclienteds_16_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV116Wplistatitulosclienteds_16_tftitulovalor)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wplistatitulosclienteds_17_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV117Wplistatitulosclienteds_17_tftitulovalor_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_18_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV118Wplistatitulosclienteds_18_tftitulodesconto)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wplistatitulosclienteds_19_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV119Wplistatitulosclienteds_19_tftitulodesconto_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Wplistatitulosclienteds_22_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV122Wplistatitulosclienteds_22_tftituloprorrogacao)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV124Wplistatitulosclienteds_24_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV124Wplistatitulosclienteds_24_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008B7( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV124Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                             string AV103Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                             short AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                             decimal AV105Wplistatitulosclienteds_5_titulovalor1 ,
                                             bool AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                             string AV107Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                             short AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                             decimal AV109Wplistatitulosclienteds_9_titulovalor2 ,
                                             bool AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                             string AV111Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                             short AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                             decimal AV113Wplistatitulosclienteds_13_titulovalor3 ,
                                             int AV114Wplistatitulosclienteds_14_tftituloid ,
                                             int AV115Wplistatitulosclienteds_15_tftituloid_to ,
                                             decimal AV116Wplistatitulosclienteds_16_tftitulovalor ,
                                             decimal AV117Wplistatitulosclienteds_17_tftitulovalor_to ,
                                             decimal AV118Wplistatitulosclienteds_18_tftitulodesconto ,
                                             decimal AV119Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                             DateTime AV122Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                             DateTime AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                             int AV124Wplistatitulosclienteds_24_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             int A261TituloId ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV102Wplistatitulosclienteds_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV121Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                             string AV120Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                             decimal AV125Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                             decimal AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                             string AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                             string AV127Wplistatitulosclienteds_27_tftitulostatus_f ,
                                             bool A284TituloDeleted ,
                                             int A168ClienteId ,
                                             int AV101Wplistatitulosclienteds_1_clienteid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[29];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloDeleted, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloId, CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T3.ClienteId, COALESCE( T4.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) INNER JOIN (SELECT ( COALESCE( T5.TituloValor, 0) - COALESCE( T5.TituloDesconto, 0)) - COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T5.TituloId FROM (Titulo T5 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T5.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = T5.TituloId) ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV125Wplistatitulosclienteds_25_tftitulosaldo_f = 0) or ( COALESCE( T4.TituloSaldo_F, 0) >= :AV125Wplistatitulosclienteds_25_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to = 0) or ( COALESCE( T4.TituloSaldo_F, 0) <= :AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV127Wplistatitulosclienteds_27_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV127Wplistatitulosclienteds_27_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and Not :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(T3.ClienteId = :AV101Wplistatitulosclienteds_1_clienteid)");
         if ( ( StringUtil.StrCmp(AV103Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV105Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV105Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV103Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV105Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV105Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV103Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV104Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV105Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV105Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV109Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV109Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV109Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV109Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV106Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV108Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV109Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV109Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV113Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV113Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV113Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV113Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV110Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV112Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV113Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV113Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (0==AV114Wplistatitulosclienteds_14_tftituloid) )
         {
            AddWhere(sWhereString, "(T1.TituloId >= :AV114Wplistatitulosclienteds_14_tftituloid)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (0==AV115Wplistatitulosclienteds_15_tftituloid_to) )
         {
            AddWhere(sWhereString, "(T1.TituloId <= :AV115Wplistatitulosclienteds_15_tftituloid_to)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV116Wplistatitulosclienteds_16_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV116Wplistatitulosclienteds_16_tftitulovalor)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Wplistatitulosclienteds_17_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV117Wplistatitulosclienteds_17_tftitulovalor_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_18_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV118Wplistatitulosclienteds_18_tftitulodesconto)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV119Wplistatitulosclienteds_19_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV119Wplistatitulosclienteds_19_tftitulodesconto_to)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Wplistatitulosclienteds_22_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV122Wplistatitulosclienteds_22_tftituloprorrogacao)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV124Wplistatitulosclienteds_24_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV124Wplistatitulosclienteds_24_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008B4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (bool)dynConstraints[36] , (int)dynConstraints[37] , (int)dynConstraints[38] );
               case 1 :
                     return conditional_P008B7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (bool)dynConstraints[36] , (int)dynConstraints[37] , (int)dynConstraints[38] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008B4;
          prmP008B4 = new Object[] {
          new ParDef("AV125Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV125Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV127Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV127Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV101Wplistatitulosclienteds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("AV105Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV105Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV105Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV109Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV109Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV109Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV113Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV113Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV113Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_14_tftituloid",GXType.Int32,9,0) ,
          new ParDef("AV115Wplistatitulosclienteds_15_tftituloid_to",GXType.Int32,9,0) ,
          new ParDef("AV116Wplistatitulosclienteds_16_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV117Wplistatitulosclienteds_17_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_18_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV119Wplistatitulosclienteds_19_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV122Wplistatitulosclienteds_22_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          Object[] prmP008B7;
          prmP008B7 = new Object[] {
          new ParDef("AV125Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV125Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV126Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV127Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV127Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV128Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV101Wplistatitulosclienteds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("AV105Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV105Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV105Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV109Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV109Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV109Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV113Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV113Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV113Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_14_tftituloid",GXType.Int32,9,0) ,
          new ParDef("AV115Wplistatitulosclienteds_15_tftituloid_to",GXType.Int32,9,0) ,
          new ParDef("AV116Wplistatitulosclienteds_16_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV117Wplistatitulosclienteds_17_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_18_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV119Wplistatitulosclienteds_19_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV122Wplistatitulosclienteds_22_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV123Wplistatitulosclienteds_23_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008B7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B7,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((short[]) buf[22])[0] = rslt.getShort(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((short[]) buf[22])[0] = rslt.getShort(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
