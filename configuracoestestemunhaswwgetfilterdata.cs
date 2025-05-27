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
   public class configuracoestestemunhaswwgetfilterdata : GXProcedure
   {
      public configuracoestestemunhaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracoestestemunhaswwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CONFIGURACOESTESTEMUNHASNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONFIGURACOESTESTEMUNHASNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CONFIGURACOESTESTEMUNHASDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCONFIGURACOESTESTEMUNHASDOCUMENTOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CONFIGURACOESTESTEMUNHASEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADCONFIGURACOESTESTEMUNHASEMAILOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV27Session.Get("ConfiguracoesTestemunhasWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfiguracoesTestemunhasWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("ConfiguracoesTestemunhasWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASNOME") == 0 )
            {
               AV10TFConfiguracoesTestemunhasNome = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASNOME_SEL") == 0 )
            {
               AV11TFConfiguracoesTestemunhasNome_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASDOCUMENTO") == 0 )
            {
               AV12TFConfiguracoesTestemunhasDocumento = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASDOCUMENTO_SEL") == 0 )
            {
               AV13TFConfiguracoesTestemunhasDocumento_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASEMAIL") == 0 )
            {
               AV14TFConfiguracoesTestemunhasEmail = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASEMAIL_SEL") == 0 )
            {
               AV15TFConfiguracoesTestemunhasEmail_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV39DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 )
            {
               AV40DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV41ConfiguracoesTestemunhasNome1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV45ConfiguracoesTestemunhasNome2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV46DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV47DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 )
                  {
                     AV48DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV49ConfiguracoesTestemunhasNome3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONFIGURACOESTESTEMUNHASNOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFConfiguracoesTestemunhasNome = AV16SearchTxt;
         AV11TFConfiguracoesTestemunhasNome_Sel = "";
         AV52Configuracoestestemunhaswwds_1_filterfulltext = AV38FilterFullText;
         AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = AV41ConfiguracoesTestemunhasNome1;
         AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = AV45ConfiguracoesTestemunhasNome2;
         AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = AV49ConfiguracoesTestemunhasNome3;
         AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = AV10TFConfiguracoesTestemunhasNome;
         AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel = AV11TFConfiguracoesTestemunhasNome_Sel;
         AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = AV12TFConfiguracoesTestemunhasDocumento;
         AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel = AV13TFConfiguracoesTestemunhasDocumento_Sel;
         AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = AV14TFConfiguracoesTestemunhasEmail;
         AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel = AV15TFConfiguracoesTestemunhasEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Configuracoestestemunhaswwds_1_filterfulltext ,
                                              AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                              AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                              AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                              AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                              AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                              AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                              AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                              AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                              AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                              AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                              AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                              AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                              AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                              AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                              AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                              AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                              AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                              A479ConfiguracoesTestemunhasNome ,
                                              A480ConfiguracoesTestemunhasDocumento ,
                                              A481ConfiguracoesTestemunhasEmail ,
                                              A133SecUserId ,
                                              AV9WWPContext.gxTpr_Userid } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT
                                              }
         });
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = StringUtil.Concat( StringUtil.RTrim( AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome), "%", "");
         lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = StringUtil.Concat( StringUtil.RTrim( AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento), "%", "");
         lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = StringUtil.Concat( StringUtil.RTrim( AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail), "%", "");
         /* Using cursor P00AC2 */
         pr_default.execute(0, new Object[] {AV9WWPContext.gxTpr_Userid, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome, AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento, AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail, AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAC2 = false;
            A133SecUserId = P00AC2_A133SecUserId[0];
            n133SecUserId = P00AC2_n133SecUserId[0];
            A479ConfiguracoesTestemunhasNome = P00AC2_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = P00AC2_n479ConfiguracoesTestemunhasNome[0];
            A481ConfiguracoesTestemunhasEmail = P00AC2_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = P00AC2_n481ConfiguracoesTestemunhasEmail[0];
            A480ConfiguracoesTestemunhasDocumento = P00AC2_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = P00AC2_n480ConfiguracoesTestemunhasDocumento[0];
            A478ConfiguracoesTestemunhasId = P00AC2_A478ConfiguracoesTestemunhasId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AC2_A479ConfiguracoesTestemunhasNome[0], A479ConfiguracoesTestemunhasNome) == 0 ) )
            {
               BRKAC2 = false;
               A478ConfiguracoesTestemunhasId = P00AC2_A478ConfiguracoesTestemunhasId[0];
               AV26count = (long)(AV26count+1);
               BRKAC2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A479ConfiguracoesTestemunhasNome)) ? "<#Empty#>" : A479ConfiguracoesTestemunhasNome);
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
            if ( ! BRKAC2 )
            {
               BRKAC2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONFIGURACOESTESTEMUNHASDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV12TFConfiguracoesTestemunhasDocumento = AV16SearchTxt;
         AV13TFConfiguracoesTestemunhasDocumento_Sel = "";
         AV52Configuracoestestemunhaswwds_1_filterfulltext = AV38FilterFullText;
         AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = AV41ConfiguracoesTestemunhasNome1;
         AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = AV45ConfiguracoesTestemunhasNome2;
         AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = AV49ConfiguracoesTestemunhasNome3;
         AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = AV10TFConfiguracoesTestemunhasNome;
         AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel = AV11TFConfiguracoesTestemunhasNome_Sel;
         AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = AV12TFConfiguracoesTestemunhasDocumento;
         AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel = AV13TFConfiguracoesTestemunhasDocumento_Sel;
         AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = AV14TFConfiguracoesTestemunhasEmail;
         AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel = AV15TFConfiguracoesTestemunhasEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Configuracoestestemunhaswwds_1_filterfulltext ,
                                              AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                              AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                              AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                              AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                              AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                              AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                              AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                              AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                              AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                              AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                              AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                              AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                              AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                              AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                              AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                              AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                              AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                              A479ConfiguracoesTestemunhasNome ,
                                              A480ConfiguracoesTestemunhasDocumento ,
                                              A481ConfiguracoesTestemunhasEmail ,
                                              A133SecUserId ,
                                              AV9WWPContext.gxTpr_Userid } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT
                                              }
         });
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = StringUtil.Concat( StringUtil.RTrim( AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome), "%", "");
         lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = StringUtil.Concat( StringUtil.RTrim( AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento), "%", "");
         lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = StringUtil.Concat( StringUtil.RTrim( AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail), "%", "");
         /* Using cursor P00AC3 */
         pr_default.execute(1, new Object[] {AV9WWPContext.gxTpr_Userid, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome, AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento, AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail, AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAC4 = false;
            A133SecUserId = P00AC3_A133SecUserId[0];
            n133SecUserId = P00AC3_n133SecUserId[0];
            A480ConfiguracoesTestemunhasDocumento = P00AC3_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = P00AC3_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = P00AC3_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = P00AC3_n481ConfiguracoesTestemunhasEmail[0];
            A479ConfiguracoesTestemunhasNome = P00AC3_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = P00AC3_n479ConfiguracoesTestemunhasNome[0];
            A478ConfiguracoesTestemunhasId = P00AC3_A478ConfiguracoesTestemunhasId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AC3_A480ConfiguracoesTestemunhasDocumento[0], A480ConfiguracoesTestemunhasDocumento) == 0 ) )
            {
               BRKAC4 = false;
               A478ConfiguracoesTestemunhasId = P00AC3_A478ConfiguracoesTestemunhasId[0];
               AV26count = (long)(AV26count+1);
               BRKAC4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A480ConfiguracoesTestemunhasDocumento)) ? "<#Empty#>" : A480ConfiguracoesTestemunhasDocumento);
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
            if ( ! BRKAC4 )
            {
               BRKAC4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCONFIGURACOESTESTEMUNHASEMAILOPTIONS' Routine */
         returnInSub = false;
         AV14TFConfiguracoesTestemunhasEmail = AV16SearchTxt;
         AV15TFConfiguracoesTestemunhasEmail_Sel = "";
         AV52Configuracoestestemunhaswwds_1_filterfulltext = AV38FilterFullText;
         AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = AV41ConfiguracoesTestemunhasNome1;
         AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = AV45ConfiguracoesTestemunhasNome2;
         AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = AV49ConfiguracoesTestemunhasNome3;
         AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = AV10TFConfiguracoesTestemunhasNome;
         AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel = AV11TFConfiguracoesTestemunhasNome_Sel;
         AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = AV12TFConfiguracoesTestemunhasDocumento;
         AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel = AV13TFConfiguracoesTestemunhasDocumento_Sel;
         AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = AV14TFConfiguracoesTestemunhasEmail;
         AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel = AV15TFConfiguracoesTestemunhasEmail_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV52Configuracoestestemunhaswwds_1_filterfulltext ,
                                              AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                              AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                              AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                              AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                              AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                              AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                              AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                              AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                              AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                              AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                              AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                              AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                              AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                              AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                              AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                              AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                              AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                              A479ConfiguracoesTestemunhasNome ,
                                              A480ConfiguracoesTestemunhasDocumento ,
                                              A481ConfiguracoesTestemunhasEmail ,
                                              A133SecUserId ,
                                              AV9WWPContext.gxTpr_Userid } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT
                                              }
         });
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV52Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = StringUtil.Concat( StringUtil.RTrim( AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome), "%", "");
         lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = StringUtil.Concat( StringUtil.RTrim( AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento), "%", "");
         lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = StringUtil.Concat( StringUtil.RTrim( AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail), "%", "");
         /* Using cursor P00AC4 */
         pr_default.execute(2, new Object[] {AV9WWPContext.gxTpr_Userid, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV52Configuracoestestemunhaswwds_1_filterfulltext, lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome, AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento, AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail, AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAC6 = false;
            A133SecUserId = P00AC4_A133SecUserId[0];
            n133SecUserId = P00AC4_n133SecUserId[0];
            A481ConfiguracoesTestemunhasEmail = P00AC4_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = P00AC4_n481ConfiguracoesTestemunhasEmail[0];
            A480ConfiguracoesTestemunhasDocumento = P00AC4_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = P00AC4_n480ConfiguracoesTestemunhasDocumento[0];
            A479ConfiguracoesTestemunhasNome = P00AC4_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = P00AC4_n479ConfiguracoesTestemunhasNome[0];
            A478ConfiguracoesTestemunhasId = P00AC4_A478ConfiguracoesTestemunhasId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AC4_A481ConfiguracoesTestemunhasEmail[0], A481ConfiguracoesTestemunhasEmail) == 0 ) )
            {
               BRKAC6 = false;
               A478ConfiguracoesTestemunhasId = P00AC4_A478ConfiguracoesTestemunhasId[0];
               AV26count = (long)(AV26count+1);
               BRKAC6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A481ConfiguracoesTestemunhasEmail)) ? "<#Empty#>" : A481ConfiguracoesTestemunhasEmail);
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
            if ( ! BRKAC6 )
            {
               BRKAC6 = true;
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
         AV10TFConfiguracoesTestemunhasNome = "";
         AV11TFConfiguracoesTestemunhasNome_Sel = "";
         AV12TFConfiguracoesTestemunhasDocumento = "";
         AV13TFConfiguracoesTestemunhasDocumento_Sel = "";
         AV14TFConfiguracoesTestemunhasEmail = "";
         AV15TFConfiguracoesTestemunhasEmail_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39DynamicFiltersSelector1 = "";
         AV41ConfiguracoesTestemunhasNome1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45ConfiguracoesTestemunhasNome2 = "";
         AV47DynamicFiltersSelector3 = "";
         AV49ConfiguracoesTestemunhasNome3 = "";
         AV52Configuracoestestemunhaswwds_1_filterfulltext = "";
         AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 = "";
         AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = "";
         AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 = "";
         AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = "";
         AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 = "";
         AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = "";
         AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = "";
         AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel = "";
         AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = "";
         AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel = "";
         AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = "";
         AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel = "";
         lV52Configuracoestestemunhaswwds_1_filterfulltext = "";
         lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = "";
         lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = "";
         lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = "";
         lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = "";
         lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = "";
         lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = "";
         A479ConfiguracoesTestemunhasNome = "";
         A480ConfiguracoesTestemunhasDocumento = "";
         A481ConfiguracoesTestemunhasEmail = "";
         P00AC2_A133SecUserId = new short[1] ;
         P00AC2_n133SecUserId = new bool[] {false} ;
         P00AC2_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         P00AC2_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         P00AC2_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         P00AC2_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         P00AC2_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         P00AC2_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         P00AC2_A478ConfiguracoesTestemunhasId = new int[1] ;
         AV21Option = "";
         P00AC3_A133SecUserId = new short[1] ;
         P00AC3_n133SecUserId = new bool[] {false} ;
         P00AC3_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         P00AC3_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         P00AC3_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         P00AC3_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         P00AC3_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         P00AC3_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         P00AC3_A478ConfiguracoesTestemunhasId = new int[1] ;
         P00AC4_A133SecUserId = new short[1] ;
         P00AC4_n133SecUserId = new bool[] {false} ;
         P00AC4_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         P00AC4_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         P00AC4_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         P00AC4_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         P00AC4_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         P00AC4_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         P00AC4_A478ConfiguracoesTestemunhasId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracoestestemunhaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AC2_A133SecUserId, P00AC2_n133SecUserId, P00AC2_A479ConfiguracoesTestemunhasNome, P00AC2_n479ConfiguracoesTestemunhasNome, P00AC2_A481ConfiguracoesTestemunhasEmail, P00AC2_n481ConfiguracoesTestemunhasEmail, P00AC2_A480ConfiguracoesTestemunhasDocumento, P00AC2_n480ConfiguracoesTestemunhasDocumento, P00AC2_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               P00AC3_A133SecUserId, P00AC3_n133SecUserId, P00AC3_A480ConfiguracoesTestemunhasDocumento, P00AC3_n480ConfiguracoesTestemunhasDocumento, P00AC3_A481ConfiguracoesTestemunhasEmail, P00AC3_n481ConfiguracoesTestemunhasEmail, P00AC3_A479ConfiguracoesTestemunhasNome, P00AC3_n479ConfiguracoesTestemunhasNome, P00AC3_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               P00AC4_A133SecUserId, P00AC4_n133SecUserId, P00AC4_A481ConfiguracoesTestemunhasEmail, P00AC4_n481ConfiguracoesTestemunhasEmail, P00AC4_A480ConfiguracoesTestemunhasDocumento, P00AC4_n480ConfiguracoesTestemunhasDocumento, P00AC4_A479ConfiguracoesTestemunhasNome, P00AC4_n479ConfiguracoesTestemunhasNome, P00AC4_A478ConfiguracoesTestemunhasId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV40DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV48DynamicFiltersOperator3 ;
      private short AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ;
      private short AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ;
      private short AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ;
      private short AV9WWPContext_gxTpr_Userid ;
      private short A133SecUserId ;
      private int AV50GXV1 ;
      private int A478ConfiguracoesTestemunhasId ;
      private long AV26count ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV46DynamicFiltersEnabled3 ;
      private bool AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ;
      private bool AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ;
      private bool BRKAC2 ;
      private bool n133SecUserId ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private bool n481ConfiguracoesTestemunhasEmail ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool BRKAC4 ;
      private bool BRKAC6 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV10TFConfiguracoesTestemunhasNome ;
      private string AV11TFConfiguracoesTestemunhasNome_Sel ;
      private string AV12TFConfiguracoesTestemunhasDocumento ;
      private string AV13TFConfiguracoesTestemunhasDocumento_Sel ;
      private string AV14TFConfiguracoesTestemunhasEmail ;
      private string AV15TFConfiguracoesTestemunhasEmail_Sel ;
      private string AV39DynamicFiltersSelector1 ;
      private string AV41ConfiguracoesTestemunhasNome1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV45ConfiguracoesTestemunhasNome2 ;
      private string AV47DynamicFiltersSelector3 ;
      private string AV49ConfiguracoesTestemunhasNome3 ;
      private string AV52Configuracoestestemunhaswwds_1_filterfulltext ;
      private string AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ;
      private string AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ;
      private string AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ;
      private string AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ;
      private string AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ;
      private string AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ;
      private string AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ;
      private string AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ;
      private string AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ;
      private string AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ;
      private string AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ;
      private string AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ;
      private string lV52Configuracoestestemunhaswwds_1_filterfulltext ;
      private string lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ;
      private string lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ;
      private string lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ;
      private string lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ;
      private string lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ;
      private string lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ;
      private string A479ConfiguracoesTestemunhasNome ;
      private string A480ConfiguracoesTestemunhasDocumento ;
      private string A481ConfiguracoesTestemunhasEmail ;
      private string AV21Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00AC2_A133SecUserId ;
      private bool[] P00AC2_n133SecUserId ;
      private string[] P00AC2_A479ConfiguracoesTestemunhasNome ;
      private bool[] P00AC2_n479ConfiguracoesTestemunhasNome ;
      private string[] P00AC2_A481ConfiguracoesTestemunhasEmail ;
      private bool[] P00AC2_n481ConfiguracoesTestemunhasEmail ;
      private string[] P00AC2_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] P00AC2_n480ConfiguracoesTestemunhasDocumento ;
      private int[] P00AC2_A478ConfiguracoesTestemunhasId ;
      private short[] P00AC3_A133SecUserId ;
      private bool[] P00AC3_n133SecUserId ;
      private string[] P00AC3_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] P00AC3_n480ConfiguracoesTestemunhasDocumento ;
      private string[] P00AC3_A481ConfiguracoesTestemunhasEmail ;
      private bool[] P00AC3_n481ConfiguracoesTestemunhasEmail ;
      private string[] P00AC3_A479ConfiguracoesTestemunhasNome ;
      private bool[] P00AC3_n479ConfiguracoesTestemunhasNome ;
      private int[] P00AC3_A478ConfiguracoesTestemunhasId ;
      private short[] P00AC4_A133SecUserId ;
      private bool[] P00AC4_n133SecUserId ;
      private string[] P00AC4_A481ConfiguracoesTestemunhasEmail ;
      private bool[] P00AC4_n481ConfiguracoesTestemunhasEmail ;
      private string[] P00AC4_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] P00AC4_n480ConfiguracoesTestemunhasDocumento ;
      private string[] P00AC4_A479ConfiguracoesTestemunhasNome ;
      private bool[] P00AC4_n479ConfiguracoesTestemunhasNome ;
      private int[] P00AC4_A478ConfiguracoesTestemunhasId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class configuracoestestemunhaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AC2( IGxContext context ,
                                             string AV52Configuracoestestemunhaswwds_1_filterfulltext ,
                                             string AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                             short AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                             string AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                             bool AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                             string AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                             short AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                             string AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                             bool AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                             string AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                             short AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                             string AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                             string AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                             string AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                             string AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                             string AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                             string AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                             string AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                             string A479ConfiguracoesTestemunhasNome ,
                                             string A480ConfiguracoesTestemunhasDocumento ,
                                             string A481ConfiguracoesTestemunhasEmail ,
                                             short A133SecUserId ,
                                             short AV9WWPContext_gxTpr_Userid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SecUserId, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasEmail, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas";
         AddWhere(sWhereString, "(SecUserId = :AV9WWPContext__Userid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracoesTestemunhasNome like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasDocumento like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasEmail like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ! ( StringUtil.StrCmp(AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome = ( :AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento like :lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ! ( StringUtil.StrCmp(AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento = ( :AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail like :lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ! ( StringUtil.StrCmp(AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail = ( :AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ConfiguracoesTestemunhasNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AC3( IGxContext context ,
                                             string AV52Configuracoestestemunhaswwds_1_filterfulltext ,
                                             string AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                             short AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                             string AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                             bool AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                             string AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                             short AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                             string AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                             bool AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                             string AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                             short AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                             string AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                             string AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                             string AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                             string AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                             string AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                             string AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                             string AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                             string A479ConfiguracoesTestemunhasNome ,
                                             string A480ConfiguracoesTestemunhasDocumento ,
                                             string A481ConfiguracoesTestemunhasEmail ,
                                             short A133SecUserId ,
                                             short AV9WWPContext_gxTpr_Userid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecUserId, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas";
         AddWhere(sWhereString, "(SecUserId = :AV9WWPContext__Userid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracoesTestemunhasNome like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasDocumento like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasEmail like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ! ( StringUtil.StrCmp(AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome = ( :AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento like :lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ! ( StringUtil.StrCmp(AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento = ( :AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail like :lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ! ( StringUtil.StrCmp(AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail = ( :AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ConfiguracoesTestemunhasDocumento";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AC4( IGxContext context ,
                                             string AV52Configuracoestestemunhaswwds_1_filterfulltext ,
                                             string AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                             short AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                             string AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                             bool AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                             string AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                             short AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                             string AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                             bool AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                             string AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                             short AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                             string AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                             string AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                             string AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                             string AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                             string AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                             string AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                             string AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                             string A479ConfiguracoesTestemunhasNome ,
                                             string A480ConfiguracoesTestemunhasDocumento ,
                                             string A481ConfiguracoesTestemunhasEmail ,
                                             short A133SecUserId ,
                                             short AV9WWPContext_gxTpr_Userid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SecUserId, ConfiguracoesTestemunhasEmail, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas";
         AddWhere(sWhereString, "(SecUserId = :AV9WWPContext__Userid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracoestestemunhaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracoesTestemunhasNome like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasDocumento like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasEmail like '%' || :lV52Configuracoestestemunhaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV54Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV56Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV58Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV60Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV62Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ! ( StringUtil.StrCmp(AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome = ( :AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento like :lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ! ( StringUtil.StrCmp(AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento = ( :AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail like :lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ! ( StringUtil.StrCmp(AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail = ( :AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ConfiguracoesTestemunhasEmail";
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
                     return conditional_P00AC2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] );
               case 1 :
                     return conditional_P00AC3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] );
               case 2 :
                     return conditional_P00AC4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] );
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
          Object[] prmP00AC2;
          prmP00AC2 = new Object[] {
          new ParDef("AV9WWPContext__Userid",GXType.Int16,4,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase",GXType.VarChar,100,0) ,
          new ParDef("AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase",GXType.VarChar,100,0)
          };
          Object[] prmP00AC3;
          prmP00AC3 = new Object[] {
          new ParDef("AV9WWPContext__Userid",GXType.Int16,4,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase",GXType.VarChar,100,0) ,
          new ParDef("AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase",GXType.VarChar,100,0)
          };
          Object[] prmP00AC4;
          prmP00AC4 = new Object[] {
          new ParDef("AV9WWPContext__Userid",GXType.Int16,4,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV55Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV59Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV63Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV64Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("AV65Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("lV66Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("AV67Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("lV68Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase",GXType.VarChar,100,0) ,
          new ParDef("AV69Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AC3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AC4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AC4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
