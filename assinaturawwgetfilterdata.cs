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
   public class assinaturawwgetfilterdata : GXProcedure
   {
      public assinaturawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CONTRATONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTRATONOMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV29Session.Get("AssinaturaWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AssinaturaWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("AssinaturaWWGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV10TFContratoNome = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV11TFContratoNome_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFASSINATURASTATUS_SEL") == 0 )
            {
               AV12TFAssinaturaStatus_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV13TFAssinaturaStatus_Sels.FromJSonString(AV12TFAssinaturaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAINICIAL") == 0 )
            {
               AV55TFContratoDataInicial = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV56TFContratoDataInicial_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAFINAL") == 0 )
            {
               AV57TFContratoDataFinal = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV58TFContratoDataFinal_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFASSINATURAFINALIZADODATA") == 0 )
            {
               AV14TFAssinaturaFinalizadoData = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV15TFAssinaturaFinalizadoData_To = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTES_F") == 0 )
            {
               AV16TFAssinaturaParticipantes_F = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV17TFAssinaturaParticipantes_F_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURASTATUS") == 0 )
            {
               AV59AssinaturaStatus = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&VIGENTE") == 0 )
            {
               AV60Vigente = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "ASSINATURASTATUS") == 0 )
            {
               AV43AssinaturaStatus1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV44ContratoNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "ASSINATURASTATUS") == 0 )
               {
                  AV48AssinaturaStatus2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV49ContratoNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV50DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV51DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "ASSINATURASTATUS") == 0 )
                  {
                     AV53AssinaturaStatus3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV52DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV54ContratoNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONTRATONOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFContratoNome = AV18SearchTxt;
         AV11TFContratoNome_Sel = "";
         AV63Assinaturawwds_1_filterfulltext = AV40FilterFullText;
         AV64Assinaturawwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV65Assinaturawwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV66Assinaturawwds_4_assinaturastatus1 = AV43AssinaturaStatus1;
         AV67Assinaturawwds_5_contratonome1 = AV44ContratoNome1;
         AV68Assinaturawwds_6_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV69Assinaturawwds_7_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV70Assinaturawwds_8_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV71Assinaturawwds_9_assinaturastatus2 = AV48AssinaturaStatus2;
         AV72Assinaturawwds_10_contratonome2 = AV49ContratoNome2;
         AV73Assinaturawwds_11_dynamicfiltersenabled3 = AV50DynamicFiltersEnabled3;
         AV74Assinaturawwds_12_dynamicfiltersselector3 = AV51DynamicFiltersSelector3;
         AV75Assinaturawwds_13_dynamicfiltersoperator3 = AV52DynamicFiltersOperator3;
         AV76Assinaturawwds_14_assinaturastatus3 = AV53AssinaturaStatus3;
         AV77Assinaturawwds_15_contratonome3 = AV54ContratoNome3;
         AV78Assinaturawwds_16_tfcontratonome = AV10TFContratoNome;
         AV79Assinaturawwds_17_tfcontratonome_sel = AV11TFContratoNome_Sel;
         AV80Assinaturawwds_18_tfassinaturastatus_sels = AV13TFAssinaturaStatus_Sels;
         AV81Assinaturawwds_19_tfcontratodatainicial = AV55TFContratoDataInicial;
         AV82Assinaturawwds_20_tfcontratodatainicial_to = AV56TFContratoDataInicial_To;
         AV83Assinaturawwds_21_tfcontratodatafinal = AV57TFContratoDataFinal;
         AV84Assinaturawwds_22_tfcontratodatafinal_to = AV58TFContratoDataFinal_To;
         AV85Assinaturawwds_23_tfassinaturafinalizadodata = AV14TFAssinaturaFinalizadoData;
         AV86Assinaturawwds_24_tfassinaturafinalizadodata_to = AV15TFAssinaturaFinalizadoData_To;
         AV87Assinaturawwds_25_tfassinaturaparticipantes_f = AV16TFAssinaturaParticipantes_F;
         AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV17TFAssinaturaParticipantes_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A239AssinaturaStatus ,
                                              AV80Assinaturawwds_18_tfassinaturastatus_sels ,
                                              AV64Assinaturawwds_2_dynamicfiltersselector1 ,
                                              AV66Assinaturawwds_4_assinaturastatus1 ,
                                              AV65Assinaturawwds_3_dynamicfiltersoperator1 ,
                                              AV67Assinaturawwds_5_contratonome1 ,
                                              AV68Assinaturawwds_6_dynamicfiltersenabled2 ,
                                              AV69Assinaturawwds_7_dynamicfiltersselector2 ,
                                              AV71Assinaturawwds_9_assinaturastatus2 ,
                                              AV70Assinaturawwds_8_dynamicfiltersoperator2 ,
                                              AV72Assinaturawwds_10_contratonome2 ,
                                              AV73Assinaturawwds_11_dynamicfiltersenabled3 ,
                                              AV74Assinaturawwds_12_dynamicfiltersselector3 ,
                                              AV76Assinaturawwds_14_assinaturastatus3 ,
                                              AV75Assinaturawwds_13_dynamicfiltersoperator3 ,
                                              AV77Assinaturawwds_15_contratonome3 ,
                                              AV79Assinaturawwds_17_tfcontratonome_sel ,
                                              AV78Assinaturawwds_16_tfcontratonome ,
                                              AV80Assinaturawwds_18_tfassinaturastatus_sels.Count ,
                                              AV81Assinaturawwds_19_tfcontratodatainicial ,
                                              AV82Assinaturawwds_20_tfcontratodatainicial_to ,
                                              AV83Assinaturawwds_21_tfcontratodatafinal ,
                                              AV84Assinaturawwds_22_tfcontratodatafinal_to ,
                                              AV85Assinaturawwds_23_tfassinaturafinalizadodata ,
                                              AV86Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                              AV59AssinaturaStatus ,
                                              A228ContratoNome ,
                                              A362ContratoDataInicial ,
                                              A363ContratoDataFinal ,
                                              A366AssinaturaFinalizadoData ,
                                              AV63Assinaturawwds_1_filterfulltext ,
                                              A367AssinaturaParticipantes_F ,
                                              AV87Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                              AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV63Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Assinaturawwds_1_filterfulltext), "%", "");
         lV67Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV67Assinaturawwds_5_contratonome1), "%", "");
         lV67Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV67Assinaturawwds_5_contratonome1), "%", "");
         lV72Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV72Assinaturawwds_10_contratonome2), "%", "");
         lV72Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV72Assinaturawwds_10_contratonome2), "%", "");
         lV77Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV77Assinaturawwds_15_contratonome3), "%", "");
         lV77Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV77Assinaturawwds_15_contratonome3), "%", "");
         lV78Assinaturawwds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV78Assinaturawwds_16_tfcontratonome), "%", "");
         /* Using cursor P008Z3 */
         pr_default.execute(0, new Object[] {AV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, lV63Assinaturawwds_1_filterfulltext, AV87Assinaturawwds_25_tfassinaturaparticipantes_f, AV87Assinaturawwds_25_tfassinaturaparticipantes_f, AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV66Assinaturawwds_4_assinaturastatus1, lV67Assinaturawwds_5_contratonome1, lV67Assinaturawwds_5_contratonome1, AV71Assinaturawwds_9_assinaturastatus2, lV72Assinaturawwds_10_contratonome2, lV72Assinaturawwds_10_contratonome2, AV76Assinaturawwds_14_assinaturastatus3, lV77Assinaturawwds_15_contratonome3, lV77Assinaturawwds_15_contratonome3, lV78Assinaturawwds_16_tfcontratonome, AV79Assinaturawwds_17_tfcontratonome_sel, AV81Assinaturawwds_19_tfcontratodatainicial, AV82Assinaturawwds_20_tfcontratodatainicial_to, AV83Assinaturawwds_21_tfcontratodatafinal, AV84Assinaturawwds_22_tfcontratodatafinal_to, AV85Assinaturawwds_23_tfassinaturafinalizadodata, AV86Assinaturawwds_24_tfassinaturafinalizadodata_to, AV59AssinaturaStatus});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8Z2 = false;
            A238AssinaturaId = P008Z3_A238AssinaturaId[0];
            n238AssinaturaId = P008Z3_n238AssinaturaId[0];
            A227ContratoId = P008Z3_A227ContratoId[0];
            n227ContratoId = P008Z3_n227ContratoId[0];
            A366AssinaturaFinalizadoData = P008Z3_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = P008Z3_n366AssinaturaFinalizadoData[0];
            A363ContratoDataFinal = P008Z3_A363ContratoDataFinal[0];
            n363ContratoDataFinal = P008Z3_n363ContratoDataFinal[0];
            A362ContratoDataInicial = P008Z3_A362ContratoDataInicial[0];
            n362ContratoDataInicial = P008Z3_n362ContratoDataInicial[0];
            A239AssinaturaStatus = P008Z3_A239AssinaturaStatus[0];
            n239AssinaturaStatus = P008Z3_n239AssinaturaStatus[0];
            A228ContratoNome = P008Z3_A228ContratoNome[0];
            n228ContratoNome = P008Z3_n228ContratoNome[0];
            A367AssinaturaParticipantes_F = P008Z3_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = P008Z3_n367AssinaturaParticipantes_F[0];
            A367AssinaturaParticipantes_F = P008Z3_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = P008Z3_n367AssinaturaParticipantes_F[0];
            A363ContratoDataFinal = P008Z3_A363ContratoDataFinal[0];
            n363ContratoDataFinal = P008Z3_n363ContratoDataFinal[0];
            A362ContratoDataInicial = P008Z3_A362ContratoDataInicial[0];
            n362ContratoDataInicial = P008Z3_n362ContratoDataInicial[0];
            A228ContratoNome = P008Z3_A228ContratoNome[0];
            n228ContratoNome = P008Z3_n228ContratoNome[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P008Z3_A227ContratoId[0] == A227ContratoId ) )
            {
               BRK8Z2 = false;
               A238AssinaturaId = P008Z3_A238AssinaturaId[0];
               n238AssinaturaId = P008Z3_n238AssinaturaId[0];
               AV28count = (long)(AV28count+1);
               BRK8Z2 = true;
               pr_default.readNext(0);
            }
            AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? "<#Empty#>" : A228ContratoNome);
            AV22InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV23Option, "<#Empty#>") != 0 ) && ( AV22InsertIndex <= AV24Options.Count ) && ( ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), AV23Option) < 0 ) || ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV22InsertIndex = (int)(AV22InsertIndex+1);
            }
            AV24Options.Add(AV23Option, AV22InsertIndex);
            AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), AV22InsertIndex);
            if ( AV24Options.Count == AV19SkipItems + 11 )
            {
               AV24Options.RemoveItem(AV24Options.Count);
               AV27OptionIndexes.RemoveItem(AV27OptionIndexes.Count);
            }
            if ( ! BRK8Z2 )
            {
               BRK8Z2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV19SkipItems > 0 )
         {
            AV24Options.RemoveItem(1);
            AV27OptionIndexes.RemoveItem(1);
            AV19SkipItems = (short)(AV19SkipItems-1);
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
         AV10TFContratoNome = "";
         AV11TFContratoNome_Sel = "";
         AV12TFAssinaturaStatus_SelsJson = "";
         AV13TFAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV55TFContratoDataInicial = DateTime.MinValue;
         AV56TFContratoDataInicial_To = DateTime.MinValue;
         AV57TFContratoDataFinal = DateTime.MinValue;
         AV58TFContratoDataFinal_To = DateTime.MinValue;
         AV14TFAssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         AV15TFAssinaturaFinalizadoData_To = (DateTime)(DateTime.MinValue);
         AV59AssinaturaStatus = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43AssinaturaStatus1 = "";
         AV44ContratoNome1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48AssinaturaStatus2 = "";
         AV49ContratoNome2 = "";
         AV51DynamicFiltersSelector3 = "";
         AV53AssinaturaStatus3 = "";
         AV54ContratoNome3 = "";
         AV63Assinaturawwds_1_filterfulltext = "";
         AV64Assinaturawwds_2_dynamicfiltersselector1 = "";
         AV66Assinaturawwds_4_assinaturastatus1 = "";
         AV67Assinaturawwds_5_contratonome1 = "";
         AV69Assinaturawwds_7_dynamicfiltersselector2 = "";
         AV71Assinaturawwds_9_assinaturastatus2 = "";
         AV72Assinaturawwds_10_contratonome2 = "";
         AV74Assinaturawwds_12_dynamicfiltersselector3 = "";
         AV76Assinaturawwds_14_assinaturastatus3 = "";
         AV77Assinaturawwds_15_contratonome3 = "";
         AV78Assinaturawwds_16_tfcontratonome = "";
         AV79Assinaturawwds_17_tfcontratonome_sel = "";
         AV80Assinaturawwds_18_tfassinaturastatus_sels = new GxSimpleCollection<string>();
         AV81Assinaturawwds_19_tfcontratodatainicial = DateTime.MinValue;
         AV82Assinaturawwds_20_tfcontratodatainicial_to = DateTime.MinValue;
         AV83Assinaturawwds_21_tfcontratodatafinal = DateTime.MinValue;
         AV84Assinaturawwds_22_tfcontratodatafinal_to = DateTime.MinValue;
         AV85Assinaturawwds_23_tfassinaturafinalizadodata = (DateTime)(DateTime.MinValue);
         AV86Assinaturawwds_24_tfassinaturafinalizadodata_to = (DateTime)(DateTime.MinValue);
         lV63Assinaturawwds_1_filterfulltext = "";
         lV67Assinaturawwds_5_contratonome1 = "";
         lV72Assinaturawwds_10_contratonome2 = "";
         lV77Assinaturawwds_15_contratonome3 = "";
         lV78Assinaturawwds_16_tfcontratonome = "";
         A239AssinaturaStatus = "";
         A228ContratoNome = "";
         A362ContratoDataInicial = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         P008Z3_A238AssinaturaId = new long[1] ;
         P008Z3_n238AssinaturaId = new bool[] {false} ;
         P008Z3_A227ContratoId = new int[1] ;
         P008Z3_n227ContratoId = new bool[] {false} ;
         P008Z3_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         P008Z3_n366AssinaturaFinalizadoData = new bool[] {false} ;
         P008Z3_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         P008Z3_n363ContratoDataFinal = new bool[] {false} ;
         P008Z3_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         P008Z3_n362ContratoDataInicial = new bool[] {false} ;
         P008Z3_A239AssinaturaStatus = new string[] {""} ;
         P008Z3_n239AssinaturaStatus = new bool[] {false} ;
         P008Z3_A228ContratoNome = new string[] {""} ;
         P008Z3_n228ContratoNome = new bool[] {false} ;
         P008Z3_A367AssinaturaParticipantes_F = new short[1] ;
         P008Z3_n367AssinaturaParticipantes_F = new bool[] {false} ;
         AV23Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008Z3_A238AssinaturaId, P008Z3_A227ContratoId, P008Z3_n227ContratoId, P008Z3_A366AssinaturaFinalizadoData, P008Z3_n366AssinaturaFinalizadoData, P008Z3_A363ContratoDataFinal, P008Z3_n363ContratoDataFinal, P008Z3_A362ContratoDataInicial, P008Z3_n362ContratoDataInicial, P008Z3_A239AssinaturaStatus,
               P008Z3_n239AssinaturaStatus, P008Z3_A228ContratoNome, P008Z3_n228ContratoNome, P008Z3_A367AssinaturaParticipantes_F, P008Z3_n367AssinaturaParticipantes_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV16TFAssinaturaParticipantes_F ;
      private short AV17TFAssinaturaParticipantes_F_To ;
      private short AV60Vigente ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV52DynamicFiltersOperator3 ;
      private short AV65Assinaturawwds_3_dynamicfiltersoperator1 ;
      private short AV70Assinaturawwds_8_dynamicfiltersoperator2 ;
      private short AV75Assinaturawwds_13_dynamicfiltersoperator3 ;
      private short AV87Assinaturawwds_25_tfassinaturaparticipantes_f ;
      private short AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to ;
      private short A367AssinaturaParticipantes_F ;
      private int AV61GXV1 ;
      private int AV80Assinaturawwds_18_tfassinaturastatus_sels_Count ;
      private int A227ContratoId ;
      private int AV22InsertIndex ;
      private long A238AssinaturaId ;
      private long AV28count ;
      private DateTime AV14TFAssinaturaFinalizadoData ;
      private DateTime AV15TFAssinaturaFinalizadoData_To ;
      private DateTime AV85Assinaturawwds_23_tfassinaturafinalizadodata ;
      private DateTime AV86Assinaturawwds_24_tfassinaturafinalizadodata_to ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime AV55TFContratoDataInicial ;
      private DateTime AV56TFContratoDataInicial_To ;
      private DateTime AV57TFContratoDataFinal ;
      private DateTime AV58TFContratoDataFinal_To ;
      private DateTime AV81Assinaturawwds_19_tfcontratodatainicial ;
      private DateTime AV82Assinaturawwds_20_tfcontratodatainicial_to ;
      private DateTime AV83Assinaturawwds_21_tfcontratodatafinal ;
      private DateTime AV84Assinaturawwds_22_tfcontratodatafinal_to ;
      private DateTime A362ContratoDataInicial ;
      private DateTime A363ContratoDataFinal ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV50DynamicFiltersEnabled3 ;
      private bool AV68Assinaturawwds_6_dynamicfiltersenabled2 ;
      private bool AV73Assinaturawwds_11_dynamicfiltersenabled3 ;
      private bool BRK8Z2 ;
      private bool n238AssinaturaId ;
      private bool n227ContratoId ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n363ContratoDataFinal ;
      private bool n362ContratoDataInicial ;
      private bool n239AssinaturaStatus ;
      private bool n228ContratoNome ;
      private bool n367AssinaturaParticipantes_F ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV12TFAssinaturaStatus_SelsJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV10TFContratoNome ;
      private string AV11TFContratoNome_Sel ;
      private string AV59AssinaturaStatus ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV43AssinaturaStatus1 ;
      private string AV44ContratoNome1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV48AssinaturaStatus2 ;
      private string AV49ContratoNome2 ;
      private string AV51DynamicFiltersSelector3 ;
      private string AV53AssinaturaStatus3 ;
      private string AV54ContratoNome3 ;
      private string AV63Assinaturawwds_1_filterfulltext ;
      private string AV64Assinaturawwds_2_dynamicfiltersselector1 ;
      private string AV66Assinaturawwds_4_assinaturastatus1 ;
      private string AV67Assinaturawwds_5_contratonome1 ;
      private string AV69Assinaturawwds_7_dynamicfiltersselector2 ;
      private string AV71Assinaturawwds_9_assinaturastatus2 ;
      private string AV72Assinaturawwds_10_contratonome2 ;
      private string AV74Assinaturawwds_12_dynamicfiltersselector3 ;
      private string AV76Assinaturawwds_14_assinaturastatus3 ;
      private string AV77Assinaturawwds_15_contratonome3 ;
      private string AV78Assinaturawwds_16_tfcontratonome ;
      private string AV79Assinaturawwds_17_tfcontratonome_sel ;
      private string lV63Assinaturawwds_1_filterfulltext ;
      private string lV67Assinaturawwds_5_contratonome1 ;
      private string lV72Assinaturawwds_10_contratonome2 ;
      private string lV77Assinaturawwds_15_contratonome3 ;
      private string lV78Assinaturawwds_16_tfcontratonome ;
      private string A239AssinaturaStatus ;
      private string A228ContratoNome ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GxSimpleCollection<string> AV13TFAssinaturaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV80Assinaturawwds_18_tfassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P008Z3_A238AssinaturaId ;
      private bool[] P008Z3_n238AssinaturaId ;
      private int[] P008Z3_A227ContratoId ;
      private bool[] P008Z3_n227ContratoId ;
      private DateTime[] P008Z3_A366AssinaturaFinalizadoData ;
      private bool[] P008Z3_n366AssinaturaFinalizadoData ;
      private DateTime[] P008Z3_A363ContratoDataFinal ;
      private bool[] P008Z3_n363ContratoDataFinal ;
      private DateTime[] P008Z3_A362ContratoDataInicial ;
      private bool[] P008Z3_n362ContratoDataInicial ;
      private string[] P008Z3_A239AssinaturaStatus ;
      private bool[] P008Z3_n239AssinaturaStatus ;
      private string[] P008Z3_A228ContratoNome ;
      private bool[] P008Z3_n228ContratoNome ;
      private short[] P008Z3_A367AssinaturaParticipantes_F ;
      private bool[] P008Z3_n367AssinaturaParticipantes_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class assinaturawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008Z3( IGxContext context ,
                                             string A239AssinaturaStatus ,
                                             GxSimpleCollection<string> AV80Assinaturawwds_18_tfassinaturastatus_sels ,
                                             string AV64Assinaturawwds_2_dynamicfiltersselector1 ,
                                             string AV66Assinaturawwds_4_assinaturastatus1 ,
                                             short AV65Assinaturawwds_3_dynamicfiltersoperator1 ,
                                             string AV67Assinaturawwds_5_contratonome1 ,
                                             bool AV68Assinaturawwds_6_dynamicfiltersenabled2 ,
                                             string AV69Assinaturawwds_7_dynamicfiltersselector2 ,
                                             string AV71Assinaturawwds_9_assinaturastatus2 ,
                                             short AV70Assinaturawwds_8_dynamicfiltersoperator2 ,
                                             string AV72Assinaturawwds_10_contratonome2 ,
                                             bool AV73Assinaturawwds_11_dynamicfiltersenabled3 ,
                                             string AV74Assinaturawwds_12_dynamicfiltersselector3 ,
                                             string AV76Assinaturawwds_14_assinaturastatus3 ,
                                             short AV75Assinaturawwds_13_dynamicfiltersoperator3 ,
                                             string AV77Assinaturawwds_15_contratonome3 ,
                                             string AV79Assinaturawwds_17_tfcontratonome_sel ,
                                             string AV78Assinaturawwds_16_tfcontratonome ,
                                             int AV80Assinaturawwds_18_tfassinaturastatus_sels_Count ,
                                             DateTime AV81Assinaturawwds_19_tfcontratodatainicial ,
                                             DateTime AV82Assinaturawwds_20_tfcontratodatainicial_to ,
                                             DateTime AV83Assinaturawwds_21_tfcontratodatafinal ,
                                             DateTime AV84Assinaturawwds_22_tfcontratodatafinal_to ,
                                             DateTime AV85Assinaturawwds_23_tfassinaturafinalizadodata ,
                                             DateTime AV86Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                             string AV59AssinaturaStatus ,
                                             string A228ContratoNome ,
                                             DateTime A362ContratoDataInicial ,
                                             DateTime A363ContratoDataFinal ,
                                             DateTime A366AssinaturaFinalizadoData ,
                                             string AV63Assinaturawwds_1_filterfulltext ,
                                             short A367AssinaturaParticipantes_F ,
                                             short AV87Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                             short AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[30];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.AssinaturaId, T1.ContratoId, T1.AssinaturaFinalizadoData, T3.ContratoDataFinal, T3.ContratoDataInicial, T1.AssinaturaStatus, T3.ContratoNome, COALESCE( T2.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM ((Assinatura T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE T1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T2 ON T2.AssinaturaId = T1.AssinaturaId) LEFT JOIN Contrato T3 ON T3.ContratoId = T1.ContratoId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV63Assinaturawwds_1_filterfulltext))=0) or ( ( T3.ContratoNome like '%' || :lV63Assinaturawwds_1_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV63Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV63Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV63Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV63Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV63Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')) or ( SUBSTR(TO_CHAR(COALESCE( T2.AssinaturaParticipantes_F, 0),'9999'), 2) like '%' || :lV63Assinaturawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV87Assinaturawwds_25_tfassinaturaparticipantes_f = 0) or ( COALESCE( T2.AssinaturaParticipantes_F, 0) >= :AV87Assinaturawwds_25_tfassinaturaparticipantes_f))");
         AddWhere(sWhereString, "((:AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to = 0) or ( COALESCE( T2.AssinaturaParticipantes_F, 0) <= :AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to))");
         if ( ( StringUtil.StrCmp(AV64Assinaturawwds_2_dynamicfiltersselector1, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Assinaturawwds_4_assinaturastatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV66Assinaturawwds_4_assinaturastatus1))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV65Assinaturawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV67Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV65Assinaturawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like '%' || :lV67Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV68Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Assinaturawwds_7_dynamicfiltersselector2, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Assinaturawwds_9_assinaturastatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV71Assinaturawwds_9_assinaturastatus2))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV68Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV70Assinaturawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV72Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV68Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV70Assinaturawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like '%' || :lV72Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV73Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Assinaturawwds_12_dynamicfiltersselector3, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Assinaturawwds_14_assinaturastatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV76Assinaturawwds_14_assinaturastatus3))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV73Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV75Assinaturawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV77Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV73Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV75Assinaturawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like '%' || :lV77Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Assinaturawwds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Assinaturawwds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV78Assinaturawwds_16_tfcontratonome)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Assinaturawwds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV79Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome = ( :AV79Assinaturawwds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV79Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T3.ContratoNome))=0))");
         }
         if ( AV80Assinaturawwds_18_tfassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80Assinaturawwds_18_tfassinaturastatus_sels, "T1.AssinaturaStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV81Assinaturawwds_19_tfcontratodatainicial) )
         {
            AddWhere(sWhereString, "(T3.ContratoDataInicial >= :AV81Assinaturawwds_19_tfcontratodatainicial)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Assinaturawwds_20_tfcontratodatainicial_to) )
         {
            AddWhere(sWhereString, "(T3.ContratoDataInicial <= :AV82Assinaturawwds_20_tfcontratodatainicial_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Assinaturawwds_21_tfcontratodatafinal) )
         {
            AddWhere(sWhereString, "(T3.ContratoDataFinal >= :AV83Assinaturawwds_21_tfcontratodatafinal)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Assinaturawwds_22_tfcontratodatafinal_to) )
         {
            AddWhere(sWhereString, "(T3.ContratoDataFinal <= :AV84Assinaturawwds_22_tfcontratodatafinal_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Assinaturawwds_23_tfassinaturafinalizadodata) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData >= :AV85Assinaturawwds_23_tfassinaturafinalizadodata)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Assinaturawwds_24_tfassinaturafinalizadodata_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData <= :AV86Assinaturawwds_24_tfassinaturafinalizadodata_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59AssinaturaStatus)) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV59AssinaturaStatus))");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoId";
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
                     return conditional_P008Z3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] );
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
          Object[] prmP008Z3;
          prmP008Z3 = new Object[] {
          new ParDef("AV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV87Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV87Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV88Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV66Assinaturawwds_4_assinaturastatus1",GXType.VarChar,40,0) ,
          new ParDef("lV67Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV67Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("AV71Assinaturawwds_9_assinaturastatus2",GXType.VarChar,40,0) ,
          new ParDef("lV72Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV72Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("AV76Assinaturawwds_14_assinaturastatus3",GXType.VarChar,40,0) ,
          new ParDef("lV77Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV77Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV78Assinaturawwds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV79Assinaturawwds_17_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV81Assinaturawwds_19_tfcontratodatainicial",GXType.Date,8,0) ,
          new ParDef("AV82Assinaturawwds_20_tfcontratodatainicial_to",GXType.Date,8,0) ,
          new ParDef("AV83Assinaturawwds_21_tfcontratodatafinal",GXType.Date,8,0) ,
          new ParDef("AV84Assinaturawwds_22_tfcontratodatafinal_to",GXType.Date,8,0) ,
          new ParDef("AV85Assinaturawwds_23_tfassinaturafinalizadodata",GXType.DateTime,8,5) ,
          new ParDef("AV86Assinaturawwds_24_tfassinaturafinalizadodata_to",GXType.DateTime,8,5) ,
          new ParDef("AV59AssinaturaStatus",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z3,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
