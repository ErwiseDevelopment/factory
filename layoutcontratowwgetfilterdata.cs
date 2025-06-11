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
   public class layoutcontratowwgetfilterdata : GXProcedure
   {
      public layoutcontratowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public layoutcontratowwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_LAYOUTCONTRATODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADLAYOUTCONTRATODESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_LAYOUTCONTRATOTAG") == 0 )
         {
            /* Execute user subroutine: 'LOADLAYOUTCONTRATOTAGOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV27Session.Get("LayoutContratoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LayoutContratoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("LayoutContratoWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV11TFLayoutContratoDescricao = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO_SEL") == 0 )
            {
               AV12TFLayoutContratoDescricao_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOSTATUS_SEL") == 0 )
            {
               AV13TFLayoutContratoStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTIPO_SEL") == 0 )
            {
               AV53TFLayoutContratoTipo_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV54TFLayoutContratoTipo_Sels.FromJSonString(AV53TFLayoutContratoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG") == 0 )
            {
               AV55TFLayoutContratoTag = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG_SEL") == 0 )
            {
               AV56TFLayoutContratoTag_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV39DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "LAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV40DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV41LayoutContratoDescricao1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "LAYOUTCONTRATODESCRICAO") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV45LayoutContratoDescricao2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV46DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV47DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "LAYOUTCONTRATODESCRICAO") == 0 )
                  {
                     AV48DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV49LayoutContratoDescricao3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADLAYOUTCONTRATODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV11TFLayoutContratoDescricao = AV16SearchTxt;
         AV12TFLayoutContratoDescricao_Sel = "";
         AV59Layoutcontratowwds_1_filterfulltext = AV38FilterFullText;
         AV60Layoutcontratowwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV61Layoutcontratowwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV62Layoutcontratowwds_4_layoutcontratodescricao1 = AV41LayoutContratoDescricao1;
         AV63Layoutcontratowwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV64Layoutcontratowwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV65Layoutcontratowwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV66Layoutcontratowwds_8_layoutcontratodescricao2 = AV45LayoutContratoDescricao2;
         AV67Layoutcontratowwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV68Layoutcontratowwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV69Layoutcontratowwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV70Layoutcontratowwds_12_layoutcontratodescricao3 = AV49LayoutContratoDescricao3;
         AV71Layoutcontratowwds_13_tflayoutcontratodescricao = AV11TFLayoutContratoDescricao;
         AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV12TFLayoutContratoDescricao_Sel;
         AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV13TFLayoutContratoStatus_Sel;
         AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV54TFLayoutContratoTipo_Sels;
         AV75Layoutcontratowwds_17_tflayoutcontratotag = AV55TFLayoutContratoTag;
         AV76Layoutcontratowwds_18_tflayoutcontratotag_sel = AV56TFLayoutContratoTag_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A906LayoutContratoTipo ,
                                              AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                              AV59Layoutcontratowwds_1_filterfulltext ,
                                              AV60Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                              AV61Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                              AV62Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                              AV63Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                              AV64Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                              AV65Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                              AV66Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                              AV67Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                              AV68Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                              AV69Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                              AV70Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                              AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                              AV71Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                              AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                              AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels.Count ,
                                              AV76Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                              AV75Layoutcontratowwds_17_tflayoutcontratotag ,
                                              A155LayoutContratoDescricao ,
                                              A156LayoutContratoStatus ,
                                              A1000LayoutContratoTag } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV62Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV62Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV66Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV66Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV70Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV70Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV71Layoutcontratowwds_13_tflayoutcontratodescricao = StringUtil.Concat( StringUtil.RTrim( AV71Layoutcontratowwds_13_tflayoutcontratodescricao), "%", "");
         lV75Layoutcontratowwds_17_tflayoutcontratotag = StringUtil.Concat( StringUtil.RTrim( AV75Layoutcontratowwds_17_tflayoutcontratotag), "%", "");
         /* Using cursor P005E2 */
         pr_default.execute(0, new Object[] {lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV62Layoutcontratowwds_4_layoutcontratodescricao1, lV62Layoutcontratowwds_4_layoutcontratodescricao1, lV66Layoutcontratowwds_8_layoutcontratodescricao2, lV66Layoutcontratowwds_8_layoutcontratodescricao2, lV70Layoutcontratowwds_12_layoutcontratodescricao3, lV70Layoutcontratowwds_12_layoutcontratodescricao3, lV71Layoutcontratowwds_13_tflayoutcontratodescricao, AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel, lV75Layoutcontratowwds_17_tflayoutcontratotag, AV76Layoutcontratowwds_18_tflayoutcontratotag_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5E2 = false;
            A155LayoutContratoDescricao = P005E2_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = P005E2_n155LayoutContratoDescricao[0];
            A1000LayoutContratoTag = P005E2_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = P005E2_n1000LayoutContratoTag[0];
            A906LayoutContratoTipo = P005E2_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = P005E2_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = P005E2_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = P005E2_n156LayoutContratoStatus[0];
            A154LayoutContratoId = P005E2_A154LayoutContratoId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005E2_A155LayoutContratoDescricao[0], A155LayoutContratoDescricao) == 0 ) )
            {
               BRK5E2 = false;
               A154LayoutContratoId = P005E2_A154LayoutContratoId[0];
               AV26count = (long)(AV26count+1);
               BRK5E2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A155LayoutContratoDescricao)) ? "<#Empty#>" : A155LayoutContratoDescricao);
               AV22Options.Add(AV21Option, 0);
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
            if ( ! BRK5E2 )
            {
               BRK5E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLAYOUTCONTRATOTAGOPTIONS' Routine */
         returnInSub = false;
         AV55TFLayoutContratoTag = AV16SearchTxt;
         AV56TFLayoutContratoTag_Sel = "";
         AV59Layoutcontratowwds_1_filterfulltext = AV38FilterFullText;
         AV60Layoutcontratowwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV61Layoutcontratowwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV62Layoutcontratowwds_4_layoutcontratodescricao1 = AV41LayoutContratoDescricao1;
         AV63Layoutcontratowwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV64Layoutcontratowwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV65Layoutcontratowwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV66Layoutcontratowwds_8_layoutcontratodescricao2 = AV45LayoutContratoDescricao2;
         AV67Layoutcontratowwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV68Layoutcontratowwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV69Layoutcontratowwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV70Layoutcontratowwds_12_layoutcontratodescricao3 = AV49LayoutContratoDescricao3;
         AV71Layoutcontratowwds_13_tflayoutcontratodescricao = AV11TFLayoutContratoDescricao;
         AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV12TFLayoutContratoDescricao_Sel;
         AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV13TFLayoutContratoStatus_Sel;
         AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV54TFLayoutContratoTipo_Sels;
         AV75Layoutcontratowwds_17_tflayoutcontratotag = AV55TFLayoutContratoTag;
         AV76Layoutcontratowwds_18_tflayoutcontratotag_sel = AV56TFLayoutContratoTag_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A906LayoutContratoTipo ,
                                              AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                              AV59Layoutcontratowwds_1_filterfulltext ,
                                              AV60Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                              AV61Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                              AV62Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                              AV63Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                              AV64Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                              AV65Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                              AV66Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                              AV67Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                              AV68Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                              AV69Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                              AV70Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                              AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                              AV71Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                              AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                              AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels.Count ,
                                              AV76Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                              AV75Layoutcontratowwds_17_tflayoutcontratotag ,
                                              A155LayoutContratoDescricao ,
                                              A156LayoutContratoStatus ,
                                              A1000LayoutContratoTag } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV59Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext), "%", "");
         lV62Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV62Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV66Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV66Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV70Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV70Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV71Layoutcontratowwds_13_tflayoutcontratodescricao = StringUtil.Concat( StringUtil.RTrim( AV71Layoutcontratowwds_13_tflayoutcontratodescricao), "%", "");
         lV75Layoutcontratowwds_17_tflayoutcontratotag = StringUtil.Concat( StringUtil.RTrim( AV75Layoutcontratowwds_17_tflayoutcontratotag), "%", "");
         /* Using cursor P005E3 */
         pr_default.execute(1, new Object[] {lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV59Layoutcontratowwds_1_filterfulltext, lV62Layoutcontratowwds_4_layoutcontratodescricao1, lV62Layoutcontratowwds_4_layoutcontratodescricao1, lV66Layoutcontratowwds_8_layoutcontratodescricao2, lV66Layoutcontratowwds_8_layoutcontratodescricao2, lV70Layoutcontratowwds_12_layoutcontratodescricao3, lV70Layoutcontratowwds_12_layoutcontratodescricao3, lV71Layoutcontratowwds_13_tflayoutcontratodescricao, AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel, lV75Layoutcontratowwds_17_tflayoutcontratotag, AV76Layoutcontratowwds_18_tflayoutcontratotag_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5E4 = false;
            A1000LayoutContratoTag = P005E3_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = P005E3_n1000LayoutContratoTag[0];
            A906LayoutContratoTipo = P005E3_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = P005E3_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = P005E3_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = P005E3_n156LayoutContratoStatus[0];
            A155LayoutContratoDescricao = P005E3_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = P005E3_n155LayoutContratoDescricao[0];
            A154LayoutContratoId = P005E3_A154LayoutContratoId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005E3_A1000LayoutContratoTag[0], A1000LayoutContratoTag) == 0 ) )
            {
               BRK5E4 = false;
               A154LayoutContratoId = P005E3_A154LayoutContratoId[0];
               AV26count = (long)(AV26count+1);
               BRK5E4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1000LayoutContratoTag)) ? "<#Empty#>" : A1000LayoutContratoTag);
               AV22Options.Add(AV21Option, 0);
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
            if ( ! BRK5E4 )
            {
               BRK5E4 = true;
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
         AV11TFLayoutContratoDescricao = "";
         AV12TFLayoutContratoDescricao_Sel = "";
         AV53TFLayoutContratoTipo_SelsJson = "";
         AV54TFLayoutContratoTipo_Sels = new GxSimpleCollection<string>();
         AV55TFLayoutContratoTag = "";
         AV56TFLayoutContratoTag_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39DynamicFiltersSelector1 = "";
         AV41LayoutContratoDescricao1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45LayoutContratoDescricao2 = "";
         AV47DynamicFiltersSelector3 = "";
         AV49LayoutContratoDescricao3 = "";
         AV59Layoutcontratowwds_1_filterfulltext = "";
         AV60Layoutcontratowwds_2_dynamicfiltersselector1 = "";
         AV62Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         AV64Layoutcontratowwds_6_dynamicfiltersselector2 = "";
         AV66Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         AV68Layoutcontratowwds_10_dynamicfiltersselector3 = "";
         AV70Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         AV71Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel = "";
         AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels = new GxSimpleCollection<string>();
         AV75Layoutcontratowwds_17_tflayoutcontratotag = "";
         AV76Layoutcontratowwds_18_tflayoutcontratotag_sel = "";
         lV59Layoutcontratowwds_1_filterfulltext = "";
         lV62Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         lV66Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         lV70Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         lV71Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         lV75Layoutcontratowwds_17_tflayoutcontratotag = "";
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         A1000LayoutContratoTag = "";
         P005E2_A155LayoutContratoDescricao = new string[] {""} ;
         P005E2_n155LayoutContratoDescricao = new bool[] {false} ;
         P005E2_A1000LayoutContratoTag = new string[] {""} ;
         P005E2_n1000LayoutContratoTag = new bool[] {false} ;
         P005E2_A906LayoutContratoTipo = new string[] {""} ;
         P005E2_n906LayoutContratoTipo = new bool[] {false} ;
         P005E2_A156LayoutContratoStatus = new bool[] {false} ;
         P005E2_n156LayoutContratoStatus = new bool[] {false} ;
         P005E2_A154LayoutContratoId = new short[1] ;
         AV21Option = "";
         P005E3_A1000LayoutContratoTag = new string[] {""} ;
         P005E3_n1000LayoutContratoTag = new bool[] {false} ;
         P005E3_A906LayoutContratoTipo = new string[] {""} ;
         P005E3_n906LayoutContratoTipo = new bool[] {false} ;
         P005E3_A156LayoutContratoStatus = new bool[] {false} ;
         P005E3_n156LayoutContratoStatus = new bool[] {false} ;
         P005E3_A155LayoutContratoDescricao = new string[] {""} ;
         P005E3_n155LayoutContratoDescricao = new bool[] {false} ;
         P005E3_A154LayoutContratoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.layoutcontratowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005E2_A155LayoutContratoDescricao, P005E2_n155LayoutContratoDescricao, P005E2_A1000LayoutContratoTag, P005E2_n1000LayoutContratoTag, P005E2_A906LayoutContratoTipo, P005E2_n906LayoutContratoTipo, P005E2_A156LayoutContratoStatus, P005E2_n156LayoutContratoStatus, P005E2_A154LayoutContratoId
               }
               , new Object[] {
               P005E3_A1000LayoutContratoTag, P005E3_n1000LayoutContratoTag, P005E3_A906LayoutContratoTipo, P005E3_n906LayoutContratoTipo, P005E3_A156LayoutContratoStatus, P005E3_n156LayoutContratoStatus, P005E3_A155LayoutContratoDescricao, P005E3_n155LayoutContratoDescricao, P005E3_A154LayoutContratoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV13TFLayoutContratoStatus_Sel ;
      private short AV40DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV48DynamicFiltersOperator3 ;
      private short AV61Layoutcontratowwds_3_dynamicfiltersoperator1 ;
      private short AV65Layoutcontratowwds_7_dynamicfiltersoperator2 ;
      private short AV69Layoutcontratowwds_11_dynamicfiltersoperator3 ;
      private short AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel ;
      private short A154LayoutContratoId ;
      private int AV57GXV1 ;
      private int AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ;
      private long AV26count ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV46DynamicFiltersEnabled3 ;
      private bool AV63Layoutcontratowwds_5_dynamicfiltersenabled2 ;
      private bool AV67Layoutcontratowwds_9_dynamicfiltersenabled3 ;
      private bool A156LayoutContratoStatus ;
      private bool BRK5E2 ;
      private bool n155LayoutContratoDescricao ;
      private bool n1000LayoutContratoTag ;
      private bool n906LayoutContratoTipo ;
      private bool n156LayoutContratoStatus ;
      private bool BRK5E4 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV53TFLayoutContratoTipo_SelsJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV11TFLayoutContratoDescricao ;
      private string AV12TFLayoutContratoDescricao_Sel ;
      private string AV55TFLayoutContratoTag ;
      private string AV56TFLayoutContratoTag_Sel ;
      private string AV39DynamicFiltersSelector1 ;
      private string AV41LayoutContratoDescricao1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV45LayoutContratoDescricao2 ;
      private string AV47DynamicFiltersSelector3 ;
      private string AV49LayoutContratoDescricao3 ;
      private string AV59Layoutcontratowwds_1_filterfulltext ;
      private string AV60Layoutcontratowwds_2_dynamicfiltersselector1 ;
      private string AV62Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string AV64Layoutcontratowwds_6_dynamicfiltersselector2 ;
      private string AV66Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string AV68Layoutcontratowwds_10_dynamicfiltersselector3 ;
      private string AV70Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string AV71Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel ;
      private string AV75Layoutcontratowwds_17_tflayoutcontratotag ;
      private string AV76Layoutcontratowwds_18_tflayoutcontratotag_sel ;
      private string lV59Layoutcontratowwds_1_filterfulltext ;
      private string lV62Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string lV66Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string lV70Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string lV71Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string lV75Layoutcontratowwds_17_tflayoutcontratotag ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private string A1000LayoutContratoTag ;
      private string AV21Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GxSimpleCollection<string> AV54TFLayoutContratoTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P005E2_A155LayoutContratoDescricao ;
      private bool[] P005E2_n155LayoutContratoDescricao ;
      private string[] P005E2_A1000LayoutContratoTag ;
      private bool[] P005E2_n1000LayoutContratoTag ;
      private string[] P005E2_A906LayoutContratoTipo ;
      private bool[] P005E2_n906LayoutContratoTipo ;
      private bool[] P005E2_A156LayoutContratoStatus ;
      private bool[] P005E2_n156LayoutContratoStatus ;
      private short[] P005E2_A154LayoutContratoId ;
      private string[] P005E3_A1000LayoutContratoTag ;
      private bool[] P005E3_n1000LayoutContratoTag ;
      private string[] P005E3_A906LayoutContratoTipo ;
      private bool[] P005E3_n906LayoutContratoTipo ;
      private bool[] P005E3_A156LayoutContratoStatus ;
      private bool[] P005E3_n156LayoutContratoStatus ;
      private string[] P005E3_A155LayoutContratoDescricao ;
      private bool[] P005E3_n155LayoutContratoDescricao ;
      private short[] P005E3_A154LayoutContratoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class layoutcontratowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005E2( IGxContext context ,
                                             string A906LayoutContratoTipo ,
                                             GxSimpleCollection<string> AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                             string AV59Layoutcontratowwds_1_filterfulltext ,
                                             string AV60Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                             short AV61Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV62Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                             bool AV63Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                             string AV64Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                             short AV65Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                             string AV66Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                             bool AV67Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                             string AV68Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                             short AV69Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                             string AV70Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                             string AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                             string AV71Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                             short AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                             int AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ,
                                             string AV76Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                             string AV75Layoutcontratowwds_17_tflayoutcontratotag ,
                                             string A155LayoutContratoDescricao ,
                                             bool A156LayoutContratoStatus ,
                                             string A1000LayoutContratoTag )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LayoutContratoDescricao, LayoutContratoTag, LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId FROM LayoutContrato";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LayoutContratoDescricao like '%' || :lV59Layoutcontratowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = TRUE) or ( 'não' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = FALSE) or ( 'contrato' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'C')) or ( 'mensagem' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'M')) or ( 'acoplado' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'A')) or ( LayoutContratoTag like '%' || :lV59Layoutcontratowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV61Layoutcontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV62Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV61Layoutcontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV62Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV63Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV65Layoutcontratowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV66Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV63Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV65Layoutcontratowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV66Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV67Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV69Layoutcontratowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV70Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV67Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV69Layoutcontratowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV70Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Layoutcontratowwds_13_tflayoutcontratodescricao)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV71Layoutcontratowwds_13_tflayoutcontratodescricao)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ! ( StringUtil.StrCmp(AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao = ( :AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao IS NULL or (char_length(trim(trailing ' ' from LayoutContratoDescricao))=0))");
         }
         if ( AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = TRUE)");
         }
         if ( AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = FALSE)");
         }
         if ( AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels, "LayoutContratoTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Layoutcontratowwds_17_tflayoutcontratotag)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag like :lV75Layoutcontratowwds_17_tflayoutcontratotag)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ! ( StringUtil.StrCmp(AV76Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag = ( :AV76Layoutcontratowwds_18_tflayoutcontratotag_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV76Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoTag IS NULL or (char_length(trim(trailing ' ' from LayoutContratoTag))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LayoutContratoDescricao";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005E3( IGxContext context ,
                                             string A906LayoutContratoTipo ,
                                             GxSimpleCollection<string> AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                             string AV59Layoutcontratowwds_1_filterfulltext ,
                                             string AV60Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                             short AV61Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV62Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                             bool AV63Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                             string AV64Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                             short AV65Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                             string AV66Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                             bool AV67Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                             string AV68Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                             short AV69Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                             string AV70Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                             string AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                             string AV71Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                             short AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                             int AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ,
                                             string AV76Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                             string AV75Layoutcontratowwds_17_tflayoutcontratotag ,
                                             string A155LayoutContratoDescricao ,
                                             bool A156LayoutContratoStatus ,
                                             string A1000LayoutContratoTag )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT LayoutContratoTag, LayoutContratoTipo, LayoutContratoStatus, LayoutContratoDescricao, LayoutContratoId FROM LayoutContrato";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Layoutcontratowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LayoutContratoDescricao like '%' || :lV59Layoutcontratowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = TRUE) or ( 'não' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = FALSE) or ( 'contrato' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'C')) or ( 'mensagem' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'M')) or ( 'acoplado' like '%' || LOWER(:lV59Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'A')) or ( LayoutContratoTag like '%' || :lV59Layoutcontratowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV61Layoutcontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV62Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV61Layoutcontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV62Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV63Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV65Layoutcontratowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV66Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV65Layoutcontratowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV66Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV69Layoutcontratowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV70Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV69Layoutcontratowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV70Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Layoutcontratowwds_13_tflayoutcontratodescricao)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV71Layoutcontratowwds_13_tflayoutcontratodescricao)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ! ( StringUtil.StrCmp(AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao = ( :AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao IS NULL or (char_length(trim(trailing ' ' from LayoutContratoDescricao))=0))");
         }
         if ( AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = TRUE)");
         }
         if ( AV73Layoutcontratowwds_15_tflayoutcontratostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = FALSE)");
         }
         if ( AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV74Layoutcontratowwds_16_tflayoutcontratotipo_sels, "LayoutContratoTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Layoutcontratowwds_17_tflayoutcontratotag)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag like :lV75Layoutcontratowwds_17_tflayoutcontratotag)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ! ( StringUtil.StrCmp(AV76Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag = ( :AV76Layoutcontratowwds_18_tflayoutcontratotag_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV76Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoTag IS NULL or (char_length(trim(trailing ' ' from LayoutContratoTag))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LayoutContratoTag";
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
                     return conditional_P005E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P005E3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP005E2;
          prmP005E2 = new Object[] {
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV62Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV66Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV66Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV70Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV70Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV71Layoutcontratowwds_13_tflayoutcontratodescricao",GXType.VarChar,60,0) ,
          new ParDef("AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel",GXType.VarChar,60,0) ,
          new ParDef("lV75Layoutcontratowwds_17_tflayoutcontratotag",GXType.VarChar,40,0) ,
          new ParDef("AV76Layoutcontratowwds_18_tflayoutcontratotag_sel",GXType.VarChar,40,0)
          };
          Object[] prmP005E3;
          prmP005E3 = new Object[] {
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV62Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV66Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV66Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV70Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV70Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV71Layoutcontratowwds_13_tflayoutcontratodescricao",GXType.VarChar,60,0) ,
          new ParDef("AV72Layoutcontratowwds_14_tflayoutcontratodescricao_sel",GXType.VarChar,60,0) ,
          new ParDef("lV75Layoutcontratowwds_17_tflayoutcontratotag",GXType.VarChar,40,0) ,
          new ParDef("AV76Layoutcontratowwds_18_tflayoutcontratotag_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
