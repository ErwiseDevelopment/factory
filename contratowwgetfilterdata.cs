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
   public class contratowwgetfilterdata : GXProcedure
   {
      public contratowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contratowwgetfilterdata( IGxContext context )
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
         this.AV28DDOName = aP0_DDOName;
         this.AV29SearchTxtParms = aP1_SearchTxtParms;
         this.AV30SearchTxtTo = aP2_SearchTxtTo;
         this.AV31OptionsJson = "" ;
         this.AV32OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV31OptionsJson;
         aP4_OptionsDescJson=this.AV32OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV28DDOName = aP0_DDOName;
         this.AV29SearchTxtParms = aP1_SearchTxtParms;
         this.AV30SearchTxtTo = aP2_SearchTxtTo;
         this.AV31OptionsJson = "" ;
         this.AV32OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV31OptionsJson;
         aP4_OptionsDescJson=this.AV32OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV15MaxItems = 10;
         AV14PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV29SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV29SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV12SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV29SearchTxtParms)) ? "" : StringUtil.Substring( AV29SearchTxtParms, 3, -1));
         AV13SkipItems = (short)(AV14PageIndex*AV15MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_CONTRATONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTRATONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV31OptionsJson = AV18Options.ToJSonString(false);
         AV32OptionsDescJson = AV20OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV21OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get("ContratoWWGridState"), "") == 0 )
         {
            AV25GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ContratoWWGridState"), null, "", "");
         }
         else
         {
            AV25GridState.FromXml(AV23Session.Get("ContratoWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV34FilterFullText = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV10TFContratoNome = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV11TFContratoNome_Sel = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCONTRATOSITUACAO_SEL") == 0 )
            {
               AV46TFContratoSituacao_SelsJson = AV26GridStateFilterValue.gxTpr_Value;
               AV47TFContratoSituacao_Sels.FromJSonString(AV46TFContratoSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "PARM_&CONTRATOCLIENTEID") == 0 )
            {
               AV49ContratoClienteId = (int)(Math.Round(NumberUtil.Val( AV26GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(1));
            AV35DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV35DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV36DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV37ContratoNome1 = AV27GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               AV36DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV50ContratoClienteDocumento1 = AV27GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV38DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(2));
               AV39DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV39DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV40DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV41ContratoNome2 = AV27GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV39DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  AV40DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV51ContratoClienteDocumento2 = AV27GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV42DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(3));
                  AV43DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV43DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV44DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV45ContratoNome3 = AV27GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
                  {
                     AV44DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV52ContratoClienteDocumento3 = AV27GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONTRATONOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFContratoNome = AV12SearchTxt;
         AV11TFContratoNome_Sel = "";
         AV55Contratowwds_1_contratoclienteid = AV49ContratoClienteId;
         AV56Contratowwds_2_filterfulltext = AV34FilterFullText;
         AV57Contratowwds_3_dynamicfiltersselector1 = AV35DynamicFiltersSelector1;
         AV58Contratowwds_4_dynamicfiltersoperator1 = AV36DynamicFiltersOperator1;
         AV59Contratowwds_5_contratonome1 = AV37ContratoNome1;
         AV60Contratowwds_6_contratoclientedocumento1 = AV50ContratoClienteDocumento1;
         AV61Contratowwds_7_dynamicfiltersenabled2 = AV38DynamicFiltersEnabled2;
         AV62Contratowwds_8_dynamicfiltersselector2 = AV39DynamicFiltersSelector2;
         AV63Contratowwds_9_dynamicfiltersoperator2 = AV40DynamicFiltersOperator2;
         AV64Contratowwds_10_contratonome2 = AV41ContratoNome2;
         AV65Contratowwds_11_contratoclientedocumento2 = AV51ContratoClienteDocumento2;
         AV66Contratowwds_12_dynamicfiltersenabled3 = AV42DynamicFiltersEnabled3;
         AV67Contratowwds_13_dynamicfiltersselector3 = AV43DynamicFiltersSelector3;
         AV68Contratowwds_14_dynamicfiltersoperator3 = AV44DynamicFiltersOperator3;
         AV69Contratowwds_15_contratonome3 = AV45ContratoNome3;
         AV70Contratowwds_16_contratoclientedocumento3 = AV52ContratoClienteDocumento3;
         AV71Contratowwds_17_tfcontratonome = AV10TFContratoNome;
         AV72Contratowwds_18_tfcontratonome_sel = AV11TFContratoNome_Sel;
         AV73Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A471ContratoSituacao ,
                                              AV73Contratowwds_19_tfcontratosituacao_sels ,
                                              AV56Contratowwds_2_filterfulltext ,
                                              AV57Contratowwds_3_dynamicfiltersselector1 ,
                                              AV58Contratowwds_4_dynamicfiltersoperator1 ,
                                              AV59Contratowwds_5_contratonome1 ,
                                              AV60Contratowwds_6_contratoclientedocumento1 ,
                                              AV61Contratowwds_7_dynamicfiltersenabled2 ,
                                              AV62Contratowwds_8_dynamicfiltersselector2 ,
                                              AV63Contratowwds_9_dynamicfiltersoperator2 ,
                                              AV64Contratowwds_10_contratonome2 ,
                                              AV65Contratowwds_11_contratoclientedocumento2 ,
                                              AV66Contratowwds_12_dynamicfiltersenabled3 ,
                                              AV67Contratowwds_13_dynamicfiltersselector3 ,
                                              AV68Contratowwds_14_dynamicfiltersoperator3 ,
                                              AV69Contratowwds_15_contratonome3 ,
                                              AV70Contratowwds_16_contratoclientedocumento3 ,
                                              AV72Contratowwds_18_tfcontratonome_sel ,
                                              AV71Contratowwds_17_tfcontratonome ,
                                              AV73Contratowwds_19_tfcontratosituacao_sels.Count ,
                                              A228ContratoNome ,
                                              A475ContratoClienteDocumento ,
                                              AV55Contratowwds_1_contratoclienteid ,
                                              A473ContratoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Contratowwds_2_filterfulltext), "%", "");
         lV56Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Contratowwds_2_filterfulltext), "%", "");
         lV56Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Contratowwds_2_filterfulltext), "%", "");
         lV56Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Contratowwds_2_filterfulltext), "%", "");
         lV59Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_5_contratonome1), "%", "");
         lV59Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_5_contratonome1), "%", "");
         lV60Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV60Contratowwds_6_contratoclientedocumento1), "%", "");
         lV60Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV60Contratowwds_6_contratoclientedocumento1), "%", "");
         lV64Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV64Contratowwds_10_contratonome2), "%", "");
         lV64Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV64Contratowwds_10_contratonome2), "%", "");
         lV65Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV65Contratowwds_11_contratoclientedocumento2), "%", "");
         lV65Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV65Contratowwds_11_contratoclientedocumento2), "%", "");
         lV69Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV69Contratowwds_15_contratonome3), "%", "");
         lV69Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV69Contratowwds_15_contratonome3), "%", "");
         lV70Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV70Contratowwds_16_contratoclientedocumento3), "%", "");
         lV70Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV70Contratowwds_16_contratoclientedocumento3), "%", "");
         lV71Contratowwds_17_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV71Contratowwds_17_tfcontratonome), "%", "");
         /* Using cursor P00782 */
         pr_default.execute(0, new Object[] {AV55Contratowwds_1_contratoclienteid, lV56Contratowwds_2_filterfulltext, lV56Contratowwds_2_filterfulltext, lV56Contratowwds_2_filterfulltext, lV56Contratowwds_2_filterfulltext, lV59Contratowwds_5_contratonome1, lV59Contratowwds_5_contratonome1, lV60Contratowwds_6_contratoclientedocumento1, lV60Contratowwds_6_contratoclientedocumento1, lV64Contratowwds_10_contratonome2, lV64Contratowwds_10_contratonome2, lV65Contratowwds_11_contratoclientedocumento2, lV65Contratowwds_11_contratoclientedocumento2, lV69Contratowwds_15_contratonome3, lV69Contratowwds_15_contratonome3, lV70Contratowwds_16_contratoclientedocumento3, lV70Contratowwds_16_contratoclientedocumento3, lV71Contratowwds_17_tfcontratonome, AV72Contratowwds_18_tfcontratonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK782 = false;
            A473ContratoClienteId = P00782_A473ContratoClienteId[0];
            n473ContratoClienteId = P00782_n473ContratoClienteId[0];
            A228ContratoNome = P00782_A228ContratoNome[0];
            n228ContratoNome = P00782_n228ContratoNome[0];
            A475ContratoClienteDocumento = P00782_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00782_n475ContratoClienteDocumento[0];
            A471ContratoSituacao = P00782_A471ContratoSituacao[0];
            n471ContratoSituacao = P00782_n471ContratoSituacao[0];
            A227ContratoId = P00782_A227ContratoId[0];
            A475ContratoClienteDocumento = P00782_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00782_n475ContratoClienteDocumento[0];
            AV22count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00782_A473ContratoClienteId[0] == A473ContratoClienteId ) && ( StringUtil.StrCmp(P00782_A228ContratoNome[0], A228ContratoNome) == 0 ) )
            {
               BRK782 = false;
               A227ContratoId = P00782_A227ContratoId[0];
               AV22count = (long)(AV22count+1);
               BRK782 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV13SkipItems) )
            {
               AV17Option = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? "<#Empty#>" : A228ContratoNome);
               AV18Options.Add(AV17Option, 0);
               AV21OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV22count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV18Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV13SkipItems = (short)(AV13SkipItems-1);
            }
            if ( ! BRK782 )
            {
               BRK782 = true;
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
         AV31OptionsJson = "";
         AV32OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV18Options = new GxSimpleCollection<string>();
         AV20OptionsDesc = new GxSimpleCollection<string>();
         AV21OptionIndexes = new GxSimpleCollection<string>();
         AV12SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV25GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34FilterFullText = "";
         AV10TFContratoNome = "";
         AV11TFContratoNome_Sel = "";
         AV46TFContratoSituacao_SelsJson = "";
         AV47TFContratoSituacao_Sels = new GxSimpleCollection<string>();
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV35DynamicFiltersSelector1 = "";
         AV37ContratoNome1 = "";
         AV50ContratoClienteDocumento1 = "";
         AV39DynamicFiltersSelector2 = "";
         AV41ContratoNome2 = "";
         AV51ContratoClienteDocumento2 = "";
         AV43DynamicFiltersSelector3 = "";
         AV45ContratoNome3 = "";
         AV52ContratoClienteDocumento3 = "";
         AV56Contratowwds_2_filterfulltext = "";
         AV57Contratowwds_3_dynamicfiltersselector1 = "";
         AV59Contratowwds_5_contratonome1 = "";
         AV60Contratowwds_6_contratoclientedocumento1 = "";
         AV62Contratowwds_8_dynamicfiltersselector2 = "";
         AV64Contratowwds_10_contratonome2 = "";
         AV65Contratowwds_11_contratoclientedocumento2 = "";
         AV67Contratowwds_13_dynamicfiltersselector3 = "";
         AV69Contratowwds_15_contratonome3 = "";
         AV70Contratowwds_16_contratoclientedocumento3 = "";
         AV71Contratowwds_17_tfcontratonome = "";
         AV72Contratowwds_18_tfcontratonome_sel = "";
         AV73Contratowwds_19_tfcontratosituacao_sels = new GxSimpleCollection<string>();
         lV56Contratowwds_2_filterfulltext = "";
         lV59Contratowwds_5_contratonome1 = "";
         lV60Contratowwds_6_contratoclientedocumento1 = "";
         lV64Contratowwds_10_contratonome2 = "";
         lV65Contratowwds_11_contratoclientedocumento2 = "";
         lV69Contratowwds_15_contratonome3 = "";
         lV70Contratowwds_16_contratoclientedocumento3 = "";
         lV71Contratowwds_17_tfcontratonome = "";
         A471ContratoSituacao = "";
         A228ContratoNome = "";
         A475ContratoClienteDocumento = "";
         P00782_A473ContratoClienteId = new int[1] ;
         P00782_n473ContratoClienteId = new bool[] {false} ;
         P00782_A228ContratoNome = new string[] {""} ;
         P00782_n228ContratoNome = new bool[] {false} ;
         P00782_A475ContratoClienteDocumento = new string[] {""} ;
         P00782_n475ContratoClienteDocumento = new bool[] {false} ;
         P00782_A471ContratoSituacao = new string[] {""} ;
         P00782_n471ContratoSituacao = new bool[] {false} ;
         P00782_A227ContratoId = new int[1] ;
         AV17Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contratowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00782_A473ContratoClienteId, P00782_n473ContratoClienteId, P00782_A228ContratoNome, P00782_n228ContratoNome, P00782_A475ContratoClienteDocumento, P00782_n475ContratoClienteDocumento, P00782_A471ContratoSituacao, P00782_n471ContratoSituacao, P00782_A227ContratoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15MaxItems ;
      private short AV14PageIndex ;
      private short AV13SkipItems ;
      private short AV36DynamicFiltersOperator1 ;
      private short AV40DynamicFiltersOperator2 ;
      private short AV44DynamicFiltersOperator3 ;
      private short AV58Contratowwds_4_dynamicfiltersoperator1 ;
      private short AV63Contratowwds_9_dynamicfiltersoperator2 ;
      private short AV68Contratowwds_14_dynamicfiltersoperator3 ;
      private int AV53GXV1 ;
      private int AV49ContratoClienteId ;
      private int AV55Contratowwds_1_contratoclienteid ;
      private int AV73Contratowwds_19_tfcontratosituacao_sels_Count ;
      private int A473ContratoClienteId ;
      private int A227ContratoId ;
      private long AV22count ;
      private bool returnInSub ;
      private bool AV38DynamicFiltersEnabled2 ;
      private bool AV42DynamicFiltersEnabled3 ;
      private bool AV61Contratowwds_7_dynamicfiltersenabled2 ;
      private bool AV66Contratowwds_12_dynamicfiltersenabled3 ;
      private bool BRK782 ;
      private bool n473ContratoClienteId ;
      private bool n228ContratoNome ;
      private bool n475ContratoClienteDocumento ;
      private bool n471ContratoSituacao ;
      private string AV31OptionsJson ;
      private string AV32OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV46TFContratoSituacao_SelsJson ;
      private string AV28DDOName ;
      private string AV29SearchTxtParms ;
      private string AV30SearchTxtTo ;
      private string AV12SearchTxt ;
      private string AV34FilterFullText ;
      private string AV10TFContratoNome ;
      private string AV11TFContratoNome_Sel ;
      private string AV35DynamicFiltersSelector1 ;
      private string AV37ContratoNome1 ;
      private string AV50ContratoClienteDocumento1 ;
      private string AV39DynamicFiltersSelector2 ;
      private string AV41ContratoNome2 ;
      private string AV51ContratoClienteDocumento2 ;
      private string AV43DynamicFiltersSelector3 ;
      private string AV45ContratoNome3 ;
      private string AV52ContratoClienteDocumento3 ;
      private string AV56Contratowwds_2_filterfulltext ;
      private string AV57Contratowwds_3_dynamicfiltersselector1 ;
      private string AV59Contratowwds_5_contratonome1 ;
      private string AV60Contratowwds_6_contratoclientedocumento1 ;
      private string AV62Contratowwds_8_dynamicfiltersselector2 ;
      private string AV64Contratowwds_10_contratonome2 ;
      private string AV65Contratowwds_11_contratoclientedocumento2 ;
      private string AV67Contratowwds_13_dynamicfiltersselector3 ;
      private string AV69Contratowwds_15_contratonome3 ;
      private string AV70Contratowwds_16_contratoclientedocumento3 ;
      private string AV71Contratowwds_17_tfcontratonome ;
      private string AV72Contratowwds_18_tfcontratonome_sel ;
      private string lV56Contratowwds_2_filterfulltext ;
      private string lV59Contratowwds_5_contratonome1 ;
      private string lV60Contratowwds_6_contratoclientedocumento1 ;
      private string lV64Contratowwds_10_contratonome2 ;
      private string lV65Contratowwds_11_contratoclientedocumento2 ;
      private string lV69Contratowwds_15_contratonome3 ;
      private string lV70Contratowwds_16_contratoclientedocumento3 ;
      private string lV71Contratowwds_17_tfcontratonome ;
      private string A471ContratoSituacao ;
      private string A228ContratoNome ;
      private string A475ContratoClienteDocumento ;
      private string AV17Option ;
      private IGxSession AV23Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV18Options ;
      private GxSimpleCollection<string> AV20OptionsDesc ;
      private GxSimpleCollection<string> AV21OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV25GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV26GridStateFilterValue ;
      private GxSimpleCollection<string> AV47TFContratoSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV73Contratowwds_19_tfcontratosituacao_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00782_A473ContratoClienteId ;
      private bool[] P00782_n473ContratoClienteId ;
      private string[] P00782_A228ContratoNome ;
      private bool[] P00782_n228ContratoNome ;
      private string[] P00782_A475ContratoClienteDocumento ;
      private bool[] P00782_n475ContratoClienteDocumento ;
      private string[] P00782_A471ContratoSituacao ;
      private bool[] P00782_n471ContratoSituacao ;
      private int[] P00782_A227ContratoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class contratowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00782( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV73Contratowwds_19_tfcontratosituacao_sels ,
                                             string AV56Contratowwds_2_filterfulltext ,
                                             string AV57Contratowwds_3_dynamicfiltersselector1 ,
                                             short AV58Contratowwds_4_dynamicfiltersoperator1 ,
                                             string AV59Contratowwds_5_contratonome1 ,
                                             string AV60Contratowwds_6_contratoclientedocumento1 ,
                                             bool AV61Contratowwds_7_dynamicfiltersenabled2 ,
                                             string AV62Contratowwds_8_dynamicfiltersselector2 ,
                                             short AV63Contratowwds_9_dynamicfiltersoperator2 ,
                                             string AV64Contratowwds_10_contratonome2 ,
                                             string AV65Contratowwds_11_contratoclientedocumento2 ,
                                             bool AV66Contratowwds_12_dynamicfiltersenabled3 ,
                                             string AV67Contratowwds_13_dynamicfiltersselector3 ,
                                             short AV68Contratowwds_14_dynamicfiltersoperator3 ,
                                             string AV69Contratowwds_15_contratonome3 ,
                                             string AV70Contratowwds_16_contratoclientedocumento3 ,
                                             string AV72Contratowwds_18_tfcontratonome_sel ,
                                             string AV71Contratowwds_17_tfcontratonome ,
                                             int AV73Contratowwds_19_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             int AV55Contratowwds_1_contratoclienteid ,
                                             int A473ContratoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[19];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoClienteId AS ContratoClienteId, T1.ContratoNome, T2.ClienteDocumento AS ContratoClienteDocumento, T1.ContratoSituacao, T1.ContratoId FROM (Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId)";
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV55Contratowwds_1_contratoclienteid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Contratowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ContratoNome like '%' || :lV56Contratowwds_2_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV56Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV56Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV56Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV58Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV59Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV58Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV59Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV58Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV60Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV58Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV60Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV61Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV63Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV64Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV61Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV63Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV64Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV61Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV63Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV65Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV61Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV63Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV65Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV66Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV68Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV69Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV66Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV68Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV69Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV66Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV68Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV70Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV66Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV68Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV70Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contratowwds_18_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contratowwds_17_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV71Contratowwds_17_tfcontratonome)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contratowwds_18_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV72Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV72Contratowwds_18_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV72Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV73Contratowwds_19_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV73Contratowwds_19_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoClienteId, T1.ContratoNome";
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
                     return conditional_P00782(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (int)dynConstraints[23] );
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
          Object[] prmP00782;
          prmP00782 = new Object[] {
          new ParDef("AV55Contratowwds_1_contratoclienteid",GXType.Int32,9,0) ,
          new ParDef("lV56Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV59Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV60Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV60Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV64Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV64Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV65Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV65Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV69Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV69Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV70Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV70Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV71Contratowwds_17_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV72Contratowwds_18_tfcontratonome_sel",GXType.VarChar,125,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,100, GxCacheFrequency.OFF ,true,false )
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
