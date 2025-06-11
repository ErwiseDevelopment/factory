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
   public class reembolsoassinaturaswwgetfilterdata : GXProcedure
   {
      public reembolsoassinaturaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoassinaturaswwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_REEMBOLSOASSINATURASNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADREEMBOLSOASSINATURASNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("ReembolsoAssinaturasWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ReembolsoAssinaturasWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("ReembolsoAssinaturasWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASNOME") == 0 )
            {
               AV10TFReembolsoAssinaturasNome = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASNOME_SEL") == 0 )
            {
               AV11TFReembolsoAssinaturasNome_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASEMISSAO") == 0 )
            {
               AV12TFReembolsoAssinaturasEmissao = context.localUtil.CToT( AV28GridStateFilterValue.gxTpr_Value, 4);
               AV13TFReembolsoAssinaturasEmissao_To = context.localUtil.CToT( AV28GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROPOSTAASSINATURASTATUS_SEL") == 0 )
            {
               AV50TFPropostaAssinaturaStatus_SelsJson = AV28GridStateFilterValue.gxTpr_Value;
               AV51TFPropostaAssinaturaStatus_Sels.FromJSonString(AV50TFPropostaAssinaturaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV48PropostaId = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PARM_&REEMBOLSOID") == 0 )
            {
               AV49ReembolsoId = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "REEMBOLSOASSINATURASNOME") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV39ReembolsoAssinaturasNome1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV40DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV41DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV41DynamicFiltersSelector2, "REEMBOLSOASSINATURASNOME") == 0 )
               {
                  AV42DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV43ReembolsoAssinaturasNome2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV44DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV45DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "REEMBOLSOASSINATURASNOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV47ReembolsoAssinaturasNome3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADREEMBOLSOASSINATURASNOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFReembolsoAssinaturasNome = AV14SearchTxt;
         AV11TFReembolsoAssinaturasNome_Sel = "";
         AV54Reembolsoassinaturaswwds_1_reembolsoid = AV49ReembolsoId;
         AV55Reembolsoassinaturaswwds_2_filterfulltext = AV36FilterFullText;
         AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV57Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV39ReembolsoAssinaturasNome1;
         AV59Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV40DynamicFiltersEnabled2;
         AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV41DynamicFiltersSelector2;
         AV61Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV42DynamicFiltersOperator2;
         AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV43ReembolsoAssinaturasNome2;
         AV63Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV65Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV46DynamicFiltersOperator3;
         AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV47ReembolsoAssinaturasNome3;
         AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV10TFReembolsoAssinaturasNome;
         AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV11TFReembolsoAssinaturasNome_Sel;
         AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV12TFReembolsoAssinaturasEmissao;
         AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV13TFReembolsoAssinaturasEmissao_To;
         AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV51TFPropostaAssinaturaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A574PropostaAssinaturaStatus ,
                                              AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                              AV55Reembolsoassinaturaswwds_2_filterfulltext ,
                                              AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                              AV57Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                              AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                              AV59Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                              AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                              AV61Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                              AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                              AV63Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                              AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                              AV65Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                              AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                              AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                              AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                              AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                              AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                              AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels.Count ,
                                              A632ReembolsoAssinaturasNome ,
                                              A633ReembolsoAssinaturasEmissao ,
                                              AV54Reembolsoassinaturaswwds_1_reembolsoid ,
                                              A518ReembolsoId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV55Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV55Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV55Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV55Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV55Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
         lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
         lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
         lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
         lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
         lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
         lV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = StringUtil.Concat( StringUtil.RTrim( AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome), "%", "");
         /* Using cursor P00CB2 */
         pr_default.execute(0, new Object[] {AV54Reembolsoassinaturaswwds_1_reembolsoid, lV55Reembolsoassinaturaswwds_2_filterfulltext, lV55Reembolsoassinaturaswwds_2_filterfulltext, lV55Reembolsoassinaturaswwds_2_filterfulltext, lV55Reembolsoassinaturaswwds_2_filterfulltext, lV55Reembolsoassinaturaswwds_2_filterfulltext, lV55Reembolsoassinaturaswwds_2_filterfulltext, lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome, AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao, AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCB2 = false;
            A572PropostaContratoAssinaturaId = P00CB2_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = P00CB2_n572PropostaContratoAssinaturaId[0];
            A571PropostaAssinatura = P00CB2_A571PropostaAssinatura[0];
            n571PropostaAssinatura = P00CB2_n571PropostaAssinatura[0];
            A518ReembolsoId = P00CB2_A518ReembolsoId[0];
            n518ReembolsoId = P00CB2_n518ReembolsoId[0];
            A632ReembolsoAssinaturasNome = P00CB2_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = P00CB2_n632ReembolsoAssinaturasNome[0];
            A633ReembolsoAssinaturasEmissao = P00CB2_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = P00CB2_n633ReembolsoAssinaturasEmissao[0];
            A574PropostaAssinaturaStatus = P00CB2_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = P00CB2_n574PropostaAssinaturaStatus[0];
            A631ReembolsoAssinaturasId = P00CB2_A631ReembolsoAssinaturasId[0];
            A571PropostaAssinatura = P00CB2_A571PropostaAssinatura[0];
            n571PropostaAssinatura = P00CB2_n571PropostaAssinatura[0];
            A574PropostaAssinaturaStatus = P00CB2_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = P00CB2_n574PropostaAssinaturaStatus[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00CB2_A518ReembolsoId[0] == A518ReembolsoId ) && ( StringUtil.StrCmp(P00CB2_A632ReembolsoAssinaturasNome[0], A632ReembolsoAssinaturasNome) == 0 ) )
            {
               BRKCB2 = false;
               A631ReembolsoAssinaturasId = P00CB2_A631ReembolsoAssinaturasId[0];
               AV24count = (long)(AV24count+1);
               BRKCB2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A632ReembolsoAssinaturasNome)) ? "<#Empty#>" : A632ReembolsoAssinaturasNome);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRKCB2 )
            {
               BRKCB2 = true;
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV10TFReembolsoAssinaturasNome = "";
         AV11TFReembolsoAssinaturasNome_Sel = "";
         AV12TFReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         AV13TFReembolsoAssinaturasEmissao_To = (DateTime)(DateTime.MinValue);
         AV50TFPropostaAssinaturaStatus_SelsJson = "";
         AV51TFPropostaAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV39ReembolsoAssinaturasNome1 = "";
         AV41DynamicFiltersSelector2 = "";
         AV43ReembolsoAssinaturasNome2 = "";
         AV45DynamicFiltersSelector3 = "";
         AV47ReembolsoAssinaturasNome3 = "";
         AV55Reembolsoassinaturaswwds_2_filterfulltext = "";
         AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = "";
         AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = "";
         AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = "";
         AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = "";
         AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = "";
         AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = "";
         AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = "";
         AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = "";
         AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = (DateTime)(DateTime.MinValue);
         AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = (DateTime)(DateTime.MinValue);
         AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = new GxSimpleCollection<string>();
         lV55Reembolsoassinaturaswwds_2_filterfulltext = "";
         lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = "";
         lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = "";
         lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = "";
         lV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = "";
         A574PropostaAssinaturaStatus = "";
         A632ReembolsoAssinaturasNome = "";
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         P00CB2_A572PropostaContratoAssinaturaId = new int[1] ;
         P00CB2_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         P00CB2_A571PropostaAssinatura = new long[1] ;
         P00CB2_n571PropostaAssinatura = new bool[] {false} ;
         P00CB2_A518ReembolsoId = new int[1] ;
         P00CB2_n518ReembolsoId = new bool[] {false} ;
         P00CB2_A632ReembolsoAssinaturasNome = new string[] {""} ;
         P00CB2_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         P00CB2_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         P00CB2_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         P00CB2_A574PropostaAssinaturaStatus = new string[] {""} ;
         P00CB2_n574PropostaAssinaturaStatus = new bool[] {false} ;
         P00CB2_A631ReembolsoAssinaturasId = new int[1] ;
         AV19Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoassinaturaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CB2_A572PropostaContratoAssinaturaId, P00CB2_n572PropostaContratoAssinaturaId, P00CB2_A571PropostaAssinatura, P00CB2_n571PropostaAssinatura, P00CB2_A518ReembolsoId, P00CB2_n518ReembolsoId, P00CB2_A632ReembolsoAssinaturasNome, P00CB2_n632ReembolsoAssinaturasNome, P00CB2_A633ReembolsoAssinaturasEmissao, P00CB2_n633ReembolsoAssinaturasEmissao,
               P00CB2_A574PropostaAssinaturaStatus, P00CB2_n574PropostaAssinaturaStatus, P00CB2_A631ReembolsoAssinaturasId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV38DynamicFiltersOperator1 ;
      private short AV42DynamicFiltersOperator2 ;
      private short AV46DynamicFiltersOperator3 ;
      private short AV57Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ;
      private short AV61Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ;
      private short AV65Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ;
      private int AV52GXV1 ;
      private int AV48PropostaId ;
      private int AV49ReembolsoId ;
      private int AV54Reembolsoassinaturaswwds_1_reembolsoid ;
      private int AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ;
      private int A518ReembolsoId ;
      private int A572PropostaContratoAssinaturaId ;
      private int A631ReembolsoAssinaturasId ;
      private long A571PropostaAssinatura ;
      private long AV24count ;
      private DateTime AV12TFReembolsoAssinaturasEmissao ;
      private DateTime AV13TFReembolsoAssinaturasEmissao_To ;
      private DateTime AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ;
      private DateTime AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ;
      private DateTime A633ReembolsoAssinaturasEmissao ;
      private bool returnInSub ;
      private bool AV40DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool AV59Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ;
      private bool AV63Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ;
      private bool BRKCB2 ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool n571PropostaAssinatura ;
      private bool n518ReembolsoId ;
      private bool n632ReembolsoAssinaturasNome ;
      private bool n633ReembolsoAssinaturasEmissao ;
      private bool n574PropostaAssinaturaStatus ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV50TFPropostaAssinaturaStatus_SelsJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV10TFReembolsoAssinaturasNome ;
      private string AV11TFReembolsoAssinaturasNome_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV39ReembolsoAssinaturasNome1 ;
      private string AV41DynamicFiltersSelector2 ;
      private string AV43ReembolsoAssinaturasNome2 ;
      private string AV45DynamicFiltersSelector3 ;
      private string AV47ReembolsoAssinaturasNome3 ;
      private string AV55Reembolsoassinaturaswwds_2_filterfulltext ;
      private string AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ;
      private string AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ;
      private string AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ;
      private string AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ;
      private string AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ;
      private string AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ;
      private string AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ;
      private string AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ;
      private string lV55Reembolsoassinaturaswwds_2_filterfulltext ;
      private string lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ;
      private string lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ;
      private string lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ;
      private string lV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ;
      private string A574PropostaAssinaturaStatus ;
      private string A632ReembolsoAssinaturasNome ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private GxSimpleCollection<string> AV51TFPropostaAssinaturaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00CB2_A572PropostaContratoAssinaturaId ;
      private bool[] P00CB2_n572PropostaContratoAssinaturaId ;
      private long[] P00CB2_A571PropostaAssinatura ;
      private bool[] P00CB2_n571PropostaAssinatura ;
      private int[] P00CB2_A518ReembolsoId ;
      private bool[] P00CB2_n518ReembolsoId ;
      private string[] P00CB2_A632ReembolsoAssinaturasNome ;
      private bool[] P00CB2_n632ReembolsoAssinaturasNome ;
      private DateTime[] P00CB2_A633ReembolsoAssinaturasEmissao ;
      private bool[] P00CB2_n633ReembolsoAssinaturasEmissao ;
      private string[] P00CB2_A574PropostaAssinaturaStatus ;
      private bool[] P00CB2_n574PropostaAssinaturaStatus ;
      private int[] P00CB2_A631ReembolsoAssinaturasId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class reembolsoassinaturaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CB2( IGxContext context ,
                                             string A574PropostaAssinaturaStatus ,
                                             GxSimpleCollection<string> AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                             string AV55Reembolsoassinaturaswwds_2_filterfulltext ,
                                             string AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                             short AV57Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                             string AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                             bool AV59Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                             string AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                             short AV61Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                             string AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                             bool AV63Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                             string AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                             short AV65Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                             string AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                             string AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                             string AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                             DateTime AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                             DateTime AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                             int AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ,
                                             string A632ReembolsoAssinaturasNome ,
                                             DateTime A633ReembolsoAssinaturasEmissao ,
                                             int AV54Reembolsoassinaturaswwds_1_reembolsoid ,
                                             int A518ReembolsoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.PropostaContratoAssinaturaId, T2.PropostaAssinatura AS PropostaAssinatura, T1.ReembolsoId, T1.ReembolsoAssinaturasNome, T1.ReembolsoAssinaturasEmissao, T3.AssinaturaStatus AS PropostaAssinaturaStatus, T1.ReembolsoAssinaturasId FROM ((ReembolsoAssinaturas T1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = T1.PropostaContratoAssinaturaId) LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.PropostaAssinatura)";
         AddWhere(sWhereString, "(T1.ReembolsoId = :AV54Reembolsoassinaturaswwds_1_reembolsoid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Reembolsoassinaturaswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ReembolsoAssinaturasNome like '%' || :lV55Reembolsoassinaturaswwds_2_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV55Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV55Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV55Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV55Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV55Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV57Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV57Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV59Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV61Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV59Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV61Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV63Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV65Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV63Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV65Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ! ( StringUtil.StrCmp(AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome = ( :AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoAssinaturasNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao >= :AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao <= :AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels, "T3.AssinaturaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ReembolsoId, T1.ReembolsoAssinaturasNome";
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
                     return conditional_P00CB2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] );
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
          Object[] prmP00CB2;
          prmP00CB2 = new Object[] {
          new ParDef("AV54Reembolsoassinaturaswwds_1_reembolsoid",GXType.Int32,9,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV58Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV62Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV66Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV67Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome",GXType.VarChar,100,0) ,
          new ParDef("AV68Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel",GXType.VarChar,100,0) ,
          new ParDef("AV69Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao",GXType.DateTime,8,5) ,
          new ParDef("AV70Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00CB2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
