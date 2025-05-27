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
   public class empresawwgetfilterdata : GXProcedure
   {
      public empresawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public empresawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_EMPRESANOMEFANTASIA") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPRESANOMEFANTASIAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_EMPRESARAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPRESARAZAOSOCIALOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_EMPRESACNPJ") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPRESACNPJOPTIONS' */
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
         if ( StringUtil.StrCmp(AV27Session.Get("EmpresaWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EmpresaWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("EmpresaWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESANOMEFANTASIA") == 0 )
            {
               AV10TFEmpresaNomeFantasia = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESANOMEFANTASIA_SEL") == 0 )
            {
               AV11TFEmpresaNomeFantasia_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESARAZAOSOCIAL") == 0 )
            {
               AV12TFEmpresaRazaoSocial = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESARAZAOSOCIAL_SEL") == 0 )
            {
               AV13TFEmpresaRazaoSocial_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESACNPJ") == 0 )
            {
               AV14TFEmpresaCNPJ = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESACNPJ_SEL") == 0 )
            {
               AV15TFEmpresaCNPJ_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESASEDE_SEL") == 0 )
            {
               AV50TFEmpresaSede_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV39DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV39DynamicFiltersSelector1, "EMPRESANOMEFANTASIA") == 0 )
            {
               AV40DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV41EmpresaNomeFantasia1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "EMPRESANOMEFANTASIA") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV45EmpresaNomeFantasia2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV46DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV47DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV47DynamicFiltersSelector3, "EMPRESANOMEFANTASIA") == 0 )
                  {
                     AV48DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV49EmpresaNomeFantasia3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPRESANOMEFANTASIAOPTIONS' Routine */
         returnInSub = false;
         AV10TFEmpresaNomeFantasia = AV16SearchTxt;
         AV11TFEmpresaNomeFantasia_Sel = "";
         AV53Empresawwds_1_filterfulltext = AV38FilterFullText;
         AV54Empresawwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV55Empresawwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV56Empresawwds_4_empresanomefantasia1 = AV41EmpresaNomeFantasia1;
         AV57Empresawwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV58Empresawwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV59Empresawwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV60Empresawwds_8_empresanomefantasia2 = AV45EmpresaNomeFantasia2;
         AV61Empresawwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV62Empresawwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV63Empresawwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV64Empresawwds_12_empresanomefantasia3 = AV49EmpresaNomeFantasia3;
         AV65Empresawwds_13_tfempresanomefantasia = AV10TFEmpresaNomeFantasia;
         AV66Empresawwds_14_tfempresanomefantasia_sel = AV11TFEmpresaNomeFantasia_Sel;
         AV67Empresawwds_15_tfempresarazaosocial = AV12TFEmpresaRazaoSocial;
         AV68Empresawwds_16_tfempresarazaosocial_sel = AV13TFEmpresaRazaoSocial_Sel;
         AV69Empresawwds_17_tfempresacnpj = AV14TFEmpresaCNPJ;
         AV70Empresawwds_18_tfempresacnpj_sel = AV15TFEmpresaCNPJ_Sel;
         AV71Empresawwds_19_tfempresasede_sel = AV50TFEmpresaSede_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Empresawwds_1_filterfulltext ,
                                              AV54Empresawwds_2_dynamicfiltersselector1 ,
                                              AV55Empresawwds_3_dynamicfiltersoperator1 ,
                                              AV56Empresawwds_4_empresanomefantasia1 ,
                                              AV57Empresawwds_5_dynamicfiltersenabled2 ,
                                              AV58Empresawwds_6_dynamicfiltersselector2 ,
                                              AV59Empresawwds_7_dynamicfiltersoperator2 ,
                                              AV60Empresawwds_8_empresanomefantasia2 ,
                                              AV61Empresawwds_9_dynamicfiltersenabled3 ,
                                              AV62Empresawwds_10_dynamicfiltersselector3 ,
                                              AV63Empresawwds_11_dynamicfiltersoperator3 ,
                                              AV64Empresawwds_12_empresanomefantasia3 ,
                                              AV66Empresawwds_14_tfempresanomefantasia_sel ,
                                              AV65Empresawwds_13_tfempresanomefantasia ,
                                              AV68Empresawwds_16_tfempresarazaosocial_sel ,
                                              AV67Empresawwds_15_tfempresarazaosocial ,
                                              AV70Empresawwds_18_tfempresacnpj_sel ,
                                              AV69Empresawwds_17_tfempresacnpj ,
                                              AV71Empresawwds_19_tfempresasede_sel ,
                                              A250EmpresaNomeFantasia ,
                                              A251EmpresaRazaoSocial ,
                                              A252EmpresaCNPJ ,
                                              A253EmpresaSede } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV56Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1), "%", "");
         lV56Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1), "%", "");
         lV60Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2), "%", "");
         lV60Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2), "%", "");
         lV64Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3), "%", "");
         lV64Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3), "%", "");
         lV65Empresawwds_13_tfempresanomefantasia = StringUtil.Concat( StringUtil.RTrim( AV65Empresawwds_13_tfempresanomefantasia), "%", "");
         lV67Empresawwds_15_tfempresarazaosocial = StringUtil.Concat( StringUtil.RTrim( AV67Empresawwds_15_tfempresarazaosocial), "%", "");
         lV69Empresawwds_17_tfempresacnpj = StringUtil.Concat( StringUtil.RTrim( AV69Empresawwds_17_tfempresacnpj), "%", "");
         /* Using cursor P007E2 */
         pr_default.execute(0, new Object[] {lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV56Empresawwds_4_empresanomefantasia1, lV56Empresawwds_4_empresanomefantasia1, lV60Empresawwds_8_empresanomefantasia2, lV60Empresawwds_8_empresanomefantasia2, lV64Empresawwds_12_empresanomefantasia3, lV64Empresawwds_12_empresanomefantasia3, lV65Empresawwds_13_tfempresanomefantasia, AV66Empresawwds_14_tfempresanomefantasia_sel, lV67Empresawwds_15_tfempresarazaosocial, AV68Empresawwds_16_tfempresarazaosocial_sel, lV69Empresawwds_17_tfempresacnpj, AV70Empresawwds_18_tfempresacnpj_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7E2 = false;
            A250EmpresaNomeFantasia = P007E2_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = P007E2_n250EmpresaNomeFantasia[0];
            A253EmpresaSede = P007E2_A253EmpresaSede[0];
            n253EmpresaSede = P007E2_n253EmpresaSede[0];
            A252EmpresaCNPJ = P007E2_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = P007E2_n252EmpresaCNPJ[0];
            A251EmpresaRazaoSocial = P007E2_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = P007E2_n251EmpresaRazaoSocial[0];
            A249EmpresaId = P007E2_A249EmpresaId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007E2_A250EmpresaNomeFantasia[0], A250EmpresaNomeFantasia) == 0 ) )
            {
               BRK7E2 = false;
               A249EmpresaId = P007E2_A249EmpresaId[0];
               AV26count = (long)(AV26count+1);
               BRK7E2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A250EmpresaNomeFantasia)) ? "<#Empty#>" : A250EmpresaNomeFantasia);
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
            if ( ! BRK7E2 )
            {
               BRK7E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADEMPRESARAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV12TFEmpresaRazaoSocial = AV16SearchTxt;
         AV13TFEmpresaRazaoSocial_Sel = "";
         AV53Empresawwds_1_filterfulltext = AV38FilterFullText;
         AV54Empresawwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV55Empresawwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV56Empresawwds_4_empresanomefantasia1 = AV41EmpresaNomeFantasia1;
         AV57Empresawwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV58Empresawwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV59Empresawwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV60Empresawwds_8_empresanomefantasia2 = AV45EmpresaNomeFantasia2;
         AV61Empresawwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV62Empresawwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV63Empresawwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV64Empresawwds_12_empresanomefantasia3 = AV49EmpresaNomeFantasia3;
         AV65Empresawwds_13_tfempresanomefantasia = AV10TFEmpresaNomeFantasia;
         AV66Empresawwds_14_tfempresanomefantasia_sel = AV11TFEmpresaNomeFantasia_Sel;
         AV67Empresawwds_15_tfempresarazaosocial = AV12TFEmpresaRazaoSocial;
         AV68Empresawwds_16_tfempresarazaosocial_sel = AV13TFEmpresaRazaoSocial_Sel;
         AV69Empresawwds_17_tfempresacnpj = AV14TFEmpresaCNPJ;
         AV70Empresawwds_18_tfempresacnpj_sel = AV15TFEmpresaCNPJ_Sel;
         AV71Empresawwds_19_tfempresasede_sel = AV50TFEmpresaSede_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Empresawwds_1_filterfulltext ,
                                              AV54Empresawwds_2_dynamicfiltersselector1 ,
                                              AV55Empresawwds_3_dynamicfiltersoperator1 ,
                                              AV56Empresawwds_4_empresanomefantasia1 ,
                                              AV57Empresawwds_5_dynamicfiltersenabled2 ,
                                              AV58Empresawwds_6_dynamicfiltersselector2 ,
                                              AV59Empresawwds_7_dynamicfiltersoperator2 ,
                                              AV60Empresawwds_8_empresanomefantasia2 ,
                                              AV61Empresawwds_9_dynamicfiltersenabled3 ,
                                              AV62Empresawwds_10_dynamicfiltersselector3 ,
                                              AV63Empresawwds_11_dynamicfiltersoperator3 ,
                                              AV64Empresawwds_12_empresanomefantasia3 ,
                                              AV66Empresawwds_14_tfempresanomefantasia_sel ,
                                              AV65Empresawwds_13_tfempresanomefantasia ,
                                              AV68Empresawwds_16_tfempresarazaosocial_sel ,
                                              AV67Empresawwds_15_tfempresarazaosocial ,
                                              AV70Empresawwds_18_tfempresacnpj_sel ,
                                              AV69Empresawwds_17_tfempresacnpj ,
                                              AV71Empresawwds_19_tfempresasede_sel ,
                                              A250EmpresaNomeFantasia ,
                                              A251EmpresaRazaoSocial ,
                                              A252EmpresaCNPJ ,
                                              A253EmpresaSede } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV56Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1), "%", "");
         lV56Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1), "%", "");
         lV60Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2), "%", "");
         lV60Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2), "%", "");
         lV64Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3), "%", "");
         lV64Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3), "%", "");
         lV65Empresawwds_13_tfempresanomefantasia = StringUtil.Concat( StringUtil.RTrim( AV65Empresawwds_13_tfempresanomefantasia), "%", "");
         lV67Empresawwds_15_tfempresarazaosocial = StringUtil.Concat( StringUtil.RTrim( AV67Empresawwds_15_tfempresarazaosocial), "%", "");
         lV69Empresawwds_17_tfempresacnpj = StringUtil.Concat( StringUtil.RTrim( AV69Empresawwds_17_tfempresacnpj), "%", "");
         /* Using cursor P007E3 */
         pr_default.execute(1, new Object[] {lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV56Empresawwds_4_empresanomefantasia1, lV56Empresawwds_4_empresanomefantasia1, lV60Empresawwds_8_empresanomefantasia2, lV60Empresawwds_8_empresanomefantasia2, lV64Empresawwds_12_empresanomefantasia3, lV64Empresawwds_12_empresanomefantasia3, lV65Empresawwds_13_tfempresanomefantasia, AV66Empresawwds_14_tfempresanomefantasia_sel, lV67Empresawwds_15_tfempresarazaosocial, AV68Empresawwds_16_tfempresarazaosocial_sel, lV69Empresawwds_17_tfempresacnpj, AV70Empresawwds_18_tfempresacnpj_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7E4 = false;
            A251EmpresaRazaoSocial = P007E3_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = P007E3_n251EmpresaRazaoSocial[0];
            A253EmpresaSede = P007E3_A253EmpresaSede[0];
            n253EmpresaSede = P007E3_n253EmpresaSede[0];
            A252EmpresaCNPJ = P007E3_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = P007E3_n252EmpresaCNPJ[0];
            A250EmpresaNomeFantasia = P007E3_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = P007E3_n250EmpresaNomeFantasia[0];
            A249EmpresaId = P007E3_A249EmpresaId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007E3_A251EmpresaRazaoSocial[0], A251EmpresaRazaoSocial) == 0 ) )
            {
               BRK7E4 = false;
               A249EmpresaId = P007E3_A249EmpresaId[0];
               AV26count = (long)(AV26count+1);
               BRK7E4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A251EmpresaRazaoSocial)) ? "<#Empty#>" : A251EmpresaRazaoSocial);
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
            if ( ! BRK7E4 )
            {
               BRK7E4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADEMPRESACNPJOPTIONS' Routine */
         returnInSub = false;
         AV14TFEmpresaCNPJ = AV16SearchTxt;
         AV15TFEmpresaCNPJ_Sel = "";
         AV53Empresawwds_1_filterfulltext = AV38FilterFullText;
         AV54Empresawwds_2_dynamicfiltersselector1 = AV39DynamicFiltersSelector1;
         AV55Empresawwds_3_dynamicfiltersoperator1 = AV40DynamicFiltersOperator1;
         AV56Empresawwds_4_empresanomefantasia1 = AV41EmpresaNomeFantasia1;
         AV57Empresawwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV58Empresawwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV59Empresawwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV60Empresawwds_8_empresanomefantasia2 = AV45EmpresaNomeFantasia2;
         AV61Empresawwds_9_dynamicfiltersenabled3 = AV46DynamicFiltersEnabled3;
         AV62Empresawwds_10_dynamicfiltersselector3 = AV47DynamicFiltersSelector3;
         AV63Empresawwds_11_dynamicfiltersoperator3 = AV48DynamicFiltersOperator3;
         AV64Empresawwds_12_empresanomefantasia3 = AV49EmpresaNomeFantasia3;
         AV65Empresawwds_13_tfempresanomefantasia = AV10TFEmpresaNomeFantasia;
         AV66Empresawwds_14_tfempresanomefantasia_sel = AV11TFEmpresaNomeFantasia_Sel;
         AV67Empresawwds_15_tfempresarazaosocial = AV12TFEmpresaRazaoSocial;
         AV68Empresawwds_16_tfempresarazaosocial_sel = AV13TFEmpresaRazaoSocial_Sel;
         AV69Empresawwds_17_tfempresacnpj = AV14TFEmpresaCNPJ;
         AV70Empresawwds_18_tfempresacnpj_sel = AV15TFEmpresaCNPJ_Sel;
         AV71Empresawwds_19_tfempresasede_sel = AV50TFEmpresaSede_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV53Empresawwds_1_filterfulltext ,
                                              AV54Empresawwds_2_dynamicfiltersselector1 ,
                                              AV55Empresawwds_3_dynamicfiltersoperator1 ,
                                              AV56Empresawwds_4_empresanomefantasia1 ,
                                              AV57Empresawwds_5_dynamicfiltersenabled2 ,
                                              AV58Empresawwds_6_dynamicfiltersselector2 ,
                                              AV59Empresawwds_7_dynamicfiltersoperator2 ,
                                              AV60Empresawwds_8_empresanomefantasia2 ,
                                              AV61Empresawwds_9_dynamicfiltersenabled3 ,
                                              AV62Empresawwds_10_dynamicfiltersselector3 ,
                                              AV63Empresawwds_11_dynamicfiltersoperator3 ,
                                              AV64Empresawwds_12_empresanomefantasia3 ,
                                              AV66Empresawwds_14_tfempresanomefantasia_sel ,
                                              AV65Empresawwds_13_tfempresanomefantasia ,
                                              AV68Empresawwds_16_tfempresarazaosocial_sel ,
                                              AV67Empresawwds_15_tfempresarazaosocial ,
                                              AV70Empresawwds_18_tfempresacnpj_sel ,
                                              AV69Empresawwds_17_tfempresacnpj ,
                                              AV71Empresawwds_19_tfempresasede_sel ,
                                              A250EmpresaNomeFantasia ,
                                              A251EmpresaRazaoSocial ,
                                              A252EmpresaCNPJ ,
                                              A253EmpresaSede } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV53Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Empresawwds_1_filterfulltext), "%", "");
         lV56Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1), "%", "");
         lV56Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1), "%", "");
         lV60Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2), "%", "");
         lV60Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2), "%", "");
         lV64Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3), "%", "");
         lV64Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3), "%", "");
         lV65Empresawwds_13_tfempresanomefantasia = StringUtil.Concat( StringUtil.RTrim( AV65Empresawwds_13_tfempresanomefantasia), "%", "");
         lV67Empresawwds_15_tfempresarazaosocial = StringUtil.Concat( StringUtil.RTrim( AV67Empresawwds_15_tfempresarazaosocial), "%", "");
         lV69Empresawwds_17_tfempresacnpj = StringUtil.Concat( StringUtil.RTrim( AV69Empresawwds_17_tfempresacnpj), "%", "");
         /* Using cursor P007E4 */
         pr_default.execute(2, new Object[] {lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV53Empresawwds_1_filterfulltext, lV56Empresawwds_4_empresanomefantasia1, lV56Empresawwds_4_empresanomefantasia1, lV60Empresawwds_8_empresanomefantasia2, lV60Empresawwds_8_empresanomefantasia2, lV64Empresawwds_12_empresanomefantasia3, lV64Empresawwds_12_empresanomefantasia3, lV65Empresawwds_13_tfempresanomefantasia, AV66Empresawwds_14_tfempresanomefantasia_sel, lV67Empresawwds_15_tfempresarazaosocial, AV68Empresawwds_16_tfempresarazaosocial_sel, lV69Empresawwds_17_tfempresacnpj, AV70Empresawwds_18_tfempresacnpj_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7E6 = false;
            A252EmpresaCNPJ = P007E4_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = P007E4_n252EmpresaCNPJ[0];
            A253EmpresaSede = P007E4_A253EmpresaSede[0];
            n253EmpresaSede = P007E4_n253EmpresaSede[0];
            A251EmpresaRazaoSocial = P007E4_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = P007E4_n251EmpresaRazaoSocial[0];
            A250EmpresaNomeFantasia = P007E4_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = P007E4_n250EmpresaNomeFantasia[0];
            A249EmpresaId = P007E4_A249EmpresaId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007E4_A252EmpresaCNPJ[0], A252EmpresaCNPJ) == 0 ) )
            {
               BRK7E6 = false;
               A249EmpresaId = P007E4_A249EmpresaId[0];
               AV26count = (long)(AV26count+1);
               BRK7E6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A252EmpresaCNPJ)) ? "<#Empty#>" : A252EmpresaCNPJ);
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
            if ( ! BRK7E6 )
            {
               BRK7E6 = true;
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
         AV10TFEmpresaNomeFantasia = "";
         AV11TFEmpresaNomeFantasia_Sel = "";
         AV12TFEmpresaRazaoSocial = "";
         AV13TFEmpresaRazaoSocial_Sel = "";
         AV14TFEmpresaCNPJ = "";
         AV15TFEmpresaCNPJ_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39DynamicFiltersSelector1 = "";
         AV41EmpresaNomeFantasia1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45EmpresaNomeFantasia2 = "";
         AV47DynamicFiltersSelector3 = "";
         AV49EmpresaNomeFantasia3 = "";
         AV53Empresawwds_1_filterfulltext = "";
         AV54Empresawwds_2_dynamicfiltersselector1 = "";
         AV56Empresawwds_4_empresanomefantasia1 = "";
         AV58Empresawwds_6_dynamicfiltersselector2 = "";
         AV60Empresawwds_8_empresanomefantasia2 = "";
         AV62Empresawwds_10_dynamicfiltersselector3 = "";
         AV64Empresawwds_12_empresanomefantasia3 = "";
         AV65Empresawwds_13_tfempresanomefantasia = "";
         AV66Empresawwds_14_tfempresanomefantasia_sel = "";
         AV67Empresawwds_15_tfempresarazaosocial = "";
         AV68Empresawwds_16_tfempresarazaosocial_sel = "";
         AV69Empresawwds_17_tfempresacnpj = "";
         AV70Empresawwds_18_tfempresacnpj_sel = "";
         lV53Empresawwds_1_filterfulltext = "";
         lV56Empresawwds_4_empresanomefantasia1 = "";
         lV60Empresawwds_8_empresanomefantasia2 = "";
         lV64Empresawwds_12_empresanomefantasia3 = "";
         lV65Empresawwds_13_tfempresanomefantasia = "";
         lV67Empresawwds_15_tfempresarazaosocial = "";
         lV69Empresawwds_17_tfempresacnpj = "";
         A250EmpresaNomeFantasia = "";
         A251EmpresaRazaoSocial = "";
         A252EmpresaCNPJ = "";
         P007E2_A250EmpresaNomeFantasia = new string[] {""} ;
         P007E2_n250EmpresaNomeFantasia = new bool[] {false} ;
         P007E2_A253EmpresaSede = new bool[] {false} ;
         P007E2_n253EmpresaSede = new bool[] {false} ;
         P007E2_A252EmpresaCNPJ = new string[] {""} ;
         P007E2_n252EmpresaCNPJ = new bool[] {false} ;
         P007E2_A251EmpresaRazaoSocial = new string[] {""} ;
         P007E2_n251EmpresaRazaoSocial = new bool[] {false} ;
         P007E2_A249EmpresaId = new int[1] ;
         AV21Option = "";
         P007E3_A251EmpresaRazaoSocial = new string[] {""} ;
         P007E3_n251EmpresaRazaoSocial = new bool[] {false} ;
         P007E3_A253EmpresaSede = new bool[] {false} ;
         P007E3_n253EmpresaSede = new bool[] {false} ;
         P007E3_A252EmpresaCNPJ = new string[] {""} ;
         P007E3_n252EmpresaCNPJ = new bool[] {false} ;
         P007E3_A250EmpresaNomeFantasia = new string[] {""} ;
         P007E3_n250EmpresaNomeFantasia = new bool[] {false} ;
         P007E3_A249EmpresaId = new int[1] ;
         P007E4_A252EmpresaCNPJ = new string[] {""} ;
         P007E4_n252EmpresaCNPJ = new bool[] {false} ;
         P007E4_A253EmpresaSede = new bool[] {false} ;
         P007E4_n253EmpresaSede = new bool[] {false} ;
         P007E4_A251EmpresaRazaoSocial = new string[] {""} ;
         P007E4_n251EmpresaRazaoSocial = new bool[] {false} ;
         P007E4_A250EmpresaNomeFantasia = new string[] {""} ;
         P007E4_n250EmpresaNomeFantasia = new bool[] {false} ;
         P007E4_A249EmpresaId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empresawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007E2_A250EmpresaNomeFantasia, P007E2_n250EmpresaNomeFantasia, P007E2_A253EmpresaSede, P007E2_n253EmpresaSede, P007E2_A252EmpresaCNPJ, P007E2_n252EmpresaCNPJ, P007E2_A251EmpresaRazaoSocial, P007E2_n251EmpresaRazaoSocial, P007E2_A249EmpresaId
               }
               , new Object[] {
               P007E3_A251EmpresaRazaoSocial, P007E3_n251EmpresaRazaoSocial, P007E3_A253EmpresaSede, P007E3_n253EmpresaSede, P007E3_A252EmpresaCNPJ, P007E3_n252EmpresaCNPJ, P007E3_A250EmpresaNomeFantasia, P007E3_n250EmpresaNomeFantasia, P007E3_A249EmpresaId
               }
               , new Object[] {
               P007E4_A252EmpresaCNPJ, P007E4_n252EmpresaCNPJ, P007E4_A253EmpresaSede, P007E4_n253EmpresaSede, P007E4_A251EmpresaRazaoSocial, P007E4_n251EmpresaRazaoSocial, P007E4_A250EmpresaNomeFantasia, P007E4_n250EmpresaNomeFantasia, P007E4_A249EmpresaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short AV50TFEmpresaSede_Sel ;
      private short AV40DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV48DynamicFiltersOperator3 ;
      private short AV55Empresawwds_3_dynamicfiltersoperator1 ;
      private short AV59Empresawwds_7_dynamicfiltersoperator2 ;
      private short AV63Empresawwds_11_dynamicfiltersoperator3 ;
      private short AV71Empresawwds_19_tfempresasede_sel ;
      private int AV51GXV1 ;
      private int A249EmpresaId ;
      private long AV26count ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV46DynamicFiltersEnabled3 ;
      private bool AV57Empresawwds_5_dynamicfiltersenabled2 ;
      private bool AV61Empresawwds_9_dynamicfiltersenabled3 ;
      private bool A253EmpresaSede ;
      private bool BRK7E2 ;
      private bool n250EmpresaNomeFantasia ;
      private bool n253EmpresaSede ;
      private bool n252EmpresaCNPJ ;
      private bool n251EmpresaRazaoSocial ;
      private bool BRK7E4 ;
      private bool BRK7E6 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV10TFEmpresaNomeFantasia ;
      private string AV11TFEmpresaNomeFantasia_Sel ;
      private string AV12TFEmpresaRazaoSocial ;
      private string AV13TFEmpresaRazaoSocial_Sel ;
      private string AV14TFEmpresaCNPJ ;
      private string AV15TFEmpresaCNPJ_Sel ;
      private string AV39DynamicFiltersSelector1 ;
      private string AV41EmpresaNomeFantasia1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV45EmpresaNomeFantasia2 ;
      private string AV47DynamicFiltersSelector3 ;
      private string AV49EmpresaNomeFantasia3 ;
      private string AV53Empresawwds_1_filterfulltext ;
      private string AV54Empresawwds_2_dynamicfiltersselector1 ;
      private string AV56Empresawwds_4_empresanomefantasia1 ;
      private string AV58Empresawwds_6_dynamicfiltersselector2 ;
      private string AV60Empresawwds_8_empresanomefantasia2 ;
      private string AV62Empresawwds_10_dynamicfiltersselector3 ;
      private string AV64Empresawwds_12_empresanomefantasia3 ;
      private string AV65Empresawwds_13_tfempresanomefantasia ;
      private string AV66Empresawwds_14_tfempresanomefantasia_sel ;
      private string AV67Empresawwds_15_tfempresarazaosocial ;
      private string AV68Empresawwds_16_tfempresarazaosocial_sel ;
      private string AV69Empresawwds_17_tfempresacnpj ;
      private string AV70Empresawwds_18_tfempresacnpj_sel ;
      private string lV53Empresawwds_1_filterfulltext ;
      private string lV56Empresawwds_4_empresanomefantasia1 ;
      private string lV60Empresawwds_8_empresanomefantasia2 ;
      private string lV64Empresawwds_12_empresanomefantasia3 ;
      private string lV65Empresawwds_13_tfempresanomefantasia ;
      private string lV67Empresawwds_15_tfempresarazaosocial ;
      private string lV69Empresawwds_17_tfempresacnpj ;
      private string A250EmpresaNomeFantasia ;
      private string A251EmpresaRazaoSocial ;
      private string A252EmpresaCNPJ ;
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
      private string[] P007E2_A250EmpresaNomeFantasia ;
      private bool[] P007E2_n250EmpresaNomeFantasia ;
      private bool[] P007E2_A253EmpresaSede ;
      private bool[] P007E2_n253EmpresaSede ;
      private string[] P007E2_A252EmpresaCNPJ ;
      private bool[] P007E2_n252EmpresaCNPJ ;
      private string[] P007E2_A251EmpresaRazaoSocial ;
      private bool[] P007E2_n251EmpresaRazaoSocial ;
      private int[] P007E2_A249EmpresaId ;
      private string[] P007E3_A251EmpresaRazaoSocial ;
      private bool[] P007E3_n251EmpresaRazaoSocial ;
      private bool[] P007E3_A253EmpresaSede ;
      private bool[] P007E3_n253EmpresaSede ;
      private string[] P007E3_A252EmpresaCNPJ ;
      private bool[] P007E3_n252EmpresaCNPJ ;
      private string[] P007E3_A250EmpresaNomeFantasia ;
      private bool[] P007E3_n250EmpresaNomeFantasia ;
      private int[] P007E3_A249EmpresaId ;
      private string[] P007E4_A252EmpresaCNPJ ;
      private bool[] P007E4_n252EmpresaCNPJ ;
      private bool[] P007E4_A253EmpresaSede ;
      private bool[] P007E4_n253EmpresaSede ;
      private string[] P007E4_A251EmpresaRazaoSocial ;
      private bool[] P007E4_n251EmpresaRazaoSocial ;
      private string[] P007E4_A250EmpresaNomeFantasia ;
      private bool[] P007E4_n250EmpresaNomeFantasia ;
      private int[] P007E4_A249EmpresaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class empresawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007E2( IGxContext context ,
                                             string AV53Empresawwds_1_filterfulltext ,
                                             string AV54Empresawwds_2_dynamicfiltersselector1 ,
                                             short AV55Empresawwds_3_dynamicfiltersoperator1 ,
                                             string AV56Empresawwds_4_empresanomefantasia1 ,
                                             bool AV57Empresawwds_5_dynamicfiltersenabled2 ,
                                             string AV58Empresawwds_6_dynamicfiltersselector2 ,
                                             short AV59Empresawwds_7_dynamicfiltersoperator2 ,
                                             string AV60Empresawwds_8_empresanomefantasia2 ,
                                             bool AV61Empresawwds_9_dynamicfiltersenabled3 ,
                                             string AV62Empresawwds_10_dynamicfiltersselector3 ,
                                             short AV63Empresawwds_11_dynamicfiltersoperator3 ,
                                             string AV64Empresawwds_12_empresanomefantasia3 ,
                                             string AV66Empresawwds_14_tfempresanomefantasia_sel ,
                                             string AV65Empresawwds_13_tfempresanomefantasia ,
                                             string AV68Empresawwds_16_tfempresarazaosocial_sel ,
                                             string AV67Empresawwds_15_tfempresarazaosocial ,
                                             string AV70Empresawwds_18_tfempresacnpj_sel ,
                                             string AV69Empresawwds_17_tfempresacnpj ,
                                             short AV71Empresawwds_19_tfempresasede_sel ,
                                             string A250EmpresaNomeFantasia ,
                                             string A251EmpresaRazaoSocial ,
                                             string A252EmpresaCNPJ ,
                                             bool A253EmpresaSede )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT EmpresaNomeFantasia, EmpresaSede, EmpresaCNPJ, EmpresaRazaoSocial, EmpresaId FROM Empresa";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Empresawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmpresaNomeFantasia like '%' || :lV53Empresawwds_1_filterfulltext) or ( EmpresaRazaoSocial like '%' || :lV53Empresawwds_1_filterfulltext) or ( EmpresaCNPJ like '%' || :lV53Empresawwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV53Empresawwds_1_filterfulltext) and EmpresaSede = TRUE) or ( 'não' like '%' || LOWER(:lV53Empresawwds_1_filterfulltext) and EmpresaSede = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV55Empresawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV56Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV55Empresawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV56Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV57Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV60Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV57Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV60Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV61Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV64Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV61Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV64Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_14_tfempresanomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Empresawwds_13_tfempresanomefantasia)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV65Empresawwds_13_tfempresanomefantasia)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_14_tfempresanomefantasia_sel)) && ! ( StringUtil.StrCmp(AV66Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia = ( :AV66Empresawwds_14_tfempresanomefantasia_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia IS NULL or (char_length(trim(trailing ' ' from EmpresaNomeFantasia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_16_tfempresarazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Empresawwds_15_tfempresarazaosocial)) ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial like :lV67Empresawwds_15_tfempresarazaosocial)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_16_tfempresarazaosocial_sel)) && ! ( StringUtil.StrCmp(AV68Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial = ( :AV68Empresawwds_16_tfempresarazaosocial_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial IS NULL or (char_length(trim(trailing ' ' from EmpresaRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_18_tfempresacnpj_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Empresawwds_17_tfempresacnpj)) ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ like :lV69Empresawwds_17_tfempresacnpj)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_18_tfempresacnpj_sel)) && ! ( StringUtil.StrCmp(AV70Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ = ( :AV70Empresawwds_18_tfempresacnpj_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ IS NULL or (char_length(trim(trailing ' ' from EmpresaCNPJ))=0))");
         }
         if ( AV71Empresawwds_19_tfempresasede_sel == 1 )
         {
            AddWhere(sWhereString, "(EmpresaSede = TRUE)");
         }
         if ( AV71Empresawwds_19_tfempresasede_sel == 2 )
         {
            AddWhere(sWhereString, "(EmpresaSede = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmpresaNomeFantasia";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007E3( IGxContext context ,
                                             string AV53Empresawwds_1_filterfulltext ,
                                             string AV54Empresawwds_2_dynamicfiltersselector1 ,
                                             short AV55Empresawwds_3_dynamicfiltersoperator1 ,
                                             string AV56Empresawwds_4_empresanomefantasia1 ,
                                             bool AV57Empresawwds_5_dynamicfiltersenabled2 ,
                                             string AV58Empresawwds_6_dynamicfiltersselector2 ,
                                             short AV59Empresawwds_7_dynamicfiltersoperator2 ,
                                             string AV60Empresawwds_8_empresanomefantasia2 ,
                                             bool AV61Empresawwds_9_dynamicfiltersenabled3 ,
                                             string AV62Empresawwds_10_dynamicfiltersselector3 ,
                                             short AV63Empresawwds_11_dynamicfiltersoperator3 ,
                                             string AV64Empresawwds_12_empresanomefantasia3 ,
                                             string AV66Empresawwds_14_tfempresanomefantasia_sel ,
                                             string AV65Empresawwds_13_tfempresanomefantasia ,
                                             string AV68Empresawwds_16_tfempresarazaosocial_sel ,
                                             string AV67Empresawwds_15_tfempresarazaosocial ,
                                             string AV70Empresawwds_18_tfempresacnpj_sel ,
                                             string AV69Empresawwds_17_tfempresacnpj ,
                                             short AV71Empresawwds_19_tfempresasede_sel ,
                                             string A250EmpresaNomeFantasia ,
                                             string A251EmpresaRazaoSocial ,
                                             string A252EmpresaCNPJ ,
                                             bool A253EmpresaSede )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT EmpresaRazaoSocial, EmpresaSede, EmpresaCNPJ, EmpresaNomeFantasia, EmpresaId FROM Empresa";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Empresawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmpresaNomeFantasia like '%' || :lV53Empresawwds_1_filterfulltext) or ( EmpresaRazaoSocial like '%' || :lV53Empresawwds_1_filterfulltext) or ( EmpresaCNPJ like '%' || :lV53Empresawwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV53Empresawwds_1_filterfulltext) and EmpresaSede = TRUE) or ( 'não' like '%' || LOWER(:lV53Empresawwds_1_filterfulltext) and EmpresaSede = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV55Empresawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV56Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV55Empresawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV56Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV57Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV60Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV57Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV60Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV61Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV64Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV61Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV64Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_14_tfempresanomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Empresawwds_13_tfempresanomefantasia)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV65Empresawwds_13_tfempresanomefantasia)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_14_tfempresanomefantasia_sel)) && ! ( StringUtil.StrCmp(AV66Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia = ( :AV66Empresawwds_14_tfempresanomefantasia_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia IS NULL or (char_length(trim(trailing ' ' from EmpresaNomeFantasia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_16_tfempresarazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Empresawwds_15_tfempresarazaosocial)) ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial like :lV67Empresawwds_15_tfempresarazaosocial)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_16_tfempresarazaosocial_sel)) && ! ( StringUtil.StrCmp(AV68Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial = ( :AV68Empresawwds_16_tfempresarazaosocial_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial IS NULL or (char_length(trim(trailing ' ' from EmpresaRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_18_tfempresacnpj_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Empresawwds_17_tfempresacnpj)) ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ like :lV69Empresawwds_17_tfempresacnpj)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_18_tfempresacnpj_sel)) && ! ( StringUtil.StrCmp(AV70Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ = ( :AV70Empresawwds_18_tfempresacnpj_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ IS NULL or (char_length(trim(trailing ' ' from EmpresaCNPJ))=0))");
         }
         if ( AV71Empresawwds_19_tfempresasede_sel == 1 )
         {
            AddWhere(sWhereString, "(EmpresaSede = TRUE)");
         }
         if ( AV71Empresawwds_19_tfempresasede_sel == 2 )
         {
            AddWhere(sWhereString, "(EmpresaSede = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmpresaRazaoSocial";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007E4( IGxContext context ,
                                             string AV53Empresawwds_1_filterfulltext ,
                                             string AV54Empresawwds_2_dynamicfiltersselector1 ,
                                             short AV55Empresawwds_3_dynamicfiltersoperator1 ,
                                             string AV56Empresawwds_4_empresanomefantasia1 ,
                                             bool AV57Empresawwds_5_dynamicfiltersenabled2 ,
                                             string AV58Empresawwds_6_dynamicfiltersselector2 ,
                                             short AV59Empresawwds_7_dynamicfiltersoperator2 ,
                                             string AV60Empresawwds_8_empresanomefantasia2 ,
                                             bool AV61Empresawwds_9_dynamicfiltersenabled3 ,
                                             string AV62Empresawwds_10_dynamicfiltersselector3 ,
                                             short AV63Empresawwds_11_dynamicfiltersoperator3 ,
                                             string AV64Empresawwds_12_empresanomefantasia3 ,
                                             string AV66Empresawwds_14_tfempresanomefantasia_sel ,
                                             string AV65Empresawwds_13_tfempresanomefantasia ,
                                             string AV68Empresawwds_16_tfempresarazaosocial_sel ,
                                             string AV67Empresawwds_15_tfempresarazaosocial ,
                                             string AV70Empresawwds_18_tfempresacnpj_sel ,
                                             string AV69Empresawwds_17_tfempresacnpj ,
                                             short AV71Empresawwds_19_tfempresasede_sel ,
                                             string A250EmpresaNomeFantasia ,
                                             string A251EmpresaRazaoSocial ,
                                             string A252EmpresaCNPJ ,
                                             bool A253EmpresaSede )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT EmpresaCNPJ, EmpresaSede, EmpresaRazaoSocial, EmpresaNomeFantasia, EmpresaId FROM Empresa";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Empresawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmpresaNomeFantasia like '%' || :lV53Empresawwds_1_filterfulltext) or ( EmpresaRazaoSocial like '%' || :lV53Empresawwds_1_filterfulltext) or ( EmpresaCNPJ like '%' || :lV53Empresawwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV53Empresawwds_1_filterfulltext) and EmpresaSede = TRUE) or ( 'não' like '%' || LOWER(:lV53Empresawwds_1_filterfulltext) and EmpresaSede = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV55Empresawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV56Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV55Empresawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV56Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV57Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV60Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV57Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV60Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV61Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV64Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV61Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV64Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_14_tfempresanomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Empresawwds_13_tfempresanomefantasia)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV65Empresawwds_13_tfempresanomefantasia)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_14_tfempresanomefantasia_sel)) && ! ( StringUtil.StrCmp(AV66Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia = ( :AV66Empresawwds_14_tfempresanomefantasia_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia IS NULL or (char_length(trim(trailing ' ' from EmpresaNomeFantasia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_16_tfempresarazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Empresawwds_15_tfempresarazaosocial)) ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial like :lV67Empresawwds_15_tfempresarazaosocial)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_16_tfempresarazaosocial_sel)) && ! ( StringUtil.StrCmp(AV68Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial = ( :AV68Empresawwds_16_tfempresarazaosocial_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial IS NULL or (char_length(trim(trailing ' ' from EmpresaRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_18_tfempresacnpj_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Empresawwds_17_tfempresacnpj)) ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ like :lV69Empresawwds_17_tfempresacnpj)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_18_tfempresacnpj_sel)) && ! ( StringUtil.StrCmp(AV70Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ = ( :AV70Empresawwds_18_tfempresacnpj_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV70Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ IS NULL or (char_length(trim(trailing ' ' from EmpresaCNPJ))=0))");
         }
         if ( AV71Empresawwds_19_tfempresasede_sel == 1 )
         {
            AddWhere(sWhereString, "(EmpresaSede = TRUE)");
         }
         if ( AV71Empresawwds_19_tfempresasede_sel == 2 )
         {
            AddWhere(sWhereString, "(EmpresaSede = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmpresaCNPJ";
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
                     return conditional_P007E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
               case 1 :
                     return conditional_P007E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
               case 2 :
                     return conditional_P007E4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP007E2;
          prmP007E2 = new Object[] {
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV56Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV65Empresawwds_13_tfempresanomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV66Empresawwds_14_tfempresanomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV67Empresawwds_15_tfempresarazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV68Empresawwds_16_tfempresarazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Empresawwds_17_tfempresacnpj",GXType.VarChar,14,0) ,
          new ParDef("AV70Empresawwds_18_tfempresacnpj_sel",GXType.VarChar,14,0)
          };
          Object[] prmP007E3;
          prmP007E3 = new Object[] {
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV56Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV65Empresawwds_13_tfempresanomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV66Empresawwds_14_tfempresanomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV67Empresawwds_15_tfempresarazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV68Empresawwds_16_tfempresarazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Empresawwds_17_tfempresacnpj",GXType.VarChar,14,0) ,
          new ParDef("AV70Empresawwds_18_tfempresacnpj_sel",GXType.VarChar,14,0)
          };
          Object[] prmP007E4;
          prmP007E4 = new Object[] {
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV56Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV65Empresawwds_13_tfempresanomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV66Empresawwds_14_tfempresanomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV67Empresawwds_15_tfempresarazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV68Empresawwds_16_tfempresarazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Empresawwds_17_tfempresacnpj",GXType.VarChar,14,0) ,
          new ParDef("AV70Empresawwds_18_tfempresacnpj_sel",GXType.VarChar,14,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007E4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
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
