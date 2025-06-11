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
   public class conveniocategoriawwexport : GXProcedure
   {
      public conveniocategoriawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conveniocategoriawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ConvenioCategoriaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ConvenioCategoriaDescricao1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ConvenioCategoriaDescricao1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ConvenioCategoriaDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ConvenioCategoriaDescricao2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ConvenioCategoriaDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ConvenioCategoriaDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ConvenioCategoriaDescricao3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ConvenioCategoriaDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ConvenioCategoriaDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConvenioCategoriaDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Categoria") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConvenioCategoriaDescricao_Sel)) ? "(Vazio)" : AV37TFConvenioCategoriaDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConvenioCategoriaDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Categoria") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFConvenioCategoriaDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV38TFConvenioCategoriaStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV38TFConvenioCategoriaStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV38TFConvenioCategoriaStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Categoria";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV40Conveniocategoriawwds_1_convenioid = AV16ConvenioId;
         AV41Conveniocategoriawwds_2_filterfulltext = AV19FilterFullText;
         AV42Conveniocategoriawwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV43Conveniocategoriawwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV44Conveniocategoriawwds_5_conveniocategoriadescricao1 = AV22ConvenioCategoriaDescricao1;
         AV45Conveniocategoriawwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV46Conveniocategoriawwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV47Conveniocategoriawwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV48Conveniocategoriawwds_9_conveniocategoriadescricao2 = AV26ConvenioCategoriaDescricao2;
         AV49Conveniocategoriawwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV50Conveniocategoriawwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV51Conveniocategoriawwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV52Conveniocategoriawwds_13_conveniocategoriadescricao3 = AV30ConvenioCategoriaDescricao3;
         AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao = AV36TFConvenioCategoriaDescricao;
         AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel = AV37TFConvenioCategoriaDescricao_Sel;
         AV55Conveniocategoriawwds_16_tfconveniocategoriastatus_sel = AV38TFConvenioCategoriaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Conveniocategoriawwds_2_filterfulltext ,
                                              AV42Conveniocategoriawwds_3_dynamicfiltersselector1 ,
                                              AV43Conveniocategoriawwds_4_dynamicfiltersoperator1 ,
                                              AV44Conveniocategoriawwds_5_conveniocategoriadescricao1 ,
                                              AV45Conveniocategoriawwds_6_dynamicfiltersenabled2 ,
                                              AV46Conveniocategoriawwds_7_dynamicfiltersselector2 ,
                                              AV47Conveniocategoriawwds_8_dynamicfiltersoperator2 ,
                                              AV48Conveniocategoriawwds_9_conveniocategoriadescricao2 ,
                                              AV49Conveniocategoriawwds_10_dynamicfiltersenabled3 ,
                                              AV50Conveniocategoriawwds_11_dynamicfiltersselector3 ,
                                              AV51Conveniocategoriawwds_12_dynamicfiltersoperator3 ,
                                              AV52Conveniocategoriawwds_13_conveniocategoriadescricao3 ,
                                              AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel ,
                                              AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao ,
                                              AV55Conveniocategoriawwds_16_tfconveniocategoriastatus_sel ,
                                              A494ConvenioCategoriaDescricao ,
                                              A495ConvenioCategoriaStatus ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV40Conveniocategoriawwds_1_convenioid ,
                                              A410ConvenioId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Conveniocategoriawwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Conveniocategoriawwds_2_filterfulltext), "%", "");
         lV41Conveniocategoriawwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Conveniocategoriawwds_2_filterfulltext), "%", "");
         lV41Conveniocategoriawwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Conveniocategoriawwds_2_filterfulltext), "%", "");
         lV44Conveniocategoriawwds_5_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV44Conveniocategoriawwds_5_conveniocategoriadescricao1), "%", "");
         lV44Conveniocategoriawwds_5_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV44Conveniocategoriawwds_5_conveniocategoriadescricao1), "%", "");
         lV48Conveniocategoriawwds_9_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV48Conveniocategoriawwds_9_conveniocategoriadescricao2), "%", "");
         lV48Conveniocategoriawwds_9_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV48Conveniocategoriawwds_9_conveniocategoriadescricao2), "%", "");
         lV52Conveniocategoriawwds_13_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV52Conveniocategoriawwds_13_conveniocategoriadescricao3), "%", "");
         lV52Conveniocategoriawwds_13_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV52Conveniocategoriawwds_13_conveniocategoriadescricao3), "%", "");
         lV53Conveniocategoriawwds_14_tfconveniocategoriadescricao = StringUtil.Concat( StringUtil.RTrim( AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao), "%", "");
         /* Using cursor P00AH2 */
         pr_default.execute(0, new Object[] {AV40Conveniocategoriawwds_1_convenioid, lV41Conveniocategoriawwds_2_filterfulltext, lV41Conveniocategoriawwds_2_filterfulltext, lV41Conveniocategoriawwds_2_filterfulltext, lV44Conveniocategoriawwds_5_conveniocategoriadescricao1, lV44Conveniocategoriawwds_5_conveniocategoriadescricao1, lV48Conveniocategoriawwds_9_conveniocategoriadescricao2, lV48Conveniocategoriawwds_9_conveniocategoriadescricao2, lV52Conveniocategoriawwds_13_conveniocategoriadescricao3, lV52Conveniocategoriawwds_13_conveniocategoriadescricao3, lV53Conveniocategoriawwds_14_tfconveniocategoriadescricao, AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A495ConvenioCategoriaStatus = P00AH2_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = P00AH2_n495ConvenioCategoriaStatus[0];
            A494ConvenioCategoriaDescricao = P00AH2_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AH2_n494ConvenioCategoriaDescricao[0];
            A410ConvenioId = P00AH2_A410ConvenioId[0];
            n410ConvenioId = P00AH2_n410ConvenioId[0];
            A493ConvenioCategoriaId = P00AH2_A493ConvenioCategoriaId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A494ConvenioCategoriaDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A495ConvenioCategoriaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A495ConvenioCategoriaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
            }
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
         AV32Session.Set("WWPExportFilePath", AV11Filename);
         AV32Session.Set("WWPExportFileName", "ConvenioCategoriaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV32Session.Get("ConvenioCategoriaWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConvenioCategoriaWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ConvenioCategoriaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV36TFConvenioCategoriaDescricao = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONVENIOCATEGORIADESCRICAO_SEL") == 0 )
            {
               AV37TFConvenioCategoriaDescricao_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONVENIOCATEGORIASTATUS_SEL") == 0 )
            {
               AV38TFConvenioCategoriaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&CONVENIOID") == 0 )
            {
               AV16ConvenioId = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
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
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ConvenioCategoriaDescricao1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ConvenioCategoriaDescricao2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ConvenioCategoriaDescricao3 = "";
         AV37TFConvenioCategoriaDescricao_Sel = "";
         AV36TFConvenioCategoriaDescricao = "";
         AV41Conveniocategoriawwds_2_filterfulltext = "";
         AV42Conveniocategoriawwds_3_dynamicfiltersselector1 = "";
         AV44Conveniocategoriawwds_5_conveniocategoriadescricao1 = "";
         AV46Conveniocategoriawwds_7_dynamicfiltersselector2 = "";
         AV48Conveniocategoriawwds_9_conveniocategoriadescricao2 = "";
         AV50Conveniocategoriawwds_11_dynamicfiltersselector3 = "";
         AV52Conveniocategoriawwds_13_conveniocategoriadescricao3 = "";
         AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao = "";
         AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel = "";
         lV41Conveniocategoriawwds_2_filterfulltext = "";
         lV44Conveniocategoriawwds_5_conveniocategoriadescricao1 = "";
         lV48Conveniocategoriawwds_9_conveniocategoriadescricao2 = "";
         lV52Conveniocategoriawwds_13_conveniocategoriadescricao3 = "";
         lV53Conveniocategoriawwds_14_tfconveniocategoriadescricao = "";
         A494ConvenioCategoriaDescricao = "";
         P00AH2_A495ConvenioCategoriaStatus = new bool[] {false} ;
         P00AH2_n495ConvenioCategoriaStatus = new bool[] {false} ;
         P00AH2_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00AH2_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00AH2_A410ConvenioId = new int[1] ;
         P00AH2_n410ConvenioId = new bool[] {false} ;
         P00AH2_A493ConvenioCategoriaId = new int[1] ;
         GXt_char1 = "";
         AV32Session = context.GetSession();
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conveniocategoriawwexport__default(),
            new Object[][] {
                new Object[] {
               P00AH2_A495ConvenioCategoriaStatus, P00AH2_n495ConvenioCategoriaStatus, P00AH2_A494ConvenioCategoriaDescricao, P00AH2_n494ConvenioCategoriaDescricao, P00AH2_A410ConvenioId, P00AH2_n410ConvenioId, P00AH2_A493ConvenioCategoriaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV38TFConvenioCategoriaStatus_Sel ;
      private short GXt_int2 ;
      private short AV43Conveniocategoriawwds_4_dynamicfiltersoperator1 ;
      private short AV47Conveniocategoriawwds_8_dynamicfiltersoperator2 ;
      private short AV51Conveniocategoriawwds_12_dynamicfiltersoperator3 ;
      private short AV55Conveniocategoriawwds_16_tfconveniocategoriastatus_sel ;
      private short AV17OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV40Conveniocategoriawwds_1_convenioid ;
      private int AV16ConvenioId ;
      private int A410ConvenioId ;
      private int A493ConvenioCategoriaId ;
      private int AV56GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV45Conveniocategoriawwds_6_dynamicfiltersenabled2 ;
      private bool AV49Conveniocategoriawwds_10_dynamicfiltersenabled3 ;
      private bool A495ConvenioCategoriaStatus ;
      private bool AV18OrderedDsc ;
      private bool n495ConvenioCategoriaStatus ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n410ConvenioId ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22ConvenioCategoriaDescricao1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26ConvenioCategoriaDescricao2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30ConvenioCategoriaDescricao3 ;
      private string AV37TFConvenioCategoriaDescricao_Sel ;
      private string AV36TFConvenioCategoriaDescricao ;
      private string AV41Conveniocategoriawwds_2_filterfulltext ;
      private string AV42Conveniocategoriawwds_3_dynamicfiltersselector1 ;
      private string AV44Conveniocategoriawwds_5_conveniocategoriadescricao1 ;
      private string AV46Conveniocategoriawwds_7_dynamicfiltersselector2 ;
      private string AV48Conveniocategoriawwds_9_conveniocategoriadescricao2 ;
      private string AV50Conveniocategoriawwds_11_dynamicfiltersselector3 ;
      private string AV52Conveniocategoriawwds_13_conveniocategoriadescricao3 ;
      private string AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao ;
      private string AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel ;
      private string lV41Conveniocategoriawwds_2_filterfulltext ;
      private string lV44Conveniocategoriawwds_5_conveniocategoriadescricao1 ;
      private string lV48Conveniocategoriawwds_9_conveniocategoriadescricao2 ;
      private string lV52Conveniocategoriawwds_13_conveniocategoriadescricao3 ;
      private string lV53Conveniocategoriawwds_14_tfconveniocategoriadescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P00AH2_A495ConvenioCategoriaStatus ;
      private bool[] P00AH2_n495ConvenioCategoriaStatus ;
      private string[] P00AH2_A494ConvenioCategoriaDescricao ;
      private bool[] P00AH2_n494ConvenioCategoriaDescricao ;
      private int[] P00AH2_A410ConvenioId ;
      private bool[] P00AH2_n410ConvenioId ;
      private int[] P00AH2_A493ConvenioCategoriaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class conveniocategoriawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AH2( IGxContext context ,
                                             string AV41Conveniocategoriawwds_2_filterfulltext ,
                                             string AV42Conveniocategoriawwds_3_dynamicfiltersselector1 ,
                                             short AV43Conveniocategoriawwds_4_dynamicfiltersoperator1 ,
                                             string AV44Conveniocategoriawwds_5_conveniocategoriadescricao1 ,
                                             bool AV45Conveniocategoriawwds_6_dynamicfiltersenabled2 ,
                                             string AV46Conveniocategoriawwds_7_dynamicfiltersselector2 ,
                                             short AV47Conveniocategoriawwds_8_dynamicfiltersoperator2 ,
                                             string AV48Conveniocategoriawwds_9_conveniocategoriadescricao2 ,
                                             bool AV49Conveniocategoriawwds_10_dynamicfiltersenabled3 ,
                                             string AV50Conveniocategoriawwds_11_dynamicfiltersselector3 ,
                                             short AV51Conveniocategoriawwds_12_dynamicfiltersoperator3 ,
                                             string AV52Conveniocategoriawwds_13_conveniocategoriadescricao3 ,
                                             string AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel ,
                                             string AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao ,
                                             short AV55Conveniocategoriawwds_16_tfconveniocategoriastatus_sel ,
                                             string A494ConvenioCategoriaDescricao ,
                                             bool A495ConvenioCategoriaStatus ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             int AV40Conveniocategoriawwds_1_convenioid ,
                                             int A410ConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ConvenioCategoriaStatus, ConvenioCategoriaDescricao, ConvenioId, ConvenioCategoriaId FROM ConvenioCategoria";
         AddWhere(sWhereString, "(ConvenioId = :AV40Conveniocategoriawwds_1_convenioid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Conveniocategoriawwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConvenioCategoriaDescricao like '%' || :lV41Conveniocategoriawwds_2_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV41Conveniocategoriawwds_2_filterfulltext) and ConvenioCategoriaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV41Conveniocategoriawwds_2_filterfulltext) and ConvenioCategoriaStatus = FALSE))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Conveniocategoriawwds_3_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV43Conveniocategoriawwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Conveniocategoriawwds_5_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV44Conveniocategoriawwds_5_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Conveniocategoriawwds_3_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV43Conveniocategoriawwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Conveniocategoriawwds_5_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like '%' || :lV44Conveniocategoriawwds_5_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV45Conveniocategoriawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Conveniocategoriawwds_7_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV47Conveniocategoriawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Conveniocategoriawwds_9_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV48Conveniocategoriawwds_9_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV45Conveniocategoriawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Conveniocategoriawwds_7_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV47Conveniocategoriawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Conveniocategoriawwds_9_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like '%' || :lV48Conveniocategoriawwds_9_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV49Conveniocategoriawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Conveniocategoriawwds_11_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV51Conveniocategoriawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Conveniocategoriawwds_13_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV52Conveniocategoriawwds_13_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV49Conveniocategoriawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Conveniocategoriawwds_11_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV51Conveniocategoriawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Conveniocategoriawwds_13_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like '%' || :lV52Conveniocategoriawwds_13_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Conveniocategoriawwds_14_tfconveniocategoriadescricao)) ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao like :lV53Conveniocategoriawwds_14_tfconveniocategoriadescricao)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel)) && ! ( StringUtil.StrCmp(AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao = ( :AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaDescricao IS NULL or (char_length(trim(trailing ' ' from ConvenioCategoriaDescricao))=0))");
         }
         if ( AV55Conveniocategoriawwds_16_tfconveniocategoriastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaStatus = TRUE)");
         }
         if ( AV55Conveniocategoriawwds_16_tfconveniocategoriastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ConvenioCategoriaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY ConvenioId, ConvenioCategoriaDescricao";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConvenioId DESC, ConvenioCategoriaDescricao DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY ConvenioId, ConvenioCategoriaStatus";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConvenioId DESC, ConvenioCategoriaStatus DESC";
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
                     return conditional_P00AH2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] );
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
          Object[] prmP00AH2;
          prmP00AH2 = new Object[] {
          new ParDef("AV40Conveniocategoriawwds_1_convenioid",GXType.Int32,9,0) ,
          new ParDef("lV41Conveniocategoriawwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Conveniocategoriawwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Conveniocategoriawwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Conveniocategoriawwds_5_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV44Conveniocategoriawwds_5_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV48Conveniocategoriawwds_9_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV48Conveniocategoriawwds_9_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV52Conveniocategoriawwds_13_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV52Conveniocategoriawwds_13_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV53Conveniocategoriawwds_14_tfconveniocategoriadescricao",GXType.VarChar,70,0) ,
          new ParDef("AV54Conveniocategoriawwds_15_tfconveniocategoriadescricao_sel",GXType.VarChar,70,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
