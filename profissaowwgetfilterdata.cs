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
   public class profissaowwgetfilterdata : GXProcedure
   {
      public profissaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profissaowwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_PROFISSAONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROFISSAONOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV25Session.Get("ProfissaoWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfissaoWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("ProfissaoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROFISSAOID") == 0 )
            {
               AV10TFProfissaoId = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFProfissaoId_To = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROFISSAONOME") == 0 )
            {
               AV12TFProfissaoNome = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROFISSAONOME_SEL") == 0 )
            {
               AV13TFProfissaoNome_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "PROFISSAONOME") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV39ProfissaoNome1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV40DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV41DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV41DynamicFiltersSelector2, "PROFISSAONOME") == 0 )
               {
                  AV42DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV43ProfissaoNome2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV44DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV45DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "PROFISSAONOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV47ProfissaoNome3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFISSAONOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFProfissaoNome = AV14SearchTxt;
         AV13TFProfissaoNome_Sel = "";
         AV50Profissaowwds_1_filterfulltext = AV36FilterFullText;
         AV51Profissaowwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV52Profissaowwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV53Profissaowwds_4_profissaonome1 = AV39ProfissaoNome1;
         AV54Profissaowwds_5_dynamicfiltersenabled2 = AV40DynamicFiltersEnabled2;
         AV55Profissaowwds_6_dynamicfiltersselector2 = AV41DynamicFiltersSelector2;
         AV56Profissaowwds_7_dynamicfiltersoperator2 = AV42DynamicFiltersOperator2;
         AV57Profissaowwds_8_profissaonome2 = AV43ProfissaoNome2;
         AV58Profissaowwds_9_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV59Profissaowwds_10_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV60Profissaowwds_11_dynamicfiltersoperator3 = AV46DynamicFiltersOperator3;
         AV61Profissaowwds_12_profissaonome3 = AV47ProfissaoNome3;
         AV62Profissaowwds_13_tfprofissaoid = AV10TFProfissaoId;
         AV63Profissaowwds_14_tfprofissaoid_to = AV11TFProfissaoId_To;
         AV64Profissaowwds_15_tfprofissaonome = AV12TFProfissaoNome;
         AV65Profissaowwds_16_tfprofissaonome_sel = AV13TFProfissaoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Profissaowwds_1_filterfulltext ,
                                              AV51Profissaowwds_2_dynamicfiltersselector1 ,
                                              AV52Profissaowwds_3_dynamicfiltersoperator1 ,
                                              AV53Profissaowwds_4_profissaonome1 ,
                                              AV54Profissaowwds_5_dynamicfiltersenabled2 ,
                                              AV55Profissaowwds_6_dynamicfiltersselector2 ,
                                              AV56Profissaowwds_7_dynamicfiltersoperator2 ,
                                              AV57Profissaowwds_8_profissaonome2 ,
                                              AV58Profissaowwds_9_dynamicfiltersenabled3 ,
                                              AV59Profissaowwds_10_dynamicfiltersselector3 ,
                                              AV60Profissaowwds_11_dynamicfiltersoperator3 ,
                                              AV61Profissaowwds_12_profissaonome3 ,
                                              AV62Profissaowwds_13_tfprofissaoid ,
                                              AV63Profissaowwds_14_tfprofissaoid_to ,
                                              AV65Profissaowwds_16_tfprofissaonome_sel ,
                                              AV64Profissaowwds_15_tfprofissaonome ,
                                              A440ProfissaoId ,
                                              A441ProfissaoNome } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Profissaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Profissaowwds_1_filterfulltext), "%", "");
         lV50Profissaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Profissaowwds_1_filterfulltext), "%", "");
         lV53Profissaowwds_4_profissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV53Profissaowwds_4_profissaonome1), "%", "");
         lV53Profissaowwds_4_profissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV53Profissaowwds_4_profissaonome1), "%", "");
         lV57Profissaowwds_8_profissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV57Profissaowwds_8_profissaonome2), "%", "");
         lV57Profissaowwds_8_profissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV57Profissaowwds_8_profissaonome2), "%", "");
         lV61Profissaowwds_12_profissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV61Profissaowwds_12_profissaonome3), "%", "");
         lV61Profissaowwds_12_profissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV61Profissaowwds_12_profissaonome3), "%", "");
         lV64Profissaowwds_15_tfprofissaonome = StringUtil.Concat( StringUtil.RTrim( AV64Profissaowwds_15_tfprofissaonome), "%", "");
         /* Using cursor P00A62 */
         pr_default.execute(0, new Object[] {lV50Profissaowwds_1_filterfulltext, lV50Profissaowwds_1_filterfulltext, lV53Profissaowwds_4_profissaonome1, lV53Profissaowwds_4_profissaonome1, lV57Profissaowwds_8_profissaonome2, lV57Profissaowwds_8_profissaonome2, lV61Profissaowwds_12_profissaonome3, lV61Profissaowwds_12_profissaonome3, AV62Profissaowwds_13_tfprofissaoid, AV63Profissaowwds_14_tfprofissaoid_to, lV64Profissaowwds_15_tfprofissaonome, AV65Profissaowwds_16_tfprofissaonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKA62 = false;
            A441ProfissaoNome = P00A62_A441ProfissaoNome[0];
            n441ProfissaoNome = P00A62_n441ProfissaoNome[0];
            A440ProfissaoId = P00A62_A440ProfissaoId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00A62_A441ProfissaoNome[0], A441ProfissaoNome) == 0 ) )
            {
               BRKA62 = false;
               A440ProfissaoId = P00A62_A440ProfissaoId[0];
               AV24count = (long)(AV24count+1);
               BRKA62 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A441ProfissaoNome)) ? "<#Empty#>" : A441ProfissaoNome);
               AV21OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A441ProfissaoNome, "@!")));
               AV20Options.Add(AV19Option, 0);
               AV22OptionsDesc.Add(AV21OptionDesc, 0);
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
            if ( ! BRKA62 )
            {
               BRKA62 = true;
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
         AV12TFProfissaoNome = "";
         AV13TFProfissaoNome_Sel = "";
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV39ProfissaoNome1 = "";
         AV41DynamicFiltersSelector2 = "";
         AV43ProfissaoNome2 = "";
         AV45DynamicFiltersSelector3 = "";
         AV47ProfissaoNome3 = "";
         AV50Profissaowwds_1_filterfulltext = "";
         AV51Profissaowwds_2_dynamicfiltersselector1 = "";
         AV53Profissaowwds_4_profissaonome1 = "";
         AV55Profissaowwds_6_dynamicfiltersselector2 = "";
         AV57Profissaowwds_8_profissaonome2 = "";
         AV59Profissaowwds_10_dynamicfiltersselector3 = "";
         AV61Profissaowwds_12_profissaonome3 = "";
         AV64Profissaowwds_15_tfprofissaonome = "";
         AV65Profissaowwds_16_tfprofissaonome_sel = "";
         lV50Profissaowwds_1_filterfulltext = "";
         lV53Profissaowwds_4_profissaonome1 = "";
         lV57Profissaowwds_8_profissaonome2 = "";
         lV61Profissaowwds_12_profissaonome3 = "";
         lV64Profissaowwds_15_tfprofissaonome = "";
         A441ProfissaoNome = "";
         P00A62_A441ProfissaoNome = new string[] {""} ;
         P00A62_n441ProfissaoNome = new bool[] {false} ;
         P00A62_A440ProfissaoId = new int[1] ;
         AV19Option = "";
         AV21OptionDesc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profissaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00A62_A441ProfissaoNome, P00A62_n441ProfissaoNome, P00A62_A440ProfissaoId
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
      private short AV52Profissaowwds_3_dynamicfiltersoperator1 ;
      private short AV56Profissaowwds_7_dynamicfiltersoperator2 ;
      private short AV60Profissaowwds_11_dynamicfiltersoperator3 ;
      private int AV48GXV1 ;
      private int AV10TFProfissaoId ;
      private int AV11TFProfissaoId_To ;
      private int AV62Profissaowwds_13_tfprofissaoid ;
      private int AV63Profissaowwds_14_tfprofissaoid_to ;
      private int A440ProfissaoId ;
      private long AV24count ;
      private bool returnInSub ;
      private bool AV40DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool AV54Profissaowwds_5_dynamicfiltersenabled2 ;
      private bool AV58Profissaowwds_9_dynamicfiltersenabled3 ;
      private bool BRKA62 ;
      private bool n441ProfissaoNome ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV12TFProfissaoNome ;
      private string AV13TFProfissaoNome_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV39ProfissaoNome1 ;
      private string AV41DynamicFiltersSelector2 ;
      private string AV43ProfissaoNome2 ;
      private string AV45DynamicFiltersSelector3 ;
      private string AV47ProfissaoNome3 ;
      private string AV50Profissaowwds_1_filterfulltext ;
      private string AV51Profissaowwds_2_dynamicfiltersselector1 ;
      private string AV53Profissaowwds_4_profissaonome1 ;
      private string AV55Profissaowwds_6_dynamicfiltersselector2 ;
      private string AV57Profissaowwds_8_profissaonome2 ;
      private string AV59Profissaowwds_10_dynamicfiltersselector3 ;
      private string AV61Profissaowwds_12_profissaonome3 ;
      private string AV64Profissaowwds_15_tfprofissaonome ;
      private string AV65Profissaowwds_16_tfprofissaonome_sel ;
      private string lV50Profissaowwds_1_filterfulltext ;
      private string lV53Profissaowwds_4_profissaonome1 ;
      private string lV57Profissaowwds_8_profissaonome2 ;
      private string lV61Profissaowwds_12_profissaonome3 ;
      private string lV64Profissaowwds_15_tfprofissaonome ;
      private string A441ProfissaoNome ;
      private string AV19Option ;
      private string AV21OptionDesc ;
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
      private string[] P00A62_A441ProfissaoNome ;
      private bool[] P00A62_n441ProfissaoNome ;
      private int[] P00A62_A440ProfissaoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class profissaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A62( IGxContext context ,
                                             string AV50Profissaowwds_1_filterfulltext ,
                                             string AV51Profissaowwds_2_dynamicfiltersselector1 ,
                                             short AV52Profissaowwds_3_dynamicfiltersoperator1 ,
                                             string AV53Profissaowwds_4_profissaonome1 ,
                                             bool AV54Profissaowwds_5_dynamicfiltersenabled2 ,
                                             string AV55Profissaowwds_6_dynamicfiltersselector2 ,
                                             short AV56Profissaowwds_7_dynamicfiltersoperator2 ,
                                             string AV57Profissaowwds_8_profissaonome2 ,
                                             bool AV58Profissaowwds_9_dynamicfiltersenabled3 ,
                                             string AV59Profissaowwds_10_dynamicfiltersselector3 ,
                                             short AV60Profissaowwds_11_dynamicfiltersoperator3 ,
                                             string AV61Profissaowwds_12_profissaonome3 ,
                                             int AV62Profissaowwds_13_tfprofissaoid ,
                                             int AV63Profissaowwds_14_tfprofissaoid_to ,
                                             string AV65Profissaowwds_16_tfprofissaonome_sel ,
                                             string AV64Profissaowwds_15_tfprofissaonome ,
                                             int A440ProfissaoId ,
                                             string A441ProfissaoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ProfissaoNome, ProfissaoId FROM Profissao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Profissaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ProfissaoId,'999999999'), 2) like '%' || :lV50Profissaowwds_1_filterfulltext) or ( ProfissaoNome like '%' || :lV50Profissaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Profissaowwds_2_dynamicfiltersselector1, "PROFISSAONOME") == 0 ) && ( AV52Profissaowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Profissaowwds_4_profissaonome1)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV53Profissaowwds_4_profissaonome1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Profissaowwds_2_dynamicfiltersselector1, "PROFISSAONOME") == 0 ) && ( AV52Profissaowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Profissaowwds_4_profissaonome1)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV53Profissaowwds_4_profissaonome1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV54Profissaowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Profissaowwds_6_dynamicfiltersselector2, "PROFISSAONOME") == 0 ) && ( AV56Profissaowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Profissaowwds_8_profissaonome2)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV57Profissaowwds_8_profissaonome2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV54Profissaowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Profissaowwds_6_dynamicfiltersselector2, "PROFISSAONOME") == 0 ) && ( AV56Profissaowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Profissaowwds_8_profissaonome2)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV57Profissaowwds_8_profissaonome2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Profissaowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Profissaowwds_10_dynamicfiltersselector3, "PROFISSAONOME") == 0 ) && ( AV60Profissaowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Profissaowwds_12_profissaonome3)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV61Profissaowwds_12_profissaonome3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Profissaowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Profissaowwds_10_dynamicfiltersselector3, "PROFISSAONOME") == 0 ) && ( AV60Profissaowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Profissaowwds_12_profissaonome3)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV61Profissaowwds_12_profissaonome3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV62Profissaowwds_13_tfprofissaoid) )
         {
            AddWhere(sWhereString, "(ProfissaoId >= :AV62Profissaowwds_13_tfprofissaoid)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV63Profissaowwds_14_tfprofissaoid_to) )
         {
            AddWhere(sWhereString, "(ProfissaoId <= :AV63Profissaowwds_14_tfprofissaoid_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Profissaowwds_16_tfprofissaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profissaowwds_15_tfprofissaonome)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV64Profissaowwds_15_tfprofissaonome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Profissaowwds_16_tfprofissaonome_sel)) && ! ( StringUtil.StrCmp(AV65Profissaowwds_16_tfprofissaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome = ( :AV65Profissaowwds_16_tfprofissaonome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Profissaowwds_16_tfprofissaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from ProfissaoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProfissaoNome";
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
                     return conditional_P00A62(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00A62;
          prmP00A62 = new Object[] {
          new ParDef("lV50Profissaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Profissaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Profissaowwds_4_profissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV53Profissaowwds_4_profissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV57Profissaowwds_8_profissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV57Profissaowwds_8_profissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV61Profissaowwds_12_profissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV61Profissaowwds_12_profissaonome3",GXType.VarChar,90,0) ,
          new ParDef("AV62Profissaowwds_13_tfprofissaoid",GXType.Int32,9,0) ,
          new ParDef("AV63Profissaowwds_14_tfprofissaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV64Profissaowwds_15_tfprofissaonome",GXType.VarChar,90,0) ,
          new ParDef("AV65Profissaowwds_16_tfprofissaonome_sel",GXType.VarChar,90,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A62,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
