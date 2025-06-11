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
   public class conveniowwexport : GXProcedure
   {
      public conveniowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conveniowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ConvenioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONVENIODESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21ConvenioDescricao1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ConvenioDescricao1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descricao", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descricao", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ConvenioDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONVENIODESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25ConvenioDescricao2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ConvenioDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descricao", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descricao", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ConvenioDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONVENIODESCRICAO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29ConvenioDescricao3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ConvenioDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descricao", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descricao", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ConvenioDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConvenioDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Convênio") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConvenioDescricao_Sel)) ? "(Vazio)" : AV38TFConvenioDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConvenioDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Convênio") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFConvenioDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV39TFConvenioStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV39TFConvenioStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV39TFConvenioStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Convênio";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV41Conveniowwds_1_filterfulltext = AV18FilterFullText;
         AV42Conveniowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV43Conveniowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV44Conveniowwds_4_conveniodescricao1 = AV21ConvenioDescricao1;
         AV45Conveniowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV46Conveniowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV47Conveniowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV48Conveniowwds_8_conveniodescricao2 = AV25ConvenioDescricao2;
         AV49Conveniowwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV50Conveniowwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV51Conveniowwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV52Conveniowwds_12_conveniodescricao3 = AV29ConvenioDescricao3;
         AV53Conveniowwds_13_tfconveniodescricao = AV37TFConvenioDescricao;
         AV54Conveniowwds_14_tfconveniodescricao_sel = AV38TFConvenioDescricao_Sel;
         AV55Conveniowwds_15_tfconveniostatus_sel = AV39TFConvenioStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Conveniowwds_1_filterfulltext ,
                                              AV42Conveniowwds_2_dynamicfiltersselector1 ,
                                              AV43Conveniowwds_3_dynamicfiltersoperator1 ,
                                              AV44Conveniowwds_4_conveniodescricao1 ,
                                              AV45Conveniowwds_5_dynamicfiltersenabled2 ,
                                              AV46Conveniowwds_6_dynamicfiltersselector2 ,
                                              AV47Conveniowwds_7_dynamicfiltersoperator2 ,
                                              AV48Conveniowwds_8_conveniodescricao2 ,
                                              AV49Conveniowwds_9_dynamicfiltersenabled3 ,
                                              AV50Conveniowwds_10_dynamicfiltersselector3 ,
                                              AV51Conveniowwds_11_dynamicfiltersoperator3 ,
                                              AV52Conveniowwds_12_conveniodescricao3 ,
                                              AV54Conveniowwds_14_tfconveniodescricao_sel ,
                                              AV53Conveniowwds_13_tfconveniodescricao ,
                                              AV55Conveniowwds_15_tfconveniostatus_sel ,
                                              A411ConvenioDescricao ,
                                              A412ConvenioStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Conveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Conveniowwds_1_filterfulltext), "%", "");
         lV41Conveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Conveniowwds_1_filterfulltext), "%", "");
         lV41Conveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Conveniowwds_1_filterfulltext), "%", "");
         lV44Conveniowwds_4_conveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV44Conveniowwds_4_conveniodescricao1), "%", "");
         lV44Conveniowwds_4_conveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV44Conveniowwds_4_conveniodescricao1), "%", "");
         lV48Conveniowwds_8_conveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV48Conveniowwds_8_conveniodescricao2), "%", "");
         lV48Conveniowwds_8_conveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV48Conveniowwds_8_conveniodescricao2), "%", "");
         lV52Conveniowwds_12_conveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV52Conveniowwds_12_conveniodescricao3), "%", "");
         lV52Conveniowwds_12_conveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV52Conveniowwds_12_conveniodescricao3), "%", "");
         lV53Conveniowwds_13_tfconveniodescricao = StringUtil.Concat( StringUtil.RTrim( AV53Conveniowwds_13_tfconveniodescricao), "%", "");
         /* Using cursor P009P2 */
         pr_default.execute(0, new Object[] {lV41Conveniowwds_1_filterfulltext, lV41Conveniowwds_1_filterfulltext, lV41Conveniowwds_1_filterfulltext, lV44Conveniowwds_4_conveniodescricao1, lV44Conveniowwds_4_conveniodescricao1, lV48Conveniowwds_8_conveniodescricao2, lV48Conveniowwds_8_conveniodescricao2, lV52Conveniowwds_12_conveniodescricao3, lV52Conveniowwds_12_conveniodescricao3, lV53Conveniowwds_13_tfconveniodescricao, AV54Conveniowwds_14_tfconveniodescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A412ConvenioStatus = P009P2_A412ConvenioStatus[0];
            A411ConvenioDescricao = P009P2_A411ConvenioDescricao[0];
            n411ConvenioDescricao = P009P2_n411ConvenioDescricao[0];
            A410ConvenioId = P009P2_A410ConvenioId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A411ConvenioDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A412ConvenioStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A412ConvenioStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Não";
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
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "ConvenioWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ConvenioWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConvenioWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ConvenioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONVENIODESCRICAO") == 0 )
            {
               AV37TFConvenioDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONVENIODESCRICAO_SEL") == 0 )
            {
               AV38TFConvenioDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONVENIOSTATUS_SEL") == 0 )
            {
               AV39TFConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
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
         AV18FilterFullText = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV21ConvenioDescricao1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ConvenioDescricao2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ConvenioDescricao3 = "";
         AV38TFConvenioDescricao_Sel = "";
         AV37TFConvenioDescricao = "";
         AV41Conveniowwds_1_filterfulltext = "";
         AV42Conveniowwds_2_dynamicfiltersselector1 = "";
         AV44Conveniowwds_4_conveniodescricao1 = "";
         AV46Conveniowwds_6_dynamicfiltersselector2 = "";
         AV48Conveniowwds_8_conveniodescricao2 = "";
         AV50Conveniowwds_10_dynamicfiltersselector3 = "";
         AV52Conveniowwds_12_conveniodescricao3 = "";
         AV53Conveniowwds_13_tfconveniodescricao = "";
         AV54Conveniowwds_14_tfconveniodescricao_sel = "";
         lV41Conveniowwds_1_filterfulltext = "";
         lV44Conveniowwds_4_conveniodescricao1 = "";
         lV48Conveniowwds_8_conveniodescricao2 = "";
         lV52Conveniowwds_12_conveniodescricao3 = "";
         lV53Conveniowwds_13_tfconveniodescricao = "";
         A411ConvenioDescricao = "";
         P009P2_A412ConvenioStatus = new bool[] {false} ;
         P009P2_A411ConvenioDescricao = new string[] {""} ;
         P009P2_n411ConvenioDescricao = new bool[] {false} ;
         P009P2_A410ConvenioId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conveniowwexport__default(),
            new Object[][] {
                new Object[] {
               P009P2_A412ConvenioStatus, P009P2_A411ConvenioDescricao, P009P2_n411ConvenioDescricao, P009P2_A410ConvenioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV39TFConvenioStatus_Sel ;
      private short GXt_int2 ;
      private short AV43Conveniowwds_3_dynamicfiltersoperator1 ;
      private short AV47Conveniowwds_7_dynamicfiltersoperator2 ;
      private short AV51Conveniowwds_11_dynamicfiltersoperator3 ;
      private short AV55Conveniowwds_15_tfconveniostatus_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A410ConvenioId ;
      private int AV56GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV45Conveniowwds_5_dynamicfiltersenabled2 ;
      private bool AV49Conveniowwds_9_dynamicfiltersenabled3 ;
      private bool A412ConvenioStatus ;
      private bool AV17OrderedDsc ;
      private bool n411ConvenioDescricao ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ConvenioDescricao1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ConvenioDescricao2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ConvenioDescricao3 ;
      private string AV38TFConvenioDescricao_Sel ;
      private string AV37TFConvenioDescricao ;
      private string AV41Conveniowwds_1_filterfulltext ;
      private string AV42Conveniowwds_2_dynamicfiltersselector1 ;
      private string AV44Conveniowwds_4_conveniodescricao1 ;
      private string AV46Conveniowwds_6_dynamicfiltersselector2 ;
      private string AV48Conveniowwds_8_conveniodescricao2 ;
      private string AV50Conveniowwds_10_dynamicfiltersselector3 ;
      private string AV52Conveniowwds_12_conveniodescricao3 ;
      private string AV53Conveniowwds_13_tfconveniodescricao ;
      private string AV54Conveniowwds_14_tfconveniodescricao_sel ;
      private string lV41Conveniowwds_1_filterfulltext ;
      private string lV44Conveniowwds_4_conveniodescricao1 ;
      private string lV48Conveniowwds_8_conveniodescricao2 ;
      private string lV52Conveniowwds_12_conveniodescricao3 ;
      private string lV53Conveniowwds_13_tfconveniodescricao ;
      private string A411ConvenioDescricao ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P009P2_A412ConvenioStatus ;
      private string[] P009P2_A411ConvenioDescricao ;
      private bool[] P009P2_n411ConvenioDescricao ;
      private int[] P009P2_A410ConvenioId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class conveniowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009P2( IGxContext context ,
                                             string AV41Conveniowwds_1_filterfulltext ,
                                             string AV42Conveniowwds_2_dynamicfiltersselector1 ,
                                             short AV43Conveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV44Conveniowwds_4_conveniodescricao1 ,
                                             bool AV45Conveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV46Conveniowwds_6_dynamicfiltersselector2 ,
                                             short AV47Conveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV48Conveniowwds_8_conveniodescricao2 ,
                                             bool AV49Conveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV50Conveniowwds_10_dynamicfiltersselector3 ,
                                             short AV51Conveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV52Conveniowwds_12_conveniodescricao3 ,
                                             string AV54Conveniowwds_14_tfconveniodescricao_sel ,
                                             string AV53Conveniowwds_13_tfconveniodescricao ,
                                             short AV55Conveniowwds_15_tfconveniostatus_sel ,
                                             string A411ConvenioDescricao ,
                                             bool A412ConvenioStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ConvenioStatus, ConvenioDescricao, ConvenioId FROM Convenio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Conveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConvenioDescricao like '%' || :lV41Conveniowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV41Conveniowwds_1_filterfulltext) and ConvenioStatus = TRUE) or ( 'não' like '%' || LOWER(:lV41Conveniowwds_1_filterfulltext) and ConvenioStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Conveniowwds_2_dynamicfiltersselector1, "CONVENIODESCRICAO") == 0 ) && ( AV43Conveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Conveniowwds_4_conveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV44Conveniowwds_4_conveniodescricao1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Conveniowwds_2_dynamicfiltersselector1, "CONVENIODESCRICAO") == 0 ) && ( AV43Conveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Conveniowwds_4_conveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like '%' || :lV44Conveniowwds_4_conveniodescricao1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV45Conveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Conveniowwds_6_dynamicfiltersselector2, "CONVENIODESCRICAO") == 0 ) && ( AV47Conveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Conveniowwds_8_conveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV48Conveniowwds_8_conveniodescricao2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV45Conveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Conveniowwds_6_dynamicfiltersselector2, "CONVENIODESCRICAO") == 0 ) && ( AV47Conveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Conveniowwds_8_conveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like '%' || :lV48Conveniowwds_8_conveniodescricao2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV49Conveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Conveniowwds_10_dynamicfiltersselector3, "CONVENIODESCRICAO") == 0 ) && ( AV51Conveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Conveniowwds_12_conveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV52Conveniowwds_12_conveniodescricao3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV49Conveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Conveniowwds_10_dynamicfiltersselector3, "CONVENIODESCRICAO") == 0 ) && ( AV51Conveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Conveniowwds_12_conveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like '%' || :lV52Conveniowwds_12_conveniodescricao3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniowwds_14_tfconveniodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Conveniowwds_13_tfconveniodescricao)) ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao like :lV53Conveniowwds_13_tfconveniodescricao)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Conveniowwds_14_tfconveniodescricao_sel)) && ! ( StringUtil.StrCmp(AV54Conveniowwds_14_tfconveniodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConvenioDescricao = ( :AV54Conveniowwds_14_tfconveniodescricao_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV54Conveniowwds_14_tfconveniodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConvenioDescricao IS NULL or (char_length(trim(trailing ' ' from ConvenioDescricao))=0))");
         }
         if ( AV55Conveniowwds_15_tfconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ConvenioStatus = TRUE)");
         }
         if ( AV55Conveniowwds_15_tfconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ConvenioStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ConvenioDescricao";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConvenioDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ConvenioStatus";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConvenioStatus DESC";
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
                     return conditional_P009P2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP009P2;
          prmP009P2 = new Object[] {
          new ParDef("lV41Conveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Conveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Conveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Conveniowwds_4_conveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV44Conveniowwds_4_conveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV48Conveniowwds_8_conveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV48Conveniowwds_8_conveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV52Conveniowwds_12_conveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV52Conveniowwds_12_conveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV53Conveniowwds_13_tfconveniodescricao",GXType.VarChar,40,0) ,
          new ParDef("AV54Conveniowwds_14_tfconveniodescricao_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
