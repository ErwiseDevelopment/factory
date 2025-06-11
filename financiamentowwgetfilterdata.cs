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
   public class financiamentowwgetfilterdata : GXProcedure
   {
      public financiamentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamentowwgetfilterdata( IGxContext context )
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
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23MaxItems = 10;
         AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
         AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_CLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTEDOCUMENTOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_INTERMEDIADORCLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADINTERMEDIADORCLIENTERAZAOSOCIALOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADINTERMEDIADORCLIENTEDOCUMENTOOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV39OptionsJson = AV26Options.ToJSonString(false);
         AV40OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("FinanciamentoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "FinanciamentoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("FinanciamentoWWGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV12TFClienteDocumento = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV13TFClienteDocumento_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFINANCIAMENTOVALOR") == 0 )
            {
               AV14TFFinanciamentoValor = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV15TFFinanciamentoValor_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL") == 0 )
            {
               AV16TFIntermediadorClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV17TFIntermediadorClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV18TFIntermediadorClienteDocumento = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV19TFIntermediadorClienteDocumento_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV43DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV43DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 )
            {
               AV44DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV45FinanciamentoValor1 = NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, ".");
            }
            else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV44DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV46ClienteDocumento1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV44DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV47IntermediadorClienteDocumento1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV48DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV49DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV51FinanciamentoValor2 = NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, ".");
               }
               else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV52ClienteDocumento2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV53IntermediadorClienteDocumento2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV54DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV55DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV57FinanciamentoValor3 = NumberUtil.Val( AV35GridStateDynamicFilter.gxTpr_Value, ".");
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV58ClienteDocumento3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV59IntermediadorClienteDocumento3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFClienteRazaoSocial = AV20SearchTxt;
         AV11TFClienteRazaoSocial_Sel = "";
         AV62Financiamentowwds_1_filterfulltext = AV42FilterFullText;
         AV63Financiamentowwds_2_dynamicfiltersselector1 = AV43DynamicFiltersSelector1;
         AV64Financiamentowwds_3_dynamicfiltersoperator1 = AV44DynamicFiltersOperator1;
         AV65Financiamentowwds_4_financiamentovalor1 = AV45FinanciamentoValor1;
         AV66Financiamentowwds_5_clientedocumento1 = AV46ClienteDocumento1;
         AV67Financiamentowwds_6_intermediadorclientedocumento1 = AV47IntermediadorClienteDocumento1;
         AV68Financiamentowwds_7_dynamicfiltersenabled2 = AV48DynamicFiltersEnabled2;
         AV69Financiamentowwds_8_dynamicfiltersselector2 = AV49DynamicFiltersSelector2;
         AV70Financiamentowwds_9_dynamicfiltersoperator2 = AV50DynamicFiltersOperator2;
         AV71Financiamentowwds_10_financiamentovalor2 = AV51FinanciamentoValor2;
         AV72Financiamentowwds_11_clientedocumento2 = AV52ClienteDocumento2;
         AV73Financiamentowwds_12_intermediadorclientedocumento2 = AV53IntermediadorClienteDocumento2;
         AV74Financiamentowwds_13_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV75Financiamentowwds_14_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV76Financiamentowwds_15_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV77Financiamentowwds_16_financiamentovalor3 = AV57FinanciamentoValor3;
         AV78Financiamentowwds_17_clientedocumento3 = AV58ClienteDocumento3;
         AV79Financiamentowwds_18_intermediadorclientedocumento3 = AV59IntermediadorClienteDocumento3;
         AV80Financiamentowwds_19_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV81Financiamentowwds_20_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV82Financiamentowwds_21_tfclientedocumento = AV12TFClienteDocumento;
         AV83Financiamentowwds_22_tfclientedocumento_sel = AV13TFClienteDocumento_Sel;
         AV84Financiamentowwds_23_tffinanciamentovalor = AV14TFFinanciamentoValor;
         AV85Financiamentowwds_24_tffinanciamentovalor_to = AV15TFFinanciamentoValor_To;
         AV86Financiamentowwds_25_tfintermediadorclienterazaosocial = AV16TFIntermediadorClienteRazaoSocial;
         AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV17TFIntermediadorClienteRazaoSocial_Sel;
         AV88Financiamentowwds_27_tfintermediadorclientedocumento = AV18TFIntermediadorClienteDocumento;
         AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV19TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62Financiamentowwds_1_filterfulltext ,
                                              AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV65Financiamentowwds_4_financiamentovalor1 ,
                                              AV66Financiamentowwds_5_clientedocumento1 ,
                                              AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV71Financiamentowwds_10_financiamentovalor2 ,
                                              AV72Financiamentowwds_11_clientedocumento2 ,
                                              AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV77Financiamentowwds_16_financiamentovalor3 ,
                                              AV78Financiamentowwds_17_clientedocumento3 ,
                                              AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV80Financiamentowwds_19_tfclienterazaosocial ,
                                              AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV82Financiamentowwds_21_tfclientedocumento ,
                                              AV84Financiamentowwds_23_tffinanciamentovalor ,
                                              AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV80Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV82Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento), "%", "");
         lV86Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV88Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor P00742 */
         pr_default.execute(0, new Object[] {lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, lV66Financiamentowwds_5_clientedocumento1, lV66Financiamentowwds_5_clientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, lV72Financiamentowwds_11_clientedocumento2, lV72Financiamentowwds_11_clientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, lV78Financiamentowwds_17_clientedocumento3, lV78Financiamentowwds_17_clientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV80Financiamentowwds_19_tfclienterazaosocial, AV81Financiamentowwds_20_tfclienterazaosocial_sel, lV82Financiamentowwds_21_tfclientedocumento, AV83Financiamentowwds_22_tfclientedocumento_sel, AV84Financiamentowwds_23_tffinanciamentovalor, AV85Financiamentowwds_24_tffinanciamentovalor_to, lV86Financiamentowwds_25_tfintermediadorclienterazaosocial, AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV88Financiamentowwds_27_tfintermediadorclientedocumento, AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK742 = false;
            A168ClienteId = P00742_A168ClienteId[0];
            n168ClienteId = P00742_n168ClienteId[0];
            A220IntermediadorClienteId = P00742_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = P00742_n220IntermediadorClienteId[0];
            A170ClienteRazaoSocial = P00742_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00742_n170ClienteRazaoSocial[0];
            A224FinanciamentoValor = P00742_A224FinanciamentoValor[0];
            n224FinanciamentoValor = P00742_n224FinanciamentoValor[0];
            A222IntermediadorClienteDocumento = P00742_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00742_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00742_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00742_n221IntermediadorClienteRazaoSocial[0];
            A169ClienteDocumento = P00742_A169ClienteDocumento[0];
            n169ClienteDocumento = P00742_n169ClienteDocumento[0];
            A223FinanciamentoId = P00742_A223FinanciamentoId[0];
            A170ClienteRazaoSocial = P00742_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00742_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00742_A169ClienteDocumento[0];
            n169ClienteDocumento = P00742_n169ClienteDocumento[0];
            A222IntermediadorClienteDocumento = P00742_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00742_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00742_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00742_n221IntermediadorClienteRazaoSocial[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00742_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
            {
               BRK742 = false;
               A168ClienteId = P00742_A168ClienteId[0];
               n168ClienteId = P00742_n168ClienteId[0];
               A223FinanciamentoId = P00742_A223FinanciamentoId[0];
               AV30count = (long)(AV30count+1);
               BRK742 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
               AV27OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
               AV26Options.Add(AV25Option, 0);
               AV28OptionsDesc.Add(AV27OptionDesc, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRK742 )
            {
               BRK742 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV12TFClienteDocumento = AV20SearchTxt;
         AV13TFClienteDocumento_Sel = "";
         AV62Financiamentowwds_1_filterfulltext = AV42FilterFullText;
         AV63Financiamentowwds_2_dynamicfiltersselector1 = AV43DynamicFiltersSelector1;
         AV64Financiamentowwds_3_dynamicfiltersoperator1 = AV44DynamicFiltersOperator1;
         AV65Financiamentowwds_4_financiamentovalor1 = AV45FinanciamentoValor1;
         AV66Financiamentowwds_5_clientedocumento1 = AV46ClienteDocumento1;
         AV67Financiamentowwds_6_intermediadorclientedocumento1 = AV47IntermediadorClienteDocumento1;
         AV68Financiamentowwds_7_dynamicfiltersenabled2 = AV48DynamicFiltersEnabled2;
         AV69Financiamentowwds_8_dynamicfiltersselector2 = AV49DynamicFiltersSelector2;
         AV70Financiamentowwds_9_dynamicfiltersoperator2 = AV50DynamicFiltersOperator2;
         AV71Financiamentowwds_10_financiamentovalor2 = AV51FinanciamentoValor2;
         AV72Financiamentowwds_11_clientedocumento2 = AV52ClienteDocumento2;
         AV73Financiamentowwds_12_intermediadorclientedocumento2 = AV53IntermediadorClienteDocumento2;
         AV74Financiamentowwds_13_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV75Financiamentowwds_14_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV76Financiamentowwds_15_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV77Financiamentowwds_16_financiamentovalor3 = AV57FinanciamentoValor3;
         AV78Financiamentowwds_17_clientedocumento3 = AV58ClienteDocumento3;
         AV79Financiamentowwds_18_intermediadorclientedocumento3 = AV59IntermediadorClienteDocumento3;
         AV80Financiamentowwds_19_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV81Financiamentowwds_20_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV82Financiamentowwds_21_tfclientedocumento = AV12TFClienteDocumento;
         AV83Financiamentowwds_22_tfclientedocumento_sel = AV13TFClienteDocumento_Sel;
         AV84Financiamentowwds_23_tffinanciamentovalor = AV14TFFinanciamentoValor;
         AV85Financiamentowwds_24_tffinanciamentovalor_to = AV15TFFinanciamentoValor_To;
         AV86Financiamentowwds_25_tfintermediadorclienterazaosocial = AV16TFIntermediadorClienteRazaoSocial;
         AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV17TFIntermediadorClienteRazaoSocial_Sel;
         AV88Financiamentowwds_27_tfintermediadorclientedocumento = AV18TFIntermediadorClienteDocumento;
         AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV19TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV62Financiamentowwds_1_filterfulltext ,
                                              AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV65Financiamentowwds_4_financiamentovalor1 ,
                                              AV66Financiamentowwds_5_clientedocumento1 ,
                                              AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV71Financiamentowwds_10_financiamentovalor2 ,
                                              AV72Financiamentowwds_11_clientedocumento2 ,
                                              AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV77Financiamentowwds_16_financiamentovalor3 ,
                                              AV78Financiamentowwds_17_clientedocumento3 ,
                                              AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV80Financiamentowwds_19_tfclienterazaosocial ,
                                              AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV82Financiamentowwds_21_tfclientedocumento ,
                                              AV84Financiamentowwds_23_tffinanciamentovalor ,
                                              AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV80Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV82Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento), "%", "");
         lV86Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV88Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor P00743 */
         pr_default.execute(1, new Object[] {lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, lV66Financiamentowwds_5_clientedocumento1, lV66Financiamentowwds_5_clientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, lV72Financiamentowwds_11_clientedocumento2, lV72Financiamentowwds_11_clientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, lV78Financiamentowwds_17_clientedocumento3, lV78Financiamentowwds_17_clientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV80Financiamentowwds_19_tfclienterazaosocial, AV81Financiamentowwds_20_tfclienterazaosocial_sel, lV82Financiamentowwds_21_tfclientedocumento, AV83Financiamentowwds_22_tfclientedocumento_sel, AV84Financiamentowwds_23_tffinanciamentovalor, AV85Financiamentowwds_24_tffinanciamentovalor_to, lV86Financiamentowwds_25_tfintermediadorclienterazaosocial, AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV88Financiamentowwds_27_tfintermediadorclientedocumento, AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK744 = false;
            A220IntermediadorClienteId = P00743_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = P00743_n220IntermediadorClienteId[0];
            A168ClienteId = P00743_A168ClienteId[0];
            n168ClienteId = P00743_n168ClienteId[0];
            A224FinanciamentoValor = P00743_A224FinanciamentoValor[0];
            n224FinanciamentoValor = P00743_n224FinanciamentoValor[0];
            A222IntermediadorClienteDocumento = P00743_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00743_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00743_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00743_n221IntermediadorClienteRazaoSocial[0];
            A169ClienteDocumento = P00743_A169ClienteDocumento[0];
            n169ClienteDocumento = P00743_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00743_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00743_n170ClienteRazaoSocial[0];
            A223FinanciamentoId = P00743_A223FinanciamentoId[0];
            A222IntermediadorClienteDocumento = P00743_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00743_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00743_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00743_n221IntermediadorClienteRazaoSocial[0];
            A169ClienteDocumento = P00743_A169ClienteDocumento[0];
            n169ClienteDocumento = P00743_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00743_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00743_n170ClienteRazaoSocial[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00743_A168ClienteId[0] == A168ClienteId ) )
            {
               BRK744 = false;
               A223FinanciamentoId = P00743_A223FinanciamentoId[0];
               AV30count = (long)(AV30count+1);
               BRK744 = true;
               pr_default.readNext(1);
            }
            AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? "<#Empty#>" : A169ClienteDocumento);
            AV24InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV25Option, "<#Empty#>") != 0 ) && ( AV24InsertIndex <= AV26Options.Count ) && ( ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) < 0 ) || ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV24InsertIndex = (int)(AV24InsertIndex+1);
            }
            AV26Options.Add(AV25Option, AV24InsertIndex);
            AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), AV24InsertIndex);
            if ( AV26Options.Count == AV21SkipItems + 11 )
            {
               AV26Options.RemoveItem(AV26Options.Count);
               AV29OptionIndexes.RemoveItem(AV29OptionIndexes.Count);
            }
            if ( ! BRK744 )
            {
               BRK744 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV21SkipItems > 0 )
         {
            AV26Options.RemoveItem(1);
            AV29OptionIndexes.RemoveItem(1);
            AV21SkipItems = (short)(AV21SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADINTERMEDIADORCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV16TFIntermediadorClienteRazaoSocial = AV20SearchTxt;
         AV17TFIntermediadorClienteRazaoSocial_Sel = "";
         AV62Financiamentowwds_1_filterfulltext = AV42FilterFullText;
         AV63Financiamentowwds_2_dynamicfiltersselector1 = AV43DynamicFiltersSelector1;
         AV64Financiamentowwds_3_dynamicfiltersoperator1 = AV44DynamicFiltersOperator1;
         AV65Financiamentowwds_4_financiamentovalor1 = AV45FinanciamentoValor1;
         AV66Financiamentowwds_5_clientedocumento1 = AV46ClienteDocumento1;
         AV67Financiamentowwds_6_intermediadorclientedocumento1 = AV47IntermediadorClienteDocumento1;
         AV68Financiamentowwds_7_dynamicfiltersenabled2 = AV48DynamicFiltersEnabled2;
         AV69Financiamentowwds_8_dynamicfiltersselector2 = AV49DynamicFiltersSelector2;
         AV70Financiamentowwds_9_dynamicfiltersoperator2 = AV50DynamicFiltersOperator2;
         AV71Financiamentowwds_10_financiamentovalor2 = AV51FinanciamentoValor2;
         AV72Financiamentowwds_11_clientedocumento2 = AV52ClienteDocumento2;
         AV73Financiamentowwds_12_intermediadorclientedocumento2 = AV53IntermediadorClienteDocumento2;
         AV74Financiamentowwds_13_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV75Financiamentowwds_14_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV76Financiamentowwds_15_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV77Financiamentowwds_16_financiamentovalor3 = AV57FinanciamentoValor3;
         AV78Financiamentowwds_17_clientedocumento3 = AV58ClienteDocumento3;
         AV79Financiamentowwds_18_intermediadorclientedocumento3 = AV59IntermediadorClienteDocumento3;
         AV80Financiamentowwds_19_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV81Financiamentowwds_20_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV82Financiamentowwds_21_tfclientedocumento = AV12TFClienteDocumento;
         AV83Financiamentowwds_22_tfclientedocumento_sel = AV13TFClienteDocumento_Sel;
         AV84Financiamentowwds_23_tffinanciamentovalor = AV14TFFinanciamentoValor;
         AV85Financiamentowwds_24_tffinanciamentovalor_to = AV15TFFinanciamentoValor_To;
         AV86Financiamentowwds_25_tfintermediadorclienterazaosocial = AV16TFIntermediadorClienteRazaoSocial;
         AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV17TFIntermediadorClienteRazaoSocial_Sel;
         AV88Financiamentowwds_27_tfintermediadorclientedocumento = AV18TFIntermediadorClienteDocumento;
         AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV19TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV62Financiamentowwds_1_filterfulltext ,
                                              AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV65Financiamentowwds_4_financiamentovalor1 ,
                                              AV66Financiamentowwds_5_clientedocumento1 ,
                                              AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV71Financiamentowwds_10_financiamentovalor2 ,
                                              AV72Financiamentowwds_11_clientedocumento2 ,
                                              AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV77Financiamentowwds_16_financiamentovalor3 ,
                                              AV78Financiamentowwds_17_clientedocumento3 ,
                                              AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV80Financiamentowwds_19_tfclienterazaosocial ,
                                              AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV82Financiamentowwds_21_tfclientedocumento ,
                                              AV84Financiamentowwds_23_tffinanciamentovalor ,
                                              AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV80Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV82Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento), "%", "");
         lV86Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV88Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor P00744 */
         pr_default.execute(2, new Object[] {lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, lV66Financiamentowwds_5_clientedocumento1, lV66Financiamentowwds_5_clientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, lV72Financiamentowwds_11_clientedocumento2, lV72Financiamentowwds_11_clientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, lV78Financiamentowwds_17_clientedocumento3, lV78Financiamentowwds_17_clientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV80Financiamentowwds_19_tfclienterazaosocial, AV81Financiamentowwds_20_tfclienterazaosocial_sel, lV82Financiamentowwds_21_tfclientedocumento, AV83Financiamentowwds_22_tfclientedocumento_sel, AV84Financiamentowwds_23_tffinanciamentovalor, AV85Financiamentowwds_24_tffinanciamentovalor_to, lV86Financiamentowwds_25_tfintermediadorclienterazaosocial, AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV88Financiamentowwds_27_tfintermediadorclientedocumento, AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK746 = false;
            A168ClienteId = P00744_A168ClienteId[0];
            n168ClienteId = P00744_n168ClienteId[0];
            A220IntermediadorClienteId = P00744_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = P00744_n220IntermediadorClienteId[0];
            A221IntermediadorClienteRazaoSocial = P00744_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00744_n221IntermediadorClienteRazaoSocial[0];
            A224FinanciamentoValor = P00744_A224FinanciamentoValor[0];
            n224FinanciamentoValor = P00744_n224FinanciamentoValor[0];
            A222IntermediadorClienteDocumento = P00744_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00744_n222IntermediadorClienteDocumento[0];
            A169ClienteDocumento = P00744_A169ClienteDocumento[0];
            n169ClienteDocumento = P00744_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00744_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00744_n170ClienteRazaoSocial[0];
            A223FinanciamentoId = P00744_A223FinanciamentoId[0];
            A169ClienteDocumento = P00744_A169ClienteDocumento[0];
            n169ClienteDocumento = P00744_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00744_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00744_n170ClienteRazaoSocial[0];
            A221IntermediadorClienteRazaoSocial = P00744_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00744_n221IntermediadorClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = P00744_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00744_n222IntermediadorClienteDocumento[0];
            AV30count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00744_A221IntermediadorClienteRazaoSocial[0], A221IntermediadorClienteRazaoSocial) == 0 ) )
            {
               BRK746 = false;
               A220IntermediadorClienteId = P00744_A220IntermediadorClienteId[0];
               n220IntermediadorClienteId = P00744_n220IntermediadorClienteId[0];
               A223FinanciamentoId = P00744_A223FinanciamentoId[0];
               AV30count = (long)(AV30count+1);
               BRK746 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A221IntermediadorClienteRazaoSocial)) ? "<#Empty#>" : A221IntermediadorClienteRazaoSocial);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRK746 )
            {
               BRK746 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADINTERMEDIADORCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV18TFIntermediadorClienteDocumento = AV20SearchTxt;
         AV19TFIntermediadorClienteDocumento_Sel = "";
         AV62Financiamentowwds_1_filterfulltext = AV42FilterFullText;
         AV63Financiamentowwds_2_dynamicfiltersselector1 = AV43DynamicFiltersSelector1;
         AV64Financiamentowwds_3_dynamicfiltersoperator1 = AV44DynamicFiltersOperator1;
         AV65Financiamentowwds_4_financiamentovalor1 = AV45FinanciamentoValor1;
         AV66Financiamentowwds_5_clientedocumento1 = AV46ClienteDocumento1;
         AV67Financiamentowwds_6_intermediadorclientedocumento1 = AV47IntermediadorClienteDocumento1;
         AV68Financiamentowwds_7_dynamicfiltersenabled2 = AV48DynamicFiltersEnabled2;
         AV69Financiamentowwds_8_dynamicfiltersselector2 = AV49DynamicFiltersSelector2;
         AV70Financiamentowwds_9_dynamicfiltersoperator2 = AV50DynamicFiltersOperator2;
         AV71Financiamentowwds_10_financiamentovalor2 = AV51FinanciamentoValor2;
         AV72Financiamentowwds_11_clientedocumento2 = AV52ClienteDocumento2;
         AV73Financiamentowwds_12_intermediadorclientedocumento2 = AV53IntermediadorClienteDocumento2;
         AV74Financiamentowwds_13_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV75Financiamentowwds_14_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV76Financiamentowwds_15_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV77Financiamentowwds_16_financiamentovalor3 = AV57FinanciamentoValor3;
         AV78Financiamentowwds_17_clientedocumento3 = AV58ClienteDocumento3;
         AV79Financiamentowwds_18_intermediadorclientedocumento3 = AV59IntermediadorClienteDocumento3;
         AV80Financiamentowwds_19_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV81Financiamentowwds_20_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV82Financiamentowwds_21_tfclientedocumento = AV12TFClienteDocumento;
         AV83Financiamentowwds_22_tfclientedocumento_sel = AV13TFClienteDocumento_Sel;
         AV84Financiamentowwds_23_tffinanciamentovalor = AV14TFFinanciamentoValor;
         AV85Financiamentowwds_24_tffinanciamentovalor_to = AV15TFFinanciamentoValor_To;
         AV86Financiamentowwds_25_tfintermediadorclienterazaosocial = AV16TFIntermediadorClienteRazaoSocial;
         AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV17TFIntermediadorClienteRazaoSocial_Sel;
         AV88Financiamentowwds_27_tfintermediadorclientedocumento = AV18TFIntermediadorClienteDocumento;
         AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV19TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV62Financiamentowwds_1_filterfulltext ,
                                              AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV65Financiamentowwds_4_financiamentovalor1 ,
                                              AV66Financiamentowwds_5_clientedocumento1 ,
                                              AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV71Financiamentowwds_10_financiamentovalor2 ,
                                              AV72Financiamentowwds_11_clientedocumento2 ,
                                              AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV77Financiamentowwds_16_financiamentovalor3 ,
                                              AV78Financiamentowwds_17_clientedocumento3 ,
                                              AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV80Financiamentowwds_19_tfclienterazaosocial ,
                                              AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV82Financiamentowwds_21_tfclientedocumento ,
                                              AV84Financiamentowwds_23_tffinanciamentovalor ,
                                              AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV62Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV66Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV72Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV78Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV80Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV82Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento), "%", "");
         lV86Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV88Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor P00745 */
         pr_default.execute(3, new Object[] {lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, lV62Financiamentowwds_1_filterfulltext, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, AV65Financiamentowwds_4_financiamentovalor1, lV66Financiamentowwds_5_clientedocumento1, lV66Financiamentowwds_5_clientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, lV67Financiamentowwds_6_intermediadorclientedocumento1, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, AV71Financiamentowwds_10_financiamentovalor2, lV72Financiamentowwds_11_clientedocumento2, lV72Financiamentowwds_11_clientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, lV73Financiamentowwds_12_intermediadorclientedocumento2, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, AV77Financiamentowwds_16_financiamentovalor3, lV78Financiamentowwds_17_clientedocumento3, lV78Financiamentowwds_17_clientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV79Financiamentowwds_18_intermediadorclientedocumento3, lV80Financiamentowwds_19_tfclienterazaosocial, AV81Financiamentowwds_20_tfclienterazaosocial_sel, lV82Financiamentowwds_21_tfclientedocumento, AV83Financiamentowwds_22_tfclientedocumento_sel, AV84Financiamentowwds_23_tffinanciamentovalor, AV85Financiamentowwds_24_tffinanciamentovalor_to, lV86Financiamentowwds_25_tfintermediadorclienterazaosocial, AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV88Financiamentowwds_27_tfintermediadorclientedocumento, AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK748 = false;
            A168ClienteId = P00745_A168ClienteId[0];
            n168ClienteId = P00745_n168ClienteId[0];
            A220IntermediadorClienteId = P00745_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = P00745_n220IntermediadorClienteId[0];
            A224FinanciamentoValor = P00745_A224FinanciamentoValor[0];
            n224FinanciamentoValor = P00745_n224FinanciamentoValor[0];
            A222IntermediadorClienteDocumento = P00745_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00745_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00745_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00745_n221IntermediadorClienteRazaoSocial[0];
            A169ClienteDocumento = P00745_A169ClienteDocumento[0];
            n169ClienteDocumento = P00745_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00745_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00745_n170ClienteRazaoSocial[0];
            A223FinanciamentoId = P00745_A223FinanciamentoId[0];
            A169ClienteDocumento = P00745_A169ClienteDocumento[0];
            n169ClienteDocumento = P00745_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00745_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00745_n170ClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = P00745_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00745_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00745_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00745_n221IntermediadorClienteRazaoSocial[0];
            AV30count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00745_A220IntermediadorClienteId[0] == A220IntermediadorClienteId ) )
            {
               BRK748 = false;
               A223FinanciamentoId = P00745_A223FinanciamentoId[0];
               AV30count = (long)(AV30count+1);
               BRK748 = true;
               pr_default.readNext(3);
            }
            AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A222IntermediadorClienteDocumento)) ? "<#Empty#>" : A222IntermediadorClienteDocumento);
            AV24InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV25Option, "<#Empty#>") != 0 ) && ( AV24InsertIndex <= AV26Options.Count ) && ( ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) < 0 ) || ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV24InsertIndex = (int)(AV24InsertIndex+1);
            }
            AV26Options.Add(AV25Option, AV24InsertIndex);
            AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), AV24InsertIndex);
            if ( AV26Options.Count == AV21SkipItems + 11 )
            {
               AV26Options.RemoveItem(AV26Options.Count);
               AV29OptionIndexes.RemoveItem(AV29OptionIndexes.Count);
            }
            if ( ! BRK748 )
            {
               BRK748 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV21SkipItems > 0 )
         {
            AV26Options.RemoveItem(1);
            AV29OptionIndexes.RemoveItem(1);
            AV21SkipItems = (short)(AV21SkipItems-1);
         }
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
         AV39OptionsJson = "";
         AV40OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42FilterFullText = "";
         AV10TFClienteRazaoSocial = "";
         AV11TFClienteRazaoSocial_Sel = "";
         AV12TFClienteDocumento = "";
         AV13TFClienteDocumento_Sel = "";
         AV16TFIntermediadorClienteRazaoSocial = "";
         AV17TFIntermediadorClienteRazaoSocial_Sel = "";
         AV18TFIntermediadorClienteDocumento = "";
         AV19TFIntermediadorClienteDocumento_Sel = "";
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV43DynamicFiltersSelector1 = "";
         AV46ClienteDocumento1 = "";
         AV47IntermediadorClienteDocumento1 = "";
         AV49DynamicFiltersSelector2 = "";
         AV52ClienteDocumento2 = "";
         AV53IntermediadorClienteDocumento2 = "";
         AV55DynamicFiltersSelector3 = "";
         AV58ClienteDocumento3 = "";
         AV59IntermediadorClienteDocumento3 = "";
         AV62Financiamentowwds_1_filterfulltext = "";
         AV63Financiamentowwds_2_dynamicfiltersselector1 = "";
         AV66Financiamentowwds_5_clientedocumento1 = "";
         AV67Financiamentowwds_6_intermediadorclientedocumento1 = "";
         AV69Financiamentowwds_8_dynamicfiltersselector2 = "";
         AV72Financiamentowwds_11_clientedocumento2 = "";
         AV73Financiamentowwds_12_intermediadorclientedocumento2 = "";
         AV75Financiamentowwds_14_dynamicfiltersselector3 = "";
         AV78Financiamentowwds_17_clientedocumento3 = "";
         AV79Financiamentowwds_18_intermediadorclientedocumento3 = "";
         AV80Financiamentowwds_19_tfclienterazaosocial = "";
         AV81Financiamentowwds_20_tfclienterazaosocial_sel = "";
         AV82Financiamentowwds_21_tfclientedocumento = "";
         AV83Financiamentowwds_22_tfclientedocumento_sel = "";
         AV86Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = "";
         AV88Financiamentowwds_27_tfintermediadorclientedocumento = "";
         AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel = "";
         lV62Financiamentowwds_1_filterfulltext = "";
         lV66Financiamentowwds_5_clientedocumento1 = "";
         lV67Financiamentowwds_6_intermediadorclientedocumento1 = "";
         lV72Financiamentowwds_11_clientedocumento2 = "";
         lV73Financiamentowwds_12_intermediadorclientedocumento2 = "";
         lV78Financiamentowwds_17_clientedocumento3 = "";
         lV79Financiamentowwds_18_intermediadorclientedocumento3 = "";
         lV80Financiamentowwds_19_tfclienterazaosocial = "";
         lV82Financiamentowwds_21_tfclientedocumento = "";
         lV86Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         lV88Financiamentowwds_27_tfintermediadorclientedocumento = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A221IntermediadorClienteRazaoSocial = "";
         A222IntermediadorClienteDocumento = "";
         P00742_A168ClienteId = new int[1] ;
         P00742_n168ClienteId = new bool[] {false} ;
         P00742_A220IntermediadorClienteId = new int[1] ;
         P00742_n220IntermediadorClienteId = new bool[] {false} ;
         P00742_A170ClienteRazaoSocial = new string[] {""} ;
         P00742_n170ClienteRazaoSocial = new bool[] {false} ;
         P00742_A224FinanciamentoValor = new decimal[1] ;
         P00742_n224FinanciamentoValor = new bool[] {false} ;
         P00742_A222IntermediadorClienteDocumento = new string[] {""} ;
         P00742_n222IntermediadorClienteDocumento = new bool[] {false} ;
         P00742_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         P00742_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         P00742_A169ClienteDocumento = new string[] {""} ;
         P00742_n169ClienteDocumento = new bool[] {false} ;
         P00742_A223FinanciamentoId = new int[1] ;
         AV25Option = "";
         AV27OptionDesc = "";
         P00743_A220IntermediadorClienteId = new int[1] ;
         P00743_n220IntermediadorClienteId = new bool[] {false} ;
         P00743_A168ClienteId = new int[1] ;
         P00743_n168ClienteId = new bool[] {false} ;
         P00743_A224FinanciamentoValor = new decimal[1] ;
         P00743_n224FinanciamentoValor = new bool[] {false} ;
         P00743_A222IntermediadorClienteDocumento = new string[] {""} ;
         P00743_n222IntermediadorClienteDocumento = new bool[] {false} ;
         P00743_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         P00743_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         P00743_A169ClienteDocumento = new string[] {""} ;
         P00743_n169ClienteDocumento = new bool[] {false} ;
         P00743_A170ClienteRazaoSocial = new string[] {""} ;
         P00743_n170ClienteRazaoSocial = new bool[] {false} ;
         P00743_A223FinanciamentoId = new int[1] ;
         P00744_A168ClienteId = new int[1] ;
         P00744_n168ClienteId = new bool[] {false} ;
         P00744_A220IntermediadorClienteId = new int[1] ;
         P00744_n220IntermediadorClienteId = new bool[] {false} ;
         P00744_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         P00744_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         P00744_A224FinanciamentoValor = new decimal[1] ;
         P00744_n224FinanciamentoValor = new bool[] {false} ;
         P00744_A222IntermediadorClienteDocumento = new string[] {""} ;
         P00744_n222IntermediadorClienteDocumento = new bool[] {false} ;
         P00744_A169ClienteDocumento = new string[] {""} ;
         P00744_n169ClienteDocumento = new bool[] {false} ;
         P00744_A170ClienteRazaoSocial = new string[] {""} ;
         P00744_n170ClienteRazaoSocial = new bool[] {false} ;
         P00744_A223FinanciamentoId = new int[1] ;
         P00745_A168ClienteId = new int[1] ;
         P00745_n168ClienteId = new bool[] {false} ;
         P00745_A220IntermediadorClienteId = new int[1] ;
         P00745_n220IntermediadorClienteId = new bool[] {false} ;
         P00745_A224FinanciamentoValor = new decimal[1] ;
         P00745_n224FinanciamentoValor = new bool[] {false} ;
         P00745_A222IntermediadorClienteDocumento = new string[] {""} ;
         P00745_n222IntermediadorClienteDocumento = new bool[] {false} ;
         P00745_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         P00745_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         P00745_A169ClienteDocumento = new string[] {""} ;
         P00745_n169ClienteDocumento = new bool[] {false} ;
         P00745_A170ClienteRazaoSocial = new string[] {""} ;
         P00745_n170ClienteRazaoSocial = new bool[] {false} ;
         P00745_A223FinanciamentoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00742_A168ClienteId, P00742_n168ClienteId, P00742_A220IntermediadorClienteId, P00742_n220IntermediadorClienteId, P00742_A170ClienteRazaoSocial, P00742_n170ClienteRazaoSocial, P00742_A224FinanciamentoValor, P00742_n224FinanciamentoValor, P00742_A222IntermediadorClienteDocumento, P00742_n222IntermediadorClienteDocumento,
               P00742_A221IntermediadorClienteRazaoSocial, P00742_n221IntermediadorClienteRazaoSocial, P00742_A169ClienteDocumento, P00742_n169ClienteDocumento, P00742_A223FinanciamentoId
               }
               , new Object[] {
               P00743_A220IntermediadorClienteId, P00743_n220IntermediadorClienteId, P00743_A168ClienteId, P00743_n168ClienteId, P00743_A224FinanciamentoValor, P00743_n224FinanciamentoValor, P00743_A222IntermediadorClienteDocumento, P00743_n222IntermediadorClienteDocumento, P00743_A221IntermediadorClienteRazaoSocial, P00743_n221IntermediadorClienteRazaoSocial,
               P00743_A169ClienteDocumento, P00743_n169ClienteDocumento, P00743_A170ClienteRazaoSocial, P00743_n170ClienteRazaoSocial, P00743_A223FinanciamentoId
               }
               , new Object[] {
               P00744_A168ClienteId, P00744_n168ClienteId, P00744_A220IntermediadorClienteId, P00744_n220IntermediadorClienteId, P00744_A221IntermediadorClienteRazaoSocial, P00744_n221IntermediadorClienteRazaoSocial, P00744_A224FinanciamentoValor, P00744_n224FinanciamentoValor, P00744_A222IntermediadorClienteDocumento, P00744_n222IntermediadorClienteDocumento,
               P00744_A169ClienteDocumento, P00744_n169ClienteDocumento, P00744_A170ClienteRazaoSocial, P00744_n170ClienteRazaoSocial, P00744_A223FinanciamentoId
               }
               , new Object[] {
               P00745_A168ClienteId, P00745_n168ClienteId, P00745_A220IntermediadorClienteId, P00745_n220IntermediadorClienteId, P00745_A224FinanciamentoValor, P00745_n224FinanciamentoValor, P00745_A222IntermediadorClienteDocumento, P00745_n222IntermediadorClienteDocumento, P00745_A221IntermediadorClienteRazaoSocial, P00745_n221IntermediadorClienteRazaoSocial,
               P00745_A169ClienteDocumento, P00745_n169ClienteDocumento, P00745_A170ClienteRazaoSocial, P00745_n170ClienteRazaoSocial, P00745_A223FinanciamentoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private short AV44DynamicFiltersOperator1 ;
      private short AV50DynamicFiltersOperator2 ;
      private short AV56DynamicFiltersOperator3 ;
      private short AV64Financiamentowwds_3_dynamicfiltersoperator1 ;
      private short AV70Financiamentowwds_9_dynamicfiltersoperator2 ;
      private short AV76Financiamentowwds_15_dynamicfiltersoperator3 ;
      private int AV60GXV1 ;
      private int A168ClienteId ;
      private int A220IntermediadorClienteId ;
      private int A223FinanciamentoId ;
      private int AV24InsertIndex ;
      private long AV30count ;
      private decimal AV14TFFinanciamentoValor ;
      private decimal AV15TFFinanciamentoValor_To ;
      private decimal AV45FinanciamentoValor1 ;
      private decimal AV51FinanciamentoValor2 ;
      private decimal AV57FinanciamentoValor3 ;
      private decimal AV65Financiamentowwds_4_financiamentovalor1 ;
      private decimal AV71Financiamentowwds_10_financiamentovalor2 ;
      private decimal AV77Financiamentowwds_16_financiamentovalor3 ;
      private decimal AV84Financiamentowwds_23_tffinanciamentovalor ;
      private decimal AV85Financiamentowwds_24_tffinanciamentovalor_to ;
      private decimal A224FinanciamentoValor ;
      private bool returnInSub ;
      private bool AV48DynamicFiltersEnabled2 ;
      private bool AV54DynamicFiltersEnabled3 ;
      private bool AV68Financiamentowwds_7_dynamicfiltersenabled2 ;
      private bool AV74Financiamentowwds_13_dynamicfiltersenabled3 ;
      private bool BRK742 ;
      private bool n168ClienteId ;
      private bool n220IntermediadorClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n224FinanciamentoValor ;
      private bool n222IntermediadorClienteDocumento ;
      private bool n221IntermediadorClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool BRK744 ;
      private bool BRK746 ;
      private bool BRK748 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV42FilterFullText ;
      private string AV10TFClienteRazaoSocial ;
      private string AV11TFClienteRazaoSocial_Sel ;
      private string AV12TFClienteDocumento ;
      private string AV13TFClienteDocumento_Sel ;
      private string AV16TFIntermediadorClienteRazaoSocial ;
      private string AV17TFIntermediadorClienteRazaoSocial_Sel ;
      private string AV18TFIntermediadorClienteDocumento ;
      private string AV19TFIntermediadorClienteDocumento_Sel ;
      private string AV43DynamicFiltersSelector1 ;
      private string AV46ClienteDocumento1 ;
      private string AV47IntermediadorClienteDocumento1 ;
      private string AV49DynamicFiltersSelector2 ;
      private string AV52ClienteDocumento2 ;
      private string AV53IntermediadorClienteDocumento2 ;
      private string AV55DynamicFiltersSelector3 ;
      private string AV58ClienteDocumento3 ;
      private string AV59IntermediadorClienteDocumento3 ;
      private string AV62Financiamentowwds_1_filterfulltext ;
      private string AV63Financiamentowwds_2_dynamicfiltersselector1 ;
      private string AV66Financiamentowwds_5_clientedocumento1 ;
      private string AV67Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string AV69Financiamentowwds_8_dynamicfiltersselector2 ;
      private string AV72Financiamentowwds_11_clientedocumento2 ;
      private string AV73Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string AV75Financiamentowwds_14_dynamicfiltersselector3 ;
      private string AV78Financiamentowwds_17_clientedocumento3 ;
      private string AV79Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string AV80Financiamentowwds_19_tfclienterazaosocial ;
      private string AV81Financiamentowwds_20_tfclienterazaosocial_sel ;
      private string AV82Financiamentowwds_21_tfclientedocumento ;
      private string AV83Financiamentowwds_22_tfclientedocumento_sel ;
      private string AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ;
      private string AV88Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ;
      private string lV62Financiamentowwds_1_filterfulltext ;
      private string lV66Financiamentowwds_5_clientedocumento1 ;
      private string lV67Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string lV72Financiamentowwds_11_clientedocumento2 ;
      private string lV73Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string lV78Financiamentowwds_17_clientedocumento3 ;
      private string lV79Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string lV80Financiamentowwds_19_tfclienterazaosocial ;
      private string lV82Financiamentowwds_21_tfclientedocumento ;
      private string lV86Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string lV88Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A221IntermediadorClienteRazaoSocial ;
      private string A222IntermediadorClienteDocumento ;
      private string AV25Option ;
      private string AV27OptionDesc ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00742_A168ClienteId ;
      private bool[] P00742_n168ClienteId ;
      private int[] P00742_A220IntermediadorClienteId ;
      private bool[] P00742_n220IntermediadorClienteId ;
      private string[] P00742_A170ClienteRazaoSocial ;
      private bool[] P00742_n170ClienteRazaoSocial ;
      private decimal[] P00742_A224FinanciamentoValor ;
      private bool[] P00742_n224FinanciamentoValor ;
      private string[] P00742_A222IntermediadorClienteDocumento ;
      private bool[] P00742_n222IntermediadorClienteDocumento ;
      private string[] P00742_A221IntermediadorClienteRazaoSocial ;
      private bool[] P00742_n221IntermediadorClienteRazaoSocial ;
      private string[] P00742_A169ClienteDocumento ;
      private bool[] P00742_n169ClienteDocumento ;
      private int[] P00742_A223FinanciamentoId ;
      private int[] P00743_A220IntermediadorClienteId ;
      private bool[] P00743_n220IntermediadorClienteId ;
      private int[] P00743_A168ClienteId ;
      private bool[] P00743_n168ClienteId ;
      private decimal[] P00743_A224FinanciamentoValor ;
      private bool[] P00743_n224FinanciamentoValor ;
      private string[] P00743_A222IntermediadorClienteDocumento ;
      private bool[] P00743_n222IntermediadorClienteDocumento ;
      private string[] P00743_A221IntermediadorClienteRazaoSocial ;
      private bool[] P00743_n221IntermediadorClienteRazaoSocial ;
      private string[] P00743_A169ClienteDocumento ;
      private bool[] P00743_n169ClienteDocumento ;
      private string[] P00743_A170ClienteRazaoSocial ;
      private bool[] P00743_n170ClienteRazaoSocial ;
      private int[] P00743_A223FinanciamentoId ;
      private int[] P00744_A168ClienteId ;
      private bool[] P00744_n168ClienteId ;
      private int[] P00744_A220IntermediadorClienteId ;
      private bool[] P00744_n220IntermediadorClienteId ;
      private string[] P00744_A221IntermediadorClienteRazaoSocial ;
      private bool[] P00744_n221IntermediadorClienteRazaoSocial ;
      private decimal[] P00744_A224FinanciamentoValor ;
      private bool[] P00744_n224FinanciamentoValor ;
      private string[] P00744_A222IntermediadorClienteDocumento ;
      private bool[] P00744_n222IntermediadorClienteDocumento ;
      private string[] P00744_A169ClienteDocumento ;
      private bool[] P00744_n169ClienteDocumento ;
      private string[] P00744_A170ClienteRazaoSocial ;
      private bool[] P00744_n170ClienteRazaoSocial ;
      private int[] P00744_A223FinanciamentoId ;
      private int[] P00745_A168ClienteId ;
      private bool[] P00745_n168ClienteId ;
      private int[] P00745_A220IntermediadorClienteId ;
      private bool[] P00745_n220IntermediadorClienteId ;
      private decimal[] P00745_A224FinanciamentoValor ;
      private bool[] P00745_n224FinanciamentoValor ;
      private string[] P00745_A222IntermediadorClienteDocumento ;
      private bool[] P00745_n222IntermediadorClienteDocumento ;
      private string[] P00745_A221IntermediadorClienteRazaoSocial ;
      private bool[] P00745_n221IntermediadorClienteRazaoSocial ;
      private string[] P00745_A169ClienteDocumento ;
      private bool[] P00745_n169ClienteDocumento ;
      private string[] P00745_A170ClienteRazaoSocial ;
      private bool[] P00745_n170ClienteRazaoSocial ;
      private int[] P00745_A223FinanciamentoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class financiamentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00742( IGxContext context ,
                                             string AV62Financiamentowwds_1_filterfulltext ,
                                             string AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV65Financiamentowwds_4_financiamentovalor1 ,
                                             string AV66Financiamentowwds_5_clientedocumento1 ,
                                             string AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV71Financiamentowwds_10_financiamentovalor2 ,
                                             string AV72Financiamentowwds_11_clientedocumento2 ,
                                             string AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV77Financiamentowwds_16_financiamentovalor3 ,
                                             string AV78Financiamentowwds_17_clientedocumento3 ,
                                             string AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV80Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV82Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV84Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[36];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.IntermediadorClienteId AS IntermediadorClienteId, T2.ClienteRazaoSocial, T1.FinanciamentoValor, T3.ClienteDocumento AS IntermediadorClienteDocumento, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T2.ClienteDocumento, T1.FinanciamentoId FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.IntermediadorClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV80Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV81Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV82Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV83Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV84Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV85Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV86Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV88Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00743( IGxContext context ,
                                             string AV62Financiamentowwds_1_filterfulltext ,
                                             string AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV65Financiamentowwds_4_financiamentovalor1 ,
                                             string AV66Financiamentowwds_5_clientedocumento1 ,
                                             string AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV71Financiamentowwds_10_financiamentovalor2 ,
                                             string AV72Financiamentowwds_11_clientedocumento2 ,
                                             string AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV77Financiamentowwds_16_financiamentovalor3 ,
                                             string AV78Financiamentowwds_17_clientedocumento3 ,
                                             string AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV80Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV82Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV84Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[36];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.IntermediadorClienteId AS IntermediadorClienteId, T1.ClienteId, T1.FinanciamentoValor, T2.ClienteDocumento AS IntermediadorClienteDocumento, T2.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T3.ClienteDocumento, T3.ClienteRazaoSocial, T1.FinanciamentoId FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.IntermediadorClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV80Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV81Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV82Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV83Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV84Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV85Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV86Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV88Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00744( IGxContext context ,
                                             string AV62Financiamentowwds_1_filterfulltext ,
                                             string AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV65Financiamentowwds_4_financiamentovalor1 ,
                                             string AV66Financiamentowwds_5_clientedocumento1 ,
                                             string AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV71Financiamentowwds_10_financiamentovalor2 ,
                                             string AV72Financiamentowwds_11_clientedocumento2 ,
                                             string AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV77Financiamentowwds_16_financiamentovalor3 ,
                                             string AV78Financiamentowwds_17_clientedocumento3 ,
                                             string AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV80Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV82Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV84Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[36];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.IntermediadorClienteId AS IntermediadorClienteId, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T1.FinanciamentoValor, T3.ClienteDocumento AS IntermediadorClienteDocumento, T2.ClienteDocumento, T2.ClienteRazaoSocial, T1.FinanciamentoId FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.IntermediadorClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV80Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV81Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV82Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV83Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV84Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV85Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV86Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV88Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00745( IGxContext context ,
                                             string AV62Financiamentowwds_1_filterfulltext ,
                                             string AV63Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV64Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV65Financiamentowwds_4_financiamentovalor1 ,
                                             string AV66Financiamentowwds_5_clientedocumento1 ,
                                             string AV67Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV68Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV69Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV70Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV71Financiamentowwds_10_financiamentovalor2 ,
                                             string AV72Financiamentowwds_11_clientedocumento2 ,
                                             string AV73Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV74Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV75Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV76Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV77Financiamentowwds_16_financiamentovalor3 ,
                                             string AV78Financiamentowwds_17_clientedocumento3 ,
                                             string AV79Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV81Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV80Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV83Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV82Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV84Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV85Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV86Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV88Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[36];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.IntermediadorClienteId AS IntermediadorClienteId, T1.FinanciamentoValor, T3.ClienteDocumento AS IntermediadorClienteDocumento, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T2.ClienteDocumento, T2.ClienteRazaoSocial, T1.FinanciamentoId FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.IntermediadorClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV62Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV62Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV65Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV66Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV64Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV67Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV71Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV71Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV72Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV68Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV70Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV73Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV77Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV77Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV78Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( AV74Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV76Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV79Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV80Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV81Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( StringUtil.StrCmp(AV81Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV82Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV83Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( StringUtil.StrCmp(AV83Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV84Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV85Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV86Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( StringUtil.StrCmp(AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV88Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( StringUtil.StrCmp(AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.IntermediadorClienteId";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00742(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
               case 1 :
                     return conditional_P00743(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
               case 2 :
                     return conditional_P00744(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
               case 3 :
                     return conditional_P00745(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00742;
          prmP00742 = new Object[] {
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV81Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV83Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV84Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV85Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV86Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV88Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00743;
          prmP00743 = new Object[] {
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV81Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV83Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV84Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV85Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV86Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV88Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00744;
          prmP00744 = new Object[] {
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV81Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV83Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV84Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV85Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV86Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV88Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00745;
          prmP00745 = new Object[] {
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV71Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV73Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV77Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV81Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV83Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV84Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV85Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV86Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV87Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV88Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV89Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00742", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00742,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00743", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00743,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00744", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00744,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00745", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00745,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
