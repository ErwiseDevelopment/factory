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
   public class categoriatitulowwgetfilterdata : GXProcedure
   {
      public categoriatitulowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public categoriatitulowwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CATEGORIATITULONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCATEGORIATITULONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CATEGORIATITULODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADCATEGORIATITULODESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("CategoriaTituloWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CategoriaTituloWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("CategoriaTituloWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULONOME") == 0 )
            {
               AV12TFCategoriaTituloNome = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULONOME_SEL") == 0 )
            {
               AV13TFCategoriaTituloNome_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO") == 0 )
            {
               AV14TFCategoriaTituloDescricao = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO_SEL") == 0 )
            {
               AV15TFCategoriaTituloDescricao_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIASTATUS_SEL") == 0 )
            {
               AV17TFCategoriaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "CATEGORIATITULONOME") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV43CategoriaTituloNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "CATEGORIATITULONOME") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV47CategoriaTituloNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "CATEGORIATITULONOME") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV51CategoriaTituloNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCATEGORIATITULONOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFCategoriaTituloNome = AV18SearchTxt;
         AV13TFCategoriaTituloNome_Sel = "";
         AV54Categoriatitulowwds_1_filterfulltext = AV40FilterFullText;
         AV55Categoriatitulowwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Categoriatitulowwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Categoriatitulowwds_4_categoriatitulonome1 = AV43CategoriaTituloNome1;
         AV58Categoriatitulowwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Categoriatitulowwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Categoriatitulowwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Categoriatitulowwds_8_categoriatitulonome2 = AV47CategoriaTituloNome2;
         AV62Categoriatitulowwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Categoriatitulowwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Categoriatitulowwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Categoriatitulowwds_12_categoriatitulonome3 = AV51CategoriaTituloNome3;
         AV66Categoriatitulowwds_13_tfcategoriatitulonome = AV12TFCategoriaTituloNome;
         AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel = AV13TFCategoriaTituloNome_Sel;
         AV68Categoriatitulowwds_15_tfcategoriatitulodescricao = AV14TFCategoriaTituloDescricao;
         AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = AV15TFCategoriaTituloDescricao_Sel;
         AV70Categoriatitulowwds_17_tfcategoriastatus_sel = AV17TFCategoriaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Categoriatitulowwds_1_filterfulltext ,
                                              AV55Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                              AV56Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                              AV57Categoriatitulowwds_4_categoriatitulonome1 ,
                                              AV58Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                              AV59Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                              AV60Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                              AV61Categoriatitulowwds_8_categoriatitulonome2 ,
                                              AV62Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                              AV63Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                              AV64Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                              AV65Categoriatitulowwds_12_categoriatitulonome3 ,
                                              AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                              AV66Categoriatitulowwds_13_tfcategoriatitulonome ,
                                              AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                              AV68Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                              AV70Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                              A427CategoriaTituloNome ,
                                              A428CategoriaTituloDescricao ,
                                              A431CategoriaStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV57Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV57Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV61Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV61Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV65Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV65Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV66Categoriatitulowwds_13_tfcategoriatitulonome = StringUtil.Concat( StringUtil.RTrim( AV66Categoriatitulowwds_13_tfcategoriatitulonome), "%", "");
         lV68Categoriatitulowwds_15_tfcategoriatitulodescricao = StringUtil.Concat( StringUtil.RTrim( AV68Categoriatitulowwds_15_tfcategoriatitulodescricao), "%", "");
         /* Using cursor P00A12 */
         pr_default.execute(0, new Object[] {lV54Categoriatitulowwds_1_filterfulltext, lV54Categoriatitulowwds_1_filterfulltext, lV54Categoriatitulowwds_1_filterfulltext, lV54Categoriatitulowwds_1_filterfulltext, lV57Categoriatitulowwds_4_categoriatitulonome1, lV57Categoriatitulowwds_4_categoriatitulonome1, lV61Categoriatitulowwds_8_categoriatitulonome2, lV61Categoriatitulowwds_8_categoriatitulonome2, lV65Categoriatitulowwds_12_categoriatitulonome3, lV65Categoriatitulowwds_12_categoriatitulonome3, lV66Categoriatitulowwds_13_tfcategoriatitulonome, AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel, lV68Categoriatitulowwds_15_tfcategoriatitulodescricao, AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKA12 = false;
            A427CategoriaTituloNome = P00A12_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = P00A12_n427CategoriaTituloNome[0];
            A431CategoriaStatus = P00A12_A431CategoriaStatus[0];
            n431CategoriaStatus = P00A12_n431CategoriaStatus[0];
            A428CategoriaTituloDescricao = P00A12_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00A12_n428CategoriaTituloDescricao[0];
            A426CategoriaTituloId = P00A12_A426CategoriaTituloId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00A12_A427CategoriaTituloNome[0], A427CategoriaTituloNome) == 0 ) )
            {
               BRKA12 = false;
               A426CategoriaTituloId = P00A12_A426CategoriaTituloId[0];
               AV28count = (long)(AV28count+1);
               BRKA12 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A427CategoriaTituloNome)) ? "<#Empty#>" : A427CategoriaTituloNome);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKA12 )
            {
               BRKA12 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCATEGORIATITULODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV14TFCategoriaTituloDescricao = AV18SearchTxt;
         AV15TFCategoriaTituloDescricao_Sel = "";
         AV54Categoriatitulowwds_1_filterfulltext = AV40FilterFullText;
         AV55Categoriatitulowwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Categoriatitulowwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Categoriatitulowwds_4_categoriatitulonome1 = AV43CategoriaTituloNome1;
         AV58Categoriatitulowwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Categoriatitulowwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Categoriatitulowwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Categoriatitulowwds_8_categoriatitulonome2 = AV47CategoriaTituloNome2;
         AV62Categoriatitulowwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Categoriatitulowwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Categoriatitulowwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Categoriatitulowwds_12_categoriatitulonome3 = AV51CategoriaTituloNome3;
         AV66Categoriatitulowwds_13_tfcategoriatitulonome = AV12TFCategoriaTituloNome;
         AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel = AV13TFCategoriaTituloNome_Sel;
         AV68Categoriatitulowwds_15_tfcategoriatitulodescricao = AV14TFCategoriaTituloDescricao;
         AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = AV15TFCategoriaTituloDescricao_Sel;
         AV70Categoriatitulowwds_17_tfcategoriastatus_sel = AV17TFCategoriaStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Categoriatitulowwds_1_filterfulltext ,
                                              AV55Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                              AV56Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                              AV57Categoriatitulowwds_4_categoriatitulonome1 ,
                                              AV58Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                              AV59Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                              AV60Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                              AV61Categoriatitulowwds_8_categoriatitulonome2 ,
                                              AV62Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                              AV63Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                              AV64Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                              AV65Categoriatitulowwds_12_categoriatitulonome3 ,
                                              AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                              AV66Categoriatitulowwds_13_tfcategoriatitulonome ,
                                              AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                              AV68Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                              AV70Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                              A427CategoriaTituloNome ,
                                              A428CategoriaTituloDescricao ,
                                              A431CategoriaStatus } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV54Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext), "%", "");
         lV57Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV57Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV61Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV61Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV65Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV65Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV66Categoriatitulowwds_13_tfcategoriatitulonome = StringUtil.Concat( StringUtil.RTrim( AV66Categoriatitulowwds_13_tfcategoriatitulonome), "%", "");
         lV68Categoriatitulowwds_15_tfcategoriatitulodescricao = StringUtil.Concat( StringUtil.RTrim( AV68Categoriatitulowwds_15_tfcategoriatitulodescricao), "%", "");
         /* Using cursor P00A13 */
         pr_default.execute(1, new Object[] {lV54Categoriatitulowwds_1_filterfulltext, lV54Categoriatitulowwds_1_filterfulltext, lV54Categoriatitulowwds_1_filterfulltext, lV54Categoriatitulowwds_1_filterfulltext, lV57Categoriatitulowwds_4_categoriatitulonome1, lV57Categoriatitulowwds_4_categoriatitulonome1, lV61Categoriatitulowwds_8_categoriatitulonome2, lV61Categoriatitulowwds_8_categoriatitulonome2, lV65Categoriatitulowwds_12_categoriatitulonome3, lV65Categoriatitulowwds_12_categoriatitulonome3, lV66Categoriatitulowwds_13_tfcategoriatitulonome, AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel, lV68Categoriatitulowwds_15_tfcategoriatitulodescricao, AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKA14 = false;
            A428CategoriaTituloDescricao = P00A13_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00A13_n428CategoriaTituloDescricao[0];
            A431CategoriaStatus = P00A13_A431CategoriaStatus[0];
            n431CategoriaStatus = P00A13_n431CategoriaStatus[0];
            A427CategoriaTituloNome = P00A13_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = P00A13_n427CategoriaTituloNome[0];
            A426CategoriaTituloId = P00A13_A426CategoriaTituloId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00A13_A428CategoriaTituloDescricao[0], A428CategoriaTituloDescricao) == 0 ) )
            {
               BRKA14 = false;
               A426CategoriaTituloId = P00A13_A426CategoriaTituloId[0];
               AV28count = (long)(AV28count+1);
               BRKA14 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) ? "<#Empty#>" : A428CategoriaTituloDescricao);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKA14 )
            {
               BRKA14 = true;
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV12TFCategoriaTituloNome = "";
         AV13TFCategoriaTituloNome_Sel = "";
         AV14TFCategoriaTituloDescricao = "";
         AV15TFCategoriaTituloDescricao_Sel = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43CategoriaTituloNome1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47CategoriaTituloNome2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51CategoriaTituloNome3 = "";
         AV54Categoriatitulowwds_1_filterfulltext = "";
         AV55Categoriatitulowwds_2_dynamicfiltersselector1 = "";
         AV57Categoriatitulowwds_4_categoriatitulonome1 = "";
         AV59Categoriatitulowwds_6_dynamicfiltersselector2 = "";
         AV61Categoriatitulowwds_8_categoriatitulonome2 = "";
         AV63Categoriatitulowwds_10_dynamicfiltersselector3 = "";
         AV65Categoriatitulowwds_12_categoriatitulonome3 = "";
         AV66Categoriatitulowwds_13_tfcategoriatitulonome = "";
         AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel = "";
         AV68Categoriatitulowwds_15_tfcategoriatitulodescricao = "";
         AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = "";
         lV54Categoriatitulowwds_1_filterfulltext = "";
         lV57Categoriatitulowwds_4_categoriatitulonome1 = "";
         lV61Categoriatitulowwds_8_categoriatitulonome2 = "";
         lV65Categoriatitulowwds_12_categoriatitulonome3 = "";
         lV66Categoriatitulowwds_13_tfcategoriatitulonome = "";
         lV68Categoriatitulowwds_15_tfcategoriatitulodescricao = "";
         A427CategoriaTituloNome = "";
         A428CategoriaTituloDescricao = "";
         P00A12_A427CategoriaTituloNome = new string[] {""} ;
         P00A12_n427CategoriaTituloNome = new bool[] {false} ;
         P00A12_A431CategoriaStatus = new bool[] {false} ;
         P00A12_n431CategoriaStatus = new bool[] {false} ;
         P00A12_A428CategoriaTituloDescricao = new string[] {""} ;
         P00A12_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00A12_A426CategoriaTituloId = new int[1] ;
         AV23Option = "";
         P00A13_A428CategoriaTituloDescricao = new string[] {""} ;
         P00A13_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00A13_A431CategoriaStatus = new bool[] {false} ;
         P00A13_n431CategoriaStatus = new bool[] {false} ;
         P00A13_A427CategoriaTituloNome = new string[] {""} ;
         P00A13_n427CategoriaTituloNome = new bool[] {false} ;
         P00A13_A426CategoriaTituloId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriatitulowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00A12_A427CategoriaTituloNome, P00A12_n427CategoriaTituloNome, P00A12_A431CategoriaStatus, P00A12_n431CategoriaStatus, P00A12_A428CategoriaTituloDescricao, P00A12_n428CategoriaTituloDescricao, P00A12_A426CategoriaTituloId
               }
               , new Object[] {
               P00A13_A428CategoriaTituloDescricao, P00A13_n428CategoriaTituloDescricao, P00A13_A431CategoriaStatus, P00A13_n431CategoriaStatus, P00A13_A427CategoriaTituloNome, P00A13_n427CategoriaTituloNome, P00A13_A426CategoriaTituloId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV17TFCategoriaStatus_Sel ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV56Categoriatitulowwds_3_dynamicfiltersoperator1 ;
      private short AV60Categoriatitulowwds_7_dynamicfiltersoperator2 ;
      private short AV64Categoriatitulowwds_11_dynamicfiltersoperator3 ;
      private short AV70Categoriatitulowwds_17_tfcategoriastatus_sel ;
      private int AV52GXV1 ;
      private int A426CategoriaTituloId ;
      private long AV28count ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV58Categoriatitulowwds_5_dynamicfiltersenabled2 ;
      private bool AV62Categoriatitulowwds_9_dynamicfiltersenabled3 ;
      private bool A431CategoriaStatus ;
      private bool BRKA12 ;
      private bool n427CategoriaTituloNome ;
      private bool n431CategoriaStatus ;
      private bool n428CategoriaTituloDescricao ;
      private bool BRKA14 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV12TFCategoriaTituloNome ;
      private string AV13TFCategoriaTituloNome_Sel ;
      private string AV14TFCategoriaTituloDescricao ;
      private string AV15TFCategoriaTituloDescricao_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV43CategoriaTituloNome1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47CategoriaTituloNome2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV51CategoriaTituloNome3 ;
      private string AV54Categoriatitulowwds_1_filterfulltext ;
      private string AV55Categoriatitulowwds_2_dynamicfiltersselector1 ;
      private string AV57Categoriatitulowwds_4_categoriatitulonome1 ;
      private string AV59Categoriatitulowwds_6_dynamicfiltersselector2 ;
      private string AV61Categoriatitulowwds_8_categoriatitulonome2 ;
      private string AV63Categoriatitulowwds_10_dynamicfiltersselector3 ;
      private string AV65Categoriatitulowwds_12_categoriatitulonome3 ;
      private string AV66Categoriatitulowwds_13_tfcategoriatitulonome ;
      private string AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel ;
      private string AV68Categoriatitulowwds_15_tfcategoriatitulodescricao ;
      private string AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ;
      private string lV54Categoriatitulowwds_1_filterfulltext ;
      private string lV57Categoriatitulowwds_4_categoriatitulonome1 ;
      private string lV61Categoriatitulowwds_8_categoriatitulonome2 ;
      private string lV65Categoriatitulowwds_12_categoriatitulonome3 ;
      private string lV66Categoriatitulowwds_13_tfcategoriatitulonome ;
      private string lV68Categoriatitulowwds_15_tfcategoriatitulodescricao ;
      private string A427CategoriaTituloNome ;
      private string A428CategoriaTituloDescricao ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00A12_A427CategoriaTituloNome ;
      private bool[] P00A12_n427CategoriaTituloNome ;
      private bool[] P00A12_A431CategoriaStatus ;
      private bool[] P00A12_n431CategoriaStatus ;
      private string[] P00A12_A428CategoriaTituloDescricao ;
      private bool[] P00A12_n428CategoriaTituloDescricao ;
      private int[] P00A12_A426CategoriaTituloId ;
      private string[] P00A13_A428CategoriaTituloDescricao ;
      private bool[] P00A13_n428CategoriaTituloDescricao ;
      private bool[] P00A13_A431CategoriaStatus ;
      private bool[] P00A13_n431CategoriaStatus ;
      private string[] P00A13_A427CategoriaTituloNome ;
      private bool[] P00A13_n427CategoriaTituloNome ;
      private int[] P00A13_A426CategoriaTituloId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class categoriatitulowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A12( IGxContext context ,
                                             string AV54Categoriatitulowwds_1_filterfulltext ,
                                             string AV55Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                             short AV56Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                             string AV57Categoriatitulowwds_4_categoriatitulonome1 ,
                                             bool AV58Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                             string AV59Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                             short AV60Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                             string AV61Categoriatitulowwds_8_categoriatitulonome2 ,
                                             bool AV62Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                             string AV63Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                             short AV64Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                             string AV65Categoriatitulowwds_12_categoriatitulonome3 ,
                                             string AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                             string AV66Categoriatitulowwds_13_tfcategoriatitulonome ,
                                             string AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                             string AV68Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                             short AV70Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                             string A427CategoriaTituloNome ,
                                             string A428CategoriaTituloDescricao ,
                                             bool A431CategoriaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CategoriaTituloNome, CategoriaStatus, CategoriaTituloDescricao, CategoriaTituloId FROM CategoriaTitulo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CategoriaTituloNome like '%' || :lV54Categoriatitulowwds_1_filterfulltext) or ( CategoriaTituloDescricao like '%' || :lV54Categoriatitulowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV54Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV54Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV56Categoriatitulowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV57Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV56Categoriatitulowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV57Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV60Categoriatitulowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV61Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV60Categoriatitulowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV61Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV62Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV64Categoriatitulowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV65Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV62Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV64Categoriatitulowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV65Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Categoriatitulowwds_13_tfcategoriatitulonome)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV66Categoriatitulowwds_13_tfcategoriatitulonome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ! ( StringUtil.StrCmp(AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome = ( :AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Categoriatitulowwds_15_tfcategoriatitulodescricao)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao like :lV68Categoriatitulowwds_15_tfcategoriatitulodescricao)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ! ( StringUtil.StrCmp(AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao = ( :AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloDescricao))=0))");
         }
         if ( AV70Categoriatitulowwds_17_tfcategoriastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = TRUE)");
         }
         if ( AV70Categoriatitulowwds_17_tfcategoriastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CategoriaTituloNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00A13( IGxContext context ,
                                             string AV54Categoriatitulowwds_1_filterfulltext ,
                                             string AV55Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                             short AV56Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                             string AV57Categoriatitulowwds_4_categoriatitulonome1 ,
                                             bool AV58Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                             string AV59Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                             short AV60Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                             string AV61Categoriatitulowwds_8_categoriatitulonome2 ,
                                             bool AV62Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                             string AV63Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                             short AV64Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                             string AV65Categoriatitulowwds_12_categoriatitulonome3 ,
                                             string AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                             string AV66Categoriatitulowwds_13_tfcategoriatitulonome ,
                                             string AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                             string AV68Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                             short AV70Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                             string A427CategoriaTituloNome ,
                                             string A428CategoriaTituloDescricao ,
                                             bool A431CategoriaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CategoriaTituloDescricao, CategoriaStatus, CategoriaTituloNome, CategoriaTituloId FROM CategoriaTitulo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Categoriatitulowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CategoriaTituloNome like '%' || :lV54Categoriatitulowwds_1_filterfulltext) or ( CategoriaTituloDescricao like '%' || :lV54Categoriatitulowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV54Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV54Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV56Categoriatitulowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV57Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV56Categoriatitulowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV57Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV58Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV60Categoriatitulowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV61Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV58Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV60Categoriatitulowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV61Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV62Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV64Categoriatitulowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV65Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV62Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV64Categoriatitulowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV65Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Categoriatitulowwds_13_tfcategoriatitulonome)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV66Categoriatitulowwds_13_tfcategoriatitulonome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ! ( StringUtil.StrCmp(AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome = ( :AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Categoriatitulowwds_15_tfcategoriatitulodescricao)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao like :lV68Categoriatitulowwds_15_tfcategoriatitulodescricao)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ! ( StringUtil.StrCmp(AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao = ( :AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloDescricao))=0))");
         }
         if ( AV70Categoriatitulowwds_17_tfcategoriastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = TRUE)");
         }
         if ( AV70Categoriatitulowwds_17_tfcategoriastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CategoriaTituloDescricao";
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
                     return conditional_P00A12(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] );
               case 1 :
                     return conditional_P00A13(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00A12;
          prmP00A12 = new Object[] {
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV57Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV61Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV61Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV65Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV65Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV66Categoriatitulowwds_13_tfcategoriatitulonome",GXType.VarChar,60,0) ,
          new ParDef("AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel",GXType.VarChar,60,0) ,
          new ParDef("lV68Categoriatitulowwds_15_tfcategoriatitulodescricao",GXType.VarChar,150,0) ,
          new ParDef("AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00A13;
          prmP00A13 = new Object[] {
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV57Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV61Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV61Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV65Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV65Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV66Categoriatitulowwds_13_tfcategoriatitulonome",GXType.VarChar,60,0) ,
          new ParDef("AV67Categoriatitulowwds_14_tfcategoriatitulonome_sel",GXType.VarChar,60,0) ,
          new ParDef("lV68Categoriatitulowwds_15_tfcategoriatitulodescricao",GXType.VarChar,150,0) ,
          new ParDef("AV69Categoriatitulowwds_16_tfcategoriatitulodescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A13,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
