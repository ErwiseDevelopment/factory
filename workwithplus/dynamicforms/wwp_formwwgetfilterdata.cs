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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_formwwgetfilterdata : GXProcedure
   {
      public wwp_formwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV25Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV10TFWWPFormReferenceName = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV11TFWWPFormReferenceName_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV12TFWWPFormTitle = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV13TFWWPFormTitle_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV37WWPFormType = (short)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV38WWPFormIsForDynamicValidations = BooleanUtil.Val( AV28GridStateFilterValue.gxTpr_Value);
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFWWPFormReferenceName = AV14SearchTxt;
         AV11TFWWPFormReferenceName_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV36FilterFullText ,
                                              AV11TFWWPFormReferenceName_Sel ,
                                              AV10TFWWPFormReferenceName ,
                                              AV13TFWWPFormTitle_Sel ,
                                              AV12TFWWPFormTitle ,
                                              AV37WWPFormType ,
                                              AV38WWPFormIsForDynamicValidations ,
                                              A96WWPFormReferenceName ,
                                              A97WWPFormTitle ,
                                              A292WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              A95WWPFormVersionNumber ,
                                              A107WWPFormLatestVersionNumber ,
                                              A290WWPFormType } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV36FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV36FilterFullText), "%", "");
         lV36FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV36FilterFullText), "%", "");
         lV10TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV10TFWWPFormReferenceName), "%", "");
         lV12TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV12TFWWPFormTitle), "%", "");
         /* Using cursor P007T3 */
         pr_default.execute(0, new Object[] {AV37WWPFormType, lV36FilterFullText, lV36FilterFullText, lV10TFWWPFormReferenceName, AV11TFWWPFormReferenceName_Sel, lV12TFWWPFormTitle, AV13TFWWPFormTitle_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7T2 = false;
            A290WWPFormType = P007T3_A290WWPFormType[0];
            A96WWPFormReferenceName = P007T3_A96WWPFormReferenceName[0];
            A292WWPFormIsForDynamicValidations = P007T3_A292WWPFormIsForDynamicValidations[0];
            A95WWPFormVersionNumber = P007T3_A95WWPFormVersionNumber[0];
            A97WWPFormTitle = P007T3_A97WWPFormTitle[0];
            A40000GXC1 = P007T3_A40000GXC1[0];
            n40000GXC1 = P007T3_n40000GXC1[0];
            A94WWPFormId = P007T3_A94WWPFormId[0];
            A40000GXC1 = P007T3_A40000GXC1[0];
            n40000GXC1 = P007T3_n40000GXC1[0];
            GXt_int1 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
            A107WWPFormLatestVersionNumber = GXt_int1;
            if ( A95WWPFormVersionNumber == A107WWPFormLatestVersionNumber )
            {
               AV24count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P007T3_A290WWPFormType[0] == A290WWPFormType ) && ( StringUtil.StrCmp(P007T3_A96WWPFormReferenceName[0], A96WWPFormReferenceName) == 0 ) )
               {
                  BRK7T2 = false;
                  A95WWPFormVersionNumber = P007T3_A95WWPFormVersionNumber[0];
                  A94WWPFormId = P007T3_A94WWPFormId[0];
                  AV24count = (long)(AV24count+1);
                  BRK7T2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV15SkipItems) )
               {
                  AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A96WWPFormReferenceName)) ? "<#Empty#>" : A96WWPFormReferenceName);
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
            }
            if ( ! BRK7T2 )
            {
               BRK7T2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV12TFWWPFormTitle = AV14SearchTxt;
         AV13TFWWPFormTitle_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV36FilterFullText ,
                                              AV11TFWWPFormReferenceName_Sel ,
                                              AV10TFWWPFormReferenceName ,
                                              AV13TFWWPFormTitle_Sel ,
                                              AV12TFWWPFormTitle ,
                                              AV37WWPFormType ,
                                              AV38WWPFormIsForDynamicValidations ,
                                              A96WWPFormReferenceName ,
                                              A97WWPFormTitle ,
                                              A292WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              A95WWPFormVersionNumber ,
                                              A107WWPFormLatestVersionNumber ,
                                              A290WWPFormType } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV36FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV36FilterFullText), "%", "");
         lV36FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV36FilterFullText), "%", "");
         lV10TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV10TFWWPFormReferenceName), "%", "");
         lV12TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV12TFWWPFormTitle), "%", "");
         /* Using cursor P007T5 */
         pr_default.execute(1, new Object[] {AV37WWPFormType, lV36FilterFullText, lV36FilterFullText, lV10TFWWPFormReferenceName, AV11TFWWPFormReferenceName_Sel, lV12TFWWPFormTitle, AV13TFWWPFormTitle_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7T4 = false;
            A290WWPFormType = P007T5_A290WWPFormType[0];
            A97WWPFormTitle = P007T5_A97WWPFormTitle[0];
            A292WWPFormIsForDynamicValidations = P007T5_A292WWPFormIsForDynamicValidations[0];
            A95WWPFormVersionNumber = P007T5_A95WWPFormVersionNumber[0];
            A96WWPFormReferenceName = P007T5_A96WWPFormReferenceName[0];
            A40000GXC1 = P007T5_A40000GXC1[0];
            n40000GXC1 = P007T5_n40000GXC1[0];
            A94WWPFormId = P007T5_A94WWPFormId[0];
            A40000GXC1 = P007T5_A40000GXC1[0];
            n40000GXC1 = P007T5_n40000GXC1[0];
            GXt_int1 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
            A107WWPFormLatestVersionNumber = GXt_int1;
            if ( A95WWPFormVersionNumber == A107WWPFormLatestVersionNumber )
            {
               AV24count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P007T5_A290WWPFormType[0] == A290WWPFormType ) && ( StringUtil.StrCmp(P007T5_A97WWPFormTitle[0], A97WWPFormTitle) == 0 ) )
               {
                  BRK7T4 = false;
                  A95WWPFormVersionNumber = P007T5_A95WWPFormVersionNumber[0];
                  A94WWPFormId = P007T5_A94WWPFormId[0];
                  AV24count = (long)(AV24count+1);
                  BRK7T4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV15SkipItems) )
               {
                  AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A97WWPFormTitle)) ? "<#Empty#>" : A97WWPFormTitle);
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
            }
            if ( ! BRK7T4 )
            {
               BRK7T4 = true;
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
         AV10TFWWPFormReferenceName = "";
         AV11TFWWPFormReferenceName_Sel = "";
         AV12TFWWPFormTitle = "";
         AV13TFWWPFormTitle_Sel = "";
         lV36FilterFullText = "";
         lV10TFWWPFormReferenceName = "";
         lV12TFWWPFormTitle = "";
         A96WWPFormReferenceName = "";
         A97WWPFormTitle = "";
         P007T3_A290WWPFormType = new short[1] ;
         P007T3_A96WWPFormReferenceName = new string[] {""} ;
         P007T3_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         P007T3_A95WWPFormVersionNumber = new short[1] ;
         P007T3_A97WWPFormTitle = new string[] {""} ;
         P007T3_A40000GXC1 = new int[1] ;
         P007T3_n40000GXC1 = new bool[] {false} ;
         P007T3_A94WWPFormId = new short[1] ;
         AV19Option = "";
         P007T5_A290WWPFormType = new short[1] ;
         P007T5_A97WWPFormTitle = new string[] {""} ;
         P007T5_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         P007T5_A95WWPFormVersionNumber = new short[1] ;
         P007T5_A96WWPFormReferenceName = new string[] {""} ;
         P007T5_A40000GXC1 = new int[1] ;
         P007T5_n40000GXC1 = new bool[] {false} ;
         P007T5_A94WWPFormId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007T3_A290WWPFormType, P007T3_A96WWPFormReferenceName, P007T3_A292WWPFormIsForDynamicValidations, P007T3_A95WWPFormVersionNumber, P007T3_A97WWPFormTitle, P007T3_A40000GXC1, P007T3_n40000GXC1, P007T3_A94WWPFormId
               }
               , new Object[] {
               P007T5_A290WWPFormType, P007T5_A97WWPFormTitle, P007T5_A292WWPFormIsForDynamicValidations, P007T5_A95WWPFormVersionNumber, P007T5_A96WWPFormReferenceName, P007T5_A40000GXC1, P007T5_n40000GXC1, P007T5_A94WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV37WWPFormType ;
      private short A95WWPFormVersionNumber ;
      private short A107WWPFormLatestVersionNumber ;
      private short A290WWPFormType ;
      private short A94WWPFormId ;
      private short GXt_int1 ;
      private int AV39GXV1 ;
      private int A40000GXC1 ;
      private long AV24count ;
      private bool returnInSub ;
      private bool AV38WWPFormIsForDynamicValidations ;
      private bool A292WWPFormIsForDynamicValidations ;
      private bool BRK7T2 ;
      private bool n40000GXC1 ;
      private bool BRK7T4 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV10TFWWPFormReferenceName ;
      private string AV11TFWWPFormReferenceName_Sel ;
      private string AV12TFWWPFormTitle ;
      private string AV13TFWWPFormTitle_Sel ;
      private string lV36FilterFullText ;
      private string lV10TFWWPFormReferenceName ;
      private string lV12TFWWPFormTitle ;
      private string A96WWPFormReferenceName ;
      private string A97WWPFormTitle ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P007T3_A290WWPFormType ;
      private string[] P007T3_A96WWPFormReferenceName ;
      private bool[] P007T3_A292WWPFormIsForDynamicValidations ;
      private short[] P007T3_A95WWPFormVersionNumber ;
      private string[] P007T3_A97WWPFormTitle ;
      private int[] P007T3_A40000GXC1 ;
      private bool[] P007T3_n40000GXC1 ;
      private short[] P007T3_A94WWPFormId ;
      private short[] P007T5_A290WWPFormType ;
      private string[] P007T5_A97WWPFormTitle ;
      private bool[] P007T5_A292WWPFormIsForDynamicValidations ;
      private short[] P007T5_A95WWPFormVersionNumber ;
      private string[] P007T5_A96WWPFormReferenceName ;
      private int[] P007T5_A40000GXC1 ;
      private bool[] P007T5_n40000GXC1 ;
      private short[] P007T5_A94WWPFormId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wwp_formwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007T3( IGxContext context ,
                                             string AV36FilterFullText ,
                                             string AV11TFWWPFormReferenceName_Sel ,
                                             string AV10TFWWPFormReferenceName ,
                                             string AV13TFWWPFormTitle_Sel ,
                                             string AV12TFWWPFormTitle ,
                                             short AV37WWPFormType ,
                                             bool AV38WWPFormIsForDynamicValidations ,
                                             string A96WWPFormReferenceName ,
                                             string A97WWPFormTitle ,
                                             bool A292WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short A95WWPFormVersionNumber ,
                                             short A107WWPFormLatestVersionNumber ,
                                             short A290WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormType, T1.WWPFormReferenceName, T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormTitle, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV37WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV36FilterFullText) or ( T1.WWPFormTitle like '%' || :lV36FilterFullText))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV10TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV11TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV11TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV12TFWWPFormTitle)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV13TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV13TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ( AV37WWPFormType == 1 ) && AV38WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV37WWPFormType == 1 ) && ! AV38WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P007T5( IGxContext context ,
                                             string AV36FilterFullText ,
                                             string AV11TFWWPFormReferenceName_Sel ,
                                             string AV10TFWWPFormReferenceName ,
                                             string AV13TFWWPFormTitle_Sel ,
                                             string AV12TFWWPFormTitle ,
                                             short AV37WWPFormType ,
                                             bool AV38WWPFormIsForDynamicValidations ,
                                             string A96WWPFormReferenceName ,
                                             string A97WWPFormTitle ,
                                             bool A292WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short A95WWPFormVersionNumber ,
                                             short A107WWPFormLatestVersionNumber ,
                                             short A290WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormType, T1.WWPFormTitle, T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormReferenceName, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV37WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV36FilterFullText) or ( T1.WWPFormTitle like '%' || :lV36FilterFullText))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV10TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV11TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV11TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV12TFWWPFormTitle)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV13TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV13TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ( AV37WWPFormType == 1 ) && AV38WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV37WWPFormType == 1 ) && ! AV38WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007T3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
               case 1 :
                     return conditional_P007T5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP007T3;
          prmP007T3 = new Object[] {
          new ParDef("AV37WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV36FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV36FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV11TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV12TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV13TFWWPFormTitle_Sel",GXType.VarChar,100,0)
          };
          Object[] prmP007T5;
          prmP007T5 = new Object[] {
          new ParDef("AV37WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV36FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV36FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV11TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV12TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV13TFWWPFormTitle_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007T5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
