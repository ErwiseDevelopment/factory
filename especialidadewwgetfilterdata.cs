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
   public class especialidadewwgetfilterdata : GXProcedure
   {
      public especialidadewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public especialidadewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_ESPECIALIDADENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADESPECIALIDADENOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV24Session.Get("EspecialidadeWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EspecialidadeWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("EspecialidadeWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADENOME") == 0 )
            {
               AV10TFEspecialidadeNome = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADENOME_SEL") == 0 )
            {
               AV11TFEspecialidadeNome_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADESTATUS_SEL") == 0 )
            {
               AV12TFEspecialidadeStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "ESPECIALIDADENOME") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV38EspecialidadeNome1 = AV28GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "ESPECIALIDADENOME") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV42EspecialidadeNome2 = AV28GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "ESPECIALIDADENOME") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV46EspecialidadeNome3 = AV28GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADESPECIALIDADENOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFEspecialidadeNome = AV13SearchTxt;
         AV11TFEspecialidadeNome_Sel = "";
         AV49Especialidadewwds_1_filterfulltext = AV35FilterFullText;
         AV50Especialidadewwds_2_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV51Especialidadewwds_3_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV52Especialidadewwds_4_especialidadenome1 = AV38EspecialidadeNome1;
         AV53Especialidadewwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV54Especialidadewwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV55Especialidadewwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV56Especialidadewwds_8_especialidadenome2 = AV42EspecialidadeNome2;
         AV57Especialidadewwds_9_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV58Especialidadewwds_10_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV59Especialidadewwds_11_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV60Especialidadewwds_12_especialidadenome3 = AV46EspecialidadeNome3;
         AV61Especialidadewwds_13_tfespecialidadenome = AV10TFEspecialidadeNome;
         AV62Especialidadewwds_14_tfespecialidadenome_sel = AV11TFEspecialidadeNome_Sel;
         AV63Especialidadewwds_15_tfespecialidadestatus_sel = AV12TFEspecialidadeStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Especialidadewwds_1_filterfulltext ,
                                              AV50Especialidadewwds_2_dynamicfiltersselector1 ,
                                              AV51Especialidadewwds_3_dynamicfiltersoperator1 ,
                                              AV52Especialidadewwds_4_especialidadenome1 ,
                                              AV53Especialidadewwds_5_dynamicfiltersenabled2 ,
                                              AV54Especialidadewwds_6_dynamicfiltersselector2 ,
                                              AV55Especialidadewwds_7_dynamicfiltersoperator2 ,
                                              AV56Especialidadewwds_8_especialidadenome2 ,
                                              AV57Especialidadewwds_9_dynamicfiltersenabled3 ,
                                              AV58Especialidadewwds_10_dynamicfiltersselector3 ,
                                              AV59Especialidadewwds_11_dynamicfiltersoperator3 ,
                                              AV60Especialidadewwds_12_especialidadenome3 ,
                                              AV62Especialidadewwds_14_tfespecialidadenome_sel ,
                                              AV61Especialidadewwds_13_tfespecialidadenome ,
                                              AV63Especialidadewwds_15_tfespecialidadestatus_sel ,
                                              A458EspecialidadeNome ,
                                              A595EspecialidadeStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV49Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Especialidadewwds_1_filterfulltext), "%", "");
         lV49Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Especialidadewwds_1_filterfulltext), "%", "");
         lV49Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Especialidadewwds_1_filterfulltext), "%", "");
         lV52Especialidadewwds_4_especialidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV52Especialidadewwds_4_especialidadenome1), "%", "");
         lV52Especialidadewwds_4_especialidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV52Especialidadewwds_4_especialidadenome1), "%", "");
         lV56Especialidadewwds_8_especialidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV56Especialidadewwds_8_especialidadenome2), "%", "");
         lV56Especialidadewwds_8_especialidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV56Especialidadewwds_8_especialidadenome2), "%", "");
         lV60Especialidadewwds_12_especialidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV60Especialidadewwds_12_especialidadenome3), "%", "");
         lV60Especialidadewwds_12_especialidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV60Especialidadewwds_12_especialidadenome3), "%", "");
         lV61Especialidadewwds_13_tfespecialidadenome = StringUtil.Concat( StringUtil.RTrim( AV61Especialidadewwds_13_tfespecialidadenome), "%", "");
         /* Using cursor P00BH2 */
         pr_default.execute(0, new Object[] {lV49Especialidadewwds_1_filterfulltext, lV49Especialidadewwds_1_filterfulltext, lV49Especialidadewwds_1_filterfulltext, lV52Especialidadewwds_4_especialidadenome1, lV52Especialidadewwds_4_especialidadenome1, lV56Especialidadewwds_8_especialidadenome2, lV56Especialidadewwds_8_especialidadenome2, lV60Especialidadewwds_12_especialidadenome3, lV60Especialidadewwds_12_especialidadenome3, lV61Especialidadewwds_13_tfespecialidadenome, AV62Especialidadewwds_14_tfespecialidadenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBH2 = false;
            A458EspecialidadeNome = P00BH2_A458EspecialidadeNome[0];
            n458EspecialidadeNome = P00BH2_n458EspecialidadeNome[0];
            A595EspecialidadeStatus = P00BH2_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = P00BH2_n595EspecialidadeStatus[0];
            A457EspecialidadeId = P00BH2_A457EspecialidadeId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BH2_A458EspecialidadeNome[0], A458EspecialidadeNome) == 0 ) )
            {
               BRKBH2 = false;
               A457EspecialidadeId = P00BH2_A457EspecialidadeId[0];
               AV23count = (long)(AV23count+1);
               BRKBH2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A458EspecialidadeNome)) ? "<#Empty#>" : A458EspecialidadeNome);
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
            if ( ! BRKBH2 )
            {
               BRKBH2 = true;
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
         AV10TFEspecialidadeNome = "";
         AV11TFEspecialidadeNome_Sel = "";
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38EspecialidadeNome1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42EspecialidadeNome2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46EspecialidadeNome3 = "";
         AV49Especialidadewwds_1_filterfulltext = "";
         AV50Especialidadewwds_2_dynamicfiltersselector1 = "";
         AV52Especialidadewwds_4_especialidadenome1 = "";
         AV54Especialidadewwds_6_dynamicfiltersselector2 = "";
         AV56Especialidadewwds_8_especialidadenome2 = "";
         AV58Especialidadewwds_10_dynamicfiltersselector3 = "";
         AV60Especialidadewwds_12_especialidadenome3 = "";
         AV61Especialidadewwds_13_tfespecialidadenome = "";
         AV62Especialidadewwds_14_tfespecialidadenome_sel = "";
         lV49Especialidadewwds_1_filterfulltext = "";
         lV52Especialidadewwds_4_especialidadenome1 = "";
         lV56Especialidadewwds_8_especialidadenome2 = "";
         lV60Especialidadewwds_12_especialidadenome3 = "";
         lV61Especialidadewwds_13_tfespecialidadenome = "";
         A458EspecialidadeNome = "";
         P00BH2_A458EspecialidadeNome = new string[] {""} ;
         P00BH2_n458EspecialidadeNome = new bool[] {false} ;
         P00BH2_A595EspecialidadeStatus = new bool[] {false} ;
         P00BH2_n595EspecialidadeStatus = new bool[] {false} ;
         P00BH2_A457EspecialidadeId = new int[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.especialidadewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BH2_A458EspecialidadeNome, P00BH2_n458EspecialidadeNome, P00BH2_A595EspecialidadeStatus, P00BH2_n595EspecialidadeStatus, P00BH2_A457EspecialidadeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV12TFEspecialidadeStatus_Sel ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV51Especialidadewwds_3_dynamicfiltersoperator1 ;
      private short AV55Especialidadewwds_7_dynamicfiltersoperator2 ;
      private short AV59Especialidadewwds_11_dynamicfiltersoperator3 ;
      private short AV63Especialidadewwds_15_tfespecialidadestatus_sel ;
      private int AV47GXV1 ;
      private int A457EspecialidadeId ;
      private long AV23count ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV53Especialidadewwds_5_dynamicfiltersenabled2 ;
      private bool AV57Especialidadewwds_9_dynamicfiltersenabled3 ;
      private bool A595EspecialidadeStatus ;
      private bool BRKBH2 ;
      private bool n458EspecialidadeNome ;
      private bool n595EspecialidadeStatus ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV10TFEspecialidadeNome ;
      private string AV11TFEspecialidadeNome_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV38EspecialidadeNome1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV42EspecialidadeNome2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV46EspecialidadeNome3 ;
      private string AV49Especialidadewwds_1_filterfulltext ;
      private string AV50Especialidadewwds_2_dynamicfiltersselector1 ;
      private string AV52Especialidadewwds_4_especialidadenome1 ;
      private string AV54Especialidadewwds_6_dynamicfiltersselector2 ;
      private string AV56Especialidadewwds_8_especialidadenome2 ;
      private string AV58Especialidadewwds_10_dynamicfiltersselector3 ;
      private string AV60Especialidadewwds_12_especialidadenome3 ;
      private string AV61Especialidadewwds_13_tfespecialidadenome ;
      private string AV62Especialidadewwds_14_tfespecialidadenome_sel ;
      private string lV49Especialidadewwds_1_filterfulltext ;
      private string lV52Especialidadewwds_4_especialidadenome1 ;
      private string lV56Especialidadewwds_8_especialidadenome2 ;
      private string lV60Especialidadewwds_12_especialidadenome3 ;
      private string lV61Especialidadewwds_13_tfespecialidadenome ;
      private string A458EspecialidadeNome ;
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
      private string[] P00BH2_A458EspecialidadeNome ;
      private bool[] P00BH2_n458EspecialidadeNome ;
      private bool[] P00BH2_A595EspecialidadeStatus ;
      private bool[] P00BH2_n595EspecialidadeStatus ;
      private int[] P00BH2_A457EspecialidadeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class especialidadewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BH2( IGxContext context ,
                                             string AV49Especialidadewwds_1_filterfulltext ,
                                             string AV50Especialidadewwds_2_dynamicfiltersselector1 ,
                                             short AV51Especialidadewwds_3_dynamicfiltersoperator1 ,
                                             string AV52Especialidadewwds_4_especialidadenome1 ,
                                             bool AV53Especialidadewwds_5_dynamicfiltersenabled2 ,
                                             string AV54Especialidadewwds_6_dynamicfiltersselector2 ,
                                             short AV55Especialidadewwds_7_dynamicfiltersoperator2 ,
                                             string AV56Especialidadewwds_8_especialidadenome2 ,
                                             bool AV57Especialidadewwds_9_dynamicfiltersenabled3 ,
                                             string AV58Especialidadewwds_10_dynamicfiltersselector3 ,
                                             short AV59Especialidadewwds_11_dynamicfiltersoperator3 ,
                                             string AV60Especialidadewwds_12_especialidadenome3 ,
                                             string AV62Especialidadewwds_14_tfespecialidadenome_sel ,
                                             string AV61Especialidadewwds_13_tfespecialidadenome ,
                                             short AV63Especialidadewwds_15_tfespecialidadestatus_sel ,
                                             string A458EspecialidadeNome ,
                                             bool A595EspecialidadeStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT EspecialidadeNome, EspecialidadeStatus, EspecialidadeId FROM Especialidade";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Especialidadewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EspecialidadeNome like '%' || :lV49Especialidadewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV49Especialidadewwds_1_filterfulltext) and EspecialidadeStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV49Especialidadewwds_1_filterfulltext) and EspecialidadeStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Especialidadewwds_2_dynamicfiltersselector1, "ESPECIALIDADENOME") == 0 ) && ( AV51Especialidadewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Especialidadewwds_4_especialidadenome1)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV52Especialidadewwds_4_especialidadenome1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Especialidadewwds_2_dynamicfiltersselector1, "ESPECIALIDADENOME") == 0 ) && ( AV51Especialidadewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Especialidadewwds_4_especialidadenome1)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV52Especialidadewwds_4_especialidadenome1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV53Especialidadewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Especialidadewwds_6_dynamicfiltersselector2, "ESPECIALIDADENOME") == 0 ) && ( AV55Especialidadewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Especialidadewwds_8_especialidadenome2)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV56Especialidadewwds_8_especialidadenome2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV53Especialidadewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Especialidadewwds_6_dynamicfiltersselector2, "ESPECIALIDADENOME") == 0 ) && ( AV55Especialidadewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Especialidadewwds_8_especialidadenome2)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV56Especialidadewwds_8_especialidadenome2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV57Especialidadewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Especialidadewwds_10_dynamicfiltersselector3, "ESPECIALIDADENOME") == 0 ) && ( AV59Especialidadewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Especialidadewwds_12_especialidadenome3)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV60Especialidadewwds_12_especialidadenome3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV57Especialidadewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Especialidadewwds_10_dynamicfiltersselector3, "ESPECIALIDADENOME") == 0 ) && ( AV59Especialidadewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Especialidadewwds_12_especialidadenome3)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV60Especialidadewwds_12_especialidadenome3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Especialidadewwds_14_tfespecialidadenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Especialidadewwds_13_tfespecialidadenome)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV61Especialidadewwds_13_tfespecialidadenome)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Especialidadewwds_14_tfespecialidadenome_sel)) && ! ( StringUtil.StrCmp(AV62Especialidadewwds_14_tfespecialidadenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome = ( :AV62Especialidadewwds_14_tfespecialidadenome_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV62Especialidadewwds_14_tfespecialidadenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EspecialidadeNome IS NULL or (char_length(trim(trailing ' ' from EspecialidadeNome))=0))");
         }
         if ( AV63Especialidadewwds_15_tfespecialidadestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(EspecialidadeStatus = TRUE)");
         }
         if ( AV63Especialidadewwds_15_tfespecialidadestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(EspecialidadeStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EspecialidadeNome";
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
                     return conditional_P00BH2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmP00BH2;
          prmP00BH2 = new Object[] {
          new ParDef("lV49Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Especialidadewwds_4_especialidadenome1",GXType.VarChar,60,0) ,
          new ParDef("lV52Especialidadewwds_4_especialidadenome1",GXType.VarChar,60,0) ,
          new ParDef("lV56Especialidadewwds_8_especialidadenome2",GXType.VarChar,60,0) ,
          new ParDef("lV56Especialidadewwds_8_especialidadenome2",GXType.VarChar,60,0) ,
          new ParDef("lV60Especialidadewwds_12_especialidadenome3",GXType.VarChar,60,0) ,
          new ParDef("lV60Especialidadewwds_12_especialidadenome3",GXType.VarChar,60,0) ,
          new ParDef("lV61Especialidadewwds_13_tfespecialidadenome",GXType.VarChar,60,0) ,
          new ParDef("AV62Especialidadewwds_14_tfespecialidadenome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
