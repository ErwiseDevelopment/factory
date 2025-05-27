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
   public class secrolewwexport : GXProcedure
   {
      public secrolewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrolewwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV50WWPContext) ;
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
         AV11Filename = GXt_char1 + "SecRoleWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV20SecRoleName1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SecRoleName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20SecRoleName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV25SecRoleName2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecRoleName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25SecRoleName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV30SecRoleName3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecRoleName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30SecRoleName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecRoleName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Perfil") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecRoleName_Sel)) ? "(Vazio)" : AV36TFSecRoleName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecRoleName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Perfil") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFSecRoleName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecRoleDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecRoleDescription_Sel)) ? "(Vazio)" : AV38TFSecRoleDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSecRoleDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFSecRoleDescription, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Perfil";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descrição";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Wwpbaseobjects_secrolewwds_1_filterfulltext = AV52FilterFullText;
         AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV61Wwpbaseobjects_secrolewwds_4_secrolename1 = AV20SecRoleName1;
         AV62Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV64Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV65Wwpbaseobjects_secrolewwds_8_secrolename2 = AV25SecRoleName2;
         AV66Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV68Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV69Wwpbaseobjects_secrolewwds_12_secrolename3 = AV30SecRoleName3;
         AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV35TFSecRoleName;
         AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV36TFSecRoleName_Sel;
         AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV37TFSecRoleDescription;
         AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV38TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                              AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                              AV60Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                              AV61Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                              AV62Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                              AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                              AV64Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                              AV65Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                              AV66Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                              AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                              AV68Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                              AV69Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                              AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                              AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                              AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                              AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV58Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV61Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV61Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV65Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV65Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV69Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV69Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV70Wwpbaseobjects_secrolewwds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename), "%", "");
         lV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription), "%", "");
         /* Using cursor P004V2 */
         pr_default.execute(0, new Object[] {lV58Wwpbaseobjects_secrolewwds_1_filterfulltext, lV58Wwpbaseobjects_secrolewwds_1_filterfulltext, lV61Wwpbaseobjects_secrolewwds_4_secrolename1, lV61Wwpbaseobjects_secrolewwds_4_secrolename1, lV65Wwpbaseobjects_secrolewwds_8_secrolename2, lV65Wwpbaseobjects_secrolewwds_8_secrolename2, lV69Wwpbaseobjects_secrolewwds_12_secrolename3, lV69Wwpbaseobjects_secrolewwds_12_secrolename3, lV70Wwpbaseobjects_secrolewwds_13_tfsecrolename, AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, lV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription, AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139SecRoleDescription = P004V2_A139SecRoleDescription[0];
            A140SecRoleName = P004V2_A140SecRoleName[0];
            A131SecRoleId = P004V2_A131SecRoleId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A140SecRoleName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A139SecRoleDescription, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
         AV41Session.Set("WWPExportFilePath", AV11Filename);
         AV41Session.Set("WWPExportFileName", "SecRoleWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV41Session.Get("WWPBaseObjects.SecRoleWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecRoleWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV41Session.Get("WWPBaseObjects.SecRoleWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV51GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV52FilterFullText = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV35TFSecRoleName = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV36TFSecRoleName_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV37TFSecRoleDescription = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV38TFSecRoleDescription_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            AV74GXV1 = (int)(AV74GXV1+1);
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
         AV50WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV52FilterFullText = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20SecRoleName1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25SecRoleName2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30SecRoleName3 = "";
         AV36TFSecRoleName_Sel = "";
         AV35TFSecRoleName = "";
         AV38TFSecRoleDescription_Sel = "";
         AV37TFSecRoleDescription = "";
         AV58Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = "";
         AV61Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = "";
         AV65Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = "";
         AV69Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = "";
         AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = "";
         lV58Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         lV61Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         lV65Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         lV69Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         lV70Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         lV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         P004V2_A139SecRoleDescription = new string[] {""} ;
         P004V2_A140SecRoleName = new string[] {""} ;
         P004V2_A131SecRoleId = new short[1] ;
         GXt_char1 = "";
         AV41Session = context.GetSession();
         AV51GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolewwexport__default(),
            new Object[][] {
                new Object[] {
               P004V2_A139SecRoleDescription, P004V2_A140SecRoleName, P004V2_A131SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV60Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ;
      private short AV64Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ;
      private short AV68Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private short A131SecRoleId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV74GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV62Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ;
      private bool AV66Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV52FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20SecRoleName1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25SecRoleName2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30SecRoleName3 ;
      private string AV36TFSecRoleName_Sel ;
      private string AV35TFSecRoleName ;
      private string AV38TFSecRoleDescription_Sel ;
      private string AV37TFSecRoleDescription ;
      private string AV58Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ;
      private string AV61Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ;
      private string AV65Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ;
      private string AV69Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ;
      private string AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ;
      private string lV58Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string lV61Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string lV65Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string lV69Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string lV70Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string lV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private IGxSession AV41Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV50WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P004V2_A139SecRoleDescription ;
      private string[] P004V2_A140SecRoleName ;
      private short[] P004V2_A131SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV51GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secrolewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004V2( IGxContext context ,
                                             string AV58Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                             string AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                             short AV60Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                             string AV61Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                             bool AV62Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                             string AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                             short AV64Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                             string AV65Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                             bool AV66Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                             string AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                             short AV68Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                             string AV69Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                             string AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                             string AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                             string AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                             string AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecRoleDescription, SecRoleName, SecRoleId FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secrolewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV58Wwpbaseobjects_secrolewwds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV58Wwpbaseobjects_secrolewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV60Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV61Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV60Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV61Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV64Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV65Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV64Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV65Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV66Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV68Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV69Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV66Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV68Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV69Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secrolewwds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV70Wwpbaseobjects_secrolewwds_13_tfsecrolename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleName";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecRoleName DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleDescription";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecRoleDescription DESC";
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
                     return conditional_P004V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP004V2;
          prmP004V2 = new Object[] {
          new ParDef("lV58Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV61Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV65Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV65Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV69Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV69Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV70Wwpbaseobjects_secrolewwds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV71Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Wwpbaseobjects_secrolewwds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV73Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
