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
   public class carteiradecobrancawwgetfilterdata : GXProcedure
   {
      public carteiradecobrancawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiradecobrancawwgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_CARTEIRADECOBRANCANOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCARTEIRADECOBRANCANOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_CARTEIRADECOBRANCACONVENIO") == 0 )
         {
            /* Execute user subroutine: 'LOADCARTEIRADECOBRANCACONVENIOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("CarteiraDeCobrancaWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CarteiraDeCobrancaWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("CarteiraDeCobrancaWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME") == 0 )
            {
               AV12TFCarteiraDeCobrancaNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME_SEL") == 0 )
            {
               AV13TFCarteiraDeCobrancaNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO") == 0 )
            {
               AV14TFCarteiraDeCobrancaConvenio = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO_SEL") == 0 )
            {
               AV15TFCarteiraDeCobrancaConvenio_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCASTATUS_SEL") == 0 )
            {
               AV16TFCarteiraDeCobrancaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "CARTEIRADECOBRANCACODIGO") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42CarteiraDeCobrancaCodigo1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "CARTEIRADECOBRANCACODIGO") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV46CarteiraDeCobrancaCodigo2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "CARTEIRADECOBRANCACODIGO") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV50CarteiraDeCobrancaCodigo3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCARTEIRADECOBRANCANOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFCarteiraDeCobrancaNome = AV17SearchTxt;
         AV13TFCarteiraDeCobrancaNome_Sel = "";
         AV53Carteiradecobrancawwds_1_filterfulltext = AV39FilterFullText;
         AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV42CarteiraDeCobrancaCodigo1;
         AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV46CarteiraDeCobrancaCodigo2;
         AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV50CarteiraDeCobrancaCodigo3;
         AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV12TFCarteiraDeCobrancaNome;
         AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV13TFCarteiraDeCobrancaNome_Sel;
         AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV14TFCarteiraDeCobrancaConvenio;
         AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV15TFCarteiraDeCobrancaConvenio_Sel;
         AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV16TFCarteiraDeCobrancaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Carteiradecobrancawwds_1_filterfulltext ,
                                              AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                              AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                              AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                              AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                              AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                              AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                              AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                              AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                              AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                              AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                              AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                              AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                              AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                              AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                              AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                              AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                              A1071CarteiraDeCobrancaNome ,
                                              A1073CarteiraDeCobrancaConvenio ,
                                              A1074CarteiraDeCobrancaStatus ,
                                              A1070CarteiraDeCobrancaCodigo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome = StringUtil.Concat( StringUtil.RTrim( AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome), "%", "");
         lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = StringUtil.Concat( StringUtil.RTrim( AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio), "%", "");
         /* Using cursor P00FD2 */
         pr_default.execute(0, new Object[] {lV53Carteiradecobrancawwds_1_filterfulltext, lV53Carteiradecobrancawwds_1_filterfulltext, lV53Carteiradecobrancawwds_1_filterfulltext, lV53Carteiradecobrancawwds_1_filterfulltext, lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome, AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio, AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKFD2 = false;
            A1071CarteiraDeCobrancaNome = P00FD2_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = P00FD2_n1071CarteiraDeCobrancaNome[0];
            A1070CarteiraDeCobrancaCodigo = P00FD2_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = P00FD2_n1070CarteiraDeCobrancaCodigo[0];
            A1074CarteiraDeCobrancaStatus = P00FD2_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = P00FD2_n1074CarteiraDeCobrancaStatus[0];
            A1073CarteiraDeCobrancaConvenio = P00FD2_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = P00FD2_n1073CarteiraDeCobrancaConvenio[0];
            A1069CarteiraDeCobrancaId = P00FD2_A1069CarteiraDeCobrancaId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00FD2_A1071CarteiraDeCobrancaNome[0], A1071CarteiraDeCobrancaNome) == 0 ) )
            {
               BRKFD2 = false;
               A1069CarteiraDeCobrancaId = P00FD2_A1069CarteiraDeCobrancaId[0];
               AV27count = (long)(AV27count+1);
               BRKFD2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1071CarteiraDeCobrancaNome)) ? "<#Empty#>" : A1071CarteiraDeCobrancaNome);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKFD2 )
            {
               BRKFD2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCARTEIRADECOBRANCACONVENIOOPTIONS' Routine */
         returnInSub = false;
         AV14TFCarteiraDeCobrancaConvenio = AV17SearchTxt;
         AV15TFCarteiraDeCobrancaConvenio_Sel = "";
         AV53Carteiradecobrancawwds_1_filterfulltext = AV39FilterFullText;
         AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV42CarteiraDeCobrancaCodigo1;
         AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV46CarteiraDeCobrancaCodigo2;
         AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV50CarteiraDeCobrancaCodigo3;
         AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV12TFCarteiraDeCobrancaNome;
         AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV13TFCarteiraDeCobrancaNome_Sel;
         AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV14TFCarteiraDeCobrancaConvenio;
         AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV15TFCarteiraDeCobrancaConvenio_Sel;
         AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV16TFCarteiraDeCobrancaStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Carteiradecobrancawwds_1_filterfulltext ,
                                              AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                              AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                              AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                              AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                              AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                              AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                              AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                              AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                              AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                              AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                              AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                              AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                              AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                              AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                              AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                              AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                              A1071CarteiraDeCobrancaNome ,
                                              A1073CarteiraDeCobrancaConvenio ,
                                              A1074CarteiraDeCobrancaStatus ,
                                              A1070CarteiraDeCobrancaCodigo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV53Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome = StringUtil.Concat( StringUtil.RTrim( AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome), "%", "");
         lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = StringUtil.Concat( StringUtil.RTrim( AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio), "%", "");
         /* Using cursor P00FD3 */
         pr_default.execute(1, new Object[] {lV53Carteiradecobrancawwds_1_filterfulltext, lV53Carteiradecobrancawwds_1_filterfulltext, lV53Carteiradecobrancawwds_1_filterfulltext, lV53Carteiradecobrancawwds_1_filterfulltext, lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome, AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio, AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKFD4 = false;
            A1073CarteiraDeCobrancaConvenio = P00FD3_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = P00FD3_n1073CarteiraDeCobrancaConvenio[0];
            A1070CarteiraDeCobrancaCodigo = P00FD3_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = P00FD3_n1070CarteiraDeCobrancaCodigo[0];
            A1074CarteiraDeCobrancaStatus = P00FD3_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = P00FD3_n1074CarteiraDeCobrancaStatus[0];
            A1071CarteiraDeCobrancaNome = P00FD3_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = P00FD3_n1071CarteiraDeCobrancaNome[0];
            A1069CarteiraDeCobrancaId = P00FD3_A1069CarteiraDeCobrancaId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00FD3_A1073CarteiraDeCobrancaConvenio[0], A1073CarteiraDeCobrancaConvenio) == 0 ) )
            {
               BRKFD4 = false;
               A1069CarteiraDeCobrancaId = P00FD3_A1069CarteiraDeCobrancaId[0];
               AV27count = (long)(AV27count+1);
               BRKFD4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1073CarteiraDeCobrancaConvenio)) ? "<#Empty#>" : A1073CarteiraDeCobrancaConvenio);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRKFD4 )
            {
               BRKFD4 = true;
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV12TFCarteiraDeCobrancaNome = "";
         AV13TFCarteiraDeCobrancaNome_Sel = "";
         AV14TFCarteiraDeCobrancaConvenio = "";
         AV15TFCarteiraDeCobrancaConvenio_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42CarteiraDeCobrancaCodigo1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46CarteiraDeCobrancaCodigo2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50CarteiraDeCobrancaCodigo3 = "";
         AV53Carteiradecobrancawwds_1_filterfulltext = "";
         AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 = "";
         AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 = "";
         AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 = "";
         AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = "";
         AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = "";
         lV53Carteiradecobrancawwds_1_filterfulltext = "";
         lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         A1071CarteiraDeCobrancaNome = "";
         A1073CarteiraDeCobrancaConvenio = "";
         A1070CarteiraDeCobrancaCodigo = "";
         P00FD2_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         P00FD2_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         P00FD2_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FD2_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         P00FD2_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FD2_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FD2_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         P00FD2_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         P00FD2_A1069CarteiraDeCobrancaId = new int[1] ;
         AV22Option = "";
         P00FD3_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         P00FD3_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         P00FD3_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FD3_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         P00FD3_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FD3_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FD3_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         P00FD3_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         P00FD3_A1069CarteiraDeCobrancaId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carteiradecobrancawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00FD2_A1071CarteiraDeCobrancaNome, P00FD2_n1071CarteiraDeCobrancaNome, P00FD2_A1070CarteiraDeCobrancaCodigo, P00FD2_n1070CarteiraDeCobrancaCodigo, P00FD2_A1074CarteiraDeCobrancaStatus, P00FD2_n1074CarteiraDeCobrancaStatus, P00FD2_A1073CarteiraDeCobrancaConvenio, P00FD2_n1073CarteiraDeCobrancaConvenio, P00FD2_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               P00FD3_A1073CarteiraDeCobrancaConvenio, P00FD3_n1073CarteiraDeCobrancaConvenio, P00FD3_A1070CarteiraDeCobrancaCodigo, P00FD3_n1070CarteiraDeCobrancaCodigo, P00FD3_A1074CarteiraDeCobrancaStatus, P00FD3_n1074CarteiraDeCobrancaStatus, P00FD3_A1071CarteiraDeCobrancaNome, P00FD3_n1071CarteiraDeCobrancaNome, P00FD3_A1069CarteiraDeCobrancaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV16TFCarteiraDeCobrancaStatus_Sel ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 ;
      private short AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 ;
      private short AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 ;
      private short AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ;
      private int AV51GXV1 ;
      private int A1069CarteiraDeCobrancaId ;
      private long AV27count ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 ;
      private bool AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool BRKFD2 ;
      private bool n1071CarteiraDeCobrancaNome ;
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool BRKFD4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV12TFCarteiraDeCobrancaNome ;
      private string AV13TFCarteiraDeCobrancaNome_Sel ;
      private string AV14TFCarteiraDeCobrancaConvenio ;
      private string AV15TFCarteiraDeCobrancaConvenio_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV42CarteiraDeCobrancaCodigo1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV46CarteiraDeCobrancaCodigo2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV50CarteiraDeCobrancaCodigo3 ;
      private string AV53Carteiradecobrancawwds_1_filterfulltext ;
      private string AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 ;
      private string AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 ;
      private string AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 ;
      private string AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ;
      private string AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ;
      private string lV53Carteiradecobrancawwds_1_filterfulltext ;
      private string lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string A1071CarteiraDeCobrancaNome ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00FD2_A1071CarteiraDeCobrancaNome ;
      private bool[] P00FD2_n1071CarteiraDeCobrancaNome ;
      private string[] P00FD2_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FD2_n1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FD2_A1074CarteiraDeCobrancaStatus ;
      private bool[] P00FD2_n1074CarteiraDeCobrancaStatus ;
      private string[] P00FD2_A1073CarteiraDeCobrancaConvenio ;
      private bool[] P00FD2_n1073CarteiraDeCobrancaConvenio ;
      private int[] P00FD2_A1069CarteiraDeCobrancaId ;
      private string[] P00FD3_A1073CarteiraDeCobrancaConvenio ;
      private bool[] P00FD3_n1073CarteiraDeCobrancaConvenio ;
      private string[] P00FD3_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FD3_n1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FD3_A1074CarteiraDeCobrancaStatus ;
      private bool[] P00FD3_n1074CarteiraDeCobrancaStatus ;
      private string[] P00FD3_A1071CarteiraDeCobrancaNome ;
      private bool[] P00FD3_n1071CarteiraDeCobrancaNome ;
      private int[] P00FD3_A1069CarteiraDeCobrancaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class carteiradecobrancawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FD2( IGxContext context ,
                                             string AV53Carteiradecobrancawwds_1_filterfulltext ,
                                             string AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                             short AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                             string AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                             bool AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                             string AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                             short AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                             string AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                             bool AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                             string AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                             short AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                             string AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                             string AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                             string AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                             string AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                             string AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                             short AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                             string A1071CarteiraDeCobrancaNome ,
                                             string A1073CarteiraDeCobrancaConvenio ,
                                             bool A1074CarteiraDeCobrancaStatus ,
                                             string A1070CarteiraDeCobrancaCodigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaNome, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaStatus, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaId FROM CarteiraDeCobranca";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CarteiraDeCobrancaNome like '%' || :lV53Carteiradecobrancawwds_1_filterfulltext) or ( CarteiraDeCobrancaConvenio like '%' || :lV53Carteiradecobrancawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome like :lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ! ( StringUtil.StrCmp(AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome = ( :AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio like :lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ! ( StringUtil.StrCmp(AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio = ( :AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaConvenio))=0))");
         }
         if ( AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = TRUE)");
         }
         if ( AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00FD3( IGxContext context ,
                                             string AV53Carteiradecobrancawwds_1_filterfulltext ,
                                             string AV54Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                             short AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                             string AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                             bool AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                             string AV58Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                             short AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                             string AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                             bool AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                             string AV62Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                             short AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                             string AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                             string AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                             string AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                             string AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                             string AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                             short AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                             string A1071CarteiraDeCobrancaNome ,
                                             string A1073CarteiraDeCobrancaConvenio ,
                                             bool A1074CarteiraDeCobrancaStatus ,
                                             string A1070CarteiraDeCobrancaCodigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaConvenio, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaStatus, CarteiraDeCobrancaNome, CarteiraDeCobrancaId FROM CarteiraDeCobranca";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Carteiradecobrancawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CarteiraDeCobrancaNome like '%' || :lV53Carteiradecobrancawwds_1_filterfulltext) or ( CarteiraDeCobrancaConvenio like '%' || :lV53Carteiradecobrancawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV55Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV57Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV59Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV61Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV63Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome like :lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ! ( StringUtil.StrCmp(AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome = ( :AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio like :lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ! ( StringUtil.StrCmp(AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio = ( :AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaConvenio))=0))");
         }
         if ( AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = TRUE)");
         }
         if ( AV69Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CarteiraDeCobrancaConvenio";
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
                     return conditional_P00FD2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] );
               case 1 :
                     return conditional_P00FD3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP00FD2;
          prmP00FD2 = new Object[] {
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome",GXType.VarChar,100,0) ,
          new ParDef("AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio",GXType.VarChar,20,0) ,
          new ParDef("AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00FD3;
          prmP00FD3 = new Object[] {
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV56Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV60Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV65Carteiradecobrancawwds_13_tfcarteiradecobrancanome",GXType.VarChar,100,0) ,
          new ParDef("AV66Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio",GXType.VarChar,20,0) ,
          new ParDef("AV68Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FD3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FD3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
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
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
