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
   public class conveniowwgetfilterdata : GXProcedure
   {
      public conveniowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conveniowwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_CONVENIODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADCONVENIODESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("ConvenioWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConvenioWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("ConvenioWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONVENIODESCRICAO") == 0 )
            {
               AV12TFConvenioDescricao = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONVENIODESCRICAO_SEL") == 0 )
            {
               AV13TFConvenioDescricao_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCONVENIOSTATUS_SEL") == 0 )
            {
               AV14TFConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CONVENIODESCRICAO") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40ConvenioDescricao1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CONVENIODESCRICAO") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44ConvenioDescricao2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CONVENIODESCRICAO") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48ConvenioDescricao3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONVENIODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV12TFConvenioDescricao = AV15SearchTxt;
         AV13TFConvenioDescricao_Sel = "";
         AV51Conveniowwds_1_filterfulltext = AV37FilterFullText;
         AV52Conveniowwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV53Conveniowwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV54Conveniowwds_4_conveniodescricao1 = AV40ConvenioDescricao1;
         AV55Conveniowwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV56Conveniowwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV57Conveniowwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV58Conveniowwds_8_conveniodescricao2 = AV44ConvenioDescricao2;
         AV59Conveniowwds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV60Conveniowwds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV61Conveniowwds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV62Conveniowwds_12_conveniodescricao3 = AV48ConvenioDescricao3;
         AV63Conveniowwds_13_tfconveniodescricao = AV12TFConvenioDescricao;
         AV64Conveniowwds_14_tfconveniodescricao_sel = AV13TFConvenioDescricao_Sel;
         AV65Conveniowwds_15_tfconveniostatus_sel = AV14TFConvenioStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Conveniowwds_1_filterfulltext ,
                                              AV52Conveniowwds_2_dynamicfiltersselector1 ,
                                              AV53Conveniowwds_3_dynamicfiltersoperator1 ,
                                              AV54Conveniowwds_4_conveniodescricao1 ,
                                              AV55Conveniowwds_5_dynamicfiltersenabled2 ,
                                              AV56Conveniowwds_6_dynamicfiltersselector2 ,
                                              AV57Conveniowwds_7_dynamicfiltersoperator2 ,
                                              AV58Conveniowwds_8_conveniodescricao2 ,
                                              AV59Conveniowwds_9_dynamicfiltersenabled3 ,
                                              AV60Conveniowwds_10_dynamicfiltersselector3 ,
                                              AV61Conveniowwds_11_dynamicfiltersoperator3 ,
                                              AV62Conveniowwds_12_conveniodescricao3 ,
                                              AV64Conveniowwds_14_tfconveniodescricao_sel ,
                                              AV63Conveniowwds_13_tfconveniodescricao ,
                                              AV65Conveniowwds_15_tfconveniostatus_sel ,
                                              A411ConvenioDescricao ,
                                              A412ConvenioStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV51Conveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Conveniowwds_1_filterfulltext), "%", "");
         lV51Conveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Conveniowwds_1_filterfulltext), "%", "");
         lV51Conveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Conveniowwds_1_filterfulltext), "%", "");
         lV54Conveniowwds_4_conveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV54Conveniowwds_4_conveniodescricao1), "%", "");
         lV54Conveniowwds_4_conveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV54Conveniowwds_4_conveniodescricao1), "%", "");
         lV58Conveniowwds_8_conveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV58Conveniowwds_8_conveniodescricao2), "%", "");
         lV58Conveniowwds_8_conveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV58Conveniowwds_8_conveniodescricao2), "%", "");
         lV62Conveniowwds_12_conveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV62Conveniowwds_12_conveniodescricao3), "%", "");
         lV62Conveniowwds_12_conveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV62Conveniowwds_12_conveniodescricao3), "%", "");
         lV63Conveniowwds_13_tfconveniodescricao = StringUtil.Concat( StringUtil.RTrim( AV63Conveniowwds_13_tfconveniodescricao), "%", "");
         /* Using cursor P009O2 */
         pr_default.execute(0, new Object[] {lV51Conveniowwds_1_filterfulltext, lV51Conveniowwds_1_filterfulltext, lV51Conveniowwds_1_filterfulltext, lV54Conveniowwds_4_conveniodescricao1, lV54Conveniowwds_4_conveniodescricao1, lV58Conveniowwds_8_conveniodescricao2, lV58Conveniowwds_8_conveniodescricao2, lV62Conveniowwds_12_conveniodescricao3, lV62Conveniowwds_12_conveniodescricao3, lV63Conveniowwds_13_tfconveniodescricao, AV64Conveniowwds_14_tfconveniodescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9O2 = false;
            A411ConvenioDescricao = P009O2_A411ConvenioDescricao[0];
            n411ConvenioDescricao = P009O2_n411ConvenioDescricao[0];
            A412ConvenioStatus = P009O2_A412ConvenioStatus[0];
            A410ConvenioId = P009O2_A410ConvenioId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009O2_A411ConvenioDescricao[0], A411ConvenioDescricao) == 0 ) )
            {
               BRK9O2 = false;
               A410ConvenioId = P009O2_A410ConvenioId[0];
               AV25count = (long)(AV25count+1);
               BRK9O2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A411ConvenioDescricao)) ? "<#Empty#>" : A411ConvenioDescricao);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK9O2 )
            {
               BRK9O2 = true;
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV12TFConvenioDescricao = "";
         AV13TFConvenioDescricao_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40ConvenioDescricao1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44ConvenioDescricao2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48ConvenioDescricao3 = "";
         AV51Conveniowwds_1_filterfulltext = "";
         AV52Conveniowwds_2_dynamicfiltersselector1 = "";
         AV54Conveniowwds_4_conveniodescricao1 = "";
         AV56Conveniowwds_6_dynamicfiltersselector2 = "";
         AV58Conveniowwds_8_conveniodescricao2 = "";
         AV60Conveniowwds_10_dynamicfiltersselector3 = "";
         AV62Conveniowwds_12_conveniodescricao3 = "";
         AV63Conveniowwds_13_tfconveniodescricao = "";
         AV64Conveniowwds_14_tfconveniodescricao_sel = "";
         lV51Conveniowwds_1_filterfulltext = "";
         lV54Conveniowwds_4_conveniodescricao1 = "";
         lV58Conveniowwds_8_conveniodescricao2 = "";
         lV62Conveniowwds_12_conveniodescricao3 = "";
         lV63Conveniowwds_13_tfconveniodescricao = "";
         A411ConvenioDescricao = "";
         P009O2_A411ConvenioDescricao = new string[] {""} ;
         P009O2_n411ConvenioDescricao = new bool[] {false} ;
         P009O2_A412ConvenioStatus = new bool[] {false} ;
         P009O2_A410ConvenioId = new int[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conveniowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009O2_A411ConvenioDescricao, P009O2_n411ConvenioDescricao, P009O2_A412ConvenioStatus, P009O2_A410ConvenioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV14TFConvenioStatus_Sel ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV53Conveniowwds_3_dynamicfiltersoperator1 ;
      private short AV57Conveniowwds_7_dynamicfiltersoperator2 ;
      private short AV61Conveniowwds_11_dynamicfiltersoperator3 ;
      private short AV65Conveniowwds_15_tfconveniostatus_sel ;
      private int AV49GXV1 ;
      private int A410ConvenioId ;
      private long AV25count ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV55Conveniowwds_5_dynamicfiltersenabled2 ;
      private bool AV59Conveniowwds_9_dynamicfiltersenabled3 ;
      private bool A412ConvenioStatus ;
      private bool BRK9O2 ;
      private bool n411ConvenioDescricao ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV12TFConvenioDescricao ;
      private string AV13TFConvenioDescricao_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40ConvenioDescricao1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44ConvenioDescricao2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48ConvenioDescricao3 ;
      private string AV51Conveniowwds_1_filterfulltext ;
      private string AV52Conveniowwds_2_dynamicfiltersselector1 ;
      private string AV54Conveniowwds_4_conveniodescricao1 ;
      private string AV56Conveniowwds_6_dynamicfiltersselector2 ;
      private string AV58Conveniowwds_8_conveniodescricao2 ;
      private string AV60Conveniowwds_10_dynamicfiltersselector3 ;
      private string AV62Conveniowwds_12_conveniodescricao3 ;
      private string AV63Conveniowwds_13_tfconveniodescricao ;
      private string AV64Conveniowwds_14_tfconveniodescricao_sel ;
      private string lV51Conveniowwds_1_filterfulltext ;
      private string lV54Conveniowwds_4_conveniodescricao1 ;
      private string lV58Conveniowwds_8_conveniodescricao2 ;
      private string lV62Conveniowwds_12_conveniodescricao3 ;
      private string lV63Conveniowwds_13_tfconveniodescricao ;
      private string A411ConvenioDescricao ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P009O2_A411ConvenioDescricao ;
      private bool[] P009O2_n411ConvenioDescricao ;
      private bool[] P009O2_A412ConvenioStatus ;
      private int[] P009O2_A410ConvenioId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class conveniowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009O2( IGxContext context ,
                                             string AV51Conveniowwds_1_filterfulltext ,
                                             string AV52Conveniowwds_2_dynamicfiltersselector1 ,
                                             short AV53Conveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV54Conveniowwds_4_conveniodescricao1 ,
                                             bool AV55Conveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV56Conveniowwds_6_dynamicfiltersselector2 ,
                                             short AV57Conveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV58Conveniowwds_8_conveniodescricao2 ,
                                             bool AV59Conveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV60Conveniowwds_10_dynamicfiltersselector3 ,
                                             short AV61Conveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV62Conveniowwds_12_conveniodescricao3 ,
                                             string AV64Conveniowwds_14_tfconveniodescricao_sel ,
                                             string AV63Conveniowwds_13_tfconveniodescricao ,
                                             short AV65Conveniowwds_15_tfconveniostatus_sel ,
                                             string A411ConvenioDescricao ,
                                             bool A412ConvenioStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ConvenioDescricao, ConvenioStatus, ConvenioId FROM Convenio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Conveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConvenioDescricao like '%' || :lV51Conveniowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV51Conveniowwds_1_filterfulltext) and ConvenioStatus = TRUE) or ( 'não' like '%' || LOWER(:lV51Conveniowwds_1_filterfulltext) and ConvenioStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Conveniowwds_2_dynamicfiltersselector1, "CONVENIODESCRICAO") == 0 ) && ( AV53Conveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniowwds_4_conveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV54Conveniowwds_4_conveniodescricao1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Conveniowwds_2_dynamicfiltersselector1, "CONVENIODESCRICAO") == 0 ) && ( AV53Conveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniowwds_4_conveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like '%' || :lV54Conveniowwds_4_conveniodescricao1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV55Conveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Conveniowwds_6_dynamicfiltersselector2, "CONVENIODESCRICAO") == 0 ) && ( AV57Conveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Conveniowwds_8_conveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV58Conveniowwds_8_conveniodescricao2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV55Conveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Conveniowwds_6_dynamicfiltersselector2, "CONVENIODESCRICAO") == 0 ) && ( AV57Conveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Conveniowwds_8_conveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like '%' || :lV58Conveniowwds_8_conveniodescricao2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV59Conveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Conveniowwds_10_dynamicfiltersselector3, "CONVENIODESCRICAO") == 0 ) && ( AV61Conveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Conveniowwds_12_conveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV62Conveniowwds_12_conveniodescricao3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV59Conveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Conveniowwds_10_dynamicfiltersselector3, "CONVENIODESCRICAO") == 0 ) && ( AV61Conveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Conveniowwds_12_conveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like '%' || :lV62Conveniowwds_12_conveniodescricao3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Conveniowwds_14_tfconveniodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Conveniowwds_13_tfconveniodescricao)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV63Conveniowwds_13_tfconveniodescricao)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conveniowwds_14_tfconveniodescricao_sel)) && ! ( StringUtil.StrCmp(AV64Conveniowwds_14_tfconveniodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao = ( :AV64Conveniowwds_14_tfconveniodescricao_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV64Conveniowwds_14_tfconveniodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConvenioDescricao IS NULL or (char_length(trim(trailing ' ' from ConvenioDescricao))=0))");
         }
         if ( AV65Conveniowwds_15_tfconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ConvenioStatus = TRUE)");
         }
         if ( AV65Conveniowwds_15_tfconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ConvenioStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ConvenioDescricao";
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
                     return conditional_P009O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmP009O2;
          prmP009O2 = new Object[] {
          new ParDef("lV51Conveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Conveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Conveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Conveniowwds_4_conveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV54Conveniowwds_4_conveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV58Conveniowwds_8_conveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV58Conveniowwds_8_conveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV62Conveniowwds_12_conveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV62Conveniowwds_12_conveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV63Conveniowwds_13_tfconveniodescricao",GXType.VarChar,40,0) ,
          new ParDef("AV64Conveniowwds_14_tfconveniodescricao_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
