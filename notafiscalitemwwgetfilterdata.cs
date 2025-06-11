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
   public class notafiscalitemwwgetfilterdata : GXProcedure
   {
      public notafiscalitemwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalitemwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_PROPOSTADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTADESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_NOTAFISCALITEMCODIGO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALITEMCODIGOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_NOTAFISCALITEMDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALITEMDESCRICAOOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV35Session.Get("NotaFiscalItemWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "NotaFiscalItemWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("NotaFiscalItemWWGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV10TFPropostaDescricao = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV11TFPropostaDescricao_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO") == 0 )
            {
               AV12TFNotaFiscalItemCodigo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO_SEL") == 0 )
            {
               AV13TFNotaFiscalItemCodigo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO") == 0 )
            {
               AV14TFNotaFiscalItemDescricao = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO_SEL") == 0 )
            {
               AV15TFNotaFiscalItemDescricao_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMQUANTIDADE") == 0 )
            {
               AV16TFNotaFiscalItemQuantidade = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV17TFNotaFiscalItemQuantidade_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORUNITARIO") == 0 )
            {
               AV18TFNotaFiscalItemValorUnitario = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV19TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORTOTAL") == 0 )
            {
               AV20TFNotaFiscalItemValorTotal = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV21TFNotaFiscalItemValorTotal_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVENDIDO_SEL") == 0 )
            {
               AV22TFNotaFiscalItemVendido_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV23TFNotaFiscalItemVendido_Sels.FromJSonString(AV22TFNotaFiscalItemVendido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&NOTAFISCALID") == 0 )
            {
               AV58NotaFiscalId = StringUtil.StrToGuid( AV38GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&NOTAFISCALSTATUS") == 0 )
            {
               AV59NotaFiscalStatus = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV47DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV47DynamicFiltersSelector1, "NOTAFISCALITEMCODIGO") == 0 )
            {
               AV48DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV49NotaFiscalItemCodigo1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV50DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "NOTAFISCALITEMCODIGO") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV53NotaFiscalItemCodigo2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV54DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV55DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "NOTAFISCALITEMCODIGO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV57NotaFiscalItemCodigo3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROPOSTADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV10TFPropostaDescricao = AV24SearchTxt;
         AV11TFPropostaDescricao_Sel = "";
         AV62Notafiscalitemwwds_1_notafiscalid = AV58NotaFiscalId;
         AV63Notafiscalitemwwds_2_filterfulltext = AV46FilterFullText;
         AV64Notafiscalitemwwds_3_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV49NotaFiscalItemCodigo1;
         AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV68Notafiscalitemwwds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV53NotaFiscalItemCodigo2;
         AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV72Notafiscalitemwwds_11_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV57NotaFiscalItemCodigo3;
         AV75Notafiscalitemwwds_14_tfpropostadescricao = AV10TFPropostaDescricao;
         AV76Notafiscalitemwwds_15_tfpropostadescricao_sel = AV11TFPropostaDescricao_Sel;
         AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV12TFNotaFiscalItemCodigo;
         AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV13TFNotaFiscalItemCodigo_Sel;
         AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV14TFNotaFiscalItemDescricao;
         AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV15TFNotaFiscalItemDescricao_Sel;
         AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV16TFNotaFiscalItemQuantidade;
         AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV17TFNotaFiscalItemQuantidade_To;
         AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV18TFNotaFiscalItemValorUnitario;
         AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV19TFNotaFiscalItemValorUnitario_To;
         AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV20TFNotaFiscalItemValorTotal;
         AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV21TFNotaFiscalItemValorTotal_To;
         AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV23TFNotaFiscalItemVendido_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A851NotaFiscalItemVendido ,
                                              AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                              AV63Notafiscalitemwwds_2_filterfulltext ,
                                              AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                              AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                              AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                              AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                              AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                              AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                              AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                              AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                              AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                              AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                              AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                              AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                              AV75Notafiscalitemwwds_14_tfpropostadescricao ,
                                              AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                              AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                              AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                              AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                              AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                              AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                              AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                              AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                              AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                              AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                              AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels.Count ,
                                              A325PropostaDescricao ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV62Notafiscalitemwwds_1_notafiscalid ,
                                              A794NotaFiscalId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV75Notafiscalitemwwds_14_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV75Notafiscalitemwwds_14_tfpropostadescricao), "%", "");
         lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo), "%", "");
         lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00DP2 */
         pr_default.execute(0, new Object[] {AV62Notafiscalitemwwds_1_notafiscalid, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV66Notafiscalitemwwds_5_notafiscalitemcodigo1, lV66Notafiscalitemwwds_5_notafiscalitemcodigo1, lV70Notafiscalitemwwds_9_notafiscalitemcodigo2, lV70Notafiscalitemwwds_9_notafiscalitemcodigo2, lV74Notafiscalitemwwds_13_notafiscalitemcodigo3, lV74Notafiscalitemwwds_13_notafiscalitemcodigo3, lV75Notafiscalitemwwds_14_tfpropostadescricao, AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo, AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao, AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade, AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to, AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario, AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to, AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal, AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDP2 = false;
            A323PropostaId = P00DP2_A323PropostaId[0];
            n323PropostaId = P00DP2_n323PropostaId[0];
            A794NotaFiscalId = P00DP2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DP2_n794NotaFiscalId[0];
            A325PropostaDescricao = P00DP2_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DP2_n325PropostaDescricao[0];
            A839NotaFiscalItemValorTotal = P00DP2_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00DP2_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00DP2_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00DP2_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00DP2_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00DP2_n837NotaFiscalItemQuantidade[0];
            A851NotaFiscalItemVendido = P00DP2_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = P00DP2_n851NotaFiscalItemVendido[0];
            A833NotaFiscalItemDescricao = P00DP2_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00DP2_n833NotaFiscalItemDescricao[0];
            A831NotaFiscalItemCodigo = P00DP2_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00DP2_n831NotaFiscalItemCodigo[0];
            A830NotaFiscalItemId = P00DP2_A830NotaFiscalItemId[0];
            A325PropostaDescricao = P00DP2_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DP2_n325PropostaDescricao[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00DP2_A794NotaFiscalId[0] == A794NotaFiscalId ) && ( StringUtil.StrCmp(P00DP2_A325PropostaDescricao[0], A325PropostaDescricao) == 0 ) )
            {
               BRKDP2 = false;
               A323PropostaId = P00DP2_A323PropostaId[0];
               n323PropostaId = P00DP2_n323PropostaId[0];
               A830NotaFiscalItemId = P00DP2_A830NotaFiscalItemId[0];
               AV34count = (long)(AV34count+1);
               BRKDP2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? "<#Empty#>" : A325PropostaDescricao);
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
            if ( ! BRKDP2 )
            {
               BRKDP2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADNOTAFISCALITEMCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV12TFNotaFiscalItemCodigo = AV24SearchTxt;
         AV13TFNotaFiscalItemCodigo_Sel = "";
         AV62Notafiscalitemwwds_1_notafiscalid = AV58NotaFiscalId;
         AV63Notafiscalitemwwds_2_filterfulltext = AV46FilterFullText;
         AV64Notafiscalitemwwds_3_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV49NotaFiscalItemCodigo1;
         AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV68Notafiscalitemwwds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV53NotaFiscalItemCodigo2;
         AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV72Notafiscalitemwwds_11_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV57NotaFiscalItemCodigo3;
         AV75Notafiscalitemwwds_14_tfpropostadescricao = AV10TFPropostaDescricao;
         AV76Notafiscalitemwwds_15_tfpropostadescricao_sel = AV11TFPropostaDescricao_Sel;
         AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV12TFNotaFiscalItemCodigo;
         AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV13TFNotaFiscalItemCodigo_Sel;
         AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV14TFNotaFiscalItemDescricao;
         AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV15TFNotaFiscalItemDescricao_Sel;
         AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV16TFNotaFiscalItemQuantidade;
         AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV17TFNotaFiscalItemQuantidade_To;
         AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV18TFNotaFiscalItemValorUnitario;
         AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV19TFNotaFiscalItemValorUnitario_To;
         AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV20TFNotaFiscalItemValorTotal;
         AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV21TFNotaFiscalItemValorTotal_To;
         AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV23TFNotaFiscalItemVendido_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A851NotaFiscalItemVendido ,
                                              AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                              AV63Notafiscalitemwwds_2_filterfulltext ,
                                              AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                              AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                              AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                              AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                              AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                              AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                              AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                              AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                              AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                              AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                              AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                              AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                              AV75Notafiscalitemwwds_14_tfpropostadescricao ,
                                              AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                              AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                              AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                              AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                              AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                              AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                              AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                              AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                              AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                              AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                              AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels.Count ,
                                              A325PropostaDescricao ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV62Notafiscalitemwwds_1_notafiscalid ,
                                              A794NotaFiscalId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV75Notafiscalitemwwds_14_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV75Notafiscalitemwwds_14_tfpropostadescricao), "%", "");
         lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo), "%", "");
         lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00DP3 */
         pr_default.execute(1, new Object[] {AV62Notafiscalitemwwds_1_notafiscalid, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV66Notafiscalitemwwds_5_notafiscalitemcodigo1, lV66Notafiscalitemwwds_5_notafiscalitemcodigo1, lV70Notafiscalitemwwds_9_notafiscalitemcodigo2, lV70Notafiscalitemwwds_9_notafiscalitemcodigo2, lV74Notafiscalitemwwds_13_notafiscalitemcodigo3, lV74Notafiscalitemwwds_13_notafiscalitemcodigo3, lV75Notafiscalitemwwds_14_tfpropostadescricao, AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo, AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao, AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade, AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to, AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario, AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to, AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal, AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKDP4 = false;
            A323PropostaId = P00DP3_A323PropostaId[0];
            n323PropostaId = P00DP3_n323PropostaId[0];
            A794NotaFiscalId = P00DP3_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DP3_n794NotaFiscalId[0];
            A831NotaFiscalItemCodigo = P00DP3_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00DP3_n831NotaFiscalItemCodigo[0];
            A839NotaFiscalItemValorTotal = P00DP3_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00DP3_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00DP3_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00DP3_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00DP3_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00DP3_n837NotaFiscalItemQuantidade[0];
            A851NotaFiscalItemVendido = P00DP3_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = P00DP3_n851NotaFiscalItemVendido[0];
            A833NotaFiscalItemDescricao = P00DP3_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00DP3_n833NotaFiscalItemDescricao[0];
            A325PropostaDescricao = P00DP3_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DP3_n325PropostaDescricao[0];
            A830NotaFiscalItemId = P00DP3_A830NotaFiscalItemId[0];
            A325PropostaDescricao = P00DP3_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DP3_n325PropostaDescricao[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00DP3_A794NotaFiscalId[0] == A794NotaFiscalId ) && ( StringUtil.StrCmp(P00DP3_A831NotaFiscalItemCodigo[0], A831NotaFiscalItemCodigo) == 0 ) )
            {
               BRKDP4 = false;
               A830NotaFiscalItemId = P00DP3_A830NotaFiscalItemId[0];
               AV34count = (long)(AV34count+1);
               BRKDP4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A831NotaFiscalItemCodigo)) ? "<#Empty#>" : A831NotaFiscalItemCodigo);
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
            if ( ! BRKDP4 )
            {
               BRKDP4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADNOTAFISCALITEMDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV14TFNotaFiscalItemDescricao = AV24SearchTxt;
         AV15TFNotaFiscalItemDescricao_Sel = "";
         AV62Notafiscalitemwwds_1_notafiscalid = AV58NotaFiscalId;
         AV63Notafiscalitemwwds_2_filterfulltext = AV46FilterFullText;
         AV64Notafiscalitemwwds_3_dynamicfiltersselector1 = AV47DynamicFiltersSelector1;
         AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV48DynamicFiltersOperator1;
         AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV49NotaFiscalItemCodigo1;
         AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV68Notafiscalitemwwds_7_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV53NotaFiscalItemCodigo2;
         AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV72Notafiscalitemwwds_11_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV57NotaFiscalItemCodigo3;
         AV75Notafiscalitemwwds_14_tfpropostadescricao = AV10TFPropostaDescricao;
         AV76Notafiscalitemwwds_15_tfpropostadescricao_sel = AV11TFPropostaDescricao_Sel;
         AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV12TFNotaFiscalItemCodigo;
         AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV13TFNotaFiscalItemCodigo_Sel;
         AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV14TFNotaFiscalItemDescricao;
         AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV15TFNotaFiscalItemDescricao_Sel;
         AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV16TFNotaFiscalItemQuantidade;
         AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV17TFNotaFiscalItemQuantidade_To;
         AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV18TFNotaFiscalItemValorUnitario;
         AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV19TFNotaFiscalItemValorUnitario_To;
         AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV20TFNotaFiscalItemValorTotal;
         AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV21TFNotaFiscalItemValorTotal_To;
         AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV23TFNotaFiscalItemVendido_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A851NotaFiscalItemVendido ,
                                              AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                              AV63Notafiscalitemwwds_2_filterfulltext ,
                                              AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                              AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                              AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                              AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                              AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                              AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                              AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                              AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                              AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                              AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                              AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                              AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                              AV75Notafiscalitemwwds_14_tfpropostadescricao ,
                                              AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                              AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                              AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                              AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                              AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                              AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                              AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                              AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                              AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                              AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                              AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels.Count ,
                                              A325PropostaDescricao ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV62Notafiscalitemwwds_1_notafiscalid ,
                                              A794NotaFiscalId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV63Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV75Notafiscalitemwwds_14_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV75Notafiscalitemwwds_14_tfpropostadescricao), "%", "");
         lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo), "%", "");
         lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00DP4 */
         pr_default.execute(2, new Object[] {AV62Notafiscalitemwwds_1_notafiscalid, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV63Notafiscalitemwwds_2_filterfulltext, lV66Notafiscalitemwwds_5_notafiscalitemcodigo1, lV66Notafiscalitemwwds_5_notafiscalitemcodigo1, lV70Notafiscalitemwwds_9_notafiscalitemcodigo2, lV70Notafiscalitemwwds_9_notafiscalitemcodigo2, lV74Notafiscalitemwwds_13_notafiscalitemcodigo3, lV74Notafiscalitemwwds_13_notafiscalitemcodigo3, lV75Notafiscalitemwwds_14_tfpropostadescricao, AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo, AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao, AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade, AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to, AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario, AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to, AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal, AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKDP6 = false;
            A323PropostaId = P00DP4_A323PropostaId[0];
            n323PropostaId = P00DP4_n323PropostaId[0];
            A794NotaFiscalId = P00DP4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DP4_n794NotaFiscalId[0];
            A833NotaFiscalItemDescricao = P00DP4_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00DP4_n833NotaFiscalItemDescricao[0];
            A839NotaFiscalItemValorTotal = P00DP4_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00DP4_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00DP4_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00DP4_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00DP4_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00DP4_n837NotaFiscalItemQuantidade[0];
            A851NotaFiscalItemVendido = P00DP4_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = P00DP4_n851NotaFiscalItemVendido[0];
            A831NotaFiscalItemCodigo = P00DP4_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00DP4_n831NotaFiscalItemCodigo[0];
            A325PropostaDescricao = P00DP4_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DP4_n325PropostaDescricao[0];
            A830NotaFiscalItemId = P00DP4_A830NotaFiscalItemId[0];
            A325PropostaDescricao = P00DP4_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DP4_n325PropostaDescricao[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00DP4_A794NotaFiscalId[0] == A794NotaFiscalId ) && ( StringUtil.StrCmp(P00DP4_A833NotaFiscalItemDescricao[0], A833NotaFiscalItemDescricao) == 0 ) )
            {
               BRKDP6 = false;
               A830NotaFiscalItemId = P00DP4_A830NotaFiscalItemId[0];
               AV34count = (long)(AV34count+1);
               BRKDP6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A833NotaFiscalItemDescricao)) ? "<#Empty#>" : A833NotaFiscalItemDescricao);
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
            if ( ! BRKDP6 )
            {
               BRKDP6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV10TFPropostaDescricao = "";
         AV11TFPropostaDescricao_Sel = "";
         AV12TFNotaFiscalItemCodigo = "";
         AV13TFNotaFiscalItemCodigo_Sel = "";
         AV14TFNotaFiscalItemDescricao = "";
         AV15TFNotaFiscalItemDescricao_Sel = "";
         AV22TFNotaFiscalItemVendido_SelsJson = "";
         AV23TFNotaFiscalItemVendido_Sels = new GxSimpleCollection<string>();
         AV58NotaFiscalId = Guid.Empty;
         AV59NotaFiscalStatus = "";
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV47DynamicFiltersSelector1 = "";
         AV49NotaFiscalItemCodigo1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV53NotaFiscalItemCodigo2 = "";
         AV55DynamicFiltersSelector3 = "";
         AV57NotaFiscalItemCodigo3 = "";
         AV62Notafiscalitemwwds_1_notafiscalid = Guid.Empty;
         AV63Notafiscalitemwwds_2_filterfulltext = "";
         AV64Notafiscalitemwwds_3_dynamicfiltersselector1 = "";
         AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = "";
         AV68Notafiscalitemwwds_7_dynamicfiltersselector2 = "";
         AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = "";
         AV72Notafiscalitemwwds_11_dynamicfiltersselector3 = "";
         AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = "";
         AV75Notafiscalitemwwds_14_tfpropostadescricao = "";
         AV76Notafiscalitemwwds_15_tfpropostadescricao_sel = "";
         AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = "";
         AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = "";
         AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = "";
         AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = "";
         AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = new GxSimpleCollection<string>();
         lV63Notafiscalitemwwds_2_filterfulltext = "";
         lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 = "";
         lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 = "";
         lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 = "";
         lV75Notafiscalitemwwds_14_tfpropostadescricao = "";
         lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo = "";
         lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao = "";
         A851NotaFiscalItemVendido = "";
         A325PropostaDescricao = "";
         A831NotaFiscalItemCodigo = "";
         A833NotaFiscalItemDescricao = "";
         A794NotaFiscalId = Guid.Empty;
         P00DP2_A323PropostaId = new int[1] ;
         P00DP2_n323PropostaId = new bool[] {false} ;
         P00DP2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DP2_n794NotaFiscalId = new bool[] {false} ;
         P00DP2_A325PropostaDescricao = new string[] {""} ;
         P00DP2_n325PropostaDescricao = new bool[] {false} ;
         P00DP2_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00DP2_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00DP2_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00DP2_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00DP2_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00DP2_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00DP2_A851NotaFiscalItemVendido = new string[] {""} ;
         P00DP2_n851NotaFiscalItemVendido = new bool[] {false} ;
         P00DP2_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00DP2_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00DP2_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00DP2_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00DP2_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         A830NotaFiscalItemId = Guid.Empty;
         AV29Option = "";
         P00DP3_A323PropostaId = new int[1] ;
         P00DP3_n323PropostaId = new bool[] {false} ;
         P00DP3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DP3_n794NotaFiscalId = new bool[] {false} ;
         P00DP3_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00DP3_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00DP3_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00DP3_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00DP3_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00DP3_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00DP3_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00DP3_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00DP3_A851NotaFiscalItemVendido = new string[] {""} ;
         P00DP3_n851NotaFiscalItemVendido = new bool[] {false} ;
         P00DP3_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00DP3_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00DP3_A325PropostaDescricao = new string[] {""} ;
         P00DP3_n325PropostaDescricao = new bool[] {false} ;
         P00DP3_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         P00DP4_A323PropostaId = new int[1] ;
         P00DP4_n323PropostaId = new bool[] {false} ;
         P00DP4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DP4_n794NotaFiscalId = new bool[] {false} ;
         P00DP4_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00DP4_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00DP4_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00DP4_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00DP4_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00DP4_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00DP4_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00DP4_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00DP4_A851NotaFiscalItemVendido = new string[] {""} ;
         P00DP4_n851NotaFiscalItemVendido = new bool[] {false} ;
         P00DP4_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00DP4_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00DP4_A325PropostaDescricao = new string[] {""} ;
         P00DP4_n325PropostaDescricao = new bool[] {false} ;
         P00DP4_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitemwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DP2_A323PropostaId, P00DP2_n323PropostaId, P00DP2_A794NotaFiscalId, P00DP2_n794NotaFiscalId, P00DP2_A325PropostaDescricao, P00DP2_n325PropostaDescricao, P00DP2_A839NotaFiscalItemValorTotal, P00DP2_n839NotaFiscalItemValorTotal, P00DP2_A838NotaFiscalItemValorUnitario, P00DP2_n838NotaFiscalItemValorUnitario,
               P00DP2_A837NotaFiscalItemQuantidade, P00DP2_n837NotaFiscalItemQuantidade, P00DP2_A851NotaFiscalItemVendido, P00DP2_n851NotaFiscalItemVendido, P00DP2_A833NotaFiscalItemDescricao, P00DP2_n833NotaFiscalItemDescricao, P00DP2_A831NotaFiscalItemCodigo, P00DP2_n831NotaFiscalItemCodigo, P00DP2_A830NotaFiscalItemId
               }
               , new Object[] {
               P00DP3_A323PropostaId, P00DP3_n323PropostaId, P00DP3_A794NotaFiscalId, P00DP3_n794NotaFiscalId, P00DP3_A831NotaFiscalItemCodigo, P00DP3_n831NotaFiscalItemCodigo, P00DP3_A839NotaFiscalItemValorTotal, P00DP3_n839NotaFiscalItemValorTotal, P00DP3_A838NotaFiscalItemValorUnitario, P00DP3_n838NotaFiscalItemValorUnitario,
               P00DP3_A837NotaFiscalItemQuantidade, P00DP3_n837NotaFiscalItemQuantidade, P00DP3_A851NotaFiscalItemVendido, P00DP3_n851NotaFiscalItemVendido, P00DP3_A833NotaFiscalItemDescricao, P00DP3_n833NotaFiscalItemDescricao, P00DP3_A325PropostaDescricao, P00DP3_n325PropostaDescricao, P00DP3_A830NotaFiscalItemId
               }
               , new Object[] {
               P00DP4_A323PropostaId, P00DP4_n323PropostaId, P00DP4_A794NotaFiscalId, P00DP4_n794NotaFiscalId, P00DP4_A833NotaFiscalItemDescricao, P00DP4_n833NotaFiscalItemDescricao, P00DP4_A839NotaFiscalItemValorTotal, P00DP4_n839NotaFiscalItemValorTotal, P00DP4_A838NotaFiscalItemValorUnitario, P00DP4_n838NotaFiscalItemValorUnitario,
               P00DP4_A837NotaFiscalItemQuantidade, P00DP4_n837NotaFiscalItemQuantidade, P00DP4_A851NotaFiscalItemVendido, P00DP4_n851NotaFiscalItemVendido, P00DP4_A831NotaFiscalItemCodigo, P00DP4_n831NotaFiscalItemCodigo, P00DP4_A325PropostaDescricao, P00DP4_n325PropostaDescricao, P00DP4_A830NotaFiscalItemId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private short AV48DynamicFiltersOperator1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV56DynamicFiltersOperator3 ;
      private short AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ;
      private short AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ;
      private short AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ;
      private int AV60GXV1 ;
      private int AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ;
      private int A323PropostaId ;
      private long AV34count ;
      private decimal AV16TFNotaFiscalItemQuantidade ;
      private decimal AV17TFNotaFiscalItemQuantidade_To ;
      private decimal AV18TFNotaFiscalItemValorUnitario ;
      private decimal AV19TFNotaFiscalItemValorUnitario_To ;
      private decimal AV20TFNotaFiscalItemValorTotal ;
      private decimal AV21TFNotaFiscalItemValorTotal_To ;
      private decimal AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ;
      private decimal AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ;
      private decimal AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ;
      private decimal AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ;
      private decimal AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ;
      private decimal AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal A839NotaFiscalItemValorTotal ;
      private bool returnInSub ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV54DynamicFiltersEnabled3 ;
      private bool AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ;
      private bool AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ;
      private bool BRKDP2 ;
      private bool n323PropostaId ;
      private bool n794NotaFiscalId ;
      private bool n325PropostaDescricao ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n851NotaFiscalItemVendido ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n831NotaFiscalItemCodigo ;
      private bool BRKDP4 ;
      private bool BRKDP6 ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV22TFNotaFiscalItemVendido_SelsJson ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV46FilterFullText ;
      private string AV10TFPropostaDescricao ;
      private string AV11TFPropostaDescricao_Sel ;
      private string AV12TFNotaFiscalItemCodigo ;
      private string AV13TFNotaFiscalItemCodigo_Sel ;
      private string AV14TFNotaFiscalItemDescricao ;
      private string AV15TFNotaFiscalItemDescricao_Sel ;
      private string AV59NotaFiscalStatus ;
      private string AV47DynamicFiltersSelector1 ;
      private string AV49NotaFiscalItemCodigo1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV53NotaFiscalItemCodigo2 ;
      private string AV55DynamicFiltersSelector3 ;
      private string AV57NotaFiscalItemCodigo3 ;
      private string AV63Notafiscalitemwwds_2_filterfulltext ;
      private string AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ;
      private string AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ;
      private string AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ;
      private string AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ;
      private string AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ;
      private string AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ;
      private string AV75Notafiscalitemwwds_14_tfpropostadescricao ;
      private string AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ;
      private string AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ;
      private string AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ;
      private string AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ;
      private string AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ;
      private string lV63Notafiscalitemwwds_2_filterfulltext ;
      private string lV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ;
      private string lV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ;
      private string lV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ;
      private string lV75Notafiscalitemwwds_14_tfpropostadescricao ;
      private string lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ;
      private string lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ;
      private string A851NotaFiscalItemVendido ;
      private string A325PropostaDescricao ;
      private string A831NotaFiscalItemCodigo ;
      private string A833NotaFiscalItemDescricao ;
      private string AV29Option ;
      private Guid AV58NotaFiscalId ;
      private Guid AV62Notafiscalitemwwds_1_notafiscalid ;
      private Guid A794NotaFiscalId ;
      private Guid A830NotaFiscalItemId ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GxSimpleCollection<string> AV23TFNotaFiscalItemVendido_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00DP2_A323PropostaId ;
      private bool[] P00DP2_n323PropostaId ;
      private Guid[] P00DP2_A794NotaFiscalId ;
      private bool[] P00DP2_n794NotaFiscalId ;
      private string[] P00DP2_A325PropostaDescricao ;
      private bool[] P00DP2_n325PropostaDescricao ;
      private decimal[] P00DP2_A839NotaFiscalItemValorTotal ;
      private bool[] P00DP2_n839NotaFiscalItemValorTotal ;
      private decimal[] P00DP2_A838NotaFiscalItemValorUnitario ;
      private bool[] P00DP2_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00DP2_A837NotaFiscalItemQuantidade ;
      private bool[] P00DP2_n837NotaFiscalItemQuantidade ;
      private string[] P00DP2_A851NotaFiscalItemVendido ;
      private bool[] P00DP2_n851NotaFiscalItemVendido ;
      private string[] P00DP2_A833NotaFiscalItemDescricao ;
      private bool[] P00DP2_n833NotaFiscalItemDescricao ;
      private string[] P00DP2_A831NotaFiscalItemCodigo ;
      private bool[] P00DP2_n831NotaFiscalItemCodigo ;
      private Guid[] P00DP2_A830NotaFiscalItemId ;
      private int[] P00DP3_A323PropostaId ;
      private bool[] P00DP3_n323PropostaId ;
      private Guid[] P00DP3_A794NotaFiscalId ;
      private bool[] P00DP3_n794NotaFiscalId ;
      private string[] P00DP3_A831NotaFiscalItemCodigo ;
      private bool[] P00DP3_n831NotaFiscalItemCodigo ;
      private decimal[] P00DP3_A839NotaFiscalItemValorTotal ;
      private bool[] P00DP3_n839NotaFiscalItemValorTotal ;
      private decimal[] P00DP3_A838NotaFiscalItemValorUnitario ;
      private bool[] P00DP3_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00DP3_A837NotaFiscalItemQuantidade ;
      private bool[] P00DP3_n837NotaFiscalItemQuantidade ;
      private string[] P00DP3_A851NotaFiscalItemVendido ;
      private bool[] P00DP3_n851NotaFiscalItemVendido ;
      private string[] P00DP3_A833NotaFiscalItemDescricao ;
      private bool[] P00DP3_n833NotaFiscalItemDescricao ;
      private string[] P00DP3_A325PropostaDescricao ;
      private bool[] P00DP3_n325PropostaDescricao ;
      private Guid[] P00DP3_A830NotaFiscalItemId ;
      private int[] P00DP4_A323PropostaId ;
      private bool[] P00DP4_n323PropostaId ;
      private Guid[] P00DP4_A794NotaFiscalId ;
      private bool[] P00DP4_n794NotaFiscalId ;
      private string[] P00DP4_A833NotaFiscalItemDescricao ;
      private bool[] P00DP4_n833NotaFiscalItemDescricao ;
      private decimal[] P00DP4_A839NotaFiscalItemValorTotal ;
      private bool[] P00DP4_n839NotaFiscalItemValorTotal ;
      private decimal[] P00DP4_A838NotaFiscalItemValorUnitario ;
      private bool[] P00DP4_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00DP4_A837NotaFiscalItemQuantidade ;
      private bool[] P00DP4_n837NotaFiscalItemQuantidade ;
      private string[] P00DP4_A851NotaFiscalItemVendido ;
      private bool[] P00DP4_n851NotaFiscalItemVendido ;
      private string[] P00DP4_A831NotaFiscalItemCodigo ;
      private bool[] P00DP4_n831NotaFiscalItemCodigo ;
      private string[] P00DP4_A325PropostaDescricao ;
      private bool[] P00DP4_n325PropostaDescricao ;
      private Guid[] P00DP4_A830NotaFiscalItemId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class notafiscalitemwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DP2( IGxContext context ,
                                             string A851NotaFiscalItemVendido ,
                                             GxSimpleCollection<string> AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                             string AV63Notafiscalitemwwds_2_filterfulltext ,
                                             string AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                             short AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                             string AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                             bool AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                             string AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                             short AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                             string AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                             bool AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                             string AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                             short AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                             string AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                             string AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                             string AV75Notafiscalitemwwds_14_tfpropostadescricao ,
                                             string AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                             string AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                             string AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                             string AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                             decimal AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                             decimal AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                             decimal AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                             decimal AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                             decimal AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                             int AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ,
                                             string A325PropostaDescricao ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             Guid AV62Notafiscalitemwwds_1_notafiscalid ,
                                             Guid A794NotaFiscalId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[28];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.PropostaId, T1.NotaFiscalId, T2.PropostaDescricao, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemVendido, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemCodigo, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(T1.NotaFiscalId = :AV62Notafiscalitemwwds_1_notafiscalid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.PropostaDescricao like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemCodigo like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemDescricao like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemQuantidade,'99999999990.999999'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorUnitario,'999999999999990.99'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorTotal,'999999999999990.99'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( 'vendido' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'VENDIDO')) or ( 'aberto' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'ABERTO')) or ( 'devolvido' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'DEVOLVIDO')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV66Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV66Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV70Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV70Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV74Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV74Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Notafiscalitemwwds_14_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao like :lV75Notafiscalitemwwds_14_tfpropostadescricao)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao = ( :AV76Notafiscalitemwwds_15_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels, "T1.NotaFiscalItemVendido IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId, T2.PropostaDescricao";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DP3( IGxContext context ,
                                             string A851NotaFiscalItemVendido ,
                                             GxSimpleCollection<string> AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                             string AV63Notafiscalitemwwds_2_filterfulltext ,
                                             string AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                             short AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                             string AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                             bool AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                             string AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                             short AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                             string AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                             bool AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                             string AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                             short AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                             string AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                             string AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                             string AV75Notafiscalitemwwds_14_tfpropostadescricao ,
                                             string AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                             string AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                             string AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                             string AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                             decimal AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                             decimal AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                             decimal AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                             decimal AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                             decimal AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                             int AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ,
                                             string A325PropostaDescricao ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             Guid AV62Notafiscalitemwwds_1_notafiscalid ,
                                             Guid A794NotaFiscalId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PropostaId, T1.NotaFiscalId, T1.NotaFiscalItemCodigo, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemVendido, T1.NotaFiscalItemDescricao, T2.PropostaDescricao, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(T1.NotaFiscalId = :AV62Notafiscalitemwwds_1_notafiscalid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.PropostaDescricao like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemCodigo like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemDescricao like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemQuantidade,'99999999990.999999'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorUnitario,'999999999999990.99'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorTotal,'999999999999990.99'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( 'vendido' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'VENDIDO')) or ( 'aberto' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'ABERTO')) or ( 'devolvido' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'DEVOLVIDO')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV66Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV66Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV70Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV70Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV74Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV74Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Notafiscalitemwwds_14_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao like :lV75Notafiscalitemwwds_14_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao = ( :AV76Notafiscalitemwwds_15_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels, "T1.NotaFiscalItemVendido IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemCodigo";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DP4( IGxContext context ,
                                             string A851NotaFiscalItemVendido ,
                                             GxSimpleCollection<string> AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                             string AV63Notafiscalitemwwds_2_filterfulltext ,
                                             string AV64Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                             short AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                             string AV66Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                             bool AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                             string AV68Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                             short AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                             string AV70Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                             bool AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                             string AV72Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                             short AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                             string AV74Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                             string AV76Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                             string AV75Notafiscalitemwwds_14_tfpropostadescricao ,
                                             string AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                             string AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                             string AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                             string AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                             decimal AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                             decimal AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                             decimal AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                             decimal AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                             decimal AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                             int AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ,
                                             string A325PropostaDescricao ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             Guid AV62Notafiscalitemwwds_1_notafiscalid ,
                                             Guid A794NotaFiscalId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[28];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.PropostaId, T1.NotaFiscalId, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemVendido, T1.NotaFiscalItemCodigo, T2.PropostaDescricao, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(T1.NotaFiscalId = :AV62Notafiscalitemwwds_1_notafiscalid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Notafiscalitemwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.PropostaDescricao like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemCodigo like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemDescricao like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemQuantidade,'99999999990.999999'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorUnitario,'999999999999990.99'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorTotal,'999999999999990.99'), 2) like '%' || :lV63Notafiscalitemwwds_2_filterfulltext) or ( 'vendido' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'VENDIDO')) or ( 'aberto' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'ABERTO')) or ( 'devolvido' like '%' || LOWER(:lV63Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'DEVOLVIDO')))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV66Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV65Notafiscalitemwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV66Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV70Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV67Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV69Notafiscalitemwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV70Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV74Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV71Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV73Notafiscalitemwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV74Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Notafiscalitemwwds_14_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao like :lV75Notafiscalitemwwds_14_tfpropostadescricao)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao = ( :AV76Notafiscalitemwwds_15_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels, "T1.NotaFiscalItemVendido IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemDescricao";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DP2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (Guid)dynConstraints[33] , (Guid)dynConstraints[34] );
               case 1 :
                     return conditional_P00DP3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (Guid)dynConstraints[33] , (Guid)dynConstraints[34] );
               case 2 :
                     return conditional_P00DP4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (Guid)dynConstraints[33] , (Guid)dynConstraints[34] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DP2;
          prmP00DP2 = new Object[] {
          new ParDef("AV62Notafiscalitemwwds_1_notafiscalid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV74Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV74Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV75Notafiscalitemwwds_14_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV76Notafiscalitemwwds_15_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel",GXType.VarChar,255,0) ,
          new ParDef("AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to",GXType.Number,18,6) ,
          new ParDef("AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario",GXType.Number,18,2) ,
          new ParDef("AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to",GXType.Number,18,2) ,
          new ParDef("AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to",GXType.Number,18,2)
          };
          Object[] prmP00DP3;
          prmP00DP3 = new Object[] {
          new ParDef("AV62Notafiscalitemwwds_1_notafiscalid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV74Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV74Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV75Notafiscalitemwwds_14_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV76Notafiscalitemwwds_15_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel",GXType.VarChar,255,0) ,
          new ParDef("AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to",GXType.Number,18,6) ,
          new ParDef("AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario",GXType.Number,18,2) ,
          new ParDef("AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to",GXType.Number,18,2) ,
          new ParDef("AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to",GXType.Number,18,2)
          };
          Object[] prmP00DP4;
          prmP00DP4 = new Object[] {
          new ParDef("AV62Notafiscalitemwwds_1_notafiscalid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV66Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV70Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV74Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV74Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV75Notafiscalitemwwds_14_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV76Notafiscalitemwwds_15_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV77Notafiscalitemwwds_16_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV78Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV79Notafiscalitemwwds_18_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV80Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel",GXType.VarChar,255,0) ,
          new ParDef("AV81Notafiscalitemwwds_20_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV82Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to",GXType.Number,18,6) ,
          new ParDef("AV83Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario",GXType.Number,18,2) ,
          new ParDef("AV84Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to",GXType.Number,18,2) ,
          new ParDef("AV85Notafiscalitemwwds_24_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV86Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00DP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DP4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DP4,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                return;
       }
    }

 }

}
