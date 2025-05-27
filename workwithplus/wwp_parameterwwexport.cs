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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameterwwexport : GXProcedure
   {
      public wwp_parameterwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameterwwexport( IGxContext context )
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
         S191 ();
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
         S181 ();
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
         AV11Filename = GXt_char1 + "WWP_ParameterWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV18FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWWPParameterKey_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Chave") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWWPParameterKey_Sel)) ? "(Vazio)" : AV24TFWWPParameterKey_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPParameterKey)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Chave") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23TFWWPParameterKey, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWWPParameterCategory_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Categoria") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWWPParameterCategory_Sel)) ? "(Vazio)" : AV26TFWWPParameterCategory_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWWPParameterCategory)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Categoria") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25TFWWPParameterCategory, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFWWPParameterDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV28TFWWPParameterDescription_Sel)) ? "(Vazio)" : AV28TFWWPParameterDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFWWPParameterDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27TFWWPParameterDescription, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPParameterValueTrimmed_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPParameterValueTrimmed_Sel)) ? "(Vazio)" : AV30TFWWPParameterValueTrimmed_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFWWPParameterValueTrimmed)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29TFWWPParameterValueTrimmed, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Chave";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Categoria";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Descrição";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Valor";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV32Workwithplus_wwp_parameterwwds_1_filterfulltext = AV18FilterFullText;
         AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV23TFWWPParameterKey;
         AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV24TFWWPParameterKey_Sel;
         AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV25TFWWPParameterCategory;
         AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV26TFWWPParameterCategory_Sel;
         AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV27TFWWPParameterDescription;
         AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV28TFWWPParameterDescription_Sel;
         AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV29TFWWPParameterValueTrimmed;
         AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV30TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV32Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV32Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV32Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV32Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV32Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV32Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV32Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV32Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV32Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor P007Y2 */
         pr_default.execute(0, new Object[] {lV32Workwithplus_wwp_parameterwwds_1_filterfulltext, lV32Workwithplus_wwp_parameterwwds_1_filterfulltext, lV32Workwithplus_wwp_parameterwwds_1_filterfulltext, lV32Workwithplus_wwp_parameterwwds_1_filterfulltext, lV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4WWPParameterDescription = P007Y2_A4WWPParameterDescription[0];
            A3WWPParameterCategory = P007Y2_A3WWPParameterCategory[0];
            A1WWPParameterKey = P007Y2_A1WWPParameterKey[0];
            A2WWPParameterValue = P007Y2_A2WWPParameterValue[0];
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1WWPParameterKey, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A3WWPParameterCategory, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A4WWPParameterDescription, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A6WWPParameterValueTrimmed, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV19Session.Set("WWPExportFilePath", AV11Filename);
         AV19Session.Set("WWPExportFileName", "WWP_ParameterWWExport.xlsx");
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

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV19Session.Get("WorkWithPlus.WWP_ParameterWWGridState"), "") == 0 )
         {
            AV21GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WorkWithPlus.WWP_ParameterWWGridState"), null, "", "");
         }
         else
         {
            AV21GridState.FromXml(AV19Session.Get("WorkWithPlus.WWP_ParameterWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV21GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV21GridState.gxTpr_Ordereddsc;
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV21GridState.gxTpr_Filtervalues.Count )
         {
            AV22GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV21GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY") == 0 )
            {
               AV23TFWWPParameterKey = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY_SEL") == 0 )
            {
               AV24TFWWPParameterKey_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY") == 0 )
            {
               AV25TFWWPParameterCategory = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY_SEL") == 0 )
            {
               AV26TFWWPParameterCategory_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION") == 0 )
            {
               AV27TFWWPParameterDescription = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION_SEL") == 0 )
            {
               AV28TFWWPParameterDescription_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED") == 0 )
            {
               AV29TFWWPParameterValueTrimmed = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED_SEL") == 0 )
            {
               AV30TFWWPParameterValueTrimmed_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            AV41GXV1 = (int)(AV41GXV1+1);
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
         AV18FilterFullText = "";
         AV24TFWWPParameterKey_Sel = "";
         AV23TFWWPParameterKey = "";
         AV26TFWWPParameterCategory_Sel = "";
         AV25TFWWPParameterCategory = "";
         AV28TFWWPParameterDescription_Sel = "";
         AV27TFWWPParameterDescription = "";
         AV30TFWWPParameterValueTrimmed_Sel = "";
         AV29TFWWPParameterValueTrimmed = "";
         AV32Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = "";
         AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = "";
         AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = "";
         AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = "";
         lV32Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         lV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         lV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         lV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         lV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         A1WWPParameterKey = "";
         A3WWPParameterCategory = "";
         A4WWPParameterDescription = "";
         A2WWPParameterValue = "";
         P007Y2_A4WWPParameterDescription = new string[] {""} ;
         P007Y2_A3WWPParameterCategory = new string[] {""} ;
         P007Y2_A1WWPParameterKey = new string[] {""} ;
         P007Y2_A2WWPParameterValue = new string[] {""} ;
         A6WWPParameterValueTrimmed = "";
         GXt_char1 = "";
         AV19Session = context.GetSession();
         AV21GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV22GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameterwwexport__default(),
            new Object[][] {
                new Object[] {
               P007Y2_A4WWPParameterDescription, P007Y2_A3WWPParameterCategory, P007Y2_A1WWPParameterKey, P007Y2_A2WWPParameterValue
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV41GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private string A2WWPParameterValue ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV24TFWWPParameterKey_Sel ;
      private string AV23TFWWPParameterKey ;
      private string AV26TFWWPParameterCategory_Sel ;
      private string AV25TFWWPParameterCategory ;
      private string AV28TFWWPParameterDescription_Sel ;
      private string AV27TFWWPParameterDescription ;
      private string AV30TFWWPParameterValueTrimmed_Sel ;
      private string AV29TFWWPParameterValueTrimmed ;
      private string AV32Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ;
      private string AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ;
      private string AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ;
      private string AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ;
      private string lV32Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string lV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string lV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string lV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string lV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string A1WWPParameterKey ;
      private string A3WWPParameterCategory ;
      private string A4WWPParameterDescription ;
      private string A6WWPParameterValueTrimmed ;
      private IGxSession AV19Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P007Y2_A4WWPParameterDescription ;
      private string[] P007Y2_A3WWPParameterCategory ;
      private string[] P007Y2_A1WWPParameterKey ;
      private string[] P007Y2_A2WWPParameterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV21GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV22GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wwp_parameterwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Y2( IGxContext context ,
                                             string AV32Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV32Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV32Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV32Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV32Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WWPParameterKey DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WWPParameterCategory";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WWPParameterCategory DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY WWPParameterDescription";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY WWPParameterDescription DESC";
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
                     return conditional_P007Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP007Y2;
          prmP007Y2 = new Object[] {
          new ParDef("lV32Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV32Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV32Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV32Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV33Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV34Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV35Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV36Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV37Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV38Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV39Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV40Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
