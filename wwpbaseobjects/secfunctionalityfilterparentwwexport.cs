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
   public class secfunctionalityfilterparentwwexport : GXProcedure
   {
      public secfunctionalityfilterparentwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityfilterparentwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV40WWPContext) ;
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
         AV11Filename = GXt_char1 + "SecFunctionalityFilterParentWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( (0==AV19SecFunctionalityType) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Type") ;
            AV13CellRow = GXt_int2;
            if ( ! (0==AV19SecFunctionalityType) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomainwwpsecfunctionalitytypes.getDescription(context,AV19SecFunctionalityType);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV21SecFunctionalityDescription)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "") ;
            AV13CellRow = GXt_int2;
            if ( AV20SecFunctionalityDescriptionOperator == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Description", "Começa com", "", "", "", "", "", "", "");
            }
            else if ( AV20SecFunctionalityDescriptionOperator == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Description", "Contém", "", "", "", "", "", "", "");
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21SecFunctionalityDescription, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecFunctionalityKey_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Key") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecFunctionalityKey_Sel)) ? "(Vazio)" : AV23TFSecFunctionalityKey_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSecFunctionalityKey)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Key") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22TFSecFunctionalityKey, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSecFunctionalityDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Description") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSecFunctionalityDescription_Sel)) ? "(Vazio)" : AV25TFSecFunctionalityDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Description") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TFSecFunctionalityDescription, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV45TFSecFunctionalityType_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Type") ;
            AV13CellRow = GXt_int2;
            AV36i = 1;
            AV50GXV1 = 1;
            while ( AV50GXV1 <= AV45TFSecFunctionalityType_Sels.Count )
            {
               AV26TFSecFunctionalityType_Sel = (short)(AV45TFSecFunctionalityType_Sels.GetNumeric(AV50GXV1));
               if ( AV36i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomainwwpsecfunctionalitytypes.getDescription(context,AV26TFSecFunctionalityType_Sel);
               AV36i = (long)(AV36i+1);
               AV50GXV1 = (int)(AV50GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSecParentFunctionalityDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Parent Functionality") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSecParentFunctionalityDescription_Sel)) ? "(Vazio)" : AV28TFSecParentFunctionalityDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Parent Functionality") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27TFSecParentFunctionalityDescription, out  GXt_char1) ;
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
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV16SecParentFunctionalityId;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV19SecFunctionalityType;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV21SecFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV22TFSecFunctionalityKey;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV23TFSecFunctionalityKey_Sel;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV24TFSecFunctionalityDescription;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV25TFSecFunctionalityDescription_Sel;
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV45TFSecFunctionalityType_Sels;
         AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV27TFSecParentFunctionalityDescription;
         AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV28TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV20SecFunctionalityDescriptionOperator ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A129SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P004J2 */
         pr_default.execute(0, new Object[] {AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext, AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A138SecParentFunctionalityDescription = P004J2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004J2_n138SecParentFunctionalityDescription[0];
            A136SecFunctionalityType = P004J2_A136SecFunctionalityType[0];
            n136SecFunctionalityType = P004J2_n136SecFunctionalityType[0];
            A135SecFunctionalityDescription = P004J2_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = P004J2_n135SecFunctionalityDescription[0];
            A130SecFunctionalityKey = P004J2_A130SecFunctionalityKey[0];
            n130SecFunctionalityKey = P004J2_n130SecFunctionalityKey[0];
            A129SecParentFunctionalityId = P004J2_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = P004J2_n129SecParentFunctionalityId[0];
            A128SecFunctionalityId = P004J2_A128SecFunctionalityId[0];
            A138SecParentFunctionalityDescription = P004J2_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = P004J2_n138SecParentFunctionalityDescription[0];
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
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "SecFunctionalityFilterParentWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV31Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV42GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV42GridState.gxTpr_Ordereddsc;
         AV63GXV2 = 1;
         while ( AV63GXV2 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV63GXV2));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV19SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV21SecFunctionalityDescription = AV43GridStateFilterValue.gxTpr_Value;
               AV20SecFunctionalityDescriptionOperator = AV43GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV22TFSecFunctionalityKey = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV23TFSecFunctionalityKey_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV24TFSecFunctionalityDescription = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV25TFSecFunctionalityDescription_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV44TFSecFunctionalityType_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV45TFSecFunctionalityType_Sels.FromJSonString(AV44TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV27TFSecParentFunctionalityDescription = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV28TFSecParentFunctionalityDescription_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&SECPARENTFUNCTIONALITYID") == 0 )
            {
               AV16SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV63GXV2 = (int)(AV63GXV2+1);
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
         AV40WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV46FilterFullText = "";
         AV21SecFunctionalityDescription = "";
         AV23TFSecFunctionalityKey_Sel = "";
         AV22TFSecFunctionalityKey = "";
         AV25TFSecFunctionalityDescription_Sel = "";
         AV24TFSecFunctionalityDescription = "";
         AV45TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV28TFSecParentFunctionalityDescription_Sel = "";
         AV27TFSecParentFunctionalityDescription = "";
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = "";
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = "";
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = "";
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         lV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         P004J2_A138SecParentFunctionalityDescription = new string[] {""} ;
         P004J2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         P004J2_A136SecFunctionalityType = new short[1] ;
         P004J2_n136SecFunctionalityType = new bool[] {false} ;
         P004J2_A135SecFunctionalityDescription = new string[] {""} ;
         P004J2_n135SecFunctionalityDescription = new bool[] {false} ;
         P004J2_A130SecFunctionalityKey = new string[] {""} ;
         P004J2_n130SecFunctionalityKey = new bool[] {false} ;
         P004J2_A129SecParentFunctionalityId = new long[1] ;
         P004J2_n129SecParentFunctionalityId = new bool[] {false} ;
         P004J2_A128SecFunctionalityId = new long[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFSecFunctionalityType_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwexport__default(),
            new Object[][] {
                new Object[] {
               P004J2_A138SecParentFunctionalityDescription, P004J2_n138SecParentFunctionalityDescription, P004J2_A136SecFunctionalityType, P004J2_n136SecFunctionalityType, P004J2_A135SecFunctionalityDescription, P004J2_n135SecFunctionalityDescription, P004J2_A130SecFunctionalityKey, P004J2_n130SecFunctionalityKey, P004J2_A129SecParentFunctionalityId, P004J2_n129SecParentFunctionalityId,
               P004J2_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19SecFunctionalityType ;
      private short AV20SecFunctionalityDescriptionOperator ;
      private short AV26TFSecFunctionalityType_Sel ;
      private short GXt_int2 ;
      private short AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ;
      private short A136SecFunctionalityType ;
      private short AV17OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV50GXV1 ;
      private int AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ;
      private int AV63GXV2 ;
      private long AV36i ;
      private long AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ;
      private long AV16SecParentFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long A128SecFunctionalityId ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n138SecParentFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n135SecFunctionalityDescription ;
      private bool n130SecFunctionalityKey ;
      private bool n129SecParentFunctionalityId ;
      private string AV44TFSecFunctionalityType_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV46FilterFullText ;
      private string AV21SecFunctionalityDescription ;
      private string AV23TFSecFunctionalityKey_Sel ;
      private string AV22TFSecFunctionalityKey ;
      private string AV25TFSecFunctionalityDescription_Sel ;
      private string AV24TFSecFunctionalityDescription ;
      private string AV28TFSecParentFunctionalityDescription_Sel ;
      private string AV27TFSecParentFunctionalityDescription ;
      private string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ;
      private string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ;
      private string AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ;
      private string lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string lV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ;
      private GxSimpleCollection<short> AV45TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004J2_A138SecParentFunctionalityDescription ;
      private bool[] P004J2_n138SecParentFunctionalityDescription ;
      private short[] P004J2_A136SecFunctionalityType ;
      private bool[] P004J2_n136SecFunctionalityType ;
      private string[] P004J2_A135SecFunctionalityDescription ;
      private bool[] P004J2_n135SecFunctionalityDescription ;
      private string[] P004J2_A130SecFunctionalityKey ;
      private bool[] P004J2_n130SecFunctionalityKey ;
      private long[] P004J2_A129SecParentFunctionalityId ;
      private bool[] P004J2_n129SecParentFunctionalityId ;
      private long[] P004J2_A128SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secfunctionalityfilterparentwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004J2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             short AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV20SecFunctionalityDescriptionOperator ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             long AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A129SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityId FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecParentFunctionalityId = :AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( T1.SecFunctionalityDescription like '%' || :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) or ( 'mode' like '%' || LOWER(:lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityType = :AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( AV20SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( AV20SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityDescription";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityDescription DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityKey";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T1.SecFunctionalityType";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T1.SecFunctionalityType DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId, T2.SecFunctionalityDescription";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecParentFunctionalityId DESC, T2.SecFunctionalityDescription DESC";
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
                     return conditional_P004J2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
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
          Object[] prmP004J2;
          prmP004J2 = new Object[] {
          new ParDef("AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparent",GXType.Int64,10,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterful",GXType.VarChar,100,0) ,
          new ParDef("AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfuncti",GXType.Int16,2,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfuncti",GXType.VarChar,100,0) ,
          new ParDef("lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunc",GXType.VarChar,100,0) ,
          new ParDef("lV61Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecpar",GXType.VarChar,100,0) ,
          new ParDef("AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecpar",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
