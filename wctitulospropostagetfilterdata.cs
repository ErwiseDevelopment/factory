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
   public class wctitulospropostagetfilterdata : GXProcedure
   {
      public wctitulospropostagetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wctitulospropostagetfilterdata( IGxContext context )
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
         this.AV46DDOName = aP0_DDOName;
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
         this.AV48SearchTxtTo = aP2_SearchTxtTo;
         this.AV49OptionsJson = "" ;
         this.AV50OptionsDescJson = "" ;
         this.AV51OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV49OptionsJson;
         aP4_OptionsDescJson=this.AV50OptionsDescJson;
         aP5_OptionIndexesJson=this.AV51OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV51OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV46DDOName = aP0_DDOName;
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
         this.AV48SearchTxtTo = aP2_SearchTxtTo;
         this.AV49OptionsJson = "" ;
         this.AV50OptionsDescJson = "" ;
         this.AV51OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV49OptionsJson;
         aP4_OptionsDescJson=this.AV50OptionsDescJson;
         aP5_OptionIndexesJson=this.AV51OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV36Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33MaxItems = 10;
         AV32PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV47SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV30SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? "" : StringUtil.Substring( AV47SearchTxtParms, 3, -1));
         AV31SkipItems = (short)(AV32PageIndex*AV33MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_TITULOCOMPETENCIA_F") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOCOMPETENCIA_FOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_TITULOSTATUS_F") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOSTATUS_FOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV49OptionsJson = AV36Options.ToJSonString(false);
         AV50OptionsDescJson = AV38OptionsDesc.ToJSonString(false);
         AV51OptionIndexesJson = AV39OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("WCTitulosPropostaGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WCTitulosPropostaGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("WCTitulosPropostaGridState"), null, "", "");
         }
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV52FilterFullText = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV12TFClienteRazaoSocial = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV13TFClienteRazaoSocial_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTATIPO_SEL") == 0 )
            {
               AV66TFTituloPropostaTipo_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV67TFTituloPropostaTipo_Sels.FromJSonString(AV66TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV14TFTituloValor = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV15TFTituloValor_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV16TFTituloDesconto = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV17TFTituloDesconto_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV18TFTituloCompetencia_F = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV19TFTituloCompetencia_F_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV20TFTituloProrrogacao = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Value, 4);
               AV21TFTituloProrrogacao_To = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV22TFTituloTipo_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV23TFTituloTipo_Sels.FromJSonString(AV22TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOSALDO_F") == 0 )
            {
               AV24TFTituloSaldo_F = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV25TFTituloSaldo_F_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F") == 0 )
            {
               AV28TFTituloStatus_F = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F_SEL") == 0 )
            {
               AV29TFTituloStatus_F_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "PARM_&TITULOPROPOSTAID") == 0 )
            {
               AV64TituloPropostaId = (int)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "PARM_&ISUNIQUE") == 0 )
            {
               AV65IsUnique = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV53DynamicFiltersSelector1 = AV45GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV53DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV54DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV55TituloValor1 = NumberUtil.Val( AV45GridStateDynamicFilter.gxTpr_Value, ".");
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV56DynamicFiltersEnabled2 = true;
               AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV57DynamicFiltersSelector2 = AV45GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV59TituloValor2 = NumberUtil.Val( AV45GridStateDynamicFilter.gxTpr_Value, ".");
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV60DynamicFiltersEnabled3 = true;
                  AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV61DynamicFiltersSelector3 = AV45GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV61DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV62DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV63TituloValor3 = NumberUtil.Val( AV45GridStateDynamicFilter.gxTpr_Value, ".");
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV12TFClienteRazaoSocial = AV30SearchTxt;
         AV13TFClienteRazaoSocial_Sel = "";
         AV70Wctitulospropostads_1_titulopropostaid = AV64TituloPropostaId;
         AV71Wctitulospropostads_2_filterfulltext = AV52FilterFullText;
         AV72Wctitulospropostads_3_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV73Wctitulospropostads_4_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV74Wctitulospropostads_5_titulovalor1 = AV55TituloValor1;
         AV75Wctitulospropostads_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV76Wctitulospropostads_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV77Wctitulospropostads_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV78Wctitulospropostads_9_titulovalor2 = AV59TituloValor2;
         AV79Wctitulospropostads_10_dynamicfiltersenabled3 = AV60DynamicFiltersEnabled3;
         AV80Wctitulospropostads_11_dynamicfiltersselector3 = AV61DynamicFiltersSelector3;
         AV81Wctitulospropostads_12_dynamicfiltersoperator3 = AV62DynamicFiltersOperator3;
         AV82Wctitulospropostads_13_titulovalor3 = AV63TituloValor3;
         AV83Wctitulospropostads_14_tfclienterazaosocial = AV12TFClienteRazaoSocial;
         AV84Wctitulospropostads_15_tfclienterazaosocial_sel = AV13TFClienteRazaoSocial_Sel;
         AV85Wctitulospropostads_16_tftitulopropostatipo_sels = AV67TFTituloPropostaTipo_Sels;
         AV86Wctitulospropostads_17_tftitulovalor = AV14TFTituloValor;
         AV87Wctitulospropostads_18_tftitulovalor_to = AV15TFTituloValor_To;
         AV88Wctitulospropostads_19_tftitulodesconto = AV16TFTituloDesconto;
         AV89Wctitulospropostads_20_tftitulodesconto_to = AV17TFTituloDesconto_To;
         AV90Wctitulospropostads_21_tftitulocompetencia_f = AV18TFTituloCompetencia_F;
         AV91Wctitulospropostads_22_tftitulocompetencia_f_sel = AV19TFTituloCompetencia_F_Sel;
         AV92Wctitulospropostads_23_tftituloprorrogacao = AV20TFTituloProrrogacao;
         AV93Wctitulospropostads_24_tftituloprorrogacao_to = AV21TFTituloProrrogacao_To;
         AV94Wctitulospropostads_25_tftitulotipo_sels = AV23TFTituloTipo_Sels;
         AV95Wctitulospropostads_26_tftitulosaldo_f = AV24TFTituloSaldo_F;
         AV96Wctitulospropostads_27_tftitulosaldo_f_to = AV25TFTituloSaldo_F_To;
         AV97Wctitulospropostads_28_tftitulostatus_f = AV28TFTituloStatus_F;
         AV98Wctitulospropostads_29_tftitulostatus_f_sel = AV29TFTituloStatus_F_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV85Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                              A283TituloTipo ,
                                              AV94Wctitulospropostads_25_tftitulotipo_sels ,
                                              AV72Wctitulospropostads_3_dynamicfiltersselector1 ,
                                              AV73Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                              AV74Wctitulospropostads_5_titulovalor1 ,
                                              AV75Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                              AV76Wctitulospropostads_7_dynamicfiltersselector2 ,
                                              AV77Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                              AV78Wctitulospropostads_9_titulovalor2 ,
                                              AV79Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                              AV80Wctitulospropostads_11_dynamicfiltersselector3 ,
                                              AV81Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                              AV82Wctitulospropostads_13_titulovalor3 ,
                                              AV84Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                              AV83Wctitulospropostads_14_tfclienterazaosocial ,
                                              AV85Wctitulospropostads_16_tftitulopropostatipo_sels.Count ,
                                              AV86Wctitulospropostads_17_tftitulovalor ,
                                              AV87Wctitulospropostads_18_tftitulovalor_to ,
                                              AV88Wctitulospropostads_19_tftitulodesconto ,
                                              AV89Wctitulospropostads_20_tftitulodesconto_to ,
                                              AV92Wctitulospropostads_23_tftituloprorrogacao ,
                                              AV93Wctitulospropostads_24_tftituloprorrogacao_to ,
                                              AV94Wctitulospropostads_25_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV71Wctitulospropostads_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                              AV90Wctitulospropostads_21_tftitulocompetencia_f ,
                                              AV95Wctitulospropostads_26_tftitulosaldo_f ,
                                              AV96Wctitulospropostads_27_tftitulosaldo_f_to ,
                                              AV98Wctitulospropostads_29_tftitulostatus_f_sel ,
                                              AV97Wctitulospropostads_28_tftitulostatus_f ,
                                              AV70Wctitulospropostads_1_titulopropostaid ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV97Wctitulospropostads_28_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV97Wctitulospropostads_28_tftitulostatus_f), "%", "");
         lV83Wctitulospropostads_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV83Wctitulospropostads_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00C34 */
         pr_default.execute(0, new Object[] {AV70Wctitulospropostads_1_titulopropostaid, AV95Wctitulospropostads_26_tftitulosaldo_f, AV95Wctitulospropostads_26_tftitulosaldo_f, AV96Wctitulospropostads_27_tftitulosaldo_f_to, AV96Wctitulospropostads_27_tftitulosaldo_f_to, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV97Wctitulospropostads_28_tftitulostatus_f, lV97Wctitulospropostads_28_tftitulostatus_f, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV74Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_5_titulovalor1, AV78Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_9_titulovalor2, AV82Wctitulospropostads_13_titulovalor3, AV82Wctitulospropostads_13_titulovalor3, AV82Wctitulospropostads_13_titulovalor3, lV83Wctitulospropostads_14_tfclienterazaosocial, AV84Wctitulospropostads_15_tfclienterazaosocial_sel, AV86Wctitulospropostads_17_tftitulovalor, AV87Wctitulospropostads_18_tftitulovalor_to, AV88Wctitulospropostads_19_tftitulodesconto, AV89Wctitulospropostads_20_tftitulodesconto_to, AV92Wctitulospropostads_23_tftituloprorrogacao, AV93Wctitulospropostads_24_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKC32 = false;
            A890NotaFiscalParcelamentoID = P00C34_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00C34_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00C34_A794NotaFiscalId[0];
            n794NotaFiscalId = P00C34_n794NotaFiscalId[0];
            A168ClienteId = P00C34_A168ClienteId[0];
            n168ClienteId = P00C34_n168ClienteId[0];
            A261TituloId = P00C34_A261TituloId[0];
            n261TituloId = P00C34_n261TituloId[0];
            A419TituloPropostaId = P00C34_A419TituloPropostaId[0];
            n419TituloPropostaId = P00C34_n419TituloPropostaId[0];
            A170ClienteRazaoSocial = P00C34_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C34_n170ClienteRazaoSocial[0];
            A264TituloProrrogacao = P00C34_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00C34_n264TituloProrrogacao[0];
            A276TituloDesconto = P00C34_A276TituloDesconto[0];
            n276TituloDesconto = P00C34_n276TituloDesconto[0];
            A282TituloStatus_F = P00C34_A282TituloStatus_F[0];
            A283TituloTipo = P00C34_A283TituloTipo[0];
            n283TituloTipo = P00C34_n283TituloTipo[0];
            A648TituloPropostaTipo = P00C34_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00C34_n648TituloPropostaTipo[0];
            A275TituloSaldo_F = P00C34_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00C34_n275TituloSaldo_F[0];
            A262TituloValor = P00C34_A262TituloValor[0];
            n262TituloValor = P00C34_n262TituloValor[0];
            A286TituloCompetenciaAno = P00C34_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00C34_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00C34_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00C34_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00C34_A794NotaFiscalId[0];
            n794NotaFiscalId = P00C34_n794NotaFiscalId[0];
            A168ClienteId = P00C34_A168ClienteId[0];
            n168ClienteId = P00C34_n168ClienteId[0];
            A170ClienteRazaoSocial = P00C34_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C34_n170ClienteRazaoSocial[0];
            A275TituloSaldo_F = P00C34_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00C34_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wctitulospropostads_2_filterfulltext)) || ( ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wctitulospropostads_21_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV90Wctitulospropostads_21_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV91Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV91Wctitulospropostads_22_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV91Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV40count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( P00C34_A419TituloPropostaId[0] == A419TituloPropostaId ) && ( StringUtil.StrCmp(P00C34_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
                        {
                           BRKC32 = false;
                           A890NotaFiscalParcelamentoID = P00C34_A890NotaFiscalParcelamentoID[0];
                           n890NotaFiscalParcelamentoID = P00C34_n890NotaFiscalParcelamentoID[0];
                           A794NotaFiscalId = P00C34_A794NotaFiscalId[0];
                           n794NotaFiscalId = P00C34_n794NotaFiscalId[0];
                           A168ClienteId = P00C34_A168ClienteId[0];
                           n168ClienteId = P00C34_n168ClienteId[0];
                           A261TituloId = P00C34_A261TituloId[0];
                           n261TituloId = P00C34_n261TituloId[0];
                           A794NotaFiscalId = P00C34_A794NotaFiscalId[0];
                           n794NotaFiscalId = P00C34_n794NotaFiscalId[0];
                           A168ClienteId = P00C34_A168ClienteId[0];
                           n168ClienteId = P00C34_n168ClienteId[0];
                           AV40count = (long)(AV40count+1);
                           BRKC32 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV31SkipItems) )
                        {
                           AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
                           AV37OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
                           AV36Options.Add(AV35Option, 0);
                           AV38OptionsDesc.Add(AV37OptionDesc, 0);
                           AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV36Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV31SkipItems = (short)(AV31SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKC32 )
            {
               BRKC32 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTITULOCOMPETENCIA_FOPTIONS' Routine */
         returnInSub = false;
         AV18TFTituloCompetencia_F = AV30SearchTxt;
         AV19TFTituloCompetencia_F_Sel = "";
         AV70Wctitulospropostads_1_titulopropostaid = AV64TituloPropostaId;
         AV71Wctitulospropostads_2_filterfulltext = AV52FilterFullText;
         AV72Wctitulospropostads_3_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV73Wctitulospropostads_4_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV74Wctitulospropostads_5_titulovalor1 = AV55TituloValor1;
         AV75Wctitulospropostads_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV76Wctitulospropostads_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV77Wctitulospropostads_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV78Wctitulospropostads_9_titulovalor2 = AV59TituloValor2;
         AV79Wctitulospropostads_10_dynamicfiltersenabled3 = AV60DynamicFiltersEnabled3;
         AV80Wctitulospropostads_11_dynamicfiltersselector3 = AV61DynamicFiltersSelector3;
         AV81Wctitulospropostads_12_dynamicfiltersoperator3 = AV62DynamicFiltersOperator3;
         AV82Wctitulospropostads_13_titulovalor3 = AV63TituloValor3;
         AV83Wctitulospropostads_14_tfclienterazaosocial = AV12TFClienteRazaoSocial;
         AV84Wctitulospropostads_15_tfclienterazaosocial_sel = AV13TFClienteRazaoSocial_Sel;
         AV85Wctitulospropostads_16_tftitulopropostatipo_sels = AV67TFTituloPropostaTipo_Sels;
         AV86Wctitulospropostads_17_tftitulovalor = AV14TFTituloValor;
         AV87Wctitulospropostads_18_tftitulovalor_to = AV15TFTituloValor_To;
         AV88Wctitulospropostads_19_tftitulodesconto = AV16TFTituloDesconto;
         AV89Wctitulospropostads_20_tftitulodesconto_to = AV17TFTituloDesconto_To;
         AV90Wctitulospropostads_21_tftitulocompetencia_f = AV18TFTituloCompetencia_F;
         AV91Wctitulospropostads_22_tftitulocompetencia_f_sel = AV19TFTituloCompetencia_F_Sel;
         AV92Wctitulospropostads_23_tftituloprorrogacao = AV20TFTituloProrrogacao;
         AV93Wctitulospropostads_24_tftituloprorrogacao_to = AV21TFTituloProrrogacao_To;
         AV94Wctitulospropostads_25_tftitulotipo_sels = AV23TFTituloTipo_Sels;
         AV95Wctitulospropostads_26_tftitulosaldo_f = AV24TFTituloSaldo_F;
         AV96Wctitulospropostads_27_tftitulosaldo_f_to = AV25TFTituloSaldo_F_To;
         AV97Wctitulospropostads_28_tftitulostatus_f = AV28TFTituloStatus_F;
         AV98Wctitulospropostads_29_tftitulostatus_f_sel = AV29TFTituloStatus_F_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV85Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                              A283TituloTipo ,
                                              AV94Wctitulospropostads_25_tftitulotipo_sels ,
                                              AV72Wctitulospropostads_3_dynamicfiltersselector1 ,
                                              AV73Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                              AV74Wctitulospropostads_5_titulovalor1 ,
                                              AV75Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                              AV76Wctitulospropostads_7_dynamicfiltersselector2 ,
                                              AV77Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                              AV78Wctitulospropostads_9_titulovalor2 ,
                                              AV79Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                              AV80Wctitulospropostads_11_dynamicfiltersselector3 ,
                                              AV81Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                              AV82Wctitulospropostads_13_titulovalor3 ,
                                              AV84Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                              AV83Wctitulospropostads_14_tfclienterazaosocial ,
                                              AV85Wctitulospropostads_16_tftitulopropostatipo_sels.Count ,
                                              AV86Wctitulospropostads_17_tftitulovalor ,
                                              AV87Wctitulospropostads_18_tftitulovalor_to ,
                                              AV88Wctitulospropostads_19_tftitulodesconto ,
                                              AV89Wctitulospropostads_20_tftitulodesconto_to ,
                                              AV92Wctitulospropostads_23_tftituloprorrogacao ,
                                              AV93Wctitulospropostads_24_tftituloprorrogacao_to ,
                                              AV94Wctitulospropostads_25_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV71Wctitulospropostads_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                              AV90Wctitulospropostads_21_tftitulocompetencia_f ,
                                              AV95Wctitulospropostads_26_tftitulosaldo_f ,
                                              AV96Wctitulospropostads_27_tftitulosaldo_f_to ,
                                              AV98Wctitulospropostads_29_tftitulostatus_f_sel ,
                                              AV97Wctitulospropostads_28_tftitulostatus_f ,
                                              AV70Wctitulospropostads_1_titulopropostaid ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV97Wctitulospropostads_28_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV97Wctitulospropostads_28_tftitulostatus_f), "%", "");
         lV83Wctitulospropostads_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV83Wctitulospropostads_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00C37 */
         pr_default.execute(1, new Object[] {AV70Wctitulospropostads_1_titulopropostaid, AV95Wctitulospropostads_26_tftitulosaldo_f, AV95Wctitulospropostads_26_tftitulosaldo_f, AV96Wctitulospropostads_27_tftitulosaldo_f_to, AV96Wctitulospropostads_27_tftitulosaldo_f_to, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV97Wctitulospropostads_28_tftitulostatus_f, lV97Wctitulospropostads_28_tftitulostatus_f, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV74Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_5_titulovalor1, AV78Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_9_titulovalor2, AV82Wctitulospropostads_13_titulovalor3, AV82Wctitulospropostads_13_titulovalor3, AV82Wctitulospropostads_13_titulovalor3, lV83Wctitulospropostads_14_tfclienterazaosocial, AV84Wctitulospropostads_15_tfclienterazaosocial_sel, AV86Wctitulospropostads_17_tftitulovalor, AV87Wctitulospropostads_18_tftitulovalor_to, AV88Wctitulospropostads_19_tftitulodesconto, AV89Wctitulospropostads_20_tftitulodesconto_to, AV92Wctitulospropostads_23_tftituloprorrogacao, AV93Wctitulospropostads_24_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00C37_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00C37_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00C37_A794NotaFiscalId[0];
            n794NotaFiscalId = P00C37_n794NotaFiscalId[0];
            A168ClienteId = P00C37_A168ClienteId[0];
            n168ClienteId = P00C37_n168ClienteId[0];
            A261TituloId = P00C37_A261TituloId[0];
            n261TituloId = P00C37_n261TituloId[0];
            A264TituloProrrogacao = P00C37_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00C37_n264TituloProrrogacao[0];
            A276TituloDesconto = P00C37_A276TituloDesconto[0];
            n276TituloDesconto = P00C37_n276TituloDesconto[0];
            A282TituloStatus_F = P00C37_A282TituloStatus_F[0];
            A283TituloTipo = P00C37_A283TituloTipo[0];
            n283TituloTipo = P00C37_n283TituloTipo[0];
            A648TituloPropostaTipo = P00C37_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00C37_n648TituloPropostaTipo[0];
            A170ClienteRazaoSocial = P00C37_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C37_n170ClienteRazaoSocial[0];
            A419TituloPropostaId = P00C37_A419TituloPropostaId[0];
            n419TituloPropostaId = P00C37_n419TituloPropostaId[0];
            A275TituloSaldo_F = P00C37_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00C37_n275TituloSaldo_F[0];
            A262TituloValor = P00C37_A262TituloValor[0];
            n262TituloValor = P00C37_n262TituloValor[0];
            A286TituloCompetenciaAno = P00C37_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00C37_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00C37_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00C37_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00C37_A794NotaFiscalId[0];
            n794NotaFiscalId = P00C37_n794NotaFiscalId[0];
            A168ClienteId = P00C37_A168ClienteId[0];
            n168ClienteId = P00C37_n168ClienteId[0];
            A170ClienteRazaoSocial = P00C37_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C37_n170ClienteRazaoSocial[0];
            A275TituloSaldo_F = P00C37_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00C37_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wctitulospropostads_2_filterfulltext)) || ( ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wctitulospropostads_21_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV90Wctitulospropostads_21_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV91Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV91Wctitulospropostads_22_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV91Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ? "<#Empty#>" : A295TituloCompetencia_F);
                        AV34InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV35Option, "<#Empty#>") != 0 ) && ( AV34InsertIndex <= AV36Options.Count ) && ( ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), AV35Option) < 0 ) || ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV34InsertIndex = (int)(AV34InsertIndex+1);
                        }
                        if ( ( AV34InsertIndex <= AV36Options.Count ) && ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), AV35Option) == 0 ) )
                        {
                           AV40count = (long)(Math.Round(NumberUtil.Val( ((string)AV39OptionIndexes.Item(AV34InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV40count = (long)(AV40count+1);
                           AV39OptionIndexes.RemoveItem(AV34InsertIndex);
                           AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), AV34InsertIndex);
                        }
                        else
                        {
                           AV36Options.Add(AV35Option, AV34InsertIndex);
                           AV39OptionIndexes.Add("1", AV34InsertIndex);
                        }
                        if ( AV36Options.Count == AV31SkipItems + 11 )
                        {
                           AV36Options.RemoveItem(AV36Options.Count);
                           AV39OptionIndexes.RemoveItem(AV39OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV31SkipItems > 0 )
         {
            AV36Options.RemoveItem(1);
            AV39OptionIndexes.RemoveItem(1);
            AV31SkipItems = (short)(AV31SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADTITULOSTATUS_FOPTIONS' Routine */
         returnInSub = false;
         AV28TFTituloStatus_F = AV30SearchTxt;
         AV29TFTituloStatus_F_Sel = "";
         AV70Wctitulospropostads_1_titulopropostaid = AV64TituloPropostaId;
         AV71Wctitulospropostads_2_filterfulltext = AV52FilterFullText;
         AV72Wctitulospropostads_3_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV73Wctitulospropostads_4_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV74Wctitulospropostads_5_titulovalor1 = AV55TituloValor1;
         AV75Wctitulospropostads_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV76Wctitulospropostads_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV77Wctitulospropostads_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV78Wctitulospropostads_9_titulovalor2 = AV59TituloValor2;
         AV79Wctitulospropostads_10_dynamicfiltersenabled3 = AV60DynamicFiltersEnabled3;
         AV80Wctitulospropostads_11_dynamicfiltersselector3 = AV61DynamicFiltersSelector3;
         AV81Wctitulospropostads_12_dynamicfiltersoperator3 = AV62DynamicFiltersOperator3;
         AV82Wctitulospropostads_13_titulovalor3 = AV63TituloValor3;
         AV83Wctitulospropostads_14_tfclienterazaosocial = AV12TFClienteRazaoSocial;
         AV84Wctitulospropostads_15_tfclienterazaosocial_sel = AV13TFClienteRazaoSocial_Sel;
         AV85Wctitulospropostads_16_tftitulopropostatipo_sels = AV67TFTituloPropostaTipo_Sels;
         AV86Wctitulospropostads_17_tftitulovalor = AV14TFTituloValor;
         AV87Wctitulospropostads_18_tftitulovalor_to = AV15TFTituloValor_To;
         AV88Wctitulospropostads_19_tftitulodesconto = AV16TFTituloDesconto;
         AV89Wctitulospropostads_20_tftitulodesconto_to = AV17TFTituloDesconto_To;
         AV90Wctitulospropostads_21_tftitulocompetencia_f = AV18TFTituloCompetencia_F;
         AV91Wctitulospropostads_22_tftitulocompetencia_f_sel = AV19TFTituloCompetencia_F_Sel;
         AV92Wctitulospropostads_23_tftituloprorrogacao = AV20TFTituloProrrogacao;
         AV93Wctitulospropostads_24_tftituloprorrogacao_to = AV21TFTituloProrrogacao_To;
         AV94Wctitulospropostads_25_tftitulotipo_sels = AV23TFTituloTipo_Sels;
         AV95Wctitulospropostads_26_tftitulosaldo_f = AV24TFTituloSaldo_F;
         AV96Wctitulospropostads_27_tftitulosaldo_f_to = AV25TFTituloSaldo_F_To;
         AV97Wctitulospropostads_28_tftitulostatus_f = AV28TFTituloStatus_F;
         AV98Wctitulospropostads_29_tftitulostatus_f_sel = AV29TFTituloStatus_F_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV85Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                              A283TituloTipo ,
                                              AV94Wctitulospropostads_25_tftitulotipo_sels ,
                                              AV72Wctitulospropostads_3_dynamicfiltersselector1 ,
                                              AV73Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                              AV74Wctitulospropostads_5_titulovalor1 ,
                                              AV75Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                              AV76Wctitulospropostads_7_dynamicfiltersselector2 ,
                                              AV77Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                              AV78Wctitulospropostads_9_titulovalor2 ,
                                              AV79Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                              AV80Wctitulospropostads_11_dynamicfiltersselector3 ,
                                              AV81Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                              AV82Wctitulospropostads_13_titulovalor3 ,
                                              AV84Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                              AV83Wctitulospropostads_14_tfclienterazaosocial ,
                                              AV85Wctitulospropostads_16_tftitulopropostatipo_sels.Count ,
                                              AV86Wctitulospropostads_17_tftitulovalor ,
                                              AV87Wctitulospropostads_18_tftitulovalor_to ,
                                              AV88Wctitulospropostads_19_tftitulodesconto ,
                                              AV89Wctitulospropostads_20_tftitulodesconto_to ,
                                              AV92Wctitulospropostads_23_tftituloprorrogacao ,
                                              AV93Wctitulospropostads_24_tftituloprorrogacao_to ,
                                              AV94Wctitulospropostads_25_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV71Wctitulospropostads_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                              AV90Wctitulospropostads_21_tftitulocompetencia_f ,
                                              AV95Wctitulospropostads_26_tftitulosaldo_f ,
                                              AV96Wctitulospropostads_27_tftitulosaldo_f_to ,
                                              AV98Wctitulospropostads_29_tftitulostatus_f_sel ,
                                              AV97Wctitulospropostads_28_tftitulostatus_f ,
                                              AV70Wctitulospropostads_1_titulopropostaid ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV97Wctitulospropostads_28_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV97Wctitulospropostads_28_tftitulostatus_f), "%", "");
         lV83Wctitulospropostads_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV83Wctitulospropostads_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00C310 */
         pr_default.execute(2, new Object[] {AV70Wctitulospropostads_1_titulopropostaid, AV95Wctitulospropostads_26_tftitulosaldo_f, AV95Wctitulospropostads_26_tftitulosaldo_f, AV96Wctitulospropostads_27_tftitulosaldo_f_to, AV96Wctitulospropostads_27_tftitulosaldo_f_to, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV97Wctitulospropostads_28_tftitulostatus_f, lV97Wctitulospropostads_28_tftitulostatus_f, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV98Wctitulospropostads_29_tftitulostatus_f_sel, AV74Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_5_titulovalor1, AV74Wctitulospropostads_5_titulovalor1, AV78Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_9_titulovalor2, AV78Wctitulospropostads_9_titulovalor2, AV82Wctitulospropostads_13_titulovalor3, AV82Wctitulospropostads_13_titulovalor3, AV82Wctitulospropostads_13_titulovalor3, lV83Wctitulospropostads_14_tfclienterazaosocial, AV84Wctitulospropostads_15_tfclienterazaosocial_sel, AV86Wctitulospropostads_17_tftitulovalor, AV87Wctitulospropostads_18_tftitulovalor_to, AV88Wctitulospropostads_19_tftitulodesconto, AV89Wctitulospropostads_20_tftitulodesconto_to, AV92Wctitulospropostads_23_tftituloprorrogacao, AV93Wctitulospropostads_24_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00C310_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00C310_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00C310_A794NotaFiscalId[0];
            n794NotaFiscalId = P00C310_n794NotaFiscalId[0];
            A168ClienteId = P00C310_A168ClienteId[0];
            n168ClienteId = P00C310_n168ClienteId[0];
            A261TituloId = P00C310_A261TituloId[0];
            n261TituloId = P00C310_n261TituloId[0];
            A264TituloProrrogacao = P00C310_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00C310_n264TituloProrrogacao[0];
            A276TituloDesconto = P00C310_A276TituloDesconto[0];
            n276TituloDesconto = P00C310_n276TituloDesconto[0];
            A282TituloStatus_F = P00C310_A282TituloStatus_F[0];
            A283TituloTipo = P00C310_A283TituloTipo[0];
            n283TituloTipo = P00C310_n283TituloTipo[0];
            A648TituloPropostaTipo = P00C310_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00C310_n648TituloPropostaTipo[0];
            A170ClienteRazaoSocial = P00C310_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C310_n170ClienteRazaoSocial[0];
            A419TituloPropostaId = P00C310_A419TituloPropostaId[0];
            n419TituloPropostaId = P00C310_n419TituloPropostaId[0];
            A275TituloSaldo_F = P00C310_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00C310_n275TituloSaldo_F[0];
            A262TituloValor = P00C310_A262TituloValor[0];
            n262TituloValor = P00C310_n262TituloValor[0];
            A286TituloCompetenciaAno = P00C310_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00C310_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00C310_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00C310_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00C310_A794NotaFiscalId[0];
            n794NotaFiscalId = P00C310_n794NotaFiscalId[0];
            A168ClienteId = P00C310_A168ClienteId[0];
            n168ClienteId = P00C310_n168ClienteId[0];
            A170ClienteRazaoSocial = P00C310_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00C310_n170ClienteRazaoSocial[0];
            A275TituloSaldo_F = P00C310_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00C310_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wctitulospropostads_2_filterfulltext)) || ( ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV71Wctitulospropostads_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV71Wctitulospropostads_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wctitulospropostads_21_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV90Wctitulospropostads_21_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wctitulospropostads_22_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV91Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV91Wctitulospropostads_22_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV91Wctitulospropostads_22_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282TituloStatus_F)) ? "<#Empty#>" : A282TituloStatus_F);
                        AV34InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV35Option, "<#Empty#>") != 0 ) && ( AV34InsertIndex <= AV36Options.Count ) && ( ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), AV35Option) < 0 ) || ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV34InsertIndex = (int)(AV34InsertIndex+1);
                        }
                        if ( ( AV34InsertIndex <= AV36Options.Count ) && ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), AV35Option) == 0 ) )
                        {
                           AV40count = (long)(Math.Round(NumberUtil.Val( ((string)AV39OptionIndexes.Item(AV34InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV40count = (long)(AV40count+1);
                           AV39OptionIndexes.RemoveItem(AV34InsertIndex);
                           AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), AV34InsertIndex);
                        }
                        else
                        {
                           AV36Options.Add(AV35Option, AV34InsertIndex);
                           AV39OptionIndexes.Add("1", AV34InsertIndex);
                        }
                        if ( AV36Options.Count == AV31SkipItems + 11 )
                        {
                           AV36Options.RemoveItem(AV36Options.Count);
                           AV39OptionIndexes.RemoveItem(AV39OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV31SkipItems > 0 )
         {
            AV36Options.RemoveItem(1);
            AV39OptionIndexes.RemoveItem(1);
            AV31SkipItems = (short)(AV31SkipItems-1);
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
         AV49OptionsJson = "";
         AV50OptionsDescJson = "";
         AV51OptionIndexesJson = "";
         AV36Options = new GxSimpleCollection<string>();
         AV38OptionsDesc = new GxSimpleCollection<string>();
         AV39OptionIndexes = new GxSimpleCollection<string>();
         AV30SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Session = context.GetSession();
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52FilterFullText = "";
         AV12TFClienteRazaoSocial = "";
         AV13TFClienteRazaoSocial_Sel = "";
         AV66TFTituloPropostaTipo_SelsJson = "";
         AV67TFTituloPropostaTipo_Sels = new GxSimpleCollection<string>();
         AV18TFTituloCompetencia_F = "";
         AV19TFTituloCompetencia_F_Sel = "";
         AV20TFTituloProrrogacao = DateTime.MinValue;
         AV21TFTituloProrrogacao_To = DateTime.MinValue;
         AV22TFTituloTipo_SelsJson = "";
         AV23TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV28TFTituloStatus_F = "";
         AV29TFTituloStatus_F_Sel = "";
         AV45GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV53DynamicFiltersSelector1 = "";
         AV57DynamicFiltersSelector2 = "";
         AV61DynamicFiltersSelector3 = "";
         AV71Wctitulospropostads_2_filterfulltext = "";
         AV72Wctitulospropostads_3_dynamicfiltersselector1 = "";
         AV76Wctitulospropostads_7_dynamicfiltersselector2 = "";
         AV80Wctitulospropostads_11_dynamicfiltersselector3 = "";
         AV83Wctitulospropostads_14_tfclienterazaosocial = "";
         AV84Wctitulospropostads_15_tfclienterazaosocial_sel = "";
         AV85Wctitulospropostads_16_tftitulopropostatipo_sels = new GxSimpleCollection<string>();
         AV90Wctitulospropostads_21_tftitulocompetencia_f = "";
         AV91Wctitulospropostads_22_tftitulocompetencia_f_sel = "";
         AV92Wctitulospropostads_23_tftituloprorrogacao = DateTime.MinValue;
         AV93Wctitulospropostads_24_tftituloprorrogacao_to = DateTime.MinValue;
         AV94Wctitulospropostads_25_tftitulotipo_sels = new GxSimpleCollection<string>();
         AV97Wctitulospropostads_28_tftitulostatus_f = "";
         AV98Wctitulospropostads_29_tftitulostatus_f_sel = "";
         lV71Wctitulospropostads_2_filterfulltext = "";
         lV97Wctitulospropostads_28_tftitulostatus_f = "";
         lV83Wctitulospropostads_14_tfclienterazaosocial = "";
         A648TituloPropostaTipo = "";
         A283TituloTipo = "";
         A170ClienteRazaoSocial = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A282TituloStatus_F = "";
         P00C34_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00C34_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00C34_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00C34_n794NotaFiscalId = new bool[] {false} ;
         P00C34_A168ClienteId = new int[1] ;
         P00C34_n168ClienteId = new bool[] {false} ;
         P00C34_A261TituloId = new int[1] ;
         P00C34_n261TituloId = new bool[] {false} ;
         P00C34_A419TituloPropostaId = new int[1] ;
         P00C34_n419TituloPropostaId = new bool[] {false} ;
         P00C34_A170ClienteRazaoSocial = new string[] {""} ;
         P00C34_n170ClienteRazaoSocial = new bool[] {false} ;
         P00C34_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00C34_n264TituloProrrogacao = new bool[] {false} ;
         P00C34_A276TituloDesconto = new decimal[1] ;
         P00C34_n276TituloDesconto = new bool[] {false} ;
         P00C34_A282TituloStatus_F = new string[] {""} ;
         P00C34_A283TituloTipo = new string[] {""} ;
         P00C34_n283TituloTipo = new bool[] {false} ;
         P00C34_A648TituloPropostaTipo = new string[] {""} ;
         P00C34_n648TituloPropostaTipo = new bool[] {false} ;
         P00C34_A275TituloSaldo_F = new decimal[1] ;
         P00C34_n275TituloSaldo_F = new bool[] {false} ;
         P00C34_A262TituloValor = new decimal[1] ;
         P00C34_n262TituloValor = new bool[] {false} ;
         P00C34_A286TituloCompetenciaAno = new short[1] ;
         P00C34_n286TituloCompetenciaAno = new bool[] {false} ;
         P00C34_A287TituloCompetenciaMes = new short[1] ;
         P00C34_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         AV35Option = "";
         AV37OptionDesc = "";
         P00C37_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00C37_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00C37_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00C37_n794NotaFiscalId = new bool[] {false} ;
         P00C37_A168ClienteId = new int[1] ;
         P00C37_n168ClienteId = new bool[] {false} ;
         P00C37_A261TituloId = new int[1] ;
         P00C37_n261TituloId = new bool[] {false} ;
         P00C37_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00C37_n264TituloProrrogacao = new bool[] {false} ;
         P00C37_A276TituloDesconto = new decimal[1] ;
         P00C37_n276TituloDesconto = new bool[] {false} ;
         P00C37_A282TituloStatus_F = new string[] {""} ;
         P00C37_A283TituloTipo = new string[] {""} ;
         P00C37_n283TituloTipo = new bool[] {false} ;
         P00C37_A648TituloPropostaTipo = new string[] {""} ;
         P00C37_n648TituloPropostaTipo = new bool[] {false} ;
         P00C37_A170ClienteRazaoSocial = new string[] {""} ;
         P00C37_n170ClienteRazaoSocial = new bool[] {false} ;
         P00C37_A419TituloPropostaId = new int[1] ;
         P00C37_n419TituloPropostaId = new bool[] {false} ;
         P00C37_A275TituloSaldo_F = new decimal[1] ;
         P00C37_n275TituloSaldo_F = new bool[] {false} ;
         P00C37_A262TituloValor = new decimal[1] ;
         P00C37_n262TituloValor = new bool[] {false} ;
         P00C37_A286TituloCompetenciaAno = new short[1] ;
         P00C37_n286TituloCompetenciaAno = new bool[] {false} ;
         P00C37_A287TituloCompetenciaMes = new short[1] ;
         P00C37_n287TituloCompetenciaMes = new bool[] {false} ;
         P00C310_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00C310_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00C310_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00C310_n794NotaFiscalId = new bool[] {false} ;
         P00C310_A168ClienteId = new int[1] ;
         P00C310_n168ClienteId = new bool[] {false} ;
         P00C310_A261TituloId = new int[1] ;
         P00C310_n261TituloId = new bool[] {false} ;
         P00C310_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00C310_n264TituloProrrogacao = new bool[] {false} ;
         P00C310_A276TituloDesconto = new decimal[1] ;
         P00C310_n276TituloDesconto = new bool[] {false} ;
         P00C310_A282TituloStatus_F = new string[] {""} ;
         P00C310_A283TituloTipo = new string[] {""} ;
         P00C310_n283TituloTipo = new bool[] {false} ;
         P00C310_A648TituloPropostaTipo = new string[] {""} ;
         P00C310_n648TituloPropostaTipo = new bool[] {false} ;
         P00C310_A170ClienteRazaoSocial = new string[] {""} ;
         P00C310_n170ClienteRazaoSocial = new bool[] {false} ;
         P00C310_A419TituloPropostaId = new int[1] ;
         P00C310_n419TituloPropostaId = new bool[] {false} ;
         P00C310_A275TituloSaldo_F = new decimal[1] ;
         P00C310_n275TituloSaldo_F = new bool[] {false} ;
         P00C310_A262TituloValor = new decimal[1] ;
         P00C310_n262TituloValor = new bool[] {false} ;
         P00C310_A286TituloCompetenciaAno = new short[1] ;
         P00C310_n286TituloCompetenciaAno = new bool[] {false} ;
         P00C310_A287TituloCompetenciaMes = new short[1] ;
         P00C310_n287TituloCompetenciaMes = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wctitulospropostagetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C34_A890NotaFiscalParcelamentoID, P00C34_n890NotaFiscalParcelamentoID, P00C34_A794NotaFiscalId, P00C34_n794NotaFiscalId, P00C34_A168ClienteId, P00C34_n168ClienteId, P00C34_A261TituloId, P00C34_A419TituloPropostaId, P00C34_n419TituloPropostaId, P00C34_A170ClienteRazaoSocial,
               P00C34_n170ClienteRazaoSocial, P00C34_A264TituloProrrogacao, P00C34_n264TituloProrrogacao, P00C34_A276TituloDesconto, P00C34_n276TituloDesconto, P00C34_A282TituloStatus_F, P00C34_A283TituloTipo, P00C34_n283TituloTipo, P00C34_A648TituloPropostaTipo, P00C34_n648TituloPropostaTipo,
               P00C34_A275TituloSaldo_F, P00C34_n275TituloSaldo_F, P00C34_A262TituloValor, P00C34_n262TituloValor, P00C34_A286TituloCompetenciaAno, P00C34_n286TituloCompetenciaAno, P00C34_A287TituloCompetenciaMes, P00C34_n287TituloCompetenciaMes
               }
               , new Object[] {
               P00C37_A890NotaFiscalParcelamentoID, P00C37_n890NotaFiscalParcelamentoID, P00C37_A794NotaFiscalId, P00C37_n794NotaFiscalId, P00C37_A168ClienteId, P00C37_n168ClienteId, P00C37_A261TituloId, P00C37_A264TituloProrrogacao, P00C37_n264TituloProrrogacao, P00C37_A276TituloDesconto,
               P00C37_n276TituloDesconto, P00C37_A282TituloStatus_F, P00C37_A283TituloTipo, P00C37_n283TituloTipo, P00C37_A648TituloPropostaTipo, P00C37_n648TituloPropostaTipo, P00C37_A170ClienteRazaoSocial, P00C37_n170ClienteRazaoSocial, P00C37_A419TituloPropostaId, P00C37_n419TituloPropostaId,
               P00C37_A275TituloSaldo_F, P00C37_n275TituloSaldo_F, P00C37_A262TituloValor, P00C37_n262TituloValor, P00C37_A286TituloCompetenciaAno, P00C37_n286TituloCompetenciaAno, P00C37_A287TituloCompetenciaMes, P00C37_n287TituloCompetenciaMes
               }
               , new Object[] {
               P00C310_A890NotaFiscalParcelamentoID, P00C310_n890NotaFiscalParcelamentoID, P00C310_A794NotaFiscalId, P00C310_n794NotaFiscalId, P00C310_A168ClienteId, P00C310_n168ClienteId, P00C310_A261TituloId, P00C310_A264TituloProrrogacao, P00C310_n264TituloProrrogacao, P00C310_A276TituloDesconto,
               P00C310_n276TituloDesconto, P00C310_A282TituloStatus_F, P00C310_A283TituloTipo, P00C310_n283TituloTipo, P00C310_A648TituloPropostaTipo, P00C310_n648TituloPropostaTipo, P00C310_A170ClienteRazaoSocial, P00C310_n170ClienteRazaoSocial, P00C310_A419TituloPropostaId, P00C310_n419TituloPropostaId,
               P00C310_A275TituloSaldo_F, P00C310_n275TituloSaldo_F, P00C310_A262TituloValor, P00C310_n262TituloValor, P00C310_A286TituloCompetenciaAno, P00C310_n286TituloCompetenciaAno, P00C310_A287TituloCompetenciaMes, P00C310_n287TituloCompetenciaMes
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV33MaxItems ;
      private short AV32PageIndex ;
      private short AV31SkipItems ;
      private short AV65IsUnique ;
      private short AV54DynamicFiltersOperator1 ;
      private short AV58DynamicFiltersOperator2 ;
      private short AV62DynamicFiltersOperator3 ;
      private short AV73Wctitulospropostads_4_dynamicfiltersoperator1 ;
      private short AV77Wctitulospropostads_8_dynamicfiltersoperator2 ;
      private short AV81Wctitulospropostads_12_dynamicfiltersoperator3 ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV68GXV1 ;
      private int AV64TituloPropostaId ;
      private int AV70Wctitulospropostads_1_titulopropostaid ;
      private int AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count ;
      private int AV94Wctitulospropostads_25_tftitulotipo_sels_Count ;
      private int A419TituloPropostaId ;
      private int A168ClienteId ;
      private int A261TituloId ;
      private int AV34InsertIndex ;
      private long AV40count ;
      private decimal AV14TFTituloValor ;
      private decimal AV15TFTituloValor_To ;
      private decimal AV16TFTituloDesconto ;
      private decimal AV17TFTituloDesconto_To ;
      private decimal AV24TFTituloSaldo_F ;
      private decimal AV25TFTituloSaldo_F_To ;
      private decimal AV55TituloValor1 ;
      private decimal AV59TituloValor2 ;
      private decimal AV63TituloValor3 ;
      private decimal AV74Wctitulospropostads_5_titulovalor1 ;
      private decimal AV78Wctitulospropostads_9_titulovalor2 ;
      private decimal AV82Wctitulospropostads_13_titulovalor3 ;
      private decimal AV86Wctitulospropostads_17_tftitulovalor ;
      private decimal AV87Wctitulospropostads_18_tftitulovalor_to ;
      private decimal AV88Wctitulospropostads_19_tftitulodesconto ;
      private decimal AV89Wctitulospropostads_20_tftitulodesconto_to ;
      private decimal AV95Wctitulospropostads_26_tftitulosaldo_f ;
      private decimal AV96Wctitulospropostads_27_tftitulosaldo_f_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A275TituloSaldo_F ;
      private DateTime AV20TFTituloProrrogacao ;
      private DateTime AV21TFTituloProrrogacao_To ;
      private DateTime AV92Wctitulospropostads_23_tftituloprorrogacao ;
      private DateTime AV93Wctitulospropostads_24_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool AV56DynamicFiltersEnabled2 ;
      private bool AV60DynamicFiltersEnabled3 ;
      private bool AV75Wctitulospropostads_6_dynamicfiltersenabled2 ;
      private bool AV79Wctitulospropostads_10_dynamicfiltersenabled3 ;
      private bool BRKC32 ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n261TituloId ;
      private bool n419TituloPropostaId ;
      private bool n170ClienteRazaoSocial ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n283TituloTipo ;
      private bool n648TituloPropostaTipo ;
      private bool n275TituloSaldo_F ;
      private bool n262TituloValor ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private string AV49OptionsJson ;
      private string AV50OptionsDescJson ;
      private string AV51OptionIndexesJson ;
      private string AV66TFTituloPropostaTipo_SelsJson ;
      private string AV22TFTituloTipo_SelsJson ;
      private string AV46DDOName ;
      private string AV47SearchTxtParms ;
      private string AV48SearchTxtTo ;
      private string AV30SearchTxt ;
      private string AV52FilterFullText ;
      private string AV12TFClienteRazaoSocial ;
      private string AV13TFClienteRazaoSocial_Sel ;
      private string AV18TFTituloCompetencia_F ;
      private string AV19TFTituloCompetencia_F_Sel ;
      private string AV28TFTituloStatus_F ;
      private string AV29TFTituloStatus_F_Sel ;
      private string AV53DynamicFiltersSelector1 ;
      private string AV57DynamicFiltersSelector2 ;
      private string AV61DynamicFiltersSelector3 ;
      private string AV71Wctitulospropostads_2_filterfulltext ;
      private string AV72Wctitulospropostads_3_dynamicfiltersselector1 ;
      private string AV76Wctitulospropostads_7_dynamicfiltersselector2 ;
      private string AV80Wctitulospropostads_11_dynamicfiltersselector3 ;
      private string AV83Wctitulospropostads_14_tfclienterazaosocial ;
      private string AV84Wctitulospropostads_15_tfclienterazaosocial_sel ;
      private string AV90Wctitulospropostads_21_tftitulocompetencia_f ;
      private string AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ;
      private string AV97Wctitulospropostads_28_tftitulostatus_f ;
      private string AV98Wctitulospropostads_29_tftitulostatus_f_sel ;
      private string lV71Wctitulospropostads_2_filterfulltext ;
      private string lV97Wctitulospropostads_28_tftitulostatus_f ;
      private string lV83Wctitulospropostads_14_tfclienterazaosocial ;
      private string A648TituloPropostaTipo ;
      private string A283TituloTipo ;
      private string A170ClienteRazaoSocial ;
      private string A295TituloCompetencia_F ;
      private string A282TituloStatus_F ;
      private string AV35Option ;
      private string AV37OptionDesc ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV36Options ;
      private GxSimpleCollection<string> AV38OptionsDesc ;
      private GxSimpleCollection<string> AV39OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GxSimpleCollection<string> AV67TFTituloPropostaTipo_Sels ;
      private GxSimpleCollection<string> AV23TFTituloTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV45GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV85Wctitulospropostads_16_tftitulopropostatipo_sels ;
      private GxSimpleCollection<string> AV94Wctitulospropostads_25_tftitulotipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C34_A890NotaFiscalParcelamentoID ;
      private bool[] P00C34_n890NotaFiscalParcelamentoID ;
      private Guid[] P00C34_A794NotaFiscalId ;
      private bool[] P00C34_n794NotaFiscalId ;
      private int[] P00C34_A168ClienteId ;
      private bool[] P00C34_n168ClienteId ;
      private int[] P00C34_A261TituloId ;
      private bool[] P00C34_n261TituloId ;
      private int[] P00C34_A419TituloPropostaId ;
      private bool[] P00C34_n419TituloPropostaId ;
      private string[] P00C34_A170ClienteRazaoSocial ;
      private bool[] P00C34_n170ClienteRazaoSocial ;
      private DateTime[] P00C34_A264TituloProrrogacao ;
      private bool[] P00C34_n264TituloProrrogacao ;
      private decimal[] P00C34_A276TituloDesconto ;
      private bool[] P00C34_n276TituloDesconto ;
      private string[] P00C34_A282TituloStatus_F ;
      private string[] P00C34_A283TituloTipo ;
      private bool[] P00C34_n283TituloTipo ;
      private string[] P00C34_A648TituloPropostaTipo ;
      private bool[] P00C34_n648TituloPropostaTipo ;
      private decimal[] P00C34_A275TituloSaldo_F ;
      private bool[] P00C34_n275TituloSaldo_F ;
      private decimal[] P00C34_A262TituloValor ;
      private bool[] P00C34_n262TituloValor ;
      private short[] P00C34_A286TituloCompetenciaAno ;
      private bool[] P00C34_n286TituloCompetenciaAno ;
      private short[] P00C34_A287TituloCompetenciaMes ;
      private bool[] P00C34_n287TituloCompetenciaMes ;
      private Guid[] P00C37_A890NotaFiscalParcelamentoID ;
      private bool[] P00C37_n890NotaFiscalParcelamentoID ;
      private Guid[] P00C37_A794NotaFiscalId ;
      private bool[] P00C37_n794NotaFiscalId ;
      private int[] P00C37_A168ClienteId ;
      private bool[] P00C37_n168ClienteId ;
      private int[] P00C37_A261TituloId ;
      private bool[] P00C37_n261TituloId ;
      private DateTime[] P00C37_A264TituloProrrogacao ;
      private bool[] P00C37_n264TituloProrrogacao ;
      private decimal[] P00C37_A276TituloDesconto ;
      private bool[] P00C37_n276TituloDesconto ;
      private string[] P00C37_A282TituloStatus_F ;
      private string[] P00C37_A283TituloTipo ;
      private bool[] P00C37_n283TituloTipo ;
      private string[] P00C37_A648TituloPropostaTipo ;
      private bool[] P00C37_n648TituloPropostaTipo ;
      private string[] P00C37_A170ClienteRazaoSocial ;
      private bool[] P00C37_n170ClienteRazaoSocial ;
      private int[] P00C37_A419TituloPropostaId ;
      private bool[] P00C37_n419TituloPropostaId ;
      private decimal[] P00C37_A275TituloSaldo_F ;
      private bool[] P00C37_n275TituloSaldo_F ;
      private decimal[] P00C37_A262TituloValor ;
      private bool[] P00C37_n262TituloValor ;
      private short[] P00C37_A286TituloCompetenciaAno ;
      private bool[] P00C37_n286TituloCompetenciaAno ;
      private short[] P00C37_A287TituloCompetenciaMes ;
      private bool[] P00C37_n287TituloCompetenciaMes ;
      private Guid[] P00C310_A890NotaFiscalParcelamentoID ;
      private bool[] P00C310_n890NotaFiscalParcelamentoID ;
      private Guid[] P00C310_A794NotaFiscalId ;
      private bool[] P00C310_n794NotaFiscalId ;
      private int[] P00C310_A168ClienteId ;
      private bool[] P00C310_n168ClienteId ;
      private int[] P00C310_A261TituloId ;
      private bool[] P00C310_n261TituloId ;
      private DateTime[] P00C310_A264TituloProrrogacao ;
      private bool[] P00C310_n264TituloProrrogacao ;
      private decimal[] P00C310_A276TituloDesconto ;
      private bool[] P00C310_n276TituloDesconto ;
      private string[] P00C310_A282TituloStatus_F ;
      private string[] P00C310_A283TituloTipo ;
      private bool[] P00C310_n283TituloTipo ;
      private string[] P00C310_A648TituloPropostaTipo ;
      private bool[] P00C310_n648TituloPropostaTipo ;
      private string[] P00C310_A170ClienteRazaoSocial ;
      private bool[] P00C310_n170ClienteRazaoSocial ;
      private int[] P00C310_A419TituloPropostaId ;
      private bool[] P00C310_n419TituloPropostaId ;
      private decimal[] P00C310_A275TituloSaldo_F ;
      private bool[] P00C310_n275TituloSaldo_F ;
      private decimal[] P00C310_A262TituloValor ;
      private bool[] P00C310_n262TituloValor ;
      private short[] P00C310_A286TituloCompetenciaAno ;
      private bool[] P00C310_n286TituloCompetenciaAno ;
      private short[] P00C310_A287TituloCompetenciaMes ;
      private bool[] P00C310_n287TituloCompetenciaMes ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wctitulospropostagetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C34( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV85Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV94Wctitulospropostads_25_tftitulotipo_sels ,
                                             string AV72Wctitulospropostads_3_dynamicfiltersselector1 ,
                                             short AV73Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                             decimal AV74Wctitulospropostads_5_titulovalor1 ,
                                             bool AV75Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                             string AV76Wctitulospropostads_7_dynamicfiltersselector2 ,
                                             short AV77Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                             decimal AV78Wctitulospropostads_9_titulovalor2 ,
                                             bool AV79Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                             string AV80Wctitulospropostads_11_dynamicfiltersselector3 ,
                                             short AV81Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                             decimal AV82Wctitulospropostads_13_titulovalor3 ,
                                             string AV84Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                             string AV83Wctitulospropostads_14_tfclienterazaosocial ,
                                             int AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count ,
                                             decimal AV86Wctitulospropostads_17_tftitulovalor ,
                                             decimal AV87Wctitulospropostads_18_tftitulovalor_to ,
                                             decimal AV88Wctitulospropostads_19_tftitulodesconto ,
                                             decimal AV89Wctitulospropostads_20_tftitulodesconto_to ,
                                             DateTime AV92Wctitulospropostads_23_tftituloprorrogacao ,
                                             DateTime AV93Wctitulospropostads_24_tftituloprorrogacao_to ,
                                             int AV94Wctitulospropostads_25_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV71Wctitulospropostads_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                             string AV90Wctitulospropostads_21_tftitulocompetencia_f ,
                                             decimal AV95Wctitulospropostads_26_tftitulosaldo_f ,
                                             decimal AV96Wctitulospropostads_27_tftitulosaldo_f_to ,
                                             string AV98Wctitulospropostads_29_tftitulostatus_f_sel ,
                                             string AV97Wctitulospropostads_28_tftitulostatus_f ,
                                             int AV70Wctitulospropostads_1_titulopropostaid ,
                                             int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[29];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T3.ClienteId, T1.TituloId, T1.TituloPropostaId, T4.ClienteRazaoSocial, T1.TituloProrrogacao, T1.TituloDesconto, CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T1.TituloPropostaTipo, COALESCE( T5.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) INNER JOIN (SELECT ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV70Wctitulospropostads_1_titulopropostaid)");
         AddWhere(sWhereString, "((:AV95Wctitulospropostads_26_tftitulosaldo_f = 0) or ( COALESCE( T5.TituloSaldo_F, 0) >= :AV95Wctitulospropostads_26_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV96Wctitulospropostads_27_tftitulosaldo_f_to = 0) or ( COALESCE( T5.TituloSaldo_F, 0) <= :AV96Wctitulospropostads_27_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV98Wctitulospropostads_29_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV97Wctitulospropostads_28_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV97Wctitulospropostads_28_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV98Wctitulospropostads_29_tftitulostatus_f_sel))=0) and Not :AV98Wctitulospropostads_29_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV98Wctitulospropostads_29_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV98Wctitulospropostads_29_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wctitulospropostads_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wctitulospropostads_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV83Wctitulospropostads_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wctitulospropostads_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV84Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV84Wctitulospropostads_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Wctitulospropostads_16_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV86Wctitulospropostads_17_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV86Wctitulospropostads_17_tftitulovalor)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wctitulospropostads_18_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV87Wctitulospropostads_18_tftitulovalor_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wctitulospropostads_19_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV88Wctitulospropostads_19_tftitulodesconto)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Wctitulospropostads_20_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV89Wctitulospropostads_20_tftitulodesconto_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wctitulospropostads_23_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV92Wctitulospropostads_23_tftituloprorrogacao)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wctitulospropostads_24_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV93Wctitulospropostads_24_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV94Wctitulospropostads_25_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV94Wctitulospropostads_25_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloPropostaId, T4.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00C37( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV85Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV94Wctitulospropostads_25_tftitulotipo_sels ,
                                             string AV72Wctitulospropostads_3_dynamicfiltersselector1 ,
                                             short AV73Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                             decimal AV74Wctitulospropostads_5_titulovalor1 ,
                                             bool AV75Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                             string AV76Wctitulospropostads_7_dynamicfiltersselector2 ,
                                             short AV77Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                             decimal AV78Wctitulospropostads_9_titulovalor2 ,
                                             bool AV79Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                             string AV80Wctitulospropostads_11_dynamicfiltersselector3 ,
                                             short AV81Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                             decimal AV82Wctitulospropostads_13_titulovalor3 ,
                                             string AV84Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                             string AV83Wctitulospropostads_14_tfclienterazaosocial ,
                                             int AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count ,
                                             decimal AV86Wctitulospropostads_17_tftitulovalor ,
                                             decimal AV87Wctitulospropostads_18_tftitulovalor_to ,
                                             decimal AV88Wctitulospropostads_19_tftitulodesconto ,
                                             decimal AV89Wctitulospropostads_20_tftitulodesconto_to ,
                                             DateTime AV92Wctitulospropostads_23_tftituloprorrogacao ,
                                             DateTime AV93Wctitulospropostads_24_tftituloprorrogacao_to ,
                                             int AV94Wctitulospropostads_25_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV71Wctitulospropostads_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                             string AV90Wctitulospropostads_21_tftitulocompetencia_f ,
                                             decimal AV95Wctitulospropostads_26_tftitulosaldo_f ,
                                             decimal AV96Wctitulospropostads_27_tftitulosaldo_f_to ,
                                             string AV98Wctitulospropostads_29_tftitulostatus_f_sel ,
                                             string AV97Wctitulospropostads_28_tftitulostatus_f ,
                                             int AV70Wctitulospropostads_1_titulopropostaid ,
                                             int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[29];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T3.ClienteId, T1.TituloId, T1.TituloProrrogacao, T1.TituloDesconto, CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T1.TituloPropostaTipo, T4.ClienteRazaoSocial, T1.TituloPropostaId, COALESCE( T5.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) INNER JOIN (SELECT ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV70Wctitulospropostads_1_titulopropostaid)");
         AddWhere(sWhereString, "((:AV95Wctitulospropostads_26_tftitulosaldo_f = 0) or ( COALESCE( T5.TituloSaldo_F, 0) >= :AV95Wctitulospropostads_26_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV96Wctitulospropostads_27_tftitulosaldo_f_to = 0) or ( COALESCE( T5.TituloSaldo_F, 0) <= :AV96Wctitulospropostads_27_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV98Wctitulospropostads_29_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV97Wctitulospropostads_28_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV97Wctitulospropostads_28_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV98Wctitulospropostads_29_tftitulostatus_f_sel))=0) and Not :AV98Wctitulospropostads_29_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV98Wctitulospropostads_29_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV98Wctitulospropostads_29_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wctitulospropostads_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wctitulospropostads_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV83Wctitulospropostads_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wctitulospropostads_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV84Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV84Wctitulospropostads_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Wctitulospropostads_16_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV86Wctitulospropostads_17_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV86Wctitulospropostads_17_tftitulovalor)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wctitulospropostads_18_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV87Wctitulospropostads_18_tftitulovalor_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wctitulospropostads_19_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV88Wctitulospropostads_19_tftitulodesconto)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Wctitulospropostads_20_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV89Wctitulospropostads_20_tftitulodesconto_to)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wctitulospropostads_23_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV92Wctitulospropostads_23_tftituloprorrogacao)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wctitulospropostads_24_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV93Wctitulospropostads_24_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV94Wctitulospropostads_25_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV94Wctitulospropostads_25_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloPropostaId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00C310( IGxContext context ,
                                              string A648TituloPropostaTipo ,
                                              GxSimpleCollection<string> AV85Wctitulospropostads_16_tftitulopropostatipo_sels ,
                                              string A283TituloTipo ,
                                              GxSimpleCollection<string> AV94Wctitulospropostads_25_tftitulotipo_sels ,
                                              string AV72Wctitulospropostads_3_dynamicfiltersselector1 ,
                                              short AV73Wctitulospropostads_4_dynamicfiltersoperator1 ,
                                              decimal AV74Wctitulospropostads_5_titulovalor1 ,
                                              bool AV75Wctitulospropostads_6_dynamicfiltersenabled2 ,
                                              string AV76Wctitulospropostads_7_dynamicfiltersselector2 ,
                                              short AV77Wctitulospropostads_8_dynamicfiltersoperator2 ,
                                              decimal AV78Wctitulospropostads_9_titulovalor2 ,
                                              bool AV79Wctitulospropostads_10_dynamicfiltersenabled3 ,
                                              string AV80Wctitulospropostads_11_dynamicfiltersselector3 ,
                                              short AV81Wctitulospropostads_12_dynamicfiltersoperator3 ,
                                              decimal AV82Wctitulospropostads_13_titulovalor3 ,
                                              string AV84Wctitulospropostads_15_tfclienterazaosocial_sel ,
                                              string AV83Wctitulospropostads_14_tfclienterazaosocial ,
                                              int AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count ,
                                              decimal AV86Wctitulospropostads_17_tftitulovalor ,
                                              decimal AV87Wctitulospropostads_18_tftitulovalor_to ,
                                              decimal AV88Wctitulospropostads_19_tftitulodesconto ,
                                              decimal AV89Wctitulospropostads_20_tftitulodesconto_to ,
                                              DateTime AV92Wctitulospropostads_23_tftituloprorrogacao ,
                                              DateTime AV93Wctitulospropostads_24_tftituloprorrogacao_to ,
                                              int AV94Wctitulospropostads_25_tftitulotipo_sels_Count ,
                                              decimal A262TituloValor ,
                                              string A170ClienteRazaoSocial ,
                                              decimal A276TituloDesconto ,
                                              DateTime A264TituloProrrogacao ,
                                              string AV71Wctitulospropostads_2_filterfulltext ,
                                              string A295TituloCompetencia_F ,
                                              decimal A275TituloSaldo_F ,
                                              string A282TituloStatus_F ,
                                              string AV91Wctitulospropostads_22_tftitulocompetencia_f_sel ,
                                              string AV90Wctitulospropostads_21_tftitulocompetencia_f ,
                                              decimal AV95Wctitulospropostads_26_tftitulosaldo_f ,
                                              decimal AV96Wctitulospropostads_27_tftitulosaldo_f_to ,
                                              string AV98Wctitulospropostads_29_tftitulostatus_f_sel ,
                                              string AV97Wctitulospropostads_28_tftitulostatus_f ,
                                              int AV70Wctitulospropostads_1_titulopropostaid ,
                                              int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[29];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T3.ClienteId, T1.TituloId, T1.TituloProrrogacao, T1.TituloDesconto, CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T1.TituloPropostaTipo, T4.ClienteRazaoSocial, T1.TituloPropostaId, COALESCE( T5.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) INNER JOIN (SELECT ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV70Wctitulospropostads_1_titulopropostaid)");
         AddWhere(sWhereString, "((:AV95Wctitulospropostads_26_tftitulosaldo_f = 0) or ( COALESCE( T5.TituloSaldo_F, 0) >= :AV95Wctitulospropostads_26_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV96Wctitulospropostads_27_tftitulosaldo_f_to = 0) or ( COALESCE( T5.TituloSaldo_F, 0) <= :AV96Wctitulospropostads_27_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV98Wctitulospropostads_29_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV97Wctitulospropostads_28_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV97Wctitulospropostads_28_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV98Wctitulospropostads_29_tftitulostatus_f_sel))=0) and Not :AV98Wctitulospropostads_29_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV98Wctitulospropostads_29_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV98Wctitulospropostads_29_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T5.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T5.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wctitulospropostads_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV73Wctitulospropostads_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV74Wctitulospropostads_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV74Wctitulospropostads_5_titulovalor1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV75Wctitulospropostads_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wctitulospropostads_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV77Wctitulospropostads_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV78Wctitulospropostads_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV78Wctitulospropostads_9_titulovalor2)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV79Wctitulospropostads_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Wctitulospropostads_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV81Wctitulospropostads_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV82Wctitulospropostads_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV82Wctitulospropostads_13_titulovalor3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wctitulospropostads_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wctitulospropostads_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV83Wctitulospropostads_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wctitulospropostads_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV84Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV84Wctitulospropostads_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wctitulospropostads_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( AV85Wctitulospropostads_16_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Wctitulospropostads_16_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV86Wctitulospropostads_17_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV86Wctitulospropostads_17_tftitulovalor)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Wctitulospropostads_18_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV87Wctitulospropostads_18_tftitulovalor_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Wctitulospropostads_19_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV88Wctitulospropostads_19_tftitulodesconto)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Wctitulospropostads_20_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV89Wctitulospropostads_20_tftitulodesconto_to)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wctitulospropostads_23_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV92Wctitulospropostads_23_tftituloprorrogacao)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wctitulospropostads_24_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV93Wctitulospropostads_24_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( AV94Wctitulospropostads_25_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV94Wctitulospropostads_25_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloPropostaId";
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
                     return conditional_P00C34(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (int)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] );
               case 1 :
                     return conditional_P00C37(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (int)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] );
               case 2 :
                     return conditional_P00C310(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (int)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] );
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
          Object[] prmP00C34;
          prmP00C34 = new Object[] {
          new ParDef("AV70Wctitulospropostads_1_titulopropostaid",GXType.Int32,9,0) ,
          new ParDef("AV95Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV95Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV96Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV96Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV97Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV97Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("lV83Wctitulospropostads_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV84Wctitulospropostads_15_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV86Wctitulospropostads_17_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV87Wctitulospropostads_18_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Wctitulospropostads_19_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV89Wctitulospropostads_20_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_23_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV93Wctitulospropostads_24_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          Object[] prmP00C37;
          prmP00C37 = new Object[] {
          new ParDef("AV70Wctitulospropostads_1_titulopropostaid",GXType.Int32,9,0) ,
          new ParDef("AV95Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV95Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV96Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV96Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV97Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV97Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("lV83Wctitulospropostads_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV84Wctitulospropostads_15_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV86Wctitulospropostads_17_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV87Wctitulospropostads_18_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Wctitulospropostads_19_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV89Wctitulospropostads_20_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_23_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV93Wctitulospropostads_24_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          Object[] prmP00C310;
          prmP00C310 = new Object[] {
          new ParDef("AV70Wctitulospropostads_1_titulopropostaid",GXType.Int32,9,0) ,
          new ParDef("AV95Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV95Wctitulospropostads_26_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV96Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV96Wctitulospropostads_27_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV97Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV97Wctitulospropostads_28_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV98Wctitulospropostads_29_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV74Wctitulospropostads_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV78Wctitulospropostads_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV82Wctitulospropostads_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("lV83Wctitulospropostads_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV84Wctitulospropostads_15_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV86Wctitulospropostads_17_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV87Wctitulospropostads_18_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Wctitulospropostads_19_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV89Wctitulospropostads_20_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV92Wctitulospropostads_23_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV93Wctitulospropostads_24_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C34", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C34,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C37", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C37,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C310", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C310,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((string[]) buf[18])[0] = rslt.getVarchar(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((short[]) buf[24])[0] = rslt.getShort(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((short[]) buf[26])[0] = rslt.getShort(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((short[]) buf[24])[0] = rslt.getShort(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((short[]) buf[26])[0] = rslt.getShort(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((short[]) buf[24])[0] = rslt.getShort(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((short[]) buf[26])[0] = rslt.getShort(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                return;
       }
    }

 }

}
