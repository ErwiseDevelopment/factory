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
   public class documentoswwgetfilterdata : GXProcedure
   {
      public documentoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoswwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_DOCUMENTOSDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCUMENTOSDESCRICAOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV24Session.Get("DocumentosWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentosWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("DocumentosWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO") == 0 )
            {
               AV10TFDocumentosDescricao = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO_SEL") == 0 )
            {
               AV11TFDocumentosDescricao_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSSTATUS_SEL") == 0 )
            {
               AV12TFDocumentosStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOOBRIGATORIO_SEL") == 0 )
            {
               AV47TFDocumentoObrigatorio_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
         if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "DOCUMENTOSDESCRICAO") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV38DocumentosDescricao1 = AV28GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "DOCUMENTOSDESCRICAO") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV42DocumentosDescricao2 = AV28GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "DOCUMENTOSDESCRICAO") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV46DocumentosDescricao3 = AV28GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCUMENTOSDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV10TFDocumentosDescricao = AV13SearchTxt;
         AV11TFDocumentosDescricao_Sel = "";
         AV50Documentoswwds_1_filterfulltext = AV35FilterFullText;
         AV51Documentoswwds_2_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Documentoswwds_3_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Documentoswwds_4_documentosdescricao1 = AV38DocumentosDescricao1;
         AV54Documentoswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Documentoswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Documentoswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Documentoswwds_8_documentosdescricao2 = AV42DocumentosDescricao2;
         AV58Documentoswwds_9_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Documentoswwds_10_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Documentoswwds_11_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Documentoswwds_12_documentosdescricao3 = AV46DocumentosDescricao3;
         AV62Documentoswwds_13_tfdocumentosdescricao = AV10TFDocumentosDescricao;
         AV63Documentoswwds_14_tfdocumentosdescricao_sel = AV11TFDocumentosDescricao_Sel;
         AV64Documentoswwds_15_tfdocumentosstatus_sel = AV12TFDocumentosStatus_Sel;
         AV65Documentoswwds_16_tfdocumentoobrigatorio_sel = AV47TFDocumentoObrigatorio_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Documentoswwds_1_filterfulltext ,
                                              AV51Documentoswwds_2_dynamicfiltersselector1 ,
                                              AV52Documentoswwds_3_dynamicfiltersoperator1 ,
                                              AV53Documentoswwds_4_documentosdescricao1 ,
                                              AV54Documentoswwds_5_dynamicfiltersenabled2 ,
                                              AV55Documentoswwds_6_dynamicfiltersselector2 ,
                                              AV56Documentoswwds_7_dynamicfiltersoperator2 ,
                                              AV57Documentoswwds_8_documentosdescricao2 ,
                                              AV58Documentoswwds_9_dynamicfiltersenabled3 ,
                                              AV59Documentoswwds_10_dynamicfiltersselector3 ,
                                              AV60Documentoswwds_11_dynamicfiltersoperator3 ,
                                              AV61Documentoswwds_12_documentosdescricao3 ,
                                              AV63Documentoswwds_14_tfdocumentosdescricao_sel ,
                                              AV62Documentoswwds_13_tfdocumentosdescricao ,
                                              AV64Documentoswwds_15_tfdocumentosstatus_sel ,
                                              AV65Documentoswwds_16_tfdocumentoobrigatorio_sel ,
                                              A406DocumentosDescricao ,
                                              A407DocumentosStatus ,
                                              A413DocumentoObrigatorio } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Documentoswwds_1_filterfulltext), "%", "");
         lV50Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Documentoswwds_1_filterfulltext), "%", "");
         lV50Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Documentoswwds_1_filterfulltext), "%", "");
         lV50Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Documentoswwds_1_filterfulltext), "%", "");
         lV50Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Documentoswwds_1_filterfulltext), "%", "");
         lV53Documentoswwds_4_documentosdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV53Documentoswwds_4_documentosdescricao1), "%", "");
         lV53Documentoswwds_4_documentosdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV53Documentoswwds_4_documentosdescricao1), "%", "");
         lV57Documentoswwds_8_documentosdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV57Documentoswwds_8_documentosdescricao2), "%", "");
         lV57Documentoswwds_8_documentosdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV57Documentoswwds_8_documentosdescricao2), "%", "");
         lV61Documentoswwds_12_documentosdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV61Documentoswwds_12_documentosdescricao3), "%", "");
         lV61Documentoswwds_12_documentosdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV61Documentoswwds_12_documentosdescricao3), "%", "");
         lV62Documentoswwds_13_tfdocumentosdescricao = StringUtil.Concat( StringUtil.RTrim( AV62Documentoswwds_13_tfdocumentosdescricao), "%", "");
         /* Using cursor P009N2 */
         pr_default.execute(0, new Object[] {lV50Documentoswwds_1_filterfulltext, lV50Documentoswwds_1_filterfulltext, lV50Documentoswwds_1_filterfulltext, lV50Documentoswwds_1_filterfulltext, lV50Documentoswwds_1_filterfulltext, lV53Documentoswwds_4_documentosdescricao1, lV53Documentoswwds_4_documentosdescricao1, lV57Documentoswwds_8_documentosdescricao2, lV57Documentoswwds_8_documentosdescricao2, lV61Documentoswwds_12_documentosdescricao3, lV61Documentoswwds_12_documentosdescricao3, lV62Documentoswwds_13_tfdocumentosdescricao, AV63Documentoswwds_14_tfdocumentosdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9N2 = false;
            A406DocumentosDescricao = P009N2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P009N2_n406DocumentosDescricao[0];
            A413DocumentoObrigatorio = P009N2_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = P009N2_n413DocumentoObrigatorio[0];
            A407DocumentosStatus = P009N2_A407DocumentosStatus[0];
            n407DocumentosStatus = P009N2_n407DocumentosStatus[0];
            A405DocumentosId = P009N2_A405DocumentosId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009N2_A406DocumentosDescricao[0], A406DocumentosDescricao) == 0 ) )
            {
               BRK9N2 = false;
               A405DocumentosId = P009N2_A405DocumentosId[0];
               AV23count = (long)(AV23count+1);
               BRK9N2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A406DocumentosDescricao)) ? "<#Empty#>" : A406DocumentosDescricao);
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
            if ( ! BRK9N2 )
            {
               BRK9N2 = true;
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
         AV10TFDocumentosDescricao = "";
         AV11TFDocumentosDescricao_Sel = "";
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38DocumentosDescricao1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42DocumentosDescricao2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46DocumentosDescricao3 = "";
         AV50Documentoswwds_1_filterfulltext = "";
         AV51Documentoswwds_2_dynamicfiltersselector1 = "";
         AV53Documentoswwds_4_documentosdescricao1 = "";
         AV55Documentoswwds_6_dynamicfiltersselector2 = "";
         AV57Documentoswwds_8_documentosdescricao2 = "";
         AV59Documentoswwds_10_dynamicfiltersselector3 = "";
         AV61Documentoswwds_12_documentosdescricao3 = "";
         AV62Documentoswwds_13_tfdocumentosdescricao = "";
         AV63Documentoswwds_14_tfdocumentosdescricao_sel = "";
         lV50Documentoswwds_1_filterfulltext = "";
         lV53Documentoswwds_4_documentosdescricao1 = "";
         lV57Documentoswwds_8_documentosdescricao2 = "";
         lV61Documentoswwds_12_documentosdescricao3 = "";
         lV62Documentoswwds_13_tfdocumentosdescricao = "";
         A406DocumentosDescricao = "";
         P009N2_A406DocumentosDescricao = new string[] {""} ;
         P009N2_n406DocumentosDescricao = new bool[] {false} ;
         P009N2_A413DocumentoObrigatorio = new bool[] {false} ;
         P009N2_n413DocumentoObrigatorio = new bool[] {false} ;
         P009N2_A407DocumentosStatus = new bool[] {false} ;
         P009N2_n407DocumentosStatus = new bool[] {false} ;
         P009N2_A405DocumentosId = new int[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009N2_A406DocumentosDescricao, P009N2_n406DocumentosDescricao, P009N2_A413DocumentoObrigatorio, P009N2_n413DocumentoObrigatorio, P009N2_A407DocumentosStatus, P009N2_n407DocumentosStatus, P009N2_A405DocumentosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV12TFDocumentosStatus_Sel ;
      private short AV47TFDocumentoObrigatorio_Sel ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Documentoswwds_3_dynamicfiltersoperator1 ;
      private short AV56Documentoswwds_7_dynamicfiltersoperator2 ;
      private short AV60Documentoswwds_11_dynamicfiltersoperator3 ;
      private short AV64Documentoswwds_15_tfdocumentosstatus_sel ;
      private short AV65Documentoswwds_16_tfdocumentoobrigatorio_sel ;
      private int AV48GXV1 ;
      private int A405DocumentosId ;
      private long AV23count ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Documentoswwds_5_dynamicfiltersenabled2 ;
      private bool AV58Documentoswwds_9_dynamicfiltersenabled3 ;
      private bool A407DocumentosStatus ;
      private bool A413DocumentoObrigatorio ;
      private bool BRK9N2 ;
      private bool n406DocumentosDescricao ;
      private bool n413DocumentoObrigatorio ;
      private bool n407DocumentosStatus ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV10TFDocumentosDescricao ;
      private string AV11TFDocumentosDescricao_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV38DocumentosDescricao1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV42DocumentosDescricao2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV46DocumentosDescricao3 ;
      private string AV50Documentoswwds_1_filterfulltext ;
      private string AV51Documentoswwds_2_dynamicfiltersselector1 ;
      private string AV53Documentoswwds_4_documentosdescricao1 ;
      private string AV55Documentoswwds_6_dynamicfiltersselector2 ;
      private string AV57Documentoswwds_8_documentosdescricao2 ;
      private string AV59Documentoswwds_10_dynamicfiltersselector3 ;
      private string AV61Documentoswwds_12_documentosdescricao3 ;
      private string AV62Documentoswwds_13_tfdocumentosdescricao ;
      private string AV63Documentoswwds_14_tfdocumentosdescricao_sel ;
      private string lV50Documentoswwds_1_filterfulltext ;
      private string lV53Documentoswwds_4_documentosdescricao1 ;
      private string lV57Documentoswwds_8_documentosdescricao2 ;
      private string lV61Documentoswwds_12_documentosdescricao3 ;
      private string lV62Documentoswwds_13_tfdocumentosdescricao ;
      private string A406DocumentosDescricao ;
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
      private string[] P009N2_A406DocumentosDescricao ;
      private bool[] P009N2_n406DocumentosDescricao ;
      private bool[] P009N2_A413DocumentoObrigatorio ;
      private bool[] P009N2_n413DocumentoObrigatorio ;
      private bool[] P009N2_A407DocumentosStatus ;
      private bool[] P009N2_n407DocumentosStatus ;
      private int[] P009N2_A405DocumentosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class documentoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009N2( IGxContext context ,
                                             string AV50Documentoswwds_1_filterfulltext ,
                                             string AV51Documentoswwds_2_dynamicfiltersselector1 ,
                                             short AV52Documentoswwds_3_dynamicfiltersoperator1 ,
                                             string AV53Documentoswwds_4_documentosdescricao1 ,
                                             bool AV54Documentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV55Documentoswwds_6_dynamicfiltersselector2 ,
                                             short AV56Documentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV57Documentoswwds_8_documentosdescricao2 ,
                                             bool AV58Documentoswwds_9_dynamicfiltersenabled3 ,
                                             string AV59Documentoswwds_10_dynamicfiltersselector3 ,
                                             short AV60Documentoswwds_11_dynamicfiltersoperator3 ,
                                             string AV61Documentoswwds_12_documentosdescricao3 ,
                                             string AV63Documentoswwds_14_tfdocumentosdescricao_sel ,
                                             string AV62Documentoswwds_13_tfdocumentosdescricao ,
                                             short AV64Documentoswwds_15_tfdocumentosstatus_sel ,
                                             short AV65Documentoswwds_16_tfdocumentoobrigatorio_sel ,
                                             string A406DocumentosDescricao ,
                                             bool A407DocumentosStatus ,
                                             bool A413DocumentoObrigatorio )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DocumentosDescricao, DocumentoObrigatorio, DocumentosStatus, DocumentosId FROM Documentos";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Documentoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocumentosDescricao like '%' || :lV50Documentoswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV50Documentoswwds_1_filterfulltext) and DocumentosStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV50Documentoswwds_1_filterfulltext) and DocumentosStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV50Documentoswwds_1_filterfulltext) and DocumentoObrigatorio = TRUE) or ( 'não' like '%' || LOWER(:lV50Documentoswwds_1_filterfulltext) and DocumentoObrigatorio = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Documentoswwds_2_dynamicfiltersselector1, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV52Documentoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Documentoswwds_4_documentosdescricao1)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV53Documentoswwds_4_documentosdescricao1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Documentoswwds_2_dynamicfiltersselector1, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV52Documentoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Documentoswwds_4_documentosdescricao1)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV53Documentoswwds_4_documentosdescricao1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV54Documentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Documentoswwds_6_dynamicfiltersselector2, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV56Documentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Documentoswwds_8_documentosdescricao2)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV57Documentoswwds_8_documentosdescricao2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV54Documentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Documentoswwds_6_dynamicfiltersselector2, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV56Documentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Documentoswwds_8_documentosdescricao2)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV57Documentoswwds_8_documentosdescricao2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV58Documentoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Documentoswwds_10_dynamicfiltersselector3, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV60Documentoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Documentoswwds_12_documentosdescricao3)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV61Documentoswwds_12_documentosdescricao3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV58Documentoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Documentoswwds_10_dynamicfiltersselector3, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV60Documentoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Documentoswwds_12_documentosdescricao3)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV61Documentoswwds_12_documentosdescricao3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentoswwds_14_tfdocumentosdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Documentoswwds_13_tfdocumentosdescricao)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV62Documentoswwds_13_tfdocumentosdescricao)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentoswwds_14_tfdocumentosdescricao_sel)) && ! ( StringUtil.StrCmp(AV63Documentoswwds_14_tfdocumentosdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao = ( :AV63Documentoswwds_14_tfdocumentosdescricao_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV63Documentoswwds_14_tfdocumentosdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocumentosDescricao IS NULL or (char_length(trim(trailing ' ' from DocumentosDescricao))=0))");
         }
         if ( AV64Documentoswwds_15_tfdocumentosstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(DocumentosStatus = TRUE)");
         }
         if ( AV64Documentoswwds_15_tfdocumentosstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(DocumentosStatus = FALSE)");
         }
         if ( AV65Documentoswwds_16_tfdocumentoobrigatorio_sel == 1 )
         {
            AddWhere(sWhereString, "(DocumentoObrigatorio = TRUE)");
         }
         if ( AV65Documentoswwds_16_tfdocumentoobrigatorio_sel == 2 )
         {
            AddWhere(sWhereString, "(DocumentoObrigatorio = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocumentosDescricao";
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
                     return conditional_P009N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP009N2;
          prmP009N2 = new Object[] {
          new ParDef("lV50Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Documentoswwds_4_documentosdescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV53Documentoswwds_4_documentosdescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57Documentoswwds_8_documentosdescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV57Documentoswwds_8_documentosdescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV61Documentoswwds_12_documentosdescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV61Documentoswwds_12_documentosdescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV62Documentoswwds_13_tfdocumentosdescricao",GXType.VarChar,40,0) ,
          new ParDef("AV63Documentoswwds_14_tfdocumentosdescricao_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009N2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
