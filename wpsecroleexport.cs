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
namespace GeneXus.Programs {
   public class wpsecroleexport : GXProcedure
   {
      public wpsecroleexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpsecroleexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
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
         AV14CellRow = 1;
         AV15FirstColumn = 1;
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
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "WpSecRoleExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Filtro principal") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22SecRoleName1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecRoleName1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22SecRoleName1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26SecRoleName2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SecRoleName2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26SecRoleName2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30SecRoleName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecRoleName3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Perfil", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30SecRoleName3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecRoleName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Perfil") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecRoleName_Sel)) ? "(Vazio)" : AV48TFSecRoleName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSecRoleName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Perfil") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFSecRoleName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecRoleDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecRoleDescription_Sel)) ? "(Vazio)" : AV50TFSecRoleDescription_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecRoleDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFSecRoleDescription, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Perfil";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Descrição";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Wpsecroleds_1_filterfulltext = AV19FilterFullText;
         AV55Wpsecroleds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV56Wpsecroleds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV57Wpsecroleds_4_secrolename1 = AV22SecRoleName1;
         AV58Wpsecroleds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpsecroleds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpsecroleds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpsecroleds_8_secrolename2 = AV26SecRoleName2;
         AV62Wpsecroleds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV63Wpsecroleds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV64Wpsecroleds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV65Wpsecroleds_12_secrolename3 = AV30SecRoleName3;
         AV66Wpsecroleds_13_tfsecrolename = AV47TFSecRoleName;
         AV67Wpsecroleds_14_tfsecrolename_sel = AV48TFSecRoleName_Sel;
         AV68Wpsecroleds_15_tfsecroledescription = AV49TFSecRoleDescription;
         AV69Wpsecroleds_16_tfsecroledescription_sel = AV50TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Wpsecroleds_1_filterfulltext ,
                                              AV55Wpsecroleds_2_dynamicfiltersselector1 ,
                                              AV56Wpsecroleds_3_dynamicfiltersoperator1 ,
                                              AV57Wpsecroleds_4_secrolename1 ,
                                              AV58Wpsecroleds_5_dynamicfiltersenabled2 ,
                                              AV59Wpsecroleds_6_dynamicfiltersselector2 ,
                                              AV60Wpsecroleds_7_dynamicfiltersoperator2 ,
                                              AV61Wpsecroleds_8_secrolename2 ,
                                              AV62Wpsecroleds_9_dynamicfiltersenabled3 ,
                                              AV63Wpsecroleds_10_dynamicfiltersselector3 ,
                                              AV64Wpsecroleds_11_dynamicfiltersoperator3 ,
                                              AV65Wpsecroleds_12_secrolename3 ,
                                              AV67Wpsecroleds_14_tfsecrolename_sel ,
                                              AV66Wpsecroleds_13_tfsecrolename ,
                                              AV69Wpsecroleds_16_tfsecroledescription_sel ,
                                              AV68Wpsecroleds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpsecroleds_1_filterfulltext), "%", "");
         lV54Wpsecroleds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpsecroleds_1_filterfulltext), "%", "");
         lV57Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1), "%", "");
         lV57Wpsecroleds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1), "%", "");
         lV61Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2), "%", "");
         lV61Wpsecroleds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2), "%", "");
         lV65Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3), "%", "");
         lV65Wpsecroleds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3), "%", "");
         lV66Wpsecroleds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV66Wpsecroleds_13_tfsecrolename), "%", "");
         lV68Wpsecroleds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV68Wpsecroleds_15_tfsecroledescription), "%", "");
         /* Using cursor P00572 */
         pr_default.execute(0, new Object[] {lV54Wpsecroleds_1_filterfulltext, lV54Wpsecroleds_1_filterfulltext, lV57Wpsecroleds_4_secrolename1, lV57Wpsecroleds_4_secrolename1, lV61Wpsecroleds_8_secrolename2, lV61Wpsecroleds_8_secrolename2, lV65Wpsecroleds_12_secrolename3, lV65Wpsecroleds_12_secrolename3, lV66Wpsecroleds_13_tfsecrolename, AV67Wpsecroleds_14_tfsecrolename_sel, lV68Wpsecroleds_15_tfsecroledescription, AV69Wpsecroleds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139SecRoleDescription = P00572_A139SecRoleDescription[0];
            A140SecRoleName = P00572_A140SecRoleName[0];
            A131SecRoleId = P00572_A131SecRoleId[0];
            AV14CellRow = (int)(AV14CellRow+1);
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
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A139SecRoleDescription, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
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
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "WpSecRoleExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("WpSecRoleGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpSecRoleGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WpSecRoleGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV47TFSecRoleName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV48TFSecRoleName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV49TFSecRoleDescription = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV50TFSecRoleDescription_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV70GXV1 = (int)(AV70GXV1+1);
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22SecRoleName1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26SecRoleName2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30SecRoleName3 = "";
         AV48TFSecRoleName_Sel = "";
         AV47TFSecRoleName = "";
         AV50TFSecRoleDescription_Sel = "";
         AV49TFSecRoleDescription = "";
         AV54Wpsecroleds_1_filterfulltext = "";
         AV55Wpsecroleds_2_dynamicfiltersselector1 = "";
         AV57Wpsecroleds_4_secrolename1 = "";
         AV59Wpsecroleds_6_dynamicfiltersselector2 = "";
         AV61Wpsecroleds_8_secrolename2 = "";
         AV63Wpsecroleds_10_dynamicfiltersselector3 = "";
         AV65Wpsecroleds_12_secrolename3 = "";
         AV66Wpsecroleds_13_tfsecrolename = "";
         AV67Wpsecroleds_14_tfsecrolename_sel = "";
         AV68Wpsecroleds_15_tfsecroledescription = "";
         AV69Wpsecroleds_16_tfsecroledescription_sel = "";
         lV54Wpsecroleds_1_filterfulltext = "";
         lV57Wpsecroleds_4_secrolename1 = "";
         lV61Wpsecroleds_8_secrolename2 = "";
         lV65Wpsecroleds_12_secrolename3 = "";
         lV66Wpsecroleds_13_tfsecrolename = "";
         lV68Wpsecroleds_15_tfsecroledescription = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         P00572_A139SecRoleDescription = new string[] {""} ;
         P00572_A140SecRoleName = new string[] {""} ;
         P00572_A131SecRoleId = new short[1] ;
         GXt_char1 = "";
         AV32Session = context.GetSession();
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsecroleexport__default(),
            new Object[][] {
                new Object[] {
               P00572_A139SecRoleDescription, P00572_A140SecRoleName, P00572_A131SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV56Wpsecroleds_3_dynamicfiltersoperator1 ;
      private short AV60Wpsecroleds_7_dynamicfiltersoperator2 ;
      private short AV64Wpsecroleds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private short A131SecRoleId ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV70GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV58Wpsecroleds_5_dynamicfiltersenabled2 ;
      private bool AV62Wpsecroleds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22SecRoleName1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26SecRoleName2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30SecRoleName3 ;
      private string AV48TFSecRoleName_Sel ;
      private string AV47TFSecRoleName ;
      private string AV50TFSecRoleDescription_Sel ;
      private string AV49TFSecRoleDescription ;
      private string AV54Wpsecroleds_1_filterfulltext ;
      private string AV55Wpsecroleds_2_dynamicfiltersselector1 ;
      private string AV57Wpsecroleds_4_secrolename1 ;
      private string AV59Wpsecroleds_6_dynamicfiltersselector2 ;
      private string AV61Wpsecroleds_8_secrolename2 ;
      private string AV63Wpsecroleds_10_dynamicfiltersselector3 ;
      private string AV65Wpsecroleds_12_secrolename3 ;
      private string AV66Wpsecroleds_13_tfsecrolename ;
      private string AV67Wpsecroleds_14_tfsecrolename_sel ;
      private string AV68Wpsecroleds_15_tfsecroledescription ;
      private string AV69Wpsecroleds_16_tfsecroledescription_sel ;
      private string lV54Wpsecroleds_1_filterfulltext ;
      private string lV57Wpsecroleds_4_secrolename1 ;
      private string lV61Wpsecroleds_8_secrolename2 ;
      private string lV65Wpsecroleds_12_secrolename3 ;
      private string lV66Wpsecroleds_13_tfsecrolename ;
      private string lV68Wpsecroleds_15_tfsecroledescription ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00572_A139SecRoleDescription ;
      private string[] P00572_A140SecRoleName ;
      private short[] P00572_A131SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wpsecroleexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00572( IGxContext context ,
                                             string AV54Wpsecroleds_1_filterfulltext ,
                                             string AV55Wpsecroleds_2_dynamicfiltersselector1 ,
                                             short AV56Wpsecroleds_3_dynamicfiltersoperator1 ,
                                             string AV57Wpsecroleds_4_secrolename1 ,
                                             bool AV58Wpsecroleds_5_dynamicfiltersenabled2 ,
                                             string AV59Wpsecroleds_6_dynamicfiltersselector2 ,
                                             short AV60Wpsecroleds_7_dynamicfiltersoperator2 ,
                                             string AV61Wpsecroleds_8_secrolename2 ,
                                             bool AV62Wpsecroleds_9_dynamicfiltersenabled3 ,
                                             string AV63Wpsecroleds_10_dynamicfiltersselector3 ,
                                             short AV64Wpsecroleds_11_dynamicfiltersoperator3 ,
                                             string AV65Wpsecroleds_12_secrolename3 ,
                                             string AV67Wpsecroleds_14_tfsecrolename_sel ,
                                             string AV66Wpsecroleds_13_tfsecrolename ,
                                             string AV69Wpsecroleds_16_tfsecroledescription_sel ,
                                             string AV68Wpsecroleds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecRoleDescription, SecRoleName, SecRoleId FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpsecroleds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV54Wpsecroleds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV54Wpsecroleds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wpsecroleds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV57Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpsecroleds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wpsecroleds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpsecroleds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV57Wpsecroleds_4_secrolename1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wpsecroleds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV61Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Wpsecroleds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpsecroleds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wpsecroleds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpsecroleds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV61Wpsecroleds_8_secrolename2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV62Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wpsecroleds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV65Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Wpsecroleds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wpsecroleds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wpsecroleds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpsecroleds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV65Wpsecroleds_12_secrolename3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpsecroleds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV66Wpsecroleds_13_tfsecrolename)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpsecroleds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV67Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV67Wpsecroleds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpsecroleds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpsecroleds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpsecroleds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV68Wpsecroleds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpsecroleds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV69Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV69Wpsecroleds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpsecroleds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleName";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecRoleName DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY SecRoleDescription";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
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
                     return conditional_P00572(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00572;
          prmP00572 = new Object[] {
          new ParDef("lV54Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpsecroleds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV57Wpsecroleds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV61Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV61Wpsecroleds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV65Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV65Wpsecroleds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV66Wpsecroleds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV67Wpsecroleds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Wpsecroleds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV69Wpsecroleds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00572", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00572,100, GxCacheFrequency.OFF ,true,false )
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
