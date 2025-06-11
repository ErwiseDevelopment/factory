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
   public class chavepixwwgetfilterdata : GXProcedure
   {
      public chavepixwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public chavepixwwgetfilterdata( IGxContext context )
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
         this.AV54DDOName = aP0_DDOName;
         this.AV55SearchTxtParms = aP1_SearchTxtParms;
         this.AV56SearchTxtTo = aP2_SearchTxtTo;
         this.AV57OptionsJson = "" ;
         this.AV58OptionsDescJson = "" ;
         this.AV59OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV57OptionsJson;
         aP4_OptionsDescJson=this.AV58OptionsDescJson;
         aP5_OptionIndexesJson=this.AV59OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV59OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV54DDOName = aP0_DDOName;
         this.AV55SearchTxtParms = aP1_SearchTxtParms;
         this.AV56SearchTxtTo = aP2_SearchTxtTo;
         this.AV57OptionsJson = "" ;
         this.AV58OptionsDescJson = "" ;
         this.AV59OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV57OptionsJson;
         aP4_OptionsDescJson=this.AV58OptionsDescJson;
         aP5_OptionIndexesJson=this.AV59OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV44Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV46OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV47OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41MaxItems = 10;
         AV40PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV55SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV55SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV38SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV55SearchTxtParms)) ? "" : StringUtil.Substring( AV55SearchTxtParms, 3, -1));
         AV39SkipItems = (short)(AV40PageIndex*AV41MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_AGENCIABANCONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADAGENCIABANCONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CHAVEPIXCONTEUDO") == 0 )
         {
            /* Execute user subroutine: 'LOADCHAVEPIXCONTEUDOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CHAVEPIXCREATEDBYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCHAVEPIXCREATEDBYNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV54DDOName), "DDO_CHAVEPIXUPDATEDBYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCHAVEPIXUPDATEDBYNAMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV57OptionsJson = AV44Options.ToJSonString(false);
         AV58OptionsDescJson = AV46OptionsDesc.ToJSonString(false);
         AV59OptionIndexesJson = AV47OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV49Session.Get("ChavePIXWWGridState"), "") == 0 )
         {
            AV51GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ChavePIXWWGridState"), null, "", "");
         }
         else
         {
            AV51GridState.FromXml(AV49Session.Get("ChavePIXWWGridState"), null, "", "");
         }
         AV82GXV1 = 1;
         while ( AV82GXV1 <= AV51GridState.gxTpr_Filtervalues.Count )
         {
            AV52GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV51GridState.gxTpr_Filtervalues.Item(AV82GXV1));
            if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV60FilterFullText = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV24TFAgenciaBancoNome = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV25TFAgenciaBancoNome_Sel = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV22TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV23TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIANUMERO") == 0 )
            {
               AV20TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV21TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXTIPO_SEL") == 0 )
            {
               AV12TFChavePIXTipo_SelsJson = AV52GridStateFilterValue.gxTpr_Value;
               AV13TFChavePIXTipo_Sels.FromJSonString(AV12TFChavePIXTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCONTEUDO") == 0 )
            {
               AV14TFChavePIXConteudo = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCONTEUDO_SEL") == 0 )
            {
               AV15TFChavePIXConteudo_Sel = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXSTATUS_SEL") == 0 )
            {
               AV16TFChavePIXStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXPRINCIPAL_SEL") == 0 )
            {
               AV17TFChavePIXPrincipal_Sel = (short)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDAT") == 0 )
            {
               AV26TFChavePIXCreatedAt = context.localUtil.CToT( AV52GridStateFilterValue.gxTpr_Value, 4);
               AV27TFChavePIXCreatedAt_To = context.localUtil.CToT( AV52GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDBYNAME") == 0 )
            {
               AV30TFChavePIXCreatedByName = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDBYNAME_SEL") == 0 )
            {
               AV31TFChavePIXCreatedByName_Sel = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDAT") == 0 )
            {
               AV32TFChavePIXUpdatedAt = context.localUtil.CToT( AV52GridStateFilterValue.gxTpr_Value, 4);
               AV33TFChavePIXUpdatedAt_To = context.localUtil.CToT( AV52GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDBYNAME") == 0 )
            {
               AV36TFChavePIXUpdatedByName = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDBYNAME_SEL") == 0 )
            {
               AV37TFChavePIXUpdatedByName_Sel = AV52GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52GridStateFilterValue.gxTpr_Name, "PARM_&CONTABANCARIAID") == 0 )
            {
               AV81ContaBancariaId = (int)(Math.Round(NumberUtil.Val( AV52GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV82GXV1 = (int)(AV82GXV1+1);
         }
         if ( AV51GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV53GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV51GridState.gxTpr_Dynamicfilters.Item(1));
            AV61DynamicFiltersSelector1 = AV53GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV61DynamicFiltersSelector1, "CHAVEPIXTIPO") == 0 )
            {
               AV63ChavePIXTipo1 = AV53GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV62DynamicFiltersOperator1 = AV53GridStateDynamicFilter.gxTpr_Operator;
               AV64ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV53GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV61DynamicFiltersSelector1, "CHAVEPIXCREATEDBYNAME") == 0 )
            {
               AV62DynamicFiltersOperator1 = AV53GridStateDynamicFilter.gxTpr_Operator;
               AV65ChavePIXCreatedByName1 = AV53GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61DynamicFiltersSelector1, "CHAVEPIXUPDATEDBYNAME") == 0 )
            {
               AV62DynamicFiltersOperator1 = AV53GridStateDynamicFilter.gxTpr_Operator;
               AV66ChavePIXUpdatedByName1 = AV53GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV51GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV67DynamicFiltersEnabled2 = true;
               AV53GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV51GridState.gxTpr_Dynamicfilters.Item(2));
               AV68DynamicFiltersSelector2 = AV53GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV68DynamicFiltersSelector2, "CHAVEPIXTIPO") == 0 )
               {
                  AV70ChavePIXTipo2 = AV53GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV68DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV69DynamicFiltersOperator2 = AV53GridStateDynamicFilter.gxTpr_Operator;
                  AV71ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV53GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV68DynamicFiltersSelector2, "CHAVEPIXCREATEDBYNAME") == 0 )
               {
                  AV69DynamicFiltersOperator2 = AV53GridStateDynamicFilter.gxTpr_Operator;
                  AV72ChavePIXCreatedByName2 = AV53GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV68DynamicFiltersSelector2, "CHAVEPIXUPDATEDBYNAME") == 0 )
               {
                  AV69DynamicFiltersOperator2 = AV53GridStateDynamicFilter.gxTpr_Operator;
                  AV73ChavePIXUpdatedByName2 = AV53GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV51GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV74DynamicFiltersEnabled3 = true;
                  AV53GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV51GridState.gxTpr_Dynamicfilters.Item(3));
                  AV75DynamicFiltersSelector3 = AV53GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV75DynamicFiltersSelector3, "CHAVEPIXTIPO") == 0 )
                  {
                     AV77ChavePIXTipo3 = AV53GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV75DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV76DynamicFiltersOperator3 = AV53GridStateDynamicFilter.gxTpr_Operator;
                     AV78ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV53GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV75DynamicFiltersSelector3, "CHAVEPIXCREATEDBYNAME") == 0 )
                  {
                     AV76DynamicFiltersOperator3 = AV53GridStateDynamicFilter.gxTpr_Operator;
                     AV79ChavePIXCreatedByName3 = AV53GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV75DynamicFiltersSelector3, "CHAVEPIXUPDATEDBYNAME") == 0 )
                  {
                     AV76DynamicFiltersOperator3 = AV53GridStateDynamicFilter.gxTpr_Operator;
                     AV80ChavePIXUpdatedByName3 = AV53GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADAGENCIABANCONOMEOPTIONS' Routine */
         returnInSub = false;
         AV24TFAgenciaBancoNome = AV38SearchTxt;
         AV25TFAgenciaBancoNome_Sel = "";
         AV84Chavepixwwds_1_filterfulltext = AV60FilterFullText;
         AV85Chavepixwwds_2_dynamicfiltersselector1 = AV61DynamicFiltersSelector1;
         AV86Chavepixwwds_3_dynamicfiltersoperator1 = AV62DynamicFiltersOperator1;
         AV87Chavepixwwds_4_chavepixtipo1 = AV63ChavePIXTipo1;
         AV88Chavepixwwds_5_contabancarianumero1 = AV64ContaBancariaNumero1;
         AV89Chavepixwwds_6_chavepixcreatedbyname1 = AV65ChavePIXCreatedByName1;
         AV90Chavepixwwds_7_chavepixupdatedbyname1 = AV66ChavePIXUpdatedByName1;
         AV91Chavepixwwds_8_dynamicfiltersenabled2 = AV67DynamicFiltersEnabled2;
         AV92Chavepixwwds_9_dynamicfiltersselector2 = AV68DynamicFiltersSelector2;
         AV93Chavepixwwds_10_dynamicfiltersoperator2 = AV69DynamicFiltersOperator2;
         AV94Chavepixwwds_11_chavepixtipo2 = AV70ChavePIXTipo2;
         AV95Chavepixwwds_12_contabancarianumero2 = AV71ContaBancariaNumero2;
         AV96Chavepixwwds_13_chavepixcreatedbyname2 = AV72ChavePIXCreatedByName2;
         AV97Chavepixwwds_14_chavepixupdatedbyname2 = AV73ChavePIXUpdatedByName2;
         AV98Chavepixwwds_15_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV99Chavepixwwds_16_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV100Chavepixwwds_17_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV101Chavepixwwds_18_chavepixtipo3 = AV77ChavePIXTipo3;
         AV102Chavepixwwds_19_contabancarianumero3 = AV78ContaBancariaNumero3;
         AV103Chavepixwwds_20_chavepixcreatedbyname3 = AV79ChavePIXCreatedByName3;
         AV104Chavepixwwds_21_chavepixupdatedbyname3 = AV80ChavePIXUpdatedByName3;
         AV105Chavepixwwds_22_tfagenciabanconome = AV24TFAgenciaBancoNome;
         AV106Chavepixwwds_23_tfagenciabanconome_sel = AV25TFAgenciaBancoNome_Sel;
         AV107Chavepixwwds_24_tfagencianumero = AV22TFAgenciaNumero;
         AV108Chavepixwwds_25_tfagencianumero_to = AV23TFAgenciaNumero_To;
         AV109Chavepixwwds_26_tfcontabancarianumero = AV20TFContaBancariaNumero;
         AV110Chavepixwwds_27_tfcontabancarianumero_to = AV21TFContaBancariaNumero_To;
         AV111Chavepixwwds_28_tfchavepixtipo_sels = AV13TFChavePIXTipo_Sels;
         AV112Chavepixwwds_29_tfchavepixconteudo = AV14TFChavePIXConteudo;
         AV113Chavepixwwds_30_tfchavepixconteudo_sel = AV15TFChavePIXConteudo_Sel;
         AV114Chavepixwwds_31_tfchavepixstatus_sel = AV16TFChavePIXStatus_Sel;
         AV115Chavepixwwds_32_tfchavepixprincipal_sel = AV17TFChavePIXPrincipal_Sel;
         AV116Chavepixwwds_33_tfchavepixcreatedat = AV26TFChavePIXCreatedAt;
         AV117Chavepixwwds_34_tfchavepixcreatedat_to = AV27TFChavePIXCreatedAt_To;
         AV118Chavepixwwds_35_tfchavepixcreatedbyname = AV30TFChavePIXCreatedByName;
         AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV31TFChavePIXCreatedByName_Sel;
         AV120Chavepixwwds_37_tfchavepixupdatedat = AV32TFChavePIXUpdatedAt;
         AV121Chavepixwwds_38_tfchavepixupdatedat_to = AV33TFChavePIXUpdatedAt_To;
         AV122Chavepixwwds_39_tfchavepixupdatedbyname = AV36TFChavePIXUpdatedByName;
         AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV37TFChavePIXUpdatedByName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A962ChavePIXTipo ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                              AV84Chavepixwwds_1_filterfulltext ,
                                              AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                              AV87Chavepixwwds_4_chavepixtipo1 ,
                                              AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                              AV88Chavepixwwds_5_contabancarianumero1 ,
                                              AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                              AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                              AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                              AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                              AV94Chavepixwwds_11_chavepixtipo2 ,
                                              AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                              AV95Chavepixwwds_12_contabancarianumero2 ,
                                              AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                              AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                              AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                              AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                              AV101Chavepixwwds_18_chavepixtipo3 ,
                                              AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                              AV102Chavepixwwds_19_contabancarianumero3 ,
                                              AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                              AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                              AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                              AV105Chavepixwwds_22_tfagenciabanconome ,
                                              AV107Chavepixwwds_24_tfagencianumero ,
                                              AV108Chavepixwwds_25_tfagencianumero_to ,
                                              AV109Chavepixwwds_26_tfcontabancarianumero ,
                                              AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                              AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                              AV112Chavepixwwds_29_tfchavepixconteudo ,
                                              AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                              AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                              AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                              AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                              AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                              AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                              AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                              AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                              AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                              AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                              AV81ContaBancariaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A963ChavePIXConteudo ,
                                              A964ChavePIXStatus ,
                                              A965ChavePIXPrincipal ,
                                              A958ChavePIXCreatedByName ,
                                              A960ChavePIXUpdatedByName ,
                                              A966ChavePIXCreatedAt ,
                                              A967ChavePIXUpdatedAt ,
                                              A951ContaBancariaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV105Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome), "%", "");
         lV112Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo), "%", "");
         lV118Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
         lV122Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
         /* Using cursor P00EQ2 */
         pr_default.execute(0, new Object[] {lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, AV87Chavepixwwds_4_chavepixtipo1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, AV94Chavepixwwds_11_chavepixtipo2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, AV101Chavepixwwds_18_chavepixtipo3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV105Chavepixwwds_22_tfagenciabanconome, AV106Chavepixwwds_23_tfagenciabanconome_sel, AV107Chavepixwwds_24_tfagencianumero, AV108Chavepixwwds_25_tfagencianumero_to, AV109Chavepixwwds_26_tfcontabancarianumero, AV110Chavepixwwds_27_tfcontabancarianumero_to, lV112Chavepixwwds_29_tfchavepixconteudo, AV113Chavepixwwds_30_tfchavepixconteudo_sel, AV116Chavepixwwds_33_tfchavepixcreatedat, AV117Chavepixwwds_34_tfchavepixcreatedat_to, lV118Chavepixwwds_35_tfchavepixcreatedbyname, AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV120Chavepixwwds_37_tfchavepixupdatedat, AV121Chavepixwwds_38_tfchavepixupdatedat_to, lV122Chavepixwwds_39_tfchavepixupdatedbyname, AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV81ContaBancariaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEQ2 = false;
            A938AgenciaId = P00EQ2_A938AgenciaId[0];
            n938AgenciaId = P00EQ2_n938AgenciaId[0];
            A968AgenciaBancoId = P00EQ2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ2_n968AgenciaBancoId[0];
            A957ChavePIXCreatedBy = P00EQ2_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = P00EQ2_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = P00EQ2_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = P00EQ2_n959ChavePIXUpdatedBy[0];
            A969AgenciaBancoNome = P00EQ2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ2_n969AgenciaBancoNome[0];
            A951ContaBancariaId = P00EQ2_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EQ2_n951ContaBancariaId[0];
            A967ChavePIXUpdatedAt = P00EQ2_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = P00EQ2_n967ChavePIXUpdatedAt[0];
            A966ChavePIXCreatedAt = P00EQ2_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = P00EQ2_n966ChavePIXCreatedAt[0];
            A963ChavePIXConteudo = P00EQ2_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = P00EQ2_n963ChavePIXConteudo[0];
            A939AgenciaNumero = P00EQ2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ2_n939AgenciaNumero[0];
            A960ChavePIXUpdatedByName = P00EQ2_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ2_n960ChavePIXUpdatedByName[0];
            A958ChavePIXCreatedByName = P00EQ2_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ2_n958ChavePIXCreatedByName[0];
            A952ContaBancariaNumero = P00EQ2_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ2_n952ContaBancariaNumero[0];
            A965ChavePIXPrincipal = P00EQ2_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = P00EQ2_n965ChavePIXPrincipal[0];
            A964ChavePIXStatus = P00EQ2_A964ChavePIXStatus[0];
            n964ChavePIXStatus = P00EQ2_n964ChavePIXStatus[0];
            A962ChavePIXTipo = P00EQ2_A962ChavePIXTipo[0];
            n962ChavePIXTipo = P00EQ2_n962ChavePIXTipo[0];
            A961ChavePIXId = P00EQ2_A961ChavePIXId[0];
            A958ChavePIXCreatedByName = P00EQ2_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ2_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = P00EQ2_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ2_n960ChavePIXUpdatedByName[0];
            A938AgenciaId = P00EQ2_A938AgenciaId[0];
            n938AgenciaId = P00EQ2_n938AgenciaId[0];
            A952ContaBancariaNumero = P00EQ2_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ2_n952ContaBancariaNumero[0];
            A968AgenciaBancoId = P00EQ2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ2_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EQ2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ2_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ2_n969AgenciaBancoNome[0];
            AV48count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EQ2_A969AgenciaBancoNome[0], A969AgenciaBancoNome) == 0 ) )
            {
               BRKEQ2 = false;
               A938AgenciaId = P00EQ2_A938AgenciaId[0];
               n938AgenciaId = P00EQ2_n938AgenciaId[0];
               A968AgenciaBancoId = P00EQ2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = P00EQ2_n968AgenciaBancoId[0];
               A951ContaBancariaId = P00EQ2_A951ContaBancariaId[0];
               n951ContaBancariaId = P00EQ2_n951ContaBancariaId[0];
               A961ChavePIXId = P00EQ2_A961ChavePIXId[0];
               A938AgenciaId = P00EQ2_A938AgenciaId[0];
               n938AgenciaId = P00EQ2_n938AgenciaId[0];
               A968AgenciaBancoId = P00EQ2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = P00EQ2_n968AgenciaBancoId[0];
               AV48count = (long)(AV48count+1);
               BRKEQ2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV39SkipItems) )
            {
               AV43Option = (String.IsNullOrEmpty(StringUtil.RTrim( A969AgenciaBancoNome)) ? "<#Empty#>" : A969AgenciaBancoNome);
               AV44Options.Add(AV43Option, 0);
               AV47OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV48count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV44Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV39SkipItems = (short)(AV39SkipItems-1);
            }
            if ( ! BRKEQ2 )
            {
               BRKEQ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCHAVEPIXCONTEUDOOPTIONS' Routine */
         returnInSub = false;
         AV14TFChavePIXConteudo = AV38SearchTxt;
         AV15TFChavePIXConteudo_Sel = "";
         AV84Chavepixwwds_1_filterfulltext = AV60FilterFullText;
         AV85Chavepixwwds_2_dynamicfiltersselector1 = AV61DynamicFiltersSelector1;
         AV86Chavepixwwds_3_dynamicfiltersoperator1 = AV62DynamicFiltersOperator1;
         AV87Chavepixwwds_4_chavepixtipo1 = AV63ChavePIXTipo1;
         AV88Chavepixwwds_5_contabancarianumero1 = AV64ContaBancariaNumero1;
         AV89Chavepixwwds_6_chavepixcreatedbyname1 = AV65ChavePIXCreatedByName1;
         AV90Chavepixwwds_7_chavepixupdatedbyname1 = AV66ChavePIXUpdatedByName1;
         AV91Chavepixwwds_8_dynamicfiltersenabled2 = AV67DynamicFiltersEnabled2;
         AV92Chavepixwwds_9_dynamicfiltersselector2 = AV68DynamicFiltersSelector2;
         AV93Chavepixwwds_10_dynamicfiltersoperator2 = AV69DynamicFiltersOperator2;
         AV94Chavepixwwds_11_chavepixtipo2 = AV70ChavePIXTipo2;
         AV95Chavepixwwds_12_contabancarianumero2 = AV71ContaBancariaNumero2;
         AV96Chavepixwwds_13_chavepixcreatedbyname2 = AV72ChavePIXCreatedByName2;
         AV97Chavepixwwds_14_chavepixupdatedbyname2 = AV73ChavePIXUpdatedByName2;
         AV98Chavepixwwds_15_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV99Chavepixwwds_16_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV100Chavepixwwds_17_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV101Chavepixwwds_18_chavepixtipo3 = AV77ChavePIXTipo3;
         AV102Chavepixwwds_19_contabancarianumero3 = AV78ContaBancariaNumero3;
         AV103Chavepixwwds_20_chavepixcreatedbyname3 = AV79ChavePIXCreatedByName3;
         AV104Chavepixwwds_21_chavepixupdatedbyname3 = AV80ChavePIXUpdatedByName3;
         AV105Chavepixwwds_22_tfagenciabanconome = AV24TFAgenciaBancoNome;
         AV106Chavepixwwds_23_tfagenciabanconome_sel = AV25TFAgenciaBancoNome_Sel;
         AV107Chavepixwwds_24_tfagencianumero = AV22TFAgenciaNumero;
         AV108Chavepixwwds_25_tfagencianumero_to = AV23TFAgenciaNumero_To;
         AV109Chavepixwwds_26_tfcontabancarianumero = AV20TFContaBancariaNumero;
         AV110Chavepixwwds_27_tfcontabancarianumero_to = AV21TFContaBancariaNumero_To;
         AV111Chavepixwwds_28_tfchavepixtipo_sels = AV13TFChavePIXTipo_Sels;
         AV112Chavepixwwds_29_tfchavepixconteudo = AV14TFChavePIXConteudo;
         AV113Chavepixwwds_30_tfchavepixconteudo_sel = AV15TFChavePIXConteudo_Sel;
         AV114Chavepixwwds_31_tfchavepixstatus_sel = AV16TFChavePIXStatus_Sel;
         AV115Chavepixwwds_32_tfchavepixprincipal_sel = AV17TFChavePIXPrincipal_Sel;
         AV116Chavepixwwds_33_tfchavepixcreatedat = AV26TFChavePIXCreatedAt;
         AV117Chavepixwwds_34_tfchavepixcreatedat_to = AV27TFChavePIXCreatedAt_To;
         AV118Chavepixwwds_35_tfchavepixcreatedbyname = AV30TFChavePIXCreatedByName;
         AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV31TFChavePIXCreatedByName_Sel;
         AV120Chavepixwwds_37_tfchavepixupdatedat = AV32TFChavePIXUpdatedAt;
         AV121Chavepixwwds_38_tfchavepixupdatedat_to = AV33TFChavePIXUpdatedAt_To;
         AV122Chavepixwwds_39_tfchavepixupdatedbyname = AV36TFChavePIXUpdatedByName;
         AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV37TFChavePIXUpdatedByName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A962ChavePIXTipo ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                              AV84Chavepixwwds_1_filterfulltext ,
                                              AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                              AV87Chavepixwwds_4_chavepixtipo1 ,
                                              AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                              AV88Chavepixwwds_5_contabancarianumero1 ,
                                              AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                              AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                              AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                              AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                              AV94Chavepixwwds_11_chavepixtipo2 ,
                                              AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                              AV95Chavepixwwds_12_contabancarianumero2 ,
                                              AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                              AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                              AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                              AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                              AV101Chavepixwwds_18_chavepixtipo3 ,
                                              AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                              AV102Chavepixwwds_19_contabancarianumero3 ,
                                              AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                              AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                              AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                              AV105Chavepixwwds_22_tfagenciabanconome ,
                                              AV107Chavepixwwds_24_tfagencianumero ,
                                              AV108Chavepixwwds_25_tfagencianumero_to ,
                                              AV109Chavepixwwds_26_tfcontabancarianumero ,
                                              AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                              AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                              AV112Chavepixwwds_29_tfchavepixconteudo ,
                                              AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                              AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                              AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                              AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                              AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                              AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                              AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                              AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                              AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                              AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                              AV81ContaBancariaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A963ChavePIXConteudo ,
                                              A964ChavePIXStatus ,
                                              A965ChavePIXPrincipal ,
                                              A958ChavePIXCreatedByName ,
                                              A960ChavePIXUpdatedByName ,
                                              A966ChavePIXCreatedAt ,
                                              A967ChavePIXUpdatedAt ,
                                              A951ContaBancariaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV105Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome), "%", "");
         lV112Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo), "%", "");
         lV118Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
         lV122Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
         /* Using cursor P00EQ3 */
         pr_default.execute(1, new Object[] {lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, AV87Chavepixwwds_4_chavepixtipo1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, AV94Chavepixwwds_11_chavepixtipo2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, AV101Chavepixwwds_18_chavepixtipo3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV105Chavepixwwds_22_tfagenciabanconome, AV106Chavepixwwds_23_tfagenciabanconome_sel, AV107Chavepixwwds_24_tfagencianumero, AV108Chavepixwwds_25_tfagencianumero_to, AV109Chavepixwwds_26_tfcontabancarianumero, AV110Chavepixwwds_27_tfcontabancarianumero_to, lV112Chavepixwwds_29_tfchavepixconteudo, AV113Chavepixwwds_30_tfchavepixconteudo_sel, AV116Chavepixwwds_33_tfchavepixcreatedat, AV117Chavepixwwds_34_tfchavepixcreatedat_to, lV118Chavepixwwds_35_tfchavepixcreatedbyname, AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV120Chavepixwwds_37_tfchavepixupdatedat, AV121Chavepixwwds_38_tfchavepixupdatedat_to, lV122Chavepixwwds_39_tfchavepixupdatedbyname, AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV81ContaBancariaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEQ4 = false;
            A938AgenciaId = P00EQ3_A938AgenciaId[0];
            n938AgenciaId = P00EQ3_n938AgenciaId[0];
            A968AgenciaBancoId = P00EQ3_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ3_n968AgenciaBancoId[0];
            A957ChavePIXCreatedBy = P00EQ3_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = P00EQ3_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = P00EQ3_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = P00EQ3_n959ChavePIXUpdatedBy[0];
            A963ChavePIXConteudo = P00EQ3_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = P00EQ3_n963ChavePIXConteudo[0];
            A951ContaBancariaId = P00EQ3_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EQ3_n951ContaBancariaId[0];
            A967ChavePIXUpdatedAt = P00EQ3_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = P00EQ3_n967ChavePIXUpdatedAt[0];
            A966ChavePIXCreatedAt = P00EQ3_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = P00EQ3_n966ChavePIXCreatedAt[0];
            A939AgenciaNumero = P00EQ3_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ3_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ3_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ3_n969AgenciaBancoNome[0];
            A960ChavePIXUpdatedByName = P00EQ3_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ3_n960ChavePIXUpdatedByName[0];
            A958ChavePIXCreatedByName = P00EQ3_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ3_n958ChavePIXCreatedByName[0];
            A952ContaBancariaNumero = P00EQ3_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ3_n952ContaBancariaNumero[0];
            A965ChavePIXPrincipal = P00EQ3_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = P00EQ3_n965ChavePIXPrincipal[0];
            A964ChavePIXStatus = P00EQ3_A964ChavePIXStatus[0];
            n964ChavePIXStatus = P00EQ3_n964ChavePIXStatus[0];
            A962ChavePIXTipo = P00EQ3_A962ChavePIXTipo[0];
            n962ChavePIXTipo = P00EQ3_n962ChavePIXTipo[0];
            A961ChavePIXId = P00EQ3_A961ChavePIXId[0];
            A958ChavePIXCreatedByName = P00EQ3_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ3_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = P00EQ3_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ3_n960ChavePIXUpdatedByName[0];
            A938AgenciaId = P00EQ3_A938AgenciaId[0];
            n938AgenciaId = P00EQ3_n938AgenciaId[0];
            A952ContaBancariaNumero = P00EQ3_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ3_n952ContaBancariaNumero[0];
            A968AgenciaBancoId = P00EQ3_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ3_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EQ3_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ3_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ3_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ3_n969AgenciaBancoNome[0];
            AV48count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EQ3_A963ChavePIXConteudo[0], A963ChavePIXConteudo) == 0 ) )
            {
               BRKEQ4 = false;
               A961ChavePIXId = P00EQ3_A961ChavePIXId[0];
               AV48count = (long)(AV48count+1);
               BRKEQ4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV39SkipItems) )
            {
               AV43Option = (String.IsNullOrEmpty(StringUtil.RTrim( A963ChavePIXConteudo)) ? "<#Empty#>" : A963ChavePIXConteudo);
               AV44Options.Add(AV43Option, 0);
               AV47OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV48count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV44Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV39SkipItems = (short)(AV39SkipItems-1);
            }
            if ( ! BRKEQ4 )
            {
               BRKEQ4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCHAVEPIXCREATEDBYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV30TFChavePIXCreatedByName = AV38SearchTxt;
         AV31TFChavePIXCreatedByName_Sel = "";
         AV84Chavepixwwds_1_filterfulltext = AV60FilterFullText;
         AV85Chavepixwwds_2_dynamicfiltersselector1 = AV61DynamicFiltersSelector1;
         AV86Chavepixwwds_3_dynamicfiltersoperator1 = AV62DynamicFiltersOperator1;
         AV87Chavepixwwds_4_chavepixtipo1 = AV63ChavePIXTipo1;
         AV88Chavepixwwds_5_contabancarianumero1 = AV64ContaBancariaNumero1;
         AV89Chavepixwwds_6_chavepixcreatedbyname1 = AV65ChavePIXCreatedByName1;
         AV90Chavepixwwds_7_chavepixupdatedbyname1 = AV66ChavePIXUpdatedByName1;
         AV91Chavepixwwds_8_dynamicfiltersenabled2 = AV67DynamicFiltersEnabled2;
         AV92Chavepixwwds_9_dynamicfiltersselector2 = AV68DynamicFiltersSelector2;
         AV93Chavepixwwds_10_dynamicfiltersoperator2 = AV69DynamicFiltersOperator2;
         AV94Chavepixwwds_11_chavepixtipo2 = AV70ChavePIXTipo2;
         AV95Chavepixwwds_12_contabancarianumero2 = AV71ContaBancariaNumero2;
         AV96Chavepixwwds_13_chavepixcreatedbyname2 = AV72ChavePIXCreatedByName2;
         AV97Chavepixwwds_14_chavepixupdatedbyname2 = AV73ChavePIXUpdatedByName2;
         AV98Chavepixwwds_15_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV99Chavepixwwds_16_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV100Chavepixwwds_17_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV101Chavepixwwds_18_chavepixtipo3 = AV77ChavePIXTipo3;
         AV102Chavepixwwds_19_contabancarianumero3 = AV78ContaBancariaNumero3;
         AV103Chavepixwwds_20_chavepixcreatedbyname3 = AV79ChavePIXCreatedByName3;
         AV104Chavepixwwds_21_chavepixupdatedbyname3 = AV80ChavePIXUpdatedByName3;
         AV105Chavepixwwds_22_tfagenciabanconome = AV24TFAgenciaBancoNome;
         AV106Chavepixwwds_23_tfagenciabanconome_sel = AV25TFAgenciaBancoNome_Sel;
         AV107Chavepixwwds_24_tfagencianumero = AV22TFAgenciaNumero;
         AV108Chavepixwwds_25_tfagencianumero_to = AV23TFAgenciaNumero_To;
         AV109Chavepixwwds_26_tfcontabancarianumero = AV20TFContaBancariaNumero;
         AV110Chavepixwwds_27_tfcontabancarianumero_to = AV21TFContaBancariaNumero_To;
         AV111Chavepixwwds_28_tfchavepixtipo_sels = AV13TFChavePIXTipo_Sels;
         AV112Chavepixwwds_29_tfchavepixconteudo = AV14TFChavePIXConteudo;
         AV113Chavepixwwds_30_tfchavepixconteudo_sel = AV15TFChavePIXConteudo_Sel;
         AV114Chavepixwwds_31_tfchavepixstatus_sel = AV16TFChavePIXStatus_Sel;
         AV115Chavepixwwds_32_tfchavepixprincipal_sel = AV17TFChavePIXPrincipal_Sel;
         AV116Chavepixwwds_33_tfchavepixcreatedat = AV26TFChavePIXCreatedAt;
         AV117Chavepixwwds_34_tfchavepixcreatedat_to = AV27TFChavePIXCreatedAt_To;
         AV118Chavepixwwds_35_tfchavepixcreatedbyname = AV30TFChavePIXCreatedByName;
         AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV31TFChavePIXCreatedByName_Sel;
         AV120Chavepixwwds_37_tfchavepixupdatedat = AV32TFChavePIXUpdatedAt;
         AV121Chavepixwwds_38_tfchavepixupdatedat_to = AV33TFChavePIXUpdatedAt_To;
         AV122Chavepixwwds_39_tfchavepixupdatedbyname = AV36TFChavePIXUpdatedByName;
         AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV37TFChavePIXUpdatedByName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A962ChavePIXTipo ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                              AV84Chavepixwwds_1_filterfulltext ,
                                              AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                              AV87Chavepixwwds_4_chavepixtipo1 ,
                                              AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                              AV88Chavepixwwds_5_contabancarianumero1 ,
                                              AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                              AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                              AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                              AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                              AV94Chavepixwwds_11_chavepixtipo2 ,
                                              AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                              AV95Chavepixwwds_12_contabancarianumero2 ,
                                              AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                              AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                              AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                              AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                              AV101Chavepixwwds_18_chavepixtipo3 ,
                                              AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                              AV102Chavepixwwds_19_contabancarianumero3 ,
                                              AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                              AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                              AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                              AV105Chavepixwwds_22_tfagenciabanconome ,
                                              AV107Chavepixwwds_24_tfagencianumero ,
                                              AV108Chavepixwwds_25_tfagencianumero_to ,
                                              AV109Chavepixwwds_26_tfcontabancarianumero ,
                                              AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                              AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                              AV112Chavepixwwds_29_tfchavepixconteudo ,
                                              AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                              AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                              AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                              AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                              AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                              AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                              AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                              AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                              AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                              AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                              AV81ContaBancariaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A963ChavePIXConteudo ,
                                              A964ChavePIXStatus ,
                                              A965ChavePIXPrincipal ,
                                              A958ChavePIXCreatedByName ,
                                              A960ChavePIXUpdatedByName ,
                                              A966ChavePIXCreatedAt ,
                                              A967ChavePIXUpdatedAt ,
                                              A951ContaBancariaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV105Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome), "%", "");
         lV112Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo), "%", "");
         lV118Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
         lV122Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
         /* Using cursor P00EQ4 */
         pr_default.execute(2, new Object[] {lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, AV87Chavepixwwds_4_chavepixtipo1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, AV94Chavepixwwds_11_chavepixtipo2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, AV101Chavepixwwds_18_chavepixtipo3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV105Chavepixwwds_22_tfagenciabanconome, AV106Chavepixwwds_23_tfagenciabanconome_sel, AV107Chavepixwwds_24_tfagencianumero, AV108Chavepixwwds_25_tfagencianumero_to, AV109Chavepixwwds_26_tfcontabancarianumero, AV110Chavepixwwds_27_tfcontabancarianumero_to, lV112Chavepixwwds_29_tfchavepixconteudo, AV113Chavepixwwds_30_tfchavepixconteudo_sel, AV116Chavepixwwds_33_tfchavepixcreatedat, AV117Chavepixwwds_34_tfchavepixcreatedat_to, lV118Chavepixwwds_35_tfchavepixcreatedbyname, AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV120Chavepixwwds_37_tfchavepixupdatedat, AV121Chavepixwwds_38_tfchavepixupdatedat_to, lV122Chavepixwwds_39_tfchavepixupdatedbyname, AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV81ContaBancariaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKEQ6 = false;
            A938AgenciaId = P00EQ4_A938AgenciaId[0];
            n938AgenciaId = P00EQ4_n938AgenciaId[0];
            A968AgenciaBancoId = P00EQ4_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ4_n968AgenciaBancoId[0];
            A959ChavePIXUpdatedBy = P00EQ4_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = P00EQ4_n959ChavePIXUpdatedBy[0];
            A957ChavePIXCreatedBy = P00EQ4_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = P00EQ4_n957ChavePIXCreatedBy[0];
            A951ContaBancariaId = P00EQ4_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EQ4_n951ContaBancariaId[0];
            A967ChavePIXUpdatedAt = P00EQ4_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = P00EQ4_n967ChavePIXUpdatedAt[0];
            A966ChavePIXCreatedAt = P00EQ4_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = P00EQ4_n966ChavePIXCreatedAt[0];
            A963ChavePIXConteudo = P00EQ4_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = P00EQ4_n963ChavePIXConteudo[0];
            A939AgenciaNumero = P00EQ4_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ4_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ4_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ4_n969AgenciaBancoNome[0];
            A960ChavePIXUpdatedByName = P00EQ4_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ4_n960ChavePIXUpdatedByName[0];
            A958ChavePIXCreatedByName = P00EQ4_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ4_n958ChavePIXCreatedByName[0];
            A952ContaBancariaNumero = P00EQ4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ4_n952ContaBancariaNumero[0];
            A965ChavePIXPrincipal = P00EQ4_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = P00EQ4_n965ChavePIXPrincipal[0];
            A964ChavePIXStatus = P00EQ4_A964ChavePIXStatus[0];
            n964ChavePIXStatus = P00EQ4_n964ChavePIXStatus[0];
            A962ChavePIXTipo = P00EQ4_A962ChavePIXTipo[0];
            n962ChavePIXTipo = P00EQ4_n962ChavePIXTipo[0];
            A961ChavePIXId = P00EQ4_A961ChavePIXId[0];
            A960ChavePIXUpdatedByName = P00EQ4_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ4_n960ChavePIXUpdatedByName[0];
            A958ChavePIXCreatedByName = P00EQ4_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ4_n958ChavePIXCreatedByName[0];
            A938AgenciaId = P00EQ4_A938AgenciaId[0];
            n938AgenciaId = P00EQ4_n938AgenciaId[0];
            A952ContaBancariaNumero = P00EQ4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ4_n952ContaBancariaNumero[0];
            A968AgenciaBancoId = P00EQ4_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ4_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EQ4_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ4_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ4_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ4_n969AgenciaBancoNome[0];
            AV48count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00EQ4_A957ChavePIXCreatedBy[0] == A957ChavePIXCreatedBy ) )
            {
               BRKEQ6 = false;
               A961ChavePIXId = P00EQ4_A961ChavePIXId[0];
               AV48count = (long)(AV48count+1);
               BRKEQ6 = true;
               pr_default.readNext(2);
            }
            AV43Option = (String.IsNullOrEmpty(StringUtil.RTrim( A958ChavePIXCreatedByName)) ? "<#Empty#>" : A958ChavePIXCreatedByName);
            AV42InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV43Option, "<#Empty#>") != 0 ) && ( AV42InsertIndex <= AV44Options.Count ) && ( ( StringUtil.StrCmp(((string)AV44Options.Item(AV42InsertIndex)), AV43Option) < 0 ) || ( StringUtil.StrCmp(((string)AV44Options.Item(AV42InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV42InsertIndex = (int)(AV42InsertIndex+1);
            }
            AV44Options.Add(AV43Option, AV42InsertIndex);
            AV47OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV48count), "Z,ZZZ,ZZZ,ZZ9")), AV42InsertIndex);
            if ( AV44Options.Count == AV39SkipItems + 11 )
            {
               AV44Options.RemoveItem(AV44Options.Count);
               AV47OptionIndexes.RemoveItem(AV47OptionIndexes.Count);
            }
            if ( ! BRKEQ6 )
            {
               BRKEQ6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV39SkipItems > 0 )
         {
            AV44Options.RemoveItem(1);
            AV47OptionIndexes.RemoveItem(1);
            AV39SkipItems = (short)(AV39SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADCHAVEPIXUPDATEDBYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV36TFChavePIXUpdatedByName = AV38SearchTxt;
         AV37TFChavePIXUpdatedByName_Sel = "";
         AV84Chavepixwwds_1_filterfulltext = AV60FilterFullText;
         AV85Chavepixwwds_2_dynamicfiltersselector1 = AV61DynamicFiltersSelector1;
         AV86Chavepixwwds_3_dynamicfiltersoperator1 = AV62DynamicFiltersOperator1;
         AV87Chavepixwwds_4_chavepixtipo1 = AV63ChavePIXTipo1;
         AV88Chavepixwwds_5_contabancarianumero1 = AV64ContaBancariaNumero1;
         AV89Chavepixwwds_6_chavepixcreatedbyname1 = AV65ChavePIXCreatedByName1;
         AV90Chavepixwwds_7_chavepixupdatedbyname1 = AV66ChavePIXUpdatedByName1;
         AV91Chavepixwwds_8_dynamicfiltersenabled2 = AV67DynamicFiltersEnabled2;
         AV92Chavepixwwds_9_dynamicfiltersselector2 = AV68DynamicFiltersSelector2;
         AV93Chavepixwwds_10_dynamicfiltersoperator2 = AV69DynamicFiltersOperator2;
         AV94Chavepixwwds_11_chavepixtipo2 = AV70ChavePIXTipo2;
         AV95Chavepixwwds_12_contabancarianumero2 = AV71ContaBancariaNumero2;
         AV96Chavepixwwds_13_chavepixcreatedbyname2 = AV72ChavePIXCreatedByName2;
         AV97Chavepixwwds_14_chavepixupdatedbyname2 = AV73ChavePIXUpdatedByName2;
         AV98Chavepixwwds_15_dynamicfiltersenabled3 = AV74DynamicFiltersEnabled3;
         AV99Chavepixwwds_16_dynamicfiltersselector3 = AV75DynamicFiltersSelector3;
         AV100Chavepixwwds_17_dynamicfiltersoperator3 = AV76DynamicFiltersOperator3;
         AV101Chavepixwwds_18_chavepixtipo3 = AV77ChavePIXTipo3;
         AV102Chavepixwwds_19_contabancarianumero3 = AV78ContaBancariaNumero3;
         AV103Chavepixwwds_20_chavepixcreatedbyname3 = AV79ChavePIXCreatedByName3;
         AV104Chavepixwwds_21_chavepixupdatedbyname3 = AV80ChavePIXUpdatedByName3;
         AV105Chavepixwwds_22_tfagenciabanconome = AV24TFAgenciaBancoNome;
         AV106Chavepixwwds_23_tfagenciabanconome_sel = AV25TFAgenciaBancoNome_Sel;
         AV107Chavepixwwds_24_tfagencianumero = AV22TFAgenciaNumero;
         AV108Chavepixwwds_25_tfagencianumero_to = AV23TFAgenciaNumero_To;
         AV109Chavepixwwds_26_tfcontabancarianumero = AV20TFContaBancariaNumero;
         AV110Chavepixwwds_27_tfcontabancarianumero_to = AV21TFContaBancariaNumero_To;
         AV111Chavepixwwds_28_tfchavepixtipo_sels = AV13TFChavePIXTipo_Sels;
         AV112Chavepixwwds_29_tfchavepixconteudo = AV14TFChavePIXConteudo;
         AV113Chavepixwwds_30_tfchavepixconteudo_sel = AV15TFChavePIXConteudo_Sel;
         AV114Chavepixwwds_31_tfchavepixstatus_sel = AV16TFChavePIXStatus_Sel;
         AV115Chavepixwwds_32_tfchavepixprincipal_sel = AV17TFChavePIXPrincipal_Sel;
         AV116Chavepixwwds_33_tfchavepixcreatedat = AV26TFChavePIXCreatedAt;
         AV117Chavepixwwds_34_tfchavepixcreatedat_to = AV27TFChavePIXCreatedAt_To;
         AV118Chavepixwwds_35_tfchavepixcreatedbyname = AV30TFChavePIXCreatedByName;
         AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV31TFChavePIXCreatedByName_Sel;
         AV120Chavepixwwds_37_tfchavepixupdatedat = AV32TFChavePIXUpdatedAt;
         AV121Chavepixwwds_38_tfchavepixupdatedat_to = AV33TFChavePIXUpdatedAt_To;
         AV122Chavepixwwds_39_tfchavepixupdatedbyname = AV36TFChavePIXUpdatedByName;
         AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV37TFChavePIXUpdatedByName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A962ChavePIXTipo ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                              AV84Chavepixwwds_1_filterfulltext ,
                                              AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                              AV87Chavepixwwds_4_chavepixtipo1 ,
                                              AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                              AV88Chavepixwwds_5_contabancarianumero1 ,
                                              AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                              AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                              AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                              AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                              AV94Chavepixwwds_11_chavepixtipo2 ,
                                              AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                              AV95Chavepixwwds_12_contabancarianumero2 ,
                                              AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                              AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                              AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                              AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                              AV101Chavepixwwds_18_chavepixtipo3 ,
                                              AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                              AV102Chavepixwwds_19_contabancarianumero3 ,
                                              AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                              AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                              AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                              AV105Chavepixwwds_22_tfagenciabanconome ,
                                              AV107Chavepixwwds_24_tfagencianumero ,
                                              AV108Chavepixwwds_25_tfagencianumero_to ,
                                              AV109Chavepixwwds_26_tfcontabancarianumero ,
                                              AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                              AV111Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                              AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                              AV112Chavepixwwds_29_tfchavepixconteudo ,
                                              AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                              AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                              AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                              AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                              AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                              AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                              AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                              AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                              AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                              AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                              AV81ContaBancariaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A963ChavePIXConteudo ,
                                              A964ChavePIXStatus ,
                                              A965ChavePIXPrincipal ,
                                              A958ChavePIXCreatedByName ,
                                              A960ChavePIXUpdatedByName ,
                                              A966ChavePIXCreatedAt ,
                                              A967ChavePIXUpdatedAt ,
                                              A951ContaBancariaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV84Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV105Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome), "%", "");
         lV112Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo), "%", "");
         lV118Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
         lV122Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
         /* Using cursor P00EQ5 */
         pr_default.execute(3, new Object[] {lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, lV84Chavepixwwds_1_filterfulltext, AV87Chavepixwwds_4_chavepixtipo1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, AV88Chavepixwwds_5_contabancarianumero1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV89Chavepixwwds_6_chavepixcreatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, lV90Chavepixwwds_7_chavepixupdatedbyname1, AV94Chavepixwwds_11_chavepixtipo2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, AV95Chavepixwwds_12_contabancarianumero2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV96Chavepixwwds_13_chavepixcreatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, lV97Chavepixwwds_14_chavepixupdatedbyname2, AV101Chavepixwwds_18_chavepixtipo3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, AV102Chavepixwwds_19_contabancarianumero3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV103Chavepixwwds_20_chavepixcreatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV104Chavepixwwds_21_chavepixupdatedbyname3, lV105Chavepixwwds_22_tfagenciabanconome, AV106Chavepixwwds_23_tfagenciabanconome_sel, AV107Chavepixwwds_24_tfagencianumero, AV108Chavepixwwds_25_tfagencianumero_to, AV109Chavepixwwds_26_tfcontabancarianumero, AV110Chavepixwwds_27_tfcontabancarianumero_to, lV112Chavepixwwds_29_tfchavepixconteudo, AV113Chavepixwwds_30_tfchavepixconteudo_sel, AV116Chavepixwwds_33_tfchavepixcreatedat, AV117Chavepixwwds_34_tfchavepixcreatedat_to, lV118Chavepixwwds_35_tfchavepixcreatedbyname, AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV120Chavepixwwds_37_tfchavepixupdatedat, AV121Chavepixwwds_38_tfchavepixupdatedat_to, lV122Chavepixwwds_39_tfchavepixupdatedbyname, AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV81ContaBancariaId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKEQ8 = false;
            A938AgenciaId = P00EQ5_A938AgenciaId[0];
            n938AgenciaId = P00EQ5_n938AgenciaId[0];
            A968AgenciaBancoId = P00EQ5_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ5_n968AgenciaBancoId[0];
            A957ChavePIXCreatedBy = P00EQ5_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = P00EQ5_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = P00EQ5_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = P00EQ5_n959ChavePIXUpdatedBy[0];
            A951ContaBancariaId = P00EQ5_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EQ5_n951ContaBancariaId[0];
            A967ChavePIXUpdatedAt = P00EQ5_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = P00EQ5_n967ChavePIXUpdatedAt[0];
            A966ChavePIXCreatedAt = P00EQ5_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = P00EQ5_n966ChavePIXCreatedAt[0];
            A963ChavePIXConteudo = P00EQ5_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = P00EQ5_n963ChavePIXConteudo[0];
            A939AgenciaNumero = P00EQ5_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ5_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ5_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ5_n969AgenciaBancoNome[0];
            A960ChavePIXUpdatedByName = P00EQ5_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ5_n960ChavePIXUpdatedByName[0];
            A958ChavePIXCreatedByName = P00EQ5_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ5_n958ChavePIXCreatedByName[0];
            A952ContaBancariaNumero = P00EQ5_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ5_n952ContaBancariaNumero[0];
            A965ChavePIXPrincipal = P00EQ5_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = P00EQ5_n965ChavePIXPrincipal[0];
            A964ChavePIXStatus = P00EQ5_A964ChavePIXStatus[0];
            n964ChavePIXStatus = P00EQ5_n964ChavePIXStatus[0];
            A962ChavePIXTipo = P00EQ5_A962ChavePIXTipo[0];
            n962ChavePIXTipo = P00EQ5_n962ChavePIXTipo[0];
            A961ChavePIXId = P00EQ5_A961ChavePIXId[0];
            A958ChavePIXCreatedByName = P00EQ5_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00EQ5_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = P00EQ5_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00EQ5_n960ChavePIXUpdatedByName[0];
            A938AgenciaId = P00EQ5_A938AgenciaId[0];
            n938AgenciaId = P00EQ5_n938AgenciaId[0];
            A952ContaBancariaNumero = P00EQ5_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EQ5_n952ContaBancariaNumero[0];
            A968AgenciaBancoId = P00EQ5_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EQ5_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EQ5_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EQ5_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EQ5_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EQ5_n969AgenciaBancoNome[0];
            AV48count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00EQ5_A959ChavePIXUpdatedBy[0] == A959ChavePIXUpdatedBy ) )
            {
               BRKEQ8 = false;
               A961ChavePIXId = P00EQ5_A961ChavePIXId[0];
               AV48count = (long)(AV48count+1);
               BRKEQ8 = true;
               pr_default.readNext(3);
            }
            AV43Option = (String.IsNullOrEmpty(StringUtil.RTrim( A960ChavePIXUpdatedByName)) ? "<#Empty#>" : A960ChavePIXUpdatedByName);
            AV42InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV43Option, "<#Empty#>") != 0 ) && ( AV42InsertIndex <= AV44Options.Count ) && ( ( StringUtil.StrCmp(((string)AV44Options.Item(AV42InsertIndex)), AV43Option) < 0 ) || ( StringUtil.StrCmp(((string)AV44Options.Item(AV42InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV42InsertIndex = (int)(AV42InsertIndex+1);
            }
            AV44Options.Add(AV43Option, AV42InsertIndex);
            AV47OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV48count), "Z,ZZZ,ZZZ,ZZ9")), AV42InsertIndex);
            if ( AV44Options.Count == AV39SkipItems + 11 )
            {
               AV44Options.RemoveItem(AV44Options.Count);
               AV47OptionIndexes.RemoveItem(AV47OptionIndexes.Count);
            }
            if ( ! BRKEQ8 )
            {
               BRKEQ8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV39SkipItems > 0 )
         {
            AV44Options.RemoveItem(1);
            AV47OptionIndexes.RemoveItem(1);
            AV39SkipItems = (short)(AV39SkipItems-1);
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
         AV57OptionsJson = "";
         AV58OptionsDescJson = "";
         AV59OptionIndexesJson = "";
         AV44Options = new GxSimpleCollection<string>();
         AV46OptionsDesc = new GxSimpleCollection<string>();
         AV47OptionIndexes = new GxSimpleCollection<string>();
         AV38SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV49Session = context.GetSession();
         AV51GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV52GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV60FilterFullText = "";
         AV24TFAgenciaBancoNome = "";
         AV25TFAgenciaBancoNome_Sel = "";
         AV12TFChavePIXTipo_SelsJson = "";
         AV13TFChavePIXTipo_Sels = new GxSimpleCollection<string>();
         AV14TFChavePIXConteudo = "";
         AV15TFChavePIXConteudo_Sel = "";
         AV26TFChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         AV27TFChavePIXCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV30TFChavePIXCreatedByName = "";
         AV31TFChavePIXCreatedByName_Sel = "";
         AV32TFChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         AV33TFChavePIXUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV36TFChavePIXUpdatedByName = "";
         AV37TFChavePIXUpdatedByName_Sel = "";
         AV53GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV61DynamicFiltersSelector1 = "";
         AV63ChavePIXTipo1 = "";
         AV65ChavePIXCreatedByName1 = "";
         AV66ChavePIXUpdatedByName1 = "";
         AV68DynamicFiltersSelector2 = "";
         AV70ChavePIXTipo2 = "";
         AV72ChavePIXCreatedByName2 = "";
         AV73ChavePIXUpdatedByName2 = "";
         AV75DynamicFiltersSelector3 = "";
         AV77ChavePIXTipo3 = "";
         AV79ChavePIXCreatedByName3 = "";
         AV80ChavePIXUpdatedByName3 = "";
         AV84Chavepixwwds_1_filterfulltext = "";
         AV85Chavepixwwds_2_dynamicfiltersselector1 = "";
         AV87Chavepixwwds_4_chavepixtipo1 = "";
         AV89Chavepixwwds_6_chavepixcreatedbyname1 = "";
         AV90Chavepixwwds_7_chavepixupdatedbyname1 = "";
         AV92Chavepixwwds_9_dynamicfiltersselector2 = "";
         AV94Chavepixwwds_11_chavepixtipo2 = "";
         AV96Chavepixwwds_13_chavepixcreatedbyname2 = "";
         AV97Chavepixwwds_14_chavepixupdatedbyname2 = "";
         AV99Chavepixwwds_16_dynamicfiltersselector3 = "";
         AV101Chavepixwwds_18_chavepixtipo3 = "";
         AV103Chavepixwwds_20_chavepixcreatedbyname3 = "";
         AV104Chavepixwwds_21_chavepixupdatedbyname3 = "";
         AV105Chavepixwwds_22_tfagenciabanconome = "";
         AV106Chavepixwwds_23_tfagenciabanconome_sel = "";
         AV111Chavepixwwds_28_tfchavepixtipo_sels = new GxSimpleCollection<string>();
         AV112Chavepixwwds_29_tfchavepixconteudo = "";
         AV113Chavepixwwds_30_tfchavepixconteudo_sel = "";
         AV116Chavepixwwds_33_tfchavepixcreatedat = (DateTime)(DateTime.MinValue);
         AV117Chavepixwwds_34_tfchavepixcreatedat_to = (DateTime)(DateTime.MinValue);
         AV118Chavepixwwds_35_tfchavepixcreatedbyname = "";
         AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel = "";
         AV120Chavepixwwds_37_tfchavepixupdatedat = (DateTime)(DateTime.MinValue);
         AV121Chavepixwwds_38_tfchavepixupdatedat_to = (DateTime)(DateTime.MinValue);
         AV122Chavepixwwds_39_tfchavepixupdatedbyname = "";
         AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel = "";
         lV84Chavepixwwds_1_filterfulltext = "";
         lV89Chavepixwwds_6_chavepixcreatedbyname1 = "";
         lV90Chavepixwwds_7_chavepixupdatedbyname1 = "";
         lV96Chavepixwwds_13_chavepixcreatedbyname2 = "";
         lV97Chavepixwwds_14_chavepixupdatedbyname2 = "";
         lV103Chavepixwwds_20_chavepixcreatedbyname3 = "";
         lV104Chavepixwwds_21_chavepixupdatedbyname3 = "";
         lV105Chavepixwwds_22_tfagenciabanconome = "";
         lV112Chavepixwwds_29_tfchavepixconteudo = "";
         lV118Chavepixwwds_35_tfchavepixcreatedbyname = "";
         lV122Chavepixwwds_39_tfchavepixupdatedbyname = "";
         A962ChavePIXTipo = "";
         A969AgenciaBancoNome = "";
         A963ChavePIXConteudo = "";
         A958ChavePIXCreatedByName = "";
         A960ChavePIXUpdatedByName = "";
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         P00EQ2_A938AgenciaId = new int[1] ;
         P00EQ2_n938AgenciaId = new bool[] {false} ;
         P00EQ2_A968AgenciaBancoId = new int[1] ;
         P00EQ2_n968AgenciaBancoId = new bool[] {false} ;
         P00EQ2_A957ChavePIXCreatedBy = new short[1] ;
         P00EQ2_n957ChavePIXCreatedBy = new bool[] {false} ;
         P00EQ2_A959ChavePIXUpdatedBy = new short[1] ;
         P00EQ2_n959ChavePIXUpdatedBy = new bool[] {false} ;
         P00EQ2_A969AgenciaBancoNome = new string[] {""} ;
         P00EQ2_n969AgenciaBancoNome = new bool[] {false} ;
         P00EQ2_A951ContaBancariaId = new int[1] ;
         P00EQ2_n951ContaBancariaId = new bool[] {false} ;
         P00EQ2_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ2_n967ChavePIXUpdatedAt = new bool[] {false} ;
         P00EQ2_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ2_n966ChavePIXCreatedAt = new bool[] {false} ;
         P00EQ2_A963ChavePIXConteudo = new string[] {""} ;
         P00EQ2_n963ChavePIXConteudo = new bool[] {false} ;
         P00EQ2_A939AgenciaNumero = new int[1] ;
         P00EQ2_n939AgenciaNumero = new bool[] {false} ;
         P00EQ2_A960ChavePIXUpdatedByName = new string[] {""} ;
         P00EQ2_n960ChavePIXUpdatedByName = new bool[] {false} ;
         P00EQ2_A958ChavePIXCreatedByName = new string[] {""} ;
         P00EQ2_n958ChavePIXCreatedByName = new bool[] {false} ;
         P00EQ2_A952ContaBancariaNumero = new long[1] ;
         P00EQ2_n952ContaBancariaNumero = new bool[] {false} ;
         P00EQ2_A965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ2_n965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ2_A964ChavePIXStatus = new bool[] {false} ;
         P00EQ2_n964ChavePIXStatus = new bool[] {false} ;
         P00EQ2_A962ChavePIXTipo = new string[] {""} ;
         P00EQ2_n962ChavePIXTipo = new bool[] {false} ;
         P00EQ2_A961ChavePIXId = new int[1] ;
         AV43Option = "";
         P00EQ3_A938AgenciaId = new int[1] ;
         P00EQ3_n938AgenciaId = new bool[] {false} ;
         P00EQ3_A968AgenciaBancoId = new int[1] ;
         P00EQ3_n968AgenciaBancoId = new bool[] {false} ;
         P00EQ3_A957ChavePIXCreatedBy = new short[1] ;
         P00EQ3_n957ChavePIXCreatedBy = new bool[] {false} ;
         P00EQ3_A959ChavePIXUpdatedBy = new short[1] ;
         P00EQ3_n959ChavePIXUpdatedBy = new bool[] {false} ;
         P00EQ3_A963ChavePIXConteudo = new string[] {""} ;
         P00EQ3_n963ChavePIXConteudo = new bool[] {false} ;
         P00EQ3_A951ContaBancariaId = new int[1] ;
         P00EQ3_n951ContaBancariaId = new bool[] {false} ;
         P00EQ3_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ3_n967ChavePIXUpdatedAt = new bool[] {false} ;
         P00EQ3_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ3_n966ChavePIXCreatedAt = new bool[] {false} ;
         P00EQ3_A939AgenciaNumero = new int[1] ;
         P00EQ3_n939AgenciaNumero = new bool[] {false} ;
         P00EQ3_A969AgenciaBancoNome = new string[] {""} ;
         P00EQ3_n969AgenciaBancoNome = new bool[] {false} ;
         P00EQ3_A960ChavePIXUpdatedByName = new string[] {""} ;
         P00EQ3_n960ChavePIXUpdatedByName = new bool[] {false} ;
         P00EQ3_A958ChavePIXCreatedByName = new string[] {""} ;
         P00EQ3_n958ChavePIXCreatedByName = new bool[] {false} ;
         P00EQ3_A952ContaBancariaNumero = new long[1] ;
         P00EQ3_n952ContaBancariaNumero = new bool[] {false} ;
         P00EQ3_A965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ3_n965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ3_A964ChavePIXStatus = new bool[] {false} ;
         P00EQ3_n964ChavePIXStatus = new bool[] {false} ;
         P00EQ3_A962ChavePIXTipo = new string[] {""} ;
         P00EQ3_n962ChavePIXTipo = new bool[] {false} ;
         P00EQ3_A961ChavePIXId = new int[1] ;
         P00EQ4_A938AgenciaId = new int[1] ;
         P00EQ4_n938AgenciaId = new bool[] {false} ;
         P00EQ4_A968AgenciaBancoId = new int[1] ;
         P00EQ4_n968AgenciaBancoId = new bool[] {false} ;
         P00EQ4_A959ChavePIXUpdatedBy = new short[1] ;
         P00EQ4_n959ChavePIXUpdatedBy = new bool[] {false} ;
         P00EQ4_A957ChavePIXCreatedBy = new short[1] ;
         P00EQ4_n957ChavePIXCreatedBy = new bool[] {false} ;
         P00EQ4_A951ContaBancariaId = new int[1] ;
         P00EQ4_n951ContaBancariaId = new bool[] {false} ;
         P00EQ4_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ4_n967ChavePIXUpdatedAt = new bool[] {false} ;
         P00EQ4_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ4_n966ChavePIXCreatedAt = new bool[] {false} ;
         P00EQ4_A963ChavePIXConteudo = new string[] {""} ;
         P00EQ4_n963ChavePIXConteudo = new bool[] {false} ;
         P00EQ4_A939AgenciaNumero = new int[1] ;
         P00EQ4_n939AgenciaNumero = new bool[] {false} ;
         P00EQ4_A969AgenciaBancoNome = new string[] {""} ;
         P00EQ4_n969AgenciaBancoNome = new bool[] {false} ;
         P00EQ4_A960ChavePIXUpdatedByName = new string[] {""} ;
         P00EQ4_n960ChavePIXUpdatedByName = new bool[] {false} ;
         P00EQ4_A958ChavePIXCreatedByName = new string[] {""} ;
         P00EQ4_n958ChavePIXCreatedByName = new bool[] {false} ;
         P00EQ4_A952ContaBancariaNumero = new long[1] ;
         P00EQ4_n952ContaBancariaNumero = new bool[] {false} ;
         P00EQ4_A965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ4_n965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ4_A964ChavePIXStatus = new bool[] {false} ;
         P00EQ4_n964ChavePIXStatus = new bool[] {false} ;
         P00EQ4_A962ChavePIXTipo = new string[] {""} ;
         P00EQ4_n962ChavePIXTipo = new bool[] {false} ;
         P00EQ4_A961ChavePIXId = new int[1] ;
         P00EQ5_A938AgenciaId = new int[1] ;
         P00EQ5_n938AgenciaId = new bool[] {false} ;
         P00EQ5_A968AgenciaBancoId = new int[1] ;
         P00EQ5_n968AgenciaBancoId = new bool[] {false} ;
         P00EQ5_A957ChavePIXCreatedBy = new short[1] ;
         P00EQ5_n957ChavePIXCreatedBy = new bool[] {false} ;
         P00EQ5_A959ChavePIXUpdatedBy = new short[1] ;
         P00EQ5_n959ChavePIXUpdatedBy = new bool[] {false} ;
         P00EQ5_A951ContaBancariaId = new int[1] ;
         P00EQ5_n951ContaBancariaId = new bool[] {false} ;
         P00EQ5_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ5_n967ChavePIXUpdatedAt = new bool[] {false} ;
         P00EQ5_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EQ5_n966ChavePIXCreatedAt = new bool[] {false} ;
         P00EQ5_A963ChavePIXConteudo = new string[] {""} ;
         P00EQ5_n963ChavePIXConteudo = new bool[] {false} ;
         P00EQ5_A939AgenciaNumero = new int[1] ;
         P00EQ5_n939AgenciaNumero = new bool[] {false} ;
         P00EQ5_A969AgenciaBancoNome = new string[] {""} ;
         P00EQ5_n969AgenciaBancoNome = new bool[] {false} ;
         P00EQ5_A960ChavePIXUpdatedByName = new string[] {""} ;
         P00EQ5_n960ChavePIXUpdatedByName = new bool[] {false} ;
         P00EQ5_A958ChavePIXCreatedByName = new string[] {""} ;
         P00EQ5_n958ChavePIXCreatedByName = new bool[] {false} ;
         P00EQ5_A952ContaBancariaNumero = new long[1] ;
         P00EQ5_n952ContaBancariaNumero = new bool[] {false} ;
         P00EQ5_A965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ5_n965ChavePIXPrincipal = new bool[] {false} ;
         P00EQ5_A964ChavePIXStatus = new bool[] {false} ;
         P00EQ5_n964ChavePIXStatus = new bool[] {false} ;
         P00EQ5_A962ChavePIXTipo = new string[] {""} ;
         P00EQ5_n962ChavePIXTipo = new bool[] {false} ;
         P00EQ5_A961ChavePIXId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.chavepixwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EQ2_A938AgenciaId, P00EQ2_n938AgenciaId, P00EQ2_A968AgenciaBancoId, P00EQ2_n968AgenciaBancoId, P00EQ2_A957ChavePIXCreatedBy, P00EQ2_n957ChavePIXCreatedBy, P00EQ2_A959ChavePIXUpdatedBy, P00EQ2_n959ChavePIXUpdatedBy, P00EQ2_A969AgenciaBancoNome, P00EQ2_n969AgenciaBancoNome,
               P00EQ2_A951ContaBancariaId, P00EQ2_n951ContaBancariaId, P00EQ2_A967ChavePIXUpdatedAt, P00EQ2_n967ChavePIXUpdatedAt, P00EQ2_A966ChavePIXCreatedAt, P00EQ2_n966ChavePIXCreatedAt, P00EQ2_A963ChavePIXConteudo, P00EQ2_n963ChavePIXConteudo, P00EQ2_A939AgenciaNumero, P00EQ2_n939AgenciaNumero,
               P00EQ2_A960ChavePIXUpdatedByName, P00EQ2_n960ChavePIXUpdatedByName, P00EQ2_A958ChavePIXCreatedByName, P00EQ2_n958ChavePIXCreatedByName, P00EQ2_A952ContaBancariaNumero, P00EQ2_n952ContaBancariaNumero, P00EQ2_A965ChavePIXPrincipal, P00EQ2_n965ChavePIXPrincipal, P00EQ2_A964ChavePIXStatus, P00EQ2_n964ChavePIXStatus,
               P00EQ2_A962ChavePIXTipo, P00EQ2_n962ChavePIXTipo, P00EQ2_A961ChavePIXId
               }
               , new Object[] {
               P00EQ3_A938AgenciaId, P00EQ3_n938AgenciaId, P00EQ3_A968AgenciaBancoId, P00EQ3_n968AgenciaBancoId, P00EQ3_A957ChavePIXCreatedBy, P00EQ3_n957ChavePIXCreatedBy, P00EQ3_A959ChavePIXUpdatedBy, P00EQ3_n959ChavePIXUpdatedBy, P00EQ3_A963ChavePIXConteudo, P00EQ3_n963ChavePIXConteudo,
               P00EQ3_A951ContaBancariaId, P00EQ3_n951ContaBancariaId, P00EQ3_A967ChavePIXUpdatedAt, P00EQ3_n967ChavePIXUpdatedAt, P00EQ3_A966ChavePIXCreatedAt, P00EQ3_n966ChavePIXCreatedAt, P00EQ3_A939AgenciaNumero, P00EQ3_n939AgenciaNumero, P00EQ3_A969AgenciaBancoNome, P00EQ3_n969AgenciaBancoNome,
               P00EQ3_A960ChavePIXUpdatedByName, P00EQ3_n960ChavePIXUpdatedByName, P00EQ3_A958ChavePIXCreatedByName, P00EQ3_n958ChavePIXCreatedByName, P00EQ3_A952ContaBancariaNumero, P00EQ3_n952ContaBancariaNumero, P00EQ3_A965ChavePIXPrincipal, P00EQ3_n965ChavePIXPrincipal, P00EQ3_A964ChavePIXStatus, P00EQ3_n964ChavePIXStatus,
               P00EQ3_A962ChavePIXTipo, P00EQ3_n962ChavePIXTipo, P00EQ3_A961ChavePIXId
               }
               , new Object[] {
               P00EQ4_A938AgenciaId, P00EQ4_n938AgenciaId, P00EQ4_A968AgenciaBancoId, P00EQ4_n968AgenciaBancoId, P00EQ4_A959ChavePIXUpdatedBy, P00EQ4_n959ChavePIXUpdatedBy, P00EQ4_A957ChavePIXCreatedBy, P00EQ4_n957ChavePIXCreatedBy, P00EQ4_A951ContaBancariaId, P00EQ4_n951ContaBancariaId,
               P00EQ4_A967ChavePIXUpdatedAt, P00EQ4_n967ChavePIXUpdatedAt, P00EQ4_A966ChavePIXCreatedAt, P00EQ4_n966ChavePIXCreatedAt, P00EQ4_A963ChavePIXConteudo, P00EQ4_n963ChavePIXConteudo, P00EQ4_A939AgenciaNumero, P00EQ4_n939AgenciaNumero, P00EQ4_A969AgenciaBancoNome, P00EQ4_n969AgenciaBancoNome,
               P00EQ4_A960ChavePIXUpdatedByName, P00EQ4_n960ChavePIXUpdatedByName, P00EQ4_A958ChavePIXCreatedByName, P00EQ4_n958ChavePIXCreatedByName, P00EQ4_A952ContaBancariaNumero, P00EQ4_n952ContaBancariaNumero, P00EQ4_A965ChavePIXPrincipal, P00EQ4_n965ChavePIXPrincipal, P00EQ4_A964ChavePIXStatus, P00EQ4_n964ChavePIXStatus,
               P00EQ4_A962ChavePIXTipo, P00EQ4_n962ChavePIXTipo, P00EQ4_A961ChavePIXId
               }
               , new Object[] {
               P00EQ5_A938AgenciaId, P00EQ5_n938AgenciaId, P00EQ5_A968AgenciaBancoId, P00EQ5_n968AgenciaBancoId, P00EQ5_A957ChavePIXCreatedBy, P00EQ5_n957ChavePIXCreatedBy, P00EQ5_A959ChavePIXUpdatedBy, P00EQ5_n959ChavePIXUpdatedBy, P00EQ5_A951ContaBancariaId, P00EQ5_n951ContaBancariaId,
               P00EQ5_A967ChavePIXUpdatedAt, P00EQ5_n967ChavePIXUpdatedAt, P00EQ5_A966ChavePIXCreatedAt, P00EQ5_n966ChavePIXCreatedAt, P00EQ5_A963ChavePIXConteudo, P00EQ5_n963ChavePIXConteudo, P00EQ5_A939AgenciaNumero, P00EQ5_n939AgenciaNumero, P00EQ5_A969AgenciaBancoNome, P00EQ5_n969AgenciaBancoNome,
               P00EQ5_A960ChavePIXUpdatedByName, P00EQ5_n960ChavePIXUpdatedByName, P00EQ5_A958ChavePIXCreatedByName, P00EQ5_n958ChavePIXCreatedByName, P00EQ5_A952ContaBancariaNumero, P00EQ5_n952ContaBancariaNumero, P00EQ5_A965ChavePIXPrincipal, P00EQ5_n965ChavePIXPrincipal, P00EQ5_A964ChavePIXStatus, P00EQ5_n964ChavePIXStatus,
               P00EQ5_A962ChavePIXTipo, P00EQ5_n962ChavePIXTipo, P00EQ5_A961ChavePIXId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV41MaxItems ;
      private short AV40PageIndex ;
      private short AV39SkipItems ;
      private short AV16TFChavePIXStatus_Sel ;
      private short AV17TFChavePIXPrincipal_Sel ;
      private short AV62DynamicFiltersOperator1 ;
      private short AV69DynamicFiltersOperator2 ;
      private short AV76DynamicFiltersOperator3 ;
      private short AV86Chavepixwwds_3_dynamicfiltersoperator1 ;
      private short AV93Chavepixwwds_10_dynamicfiltersoperator2 ;
      private short AV100Chavepixwwds_17_dynamicfiltersoperator3 ;
      private short AV114Chavepixwwds_31_tfchavepixstatus_sel ;
      private short AV115Chavepixwwds_32_tfchavepixprincipal_sel ;
      private short A957ChavePIXCreatedBy ;
      private short A959ChavePIXUpdatedBy ;
      private int AV82GXV1 ;
      private int AV22TFAgenciaNumero ;
      private int AV23TFAgenciaNumero_To ;
      private int AV81ContaBancariaId ;
      private int AV107Chavepixwwds_24_tfagencianumero ;
      private int AV108Chavepixwwds_25_tfagencianumero_to ;
      private int AV111Chavepixwwds_28_tfchavepixtipo_sels_Count ;
      private int A939AgenciaNumero ;
      private int A951ContaBancariaId ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int A961ChavePIXId ;
      private int AV42InsertIndex ;
      private long AV20TFContaBancariaNumero ;
      private long AV21TFContaBancariaNumero_To ;
      private long AV64ContaBancariaNumero1 ;
      private long AV71ContaBancariaNumero2 ;
      private long AV78ContaBancariaNumero3 ;
      private long AV88Chavepixwwds_5_contabancarianumero1 ;
      private long AV95Chavepixwwds_12_contabancarianumero2 ;
      private long AV102Chavepixwwds_19_contabancarianumero3 ;
      private long AV109Chavepixwwds_26_tfcontabancarianumero ;
      private long AV110Chavepixwwds_27_tfcontabancarianumero_to ;
      private long A952ContaBancariaNumero ;
      private long AV48count ;
      private DateTime AV26TFChavePIXCreatedAt ;
      private DateTime AV27TFChavePIXCreatedAt_To ;
      private DateTime AV32TFChavePIXUpdatedAt ;
      private DateTime AV33TFChavePIXUpdatedAt_To ;
      private DateTime AV116Chavepixwwds_33_tfchavepixcreatedat ;
      private DateTime AV117Chavepixwwds_34_tfchavepixcreatedat_to ;
      private DateTime AV120Chavepixwwds_37_tfchavepixupdatedat ;
      private DateTime AV121Chavepixwwds_38_tfchavepixupdatedat_to ;
      private DateTime A966ChavePIXCreatedAt ;
      private DateTime A967ChavePIXUpdatedAt ;
      private bool returnInSub ;
      private bool AV67DynamicFiltersEnabled2 ;
      private bool AV74DynamicFiltersEnabled3 ;
      private bool AV91Chavepixwwds_8_dynamicfiltersenabled2 ;
      private bool AV98Chavepixwwds_15_dynamicfiltersenabled3 ;
      private bool A964ChavePIXStatus ;
      private bool A965ChavePIXPrincipal ;
      private bool BRKEQ2 ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n957ChavePIXCreatedBy ;
      private bool n959ChavePIXUpdatedBy ;
      private bool n969AgenciaBancoNome ;
      private bool n951ContaBancariaId ;
      private bool n967ChavePIXUpdatedAt ;
      private bool n966ChavePIXCreatedAt ;
      private bool n963ChavePIXConteudo ;
      private bool n939AgenciaNumero ;
      private bool n960ChavePIXUpdatedByName ;
      private bool n958ChavePIXCreatedByName ;
      private bool n952ContaBancariaNumero ;
      private bool n965ChavePIXPrincipal ;
      private bool n964ChavePIXStatus ;
      private bool n962ChavePIXTipo ;
      private bool BRKEQ4 ;
      private bool BRKEQ6 ;
      private bool BRKEQ8 ;
      private string AV57OptionsJson ;
      private string AV58OptionsDescJson ;
      private string AV59OptionIndexesJson ;
      private string AV12TFChavePIXTipo_SelsJson ;
      private string AV54DDOName ;
      private string AV55SearchTxtParms ;
      private string AV56SearchTxtTo ;
      private string AV38SearchTxt ;
      private string AV60FilterFullText ;
      private string AV24TFAgenciaBancoNome ;
      private string AV25TFAgenciaBancoNome_Sel ;
      private string AV14TFChavePIXConteudo ;
      private string AV15TFChavePIXConteudo_Sel ;
      private string AV30TFChavePIXCreatedByName ;
      private string AV31TFChavePIXCreatedByName_Sel ;
      private string AV36TFChavePIXUpdatedByName ;
      private string AV37TFChavePIXUpdatedByName_Sel ;
      private string AV61DynamicFiltersSelector1 ;
      private string AV63ChavePIXTipo1 ;
      private string AV65ChavePIXCreatedByName1 ;
      private string AV66ChavePIXUpdatedByName1 ;
      private string AV68DynamicFiltersSelector2 ;
      private string AV70ChavePIXTipo2 ;
      private string AV72ChavePIXCreatedByName2 ;
      private string AV73ChavePIXUpdatedByName2 ;
      private string AV75DynamicFiltersSelector3 ;
      private string AV77ChavePIXTipo3 ;
      private string AV79ChavePIXCreatedByName3 ;
      private string AV80ChavePIXUpdatedByName3 ;
      private string AV84Chavepixwwds_1_filterfulltext ;
      private string AV85Chavepixwwds_2_dynamicfiltersselector1 ;
      private string AV87Chavepixwwds_4_chavepixtipo1 ;
      private string AV89Chavepixwwds_6_chavepixcreatedbyname1 ;
      private string AV90Chavepixwwds_7_chavepixupdatedbyname1 ;
      private string AV92Chavepixwwds_9_dynamicfiltersselector2 ;
      private string AV94Chavepixwwds_11_chavepixtipo2 ;
      private string AV96Chavepixwwds_13_chavepixcreatedbyname2 ;
      private string AV97Chavepixwwds_14_chavepixupdatedbyname2 ;
      private string AV99Chavepixwwds_16_dynamicfiltersselector3 ;
      private string AV101Chavepixwwds_18_chavepixtipo3 ;
      private string AV103Chavepixwwds_20_chavepixcreatedbyname3 ;
      private string AV104Chavepixwwds_21_chavepixupdatedbyname3 ;
      private string AV105Chavepixwwds_22_tfagenciabanconome ;
      private string AV106Chavepixwwds_23_tfagenciabanconome_sel ;
      private string AV112Chavepixwwds_29_tfchavepixconteudo ;
      private string AV113Chavepixwwds_30_tfchavepixconteudo_sel ;
      private string AV118Chavepixwwds_35_tfchavepixcreatedbyname ;
      private string AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ;
      private string AV122Chavepixwwds_39_tfchavepixupdatedbyname ;
      private string AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ;
      private string lV84Chavepixwwds_1_filterfulltext ;
      private string lV89Chavepixwwds_6_chavepixcreatedbyname1 ;
      private string lV90Chavepixwwds_7_chavepixupdatedbyname1 ;
      private string lV96Chavepixwwds_13_chavepixcreatedbyname2 ;
      private string lV97Chavepixwwds_14_chavepixupdatedbyname2 ;
      private string lV103Chavepixwwds_20_chavepixcreatedbyname3 ;
      private string lV104Chavepixwwds_21_chavepixupdatedbyname3 ;
      private string lV105Chavepixwwds_22_tfagenciabanconome ;
      private string lV112Chavepixwwds_29_tfchavepixconteudo ;
      private string lV118Chavepixwwds_35_tfchavepixcreatedbyname ;
      private string lV122Chavepixwwds_39_tfchavepixupdatedbyname ;
      private string A962ChavePIXTipo ;
      private string A969AgenciaBancoNome ;
      private string A963ChavePIXConteudo ;
      private string A958ChavePIXCreatedByName ;
      private string A960ChavePIXUpdatedByName ;
      private string AV43Option ;
      private IGxSession AV49Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV44Options ;
      private GxSimpleCollection<string> AV46OptionsDesc ;
      private GxSimpleCollection<string> AV47OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV51GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV52GridStateFilterValue ;
      private GxSimpleCollection<string> AV13TFChavePIXTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV53GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV111Chavepixwwds_28_tfchavepixtipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00EQ2_A938AgenciaId ;
      private bool[] P00EQ2_n938AgenciaId ;
      private int[] P00EQ2_A968AgenciaBancoId ;
      private bool[] P00EQ2_n968AgenciaBancoId ;
      private short[] P00EQ2_A957ChavePIXCreatedBy ;
      private bool[] P00EQ2_n957ChavePIXCreatedBy ;
      private short[] P00EQ2_A959ChavePIXUpdatedBy ;
      private bool[] P00EQ2_n959ChavePIXUpdatedBy ;
      private string[] P00EQ2_A969AgenciaBancoNome ;
      private bool[] P00EQ2_n969AgenciaBancoNome ;
      private int[] P00EQ2_A951ContaBancariaId ;
      private bool[] P00EQ2_n951ContaBancariaId ;
      private DateTime[] P00EQ2_A967ChavePIXUpdatedAt ;
      private bool[] P00EQ2_n967ChavePIXUpdatedAt ;
      private DateTime[] P00EQ2_A966ChavePIXCreatedAt ;
      private bool[] P00EQ2_n966ChavePIXCreatedAt ;
      private string[] P00EQ2_A963ChavePIXConteudo ;
      private bool[] P00EQ2_n963ChavePIXConteudo ;
      private int[] P00EQ2_A939AgenciaNumero ;
      private bool[] P00EQ2_n939AgenciaNumero ;
      private string[] P00EQ2_A960ChavePIXUpdatedByName ;
      private bool[] P00EQ2_n960ChavePIXUpdatedByName ;
      private string[] P00EQ2_A958ChavePIXCreatedByName ;
      private bool[] P00EQ2_n958ChavePIXCreatedByName ;
      private long[] P00EQ2_A952ContaBancariaNumero ;
      private bool[] P00EQ2_n952ContaBancariaNumero ;
      private bool[] P00EQ2_A965ChavePIXPrincipal ;
      private bool[] P00EQ2_n965ChavePIXPrincipal ;
      private bool[] P00EQ2_A964ChavePIXStatus ;
      private bool[] P00EQ2_n964ChavePIXStatus ;
      private string[] P00EQ2_A962ChavePIXTipo ;
      private bool[] P00EQ2_n962ChavePIXTipo ;
      private int[] P00EQ2_A961ChavePIXId ;
      private int[] P00EQ3_A938AgenciaId ;
      private bool[] P00EQ3_n938AgenciaId ;
      private int[] P00EQ3_A968AgenciaBancoId ;
      private bool[] P00EQ3_n968AgenciaBancoId ;
      private short[] P00EQ3_A957ChavePIXCreatedBy ;
      private bool[] P00EQ3_n957ChavePIXCreatedBy ;
      private short[] P00EQ3_A959ChavePIXUpdatedBy ;
      private bool[] P00EQ3_n959ChavePIXUpdatedBy ;
      private string[] P00EQ3_A963ChavePIXConteudo ;
      private bool[] P00EQ3_n963ChavePIXConteudo ;
      private int[] P00EQ3_A951ContaBancariaId ;
      private bool[] P00EQ3_n951ContaBancariaId ;
      private DateTime[] P00EQ3_A967ChavePIXUpdatedAt ;
      private bool[] P00EQ3_n967ChavePIXUpdatedAt ;
      private DateTime[] P00EQ3_A966ChavePIXCreatedAt ;
      private bool[] P00EQ3_n966ChavePIXCreatedAt ;
      private int[] P00EQ3_A939AgenciaNumero ;
      private bool[] P00EQ3_n939AgenciaNumero ;
      private string[] P00EQ3_A969AgenciaBancoNome ;
      private bool[] P00EQ3_n969AgenciaBancoNome ;
      private string[] P00EQ3_A960ChavePIXUpdatedByName ;
      private bool[] P00EQ3_n960ChavePIXUpdatedByName ;
      private string[] P00EQ3_A958ChavePIXCreatedByName ;
      private bool[] P00EQ3_n958ChavePIXCreatedByName ;
      private long[] P00EQ3_A952ContaBancariaNumero ;
      private bool[] P00EQ3_n952ContaBancariaNumero ;
      private bool[] P00EQ3_A965ChavePIXPrincipal ;
      private bool[] P00EQ3_n965ChavePIXPrincipal ;
      private bool[] P00EQ3_A964ChavePIXStatus ;
      private bool[] P00EQ3_n964ChavePIXStatus ;
      private string[] P00EQ3_A962ChavePIXTipo ;
      private bool[] P00EQ3_n962ChavePIXTipo ;
      private int[] P00EQ3_A961ChavePIXId ;
      private int[] P00EQ4_A938AgenciaId ;
      private bool[] P00EQ4_n938AgenciaId ;
      private int[] P00EQ4_A968AgenciaBancoId ;
      private bool[] P00EQ4_n968AgenciaBancoId ;
      private short[] P00EQ4_A959ChavePIXUpdatedBy ;
      private bool[] P00EQ4_n959ChavePIXUpdatedBy ;
      private short[] P00EQ4_A957ChavePIXCreatedBy ;
      private bool[] P00EQ4_n957ChavePIXCreatedBy ;
      private int[] P00EQ4_A951ContaBancariaId ;
      private bool[] P00EQ4_n951ContaBancariaId ;
      private DateTime[] P00EQ4_A967ChavePIXUpdatedAt ;
      private bool[] P00EQ4_n967ChavePIXUpdatedAt ;
      private DateTime[] P00EQ4_A966ChavePIXCreatedAt ;
      private bool[] P00EQ4_n966ChavePIXCreatedAt ;
      private string[] P00EQ4_A963ChavePIXConteudo ;
      private bool[] P00EQ4_n963ChavePIXConteudo ;
      private int[] P00EQ4_A939AgenciaNumero ;
      private bool[] P00EQ4_n939AgenciaNumero ;
      private string[] P00EQ4_A969AgenciaBancoNome ;
      private bool[] P00EQ4_n969AgenciaBancoNome ;
      private string[] P00EQ4_A960ChavePIXUpdatedByName ;
      private bool[] P00EQ4_n960ChavePIXUpdatedByName ;
      private string[] P00EQ4_A958ChavePIXCreatedByName ;
      private bool[] P00EQ4_n958ChavePIXCreatedByName ;
      private long[] P00EQ4_A952ContaBancariaNumero ;
      private bool[] P00EQ4_n952ContaBancariaNumero ;
      private bool[] P00EQ4_A965ChavePIXPrincipal ;
      private bool[] P00EQ4_n965ChavePIXPrincipal ;
      private bool[] P00EQ4_A964ChavePIXStatus ;
      private bool[] P00EQ4_n964ChavePIXStatus ;
      private string[] P00EQ4_A962ChavePIXTipo ;
      private bool[] P00EQ4_n962ChavePIXTipo ;
      private int[] P00EQ4_A961ChavePIXId ;
      private int[] P00EQ5_A938AgenciaId ;
      private bool[] P00EQ5_n938AgenciaId ;
      private int[] P00EQ5_A968AgenciaBancoId ;
      private bool[] P00EQ5_n968AgenciaBancoId ;
      private short[] P00EQ5_A957ChavePIXCreatedBy ;
      private bool[] P00EQ5_n957ChavePIXCreatedBy ;
      private short[] P00EQ5_A959ChavePIXUpdatedBy ;
      private bool[] P00EQ5_n959ChavePIXUpdatedBy ;
      private int[] P00EQ5_A951ContaBancariaId ;
      private bool[] P00EQ5_n951ContaBancariaId ;
      private DateTime[] P00EQ5_A967ChavePIXUpdatedAt ;
      private bool[] P00EQ5_n967ChavePIXUpdatedAt ;
      private DateTime[] P00EQ5_A966ChavePIXCreatedAt ;
      private bool[] P00EQ5_n966ChavePIXCreatedAt ;
      private string[] P00EQ5_A963ChavePIXConteudo ;
      private bool[] P00EQ5_n963ChavePIXConteudo ;
      private int[] P00EQ5_A939AgenciaNumero ;
      private bool[] P00EQ5_n939AgenciaNumero ;
      private string[] P00EQ5_A969AgenciaBancoNome ;
      private bool[] P00EQ5_n969AgenciaBancoNome ;
      private string[] P00EQ5_A960ChavePIXUpdatedByName ;
      private bool[] P00EQ5_n960ChavePIXUpdatedByName ;
      private string[] P00EQ5_A958ChavePIXCreatedByName ;
      private bool[] P00EQ5_n958ChavePIXCreatedByName ;
      private long[] P00EQ5_A952ContaBancariaNumero ;
      private bool[] P00EQ5_n952ContaBancariaNumero ;
      private bool[] P00EQ5_A965ChavePIXPrincipal ;
      private bool[] P00EQ5_n965ChavePIXPrincipal ;
      private bool[] P00EQ5_A964ChavePIXStatus ;
      private bool[] P00EQ5_n964ChavePIXStatus ;
      private string[] P00EQ5_A962ChavePIXTipo ;
      private bool[] P00EQ5_n962ChavePIXTipo ;
      private int[] P00EQ5_A961ChavePIXId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class chavepixwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EQ2( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV84Chavepixwwds_1_filterfulltext ,
                                             string AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV87Chavepixwwds_4_chavepixtipo1 ,
                                             short AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV88Chavepixwwds_5_contabancarianumero1 ,
                                             string AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV94Chavepixwwds_11_chavepixtipo2 ,
                                             short AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV95Chavepixwwds_12_contabancarianumero2 ,
                                             string AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV101Chavepixwwds_18_chavepixtipo3 ,
                                             short AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV102Chavepixwwds_19_contabancarianumero3 ,
                                             string AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV105Chavepixwwds_22_tfagenciabanconome ,
                                             int AV107Chavepixwwds_24_tfagencianumero ,
                                             int AV108Chavepixwwds_25_tfagencianumero_to ,
                                             long AV109Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV111Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV112Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV81ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[56];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, T1.ChavePIXCreatedBy AS ChavePIXCreatedBy, T1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, T6.BancoNome AS AgenciaBancoNome, T1.ContaBancariaId, T1.ChavePIXUpdatedAt, T1.ChavePIXCreatedAt, T1.ChavePIXConteudo, T5.AgenciaNumero, T3.SecUserName AS ChavePIXUpdatedByName, T2.SecUserName AS ChavePIXCreatedByName, T4.ContaBancariaNumero, T1.ChavePIXPrincipal, T1.ChavePIXStatus, T1.ChavePIXTipo, T1.ChavePIXId FROM (((((ChavePIX T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T6.BancoNome) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T5.AgenciaNumero,'999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T4.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)))");
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
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
            GXv_int1[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV87Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV94Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV101Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome like :lV105Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome = ( :AV106Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.BancoNome IS NULL or (char_length(trim(trailing ' ' from T6.BancoNome))=0))");
         }
         if ( ! (0==AV107Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero >= :AV107Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! (0==AV108Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero <= :AV108Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( ! (0==AV109Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero >= :AV109Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( ! (0==AV110Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero <= :AV110Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( AV111Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV111Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV112Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV113Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV116Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV116Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV117Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV118Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV120Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV120Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV121Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV122Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (0==AV81ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV81ContaBancariaId)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T6.BancoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00EQ3( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV84Chavepixwwds_1_filterfulltext ,
                                             string AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV87Chavepixwwds_4_chavepixtipo1 ,
                                             short AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV88Chavepixwwds_5_contabancarianumero1 ,
                                             string AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV94Chavepixwwds_11_chavepixtipo2 ,
                                             short AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV95Chavepixwwds_12_contabancarianumero2 ,
                                             string AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV101Chavepixwwds_18_chavepixtipo3 ,
                                             short AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV102Chavepixwwds_19_contabancarianumero3 ,
                                             string AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV105Chavepixwwds_22_tfagenciabanconome ,
                                             int AV107Chavepixwwds_24_tfagencianumero ,
                                             int AV108Chavepixwwds_25_tfagencianumero_to ,
                                             long AV109Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV111Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV112Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV81ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[56];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, T1.ChavePIXCreatedBy AS ChavePIXCreatedBy, T1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, T1.ChavePIXConteudo, T1.ContaBancariaId, T1.ChavePIXUpdatedAt, T1.ChavePIXCreatedAt, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome, T3.SecUserName AS ChavePIXUpdatedByName, T2.SecUserName AS ChavePIXCreatedByName, T4.ContaBancariaNumero, T1.ChavePIXPrincipal, T1.ChavePIXStatus, T1.ChavePIXTipo, T1.ChavePIXId FROM (((((ChavePIX T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T6.BancoNome) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T5.AgenciaNumero,'999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T4.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)))");
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
            GXv_int3[11] = 1;
            GXv_int3[12] = 1;
            GXv_int3[13] = 1;
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV87Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV94Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV101Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome like :lV105Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome = ( :AV106Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.BancoNome IS NULL or (char_length(trim(trailing ' ' from T6.BancoNome))=0))");
         }
         if ( ! (0==AV107Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero >= :AV107Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! (0==AV108Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero <= :AV108Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( ! (0==AV109Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero >= :AV109Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (0==AV110Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero <= :AV110Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV111Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV111Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV112Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV113Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV116Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV116Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV117Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV118Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV120Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV120Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV121Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV122Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (0==AV81ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV81ContaBancariaId)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ChavePIXConteudo";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00EQ4( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV84Chavepixwwds_1_filterfulltext ,
                                             string AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV87Chavepixwwds_4_chavepixtipo1 ,
                                             short AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV88Chavepixwwds_5_contabancarianumero1 ,
                                             string AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV94Chavepixwwds_11_chavepixtipo2 ,
                                             short AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV95Chavepixwwds_12_contabancarianumero2 ,
                                             string AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV101Chavepixwwds_18_chavepixtipo3 ,
                                             short AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV102Chavepixwwds_19_contabancarianumero3 ,
                                             string AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV105Chavepixwwds_22_tfagenciabanconome ,
                                             int AV107Chavepixwwds_24_tfagencianumero ,
                                             int AV108Chavepixwwds_25_tfagencianumero_to ,
                                             long AV109Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV111Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV112Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV81ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[56];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, T1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, T1.ChavePIXCreatedBy AS ChavePIXCreatedBy, T1.ContaBancariaId, T1.ChavePIXUpdatedAt, T1.ChavePIXCreatedAt, T1.ChavePIXConteudo, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome, T2.SecUserName AS ChavePIXUpdatedByName, T3.SecUserName AS ChavePIXCreatedByName, T4.ContaBancariaNumero, T1.ChavePIXPrincipal, T1.ChavePIXStatus, T1.ChavePIXTipo, T1.ChavePIXId FROM (((((ChavePIX T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T6.BancoNome) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T5.AgenciaNumero,'999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T4.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)))");
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
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV87Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV94Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV101Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome like :lV105Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome = ( :AV106Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.BancoNome IS NULL or (char_length(trim(trailing ' ' from T6.BancoNome))=0))");
         }
         if ( ! (0==AV107Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero >= :AV107Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! (0==AV108Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero <= :AV108Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( ! (0==AV109Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero >= :AV109Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! (0==AV110Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero <= :AV110Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( AV111Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV111Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV112Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV113Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV116Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV116Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV117Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV118Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV120Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV120Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV121Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV122Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (0==AV81ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV81ContaBancariaId)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ChavePIXCreatedBy";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00EQ5( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV111Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV84Chavepixwwds_1_filterfulltext ,
                                             string AV85Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV87Chavepixwwds_4_chavepixtipo1 ,
                                             short AV86Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV88Chavepixwwds_5_contabancarianumero1 ,
                                             string AV89Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV90Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV91Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV92Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV94Chavepixwwds_11_chavepixtipo2 ,
                                             short AV93Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV95Chavepixwwds_12_contabancarianumero2 ,
                                             string AV96Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV97Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV98Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV99Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV101Chavepixwwds_18_chavepixtipo3 ,
                                             short AV100Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV102Chavepixwwds_19_contabancarianumero3 ,
                                             string AV103Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV104Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV106Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV105Chavepixwwds_22_tfagenciabanconome ,
                                             int AV107Chavepixwwds_24_tfagencianumero ,
                                             int AV108Chavepixwwds_25_tfagencianumero_to ,
                                             long AV109Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV110Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV111Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV113Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV112Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV114Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV115Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV116Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV117Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV118Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV120Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV121Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV122Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV81ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[56];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, T1.ChavePIXCreatedBy AS ChavePIXCreatedBy, T1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, T1.ContaBancariaId, T1.ChavePIXUpdatedAt, T1.ChavePIXCreatedAt, T1.ChavePIXConteudo, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome, T3.SecUserName AS ChavePIXUpdatedByName, T2.SecUserName AS ChavePIXCreatedByName, T4.ContaBancariaNumero, T1.ChavePIXPrincipal, T1.ChavePIXStatus, T1.ChavePIXTipo, T1.ChavePIXId FROM (((((ChavePIX T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T6.BancoNome) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T5.AgenciaNumero,'999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T4.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV84Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV84Chavepixwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV87Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV88Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV88Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV89Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV85Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV90Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV94Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV95Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV95Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV96Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( AV91Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV97Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV101Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV102Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV102Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV103Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( AV98Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV100Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV104Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome like :lV105Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome = ( :AV106Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( StringUtil.StrCmp(AV106Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.BancoNome IS NULL or (char_length(trim(trailing ' ' from T6.BancoNome))=0))");
         }
         if ( ! (0==AV107Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero >= :AV107Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( ! (0==AV108Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero <= :AV108Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( ! (0==AV109Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero >= :AV109Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( ! (0==AV110Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero <= :AV110Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( AV111Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV111Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV112Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int7[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV113Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int7[46] = 1;
         }
         if ( StringUtil.StrCmp(AV113Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV114Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV115Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV116Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV116Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int7[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV117Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int7[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV118Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int7[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int7[50] = 1;
         }
         if ( StringUtil.StrCmp(AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV120Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV120Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int7[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV121Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int7[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV122Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int7[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int7[54] = 1;
         }
         if ( StringUtil.StrCmp(AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (0==AV81ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV81ContaBancariaId)");
         }
         else
         {
            GXv_int7[55] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ChavePIXUpdatedBy";
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
                     return conditional_P00EQ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
               case 1 :
                     return conditional_P00EQ3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
               case 2 :
                     return conditional_P00EQ4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
               case 3 :
                     return conditional_P00EQ5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] );
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
          Object[] prmP00EQ2;
          prmP00EQ2 = new Object[] {
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV87Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV94Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV101Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV105Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV106Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV107Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV108Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV109Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV110Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV112Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV113Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV116Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV117Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV118Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV120Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV121Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV122Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV81ContaBancariaId",GXType.Int32,9,0)
          };
          Object[] prmP00EQ3;
          prmP00EQ3 = new Object[] {
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV87Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV94Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV101Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV105Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV106Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV107Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV108Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV109Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV110Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV112Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV113Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV116Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV117Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV118Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV120Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV121Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV122Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV81ContaBancariaId",GXType.Int32,9,0)
          };
          Object[] prmP00EQ4;
          prmP00EQ4 = new Object[] {
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV87Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV94Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV101Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV105Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV106Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV107Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV108Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV109Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV110Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV112Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV113Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV116Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV117Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV118Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV120Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV121Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV122Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV81ContaBancariaId",GXType.Int32,9,0)
          };
          Object[] prmP00EQ5;
          prmP00EQ5 = new Object[] {
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV84Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV87Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV89Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV94Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV96Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV101Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV102Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV103Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV104Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV105Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV106Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV107Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV108Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV109Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV110Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV112Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV113Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV116Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV117Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV118Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV119Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV120Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV121Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV122Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV123Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV81ContaBancariaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EQ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EQ5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EQ5,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                return;
       }
    }

 }

}
