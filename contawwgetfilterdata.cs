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
   public class contawwgetfilterdata : GXProcedure
   {
      public contawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contawwgetfilterdata( IGxContext context )
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV16MaxItems = 10;
         AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
         AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_CONTANOMECONTA") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTANOMECONTAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("ContaWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ContaWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("ContaWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONTANOMECONTA") == 0 )
            {
               AV10TFContaNomeConta = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONTANOMECONTA_SEL") == 0 )
            {
               AV11TFContaNomeConta_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONTASALDOATUAL") == 0 )
            {
               AV47TFContaSaldoAtual = NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, ".");
               AV48TFContaSaldoAtual_To = NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONTASTATUS_SEL") == 0 )
            {
               AV12TFContaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "CONTASALDOATUAL") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV38ContaSaldoAtual1 = NumberUtil.Val( AV28GridStateDynamicFilter.gxTpr_Value, ".");
            }
            if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "CONTASALDOATUAL") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV42ContaSaldoAtual2 = NumberUtil.Val( AV28GridStateDynamicFilter.gxTpr_Value, ".");
               }
               if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "CONTASALDOATUAL") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV46ContaSaldoAtual3 = NumberUtil.Val( AV28GridStateDynamicFilter.gxTpr_Value, ".");
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONTANOMECONTAOPTIONS' Routine */
         returnInSub = false;
         AV10TFContaNomeConta = AV13SearchTxt;
         AV11TFContaNomeConta_Sel = "";
         AV51Contawwds_1_filterfulltext = AV35FilterFullText;
         AV52Contawwds_2_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV53Contawwds_3_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV54Contawwds_4_contasaldoatual1 = AV38ContaSaldoAtual1;
         AV55Contawwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV56Contawwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV57Contawwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV58Contawwds_8_contasaldoatual2 = AV42ContaSaldoAtual2;
         AV59Contawwds_9_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV60Contawwds_10_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV61Contawwds_11_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV62Contawwds_12_contasaldoatual3 = AV46ContaSaldoAtual3;
         AV63Contawwds_13_tfcontanomeconta = AV10TFContaNomeConta;
         AV64Contawwds_14_tfcontanomeconta_sel = AV11TFContaNomeConta_Sel;
         AV65Contawwds_15_tfcontasaldoatual = AV47TFContaSaldoAtual;
         AV66Contawwds_16_tfcontasaldoatual_to = AV48TFContaSaldoAtual_To;
         AV67Contawwds_17_tfcontastatus_sel = AV12TFContaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Contawwds_1_filterfulltext ,
                                              AV52Contawwds_2_dynamicfiltersselector1 ,
                                              AV53Contawwds_3_dynamicfiltersoperator1 ,
                                              AV54Contawwds_4_contasaldoatual1 ,
                                              AV55Contawwds_5_dynamicfiltersenabled2 ,
                                              AV56Contawwds_6_dynamicfiltersselector2 ,
                                              AV57Contawwds_7_dynamicfiltersoperator2 ,
                                              AV58Contawwds_8_contasaldoatual2 ,
                                              AV59Contawwds_9_dynamicfiltersenabled3 ,
                                              AV60Contawwds_10_dynamicfiltersselector3 ,
                                              AV61Contawwds_11_dynamicfiltersoperator3 ,
                                              AV62Contawwds_12_contasaldoatual3 ,
                                              AV64Contawwds_14_tfcontanomeconta_sel ,
                                              AV63Contawwds_13_tfcontanomeconta ,
                                              AV65Contawwds_15_tfcontasaldoatual ,
                                              AV66Contawwds_16_tfcontasaldoatual_to ,
                                              AV67Contawwds_17_tfcontastatus_sel ,
                                              A424ContaNomeConta ,
                                              A423ContaSaldoAtual ,
                                              A430ContaStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV51Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Contawwds_1_filterfulltext), "%", "");
         lV51Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Contawwds_1_filterfulltext), "%", "");
         lV51Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Contawwds_1_filterfulltext), "%", "");
         lV51Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Contawwds_1_filterfulltext), "%", "");
         lV63Contawwds_13_tfcontanomeconta = StringUtil.Concat( StringUtil.RTrim( AV63Contawwds_13_tfcontanomeconta), "%", "");
         /* Using cursor P00A02 */
         pr_default.execute(0, new Object[] {lV51Contawwds_1_filterfulltext, lV51Contawwds_1_filterfulltext, lV51Contawwds_1_filterfulltext, lV51Contawwds_1_filterfulltext, AV54Contawwds_4_contasaldoatual1, AV54Contawwds_4_contasaldoatual1, AV54Contawwds_4_contasaldoatual1, AV58Contawwds_8_contasaldoatual2, AV58Contawwds_8_contasaldoatual2, AV58Contawwds_8_contasaldoatual2, AV62Contawwds_12_contasaldoatual3, AV62Contawwds_12_contasaldoatual3, AV62Contawwds_12_contasaldoatual3, lV63Contawwds_13_tfcontanomeconta, AV64Contawwds_14_tfcontanomeconta_sel, AV65Contawwds_15_tfcontasaldoatual, AV66Contawwds_16_tfcontasaldoatual_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKA02 = false;
            A424ContaNomeConta = P00A02_A424ContaNomeConta[0];
            n424ContaNomeConta = P00A02_n424ContaNomeConta[0];
            A423ContaSaldoAtual = P00A02_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = P00A02_n423ContaSaldoAtual[0];
            A430ContaStatus = P00A02_A430ContaStatus[0];
            n430ContaStatus = P00A02_n430ContaStatus[0];
            A422ContaId = P00A02_A422ContaId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00A02_A424ContaNomeConta[0], A424ContaNomeConta) == 0 ) )
            {
               BRKA02 = false;
               A422ContaId = P00A02_A422ContaId[0];
               AV23count = (long)(AV23count+1);
               BRKA02 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A424ContaNomeConta)) ? "<#Empty#>" : A424ContaNomeConta);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRKA02 )
            {
               BRKA02 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV35FilterFullText = "";
         AV10TFContaNomeConta = "";
         AV11TFContaNomeConta_Sel = "";
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV51Contawwds_1_filterfulltext = "";
         AV52Contawwds_2_dynamicfiltersselector1 = "";
         AV56Contawwds_6_dynamicfiltersselector2 = "";
         AV60Contawwds_10_dynamicfiltersselector3 = "";
         AV63Contawwds_13_tfcontanomeconta = "";
         AV64Contawwds_14_tfcontanomeconta_sel = "";
         lV51Contawwds_1_filterfulltext = "";
         lV63Contawwds_13_tfcontanomeconta = "";
         A424ContaNomeConta = "";
         P00A02_A424ContaNomeConta = new string[] {""} ;
         P00A02_n424ContaNomeConta = new bool[] {false} ;
         P00A02_A423ContaSaldoAtual = new decimal[1] ;
         P00A02_n423ContaSaldoAtual = new bool[] {false} ;
         P00A02_A430ContaStatus = new bool[] {false} ;
         P00A02_n430ContaStatus = new bool[] {false} ;
         P00A02_A422ContaId = new int[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00A02_A424ContaNomeConta, P00A02_n424ContaNomeConta, P00A02_A423ContaSaldoAtual, P00A02_n423ContaSaldoAtual, P00A02_A430ContaStatus, P00A02_n430ContaStatus, P00A02_A422ContaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV12TFContaStatus_Sel ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV53Contawwds_3_dynamicfiltersoperator1 ;
      private short AV57Contawwds_7_dynamicfiltersoperator2 ;
      private short AV61Contawwds_11_dynamicfiltersoperator3 ;
      private short AV67Contawwds_17_tfcontastatus_sel ;
      private int AV49GXV1 ;
      private int A422ContaId ;
      private long AV23count ;
      private decimal AV47TFContaSaldoAtual ;
      private decimal AV48TFContaSaldoAtual_To ;
      private decimal AV38ContaSaldoAtual1 ;
      private decimal AV42ContaSaldoAtual2 ;
      private decimal AV46ContaSaldoAtual3 ;
      private decimal AV54Contawwds_4_contasaldoatual1 ;
      private decimal AV58Contawwds_8_contasaldoatual2 ;
      private decimal AV62Contawwds_12_contasaldoatual3 ;
      private decimal AV65Contawwds_15_tfcontasaldoatual ;
      private decimal AV66Contawwds_16_tfcontasaldoatual_to ;
      private decimal A423ContaSaldoAtual ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV55Contawwds_5_dynamicfiltersenabled2 ;
      private bool AV59Contawwds_9_dynamicfiltersenabled3 ;
      private bool A430ContaStatus ;
      private bool BRKA02 ;
      private bool n424ContaNomeConta ;
      private bool n423ContaSaldoAtual ;
      private bool n430ContaStatus ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV10TFContaNomeConta ;
      private string AV11TFContaNomeConta_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Contawwds_1_filterfulltext ;
      private string AV52Contawwds_2_dynamicfiltersselector1 ;
      private string AV56Contawwds_6_dynamicfiltersselector2 ;
      private string AV60Contawwds_10_dynamicfiltersselector3 ;
      private string AV63Contawwds_13_tfcontanomeconta ;
      private string AV64Contawwds_14_tfcontanomeconta_sel ;
      private string lV51Contawwds_1_filterfulltext ;
      private string lV63Contawwds_13_tfcontanomeconta ;
      private string A424ContaNomeConta ;
      private string AV18Option ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00A02_A424ContaNomeConta ;
      private bool[] P00A02_n424ContaNomeConta ;
      private decimal[] P00A02_A423ContaSaldoAtual ;
      private bool[] P00A02_n423ContaSaldoAtual ;
      private bool[] P00A02_A430ContaStatus ;
      private bool[] P00A02_n430ContaStatus ;
      private int[] P00A02_A422ContaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class contawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A02( IGxContext context ,
                                             string AV51Contawwds_1_filterfulltext ,
                                             string AV52Contawwds_2_dynamicfiltersselector1 ,
                                             short AV53Contawwds_3_dynamicfiltersoperator1 ,
                                             decimal AV54Contawwds_4_contasaldoatual1 ,
                                             bool AV55Contawwds_5_dynamicfiltersenabled2 ,
                                             string AV56Contawwds_6_dynamicfiltersselector2 ,
                                             short AV57Contawwds_7_dynamicfiltersoperator2 ,
                                             decimal AV58Contawwds_8_contasaldoatual2 ,
                                             bool AV59Contawwds_9_dynamicfiltersenabled3 ,
                                             string AV60Contawwds_10_dynamicfiltersselector3 ,
                                             short AV61Contawwds_11_dynamicfiltersoperator3 ,
                                             decimal AV62Contawwds_12_contasaldoatual3 ,
                                             string AV64Contawwds_14_tfcontanomeconta_sel ,
                                             string AV63Contawwds_13_tfcontanomeconta ,
                                             decimal AV65Contawwds_15_tfcontasaldoatual ,
                                             decimal AV66Contawwds_16_tfcontasaldoatual_to ,
                                             short AV67Contawwds_17_tfcontastatus_sel ,
                                             string A424ContaNomeConta ,
                                             decimal A423ContaSaldoAtual ,
                                             bool A430ContaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ContaNomeConta, ContaSaldoAtual, ContaStatus, ContaId FROM Conta";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Contawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ContaNomeConta like '%' || :lV51Contawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ContaSaldoAtual,'999999999999990.99'), 2) like '%' || :lV51Contawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV51Contawwds_1_filterfulltext) and ContaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV51Contawwds_1_filterfulltext) and ContaStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Contawwds_2_dynamicfiltersselector1, "CONTASALDOATUAL") == 0 ) && ( AV53Contawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV54Contawwds_4_contasaldoatual1) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual < :AV54Contawwds_4_contasaldoatual1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Contawwds_2_dynamicfiltersselector1, "CONTASALDOATUAL") == 0 ) && ( AV53Contawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV54Contawwds_4_contasaldoatual1) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual = :AV54Contawwds_4_contasaldoatual1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Contawwds_2_dynamicfiltersselector1, "CONTASALDOATUAL") == 0 ) && ( AV53Contawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV54Contawwds_4_contasaldoatual1) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual > :AV54Contawwds_4_contasaldoatual1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV55Contawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Contawwds_6_dynamicfiltersselector2, "CONTASALDOATUAL") == 0 ) && ( AV57Contawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV58Contawwds_8_contasaldoatual2) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual < :AV58Contawwds_8_contasaldoatual2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV55Contawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Contawwds_6_dynamicfiltersselector2, "CONTASALDOATUAL") == 0 ) && ( AV57Contawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV58Contawwds_8_contasaldoatual2) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual = :AV58Contawwds_8_contasaldoatual2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV55Contawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Contawwds_6_dynamicfiltersselector2, "CONTASALDOATUAL") == 0 ) && ( AV57Contawwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV58Contawwds_8_contasaldoatual2) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual > :AV58Contawwds_8_contasaldoatual2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV59Contawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contawwds_10_dynamicfiltersselector3, "CONTASALDOATUAL") == 0 ) && ( AV61Contawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV62Contawwds_12_contasaldoatual3) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual < :AV62Contawwds_12_contasaldoatual3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV59Contawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contawwds_10_dynamicfiltersselector3, "CONTASALDOATUAL") == 0 ) && ( AV61Contawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV62Contawwds_12_contasaldoatual3) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual = :AV62Contawwds_12_contasaldoatual3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV59Contawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contawwds_10_dynamicfiltersselector3, "CONTASALDOATUAL") == 0 ) && ( AV61Contawwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV62Contawwds_12_contasaldoatual3) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual > :AV62Contawwds_12_contasaldoatual3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Contawwds_14_tfcontanomeconta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contawwds_13_tfcontanomeconta)) ) )
         {
            AddWhere(sWhereString, "(ContaNomeConta like :lV63Contawwds_13_tfcontanomeconta)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contawwds_14_tfcontanomeconta_sel)) && ! ( StringUtil.StrCmp(AV64Contawwds_14_tfcontanomeconta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ContaNomeConta = ( :AV64Contawwds_14_tfcontanomeconta_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV64Contawwds_14_tfcontanomeconta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ContaNomeConta IS NULL or (char_length(trim(trailing ' ' from ContaNomeConta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV65Contawwds_15_tfcontasaldoatual) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual >= :AV65Contawwds_15_tfcontasaldoatual)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV66Contawwds_16_tfcontasaldoatual_to) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual <= :AV66Contawwds_16_tfcontasaldoatual_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV67Contawwds_17_tfcontastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ContaStatus = TRUE)");
         }
         if ( AV67Contawwds_17_tfcontastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ContaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ContaNomeConta";
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
                     return conditional_P00A02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00A02;
          prmP00A02 = new Object[] {
          new ParDef("lV51Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Contawwds_4_contasaldoatual1",GXType.Number,18,2) ,
          new ParDef("AV54Contawwds_4_contasaldoatual1",GXType.Number,18,2) ,
          new ParDef("AV54Contawwds_4_contasaldoatual1",GXType.Number,18,2) ,
          new ParDef("AV58Contawwds_8_contasaldoatual2",GXType.Number,18,2) ,
          new ParDef("AV58Contawwds_8_contasaldoatual2",GXType.Number,18,2) ,
          new ParDef("AV58Contawwds_8_contasaldoatual2",GXType.Number,18,2) ,
          new ParDef("AV62Contawwds_12_contasaldoatual3",GXType.Number,18,2) ,
          new ParDef("AV62Contawwds_12_contasaldoatual3",GXType.Number,18,2) ,
          new ParDef("AV62Contawwds_12_contasaldoatual3",GXType.Number,18,2) ,
          new ParDef("lV63Contawwds_13_tfcontanomeconta",GXType.VarChar,60,2) ,
          new ParDef("AV64Contawwds_14_tfcontanomeconta_sel",GXType.VarChar,60,2) ,
          new ParDef("AV65Contawwds_15_tfcontasaldoatual",GXType.Number,18,2) ,
          new ParDef("AV66Contawwds_16_tfcontasaldoatual_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00A02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A02,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
