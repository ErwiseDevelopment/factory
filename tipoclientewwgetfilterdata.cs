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
   public class tipoclientewwgetfilterdata : GXProcedure
   {
      public tipoclientewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipoclientewwgetfilterdata( IGxContext context )
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
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_TIPOCLIENTEDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPOCLIENTEDESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("TipoClienteWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoClienteWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("TipoClienteWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV12TFTipoClienteDescricao = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV13TFTipoClienteDescricao_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV14TFTipoClienteTipoPessoa_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV15TFTipoClienteTipoPessoa_Sels.FromJSonString(AV14TFTipoClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEPORTAL_SEL") == 0 )
            {
               AV50TFTipoClientePortal_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV39DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV40DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV41TipoClienteDescricao1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV45TipoClienteDescricao2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV46DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV47DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV48DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV49TipoClienteDescricao3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPOCLIENTEDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipoClienteDescricao = AV16SearchTxt;
         AV13TFTipoClienteDescricao_Sel = "";
         AV53Tipoclientewwds_1_filterfulltext = AV38FilterFullText;
         AV54Tipoclientewwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV55Tipoclientewwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV56Tipoclientewwds_4_tipoclientedescricao1 = AV41TipoClienteDescricao1;
         AV57Tipoclientewwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV58Tipoclientewwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV59Tipoclientewwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV60Tipoclientewwds_8_tipoclientedescricao2 = AV45TipoClienteDescricao2;
         AV61Tipoclientewwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV62Tipoclientewwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV63Tipoclientewwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV64Tipoclientewwds_12_tipoclientedescricao3 = AV49TipoClienteDescricao3;
         AV65Tipoclientewwds_13_tftipoclientedescricao = AV12TFTipoClienteDescricao;
         AV66Tipoclientewwds_14_tftipoclientedescricao_sel = AV13TFTipoClienteDescricao_Sel;
         AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV15TFTipoClienteTipoPessoa_Sels;
         AV68Tipoclientewwds_16_tftipoclienteportal_sel = AV50TFTipoClientePortal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A194TipoClienteTipoPessoa ,
                                              AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                              AV53Tipoclientewwds_1_filterfulltext ,
                                              AV54Tipoclientewwds_2_dynamicfiltersselector1 ,
                                              AV55Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                              AV56Tipoclientewwds_4_tipoclientedescricao1 ,
                                              AV57Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                              AV58Tipoclientewwds_6_dynamicfiltersselector2 ,
                                              AV59Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                              AV60Tipoclientewwds_8_tipoclientedescricao2 ,
                                              AV61Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                              AV62Tipoclientewwds_10_dynamicfiltersselector3 ,
                                              AV63Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                              AV64Tipoclientewwds_12_tipoclientedescricao3 ,
                                              AV66Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                              AV65Tipoclientewwds_13_tftipoclientedescricao ,
                                              AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels.Count ,
                                              AV68Tipoclientewwds_16_tftipoclienteportal_sel ,
                                              A193TipoClienteDescricao ,
                                              A207TipoClientePortal } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipoclientewwds_1_filterfulltext), "%", "");
         lV53Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipoclientewwds_1_filterfulltext), "%", "");
         lV53Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipoclientewwds_1_filterfulltext), "%", "");
         lV53Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipoclientewwds_1_filterfulltext), "%", "");
         lV53Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipoclientewwds_1_filterfulltext), "%", "");
         lV56Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV56Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV60Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV60Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV60Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV60Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV64Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV64Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV64Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV64Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV65Tipoclientewwds_13_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV65Tipoclientewwds_13_tftipoclientedescricao), "%", "");
         /* Using cursor P00622 */
         pr_default.execute(0, new Object[] {lV53Tipoclientewwds_1_filterfulltext, lV53Tipoclientewwds_1_filterfulltext, lV53Tipoclientewwds_1_filterfulltext, lV53Tipoclientewwds_1_filterfulltext, lV53Tipoclientewwds_1_filterfulltext, lV56Tipoclientewwds_4_tipoclientedescricao1, lV56Tipoclientewwds_4_tipoclientedescricao1, lV60Tipoclientewwds_8_tipoclientedescricao2, lV60Tipoclientewwds_8_tipoclientedescricao2, lV64Tipoclientewwds_12_tipoclientedescricao3, lV64Tipoclientewwds_12_tipoclientedescricao3, lV65Tipoclientewwds_13_tftipoclientedescricao, AV66Tipoclientewwds_14_tftipoclientedescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK622 = false;
            A193TipoClienteDescricao = P00622_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00622_n193TipoClienteDescricao[0];
            A207TipoClientePortal = P00622_A207TipoClientePortal[0];
            n207TipoClientePortal = P00622_n207TipoClientePortal[0];
            A194TipoClienteTipoPessoa = P00622_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = P00622_n194TipoClienteTipoPessoa[0];
            A192TipoClienteId = P00622_A192TipoClienteId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00622_A193TipoClienteDescricao[0], A193TipoClienteDescricao) == 0 ) )
            {
               BRK622 = false;
               A192TipoClienteId = P00622_A192TipoClienteId[0];
               AV26count = (long)(AV26count+1);
               BRK622 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) ? "<#Empty#>" : A193TipoClienteDescricao);
               AV23OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")));
               AV22Options.Add(AV21Option, 0);
               AV24OptionsDesc.Add(AV23OptionDesc, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK622 )
            {
               BRK622 = true;
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
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV12TFTipoClienteDescricao = "";
         AV13TFTipoClienteDescricao_Sel = "";
         AV14TFTipoClienteTipoPessoa_SelsJson = "";
         AV15TFTipoClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39DynamicFiltersSelector1 = "";
         AV41TipoClienteDescricao1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45TipoClienteDescricao2 = "";
         AV47DynamicFiltersSelector3 = "";
         AV49TipoClienteDescricao3 = "";
         AV53Tipoclientewwds_1_filterfulltext = "";
         AV54Tipoclientewwds_2_dynamicfiltersselector1 = "";
         AV56Tipoclientewwds_4_tipoclientedescricao1 = "";
         AV58Tipoclientewwds_6_dynamicfiltersselector2 = "";
         AV60Tipoclientewwds_8_tipoclientedescricao2 = "";
         AV62Tipoclientewwds_10_dynamicfiltersselector3 = "";
         AV64Tipoclientewwds_12_tipoclientedescricao3 = "";
         AV65Tipoclientewwds_13_tftipoclientedescricao = "";
         AV66Tipoclientewwds_14_tftipoclientedescricao_sel = "";
         AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV53Tipoclientewwds_1_filterfulltext = "";
         lV56Tipoclientewwds_4_tipoclientedescricao1 = "";
         lV60Tipoclientewwds_8_tipoclientedescricao2 = "";
         lV64Tipoclientewwds_12_tipoclientedescricao3 = "";
         lV65Tipoclientewwds_13_tftipoclientedescricao = "";
         A194TipoClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         P00622_A193TipoClienteDescricao = new string[] {""} ;
         P00622_n193TipoClienteDescricao = new bool[] {false} ;
         P00622_A207TipoClientePortal = new bool[] {false} ;
         P00622_n207TipoClientePortal = new bool[] {false} ;
         P00622_A194TipoClienteTipoPessoa = new string[] {""} ;
         P00622_n194TipoClienteTipoPessoa = new bool[] {false} ;
         P00622_A192TipoClienteId = new short[1] ;
         AV21Option = "";
         AV23OptionDesc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoclientewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00622_A193TipoClienteDescricao, P00622_n193TipoClienteDescricao, P00622_A207TipoClientePortal, P00622_n207TipoClientePortal, P00622_A194TipoClienteTipoPessoa, P00622_n194TipoClienteTipoPessoa, P00622_A192TipoClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV50TFTipoClientePortal_Sel ;
      private short AV40DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV48DynamicFiltersOperator3 ;
      private short AV55Tipoclientewwds_3_dynamicfiltersoperator1 ;
      private short AV59Tipoclientewwds_7_dynamicfiltersoperator2 ;
      private short AV63Tipoclientewwds_11_dynamicfiltersoperator3 ;
      private short AV68Tipoclientewwds_16_tftipoclienteportal_sel ;
      private short A192TipoClienteId ;
      private int AV51GXV1 ;
      private int AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ;
      private long AV26count ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV46DynamicFiltersEnabled3 ;
      private bool AV57Tipoclientewwds_5_dynamicfiltersenabled2 ;
      private bool AV61Tipoclientewwds_9_dynamicfiltersenabled3 ;
      private bool A207TipoClientePortal ;
      private bool BRK622 ;
      private bool n193TipoClienteDescricao ;
      private bool n207TipoClientePortal ;
      private bool n194TipoClienteTipoPessoa ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV14TFTipoClienteTipoPessoa_SelsJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV12TFTipoClienteDescricao ;
      private string AV13TFTipoClienteDescricao_Sel ;
      private string AV39DynamicFiltersSelector1 ;
      private string AV41TipoClienteDescricao1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV45TipoClienteDescricao2 ;
      private string AV47DynamicFiltersSelector3 ;
      private string AV49TipoClienteDescricao3 ;
      private string AV53Tipoclientewwds_1_filterfulltext ;
      private string AV54Tipoclientewwds_2_dynamicfiltersselector1 ;
      private string AV56Tipoclientewwds_4_tipoclientedescricao1 ;
      private string AV58Tipoclientewwds_6_dynamicfiltersselector2 ;
      private string AV60Tipoclientewwds_8_tipoclientedescricao2 ;
      private string AV62Tipoclientewwds_10_dynamicfiltersselector3 ;
      private string AV64Tipoclientewwds_12_tipoclientedescricao3 ;
      private string AV65Tipoclientewwds_13_tftipoclientedescricao ;
      private string AV66Tipoclientewwds_14_tftipoclientedescricao_sel ;
      private string lV53Tipoclientewwds_1_filterfulltext ;
      private string lV56Tipoclientewwds_4_tipoclientedescricao1 ;
      private string lV60Tipoclientewwds_8_tipoclientedescricao2 ;
      private string lV64Tipoclientewwds_12_tipoclientedescricao3 ;
      private string lV65Tipoclientewwds_13_tftipoclientedescricao ;
      private string A194TipoClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string AV21Option ;
      private string AV23OptionDesc ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GxSimpleCollection<string> AV15TFTipoClienteTipoPessoa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00622_A193TipoClienteDescricao ;
      private bool[] P00622_n193TipoClienteDescricao ;
      private bool[] P00622_A207TipoClientePortal ;
      private bool[] P00622_n207TipoClientePortal ;
      private string[] P00622_A194TipoClienteTipoPessoa ;
      private bool[] P00622_n194TipoClienteTipoPessoa ;
      private short[] P00622_A192TipoClienteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class tipoclientewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00622( IGxContext context ,
                                             string A194TipoClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                             string AV53Tipoclientewwds_1_filterfulltext ,
                                             string AV54Tipoclientewwds_2_dynamicfiltersselector1 ,
                                             short AV55Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV56Tipoclientewwds_4_tipoclientedescricao1 ,
                                             bool AV57Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                             string AV58Tipoclientewwds_6_dynamicfiltersselector2 ,
                                             short AV59Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                             string AV60Tipoclientewwds_8_tipoclientedescricao2 ,
                                             bool AV61Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                             string AV62Tipoclientewwds_10_dynamicfiltersselector3 ,
                                             short AV63Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                             string AV64Tipoclientewwds_12_tipoclientedescricao3 ,
                                             string AV66Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                             string AV65Tipoclientewwds_13_tftipoclientedescricao ,
                                             int AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ,
                                             short AV68Tipoclientewwds_16_tftipoclienteportal_sel ,
                                             string A193TipoClienteDescricao ,
                                             bool A207TipoClientePortal )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TipoClienteDescricao, TipoClientePortal, TipoClienteTipoPessoa, TipoClienteId FROM TipoCliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tipoclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TipoClienteDescricao like '%' || :lV53Tipoclientewwds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV53Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV53Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'JURIDICA')) or ( 'sim' like '%' || LOWER(:lV53Tipoclientewwds_1_filterfulltext) and TipoClientePortal = TRUE) or ( 'não' like '%' || LOWER(:lV53Tipoclientewwds_1_filterfulltext) and TipoClientePortal = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV55Tipoclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV56Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV55Tipoclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV56Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV57Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV59Tipoclientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV60Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV57Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV59Tipoclientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV60Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV61Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV63Tipoclientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV64Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV61Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV63Tipoclientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV64Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Tipoclientewwds_14_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Tipoclientewwds_13_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV65Tipoclientewwds_13_tftipoclientedescricao)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Tipoclientewwds_14_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV66Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao = ( :AV66Tipoclientewwds_14_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from TipoClienteDescricao))=0))");
         }
         if ( AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV67Tipoclientewwds_15_tftipoclientetipopessoa_sels, "TipoClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV68Tipoclientewwds_16_tftipoclienteportal_sel == 1 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = TRUE)");
         }
         if ( AV68Tipoclientewwds_16_tftipoclienteportal_sel == 2 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TipoClienteDescricao";
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
                     return conditional_P00622(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00622;
          prmP00622 = new Object[] {
          new ParDef("lV53Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV60Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV60Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV64Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV64Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV65Tipoclientewwds_13_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV66Tipoclientewwds_14_tftipoclientedescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00622", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00622,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
