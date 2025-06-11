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
   public class propostanotawwgetfilterdata : GXProcedure
   {
      public propostanotawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostanotawwgetfilterdata( IGxContext context )
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
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV45OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27MaxItems = 10;
         AV26PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV41SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? "" : StringUtil.Substring( AV41SearchTxtParms, 3, -1));
         AV25SkipItems = (short)(AV26PageIndex*AV27MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_PROPOSTAPROTOCOLO") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAPROTOCOLOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_PROPOSTAEMPRESARAZAO") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAEMPRESARAZAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV43OptionsJson = AV30Options.ToJSonString(false);
         AV44OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV45OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("PropostaNotaWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaNotaWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("PropostaNotaWWGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO") == 0 )
            {
               AV10TFPropostaProtocolo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO_SEL") == 0 )
            {
               AV11TFPropostaProtocolo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO") == 0 )
            {
               AV12TFPropostaEmpresaRazao = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO_SEL") == 0 )
            {
               AV13TFPropostaEmpresaRazao_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV14TFPropostaQtdItensNota_F = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV15TFPropostaQtdItensNota_F_To = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTATIPOPROPOSTA_SEL") == 0 )
            {
               AV16TFPropostaTipoProposta_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV17TFPropostaTipoProposta_Sels.FromJSonString(AV16TFPropostaTipoProposta_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTASUMITENSNOTA_F") == 0 )
            {
               AV18TFPropostaSumItensnota_F = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV19TFPropostaSumItensnota_F_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTACREATEDAT") == 0 )
            {
               AV20TFPropostaCreatedAt = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, 4);
               AV21TFPropostaCreatedAt_To = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV22TFPropostaStatus_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV23TFPropostaStatus_Sels.FromJSonString(AV22TFPropostaStatus_SelsJson, null);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV47DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV47DynamicFiltersSelector1, "PROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV48DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV49PropostaQtdItensNota_F1 = (short)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV50DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "PROPOSTAQTDITENSNOTA_F") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV53PropostaQtdItensNota_F2 = (short)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV54DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV55DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PROPOSTAQTDITENSNOTA_F") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV57PropostaQtdItensNota_F3 = (short)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROPOSTAPROTOCOLOOPTIONS' Routine */
         returnInSub = false;
         AV10TFPropostaProtocolo = AV24SearchTxt;
         AV11TFPropostaProtocolo_Sel = "";
         AV60Propostanotawwds_1_filterfulltext = AV46FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV49PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV53PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV57PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV10TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV11TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV12TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV13TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV14TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV15TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV17TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV18TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV19TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV20TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV21TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A849PropostaTipoProposta ,
                                              AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                              A329PropostaStatus ,
                                              AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                              AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                              AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                              AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                              AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                              AV78Propostanotawwds_19_tfpropostatipoproposta_sels.Count ,
                                              AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                              AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                              AV81Propostanotawwds_22_tfpropostacreatedat ,
                                              AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                              AV83Propostanotawwds_24_tfpropostastatus_sels.Count ,
                                              A853PropostaProtocolo ,
                                              A888PropostaEmpresaRazao ,
                                              A887PropostaSumItensnota_F ,
                                              A327PropostaCreatedAt ,
                                              AV60Propostanotawwds_1_filterfulltext ,
                                              A854PropostaQtdItensNota_F ,
                                              AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                              AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                              AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                              AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                              AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                              AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                              AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                              AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                              AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                              AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                              AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                              AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                              AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV72Propostanotawwds_13_tfpropostaprotocolo = StringUtil.Concat( StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo), "%", "");
         lV74Propostanotawwds_15_tfpropostaempresarazao = StringUtil.Concat( StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao), "%", "");
         /* Using cursor P00E53 */
         pr_default.execute(0, new Object[] {AV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, lV72Propostanotawwds_13_tfpropostaprotocolo, AV73Propostanotawwds_14_tfpropostaprotocolo_sel, lV74Propostanotawwds_15_tfpropostaempresarazao, AV75Propostanotawwds_16_tfpropostaempresarazao_sel, AV79Propostanotawwds_20_tfpropostasumitensnota_f, AV80Propostanotawwds_21_tfpropostasumitensnota_f_to, AV81Propostanotawwds_22_tfpropostacreatedat, AV82Propostanotawwds_23_tfpropostacreatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKE52 = false;
            A850PropostaEmpresaClienteId = P00E53_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = P00E53_n850PropostaEmpresaClienteId[0];
            A323PropostaId = P00E53_A323PropostaId[0];
            n323PropostaId = P00E53_n323PropostaId[0];
            A853PropostaProtocolo = P00E53_A853PropostaProtocolo[0];
            n853PropostaProtocolo = P00E53_n853PropostaProtocolo[0];
            A327PropostaCreatedAt = P00E53_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = P00E53_n327PropostaCreatedAt[0];
            A329PropostaStatus = P00E53_A329PropostaStatus[0];
            n329PropostaStatus = P00E53_n329PropostaStatus[0];
            A849PropostaTipoProposta = P00E53_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = P00E53_n849PropostaTipoProposta[0];
            A888PropostaEmpresaRazao = P00E53_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E53_n888PropostaEmpresaRazao[0];
            A887PropostaSumItensnota_F = P00E53_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E53_A854PropostaQtdItensNota_F[0];
            A888PropostaEmpresaRazao = P00E53_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E53_n888PropostaEmpresaRazao[0];
            A887PropostaSumItensnota_F = P00E53_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E53_A854PropostaQtdItensNota_F[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00E53_A853PropostaProtocolo[0], A853PropostaProtocolo) == 0 ) )
            {
               BRKE52 = false;
               A323PropostaId = P00E53_A323PropostaId[0];
               n323PropostaId = P00E53_n323PropostaId[0];
               AV34count = (long)(AV34count+1);
               BRKE52 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? "<#Empty#>" : A853PropostaProtocolo);
               AV30Options.Add(AV29Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV25SkipItems = (short)(AV25SkipItems-1);
            }
            if ( ! BRKE52 )
            {
               BRKE52 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROPOSTAEMPRESARAZAOOPTIONS' Routine */
         returnInSub = false;
         AV12TFPropostaEmpresaRazao = AV24SearchTxt;
         AV13TFPropostaEmpresaRazao_Sel = "";
         AV60Propostanotawwds_1_filterfulltext = AV46FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV49PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV53PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV57PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV10TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV11TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV12TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV13TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV14TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV15TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV17TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV18TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV19TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV20TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV21TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A849PropostaTipoProposta ,
                                              AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                              A329PropostaStatus ,
                                              AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                              AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                              AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                              AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                              AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                              AV78Propostanotawwds_19_tfpropostatipoproposta_sels.Count ,
                                              AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                              AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                              AV81Propostanotawwds_22_tfpropostacreatedat ,
                                              AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                              AV83Propostanotawwds_24_tfpropostastatus_sels.Count ,
                                              A853PropostaProtocolo ,
                                              A888PropostaEmpresaRazao ,
                                              A887PropostaSumItensnota_F ,
                                              A327PropostaCreatedAt ,
                                              AV60Propostanotawwds_1_filterfulltext ,
                                              A854PropostaQtdItensNota_F ,
                                              AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                              AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                              AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                              AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                              AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                              AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                              AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                              AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                              AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                              AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                              AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                              AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                              AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV72Propostanotawwds_13_tfpropostaprotocolo = StringUtil.Concat( StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo), "%", "");
         lV74Propostanotawwds_15_tfpropostaempresarazao = StringUtil.Concat( StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao), "%", "");
         /* Using cursor P00E55 */
         pr_default.execute(1, new Object[] {AV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, lV72Propostanotawwds_13_tfpropostaprotocolo, AV73Propostanotawwds_14_tfpropostaprotocolo_sel, lV74Propostanotawwds_15_tfpropostaempresarazao, AV75Propostanotawwds_16_tfpropostaempresarazao_sel, AV79Propostanotawwds_20_tfpropostasumitensnota_f, AV80Propostanotawwds_21_tfpropostasumitensnota_f_to, AV81Propostanotawwds_22_tfpropostacreatedat, AV82Propostanotawwds_23_tfpropostacreatedat_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKE54 = false;
            A850PropostaEmpresaClienteId = P00E55_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = P00E55_n850PropostaEmpresaClienteId[0];
            A323PropostaId = P00E55_A323PropostaId[0];
            n323PropostaId = P00E55_n323PropostaId[0];
            A888PropostaEmpresaRazao = P00E55_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E55_n888PropostaEmpresaRazao[0];
            A327PropostaCreatedAt = P00E55_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = P00E55_n327PropostaCreatedAt[0];
            A329PropostaStatus = P00E55_A329PropostaStatus[0];
            n329PropostaStatus = P00E55_n329PropostaStatus[0];
            A849PropostaTipoProposta = P00E55_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = P00E55_n849PropostaTipoProposta[0];
            A853PropostaProtocolo = P00E55_A853PropostaProtocolo[0];
            n853PropostaProtocolo = P00E55_n853PropostaProtocolo[0];
            A887PropostaSumItensnota_F = P00E55_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E55_A854PropostaQtdItensNota_F[0];
            A888PropostaEmpresaRazao = P00E55_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E55_n888PropostaEmpresaRazao[0];
            A887PropostaSumItensnota_F = P00E55_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E55_A854PropostaQtdItensNota_F[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00E55_A888PropostaEmpresaRazao[0], A888PropostaEmpresaRazao) == 0 ) )
            {
               BRKE54 = false;
               A850PropostaEmpresaClienteId = P00E55_A850PropostaEmpresaClienteId[0];
               n850PropostaEmpresaClienteId = P00E55_n850PropostaEmpresaClienteId[0];
               A323PropostaId = P00E55_A323PropostaId[0];
               n323PropostaId = P00E55_n323PropostaId[0];
               AV34count = (long)(AV34count+1);
               BRKE54 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A888PropostaEmpresaRazao)) ? "<#Empty#>" : A888PropostaEmpresaRazao);
               AV30Options.Add(AV29Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV25SkipItems = (short)(AV25SkipItems-1);
            }
            if ( ! BRKE54 )
            {
               BRKE54 = true;
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
         AV43OptionsJson = "";
         AV44OptionsDescJson = "";
         AV45OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV10TFPropostaProtocolo = "";
         AV11TFPropostaProtocolo_Sel = "";
         AV12TFPropostaEmpresaRazao = "";
         AV13TFPropostaEmpresaRazao_Sel = "";
         AV16TFPropostaTipoProposta_SelsJson = "";
         AV17TFPropostaTipoProposta_Sels = new GxSimpleCollection<string>();
         AV20TFPropostaCreatedAt = (DateTime)(DateTime.MinValue);
         AV21TFPropostaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV22TFPropostaStatus_SelsJson = "";
         AV23TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV47DynamicFiltersSelector1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV55DynamicFiltersSelector3 = "";
         AV60Propostanotawwds_1_filterfulltext = "";
         AV61Propostanotawwds_2_dynamicfiltersselector1 = "";
         AV65Propostanotawwds_6_dynamicfiltersselector2 = "";
         AV69Propostanotawwds_10_dynamicfiltersselector3 = "";
         AV72Propostanotawwds_13_tfpropostaprotocolo = "";
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = "";
         AV74Propostanotawwds_15_tfpropostaempresarazao = "";
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = "";
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = new GxSimpleCollection<string>();
         AV81Propostanotawwds_22_tfpropostacreatedat = (DateTime)(DateTime.MinValue);
         AV82Propostanotawwds_23_tfpropostacreatedat_to = (DateTime)(DateTime.MinValue);
         AV83Propostanotawwds_24_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV60Propostanotawwds_1_filterfulltext = "";
         lV72Propostanotawwds_13_tfpropostaprotocolo = "";
         lV74Propostanotawwds_15_tfpropostaempresarazao = "";
         A849PropostaTipoProposta = "";
         A329PropostaStatus = "";
         A853PropostaProtocolo = "";
         A888PropostaEmpresaRazao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         P00E53_A850PropostaEmpresaClienteId = new int[1] ;
         P00E53_n850PropostaEmpresaClienteId = new bool[] {false} ;
         P00E53_A323PropostaId = new int[1] ;
         P00E53_n323PropostaId = new bool[] {false} ;
         P00E53_A853PropostaProtocolo = new string[] {""} ;
         P00E53_n853PropostaProtocolo = new bool[] {false} ;
         P00E53_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E53_n327PropostaCreatedAt = new bool[] {false} ;
         P00E53_A329PropostaStatus = new string[] {""} ;
         P00E53_n329PropostaStatus = new bool[] {false} ;
         P00E53_A849PropostaTipoProposta = new string[] {""} ;
         P00E53_n849PropostaTipoProposta = new bool[] {false} ;
         P00E53_A888PropostaEmpresaRazao = new string[] {""} ;
         P00E53_n888PropostaEmpresaRazao = new bool[] {false} ;
         P00E53_A887PropostaSumItensnota_F = new decimal[1] ;
         P00E53_A854PropostaQtdItensNota_F = new short[1] ;
         AV29Option = "";
         P00E55_A850PropostaEmpresaClienteId = new int[1] ;
         P00E55_n850PropostaEmpresaClienteId = new bool[] {false} ;
         P00E55_A323PropostaId = new int[1] ;
         P00E55_n323PropostaId = new bool[] {false} ;
         P00E55_A888PropostaEmpresaRazao = new string[] {""} ;
         P00E55_n888PropostaEmpresaRazao = new bool[] {false} ;
         P00E55_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E55_n327PropostaCreatedAt = new bool[] {false} ;
         P00E55_A329PropostaStatus = new string[] {""} ;
         P00E55_n329PropostaStatus = new bool[] {false} ;
         P00E55_A849PropostaTipoProposta = new string[] {""} ;
         P00E55_n849PropostaTipoProposta = new bool[] {false} ;
         P00E55_A853PropostaProtocolo = new string[] {""} ;
         P00E55_n853PropostaProtocolo = new bool[] {false} ;
         P00E55_A887PropostaSumItensnota_F = new decimal[1] ;
         P00E55_A854PropostaQtdItensNota_F = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostanotawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00E53_A850PropostaEmpresaClienteId, P00E53_n850PropostaEmpresaClienteId, P00E53_A323PropostaId, P00E53_A853PropostaProtocolo, P00E53_n853PropostaProtocolo, P00E53_A327PropostaCreatedAt, P00E53_n327PropostaCreatedAt, P00E53_A329PropostaStatus, P00E53_n329PropostaStatus, P00E53_A849PropostaTipoProposta,
               P00E53_n849PropostaTipoProposta, P00E53_A888PropostaEmpresaRazao, P00E53_n888PropostaEmpresaRazao, P00E53_A887PropostaSumItensnota_F, P00E53_A854PropostaQtdItensNota_F
               }
               , new Object[] {
               P00E55_A850PropostaEmpresaClienteId, P00E55_n850PropostaEmpresaClienteId, P00E55_A323PropostaId, P00E55_A888PropostaEmpresaRazao, P00E55_n888PropostaEmpresaRazao, P00E55_A327PropostaCreatedAt, P00E55_n327PropostaCreatedAt, P00E55_A329PropostaStatus, P00E55_n329PropostaStatus, P00E55_A849PropostaTipoProposta,
               P00E55_n849PropostaTipoProposta, P00E55_A853PropostaProtocolo, P00E55_n853PropostaProtocolo, P00E55_A887PropostaSumItensnota_F, P00E55_A854PropostaQtdItensNota_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private short AV14TFPropostaQtdItensNota_F ;
      private short AV15TFPropostaQtdItensNota_F_To ;
      private short AV48DynamicFiltersOperator1 ;
      private short AV49PropostaQtdItensNota_F1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV53PropostaQtdItensNota_F2 ;
      private short AV56DynamicFiltersOperator3 ;
      private short AV57PropostaQtdItensNota_F3 ;
      private short AV62Propostanotawwds_3_dynamicfiltersoperator1 ;
      private short AV63Propostanotawwds_4_propostaqtditensnota_f1 ;
      private short AV66Propostanotawwds_7_dynamicfiltersoperator2 ;
      private short AV67Propostanotawwds_8_propostaqtditensnota_f2 ;
      private short AV70Propostanotawwds_11_dynamicfiltersoperator3 ;
      private short AV71Propostanotawwds_12_propostaqtditensnota_f3 ;
      private short AV76Propostanotawwds_17_tfpropostaqtditensnota_f ;
      private short AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to ;
      private short A854PropostaQtdItensNota_F ;
      private int AV58GXV1 ;
      private int AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count ;
      private int AV83Propostanotawwds_24_tfpropostastatus_sels_Count ;
      private int A850PropostaEmpresaClienteId ;
      private int A323PropostaId ;
      private long AV34count ;
      private decimal AV18TFPropostaSumItensnota_F ;
      private decimal AV19TFPropostaSumItensnota_F_To ;
      private decimal AV79Propostanotawwds_20_tfpropostasumitensnota_f ;
      private decimal AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ;
      private decimal A887PropostaSumItensnota_F ;
      private DateTime AV20TFPropostaCreatedAt ;
      private DateTime AV21TFPropostaCreatedAt_To ;
      private DateTime AV81Propostanotawwds_22_tfpropostacreatedat ;
      private DateTime AV82Propostanotawwds_23_tfpropostacreatedat_to ;
      private DateTime A327PropostaCreatedAt ;
      private bool returnInSub ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV54DynamicFiltersEnabled3 ;
      private bool AV64Propostanotawwds_5_dynamicfiltersenabled2 ;
      private bool AV68Propostanotawwds_9_dynamicfiltersenabled3 ;
      private bool BRKE52 ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n323PropostaId ;
      private bool n853PropostaProtocolo ;
      private bool n327PropostaCreatedAt ;
      private bool n329PropostaStatus ;
      private bool n849PropostaTipoProposta ;
      private bool n888PropostaEmpresaRazao ;
      private bool BRKE54 ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV16TFPropostaTipoProposta_SelsJson ;
      private string AV22TFPropostaStatus_SelsJson ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV46FilterFullText ;
      private string AV10TFPropostaProtocolo ;
      private string AV11TFPropostaProtocolo_Sel ;
      private string AV12TFPropostaEmpresaRazao ;
      private string AV13TFPropostaEmpresaRazao_Sel ;
      private string AV47DynamicFiltersSelector1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV55DynamicFiltersSelector3 ;
      private string AV60Propostanotawwds_1_filterfulltext ;
      private string AV61Propostanotawwds_2_dynamicfiltersselector1 ;
      private string AV65Propostanotawwds_6_dynamicfiltersselector2 ;
      private string AV69Propostanotawwds_10_dynamicfiltersselector3 ;
      private string AV72Propostanotawwds_13_tfpropostaprotocolo ;
      private string AV73Propostanotawwds_14_tfpropostaprotocolo_sel ;
      private string AV74Propostanotawwds_15_tfpropostaempresarazao ;
      private string AV75Propostanotawwds_16_tfpropostaempresarazao_sel ;
      private string lV60Propostanotawwds_1_filterfulltext ;
      private string lV72Propostanotawwds_13_tfpropostaprotocolo ;
      private string lV74Propostanotawwds_15_tfpropostaempresarazao ;
      private string A849PropostaTipoProposta ;
      private string A329PropostaStatus ;
      private string A853PropostaProtocolo ;
      private string A888PropostaEmpresaRazao ;
      private string AV29Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GxSimpleCollection<string> AV17TFPropostaTipoProposta_Sels ;
      private GxSimpleCollection<string> AV23TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV78Propostanotawwds_19_tfpropostatipoproposta_sels ;
      private GxSimpleCollection<string> AV83Propostanotawwds_24_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00E53_A850PropostaEmpresaClienteId ;
      private bool[] P00E53_n850PropostaEmpresaClienteId ;
      private int[] P00E53_A323PropostaId ;
      private bool[] P00E53_n323PropostaId ;
      private string[] P00E53_A853PropostaProtocolo ;
      private bool[] P00E53_n853PropostaProtocolo ;
      private DateTime[] P00E53_A327PropostaCreatedAt ;
      private bool[] P00E53_n327PropostaCreatedAt ;
      private string[] P00E53_A329PropostaStatus ;
      private bool[] P00E53_n329PropostaStatus ;
      private string[] P00E53_A849PropostaTipoProposta ;
      private bool[] P00E53_n849PropostaTipoProposta ;
      private string[] P00E53_A888PropostaEmpresaRazao ;
      private bool[] P00E53_n888PropostaEmpresaRazao ;
      private decimal[] P00E53_A887PropostaSumItensnota_F ;
      private short[] P00E53_A854PropostaQtdItensNota_F ;
      private int[] P00E55_A850PropostaEmpresaClienteId ;
      private bool[] P00E55_n850PropostaEmpresaClienteId ;
      private int[] P00E55_A323PropostaId ;
      private bool[] P00E55_n323PropostaId ;
      private string[] P00E55_A888PropostaEmpresaRazao ;
      private bool[] P00E55_n888PropostaEmpresaRazao ;
      private DateTime[] P00E55_A327PropostaCreatedAt ;
      private bool[] P00E55_n327PropostaCreatedAt ;
      private string[] P00E55_A329PropostaStatus ;
      private bool[] P00E55_n329PropostaStatus ;
      private string[] P00E55_A849PropostaTipoProposta ;
      private bool[] P00E55_n849PropostaTipoProposta ;
      private string[] P00E55_A853PropostaProtocolo ;
      private bool[] P00E55_n853PropostaProtocolo ;
      private decimal[] P00E55_A887PropostaSumItensnota_F ;
      private short[] P00E55_A854PropostaQtdItensNota_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class propostanotawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E53( IGxContext context ,
                                             string A849PropostaTipoProposta ,
                                             GxSimpleCollection<string> AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                             string AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                             string AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                             string AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                             string AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                             int AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count ,
                                             decimal AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                             decimal AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                             DateTime AV81Propostanotawwds_22_tfpropostacreatedat ,
                                             DateTime AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                             int AV83Propostanotawwds_24_tfpropostastatus_sels_Count ,
                                             string A853PropostaProtocolo ,
                                             string A888PropostaEmpresaRazao ,
                                             decimal A887PropostaSumItensnota_F ,
                                             DateTime A327PropostaCreatedAt ,
                                             string AV60Propostanotawwds_1_filterfulltext ,
                                             short A854PropostaQtdItensNota_F ,
                                             string AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                             short AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                             short AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                             bool AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                             short AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                             short AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                             bool AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                             string AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                             short AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                             short AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                             short AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                             short AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[69];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T1.PropostaId, T1.PropostaProtocolo, T1.PropostaCreatedAt, T1.PropostaStatus, T1.PropostaTipoProposta, T2.ClienteRazaoSocial AS PropostaEmpresaRazao, COALESCE( T3.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM ((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaEmpresaClienteId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId, COUNT(*) AS PropostaQtdItensNota_F FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV60Propostanotawwds_1_filterfulltext))=0) or ( ( T1.PropostaProtocolo like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaQtdItensNota_F, 0),'9999'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'clinica' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'CLINICA')) or ( 'compra de título' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'COMPRA_TITULO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaSumItensnota_F, 0),'999999999999990.99'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada'))))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 0 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 1 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 2 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 0 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 1 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 2 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "((:AV76Propostanotawwds_17_tfpropostaqtditensnota_f = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) >= :AV76Propostanotawwds_17_tfpropostaqtditensnota_f))");
         AddWhere(sWhereString, "((:AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) <= :AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to))");
         AddWhere(sWhereString, "(COALESCE( T3.PropostaQtdItensNota_F, 0) > 0)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo like :lV72Propostanotawwds_13_tfpropostaprotocolo)");
         }
         else
         {
            GXv_int1[61] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ! ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo = ( :AV73Propostanotawwds_14_tfpropostaprotocolo_sel))");
         }
         else
         {
            GXv_int1[62] = 1;
         }
         if ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.PropostaProtocolo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV74Propostanotawwds_15_tfpropostaempresarazao)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ! ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV75Propostanotawwds_16_tfpropostaempresarazao_sel))");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Propostanotawwds_19_tfpropostatipoproposta_sels, "T1.PropostaTipoProposta IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Propostanotawwds_20_tfpropostasumitensnota_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) >= :AV79Propostanotawwds_20_tfpropostasumitensnota_f)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Propostanotawwds_21_tfpropostasumitensnota_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) <= :AV80Propostanotawwds_21_tfpropostasumitensnota_f_to)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Propostanotawwds_22_tfpropostacreatedat) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt >= :AV81Propostanotawwds_22_tfpropostacreatedat)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Propostanotawwds_23_tfpropostacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt <= :AV82Propostanotawwds_23_tfpropostacreatedat_to)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( AV83Propostanotawwds_24_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV83Propostanotawwds_24_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaProtocolo";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E55( IGxContext context ,
                                             string A849PropostaTipoProposta ,
                                             GxSimpleCollection<string> AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                             string AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                             string AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                             string AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                             string AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                             int AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count ,
                                             decimal AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                             decimal AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                             DateTime AV81Propostanotawwds_22_tfpropostacreatedat ,
                                             DateTime AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                             int AV83Propostanotawwds_24_tfpropostastatus_sels_Count ,
                                             string A853PropostaProtocolo ,
                                             string A888PropostaEmpresaRazao ,
                                             decimal A887PropostaSumItensnota_F ,
                                             DateTime A327PropostaCreatedAt ,
                                             string AV60Propostanotawwds_1_filterfulltext ,
                                             short A854PropostaQtdItensNota_F ,
                                             string AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                             short AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                             short AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                             bool AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                             short AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                             short AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                             bool AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                             string AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                             short AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                             short AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                             short AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                             short AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[69];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T1.PropostaId, T2.ClienteRazaoSocial AS PropostaEmpresaRazao, T1.PropostaCreatedAt, T1.PropostaStatus, T1.PropostaTipoProposta, T1.PropostaProtocolo, COALESCE( T3.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM ((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaEmpresaClienteId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId, COUNT(*) AS PropostaQtdItensNota_F FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV60Propostanotawwds_1_filterfulltext))=0) or ( ( T1.PropostaProtocolo like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaQtdItensNota_F, 0),'9999'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'clinica' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'CLINICA')) or ( 'compra de título' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'COMPRA_TITULO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaSumItensnota_F, 0),'999999999999990.99'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada'))))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 0 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 1 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 2 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 0 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 1 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 2 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "((:AV76Propostanotawwds_17_tfpropostaqtditensnota_f = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) >= :AV76Propostanotawwds_17_tfpropostaqtditensnota_f))");
         AddWhere(sWhereString, "((:AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) <= :AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to))");
         AddWhere(sWhereString, "(COALESCE( T3.PropostaQtdItensNota_F, 0) > 0)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo like :lV72Propostanotawwds_13_tfpropostaprotocolo)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ! ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo = ( :AV73Propostanotawwds_14_tfpropostaprotocolo_sel))");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.PropostaProtocolo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV74Propostanotawwds_15_tfpropostaempresarazao)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ! ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV75Propostanotawwds_16_tfpropostaempresarazao_sel))");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Propostanotawwds_19_tfpropostatipoproposta_sels, "T1.PropostaTipoProposta IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Propostanotawwds_20_tfpropostasumitensnota_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) >= :AV79Propostanotawwds_20_tfpropostasumitensnota_f)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Propostanotawwds_21_tfpropostasumitensnota_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) <= :AV80Propostanotawwds_21_tfpropostasumitensnota_f_to)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Propostanotawwds_22_tfpropostacreatedat) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt >= :AV81Propostanotawwds_22_tfpropostacreatedat)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Propostanotawwds_23_tfpropostacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt <= :AV82Propostanotawwds_23_tfpropostacreatedat_to)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV83Propostanotawwds_24_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV83Propostanotawwds_24_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ClienteRazaoSocial";
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
                     return conditional_P00E53(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] );
               case 1 :
                     return conditional_P00E55(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] );
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
          Object[] prmP00E53;
          prmP00E53 = new Object[] {
          new ParDef("AV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("lV72Propostanotawwds_13_tfpropostaprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV73Propostanotawwds_14_tfpropostaprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("lV74Propostanotawwds_15_tfpropostaempresarazao",GXType.VarChar,150,0) ,
          new ParDef("AV75Propostanotawwds_16_tfpropostaempresarazao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV79Propostanotawwds_20_tfpropostasumitensnota_f",GXType.Number,18,2) ,
          new ParDef("AV80Propostanotawwds_21_tfpropostasumitensnota_f_to",GXType.Number,18,2) ,
          new ParDef("AV81Propostanotawwds_22_tfpropostacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Propostanotawwds_23_tfpropostacreatedat_to",GXType.DateTime,8,5)
          };
          Object[] prmP00E55;
          prmP00E55 = new Object[] {
          new ParDef("AV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("lV72Propostanotawwds_13_tfpropostaprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV73Propostanotawwds_14_tfpropostaprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("lV74Propostanotawwds_15_tfpropostaempresarazao",GXType.VarChar,150,0) ,
          new ParDef("AV75Propostanotawwds_16_tfpropostaempresarazao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV79Propostanotawwds_20_tfpropostasumitensnota_f",GXType.Number,18,2) ,
          new ParDef("AV80Propostanotawwds_21_tfpropostasumitensnota_f_to",GXType.Number,18,2) ,
          new ParDef("AV81Propostanotawwds_22_tfpropostacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Propostanotawwds_23_tfpropostacreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00E53", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E53,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E55", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E55,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((short[]) buf[14])[0] = rslt.getShort(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((short[]) buf[14])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
