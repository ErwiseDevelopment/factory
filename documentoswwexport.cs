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
   public class documentoswwexport : GXProcedure
   {
      public documentoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "DocumentosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "DOCUMENTOSDESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21DocumentosDescricao1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DocumentosDescricao1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21DocumentosDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCUMENTOSDESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25DocumentosDescricao2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25DocumentosDescricao2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25DocumentosDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "DOCUMENTOSDESCRICAO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29DocumentosDescricao3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29DocumentosDescricao3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29DocumentosDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDocumentosDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descricao") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDocumentosDescricao_Sel)) ? "(Vazio)" : AV36TFDocumentosDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFDocumentosDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descricao") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFDocumentosDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV37TFDocumentosStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV37TFDocumentosStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV37TFDocumentosStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV38TFDocumentoObrigatorio_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Obrigatorio") ;
            AV13CellRow = GXt_int2;
            if ( AV38TFDocumentoObrigatorio_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV38TFDocumentoObrigatorio_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Descricao";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Obrigatorio";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV40Documentoswwds_1_filterfulltext = AV18FilterFullText;
         AV41Documentoswwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV42Documentoswwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV43Documentoswwds_4_documentosdescricao1 = AV21DocumentosDescricao1;
         AV44Documentoswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV45Documentoswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV46Documentoswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV47Documentoswwds_8_documentosdescricao2 = AV25DocumentosDescricao2;
         AV48Documentoswwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV49Documentoswwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV50Documentoswwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV51Documentoswwds_12_documentosdescricao3 = AV29DocumentosDescricao3;
         AV52Documentoswwds_13_tfdocumentosdescricao = AV35TFDocumentosDescricao;
         AV53Documentoswwds_14_tfdocumentosdescricao_sel = AV36TFDocumentosDescricao_Sel;
         AV54Documentoswwds_15_tfdocumentosstatus_sel = AV37TFDocumentosStatus_Sel;
         AV55Documentoswwds_16_tfdocumentoobrigatorio_sel = AV38TFDocumentoObrigatorio_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Documentoswwds_1_filterfulltext ,
                                              AV41Documentoswwds_2_dynamicfiltersselector1 ,
                                              AV42Documentoswwds_3_dynamicfiltersoperator1 ,
                                              AV43Documentoswwds_4_documentosdescricao1 ,
                                              AV44Documentoswwds_5_dynamicfiltersenabled2 ,
                                              AV45Documentoswwds_6_dynamicfiltersselector2 ,
                                              AV46Documentoswwds_7_dynamicfiltersoperator2 ,
                                              AV47Documentoswwds_8_documentosdescricao2 ,
                                              AV48Documentoswwds_9_dynamicfiltersenabled3 ,
                                              AV49Documentoswwds_10_dynamicfiltersselector3 ,
                                              AV50Documentoswwds_11_dynamicfiltersoperator3 ,
                                              AV51Documentoswwds_12_documentosdescricao3 ,
                                              AV53Documentoswwds_14_tfdocumentosdescricao_sel ,
                                              AV52Documentoswwds_13_tfdocumentosdescricao ,
                                              AV54Documentoswwds_15_tfdocumentosstatus_sel ,
                                              AV55Documentoswwds_16_tfdocumentoobrigatorio_sel ,
                                              A406DocumentosDescricao ,
                                              A407DocumentosStatus ,
                                              A413DocumentoObrigatorio ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Documentoswwds_1_filterfulltext), "%", "");
         lV40Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Documentoswwds_1_filterfulltext), "%", "");
         lV40Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Documentoswwds_1_filterfulltext), "%", "");
         lV40Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Documentoswwds_1_filterfulltext), "%", "");
         lV40Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Documentoswwds_1_filterfulltext), "%", "");
         lV43Documentoswwds_4_documentosdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV43Documentoswwds_4_documentosdescricao1), "%", "");
         lV43Documentoswwds_4_documentosdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV43Documentoswwds_4_documentosdescricao1), "%", "");
         lV47Documentoswwds_8_documentosdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV47Documentoswwds_8_documentosdescricao2), "%", "");
         lV47Documentoswwds_8_documentosdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV47Documentoswwds_8_documentosdescricao2), "%", "");
         lV51Documentoswwds_12_documentosdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV51Documentoswwds_12_documentosdescricao3), "%", "");
         lV51Documentoswwds_12_documentosdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV51Documentoswwds_12_documentosdescricao3), "%", "");
         lV52Documentoswwds_13_tfdocumentosdescricao = StringUtil.Concat( StringUtil.RTrim( AV52Documentoswwds_13_tfdocumentosdescricao), "%", "");
         /* Using cursor P009R2 */
         pr_default.execute(0, new Object[] {lV40Documentoswwds_1_filterfulltext, lV40Documentoswwds_1_filterfulltext, lV40Documentoswwds_1_filterfulltext, lV40Documentoswwds_1_filterfulltext, lV40Documentoswwds_1_filterfulltext, lV43Documentoswwds_4_documentosdescricao1, lV43Documentoswwds_4_documentosdescricao1, lV47Documentoswwds_8_documentosdescricao2, lV47Documentoswwds_8_documentosdescricao2, lV51Documentoswwds_12_documentosdescricao3, lV51Documentoswwds_12_documentosdescricao3, lV52Documentoswwds_13_tfdocumentosdescricao, AV53Documentoswwds_14_tfdocumentosdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A413DocumentoObrigatorio = P009R2_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = P009R2_n413DocumentoObrigatorio[0];
            A407DocumentosStatus = P009R2_A407DocumentosStatus[0];
            n407DocumentosStatus = P009R2_n407DocumentosStatus[0];
            A406DocumentosDescricao = P009R2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P009R2_n406DocumentosDescricao[0];
            A405DocumentosId = P009R2_A405DocumentosId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A406DocumentosDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A407DocumentosStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A407DocumentosStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A413DocumentoObrigatorio)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A413DocumentoObrigatorio)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Não";
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
         AV31Session.Set("WWPExportFileName", "DocumentosWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("DocumentosWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentosWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("DocumentosWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO") == 0 )
            {
               AV35TFDocumentosDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO_SEL") == 0 )
            {
               AV36TFDocumentosDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSSTATUS_SEL") == 0 )
            {
               AV37TFDocumentosStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOOBRIGATORIO_SEL") == 0 )
            {
               AV38TFDocumentoObrigatorio_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
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
         AV21DocumentosDescricao1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25DocumentosDescricao2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29DocumentosDescricao3 = "";
         AV36TFDocumentosDescricao_Sel = "";
         AV35TFDocumentosDescricao = "";
         AV40Documentoswwds_1_filterfulltext = "";
         AV41Documentoswwds_2_dynamicfiltersselector1 = "";
         AV43Documentoswwds_4_documentosdescricao1 = "";
         AV45Documentoswwds_6_dynamicfiltersselector2 = "";
         AV47Documentoswwds_8_documentosdescricao2 = "";
         AV49Documentoswwds_10_dynamicfiltersselector3 = "";
         AV51Documentoswwds_12_documentosdescricao3 = "";
         AV52Documentoswwds_13_tfdocumentosdescricao = "";
         AV53Documentoswwds_14_tfdocumentosdescricao_sel = "";
         lV40Documentoswwds_1_filterfulltext = "";
         lV43Documentoswwds_4_documentosdescricao1 = "";
         lV47Documentoswwds_8_documentosdescricao2 = "";
         lV51Documentoswwds_12_documentosdescricao3 = "";
         lV52Documentoswwds_13_tfdocumentosdescricao = "";
         A406DocumentosDescricao = "";
         P009R2_A413DocumentoObrigatorio = new bool[] {false} ;
         P009R2_n413DocumentoObrigatorio = new bool[] {false} ;
         P009R2_A407DocumentosStatus = new bool[] {false} ;
         P009R2_n407DocumentosStatus = new bool[] {false} ;
         P009R2_A406DocumentosDescricao = new string[] {""} ;
         P009R2_n406DocumentosDescricao = new bool[] {false} ;
         P009R2_A405DocumentosId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoswwexport__default(),
            new Object[][] {
                new Object[] {
               P009R2_A413DocumentoObrigatorio, P009R2_n413DocumentoObrigatorio, P009R2_A407DocumentosStatus, P009R2_n407DocumentosStatus, P009R2_A406DocumentosDescricao, P009R2_n406DocumentosDescricao, P009R2_A405DocumentosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV37TFDocumentosStatus_Sel ;
      private short AV38TFDocumentoObrigatorio_Sel ;
      private short GXt_int2 ;
      private short AV42Documentoswwds_3_dynamicfiltersoperator1 ;
      private short AV46Documentoswwds_7_dynamicfiltersoperator2 ;
      private short AV50Documentoswwds_11_dynamicfiltersoperator3 ;
      private short AV54Documentoswwds_15_tfdocumentosstatus_sel ;
      private short AV55Documentoswwds_16_tfdocumentoobrigatorio_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A405DocumentosId ;
      private int AV56GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV44Documentoswwds_5_dynamicfiltersenabled2 ;
      private bool AV48Documentoswwds_9_dynamicfiltersenabled3 ;
      private bool A407DocumentosStatus ;
      private bool A413DocumentoObrigatorio ;
      private bool AV17OrderedDsc ;
      private bool n413DocumentoObrigatorio ;
      private bool n407DocumentosStatus ;
      private bool n406DocumentosDescricao ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21DocumentosDescricao1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25DocumentosDescricao2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29DocumentosDescricao3 ;
      private string AV36TFDocumentosDescricao_Sel ;
      private string AV35TFDocumentosDescricao ;
      private string AV40Documentoswwds_1_filterfulltext ;
      private string AV41Documentoswwds_2_dynamicfiltersselector1 ;
      private string AV43Documentoswwds_4_documentosdescricao1 ;
      private string AV45Documentoswwds_6_dynamicfiltersselector2 ;
      private string AV47Documentoswwds_8_documentosdescricao2 ;
      private string AV49Documentoswwds_10_dynamicfiltersselector3 ;
      private string AV51Documentoswwds_12_documentosdescricao3 ;
      private string AV52Documentoswwds_13_tfdocumentosdescricao ;
      private string AV53Documentoswwds_14_tfdocumentosdescricao_sel ;
      private string lV40Documentoswwds_1_filterfulltext ;
      private string lV43Documentoswwds_4_documentosdescricao1 ;
      private string lV47Documentoswwds_8_documentosdescricao2 ;
      private string lV51Documentoswwds_12_documentosdescricao3 ;
      private string lV52Documentoswwds_13_tfdocumentosdescricao ;
      private string A406DocumentosDescricao ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P009R2_A413DocumentoObrigatorio ;
      private bool[] P009R2_n413DocumentoObrigatorio ;
      private bool[] P009R2_A407DocumentosStatus ;
      private bool[] P009R2_n407DocumentosStatus ;
      private string[] P009R2_A406DocumentosDescricao ;
      private bool[] P009R2_n406DocumentosDescricao ;
      private int[] P009R2_A405DocumentosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class documentoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009R2( IGxContext context ,
                                             string AV40Documentoswwds_1_filterfulltext ,
                                             string AV41Documentoswwds_2_dynamicfiltersselector1 ,
                                             short AV42Documentoswwds_3_dynamicfiltersoperator1 ,
                                             string AV43Documentoswwds_4_documentosdescricao1 ,
                                             bool AV44Documentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV45Documentoswwds_6_dynamicfiltersselector2 ,
                                             short AV46Documentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV47Documentoswwds_8_documentosdescricao2 ,
                                             bool AV48Documentoswwds_9_dynamicfiltersenabled3 ,
                                             string AV49Documentoswwds_10_dynamicfiltersselector3 ,
                                             short AV50Documentoswwds_11_dynamicfiltersoperator3 ,
                                             string AV51Documentoswwds_12_documentosdescricao3 ,
                                             string AV53Documentoswwds_14_tfdocumentosdescricao_sel ,
                                             string AV52Documentoswwds_13_tfdocumentosdescricao ,
                                             short AV54Documentoswwds_15_tfdocumentosstatus_sel ,
                                             short AV55Documentoswwds_16_tfdocumentoobrigatorio_sel ,
                                             string A406DocumentosDescricao ,
                                             bool A407DocumentosStatus ,
                                             bool A413DocumentoObrigatorio ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT DocumentoObrigatorio, DocumentosStatus, DocumentosDescricao, DocumentosId FROM Documentos";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Documentoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocumentosDescricao like '%' || :lV40Documentoswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV40Documentoswwds_1_filterfulltext) and DocumentosStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV40Documentoswwds_1_filterfulltext) and DocumentosStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV40Documentoswwds_1_filterfulltext) and DocumentoObrigatorio = TRUE) or ( 'não' like '%' || LOWER(:lV40Documentoswwds_1_filterfulltext) and DocumentoObrigatorio = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV41Documentoswwds_2_dynamicfiltersselector1, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV42Documentoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Documentoswwds_4_documentosdescricao1)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV43Documentoswwds_4_documentosdescricao1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV41Documentoswwds_2_dynamicfiltersselector1, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV42Documentoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Documentoswwds_4_documentosdescricao1)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV43Documentoswwds_4_documentosdescricao1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV44Documentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV45Documentoswwds_6_dynamicfiltersselector2, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV46Documentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Documentoswwds_8_documentosdescricao2)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV47Documentoswwds_8_documentosdescricao2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV44Documentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV45Documentoswwds_6_dynamicfiltersselector2, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV46Documentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Documentoswwds_8_documentosdescricao2)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV47Documentoswwds_8_documentosdescricao2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV48Documentoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV49Documentoswwds_10_dynamicfiltersselector3, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV50Documentoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Documentoswwds_12_documentosdescricao3)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV51Documentoswwds_12_documentosdescricao3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV48Documentoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV49Documentoswwds_10_dynamicfiltersselector3, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV50Documentoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Documentoswwds_12_documentosdescricao3)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV51Documentoswwds_12_documentosdescricao3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Documentoswwds_14_tfdocumentosdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Documentoswwds_13_tfdocumentosdescricao)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV52Documentoswwds_13_tfdocumentosdescricao)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Documentoswwds_14_tfdocumentosdescricao_sel)) && ! ( StringUtil.StrCmp(AV53Documentoswwds_14_tfdocumentosdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao = ( :AV53Documentoswwds_14_tfdocumentosdescricao_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV53Documentoswwds_14_tfdocumentosdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocumentosDescricao IS NULL or (char_length(trim(trailing ' ' from DocumentosDescricao))=0))");
         }
         if ( AV54Documentoswwds_15_tfdocumentosstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(DocumentosStatus = TRUE)");
         }
         if ( AV54Documentoswwds_15_tfdocumentosstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(DocumentosStatus = FALSE)");
         }
         if ( AV55Documentoswwds_16_tfdocumentoobrigatorio_sel == 1 )
         {
            AddWhere(sWhereString, "(DocumentoObrigatorio = TRUE)");
         }
         if ( AV55Documentoswwds_16_tfdocumentoobrigatorio_sel == 2 )
         {
            AddWhere(sWhereString, "(DocumentoObrigatorio = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY DocumentosDescricao";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocumentosDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY DocumentosStatus";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocumentosStatus DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY DocumentoObrigatorio";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocumentoObrigatorio DESC";
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
                     return conditional_P009R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP009R2;
          prmP009R2 = new Object[] {
          new ParDef("lV40Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Documentoswwds_4_documentosdescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV43Documentoswwds_4_documentosdescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV47Documentoswwds_8_documentosdescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV47Documentoswwds_8_documentosdescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV51Documentoswwds_12_documentosdescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV51Documentoswwds_12_documentosdescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV52Documentoswwds_13_tfdocumentosdescricao",GXType.VarChar,40,0) ,
          new ParDef("AV53Documentoswwds_14_tfdocumentosdescricao_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009R2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
