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
   public class configuracaonotificacoeswwgetfilterdata : GXProcedure
   {
      public configuracaonotificacoeswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracaonotificacoeswwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_CONFIGURACAONOTIFICACOESEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADCONFIGURACAONOTIFICACOESEMAILOPTIONS' */
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
         if ( StringUtil.StrCmp(AV23Session.Get("ConfiguracaoNotificacoesWWGridState"), "") == 0 )
         {
            AV25GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfiguracaoNotificacoesWWGridState"), null, "", "");
         }
         else
         {
            AV25GridState.FromXml(AV23Session.Get("ConfiguracaoNotificacoesWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV34FilterFullText = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCONFIGURACAONOTIFICACOESEMAIL") == 0 )
            {
               AV10TFConfiguracaoNotificacoesEmail = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCONFIGURACAONOTIFICACOESEMAIL_SEL") == 0 )
            {
               AV11TFConfiguracaoNotificacoesEmail_Sel = AV26GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
         if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(1));
            AV35DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV35DynamicFiltersSelector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
            {
               AV36DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV37ConfiguracaoNotificacoesEmail1 = AV27GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV38DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(2));
               AV39DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV39DynamicFiltersSelector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
               {
                  AV40DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV41ConfiguracaoNotificacoesEmail2 = AV27GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV42DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(3));
                  AV43DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV43DynamicFiltersSelector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
                  {
                     AV44DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV45ConfiguracaoNotificacoesEmail3 = AV27GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONFIGURACAONOTIFICACOESEMAILOPTIONS' Routine */
         returnInSub = false;
         AV10TFConfiguracaoNotificacoesEmail = AV12SearchTxt;
         AV11TFConfiguracaoNotificacoesEmail_Sel = "";
         AV48Configuracaonotificacoeswwds_1_filterfulltext = AV34FilterFullText;
         AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV35DynamicFiltersSelector1;
         AV50Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV36DynamicFiltersOperator1;
         AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV37ConfiguracaoNotificacoesEmail1;
         AV52Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV38DynamicFiltersEnabled2;
         AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV39DynamicFiltersSelector2;
         AV54Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV40DynamicFiltersOperator2;
         AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV41ConfiguracaoNotificacoesEmail2;
         AV56Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV42DynamicFiltersEnabled3;
         AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV43DynamicFiltersSelector3;
         AV58Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV44DynamicFiltersOperator3;
         AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV45ConfiguracaoNotificacoesEmail3;
         AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV10TFConfiguracaoNotificacoesEmail;
         AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV11TFConfiguracaoNotificacoesEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Configuracaonotificacoeswwds_1_filterfulltext ,
                                              AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                              AV50Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                              AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                              AV52Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                              AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                              AV54Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                              AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                              AV56Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                              AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                              AV58Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                              AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                              AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                              AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                              A492ConfiguracaoNotificacoesEmail } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Configuracaonotificacoeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_1_filterfulltext), "%", "");
         lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
         lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
         lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
         lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
         lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
         lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
         lV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = StringUtil.Concat( StringUtil.RTrim( AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail), "%", "");
         /* Using cursor P00AF2 */
         pr_default.execute(0, new Object[] {lV48Configuracaonotificacoeswwds_1_filterfulltext, lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail, AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAF2 = false;
            A492ConfiguracaoNotificacoesEmail = P00AF2_A492ConfiguracaoNotificacoesEmail[0];
            n492ConfiguracaoNotificacoesEmail = P00AF2_n492ConfiguracaoNotificacoesEmail[0];
            A491ConfiguracaoNotificacoesId = P00AF2_A491ConfiguracaoNotificacoesId[0];
            AV22count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AF2_A492ConfiguracaoNotificacoesEmail[0], A492ConfiguracaoNotificacoesEmail) == 0 ) )
            {
               BRKAF2 = false;
               A491ConfiguracaoNotificacoesId = P00AF2_A491ConfiguracaoNotificacoesId[0];
               AV22count = (long)(AV22count+1);
               BRKAF2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV13SkipItems) )
            {
               AV17Option = (String.IsNullOrEmpty(StringUtil.RTrim( A492ConfiguracaoNotificacoesEmail)) ? "<#Empty#>" : A492ConfiguracaoNotificacoesEmail);
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
            if ( ! BRKAF2 )
            {
               BRKAF2 = true;
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
         AV10TFConfiguracaoNotificacoesEmail = "";
         AV11TFConfiguracaoNotificacoesEmail_Sel = "";
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV35DynamicFiltersSelector1 = "";
         AV37ConfiguracaoNotificacoesEmail1 = "";
         AV39DynamicFiltersSelector2 = "";
         AV41ConfiguracaoNotificacoesEmail2 = "";
         AV43DynamicFiltersSelector3 = "";
         AV45ConfiguracaoNotificacoesEmail3 = "";
         AV48Configuracaonotificacoeswwds_1_filterfulltext = "";
         AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = "";
         AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = "";
         AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = "";
         AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = "";
         AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = "";
         AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = "";
         AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = "";
         AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = "";
         lV48Configuracaonotificacoeswwds_1_filterfulltext = "";
         lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = "";
         lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = "";
         lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = "";
         lV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = "";
         A492ConfiguracaoNotificacoesEmail = "";
         P00AF2_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         P00AF2_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         P00AF2_A491ConfiguracaoNotificacoesId = new int[1] ;
         AV17Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracaonotificacoeswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AF2_A492ConfiguracaoNotificacoesEmail, P00AF2_n492ConfiguracaoNotificacoesEmail, P00AF2_A491ConfiguracaoNotificacoesId
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
      private short AV50Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ;
      private short AV54Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ;
      private short AV58Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ;
      private int AV46GXV1 ;
      private int A491ConfiguracaoNotificacoesId ;
      private long AV22count ;
      private bool returnInSub ;
      private bool AV38DynamicFiltersEnabled2 ;
      private bool AV42DynamicFiltersEnabled3 ;
      private bool AV52Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ;
      private bool AV56Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ;
      private bool BRKAF2 ;
      private bool n492ConfiguracaoNotificacoesEmail ;
      private string AV31OptionsJson ;
      private string AV32OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV28DDOName ;
      private string AV29SearchTxtParms ;
      private string AV30SearchTxtTo ;
      private string AV12SearchTxt ;
      private string AV34FilterFullText ;
      private string AV10TFConfiguracaoNotificacoesEmail ;
      private string AV11TFConfiguracaoNotificacoesEmail_Sel ;
      private string AV35DynamicFiltersSelector1 ;
      private string AV37ConfiguracaoNotificacoesEmail1 ;
      private string AV39DynamicFiltersSelector2 ;
      private string AV41ConfiguracaoNotificacoesEmail2 ;
      private string AV43DynamicFiltersSelector3 ;
      private string AV45ConfiguracaoNotificacoesEmail3 ;
      private string AV48Configuracaonotificacoeswwds_1_filterfulltext ;
      private string AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ;
      private string AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ;
      private string AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ;
      private string AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ;
      private string AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ;
      private string AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ;
      private string AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ;
      private string AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ;
      private string lV48Configuracaonotificacoeswwds_1_filterfulltext ;
      private string lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ;
      private string lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ;
      private string lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ;
      private string lV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ;
      private string A492ConfiguracaoNotificacoesEmail ;
      private string AV17Option ;
      private IGxSession AV23Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV18Options ;
      private GxSimpleCollection<string> AV20OptionsDesc ;
      private GxSimpleCollection<string> AV21OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV25GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV26GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00AF2_A492ConfiguracaoNotificacoesEmail ;
      private bool[] P00AF2_n492ConfiguracaoNotificacoesEmail ;
      private int[] P00AF2_A491ConfiguracaoNotificacoesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class configuracaonotificacoeswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AF2( IGxContext context ,
                                             string AV48Configuracaonotificacoeswwds_1_filterfulltext ,
                                             string AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                             short AV50Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                             string AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                             bool AV52Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                             string AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                             short AV54Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                             string AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                             bool AV56Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                             string AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                             short AV58Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                             string AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                             string AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                             string AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                             string A492ConfiguracaoNotificacoesEmail )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ConfiguracaoNotificacoesEmail, ConfiguracaoNotificacoesId FROM ConfiguracaoNotificacoes";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracaoNotificacoesEmail like '%' || :lV48Configuracaonotificacoeswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV50Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV50Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV52Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV54Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV52Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV54Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV56Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV58Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV56Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV58Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ! ( StringUtil.StrCmp(AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail = ( :AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracaoNotificacoesEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ConfiguracaoNotificacoesEmail";
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
                     return conditional_P00AF2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] );
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
          Object[] prmP00AF2;
          prmP00AF2 = new Object[] {
          new ParDef("lV48Configuracaonotificacoeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV51Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV55Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV59Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV60Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese",GXType.VarChar,100,0) ,
          new ParDef("AV61Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
