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
   public class conveniocategoriawwgetfilterdata : GXProcedure
   {
      public conveniocategoriawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conveniocategoriawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_CONVENIOCATEGORIADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADCONVENIOCATEGORIADESCRICAOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV24Session.Get("ConvenioCategoriaWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConvenioCategoriaWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("ConvenioCategoriaWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV10TFConvenioCategoriaDescricao = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONVENIOCATEGORIADESCRICAO_SEL") == 0 )
            {
               AV11TFConvenioCategoriaDescricao_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCONVENIOCATEGORIASTATUS_SEL") == 0 )
            {
               AV12TFConvenioCategoriaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "PARM_&CONVENIOID") == 0 )
            {
               AV47ConvenioId = (int)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
         if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV38ConvenioCategoriaDescricao1 = AV28GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV42ConvenioCategoriaDescricao2 = AV28GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV46ConvenioCategoriaDescricao3 = AV28GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONVENIOCATEGORIADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV10TFConvenioCategoriaDescricao = AV13SearchTxt;
         AV11TFConvenioCategoriaDescricao_Sel = "";
         AV50Conveniocategoriawwds_1_convenioid = AV47ConvenioId;
         AV51Conveniocategoriawwds_2_filterfulltext = AV35FilterFullText;
         AV52Conveniocategoriawwds_3_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV53Conveniocategoriawwds_4_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV54Conveniocategoriawwds_5_conveniocategoriadescricao1 = AV38ConvenioCategoriaDescricao1;
         AV55Conveniocategoriawwds_6_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV56Conveniocategoriawwds_7_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV57Conveniocategoriawwds_8_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV58Conveniocategoriawwds_9_conveniocategoriadescricao2 = AV42ConvenioCategoriaDescricao2;
         AV59Conveniocategoriawwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV60Conveniocategoriawwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV61Conveniocategoriawwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV62Conveniocategoriawwds_13_conveniocategoriadescricao3 = AV46ConvenioCategoriaDescricao3;
         AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao = AV10TFConvenioCategoriaDescricao;
         AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel = AV11TFConvenioCategoriaDescricao_Sel;
         AV65Conveniocategoriawwds_16_tfconveniocategoriastatus_sel = AV12TFConvenioCategoriaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Conveniocategoriawwds_2_filterfulltext ,
                                              AV52Conveniocategoriawwds_3_dynamicfiltersselector1 ,
                                              AV53Conveniocategoriawwds_4_dynamicfiltersoperator1 ,
                                              AV54Conveniocategoriawwds_5_conveniocategoriadescricao1 ,
                                              AV55Conveniocategoriawwds_6_dynamicfiltersenabled2 ,
                                              AV56Conveniocategoriawwds_7_dynamicfiltersselector2 ,
                                              AV57Conveniocategoriawwds_8_dynamicfiltersoperator2 ,
                                              AV58Conveniocategoriawwds_9_conveniocategoriadescricao2 ,
                                              AV59Conveniocategoriawwds_10_dynamicfiltersenabled3 ,
                                              AV60Conveniocategoriawwds_11_dynamicfiltersselector3 ,
                                              AV61Conveniocategoriawwds_12_dynamicfiltersoperator3 ,
                                              AV62Conveniocategoriawwds_13_conveniocategoriadescricao3 ,
                                              AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel ,
                                              AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao ,
                                              AV65Conveniocategoriawwds_16_tfconveniocategoriastatus_sel ,
                                              A494ConvenioCategoriaDescricao ,
                                              A495ConvenioCategoriaStatus ,
                                              AV50Conveniocategoriawwds_1_convenioid ,
                                              A410ConvenioId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Conveniocategoriawwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Conveniocategoriawwds_2_filterfulltext), "%", "");
         lV51Conveniocategoriawwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Conveniocategoriawwds_2_filterfulltext), "%", "");
         lV51Conveniocategoriawwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Conveniocategoriawwds_2_filterfulltext), "%", "");
         lV54Conveniocategoriawwds_5_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV54Conveniocategoriawwds_5_conveniocategoriadescricao1), "%", "");
         lV54Conveniocategoriawwds_5_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV54Conveniocategoriawwds_5_conveniocategoriadescricao1), "%", "");
         lV58Conveniocategoriawwds_9_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV58Conveniocategoriawwds_9_conveniocategoriadescricao2), "%", "");
         lV58Conveniocategoriawwds_9_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV58Conveniocategoriawwds_9_conveniocategoriadescricao2), "%", "");
         lV62Conveniocategoriawwds_13_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV62Conveniocategoriawwds_13_conveniocategoriadescricao3), "%", "");
         lV62Conveniocategoriawwds_13_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV62Conveniocategoriawwds_13_conveniocategoriadescricao3), "%", "");
         lV63Conveniocategoriawwds_14_tfconveniocategoriadescricao = StringUtil.Concat( StringUtil.RTrim( AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao), "%", "");
         /* Using cursor P00A92 */
         pr_default.execute(0, new Object[] {AV50Conveniocategoriawwds_1_convenioid, lV51Conveniocategoriawwds_2_filterfulltext, lV51Conveniocategoriawwds_2_filterfulltext, lV51Conveniocategoriawwds_2_filterfulltext, lV54Conveniocategoriawwds_5_conveniocategoriadescricao1, lV54Conveniocategoriawwds_5_conveniocategoriadescricao1, lV58Conveniocategoriawwds_9_conveniocategoriadescricao2, lV58Conveniocategoriawwds_9_conveniocategoriadescricao2, lV62Conveniocategoriawwds_13_conveniocategoriadescricao3, lV62Conveniocategoriawwds_13_conveniocategoriadescricao3, lV63Conveniocategoriawwds_14_tfconveniocategoriadescricao, AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKA92 = false;
            A410ConvenioId = P00A92_A410ConvenioId[0];
            n410ConvenioId = P00A92_n410ConvenioId[0];
            A494ConvenioCategoriaDescricao = P00A92_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00A92_n494ConvenioCategoriaDescricao[0];
            A495ConvenioCategoriaStatus = P00A92_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = P00A92_n495ConvenioCategoriaStatus[0];
            A493ConvenioCategoriaId = P00A92_A493ConvenioCategoriaId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00A92_A410ConvenioId[0] == A410ConvenioId ) && ( StringUtil.StrCmp(P00A92_A494ConvenioCategoriaDescricao[0], A494ConvenioCategoriaDescricao) == 0 ) )
            {
               BRKA92 = false;
               A493ConvenioCategoriaId = P00A92_A493ConvenioCategoriaId[0];
               AV23count = (long)(AV23count+1);
               BRKA92 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A494ConvenioCategoriaDescricao)) ? "<#Empty#>" : A494ConvenioCategoriaDescricao);
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
            if ( ! BRKA92 )
            {
               BRKA92 = true;
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
         AV10TFConvenioCategoriaDescricao = "";
         AV11TFConvenioCategoriaDescricao_Sel = "";
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38ConvenioCategoriaDescricao1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42ConvenioCategoriaDescricao2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46ConvenioCategoriaDescricao3 = "";
         AV51Conveniocategoriawwds_2_filterfulltext = "";
         AV52Conveniocategoriawwds_3_dynamicfiltersselector1 = "";
         AV54Conveniocategoriawwds_5_conveniocategoriadescricao1 = "";
         AV56Conveniocategoriawwds_7_dynamicfiltersselector2 = "";
         AV58Conveniocategoriawwds_9_conveniocategoriadescricao2 = "";
         AV60Conveniocategoriawwds_11_dynamicfiltersselector3 = "";
         AV62Conveniocategoriawwds_13_conveniocategoriadescricao3 = "";
         AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao = "";
         AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel = "";
         lV51Conveniocategoriawwds_2_filterfulltext = "";
         lV54Conveniocategoriawwds_5_conveniocategoriadescricao1 = "";
         lV58Conveniocategoriawwds_9_conveniocategoriadescricao2 = "";
         lV62Conveniocategoriawwds_13_conveniocategoriadescricao3 = "";
         lV63Conveniocategoriawwds_14_tfconveniocategoriadescricao = "";
         A494ConvenioCategoriaDescricao = "";
         P00A92_A410ConvenioId = new int[1] ;
         P00A92_n410ConvenioId = new bool[] {false} ;
         P00A92_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00A92_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00A92_A495ConvenioCategoriaStatus = new bool[] {false} ;
         P00A92_n495ConvenioCategoriaStatus = new bool[] {false} ;
         P00A92_A493ConvenioCategoriaId = new int[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conveniocategoriawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00A92_A410ConvenioId, P00A92_n410ConvenioId, P00A92_A494ConvenioCategoriaDescricao, P00A92_n494ConvenioCategoriaDescricao, P00A92_A495ConvenioCategoriaStatus, P00A92_n495ConvenioCategoriaStatus, P00A92_A493ConvenioCategoriaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV12TFConvenioCategoriaStatus_Sel ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV53Conveniocategoriawwds_4_dynamicfiltersoperator1 ;
      private short AV57Conveniocategoriawwds_8_dynamicfiltersoperator2 ;
      private short AV61Conveniocategoriawwds_12_dynamicfiltersoperator3 ;
      private short AV65Conveniocategoriawwds_16_tfconveniocategoriastatus_sel ;
      private int AV48GXV1 ;
      private int AV47ConvenioId ;
      private int AV50Conveniocategoriawwds_1_convenioid ;
      private int A410ConvenioId ;
      private int A493ConvenioCategoriaId ;
      private long AV23count ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV55Conveniocategoriawwds_6_dynamicfiltersenabled2 ;
      private bool AV59Conveniocategoriawwds_10_dynamicfiltersenabled3 ;
      private bool A495ConvenioCategoriaStatus ;
      private bool BRKA92 ;
      private bool n410ConvenioId ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n495ConvenioCategoriaStatus ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV10TFConvenioCategoriaDescricao ;
      private string AV11TFConvenioCategoriaDescricao_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV38ConvenioCategoriaDescricao1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV42ConvenioCategoriaDescricao2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV46ConvenioCategoriaDescricao3 ;
      private string AV51Conveniocategoriawwds_2_filterfulltext ;
      private string AV52Conveniocategoriawwds_3_dynamicfiltersselector1 ;
      private string AV54Conveniocategoriawwds_5_conveniocategoriadescricao1 ;
      private string AV56Conveniocategoriawwds_7_dynamicfiltersselector2 ;
      private string AV58Conveniocategoriawwds_9_conveniocategoriadescricao2 ;
      private string AV60Conveniocategoriawwds_11_dynamicfiltersselector3 ;
      private string AV62Conveniocategoriawwds_13_conveniocategoriadescricao3 ;
      private string AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao ;
      private string AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel ;
      private string lV51Conveniocategoriawwds_2_filterfulltext ;
      private string lV54Conveniocategoriawwds_5_conveniocategoriadescricao1 ;
      private string lV58Conveniocategoriawwds_9_conveniocategoriadescricao2 ;
      private string lV62Conveniocategoriawwds_13_conveniocategoriadescricao3 ;
      private string lV63Conveniocategoriawwds_14_tfconveniocategoriadescricao ;
      private string A494ConvenioCategoriaDescricao ;
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
      private int[] P00A92_A410ConvenioId ;
      private bool[] P00A92_n410ConvenioId ;
      private string[] P00A92_A494ConvenioCategoriaDescricao ;
      private bool[] P00A92_n494ConvenioCategoriaDescricao ;
      private bool[] P00A92_A495ConvenioCategoriaStatus ;
      private bool[] P00A92_n495ConvenioCategoriaStatus ;
      private int[] P00A92_A493ConvenioCategoriaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class conveniocategoriawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A92( IGxContext context ,
                                             string AV51Conveniocategoriawwds_2_filterfulltext ,
                                             string AV52Conveniocategoriawwds_3_dynamicfiltersselector1 ,
                                             short AV53Conveniocategoriawwds_4_dynamicfiltersoperator1 ,
                                             string AV54Conveniocategoriawwds_5_conveniocategoriadescricao1 ,
                                             bool AV55Conveniocategoriawwds_6_dynamicfiltersenabled2 ,
                                             string AV56Conveniocategoriawwds_7_dynamicfiltersselector2 ,
                                             short AV57Conveniocategoriawwds_8_dynamicfiltersoperator2 ,
                                             string AV58Conveniocategoriawwds_9_conveniocategoriadescricao2 ,
                                             bool AV59Conveniocategoriawwds_10_dynamicfiltersenabled3 ,
                                             string AV60Conveniocategoriawwds_11_dynamicfiltersselector3 ,
                                             short AV61Conveniocategoriawwds_12_dynamicfiltersoperator3 ,
                                             string AV62Conveniocategoriawwds_13_conveniocategoriadescricao3 ,
                                             string AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel ,
                                             string AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao ,
                                             short AV65Conveniocategoriawwds_16_tfconveniocategoriastatus_sel ,
                                             string A494ConvenioCategoriaDescricao ,
                                             bool A495ConvenioCategoriaStatus ,
                                             int AV50Conveniocategoriawwds_1_convenioid ,
                                             int A410ConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ConvenioId, ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioCategoriaId FROM ConvenioCategoria";
         AddWhere(sWhereString, "(ConvenioId = :AV50Conveniocategoriawwds_1_convenioid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Conveniocategoriawwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConvenioCategoriaDescricao like '%' || :lV51Conveniocategoriawwds_2_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV51Conveniocategoriawwds_2_filterfulltext) and ConvenioCategoriaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV51Conveniocategoriawwds_2_filterfulltext) and ConvenioCategoriaStatus = FALSE))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Conveniocategoriawwds_3_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV53Conveniocategoriawwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniocategoriawwds_5_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV54Conveniocategoriawwds_5_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Conveniocategoriawwds_3_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV53Conveniocategoriawwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniocategoriawwds_5_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like '%' || :lV54Conveniocategoriawwds_5_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV55Conveniocategoriawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Conveniocategoriawwds_7_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV57Conveniocategoriawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Conveniocategoriawwds_9_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV58Conveniocategoriawwds_9_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV55Conveniocategoriawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Conveniocategoriawwds_7_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV57Conveniocategoriawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Conveniocategoriawwds_9_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like '%' || :lV58Conveniocategoriawwds_9_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV59Conveniocategoriawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Conveniocategoriawwds_11_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV61Conveniocategoriawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Conveniocategoriawwds_13_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV62Conveniocategoriawwds_13_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV59Conveniocategoriawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Conveniocategoriawwds_11_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV61Conveniocategoriawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Conveniocategoriawwds_13_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like '%' || :lV62Conveniocategoriawwds_13_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Conveniocategoriawwds_14_tfconveniocategoriadescricao)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV63Conveniocategoriawwds_14_tfconveniocategoriadescricao)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel)) && ! ( StringUtil.StrCmp(AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao = ( :AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao IS NULL or (char_length(trim(trailing ' ' from ConvenioCategoriaDescricao))=0))");
         }
         if ( AV65Conveniocategoriawwds_16_tfconveniocategoriastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaStatus = TRUE)");
         }
         if ( AV65Conveniocategoriawwds_16_tfconveniocategoriastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ConvenioId, ConvenioCategoriaDescricao";
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
                     return conditional_P00A92(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] );
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
          Object[] prmP00A92;
          prmP00A92 = new Object[] {
          new ParDef("AV50Conveniocategoriawwds_1_convenioid",GXType.Int32,9,0) ,
          new ParDef("lV51Conveniocategoriawwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Conveniocategoriawwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Conveniocategoriawwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Conveniocategoriawwds_5_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV54Conveniocategoriawwds_5_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV58Conveniocategoriawwds_9_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV58Conveniocategoriawwds_9_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV62Conveniocategoriawwds_13_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV62Conveniocategoriawwds_13_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV63Conveniocategoriawwds_14_tfconveniocategoriadescricao",GXType.VarChar,70,0) ,
          new ParDef("AV64Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel",GXType.VarChar,70,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A92,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
