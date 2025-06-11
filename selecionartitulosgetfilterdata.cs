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
   public class selecionartitulosgetfilterdata : GXProcedure
   {
      public selecionartitulosgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public selecionartitulosgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_TITULOCLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_TITULOPROPOSTADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOPROPOSTADESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALNUMEROOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV33Session.Get("SelecionarTitulosGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SelecionarTitulosGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("SelecionarTitulosGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFTituloCLienteRazaoSocial = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFTituloCLienteRazaoSocial_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV12TFTituloValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV13TFTituloValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV14TFTituloDesconto = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV15TFTituloDesconto_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV16TFTituloProrrogacao = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV17TFTituloProrrogacao_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO") == 0 )
            {
               AV18TFTituloPropostaDescricao = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV19TFTituloPropostaDescricao_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV20TFNotaFiscalNumero = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV21TFNotaFiscalNumero_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&CARTEIRADECOBRANCAID") == 0 )
            {
               AV45CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTITULOCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFTituloCLienteRazaoSocial = AV22SearchTxt;
         AV11TFTituloCLienteRazaoSocial_Sel = "";
         AV48Selecionartitulosds_1_filterfulltext = AV44FilterFullText;
         AV49Selecionartitulosds_2_tftituloclienterazaosocial = AV10TFTituloCLienteRazaoSocial;
         AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV11TFTituloCLienteRazaoSocial_Sel;
         AV51Selecionartitulosds_4_tftitulovalor = AV12TFTituloValor;
         AV52Selecionartitulosds_5_tftitulovalor_to = AV13TFTituloValor_To;
         AV53Selecionartitulosds_6_tftitulodesconto = AV14TFTituloDesconto;
         AV54Selecionartitulosds_7_tftitulodesconto_to = AV15TFTituloDesconto_To;
         AV55Selecionartitulosds_8_tftituloprorrogacao = AV16TFTituloProrrogacao;
         AV56Selecionartitulosds_9_tftituloprorrogacao_to = AV17TFTituloProrrogacao_To;
         AV57Selecionartitulosds_10_tftitulopropostadescricao = AV18TFTituloPropostaDescricao;
         AV58Selecionartitulosds_11_tftitulopropostadescricao_sel = AV19TFTituloPropostaDescricao_Sel;
         AV59Selecionartitulosds_12_tfnotafiscalnumero = AV20TFNotaFiscalNumero;
         AV60Selecionartitulosds_13_tfnotafiscalnumero_sel = AV21TFNotaFiscalNumero_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Selecionartitulosds_1_filterfulltext ,
                                              AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              AV49Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              AV51Selecionartitulosds_4_tftitulovalor ,
                                              AV52Selecionartitulosds_5_tftitulovalor_to ,
                                              AV53Selecionartitulosds_6_tftitulodesconto ,
                                              AV54Selecionartitulosds_7_tftitulodesconto_to ,
                                              AV55Selecionartitulosds_8_tftituloprorrogacao ,
                                              AV56Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              AV57Selecionartitulosds_10_tftitulopropostadescricao ,
                                              AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              AV59Selecionartitulosds_12_tfnotafiscalnumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A262TituloValor ,
                                              A276TituloDesconto ,
                                              A971TituloPropostaDescricao ,
                                              A799NotaFiscalNumero ,
                                              A264TituloProrrogacao ,
                                              A1118TitulosEmCarteiraDeCobranca_F ,
                                              A261TituloId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV49Selecionartitulosds_2_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV49Selecionartitulosds_2_tftituloclienterazaosocial), "%", "");
         lV57Selecionartitulosds_10_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV57Selecionartitulosds_10_tftitulopropostadescricao), "%", "");
         lV59Selecionartitulosds_12_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV59Selecionartitulosds_12_tfnotafiscalnumero), "%", "");
         /* Using cursor P00FQ2 */
         pr_default.execute(0, new Object[] {lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV49Selecionartitulosds_2_tftituloclienterazaosocial, AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, AV51Selecionartitulosds_4_tftitulovalor, AV52Selecionartitulosds_5_tftitulovalor_to, AV53Selecionartitulosds_6_tftitulodesconto, AV54Selecionartitulosds_7_tftitulodesconto_to, AV55Selecionartitulosds_8_tftituloprorrogacao, AV56Selecionartitulosds_9_tftituloprorrogacao_to, lV57Selecionartitulosds_10_tftitulopropostadescricao, AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, lV59Selecionartitulosds_12_tfnotafiscalnumero, AV60Selecionartitulosds_13_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFQ2 = false;
            A890NotaFiscalParcelamentoID = P00FQ2_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00FQ2_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00FQ2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00FQ2_n794NotaFiscalId[0];
            A419TituloPropostaId = P00FQ2_A419TituloPropostaId[0];
            n419TituloPropostaId = P00FQ2_n419TituloPropostaId[0];
            A420TituloClienteId = P00FQ2_A420TituloClienteId[0];
            n420TituloClienteId = P00FQ2_n420TituloClienteId[0];
            A972TituloCLienteRazaoSocial = P00FQ2_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00FQ2_n972TituloCLienteRazaoSocial[0];
            A264TituloProrrogacao = P00FQ2_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00FQ2_n264TituloProrrogacao[0];
            A276TituloDesconto = P00FQ2_A276TituloDesconto[0];
            n276TituloDesconto = P00FQ2_n276TituloDesconto[0];
            A262TituloValor = P00FQ2_A262TituloValor[0];
            n262TituloValor = P00FQ2_n262TituloValor[0];
            A799NotaFiscalNumero = P00FQ2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00FQ2_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00FQ2_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00FQ2_n971TituloPropostaDescricao[0];
            A261TituloId = P00FQ2_A261TituloId[0];
            n261TituloId = P00FQ2_n261TituloId[0];
            A794NotaFiscalId = P00FQ2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00FQ2_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00FQ2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00FQ2_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00FQ2_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00FQ2_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00FQ2_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00FQ2_n972TituloCLienteRazaoSocial[0];
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            if ( ! A1118TitulosEmCarteiraDeCobranca_F )
            {
               AV32count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00FQ2_A972TituloCLienteRazaoSocial[0], A972TituloCLienteRazaoSocial) == 0 ) )
               {
                  BRKFQ2 = false;
                  A420TituloClienteId = P00FQ2_A420TituloClienteId[0];
                  n420TituloClienteId = P00FQ2_n420TituloClienteId[0];
                  A261TituloId = P00FQ2_A261TituloId[0];
                  n261TituloId = P00FQ2_n261TituloId[0];
                  AV32count = (long)(AV32count+1);
                  BRKFQ2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV23SkipItems) )
               {
                  AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A972TituloCLienteRazaoSocial)) ? "<#Empty#>" : A972TituloCLienteRazaoSocial);
                  AV28Options.Add(AV27Option, 0);
                  AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV28Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV23SkipItems = (short)(AV23SkipItems-1);
               }
            }
            if ( ! BRKFQ2 )
            {
               BRKFQ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTITULOPROPOSTADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV18TFTituloPropostaDescricao = AV22SearchTxt;
         AV19TFTituloPropostaDescricao_Sel = "";
         AV48Selecionartitulosds_1_filterfulltext = AV44FilterFullText;
         AV49Selecionartitulosds_2_tftituloclienterazaosocial = AV10TFTituloCLienteRazaoSocial;
         AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV11TFTituloCLienteRazaoSocial_Sel;
         AV51Selecionartitulosds_4_tftitulovalor = AV12TFTituloValor;
         AV52Selecionartitulosds_5_tftitulovalor_to = AV13TFTituloValor_To;
         AV53Selecionartitulosds_6_tftitulodesconto = AV14TFTituloDesconto;
         AV54Selecionartitulosds_7_tftitulodesconto_to = AV15TFTituloDesconto_To;
         AV55Selecionartitulosds_8_tftituloprorrogacao = AV16TFTituloProrrogacao;
         AV56Selecionartitulosds_9_tftituloprorrogacao_to = AV17TFTituloProrrogacao_To;
         AV57Selecionartitulosds_10_tftitulopropostadescricao = AV18TFTituloPropostaDescricao;
         AV58Selecionartitulosds_11_tftitulopropostadescricao_sel = AV19TFTituloPropostaDescricao_Sel;
         AV59Selecionartitulosds_12_tfnotafiscalnumero = AV20TFNotaFiscalNumero;
         AV60Selecionartitulosds_13_tfnotafiscalnumero_sel = AV21TFNotaFiscalNumero_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Selecionartitulosds_1_filterfulltext ,
                                              AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              AV49Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              AV51Selecionartitulosds_4_tftitulovalor ,
                                              AV52Selecionartitulosds_5_tftitulovalor_to ,
                                              AV53Selecionartitulosds_6_tftitulodesconto ,
                                              AV54Selecionartitulosds_7_tftitulodesconto_to ,
                                              AV55Selecionartitulosds_8_tftituloprorrogacao ,
                                              AV56Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              AV57Selecionartitulosds_10_tftitulopropostadescricao ,
                                              AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              AV59Selecionartitulosds_12_tfnotafiscalnumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A262TituloValor ,
                                              A276TituloDesconto ,
                                              A971TituloPropostaDescricao ,
                                              A799NotaFiscalNumero ,
                                              A264TituloProrrogacao ,
                                              A1118TitulosEmCarteiraDeCobranca_F ,
                                              A261TituloId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV49Selecionartitulosds_2_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV49Selecionartitulosds_2_tftituloclienterazaosocial), "%", "");
         lV57Selecionartitulosds_10_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV57Selecionartitulosds_10_tftitulopropostadescricao), "%", "");
         lV59Selecionartitulosds_12_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV59Selecionartitulosds_12_tfnotafiscalnumero), "%", "");
         /* Using cursor P00FQ3 */
         pr_default.execute(1, new Object[] {lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV49Selecionartitulosds_2_tftituloclienterazaosocial, AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, AV51Selecionartitulosds_4_tftitulovalor, AV52Selecionartitulosds_5_tftitulovalor_to, AV53Selecionartitulosds_6_tftitulodesconto, AV54Selecionartitulosds_7_tftitulodesconto_to, AV55Selecionartitulosds_8_tftituloprorrogacao, AV56Selecionartitulosds_9_tftituloprorrogacao_to, lV57Selecionartitulosds_10_tftitulopropostadescricao, AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, lV59Selecionartitulosds_12_tfnotafiscalnumero, AV60Selecionartitulosds_13_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKFQ4 = false;
            A890NotaFiscalParcelamentoID = P00FQ3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00FQ3_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00FQ3_A794NotaFiscalId[0];
            n794NotaFiscalId = P00FQ3_n794NotaFiscalId[0];
            A419TituloPropostaId = P00FQ3_A419TituloPropostaId[0];
            n419TituloPropostaId = P00FQ3_n419TituloPropostaId[0];
            A420TituloClienteId = P00FQ3_A420TituloClienteId[0];
            n420TituloClienteId = P00FQ3_n420TituloClienteId[0];
            A971TituloPropostaDescricao = P00FQ3_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00FQ3_n971TituloPropostaDescricao[0];
            A264TituloProrrogacao = P00FQ3_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00FQ3_n264TituloProrrogacao[0];
            A276TituloDesconto = P00FQ3_A276TituloDesconto[0];
            n276TituloDesconto = P00FQ3_n276TituloDesconto[0];
            A262TituloValor = P00FQ3_A262TituloValor[0];
            n262TituloValor = P00FQ3_n262TituloValor[0];
            A799NotaFiscalNumero = P00FQ3_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00FQ3_n799NotaFiscalNumero[0];
            A972TituloCLienteRazaoSocial = P00FQ3_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00FQ3_n972TituloCLienteRazaoSocial[0];
            A261TituloId = P00FQ3_A261TituloId[0];
            n261TituloId = P00FQ3_n261TituloId[0];
            A794NotaFiscalId = P00FQ3_A794NotaFiscalId[0];
            n794NotaFiscalId = P00FQ3_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00FQ3_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00FQ3_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00FQ3_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00FQ3_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00FQ3_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00FQ3_n972TituloCLienteRazaoSocial[0];
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            if ( ! A1118TitulosEmCarteiraDeCobranca_F )
            {
               AV32count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00FQ3_A971TituloPropostaDescricao[0], A971TituloPropostaDescricao) == 0 ) )
               {
                  BRKFQ4 = false;
                  A419TituloPropostaId = P00FQ3_A419TituloPropostaId[0];
                  n419TituloPropostaId = P00FQ3_n419TituloPropostaId[0];
                  A261TituloId = P00FQ3_A261TituloId[0];
                  n261TituloId = P00FQ3_n261TituloId[0];
                  AV32count = (long)(AV32count+1);
                  BRKFQ4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV23SkipItems) )
               {
                  AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A971TituloPropostaDescricao)) ? "<#Empty#>" : A971TituloPropostaDescricao);
                  AV28Options.Add(AV27Option, 0);
                  AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV28Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV23SkipItems = (short)(AV23SkipItems-1);
               }
            }
            if ( ! BRKFQ4 )
            {
               BRKFQ4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADNOTAFISCALNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV20TFNotaFiscalNumero = AV22SearchTxt;
         AV21TFNotaFiscalNumero_Sel = "";
         AV48Selecionartitulosds_1_filterfulltext = AV44FilterFullText;
         AV49Selecionartitulosds_2_tftituloclienterazaosocial = AV10TFTituloCLienteRazaoSocial;
         AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel = AV11TFTituloCLienteRazaoSocial_Sel;
         AV51Selecionartitulosds_4_tftitulovalor = AV12TFTituloValor;
         AV52Selecionartitulosds_5_tftitulovalor_to = AV13TFTituloValor_To;
         AV53Selecionartitulosds_6_tftitulodesconto = AV14TFTituloDesconto;
         AV54Selecionartitulosds_7_tftitulodesconto_to = AV15TFTituloDesconto_To;
         AV55Selecionartitulosds_8_tftituloprorrogacao = AV16TFTituloProrrogacao;
         AV56Selecionartitulosds_9_tftituloprorrogacao_to = AV17TFTituloProrrogacao_To;
         AV57Selecionartitulosds_10_tftitulopropostadescricao = AV18TFTituloPropostaDescricao;
         AV58Selecionartitulosds_11_tftitulopropostadescricao_sel = AV19TFTituloPropostaDescricao_Sel;
         AV59Selecionartitulosds_12_tfnotafiscalnumero = AV20TFNotaFiscalNumero;
         AV60Selecionartitulosds_13_tfnotafiscalnumero_sel = AV21TFNotaFiscalNumero_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV48Selecionartitulosds_1_filterfulltext ,
                                              AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                              AV49Selecionartitulosds_2_tftituloclienterazaosocial ,
                                              AV51Selecionartitulosds_4_tftitulovalor ,
                                              AV52Selecionartitulosds_5_tftitulovalor_to ,
                                              AV53Selecionartitulosds_6_tftitulodesconto ,
                                              AV54Selecionartitulosds_7_tftitulodesconto_to ,
                                              AV55Selecionartitulosds_8_tftituloprorrogacao ,
                                              AV56Selecionartitulosds_9_tftituloprorrogacao_to ,
                                              AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                              AV57Selecionartitulosds_10_tftitulopropostadescricao ,
                                              AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                              AV59Selecionartitulosds_12_tfnotafiscalnumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A262TituloValor ,
                                              A276TituloDesconto ,
                                              A971TituloPropostaDescricao ,
                                              A799NotaFiscalNumero ,
                                              A264TituloProrrogacao ,
                                              A1118TitulosEmCarteiraDeCobranca_F ,
                                              A261TituloId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV48Selecionartitulosds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext), "%", "");
         lV49Selecionartitulosds_2_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV49Selecionartitulosds_2_tftituloclienterazaosocial), "%", "");
         lV57Selecionartitulosds_10_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV57Selecionartitulosds_10_tftitulopropostadescricao), "%", "");
         lV59Selecionartitulosds_12_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV59Selecionartitulosds_12_tfnotafiscalnumero), "%", "");
         /* Using cursor P00FQ4 */
         pr_default.execute(2, new Object[] {lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV48Selecionartitulosds_1_filterfulltext, lV49Selecionartitulosds_2_tftituloclienterazaosocial, AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, AV51Selecionartitulosds_4_tftitulovalor, AV52Selecionartitulosds_5_tftitulovalor_to, AV53Selecionartitulosds_6_tftitulodesconto, AV54Selecionartitulosds_7_tftitulodesconto_to, AV55Selecionartitulosds_8_tftituloprorrogacao, AV56Selecionartitulosds_9_tftituloprorrogacao_to, lV57Selecionartitulosds_10_tftitulopropostadescricao, AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, lV59Selecionartitulosds_12_tfnotafiscalnumero, AV60Selecionartitulosds_13_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKFQ6 = false;
            A890NotaFiscalParcelamentoID = P00FQ4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00FQ4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00FQ4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00FQ4_n794NotaFiscalId[0];
            A419TituloPropostaId = P00FQ4_A419TituloPropostaId[0];
            n419TituloPropostaId = P00FQ4_n419TituloPropostaId[0];
            A420TituloClienteId = P00FQ4_A420TituloClienteId[0];
            n420TituloClienteId = P00FQ4_n420TituloClienteId[0];
            A799NotaFiscalNumero = P00FQ4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00FQ4_n799NotaFiscalNumero[0];
            A264TituloProrrogacao = P00FQ4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00FQ4_n264TituloProrrogacao[0];
            A276TituloDesconto = P00FQ4_A276TituloDesconto[0];
            n276TituloDesconto = P00FQ4_n276TituloDesconto[0];
            A262TituloValor = P00FQ4_A262TituloValor[0];
            n262TituloValor = P00FQ4_n262TituloValor[0];
            A971TituloPropostaDescricao = P00FQ4_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00FQ4_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00FQ4_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00FQ4_n972TituloCLienteRazaoSocial[0];
            A261TituloId = P00FQ4_A261TituloId[0];
            n261TituloId = P00FQ4_n261TituloId[0];
            A794NotaFiscalId = P00FQ4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00FQ4_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00FQ4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00FQ4_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00FQ4_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00FQ4_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00FQ4_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00FQ4_n972TituloCLienteRazaoSocial[0];
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            if ( ! A1118TitulosEmCarteiraDeCobranca_F )
            {
               AV32count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00FQ4_A799NotaFiscalNumero[0], A799NotaFiscalNumero) == 0 ) )
               {
                  BRKFQ6 = false;
                  A890NotaFiscalParcelamentoID = P00FQ4_A890NotaFiscalParcelamentoID[0];
                  n890NotaFiscalParcelamentoID = P00FQ4_n890NotaFiscalParcelamentoID[0];
                  A794NotaFiscalId = P00FQ4_A794NotaFiscalId[0];
                  n794NotaFiscalId = P00FQ4_n794NotaFiscalId[0];
                  A261TituloId = P00FQ4_A261TituloId[0];
                  n261TituloId = P00FQ4_n261TituloId[0];
                  A794NotaFiscalId = P00FQ4_A794NotaFiscalId[0];
                  n794NotaFiscalId = P00FQ4_n794NotaFiscalId[0];
                  AV32count = (long)(AV32count+1);
                  BRKFQ6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV23SkipItems) )
               {
                  AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? "<#Empty#>" : A799NotaFiscalNumero);
                  AV28Options.Add(AV27Option, 0);
                  AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV28Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV23SkipItems = (short)(AV23SkipItems-1);
               }
            }
            if ( ! BRKFQ6 )
            {
               BRKFQ6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected int GetTitulosEmCarteiraDeCobranca_F0( int E261TituloId )
      {
         Gx_cnt = 0;
         /* Using cursor P00FQ5 */
         pr_default.execute(3, new Object[] {nA261TituloId, E261TituloId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            Gx_cnt = P00FQ5_Gx_cnt[0];
         }
         pr_default.close(3);
         return Gx_cnt ;
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
         AV10TFTituloCLienteRazaoSocial = "";
         AV11TFTituloCLienteRazaoSocial_Sel = "";
         AV16TFTituloProrrogacao = DateTime.MinValue;
         AV17TFTituloProrrogacao_To = DateTime.MinValue;
         AV18TFTituloPropostaDescricao = "";
         AV19TFTituloPropostaDescricao_Sel = "";
         AV20TFNotaFiscalNumero = "";
         AV21TFNotaFiscalNumero_Sel = "";
         AV48Selecionartitulosds_1_filterfulltext = "";
         AV49Selecionartitulosds_2_tftituloclienterazaosocial = "";
         AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel = "";
         AV55Selecionartitulosds_8_tftituloprorrogacao = DateTime.MinValue;
         AV56Selecionartitulosds_9_tftituloprorrogacao_to = DateTime.MinValue;
         AV57Selecionartitulosds_10_tftitulopropostadescricao = "";
         AV58Selecionartitulosds_11_tftitulopropostadescricao_sel = "";
         AV59Selecionartitulosds_12_tfnotafiscalnumero = "";
         AV60Selecionartitulosds_13_tfnotafiscalnumero_sel = "";
         lV48Selecionartitulosds_1_filterfulltext = "";
         lV49Selecionartitulosds_2_tftituloclienterazaosocial = "";
         lV57Selecionartitulosds_10_tftitulopropostadescricao = "";
         lV59Selecionartitulosds_12_tfnotafiscalnumero = "";
         A972TituloCLienteRazaoSocial = "";
         A971TituloPropostaDescricao = "";
         A799NotaFiscalNumero = "";
         A264TituloProrrogacao = DateTime.MinValue;
         P00FQ2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00FQ2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00FQ2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00FQ2_n794NotaFiscalId = new bool[] {false} ;
         P00FQ2_A419TituloPropostaId = new int[1] ;
         P00FQ2_n419TituloPropostaId = new bool[] {false} ;
         P00FQ2_A420TituloClienteId = new int[1] ;
         P00FQ2_n420TituloClienteId = new bool[] {false} ;
         P00FQ2_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00FQ2_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00FQ2_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00FQ2_n264TituloProrrogacao = new bool[] {false} ;
         P00FQ2_A276TituloDesconto = new decimal[1] ;
         P00FQ2_n276TituloDesconto = new bool[] {false} ;
         P00FQ2_A262TituloValor = new decimal[1] ;
         P00FQ2_n262TituloValor = new bool[] {false} ;
         P00FQ2_A799NotaFiscalNumero = new string[] {""} ;
         P00FQ2_n799NotaFiscalNumero = new bool[] {false} ;
         P00FQ2_A971TituloPropostaDescricao = new string[] {""} ;
         P00FQ2_n971TituloPropostaDescricao = new bool[] {false} ;
         P00FQ2_A261TituloId = new int[1] ;
         P00FQ2_n261TituloId = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         AV27Option = "";
         P00FQ3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00FQ3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00FQ3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00FQ3_n794NotaFiscalId = new bool[] {false} ;
         P00FQ3_A419TituloPropostaId = new int[1] ;
         P00FQ3_n419TituloPropostaId = new bool[] {false} ;
         P00FQ3_A420TituloClienteId = new int[1] ;
         P00FQ3_n420TituloClienteId = new bool[] {false} ;
         P00FQ3_A971TituloPropostaDescricao = new string[] {""} ;
         P00FQ3_n971TituloPropostaDescricao = new bool[] {false} ;
         P00FQ3_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00FQ3_n264TituloProrrogacao = new bool[] {false} ;
         P00FQ3_A276TituloDesconto = new decimal[1] ;
         P00FQ3_n276TituloDesconto = new bool[] {false} ;
         P00FQ3_A262TituloValor = new decimal[1] ;
         P00FQ3_n262TituloValor = new bool[] {false} ;
         P00FQ3_A799NotaFiscalNumero = new string[] {""} ;
         P00FQ3_n799NotaFiscalNumero = new bool[] {false} ;
         P00FQ3_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00FQ3_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00FQ3_A261TituloId = new int[1] ;
         P00FQ3_n261TituloId = new bool[] {false} ;
         P00FQ4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00FQ4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00FQ4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00FQ4_n794NotaFiscalId = new bool[] {false} ;
         P00FQ4_A419TituloPropostaId = new int[1] ;
         P00FQ4_n419TituloPropostaId = new bool[] {false} ;
         P00FQ4_A420TituloClienteId = new int[1] ;
         P00FQ4_n420TituloClienteId = new bool[] {false} ;
         P00FQ4_A799NotaFiscalNumero = new string[] {""} ;
         P00FQ4_n799NotaFiscalNumero = new bool[] {false} ;
         P00FQ4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00FQ4_n264TituloProrrogacao = new bool[] {false} ;
         P00FQ4_A276TituloDesconto = new decimal[1] ;
         P00FQ4_n276TituloDesconto = new bool[] {false} ;
         P00FQ4_A262TituloValor = new decimal[1] ;
         P00FQ4_n262TituloValor = new bool[] {false} ;
         P00FQ4_A971TituloPropostaDescricao = new string[] {""} ;
         P00FQ4_n971TituloPropostaDescricao = new bool[] {false} ;
         P00FQ4_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00FQ4_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00FQ4_A261TituloId = new int[1] ;
         P00FQ4_n261TituloId = new bool[] {false} ;
         P00FQ5_Gx_cnt = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.selecionartitulosgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00FQ2_A890NotaFiscalParcelamentoID, P00FQ2_n890NotaFiscalParcelamentoID, P00FQ2_A794NotaFiscalId, P00FQ2_n794NotaFiscalId, P00FQ2_A419TituloPropostaId, P00FQ2_n419TituloPropostaId, P00FQ2_A420TituloClienteId, P00FQ2_n420TituloClienteId, P00FQ2_A972TituloCLienteRazaoSocial, P00FQ2_n972TituloCLienteRazaoSocial,
               P00FQ2_A264TituloProrrogacao, P00FQ2_n264TituloProrrogacao, P00FQ2_A276TituloDesconto, P00FQ2_n276TituloDesconto, P00FQ2_A262TituloValor, P00FQ2_n262TituloValor, P00FQ2_A799NotaFiscalNumero, P00FQ2_n799NotaFiscalNumero, P00FQ2_A971TituloPropostaDescricao, P00FQ2_n971TituloPropostaDescricao,
               P00FQ2_A261TituloId
               }
               , new Object[] {
               P00FQ3_A890NotaFiscalParcelamentoID, P00FQ3_n890NotaFiscalParcelamentoID, P00FQ3_A794NotaFiscalId, P00FQ3_n794NotaFiscalId, P00FQ3_A419TituloPropostaId, P00FQ3_n419TituloPropostaId, P00FQ3_A420TituloClienteId, P00FQ3_n420TituloClienteId, P00FQ3_A971TituloPropostaDescricao, P00FQ3_n971TituloPropostaDescricao,
               P00FQ3_A264TituloProrrogacao, P00FQ3_n264TituloProrrogacao, P00FQ3_A276TituloDesconto, P00FQ3_n276TituloDesconto, P00FQ3_A262TituloValor, P00FQ3_n262TituloValor, P00FQ3_A799NotaFiscalNumero, P00FQ3_n799NotaFiscalNumero, P00FQ3_A972TituloCLienteRazaoSocial, P00FQ3_n972TituloCLienteRazaoSocial,
               P00FQ3_A261TituloId
               }
               , new Object[] {
               P00FQ4_A890NotaFiscalParcelamentoID, P00FQ4_n890NotaFiscalParcelamentoID, P00FQ4_A794NotaFiscalId, P00FQ4_n794NotaFiscalId, P00FQ4_A419TituloPropostaId, P00FQ4_n419TituloPropostaId, P00FQ4_A420TituloClienteId, P00FQ4_n420TituloClienteId, P00FQ4_A799NotaFiscalNumero, P00FQ4_n799NotaFiscalNumero,
               P00FQ4_A264TituloProrrogacao, P00FQ4_n264TituloProrrogacao, P00FQ4_A276TituloDesconto, P00FQ4_n276TituloDesconto, P00FQ4_A262TituloValor, P00FQ4_n262TituloValor, P00FQ4_A971TituloPropostaDescricao, P00FQ4_n971TituloPropostaDescricao, P00FQ4_A972TituloCLienteRazaoSocial, P00FQ4_n972TituloCLienteRazaoSocial,
               P00FQ4_A261TituloId
               }
               , new Object[] {
               P00FQ5_Gx_cnt
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private int AV46GXV1 ;
      private int AV45CarteiraDeCobrancaId ;
      private int A261TituloId ;
      private int A419TituloPropostaId ;
      private int A420TituloClienteId ;
      private int Gx_cnt ;
      private int E261TituloId ;
      private long AV32count ;
      private decimal AV12TFTituloValor ;
      private decimal AV13TFTituloValor_To ;
      private decimal AV14TFTituloDesconto ;
      private decimal AV15TFTituloDesconto_To ;
      private decimal AV51Selecionartitulosds_4_tftitulovalor ;
      private decimal AV52Selecionartitulosds_5_tftitulovalor_to ;
      private decimal AV53Selecionartitulosds_6_tftitulodesconto ;
      private decimal AV54Selecionartitulosds_7_tftitulodesconto_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private DateTime AV16TFTituloProrrogacao ;
      private DateTime AV17TFTituloProrrogacao_To ;
      private DateTime AV55Selecionartitulosds_8_tftituloprorrogacao ;
      private DateTime AV56Selecionartitulosds_9_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool A1118TitulosEmCarteiraDeCobranca_F ;
      private bool BRKFQ2 ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n419TituloPropostaId ;
      private bool n420TituloClienteId ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n262TituloValor ;
      private bool n799NotaFiscalNumero ;
      private bool n971TituloPropostaDescricao ;
      private bool n261TituloId ;
      private bool BRKFQ4 ;
      private bool BRKFQ6 ;
      private bool nA261TituloId ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV10TFTituloCLienteRazaoSocial ;
      private string AV11TFTituloCLienteRazaoSocial_Sel ;
      private string AV18TFTituloPropostaDescricao ;
      private string AV19TFTituloPropostaDescricao_Sel ;
      private string AV20TFNotaFiscalNumero ;
      private string AV21TFNotaFiscalNumero_Sel ;
      private string AV48Selecionartitulosds_1_filterfulltext ;
      private string AV49Selecionartitulosds_2_tftituloclienterazaosocial ;
      private string AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ;
      private string AV57Selecionartitulosds_10_tftitulopropostadescricao ;
      private string AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ;
      private string AV59Selecionartitulosds_12_tfnotafiscalnumero ;
      private string AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ;
      private string lV48Selecionartitulosds_1_filterfulltext ;
      private string lV49Selecionartitulosds_2_tftituloclienterazaosocial ;
      private string lV57Selecionartitulosds_10_tftitulopropostadescricao ;
      private string lV59Selecionartitulosds_12_tfnotafiscalnumero ;
      private string A972TituloCLienteRazaoSocial ;
      private string A971TituloPropostaDescricao ;
      private string A799NotaFiscalNumero ;
      private string AV27Option ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00FQ2_A890NotaFiscalParcelamentoID ;
      private bool[] P00FQ2_n890NotaFiscalParcelamentoID ;
      private Guid[] P00FQ2_A794NotaFiscalId ;
      private bool[] P00FQ2_n794NotaFiscalId ;
      private int[] P00FQ2_A419TituloPropostaId ;
      private bool[] P00FQ2_n419TituloPropostaId ;
      private int[] P00FQ2_A420TituloClienteId ;
      private bool[] P00FQ2_n420TituloClienteId ;
      private string[] P00FQ2_A972TituloCLienteRazaoSocial ;
      private bool[] P00FQ2_n972TituloCLienteRazaoSocial ;
      private DateTime[] P00FQ2_A264TituloProrrogacao ;
      private bool[] P00FQ2_n264TituloProrrogacao ;
      private decimal[] P00FQ2_A276TituloDesconto ;
      private bool[] P00FQ2_n276TituloDesconto ;
      private decimal[] P00FQ2_A262TituloValor ;
      private bool[] P00FQ2_n262TituloValor ;
      private string[] P00FQ2_A799NotaFiscalNumero ;
      private bool[] P00FQ2_n799NotaFiscalNumero ;
      private string[] P00FQ2_A971TituloPropostaDescricao ;
      private bool[] P00FQ2_n971TituloPropostaDescricao ;
      private int[] P00FQ2_A261TituloId ;
      private bool[] P00FQ2_n261TituloId ;
      private Guid[] P00FQ3_A890NotaFiscalParcelamentoID ;
      private bool[] P00FQ3_n890NotaFiscalParcelamentoID ;
      private Guid[] P00FQ3_A794NotaFiscalId ;
      private bool[] P00FQ3_n794NotaFiscalId ;
      private int[] P00FQ3_A419TituloPropostaId ;
      private bool[] P00FQ3_n419TituloPropostaId ;
      private int[] P00FQ3_A420TituloClienteId ;
      private bool[] P00FQ3_n420TituloClienteId ;
      private string[] P00FQ3_A971TituloPropostaDescricao ;
      private bool[] P00FQ3_n971TituloPropostaDescricao ;
      private DateTime[] P00FQ3_A264TituloProrrogacao ;
      private bool[] P00FQ3_n264TituloProrrogacao ;
      private decimal[] P00FQ3_A276TituloDesconto ;
      private bool[] P00FQ3_n276TituloDesconto ;
      private decimal[] P00FQ3_A262TituloValor ;
      private bool[] P00FQ3_n262TituloValor ;
      private string[] P00FQ3_A799NotaFiscalNumero ;
      private bool[] P00FQ3_n799NotaFiscalNumero ;
      private string[] P00FQ3_A972TituloCLienteRazaoSocial ;
      private bool[] P00FQ3_n972TituloCLienteRazaoSocial ;
      private int[] P00FQ3_A261TituloId ;
      private bool[] P00FQ3_n261TituloId ;
      private Guid[] P00FQ4_A890NotaFiscalParcelamentoID ;
      private bool[] P00FQ4_n890NotaFiscalParcelamentoID ;
      private Guid[] P00FQ4_A794NotaFiscalId ;
      private bool[] P00FQ4_n794NotaFiscalId ;
      private int[] P00FQ4_A419TituloPropostaId ;
      private bool[] P00FQ4_n419TituloPropostaId ;
      private int[] P00FQ4_A420TituloClienteId ;
      private bool[] P00FQ4_n420TituloClienteId ;
      private string[] P00FQ4_A799NotaFiscalNumero ;
      private bool[] P00FQ4_n799NotaFiscalNumero ;
      private DateTime[] P00FQ4_A264TituloProrrogacao ;
      private bool[] P00FQ4_n264TituloProrrogacao ;
      private decimal[] P00FQ4_A276TituloDesconto ;
      private bool[] P00FQ4_n276TituloDesconto ;
      private decimal[] P00FQ4_A262TituloValor ;
      private bool[] P00FQ4_n262TituloValor ;
      private string[] P00FQ4_A971TituloPropostaDescricao ;
      private bool[] P00FQ4_n971TituloPropostaDescricao ;
      private string[] P00FQ4_A972TituloCLienteRazaoSocial ;
      private bool[] P00FQ4_n972TituloCLienteRazaoSocial ;
      private int[] P00FQ4_A261TituloId ;
      private bool[] P00FQ4_n261TituloId ;
      private int[] P00FQ5_Gx_cnt ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class selecionartitulosgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FQ2( IGxContext context ,
                                             string AV48Selecionartitulosds_1_filterfulltext ,
                                             string AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                             string AV49Selecionartitulosds_2_tftituloclienterazaosocial ,
                                             decimal AV51Selecionartitulosds_4_tftitulovalor ,
                                             decimal AV52Selecionartitulosds_5_tftitulovalor_to ,
                                             decimal AV53Selecionartitulosds_6_tftitulodesconto ,
                                             decimal AV54Selecionartitulosds_7_tftitulodesconto_to ,
                                             DateTime AV55Selecionartitulosds_8_tftituloprorrogacao ,
                                             DateTime AV56Selecionartitulosds_9_tftituloprorrogacao_to ,
                                             string AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                             string AV57Selecionartitulosds_10_tftitulopropostadescricao ,
                                             string AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                             string AV59Selecionartitulosds_12_tfnotafiscalnumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             decimal A262TituloValor ,
                                             decimal A276TituloDesconto ,
                                             string A971TituloPropostaDescricao ,
                                             string A799NotaFiscalNumero ,
                                             DateTime A264TituloProrrogacao ,
                                             bool A1118TitulosEmCarteiraDeCobranca_F ,
                                             int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloValor, T3.NotaFiscalNumero, T4.PropostaDescricao AS TituloPropostaDescricao, T1.TituloId FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T5.ClienteRazaoSocial like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloValor,'999999999999990.99'), 2) like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloDesconto,'999999999999990.99'), 2) like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( T4.PropostaDescricao like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( T3.NotaFiscalNumero like '%' || :lV48Selecionartitulosds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Selecionartitulosds_2_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV49Selecionartitulosds_2_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV51Selecionartitulosds_4_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV51Selecionartitulosds_4_tftitulovalor)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV52Selecionartitulosds_5_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV52Selecionartitulosds_5_tftitulovalor_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV53Selecionartitulosds_6_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV53Selecionartitulosds_6_tftitulodesconto)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Selecionartitulosds_7_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV54Selecionartitulosds_7_tftitulodesconto_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Selecionartitulosds_8_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV55Selecionartitulosds_8_tftituloprorrogacao)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Selecionartitulosds_9_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV56Selecionartitulosds_9_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Selecionartitulosds_10_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV57Selecionartitulosds_10_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV58Selecionartitulosds_11_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Selecionartitulosds_12_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV59Selecionartitulosds_12_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV60Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV60Selecionartitulosds_13_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00FQ3( IGxContext context ,
                                             string AV48Selecionartitulosds_1_filterfulltext ,
                                             string AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                             string AV49Selecionartitulosds_2_tftituloclienterazaosocial ,
                                             decimal AV51Selecionartitulosds_4_tftitulovalor ,
                                             decimal AV52Selecionartitulosds_5_tftitulovalor_to ,
                                             decimal AV53Selecionartitulosds_6_tftitulodesconto ,
                                             decimal AV54Selecionartitulosds_7_tftitulodesconto_to ,
                                             DateTime AV55Selecionartitulosds_8_tftituloprorrogacao ,
                                             DateTime AV56Selecionartitulosds_9_tftituloprorrogacao_to ,
                                             string AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                             string AV57Selecionartitulosds_10_tftitulopropostadescricao ,
                                             string AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                             string AV59Selecionartitulosds_12_tfnotafiscalnumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             decimal A262TituloValor ,
                                             decimal A276TituloDesconto ,
                                             string A971TituloPropostaDescricao ,
                                             string A799NotaFiscalNumero ,
                                             DateTime A264TituloProrrogacao ,
                                             bool A1118TitulosEmCarteiraDeCobranca_F ,
                                             int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T4.PropostaDescricao AS TituloPropostaDescricao, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloValor, T3.NotaFiscalNumero, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloId FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T5.ClienteRazaoSocial like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloValor,'999999999999990.99'), 2) like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloDesconto,'999999999999990.99'), 2) like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( T4.PropostaDescricao like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( T3.NotaFiscalNumero like '%' || :lV48Selecionartitulosds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Selecionartitulosds_2_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV49Selecionartitulosds_2_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV51Selecionartitulosds_4_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV51Selecionartitulosds_4_tftitulovalor)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV52Selecionartitulosds_5_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV52Selecionartitulosds_5_tftitulovalor_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV53Selecionartitulosds_6_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV53Selecionartitulosds_6_tftitulodesconto)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Selecionartitulosds_7_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV54Selecionartitulosds_7_tftitulodesconto_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Selecionartitulosds_8_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV55Selecionartitulosds_8_tftituloprorrogacao)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Selecionartitulosds_9_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV56Selecionartitulosds_9_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Selecionartitulosds_10_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV57Selecionartitulosds_10_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV58Selecionartitulosds_11_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Selecionartitulosds_12_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV59Selecionartitulosds_12_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV60Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV60Selecionartitulosds_13_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.PropostaDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00FQ4( IGxContext context ,
                                             string AV48Selecionartitulosds_1_filterfulltext ,
                                             string AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel ,
                                             string AV49Selecionartitulosds_2_tftituloclienterazaosocial ,
                                             decimal AV51Selecionartitulosds_4_tftitulovalor ,
                                             decimal AV52Selecionartitulosds_5_tftitulovalor_to ,
                                             decimal AV53Selecionartitulosds_6_tftitulodesconto ,
                                             decimal AV54Selecionartitulosds_7_tftitulodesconto_to ,
                                             DateTime AV55Selecionartitulosds_8_tftituloprorrogacao ,
                                             DateTime AV56Selecionartitulosds_9_tftituloprorrogacao_to ,
                                             string AV58Selecionartitulosds_11_tftitulopropostadescricao_sel ,
                                             string AV57Selecionartitulosds_10_tftitulopropostadescricao ,
                                             string AV60Selecionartitulosds_13_tfnotafiscalnumero_sel ,
                                             string AV59Selecionartitulosds_12_tfnotafiscalnumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             decimal A262TituloValor ,
                                             decimal A276TituloDesconto ,
                                             string A971TituloPropostaDescricao ,
                                             string A799NotaFiscalNumero ,
                                             DateTime A264TituloProrrogacao ,
                                             bool A1118TitulosEmCarteiraDeCobranca_F ,
                                             int A261TituloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T3.NotaFiscalNumero, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloValor, T4.PropostaDescricao AS TituloPropostaDescricao, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloId FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Selecionartitulosds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T5.ClienteRazaoSocial like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloValor,'999999999999990.99'), 2) like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.TituloDesconto,'999999999999990.99'), 2) like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( T4.PropostaDescricao like '%' || :lV48Selecionartitulosds_1_filterfulltext) or ( T3.NotaFiscalNumero like '%' || :lV48Selecionartitulosds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Selecionartitulosds_2_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV49Selecionartitulosds_2_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV51Selecionartitulosds_4_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV51Selecionartitulosds_4_tftitulovalor)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV52Selecionartitulosds_5_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV52Selecionartitulosds_5_tftitulovalor_to)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV53Selecionartitulosds_6_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV53Selecionartitulosds_6_tftitulodesconto)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Selecionartitulosds_7_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV54Selecionartitulosds_7_tftitulodesconto_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Selecionartitulosds_8_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV55Selecionartitulosds_8_tftituloprorrogacao)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Selecionartitulosds_9_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV56Selecionartitulosds_9_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Selecionartitulosds_10_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV57Selecionartitulosds_10_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Selecionartitulosds_11_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV58Selecionartitulosds_11_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Selecionartitulosds_11_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Selecionartitulosds_12_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV59Selecionartitulosds_12_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Selecionartitulosds_13_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV60Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV60Selecionartitulosds_13_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Selecionartitulosds_13_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.NotaFiscalNumero";
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
                     return conditional_P00FQ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] );
               case 1 :
                     return conditional_P00FQ3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] );
               case 2 :
                     return conditional_P00FQ4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] );
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
          Object[] prmP00FQ5;
          prmP00FQ5 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmP00FQ2;
          prmP00FQ2 = new Object[] {
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Selecionartitulosds_2_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV51Selecionartitulosds_4_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV52Selecionartitulosds_5_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV53Selecionartitulosds_6_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV54Selecionartitulosds_7_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV55Selecionartitulosds_8_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV56Selecionartitulosds_9_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("lV57Selecionartitulosds_10_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV58Selecionartitulosds_11_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV59Selecionartitulosds_12_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV60Selecionartitulosds_13_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00FQ3;
          prmP00FQ3 = new Object[] {
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Selecionartitulosds_2_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV51Selecionartitulosds_4_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV52Selecionartitulosds_5_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV53Selecionartitulosds_6_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV54Selecionartitulosds_7_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV55Selecionartitulosds_8_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV56Selecionartitulosds_9_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("lV57Selecionartitulosds_10_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV58Selecionartitulosds_11_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV59Selecionartitulosds_12_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV60Selecionartitulosds_13_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00FQ4;
          prmP00FQ4 = new Object[] {
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Selecionartitulosds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Selecionartitulosds_2_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV50Selecionartitulosds_3_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV51Selecionartitulosds_4_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV52Selecionartitulosds_5_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV53Selecionartitulosds_6_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV54Selecionartitulosds_7_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV55Selecionartitulosds_8_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV56Selecionartitulosds_9_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("lV57Selecionartitulosds_10_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV58Selecionartitulosds_11_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV59Selecionartitulosds_12_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV60Selecionartitulosds_13_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FQ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FQ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FQ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FQ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FQ5", "SELECT COUNT(*) FROM Boleto WHERE TituloId = :TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FQ5,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
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
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
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
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
