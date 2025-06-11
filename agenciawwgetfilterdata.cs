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
   public class agenciawwgetfilterdata : GXProcedure
   {
      public agenciawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agenciawwgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_AGENCIABANCONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADAGENCIABANCONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("AgenciaWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AgenciaWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("AgenciaWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV10TFAgenciaBancoNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV11TFAgenciaBancoNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV12TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV13TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIADIGITO") == 0 )
            {
               AV14TFAgenciaDigito = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV15TFAgenciaDigito_To = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIASTATUS_SEL") == 0 )
            {
               AV16TFAgenciaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIACREATEDAT") == 0 )
            {
               AV17TFAgenciaCreatedAt = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Value, 4);
               AV18TFAgenciaCreatedAt_To = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFAGENCIAUPDATEDAT") == 0 )
            {
               AV19TFAgenciaUpdatedAt = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Value, 4);
               AV20TFAgenciaUpdatedAt_To = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&BANCOID") == 0 )
            {
               AV55BancoId = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV44DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV44DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
            {
               AV45DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV46AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV50AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV51DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV52DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
                  {
                     AV53DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV54AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADAGENCIABANCONOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFAgenciaBancoNome = AV21SearchTxt;
         AV11TFAgenciaBancoNome_Sel = "";
         AV58Agenciawwds_1_filterfulltext = AV43FilterFullText;
         AV59Agenciawwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV60Agenciawwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV61Agenciawwds_4_agencianumero1 = AV46AgenciaNumero1;
         AV62Agenciawwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV63Agenciawwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV64Agenciawwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV65Agenciawwds_8_agencianumero2 = AV50AgenciaNumero2;
         AV66Agenciawwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV67Agenciawwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV68Agenciawwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV69Agenciawwds_12_agencianumero3 = AV54AgenciaNumero3;
         AV70Agenciawwds_13_tfagenciabanconome = AV10TFAgenciaBancoNome;
         AV71Agenciawwds_14_tfagenciabanconome_sel = AV11TFAgenciaBancoNome_Sel;
         AV72Agenciawwds_15_tfagencianumero = AV12TFAgenciaNumero;
         AV73Agenciawwds_16_tfagencianumero_to = AV13TFAgenciaNumero_To;
         AV74Agenciawwds_17_tfagenciadigito = AV14TFAgenciaDigito;
         AV75Agenciawwds_18_tfagenciadigito_to = AV15TFAgenciaDigito_To;
         AV76Agenciawwds_19_tfagenciastatus_sel = AV16TFAgenciaStatus_Sel;
         AV77Agenciawwds_20_tfagenciacreatedat = AV17TFAgenciaCreatedAt;
         AV78Agenciawwds_21_tfagenciacreatedat_to = AV18TFAgenciaCreatedAt_To;
         AV79Agenciawwds_22_tfagenciaupdatedat = AV19TFAgenciaUpdatedAt;
         AV80Agenciawwds_23_tfagenciaupdatedat_to = AV20TFAgenciaUpdatedAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Agenciawwds_1_filterfulltext ,
                                              AV59Agenciawwds_2_dynamicfiltersselector1 ,
                                              AV60Agenciawwds_3_dynamicfiltersoperator1 ,
                                              AV61Agenciawwds_4_agencianumero1 ,
                                              AV62Agenciawwds_5_dynamicfiltersenabled2 ,
                                              AV63Agenciawwds_6_dynamicfiltersselector2 ,
                                              AV64Agenciawwds_7_dynamicfiltersoperator2 ,
                                              AV65Agenciawwds_8_agencianumero2 ,
                                              AV66Agenciawwds_9_dynamicfiltersenabled3 ,
                                              AV67Agenciawwds_10_dynamicfiltersselector3 ,
                                              AV68Agenciawwds_11_dynamicfiltersoperator3 ,
                                              AV69Agenciawwds_12_agencianumero3 ,
                                              AV71Agenciawwds_14_tfagenciabanconome_sel ,
                                              AV70Agenciawwds_13_tfagenciabanconome ,
                                              AV72Agenciawwds_15_tfagencianumero ,
                                              AV73Agenciawwds_16_tfagencianumero_to ,
                                              AV74Agenciawwds_17_tfagenciadigito ,
                                              AV75Agenciawwds_18_tfagenciadigito_to ,
                                              AV76Agenciawwds_19_tfagenciastatus_sel ,
                                              AV77Agenciawwds_20_tfagenciacreatedat ,
                                              AV78Agenciawwds_21_tfagenciacreatedat_to ,
                                              AV79Agenciawwds_22_tfagenciaupdatedat ,
                                              AV80Agenciawwds_23_tfagenciaupdatedat_to ,
                                              AV55BancoId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A945AgenciaDigito ,
                                              A940AgenciaStatus ,
                                              A941AgenciaCreatedAt ,
                                              A942AgenciaUpdatedAt ,
                                              A968AgenciaBancoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV58Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Agenciawwds_1_filterfulltext), "%", "");
         lV58Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Agenciawwds_1_filterfulltext), "%", "");
         lV58Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Agenciawwds_1_filterfulltext), "%", "");
         lV58Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Agenciawwds_1_filterfulltext), "%", "");
         lV58Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Agenciawwds_1_filterfulltext), "%", "");
         lV70Agenciawwds_13_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV70Agenciawwds_13_tfagenciabanconome), "%", "");
         /* Using cursor P00EP2 */
         pr_default.execute(0, new Object[] {lV58Agenciawwds_1_filterfulltext, lV58Agenciawwds_1_filterfulltext, lV58Agenciawwds_1_filterfulltext, lV58Agenciawwds_1_filterfulltext, lV58Agenciawwds_1_filterfulltext, AV61Agenciawwds_4_agencianumero1, AV61Agenciawwds_4_agencianumero1, AV61Agenciawwds_4_agencianumero1, AV65Agenciawwds_8_agencianumero2, AV65Agenciawwds_8_agencianumero2, AV65Agenciawwds_8_agencianumero2, AV69Agenciawwds_12_agencianumero3, AV69Agenciawwds_12_agencianumero3, AV69Agenciawwds_12_agencianumero3, lV70Agenciawwds_13_tfagenciabanconome, AV71Agenciawwds_14_tfagenciabanconome_sel, AV72Agenciawwds_15_tfagencianumero, AV73Agenciawwds_16_tfagencianumero_to, AV74Agenciawwds_17_tfagenciadigito, AV75Agenciawwds_18_tfagenciadigito_to, AV77Agenciawwds_20_tfagenciacreatedat, AV78Agenciawwds_21_tfagenciacreatedat_to, AV79Agenciawwds_22_tfagenciaupdatedat, AV80Agenciawwds_23_tfagenciaupdatedat_to, AV55BancoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEP2 = false;
            A969AgenciaBancoNome = P00EP2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EP2_n969AgenciaBancoNome[0];
            A968AgenciaBancoId = P00EP2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EP2_n968AgenciaBancoId[0];
            A942AgenciaUpdatedAt = P00EP2_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = P00EP2_n942AgenciaUpdatedAt[0];
            A941AgenciaCreatedAt = P00EP2_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = P00EP2_n941AgenciaCreatedAt[0];
            A945AgenciaDigito = P00EP2_A945AgenciaDigito[0];
            n945AgenciaDigito = P00EP2_n945AgenciaDigito[0];
            A939AgenciaNumero = P00EP2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EP2_n939AgenciaNumero[0];
            A940AgenciaStatus = P00EP2_A940AgenciaStatus[0];
            n940AgenciaStatus = P00EP2_n940AgenciaStatus[0];
            A938AgenciaId = P00EP2_A938AgenciaId[0];
            A969AgenciaBancoNome = P00EP2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EP2_n969AgenciaBancoNome[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EP2_A969AgenciaBancoNome[0], A969AgenciaBancoNome) == 0 ) )
            {
               BRKEP2 = false;
               A968AgenciaBancoId = P00EP2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = P00EP2_n968AgenciaBancoId[0];
               A938AgenciaId = P00EP2_A938AgenciaId[0];
               AV31count = (long)(AV31count+1);
               BRKEP2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A969AgenciaBancoNome)) ? "<#Empty#>" : A969AgenciaBancoNome);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRKEP2 )
            {
               BRKEP2 = true;
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV10TFAgenciaBancoNome = "";
         AV11TFAgenciaBancoNome_Sel = "";
         AV17TFAgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         AV18TFAgenciaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV19TFAgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         AV20TFAgenciaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV44DynamicFiltersSelector1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV52DynamicFiltersSelector3 = "";
         AV58Agenciawwds_1_filterfulltext = "";
         AV59Agenciawwds_2_dynamicfiltersselector1 = "";
         AV63Agenciawwds_6_dynamicfiltersselector2 = "";
         AV67Agenciawwds_10_dynamicfiltersselector3 = "";
         AV70Agenciawwds_13_tfagenciabanconome = "";
         AV71Agenciawwds_14_tfagenciabanconome_sel = "";
         AV77Agenciawwds_20_tfagenciacreatedat = (DateTime)(DateTime.MinValue);
         AV78Agenciawwds_21_tfagenciacreatedat_to = (DateTime)(DateTime.MinValue);
         AV79Agenciawwds_22_tfagenciaupdatedat = (DateTime)(DateTime.MinValue);
         AV80Agenciawwds_23_tfagenciaupdatedat_to = (DateTime)(DateTime.MinValue);
         lV58Agenciawwds_1_filterfulltext = "";
         lV70Agenciawwds_13_tfagenciabanconome = "";
         A969AgenciaBancoNome = "";
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         P00EP2_A969AgenciaBancoNome = new string[] {""} ;
         P00EP2_n969AgenciaBancoNome = new bool[] {false} ;
         P00EP2_A968AgenciaBancoId = new int[1] ;
         P00EP2_n968AgenciaBancoId = new bool[] {false} ;
         P00EP2_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EP2_n942AgenciaUpdatedAt = new bool[] {false} ;
         P00EP2_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EP2_n941AgenciaCreatedAt = new bool[] {false} ;
         P00EP2_A945AgenciaDigito = new int[1] ;
         P00EP2_n945AgenciaDigito = new bool[] {false} ;
         P00EP2_A939AgenciaNumero = new int[1] ;
         P00EP2_n939AgenciaNumero = new bool[] {false} ;
         P00EP2_A940AgenciaStatus = new bool[] {false} ;
         P00EP2_n940AgenciaStatus = new bool[] {false} ;
         P00EP2_A938AgenciaId = new int[1] ;
         AV26Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agenciawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EP2_A969AgenciaBancoNome, P00EP2_n969AgenciaBancoNome, P00EP2_A968AgenciaBancoId, P00EP2_n968AgenciaBancoId, P00EP2_A942AgenciaUpdatedAt, P00EP2_n942AgenciaUpdatedAt, P00EP2_A941AgenciaCreatedAt, P00EP2_n941AgenciaCreatedAt, P00EP2_A945AgenciaDigito, P00EP2_n945AgenciaDigito,
               P00EP2_A939AgenciaNumero, P00EP2_n939AgenciaNumero, P00EP2_A940AgenciaStatus, P00EP2_n940AgenciaStatus, P00EP2_A938AgenciaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV16TFAgenciaStatus_Sel ;
      private short AV45DynamicFiltersOperator1 ;
      private short AV49DynamicFiltersOperator2 ;
      private short AV53DynamicFiltersOperator3 ;
      private short AV60Agenciawwds_3_dynamicfiltersoperator1 ;
      private short AV64Agenciawwds_7_dynamicfiltersoperator2 ;
      private short AV68Agenciawwds_11_dynamicfiltersoperator3 ;
      private short AV76Agenciawwds_19_tfagenciastatus_sel ;
      private int AV56GXV1 ;
      private int AV12TFAgenciaNumero ;
      private int AV13TFAgenciaNumero_To ;
      private int AV14TFAgenciaDigito ;
      private int AV15TFAgenciaDigito_To ;
      private int AV55BancoId ;
      private int AV46AgenciaNumero1 ;
      private int AV50AgenciaNumero2 ;
      private int AV54AgenciaNumero3 ;
      private int AV61Agenciawwds_4_agencianumero1 ;
      private int AV65Agenciawwds_8_agencianumero2 ;
      private int AV69Agenciawwds_12_agencianumero3 ;
      private int AV72Agenciawwds_15_tfagencianumero ;
      private int AV73Agenciawwds_16_tfagencianumero_to ;
      private int AV74Agenciawwds_17_tfagenciadigito ;
      private int AV75Agenciawwds_18_tfagenciadigito_to ;
      private int A939AgenciaNumero ;
      private int A945AgenciaDigito ;
      private int A968AgenciaBancoId ;
      private int A938AgenciaId ;
      private long AV31count ;
      private DateTime AV17TFAgenciaCreatedAt ;
      private DateTime AV18TFAgenciaCreatedAt_To ;
      private DateTime AV19TFAgenciaUpdatedAt ;
      private DateTime AV20TFAgenciaUpdatedAt_To ;
      private DateTime AV77Agenciawwds_20_tfagenciacreatedat ;
      private DateTime AV78Agenciawwds_21_tfagenciacreatedat_to ;
      private DateTime AV79Agenciawwds_22_tfagenciaupdatedat ;
      private DateTime AV80Agenciawwds_23_tfagenciaupdatedat_to ;
      private DateTime A941AgenciaCreatedAt ;
      private DateTime A942AgenciaUpdatedAt ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV51DynamicFiltersEnabled3 ;
      private bool AV62Agenciawwds_5_dynamicfiltersenabled2 ;
      private bool AV66Agenciawwds_9_dynamicfiltersenabled3 ;
      private bool A940AgenciaStatus ;
      private bool BRKEP2 ;
      private bool n969AgenciaBancoNome ;
      private bool n968AgenciaBancoId ;
      private bool n942AgenciaUpdatedAt ;
      private bool n941AgenciaCreatedAt ;
      private bool n945AgenciaDigito ;
      private bool n939AgenciaNumero ;
      private bool n940AgenciaStatus ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV10TFAgenciaBancoNome ;
      private string AV11TFAgenciaBancoNome_Sel ;
      private string AV44DynamicFiltersSelector1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV52DynamicFiltersSelector3 ;
      private string AV58Agenciawwds_1_filterfulltext ;
      private string AV59Agenciawwds_2_dynamicfiltersselector1 ;
      private string AV63Agenciawwds_6_dynamicfiltersselector2 ;
      private string AV67Agenciawwds_10_dynamicfiltersselector3 ;
      private string AV70Agenciawwds_13_tfagenciabanconome ;
      private string AV71Agenciawwds_14_tfagenciabanconome_sel ;
      private string lV58Agenciawwds_1_filterfulltext ;
      private string lV70Agenciawwds_13_tfagenciabanconome ;
      private string A969AgenciaBancoNome ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00EP2_A969AgenciaBancoNome ;
      private bool[] P00EP2_n969AgenciaBancoNome ;
      private int[] P00EP2_A968AgenciaBancoId ;
      private bool[] P00EP2_n968AgenciaBancoId ;
      private DateTime[] P00EP2_A942AgenciaUpdatedAt ;
      private bool[] P00EP2_n942AgenciaUpdatedAt ;
      private DateTime[] P00EP2_A941AgenciaCreatedAt ;
      private bool[] P00EP2_n941AgenciaCreatedAt ;
      private int[] P00EP2_A945AgenciaDigito ;
      private bool[] P00EP2_n945AgenciaDigito ;
      private int[] P00EP2_A939AgenciaNumero ;
      private bool[] P00EP2_n939AgenciaNumero ;
      private bool[] P00EP2_A940AgenciaStatus ;
      private bool[] P00EP2_n940AgenciaStatus ;
      private int[] P00EP2_A938AgenciaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class agenciawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EP2( IGxContext context ,
                                             string AV58Agenciawwds_1_filterfulltext ,
                                             string AV59Agenciawwds_2_dynamicfiltersselector1 ,
                                             short AV60Agenciawwds_3_dynamicfiltersoperator1 ,
                                             int AV61Agenciawwds_4_agencianumero1 ,
                                             bool AV62Agenciawwds_5_dynamicfiltersenabled2 ,
                                             string AV63Agenciawwds_6_dynamicfiltersselector2 ,
                                             short AV64Agenciawwds_7_dynamicfiltersoperator2 ,
                                             int AV65Agenciawwds_8_agencianumero2 ,
                                             bool AV66Agenciawwds_9_dynamicfiltersenabled3 ,
                                             string AV67Agenciawwds_10_dynamicfiltersselector3 ,
                                             short AV68Agenciawwds_11_dynamicfiltersoperator3 ,
                                             int AV69Agenciawwds_12_agencianumero3 ,
                                             string AV71Agenciawwds_14_tfagenciabanconome_sel ,
                                             string AV70Agenciawwds_13_tfagenciabanconome ,
                                             int AV72Agenciawwds_15_tfagencianumero ,
                                             int AV73Agenciawwds_16_tfagencianumero_to ,
                                             int AV74Agenciawwds_17_tfagenciadigito ,
                                             int AV75Agenciawwds_18_tfagenciadigito_to ,
                                             short AV76Agenciawwds_19_tfagenciastatus_sel ,
                                             DateTime AV77Agenciawwds_20_tfagenciacreatedat ,
                                             DateTime AV78Agenciawwds_21_tfagenciacreatedat_to ,
                                             DateTime AV79Agenciawwds_22_tfagenciaupdatedat ,
                                             DateTime AV80Agenciawwds_23_tfagenciaupdatedat_to ,
                                             int AV55BancoId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             int A945AgenciaDigito ,
                                             bool A940AgenciaStatus ,
                                             DateTime A941AgenciaCreatedAt ,
                                             DateTime A942AgenciaUpdatedAt ,
                                             int A968AgenciaBancoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[25];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.BancoNome AS AgenciaBancoNome, T1.AgenciaBancoId AS AgenciaBancoId, T1.AgenciaUpdatedAt, T1.AgenciaCreatedAt, T1.AgenciaDigito, T1.AgenciaNumero, T1.AgenciaStatus, T1.AgenciaId FROM (Agencia T1 LEFT JOIN Banco T2 ON T2.BancoId = T1.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Agenciawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.BancoNome) like '%' || LOWER(:lV58Agenciawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.AgenciaNumero,'999999999'), 2) like '%' || :lV58Agenciawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.AgenciaDigito,'999999999'), 2) like '%' || :lV58Agenciawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV58Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV58Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV60Agenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV61Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV61Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV60Agenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV61Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV61Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV60Agenciawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV61Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV61Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV62Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV64Agenciawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV65Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV65Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV62Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV64Agenciawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV65Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV65Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV62Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV64Agenciawwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV65Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV65Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV66Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV68Agenciawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV69Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV69Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV66Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV68Agenciawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV69Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV69Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV66Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV68Agenciawwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV69Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV69Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Agenciawwds_14_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Agenciawwds_13_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome like :lV70Agenciawwds_13_tfagenciabanconome)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Agenciawwds_14_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV71Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome = ( :AV71Agenciawwds_14_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.BancoNome IS NULL or (char_length(trim(trailing ' ' from T2.BancoNome))=0))");
         }
         if ( ! (0==AV72Agenciawwds_15_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero >= :AV72Agenciawwds_15_tfagencianumero)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (0==AV73Agenciawwds_16_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero <= :AV73Agenciawwds_16_tfagencianumero_to)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (0==AV74Agenciawwds_17_tfagenciadigito) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito >= :AV74Agenciawwds_17_tfagenciadigito)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV75Agenciawwds_18_tfagenciadigito_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito <= :AV75Agenciawwds_18_tfagenciadigito_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV76Agenciawwds_19_tfagenciastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = TRUE)");
         }
         if ( AV76Agenciawwds_19_tfagenciastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV77Agenciawwds_20_tfagenciacreatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt >= :AV77Agenciawwds_20_tfagenciacreatedat)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Agenciawwds_21_tfagenciacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt <= :AV78Agenciawwds_21_tfagenciacreatedat_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Agenciawwds_22_tfagenciaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt >= :AV79Agenciawwds_22_tfagenciaupdatedat)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Agenciawwds_23_tfagenciaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt <= :AV80Agenciawwds_23_tfagenciaupdatedat_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (0==AV55BancoId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaBancoId = :AV55BancoId)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.BancoNome";
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
                     return conditional_P00EP2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (int)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (short)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (int)dynConstraints[30] );
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
          Object[] prmP00EP2;
          prmP00EP2 = new Object[] {
          new ParDef("lV58Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV61Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV61Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV65Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV65Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV65Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV69Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV69Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV69Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV70Agenciawwds_13_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV71Agenciawwds_14_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV72Agenciawwds_15_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV73Agenciawwds_16_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV74Agenciawwds_17_tfagenciadigito",GXType.Int32,9,0) ,
          new ParDef("AV75Agenciawwds_18_tfagenciadigito_to",GXType.Int32,9,0) ,
          new ParDef("AV77Agenciawwds_20_tfagenciacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV78Agenciawwds_21_tfagenciacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV79Agenciawwds_22_tfagenciaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV80Agenciawwds_23_tfagenciaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV55BancoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
