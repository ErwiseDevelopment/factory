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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_formwwexport : GXProcedure
   {
      public wwp_formwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formwwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13CellRow = 1;
         AV14FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S181 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV11Filename = GXt_char1 + "WWP_FormWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFWWPFormReferenceName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome de referencia") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV29TFWWPFormReferenceName_Sel)) ? "(Vazio)" : AV29TFWWPFormReferenceName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFWWPFormReferenceName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome de referencia") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TFWWPFormReferenceName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPFormTitle_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Qualificação") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPFormTitle_Sel)) ? "(Vazio)" : AV31TFWWPFormTitle_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPFormTitle)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Qualificação") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30TFWWPFormTitle, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV26ColumnsWithSec = 0;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nome de referencia";
         if ( AV25IsAuthorizedWWPFormTitle )
         {
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Qualificação";
            AV26ColumnsWithSec = (int)(AV26ColumnsWithSec+1);
         }
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV20FilterFullText ,
                                              AV29TFWWPFormReferenceName_Sel ,
                                              AV28TFWWPFormReferenceName ,
                                              AV31TFWWPFormTitle_Sel ,
                                              AV30TFWWPFormTitle ,
                                              AV16WWPFormType ,
                                              AV17WWPFormIsForDynamicValidations ,
                                              A96WWPFormReferenceName ,
                                              A97WWPFormTitle ,
                                              A292WWPFormIsForDynamicValidations ,
                                              A40000GXC1 ,
                                              AV18OrderedBy ,
                                              AV19OrderedDsc ,
                                              A95WWPFormVersionNumber ,
                                              A107WWPFormLatestVersionNumber ,
                                              A290WWPFormType } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV20FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV20FilterFullText), "%", "");
         lV20FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV20FilterFullText), "%", "");
         lV28TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV28TFWWPFormReferenceName), "%", "");
         lV30TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV30TFWWPFormTitle), "%", "");
         /* Using cursor P00803 */
         pr_default.execute(0, new Object[] {AV16WWPFormType, lV20FilterFullText, lV20FilterFullText, lV28TFWWPFormReferenceName, AV29TFWWPFormReferenceName_Sel, lV30TFWWPFormTitle, AV31TFWWPFormTitle_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A292WWPFormIsForDynamicValidations = P00803_A292WWPFormIsForDynamicValidations[0];
            A95WWPFormVersionNumber = P00803_A95WWPFormVersionNumber[0];
            A97WWPFormTitle = P00803_A97WWPFormTitle[0];
            A96WWPFormReferenceName = P00803_A96WWPFormReferenceName[0];
            A290WWPFormType = P00803_A290WWPFormType[0];
            A40000GXC1 = P00803_A40000GXC1[0];
            n40000GXC1 = P00803_n40000GXC1[0];
            A94WWPFormId = P00803_A94WWPFormId[0];
            A40000GXC1 = P00803_A40000GXC1[0];
            n40000GXC1 = P00803_n40000GXC1[0];
            GXt_int2 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int2) ;
            A107WWPFormLatestVersionNumber = GXt_int2;
            if ( A95WWPFormVersionNumber == A107WWPFormLatestVersionNumber )
            {
               AV13CellRow = (int)(AV13CellRow+1);
               /* Execute user subroutine: 'BEFOREWRITELINE' */
               S162 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               AV26ColumnsWithSec = 0;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A96WWPFormReferenceName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
               if ( AV25IsAuthorizedWWPFormTitle )
               {
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A97WWPFormTitle, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  AV26ColumnsWithSec = (int)(AV26ColumnsWithSec+1);
               }
               /* Execute user subroutine: 'AFTERWRITELINE' */
               S172 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S181( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         AV25IsAuthorizedWWPFormTitle = (bool)(((AV16WWPFormType==0)));
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV21Session.Set("WWPExportFilePath", AV11Filename);
         AV21Session.Set("WWPExportFileName", "WWP_FormWWExport.xlsx");
         AV11Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), "") == 0 )
         {
            AV23GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         else
         {
            AV23GridState.FromXml(AV21Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWGridState"), null, "", "");
         }
         AV18OrderedBy = AV23GridState.gxTpr_Orderedby;
         AV19OrderedDsc = AV23GridState.gxTpr_Ordereddsc;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV33GXV1));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV28TFWWPFormReferenceName = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV29TFWWPFormReferenceName_Sel = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV30TFWWPFormTitle = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV31TFWWPFormTitle_Sel = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV16WWPFormType = (short)(Math.Round(NumberUtil.Val( AV24GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV17WWPFormIsForDynamicValidations = BooleanUtil.Val( AV24GridStateFilterValue.gxTpr_Value);
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV20FilterFullText = "";
         AV29TFWWPFormReferenceName_Sel = "";
         AV28TFWWPFormReferenceName = "";
         AV31TFWWPFormTitle_Sel = "";
         AV30TFWWPFormTitle = "";
         lV20FilterFullText = "";
         lV28TFWWPFormReferenceName = "";
         lV30TFWWPFormTitle = "";
         A96WWPFormReferenceName = "";
         A97WWPFormTitle = "";
         P00803_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         P00803_A95WWPFormVersionNumber = new short[1] ;
         P00803_A97WWPFormTitle = new string[] {""} ;
         P00803_A96WWPFormReferenceName = new string[] {""} ;
         P00803_A290WWPFormType = new short[1] ;
         P00803_A40000GXC1 = new int[1] ;
         P00803_n40000GXC1 = new bool[] {false} ;
         P00803_A94WWPFormId = new short[1] ;
         GXt_char1 = "";
         AV21Session = context.GetSession();
         AV23GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV24GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formwwexport__default(),
            new Object[][] {
                new Object[] {
               P00803_A292WWPFormIsForDynamicValidations, P00803_A95WWPFormVersionNumber, P00803_A97WWPFormTitle, P00803_A96WWPFormReferenceName, P00803_A290WWPFormType, P00803_A40000GXC1, P00803_n40000GXC1, P00803_A94WWPFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16WWPFormType ;
      private short AV18OrderedBy ;
      private short A95WWPFormVersionNumber ;
      private short A107WWPFormLatestVersionNumber ;
      private short A290WWPFormType ;
      private short A94WWPFormId ;
      private short GXt_int2 ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV26ColumnsWithSec ;
      private int A40000GXC1 ;
      private int AV33GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV25IsAuthorizedWWPFormTitle ;
      private bool AV17WWPFormIsForDynamicValidations ;
      private bool A292WWPFormIsForDynamicValidations ;
      private bool AV19OrderedDsc ;
      private bool n40000GXC1 ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV20FilterFullText ;
      private string AV29TFWWPFormReferenceName_Sel ;
      private string AV28TFWWPFormReferenceName ;
      private string AV31TFWWPFormTitle_Sel ;
      private string AV30TFWWPFormTitle ;
      private string lV20FilterFullText ;
      private string lV28TFWWPFormReferenceName ;
      private string lV30TFWWPFormTitle ;
      private string A96WWPFormReferenceName ;
      private string A97WWPFormTitle ;
      private IGxSession AV21Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private bool[] P00803_A292WWPFormIsForDynamicValidations ;
      private short[] P00803_A95WWPFormVersionNumber ;
      private string[] P00803_A97WWPFormTitle ;
      private string[] P00803_A96WWPFormReferenceName ;
      private short[] P00803_A290WWPFormType ;
      private int[] P00803_A40000GXC1 ;
      private bool[] P00803_n40000GXC1 ;
      private short[] P00803_A94WWPFormId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV23GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV24GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wwp_formwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00803( IGxContext context ,
                                             string AV20FilterFullText ,
                                             string AV29TFWWPFormReferenceName_Sel ,
                                             string AV28TFWWPFormReferenceName ,
                                             string AV31TFWWPFormTitle_Sel ,
                                             string AV30TFWWPFormTitle ,
                                             short AV16WWPFormType ,
                                             bool AV17WWPFormIsForDynamicValidations ,
                                             string A96WWPFormReferenceName ,
                                             string A97WWPFormTitle ,
                                             bool A292WWPFormIsForDynamicValidations ,
                                             int A40000GXC1 ,
                                             short AV18OrderedBy ,
                                             bool AV19OrderedDsc ,
                                             short A95WWPFormVersionNumber ,
                                             short A107WWPFormLatestVersionNumber ,
                                             short A290WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.WWPFormIsForDynamicValidations, T1.WWPFormVersionNumber, T1.WWPFormTitle, T1.WWPFormReferenceName, T1.WWPFormType, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormType = :AV16WWPFormType)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.WWPFormReferenceName like '%' || :lV20FilterFullText) or ( T1.WWPFormTitle like '%' || :lV20FilterFullText))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFWWPFormReferenceName)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV28TFWWPFormReferenceName)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV29TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV29TFWWPFormReferenceName_Sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPFormTitle)) ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle like :lV30TFWWPFormTitle)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV31TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV31TFWWPFormTitle_Sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV31TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
         }
         if ( ( AV16WWPFormType == 1 ) && AV17WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
         }
         if ( ( AV16WWPFormType == 1 ) && ! AV17WWPFormIsForDynamicValidations )
         {
            AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV18OrderedBy == 1 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName";
         }
         else if ( ( AV18OrderedBy == 1 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormReferenceName DESC";
         }
         else if ( ( AV18OrderedBy == 2 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle";
         }
         else if ( ( AV18OrderedBy == 2 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormTitle DESC";
         }
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
                     return conditional_P00803(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP00803;
          prmP00803 = new Object[] {
          new ParDef("AV16WWPFormType",GXType.Int16,1,0) ,
          new ParDef("lV20FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV20FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV28TFWWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("AV29TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV30TFWWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("AV31TFWWPFormTitle_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00803", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00803,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
