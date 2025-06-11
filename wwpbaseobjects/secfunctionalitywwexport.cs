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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalitywwexport : GXProcedure
   {
      public secfunctionalitywwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalitywwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV39WWPContext) ;
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
         AV11Filename = GXt_char1 + "SecFunctionalityWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSecFunctionalityKey_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Key") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSecFunctionalityKey_Sel)) ? "(Vazio)" : AV22TFSecFunctionalityKey_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSecFunctionalityKey)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Key") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21TFSecFunctionalityKey, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Description") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityDescription_Sel)) ? "(Vazio)" : AV24TFSecFunctionalityDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecFunctionalityDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Description") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23TFSecFunctionalityDescription, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV44TFSecFunctionalityType_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Type") ;
            AV13CellRow = GXt_int2;
            AV35i = 1;
            AV49GXV1 = 1;
            while ( AV49GXV1 <= AV44TFSecFunctionalityType_Sels.Count )
            {
               AV25TFSecFunctionalityType_Sel = (short)(AV44TFSecFunctionalityType_Sels.GetNumeric(AV49GXV1));
               if ( AV35i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomainwwpsecfunctionalitytypes.getDescription(context,AV25TFSecFunctionalityType_Sel);
               AV35i = (long)(AV35i+1);
               AV49GXV1 = (int)(AV49GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Parent Functionality") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription_Sel)) ? "(Vazio)" : AV27TFSecParentFunctionalityDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSecParentFunctionalityDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Parent Functionality") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26TFSecParentFunctionalityDescription, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Key";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Description";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Type";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Parent Functionality";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV21TFSecFunctionalityKey;
         AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV22TFSecFunctionalityKey_Sel;
         AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV23TFSecFunctionalityDescription;
         AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV24TFSecFunctionalityDescription_Sel;
         AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV44TFSecFunctionalityType_Sels;
         AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV26TFSecParentFunctionalityDescription;
         AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV27TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004O2 */
         pr_default.execute(0, new Object[] {lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A129SecParentFunctionalityId = P004O2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004O2_n129SecParentFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004O2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004O2_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004O2_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004O2_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P004O2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004O2_n135SecFunctionalityDescription[0];
            A130SecFunctionalityKey = P004O2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004O2_n130SecFunctionalityKey[0];
            A128SecFunctionalityId = P004O2_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004O2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004O2_n138SecParentFunctionalityDescription[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A130SecFunctionalityKey, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A135SecFunctionalityDescription, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = gxdomainwwpsecfunctionalitytypes.getDescription(context,A136SecFunctionalityType);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A138SecParentFunctionalityDescription, out  GXt_char1) ;
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
         AV30Session.Set("WWPExportFilePath", AV11Filename);
         AV30Session.Set("WWPExportFileName", "SecFunctionalityWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV59GXV2 = 1;
         while ( AV59GXV2 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV59GXV2));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV21TFSecFunctionalityKey = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV22TFSecFunctionalityKey_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV23TFSecFunctionalityDescription = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV24TFSecFunctionalityDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV43TFSecFunctionalityType_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV44TFSecFunctionalityType_Sels.FromJSonString(AV43TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV26TFSecParentFunctionalityDescription = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV27TFSecParentFunctionalityDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV59GXV2 = (int)(AV59GXV2+1);
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
         AV39WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV45FilterFullText = "";
         AV22TFSecFunctionalityKey_Sel = "";
         AV21TFSecFunctionalityKey = "";
         AV24TFSecFunctionalityDescription_Sel = "";
         AV23TFSecFunctionalityDescription = "";
         AV44TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV27TFSecParentFunctionalityDescription_Sel = "";
         AV26TFSecParentFunctionalityDescription = "";
         AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P004O2_A129SecParentFunctionalityId = new long[1] ;
         P004O2_n129SecParentFunctionalityId = new bool[] {false} ;
         P004O2_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004O2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004O2_A136SecFunctionalityType = new short[1] ;
         P004O2_n136SecFunctionalityType = new bool[] {false} ;
         P004O2_A135SecFunctionalityDescription = new string[] {""} ;
         P004O2_n135SecFunctionalityDescription = new bool[] {false} ;
         P004O2_A130SecFunctionalityKey = new string[] {""} ;
         P004O2_n130SecFunctionalityKey = new bool[] {false} ;
         P004O2_A128SecFunctionalityId = new long[1] ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43TFSecFunctionalityType_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalitywwexport__default(),
            new Object[][] {
                new Object[] {
               P004O2_A129SecParentFunctionalityId, P004O2_n129SecParentFunctionalityId, P004O2_A138SecParentFunctionalityDescription, P004O2_n138SecParentFunctionalityDescription, P004O2_A136SecFunctionalityType, P004O2_n136SecFunctionalityType, P004O2_A135SecFunctionalityDescription, P004O2_n135SecFunctionalityDescription, P004O2_A130SecFunctionalityKey, P004O2_n130SecFunctionalityKey,
               P004O2_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25TFSecFunctionalityType_Sel ;
      private short GXt_int2 ;
      private short A136SecFunctionalityType ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV49GXV1 ;
      private int AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private int AV59GXV2 ;
      private long AV35i ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private bool n129SecParentFunctionalityId ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool n130SecFunctionalityKey ;
      private string AV43TFSecFunctionalityType_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV45FilterFullText ;
      private string AV22TFSecFunctionalityKey_Sel ;
      private string AV21TFSecFunctionalityKey ;
      private string AV24TFSecFunctionalityDescription_Sel ;
      private string AV23TFSecFunctionalityDescription ;
      private string AV27TFSecParentFunctionalityDescription_Sel ;
      private string AV26TFSecParentFunctionalityDescription ;
      private string AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private IGxSession AV30Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV39WWPContext ;
      private GxSimpleCollection<short> AV44TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P004O2_A129SecParentFunctionalityId ;
      private bool[] P004O2_n129SecParentFunctionalityId ;
      private string[] P004O2_A138SecParentFunctionalityDescription ;
      private bool[] P004O2_n138SecParentFunctionalityDescription ;
      private short[] P004O2_A136SecFunctionalityType ;
      private bool[] P004O2_n136SecFunctionalityType ;
      private string[] P004O2_A135SecFunctionalityDescription ;
      private bool[] P004O2_n135SecFunctionalityDescription ;
      private string[] P004O2_A130SecFunctionalityKey ;
      private bool[] P004O2_n130SecFunctionalityKey ;
      private long[] P004O2_A128SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secfunctionalitywwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004O2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityDescription";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityDescription DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityKey";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityType";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecFunctionalityType DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.SecFunctionalityDescription";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecFunctionalityDescription DESC";
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
                     return conditional_P004O2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP004O2;
          prmP004O2 = new Object[] {
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV53Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV54Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV55Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV57Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctional",GXType.VarChar,100,0) ,
          new ParDef("AV58Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctional",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
