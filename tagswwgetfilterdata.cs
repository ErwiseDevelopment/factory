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
   public class tagswwgetfilterdata : GXProcedure
   {
      public tagswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tagswwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_TAGSDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTAGSDESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_TAGSCONTEUDO") == 0 )
         {
            /* Execute user subroutine: 'LOADTAGSCONTEUDOOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV25Session.Get("TagsWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TagsWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("TagsWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTAGSDESCRICAO") == 0 )
            {
               AV12TFTagsDescricao = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTAGSDESCRICAO_SEL") == 0 )
            {
               AV13TFTagsDescricao_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTAGSCONTEUDO") == 0 )
            {
               AV10TFTagsConteudo = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTAGSCONTEUDO_SEL") == 0 )
            {
               AV11TFTagsConteudo_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "TAGSDESCRICAO") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV39TagsDescricao1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV40DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV41DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV41DynamicFiltersSelector2, "TAGSDESCRICAO") == 0 )
               {
                  AV42DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV43TagsDescricao2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV44DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV45DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "TAGSDESCRICAO") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV47TagsDescricao3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTAGSDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV12TFTagsDescricao = AV14SearchTxt;
         AV13TFTagsDescricao_Sel = "";
         AV50Tagswwds_1_filterfulltext = AV36FilterFullText;
         AV51Tagswwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV52Tagswwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV53Tagswwds_4_tagsdescricao1 = AV39TagsDescricao1;
         AV54Tagswwds_5_dynamicfiltersenabled2 = AV40DynamicFiltersEnabled2;
         AV55Tagswwds_6_dynamicfiltersselector2 = AV41DynamicFiltersSelector2;
         AV56Tagswwds_7_dynamicfiltersoperator2 = AV42DynamicFiltersOperator2;
         AV57Tagswwds_8_tagsdescricao2 = AV43TagsDescricao2;
         AV58Tagswwds_9_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV59Tagswwds_10_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV60Tagswwds_11_dynamicfiltersoperator3 = AV46DynamicFiltersOperator3;
         AV61Tagswwds_12_tagsdescricao3 = AV47TagsDescricao3;
         AV62Tagswwds_13_tftagsdescricao = AV12TFTagsDescricao;
         AV63Tagswwds_14_tftagsdescricao_sel = AV13TFTagsDescricao_Sel;
         AV64Tagswwds_15_tftagsconteudo = AV10TFTagsConteudo;
         AV65Tagswwds_16_tftagsconteudo_sel = AV11TFTagsConteudo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Tagswwds_1_filterfulltext ,
                                              AV51Tagswwds_2_dynamicfiltersselector1 ,
                                              AV52Tagswwds_3_dynamicfiltersoperator1 ,
                                              AV53Tagswwds_4_tagsdescricao1 ,
                                              AV54Tagswwds_5_dynamicfiltersenabled2 ,
                                              AV55Tagswwds_6_dynamicfiltersselector2 ,
                                              AV56Tagswwds_7_dynamicfiltersoperator2 ,
                                              AV57Tagswwds_8_tagsdescricao2 ,
                                              AV58Tagswwds_9_dynamicfiltersenabled3 ,
                                              AV59Tagswwds_10_dynamicfiltersselector3 ,
                                              AV60Tagswwds_11_dynamicfiltersoperator3 ,
                                              AV61Tagswwds_12_tagsdescricao3 ,
                                              AV63Tagswwds_14_tftagsdescricao_sel ,
                                              AV62Tagswwds_13_tftagsdescricao ,
                                              AV65Tagswwds_16_tftagsconteudo_sel ,
                                              AV64Tagswwds_15_tftagsconteudo ,
                                              A373TagsDescricao ,
                                              A374TagsConteudo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Tagswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Tagswwds_1_filterfulltext), "%", "");
         lV50Tagswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Tagswwds_1_filterfulltext), "%", "");
         lV53Tagswwds_4_tagsdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1), "%", "");
         lV53Tagswwds_4_tagsdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1), "%", "");
         lV57Tagswwds_8_tagsdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2), "%", "");
         lV57Tagswwds_8_tagsdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2), "%", "");
         lV61Tagswwds_12_tagsdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3), "%", "");
         lV61Tagswwds_12_tagsdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3), "%", "");
         lV62Tagswwds_13_tftagsdescricao = StringUtil.Concat( StringUtil.RTrim( AV62Tagswwds_13_tftagsdescricao), "%", "");
         lV64Tagswwds_15_tftagsconteudo = StringUtil.Concat( StringUtil.RTrim( AV64Tagswwds_15_tftagsconteudo), "%", "");
         /* Using cursor P00942 */
         pr_default.execute(0, new Object[] {lV50Tagswwds_1_filterfulltext, lV50Tagswwds_1_filterfulltext, lV53Tagswwds_4_tagsdescricao1, lV53Tagswwds_4_tagsdescricao1, lV57Tagswwds_8_tagsdescricao2, lV57Tagswwds_8_tagsdescricao2, lV61Tagswwds_12_tagsdescricao3, lV61Tagswwds_12_tagsdescricao3, lV62Tagswwds_13_tftagsdescricao, AV63Tagswwds_14_tftagsdescricao_sel, lV64Tagswwds_15_tftagsconteudo, AV65Tagswwds_16_tftagsconteudo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK942 = false;
            A373TagsDescricao = P00942_A373TagsDescricao[0];
            n373TagsDescricao = P00942_n373TagsDescricao[0];
            A374TagsConteudo = P00942_A374TagsConteudo[0];
            n374TagsConteudo = P00942_n374TagsConteudo[0];
            A372TagsId = P00942_A372TagsId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00942_A373TagsDescricao[0], A373TagsDescricao) == 0 ) )
            {
               BRK942 = false;
               A372TagsId = P00942_A372TagsId[0];
               AV24count = (long)(AV24count+1);
               BRK942 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A373TagsDescricao)) ? "<#Empty#>" : A373TagsDescricao);
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
            if ( ! BRK942 )
            {
               BRK942 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTAGSCONTEUDOOPTIONS' Routine */
         returnInSub = false;
         AV10TFTagsConteudo = AV14SearchTxt;
         AV11TFTagsConteudo_Sel = "";
         AV50Tagswwds_1_filterfulltext = AV36FilterFullText;
         AV51Tagswwds_2_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV52Tagswwds_3_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV53Tagswwds_4_tagsdescricao1 = AV39TagsDescricao1;
         AV54Tagswwds_5_dynamicfiltersenabled2 = AV40DynamicFiltersEnabled2;
         AV55Tagswwds_6_dynamicfiltersselector2 = AV41DynamicFiltersSelector2;
         AV56Tagswwds_7_dynamicfiltersoperator2 = AV42DynamicFiltersOperator2;
         AV57Tagswwds_8_tagsdescricao2 = AV43TagsDescricao2;
         AV58Tagswwds_9_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV59Tagswwds_10_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV60Tagswwds_11_dynamicfiltersoperator3 = AV46DynamicFiltersOperator3;
         AV61Tagswwds_12_tagsdescricao3 = AV47TagsDescricao3;
         AV62Tagswwds_13_tftagsdescricao = AV12TFTagsDescricao;
         AV63Tagswwds_14_tftagsdescricao_sel = AV13TFTagsDescricao_Sel;
         AV64Tagswwds_15_tftagsconteudo = AV10TFTagsConteudo;
         AV65Tagswwds_16_tftagsconteudo_sel = AV11TFTagsConteudo_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Tagswwds_1_filterfulltext ,
                                              AV51Tagswwds_2_dynamicfiltersselector1 ,
                                              AV52Tagswwds_3_dynamicfiltersoperator1 ,
                                              AV53Tagswwds_4_tagsdescricao1 ,
                                              AV54Tagswwds_5_dynamicfiltersenabled2 ,
                                              AV55Tagswwds_6_dynamicfiltersselector2 ,
                                              AV56Tagswwds_7_dynamicfiltersoperator2 ,
                                              AV57Tagswwds_8_tagsdescricao2 ,
                                              AV58Tagswwds_9_dynamicfiltersenabled3 ,
                                              AV59Tagswwds_10_dynamicfiltersselector3 ,
                                              AV60Tagswwds_11_dynamicfiltersoperator3 ,
                                              AV61Tagswwds_12_tagsdescricao3 ,
                                              AV63Tagswwds_14_tftagsdescricao_sel ,
                                              AV62Tagswwds_13_tftagsdescricao ,
                                              AV65Tagswwds_16_tftagsconteudo_sel ,
                                              AV64Tagswwds_15_tftagsconteudo ,
                                              A373TagsDescricao ,
                                              A374TagsConteudo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Tagswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Tagswwds_1_filterfulltext), "%", "");
         lV50Tagswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Tagswwds_1_filterfulltext), "%", "");
         lV53Tagswwds_4_tagsdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1), "%", "");
         lV53Tagswwds_4_tagsdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1), "%", "");
         lV57Tagswwds_8_tagsdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2), "%", "");
         lV57Tagswwds_8_tagsdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2), "%", "");
         lV61Tagswwds_12_tagsdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3), "%", "");
         lV61Tagswwds_12_tagsdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3), "%", "");
         lV62Tagswwds_13_tftagsdescricao = StringUtil.Concat( StringUtil.RTrim( AV62Tagswwds_13_tftagsdescricao), "%", "");
         lV64Tagswwds_15_tftagsconteudo = StringUtil.Concat( StringUtil.RTrim( AV64Tagswwds_15_tftagsconteudo), "%", "");
         /* Using cursor P00943 */
         pr_default.execute(1, new Object[] {lV50Tagswwds_1_filterfulltext, lV50Tagswwds_1_filterfulltext, lV53Tagswwds_4_tagsdescricao1, lV53Tagswwds_4_tagsdescricao1, lV57Tagswwds_8_tagsdescricao2, lV57Tagswwds_8_tagsdescricao2, lV61Tagswwds_12_tagsdescricao3, lV61Tagswwds_12_tagsdescricao3, lV62Tagswwds_13_tftagsdescricao, AV63Tagswwds_14_tftagsdescricao_sel, lV64Tagswwds_15_tftagsconteudo, AV65Tagswwds_16_tftagsconteudo_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK944 = false;
            A374TagsConteudo = P00943_A374TagsConteudo[0];
            n374TagsConteudo = P00943_n374TagsConteudo[0];
            A373TagsDescricao = P00943_A373TagsDescricao[0];
            n373TagsDescricao = P00943_n373TagsDescricao[0];
            A372TagsId = P00943_A372TagsId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00943_A374TagsConteudo[0], A374TagsConteudo) == 0 ) )
            {
               BRK944 = false;
               A372TagsId = P00943_A372TagsId[0];
               AV24count = (long)(AV24count+1);
               BRK944 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A374TagsConteudo)) ? "<#Empty#>" : A374TagsConteudo);
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
            if ( ! BRK944 )
            {
               BRK944 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV12TFTagsDescricao = "";
         AV13TFTagsDescricao_Sel = "";
         AV10TFTagsConteudo = "";
         AV11TFTagsConteudo_Sel = "";
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV39TagsDescricao1 = "";
         AV41DynamicFiltersSelector2 = "";
         AV43TagsDescricao2 = "";
         AV45DynamicFiltersSelector3 = "";
         AV47TagsDescricao3 = "";
         AV50Tagswwds_1_filterfulltext = "";
         AV51Tagswwds_2_dynamicfiltersselector1 = "";
         AV53Tagswwds_4_tagsdescricao1 = "";
         AV55Tagswwds_6_dynamicfiltersselector2 = "";
         AV57Tagswwds_8_tagsdescricao2 = "";
         AV59Tagswwds_10_dynamicfiltersselector3 = "";
         AV61Tagswwds_12_tagsdescricao3 = "";
         AV62Tagswwds_13_tftagsdescricao = "";
         AV63Tagswwds_14_tftagsdescricao_sel = "";
         AV64Tagswwds_15_tftagsconteudo = "";
         AV65Tagswwds_16_tftagsconteudo_sel = "";
         lV50Tagswwds_1_filterfulltext = "";
         lV53Tagswwds_4_tagsdescricao1 = "";
         lV57Tagswwds_8_tagsdescricao2 = "";
         lV61Tagswwds_12_tagsdescricao3 = "";
         lV62Tagswwds_13_tftagsdescricao = "";
         lV64Tagswwds_15_tftagsconteudo = "";
         A373TagsDescricao = "";
         A374TagsConteudo = "";
         P00942_A373TagsDescricao = new string[] {""} ;
         P00942_n373TagsDescricao = new bool[] {false} ;
         P00942_A374TagsConteudo = new string[] {""} ;
         P00942_n374TagsConteudo = new bool[] {false} ;
         P00942_A372TagsId = new int[1] ;
         AV19Option = "";
         P00943_A374TagsConteudo = new string[] {""} ;
         P00943_n374TagsConteudo = new bool[] {false} ;
         P00943_A373TagsDescricao = new string[] {""} ;
         P00943_n373TagsDescricao = new bool[] {false} ;
         P00943_A372TagsId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tagswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00942_A373TagsDescricao, P00942_n373TagsDescricao, P00942_A374TagsConteudo, P00942_n374TagsConteudo, P00942_A372TagsId
               }
               , new Object[] {
               P00943_A374TagsConteudo, P00943_n374TagsConteudo, P00943_A373TagsDescricao, P00943_n373TagsDescricao, P00943_A372TagsId
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
      private short AV52Tagswwds_3_dynamicfiltersoperator1 ;
      private short AV56Tagswwds_7_dynamicfiltersoperator2 ;
      private short AV60Tagswwds_11_dynamicfiltersoperator3 ;
      private int AV48GXV1 ;
      private int A372TagsId ;
      private long AV24count ;
      private bool returnInSub ;
      private bool AV40DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool AV54Tagswwds_5_dynamicfiltersenabled2 ;
      private bool AV58Tagswwds_9_dynamicfiltersenabled3 ;
      private bool BRK942 ;
      private bool n373TagsDescricao ;
      private bool n374TagsConteudo ;
      private bool BRK944 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV12TFTagsDescricao ;
      private string AV13TFTagsDescricao_Sel ;
      private string AV10TFTagsConteudo ;
      private string AV11TFTagsConteudo_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV39TagsDescricao1 ;
      private string AV41DynamicFiltersSelector2 ;
      private string AV43TagsDescricao2 ;
      private string AV45DynamicFiltersSelector3 ;
      private string AV47TagsDescricao3 ;
      private string AV50Tagswwds_1_filterfulltext ;
      private string AV51Tagswwds_2_dynamicfiltersselector1 ;
      private string AV53Tagswwds_4_tagsdescricao1 ;
      private string AV55Tagswwds_6_dynamicfiltersselector2 ;
      private string AV57Tagswwds_8_tagsdescricao2 ;
      private string AV59Tagswwds_10_dynamicfiltersselector3 ;
      private string AV61Tagswwds_12_tagsdescricao3 ;
      private string AV62Tagswwds_13_tftagsdescricao ;
      private string AV63Tagswwds_14_tftagsdescricao_sel ;
      private string AV64Tagswwds_15_tftagsconteudo ;
      private string AV65Tagswwds_16_tftagsconteudo_sel ;
      private string lV50Tagswwds_1_filterfulltext ;
      private string lV53Tagswwds_4_tagsdescricao1 ;
      private string lV57Tagswwds_8_tagsdescricao2 ;
      private string lV61Tagswwds_12_tagsdescricao3 ;
      private string lV62Tagswwds_13_tftagsdescricao ;
      private string lV64Tagswwds_15_tftagsconteudo ;
      private string A373TagsDescricao ;
      private string A374TagsConteudo ;
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
      private string[] P00942_A373TagsDescricao ;
      private bool[] P00942_n373TagsDescricao ;
      private string[] P00942_A374TagsConteudo ;
      private bool[] P00942_n374TagsConteudo ;
      private int[] P00942_A372TagsId ;
      private string[] P00943_A374TagsConteudo ;
      private bool[] P00943_n374TagsConteudo ;
      private string[] P00943_A373TagsDescricao ;
      private bool[] P00943_n373TagsDescricao ;
      private int[] P00943_A372TagsId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class tagswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00942( IGxContext context ,
                                             string AV50Tagswwds_1_filterfulltext ,
                                             string AV51Tagswwds_2_dynamicfiltersselector1 ,
                                             short AV52Tagswwds_3_dynamicfiltersoperator1 ,
                                             string AV53Tagswwds_4_tagsdescricao1 ,
                                             bool AV54Tagswwds_5_dynamicfiltersenabled2 ,
                                             string AV55Tagswwds_6_dynamicfiltersselector2 ,
                                             short AV56Tagswwds_7_dynamicfiltersoperator2 ,
                                             string AV57Tagswwds_8_tagsdescricao2 ,
                                             bool AV58Tagswwds_9_dynamicfiltersenabled3 ,
                                             string AV59Tagswwds_10_dynamicfiltersselector3 ,
                                             short AV60Tagswwds_11_dynamicfiltersoperator3 ,
                                             string AV61Tagswwds_12_tagsdescricao3 ,
                                             string AV63Tagswwds_14_tftagsdescricao_sel ,
                                             string AV62Tagswwds_13_tftagsdescricao ,
                                             string AV65Tagswwds_16_tftagsconteudo_sel ,
                                             string AV64Tagswwds_15_tftagsconteudo ,
                                             string A373TagsDescricao ,
                                             string A374TagsConteudo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TagsDescricao, TagsConteudo, TagsId FROM Tags";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Tagswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(TagsDescricao) like '%' || LOWER(:lV50Tagswwds_1_filterfulltext)) or ( LOWER(TagsConteudo) like '%' || LOWER(:lV50Tagswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Tagswwds_2_dynamicfiltersselector1, "TAGSDESCRICAO") == 0 ) && ( AV52Tagswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV53Tagswwds_4_tagsdescricao1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Tagswwds_2_dynamicfiltersselector1, "TAGSDESCRICAO") == 0 ) && ( AV52Tagswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like '%' || :lV53Tagswwds_4_tagsdescricao1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV54Tagswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Tagswwds_6_dynamicfiltersselector2, "TAGSDESCRICAO") == 0 ) && ( AV56Tagswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV57Tagswwds_8_tagsdescricao2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV54Tagswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Tagswwds_6_dynamicfiltersselector2, "TAGSDESCRICAO") == 0 ) && ( AV56Tagswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like '%' || :lV57Tagswwds_8_tagsdescricao2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Tagswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Tagswwds_10_dynamicfiltersselector3, "TAGSDESCRICAO") == 0 ) && ( AV60Tagswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV61Tagswwds_12_tagsdescricao3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Tagswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Tagswwds_10_dynamicfiltersselector3, "TAGSDESCRICAO") == 0 ) && ( AV60Tagswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like '%' || :lV61Tagswwds_12_tagsdescricao3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Tagswwds_14_tftagsdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Tagswwds_13_tftagsdescricao)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV62Tagswwds_13_tftagsdescricao)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Tagswwds_14_tftagsdescricao_sel)) && ! ( StringUtil.StrCmp(AV63Tagswwds_14_tftagsdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TagsDescricao = ( :AV63Tagswwds_14_tftagsdescricao_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Tagswwds_14_tftagsdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TagsDescricao IS NULL or (char_length(trim(trailing ' ' from TagsDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Tagswwds_16_tftagsconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tagswwds_15_tftagsconteudo)) ) )
         {
            AddWhere(sWhereString, "(TagsConteudo like :lV64Tagswwds_15_tftagsconteudo)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Tagswwds_16_tftagsconteudo_sel)) && ! ( StringUtil.StrCmp(AV65Tagswwds_16_tftagsconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TagsConteudo = ( :AV65Tagswwds_16_tftagsconteudo_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Tagswwds_16_tftagsconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TagsConteudo IS NULL or (char_length(trim(trailing ' ' from TagsConteudo))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TagsDescricao";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00943( IGxContext context ,
                                             string AV50Tagswwds_1_filterfulltext ,
                                             string AV51Tagswwds_2_dynamicfiltersselector1 ,
                                             short AV52Tagswwds_3_dynamicfiltersoperator1 ,
                                             string AV53Tagswwds_4_tagsdescricao1 ,
                                             bool AV54Tagswwds_5_dynamicfiltersenabled2 ,
                                             string AV55Tagswwds_6_dynamicfiltersselector2 ,
                                             short AV56Tagswwds_7_dynamicfiltersoperator2 ,
                                             string AV57Tagswwds_8_tagsdescricao2 ,
                                             bool AV58Tagswwds_9_dynamicfiltersenabled3 ,
                                             string AV59Tagswwds_10_dynamicfiltersselector3 ,
                                             short AV60Tagswwds_11_dynamicfiltersoperator3 ,
                                             string AV61Tagswwds_12_tagsdescricao3 ,
                                             string AV63Tagswwds_14_tftagsdescricao_sel ,
                                             string AV62Tagswwds_13_tftagsdescricao ,
                                             string AV65Tagswwds_16_tftagsconteudo_sel ,
                                             string AV64Tagswwds_15_tftagsconteudo ,
                                             string A373TagsDescricao ,
                                             string A374TagsConteudo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TagsConteudo, TagsDescricao, TagsId FROM Tags";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Tagswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(TagsDescricao) like '%' || LOWER(:lV50Tagswwds_1_filterfulltext)) or ( LOWER(TagsConteudo) like '%' || LOWER(:lV50Tagswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Tagswwds_2_dynamicfiltersselector1, "TAGSDESCRICAO") == 0 ) && ( AV52Tagswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV53Tagswwds_4_tagsdescricao1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Tagswwds_2_dynamicfiltersselector1, "TAGSDESCRICAO") == 0 ) && ( AV52Tagswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tagswwds_4_tagsdescricao1)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like '%' || :lV53Tagswwds_4_tagsdescricao1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV54Tagswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Tagswwds_6_dynamicfiltersselector2, "TAGSDESCRICAO") == 0 ) && ( AV56Tagswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV57Tagswwds_8_tagsdescricao2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV54Tagswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Tagswwds_6_dynamicfiltersselector2, "TAGSDESCRICAO") == 0 ) && ( AV56Tagswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tagswwds_8_tagsdescricao2)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like '%' || :lV57Tagswwds_8_tagsdescricao2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV58Tagswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Tagswwds_10_dynamicfiltersselector3, "TAGSDESCRICAO") == 0 ) && ( AV60Tagswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV61Tagswwds_12_tagsdescricao3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV58Tagswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Tagswwds_10_dynamicfiltersselector3, "TAGSDESCRICAO") == 0 ) && ( AV60Tagswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Tagswwds_12_tagsdescricao3)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like '%' || :lV61Tagswwds_12_tagsdescricao3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Tagswwds_14_tftagsdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Tagswwds_13_tftagsdescricao)) ) )
         {
            AddWhere(sWhereString, "(TagsDescricao like :lV62Tagswwds_13_tftagsdescricao)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Tagswwds_14_tftagsdescricao_sel)) && ! ( StringUtil.StrCmp(AV63Tagswwds_14_tftagsdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TagsDescricao = ( :AV63Tagswwds_14_tftagsdescricao_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Tagswwds_14_tftagsdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TagsDescricao IS NULL or (char_length(trim(trailing ' ' from TagsDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Tagswwds_16_tftagsconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tagswwds_15_tftagsconteudo)) ) )
         {
            AddWhere(sWhereString, "(TagsConteudo like :lV64Tagswwds_15_tftagsconteudo)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Tagswwds_16_tftagsconteudo_sel)) && ! ( StringUtil.StrCmp(AV65Tagswwds_16_tftagsconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TagsConteudo = ( :AV65Tagswwds_16_tftagsconteudo_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Tagswwds_16_tftagsconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TagsConteudo IS NULL or (char_length(trim(trailing ' ' from TagsConteudo))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TagsConteudo";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00942(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P00943(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00942;
          prmP00942 = new Object[] {
          new ParDef("lV50Tagswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Tagswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tagswwds_4_tagsdescricao1",GXType.VarChar,108,0) ,
          new ParDef("lV53Tagswwds_4_tagsdescricao1",GXType.VarChar,108,0) ,
          new ParDef("lV57Tagswwds_8_tagsdescricao2",GXType.VarChar,108,0) ,
          new ParDef("lV57Tagswwds_8_tagsdescricao2",GXType.VarChar,108,0) ,
          new ParDef("lV61Tagswwds_12_tagsdescricao3",GXType.VarChar,108,0) ,
          new ParDef("lV61Tagswwds_12_tagsdescricao3",GXType.VarChar,108,0) ,
          new ParDef("lV62Tagswwds_13_tftagsdescricao",GXType.VarChar,108,0) ,
          new ParDef("AV63Tagswwds_14_tftagsdescricao_sel",GXType.VarChar,108,0) ,
          new ParDef("lV64Tagswwds_15_tftagsconteudo",GXType.VarChar,40,0) ,
          new ParDef("AV65Tagswwds_16_tftagsconteudo_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00943;
          prmP00943 = new Object[] {
          new ParDef("lV50Tagswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Tagswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tagswwds_4_tagsdescricao1",GXType.VarChar,108,0) ,
          new ParDef("lV53Tagswwds_4_tagsdescricao1",GXType.VarChar,108,0) ,
          new ParDef("lV57Tagswwds_8_tagsdescricao2",GXType.VarChar,108,0) ,
          new ParDef("lV57Tagswwds_8_tagsdescricao2",GXType.VarChar,108,0) ,
          new ParDef("lV61Tagswwds_12_tagsdescricao3",GXType.VarChar,108,0) ,
          new ParDef("lV61Tagswwds_12_tagsdescricao3",GXType.VarChar,108,0) ,
          new ParDef("lV62Tagswwds_13_tftagsdescricao",GXType.VarChar,108,0) ,
          new ParDef("AV63Tagswwds_14_tftagsdescricao_sel",GXType.VarChar,108,0) ,
          new ParDef("lV64Tagswwds_15_tftagsconteudo",GXType.VarChar,40,0) ,
          new ParDef("AV65Tagswwds_16_tftagsconteudo_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00942", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00942,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00943", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00943,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
