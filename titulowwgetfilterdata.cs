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
   public class titulowwgetfilterdata : GXProcedure
   {
      public titulowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulowwgetfilterdata( IGxContext context )
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
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_CATEGORIATITULODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADCATEGORIATITULODESCRICAOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("TituloWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TituloWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("TituloWWGridState"), null, "", "");
         }
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL") == 0 )
            {
               AV67TFTituloCLienteRazaoSocial = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV68TFTituloCLienteRazaoSocial_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO") == 0 )
            {
               AV63TFCategoriaTituloDescricao = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO_SEL") == 0 )
            {
               AV64TFCategoriaTituloDescricao_Sel = AV36GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULODATACREDITO_F") == 0 )
            {
               AV65TFTituloDataCredito_F = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV66TFTituloDataCredito_F_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&TITULOTIPO") == 0 )
            {
               AV62TituloTipo = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV69GXV1 = (int)(AV69GXV1+1);
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
         /* 'LOADTITULOCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV67TFTituloCLienteRazaoSocial = AV22SearchTxt;
         AV68TFTituloCLienteRazaoSocial_Sel = "";
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
                                              AV68TFTituloCLienteRazaoSocial_Sel ,
                                              AV67TFTituloCLienteRazaoSocial ,
                                              AV64TFCategoriaTituloDescricao_Sel ,
                                              AV63TFCategoriaTituloDescricao ,
                                              AV10TFTituloValor ,
                                              AV11TFTituloValor_To ,
                                              AV12TFTituloDesconto ,
                                              AV13TFTituloDesconto_To ,
                                              AV14TFTituloProrrogacao ,
                                              AV15TFTituloProrrogacao_To ,
                                              AV17TFTituloTipo_Sels.Count ,
                                              AV62TituloTipo ,
                                              A262TituloValor ,
                                              A972TituloCLienteRazaoSocial ,
                                              A428CategoriaTituloDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV44FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV61TFTituloCompetencia_F_Sel ,
                                              AV60TFTituloCompetencia_F ,
                                              AV65TFTituloDataCredito_F ,
                                              A516TituloDataCredito_F ,
                                              AV66TFTituloDataCredito_F_To } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV67TFTituloCLienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV67TFTituloCLienteRazaoSocial), "%", "");
         lV63TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV63TFCategoriaTituloDescricao), "%", "");
         /* Using cursor P007L3 */
         pr_default.execute(0, new Object[] {AV65TFTituloDataCredito_F, AV65TFTituloDataCredito_F, AV66TFTituloDataCredito_F_To, AV66TFTituloDataCredito_F_To, AV47TituloValor1, AV47TituloValor1, AV47TituloValor1, AV51TituloValor2, AV51TituloValor2, AV51TituloValor2, AV55TituloValor3, AV55TituloValor3, AV55TituloValor3, lV67TFTituloCLienteRazaoSocial, AV68TFTituloCLienteRazaoSocial_Sel, lV63TFCategoriaTituloDescricao, AV64TFCategoriaTituloDescricao_Sel, AV10TFTituloValor, AV11TFTituloValor_To, AV12TFTituloDesconto, AV13TFTituloDesconto_To, AV14TFTituloProrrogacao, AV15TFTituloProrrogacao_To, AV62TituloTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7L2 = false;
            A426CategoriaTituloId = P007L3_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P007L3_n426CategoriaTituloId[0];
            A420TituloClienteId = P007L3_A420TituloClienteId[0];
            n420TituloClienteId = P007L3_n420TituloClienteId[0];
            A261TituloId = P007L3_A261TituloId[0];
            n261TituloId = P007L3_n261TituloId[0];
            A972TituloCLienteRazaoSocial = P007L3_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P007L3_n972TituloCLienteRazaoSocial[0];
            A264TituloProrrogacao = P007L3_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P007L3_n264TituloProrrogacao[0];
            A283TituloTipo = P007L3_A283TituloTipo[0];
            n283TituloTipo = P007L3_n283TituloTipo[0];
            A276TituloDesconto = P007L3_A276TituloDesconto[0];
            n276TituloDesconto = P007L3_n276TituloDesconto[0];
            A262TituloValor = P007L3_A262TituloValor[0];
            n262TituloValor = P007L3_n262TituloValor[0];
            A428CategoriaTituloDescricao = P007L3_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P007L3_n428CategoriaTituloDescricao[0];
            A516TituloDataCredito_F = P007L3_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = P007L3_n516TituloDataCredito_F[0];
            A286TituloCompetenciaAno = P007L3_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P007L3_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P007L3_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P007L3_n287TituloCompetenciaMes[0];
            A428CategoriaTituloDescricao = P007L3_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P007L3_n428CategoriaTituloDescricao[0];
            A972TituloCLienteRazaoSocial = P007L3_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P007L3_n972TituloCLienteRazaoSocial[0];
            A516TituloDataCredito_F = P007L3_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = P007L3_n516TituloDataCredito_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV60TFTituloCompetencia_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ! ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV61TFTituloCompetencia_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV32count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007L3_A972TituloCLienteRazaoSocial[0], A972TituloCLienteRazaoSocial) == 0 ) )
                        {
                           BRK7L2 = false;
                           A420TituloClienteId = P007L3_A420TituloClienteId[0];
                           n420TituloClienteId = P007L3_n420TituloClienteId[0];
                           A261TituloId = P007L3_A261TituloId[0];
                           n261TituloId = P007L3_n261TituloId[0];
                           AV32count = (long)(AV32count+1);
                           BRK7L2 = true;
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
                  }
               }
            }
            if ( ! BRK7L2 )
            {
               BRK7L2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCATEGORIATITULODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV63TFCategoriaTituloDescricao = AV22SearchTxt;
         AV64TFCategoriaTituloDescricao_Sel = "";
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
                                              AV68TFTituloCLienteRazaoSocial_Sel ,
                                              AV67TFTituloCLienteRazaoSocial ,
                                              AV64TFCategoriaTituloDescricao_Sel ,
                                              AV63TFCategoriaTituloDescricao ,
                                              AV10TFTituloValor ,
                                              AV11TFTituloValor_To ,
                                              AV12TFTituloDesconto ,
                                              AV13TFTituloDesconto_To ,
                                              AV14TFTituloProrrogacao ,
                                              AV15TFTituloProrrogacao_To ,
                                              AV17TFTituloTipo_Sels.Count ,
                                              AV62TituloTipo ,
                                              A262TituloValor ,
                                              A972TituloCLienteRazaoSocial ,
                                              A428CategoriaTituloDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV44FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV61TFTituloCompetencia_F_Sel ,
                                              AV60TFTituloCompetencia_F ,
                                              AV65TFTituloDataCredito_F ,
                                              A516TituloDataCredito_F ,
                                              AV66TFTituloDataCredito_F_To } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV67TFTituloCLienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV67TFTituloCLienteRazaoSocial), "%", "");
         lV63TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV63TFCategoriaTituloDescricao), "%", "");
         /* Using cursor P007L5 */
         pr_default.execute(1, new Object[] {AV65TFTituloDataCredito_F, AV65TFTituloDataCredito_F, AV66TFTituloDataCredito_F_To, AV66TFTituloDataCredito_F_To, AV47TituloValor1, AV47TituloValor1, AV47TituloValor1, AV51TituloValor2, AV51TituloValor2, AV51TituloValor2, AV55TituloValor3, AV55TituloValor3, AV55TituloValor3, lV67TFTituloCLienteRazaoSocial, AV68TFTituloCLienteRazaoSocial_Sel, lV63TFCategoriaTituloDescricao, AV64TFCategoriaTituloDescricao_Sel, AV10TFTituloValor, AV11TFTituloValor_To, AV12TFTituloDesconto, AV13TFTituloDesconto_To, AV14TFTituloProrrogacao, AV15TFTituloProrrogacao_To, AV62TituloTipo});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7L4 = false;
            A426CategoriaTituloId = P007L5_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P007L5_n426CategoriaTituloId[0];
            A420TituloClienteId = P007L5_A420TituloClienteId[0];
            n420TituloClienteId = P007L5_n420TituloClienteId[0];
            A261TituloId = P007L5_A261TituloId[0];
            n261TituloId = P007L5_n261TituloId[0];
            A428CategoriaTituloDescricao = P007L5_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P007L5_n428CategoriaTituloDescricao[0];
            A264TituloProrrogacao = P007L5_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P007L5_n264TituloProrrogacao[0];
            A283TituloTipo = P007L5_A283TituloTipo[0];
            n283TituloTipo = P007L5_n283TituloTipo[0];
            A276TituloDesconto = P007L5_A276TituloDesconto[0];
            n276TituloDesconto = P007L5_n276TituloDesconto[0];
            A262TituloValor = P007L5_A262TituloValor[0];
            n262TituloValor = P007L5_n262TituloValor[0];
            A972TituloCLienteRazaoSocial = P007L5_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P007L5_n972TituloCLienteRazaoSocial[0];
            A516TituloDataCredito_F = P007L5_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = P007L5_n516TituloDataCredito_F[0];
            A286TituloCompetenciaAno = P007L5_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P007L5_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P007L5_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P007L5_n287TituloCompetenciaMes[0];
            A428CategoriaTituloDescricao = P007L5_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P007L5_n428CategoriaTituloDescricao[0];
            A972TituloCLienteRazaoSocial = P007L5_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P007L5_n972TituloCLienteRazaoSocial[0];
            A516TituloDataCredito_F = P007L5_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = P007L5_n516TituloDataCredito_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTituloCompetencia_F)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV60TFTituloCompetencia_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTituloCompetencia_F_Sel)) && ! ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV61TFTituloCompetencia_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV61TFTituloCompetencia_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        AV32count = 0;
                        while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007L5_A428CategoriaTituloDescricao[0], A428CategoriaTituloDescricao) == 0 ) )
                        {
                           BRK7L4 = false;
                           A426CategoriaTituloId = P007L5_A426CategoriaTituloId[0];
                           n426CategoriaTituloId = P007L5_n426CategoriaTituloId[0];
                           A261TituloId = P007L5_A261TituloId[0];
                           n261TituloId = P007L5_n261TituloId[0];
                           AV32count = (long)(AV32count+1);
                           BRK7L4 = true;
                           pr_default.readNext(1);
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
            if ( ! BRK7L4 )
            {
               BRK7L4 = true;
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
                                              AV68TFTituloCLienteRazaoSocial_Sel ,
                                              AV67TFTituloCLienteRazaoSocial ,
                                              AV64TFCategoriaTituloDescricao_Sel ,
                                              AV63TFCategoriaTituloDescricao ,
                                              AV10TFTituloValor ,
                                              AV11TFTituloValor_To ,
                                              AV12TFTituloDesconto ,
                                              AV13TFTituloDesconto_To ,
                                              AV14TFTituloProrrogacao ,
                                              AV15TFTituloProrrogacao_To ,
                                              AV17TFTituloTipo_Sels.Count ,
                                              AV62TituloTipo ,
                                              A262TituloValor ,
                                              A972TituloCLienteRazaoSocial ,
                                              A428CategoriaTituloDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV44FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV61TFTituloCompetencia_F_Sel ,
                                              AV60TFTituloCompetencia_F ,
                                              AV65TFTituloDataCredito_F ,
                                              A516TituloDataCredito_F ,
                                              AV66TFTituloDataCredito_F_To } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV67TFTituloCLienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV67TFTituloCLienteRazaoSocial), "%", "");
         lV63TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV63TFCategoriaTituloDescricao), "%", "");
         /* Using cursor P007L7 */
         pr_default.execute(2, new Object[] {AV65TFTituloDataCredito_F, AV65TFTituloDataCredito_F, AV66TFTituloDataCredito_F_To, AV66TFTituloDataCredito_F_To, AV47TituloValor1, AV47TituloValor1, AV47TituloValor1, AV51TituloValor2, AV51TituloValor2, AV51TituloValor2, AV55TituloValor3, AV55TituloValor3, AV55TituloValor3, lV67TFTituloCLienteRazaoSocial, AV68TFTituloCLienteRazaoSocial_Sel, lV63TFCategoriaTituloDescricao, AV64TFCategoriaTituloDescricao_Sel, AV10TFTituloValor, AV11TFTituloValor_To, AV12TFTituloDesconto, AV13TFTituloDesconto_To, AV14TFTituloProrrogacao, AV15TFTituloProrrogacao_To, AV62TituloTipo});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A426CategoriaTituloId = P007L7_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P007L7_n426CategoriaTituloId[0];
            A420TituloClienteId = P007L7_A420TituloClienteId[0];
            n420TituloClienteId = P007L7_n420TituloClienteId[0];
            A261TituloId = P007L7_A261TituloId[0];
            n261TituloId = P007L7_n261TituloId[0];
            A264TituloProrrogacao = P007L7_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P007L7_n264TituloProrrogacao[0];
            A283TituloTipo = P007L7_A283TituloTipo[0];
            n283TituloTipo = P007L7_n283TituloTipo[0];
            A276TituloDesconto = P007L7_A276TituloDesconto[0];
            n276TituloDesconto = P007L7_n276TituloDesconto[0];
            A262TituloValor = P007L7_A262TituloValor[0];
            n262TituloValor = P007L7_n262TituloValor[0];
            A428CategoriaTituloDescricao = P007L7_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P007L7_n428CategoriaTituloDescricao[0];
            A972TituloCLienteRazaoSocial = P007L7_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P007L7_n972TituloCLienteRazaoSocial[0];
            A516TituloDataCredito_F = P007L7_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = P007L7_n516TituloDataCredito_F[0];
            A286TituloCompetenciaAno = P007L7_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P007L7_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P007L7_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P007L7_n287TituloCompetenciaMes[0];
            A428CategoriaTituloDescricao = P007L7_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P007L7_n428CategoriaTituloDescricao[0];
            A972TituloCLienteRazaoSocial = P007L7_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P007L7_n972TituloCLienteRazaoSocial[0];
            A516TituloDataCredito_F = P007L7_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = P007L7_n516TituloDataCredito_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV44FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV44FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
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
         AV67TFTituloCLienteRazaoSocial = "";
         AV68TFTituloCLienteRazaoSocial_Sel = "";
         AV63TFCategoriaTituloDescricao = "";
         AV64TFCategoriaTituloDescricao_Sel = "";
         AV60TFTituloCompetencia_F = "";
         AV61TFTituloCompetencia_F_Sel = "";
         AV14TFTituloProrrogacao = DateTime.MinValue;
         AV15TFTituloProrrogacao_To = DateTime.MinValue;
         AV16TFTituloTipo_SelsJson = "";
         AV17TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV65TFTituloDataCredito_F = DateTime.MinValue;
         AV66TFTituloDataCredito_F_To = DateTime.MinValue;
         AV62TituloTipo = "";
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV49DynamicFiltersSelector2 = "";
         AV53DynamicFiltersSelector3 = "";
         lV44FilterFullText = "";
         lV67TFTituloCLienteRazaoSocial = "";
         lV63TFCategoriaTituloDescricao = "";
         A283TituloTipo = "";
         A972TituloCLienteRazaoSocial = "";
         A428CategoriaTituloDescricao = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A516TituloDataCredito_F = DateTime.MinValue;
         P007L3_A426CategoriaTituloId = new int[1] ;
         P007L3_n426CategoriaTituloId = new bool[] {false} ;
         P007L3_A420TituloClienteId = new int[1] ;
         P007L3_n420TituloClienteId = new bool[] {false} ;
         P007L3_A261TituloId = new int[1] ;
         P007L3_n261TituloId = new bool[] {false} ;
         P007L3_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P007L3_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P007L3_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P007L3_n264TituloProrrogacao = new bool[] {false} ;
         P007L3_A283TituloTipo = new string[] {""} ;
         P007L3_n283TituloTipo = new bool[] {false} ;
         P007L3_A276TituloDesconto = new decimal[1] ;
         P007L3_n276TituloDesconto = new bool[] {false} ;
         P007L3_A262TituloValor = new decimal[1] ;
         P007L3_n262TituloValor = new bool[] {false} ;
         P007L3_A428CategoriaTituloDescricao = new string[] {""} ;
         P007L3_n428CategoriaTituloDescricao = new bool[] {false} ;
         P007L3_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         P007L3_n516TituloDataCredito_F = new bool[] {false} ;
         P007L3_A286TituloCompetenciaAno = new short[1] ;
         P007L3_n286TituloCompetenciaAno = new bool[] {false} ;
         P007L3_A287TituloCompetenciaMes = new short[1] ;
         P007L3_n287TituloCompetenciaMes = new bool[] {false} ;
         AV27Option = "";
         P007L5_A426CategoriaTituloId = new int[1] ;
         P007L5_n426CategoriaTituloId = new bool[] {false} ;
         P007L5_A420TituloClienteId = new int[1] ;
         P007L5_n420TituloClienteId = new bool[] {false} ;
         P007L5_A261TituloId = new int[1] ;
         P007L5_n261TituloId = new bool[] {false} ;
         P007L5_A428CategoriaTituloDescricao = new string[] {""} ;
         P007L5_n428CategoriaTituloDescricao = new bool[] {false} ;
         P007L5_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P007L5_n264TituloProrrogacao = new bool[] {false} ;
         P007L5_A283TituloTipo = new string[] {""} ;
         P007L5_n283TituloTipo = new bool[] {false} ;
         P007L5_A276TituloDesconto = new decimal[1] ;
         P007L5_n276TituloDesconto = new bool[] {false} ;
         P007L5_A262TituloValor = new decimal[1] ;
         P007L5_n262TituloValor = new bool[] {false} ;
         P007L5_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P007L5_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P007L5_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         P007L5_n516TituloDataCredito_F = new bool[] {false} ;
         P007L5_A286TituloCompetenciaAno = new short[1] ;
         P007L5_n286TituloCompetenciaAno = new bool[] {false} ;
         P007L5_A287TituloCompetenciaMes = new short[1] ;
         P007L5_n287TituloCompetenciaMes = new bool[] {false} ;
         P007L7_A426CategoriaTituloId = new int[1] ;
         P007L7_n426CategoriaTituloId = new bool[] {false} ;
         P007L7_A420TituloClienteId = new int[1] ;
         P007L7_n420TituloClienteId = new bool[] {false} ;
         P007L7_A261TituloId = new int[1] ;
         P007L7_n261TituloId = new bool[] {false} ;
         P007L7_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P007L7_n264TituloProrrogacao = new bool[] {false} ;
         P007L7_A283TituloTipo = new string[] {""} ;
         P007L7_n283TituloTipo = new bool[] {false} ;
         P007L7_A276TituloDesconto = new decimal[1] ;
         P007L7_n276TituloDesconto = new bool[] {false} ;
         P007L7_A262TituloValor = new decimal[1] ;
         P007L7_n262TituloValor = new bool[] {false} ;
         P007L7_A428CategoriaTituloDescricao = new string[] {""} ;
         P007L7_n428CategoriaTituloDescricao = new bool[] {false} ;
         P007L7_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P007L7_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P007L7_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         P007L7_n516TituloDataCredito_F = new bool[] {false} ;
         P007L7_A286TituloCompetenciaAno = new short[1] ;
         P007L7_n286TituloCompetenciaAno = new bool[] {false} ;
         P007L7_A287TituloCompetenciaMes = new short[1] ;
         P007L7_n287TituloCompetenciaMes = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007L3_A426CategoriaTituloId, P007L3_n426CategoriaTituloId, P007L3_A420TituloClienteId, P007L3_n420TituloClienteId, P007L3_A261TituloId, P007L3_A972TituloCLienteRazaoSocial, P007L3_n972TituloCLienteRazaoSocial, P007L3_A264TituloProrrogacao, P007L3_n264TituloProrrogacao, P007L3_A283TituloTipo,
               P007L3_n283TituloTipo, P007L3_A276TituloDesconto, P007L3_n276TituloDesconto, P007L3_A262TituloValor, P007L3_n262TituloValor, P007L3_A428CategoriaTituloDescricao, P007L3_n428CategoriaTituloDescricao, P007L3_A516TituloDataCredito_F, P007L3_n516TituloDataCredito_F, P007L3_A286TituloCompetenciaAno,
               P007L3_n286TituloCompetenciaAno, P007L3_A287TituloCompetenciaMes, P007L3_n287TituloCompetenciaMes
               }
               , new Object[] {
               P007L5_A426CategoriaTituloId, P007L5_n426CategoriaTituloId, P007L5_A420TituloClienteId, P007L5_n420TituloClienteId, P007L5_A261TituloId, P007L5_A428CategoriaTituloDescricao, P007L5_n428CategoriaTituloDescricao, P007L5_A264TituloProrrogacao, P007L5_n264TituloProrrogacao, P007L5_A283TituloTipo,
               P007L5_n283TituloTipo, P007L5_A276TituloDesconto, P007L5_n276TituloDesconto, P007L5_A262TituloValor, P007L5_n262TituloValor, P007L5_A972TituloCLienteRazaoSocial, P007L5_n972TituloCLienteRazaoSocial, P007L5_A516TituloDataCredito_F, P007L5_n516TituloDataCredito_F, P007L5_A286TituloCompetenciaAno,
               P007L5_n286TituloCompetenciaAno, P007L5_A287TituloCompetenciaMes, P007L5_n287TituloCompetenciaMes
               }
               , new Object[] {
               P007L7_A426CategoriaTituloId, P007L7_n426CategoriaTituloId, P007L7_A420TituloClienteId, P007L7_n420TituloClienteId, P007L7_A261TituloId, P007L7_A264TituloProrrogacao, P007L7_n264TituloProrrogacao, P007L7_A283TituloTipo, P007L7_n283TituloTipo, P007L7_A276TituloDesconto,
               P007L7_n276TituloDesconto, P007L7_A262TituloValor, P007L7_n262TituloValor, P007L7_A428CategoriaTituloDescricao, P007L7_n428CategoriaTituloDescricao, P007L7_A972TituloCLienteRazaoSocial, P007L7_n972TituloCLienteRazaoSocial, P007L7_A516TituloDataCredito_F, P007L7_n516TituloDataCredito_F, P007L7_A286TituloCompetenciaAno,
               P007L7_n286TituloCompetenciaAno, P007L7_A287TituloCompetenciaMes, P007L7_n287TituloCompetenciaMes
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
      private int AV69GXV1 ;
      private int AV17TFTituloTipo_Sels_Count ;
      private int A426CategoriaTituloId ;
      private int A420TituloClienteId ;
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
      private DateTime AV65TFTituloDataCredito_F ;
      private DateTime AV66TFTituloDataCredito_F_To ;
      private DateTime A264TituloProrrogacao ;
      private DateTime A516TituloDataCredito_F ;
      private bool returnInSub ;
      private bool AV48DynamicFiltersEnabled2 ;
      private bool AV52DynamicFiltersEnabled3 ;
      private bool BRK7L2 ;
      private bool n426CategoriaTituloId ;
      private bool n420TituloClienteId ;
      private bool n261TituloId ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n264TituloProrrogacao ;
      private bool n283TituloTipo ;
      private bool n276TituloDesconto ;
      private bool n262TituloValor ;
      private bool n428CategoriaTituloDescricao ;
      private bool n516TituloDataCredito_F ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool BRK7L4 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV16TFTituloTipo_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV67TFTituloCLienteRazaoSocial ;
      private string AV68TFTituloCLienteRazaoSocial_Sel ;
      private string AV63TFCategoriaTituloDescricao ;
      private string AV64TFCategoriaTituloDescricao_Sel ;
      private string AV60TFTituloCompetencia_F ;
      private string AV61TFTituloCompetencia_F_Sel ;
      private string AV62TituloTipo ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV49DynamicFiltersSelector2 ;
      private string AV53DynamicFiltersSelector3 ;
      private string lV44FilterFullText ;
      private string lV67TFTituloCLienteRazaoSocial ;
      private string lV63TFCategoriaTituloDescricao ;
      private string A283TituloTipo ;
      private string A972TituloCLienteRazaoSocial ;
      private string A428CategoriaTituloDescricao ;
      private string A295TituloCompetencia_F ;
      private string AV27Option ;
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
      private int[] P007L3_A426CategoriaTituloId ;
      private bool[] P007L3_n426CategoriaTituloId ;
      private int[] P007L3_A420TituloClienteId ;
      private bool[] P007L3_n420TituloClienteId ;
      private int[] P007L3_A261TituloId ;
      private bool[] P007L3_n261TituloId ;
      private string[] P007L3_A972TituloCLienteRazaoSocial ;
      private bool[] P007L3_n972TituloCLienteRazaoSocial ;
      private DateTime[] P007L3_A264TituloProrrogacao ;
      private bool[] P007L3_n264TituloProrrogacao ;
      private string[] P007L3_A283TituloTipo ;
      private bool[] P007L3_n283TituloTipo ;
      private decimal[] P007L3_A276TituloDesconto ;
      private bool[] P007L3_n276TituloDesconto ;
      private decimal[] P007L3_A262TituloValor ;
      private bool[] P007L3_n262TituloValor ;
      private string[] P007L3_A428CategoriaTituloDescricao ;
      private bool[] P007L3_n428CategoriaTituloDescricao ;
      private DateTime[] P007L3_A516TituloDataCredito_F ;
      private bool[] P007L3_n516TituloDataCredito_F ;
      private short[] P007L3_A286TituloCompetenciaAno ;
      private bool[] P007L3_n286TituloCompetenciaAno ;
      private short[] P007L3_A287TituloCompetenciaMes ;
      private bool[] P007L3_n287TituloCompetenciaMes ;
      private int[] P007L5_A426CategoriaTituloId ;
      private bool[] P007L5_n426CategoriaTituloId ;
      private int[] P007L5_A420TituloClienteId ;
      private bool[] P007L5_n420TituloClienteId ;
      private int[] P007L5_A261TituloId ;
      private bool[] P007L5_n261TituloId ;
      private string[] P007L5_A428CategoriaTituloDescricao ;
      private bool[] P007L5_n428CategoriaTituloDescricao ;
      private DateTime[] P007L5_A264TituloProrrogacao ;
      private bool[] P007L5_n264TituloProrrogacao ;
      private string[] P007L5_A283TituloTipo ;
      private bool[] P007L5_n283TituloTipo ;
      private decimal[] P007L5_A276TituloDesconto ;
      private bool[] P007L5_n276TituloDesconto ;
      private decimal[] P007L5_A262TituloValor ;
      private bool[] P007L5_n262TituloValor ;
      private string[] P007L5_A972TituloCLienteRazaoSocial ;
      private bool[] P007L5_n972TituloCLienteRazaoSocial ;
      private DateTime[] P007L5_A516TituloDataCredito_F ;
      private bool[] P007L5_n516TituloDataCredito_F ;
      private short[] P007L5_A286TituloCompetenciaAno ;
      private bool[] P007L5_n286TituloCompetenciaAno ;
      private short[] P007L5_A287TituloCompetenciaMes ;
      private bool[] P007L5_n287TituloCompetenciaMes ;
      private int[] P007L7_A426CategoriaTituloId ;
      private bool[] P007L7_n426CategoriaTituloId ;
      private int[] P007L7_A420TituloClienteId ;
      private bool[] P007L7_n420TituloClienteId ;
      private int[] P007L7_A261TituloId ;
      private bool[] P007L7_n261TituloId ;
      private DateTime[] P007L7_A264TituloProrrogacao ;
      private bool[] P007L7_n264TituloProrrogacao ;
      private string[] P007L7_A283TituloTipo ;
      private bool[] P007L7_n283TituloTipo ;
      private decimal[] P007L7_A276TituloDesconto ;
      private bool[] P007L7_n276TituloDesconto ;
      private decimal[] P007L7_A262TituloValor ;
      private bool[] P007L7_n262TituloValor ;
      private string[] P007L7_A428CategoriaTituloDescricao ;
      private bool[] P007L7_n428CategoriaTituloDescricao ;
      private string[] P007L7_A972TituloCLienteRazaoSocial ;
      private bool[] P007L7_n972TituloCLienteRazaoSocial ;
      private DateTime[] P007L7_A516TituloDataCredito_F ;
      private bool[] P007L7_n516TituloDataCredito_F ;
      private short[] P007L7_A286TituloCompetenciaAno ;
      private bool[] P007L7_n286TituloCompetenciaAno ;
      private short[] P007L7_A287TituloCompetenciaMes ;
      private bool[] P007L7_n287TituloCompetenciaMes ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class titulowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007L3( IGxContext context ,
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
                                             string AV68TFTituloCLienteRazaoSocial_Sel ,
                                             string AV67TFTituloCLienteRazaoSocial ,
                                             string AV64TFCategoriaTituloDescricao_Sel ,
                                             string AV63TFCategoriaTituloDescricao ,
                                             decimal AV10TFTituloValor ,
                                             decimal AV11TFTituloValor_To ,
                                             decimal AV12TFTituloDesconto ,
                                             decimal AV13TFTituloDesconto_To ,
                                             DateTime AV14TFTituloProrrogacao ,
                                             DateTime AV15TFTituloProrrogacao_To ,
                                             int AV17TFTituloTipo_Sels_Count ,
                                             string AV62TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A428CategoriaTituloDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV44FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV61TFTituloCompetencia_F_Sel ,
                                             string AV60TFTituloCompetencia_F ,
                                             DateTime AV65TFTituloDataCredito_F ,
                                             DateTime A516TituloDataCredito_F ,
                                             DateTime AV66TFTituloDataCredito_F_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T3.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T2.CategoriaTituloDescricao, COALESCE( T4.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV65TFTituloDataCredito_F = DATE '00010101') or ( COALESCE( T4.TituloDataCredito_F, DATE '00010101') >= :AV65TFTituloDataCredito_F))");
         AddWhere(sWhereString, "((:AV66TFTituloDataCredito_F_To = DATE '00010101') or ( COALESCE( T4.TituloDataCredito_F, DATE '00010101') <= :AV66TFTituloDataCredito_F_To))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV47TituloValor1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV47TituloValor1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV47TituloValor1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV51TituloValor2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV51TituloValor2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV51TituloValor2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV55TituloValor3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV55TituloValor3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV55TituloValor3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFTituloCLienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFTituloCLienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV67TFTituloCLienteRazaoSocial)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFTituloCLienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV68TFTituloCLienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV68TFTituloCLienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68TFTituloCLienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV63TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV64TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV10TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV10TFTituloValor)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV11TFTituloValor_To)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV12TFTituloDesconto)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV13TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV13TFTituloDesconto_To)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV14TFTituloProrrogacao)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV15TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int1[22] = 1;
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
            GXv_int1[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007L5( IGxContext context ,
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
                                             string AV68TFTituloCLienteRazaoSocial_Sel ,
                                             string AV67TFTituloCLienteRazaoSocial ,
                                             string AV64TFCategoriaTituloDescricao_Sel ,
                                             string AV63TFCategoriaTituloDescricao ,
                                             decimal AV10TFTituloValor ,
                                             decimal AV11TFTituloValor_To ,
                                             decimal AV12TFTituloDesconto ,
                                             decimal AV13TFTituloDesconto_To ,
                                             DateTime AV14TFTituloProrrogacao ,
                                             DateTime AV15TFTituloProrrogacao_To ,
                                             int AV17TFTituloTipo_Sels_Count ,
                                             string AV62TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A428CategoriaTituloDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV44FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV61TFTituloCompetencia_F_Sel ,
                                             string AV60TFTituloCompetencia_F ,
                                             DateTime AV65TFTituloDataCredito_F ,
                                             DateTime A516TituloDataCredito_F ,
                                             DateTime AV66TFTituloDataCredito_F_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T2.CategoriaTituloDescricao, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T3.ClienteRazaoSocial AS TituloCLienteRazaoSocial, COALESCE( T4.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV65TFTituloDataCredito_F = DATE '00010101') or ( COALESCE( T4.TituloDataCredito_F, DATE '00010101') >= :AV65TFTituloDataCredito_F))");
         AddWhere(sWhereString, "((:AV66TFTituloDataCredito_F_To = DATE '00010101') or ( COALESCE( T4.TituloDataCredito_F, DATE '00010101') <= :AV66TFTituloDataCredito_F_To))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV47TituloValor1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV47TituloValor1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV47TituloValor1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV51TituloValor2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV51TituloValor2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV51TituloValor2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV55TituloValor3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV55TituloValor3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV55TituloValor3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFTituloCLienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFTituloCLienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV67TFTituloCLienteRazaoSocial)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFTituloCLienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV68TFTituloCLienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV68TFTituloCLienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68TFTituloCLienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV63TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV64TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV10TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV10TFTituloValor)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV11TFTituloValor_To)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV12TFTituloDesconto)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV13TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV13TFTituloDesconto_To)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV14TFTituloProrrogacao)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV15TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int3[22] = 1;
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
            GXv_int3[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.CategoriaTituloDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007L7( IGxContext context ,
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
                                             string AV68TFTituloCLienteRazaoSocial_Sel ,
                                             string AV67TFTituloCLienteRazaoSocial ,
                                             string AV64TFCategoriaTituloDescricao_Sel ,
                                             string AV63TFCategoriaTituloDescricao ,
                                             decimal AV10TFTituloValor ,
                                             decimal AV11TFTituloValor_To ,
                                             decimal AV12TFTituloDesconto ,
                                             decimal AV13TFTituloDesconto_To ,
                                             DateTime AV14TFTituloProrrogacao ,
                                             DateTime AV15TFTituloProrrogacao_To ,
                                             int AV17TFTituloTipo_Sels_Count ,
                                             string AV62TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A428CategoriaTituloDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             string AV44FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV61TFTituloCompetencia_F_Sel ,
                                             string AV60TFTituloCompetencia_F ,
                                             DateTime AV65TFTituloDataCredito_F ,
                                             DateTime A516TituloDataCredito_F ,
                                             DateTime AV66TFTituloDataCredito_F_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T2.CategoriaTituloDescricao, T3.ClienteRazaoSocial AS TituloCLienteRazaoSocial, COALESCE( T4.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.TituloClienteId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T1.TituloId = TituloId GROUP BY TituloId ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV65TFTituloDataCredito_F = DATE '00010101') or ( COALESCE( T4.TituloDataCredito_F, DATE '00010101') >= :AV65TFTituloDataCredito_F))");
         AddWhere(sWhereString, "((:AV66TFTituloDataCredito_F_To = DATE '00010101') or ( COALESCE( T4.TituloDataCredito_F, DATE '00010101') <= :AV66TFTituloDataCredito_F_To))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV47TituloValor1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV47TituloValor1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV46DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV47TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV47TituloValor1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV51TituloValor2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV51TituloValor2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV48DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV50DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV51TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV51TituloValor2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV55TituloValor3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV55TituloValor3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV52DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV54DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV55TituloValor3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFTituloCLienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFTituloCLienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV67TFTituloCLienteRazaoSocial)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFTituloCLienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV68TFTituloCLienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV68TFTituloCLienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68TFTituloCLienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV63TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV64TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV10TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV10TFTituloValor)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV11TFTituloValor_To)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV12TFTituloDesconto)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV13TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV13TFTituloDesconto_To)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV14TFTituloProrrogacao)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV15TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int5[22] = 1;
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
            GXv_int5[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TituloId";
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
                     return conditional_P007L3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (DateTime)dynConstraints[36] );
               case 1 :
                     return conditional_P007L5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (DateTime)dynConstraints[36] );
               case 2 :
                     return conditional_P007L7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (DateTime)dynConstraints[36] );
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
          Object[] prmP007L3;
          prmP007L3 = new Object[] {
          new ParDef("AV65TFTituloDataCredito_F",GXType.Date,8,0) ,
          new ParDef("AV65TFTituloDataCredito_F",GXType.Date,8,0) ,
          new ParDef("AV66TFTituloDataCredito_F_To",GXType.Date,8,0) ,
          new ParDef("AV66TFTituloDataCredito_F_To",GXType.Date,8,0) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV67TFTituloCLienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV68TFTituloCLienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV63TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV64TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV10TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV11TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV12TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV13TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV14TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV15TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV62TituloTipo",GXType.VarChar,40,0)
          };
          Object[] prmP007L5;
          prmP007L5 = new Object[] {
          new ParDef("AV65TFTituloDataCredito_F",GXType.Date,8,0) ,
          new ParDef("AV65TFTituloDataCredito_F",GXType.Date,8,0) ,
          new ParDef("AV66TFTituloDataCredito_F_To",GXType.Date,8,0) ,
          new ParDef("AV66TFTituloDataCredito_F_To",GXType.Date,8,0) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV67TFTituloCLienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV68TFTituloCLienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV63TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV64TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV10TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV11TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV12TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV13TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV14TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV15TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV62TituloTipo",GXType.VarChar,40,0)
          };
          Object[] prmP007L7;
          prmP007L7 = new Object[] {
          new ParDef("AV65TFTituloDataCredito_F",GXType.Date,8,0) ,
          new ParDef("AV65TFTituloDataCredito_F",GXType.Date,8,0) ,
          new ParDef("AV66TFTituloDataCredito_F_To",GXType.Date,8,0) ,
          new ParDef("AV66TFTituloDataCredito_F_To",GXType.Date,8,0) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV47TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV51TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV55TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV67TFTituloCLienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV68TFTituloCLienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV63TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV64TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV10TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV11TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV12TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV13TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV14TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV15TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV62TituloTipo",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
