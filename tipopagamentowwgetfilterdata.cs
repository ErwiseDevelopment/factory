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
   public class tipopagamentowwgetfilterdata : GXProcedure
   {
      public tipopagamentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipopagamentowwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_TIPOPAGAMENTONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPOPAGAMENTONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("TipoPagamentoWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoPagamentoWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("TipoPagamentoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTOID") == 0 )
            {
               AV10TFTipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFTipoPagamentoId_To = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME") == 0 )
            {
               AV12TFTipoPagamentoNome = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME_SEL") == 0 )
            {
               AV13TFTipoPagamentoNome_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV39TipoPagamentoNome1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV40DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV41DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV41DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
               {
                  AV42DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV43TipoPagamentoNome2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV44DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV45DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV47TipoPagamentoNome3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPOPAGAMENTONOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipoPagamentoNome = AV14SearchTxt;
         AV13TFTipoPagamentoNome_Sel = "";
         AV50Tipopagamentowwds_1_filterfulltext = AV36FilterFullText;
         AV51Tipopagamentowwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV52Tipopagamentowwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV53Tipopagamentowwds_4_tipopagamentonome1 = AV39TipoPagamentoNome1;
         AV54Tipopagamentowwds_5_dynamicfiltersenabled2 = AV40DynamicFiltersEnabled2;
         AV55Tipopagamentowwds_6_dynamicfiltersselector2 = AV41DynamicFiltersSelector2;
         AV56Tipopagamentowwds_7_dynamicfiltersoperator2 = AV42DynamicFiltersOperator2;
         AV57Tipopagamentowwds_8_tipopagamentonome2 = AV43TipoPagamentoNome2;
         AV58Tipopagamentowwds_9_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV59Tipopagamentowwds_10_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV60Tipopagamentowwds_11_dynamicfiltersoperator3 = AV46DynamicFiltersOperator3;
         AV61Tipopagamentowwds_12_tipopagamentonome3 = AV47TipoPagamentoNome3;
         AV62Tipopagamentowwds_13_tftipopagamentoid = AV10TFTipoPagamentoId;
         AV63Tipopagamentowwds_14_tftipopagamentoid_to = AV11TFTipoPagamentoId_To;
         AV64Tipopagamentowwds_15_tftipopagamentonome = AV12TFTipoPagamentoNome;
         AV65Tipopagamentowwds_16_tftipopagamentonome_sel = AV13TFTipoPagamentoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Tipopagamentowwds_1_filterfulltext ,
                                              AV51Tipopagamentowwds_2_dynamicfiltersselector1 ,
                                              AV52Tipopagamentowwds_3_dynamicfiltersoperator1 ,
                                              AV53Tipopagamentowwds_4_tipopagamentonome1 ,
                                              AV54Tipopagamentowwds_5_dynamicfiltersenabled2 ,
                                              AV55Tipopagamentowwds_6_dynamicfiltersselector2 ,
                                              AV56Tipopagamentowwds_7_dynamicfiltersoperator2 ,
                                              AV57Tipopagamentowwds_8_tipopagamentonome2 ,
                                              AV58Tipopagamentowwds_9_dynamicfiltersenabled3 ,
                                              AV59Tipopagamentowwds_10_dynamicfiltersselector3 ,
                                              AV60Tipopagamentowwds_11_dynamicfiltersoperator3 ,
                                              AV61Tipopagamentowwds_12_tipopagamentonome3 ,
                                              AV62Tipopagamentowwds_13_tftipopagamentoid ,
                                              AV63Tipopagamentowwds_14_tftipopagamentoid_to ,
                                              AV65Tipopagamentowwds_16_tftipopagamentonome_sel ,
                                              AV64Tipopagamentowwds_15_tftipopagamentonome ,
                                              A288TipoPagamentoId ,
                                              A289TipoPagamentoNome } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV50Tipopagamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Tipopagamentowwds_1_filterfulltext), "%", "");
         lV50Tipopagamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Tipopagamentowwds_1_filterfulltext), "%", "");
         lV53Tipopagamentowwds_4_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV53Tipopagamentowwds_4_tipopagamentonome1), "%", "");
         lV53Tipopagamentowwds_4_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV53Tipopagamentowwds_4_tipopagamentonome1), "%", "");
         lV57Tipopagamentowwds_8_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV57Tipopagamentowwds_8_tipopagamentonome2), "%", "");
         lV57Tipopagamentowwds_8_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV57Tipopagamentowwds_8_tipopagamentonome2), "%", "");
         lV61Tipopagamentowwds_12_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV61Tipopagamentowwds_12_tipopagamentonome3), "%", "");
         lV61Tipopagamentowwds_12_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV61Tipopagamentowwds_12_tipopagamentonome3), "%", "");
         lV64Tipopagamentowwds_15_tftipopagamentonome = StringUtil.Concat( StringUtil.RTrim( AV64Tipopagamentowwds_15_tftipopagamentonome), "%", "");
         /* Using cursor P007M2 */
         pr_default.execute(0, new Object[] {lV50Tipopagamentowwds_1_filterfulltext, lV50Tipopagamentowwds_1_filterfulltext, lV53Tipopagamentowwds_4_tipopagamentonome1, lV53Tipopagamentowwds_4_tipopagamentonome1, lV57Tipopagamentowwds_8_tipopagamentonome2, lV57Tipopagamentowwds_8_tipopagamentonome2, lV61Tipopagamentowwds_12_tipopagamentonome3, lV61Tipopagamentowwds_12_tipopagamentonome3, AV62Tipopagamentowwds_13_tftipopagamentoid, AV63Tipopagamentowwds_14_tftipopagamentoid_to, lV64Tipopagamentowwds_15_tftipopagamentonome, AV65Tipopagamentowwds_16_tftipopagamentonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7M2 = false;
            A289TipoPagamentoNome = P007M2_A289TipoPagamentoNome[0];
            A288TipoPagamentoId = P007M2_A288TipoPagamentoId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007M2_A289TipoPagamentoNome[0], A289TipoPagamentoNome) == 0 ) )
            {
               BRK7M2 = false;
               A288TipoPagamentoId = P007M2_A288TipoPagamentoId[0];
               AV24count = (long)(AV24count+1);
               BRK7M2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A289TipoPagamentoNome)) ? "<#Empty#>" : A289TipoPagamentoNome);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK7M2 )
            {
               BRK7M2 = true;
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV12TFTipoPagamentoNome = "";
         AV13TFTipoPagamentoNome_Sel = "";
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV39TipoPagamentoNome1 = "";
         AV41DynamicFiltersSelector2 = "";
         AV43TipoPagamentoNome2 = "";
         AV45DynamicFiltersSelector3 = "";
         AV47TipoPagamentoNome3 = "";
         AV50Tipopagamentowwds_1_filterfulltext = "";
         AV51Tipopagamentowwds_2_dynamicfiltersselector1 = "";
         AV53Tipopagamentowwds_4_tipopagamentonome1 = "";
         AV55Tipopagamentowwds_6_dynamicfiltersselector2 = "";
         AV57Tipopagamentowwds_8_tipopagamentonome2 = "";
         AV59Tipopagamentowwds_10_dynamicfiltersselector3 = "";
         AV61Tipopagamentowwds_12_tipopagamentonome3 = "";
         AV64Tipopagamentowwds_15_tftipopagamentonome = "";
         AV65Tipopagamentowwds_16_tftipopagamentonome_sel = "";
         lV50Tipopagamentowwds_1_filterfulltext = "";
         lV53Tipopagamentowwds_4_tipopagamentonome1 = "";
         lV57Tipopagamentowwds_8_tipopagamentonome2 = "";
         lV61Tipopagamentowwds_12_tipopagamentonome3 = "";
         lV64Tipopagamentowwds_15_tftipopagamentonome = "";
         A289TipoPagamentoNome = "";
         P007M2_A289TipoPagamentoNome = new string[] {""} ;
         P007M2_A288TipoPagamentoId = new int[1] ;
         AV19Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipopagamentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007M2_A289TipoPagamentoNome, P007M2_A288TipoPagamentoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV38DynamicFiltersOperator1 ;
      private short AV42DynamicFiltersOperator2 ;
      private short AV46DynamicFiltersOperator3 ;
      private short AV52Tipopagamentowwds_3_dynamicfiltersoperator1 ;
      private short AV56Tipopagamentowwds_7_dynamicfiltersoperator2 ;
      private short AV60Tipopagamentowwds_11_dynamicfiltersoperator3 ;
      private int AV48GXV1 ;
      private int AV10TFTipoPagamentoId ;
      private int AV11TFTipoPagamentoId_To ;
      private int AV62Tipopagamentowwds_13_tftipopagamentoid ;
      private int AV63Tipopagamentowwds_14_tftipopagamentoid_to ;
      private int A288TipoPagamentoId ;
      private long AV24count ;
      private bool returnInSub ;
      private bool AV40DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool AV54Tipopagamentowwds_5_dynamicfiltersenabled2 ;
      private bool AV58Tipopagamentowwds_9_dynamicfiltersenabled3 ;
      private bool BRK7M2 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV12TFTipoPagamentoNome ;
      private string AV13TFTipoPagamentoNome_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV39TipoPagamentoNome1 ;
      private string AV41DynamicFiltersSelector2 ;
      private string AV43TipoPagamentoNome2 ;
      private string AV45DynamicFiltersSelector3 ;
      private string AV47TipoPagamentoNome3 ;
      private string AV50Tipopagamentowwds_1_filterfulltext ;
      private string AV51Tipopagamentowwds_2_dynamicfiltersselector1 ;
      private string AV53Tipopagamentowwds_4_tipopagamentonome1 ;
      private string AV55Tipopagamentowwds_6_dynamicfiltersselector2 ;
      private string AV57Tipopagamentowwds_8_tipopagamentonome2 ;
      private string AV59Tipopagamentowwds_10_dynamicfiltersselector3 ;
      private string AV61Tipopagamentowwds_12_tipopagamentonome3 ;
      private string AV64Tipopagamentowwds_15_tftipopagamentonome ;
      private string AV65Tipopagamentowwds_16_tftipopagamentonome_sel ;
      private string lV50Tipopagamentowwds_1_filterfulltext ;
      private string lV53Tipopagamentowwds_4_tipopagamentonome1 ;
      private string lV57Tipopagamentowwds_8_tipopagamentonome2 ;
      private string lV61Tipopagamentowwds_12_tipopagamentonome3 ;
      private string lV64Tipopagamentowwds_15_tftipopagamentonome ;
      private string A289TipoPagamentoNome ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P007M2_A289TipoPagamentoNome ;
      private int[] P007M2_A288TipoPagamentoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class tipopagamentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007M2( IGxContext context ,
                                             string AV50Tipopagamentowwds_1_filterfulltext ,
                                             string AV51Tipopagamentowwds_2_dynamicfiltersselector1 ,
                                             short AV52Tipopagamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV53Tipopagamentowwds_4_tipopagamentonome1 ,
                                             bool AV54Tipopagamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV55Tipopagamentowwds_6_dynamicfiltersselector2 ,
                                             short AV56Tipopagamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV57Tipopagamentowwds_8_tipopagamentonome2 ,
                                             bool AV58Tipopagamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV59Tipopagamentowwds_10_dynamicfiltersselector3 ,
                                             short AV60Tipopagamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV61Tipopagamentowwds_12_tipopagamentonome3 ,
                                             int AV62Tipopagamentowwds_13_tftipopagamentoid ,
                                             int AV63Tipopagamentowwds_14_tftipopagamentoid_to ,
                                             string AV65Tipopagamentowwds_16_tftipopagamentonome_sel ,
                                             string AV64Tipopagamentowwds_15_tftipopagamentonome ,
                                             int A288TipoPagamentoId ,
                                             string A289TipoPagamentoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TipoPagamentoNome, TipoPagamentoId FROM TipoPagamento";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Tipopagamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TipoPagamentoId,'999999999'), 2) like '%' || :lV50Tipopagamentowwds_1_filterfulltext) or ( TipoPagamentoNome like '%' || :lV50Tipopagamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Tipopagamentowwds_2_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV52Tipopagamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tipopagamentowwds_4_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV53Tipopagamentowwds_4_tipopagamentonome1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Tipopagamentowwds_2_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV52Tipopagamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tipopagamentowwds_4_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV53Tipopagamentowwds_4_tipopagamentonome1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV54Tipopagamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Tipopagamentowwds_6_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV56Tipopagamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tipopagamentowwds_8_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV57Tipopagamentowwds_8_tipopagamentonome2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV54Tipopagamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Tipopagamentowwds_6_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV56Tipopagamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tipopagamentowwds_8_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV57Tipopagamentowwds_8_tipopagamentonome2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Tipopagamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Tipopagamentowwds_10_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV60Tipopagamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tipopagamentowwds_12_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV61Tipopagamentowwds_12_tipopagamentonome3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Tipopagamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Tipopagamentowwds_10_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV60Tipopagamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tipopagamentowwds_12_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV61Tipopagamentowwds_12_tipopagamentonome3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV62Tipopagamentowwds_13_tftipopagamentoid) )
         {
            AddWhere(sWhereString, "(TipoPagamentoId >= :AV62Tipopagamentowwds_13_tftipopagamentoid)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV63Tipopagamentowwds_14_tftipopagamentoid_to) )
         {
            AddWhere(sWhereString, "(TipoPagamentoId <= :AV63Tipopagamentowwds_14_tftipopagamentoid_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Tipopagamentowwds_16_tftipopagamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipopagamentowwds_15_tftipopagamentonome)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV64Tipopagamentowwds_15_tftipopagamentonome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Tipopagamentowwds_16_tftipopagamentonome_sel)) && ! ( StringUtil.StrCmp(AV65Tipopagamentowwds_16_tftipopagamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome = ( :AV65Tipopagamentowwds_16_tftipopagamentonome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Tipopagamentowwds_16_tftipopagamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TipoPagamentoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TipoPagamentoNome";
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
                     return conditional_P007M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP007M2;
          prmP007M2 = new Object[] {
          new ParDef("lV50Tipopagamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Tipopagamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tipopagamentowwds_4_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV53Tipopagamentowwds_4_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV57Tipopagamentowwds_8_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV57Tipopagamentowwds_8_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV61Tipopagamentowwds_12_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("lV61Tipopagamentowwds_12_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("AV62Tipopagamentowwds_13_tftipopagamentoid",GXType.Int32,9,0) ,
          new ParDef("AV63Tipopagamentowwds_14_tftipopagamentoid_to",GXType.Int32,9,0) ,
          new ParDef("lV64Tipopagamentowwds_15_tftipopagamentonome",GXType.VarChar,60,0) ,
          new ParDef("AV65Tipopagamentowwds_16_tftipopagamentonome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
