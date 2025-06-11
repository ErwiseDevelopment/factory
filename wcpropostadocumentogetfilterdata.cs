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
   public class wcpropostadocumentogetfilterdata : GXProcedure
   {
      public wcpropostadocumentogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcpropostadocumentogetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_PROPOSTADOCUMENTOSANEXONAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTADOCUMENTOSANEXONAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_PROPOSTADOCUMENTOSANEXOFILETYPE") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTADOCUMENTOSANEXOFILETYPEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV25Session.Get("WcPropostaDocumentoGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcPropostaDocumentoGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("WcPropostaDocumentoGridState"), null, "", "");
         }
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV37GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROPOSTADOCUMENTOSANEXONAME") == 0 )
            {
               AV10TFPropostaDocumentosAnexoName = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROPOSTADOCUMENTOSANEXONAME_SEL") == 0 )
            {
               AV11TFPropostaDocumentosAnexoName_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROPOSTADOCUMENTOSANEXOFILETYPE") == 0 )
            {
               AV12TFPropostaDocumentosAnexoFileType = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFPROPOSTADOCUMENTOSANEXOFILETYPE_SEL") == 0 )
            {
               AV13TFPropostaDocumentosAnexoFileType_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV36PropostaId = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROPOSTADOCUMENTOSANEXONAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFPropostaDocumentosAnexoName = AV14SearchTxt;
         AV11TFPropostaDocumentosAnexoName_Sel = "";
         AV39Wcpropostadocumentods_1_propostaid = AV36PropostaId;
         AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname = AV10TFPropostaDocumentosAnexoName;
         AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel = AV11TFPropostaDocumentosAnexoName_Sel;
         AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype = AV12TFPropostaDocumentosAnexoFileType;
         AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel = AV13TFPropostaDocumentosAnexoFileType_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel ,
                                              AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname ,
                                              AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel ,
                                              AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype ,
                                              A416PropostaDocumentosAnexoName ,
                                              A417PropostaDocumentosAnexoFileType ,
                                              AV39Wcpropostadocumentods_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname = StringUtil.Concat( StringUtil.RTrim( AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname), "%", "");
         lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype = StringUtil.Concat( StringUtil.RTrim( AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype), "%", "");
         /* Using cursor P009U2 */
         pr_default.execute(0, new Object[] {AV39Wcpropostadocumentods_1_propostaid, lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname, AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel, lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype, AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9U2 = false;
            A323PropostaId = P009U2_A323PropostaId[0];
            n323PropostaId = P009U2_n323PropostaId[0];
            A416PropostaDocumentosAnexoName = P009U2_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = P009U2_n416PropostaDocumentosAnexoName[0];
            A417PropostaDocumentosAnexoFileType = P009U2_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = P009U2_n417PropostaDocumentosAnexoFileType[0];
            A414PropostaDocumentosId = P009U2_A414PropostaDocumentosId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P009U2_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P009U2_A416PropostaDocumentosAnexoName[0], A416PropostaDocumentosAnexoName) == 0 ) )
            {
               BRK9U2 = false;
               A414PropostaDocumentosId = P009U2_A414PropostaDocumentosId[0];
               AV24count = (long)(AV24count+1);
               BRK9U2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A416PropostaDocumentosAnexoName)) ? "<#Empty#>" : A416PropostaDocumentosAnexoName);
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
            if ( ! BRK9U2 )
            {
               BRK9U2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROPOSTADOCUMENTOSANEXOFILETYPEOPTIONS' Routine */
         returnInSub = false;
         AV12TFPropostaDocumentosAnexoFileType = AV14SearchTxt;
         AV13TFPropostaDocumentosAnexoFileType_Sel = "";
         AV39Wcpropostadocumentods_1_propostaid = AV36PropostaId;
         AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname = AV10TFPropostaDocumentosAnexoName;
         AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel = AV11TFPropostaDocumentosAnexoName_Sel;
         AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype = AV12TFPropostaDocumentosAnexoFileType;
         AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel = AV13TFPropostaDocumentosAnexoFileType_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel ,
                                              AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname ,
                                              AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel ,
                                              AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype ,
                                              A416PropostaDocumentosAnexoName ,
                                              A417PropostaDocumentosAnexoFileType ,
                                              AV39Wcpropostadocumentods_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname = StringUtil.Concat( StringUtil.RTrim( AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname), "%", "");
         lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype = StringUtil.Concat( StringUtil.RTrim( AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype), "%", "");
         /* Using cursor P009U3 */
         pr_default.execute(1, new Object[] {AV39Wcpropostadocumentods_1_propostaid, lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname, AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel, lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype, AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9U4 = false;
            A323PropostaId = P009U3_A323PropostaId[0];
            n323PropostaId = P009U3_n323PropostaId[0];
            A417PropostaDocumentosAnexoFileType = P009U3_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = P009U3_n417PropostaDocumentosAnexoFileType[0];
            A416PropostaDocumentosAnexoName = P009U3_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = P009U3_n416PropostaDocumentosAnexoName[0];
            A414PropostaDocumentosId = P009U3_A414PropostaDocumentosId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P009U3_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P009U3_A417PropostaDocumentosAnexoFileType[0], A417PropostaDocumentosAnexoFileType) == 0 ) )
            {
               BRK9U4 = false;
               A414PropostaDocumentosId = P009U3_A414PropostaDocumentosId[0];
               AV24count = (long)(AV24count+1);
               BRK9U4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A417PropostaDocumentosAnexoFileType)) ? "<#Empty#>" : A417PropostaDocumentosAnexoFileType);
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
            if ( ! BRK9U4 )
            {
               BRK9U4 = true;
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
         AV10TFPropostaDocumentosAnexoName = "";
         AV11TFPropostaDocumentosAnexoName_Sel = "";
         AV12TFPropostaDocumentosAnexoFileType = "";
         AV13TFPropostaDocumentosAnexoFileType_Sel = "";
         AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname = "";
         AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel = "";
         AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype = "";
         AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel = "";
         lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname = "";
         lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype = "";
         A416PropostaDocumentosAnexoName = "";
         A417PropostaDocumentosAnexoFileType = "";
         P009U2_A323PropostaId = new int[1] ;
         P009U2_n323PropostaId = new bool[] {false} ;
         P009U2_A416PropostaDocumentosAnexoName = new string[] {""} ;
         P009U2_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         P009U2_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         P009U2_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         P009U2_A414PropostaDocumentosId = new int[1] ;
         AV19Option = "";
         P009U3_A323PropostaId = new int[1] ;
         P009U3_n323PropostaId = new bool[] {false} ;
         P009U3_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         P009U3_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         P009U3_A416PropostaDocumentosAnexoName = new string[] {""} ;
         P009U3_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         P009U3_A414PropostaDocumentosId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcpropostadocumentogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009U2_A323PropostaId, P009U2_n323PropostaId, P009U2_A416PropostaDocumentosAnexoName, P009U2_n416PropostaDocumentosAnexoName, P009U2_A417PropostaDocumentosAnexoFileType, P009U2_n417PropostaDocumentosAnexoFileType, P009U2_A414PropostaDocumentosId
               }
               , new Object[] {
               P009U3_A323PropostaId, P009U3_n323PropostaId, P009U3_A417PropostaDocumentosAnexoFileType, P009U3_n417PropostaDocumentosAnexoFileType, P009U3_A416PropostaDocumentosAnexoName, P009U3_n416PropostaDocumentosAnexoName, P009U3_A414PropostaDocumentosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV37GXV1 ;
      private int AV36PropostaId ;
      private int AV39Wcpropostadocumentods_1_propostaid ;
      private int A323PropostaId ;
      private int A414PropostaDocumentosId ;
      private long AV24count ;
      private bool returnInSub ;
      private bool BRK9U2 ;
      private bool n323PropostaId ;
      private bool n416PropostaDocumentosAnexoName ;
      private bool n417PropostaDocumentosAnexoFileType ;
      private bool BRK9U4 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV10TFPropostaDocumentosAnexoName ;
      private string AV11TFPropostaDocumentosAnexoName_Sel ;
      private string AV12TFPropostaDocumentosAnexoFileType ;
      private string AV13TFPropostaDocumentosAnexoFileType_Sel ;
      private string AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname ;
      private string AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel ;
      private string AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype ;
      private string AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel ;
      private string lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname ;
      private string lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype ;
      private string A416PropostaDocumentosAnexoName ;
      private string A417PropostaDocumentosAnexoFileType ;
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
      private int[] P009U2_A323PropostaId ;
      private bool[] P009U2_n323PropostaId ;
      private string[] P009U2_A416PropostaDocumentosAnexoName ;
      private bool[] P009U2_n416PropostaDocumentosAnexoName ;
      private string[] P009U2_A417PropostaDocumentosAnexoFileType ;
      private bool[] P009U2_n417PropostaDocumentosAnexoFileType ;
      private int[] P009U2_A414PropostaDocumentosId ;
      private int[] P009U3_A323PropostaId ;
      private bool[] P009U3_n323PropostaId ;
      private string[] P009U3_A417PropostaDocumentosAnexoFileType ;
      private bool[] P009U3_n417PropostaDocumentosAnexoFileType ;
      private string[] P009U3_A416PropostaDocumentosAnexoName ;
      private bool[] P009U3_n416PropostaDocumentosAnexoName ;
      private int[] P009U3_A414PropostaDocumentosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcpropostadocumentogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009U2( IGxContext context ,
                                             string AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel ,
                                             string AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname ,
                                             string AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel ,
                                             string AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype ,
                                             string A416PropostaDocumentosAnexoName ,
                                             string A417PropostaDocumentosAnexoFileType ,
                                             int AV39Wcpropostadocumentods_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT PropostaId, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosId FROM PropostaDocumentos";
         AddWhere(sWhereString, "(PropostaId = :AV39Wcpropostadocumentods_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname)) ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoName like :lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel)) && ! ( StringUtil.StrCmp(AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoName = ( :AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoName IS NULL or (char_length(trim(trailing ' ' from PropostaDocumentosAnexoName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype)) ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoFileType like :lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel)) && ! ( StringUtil.StrCmp(AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoFileType = ( :AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_s))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoFileType IS NULL or (char_length(trim(trailing ' ' from PropostaDocumentosAnexoFileType))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PropostaId, PropostaDocumentosAnexoName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009U3( IGxContext context ,
                                             string AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel ,
                                             string AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname ,
                                             string AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel ,
                                             string AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype ,
                                             string A416PropostaDocumentosAnexoName ,
                                             string A417PropostaDocumentosAnexoFileType ,
                                             int AV39Wcpropostadocumentods_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PropostaId, PropostaDocumentosAnexoFileType, PropostaDocumentosAnexoName, PropostaDocumentosId FROM PropostaDocumentos";
         AddWhere(sWhereString, "(PropostaId = :AV39Wcpropostadocumentods_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname)) ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoName like :lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel)) && ! ( StringUtil.StrCmp(AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoName = ( :AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoName IS NULL or (char_length(trim(trailing ' ' from PropostaDocumentosAnexoName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype)) ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoFileType like :lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel)) && ! ( StringUtil.StrCmp(AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoFileType = ( :AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_s))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(PropostaDocumentosAnexoFileType IS NULL or (char_length(trim(trailing ' ' from PropostaDocumentosAnexoFileType))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PropostaId, PropostaDocumentosAnexoFileType";
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
                     return conditional_P009U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
               case 1 :
                     return conditional_P009U3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
          Object[] prmP009U2;
          prmP009U2 = new Object[] {
          new ParDef("AV39Wcpropostadocumentods_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname",GXType.VarChar,128,0) ,
          new ParDef("AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel",GXType.VarChar,128,0) ,
          new ParDef("lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype",GXType.VarChar,40,0) ,
          new ParDef("AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_s",GXType.VarChar,40,0)
          };
          Object[] prmP009U3;
          prmP009U3 = new Object[] {
          new ParDef("AV39Wcpropostadocumentods_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV40Wcpropostadocumentods_2_tfpropostadocumentosanexoname",GXType.VarChar,128,0) ,
          new ParDef("AV41Wcpropostadocumentods_3_tfpropostadocumentosanexoname_sel",GXType.VarChar,128,0) ,
          new ParDef("lV42Wcpropostadocumentods_4_tfpropostadocumentosanexofiletype",GXType.VarChar,40,0) ,
          new ParDef("AV43Wcpropostadocumentods_5_tfpropostadocumentosanexofiletype_s",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U3,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
