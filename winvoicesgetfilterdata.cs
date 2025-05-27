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
   public class winvoicesgetfilterdata : GXProcedure
   {
      public winvoicesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public winvoicesgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_NOTAFISCALNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALNUMEROOPTIONS' */
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
         if ( StringUtil.StrCmp(AV23Session.Get("WInvoicesGridState"), "") == 0 )
         {
            AV25GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WInvoicesGridState"), null, "", "");
         }
         else
         {
            AV25GridState.FromXml(AV23Session.Get("WInvoicesGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV34FilterFullText = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV10TFNotaFiscalNumero = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV11TFNotaFiscalNumero_Sel = AV26GridStateFilterValue.gxTpr_Value;
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(1));
            AV35DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV35DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
            {
               AV36NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV37DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(2));
               AV38DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV38DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
               {
                  AV39NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               if ( AV25GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV40DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV25GridState.gxTpr_Dynamicfilters.Item(3));
                  AV41DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV41DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
                  {
                     AV42NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADNOTAFISCALNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV10TFNotaFiscalNumero = AV12SearchTxt;
         AV11TFNotaFiscalNumero_Sel = "";
         AV45Winvoicesds_1_filterfulltext = AV34FilterFullText;
         AV46Winvoicesds_2_dynamicfiltersselector1 = AV35DynamicFiltersSelector1;
         AV47Winvoicesds_3_notafiscaluf1 = AV36NotaFiscalUF1;
         AV48Winvoicesds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV49Winvoicesds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV50Winvoicesds_6_notafiscaluf2 = AV39NotaFiscalUF2;
         AV51Winvoicesds_7_dynamicfiltersenabled3 = AV40DynamicFiltersEnabled3;
         AV52Winvoicesds_8_dynamicfiltersselector3 = AV41DynamicFiltersSelector3;
         AV53Winvoicesds_9_notafiscaluf3 = AV42NotaFiscalUF3;
         AV54Winvoicesds_10_tfnotafiscalnumero = AV10TFNotaFiscalNumero;
         AV55Winvoicesds_11_tfnotafiscalnumero_sel = AV11TFNotaFiscalNumero_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Winvoicesds_1_filterfulltext ,
                                              AV46Winvoicesds_2_dynamicfiltersselector1 ,
                                              AV47Winvoicesds_3_notafiscaluf1 ,
                                              AV48Winvoicesds_4_dynamicfiltersenabled2 ,
                                              AV49Winvoicesds_5_dynamicfiltersselector2 ,
                                              AV50Winvoicesds_6_notafiscaluf2 ,
                                              AV51Winvoicesds_7_dynamicfiltersenabled3 ,
                                              AV52Winvoicesds_8_dynamicfiltersselector3 ,
                                              AV53Winvoicesds_9_notafiscaluf3 ,
                                              AV55Winvoicesds_11_tfnotafiscalnumero_sel ,
                                              AV54Winvoicesds_10_tfnotafiscalnumero ,
                                              A799NotaFiscalNumero ,
                                              A795NotaFiscalUF } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV45Winvoicesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Winvoicesds_1_filterfulltext), "%", "");
         lV54Winvoicesds_10_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV54Winvoicesds_10_tfnotafiscalnumero), "%", "");
         /* Using cursor P00DF2 */
         pr_default.execute(0, new Object[] {lV45Winvoicesds_1_filterfulltext, AV47Winvoicesds_3_notafiscaluf1, AV50Winvoicesds_6_notafiscaluf2, AV53Winvoicesds_9_notafiscaluf3, lV54Winvoicesds_10_tfnotafiscalnumero, AV55Winvoicesds_11_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDF2 = false;
            A799NotaFiscalNumero = P00DF2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DF2_n799NotaFiscalNumero[0];
            A795NotaFiscalUF = P00DF2_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DF2_n795NotaFiscalUF[0];
            A794NotaFiscalId = P00DF2_A794NotaFiscalId[0];
            AV22count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DF2_A799NotaFiscalNumero[0], A799NotaFiscalNumero) == 0 ) )
            {
               BRKDF2 = false;
               A794NotaFiscalId = P00DF2_A794NotaFiscalId[0];
               AV22count = (long)(AV22count+1);
               BRKDF2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV13SkipItems) )
            {
               AV17Option = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? "<#Empty#>" : A799NotaFiscalNumero);
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
            if ( ! BRKDF2 )
            {
               BRKDF2 = true;
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
         AV10TFNotaFiscalNumero = "";
         AV11TFNotaFiscalNumero_Sel = "";
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV35DynamicFiltersSelector1 = "";
         AV38DynamicFiltersSelector2 = "";
         AV41DynamicFiltersSelector3 = "";
         AV45Winvoicesds_1_filterfulltext = "";
         AV46Winvoicesds_2_dynamicfiltersselector1 = "";
         AV49Winvoicesds_5_dynamicfiltersselector2 = "";
         AV52Winvoicesds_8_dynamicfiltersselector3 = "";
         AV54Winvoicesds_10_tfnotafiscalnumero = "";
         AV55Winvoicesds_11_tfnotafiscalnumero_sel = "";
         lV45Winvoicesds_1_filterfulltext = "";
         lV54Winvoicesds_10_tfnotafiscalnumero = "";
         A799NotaFiscalNumero = "";
         P00DF2_A799NotaFiscalNumero = new string[] {""} ;
         P00DF2_n799NotaFiscalNumero = new bool[] {false} ;
         P00DF2_A795NotaFiscalUF = new short[1] ;
         P00DF2_n795NotaFiscalUF = new bool[] {false} ;
         P00DF2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         A794NotaFiscalId = Guid.Empty;
         AV17Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.winvoicesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DF2_A799NotaFiscalNumero, P00DF2_n799NotaFiscalNumero, P00DF2_A795NotaFiscalUF, P00DF2_n795NotaFiscalUF, P00DF2_A794NotaFiscalId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15MaxItems ;
      private short AV14PageIndex ;
      private short AV13SkipItems ;
      private short AV36NotaFiscalUF1 ;
      private short AV39NotaFiscalUF2 ;
      private short AV42NotaFiscalUF3 ;
      private short AV47Winvoicesds_3_notafiscaluf1 ;
      private short AV50Winvoicesds_6_notafiscaluf2 ;
      private short AV53Winvoicesds_9_notafiscaluf3 ;
      private short A795NotaFiscalUF ;
      private int AV43GXV1 ;
      private long AV22count ;
      private bool returnInSub ;
      private bool AV37DynamicFiltersEnabled2 ;
      private bool AV40DynamicFiltersEnabled3 ;
      private bool AV48Winvoicesds_4_dynamicfiltersenabled2 ;
      private bool AV51Winvoicesds_7_dynamicfiltersenabled3 ;
      private bool BRKDF2 ;
      private bool n799NotaFiscalNumero ;
      private bool n795NotaFiscalUF ;
      private string AV31OptionsJson ;
      private string AV32OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV28DDOName ;
      private string AV29SearchTxtParms ;
      private string AV30SearchTxtTo ;
      private string AV12SearchTxt ;
      private string AV34FilterFullText ;
      private string AV10TFNotaFiscalNumero ;
      private string AV11TFNotaFiscalNumero_Sel ;
      private string AV35DynamicFiltersSelector1 ;
      private string AV38DynamicFiltersSelector2 ;
      private string AV41DynamicFiltersSelector3 ;
      private string AV45Winvoicesds_1_filterfulltext ;
      private string AV46Winvoicesds_2_dynamicfiltersselector1 ;
      private string AV49Winvoicesds_5_dynamicfiltersselector2 ;
      private string AV52Winvoicesds_8_dynamicfiltersselector3 ;
      private string AV54Winvoicesds_10_tfnotafiscalnumero ;
      private string AV55Winvoicesds_11_tfnotafiscalnumero_sel ;
      private string lV45Winvoicesds_1_filterfulltext ;
      private string lV54Winvoicesds_10_tfnotafiscalnumero ;
      private string A799NotaFiscalNumero ;
      private string AV17Option ;
      private Guid A794NotaFiscalId ;
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
      private string[] P00DF2_A799NotaFiscalNumero ;
      private bool[] P00DF2_n799NotaFiscalNumero ;
      private short[] P00DF2_A795NotaFiscalUF ;
      private bool[] P00DF2_n795NotaFiscalUF ;
      private Guid[] P00DF2_A794NotaFiscalId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class winvoicesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DF2( IGxContext context ,
                                             string AV45Winvoicesds_1_filterfulltext ,
                                             string AV46Winvoicesds_2_dynamicfiltersselector1 ,
                                             short AV47Winvoicesds_3_notafiscaluf1 ,
                                             bool AV48Winvoicesds_4_dynamicfiltersenabled2 ,
                                             string AV49Winvoicesds_5_dynamicfiltersselector2 ,
                                             short AV50Winvoicesds_6_notafiscaluf2 ,
                                             bool AV51Winvoicesds_7_dynamicfiltersenabled3 ,
                                             string AV52Winvoicesds_8_dynamicfiltersselector3 ,
                                             short AV53Winvoicesds_9_notafiscaluf3 ,
                                             string AV55Winvoicesds_11_tfnotafiscalnumero_sel ,
                                             string AV54Winvoicesds_10_tfnotafiscalnumero ,
                                             string A799NotaFiscalNumero ,
                                             short A795NotaFiscalUF )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT NotaFiscalNumero, NotaFiscalUF, NotaFiscalId FROM NotaFiscal";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Winvoicesds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( NotaFiscalNumero like '%' || :lV45Winvoicesds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Winvoicesds_2_dynamicfiltersselector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV47Winvoicesds_3_notafiscaluf1) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV47Winvoicesds_3_notafiscaluf1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV48Winvoicesds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV49Winvoicesds_5_dynamicfiltersselector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV50Winvoicesds_6_notafiscaluf2) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV50Winvoicesds_6_notafiscaluf2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV51Winvoicesds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Winvoicesds_8_dynamicfiltersselector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV53Winvoicesds_9_notafiscaluf3) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV53Winvoicesds_9_notafiscaluf3)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Winvoicesds_11_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Winvoicesds_10_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero like :lV54Winvoicesds_10_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Winvoicesds_11_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV55Winvoicesds_11_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero = ( :AV55Winvoicesds_11_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Winvoicesds_11_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY NotaFiscalNumero";
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
                     return conditional_P00DF2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmP00DF2;
          prmP00DF2 = new Object[] {
          new ParDef("lV45Winvoicesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV47Winvoicesds_3_notafiscaluf1",GXType.Int16,4,0) ,
          new ParDef("AV50Winvoicesds_6_notafiscaluf2",GXType.Int16,4,0) ,
          new ParDef("AV53Winvoicesds_9_notafiscaluf3",GXType.Int16,4,0) ,
          new ParDef("lV54Winvoicesds_10_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV55Winvoicesds_11_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
