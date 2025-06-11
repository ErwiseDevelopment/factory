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
   public class operacoestituloswwgetfilterdata : GXProcedure
   {
      public operacoestituloswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoestituloswwgetfilterdata( IGxContext context )
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
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV53OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV38Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35MaxItems = 10;
         AV34PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV49SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV32SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? "" : StringUtil.Substring( AV49SearchTxtParms, 3, -1));
         AV33SkipItems = (short)(AV34PageIndex*AV35MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_SACADORAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADSACADORAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV51OptionsJson = AV38Options.ToJSonString(false);
         AV52OptionsDescJson = AV40OptionsDesc.ToJSonString(false);
         AV53OptionIndexesJson = AV41OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get("OperacoesTitulosWWGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacoesTitulosWWGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("OperacoesTitulosWWGridState"), null, "", "");
         }
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV65GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV54FilterFullText = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSACADORAZAOSOCIAL") == 0 )
            {
               AV10TFSacadoRazaoSocial = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSACADORAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFSacadoRazaoSocial_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSTIPO_SEL") == 0 )
            {
               AV12TFOperacoesTitulosTipo_SelsJson = AV46GridStateFilterValue.gxTpr_Value;
               AV13TFOperacoesTitulosTipo_Sels.FromJSonString(AV12TFOperacoesTitulosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSNUMERO") == 0 )
            {
               AV14TFOperacoesTitulosNumero = (int)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV15TFOperacoesTitulosNumero_To = (int)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSDATAEMISSAO") == 0 )
            {
               AV16TFOperacoesTitulosDataEmissao = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, 4);
               AV17TFOperacoesTitulosDataEmissao_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSDATAVENCIMENTO") == 0 )
            {
               AV18TFOperacoesTitulosDataVencimento = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, 4);
               AV19TFOperacoesTitulosDataVencimento_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSVALOR") == 0 )
            {
               AV20TFOperacoesTitulosValor = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV21TFOperacoesTitulosValor_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSLIQUIDO") == 0 )
            {
               AV22TFOperacoesTitulosLiquido = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV23TFOperacoesTitulosLiquido_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSTAXA") == 0 )
            {
               AV24TFOperacoesTitulosTaxa = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV25TFOperacoesTitulosTaxa_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSSTATUS_SEL") == 0 )
            {
               AV26TFOperacoesTitulosStatus_SelsJson = AV46GridStateFilterValue.gxTpr_Value;
               AV27TFOperacoesTitulosStatus_Sels.FromJSonString(AV26TFOperacoesTitulosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSCREATEDAT") == 0 )
            {
               AV28TFOperacoesTitulosCreatedAt = context.localUtil.CToT( AV46GridStateFilterValue.gxTpr_Value, 4);
               AV29TFOperacoesTitulosCreatedAt_To = context.localUtil.CToT( AV46GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSUPDATEDAT") == 0 )
            {
               AV30TFOperacoesTitulosUpdatedAt = context.localUtil.CToT( AV46GridStateFilterValue.gxTpr_Value, 4);
               AV31TFOperacoesTitulosUpdatedAt_To = context.localUtil.CToT( AV46GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "PARM_&OPERACOESID") == 0 )
            {
               AV63OperacoesId = (int)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "PARM_&TRNMODE") == 0 )
            {
               AV64TrnMode = AV46GridStateFilterValue.gxTpr_Value;
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
         if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(1));
            AV55DynamicFiltersSelector1 = AV47GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV55DynamicFiltersSelector1, "OPERACOESTITULOSTIPO") == 0 )
            {
               AV56OperacoesTitulosTipo1 = AV47GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV57DynamicFiltersEnabled2 = true;
               AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(2));
               AV58DynamicFiltersSelector2 = AV47GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "OPERACOESTITULOSTIPO") == 0 )
               {
                  AV59OperacoesTitulosTipo2 = AV47GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV60DynamicFiltersEnabled3 = true;
                  AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(3));
                  AV61DynamicFiltersSelector3 = AV47GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV61DynamicFiltersSelector3, "OPERACOESTITULOSTIPO") == 0 )
                  {
                     AV62OperacoesTitulosTipo3 = AV47GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSACADORAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFSacadoRazaoSocial = AV32SearchTxt;
         AV11TFSacadoRazaoSocial_Sel = "";
         AV67Operacoestituloswwds_1_operacoesid = AV63OperacoesId;
         AV68Operacoestituloswwds_2_filterfulltext = AV54FilterFullText;
         AV69Operacoestituloswwds_3_dynamicfiltersselector1 = AV55DynamicFiltersSelector1;
         AV70Operacoestituloswwds_4_operacoestitulostipo1 = AV56OperacoesTitulosTipo1;
         AV71Operacoestituloswwds_5_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV72Operacoestituloswwds_6_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV73Operacoestituloswwds_7_operacoestitulostipo2 = AV59OperacoesTitulosTipo2;
         AV74Operacoestituloswwds_8_dynamicfiltersenabled3 = AV60DynamicFiltersEnabled3;
         AV75Operacoestituloswwds_9_dynamicfiltersselector3 = AV61DynamicFiltersSelector3;
         AV76Operacoestituloswwds_10_operacoestitulostipo3 = AV62OperacoesTitulosTipo3;
         AV77Operacoestituloswwds_11_tfsacadorazaosocial = AV10TFSacadoRazaoSocial;
         AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV11TFSacadoRazaoSocial_Sel;
         AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV13TFOperacoesTitulosTipo_Sels;
         AV80Operacoestituloswwds_14_tfoperacoestitulosnumero = AV14TFOperacoesTitulosNumero;
         AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV15TFOperacoesTitulosNumero_To;
         AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV16TFOperacoesTitulosDataEmissao;
         AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV17TFOperacoesTitulosDataEmissao_To;
         AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV18TFOperacoesTitulosDataVencimento;
         AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV19TFOperacoesTitulosDataVencimento_To;
         AV86Operacoestituloswwds_20_tfoperacoestitulosvalor = AV20TFOperacoesTitulosValor;
         AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV21TFOperacoesTitulosValor_To;
         AV88Operacoestituloswwds_22_tfoperacoestitulosliquido = AV22TFOperacoesTitulosLiquido;
         AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV23TFOperacoesTitulosLiquido_To;
         AV90Operacoestituloswwds_24_tfoperacoestitulostaxa = AV24TFOperacoesTitulosTaxa;
         AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV25TFOperacoesTitulosTaxa_To;
         AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV27TFOperacoesTitulosStatus_Sels;
         AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV28TFOperacoesTitulosCreatedAt;
         AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV29TFOperacoesTitulosCreatedAt_To;
         AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV30TFOperacoesTitulosUpdatedAt;
         AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV31TFOperacoesTitulosUpdatedAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1020OperacoesTitulosTipo ,
                                              AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                              A1027OperacoesTitulosStatus ,
                                              AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                              AV68Operacoestituloswwds_2_filterfulltext ,
                                              AV69Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                              AV70Operacoestituloswwds_4_operacoestitulostipo1 ,
                                              AV71Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                              AV72Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                              AV73Operacoestituloswwds_7_operacoestitulostipo2 ,
                                              AV74Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                              AV75Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                              AV76Operacoestituloswwds_10_operacoestitulostipo3 ,
                                              AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                              AV77Operacoestituloswwds_11_tfsacadorazaosocial ,
                                              AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels.Count ,
                                              AV80Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                              AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                              AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                              AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                              AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                              AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                              AV86Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                              AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                              AV88Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                              AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                              AV90Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                              AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                              AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels.Count ,
                                              AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                              AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                              AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                              AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                              A1035SacadoRazaoSocial ,
                                              A1021OperacoesTitulosNumero ,
                                              A1024OperacoesTitulosValor ,
                                              A1025OperacoesTitulosLiquido ,
                                              A1026OperacoesTitulosTaxa ,
                                              A1022OperacoesTitulosDataEmissao ,
                                              A1023OperacoesTitulosDataVencimento ,
                                              A1028OperacoesTitulosCreatedAt ,
                                              A1029OperacoesTitulosUpdatedAt ,
                                              AV67Operacoestituloswwds_1_operacoesid ,
                                              A1010OperacoesId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV68Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext), "%", "");
         lV77Operacoestituloswwds_11_tfsacadorazaosocial = StringUtil.Concat( StringUtil.RTrim( AV77Operacoestituloswwds_11_tfsacadorazaosocial), "%", "");
         /* Using cursor P00F82 */
         pr_default.execute(0, new Object[] {AV67Operacoestituloswwds_1_operacoesid, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, lV68Operacoestituloswwds_2_filterfulltext, AV70Operacoestituloswwds_4_operacoestitulostipo1, AV73Operacoestituloswwds_7_operacoestitulostipo2, AV76Operacoestituloswwds_10_operacoestitulostipo3, lV77Operacoestituloswwds_11_tfsacadorazaosocial, AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel, AV80Operacoestituloswwds_14_tfoperacoestitulosnumero, AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to, AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao, AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to, AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento, AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to, AV86Operacoestituloswwds_20_tfoperacoestitulosvalor, AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to, AV88Operacoestituloswwds_22_tfoperacoestitulosliquido, AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to, AV90Operacoestituloswwds_24_tfoperacoestitulostaxa, AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to, AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat, AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to, AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat, AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKF82 = false;
            A1034SacadoId = P00F82_A1034SacadoId[0];
            n1034SacadoId = P00F82_n1034SacadoId[0];
            A1010OperacoesId = P00F82_A1010OperacoesId[0];
            n1010OperacoesId = P00F82_n1010OperacoesId[0];
            A1035SacadoRazaoSocial = P00F82_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = P00F82_n1035SacadoRazaoSocial[0];
            A1029OperacoesTitulosUpdatedAt = P00F82_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = P00F82_n1029OperacoesTitulosUpdatedAt[0];
            A1028OperacoesTitulosCreatedAt = P00F82_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = P00F82_n1028OperacoesTitulosCreatedAt[0];
            A1026OperacoesTitulosTaxa = P00F82_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = P00F82_n1026OperacoesTitulosTaxa[0];
            A1025OperacoesTitulosLiquido = P00F82_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = P00F82_n1025OperacoesTitulosLiquido[0];
            A1024OperacoesTitulosValor = P00F82_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = P00F82_n1024OperacoesTitulosValor[0];
            A1023OperacoesTitulosDataVencimento = P00F82_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = P00F82_n1023OperacoesTitulosDataVencimento[0];
            A1022OperacoesTitulosDataEmissao = P00F82_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = P00F82_n1022OperacoesTitulosDataEmissao[0];
            A1021OperacoesTitulosNumero = P00F82_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = P00F82_n1021OperacoesTitulosNumero[0];
            A1027OperacoesTitulosStatus = P00F82_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = P00F82_n1027OperacoesTitulosStatus[0];
            A1020OperacoesTitulosTipo = P00F82_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = P00F82_n1020OperacoesTitulosTipo[0];
            A1019OperacoesTitulosId = P00F82_A1019OperacoesTitulosId[0];
            A1035SacadoRazaoSocial = P00F82_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = P00F82_n1035SacadoRazaoSocial[0];
            AV42count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00F82_A1010OperacoesId[0] == A1010OperacoesId ) && ( StringUtil.StrCmp(P00F82_A1035SacadoRazaoSocial[0], A1035SacadoRazaoSocial) == 0 ) )
            {
               BRKF82 = false;
               A1034SacadoId = P00F82_A1034SacadoId[0];
               n1034SacadoId = P00F82_n1034SacadoId[0];
               A1019OperacoesTitulosId = P00F82_A1019OperacoesTitulosId[0];
               AV42count = (long)(AV42count+1);
               BRKF82 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV33SkipItems) )
            {
               AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1035SacadoRazaoSocial)) ? "<#Empty#>" : A1035SacadoRazaoSocial);
               AV38Options.Add(AV37Option, 0);
               AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV38Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV33SkipItems = (short)(AV33SkipItems-1);
            }
            if ( ! BRKF82 )
            {
               BRKF82 = true;
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
         AV51OptionsJson = "";
         AV52OptionsDescJson = "";
         AV53OptionIndexesJson = "";
         AV38Options = new GxSimpleCollection<string>();
         AV40OptionsDesc = new GxSimpleCollection<string>();
         AV41OptionIndexes = new GxSimpleCollection<string>();
         AV32SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV45GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV46GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54FilterFullText = "";
         AV10TFSacadoRazaoSocial = "";
         AV11TFSacadoRazaoSocial_Sel = "";
         AV12TFOperacoesTitulosTipo_SelsJson = "";
         AV13TFOperacoesTitulosTipo_Sels = new GxSimpleCollection<string>();
         AV16TFOperacoesTitulosDataEmissao = DateTime.MinValue;
         AV17TFOperacoesTitulosDataEmissao_To = DateTime.MinValue;
         AV18TFOperacoesTitulosDataVencimento = DateTime.MinValue;
         AV19TFOperacoesTitulosDataVencimento_To = DateTime.MinValue;
         AV26TFOperacoesTitulosStatus_SelsJson = "";
         AV27TFOperacoesTitulosStatus_Sels = new GxSimpleCollection<string>();
         AV28TFOperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         AV29TFOperacoesTitulosCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV30TFOperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         AV31TFOperacoesTitulosUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV64TrnMode = "";
         AV47GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV55DynamicFiltersSelector1 = "";
         AV56OperacoesTitulosTipo1 = "";
         AV58DynamicFiltersSelector2 = "";
         AV59OperacoesTitulosTipo2 = "";
         AV61DynamicFiltersSelector3 = "";
         AV62OperacoesTitulosTipo3 = "";
         AV68Operacoestituloswwds_2_filterfulltext = "";
         AV69Operacoestituloswwds_3_dynamicfiltersselector1 = "";
         AV70Operacoestituloswwds_4_operacoestitulostipo1 = "";
         AV72Operacoestituloswwds_6_dynamicfiltersselector2 = "";
         AV73Operacoestituloswwds_7_operacoestitulostipo2 = "";
         AV75Operacoestituloswwds_9_dynamicfiltersselector3 = "";
         AV76Operacoestituloswwds_10_operacoestitulostipo3 = "";
         AV77Operacoestituloswwds_11_tfsacadorazaosocial = "";
         AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel = "";
         AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels = new GxSimpleCollection<string>();
         AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao = DateTime.MinValue;
         AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = DateTime.MinValue;
         AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = DateTime.MinValue;
         AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = DateTime.MinValue;
         AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = new GxSimpleCollection<string>();
         AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat = (DateTime)(DateTime.MinValue);
         AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = (DateTime)(DateTime.MinValue);
         AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat = (DateTime)(DateTime.MinValue);
         AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = (DateTime)(DateTime.MinValue);
         lV68Operacoestituloswwds_2_filterfulltext = "";
         lV77Operacoestituloswwds_11_tfsacadorazaosocial = "";
         A1020OperacoesTitulosTipo = "";
         A1027OperacoesTitulosStatus = "";
         A1035SacadoRazaoSocial = "";
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         P00F82_A1034SacadoId = new int[1] ;
         P00F82_n1034SacadoId = new bool[] {false} ;
         P00F82_A1010OperacoesId = new int[1] ;
         P00F82_n1010OperacoesId = new bool[] {false} ;
         P00F82_A1035SacadoRazaoSocial = new string[] {""} ;
         P00F82_n1035SacadoRazaoSocial = new bool[] {false} ;
         P00F82_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F82_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         P00F82_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F82_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         P00F82_A1026OperacoesTitulosTaxa = new decimal[1] ;
         P00F82_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         P00F82_A1025OperacoesTitulosLiquido = new decimal[1] ;
         P00F82_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         P00F82_A1024OperacoesTitulosValor = new decimal[1] ;
         P00F82_n1024OperacoesTitulosValor = new bool[] {false} ;
         P00F82_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00F82_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         P00F82_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00F82_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         P00F82_A1021OperacoesTitulosNumero = new int[1] ;
         P00F82_n1021OperacoesTitulosNumero = new bool[] {false} ;
         P00F82_A1027OperacoesTitulosStatus = new string[] {""} ;
         P00F82_n1027OperacoesTitulosStatus = new bool[] {false} ;
         P00F82_A1020OperacoesTitulosTipo = new string[] {""} ;
         P00F82_n1020OperacoesTitulosTipo = new bool[] {false} ;
         P00F82_A1019OperacoesTitulosId = new int[1] ;
         AV37Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoestituloswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00F82_A1034SacadoId, P00F82_n1034SacadoId, P00F82_A1010OperacoesId, P00F82_n1010OperacoesId, P00F82_A1035SacadoRazaoSocial, P00F82_n1035SacadoRazaoSocial, P00F82_A1029OperacoesTitulosUpdatedAt, P00F82_n1029OperacoesTitulosUpdatedAt, P00F82_A1028OperacoesTitulosCreatedAt, P00F82_n1028OperacoesTitulosCreatedAt,
               P00F82_A1026OperacoesTitulosTaxa, P00F82_n1026OperacoesTitulosTaxa, P00F82_A1025OperacoesTitulosLiquido, P00F82_n1025OperacoesTitulosLiquido, P00F82_A1024OperacoesTitulosValor, P00F82_n1024OperacoesTitulosValor, P00F82_A1023OperacoesTitulosDataVencimento, P00F82_n1023OperacoesTitulosDataVencimento, P00F82_A1022OperacoesTitulosDataEmissao, P00F82_n1022OperacoesTitulosDataEmissao,
               P00F82_A1021OperacoesTitulosNumero, P00F82_n1021OperacoesTitulosNumero, P00F82_A1027OperacoesTitulosStatus, P00F82_n1027OperacoesTitulosStatus, P00F82_A1020OperacoesTitulosTipo, P00F82_n1020OperacoesTitulosTipo, P00F82_A1019OperacoesTitulosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV35MaxItems ;
      private short AV34PageIndex ;
      private short AV33SkipItems ;
      private int AV65GXV1 ;
      private int AV14TFOperacoesTitulosNumero ;
      private int AV15TFOperacoesTitulosNumero_To ;
      private int AV63OperacoesId ;
      private int AV67Operacoestituloswwds_1_operacoesid ;
      private int AV80Operacoestituloswwds_14_tfoperacoestitulosnumero ;
      private int AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to ;
      private int AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ;
      private int AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ;
      private int A1021OperacoesTitulosNumero ;
      private int A1010OperacoesId ;
      private int A1034SacadoId ;
      private int A1019OperacoesTitulosId ;
      private long AV42count ;
      private decimal AV20TFOperacoesTitulosValor ;
      private decimal AV21TFOperacoesTitulosValor_To ;
      private decimal AV22TFOperacoesTitulosLiquido ;
      private decimal AV23TFOperacoesTitulosLiquido_To ;
      private decimal AV24TFOperacoesTitulosTaxa ;
      private decimal AV25TFOperacoesTitulosTaxa_To ;
      private decimal AV86Operacoestituloswwds_20_tfoperacoestitulosvalor ;
      private decimal AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to ;
      private decimal AV88Operacoestituloswwds_22_tfoperacoestitulosliquido ;
      private decimal AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to ;
      private decimal AV90Operacoestituloswwds_24_tfoperacoestitulostaxa ;
      private decimal AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to ;
      private decimal A1024OperacoesTitulosValor ;
      private decimal A1025OperacoesTitulosLiquido ;
      private decimal A1026OperacoesTitulosTaxa ;
      private string AV64TrnMode ;
      private DateTime AV28TFOperacoesTitulosCreatedAt ;
      private DateTime AV29TFOperacoesTitulosCreatedAt_To ;
      private DateTime AV30TFOperacoesTitulosUpdatedAt ;
      private DateTime AV31TFOperacoesTitulosUpdatedAt_To ;
      private DateTime AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat ;
      private DateTime AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ;
      private DateTime AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat ;
      private DateTime AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ;
      private DateTime A1028OperacoesTitulosCreatedAt ;
      private DateTime A1029OperacoesTitulosUpdatedAt ;
      private DateTime AV16TFOperacoesTitulosDataEmissao ;
      private DateTime AV17TFOperacoesTitulosDataEmissao_To ;
      private DateTime AV18TFOperacoesTitulosDataVencimento ;
      private DateTime AV19TFOperacoesTitulosDataVencimento_To ;
      private DateTime AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao ;
      private DateTime AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ;
      private DateTime AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ;
      private DateTime AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ;
      private DateTime A1022OperacoesTitulosDataEmissao ;
      private DateTime A1023OperacoesTitulosDataVencimento ;
      private bool returnInSub ;
      private bool AV57DynamicFiltersEnabled2 ;
      private bool AV60DynamicFiltersEnabled3 ;
      private bool AV71Operacoestituloswwds_5_dynamicfiltersenabled2 ;
      private bool AV74Operacoestituloswwds_8_dynamicfiltersenabled3 ;
      private bool BRKF82 ;
      private bool n1034SacadoId ;
      private bool n1010OperacoesId ;
      private bool n1035SacadoRazaoSocial ;
      private bool n1029OperacoesTitulosUpdatedAt ;
      private bool n1028OperacoesTitulosCreatedAt ;
      private bool n1026OperacoesTitulosTaxa ;
      private bool n1025OperacoesTitulosLiquido ;
      private bool n1024OperacoesTitulosValor ;
      private bool n1023OperacoesTitulosDataVencimento ;
      private bool n1022OperacoesTitulosDataEmissao ;
      private bool n1021OperacoesTitulosNumero ;
      private bool n1027OperacoesTitulosStatus ;
      private bool n1020OperacoesTitulosTipo ;
      private string AV51OptionsJson ;
      private string AV52OptionsDescJson ;
      private string AV53OptionIndexesJson ;
      private string AV12TFOperacoesTitulosTipo_SelsJson ;
      private string AV26TFOperacoesTitulosStatus_SelsJson ;
      private string AV48DDOName ;
      private string AV49SearchTxtParms ;
      private string AV50SearchTxtTo ;
      private string AV32SearchTxt ;
      private string AV54FilterFullText ;
      private string AV10TFSacadoRazaoSocial ;
      private string AV11TFSacadoRazaoSocial_Sel ;
      private string AV55DynamicFiltersSelector1 ;
      private string AV56OperacoesTitulosTipo1 ;
      private string AV58DynamicFiltersSelector2 ;
      private string AV59OperacoesTitulosTipo2 ;
      private string AV61DynamicFiltersSelector3 ;
      private string AV62OperacoesTitulosTipo3 ;
      private string AV68Operacoestituloswwds_2_filterfulltext ;
      private string AV69Operacoestituloswwds_3_dynamicfiltersselector1 ;
      private string AV70Operacoestituloswwds_4_operacoestitulostipo1 ;
      private string AV72Operacoestituloswwds_6_dynamicfiltersselector2 ;
      private string AV73Operacoestituloswwds_7_operacoestitulostipo2 ;
      private string AV75Operacoestituloswwds_9_dynamicfiltersselector3 ;
      private string AV76Operacoestituloswwds_10_operacoestitulostipo3 ;
      private string AV77Operacoestituloswwds_11_tfsacadorazaosocial ;
      private string AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel ;
      private string lV68Operacoestituloswwds_2_filterfulltext ;
      private string lV77Operacoestituloswwds_11_tfsacadorazaosocial ;
      private string A1020OperacoesTitulosTipo ;
      private string A1027OperacoesTitulosStatus ;
      private string A1035SacadoRazaoSocial ;
      private string AV37Option ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV38Options ;
      private GxSimpleCollection<string> AV40OptionsDesc ;
      private GxSimpleCollection<string> AV41OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV45GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private GxSimpleCollection<string> AV13TFOperacoesTitulosTipo_Sels ;
      private GxSimpleCollection<string> AV27TFOperacoesTitulosStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV47GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels ;
      private GxSimpleCollection<string> AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00F82_A1034SacadoId ;
      private bool[] P00F82_n1034SacadoId ;
      private int[] P00F82_A1010OperacoesId ;
      private bool[] P00F82_n1010OperacoesId ;
      private string[] P00F82_A1035SacadoRazaoSocial ;
      private bool[] P00F82_n1035SacadoRazaoSocial ;
      private DateTime[] P00F82_A1029OperacoesTitulosUpdatedAt ;
      private bool[] P00F82_n1029OperacoesTitulosUpdatedAt ;
      private DateTime[] P00F82_A1028OperacoesTitulosCreatedAt ;
      private bool[] P00F82_n1028OperacoesTitulosCreatedAt ;
      private decimal[] P00F82_A1026OperacoesTitulosTaxa ;
      private bool[] P00F82_n1026OperacoesTitulosTaxa ;
      private decimal[] P00F82_A1025OperacoesTitulosLiquido ;
      private bool[] P00F82_n1025OperacoesTitulosLiquido ;
      private decimal[] P00F82_A1024OperacoesTitulosValor ;
      private bool[] P00F82_n1024OperacoesTitulosValor ;
      private DateTime[] P00F82_A1023OperacoesTitulosDataVencimento ;
      private bool[] P00F82_n1023OperacoesTitulosDataVencimento ;
      private DateTime[] P00F82_A1022OperacoesTitulosDataEmissao ;
      private bool[] P00F82_n1022OperacoesTitulosDataEmissao ;
      private int[] P00F82_A1021OperacoesTitulosNumero ;
      private bool[] P00F82_n1021OperacoesTitulosNumero ;
      private string[] P00F82_A1027OperacoesTitulosStatus ;
      private bool[] P00F82_n1027OperacoesTitulosStatus ;
      private string[] P00F82_A1020OperacoesTitulosTipo ;
      private bool[] P00F82_n1020OperacoesTitulosTipo ;
      private int[] P00F82_A1019OperacoesTitulosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class operacoestituloswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F82( IGxContext context ,
                                             string A1020OperacoesTitulosTipo ,
                                             GxSimpleCollection<string> AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                             string A1027OperacoesTitulosStatus ,
                                             GxSimpleCollection<string> AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                             string AV68Operacoestituloswwds_2_filterfulltext ,
                                             string AV69Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                             string AV70Operacoestituloswwds_4_operacoestitulostipo1 ,
                                             bool AV71Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                             string AV72Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                             string AV73Operacoestituloswwds_7_operacoestitulostipo2 ,
                                             bool AV74Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                             string AV75Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                             string AV76Operacoestituloswwds_10_operacoestitulostipo3 ,
                                             string AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                             string AV77Operacoestituloswwds_11_tfsacadorazaosocial ,
                                             int AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ,
                                             int AV80Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                             int AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                             DateTime AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                             DateTime AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                             DateTime AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                             DateTime AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                             decimal AV86Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                             decimal AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                             decimal AV88Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                             decimal AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                             decimal AV90Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                             decimal AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                             int AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ,
                                             DateTime AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                             DateTime AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                             DateTime AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                             DateTime AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                             string A1035SacadoRazaoSocial ,
                                             int A1021OperacoesTitulosNumero ,
                                             decimal A1024OperacoesTitulosValor ,
                                             decimal A1025OperacoesTitulosLiquido ,
                                             decimal A1026OperacoesTitulosTaxa ,
                                             DateTime A1022OperacoesTitulosDataEmissao ,
                                             DateTime A1023OperacoesTitulosDataVencimento ,
                                             DateTime A1028OperacoesTitulosCreatedAt ,
                                             DateTime A1029OperacoesTitulosUpdatedAt ,
                                             int AV67Operacoestituloswwds_1_operacoesid ,
                                             int A1010OperacoesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[35];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SacadoId AS SacadoId, T1.OperacoesId, T2.ClienteRazaoSocial AS SacadoRazaoSocial, T1.OperacoesTitulosUpdatedAt, T1.OperacoesTitulosCreatedAt, T1.OperacoesTitulosTaxa, T1.OperacoesTitulosLiquido, T1.OperacoesTitulosValor, T1.OperacoesTitulosDataVencimento, T1.OperacoesTitulosDataEmissao, T1.OperacoesTitulosNumero, T1.OperacoesTitulosStatus, T1.OperacoesTitulosTipo, T1.OperacoesTitulosId FROM (OperacoesTitulos T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.SacadoId)";
         AddWhere(sWhereString, "(T1.OperacoesId = :AV67Operacoestituloswwds_1_operacoesid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Operacoestituloswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV68Operacoestituloswwds_2_filterfulltext) or ( 'na' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and (char_length(trim(trailing ' ' from T1.OperacoesTitulosTipo))=0)) or ( 'nota fiscal' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'NOTA_FISCAL')) or ( 'rpa' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'RPA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosNumero,'999999999'), 2) like '%' || :lV68Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosValor,'999999999999990.99'), 2) like '%' || :lV68Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosLiquido,'999999999999990.99'), 2) like '%' || :lV68Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosTaxa,'99999999990.9999'), 2) like '%' || :lV68Operacoestituloswwds_2_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'PENDENTE')) or ( 'aceito' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'ACEITO')) or ( 'recusado' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'RECUSADO')) or ( 'vencido' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'VENCIDO')) or ( 'liquidado' like '%' || LOWER(:lV68Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'LIQUIDADO')))");
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
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Operacoestituloswwds_3_dynamicfiltersselector1, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Operacoestituloswwds_4_operacoestitulostipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV70Operacoestituloswwds_4_operacoestitulostipo1))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV71Operacoestituloswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Operacoestituloswwds_6_dynamicfiltersselector2, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Operacoestituloswwds_7_operacoestitulostipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV73Operacoestituloswwds_7_operacoestitulostipo2))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV74Operacoestituloswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Operacoestituloswwds_9_dynamicfiltersselector3, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Operacoestituloswwds_10_operacoestitulostipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV76Operacoestituloswwds_10_operacoestitulostipo3))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Operacoestituloswwds_11_tfsacadorazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV77Operacoestituloswwds_11_tfsacadorazaosocial)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ! ( StringUtil.StrCmp(AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV79Operacoestituloswwds_13_tfoperacoestitulostipo_sels, "T1.OperacoesTitulosTipo IN (", ")")+")");
         }
         if ( ! (0==AV80Operacoestituloswwds_14_tfoperacoestitulosnumero) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero >= :AV80Operacoestituloswwds_14_tfoperacoestitulosnumero)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (0==AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero <= :AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao >= :AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao <= :AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento >= :AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento <= :AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Operacoestituloswwds_20_tfoperacoestitulosvalor) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor >= :AV86Operacoestituloswwds_20_tfoperacoestitulosvalor)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor <= :AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Operacoestituloswwds_22_tfoperacoestitulosliquido) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido >= :AV88Operacoestituloswwds_22_tfoperacoestitulosliquido)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido <= :AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV90Operacoestituloswwds_24_tfoperacoestitulostaxa) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa >= :AV90Operacoestituloswwds_24_tfoperacoestitulostaxa)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa <= :AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV92Operacoestituloswwds_26_tfoperacoestitulosstatus_sels, "T1.OperacoesTitulosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt >= :AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt <= :AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt >= :AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt <= :AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.OperacoesId, T2.ClienteRazaoSocial";
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
                     return conditional_P00F82(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (int)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (int)dynConstraints[42] , (int)dynConstraints[43] );
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
          Object[] prmP00F82;
          prmP00F82 = new Object[] {
          new ParDef("AV67Operacoestituloswwds_1_operacoesid",GXType.Int32,9,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV70Operacoestituloswwds_4_operacoestitulostipo1",GXType.VarChar,40,0) ,
          new ParDef("AV73Operacoestituloswwds_7_operacoestitulostipo2",GXType.VarChar,40,0) ,
          new ParDef("AV76Operacoestituloswwds_10_operacoestitulostipo3",GXType.VarChar,40,0) ,
          new ParDef("lV77Operacoestituloswwds_11_tfsacadorazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV78Operacoestituloswwds_12_tfsacadorazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV80Operacoestituloswwds_14_tfoperacoestitulosnumero",GXType.Int32,9,0) ,
          new ParDef("AV81Operacoestituloswwds_15_tfoperacoestitulosnumero_to",GXType.Int32,9,0) ,
          new ParDef("AV82Operacoestituloswwds_16_tfoperacoestitulosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV83Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV84Operacoestituloswwds_18_tfoperacoestitulosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV85Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV86Operacoestituloswwds_20_tfoperacoestitulosvalor",GXType.Number,18,2) ,
          new ParDef("AV87Operacoestituloswwds_21_tfoperacoestitulosvalor_to",GXType.Number,18,2) ,
          new ParDef("AV88Operacoestituloswwds_22_tfoperacoestitulosliquido",GXType.Number,18,2) ,
          new ParDef("AV89Operacoestituloswwds_23_tfoperacoestitulosliquido_to",GXType.Number,18,2) ,
          new ParDef("AV90Operacoestituloswwds_24_tfoperacoestitulostaxa",GXType.Number,16,4) ,
          new ParDef("AV91Operacoestituloswwds_25_tfoperacoestitulostaxa_to",GXType.Number,16,4) ,
          new ParDef("AV93Operacoestituloswwds_27_tfoperacoestituloscreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV94Operacoestituloswwds_28_tfoperacoestituloscreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV95Operacoestituloswwds_29_tfoperacoestitulosupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV96Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00F82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F82,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
