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
   public class serasaprotestoswwgetfilterdata : GXProcedure
   {
      public serasaprotestoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaprotestoswwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERASAPROTESTOSCARTORIO") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAPROTESTOSCARTORIOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERASAPROTESTOSCIDADE") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAPROTESTOSCIDADEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("SerasaProtestosWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SerasaProtestosWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("SerasaProtestosWWGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSDATA") == 0 )
            {
               AV10TFSerasaProtestosData = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV11TFSerasaProtestosData_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSVALOR") == 0 )
            {
               AV12TFSerasaProtestosValor = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV13TFSerasaProtestosValor_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCARTORIO") == 0 )
            {
               AV14TFSerasaProtestosCartorio = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCARTORIO_SEL") == 0 )
            {
               AV15TFSerasaProtestosCartorio_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCIDADE") == 0 )
            {
               AV16TFSerasaProtestosCidade = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCIDADE_SEL") == 0 )
            {
               AV17TFSerasaProtestosCidade_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&SERASAID") == 0 )
            {
               AV40SerasaId = (int)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSERASAPROTESTOSCARTORIOOPTIONS' Routine */
         returnInSub = false;
         AV14TFSerasaProtestosCartorio = AV18SearchTxt;
         AV15TFSerasaProtestosCartorio_Sel = "";
         AV43Serasaprotestoswwds_1_serasaid = AV40SerasaId;
         AV44Serasaprotestoswwds_2_tfserasaprotestosdata = AV10TFSerasaProtestosData;
         AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV11TFSerasaProtestosData_To;
         AV46Serasaprotestoswwds_4_tfserasaprotestosvalor = AV12TFSerasaProtestosValor;
         AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV13TFSerasaProtestosValor_To;
         AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV14TFSerasaProtestosCartorio;
         AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV15TFSerasaProtestosCartorio_Sel;
         AV50Serasaprotestoswwds_8_tfserasaprotestoscidade = AV16TFSerasaProtestosCidade;
         AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV17TFSerasaProtestosCidade_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                              AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                              AV46Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                              AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                              AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                              AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                              AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                              AV50Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                              A712SerasaProtestosData ,
                                              A713SerasaProtestosValor ,
                                              A714SerasaProtestosCartorio ,
                                              A715SerasaProtestosCidade ,
                                              AV43Serasaprotestoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio = StringUtil.Concat( StringUtil.RTrim( AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio), "%", "");
         lV50Serasaprotestoswwds_8_tfserasaprotestoscidade = StringUtil.Concat( StringUtil.RTrim( AV50Serasaprotestoswwds_8_tfserasaprotestoscidade), "%", "");
         /* Using cursor P00D02 */
         pr_default.execute(0, new Object[] {AV43Serasaprotestoswwds_1_serasaid, AV44Serasaprotestoswwds_2_tfserasaprotestosdata, AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to, AV46Serasaprotestoswwds_4_tfserasaprotestosvalor, AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to, lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio, AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, lV50Serasaprotestoswwds_8_tfserasaprotestoscidade, AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD02 = false;
            A662SerasaId = P00D02_A662SerasaId[0];
            n662SerasaId = P00D02_n662SerasaId[0];
            A714SerasaProtestosCartorio = P00D02_A714SerasaProtestosCartorio[0];
            n714SerasaProtestosCartorio = P00D02_n714SerasaProtestosCartorio[0];
            A715SerasaProtestosCidade = P00D02_A715SerasaProtestosCidade[0];
            n715SerasaProtestosCidade = P00D02_n715SerasaProtestosCidade[0];
            A713SerasaProtestosValor = P00D02_A713SerasaProtestosValor[0];
            n713SerasaProtestosValor = P00D02_n713SerasaProtestosValor[0];
            A712SerasaProtestosData = P00D02_A712SerasaProtestosData[0];
            n712SerasaProtestosData = P00D02_n712SerasaProtestosData[0];
            A711SerasaProtestosId = P00D02_A711SerasaProtestosId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00D02_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D02_A714SerasaProtestosCartorio[0], A714SerasaProtestosCartorio) == 0 ) )
            {
               BRKD02 = false;
               A711SerasaProtestosId = P00D02_A711SerasaProtestosId[0];
               AV28count = (long)(AV28count+1);
               BRKD02 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A714SerasaProtestosCartorio)) ? "<#Empty#>" : A714SerasaProtestosCartorio);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKD02 )
            {
               BRKD02 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSERASAPROTESTOSCIDADEOPTIONS' Routine */
         returnInSub = false;
         AV16TFSerasaProtestosCidade = AV18SearchTxt;
         AV17TFSerasaProtestosCidade_Sel = "";
         AV43Serasaprotestoswwds_1_serasaid = AV40SerasaId;
         AV44Serasaprotestoswwds_2_tfserasaprotestosdata = AV10TFSerasaProtestosData;
         AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV11TFSerasaProtestosData_To;
         AV46Serasaprotestoswwds_4_tfserasaprotestosvalor = AV12TFSerasaProtestosValor;
         AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV13TFSerasaProtestosValor_To;
         AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV14TFSerasaProtestosCartorio;
         AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV15TFSerasaProtestosCartorio_Sel;
         AV50Serasaprotestoswwds_8_tfserasaprotestoscidade = AV16TFSerasaProtestosCidade;
         AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV17TFSerasaProtestosCidade_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                              AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                              AV46Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                              AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                              AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                              AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                              AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                              AV50Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                              A712SerasaProtestosData ,
                                              A713SerasaProtestosValor ,
                                              A714SerasaProtestosCartorio ,
                                              A715SerasaProtestosCidade ,
                                              AV43Serasaprotestoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio = StringUtil.Concat( StringUtil.RTrim( AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio), "%", "");
         lV50Serasaprotestoswwds_8_tfserasaprotestoscidade = StringUtil.Concat( StringUtil.RTrim( AV50Serasaprotestoswwds_8_tfserasaprotestoscidade), "%", "");
         /* Using cursor P00D03 */
         pr_default.execute(1, new Object[] {AV43Serasaprotestoswwds_1_serasaid, AV44Serasaprotestoswwds_2_tfserasaprotestosdata, AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to, AV46Serasaprotestoswwds_4_tfserasaprotestosvalor, AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to, lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio, AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, lV50Serasaprotestoswwds_8_tfserasaprotestoscidade, AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKD04 = false;
            A662SerasaId = P00D03_A662SerasaId[0];
            n662SerasaId = P00D03_n662SerasaId[0];
            A715SerasaProtestosCidade = P00D03_A715SerasaProtestosCidade[0];
            n715SerasaProtestosCidade = P00D03_n715SerasaProtestosCidade[0];
            A714SerasaProtestosCartorio = P00D03_A714SerasaProtestosCartorio[0];
            n714SerasaProtestosCartorio = P00D03_n714SerasaProtestosCartorio[0];
            A713SerasaProtestosValor = P00D03_A713SerasaProtestosValor[0];
            n713SerasaProtestosValor = P00D03_n713SerasaProtestosValor[0];
            A712SerasaProtestosData = P00D03_A712SerasaProtestosData[0];
            n712SerasaProtestosData = P00D03_n712SerasaProtestosData[0];
            A711SerasaProtestosId = P00D03_A711SerasaProtestosId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00D03_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D03_A715SerasaProtestosCidade[0], A715SerasaProtestosCidade) == 0 ) )
            {
               BRKD04 = false;
               A711SerasaProtestosId = P00D03_A711SerasaProtestosId[0];
               AV28count = (long)(AV28count+1);
               BRKD04 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A715SerasaProtestosCidade)) ? "<#Empty#>" : A715SerasaProtestosCidade);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKD04 )
            {
               BRKD04 = true;
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFSerasaProtestosData = DateTime.MinValue;
         AV11TFSerasaProtestosData_To = DateTime.MinValue;
         AV14TFSerasaProtestosCartorio = "";
         AV15TFSerasaProtestosCartorio_Sel = "";
         AV16TFSerasaProtestosCidade = "";
         AV17TFSerasaProtestosCidade_Sel = "";
         AV44Serasaprotestoswwds_2_tfserasaprotestosdata = DateTime.MinValue;
         AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to = DateTime.MinValue;
         AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio = "";
         AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = "";
         AV50Serasaprotestoswwds_8_tfserasaprotestoscidade = "";
         AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = "";
         lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio = "";
         lV50Serasaprotestoswwds_8_tfserasaprotestoscidade = "";
         A712SerasaProtestosData = DateTime.MinValue;
         A714SerasaProtestosCartorio = "";
         A715SerasaProtestosCidade = "";
         P00D02_A662SerasaId = new int[1] ;
         P00D02_n662SerasaId = new bool[] {false} ;
         P00D02_A714SerasaProtestosCartorio = new string[] {""} ;
         P00D02_n714SerasaProtestosCartorio = new bool[] {false} ;
         P00D02_A715SerasaProtestosCidade = new string[] {""} ;
         P00D02_n715SerasaProtestosCidade = new bool[] {false} ;
         P00D02_A713SerasaProtestosValor = new decimal[1] ;
         P00D02_n713SerasaProtestosValor = new bool[] {false} ;
         P00D02_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         P00D02_n712SerasaProtestosData = new bool[] {false} ;
         P00D02_A711SerasaProtestosId = new int[1] ;
         AV23Option = "";
         P00D03_A662SerasaId = new int[1] ;
         P00D03_n662SerasaId = new bool[] {false} ;
         P00D03_A715SerasaProtestosCidade = new string[] {""} ;
         P00D03_n715SerasaProtestosCidade = new bool[] {false} ;
         P00D03_A714SerasaProtestosCartorio = new string[] {""} ;
         P00D03_n714SerasaProtestosCartorio = new bool[] {false} ;
         P00D03_A713SerasaProtestosValor = new decimal[1] ;
         P00D03_n713SerasaProtestosValor = new bool[] {false} ;
         P00D03_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         P00D03_n712SerasaProtestosData = new bool[] {false} ;
         P00D03_A711SerasaProtestosId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaprotestoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D02_A662SerasaId, P00D02_n662SerasaId, P00D02_A714SerasaProtestosCartorio, P00D02_n714SerasaProtestosCartorio, P00D02_A715SerasaProtestosCidade, P00D02_n715SerasaProtestosCidade, P00D02_A713SerasaProtestosValor, P00D02_n713SerasaProtestosValor, P00D02_A712SerasaProtestosData, P00D02_n712SerasaProtestosData,
               P00D02_A711SerasaProtestosId
               }
               , new Object[] {
               P00D03_A662SerasaId, P00D03_n662SerasaId, P00D03_A715SerasaProtestosCidade, P00D03_n715SerasaProtestosCidade, P00D03_A714SerasaProtestosCartorio, P00D03_n714SerasaProtestosCartorio, P00D03_A713SerasaProtestosValor, P00D03_n713SerasaProtestosValor, P00D03_A712SerasaProtestosData, P00D03_n712SerasaProtestosData,
               P00D03_A711SerasaProtestosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private int AV41GXV1 ;
      private int AV40SerasaId ;
      private int AV43Serasaprotestoswwds_1_serasaid ;
      private int A662SerasaId ;
      private int A711SerasaProtestosId ;
      private long AV28count ;
      private decimal AV12TFSerasaProtestosValor ;
      private decimal AV13TFSerasaProtestosValor_To ;
      private decimal AV46Serasaprotestoswwds_4_tfserasaprotestosvalor ;
      private decimal AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to ;
      private decimal A713SerasaProtestosValor ;
      private DateTime AV10TFSerasaProtestosData ;
      private DateTime AV11TFSerasaProtestosData_To ;
      private DateTime AV44Serasaprotestoswwds_2_tfserasaprotestosdata ;
      private DateTime AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to ;
      private DateTime A712SerasaProtestosData ;
      private bool returnInSub ;
      private bool BRKD02 ;
      private bool n662SerasaId ;
      private bool n714SerasaProtestosCartorio ;
      private bool n715SerasaProtestosCidade ;
      private bool n713SerasaProtestosValor ;
      private bool n712SerasaProtestosData ;
      private bool BRKD04 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV14TFSerasaProtestosCartorio ;
      private string AV15TFSerasaProtestosCartorio_Sel ;
      private string AV16TFSerasaProtestosCidade ;
      private string AV17TFSerasaProtestosCidade_Sel ;
      private string AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio ;
      private string AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ;
      private string AV50Serasaprotestoswwds_8_tfserasaprotestoscidade ;
      private string AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ;
      private string lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio ;
      private string lV50Serasaprotestoswwds_8_tfserasaprotestoscidade ;
      private string A714SerasaProtestosCartorio ;
      private string A715SerasaProtestosCidade ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00D02_A662SerasaId ;
      private bool[] P00D02_n662SerasaId ;
      private string[] P00D02_A714SerasaProtestosCartorio ;
      private bool[] P00D02_n714SerasaProtestosCartorio ;
      private string[] P00D02_A715SerasaProtestosCidade ;
      private bool[] P00D02_n715SerasaProtestosCidade ;
      private decimal[] P00D02_A713SerasaProtestosValor ;
      private bool[] P00D02_n713SerasaProtestosValor ;
      private DateTime[] P00D02_A712SerasaProtestosData ;
      private bool[] P00D02_n712SerasaProtestosData ;
      private int[] P00D02_A711SerasaProtestosId ;
      private int[] P00D03_A662SerasaId ;
      private bool[] P00D03_n662SerasaId ;
      private string[] P00D03_A715SerasaProtestosCidade ;
      private bool[] P00D03_n715SerasaProtestosCidade ;
      private string[] P00D03_A714SerasaProtestosCartorio ;
      private bool[] P00D03_n714SerasaProtestosCartorio ;
      private decimal[] P00D03_A713SerasaProtestosValor ;
      private bool[] P00D03_n713SerasaProtestosValor ;
      private DateTime[] P00D03_A712SerasaProtestosData ;
      private bool[] P00D03_n712SerasaProtestosData ;
      private int[] P00D03_A711SerasaProtestosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class serasaprotestoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D02( IGxContext context ,
                                             DateTime AV44Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                             DateTime AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                             decimal AV46Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                             decimal AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                             string AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                             string AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                             string AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                             string AV50Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                             DateTime A712SerasaProtestosData ,
                                             decimal A713SerasaProtestosValor ,
                                             string A714SerasaProtestosCartorio ,
                                             string A715SerasaProtestosCidade ,
                                             int AV43Serasaprotestoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaProtestosCartorio, SerasaProtestosCidade, SerasaProtestosValor, SerasaProtestosData, SerasaProtestosId FROM SerasaProtestos";
         AddWhere(sWhereString, "(SerasaId = :AV43Serasaprotestoswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV44Serasaprotestoswwds_2_tfserasaprotestosdata) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData >= :AV44Serasaprotestoswwds_2_tfserasaprotestosdata)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData <= :AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV46Serasaprotestoswwds_4_tfserasaprotestosvalor) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor >= :AV46Serasaprotestoswwds_4_tfserasaprotestosvalor)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor <= :AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio like :lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ! ( StringUtil.StrCmp(AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio = ( :AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCartorio))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaprotestoswwds_8_tfserasaprotestoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade like :lV50Serasaprotestoswwds_8_tfserasaprotestoscidade)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ! ( StringUtil.StrCmp(AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade = ( :AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCidade))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaProtestosCartorio";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00D03( IGxContext context ,
                                             DateTime AV44Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                             DateTime AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                             decimal AV46Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                             decimal AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                             string AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                             string AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                             string AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                             string AV50Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                             DateTime A712SerasaProtestosData ,
                                             decimal A713SerasaProtestosValor ,
                                             string A714SerasaProtestosCartorio ,
                                             string A715SerasaProtestosCidade ,
                                             int AV43Serasaprotestoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaProtestosCidade, SerasaProtestosCartorio, SerasaProtestosValor, SerasaProtestosData, SerasaProtestosId FROM SerasaProtestos";
         AddWhere(sWhereString, "(SerasaId = :AV43Serasaprotestoswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV44Serasaprotestoswwds_2_tfserasaprotestosdata) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData >= :AV44Serasaprotestoswwds_2_tfserasaprotestosdata)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData <= :AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV46Serasaprotestoswwds_4_tfserasaprotestosvalor) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor >= :AV46Serasaprotestoswwds_4_tfserasaprotestosvalor)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor <= :AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaprotestoswwds_6_tfserasaprotestoscartorio)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio like :lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ! ( StringUtil.StrCmp(AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio = ( :AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCartorio))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaprotestoswwds_8_tfserasaprotestoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade like :lV50Serasaprotestoswwds_8_tfserasaprotestoscidade)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ! ( StringUtil.StrCmp(AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade = ( :AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCidade))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaProtestosCidade";
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
                     return conditional_P00D02(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] );
               case 1 :
                     return conditional_P00D03(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] );
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
          Object[] prmP00D02;
          prmP00D02 = new Object[] {
          new ParDef("AV43Serasaprotestoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV44Serasaprotestoswwds_2_tfserasaprotestosdata",GXType.Date,8,0) ,
          new ParDef("AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to",GXType.Date,8,0) ,
          new ParDef("AV46Serasaprotestoswwds_4_tfserasaprotestosvalor",GXType.Number,18,2) ,
          new ParDef("AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to",GXType.Number,18,2) ,
          new ParDef("lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaprotestoswwds_8_tfserasaprotestoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D03;
          prmP00D03 = new Object[] {
          new ParDef("AV43Serasaprotestoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV44Serasaprotestoswwds_2_tfserasaprotestosdata",GXType.Date,8,0) ,
          new ParDef("AV45Serasaprotestoswwds_3_tfserasaprotestosdata_to",GXType.Date,8,0) ,
          new ParDef("AV46Serasaprotestoswwds_4_tfserasaprotestosvalor",GXType.Number,18,2) ,
          new ParDef("AV47Serasaprotestoswwds_5_tfserasaprotestosvalor_to",GXType.Number,18,2) ,
          new ParDef("lV48Serasaprotestoswwds_6_tfserasaprotestoscartorio",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaprotestoswwds_8_tfserasaprotestoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaprotestoswwds_9_tfserasaprotestoscidade_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D03", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D03,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
