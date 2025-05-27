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
   public class titulomovimentowwgetfilterdata : GXProcedure
   {
      public titulomovimentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulomovimentowwgetfilterdata( IGxContext context )
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
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25MaxItems = 10;
         AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV39SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? "" : StringUtil.Substring( AV39SearchTxtParms, 3, -1));
         AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_TIPOPAGAMENTONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPOPAGAMENTONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV41OptionsJson = AV28Options.ToJSonString(false);
         AV42OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("TituloMovimentoWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TituloMovimentoWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("TituloMovimentoWWGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTOVALOR") == 0 )
            {
               AV14TFTituloMovimentoValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV15TFTituloMovimentoValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTOTIPO_SEL") == 0 )
            {
               AV16TFTituloMovimentoTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV17TFTituloMovimentoTipo_Sels.FromJSonString(AV16TFTituloMovimentoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTODATACREDITO") == 0 )
            {
               AV18TFTituloMovimentoDataCredito = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV19TFTituloMovimentoDataCredito_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOMOVIMENTOCREATEDAT") == 0 )
            {
               AV20TFTituloMovimentoCreatedAt = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV21TFTituloMovimentoCreatedAt_To = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME") == 0 )
            {
               AV12TFTipoPagamentoNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME_SEL") == 0 )
            {
               AV13TFTipoPagamentoNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&TITULOID") == 0 )
            {
               AV56TituloId = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV45DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOMOVIMENTOVALOR") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV47TituloMovimentoValor1 = NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, ".");
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV57TipoPagamentoNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV48DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV49DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOMOVIMENTOVALOR") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV51TituloMovimentoValor2 = NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, ".");
               }
               else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV58TipoPagamentoNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV52DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV53DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOMOVIMENTOVALOR") == 0 )
                  {
                     AV54DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV55TituloMovimentoValor3 = NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, ".");
                  }
                  else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
                  {
                     AV54DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV59TipoPagamentoNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPOPAGAMENTONOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipoPagamentoNome = AV22SearchTxt;
         AV13TFTipoPagamentoNome_Sel = "";
         AV62Titulomovimentowwds_1_tituloid = AV56TituloId;
         AV63Titulomovimentowwds_2_filterfulltext = AV44FilterFullText;
         AV64Titulomovimentowwds_3_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV65Titulomovimentowwds_4_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV66Titulomovimentowwds_5_titulomovimentovalor1 = AV47TituloMovimentoValor1;
         AV67Titulomovimentowwds_6_tipopagamentonome1 = AV57TipoPagamentoNome1;
         AV68Titulomovimentowwds_7_dynamicfiltersenabled2 = AV48DynamicFiltersEnabled2;
         AV69Titulomovimentowwds_8_dynamicfiltersselector2 = AV49DynamicFiltersSelector2;
         AV70Titulomovimentowwds_9_dynamicfiltersoperator2 = AV50DynamicFiltersOperator2;
         AV71Titulomovimentowwds_10_titulomovimentovalor2 = AV51TituloMovimentoValor2;
         AV72Titulomovimentowwds_11_tipopagamentonome2 = AV58TipoPagamentoNome2;
         AV73Titulomovimentowwds_12_dynamicfiltersenabled3 = AV52DynamicFiltersEnabled3;
         AV74Titulomovimentowwds_13_dynamicfiltersselector3 = AV53DynamicFiltersSelector3;
         AV75Titulomovimentowwds_14_dynamicfiltersoperator3 = AV54DynamicFiltersOperator3;
         AV76Titulomovimentowwds_15_titulomovimentovalor3 = AV55TituloMovimentoValor3;
         AV77Titulomovimentowwds_16_tipopagamentonome3 = AV59TipoPagamentoNome3;
         AV78Titulomovimentowwds_17_tftitulomovimentovalor = AV14TFTituloMovimentoValor;
         AV79Titulomovimentowwds_18_tftitulomovimentovalor_to = AV15TFTituloMovimentoValor_To;
         AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels = AV17TFTituloMovimentoTipo_Sels;
         AV81Titulomovimentowwds_20_tftitulomovimentodatacredito = AV18TFTituloMovimentoDataCredito;
         AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to = AV19TFTituloMovimentoDataCredito_To;
         AV83Titulomovimentowwds_22_tftitulomovimentocreatedat = AV20TFTituloMovimentoCreatedAt;
         AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to = AV21TFTituloMovimentoCreatedAt_To;
         AV85Titulomovimentowwds_24_tftipopagamentonome = AV12TFTipoPagamentoNome;
         AV86Titulomovimentowwds_25_tftipopagamentonome_sel = AV13TFTipoPagamentoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A272TituloMovimentoTipo ,
                                              AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels ,
                                              AV63Titulomovimentowwds_2_filterfulltext ,
                                              AV64Titulomovimentowwds_3_dynamicfiltersselector1 ,
                                              AV65Titulomovimentowwds_4_dynamicfiltersoperator1 ,
                                              AV66Titulomovimentowwds_5_titulomovimentovalor1 ,
                                              AV67Titulomovimentowwds_6_tipopagamentonome1 ,
                                              AV68Titulomovimentowwds_7_dynamicfiltersenabled2 ,
                                              AV69Titulomovimentowwds_8_dynamicfiltersselector2 ,
                                              AV70Titulomovimentowwds_9_dynamicfiltersoperator2 ,
                                              AV71Titulomovimentowwds_10_titulomovimentovalor2 ,
                                              AV72Titulomovimentowwds_11_tipopagamentonome2 ,
                                              AV73Titulomovimentowwds_12_dynamicfiltersenabled3 ,
                                              AV74Titulomovimentowwds_13_dynamicfiltersselector3 ,
                                              AV75Titulomovimentowwds_14_dynamicfiltersoperator3 ,
                                              AV76Titulomovimentowwds_15_titulomovimentovalor3 ,
                                              AV77Titulomovimentowwds_16_tipopagamentonome3 ,
                                              AV78Titulomovimentowwds_17_tftitulomovimentovalor ,
                                              AV79Titulomovimentowwds_18_tftitulomovimentovalor_to ,
                                              AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels.Count ,
                                              AV81Titulomovimentowwds_20_tftitulomovimentodatacredito ,
                                              AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to ,
                                              AV83Titulomovimentowwds_22_tftitulomovimentocreatedat ,
                                              AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to ,
                                              AV86Titulomovimentowwds_25_tftipopagamentonome_sel ,
                                              AV85Titulomovimentowwds_24_tftipopagamentonome ,
                                              A271TituloMovimentoValor ,
                                              A289TipoPagamentoNome ,
                                              A279TituloMovimentoDataCredito ,
                                              A280TituloMovimentoCreatedAt ,
                                              AV62Titulomovimentowwds_1_tituloid ,
                                              A261TituloId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext), "%", "");
         lV63Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext), "%", "");
         lV63Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext), "%", "");
         lV63Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext), "%", "");
         lV63Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext), "%", "");
         lV63Titulomovimentowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext), "%", "");
         lV67Titulomovimentowwds_6_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV67Titulomovimentowwds_6_tipopagamentonome1), "%", "");
         lV67Titulomovimentowwds_6_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV67Titulomovimentowwds_6_tipopagamentonome1), "%", "");
         lV72Titulomovimentowwds_11_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV72Titulomovimentowwds_11_tipopagamentonome2), "%", "");
         lV72Titulomovimentowwds_11_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV72Titulomovimentowwds_11_tipopagamentonome2), "%", "");
         lV77Titulomovimentowwds_16_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV77Titulomovimentowwds_16_tipopagamentonome3), "%", "");
         lV77Titulomovimentowwds_16_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV77Titulomovimentowwds_16_tipopagamentonome3), "%", "");
         lV85Titulomovimentowwds_24_tftipopagamentonome = StringUtil.Concat( StringUtil.RTrim( AV85Titulomovimentowwds_24_tftipopagamentonome), "%", "");
         /* Using cursor P007K2 */
         pr_default.execute(0, new Object[] {AV62Titulomovimentowwds_1_tituloid, lV63Titulomovimentowwds_2_filterfulltext, lV63Titulomovimentowwds_2_filterfulltext, lV63Titulomovimentowwds_2_filterfulltext, lV63Titulomovimentowwds_2_filterfulltext, lV63Titulomovimentowwds_2_filterfulltext, lV63Titulomovimentowwds_2_filterfulltext, AV66Titulomovimentowwds_5_titulomovimentovalor1, AV66Titulomovimentowwds_5_titulomovimentovalor1, AV66Titulomovimentowwds_5_titulomovimentovalor1, lV67Titulomovimentowwds_6_tipopagamentonome1, lV67Titulomovimentowwds_6_tipopagamentonome1, AV71Titulomovimentowwds_10_titulomovimentovalor2, AV71Titulomovimentowwds_10_titulomovimentovalor2, AV71Titulomovimentowwds_10_titulomovimentovalor2, lV72Titulomovimentowwds_11_tipopagamentonome2, lV72Titulomovimentowwds_11_tipopagamentonome2, AV76Titulomovimentowwds_15_titulomovimentovalor3, AV76Titulomovimentowwds_15_titulomovimentovalor3, AV76Titulomovimentowwds_15_titulomovimentovalor3, lV77Titulomovimentowwds_16_tipopagamentonome3, lV77Titulomovimentowwds_16_tipopagamentonome3, AV78Titulomovimentowwds_17_tftitulomovimentovalor, AV79Titulomovimentowwds_18_tftitulomovimentovalor_to, AV81Titulomovimentowwds_20_tftitulomovimentodatacredito, AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to, AV83Titulomovimentowwds_22_tftitulomovimentocreatedat, AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to, lV85Titulomovimentowwds_24_tftipopagamentonome, AV86Titulomovimentowwds_25_tftipopagamentonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7K2 = false;
            A261TituloId = P007K2_A261TituloId[0];
            n261TituloId = P007K2_n261TituloId[0];
            A288TipoPagamentoId = P007K2_A288TipoPagamentoId[0];
            n288TipoPagamentoId = P007K2_n288TipoPagamentoId[0];
            A280TituloMovimentoCreatedAt = P007K2_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = P007K2_n280TituloMovimentoCreatedAt[0];
            A279TituloMovimentoDataCredito = P007K2_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = P007K2_n279TituloMovimentoDataCredito[0];
            A271TituloMovimentoValor = P007K2_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = P007K2_n271TituloMovimentoValor[0];
            A289TipoPagamentoNome = P007K2_A289TipoPagamentoNome[0];
            A272TituloMovimentoTipo = P007K2_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = P007K2_n272TituloMovimentoTipo[0];
            A270TituloMovimentoId = P007K2_A270TituloMovimentoId[0];
            A289TipoPagamentoNome = P007K2_A289TipoPagamentoNome[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P007K2_A261TituloId[0] == A261TituloId ) && ( P007K2_A288TipoPagamentoId[0] == A288TipoPagamentoId ) )
            {
               BRK7K2 = false;
               A270TituloMovimentoId = P007K2_A270TituloMovimentoId[0];
               AV32count = (long)(AV32count+1);
               BRK7K2 = true;
               pr_default.readNext(0);
            }
            AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A289TipoPagamentoNome)) ? "<#Empty#>" : A289TipoPagamentoNome);
            AV26InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV26InsertIndex = (int)(AV26InsertIndex+1);
            }
            AV28Options.Add(AV27Option, AV26InsertIndex);
            AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
            if ( AV28Options.Count == AV23SkipItems + 11 )
            {
               AV28Options.RemoveItem(AV28Options.Count);
               AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
            }
            if ( ! BRK7K2 )
            {
               BRK7K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
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
         AV41OptionsJson = "";
         AV42OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44FilterFullText = "";
         AV16TFTituloMovimentoTipo_SelsJson = "";
         AV17TFTituloMovimentoTipo_Sels = new GxSimpleCollection<string>();
         AV18TFTituloMovimentoDataCredito = DateTime.MinValue;
         AV19TFTituloMovimentoDataCredito_To = DateTime.MinValue;
         AV20TFTituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         AV21TFTituloMovimentoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV12TFTipoPagamentoNome = "";
         AV13TFTipoPagamentoNome_Sel = "";
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV57TipoPagamentoNome1 = "";
         AV49DynamicFiltersSelector2 = "";
         AV58TipoPagamentoNome2 = "";
         AV53DynamicFiltersSelector3 = "";
         AV59TipoPagamentoNome3 = "";
         AV63Titulomovimentowwds_2_filterfulltext = "";
         AV64Titulomovimentowwds_3_dynamicfiltersselector1 = "";
         AV67Titulomovimentowwds_6_tipopagamentonome1 = "";
         AV69Titulomovimentowwds_8_dynamicfiltersselector2 = "";
         AV72Titulomovimentowwds_11_tipopagamentonome2 = "";
         AV74Titulomovimentowwds_13_dynamicfiltersselector3 = "";
         AV77Titulomovimentowwds_16_tipopagamentonome3 = "";
         AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels = new GxSimpleCollection<string>();
         AV81Titulomovimentowwds_20_tftitulomovimentodatacredito = DateTime.MinValue;
         AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to = DateTime.MinValue;
         AV83Titulomovimentowwds_22_tftitulomovimentocreatedat = (DateTime)(DateTime.MinValue);
         AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to = (DateTime)(DateTime.MinValue);
         AV85Titulomovimentowwds_24_tftipopagamentonome = "";
         AV86Titulomovimentowwds_25_tftipopagamentonome_sel = "";
         lV63Titulomovimentowwds_2_filterfulltext = "";
         lV67Titulomovimentowwds_6_tipopagamentonome1 = "";
         lV72Titulomovimentowwds_11_tipopagamentonome2 = "";
         lV77Titulomovimentowwds_16_tipopagamentonome3 = "";
         lV85Titulomovimentowwds_24_tftipopagamentonome = "";
         A272TituloMovimentoTipo = "";
         A289TipoPagamentoNome = "";
         A279TituloMovimentoDataCredito = DateTime.MinValue;
         A280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         P007K2_A261TituloId = new int[1] ;
         P007K2_n261TituloId = new bool[] {false} ;
         P007K2_A288TipoPagamentoId = new int[1] ;
         P007K2_n288TipoPagamentoId = new bool[] {false} ;
         P007K2_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P007K2_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         P007K2_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         P007K2_n279TituloMovimentoDataCredito = new bool[] {false} ;
         P007K2_A271TituloMovimentoValor = new decimal[1] ;
         P007K2_n271TituloMovimentoValor = new bool[] {false} ;
         P007K2_A289TipoPagamentoNome = new string[] {""} ;
         P007K2_A272TituloMovimentoTipo = new string[] {""} ;
         P007K2_n272TituloMovimentoTipo = new bool[] {false} ;
         P007K2_A270TituloMovimentoId = new int[1] ;
         AV27Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulomovimentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007K2_A261TituloId, P007K2_n261TituloId, P007K2_A288TipoPagamentoId, P007K2_n288TipoPagamentoId, P007K2_A280TituloMovimentoCreatedAt, P007K2_n280TituloMovimentoCreatedAt, P007K2_A279TituloMovimentoDataCredito, P007K2_n279TituloMovimentoDataCredito, P007K2_A271TituloMovimentoValor, P007K2_n271TituloMovimentoValor,
               P007K2_A289TipoPagamentoNome, P007K2_A272TituloMovimentoTipo, P007K2_n272TituloMovimentoTipo, P007K2_A270TituloMovimentoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV46DynamicFiltersOperator1 ;
      private short AV50DynamicFiltersOperator2 ;
      private short AV54DynamicFiltersOperator3 ;
      private short AV65Titulomovimentowwds_4_dynamicfiltersoperator1 ;
      private short AV70Titulomovimentowwds_9_dynamicfiltersoperator2 ;
      private short AV75Titulomovimentowwds_14_dynamicfiltersoperator3 ;
      private int AV60GXV1 ;
      private int AV56TituloId ;
      private int AV62Titulomovimentowwds_1_tituloid ;
      private int AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count ;
      private int A261TituloId ;
      private int A288TipoPagamentoId ;
      private int A270TituloMovimentoId ;
      private int AV26InsertIndex ;
      private long AV32count ;
      private decimal AV14TFTituloMovimentoValor ;
      private decimal AV15TFTituloMovimentoValor_To ;
      private decimal AV47TituloMovimentoValor1 ;
      private decimal AV51TituloMovimentoValor2 ;
      private decimal AV55TituloMovimentoValor3 ;
      private decimal AV66Titulomovimentowwds_5_titulomovimentovalor1 ;
      private decimal AV71Titulomovimentowwds_10_titulomovimentovalor2 ;
      private decimal AV76Titulomovimentowwds_15_titulomovimentovalor3 ;
      private decimal AV78Titulomovimentowwds_17_tftitulomovimentovalor ;
      private decimal AV79Titulomovimentowwds_18_tftitulomovimentovalor_to ;
      private decimal A271TituloMovimentoValor ;
      private DateTime AV20TFTituloMovimentoCreatedAt ;
      private DateTime AV21TFTituloMovimentoCreatedAt_To ;
      private DateTime AV83Titulomovimentowwds_22_tftitulomovimentocreatedat ;
      private DateTime AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to ;
      private DateTime A280TituloMovimentoCreatedAt ;
      private DateTime AV18TFTituloMovimentoDataCredito ;
      private DateTime AV19TFTituloMovimentoDataCredito_To ;
      private DateTime AV81Titulomovimentowwds_20_tftitulomovimentodatacredito ;
      private DateTime AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to ;
      private DateTime A279TituloMovimentoDataCredito ;
      private bool returnInSub ;
      private bool AV48DynamicFiltersEnabled2 ;
      private bool AV52DynamicFiltersEnabled3 ;
      private bool AV68Titulomovimentowwds_7_dynamicfiltersenabled2 ;
      private bool AV73Titulomovimentowwds_12_dynamicfiltersenabled3 ;
      private bool BRK7K2 ;
      private bool n261TituloId ;
      private bool n288TipoPagamentoId ;
      private bool n280TituloMovimentoCreatedAt ;
      private bool n279TituloMovimentoDataCredito ;
      private bool n271TituloMovimentoValor ;
      private bool n272TituloMovimentoTipo ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV16TFTituloMovimentoTipo_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV12TFTipoPagamentoNome ;
      private string AV13TFTipoPagamentoNome_Sel ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV57TipoPagamentoNome1 ;
      private string AV49DynamicFiltersSelector2 ;
      private string AV58TipoPagamentoNome2 ;
      private string AV53DynamicFiltersSelector3 ;
      private string AV59TipoPagamentoNome3 ;
      private string AV63Titulomovimentowwds_2_filterfulltext ;
      private string AV64Titulomovimentowwds_3_dynamicfiltersselector1 ;
      private string AV67Titulomovimentowwds_6_tipopagamentonome1 ;
      private string AV69Titulomovimentowwds_8_dynamicfiltersselector2 ;
      private string AV72Titulomovimentowwds_11_tipopagamentonome2 ;
      private string AV74Titulomovimentowwds_13_dynamicfiltersselector3 ;
      private string AV77Titulomovimentowwds_16_tipopagamentonome3 ;
      private string AV85Titulomovimentowwds_24_tftipopagamentonome ;
      private string AV86Titulomovimentowwds_25_tftipopagamentonome_sel ;
      private string lV63Titulomovimentowwds_2_filterfulltext ;
      private string lV67Titulomovimentowwds_6_tipopagamentonome1 ;
      private string lV72Titulomovimentowwds_11_tipopagamentonome2 ;
      private string lV77Titulomovimentowwds_16_tipopagamentonome3 ;
      private string lV85Titulomovimentowwds_24_tftipopagamentonome ;
      private string A272TituloMovimentoTipo ;
      private string A289TipoPagamentoNome ;
      private string AV27Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GxSimpleCollection<string> AV17TFTituloMovimentoTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P007K2_A261TituloId ;
      private bool[] P007K2_n261TituloId ;
      private int[] P007K2_A288TipoPagamentoId ;
      private bool[] P007K2_n288TipoPagamentoId ;
      private DateTime[] P007K2_A280TituloMovimentoCreatedAt ;
      private bool[] P007K2_n280TituloMovimentoCreatedAt ;
      private DateTime[] P007K2_A279TituloMovimentoDataCredito ;
      private bool[] P007K2_n279TituloMovimentoDataCredito ;
      private decimal[] P007K2_A271TituloMovimentoValor ;
      private bool[] P007K2_n271TituloMovimentoValor ;
      private string[] P007K2_A289TipoPagamentoNome ;
      private string[] P007K2_A272TituloMovimentoTipo ;
      private bool[] P007K2_n272TituloMovimentoTipo ;
      private int[] P007K2_A270TituloMovimentoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class titulomovimentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007K2( IGxContext context ,
                                             string A272TituloMovimentoTipo ,
                                             GxSimpleCollection<string> AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels ,
                                             string AV63Titulomovimentowwds_2_filterfulltext ,
                                             string AV64Titulomovimentowwds_3_dynamicfiltersselector1 ,
                                             short AV65Titulomovimentowwds_4_dynamicfiltersoperator1 ,
                                             decimal AV66Titulomovimentowwds_5_titulomovimentovalor1 ,
                                             string AV67Titulomovimentowwds_6_tipopagamentonome1 ,
                                             bool AV68Titulomovimentowwds_7_dynamicfiltersenabled2 ,
                                             string AV69Titulomovimentowwds_8_dynamicfiltersselector2 ,
                                             short AV70Titulomovimentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV71Titulomovimentowwds_10_titulomovimentovalor2 ,
                                             string AV72Titulomovimentowwds_11_tipopagamentonome2 ,
                                             bool AV73Titulomovimentowwds_12_dynamicfiltersenabled3 ,
                                             string AV74Titulomovimentowwds_13_dynamicfiltersselector3 ,
                                             short AV75Titulomovimentowwds_14_dynamicfiltersoperator3 ,
                                             decimal AV76Titulomovimentowwds_15_titulomovimentovalor3 ,
                                             string AV77Titulomovimentowwds_16_tipopagamentonome3 ,
                                             decimal AV78Titulomovimentowwds_17_tftitulomovimentovalor ,
                                             decimal AV79Titulomovimentowwds_18_tftitulomovimentovalor_to ,
                                             int AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count ,
                                             DateTime AV81Titulomovimentowwds_20_tftitulomovimentodatacredito ,
                                             DateTime AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to ,
                                             DateTime AV83Titulomovimentowwds_22_tftitulomovimentocreatedat ,
                                             DateTime AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to ,
                                             string AV86Titulomovimentowwds_25_tftipopagamentonome_sel ,
                                             string AV85Titulomovimentowwds_24_tftipopagamentonome ,
                                             decimal A271TituloMovimentoValor ,
                                             string A289TipoPagamentoNome ,
                                             DateTime A279TituloMovimentoDataCredito ,
                                             DateTime A280TituloMovimentoCreatedAt ,
                                             int AV62Titulomovimentowwds_1_tituloid ,
                                             int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[30];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.TituloId, T1.TipoPagamentoId, T1.TituloMovimentoCreatedAt, T1.TituloMovimentoDataCredito, T1.TituloMovimentoValor, T2.TipoPagamentoNome, T1.TituloMovimentoTipo, T1.TituloMovimentoId FROM (TituloMovimento T1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = T1.TipoPagamentoId)";
         AddWhere(sWhereString, "(T1.TituloId = :AV62Titulomovimentowwds_1_tituloid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Titulomovimentowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.TituloMovimentoValor,'999999999999990.99'), 2) like '%' || :lV63Titulomovimentowwds_2_filterfulltext) or ( 'baixa' like '%' || LOWER(:lV63Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Baixa')) or ( 'juros' like '%' || LOWER(:lV63Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Juros')) or ( 'taxa' like '%' || LOWER(:lV63Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Taxa')) or ( 'multa' like '%' || LOWER(:lV63Titulomovimentowwds_2_filterfulltext) and T1.TituloMovimentoTipo = ( 'Multa')) or ( T2.TipoPagamentoNome like '%' || :lV63Titulomovimentowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV66Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV66Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Titulomovimentowwds_3_dynamicfiltersselector1, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV65Titulomovimentowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV66Titulomovimentowwds_5_titulomovimentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV66Titulomovimentowwds_5_titulomovimentovalor1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Titulomovimentowwds_3_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV65Titulomovimentowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Titulomovimentowwds_6_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV67Titulomovimentowwds_6_tipopagamentonome1)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Titulomovimentowwds_3_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV65Titulomovimentowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Titulomovimentowwds_6_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV67Titulomovimentowwds_6_tipopagamentonome1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV71Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV68Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV71Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV68Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_8_dynamicfiltersselector2, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV70Titulomovimentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Titulomovimentowwds_10_titulomovimentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV71Titulomovimentowwds_10_titulomovimentovalor2)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV68Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_8_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV70Titulomovimentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Titulomovimentowwds_11_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV72Titulomovimentowwds_11_tipopagamentonome2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV68Titulomovimentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Titulomovimentowwds_8_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV70Titulomovimentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Titulomovimentowwds_11_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV72Titulomovimentowwds_11_tipopagamentonome2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV73Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV75Titulomovimentowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV76Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor < :AV76Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV73Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV75Titulomovimentowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV76Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor = :AV76Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV73Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Titulomovimentowwds_13_dynamicfiltersselector3, "TITULOMOVIMENTOVALOR") == 0 ) && ( AV75Titulomovimentowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV76Titulomovimentowwds_15_titulomovimentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor > :AV76Titulomovimentowwds_15_titulomovimentovalor3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV73Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Titulomovimentowwds_13_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV75Titulomovimentowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Titulomovimentowwds_16_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV77Titulomovimentowwds_16_tipopagamentonome3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV73Titulomovimentowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Titulomovimentowwds_13_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV75Titulomovimentowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Titulomovimentowwds_16_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like '%' || :lV77Titulomovimentowwds_16_tipopagamentonome3)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Titulomovimentowwds_17_tftitulomovimentovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor >= :AV78Titulomovimentowwds_17_tftitulomovimentovalor)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Titulomovimentowwds_18_tftitulomovimentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoValor <= :AV79Titulomovimentowwds_18_tftitulomovimentovalor_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80Titulomovimentowwds_19_tftitulomovimentotipo_sels, "T1.TituloMovimentoTipo IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV81Titulomovimentowwds_20_tftitulomovimentodatacredito) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoDataCredito >= :AV81Titulomovimentowwds_20_tftitulomovimentodatacredito)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoDataCredito <= :AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Titulomovimentowwds_22_tftitulomovimentocreatedat) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoCreatedAt >= :AV83Titulomovimentowwds_22_tftitulomovimentocreatedat)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.TituloMovimentoCreatedAt <= :AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Titulomovimentowwds_25_tftipopagamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Titulomovimentowwds_24_tftipopagamentonome)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome like :lV85Titulomovimentowwds_24_tftipopagamentonome)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Titulomovimentowwds_25_tftipopagamentonome_sel)) && ! ( StringUtil.StrCmp(AV86Titulomovimentowwds_25_tftipopagamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome = ( :AV86Titulomovimentowwds_25_tftipopagamentonome_sel))");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Titulomovimentowwds_25_tftipopagamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoPagamentoNome IS NULL or (char_length(trim(trailing ' ' from T2.TipoPagamentoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId, T1.TipoPagamentoId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007K2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (int)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007K2;
          prmP007K2 = new Object[] {
          new ParDef("AV62Titulomovimentowwds_1_tituloid",GXType.Int32,9,0) ,
          new ParDef("lV63Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Titulomovimentowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV66Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("AV66Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("AV66Titulomovimentowwds_5_titulomovimentovalor1",GXType.Number,18,2) ,
          new ParDef("lV67Titulomovimentowwds_6_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV67Titulomovimentowwds_6_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("AV71Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Titulomovimentowwds_10_titulomovimentovalor2",GXType.Number,18,2) ,
          new ParDef("lV72Titulomovimentowwds_11_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV72Titulomovimentowwds_11_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("AV76Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("AV76Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("AV76Titulomovimentowwds_15_titulomovimentovalor3",GXType.Number,18,2) ,
          new ParDef("lV77Titulomovimentowwds_16_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("lV77Titulomovimentowwds_16_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("AV78Titulomovimentowwds_17_tftitulomovimentovalor",GXType.Number,18,2) ,
          new ParDef("AV79Titulomovimentowwds_18_tftitulomovimentovalor_to",GXType.Number,18,2) ,
          new ParDef("AV81Titulomovimentowwds_20_tftitulomovimentodatacredito",GXType.Date,8,0) ,
          new ParDef("AV82Titulomovimentowwds_21_tftitulomovimentodatacredito_to",GXType.Date,8,0) ,
          new ParDef("AV83Titulomovimentowwds_22_tftitulomovimentocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV84Titulomovimentowwds_23_tftitulomovimentocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("lV85Titulomovimentowwds_24_tftipopagamentonome",GXType.VarChar,60,0) ,
          new ParDef("AV86Titulomovimentowwds_25_tftipopagamentonome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
