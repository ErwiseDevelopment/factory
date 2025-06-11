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
   public class titulopropostawwgetfilterdata : GXProcedure
   {
      public titulopropostawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulopropostawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_CATEGORIATITULODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADCATEGORIATITULODESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_TITULOCOMPETENCIA_F") == 0 )
         {
            /* Execute user subroutine: 'LOADTITULOCOMPETENCIA_FOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("TituloPropostaWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TituloPropostaWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("TituloPropostaWWGridState"), null, "", "");
         }
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO") == 0 )
            {
               AV63TFCategoriaTituloDescricao = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO_SEL") == 0 )
            {
               AV64TFCategoriaTituloDescricao_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV56TFClienteRazaoSocial = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV57TFClienteRazaoSocial_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV10TFTituloValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV11TFTituloValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV12TFTituloDesconto = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV13TFTituloDesconto_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV60TFTituloCompetencia_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV61TFTituloCompetencia_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV14TFTituloProrrogacao = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV15TFTituloProrrogacao_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV16TFTituloTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV17TFTituloTipo_Sels.FromJSonString(AV16TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&TITULOPROPOSTAID") == 0 )
            {
               AV65TituloPropostaId = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV45DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV47TituloValor1 = NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, ".");
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV48DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV49DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV51TituloValor2 = NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, ".");
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV52DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV53DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV54DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV55TituloValor3 = NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, ".");
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCATEGORIATITULODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV63TFCategoriaTituloDescricao = AV22SearchTxt;
         AV64TFCategoriaTituloDescricao_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV17TFTituloTipo_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46DynamicFiltersOperator1 ,
                                              AV47TituloValor1 ,
                                              AV48DynamicFiltersEnabled2 ,
                                              AV49DynamicFiltersSelector2 ,
                                              AV50DynamicFiltersOperator2 ,
                                              AV51TituloValor2 ,
                                              AV52DynamicFiltersEnabled3 ,
                                              AV53DynamicFiltersSelector3 ,
                                              AV54DynamicFiltersOperator3 ,
                                              AV55TituloValor3 ,
                                              AV64TFCategoriaTituloDescricao_Sel ,
                                              AV63TFCategoriaTituloDescricao ,
                                              AV57TFClienteRazaoSocial_Sel ,
                                              AV56TFClienteRazaoSocial ,
                                              AV10TFTituloValor ,
                                              AV11TFTituloValor_To ,
                                              AV12TFTituloDesconto ,
                                              AV13TFTituloDesconto_To ,
                                              AV14TFTituloProrrogacao ,
                                              AV15TFTituloProrrogacao_To ,
                                              AV17TFTituloTipo_Sels.Count ,
                                              AV62TituloTipo ,
                                              A262TituloValor ,
                                              A428CategoriaTituloDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV44FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV61TFTituloCompetencia_F_Sel ,
                                              AV60TFTituloCompetencia_F ,
                                              AV65TituloPropostaId ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV63TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV63TFCategoriaTituloDescricao), "%", "");
         lV56TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV56TFClienteRazaoSocial), "%", "");
         /* Using cursor P00AJ2 */
         pr_default.execute(0, new Object[] {AV65TituloPropostaId, AV47TituloValor1, AV47TituloValor1, AV47TituloValor1, AV51TituloValor2, AV51TituloValor2, AV51TituloValor2, AV55TituloValor3, AV55TituloValor3, AV55TituloValor3, lV63TFCategoriaTituloDescricao, AV64TFCategoriaTituloDescricao_Sel, lV56TFClienteRazaoSocial, AV57TFClienteRazaoSocial_Sel, AV10TFTituloValor, AV11TFTituloValor_To, AV12TFTituloDesconto, AV13TFTituloDesconto_To, AV14TFTituloProrrogacao, AV15TFTituloProrrogacao_To, AV62TituloTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAJ2 = false;
            A426CategoriaTituloId = P00AJ2_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P00AJ2_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = P00AJ2_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00AJ2_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00AJ2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AJ2_n794NotaFiscalId[0];
            A168ClienteId = P00AJ2_A168ClienteId[0];
            n168ClienteId = P00AJ2_n168ClienteId[0];
            A419TituloPropostaId = P00AJ2_A419TituloPropostaId[0];
            n419TituloPropostaId = P00AJ2_n419TituloPropostaId[0];
            A428CategoriaTituloDescricao = P00AJ2_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AJ2_n428CategoriaTituloDescricao[0];
            A264TituloProrrogacao = P00AJ2_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00AJ2_n264TituloProrrogacao[0];
            A283TituloTipo = P00AJ2_A283TituloTipo[0];
            n283TituloTipo = P00AJ2_n283TituloTipo[0];
            A276TituloDesconto = P00AJ2_A276TituloDesconto[0];
            n276TituloDesconto = P00AJ2_n276TituloDesconto[0];
            A262TituloValor = P00AJ2_A262TituloValor[0];
            n262TituloValor = P00AJ2_n262TituloValor[0];
            A170ClienteRazaoSocial = P00AJ2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AJ2_n170ClienteRazaoSocial[0];
            A286TituloCompetenciaAno = P00AJ2_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00AJ2_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00AJ2_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00AJ2_n287TituloCompetenciaMes[0];
            A261TituloId = P00AJ2_A261TituloId[0];
            A428CategoriaTituloDescricao = P00AJ2_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AJ2_n428CategoriaTituloDescricao[0];
            A794NotaFiscalId = P00AJ2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AJ2_n794NotaFiscalId[0];
            A168ClienteId = P00AJ2_A168ClienteId[0];
            n168ClienteId = P00AJ2_n168ClienteId[0];
            A170ClienteRazaoSocial = P00AJ2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AJ2_n170ClienteRazaoSocial[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV60TFTituloCompetencia_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ! ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV61TFTituloCompetencia_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV32count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( P00AJ2_A419TituloPropostaId[0] == A419TituloPropostaId ) && ( StringUtil.StrCmp(P00AJ2_A428CategoriaTituloDescricao[0], A428CategoriaTituloDescricao) == 0 ) )
                        {
                           BRKAJ2 = false;
                           A426CategoriaTituloId = P00AJ2_A426CategoriaTituloId[0];
                           n426CategoriaTituloId = P00AJ2_n426CategoriaTituloId[0];
                           A261TituloId = P00AJ2_A261TituloId[0];
                           AV32count = (long)(AV32count+1);
                           BRKAJ2 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV23SkipItems) )
                        {
                           AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) ? "<#Empty#>" : A428CategoriaTituloDescricao);
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
                  }
               }
            }
            if ( ! BRKAJ2 )
            {
               BRKAJ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV56TFClienteRazaoSocial = AV22SearchTxt;
         AV57TFClienteRazaoSocial_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV17TFTituloTipo_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46DynamicFiltersOperator1 ,
                                              AV47TituloValor1 ,
                                              AV48DynamicFiltersEnabled2 ,
                                              AV49DynamicFiltersSelector2 ,
                                              AV50DynamicFiltersOperator2 ,
                                              AV51TituloValor2 ,
                                              AV52DynamicFiltersEnabled3 ,
                                              AV53DynamicFiltersSelector3 ,
                                              AV54DynamicFiltersOperator3 ,
                                              AV55TituloValor3 ,
                                              AV64TFCategoriaTituloDescricao_Sel ,
                                              AV63TFCategoriaTituloDescricao ,
                                              AV57TFClienteRazaoSocial_Sel ,
                                              AV56TFClienteRazaoSocial ,
                                              AV10TFTituloValor ,
                                              AV11TFTituloValor_To ,
                                              AV12TFTituloDesconto ,
                                              AV13TFTituloDesconto_To ,
                                              AV14TFTituloProrrogacao ,
                                              AV15TFTituloProrrogacao_To ,
                                              AV17TFTituloTipo_Sels.Count ,
                                              AV62TituloTipo ,
                                              A262TituloValor ,
                                              A428CategoriaTituloDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV44FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV61TFTituloCompetencia_F_Sel ,
                                              AV60TFTituloCompetencia_F ,
                                              AV65TituloPropostaId ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV63TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV63TFCategoriaTituloDescricao), "%", "");
         lV56TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV56TFClienteRazaoSocial), "%", "");
         /* Using cursor P00AJ3 */
         pr_default.execute(1, new Object[] {AV65TituloPropostaId, AV47TituloValor1, AV47TituloValor1, AV47TituloValor1, AV51TituloValor2, AV51TituloValor2, AV51TituloValor2, AV55TituloValor3, AV55TituloValor3, AV55TituloValor3, lV63TFCategoriaTituloDescricao, AV64TFCategoriaTituloDescricao_Sel, lV56TFClienteRazaoSocial, AV57TFClienteRazaoSocial_Sel, AV10TFTituloValor, AV11TFTituloValor_To, AV12TFTituloDesconto, AV13TFTituloDesconto_To, AV14TFTituloProrrogacao, AV15TFTituloProrrogacao_To, AV62TituloTipo});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAJ4 = false;
            A426CategoriaTituloId = P00AJ3_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P00AJ3_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = P00AJ3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00AJ3_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00AJ3_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AJ3_n794NotaFiscalId[0];
            A168ClienteId = P00AJ3_A168ClienteId[0];
            n168ClienteId = P00AJ3_n168ClienteId[0];
            A419TituloPropostaId = P00AJ3_A419TituloPropostaId[0];
            n419TituloPropostaId = P00AJ3_n419TituloPropostaId[0];
            A170ClienteRazaoSocial = P00AJ3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AJ3_n170ClienteRazaoSocial[0];
            A264TituloProrrogacao = P00AJ3_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00AJ3_n264TituloProrrogacao[0];
            A283TituloTipo = P00AJ3_A283TituloTipo[0];
            n283TituloTipo = P00AJ3_n283TituloTipo[0];
            A276TituloDesconto = P00AJ3_A276TituloDesconto[0];
            n276TituloDesconto = P00AJ3_n276TituloDesconto[0];
            A262TituloValor = P00AJ3_A262TituloValor[0];
            n262TituloValor = P00AJ3_n262TituloValor[0];
            A428CategoriaTituloDescricao = P00AJ3_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AJ3_n428CategoriaTituloDescricao[0];
            A286TituloCompetenciaAno = P00AJ3_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00AJ3_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00AJ3_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00AJ3_n287TituloCompetenciaMes[0];
            A261TituloId = P00AJ3_A261TituloId[0];
            A428CategoriaTituloDescricao = P00AJ3_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AJ3_n428CategoriaTituloDescricao[0];
            A794NotaFiscalId = P00AJ3_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AJ3_n794NotaFiscalId[0];
            A168ClienteId = P00AJ3_A168ClienteId[0];
            n168ClienteId = P00AJ3_n168ClienteId[0];
            A170ClienteRazaoSocial = P00AJ3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AJ3_n170ClienteRazaoSocial[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV60TFTituloCompetencia_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ! ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV61TFTituloCompetencia_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV32count = 0;
                        while ( (pr_default.getStatus(1) != 101) && ( P00AJ3_A419TituloPropostaId[0] == A419TituloPropostaId ) && ( StringUtil.StrCmp(P00AJ3_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
                        {
                           BRKAJ4 = false;
                           A890NotaFiscalParcelamentoID = P00AJ3_A890NotaFiscalParcelamentoID[0];
                           n890NotaFiscalParcelamentoID = P00AJ3_n890NotaFiscalParcelamentoID[0];
                           A794NotaFiscalId = P00AJ3_A794NotaFiscalId[0];
                           n794NotaFiscalId = P00AJ3_n794NotaFiscalId[0];
                           A168ClienteId = P00AJ3_A168ClienteId[0];
                           n168ClienteId = P00AJ3_n168ClienteId[0];
                           A261TituloId = P00AJ3_A261TituloId[0];
                           A794NotaFiscalId = P00AJ3_A794NotaFiscalId[0];
                           n794NotaFiscalId = P00AJ3_n794NotaFiscalId[0];
                           A168ClienteId = P00AJ3_A168ClienteId[0];
                           n168ClienteId = P00AJ3_n168ClienteId[0];
                           AV32count = (long)(AV32count+1);
                           BRKAJ4 = true;
                           pr_default.readNext(1);
                        }
                        if ( (0==AV23SkipItems) )
                        {
                           AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
                           AV29OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
                           AV28Options.Add(AV27Option, 0);
                           AV30OptionsDesc.Add(AV29OptionDesc, 0);
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
                  }
               }
            }
            if ( ! BRKAJ4 )
            {
               BRKAJ4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTITULOCOMPETENCIA_FOPTIONS' Routine */
         returnInSub = false;
         AV60TFTituloCompetencia_F = AV22SearchTxt;
         AV61TFTituloCompetencia_F_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV17TFTituloTipo_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46DynamicFiltersOperator1 ,
                                              AV47TituloValor1 ,
                                              AV48DynamicFiltersEnabled2 ,
                                              AV49DynamicFiltersSelector2 ,
                                              AV50DynamicFiltersOperator2 ,
                                              AV51TituloValor2 ,
                                              AV52DynamicFiltersEnabled3 ,
                                              AV53DynamicFiltersSelector3 ,
                                              AV54DynamicFiltersOperator3 ,
                                              AV55TituloValor3 ,
                                              AV64TFCategoriaTituloDescricao_Sel ,
                                              AV63TFCategoriaTituloDescricao ,
                                              AV57TFClienteRazaoSocial_Sel ,
                                              AV56TFClienteRazaoSocial ,
                                              AV10TFTituloValor ,
                                              AV11TFTituloValor_To ,
                                              AV12TFTituloDesconto ,
                                              AV13TFTituloDesconto_To ,
                                              AV14TFTituloProrrogacao ,
                                              AV15TFTituloProrrogacao_To ,
                                              AV17TFTituloTipo_Sels.Count ,
                                              AV62TituloTipo ,
                                              A262TituloValor ,
                                              A428CategoriaTituloDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV44FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV61TFTituloCompetencia_F_Sel ,
                                              AV60TFTituloCompetencia_F ,
                                              AV65TituloPropostaId ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV63TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV63TFCategoriaTituloDescricao), "%", "");
         lV56TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV56TFClienteRazaoSocial), "%", "");
         /* Using cursor P00AJ4 */
         pr_default.execute(2, new Object[] {AV65TituloPropostaId, AV47TituloValor1, AV47TituloValor1, AV47TituloValor1, AV51TituloValor2, AV51TituloValor2, AV51TituloValor2, AV55TituloValor3, AV55TituloValor3, AV55TituloValor3, lV63TFCategoriaTituloDescricao, AV64TFCategoriaTituloDescricao_Sel, lV56TFClienteRazaoSocial, AV57TFClienteRazaoSocial_Sel, AV10TFTituloValor, AV11TFTituloValor_To, AV12TFTituloDesconto, AV13TFTituloDesconto_To, AV14TFTituloProrrogacao, AV15TFTituloProrrogacao_To, AV62TituloTipo});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A426CategoriaTituloId = P00AJ4_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P00AJ4_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = P00AJ4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00AJ4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00AJ4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AJ4_n794NotaFiscalId[0];
            A168ClienteId = P00AJ4_A168ClienteId[0];
            n168ClienteId = P00AJ4_n168ClienteId[0];
            A264TituloProrrogacao = P00AJ4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00AJ4_n264TituloProrrogacao[0];
            A283TituloTipo = P00AJ4_A283TituloTipo[0];
            n283TituloTipo = P00AJ4_n283TituloTipo[0];
            A276TituloDesconto = P00AJ4_A276TituloDesconto[0];
            n276TituloDesconto = P00AJ4_n276TituloDesconto[0];
            A262TituloValor = P00AJ4_A262TituloValor[0];
            n262TituloValor = P00AJ4_n262TituloValor[0];
            A170ClienteRazaoSocial = P00AJ4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AJ4_n170ClienteRazaoSocial[0];
            A428CategoriaTituloDescricao = P00AJ4_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AJ4_n428CategoriaTituloDescricao[0];
            A419TituloPropostaId = P00AJ4_A419TituloPropostaId[0];
            n419TituloPropostaId = P00AJ4_n419TituloPropostaId[0];
            A286TituloCompetenciaAno = P00AJ4_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00AJ4_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00AJ4_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00AJ4_n287TituloCompetenciaMes[0];
            A261TituloId = P00AJ4_A261TituloId[0];
            A428CategoriaTituloDescricao = P00AJ4_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AJ4_n428CategoriaTituloDescricao[0];
            A794NotaFiscalId = P00AJ4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AJ4_n794NotaFiscalId[0];
            A168ClienteId = P00AJ4_A168ClienteId[0];
            n168ClienteId = P00AJ4_n168ClienteId[0];
            A170ClienteRazaoSocial = P00AJ4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AJ4_n170ClienteRazaoSocial[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV60TFTituloCompetencia_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ! ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV61TFTituloCompetencia_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ? "<#Empty#>" : A295TituloCompetencia_F);
                        AV26InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV26InsertIndex = (int)(AV26InsertIndex+1);
                        }
                        if ( ( AV26InsertIndex <= AV28Options.Count ) && ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) == 0 ) )
                        {
                           AV32count = (long)(Math.Round(NumberUtil.Val( ((string)AV31OptionIndexes.Item(AV26InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV32count = (long)(AV32count+1);
                           AV31OptionIndexes.RemoveItem(AV26InsertIndex);
                           AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
                        }
                        else
                        {
                           AV28Options.Add(AV27Option, AV26InsertIndex);
                           AV31OptionIndexes.Add("1", AV26InsertIndex);
                        }
                        if ( AV28Options.Count == AV23SkipItems + 11 )
                        {
                           AV28Options.RemoveItem(AV28Options.Count);
                           AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV63TFCategoriaTituloDescricao = "";
         AV64TFCategoriaTituloDescricao_Sel = "";
         AV56TFClienteRazaoSocial = "";
         AV57TFClienteRazaoSocial_Sel = "";
         AV60TFTituloCompetencia_F = "";
         AV61TFTituloCompetencia_F_Sel = "";
         AV14TFTituloProrrogacao = DateTime.MinValue;
         AV15TFTituloProrrogacao_To = DateTime.MinValue;
         AV16TFTituloTipo_SelsJson = "";
         AV17TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV49DynamicFiltersSelector2 = "";
         AV53DynamicFiltersSelector3 = "";
         lV44FilterFullText = "";
         lV63TFCategoriaTituloDescricao = "";
         lV56TFClienteRazaoSocial = "";
         A283TituloTipo = "";
         AV62TituloTipo = "";
         A428CategoriaTituloDescricao = "";
         A170ClienteRazaoSocial = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         P00AJ2_A426CategoriaTituloId = new int[1] ;
         P00AJ2_n426CategoriaTituloId = new bool[] {false} ;
         P00AJ2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00AJ2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00AJ2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00AJ2_n794NotaFiscalId = new bool[] {false} ;
         P00AJ2_A168ClienteId = new int[1] ;
         P00AJ2_n168ClienteId = new bool[] {false} ;
         P00AJ2_A419TituloPropostaId = new int[1] ;
         P00AJ2_n419TituloPropostaId = new bool[] {false} ;
         P00AJ2_A428CategoriaTituloDescricao = new string[] {""} ;
         P00AJ2_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00AJ2_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00AJ2_n264TituloProrrogacao = new bool[] {false} ;
         P00AJ2_A283TituloTipo = new string[] {""} ;
         P00AJ2_n283TituloTipo = new bool[] {false} ;
         P00AJ2_A276TituloDesconto = new decimal[1] ;
         P00AJ2_n276TituloDesconto = new bool[] {false} ;
         P00AJ2_A262TituloValor = new decimal[1] ;
         P00AJ2_n262TituloValor = new bool[] {false} ;
         P00AJ2_A170ClienteRazaoSocial = new string[] {""} ;
         P00AJ2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00AJ2_A286TituloCompetenciaAno = new short[1] ;
         P00AJ2_n286TituloCompetenciaAno = new bool[] {false} ;
         P00AJ2_A287TituloCompetenciaMes = new short[1] ;
         P00AJ2_n287TituloCompetenciaMes = new bool[] {false} ;
         P00AJ2_A261TituloId = new int[1] ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         AV27Option = "";
         P00AJ3_A426CategoriaTituloId = new int[1] ;
         P00AJ3_n426CategoriaTituloId = new bool[] {false} ;
         P00AJ3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00AJ3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00AJ3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00AJ3_n794NotaFiscalId = new bool[] {false} ;
         P00AJ3_A168ClienteId = new int[1] ;
         P00AJ3_n168ClienteId = new bool[] {false} ;
         P00AJ3_A419TituloPropostaId = new int[1] ;
         P00AJ3_n419TituloPropostaId = new bool[] {false} ;
         P00AJ3_A170ClienteRazaoSocial = new string[] {""} ;
         P00AJ3_n170ClienteRazaoSocial = new bool[] {false} ;
         P00AJ3_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00AJ3_n264TituloProrrogacao = new bool[] {false} ;
         P00AJ3_A283TituloTipo = new string[] {""} ;
         P00AJ3_n283TituloTipo = new bool[] {false} ;
         P00AJ3_A276TituloDesconto = new decimal[1] ;
         P00AJ3_n276TituloDesconto = new bool[] {false} ;
         P00AJ3_A262TituloValor = new decimal[1] ;
         P00AJ3_n262TituloValor = new bool[] {false} ;
         P00AJ3_A428CategoriaTituloDescricao = new string[] {""} ;
         P00AJ3_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00AJ3_A286TituloCompetenciaAno = new short[1] ;
         P00AJ3_n286TituloCompetenciaAno = new bool[] {false} ;
         P00AJ3_A287TituloCompetenciaMes = new short[1] ;
         P00AJ3_n287TituloCompetenciaMes = new bool[] {false} ;
         P00AJ3_A261TituloId = new int[1] ;
         AV29OptionDesc = "";
         P00AJ4_A426CategoriaTituloId = new int[1] ;
         P00AJ4_n426CategoriaTituloId = new bool[] {false} ;
         P00AJ4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00AJ4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00AJ4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00AJ4_n794NotaFiscalId = new bool[] {false} ;
         P00AJ4_A168ClienteId = new int[1] ;
         P00AJ4_n168ClienteId = new bool[] {false} ;
         P00AJ4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00AJ4_n264TituloProrrogacao = new bool[] {false} ;
         P00AJ4_A283TituloTipo = new string[] {""} ;
         P00AJ4_n283TituloTipo = new bool[] {false} ;
         P00AJ4_A276TituloDesconto = new decimal[1] ;
         P00AJ4_n276TituloDesconto = new bool[] {false} ;
         P00AJ4_A262TituloValor = new decimal[1] ;
         P00AJ4_n262TituloValor = new bool[] {false} ;
         P00AJ4_A170ClienteRazaoSocial = new string[] {""} ;
         P00AJ4_n170ClienteRazaoSocial = new bool[] {false} ;
         P00AJ4_A428CategoriaTituloDescricao = new string[] {""} ;
         P00AJ4_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00AJ4_A419TituloPropostaId = new int[1] ;
         P00AJ4_n419TituloPropostaId = new bool[] {false} ;
         P00AJ4_A286TituloCompetenciaAno = new short[1] ;
         P00AJ4_n286TituloCompetenciaAno = new bool[] {false} ;
         P00AJ4_A287TituloCompetenciaMes = new short[1] ;
         P00AJ4_n287TituloCompetenciaMes = new bool[] {false} ;
         P00AJ4_A261TituloId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulopropostawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AJ2_A426CategoriaTituloId, P00AJ2_n426CategoriaTituloId, P00AJ2_A890NotaFiscalParcelamentoID, P00AJ2_n890NotaFiscalParcelamentoID, P00AJ2_A794NotaFiscalId, P00AJ2_n794NotaFiscalId, P00AJ2_A168ClienteId, P00AJ2_n168ClienteId, P00AJ2_A419TituloPropostaId, P00AJ2_n419TituloPropostaId,
               P00AJ2_A428CategoriaTituloDescricao, P00AJ2_n428CategoriaTituloDescricao, P00AJ2_A264TituloProrrogacao, P00AJ2_n264TituloProrrogacao, P00AJ2_A283TituloTipo, P00AJ2_n283TituloTipo, P00AJ2_A276TituloDesconto, P00AJ2_n276TituloDesconto, P00AJ2_A262TituloValor, P00AJ2_n262TituloValor,
               P00AJ2_A170ClienteRazaoSocial, P00AJ2_n170ClienteRazaoSocial, P00AJ2_A286TituloCompetenciaAno, P00AJ2_n286TituloCompetenciaAno, P00AJ2_A287TituloCompetenciaMes, P00AJ2_n287TituloCompetenciaMes, P00AJ2_A261TituloId
               }
               , new Object[] {
               P00AJ3_A426CategoriaTituloId, P00AJ3_n426CategoriaTituloId, P00AJ3_A890NotaFiscalParcelamentoID, P00AJ3_n890NotaFiscalParcelamentoID, P00AJ3_A794NotaFiscalId, P00AJ3_n794NotaFiscalId, P00AJ3_A168ClienteId, P00AJ3_n168ClienteId, P00AJ3_A419TituloPropostaId, P00AJ3_n419TituloPropostaId,
               P00AJ3_A170ClienteRazaoSocial, P00AJ3_n170ClienteRazaoSocial, P00AJ3_A264TituloProrrogacao, P00AJ3_n264TituloProrrogacao, P00AJ3_A283TituloTipo, P00AJ3_n283TituloTipo, P00AJ3_A276TituloDesconto, P00AJ3_n276TituloDesconto, P00AJ3_A262TituloValor, P00AJ3_n262TituloValor,
               P00AJ3_A428CategoriaTituloDescricao, P00AJ3_n428CategoriaTituloDescricao, P00AJ3_A286TituloCompetenciaAno, P00AJ3_n286TituloCompetenciaAno, P00AJ3_A287TituloCompetenciaMes, P00AJ3_n287TituloCompetenciaMes, P00AJ3_A261TituloId
               }
               , new Object[] {
               P00AJ4_A426CategoriaTituloId, P00AJ4_n426CategoriaTituloId, P00AJ4_A890NotaFiscalParcelamentoID, P00AJ4_n890NotaFiscalParcelamentoID, P00AJ4_A794NotaFiscalId, P00AJ4_n794NotaFiscalId, P00AJ4_A168ClienteId, P00AJ4_n168ClienteId, P00AJ4_A264TituloProrrogacao, P00AJ4_n264TituloProrrogacao,
               P00AJ4_A283TituloTipo, P00AJ4_n283TituloTipo, P00AJ4_A276TituloDesconto, P00AJ4_n276TituloDesconto, P00AJ4_A262TituloValor, P00AJ4_n262TituloValor, P00AJ4_A170ClienteRazaoSocial, P00AJ4_n170ClienteRazaoSocial, P00AJ4_A428CategoriaTituloDescricao, P00AJ4_n428CategoriaTituloDescricao,
               P00AJ4_A419TituloPropostaId, P00AJ4_n419TituloPropostaId, P00AJ4_A286TituloCompetenciaAno, P00AJ4_n286TituloCompetenciaAno, P00AJ4_A287TituloCompetenciaMes, P00AJ4_n287TituloCompetenciaMes, P00AJ4_A261TituloId
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
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV66GXV1 ;
      private int AV65TituloPropostaId ;
      private int AV17TFTituloTipo_Sels_Count ;
      private int A419TituloPropostaId ;
      private int A426CategoriaTituloId ;
      private int A168ClienteId ;
      private int A261TituloId ;
      private int AV26InsertIndex ;
      private long AV32count ;
      private decimal AV10TFTituloValor ;
      private decimal AV11TFTituloValor_To ;
      private decimal AV12TFTituloDesconto ;
      private decimal AV13TFTituloDesconto_To ;
      private decimal AV47TituloValor1 ;
      private decimal AV51TituloValor2 ;
      private decimal AV55TituloValor3 ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private DateTime AV14TFTituloProrrogacao ;
      private DateTime AV15TFTituloProrrogacao_To ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool AV48DynamicFiltersEnabled2 ;
      private bool AV52DynamicFiltersEnabled3 ;
      private bool BRKAJ2 ;
      private bool n426CategoriaTituloId ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n419TituloPropostaId ;
      private bool n428CategoriaTituloDescricao ;
      private bool n264TituloProrrogacao ;
      private bool n283TituloTipo ;
      private bool n276TituloDesconto ;
      private bool n262TituloValor ;
      private bool n170ClienteRazaoSocial ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool BRKAJ4 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV16TFTituloTipo_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV63TFCategoriaTituloDescricao ;
      private string AV64TFCategoriaTituloDescricao_Sel ;
      private string AV56TFClienteRazaoSocial ;
      private string AV57TFClienteRazaoSocial_Sel ;
      private string AV60TFTituloCompetencia_F ;
      private string AV61TFTituloCompetencia_F_Sel ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV49DynamicFiltersSelector2 ;
      private string AV53DynamicFiltersSelector3 ;
      private string lV44FilterFullText ;
      private string lV63TFCategoriaTituloDescricao ;
      private string lV56TFClienteRazaoSocial ;
      private string A283TituloTipo ;
      private string AV62TituloTipo ;
      private string A428CategoriaTituloDescricao ;
      private string A170ClienteRazaoSocial ;
      private string A295TituloCompetencia_F ;
      private string AV27Option ;
      private string AV29OptionDesc ;
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
      private GxSimpleCollection<string> AV17TFTituloTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00AJ2_A426CategoriaTituloId ;
      private bool[] P00AJ2_n426CategoriaTituloId ;
      private Guid[] P00AJ2_A890NotaFiscalParcelamentoID ;
      private bool[] P00AJ2_n890NotaFiscalParcelamentoID ;
      private Guid[] P00AJ2_A794NotaFiscalId ;
      private bool[] P00AJ2_n794NotaFiscalId ;
      private int[] P00AJ2_A168ClienteId ;
      private bool[] P00AJ2_n168ClienteId ;
      private int[] P00AJ2_A419TituloPropostaId ;
      private bool[] P00AJ2_n419TituloPropostaId ;
      private string[] P00AJ2_A428CategoriaTituloDescricao ;
      private bool[] P00AJ2_n428CategoriaTituloDescricao ;
      private DateTime[] P00AJ2_A264TituloProrrogacao ;
      private bool[] P00AJ2_n264TituloProrrogacao ;
      private string[] P00AJ2_A283TituloTipo ;
      private bool[] P00AJ2_n283TituloTipo ;
      private decimal[] P00AJ2_A276TituloDesconto ;
      private bool[] P00AJ2_n276TituloDesconto ;
      private decimal[] P00AJ2_A262TituloValor ;
      private bool[] P00AJ2_n262TituloValor ;
      private string[] P00AJ2_A170ClienteRazaoSocial ;
      private bool[] P00AJ2_n170ClienteRazaoSocial ;
      private short[] P00AJ2_A286TituloCompetenciaAno ;
      private bool[] P00AJ2_n286TituloCompetenciaAno ;
      private short[] P00AJ2_A287TituloCompetenciaMes ;
      private bool[] P00AJ2_n287TituloCompetenciaMes ;
      private int[] P00AJ2_A261TituloId ;
      private int[] P00AJ3_A426CategoriaTituloId ;
      private bool[] P00AJ3_n426CategoriaTituloId ;
      private Guid[] P00AJ3_A890NotaFiscalParcelamentoID ;
      private bool[] P00AJ3_n890NotaFiscalParcelamentoID ;
      private Guid[] P00AJ3_A794NotaFiscalId ;
      private bool[] P00AJ3_n794NotaFiscalId ;
      private int[] P00AJ3_A168ClienteId ;
      private bool[] P00AJ3_n168ClienteId ;
      private int[] P00AJ3_A419TituloPropostaId ;
      private bool[] P00AJ3_n419TituloPropostaId ;
      private string[] P00AJ3_A170ClienteRazaoSocial ;
      private bool[] P00AJ3_n170ClienteRazaoSocial ;
      private DateTime[] P00AJ3_A264TituloProrrogacao ;
      private bool[] P00AJ3_n264TituloProrrogacao ;
      private string[] P00AJ3_A283TituloTipo ;
      private bool[] P00AJ3_n283TituloTipo ;
      private decimal[] P00AJ3_A276TituloDesconto ;
      private bool[] P00AJ3_n276TituloDesconto ;
      private decimal[] P00AJ3_A262TituloValor ;
      private bool[] P00AJ3_n262TituloValor ;
      private string[] P00AJ3_A428CategoriaTituloDescricao ;
      private bool[] P00AJ3_n428CategoriaTituloDescricao ;
      private short[] P00AJ3_A286TituloCompetenciaAno ;
      private bool[] P00AJ3_n286TituloCompetenciaAno ;
      private short[] P00AJ3_A287TituloCompetenciaMes ;
      private bool[] P00AJ3_n287TituloCompetenciaMes ;
      private int[] P00AJ3_A261TituloId ;
      private int[] P00AJ4_A426CategoriaTituloId ;
      private bool[] P00AJ4_n426CategoriaTituloId ;
      private Guid[] P00AJ4_A890NotaFiscalParcelamentoID ;
      private bool[] P00AJ4_n890NotaFiscalParcelamentoID ;
      private Guid[] P00AJ4_A794NotaFiscalId ;
      private bool[] P00AJ4_n794NotaFiscalId ;
      private int[] P00AJ4_A168ClienteId ;
      private bool[] P00AJ4_n168ClienteId ;
      private DateTime[] P00AJ4_A264TituloProrrogacao ;
      private bool[] P00AJ4_n264TituloProrrogacao ;
      private string[] P00AJ4_A283TituloTipo ;
      private bool[] P00AJ4_n283TituloTipo ;
      private decimal[] P00AJ4_A276TituloDesconto ;
      private bool[] P00AJ4_n276TituloDesconto ;
      private decimal[] P00AJ4_A262TituloValor ;
      private bool[] P00AJ4_n262TituloValor ;
      private string[] P00AJ4_A170ClienteRazaoSocial ;
      private bool[] P00AJ4_n170ClienteRazaoSocial ;
      private string[] P00AJ4_A428CategoriaTituloDescricao ;
      private bool[] P00AJ4_n428CategoriaTituloDescricao ;
      private int[] P00AJ4_A419TituloPropostaId ;
      private bool[] P00AJ4_n419TituloPropostaId ;
      private short[] P00AJ4_A286TituloCompetenciaAno ;
      private bool[] P00AJ4_n286TituloCompetenciaAno ;
      private short[] P00AJ4_A287TituloCompetenciaMes ;
      private bool[] P00AJ4_n287TituloCompetenciaMes ;
      private int[] P00AJ4_A261TituloId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class titulopropostawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AJ2( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV17TFTituloTipo_Sels ,
                                             string AV45DynamicFiltersSelector1 ,
                                             short AV46DynamicFiltersOperator1 ,
                                             decimal AV47TituloValor1 ,
                                             bool AV48DynamicFiltersEnabled2 ,
                                             string AV49DynamicFiltersSelector2 ,
                                             short AV50DynamicFiltersOperator2 ,
                                             decimal AV51TituloValor2 ,
                                             bool AV52DynamicFiltersEnabled3 ,
                                             string AV53DynamicFiltersSelector3 ,
                                             short AV54DynamicFiltersOperator3 ,
                                             decimal AV55TituloValor3 ,
                                             string AV64TFCategoriaTituloDescricao_Sel ,
                                             string AV63TFCategoriaTituloDescricao ,
                                             string AV57TFClienteRazaoSocial_Sel ,
                                             string AV56TFClienteRazaoSocial ,
                                             decimal AV10TFTituloValor ,
                                             decimal AV11TFTituloValor_To ,
                                             decimal AV12TFTituloDesconto ,
                                             decimal AV13TFTituloDesconto_To ,
                                             DateTime AV14TFTituloProrrogacao ,
                                             DateTime AV15TFTituloProrrogacao_To ,
                                             int AV17TFTituloTipo_Sels_Count ,
                                             string AV62TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A428CategoriaTituloDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV44FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV61TFTituloCompetencia_F_Sel ,
                                             string AV60TFTituloCompetencia_F ,
                                             int AV65TituloPropostaId ,
                                             int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[21];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T3.NotaFiscalId, T4.ClienteId, T1.TituloPropostaId, T2.CategoriaTituloDescricao, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T5.ClienteRazaoSocial, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, T1.TituloId FROM ((((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.ClienteId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV65TituloPropostaId)");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV47TituloValor1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV47TituloValor1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV47TituloValor1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV51TituloValor2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV51TituloValor2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV51TituloValor2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV55TituloValor3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV55TituloValor3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV55TituloValor3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV63TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV64TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV56TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV57TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV57TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV57TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV10TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV10TFTituloValor)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV11TFTituloValor_To)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV12TFTituloDesconto)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV13TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV13TFTituloDesconto_To)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV14TFTituloProrrogacao)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV15TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV17TFTituloTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17TFTituloTipo_Sels, "T1.TituloTipo IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TituloTipo)) )
         {
            AddWhere(sWhereString, "(T1.TituloTipo = ( :AV62TituloTipo))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloPropostaId, T2.CategoriaTituloDescricao";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AJ3( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV17TFTituloTipo_Sels ,
                                             string AV45DynamicFiltersSelector1 ,
                                             short AV46DynamicFiltersOperator1 ,
                                             decimal AV47TituloValor1 ,
                                             bool AV48DynamicFiltersEnabled2 ,
                                             string AV49DynamicFiltersSelector2 ,
                                             short AV50DynamicFiltersOperator2 ,
                                             decimal AV51TituloValor2 ,
                                             bool AV52DynamicFiltersEnabled3 ,
                                             string AV53DynamicFiltersSelector3 ,
                                             short AV54DynamicFiltersOperator3 ,
                                             decimal AV55TituloValor3 ,
                                             string AV64TFCategoriaTituloDescricao_Sel ,
                                             string AV63TFCategoriaTituloDescricao ,
                                             string AV57TFClienteRazaoSocial_Sel ,
                                             string AV56TFClienteRazaoSocial ,
                                             decimal AV10TFTituloValor ,
                                             decimal AV11TFTituloValor_To ,
                                             decimal AV12TFTituloDesconto ,
                                             decimal AV13TFTituloDesconto_To ,
                                             DateTime AV14TFTituloProrrogacao ,
                                             DateTime AV15TFTituloProrrogacao_To ,
                                             int AV17TFTituloTipo_Sels_Count ,
                                             string AV62TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A428CategoriaTituloDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV44FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV61TFTituloCompetencia_F_Sel ,
                                             string AV60TFTituloCompetencia_F ,
                                             int AV65TituloPropostaId ,
                                             int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[21];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T3.NotaFiscalId, T4.ClienteId, T1.TituloPropostaId, T5.ClienteRazaoSocial, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T2.CategoriaTituloDescricao, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, T1.TituloId FROM ((((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.ClienteId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV65TituloPropostaId)");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV47TituloValor1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV47TituloValor1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV47TituloValor1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV51TituloValor2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV51TituloValor2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV51TituloValor2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV55TituloValor3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV55TituloValor3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV55TituloValor3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV63TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV64TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV56TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV57TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV57TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV57TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV10TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV10TFTituloValor)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV11TFTituloValor_To)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV12TFTituloDesconto)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV13TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV13TFTituloDesconto_To)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV14TFTituloProrrogacao)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV15TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV17TFTituloTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17TFTituloTipo_Sels, "T1.TituloTipo IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TituloTipo)) )
         {
            AddWhere(sWhereString, "(T1.TituloTipo = ( :AV62TituloTipo))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloPropostaId, T5.ClienteRazaoSocial";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AJ4( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV17TFTituloTipo_Sels ,
                                             string AV45DynamicFiltersSelector1 ,
                                             short AV46DynamicFiltersOperator1 ,
                                             decimal AV47TituloValor1 ,
                                             bool AV48DynamicFiltersEnabled2 ,
                                             string AV49DynamicFiltersSelector2 ,
                                             short AV50DynamicFiltersOperator2 ,
                                             decimal AV51TituloValor2 ,
                                             bool AV52DynamicFiltersEnabled3 ,
                                             string AV53DynamicFiltersSelector3 ,
                                             short AV54DynamicFiltersOperator3 ,
                                             decimal AV55TituloValor3 ,
                                             string AV64TFCategoriaTituloDescricao_Sel ,
                                             string AV63TFCategoriaTituloDescricao ,
                                             string AV57TFClienteRazaoSocial_Sel ,
                                             string AV56TFClienteRazaoSocial ,
                                             decimal AV10TFTituloValor ,
                                             decimal AV11TFTituloValor_To ,
                                             decimal AV12TFTituloDesconto ,
                                             decimal AV13TFTituloDesconto_To ,
                                             DateTime AV14TFTituloProrrogacao ,
                                             DateTime AV15TFTituloProrrogacao_To ,
                                             int AV17TFTituloTipo_Sels_Count ,
                                             string AV62TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A428CategoriaTituloDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV44FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV61TFTituloCompetencia_F_Sel ,
                                             string AV60TFTituloCompetencia_F ,
                                             int AV65TituloPropostaId ,
                                             int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[21];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T3.NotaFiscalId, T4.ClienteId, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T5.ClienteRazaoSocial, T2.CategoriaTituloDescricao, T1.TituloPropostaId, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, T1.TituloId FROM ((((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.ClienteId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV65TituloPropostaId)");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV47TituloValor1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV47TituloValor1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV47TituloValor1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV51TituloValor2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV51TituloValor2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV51TituloValor2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV55TituloValor3)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV55TituloValor3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV55TituloValor3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV63TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV64TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV56TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV57TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV57TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV57TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV10TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV10TFTituloValor)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV11TFTituloValor_To)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV12TFTituloDesconto)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV13TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV13TFTituloDesconto_To)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV14TFTituloProrrogacao)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV15TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV17TFTituloTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17TFTituloTipo_Sels, "T1.TituloTipo IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TituloTipo)) )
         {
            AddWhere(sWhereString, "(T1.TituloTipo = ( :AV62TituloTipo))");
         }
         else
         {
            GXv_int5[20] = 1;
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
                     return conditional_P00AJ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] );
               case 1 :
                     return conditional_P00AJ3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] );
               case 2 :
                     return conditional_P00AJ4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] );
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
          Object[] prmP00AJ2;
          prmP00AJ2 = new Object[] {
          new ParDef("AV65TituloPropostaId",GXType.Int32,9,0) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV63TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV64TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV56TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV57TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV10TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV11TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV12TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV13TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV14TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV15TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV62TituloTipo",GXType.VarChar,40,0)
          };
          Object[] prmP00AJ3;
          prmP00AJ3 = new Object[] {
          new ParDef("AV65TituloPropostaId",GXType.Int32,9,0) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV63TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV64TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV56TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV57TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV10TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV11TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV12TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV13TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV14TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV15TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV62TituloTipo",GXType.VarChar,40,0)
          };
          Object[] prmP00AJ4;
          prmP00AJ4 = new Object[] {
          new ParDef("AV65TituloPropostaId",GXType.Int32,9,0) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV63TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV64TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV56TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV57TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV10TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV11TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV12TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV13TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV14TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV15TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV62TituloTipo",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AJ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AJ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AJ4,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((short[]) buf[22])[0] = rslt.getShort(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((short[]) buf[24])[0] = rslt.getShort(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((short[]) buf[22])[0] = rslt.getShort(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((short[]) buf[24])[0] = rslt.getShort(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
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
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((short[]) buf[22])[0] = rslt.getShort(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((short[]) buf[24])[0] = rslt.getShort(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
