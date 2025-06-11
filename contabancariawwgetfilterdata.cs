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
   public class contabancariawwgetfilterdata : GXProcedure
   {
      public contabancariawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contabancariawwgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30MaxItems = 10;
         AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_AGENCIABANCONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADAGENCIABANCONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_CONTABANCARIACREATEDBYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTABANCARIACREATEDBYNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_CONTABANCARIAUPDATEDBYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTABANCARIAUPDATEDBYNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("ContaBancariaWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ContaBancariaWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("ContaBancariaWWGridState"), null, "", "");
         }
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV71TFAgenciaBancoNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV72TFAgenciaBancoNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV12TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV13TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIANUMERO") == 0 )
            {
               AV14TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV15TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIADIGITO") == 0 )
            {
               AV74TFContaBancariaDigito = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV75TFContaBancariaDigito_To = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACARTEIRA") == 0 )
            {
               AV16TFContaBancariaCarteira = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV17TFContaBancariaCarteira_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIASTATUS_SEL") == 0 )
            {
               AV18TFContaBancariaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDAT") == 0 )
            {
               AV19TFContaBancariaCreatedAt = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV20TFContaBancariaCreatedAt_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDBYNAME") == 0 )
            {
               AV21TFContaBancariaCreatedByName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDBYNAME_SEL") == 0 )
            {
               AV22TFContaBancariaCreatedByName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDAT") == 0 )
            {
               AV23TFContaBancariaUpdatedAt = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV24TFContaBancariaUpdatedAt_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               AV25TFContaBancariaUpdatedByName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDBYNAME_SEL") == 0 )
            {
               AV26TFContaBancariaUpdatedByName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAREGISTRABOLETOS_SEL") == 0 )
            {
               AV73TFContaBancariaRegistraBoletos_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&AGENCIAID") == 0 )
            {
               AV70AgenciaId = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(1));
            AV50DynamicFiltersSelector1 = AV42GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV52ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV42GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV53AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( AV42GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CONTABANCARIACREATEDBYNAME") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV54ContaBancariaCreatedByName1 = AV42GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV55ContaBancariaUpdatedByName1 = AV42GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV56DynamicFiltersEnabled2 = true;
               AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(2));
               AV57DynamicFiltersSelector2 = AV42GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV59ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV42GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV60AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( AV42GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "CONTABANCARIACREATEDBYNAME") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV61ContaBancariaCreatedByName2 = AV42GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "CONTABANCARIAUPDATEDBYNAME") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV62ContaBancariaUpdatedByName2 = AV42GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV63DynamicFiltersEnabled3 = true;
                  AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(3));
                  AV64DynamicFiltersSelector3 = AV42GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV64DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV65DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV66ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV42GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV64DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
                  {
                     AV65DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV67AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( AV42GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV64DynamicFiltersSelector3, "CONTABANCARIACREATEDBYNAME") == 0 )
                  {
                     AV65DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV68ContaBancariaCreatedByName3 = AV42GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV64DynamicFiltersSelector3, "CONTABANCARIAUPDATEDBYNAME") == 0 )
                  {
                     AV65DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV69ContaBancariaUpdatedByName3 = AV42GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADAGENCIABANCONOMEOPTIONS' Routine */
         returnInSub = false;
         AV71TFAgenciaBancoNome = AV27SearchTxt;
         AV72TFAgenciaBancoNome_Sel = "";
         AV78Contabancariawwds_1_filterfulltext = AV49FilterFullText;
         AV79Contabancariawwds_2_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV80Contabancariawwds_3_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV81Contabancariawwds_4_contabancarianumero1 = AV52ContaBancariaNumero1;
         AV82Contabancariawwds_5_agencianumero1 = AV53AgenciaNumero1;
         AV83Contabancariawwds_6_contabancariacreatedbyname1 = AV54ContaBancariaCreatedByName1;
         AV84Contabancariawwds_7_contabancariaupdatedbyname1 = AV55ContaBancariaUpdatedByName1;
         AV85Contabancariawwds_8_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV86Contabancariawwds_9_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV87Contabancariawwds_10_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV88Contabancariawwds_11_contabancarianumero2 = AV59ContaBancariaNumero2;
         AV89Contabancariawwds_12_agencianumero2 = AV60AgenciaNumero2;
         AV90Contabancariawwds_13_contabancariacreatedbyname2 = AV61ContaBancariaCreatedByName2;
         AV91Contabancariawwds_14_contabancariaupdatedbyname2 = AV62ContaBancariaUpdatedByName2;
         AV92Contabancariawwds_15_dynamicfiltersenabled3 = AV63DynamicFiltersEnabled3;
         AV93Contabancariawwds_16_dynamicfiltersselector3 = AV64DynamicFiltersSelector3;
         AV94Contabancariawwds_17_dynamicfiltersoperator3 = AV65DynamicFiltersOperator3;
         AV95Contabancariawwds_18_contabancarianumero3 = AV66ContaBancariaNumero3;
         AV96Contabancariawwds_19_agencianumero3 = AV67AgenciaNumero3;
         AV97Contabancariawwds_20_contabancariacreatedbyname3 = AV68ContaBancariaCreatedByName3;
         AV98Contabancariawwds_21_contabancariaupdatedbyname3 = AV69ContaBancariaUpdatedByName3;
         AV99Contabancariawwds_22_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV100Contabancariawwds_23_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV101Contabancariawwds_24_tfagencianumero = AV12TFAgenciaNumero;
         AV102Contabancariawwds_25_tfagencianumero_to = AV13TFAgenciaNumero_To;
         AV103Contabancariawwds_26_tfcontabancarianumero = AV14TFContaBancariaNumero;
         AV104Contabancariawwds_27_tfcontabancarianumero_to = AV15TFContaBancariaNumero_To;
         AV105Contabancariawwds_28_tfcontabancariadigito = AV74TFContaBancariaDigito;
         AV106Contabancariawwds_29_tfcontabancariadigito_to = AV75TFContaBancariaDigito_To;
         AV107Contabancariawwds_30_tfcontabancariacarteira = AV16TFContaBancariaCarteira;
         AV108Contabancariawwds_31_tfcontabancariacarteira_to = AV17TFContaBancariaCarteira_To;
         AV109Contabancariawwds_32_tfcontabancariastatus_sel = AV18TFContaBancariaStatus_Sel;
         AV110Contabancariawwds_33_tfcontabancariacreatedat = AV19TFContaBancariaCreatedAt;
         AV111Contabancariawwds_34_tfcontabancariacreatedat_to = AV20TFContaBancariaCreatedAt_To;
         AV112Contabancariawwds_35_tfcontabancariacreatedbyname = AV21TFContaBancariaCreatedByName;
         AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV22TFContaBancariaCreatedByName_Sel;
         AV114Contabancariawwds_37_tfcontabancariaupdatedat = AV23TFContaBancariaUpdatedAt;
         AV115Contabancariawwds_38_tfcontabancariaupdatedat_to = AV24TFContaBancariaUpdatedAt_To;
         AV116Contabancariawwds_39_tfcontabancariaupdatedbyname = AV25TFContaBancariaUpdatedByName;
         AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV26TFContaBancariaUpdatedByName_Sel;
         AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV73TFContaBancariaRegistraBoletos_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV78Contabancariawwds_1_filterfulltext ,
                                              AV79Contabancariawwds_2_dynamicfiltersselector1 ,
                                              AV80Contabancariawwds_3_dynamicfiltersoperator1 ,
                                              AV81Contabancariawwds_4_contabancarianumero1 ,
                                              AV82Contabancariawwds_5_agencianumero1 ,
                                              AV83Contabancariawwds_6_contabancariacreatedbyname1 ,
                                              AV84Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                              AV85Contabancariawwds_8_dynamicfiltersenabled2 ,
                                              AV86Contabancariawwds_9_dynamicfiltersselector2 ,
                                              AV87Contabancariawwds_10_dynamicfiltersoperator2 ,
                                              AV88Contabancariawwds_11_contabancarianumero2 ,
                                              AV89Contabancariawwds_12_agencianumero2 ,
                                              AV90Contabancariawwds_13_contabancariacreatedbyname2 ,
                                              AV91Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                              AV92Contabancariawwds_15_dynamicfiltersenabled3 ,
                                              AV93Contabancariawwds_16_dynamicfiltersselector3 ,
                                              AV94Contabancariawwds_17_dynamicfiltersoperator3 ,
                                              AV95Contabancariawwds_18_contabancarianumero3 ,
                                              AV96Contabancariawwds_19_agencianumero3 ,
                                              AV97Contabancariawwds_20_contabancariacreatedbyname3 ,
                                              AV98Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                              AV100Contabancariawwds_23_tfagenciabanconome_sel ,
                                              AV99Contabancariawwds_22_tfagenciabanconome ,
                                              AV101Contabancariawwds_24_tfagencianumero ,
                                              AV102Contabancariawwds_25_tfagencianumero_to ,
                                              AV103Contabancariawwds_26_tfcontabancarianumero ,
                                              AV104Contabancariawwds_27_tfcontabancarianumero_to ,
                                              AV105Contabancariawwds_28_tfcontabancariadigito ,
                                              AV106Contabancariawwds_29_tfcontabancariadigito_to ,
                                              AV107Contabancariawwds_30_tfcontabancariacarteira ,
                                              AV108Contabancariawwds_31_tfcontabancariacarteira_to ,
                                              AV109Contabancariawwds_32_tfcontabancariastatus_sel ,
                                              AV110Contabancariawwds_33_tfcontabancariacreatedat ,
                                              AV111Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                              AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                              AV112Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                              AV114Contabancariawwds_37_tfcontabancariaupdatedat ,
                                              AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                              AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                              AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                              AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                              AV70AgenciaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A975ContaBancariaDigito ,
                                              A953ContaBancariaCarteira ,
                                              A956ContaBancariaStatus ,
                                              A948ContaBancariaCreatedByName ,
                                              A950ContaBancariaUpdatedByName ,
                                              A973ContaBancariaRegistraBoletos ,
                                              A954ContaBancariaCreatedAt ,
                                              A955ContaBancariaUpdatedAt ,
                                              A938AgenciaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV99Contabancariawwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV99Contabancariawwds_22_tfagenciabanconome), "%", "");
         lV112Contabancariawwds_35_tfcontabancariacreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV112Contabancariawwds_35_tfcontabancariacreatedbyname), "%", "");
         lV116Contabancariawwds_39_tfcontabancariaupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV116Contabancariawwds_39_tfcontabancariaupdatedbyname), "%", "");
         /* Using cursor P00EL2 */
         pr_default.execute(0, new Object[] {lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, AV81Contabancariawwds_4_contabancarianumero1, AV81Contabancariawwds_4_contabancarianumero1, AV81Contabancariawwds_4_contabancarianumero1, AV82Contabancariawwds_5_agencianumero1, AV82Contabancariawwds_5_agencianumero1, AV82Contabancariawwds_5_agencianumero1, lV83Contabancariawwds_6_contabancariacreatedbyname1, lV83Contabancariawwds_6_contabancariacreatedbyname1, lV84Contabancariawwds_7_contabancariaupdatedbyname1, lV84Contabancariawwds_7_contabancariaupdatedbyname1, AV88Contabancariawwds_11_contabancarianumero2, AV88Contabancariawwds_11_contabancarianumero2, AV88Contabancariawwds_11_contabancarianumero2, AV89Contabancariawwds_12_agencianumero2, AV89Contabancariawwds_12_agencianumero2, AV89Contabancariawwds_12_agencianumero2, lV90Contabancariawwds_13_contabancariacreatedbyname2, lV90Contabancariawwds_13_contabancariacreatedbyname2, lV91Contabancariawwds_14_contabancariaupdatedbyname2, lV91Contabancariawwds_14_contabancariaupdatedbyname2, AV95Contabancariawwds_18_contabancarianumero3, AV95Contabancariawwds_18_contabancarianumero3, AV95Contabancariawwds_18_contabancarianumero3, AV96Contabancariawwds_19_agencianumero3, AV96Contabancariawwds_19_agencianumero3, AV96Contabancariawwds_19_agencianumero3, lV97Contabancariawwds_20_contabancariacreatedbyname3, lV97Contabancariawwds_20_contabancariacreatedbyname3, lV98Contabancariawwds_21_contabancariaupdatedbyname3, lV98Contabancariawwds_21_contabancariaupdatedbyname3, lV99Contabancariawwds_22_tfagenciabanconome, AV100Contabancariawwds_23_tfagenciabanconome_sel, AV101Contabancariawwds_24_tfagencianumero, AV102Contabancariawwds_25_tfagencianumero_to, AV103Contabancariawwds_26_tfcontabancarianumero, AV104Contabancariawwds_27_tfcontabancarianumero_to, AV105Contabancariawwds_28_tfcontabancariadigito, AV106Contabancariawwds_29_tfcontabancariadigito_to, AV107Contabancariawwds_30_tfcontabancariacarteira, AV108Contabancariawwds_31_tfcontabancariacarteira_to, AV110Contabancariawwds_33_tfcontabancariacreatedat, AV111Contabancariawwds_34_tfcontabancariacreatedat_to, lV112Contabancariawwds_35_tfcontabancariacreatedbyname, AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, AV114Contabancariawwds_37_tfcontabancariaupdatedat, AV115Contabancariawwds_38_tfcontabancariaupdatedat_to, lV116Contabancariawwds_39_tfcontabancariaupdatedbyname, AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, AV70AgenciaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEL2 = false;
            A968AgenciaBancoId = P00EL2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EL2_n968AgenciaBancoId[0];
            A947ContaBancariaCreatedBy = P00EL2_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = P00EL2_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = P00EL2_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = P00EL2_n949ContaBancariaUpdatedBy[0];
            A969AgenciaBancoNome = P00EL2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EL2_n969AgenciaBancoNome[0];
            A938AgenciaId = P00EL2_A938AgenciaId[0];
            n938AgenciaId = P00EL2_n938AgenciaId[0];
            A955ContaBancariaUpdatedAt = P00EL2_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = P00EL2_n955ContaBancariaUpdatedAt[0];
            A954ContaBancariaCreatedAt = P00EL2_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = P00EL2_n954ContaBancariaCreatedAt[0];
            A953ContaBancariaCarteira = P00EL2_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = P00EL2_n953ContaBancariaCarteira[0];
            A975ContaBancariaDigito = P00EL2_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = P00EL2_n975ContaBancariaDigito[0];
            A950ContaBancariaUpdatedByName = P00EL2_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EL2_n950ContaBancariaUpdatedByName[0];
            A948ContaBancariaCreatedByName = P00EL2_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EL2_n948ContaBancariaCreatedByName[0];
            A939AgenciaNumero = P00EL2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EL2_n939AgenciaNumero[0];
            A952ContaBancariaNumero = P00EL2_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EL2_n952ContaBancariaNumero[0];
            A973ContaBancariaRegistraBoletos = P00EL2_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = P00EL2_n973ContaBancariaRegistraBoletos[0];
            A956ContaBancariaStatus = P00EL2_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = P00EL2_n956ContaBancariaStatus[0];
            A951ContaBancariaId = P00EL2_A951ContaBancariaId[0];
            A948ContaBancariaCreatedByName = P00EL2_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EL2_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = P00EL2_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EL2_n950ContaBancariaUpdatedByName[0];
            A968AgenciaBancoId = P00EL2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EL2_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EL2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EL2_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EL2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EL2_n969AgenciaBancoNome[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EL2_A969AgenciaBancoNome[0], A969AgenciaBancoNome) == 0 ) )
            {
               BRKEL2 = false;
               A968AgenciaBancoId = P00EL2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = P00EL2_n968AgenciaBancoId[0];
               A938AgenciaId = P00EL2_A938AgenciaId[0];
               n938AgenciaId = P00EL2_n938AgenciaId[0];
               A951ContaBancariaId = P00EL2_A951ContaBancariaId[0];
               A968AgenciaBancoId = P00EL2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = P00EL2_n968AgenciaBancoId[0];
               AV37count = (long)(AV37count+1);
               BRKEL2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A969AgenciaBancoNome)) ? "<#Empty#>" : A969AgenciaBancoNome);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRKEL2 )
            {
               BRKEL2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONTABANCARIACREATEDBYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFContaBancariaCreatedByName = AV27SearchTxt;
         AV22TFContaBancariaCreatedByName_Sel = "";
         AV78Contabancariawwds_1_filterfulltext = AV49FilterFullText;
         AV79Contabancariawwds_2_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV80Contabancariawwds_3_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV81Contabancariawwds_4_contabancarianumero1 = AV52ContaBancariaNumero1;
         AV82Contabancariawwds_5_agencianumero1 = AV53AgenciaNumero1;
         AV83Contabancariawwds_6_contabancariacreatedbyname1 = AV54ContaBancariaCreatedByName1;
         AV84Contabancariawwds_7_contabancariaupdatedbyname1 = AV55ContaBancariaUpdatedByName1;
         AV85Contabancariawwds_8_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV86Contabancariawwds_9_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV87Contabancariawwds_10_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV88Contabancariawwds_11_contabancarianumero2 = AV59ContaBancariaNumero2;
         AV89Contabancariawwds_12_agencianumero2 = AV60AgenciaNumero2;
         AV90Contabancariawwds_13_contabancariacreatedbyname2 = AV61ContaBancariaCreatedByName2;
         AV91Contabancariawwds_14_contabancariaupdatedbyname2 = AV62ContaBancariaUpdatedByName2;
         AV92Contabancariawwds_15_dynamicfiltersenabled3 = AV63DynamicFiltersEnabled3;
         AV93Contabancariawwds_16_dynamicfiltersselector3 = AV64DynamicFiltersSelector3;
         AV94Contabancariawwds_17_dynamicfiltersoperator3 = AV65DynamicFiltersOperator3;
         AV95Contabancariawwds_18_contabancarianumero3 = AV66ContaBancariaNumero3;
         AV96Contabancariawwds_19_agencianumero3 = AV67AgenciaNumero3;
         AV97Contabancariawwds_20_contabancariacreatedbyname3 = AV68ContaBancariaCreatedByName3;
         AV98Contabancariawwds_21_contabancariaupdatedbyname3 = AV69ContaBancariaUpdatedByName3;
         AV99Contabancariawwds_22_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV100Contabancariawwds_23_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV101Contabancariawwds_24_tfagencianumero = AV12TFAgenciaNumero;
         AV102Contabancariawwds_25_tfagencianumero_to = AV13TFAgenciaNumero_To;
         AV103Contabancariawwds_26_tfcontabancarianumero = AV14TFContaBancariaNumero;
         AV104Contabancariawwds_27_tfcontabancarianumero_to = AV15TFContaBancariaNumero_To;
         AV105Contabancariawwds_28_tfcontabancariadigito = AV74TFContaBancariaDigito;
         AV106Contabancariawwds_29_tfcontabancariadigito_to = AV75TFContaBancariaDigito_To;
         AV107Contabancariawwds_30_tfcontabancariacarteira = AV16TFContaBancariaCarteira;
         AV108Contabancariawwds_31_tfcontabancariacarteira_to = AV17TFContaBancariaCarteira_To;
         AV109Contabancariawwds_32_tfcontabancariastatus_sel = AV18TFContaBancariaStatus_Sel;
         AV110Contabancariawwds_33_tfcontabancariacreatedat = AV19TFContaBancariaCreatedAt;
         AV111Contabancariawwds_34_tfcontabancariacreatedat_to = AV20TFContaBancariaCreatedAt_To;
         AV112Contabancariawwds_35_tfcontabancariacreatedbyname = AV21TFContaBancariaCreatedByName;
         AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV22TFContaBancariaCreatedByName_Sel;
         AV114Contabancariawwds_37_tfcontabancariaupdatedat = AV23TFContaBancariaUpdatedAt;
         AV115Contabancariawwds_38_tfcontabancariaupdatedat_to = AV24TFContaBancariaUpdatedAt_To;
         AV116Contabancariawwds_39_tfcontabancariaupdatedbyname = AV25TFContaBancariaUpdatedByName;
         AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV26TFContaBancariaUpdatedByName_Sel;
         AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV73TFContaBancariaRegistraBoletos_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV78Contabancariawwds_1_filterfulltext ,
                                              AV79Contabancariawwds_2_dynamicfiltersselector1 ,
                                              AV80Contabancariawwds_3_dynamicfiltersoperator1 ,
                                              AV81Contabancariawwds_4_contabancarianumero1 ,
                                              AV82Contabancariawwds_5_agencianumero1 ,
                                              AV83Contabancariawwds_6_contabancariacreatedbyname1 ,
                                              AV84Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                              AV85Contabancariawwds_8_dynamicfiltersenabled2 ,
                                              AV86Contabancariawwds_9_dynamicfiltersselector2 ,
                                              AV87Contabancariawwds_10_dynamicfiltersoperator2 ,
                                              AV88Contabancariawwds_11_contabancarianumero2 ,
                                              AV89Contabancariawwds_12_agencianumero2 ,
                                              AV90Contabancariawwds_13_contabancariacreatedbyname2 ,
                                              AV91Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                              AV92Contabancariawwds_15_dynamicfiltersenabled3 ,
                                              AV93Contabancariawwds_16_dynamicfiltersselector3 ,
                                              AV94Contabancariawwds_17_dynamicfiltersoperator3 ,
                                              AV95Contabancariawwds_18_contabancarianumero3 ,
                                              AV96Contabancariawwds_19_agencianumero3 ,
                                              AV97Contabancariawwds_20_contabancariacreatedbyname3 ,
                                              AV98Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                              AV100Contabancariawwds_23_tfagenciabanconome_sel ,
                                              AV99Contabancariawwds_22_tfagenciabanconome ,
                                              AV101Contabancariawwds_24_tfagencianumero ,
                                              AV102Contabancariawwds_25_tfagencianumero_to ,
                                              AV103Contabancariawwds_26_tfcontabancarianumero ,
                                              AV104Contabancariawwds_27_tfcontabancarianumero_to ,
                                              AV105Contabancariawwds_28_tfcontabancariadigito ,
                                              AV106Contabancariawwds_29_tfcontabancariadigito_to ,
                                              AV107Contabancariawwds_30_tfcontabancariacarteira ,
                                              AV108Contabancariawwds_31_tfcontabancariacarteira_to ,
                                              AV109Contabancariawwds_32_tfcontabancariastatus_sel ,
                                              AV110Contabancariawwds_33_tfcontabancariacreatedat ,
                                              AV111Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                              AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                              AV112Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                              AV114Contabancariawwds_37_tfcontabancariaupdatedat ,
                                              AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                              AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                              AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                              AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                              AV70AgenciaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A975ContaBancariaDigito ,
                                              A953ContaBancariaCarteira ,
                                              A956ContaBancariaStatus ,
                                              A948ContaBancariaCreatedByName ,
                                              A950ContaBancariaUpdatedByName ,
                                              A973ContaBancariaRegistraBoletos ,
                                              A954ContaBancariaCreatedAt ,
                                              A955ContaBancariaUpdatedAt ,
                                              A938AgenciaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV99Contabancariawwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV99Contabancariawwds_22_tfagenciabanconome), "%", "");
         lV112Contabancariawwds_35_tfcontabancariacreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV112Contabancariawwds_35_tfcontabancariacreatedbyname), "%", "");
         lV116Contabancariawwds_39_tfcontabancariaupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV116Contabancariawwds_39_tfcontabancariaupdatedbyname), "%", "");
         /* Using cursor P00EL3 */
         pr_default.execute(1, new Object[] {lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, AV81Contabancariawwds_4_contabancarianumero1, AV81Contabancariawwds_4_contabancarianumero1, AV81Contabancariawwds_4_contabancarianumero1, AV82Contabancariawwds_5_agencianumero1, AV82Contabancariawwds_5_agencianumero1, AV82Contabancariawwds_5_agencianumero1, lV83Contabancariawwds_6_contabancariacreatedbyname1, lV83Contabancariawwds_6_contabancariacreatedbyname1, lV84Contabancariawwds_7_contabancariaupdatedbyname1, lV84Contabancariawwds_7_contabancariaupdatedbyname1, AV88Contabancariawwds_11_contabancarianumero2, AV88Contabancariawwds_11_contabancarianumero2, AV88Contabancariawwds_11_contabancarianumero2, AV89Contabancariawwds_12_agencianumero2, AV89Contabancariawwds_12_agencianumero2, AV89Contabancariawwds_12_agencianumero2, lV90Contabancariawwds_13_contabancariacreatedbyname2, lV90Contabancariawwds_13_contabancariacreatedbyname2, lV91Contabancariawwds_14_contabancariaupdatedbyname2, lV91Contabancariawwds_14_contabancariaupdatedbyname2, AV95Contabancariawwds_18_contabancarianumero3, AV95Contabancariawwds_18_contabancarianumero3, AV95Contabancariawwds_18_contabancarianumero3, AV96Contabancariawwds_19_agencianumero3, AV96Contabancariawwds_19_agencianumero3, AV96Contabancariawwds_19_agencianumero3, lV97Contabancariawwds_20_contabancariacreatedbyname3, lV97Contabancariawwds_20_contabancariacreatedbyname3, lV98Contabancariawwds_21_contabancariaupdatedbyname3, lV98Contabancariawwds_21_contabancariaupdatedbyname3, lV99Contabancariawwds_22_tfagenciabanconome, AV100Contabancariawwds_23_tfagenciabanconome_sel, AV101Contabancariawwds_24_tfagencianumero, AV102Contabancariawwds_25_tfagencianumero_to, AV103Contabancariawwds_26_tfcontabancarianumero, AV104Contabancariawwds_27_tfcontabancarianumero_to, AV105Contabancariawwds_28_tfcontabancariadigito, AV106Contabancariawwds_29_tfcontabancariadigito_to, AV107Contabancariawwds_30_tfcontabancariacarteira, AV108Contabancariawwds_31_tfcontabancariacarteira_to, AV110Contabancariawwds_33_tfcontabancariacreatedat, AV111Contabancariawwds_34_tfcontabancariacreatedat_to, lV112Contabancariawwds_35_tfcontabancariacreatedbyname, AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, AV114Contabancariawwds_37_tfcontabancariaupdatedat, AV115Contabancariawwds_38_tfcontabancariaupdatedat_to, lV116Contabancariawwds_39_tfcontabancariaupdatedbyname, AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, AV70AgenciaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEL4 = false;
            A968AgenciaBancoId = P00EL3_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EL3_n968AgenciaBancoId[0];
            A949ContaBancariaUpdatedBy = P00EL3_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = P00EL3_n949ContaBancariaUpdatedBy[0];
            A947ContaBancariaCreatedBy = P00EL3_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = P00EL3_n947ContaBancariaCreatedBy[0];
            A938AgenciaId = P00EL3_A938AgenciaId[0];
            n938AgenciaId = P00EL3_n938AgenciaId[0];
            A955ContaBancariaUpdatedAt = P00EL3_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = P00EL3_n955ContaBancariaUpdatedAt[0];
            A954ContaBancariaCreatedAt = P00EL3_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = P00EL3_n954ContaBancariaCreatedAt[0];
            A953ContaBancariaCarteira = P00EL3_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = P00EL3_n953ContaBancariaCarteira[0];
            A975ContaBancariaDigito = P00EL3_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = P00EL3_n975ContaBancariaDigito[0];
            A969AgenciaBancoNome = P00EL3_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EL3_n969AgenciaBancoNome[0];
            A950ContaBancariaUpdatedByName = P00EL3_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EL3_n950ContaBancariaUpdatedByName[0];
            A948ContaBancariaCreatedByName = P00EL3_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EL3_n948ContaBancariaCreatedByName[0];
            A939AgenciaNumero = P00EL3_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EL3_n939AgenciaNumero[0];
            A952ContaBancariaNumero = P00EL3_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EL3_n952ContaBancariaNumero[0];
            A973ContaBancariaRegistraBoletos = P00EL3_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = P00EL3_n973ContaBancariaRegistraBoletos[0];
            A956ContaBancariaStatus = P00EL3_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = P00EL3_n956ContaBancariaStatus[0];
            A951ContaBancariaId = P00EL3_A951ContaBancariaId[0];
            A950ContaBancariaUpdatedByName = P00EL3_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EL3_n950ContaBancariaUpdatedByName[0];
            A948ContaBancariaCreatedByName = P00EL3_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EL3_n948ContaBancariaCreatedByName[0];
            A968AgenciaBancoId = P00EL3_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EL3_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EL3_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EL3_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EL3_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EL3_n969AgenciaBancoNome[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00EL3_A947ContaBancariaCreatedBy[0] == A947ContaBancariaCreatedBy ) )
            {
               BRKEL4 = false;
               A951ContaBancariaId = P00EL3_A951ContaBancariaId[0];
               AV37count = (long)(AV37count+1);
               BRKEL4 = true;
               pr_default.readNext(1);
            }
            AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A948ContaBancariaCreatedByName)) ? "<#Empty#>" : A948ContaBancariaCreatedByName);
            AV31InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV31InsertIndex = (int)(AV31InsertIndex+1);
            }
            AV33Options.Add(AV32Option, AV31InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            if ( AV33Options.Count == AV28SkipItems + 11 )
            {
               AV33Options.RemoveItem(AV33Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRKEL4 )
            {
               BRKEL4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADCONTABANCARIAUPDATEDBYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV25TFContaBancariaUpdatedByName = AV27SearchTxt;
         AV26TFContaBancariaUpdatedByName_Sel = "";
         AV78Contabancariawwds_1_filterfulltext = AV49FilterFullText;
         AV79Contabancariawwds_2_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV80Contabancariawwds_3_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV81Contabancariawwds_4_contabancarianumero1 = AV52ContaBancariaNumero1;
         AV82Contabancariawwds_5_agencianumero1 = AV53AgenciaNumero1;
         AV83Contabancariawwds_6_contabancariacreatedbyname1 = AV54ContaBancariaCreatedByName1;
         AV84Contabancariawwds_7_contabancariaupdatedbyname1 = AV55ContaBancariaUpdatedByName1;
         AV85Contabancariawwds_8_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV86Contabancariawwds_9_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV87Contabancariawwds_10_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV88Contabancariawwds_11_contabancarianumero2 = AV59ContaBancariaNumero2;
         AV89Contabancariawwds_12_agencianumero2 = AV60AgenciaNumero2;
         AV90Contabancariawwds_13_contabancariacreatedbyname2 = AV61ContaBancariaCreatedByName2;
         AV91Contabancariawwds_14_contabancariaupdatedbyname2 = AV62ContaBancariaUpdatedByName2;
         AV92Contabancariawwds_15_dynamicfiltersenabled3 = AV63DynamicFiltersEnabled3;
         AV93Contabancariawwds_16_dynamicfiltersselector3 = AV64DynamicFiltersSelector3;
         AV94Contabancariawwds_17_dynamicfiltersoperator3 = AV65DynamicFiltersOperator3;
         AV95Contabancariawwds_18_contabancarianumero3 = AV66ContaBancariaNumero3;
         AV96Contabancariawwds_19_agencianumero3 = AV67AgenciaNumero3;
         AV97Contabancariawwds_20_contabancariacreatedbyname3 = AV68ContaBancariaCreatedByName3;
         AV98Contabancariawwds_21_contabancariaupdatedbyname3 = AV69ContaBancariaUpdatedByName3;
         AV99Contabancariawwds_22_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV100Contabancariawwds_23_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV101Contabancariawwds_24_tfagencianumero = AV12TFAgenciaNumero;
         AV102Contabancariawwds_25_tfagencianumero_to = AV13TFAgenciaNumero_To;
         AV103Contabancariawwds_26_tfcontabancarianumero = AV14TFContaBancariaNumero;
         AV104Contabancariawwds_27_tfcontabancarianumero_to = AV15TFContaBancariaNumero_To;
         AV105Contabancariawwds_28_tfcontabancariadigito = AV74TFContaBancariaDigito;
         AV106Contabancariawwds_29_tfcontabancariadigito_to = AV75TFContaBancariaDigito_To;
         AV107Contabancariawwds_30_tfcontabancariacarteira = AV16TFContaBancariaCarteira;
         AV108Contabancariawwds_31_tfcontabancariacarteira_to = AV17TFContaBancariaCarteira_To;
         AV109Contabancariawwds_32_tfcontabancariastatus_sel = AV18TFContaBancariaStatus_Sel;
         AV110Contabancariawwds_33_tfcontabancariacreatedat = AV19TFContaBancariaCreatedAt;
         AV111Contabancariawwds_34_tfcontabancariacreatedat_to = AV20TFContaBancariaCreatedAt_To;
         AV112Contabancariawwds_35_tfcontabancariacreatedbyname = AV21TFContaBancariaCreatedByName;
         AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV22TFContaBancariaCreatedByName_Sel;
         AV114Contabancariawwds_37_tfcontabancariaupdatedat = AV23TFContaBancariaUpdatedAt;
         AV115Contabancariawwds_38_tfcontabancariaupdatedat_to = AV24TFContaBancariaUpdatedAt_To;
         AV116Contabancariawwds_39_tfcontabancariaupdatedbyname = AV25TFContaBancariaUpdatedByName;
         AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV26TFContaBancariaUpdatedByName_Sel;
         AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV73TFContaBancariaRegistraBoletos_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV78Contabancariawwds_1_filterfulltext ,
                                              AV79Contabancariawwds_2_dynamicfiltersselector1 ,
                                              AV80Contabancariawwds_3_dynamicfiltersoperator1 ,
                                              AV81Contabancariawwds_4_contabancarianumero1 ,
                                              AV82Contabancariawwds_5_agencianumero1 ,
                                              AV83Contabancariawwds_6_contabancariacreatedbyname1 ,
                                              AV84Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                              AV85Contabancariawwds_8_dynamicfiltersenabled2 ,
                                              AV86Contabancariawwds_9_dynamicfiltersselector2 ,
                                              AV87Contabancariawwds_10_dynamicfiltersoperator2 ,
                                              AV88Contabancariawwds_11_contabancarianumero2 ,
                                              AV89Contabancariawwds_12_agencianumero2 ,
                                              AV90Contabancariawwds_13_contabancariacreatedbyname2 ,
                                              AV91Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                              AV92Contabancariawwds_15_dynamicfiltersenabled3 ,
                                              AV93Contabancariawwds_16_dynamicfiltersselector3 ,
                                              AV94Contabancariawwds_17_dynamicfiltersoperator3 ,
                                              AV95Contabancariawwds_18_contabancarianumero3 ,
                                              AV96Contabancariawwds_19_agencianumero3 ,
                                              AV97Contabancariawwds_20_contabancariacreatedbyname3 ,
                                              AV98Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                              AV100Contabancariawwds_23_tfagenciabanconome_sel ,
                                              AV99Contabancariawwds_22_tfagenciabanconome ,
                                              AV101Contabancariawwds_24_tfagencianumero ,
                                              AV102Contabancariawwds_25_tfagencianumero_to ,
                                              AV103Contabancariawwds_26_tfcontabancarianumero ,
                                              AV104Contabancariawwds_27_tfcontabancarianumero_to ,
                                              AV105Contabancariawwds_28_tfcontabancariadigito ,
                                              AV106Contabancariawwds_29_tfcontabancariadigito_to ,
                                              AV107Contabancariawwds_30_tfcontabancariacarteira ,
                                              AV108Contabancariawwds_31_tfcontabancariacarteira_to ,
                                              AV109Contabancariawwds_32_tfcontabancariastatus_sel ,
                                              AV110Contabancariawwds_33_tfcontabancariacreatedat ,
                                              AV111Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                              AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                              AV112Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                              AV114Contabancariawwds_37_tfcontabancariaupdatedat ,
                                              AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                              AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                              AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                              AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                              AV70AgenciaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A975ContaBancariaDigito ,
                                              A953ContaBancariaCarteira ,
                                              A956ContaBancariaStatus ,
                                              A948ContaBancariaCreatedByName ,
                                              A950ContaBancariaUpdatedByName ,
                                              A973ContaBancariaRegistraBoletos ,
                                              A954ContaBancariaCreatedAt ,
                                              A955ContaBancariaUpdatedAt ,
                                              A938AgenciaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV78Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext), "%", "");
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV99Contabancariawwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV99Contabancariawwds_22_tfagenciabanconome), "%", "");
         lV112Contabancariawwds_35_tfcontabancariacreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV112Contabancariawwds_35_tfcontabancariacreatedbyname), "%", "");
         lV116Contabancariawwds_39_tfcontabancariaupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV116Contabancariawwds_39_tfcontabancariaupdatedbyname), "%", "");
         /* Using cursor P00EL4 */
         pr_default.execute(2, new Object[] {lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, lV78Contabancariawwds_1_filterfulltext, AV81Contabancariawwds_4_contabancarianumero1, AV81Contabancariawwds_4_contabancarianumero1, AV81Contabancariawwds_4_contabancarianumero1, AV82Contabancariawwds_5_agencianumero1, AV82Contabancariawwds_5_agencianumero1, AV82Contabancariawwds_5_agencianumero1, lV83Contabancariawwds_6_contabancariacreatedbyname1, lV83Contabancariawwds_6_contabancariacreatedbyname1, lV84Contabancariawwds_7_contabancariaupdatedbyname1, lV84Contabancariawwds_7_contabancariaupdatedbyname1, AV88Contabancariawwds_11_contabancarianumero2, AV88Contabancariawwds_11_contabancarianumero2, AV88Contabancariawwds_11_contabancarianumero2, AV89Contabancariawwds_12_agencianumero2, AV89Contabancariawwds_12_agencianumero2, AV89Contabancariawwds_12_agencianumero2, lV90Contabancariawwds_13_contabancariacreatedbyname2, lV90Contabancariawwds_13_contabancariacreatedbyname2, lV91Contabancariawwds_14_contabancariaupdatedbyname2, lV91Contabancariawwds_14_contabancariaupdatedbyname2, AV95Contabancariawwds_18_contabancarianumero3, AV95Contabancariawwds_18_contabancarianumero3, AV95Contabancariawwds_18_contabancarianumero3, AV96Contabancariawwds_19_agencianumero3, AV96Contabancariawwds_19_agencianumero3, AV96Contabancariawwds_19_agencianumero3, lV97Contabancariawwds_20_contabancariacreatedbyname3, lV97Contabancariawwds_20_contabancariacreatedbyname3, lV98Contabancariawwds_21_contabancariaupdatedbyname3, lV98Contabancariawwds_21_contabancariaupdatedbyname3, lV99Contabancariawwds_22_tfagenciabanconome, AV100Contabancariawwds_23_tfagenciabanconome_sel, AV101Contabancariawwds_24_tfagencianumero, AV102Contabancariawwds_25_tfagencianumero_to, AV103Contabancariawwds_26_tfcontabancarianumero, AV104Contabancariawwds_27_tfcontabancarianumero_to, AV105Contabancariawwds_28_tfcontabancariadigito, AV106Contabancariawwds_29_tfcontabancariadigito_to, AV107Contabancariawwds_30_tfcontabancariacarteira, AV108Contabancariawwds_31_tfcontabancariacarteira_to, AV110Contabancariawwds_33_tfcontabancariacreatedat, AV111Contabancariawwds_34_tfcontabancariacreatedat_to, lV112Contabancariawwds_35_tfcontabancariacreatedbyname, AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, AV114Contabancariawwds_37_tfcontabancariaupdatedat, AV115Contabancariawwds_38_tfcontabancariaupdatedat_to, lV116Contabancariawwds_39_tfcontabancariaupdatedbyname, AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, AV70AgenciaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKEL6 = false;
            A968AgenciaBancoId = P00EL4_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EL4_n968AgenciaBancoId[0];
            A947ContaBancariaCreatedBy = P00EL4_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = P00EL4_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = P00EL4_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = P00EL4_n949ContaBancariaUpdatedBy[0];
            A938AgenciaId = P00EL4_A938AgenciaId[0];
            n938AgenciaId = P00EL4_n938AgenciaId[0];
            A955ContaBancariaUpdatedAt = P00EL4_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = P00EL4_n955ContaBancariaUpdatedAt[0];
            A954ContaBancariaCreatedAt = P00EL4_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = P00EL4_n954ContaBancariaCreatedAt[0];
            A953ContaBancariaCarteira = P00EL4_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = P00EL4_n953ContaBancariaCarteira[0];
            A975ContaBancariaDigito = P00EL4_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = P00EL4_n975ContaBancariaDigito[0];
            A969AgenciaBancoNome = P00EL4_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EL4_n969AgenciaBancoNome[0];
            A950ContaBancariaUpdatedByName = P00EL4_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EL4_n950ContaBancariaUpdatedByName[0];
            A948ContaBancariaCreatedByName = P00EL4_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EL4_n948ContaBancariaCreatedByName[0];
            A939AgenciaNumero = P00EL4_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EL4_n939AgenciaNumero[0];
            A952ContaBancariaNumero = P00EL4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EL4_n952ContaBancariaNumero[0];
            A973ContaBancariaRegistraBoletos = P00EL4_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = P00EL4_n973ContaBancariaRegistraBoletos[0];
            A956ContaBancariaStatus = P00EL4_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = P00EL4_n956ContaBancariaStatus[0];
            A951ContaBancariaId = P00EL4_A951ContaBancariaId[0];
            A948ContaBancariaCreatedByName = P00EL4_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EL4_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = P00EL4_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EL4_n950ContaBancariaUpdatedByName[0];
            A968AgenciaBancoId = P00EL4_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EL4_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EL4_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EL4_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EL4_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EL4_n969AgenciaBancoNome[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00EL4_A949ContaBancariaUpdatedBy[0] == A949ContaBancariaUpdatedBy ) )
            {
               BRKEL6 = false;
               A951ContaBancariaId = P00EL4_A951ContaBancariaId[0];
               AV37count = (long)(AV37count+1);
               BRKEL6 = true;
               pr_default.readNext(2);
            }
            AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A950ContaBancariaUpdatedByName)) ? "<#Empty#>" : A950ContaBancariaUpdatedByName);
            AV31InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV31InsertIndex = (int)(AV31InsertIndex+1);
            }
            AV33Options.Add(AV32Option, AV31InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            if ( AV33Options.Count == AV28SkipItems + 11 )
            {
               AV33Options.RemoveItem(AV33Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRKEL6 )
            {
               BRKEL6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49FilterFullText = "";
         AV71TFAgenciaBancoNome = "";
         AV72TFAgenciaBancoNome_Sel = "";
         AV19TFContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         AV20TFContaBancariaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV21TFContaBancariaCreatedByName = "";
         AV22TFContaBancariaCreatedByName_Sel = "";
         AV23TFContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         AV24TFContaBancariaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV25TFContaBancariaUpdatedByName = "";
         AV26TFContaBancariaUpdatedByName_Sel = "";
         AV42GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV50DynamicFiltersSelector1 = "";
         AV54ContaBancariaCreatedByName1 = "";
         AV55ContaBancariaUpdatedByName1 = "";
         AV57DynamicFiltersSelector2 = "";
         AV61ContaBancariaCreatedByName2 = "";
         AV62ContaBancariaUpdatedByName2 = "";
         AV64DynamicFiltersSelector3 = "";
         AV68ContaBancariaCreatedByName3 = "";
         AV69ContaBancariaUpdatedByName3 = "";
         AV78Contabancariawwds_1_filterfulltext = "";
         AV79Contabancariawwds_2_dynamicfiltersselector1 = "";
         AV83Contabancariawwds_6_contabancariacreatedbyname1 = "";
         AV84Contabancariawwds_7_contabancariaupdatedbyname1 = "";
         AV86Contabancariawwds_9_dynamicfiltersselector2 = "";
         AV90Contabancariawwds_13_contabancariacreatedbyname2 = "";
         AV91Contabancariawwds_14_contabancariaupdatedbyname2 = "";
         AV93Contabancariawwds_16_dynamicfiltersselector3 = "";
         AV97Contabancariawwds_20_contabancariacreatedbyname3 = "";
         AV98Contabancariawwds_21_contabancariaupdatedbyname3 = "";
         AV99Contabancariawwds_22_tfagenciabanconome = "";
         AV100Contabancariawwds_23_tfagenciabanconome_sel = "";
         AV110Contabancariawwds_33_tfcontabancariacreatedat = (DateTime)(DateTime.MinValue);
         AV111Contabancariawwds_34_tfcontabancariacreatedat_to = (DateTime)(DateTime.MinValue);
         AV112Contabancariawwds_35_tfcontabancariacreatedbyname = "";
         AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel = "";
         AV114Contabancariawwds_37_tfcontabancariaupdatedat = (DateTime)(DateTime.MinValue);
         AV115Contabancariawwds_38_tfcontabancariaupdatedat_to = (DateTime)(DateTime.MinValue);
         AV116Contabancariawwds_39_tfcontabancariaupdatedbyname = "";
         AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = "";
         lV78Contabancariawwds_1_filterfulltext = "";
         lV83Contabancariawwds_6_contabancariacreatedbyname1 = "";
         lV84Contabancariawwds_7_contabancariaupdatedbyname1 = "";
         lV90Contabancariawwds_13_contabancariacreatedbyname2 = "";
         lV91Contabancariawwds_14_contabancariaupdatedbyname2 = "";
         lV97Contabancariawwds_20_contabancariacreatedbyname3 = "";
         lV98Contabancariawwds_21_contabancariaupdatedbyname3 = "";
         lV99Contabancariawwds_22_tfagenciabanconome = "";
         lV112Contabancariawwds_35_tfcontabancariacreatedbyname = "";
         lV116Contabancariawwds_39_tfcontabancariaupdatedbyname = "";
         A969AgenciaBancoNome = "";
         A948ContaBancariaCreatedByName = "";
         A950ContaBancariaUpdatedByName = "";
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         P00EL2_A968AgenciaBancoId = new int[1] ;
         P00EL2_n968AgenciaBancoId = new bool[] {false} ;
         P00EL2_A947ContaBancariaCreatedBy = new short[1] ;
         P00EL2_n947ContaBancariaCreatedBy = new bool[] {false} ;
         P00EL2_A949ContaBancariaUpdatedBy = new short[1] ;
         P00EL2_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         P00EL2_A969AgenciaBancoNome = new string[] {""} ;
         P00EL2_n969AgenciaBancoNome = new bool[] {false} ;
         P00EL2_A938AgenciaId = new int[1] ;
         P00EL2_n938AgenciaId = new bool[] {false} ;
         P00EL2_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EL2_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         P00EL2_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EL2_n954ContaBancariaCreatedAt = new bool[] {false} ;
         P00EL2_A953ContaBancariaCarteira = new long[1] ;
         P00EL2_n953ContaBancariaCarteira = new bool[] {false} ;
         P00EL2_A975ContaBancariaDigito = new short[1] ;
         P00EL2_n975ContaBancariaDigito = new bool[] {false} ;
         P00EL2_A950ContaBancariaUpdatedByName = new string[] {""} ;
         P00EL2_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         P00EL2_A948ContaBancariaCreatedByName = new string[] {""} ;
         P00EL2_n948ContaBancariaCreatedByName = new bool[] {false} ;
         P00EL2_A939AgenciaNumero = new int[1] ;
         P00EL2_n939AgenciaNumero = new bool[] {false} ;
         P00EL2_A952ContaBancariaNumero = new long[1] ;
         P00EL2_n952ContaBancariaNumero = new bool[] {false} ;
         P00EL2_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EL2_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EL2_A956ContaBancariaStatus = new bool[] {false} ;
         P00EL2_n956ContaBancariaStatus = new bool[] {false} ;
         P00EL2_A951ContaBancariaId = new int[1] ;
         AV32Option = "";
         P00EL3_A968AgenciaBancoId = new int[1] ;
         P00EL3_n968AgenciaBancoId = new bool[] {false} ;
         P00EL3_A949ContaBancariaUpdatedBy = new short[1] ;
         P00EL3_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         P00EL3_A947ContaBancariaCreatedBy = new short[1] ;
         P00EL3_n947ContaBancariaCreatedBy = new bool[] {false} ;
         P00EL3_A938AgenciaId = new int[1] ;
         P00EL3_n938AgenciaId = new bool[] {false} ;
         P00EL3_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EL3_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         P00EL3_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EL3_n954ContaBancariaCreatedAt = new bool[] {false} ;
         P00EL3_A953ContaBancariaCarteira = new long[1] ;
         P00EL3_n953ContaBancariaCarteira = new bool[] {false} ;
         P00EL3_A975ContaBancariaDigito = new short[1] ;
         P00EL3_n975ContaBancariaDigito = new bool[] {false} ;
         P00EL3_A969AgenciaBancoNome = new string[] {""} ;
         P00EL3_n969AgenciaBancoNome = new bool[] {false} ;
         P00EL3_A950ContaBancariaUpdatedByName = new string[] {""} ;
         P00EL3_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         P00EL3_A948ContaBancariaCreatedByName = new string[] {""} ;
         P00EL3_n948ContaBancariaCreatedByName = new bool[] {false} ;
         P00EL3_A939AgenciaNumero = new int[1] ;
         P00EL3_n939AgenciaNumero = new bool[] {false} ;
         P00EL3_A952ContaBancariaNumero = new long[1] ;
         P00EL3_n952ContaBancariaNumero = new bool[] {false} ;
         P00EL3_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EL3_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EL3_A956ContaBancariaStatus = new bool[] {false} ;
         P00EL3_n956ContaBancariaStatus = new bool[] {false} ;
         P00EL3_A951ContaBancariaId = new int[1] ;
         P00EL4_A968AgenciaBancoId = new int[1] ;
         P00EL4_n968AgenciaBancoId = new bool[] {false} ;
         P00EL4_A947ContaBancariaCreatedBy = new short[1] ;
         P00EL4_n947ContaBancariaCreatedBy = new bool[] {false} ;
         P00EL4_A949ContaBancariaUpdatedBy = new short[1] ;
         P00EL4_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         P00EL4_A938AgenciaId = new int[1] ;
         P00EL4_n938AgenciaId = new bool[] {false} ;
         P00EL4_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EL4_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         P00EL4_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EL4_n954ContaBancariaCreatedAt = new bool[] {false} ;
         P00EL4_A953ContaBancariaCarteira = new long[1] ;
         P00EL4_n953ContaBancariaCarteira = new bool[] {false} ;
         P00EL4_A975ContaBancariaDigito = new short[1] ;
         P00EL4_n975ContaBancariaDigito = new bool[] {false} ;
         P00EL4_A969AgenciaBancoNome = new string[] {""} ;
         P00EL4_n969AgenciaBancoNome = new bool[] {false} ;
         P00EL4_A950ContaBancariaUpdatedByName = new string[] {""} ;
         P00EL4_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         P00EL4_A948ContaBancariaCreatedByName = new string[] {""} ;
         P00EL4_n948ContaBancariaCreatedByName = new bool[] {false} ;
         P00EL4_A939AgenciaNumero = new int[1] ;
         P00EL4_n939AgenciaNumero = new bool[] {false} ;
         P00EL4_A952ContaBancariaNumero = new long[1] ;
         P00EL4_n952ContaBancariaNumero = new bool[] {false} ;
         P00EL4_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EL4_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EL4_A956ContaBancariaStatus = new bool[] {false} ;
         P00EL4_n956ContaBancariaStatus = new bool[] {false} ;
         P00EL4_A951ContaBancariaId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabancariawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EL2_A968AgenciaBancoId, P00EL2_n968AgenciaBancoId, P00EL2_A947ContaBancariaCreatedBy, P00EL2_n947ContaBancariaCreatedBy, P00EL2_A949ContaBancariaUpdatedBy, P00EL2_n949ContaBancariaUpdatedBy, P00EL2_A969AgenciaBancoNome, P00EL2_n969AgenciaBancoNome, P00EL2_A938AgenciaId, P00EL2_n938AgenciaId,
               P00EL2_A955ContaBancariaUpdatedAt, P00EL2_n955ContaBancariaUpdatedAt, P00EL2_A954ContaBancariaCreatedAt, P00EL2_n954ContaBancariaCreatedAt, P00EL2_A953ContaBancariaCarteira, P00EL2_n953ContaBancariaCarteira, P00EL2_A975ContaBancariaDigito, P00EL2_n975ContaBancariaDigito, P00EL2_A950ContaBancariaUpdatedByName, P00EL2_n950ContaBancariaUpdatedByName,
               P00EL2_A948ContaBancariaCreatedByName, P00EL2_n948ContaBancariaCreatedByName, P00EL2_A939AgenciaNumero, P00EL2_n939AgenciaNumero, P00EL2_A952ContaBancariaNumero, P00EL2_n952ContaBancariaNumero, P00EL2_A973ContaBancariaRegistraBoletos, P00EL2_n973ContaBancariaRegistraBoletos, P00EL2_A956ContaBancariaStatus, P00EL2_n956ContaBancariaStatus,
               P00EL2_A951ContaBancariaId
               }
               , new Object[] {
               P00EL3_A968AgenciaBancoId, P00EL3_n968AgenciaBancoId, P00EL3_A949ContaBancariaUpdatedBy, P00EL3_n949ContaBancariaUpdatedBy, P00EL3_A947ContaBancariaCreatedBy, P00EL3_n947ContaBancariaCreatedBy, P00EL3_A938AgenciaId, P00EL3_n938AgenciaId, P00EL3_A955ContaBancariaUpdatedAt, P00EL3_n955ContaBancariaUpdatedAt,
               P00EL3_A954ContaBancariaCreatedAt, P00EL3_n954ContaBancariaCreatedAt, P00EL3_A953ContaBancariaCarteira, P00EL3_n953ContaBancariaCarteira, P00EL3_A975ContaBancariaDigito, P00EL3_n975ContaBancariaDigito, P00EL3_A969AgenciaBancoNome, P00EL3_n969AgenciaBancoNome, P00EL3_A950ContaBancariaUpdatedByName, P00EL3_n950ContaBancariaUpdatedByName,
               P00EL3_A948ContaBancariaCreatedByName, P00EL3_n948ContaBancariaCreatedByName, P00EL3_A939AgenciaNumero, P00EL3_n939AgenciaNumero, P00EL3_A952ContaBancariaNumero, P00EL3_n952ContaBancariaNumero, P00EL3_A973ContaBancariaRegistraBoletos, P00EL3_n973ContaBancariaRegistraBoletos, P00EL3_A956ContaBancariaStatus, P00EL3_n956ContaBancariaStatus,
               P00EL3_A951ContaBancariaId
               }
               , new Object[] {
               P00EL4_A968AgenciaBancoId, P00EL4_n968AgenciaBancoId, P00EL4_A947ContaBancariaCreatedBy, P00EL4_n947ContaBancariaCreatedBy, P00EL4_A949ContaBancariaUpdatedBy, P00EL4_n949ContaBancariaUpdatedBy, P00EL4_A938AgenciaId, P00EL4_n938AgenciaId, P00EL4_A955ContaBancariaUpdatedAt, P00EL4_n955ContaBancariaUpdatedAt,
               P00EL4_A954ContaBancariaCreatedAt, P00EL4_n954ContaBancariaCreatedAt, P00EL4_A953ContaBancariaCarteira, P00EL4_n953ContaBancariaCarteira, P00EL4_A975ContaBancariaDigito, P00EL4_n975ContaBancariaDigito, P00EL4_A969AgenciaBancoNome, P00EL4_n969AgenciaBancoNome, P00EL4_A950ContaBancariaUpdatedByName, P00EL4_n950ContaBancariaUpdatedByName,
               P00EL4_A948ContaBancariaCreatedByName, P00EL4_n948ContaBancariaCreatedByName, P00EL4_A939AgenciaNumero, P00EL4_n939AgenciaNumero, P00EL4_A952ContaBancariaNumero, P00EL4_n952ContaBancariaNumero, P00EL4_A973ContaBancariaRegistraBoletos, P00EL4_n973ContaBancariaRegistraBoletos, P00EL4_A956ContaBancariaStatus, P00EL4_n956ContaBancariaStatus,
               P00EL4_A951ContaBancariaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private short AV74TFContaBancariaDigito ;
      private short AV75TFContaBancariaDigito_To ;
      private short AV18TFContaBancariaStatus_Sel ;
      private short AV73TFContaBancariaRegistraBoletos_Sel ;
      private short AV51DynamicFiltersOperator1 ;
      private short AV58DynamicFiltersOperator2 ;
      private short AV65DynamicFiltersOperator3 ;
      private short AV80Contabancariawwds_3_dynamicfiltersoperator1 ;
      private short AV87Contabancariawwds_10_dynamicfiltersoperator2 ;
      private short AV94Contabancariawwds_17_dynamicfiltersoperator3 ;
      private short AV105Contabancariawwds_28_tfcontabancariadigito ;
      private short AV106Contabancariawwds_29_tfcontabancariadigito_to ;
      private short AV109Contabancariawwds_32_tfcontabancariastatus_sel ;
      private short AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ;
      private short A975ContaBancariaDigito ;
      private short A947ContaBancariaCreatedBy ;
      private short A949ContaBancariaUpdatedBy ;
      private int AV76GXV1 ;
      private int AV12TFAgenciaNumero ;
      private int AV13TFAgenciaNumero_To ;
      private int AV70AgenciaId ;
      private int AV53AgenciaNumero1 ;
      private int AV60AgenciaNumero2 ;
      private int AV67AgenciaNumero3 ;
      private int AV82Contabancariawwds_5_agencianumero1 ;
      private int AV89Contabancariawwds_12_agencianumero2 ;
      private int AV96Contabancariawwds_19_agencianumero3 ;
      private int AV101Contabancariawwds_24_tfagencianumero ;
      private int AV102Contabancariawwds_25_tfagencianumero_to ;
      private int A939AgenciaNumero ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int A951ContaBancariaId ;
      private int AV31InsertIndex ;
      private long AV14TFContaBancariaNumero ;
      private long AV15TFContaBancariaNumero_To ;
      private long AV16TFContaBancariaCarteira ;
      private long AV17TFContaBancariaCarteira_To ;
      private long AV52ContaBancariaNumero1 ;
      private long AV59ContaBancariaNumero2 ;
      private long AV66ContaBancariaNumero3 ;
      private long AV81Contabancariawwds_4_contabancarianumero1 ;
      private long AV88Contabancariawwds_11_contabancarianumero2 ;
      private long AV95Contabancariawwds_18_contabancarianumero3 ;
      private long AV103Contabancariawwds_26_tfcontabancarianumero ;
      private long AV104Contabancariawwds_27_tfcontabancarianumero_to ;
      private long AV107Contabancariawwds_30_tfcontabancariacarteira ;
      private long AV108Contabancariawwds_31_tfcontabancariacarteira_to ;
      private long A952ContaBancariaNumero ;
      private long A953ContaBancariaCarteira ;
      private long AV37count ;
      private DateTime AV19TFContaBancariaCreatedAt ;
      private DateTime AV20TFContaBancariaCreatedAt_To ;
      private DateTime AV23TFContaBancariaUpdatedAt ;
      private DateTime AV24TFContaBancariaUpdatedAt_To ;
      private DateTime AV110Contabancariawwds_33_tfcontabancariacreatedat ;
      private DateTime AV111Contabancariawwds_34_tfcontabancariacreatedat_to ;
      private DateTime AV114Contabancariawwds_37_tfcontabancariaupdatedat ;
      private DateTime AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ;
      private DateTime A954ContaBancariaCreatedAt ;
      private DateTime A955ContaBancariaUpdatedAt ;
      private bool returnInSub ;
      private bool AV56DynamicFiltersEnabled2 ;
      private bool AV63DynamicFiltersEnabled3 ;
      private bool AV85Contabancariawwds_8_dynamicfiltersenabled2 ;
      private bool AV92Contabancariawwds_15_dynamicfiltersenabled3 ;
      private bool A956ContaBancariaStatus ;
      private bool A973ContaBancariaRegistraBoletos ;
      private bool BRKEL2 ;
      private bool n968AgenciaBancoId ;
      private bool n947ContaBancariaCreatedBy ;
      private bool n949ContaBancariaUpdatedBy ;
      private bool n969AgenciaBancoNome ;
      private bool n938AgenciaId ;
      private bool n955ContaBancariaUpdatedAt ;
      private bool n954ContaBancariaCreatedAt ;
      private bool n953ContaBancariaCarteira ;
      private bool n975ContaBancariaDigito ;
      private bool n950ContaBancariaUpdatedByName ;
      private bool n948ContaBancariaCreatedByName ;
      private bool n939AgenciaNumero ;
      private bool n952ContaBancariaNumero ;
      private bool n973ContaBancariaRegistraBoletos ;
      private bool n956ContaBancariaStatus ;
      private bool BRKEL4 ;
      private bool BRKEL6 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
      private string AV71TFAgenciaBancoNome ;
      private string AV72TFAgenciaBancoNome_Sel ;
      private string AV21TFContaBancariaCreatedByName ;
      private string AV22TFContaBancariaCreatedByName_Sel ;
      private string AV25TFContaBancariaUpdatedByName ;
      private string AV26TFContaBancariaUpdatedByName_Sel ;
      private string AV50DynamicFiltersSelector1 ;
      private string AV54ContaBancariaCreatedByName1 ;
      private string AV55ContaBancariaUpdatedByName1 ;
      private string AV57DynamicFiltersSelector2 ;
      private string AV61ContaBancariaCreatedByName2 ;
      private string AV62ContaBancariaUpdatedByName2 ;
      private string AV64DynamicFiltersSelector3 ;
      private string AV68ContaBancariaCreatedByName3 ;
      private string AV69ContaBancariaUpdatedByName3 ;
      private string AV78Contabancariawwds_1_filterfulltext ;
      private string AV79Contabancariawwds_2_dynamicfiltersselector1 ;
      private string AV83Contabancariawwds_6_contabancariacreatedbyname1 ;
      private string AV84Contabancariawwds_7_contabancariaupdatedbyname1 ;
      private string AV86Contabancariawwds_9_dynamicfiltersselector2 ;
      private string AV90Contabancariawwds_13_contabancariacreatedbyname2 ;
      private string AV91Contabancariawwds_14_contabancariaupdatedbyname2 ;
      private string AV93Contabancariawwds_16_dynamicfiltersselector3 ;
      private string AV97Contabancariawwds_20_contabancariacreatedbyname3 ;
      private string AV98Contabancariawwds_21_contabancariaupdatedbyname3 ;
      private string AV99Contabancariawwds_22_tfagenciabanconome ;
      private string AV100Contabancariawwds_23_tfagenciabanconome_sel ;
      private string AV112Contabancariawwds_35_tfcontabancariacreatedbyname ;
      private string AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ;
      private string AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ;
      private string AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ;
      private string lV78Contabancariawwds_1_filterfulltext ;
      private string lV83Contabancariawwds_6_contabancariacreatedbyname1 ;
      private string lV84Contabancariawwds_7_contabancariaupdatedbyname1 ;
      private string lV90Contabancariawwds_13_contabancariacreatedbyname2 ;
      private string lV91Contabancariawwds_14_contabancariaupdatedbyname2 ;
      private string lV97Contabancariawwds_20_contabancariacreatedbyname3 ;
      private string lV98Contabancariawwds_21_contabancariaupdatedbyname3 ;
      private string lV99Contabancariawwds_22_tfagenciabanconome ;
      private string lV112Contabancariawwds_35_tfcontabancariacreatedbyname ;
      private string lV116Contabancariawwds_39_tfcontabancariaupdatedbyname ;
      private string A969AgenciaBancoNome ;
      private string A948ContaBancariaCreatedByName ;
      private string A950ContaBancariaUpdatedByName ;
      private string AV32Option ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV42GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00EL2_A968AgenciaBancoId ;
      private bool[] P00EL2_n968AgenciaBancoId ;
      private short[] P00EL2_A947ContaBancariaCreatedBy ;
      private bool[] P00EL2_n947ContaBancariaCreatedBy ;
      private short[] P00EL2_A949ContaBancariaUpdatedBy ;
      private bool[] P00EL2_n949ContaBancariaUpdatedBy ;
      private string[] P00EL2_A969AgenciaBancoNome ;
      private bool[] P00EL2_n969AgenciaBancoNome ;
      private int[] P00EL2_A938AgenciaId ;
      private bool[] P00EL2_n938AgenciaId ;
      private DateTime[] P00EL2_A955ContaBancariaUpdatedAt ;
      private bool[] P00EL2_n955ContaBancariaUpdatedAt ;
      private DateTime[] P00EL2_A954ContaBancariaCreatedAt ;
      private bool[] P00EL2_n954ContaBancariaCreatedAt ;
      private long[] P00EL2_A953ContaBancariaCarteira ;
      private bool[] P00EL2_n953ContaBancariaCarteira ;
      private short[] P00EL2_A975ContaBancariaDigito ;
      private bool[] P00EL2_n975ContaBancariaDigito ;
      private string[] P00EL2_A950ContaBancariaUpdatedByName ;
      private bool[] P00EL2_n950ContaBancariaUpdatedByName ;
      private string[] P00EL2_A948ContaBancariaCreatedByName ;
      private bool[] P00EL2_n948ContaBancariaCreatedByName ;
      private int[] P00EL2_A939AgenciaNumero ;
      private bool[] P00EL2_n939AgenciaNumero ;
      private long[] P00EL2_A952ContaBancariaNumero ;
      private bool[] P00EL2_n952ContaBancariaNumero ;
      private bool[] P00EL2_A973ContaBancariaRegistraBoletos ;
      private bool[] P00EL2_n973ContaBancariaRegistraBoletos ;
      private bool[] P00EL2_A956ContaBancariaStatus ;
      private bool[] P00EL2_n956ContaBancariaStatus ;
      private int[] P00EL2_A951ContaBancariaId ;
      private int[] P00EL3_A968AgenciaBancoId ;
      private bool[] P00EL3_n968AgenciaBancoId ;
      private short[] P00EL3_A949ContaBancariaUpdatedBy ;
      private bool[] P00EL3_n949ContaBancariaUpdatedBy ;
      private short[] P00EL3_A947ContaBancariaCreatedBy ;
      private bool[] P00EL3_n947ContaBancariaCreatedBy ;
      private int[] P00EL3_A938AgenciaId ;
      private bool[] P00EL3_n938AgenciaId ;
      private DateTime[] P00EL3_A955ContaBancariaUpdatedAt ;
      private bool[] P00EL3_n955ContaBancariaUpdatedAt ;
      private DateTime[] P00EL3_A954ContaBancariaCreatedAt ;
      private bool[] P00EL3_n954ContaBancariaCreatedAt ;
      private long[] P00EL3_A953ContaBancariaCarteira ;
      private bool[] P00EL3_n953ContaBancariaCarteira ;
      private short[] P00EL3_A975ContaBancariaDigito ;
      private bool[] P00EL3_n975ContaBancariaDigito ;
      private string[] P00EL3_A969AgenciaBancoNome ;
      private bool[] P00EL3_n969AgenciaBancoNome ;
      private string[] P00EL3_A950ContaBancariaUpdatedByName ;
      private bool[] P00EL3_n950ContaBancariaUpdatedByName ;
      private string[] P00EL3_A948ContaBancariaCreatedByName ;
      private bool[] P00EL3_n948ContaBancariaCreatedByName ;
      private int[] P00EL3_A939AgenciaNumero ;
      private bool[] P00EL3_n939AgenciaNumero ;
      private long[] P00EL3_A952ContaBancariaNumero ;
      private bool[] P00EL3_n952ContaBancariaNumero ;
      private bool[] P00EL3_A973ContaBancariaRegistraBoletos ;
      private bool[] P00EL3_n973ContaBancariaRegistraBoletos ;
      private bool[] P00EL3_A956ContaBancariaStatus ;
      private bool[] P00EL3_n956ContaBancariaStatus ;
      private int[] P00EL3_A951ContaBancariaId ;
      private int[] P00EL4_A968AgenciaBancoId ;
      private bool[] P00EL4_n968AgenciaBancoId ;
      private short[] P00EL4_A947ContaBancariaCreatedBy ;
      private bool[] P00EL4_n947ContaBancariaCreatedBy ;
      private short[] P00EL4_A949ContaBancariaUpdatedBy ;
      private bool[] P00EL4_n949ContaBancariaUpdatedBy ;
      private int[] P00EL4_A938AgenciaId ;
      private bool[] P00EL4_n938AgenciaId ;
      private DateTime[] P00EL4_A955ContaBancariaUpdatedAt ;
      private bool[] P00EL4_n955ContaBancariaUpdatedAt ;
      private DateTime[] P00EL4_A954ContaBancariaCreatedAt ;
      private bool[] P00EL4_n954ContaBancariaCreatedAt ;
      private long[] P00EL4_A953ContaBancariaCarteira ;
      private bool[] P00EL4_n953ContaBancariaCarteira ;
      private short[] P00EL4_A975ContaBancariaDigito ;
      private bool[] P00EL4_n975ContaBancariaDigito ;
      private string[] P00EL4_A969AgenciaBancoNome ;
      private bool[] P00EL4_n969AgenciaBancoNome ;
      private string[] P00EL4_A950ContaBancariaUpdatedByName ;
      private bool[] P00EL4_n950ContaBancariaUpdatedByName ;
      private string[] P00EL4_A948ContaBancariaCreatedByName ;
      private bool[] P00EL4_n948ContaBancariaCreatedByName ;
      private int[] P00EL4_A939AgenciaNumero ;
      private bool[] P00EL4_n939AgenciaNumero ;
      private long[] P00EL4_A952ContaBancariaNumero ;
      private bool[] P00EL4_n952ContaBancariaNumero ;
      private bool[] P00EL4_A973ContaBancariaRegistraBoletos ;
      private bool[] P00EL4_n973ContaBancariaRegistraBoletos ;
      private bool[] P00EL4_A956ContaBancariaStatus ;
      private bool[] P00EL4_n956ContaBancariaStatus ;
      private int[] P00EL4_A951ContaBancariaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class contabancariawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EL2( IGxContext context ,
                                             string AV78Contabancariawwds_1_filterfulltext ,
                                             string AV79Contabancariawwds_2_dynamicfiltersselector1 ,
                                             short AV80Contabancariawwds_3_dynamicfiltersoperator1 ,
                                             long AV81Contabancariawwds_4_contabancarianumero1 ,
                                             int AV82Contabancariawwds_5_agencianumero1 ,
                                             string AV83Contabancariawwds_6_contabancariacreatedbyname1 ,
                                             string AV84Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                             bool AV85Contabancariawwds_8_dynamicfiltersenabled2 ,
                                             string AV86Contabancariawwds_9_dynamicfiltersselector2 ,
                                             short AV87Contabancariawwds_10_dynamicfiltersoperator2 ,
                                             long AV88Contabancariawwds_11_contabancarianumero2 ,
                                             int AV89Contabancariawwds_12_agencianumero2 ,
                                             string AV90Contabancariawwds_13_contabancariacreatedbyname2 ,
                                             string AV91Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                             bool AV92Contabancariawwds_15_dynamicfiltersenabled3 ,
                                             string AV93Contabancariawwds_16_dynamicfiltersselector3 ,
                                             short AV94Contabancariawwds_17_dynamicfiltersoperator3 ,
                                             long AV95Contabancariawwds_18_contabancarianumero3 ,
                                             int AV96Contabancariawwds_19_agencianumero3 ,
                                             string AV97Contabancariawwds_20_contabancariacreatedbyname3 ,
                                             string AV98Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                             string AV100Contabancariawwds_23_tfagenciabanconome_sel ,
                                             string AV99Contabancariawwds_22_tfagenciabanconome ,
                                             int AV101Contabancariawwds_24_tfagencianumero ,
                                             int AV102Contabancariawwds_25_tfagencianumero_to ,
                                             long AV103Contabancariawwds_26_tfcontabancarianumero ,
                                             long AV104Contabancariawwds_27_tfcontabancarianumero_to ,
                                             short AV105Contabancariawwds_28_tfcontabancariadigito ,
                                             short AV106Contabancariawwds_29_tfcontabancariadigito_to ,
                                             long AV107Contabancariawwds_30_tfcontabancariacarteira ,
                                             long AV108Contabancariawwds_31_tfcontabancariacarteira_to ,
                                             short AV109Contabancariawwds_32_tfcontabancariastatus_sel ,
                                             DateTime AV110Contabancariawwds_33_tfcontabancariacreatedat ,
                                             DateTime AV111Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                             string AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                             string AV112Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                             DateTime AV114Contabancariawwds_37_tfcontabancariaupdatedat ,
                                             DateTime AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                             string AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                             string AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                             short AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                             int AV70AgenciaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             short A975ContaBancariaDigito ,
                                             long A953ContaBancariaCarteira ,
                                             bool A956ContaBancariaStatus ,
                                             string A948ContaBancariaCreatedByName ,
                                             string A950ContaBancariaUpdatedByName ,
                                             bool A973ContaBancariaRegistraBoletos ,
                                             DateTime A954ContaBancariaCreatedAt ,
                                             DateTime A955ContaBancariaUpdatedAt ,
                                             int A938AgenciaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[60];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaBancoId AS AgenciaBancoId, T1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, T1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, T5.BancoNome AS AgenciaBancoNome, T1.AgenciaId, T1.ContaBancariaUpdatedAt, T1.ContaBancariaCreatedAt, T1.ContaBancariaCarteira, T1.ContaBancariaDigito, T3.SecUserName AS ContaBancariaUpdatedByName, T2.SecUserName AS ContaBancariaCreatedByName, T4.AgenciaNumero, T1.ContaBancariaNumero, T1.ContaBancariaRegistraBoletos, T1.ContaBancariaStatus, T1.ContaBancariaId FROM ((((ContaBancaria T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ContaBancariaCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ContaBancariaUpdatedBy) LEFT JOIN Agencia T4 ON T4.AgenciaId = T1.AgenciaId) LEFT JOIN Banco T5 ON T5.BancoId = T4.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T5.BancoNome) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T4.AgenciaNumero,'999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaDigito,'9999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaCarteira,'9999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( 'não' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = FALSE) or ( 'sim' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = TRUE))");
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
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV83Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV83Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV84Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV84Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV90Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV90Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV91Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV91Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV97Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV97Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV98Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV98Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabancariawwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabancariawwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome like :lV99Contabancariawwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabancariawwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV100Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome = ( :AV100Contabancariawwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( StringUtil.StrCmp(AV100Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.BancoNome IS NULL or (char_length(trim(trailing ' ' from T5.BancoNome))=0))");
         }
         if ( ! (0==AV101Contabancariawwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero >= :AV101Contabancariawwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( ! (0==AV102Contabancariawwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero <= :AV102Contabancariawwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( ! (0==AV103Contabancariawwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero >= :AV103Contabancariawwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( ! (0==AV104Contabancariawwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero <= :AV104Contabancariawwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( ! (0==AV105Contabancariawwds_28_tfcontabancariadigito) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito >= :AV105Contabancariawwds_28_tfcontabancariadigito)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( ! (0==AV106Contabancariawwds_29_tfcontabancariadigito_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito <= :AV106Contabancariawwds_29_tfcontabancariadigito_to)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( ! (0==AV107Contabancariawwds_30_tfcontabancariacarteira) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira >= :AV107Contabancariawwds_30_tfcontabancariacarteira)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( ! (0==AV108Contabancariawwds_31_tfcontabancariacarteira_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira <= :AV108Contabancariawwds_31_tfcontabancariacarteira_to)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( AV109Contabancariawwds_32_tfcontabancariastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = TRUE)");
         }
         if ( AV109Contabancariawwds_32_tfcontabancariastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV110Contabancariawwds_33_tfcontabancariacreatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt >= :AV110Contabancariawwds_33_tfcontabancariacreatedat)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Contabancariawwds_34_tfcontabancariacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt <= :AV111Contabancariawwds_34_tfcontabancariacreatedat_to)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabancariawwds_35_tfcontabancariacreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV112Contabancariawwds_35_tfcontabancariacreatedbyname)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel))");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( StringUtil.StrCmp(AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV114Contabancariawwds_37_tfcontabancariaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt >= :AV114Contabancariawwds_37_tfcontabancariaupdatedat)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Contabancariawwds_38_tfcontabancariaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt <= :AV115Contabancariawwds_38_tfcontabancariaupdatedat_to)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabancariawwds_39_tfcontabancariaupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV116Contabancariawwds_39_tfcontabancariaupdatedbyname)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel))");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( StringUtil.StrCmp(AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = TRUE)");
         }
         if ( AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = FALSE)");
         }
         if ( ! (0==AV70AgenciaId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaId = :AV70AgenciaId)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.BancoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00EL3( IGxContext context ,
                                             string AV78Contabancariawwds_1_filterfulltext ,
                                             string AV79Contabancariawwds_2_dynamicfiltersselector1 ,
                                             short AV80Contabancariawwds_3_dynamicfiltersoperator1 ,
                                             long AV81Contabancariawwds_4_contabancarianumero1 ,
                                             int AV82Contabancariawwds_5_agencianumero1 ,
                                             string AV83Contabancariawwds_6_contabancariacreatedbyname1 ,
                                             string AV84Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                             bool AV85Contabancariawwds_8_dynamicfiltersenabled2 ,
                                             string AV86Contabancariawwds_9_dynamicfiltersselector2 ,
                                             short AV87Contabancariawwds_10_dynamicfiltersoperator2 ,
                                             long AV88Contabancariawwds_11_contabancarianumero2 ,
                                             int AV89Contabancariawwds_12_agencianumero2 ,
                                             string AV90Contabancariawwds_13_contabancariacreatedbyname2 ,
                                             string AV91Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                             bool AV92Contabancariawwds_15_dynamicfiltersenabled3 ,
                                             string AV93Contabancariawwds_16_dynamicfiltersselector3 ,
                                             short AV94Contabancariawwds_17_dynamicfiltersoperator3 ,
                                             long AV95Contabancariawwds_18_contabancarianumero3 ,
                                             int AV96Contabancariawwds_19_agencianumero3 ,
                                             string AV97Contabancariawwds_20_contabancariacreatedbyname3 ,
                                             string AV98Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                             string AV100Contabancariawwds_23_tfagenciabanconome_sel ,
                                             string AV99Contabancariawwds_22_tfagenciabanconome ,
                                             int AV101Contabancariawwds_24_tfagencianumero ,
                                             int AV102Contabancariawwds_25_tfagencianumero_to ,
                                             long AV103Contabancariawwds_26_tfcontabancarianumero ,
                                             long AV104Contabancariawwds_27_tfcontabancarianumero_to ,
                                             short AV105Contabancariawwds_28_tfcontabancariadigito ,
                                             short AV106Contabancariawwds_29_tfcontabancariadigito_to ,
                                             long AV107Contabancariawwds_30_tfcontabancariacarteira ,
                                             long AV108Contabancariawwds_31_tfcontabancariacarteira_to ,
                                             short AV109Contabancariawwds_32_tfcontabancariastatus_sel ,
                                             DateTime AV110Contabancariawwds_33_tfcontabancariacreatedat ,
                                             DateTime AV111Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                             string AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                             string AV112Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                             DateTime AV114Contabancariawwds_37_tfcontabancariaupdatedat ,
                                             DateTime AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                             string AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                             string AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                             short AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                             int AV70AgenciaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             short A975ContaBancariaDigito ,
                                             long A953ContaBancariaCarteira ,
                                             bool A956ContaBancariaStatus ,
                                             string A948ContaBancariaCreatedByName ,
                                             string A950ContaBancariaUpdatedByName ,
                                             bool A973ContaBancariaRegistraBoletos ,
                                             DateTime A954ContaBancariaCreatedAt ,
                                             DateTime A955ContaBancariaUpdatedAt ,
                                             int A938AgenciaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[60];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaBancoId AS AgenciaBancoId, T1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, T1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, T1.AgenciaId, T1.ContaBancariaUpdatedAt, T1.ContaBancariaCreatedAt, T1.ContaBancariaCarteira, T1.ContaBancariaDigito, T5.BancoNome AS AgenciaBancoNome, T2.SecUserName AS ContaBancariaUpdatedByName, T3.SecUserName AS ContaBancariaCreatedByName, T4.AgenciaNumero, T1.ContaBancariaNumero, T1.ContaBancariaRegistraBoletos, T1.ContaBancariaStatus, T1.ContaBancariaId FROM ((((ContaBancaria T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ContaBancariaUpdatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ContaBancariaCreatedBy) LEFT JOIN Agencia T4 ON T4.AgenciaId = T1.AgenciaId) LEFT JOIN Banco T5 ON T5.BancoId = T4.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T5.BancoNome) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T4.AgenciaNumero,'999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaDigito,'9999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaCarteira,'9999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = FALSE) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( 'não' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = FALSE) or ( 'sim' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = TRUE))");
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
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV83Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV83Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV84Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV84Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV90Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV90Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV91Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV91Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV97Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV97Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV98Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV98Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabancariawwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabancariawwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome like :lV99Contabancariawwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabancariawwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV100Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome = ( :AV100Contabancariawwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV100Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.BancoNome IS NULL or (char_length(trim(trailing ' ' from T5.BancoNome))=0))");
         }
         if ( ! (0==AV101Contabancariawwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero >= :AV101Contabancariawwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (0==AV102Contabancariawwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero <= :AV102Contabancariawwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( ! (0==AV103Contabancariawwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero >= :AV103Contabancariawwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! (0==AV104Contabancariawwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero <= :AV104Contabancariawwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( ! (0==AV105Contabancariawwds_28_tfcontabancariadigito) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito >= :AV105Contabancariawwds_28_tfcontabancariadigito)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (0==AV106Contabancariawwds_29_tfcontabancariadigito_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito <= :AV106Contabancariawwds_29_tfcontabancariadigito_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( ! (0==AV107Contabancariawwds_30_tfcontabancariacarteira) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira >= :AV107Contabancariawwds_30_tfcontabancariacarteira)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! (0==AV108Contabancariawwds_31_tfcontabancariacarteira_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira <= :AV108Contabancariawwds_31_tfcontabancariacarteira_to)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV109Contabancariawwds_32_tfcontabancariastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = TRUE)");
         }
         if ( AV109Contabancariawwds_32_tfcontabancariastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV110Contabancariawwds_33_tfcontabancariacreatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt >= :AV110Contabancariawwds_33_tfcontabancariacreatedat)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Contabancariawwds_34_tfcontabancariacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt <= :AV111Contabancariawwds_34_tfcontabancariacreatedat_to)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabancariawwds_35_tfcontabancariacreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV112Contabancariawwds_35_tfcontabancariacreatedbyname)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel))");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( StringUtil.StrCmp(AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV114Contabancariawwds_37_tfcontabancariaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt >= :AV114Contabancariawwds_37_tfcontabancariaupdatedat)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Contabancariawwds_38_tfcontabancariaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt <= :AV115Contabancariawwds_38_tfcontabancariaupdatedat_to)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabancariawwds_39_tfcontabancariaupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV116Contabancariawwds_39_tfcontabancariaupdatedbyname)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel))");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( StringUtil.StrCmp(AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = TRUE)");
         }
         if ( AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = FALSE)");
         }
         if ( ! (0==AV70AgenciaId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaId = :AV70AgenciaId)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContaBancariaCreatedBy";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00EL4( IGxContext context ,
                                             string AV78Contabancariawwds_1_filterfulltext ,
                                             string AV79Contabancariawwds_2_dynamicfiltersselector1 ,
                                             short AV80Contabancariawwds_3_dynamicfiltersoperator1 ,
                                             long AV81Contabancariawwds_4_contabancarianumero1 ,
                                             int AV82Contabancariawwds_5_agencianumero1 ,
                                             string AV83Contabancariawwds_6_contabancariacreatedbyname1 ,
                                             string AV84Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                             bool AV85Contabancariawwds_8_dynamicfiltersenabled2 ,
                                             string AV86Contabancariawwds_9_dynamicfiltersselector2 ,
                                             short AV87Contabancariawwds_10_dynamicfiltersoperator2 ,
                                             long AV88Contabancariawwds_11_contabancarianumero2 ,
                                             int AV89Contabancariawwds_12_agencianumero2 ,
                                             string AV90Contabancariawwds_13_contabancariacreatedbyname2 ,
                                             string AV91Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                             bool AV92Contabancariawwds_15_dynamicfiltersenabled3 ,
                                             string AV93Contabancariawwds_16_dynamicfiltersselector3 ,
                                             short AV94Contabancariawwds_17_dynamicfiltersoperator3 ,
                                             long AV95Contabancariawwds_18_contabancarianumero3 ,
                                             int AV96Contabancariawwds_19_agencianumero3 ,
                                             string AV97Contabancariawwds_20_contabancariacreatedbyname3 ,
                                             string AV98Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                             string AV100Contabancariawwds_23_tfagenciabanconome_sel ,
                                             string AV99Contabancariawwds_22_tfagenciabanconome ,
                                             int AV101Contabancariawwds_24_tfagencianumero ,
                                             int AV102Contabancariawwds_25_tfagencianumero_to ,
                                             long AV103Contabancariawwds_26_tfcontabancarianumero ,
                                             long AV104Contabancariawwds_27_tfcontabancarianumero_to ,
                                             short AV105Contabancariawwds_28_tfcontabancariadigito ,
                                             short AV106Contabancariawwds_29_tfcontabancariadigito_to ,
                                             long AV107Contabancariawwds_30_tfcontabancariacarteira ,
                                             long AV108Contabancariawwds_31_tfcontabancariacarteira_to ,
                                             short AV109Contabancariawwds_32_tfcontabancariastatus_sel ,
                                             DateTime AV110Contabancariawwds_33_tfcontabancariacreatedat ,
                                             DateTime AV111Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                             string AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                             string AV112Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                             DateTime AV114Contabancariawwds_37_tfcontabancariaupdatedat ,
                                             DateTime AV115Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                             string AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                             string AV116Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                             short AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                             int AV70AgenciaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             short A975ContaBancariaDigito ,
                                             long A953ContaBancariaCarteira ,
                                             bool A956ContaBancariaStatus ,
                                             string A948ContaBancariaCreatedByName ,
                                             string A950ContaBancariaUpdatedByName ,
                                             bool A973ContaBancariaRegistraBoletos ,
                                             DateTime A954ContaBancariaCreatedAt ,
                                             DateTime A955ContaBancariaUpdatedAt ,
                                             int A938AgenciaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[60];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaBancoId AS AgenciaBancoId, T1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, T1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, T1.AgenciaId, T1.ContaBancariaUpdatedAt, T1.ContaBancariaCreatedAt, T1.ContaBancariaCarteira, T1.ContaBancariaDigito, T5.BancoNome AS AgenciaBancoNome, T3.SecUserName AS ContaBancariaUpdatedByName, T2.SecUserName AS ContaBancariaCreatedByName, T4.AgenciaNumero, T1.ContaBancariaNumero, T1.ContaBancariaRegistraBoletos, T1.ContaBancariaStatus, T1.ContaBancariaId FROM ((((ContaBancaria T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ContaBancariaCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ContaBancariaUpdatedBy) LEFT JOIN Agencia T4 ON T4.AgenciaId = T1.AgenciaId) LEFT JOIN Banco T5 ON T5.BancoId = T4.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabancariawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T5.BancoNome) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T4.AgenciaNumero,'999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaDigito,'9999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaCarteira,'9999999999'), 2) like '%' || :lV78Contabancariawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext)) or ( 'não' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = FALSE) or ( 'sim' like '%' || LOWER(:lV78Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = TRUE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV81Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV81Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV82Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV82Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV83Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV83Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV84Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV80Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV84Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV88Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV88Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV89Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV89Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV90Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV90Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV91Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( AV85Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV87Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV91Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV95Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV95Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV96Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV96Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV97Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV97Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV98Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( AV92Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV94Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV98Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabancariawwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Contabancariawwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome like :lV99Contabancariawwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Contabancariawwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV100Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome = ( :AV100Contabancariawwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( StringUtil.StrCmp(AV100Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.BancoNome IS NULL or (char_length(trim(trailing ' ' from T5.BancoNome))=0))");
         }
         if ( ! (0==AV101Contabancariawwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero >= :AV101Contabancariawwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! (0==AV102Contabancariawwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero <= :AV102Contabancariawwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( ! (0==AV103Contabancariawwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero >= :AV103Contabancariawwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! (0==AV104Contabancariawwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero <= :AV104Contabancariawwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( ! (0==AV105Contabancariawwds_28_tfcontabancariadigito) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito >= :AV105Contabancariawwds_28_tfcontabancariadigito)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( ! (0==AV106Contabancariawwds_29_tfcontabancariadigito_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito <= :AV106Contabancariawwds_29_tfcontabancariadigito_to)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( ! (0==AV107Contabancariawwds_30_tfcontabancariacarteira) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira >= :AV107Contabancariawwds_30_tfcontabancariacarteira)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( ! (0==AV108Contabancariawwds_31_tfcontabancariacarteira_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira <= :AV108Contabancariawwds_31_tfcontabancariacarteira_to)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( AV109Contabancariawwds_32_tfcontabancariastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = TRUE)");
         }
         if ( AV109Contabancariawwds_32_tfcontabancariastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV110Contabancariawwds_33_tfcontabancariacreatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt >= :AV110Contabancariawwds_33_tfcontabancariacreatedat)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Contabancariawwds_34_tfcontabancariacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt <= :AV111Contabancariawwds_34_tfcontabancariacreatedat_to)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Contabancariawwds_35_tfcontabancariacreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV112Contabancariawwds_35_tfcontabancariacreatedbyname)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel))");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( StringUtil.StrCmp(AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV114Contabancariawwds_37_tfcontabancariaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt >= :AV114Contabancariawwds_37_tfcontabancariaupdatedat)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Contabancariawwds_38_tfcontabancariaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt <= :AV115Contabancariawwds_38_tfcontabancariaupdatedat_to)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Contabancariawwds_39_tfcontabancariaupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV116Contabancariawwds_39_tfcontabancariaupdatedbyname)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel))");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( StringUtil.StrCmp(AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = TRUE)");
         }
         if ( AV118Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = FALSE)");
         }
         if ( ! (0==AV70AgenciaId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaId = :AV70AgenciaId)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContaBancariaUpdatedBy";
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
                     return conditional_P00EL2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (short)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (short)dynConstraints[40] , (int)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (long)dynConstraints[44] , (short)dynConstraints[45] , (long)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (bool)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
               case 1 :
                     return conditional_P00EL3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (short)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (short)dynConstraints[40] , (int)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (long)dynConstraints[44] , (short)dynConstraints[45] , (long)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (bool)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
               case 2 :
                     return conditional_P00EL4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (short)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (short)dynConstraints[40] , (int)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (long)dynConstraints[44] , (short)dynConstraints[45] , (long)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (bool)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
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
          Object[] prmP00EL2;
          prmP00EL2 = new Object[] {
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("lV83Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV84Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV84Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("lV90Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV90Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV91Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV91Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV97Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV97Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV99Contabancariawwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV100Contabancariawwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV101Contabancariawwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV102Contabancariawwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV103Contabancariawwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV104Contabancariawwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("AV105Contabancariawwds_28_tfcontabancariadigito",GXType.Int16,4,0) ,
          new ParDef("AV106Contabancariawwds_29_tfcontabancariadigito_to",GXType.Int16,4,0) ,
          new ParDef("AV107Contabancariawwds_30_tfcontabancariacarteira",GXType.Int64,10,0) ,
          new ParDef("AV108Contabancariawwds_31_tfcontabancariacarteira_to",GXType.Int64,10,0) ,
          new ParDef("AV110Contabancariawwds_33_tfcontabancariacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV111Contabancariawwds_34_tfcontabancariacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV112Contabancariawwds_35_tfcontabancariacreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV114Contabancariawwds_37_tfcontabancariaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV115Contabancariawwds_38_tfcontabancariaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV116Contabancariawwds_39_tfcontabancariaupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV70AgenciaId",GXType.Int32,9,0)
          };
          Object[] prmP00EL3;
          prmP00EL3 = new Object[] {
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("lV83Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV84Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV84Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("lV90Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV90Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV91Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV91Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV97Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV97Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV99Contabancariawwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV100Contabancariawwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV101Contabancariawwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV102Contabancariawwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV103Contabancariawwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV104Contabancariawwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("AV105Contabancariawwds_28_tfcontabancariadigito",GXType.Int16,4,0) ,
          new ParDef("AV106Contabancariawwds_29_tfcontabancariadigito_to",GXType.Int16,4,0) ,
          new ParDef("AV107Contabancariawwds_30_tfcontabancariacarteira",GXType.Int64,10,0) ,
          new ParDef("AV108Contabancariawwds_31_tfcontabancariacarteira_to",GXType.Int64,10,0) ,
          new ParDef("AV110Contabancariawwds_33_tfcontabancariacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV111Contabancariawwds_34_tfcontabancariacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV112Contabancariawwds_35_tfcontabancariacreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV114Contabancariawwds_37_tfcontabancariaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV115Contabancariawwds_38_tfcontabancariaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV116Contabancariawwds_39_tfcontabancariaupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV70AgenciaId",GXType.Int32,9,0)
          };
          Object[] prmP00EL4;
          prmP00EL4 = new Object[] {
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV82Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("lV83Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV83Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV84Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV84Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV89Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("lV90Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV90Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV91Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV91Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV96Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV97Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV97Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV99Contabancariawwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV100Contabancariawwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV101Contabancariawwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV102Contabancariawwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV103Contabancariawwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV104Contabancariawwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("AV105Contabancariawwds_28_tfcontabancariadigito",GXType.Int16,4,0) ,
          new ParDef("AV106Contabancariawwds_29_tfcontabancariadigito_to",GXType.Int16,4,0) ,
          new ParDef("AV107Contabancariawwds_30_tfcontabancariacarteira",GXType.Int64,10,0) ,
          new ParDef("AV108Contabancariawwds_31_tfcontabancariacarteira_to",GXType.Int64,10,0) ,
          new ParDef("AV110Contabancariawwds_33_tfcontabancariacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV111Contabancariawwds_34_tfcontabancariacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV112Contabancariawwds_35_tfcontabancariacreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV113Contabancariawwds_36_tfcontabancariacreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV114Contabancariawwds_37_tfcontabancariaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV115Contabancariawwds_38_tfcontabancariaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV116Contabancariawwds_39_tfcontabancariaupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV117Contabancariawwds_40_tfcontabancariaupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV70AgenciaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EL3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EL4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EL4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((long[]) buf[14])[0] = rslt.getLong(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((short[]) buf[16])[0] = rslt.getShort(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((short[]) buf[14])[0] = rslt.getShort(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((short[]) buf[14])[0] = rslt.getShort(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                return;
       }
    }

 }

}
