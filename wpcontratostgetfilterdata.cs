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
   public class wpcontratostgetfilterdata : GXProcedure
   {
      public wpcontratostgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpcontratostgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_CONTRATONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTRATONOMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("WpContratosTGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpContratosTGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WpContratosTGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV10TFContratoNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV11TFContratoNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCONTRATOSITUACAO_SEL") == 0 )
            {
               AV55TFContratoSituacao_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV56TFContratoSituacao_Sels.FromJSonString(AV55TFContratoSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCONTRATOCOUNTASSINANTES_F") == 0 )
            {
               AV57TFContratoCountAssinantes_F = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV58TFContratoCountAssinantes_F_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV54ClienteId = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42ContratoNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV43ContratoClienteDocumento1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV47ContratoNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV48ContratoClienteDocumento2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV52ContratoNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV53ContratoClienteDocumento3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONTRATONOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFContratoNome = AV17SearchTxt;
         AV11TFContratoNome_Sel = "";
         AV61Wpcontratostds_1_filterfulltext = AV39FilterFullText;
         AV62Wpcontratostds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV63Wpcontratostds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV64Wpcontratostds_4_contratonome1 = AV42ContratoNome1;
         AV65Wpcontratostds_5_contratoclientedocumento1 = AV43ContratoClienteDocumento1;
         AV66Wpcontratostds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV67Wpcontratostds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV68Wpcontratostds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV69Wpcontratostds_9_contratonome2 = AV47ContratoNome2;
         AV70Wpcontratostds_10_contratoclientedocumento2 = AV48ContratoClienteDocumento2;
         AV71Wpcontratostds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV72Wpcontratostds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV73Wpcontratostds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV74Wpcontratostds_14_contratonome3 = AV52ContratoNome3;
         AV75Wpcontratostds_15_contratoclientedocumento3 = AV53ContratoClienteDocumento3;
         AV76Wpcontratostds_16_tfcontratonome = AV10TFContratoNome;
         AV77Wpcontratostds_17_tfcontratonome_sel = AV11TFContratoNome_Sel;
         AV78Wpcontratostds_18_tfcontratosituacao_sels = AV56TFContratoSituacao_Sels;
         AV79Wpcontratostds_19_tfcontratocountassinantes_f = AV57TFContratoCountAssinantes_F;
         AV80Wpcontratostds_20_tfcontratocountassinantes_f_to = AV58TFContratoCountAssinantes_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A471ContratoSituacao ,
                                              AV78Wpcontratostds_18_tfcontratosituacao_sels ,
                                              AV62Wpcontratostds_2_dynamicfiltersselector1 ,
                                              AV63Wpcontratostds_3_dynamicfiltersoperator1 ,
                                              AV64Wpcontratostds_4_contratonome1 ,
                                              AV65Wpcontratostds_5_contratoclientedocumento1 ,
                                              AV66Wpcontratostds_6_dynamicfiltersenabled2 ,
                                              AV67Wpcontratostds_7_dynamicfiltersselector2 ,
                                              AV68Wpcontratostds_8_dynamicfiltersoperator2 ,
                                              AV69Wpcontratostds_9_contratonome2 ,
                                              AV70Wpcontratostds_10_contratoclientedocumento2 ,
                                              AV71Wpcontratostds_11_dynamicfiltersenabled3 ,
                                              AV72Wpcontratostds_12_dynamicfiltersselector3 ,
                                              AV73Wpcontratostds_13_dynamicfiltersoperator3 ,
                                              AV74Wpcontratostds_14_contratonome3 ,
                                              AV75Wpcontratostds_15_contratoclientedocumento3 ,
                                              AV77Wpcontratostds_17_tfcontratonome_sel ,
                                              AV76Wpcontratostds_16_tfcontratonome ,
                                              AV78Wpcontratostds_18_tfcontratosituacao_sels.Count ,
                                              A228ContratoNome ,
                                              A475ContratoClienteDocumento ,
                                              AV61Wpcontratostds_1_filterfulltext ,
                                              A1007ContratoCountAssinantes_F ,
                                              AV79Wpcontratostds_19_tfcontratocountassinantes_f ,
                                              AV80Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                              A473ContratoClienteId ,
                                              AV54ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV61Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpcontratostds_1_filterfulltext), "%", "");
         lV61Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpcontratostds_1_filterfulltext), "%", "");
         lV61Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpcontratostds_1_filterfulltext), "%", "");
         lV61Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpcontratostds_1_filterfulltext), "%", "");
         lV61Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpcontratostds_1_filterfulltext), "%", "");
         lV64Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV64Wpcontratostds_4_contratonome1), "%", "");
         lV64Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV64Wpcontratostds_4_contratonome1), "%", "");
         lV65Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_5_contratoclientedocumento1), "%", "");
         lV65Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_5_contratoclientedocumento1), "%", "");
         lV69Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_9_contratonome2), "%", "");
         lV69Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_9_contratonome2), "%", "");
         lV70Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV70Wpcontratostds_10_contratoclientedocumento2), "%", "");
         lV70Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV70Wpcontratostds_10_contratoclientedocumento2), "%", "");
         lV74Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV74Wpcontratostds_14_contratonome3), "%", "");
         lV74Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV74Wpcontratostds_14_contratonome3), "%", "");
         lV75Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV75Wpcontratostds_15_contratoclientedocumento3), "%", "");
         lV75Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV75Wpcontratostds_15_contratoclientedocumento3), "%", "");
         lV76Wpcontratostds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV76Wpcontratostds_16_tfcontratonome), "%", "");
         /* Using cursor P00F23 */
         pr_default.execute(0, new Object[] {AV61Wpcontratostds_1_filterfulltext, lV61Wpcontratostds_1_filterfulltext, lV61Wpcontratostds_1_filterfulltext, lV61Wpcontratostds_1_filterfulltext, lV61Wpcontratostds_1_filterfulltext, lV61Wpcontratostds_1_filterfulltext, AV79Wpcontratostds_19_tfcontratocountassinantes_f, AV79Wpcontratostds_19_tfcontratocountassinantes_f, AV80Wpcontratostds_20_tfcontratocountassinantes_f_to, AV80Wpcontratostds_20_tfcontratocountassinantes_f_to, AV54ClienteId, lV64Wpcontratostds_4_contratonome1, lV64Wpcontratostds_4_contratonome1, lV65Wpcontratostds_5_contratoclientedocumento1, lV65Wpcontratostds_5_contratoclientedocumento1, lV69Wpcontratostds_9_contratonome2, lV69Wpcontratostds_9_contratonome2, lV70Wpcontratostds_10_contratoclientedocumento2, lV70Wpcontratostds_10_contratoclientedocumento2, lV74Wpcontratostds_14_contratonome3, lV74Wpcontratostds_14_contratonome3, lV75Wpcontratostds_15_contratoclientedocumento3, lV75Wpcontratostds_15_contratoclientedocumento3, lV76Wpcontratostds_16_tfcontratonome, AV77Wpcontratostds_17_tfcontratonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKF22 = false;
            A227ContratoId = P00F23_A227ContratoId[0];
            n227ContratoId = P00F23_n227ContratoId[0];
            A473ContratoClienteId = P00F23_A473ContratoClienteId[0];
            n473ContratoClienteId = P00F23_n473ContratoClienteId[0];
            A228ContratoNome = P00F23_A228ContratoNome[0];
            n228ContratoNome = P00F23_n228ContratoNome[0];
            A475ContratoClienteDocumento = P00F23_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00F23_n475ContratoClienteDocumento[0];
            A471ContratoSituacao = P00F23_A471ContratoSituacao[0];
            n471ContratoSituacao = P00F23_n471ContratoSituacao[0];
            A1007ContratoCountAssinantes_F = P00F23_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = P00F23_n1007ContratoCountAssinantes_F[0];
            A475ContratoClienteDocumento = P00F23_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00F23_n475ContratoClienteDocumento[0];
            A1007ContratoCountAssinantes_F = P00F23_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = P00F23_n1007ContratoCountAssinantes_F[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00F23_A228ContratoNome[0], A228ContratoNome) == 0 ) )
            {
               BRKF22 = false;
               A227ContratoId = P00F23_A227ContratoId[0];
               n227ContratoId = P00F23_n227ContratoId[0];
               AV27count = (long)(AV27count+1);
               BRKF22 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? "<#Empty#>" : A228ContratoNome);
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
            if ( ! BRKF22 )
            {
               BRKF22 = true;
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
         AV10TFContratoNome = "";
         AV11TFContratoNome_Sel = "";
         AV55TFContratoSituacao_SelsJson = "";
         AV56TFContratoSituacao_Sels = new GxSimpleCollection<string>();
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42ContratoNome1 = "";
         AV43ContratoClienteDocumento1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47ContratoNome2 = "";
         AV48ContratoClienteDocumento2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52ContratoNome3 = "";
         AV53ContratoClienteDocumento3 = "";
         AV61Wpcontratostds_1_filterfulltext = "";
         AV62Wpcontratostds_2_dynamicfiltersselector1 = "";
         AV64Wpcontratostds_4_contratonome1 = "";
         AV65Wpcontratostds_5_contratoclientedocumento1 = "";
         AV67Wpcontratostds_7_dynamicfiltersselector2 = "";
         AV69Wpcontratostds_9_contratonome2 = "";
         AV70Wpcontratostds_10_contratoclientedocumento2 = "";
         AV72Wpcontratostds_12_dynamicfiltersselector3 = "";
         AV74Wpcontratostds_14_contratonome3 = "";
         AV75Wpcontratostds_15_contratoclientedocumento3 = "";
         AV76Wpcontratostds_16_tfcontratonome = "";
         AV77Wpcontratostds_17_tfcontratonome_sel = "";
         AV78Wpcontratostds_18_tfcontratosituacao_sels = new GxSimpleCollection<string>();
         lV61Wpcontratostds_1_filterfulltext = "";
         lV64Wpcontratostds_4_contratonome1 = "";
         lV65Wpcontratostds_5_contratoclientedocumento1 = "";
         lV69Wpcontratostds_9_contratonome2 = "";
         lV70Wpcontratostds_10_contratoclientedocumento2 = "";
         lV74Wpcontratostds_14_contratonome3 = "";
         lV75Wpcontratostds_15_contratoclientedocumento3 = "";
         lV76Wpcontratostds_16_tfcontratonome = "";
         A471ContratoSituacao = "";
         A228ContratoNome = "";
         A475ContratoClienteDocumento = "";
         P00F23_A227ContratoId = new int[1] ;
         P00F23_n227ContratoId = new bool[] {false} ;
         P00F23_A473ContratoClienteId = new int[1] ;
         P00F23_n473ContratoClienteId = new bool[] {false} ;
         P00F23_A228ContratoNome = new string[] {""} ;
         P00F23_n228ContratoNome = new bool[] {false} ;
         P00F23_A475ContratoClienteDocumento = new string[] {""} ;
         P00F23_n475ContratoClienteDocumento = new bool[] {false} ;
         P00F23_A471ContratoSituacao = new string[] {""} ;
         P00F23_n471ContratoSituacao = new bool[] {false} ;
         P00F23_A1007ContratoCountAssinantes_F = new short[1] ;
         P00F23_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcontratostgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00F23_A227ContratoId, P00F23_A473ContratoClienteId, P00F23_n473ContratoClienteId, P00F23_A228ContratoNome, P00F23_n228ContratoNome, P00F23_A475ContratoClienteDocumento, P00F23_n475ContratoClienteDocumento, P00F23_A471ContratoSituacao, P00F23_n471ContratoSituacao, P00F23_A1007ContratoCountAssinantes_F,
               P00F23_n1007ContratoCountAssinantes_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV57TFContratoCountAssinantes_F ;
      private short AV58TFContratoCountAssinantes_F_To ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV63Wpcontratostds_3_dynamicfiltersoperator1 ;
      private short AV68Wpcontratostds_8_dynamicfiltersoperator2 ;
      private short AV73Wpcontratostds_13_dynamicfiltersoperator3 ;
      private short AV79Wpcontratostds_19_tfcontratocountassinantes_f ;
      private short AV80Wpcontratostds_20_tfcontratocountassinantes_f_to ;
      private short A1007ContratoCountAssinantes_F ;
      private int AV59GXV1 ;
      private int AV54ClienteId ;
      private int AV78Wpcontratostds_18_tfcontratosituacao_sels_Count ;
      private int A473ContratoClienteId ;
      private int A227ContratoId ;
      private long AV27count ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV66Wpcontratostds_6_dynamicfiltersenabled2 ;
      private bool AV71Wpcontratostds_11_dynamicfiltersenabled3 ;
      private bool BRKF22 ;
      private bool n227ContratoId ;
      private bool n473ContratoClienteId ;
      private bool n228ContratoNome ;
      private bool n475ContratoClienteDocumento ;
      private bool n471ContratoSituacao ;
      private bool n1007ContratoCountAssinantes_F ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV55TFContratoSituacao_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV10TFContratoNome ;
      private string AV11TFContratoNome_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV42ContratoNome1 ;
      private string AV43ContratoClienteDocumento1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47ContratoNome2 ;
      private string AV48ContratoClienteDocumento2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV52ContratoNome3 ;
      private string AV53ContratoClienteDocumento3 ;
      private string AV61Wpcontratostds_1_filterfulltext ;
      private string AV62Wpcontratostds_2_dynamicfiltersselector1 ;
      private string AV64Wpcontratostds_4_contratonome1 ;
      private string AV65Wpcontratostds_5_contratoclientedocumento1 ;
      private string AV67Wpcontratostds_7_dynamicfiltersselector2 ;
      private string AV69Wpcontratostds_9_contratonome2 ;
      private string AV70Wpcontratostds_10_contratoclientedocumento2 ;
      private string AV72Wpcontratostds_12_dynamicfiltersselector3 ;
      private string AV74Wpcontratostds_14_contratonome3 ;
      private string AV75Wpcontratostds_15_contratoclientedocumento3 ;
      private string AV76Wpcontratostds_16_tfcontratonome ;
      private string AV77Wpcontratostds_17_tfcontratonome_sel ;
      private string lV61Wpcontratostds_1_filterfulltext ;
      private string lV64Wpcontratostds_4_contratonome1 ;
      private string lV65Wpcontratostds_5_contratoclientedocumento1 ;
      private string lV69Wpcontratostds_9_contratonome2 ;
      private string lV70Wpcontratostds_10_contratoclientedocumento2 ;
      private string lV74Wpcontratostds_14_contratonome3 ;
      private string lV75Wpcontratostds_15_contratoclientedocumento3 ;
      private string lV76Wpcontratostds_16_tfcontratonome ;
      private string A471ContratoSituacao ;
      private string A228ContratoNome ;
      private string A475ContratoClienteDocumento ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GxSimpleCollection<string> AV56TFContratoSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV78Wpcontratostds_18_tfcontratosituacao_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00F23_A227ContratoId ;
      private bool[] P00F23_n227ContratoId ;
      private int[] P00F23_A473ContratoClienteId ;
      private bool[] P00F23_n473ContratoClienteId ;
      private string[] P00F23_A228ContratoNome ;
      private bool[] P00F23_n228ContratoNome ;
      private string[] P00F23_A475ContratoClienteDocumento ;
      private bool[] P00F23_n475ContratoClienteDocumento ;
      private string[] P00F23_A471ContratoSituacao ;
      private bool[] P00F23_n471ContratoSituacao ;
      private short[] P00F23_A1007ContratoCountAssinantes_F ;
      private bool[] P00F23_n1007ContratoCountAssinantes_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpcontratostgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F23( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV78Wpcontratostds_18_tfcontratosituacao_sels ,
                                             string AV62Wpcontratostds_2_dynamicfiltersselector1 ,
                                             short AV63Wpcontratostds_3_dynamicfiltersoperator1 ,
                                             string AV64Wpcontratostds_4_contratonome1 ,
                                             string AV65Wpcontratostds_5_contratoclientedocumento1 ,
                                             bool AV66Wpcontratostds_6_dynamicfiltersenabled2 ,
                                             string AV67Wpcontratostds_7_dynamicfiltersselector2 ,
                                             short AV68Wpcontratostds_8_dynamicfiltersoperator2 ,
                                             string AV69Wpcontratostds_9_contratonome2 ,
                                             string AV70Wpcontratostds_10_contratoclientedocumento2 ,
                                             bool AV71Wpcontratostds_11_dynamicfiltersenabled3 ,
                                             string AV72Wpcontratostds_12_dynamicfiltersselector3 ,
                                             short AV73Wpcontratostds_13_dynamicfiltersoperator3 ,
                                             string AV74Wpcontratostds_14_contratonome3 ,
                                             string AV75Wpcontratostds_15_contratoclientedocumento3 ,
                                             string AV77Wpcontratostds_17_tfcontratonome_sel ,
                                             string AV76Wpcontratostds_16_tfcontratonome ,
                                             int AV78Wpcontratostds_18_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             string AV61Wpcontratostds_1_filterfulltext ,
                                             short A1007ContratoCountAssinantes_F ,
                                             short AV79Wpcontratostds_19_tfcontratocountassinantes_f ,
                                             short AV80Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                             int A473ContratoClienteId ,
                                             int AV54ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[25];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ContratoClienteId AS ContratoClienteId, T1.ContratoNome, T2.ClienteDocumento AS ContratoClienteDocumento, T1.ContratoSituacao, COALESCE( T3.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM ((Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T5.ContratoId, T4.ClienteId FROM (AssinaturaParticipante T4 LEFT JOIN Assinatura T5 ON T5.AssinaturaId = T4.AssinaturaId) WHERE T1.ContratoId = T5.ContratoId and T1.ContratoClienteId = T4.ClienteId GROUP BY T5.ContratoId, T4.ClienteId ) T3 ON T3.ContratoId = T1.ContratoId AND T3.ClienteId = T1.ContratoClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV61Wpcontratostds_1_filterfulltext))=0) or ( ( T1.ContratoNome like '%' || :lV61Wpcontratostds_1_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV61Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV61Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV61Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')) or ( SUBSTR(TO_CHAR(COALESCE( T3.ContratoCountAssinantes_F, 0),'9999'), 2) like '%' || :lV61Wpcontratostds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV79Wpcontratostds_19_tfcontratocountassinantes_f = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) >= :AV79Wpcontratostds_19_tfcontratocountassinantes_f))");
         AddWhere(sWhereString, "((:AV80Wpcontratostds_20_tfcontratocountassinantes_f_to = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) <= :AV80Wpcontratostds_20_tfcontratocountassinantes_f_to))");
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV54ClienteId)");
         if ( ( StringUtil.StrCmp(AV62Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV63Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV64Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV63Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV64Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV63Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV65Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV63Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV65Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV66Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV68Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV69Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV66Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV68Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV69Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV66Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV68Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV70Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV66Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV68Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV70Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV71Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV73Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV74Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV71Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV73Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV74Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV71Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV73Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV75Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV71Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV73Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV75Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpcontratostds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpcontratostds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV76Wpcontratostds_16_tfcontratonome)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpcontratostds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV77Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV77Wpcontratostds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV78Wpcontratostds_18_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Wpcontratostds_18_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoNome";
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
                     return conditional_P00F23(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] );
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
          Object[] prmP00F23;
          prmP00F23 = new Object[] {
          new ParDef("AV61Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV79Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV79Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV80Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV80Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV54ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV64Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV64Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV65Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV65Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV69Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV69Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV70Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV70Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV74Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV74Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV75Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV75Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV76Wpcontratostds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV77Wpcontratostds_17_tfcontratonome_sel",GXType.VarChar,125,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F23,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
