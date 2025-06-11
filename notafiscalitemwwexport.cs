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
   public class notafiscalitemwwexport : GXProcedure
   {
      public notafiscalitemwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalitemwwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "NotaFiscalItemWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "NOTAFISCALITEMCODIGO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21NotaFiscalItemCodigo1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21NotaFiscalItemCodigo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Item Codigo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Item Codigo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21NotaFiscalItemCodigo1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "NOTAFISCALITEMCODIGO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25NotaFiscalItemCodigo2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25NotaFiscalItemCodigo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Item Codigo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Item Codigo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25NotaFiscalItemCodigo2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "NOTAFISCALITEMCODIGO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29NotaFiscalItemCodigo3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29NotaFiscalItemCodigo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Item Codigo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Item Codigo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29NotaFiscalItemCodigo3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Solicitação") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaDescricao_Sel)) ? "(Vazio)" : AV36TFPropostaDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Solicitação") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFPropostaDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalItemCodigo_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Código") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalItemCodigo_Sel)) ? "(Vazio)" : AV38TFNotaFiscalItemCodigo_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalItemCodigo)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Código") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFNotaFiscalItemCodigo, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalItemDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalItemDescricao_Sel)) ? "(Vazio)" : AV40TFNotaFiscalItemDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalItemDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFNotaFiscalItemDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFNotaFiscalItemQuantidade) && (Convert.ToDecimal(0)==AV42TFNotaFiscalItemQuantidade_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Quantidade") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV41TFNotaFiscalItemQuantidade);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV42TFNotaFiscalItemQuantidade_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV43TFNotaFiscalItemValorUnitario) && (Convert.ToDecimal(0)==AV44TFNotaFiscalItemValorUnitario_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Unitário") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV43TFNotaFiscalItemValorUnitario);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV44TFNotaFiscalItemValorUnitario_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFNotaFiscalItemValorTotal) && (Convert.ToDecimal(0)==AV46TFNotaFiscalItemValorTotal_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Total") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV45TFNotaFiscalItemValorTotal);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV46TFNotaFiscalItemValorTotal_To);
         }
         if ( ! ( ( AV49TFNotaFiscalItemVendido_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV53GXV1 = 1;
            while ( AV53GXV1 <= AV49TFNotaFiscalItemVendido_Sels.Count )
            {
               AV48TFNotaFiscalItemVendido_Sel = ((string)AV49TFNotaFiscalItemVendido_Sels.Item(AV53GXV1));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusitemnota.getDescription(context,AV48TFNotaFiscalItemVendido_Sel);
               AV50i = (long)(AV50i+1);
               AV53GXV1 = (int)(AV53GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Solicitação";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Código";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Descrição";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Quantidade";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Unitário";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Total";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Notafiscalitemwwds_1_notafiscalid = AV51NotaFiscalId;
         AV56Notafiscalitemwwds_2_filterfulltext = AV18FilterFullText;
         AV57Notafiscalitemwwds_3_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV58Notafiscalitemwwds_4_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV59Notafiscalitemwwds_5_notafiscalitemcodigo1 = AV21NotaFiscalItemCodigo1;
         AV60Notafiscalitemwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV61Notafiscalitemwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV62Notafiscalitemwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV63Notafiscalitemwwds_9_notafiscalitemcodigo2 = AV25NotaFiscalItemCodigo2;
         AV64Notafiscalitemwwds_10_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV65Notafiscalitemwwds_11_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV66Notafiscalitemwwds_12_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV67Notafiscalitemwwds_13_notafiscalitemcodigo3 = AV29NotaFiscalItemCodigo3;
         AV68Notafiscalitemwwds_14_tfpropostadescricao = AV35TFPropostaDescricao;
         AV69Notafiscalitemwwds_15_tfpropostadescricao_sel = AV36TFPropostaDescricao_Sel;
         AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo = AV37TFNotaFiscalItemCodigo;
         AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = AV38TFNotaFiscalItemCodigo_Sel;
         AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao = AV39TFNotaFiscalItemDescricao;
         AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = AV40TFNotaFiscalItemDescricao_Sel;
         AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade = AV41TFNotaFiscalItemQuantidade;
         AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to = AV42TFNotaFiscalItemQuantidade_To;
         AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario = AV43TFNotaFiscalItemValorUnitario;
         AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to = AV44TFNotaFiscalItemValorUnitario_To;
         AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal = AV45TFNotaFiscalItemValorTotal;
         AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to = AV46TFNotaFiscalItemValorTotal_To;
         AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = AV49TFNotaFiscalItemVendido_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A851NotaFiscalItemVendido ,
                                              AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                              AV56Notafiscalitemwwds_2_filterfulltext ,
                                              AV57Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                              AV58Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                              AV59Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                              AV60Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                              AV61Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                              AV62Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                              AV63Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                              AV64Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                              AV65Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                              AV66Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                              AV67Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                              AV69Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                              AV68Notafiscalitemwwds_14_tfpropostadescricao ,
                                              AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                              AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                              AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                              AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                              AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                              AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                              AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                              AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                              AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                              AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                              AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels.Count ,
                                              A325PropostaDescricao ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV55Notafiscalitemwwds_1_notafiscalid ,
                                              A794NotaFiscalId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV56Notafiscalitemwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext), "%", "");
         lV59Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV59Notafiscalitemwwds_5_notafiscalitemcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV59Notafiscalitemwwds_5_notafiscalitemcodigo1), "%", "");
         lV63Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV63Notafiscalitemwwds_9_notafiscalitemcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV63Notafiscalitemwwds_9_notafiscalitemcodigo2), "%", "");
         lV67Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV67Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV67Notafiscalitemwwds_13_notafiscalitemcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV67Notafiscalitemwwds_13_notafiscalitemcodigo3), "%", "");
         lV68Notafiscalitemwwds_14_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV68Notafiscalitemwwds_14_tfpropostadescricao), "%", "");
         lV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo), "%", "");
         lV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00DQ2 */
         pr_default.execute(0, new Object[] {AV55Notafiscalitemwwds_1_notafiscalid, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV56Notafiscalitemwwds_2_filterfulltext, lV59Notafiscalitemwwds_5_notafiscalitemcodigo1, lV59Notafiscalitemwwds_5_notafiscalitemcodigo1, lV63Notafiscalitemwwds_9_notafiscalitemcodigo2, lV63Notafiscalitemwwds_9_notafiscalitemcodigo2, lV67Notafiscalitemwwds_13_notafiscalitemcodigo3, lV67Notafiscalitemwwds_13_notafiscalitemcodigo3, lV68Notafiscalitemwwds_14_tfpropostadescricao, AV69Notafiscalitemwwds_15_tfpropostadescricao_sel, lV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo, AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, lV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao, AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade, AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to, AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario, AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to, AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal, AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A323PropostaId = P00DQ2_A323PropostaId[0];
            n323PropostaId = P00DQ2_n323PropostaId[0];
            A839NotaFiscalItemValorTotal = P00DQ2_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00DQ2_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00DQ2_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00DQ2_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00DQ2_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00DQ2_n837NotaFiscalItemQuantidade[0];
            A851NotaFiscalItemVendido = P00DQ2_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = P00DQ2_n851NotaFiscalItemVendido[0];
            A833NotaFiscalItemDescricao = P00DQ2_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00DQ2_n833NotaFiscalItemDescricao[0];
            A831NotaFiscalItemCodigo = P00DQ2_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00DQ2_n831NotaFiscalItemCodigo[0];
            A325PropostaDescricao = P00DQ2_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DQ2_n325PropostaDescricao[0];
            A794NotaFiscalId = P00DQ2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DQ2_n794NotaFiscalId[0];
            A830NotaFiscalItemId = P00DQ2_A830NotaFiscalItemId[0];
            A325PropostaDescricao = P00DQ2_A325PropostaDescricao[0];
            n325PropostaDescricao = P00DQ2_n325PropostaDescricao[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A325PropostaDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A831NotaFiscalItemCodigo, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A833NotaFiscalItemDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A837NotaFiscalItemQuantidade);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A838NotaFiscalItemValorUnitario);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = (double)(A839NotaFiscalItemValorTotal);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = gxdomaindmstatusitemnota.getDescription(context,A851NotaFiscalItemVendido);
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
         AV31Session.Set("WWPExportFileName", "NotaFiscalItemWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("NotaFiscalItemWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "NotaFiscalItemWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("NotaFiscalItemWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV81GXV2 = 1;
         while ( AV81GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV81GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV35TFPropostaDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV36TFPropostaDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO") == 0 )
            {
               AV37TFNotaFiscalItemCodigo = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO_SEL") == 0 )
            {
               AV38TFNotaFiscalItemCodigo_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO") == 0 )
            {
               AV39TFNotaFiscalItemDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO_SEL") == 0 )
            {
               AV40TFNotaFiscalItemDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMQUANTIDADE") == 0 )
            {
               AV41TFNotaFiscalItemQuantidade = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV42TFNotaFiscalItemQuantidade_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORUNITARIO") == 0 )
            {
               AV43TFNotaFiscalItemValorUnitario = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV44TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORTOTAL") == 0 )
            {
               AV45TFNotaFiscalItemValorTotal = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV46TFNotaFiscalItemValorTotal_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVENDIDO_SEL") == 0 )
            {
               AV47TFNotaFiscalItemVendido_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV49TFNotaFiscalItemVendido_Sels.FromJSonString(AV47TFNotaFiscalItemVendido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&NOTAFISCALID") == 0 )
            {
               AV51NotaFiscalId = StringUtil.StrToGuid( AV34GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&NOTAFISCALSTATUS") == 0 )
            {
               AV52NotaFiscalStatus = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV81GXV2 = (int)(AV81GXV2+1);
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
         AV21NotaFiscalItemCodigo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25NotaFiscalItemCodigo2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29NotaFiscalItemCodigo3 = "";
         AV36TFPropostaDescricao_Sel = "";
         AV35TFPropostaDescricao = "";
         AV38TFNotaFiscalItemCodigo_Sel = "";
         AV37TFNotaFiscalItemCodigo = "";
         AV40TFNotaFiscalItemDescricao_Sel = "";
         AV39TFNotaFiscalItemDescricao = "";
         AV49TFNotaFiscalItemVendido_Sels = new GxSimpleCollection<string>();
         AV48TFNotaFiscalItemVendido_Sel = "";
         AV55Notafiscalitemwwds_1_notafiscalid = Guid.Empty;
         AV51NotaFiscalId = Guid.Empty;
         AV56Notafiscalitemwwds_2_filterfulltext = "";
         AV57Notafiscalitemwwds_3_dynamicfiltersselector1 = "";
         AV59Notafiscalitemwwds_5_notafiscalitemcodigo1 = "";
         AV61Notafiscalitemwwds_7_dynamicfiltersselector2 = "";
         AV63Notafiscalitemwwds_9_notafiscalitemcodigo2 = "";
         AV65Notafiscalitemwwds_11_dynamicfiltersselector3 = "";
         AV67Notafiscalitemwwds_13_notafiscalitemcodigo3 = "";
         AV68Notafiscalitemwwds_14_tfpropostadescricao = "";
         AV69Notafiscalitemwwds_15_tfpropostadescricao_sel = "";
         AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo = "";
         AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel = "";
         AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao = "";
         AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel = "";
         AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels = new GxSimpleCollection<string>();
         lV56Notafiscalitemwwds_2_filterfulltext = "";
         lV59Notafiscalitemwwds_5_notafiscalitemcodigo1 = "";
         lV63Notafiscalitemwwds_9_notafiscalitemcodigo2 = "";
         lV67Notafiscalitemwwds_13_notafiscalitemcodigo3 = "";
         lV68Notafiscalitemwwds_14_tfpropostadescricao = "";
         lV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo = "";
         lV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao = "";
         A851NotaFiscalItemVendido = "";
         A325PropostaDescricao = "";
         A831NotaFiscalItemCodigo = "";
         A833NotaFiscalItemDescricao = "";
         A794NotaFiscalId = Guid.Empty;
         P00DQ2_A323PropostaId = new int[1] ;
         P00DQ2_n323PropostaId = new bool[] {false} ;
         P00DQ2_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00DQ2_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00DQ2_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00DQ2_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00DQ2_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00DQ2_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00DQ2_A851NotaFiscalItemVendido = new string[] {""} ;
         P00DQ2_n851NotaFiscalItemVendido = new bool[] {false} ;
         P00DQ2_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00DQ2_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00DQ2_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00DQ2_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00DQ2_A325PropostaDescricao = new string[] {""} ;
         P00DQ2_n325PropostaDescricao = new bool[] {false} ;
         P00DQ2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DQ2_n794NotaFiscalId = new bool[] {false} ;
         P00DQ2_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         A830NotaFiscalItemId = Guid.Empty;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFNotaFiscalItemVendido_SelsJson = "";
         AV52NotaFiscalStatus = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitemwwexport__default(),
            new Object[][] {
                new Object[] {
               P00DQ2_A323PropostaId, P00DQ2_n323PropostaId, P00DQ2_A839NotaFiscalItemValorTotal, P00DQ2_n839NotaFiscalItemValorTotal, P00DQ2_A838NotaFiscalItemValorUnitario, P00DQ2_n838NotaFiscalItemValorUnitario, P00DQ2_A837NotaFiscalItemQuantidade, P00DQ2_n837NotaFiscalItemQuantidade, P00DQ2_A851NotaFiscalItemVendido, P00DQ2_n851NotaFiscalItemVendido,
               P00DQ2_A833NotaFiscalItemDescricao, P00DQ2_n833NotaFiscalItemDescricao, P00DQ2_A831NotaFiscalItemCodigo, P00DQ2_n831NotaFiscalItemCodigo, P00DQ2_A325PropostaDescricao, P00DQ2_n325PropostaDescricao, P00DQ2_A794NotaFiscalId, P00DQ2_n794NotaFiscalId, P00DQ2_A830NotaFiscalItemId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV58Notafiscalitemwwds_4_dynamicfiltersoperator1 ;
      private short AV62Notafiscalitemwwds_8_dynamicfiltersoperator2 ;
      private short AV66Notafiscalitemwwds_12_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV53GXV1 ;
      private int AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ;
      private int A323PropostaId ;
      private int AV81GXV2 ;
      private long AV50i ;
      private decimal AV41TFNotaFiscalItemQuantidade ;
      private decimal AV42TFNotaFiscalItemQuantidade_To ;
      private decimal AV43TFNotaFiscalItemValorUnitario ;
      private decimal AV44TFNotaFiscalItemValorUnitario_To ;
      private decimal AV45TFNotaFiscalItemValorTotal ;
      private decimal AV46TFNotaFiscalItemValorTotal_To ;
      private decimal AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade ;
      private decimal AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ;
      private decimal AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ;
      private decimal AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ;
      private decimal AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ;
      private decimal AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal A839NotaFiscalItemValorTotal ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV60Notafiscalitemwwds_6_dynamicfiltersenabled2 ;
      private bool AV64Notafiscalitemwwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n323PropostaId ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n851NotaFiscalItemVendido ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n831NotaFiscalItemCodigo ;
      private bool n325PropostaDescricao ;
      private bool n794NotaFiscalId ;
      private string AV47TFNotaFiscalItemVendido_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21NotaFiscalItemCodigo1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25NotaFiscalItemCodigo2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29NotaFiscalItemCodigo3 ;
      private string AV36TFPropostaDescricao_Sel ;
      private string AV35TFPropostaDescricao ;
      private string AV38TFNotaFiscalItemCodigo_Sel ;
      private string AV37TFNotaFiscalItemCodigo ;
      private string AV40TFNotaFiscalItemDescricao_Sel ;
      private string AV39TFNotaFiscalItemDescricao ;
      private string AV48TFNotaFiscalItemVendido_Sel ;
      private string AV56Notafiscalitemwwds_2_filterfulltext ;
      private string AV57Notafiscalitemwwds_3_dynamicfiltersselector1 ;
      private string AV59Notafiscalitemwwds_5_notafiscalitemcodigo1 ;
      private string AV61Notafiscalitemwwds_7_dynamicfiltersselector2 ;
      private string AV63Notafiscalitemwwds_9_notafiscalitemcodigo2 ;
      private string AV65Notafiscalitemwwds_11_dynamicfiltersselector3 ;
      private string AV67Notafiscalitemwwds_13_notafiscalitemcodigo3 ;
      private string AV68Notafiscalitemwwds_14_tfpropostadescricao ;
      private string AV69Notafiscalitemwwds_15_tfpropostadescricao_sel ;
      private string AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo ;
      private string AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ;
      private string AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao ;
      private string AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ;
      private string lV56Notafiscalitemwwds_2_filterfulltext ;
      private string lV59Notafiscalitemwwds_5_notafiscalitemcodigo1 ;
      private string lV63Notafiscalitemwwds_9_notafiscalitemcodigo2 ;
      private string lV67Notafiscalitemwwds_13_notafiscalitemcodigo3 ;
      private string lV68Notafiscalitemwwds_14_tfpropostadescricao ;
      private string lV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo ;
      private string lV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao ;
      private string A851NotaFiscalItemVendido ;
      private string A325PropostaDescricao ;
      private string A831NotaFiscalItemCodigo ;
      private string A833NotaFiscalItemDescricao ;
      private string AV52NotaFiscalStatus ;
      private Guid AV55Notafiscalitemwwds_1_notafiscalid ;
      private Guid AV51NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private Guid A830NotaFiscalItemId ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV49TFNotaFiscalItemVendido_Sels ;
      private GxSimpleCollection<string> AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00DQ2_A323PropostaId ;
      private bool[] P00DQ2_n323PropostaId ;
      private decimal[] P00DQ2_A839NotaFiscalItemValorTotal ;
      private bool[] P00DQ2_n839NotaFiscalItemValorTotal ;
      private decimal[] P00DQ2_A838NotaFiscalItemValorUnitario ;
      private bool[] P00DQ2_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00DQ2_A837NotaFiscalItemQuantidade ;
      private bool[] P00DQ2_n837NotaFiscalItemQuantidade ;
      private string[] P00DQ2_A851NotaFiscalItemVendido ;
      private bool[] P00DQ2_n851NotaFiscalItemVendido ;
      private string[] P00DQ2_A833NotaFiscalItemDescricao ;
      private bool[] P00DQ2_n833NotaFiscalItemDescricao ;
      private string[] P00DQ2_A831NotaFiscalItemCodigo ;
      private bool[] P00DQ2_n831NotaFiscalItemCodigo ;
      private string[] P00DQ2_A325PropostaDescricao ;
      private bool[] P00DQ2_n325PropostaDescricao ;
      private Guid[] P00DQ2_A794NotaFiscalId ;
      private bool[] P00DQ2_n794NotaFiscalId ;
      private Guid[] P00DQ2_A830NotaFiscalItemId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class notafiscalitemwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DQ2( IGxContext context ,
                                             string A851NotaFiscalItemVendido ,
                                             GxSimpleCollection<string> AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels ,
                                             string AV56Notafiscalitemwwds_2_filterfulltext ,
                                             string AV57Notafiscalitemwwds_3_dynamicfiltersselector1 ,
                                             short AV58Notafiscalitemwwds_4_dynamicfiltersoperator1 ,
                                             string AV59Notafiscalitemwwds_5_notafiscalitemcodigo1 ,
                                             bool AV60Notafiscalitemwwds_6_dynamicfiltersenabled2 ,
                                             string AV61Notafiscalitemwwds_7_dynamicfiltersselector2 ,
                                             short AV62Notafiscalitemwwds_8_dynamicfiltersoperator2 ,
                                             string AV63Notafiscalitemwwds_9_notafiscalitemcodigo2 ,
                                             bool AV64Notafiscalitemwwds_10_dynamicfiltersenabled3 ,
                                             string AV65Notafiscalitemwwds_11_dynamicfiltersselector3 ,
                                             short AV66Notafiscalitemwwds_12_dynamicfiltersoperator3 ,
                                             string AV67Notafiscalitemwwds_13_notafiscalitemcodigo3 ,
                                             string AV69Notafiscalitemwwds_15_tfpropostadescricao_sel ,
                                             string AV68Notafiscalitemwwds_14_tfpropostadescricao ,
                                             string AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel ,
                                             string AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo ,
                                             string AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel ,
                                             string AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao ,
                                             decimal AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade ,
                                             decimal AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to ,
                                             decimal AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario ,
                                             decimal AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal ,
                                             decimal AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to ,
                                             int AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count ,
                                             string A325PropostaDescricao ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             Guid AV55Notafiscalitemwwds_1_notafiscalid ,
                                             Guid A794NotaFiscalId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PropostaId, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemVendido, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemCodigo, T2.PropostaDescricao, T1.NotaFiscalId, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(T1.NotaFiscalId = :AV55Notafiscalitemwwds_1_notafiscalid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Notafiscalitemwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.PropostaDescricao like '%' || :lV56Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemCodigo like '%' || :lV56Notafiscalitemwwds_2_filterfulltext) or ( T1.NotaFiscalItemDescricao like '%' || :lV56Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemQuantidade,'99999999990.999999'), 2) like '%' || :lV56Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorUnitario,'999999999999990.99'), 2) like '%' || :lV56Notafiscalitemwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NotaFiscalItemValorTotal,'999999999999990.99'), 2) like '%' || :lV56Notafiscalitemwwds_2_filterfulltext) or ( 'vendido' like '%' || LOWER(:lV56Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'VENDIDO')) or ( 'aberto' like '%' || LOWER(:lV56Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'ABERTO')) or ( 'devolvido' like '%' || LOWER(:lV56Notafiscalitemwwds_2_filterfulltext) and T1.NotaFiscalItemVendido = ( 'DEVOLVIDO')))");
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
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV58Notafiscalitemwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV59Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Notafiscalitemwwds_3_dynamicfiltersselector1, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV58Notafiscalitemwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Notafiscalitemwwds_5_notafiscalitemcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV59Notafiscalitemwwds_5_notafiscalitemcodigo1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV60Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV62Notafiscalitemwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV63Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV60Notafiscalitemwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Notafiscalitemwwds_7_dynamicfiltersselector2, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV62Notafiscalitemwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Notafiscalitemwwds_9_notafiscalitemcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV63Notafiscalitemwwds_9_notafiscalitemcodigo2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV64Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV66Notafiscalitemwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV67Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV64Notafiscalitemwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Notafiscalitemwwds_11_dynamicfiltersselector3, "NOTAFISCALITEMCODIGO") == 0 ) && ( AV66Notafiscalitemwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Notafiscalitemwwds_13_notafiscalitemcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like '%' || :lV67Notafiscalitemwwds_13_notafiscalitemcodigo3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Notafiscalitemwwds_14_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao like :lV68Notafiscalitemwwds_14_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Notafiscalitemwwds_15_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV69Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PropostaDescricao = ( :AV69Notafiscalitemwwds_15_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV69Notafiscalitemwwds_15_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PropostaDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80Notafiscalitemwwds_26_tfnotafiscalitemvendido_sels, "T1.NotaFiscalItemVendido IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemCodigo";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemCodigo DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T2.PropostaDescricao";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T2.PropostaDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemDescricao";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemQuantidade";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemQuantidade DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemValorUnitario";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemValorUnitario DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemValorTotal";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemValorTotal DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId, T1.NotaFiscalItemVendido";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalId DESC, T1.NotaFiscalItemVendido DESC";
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
                     return conditional_P00DQ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] , (Guid)dynConstraints[35] , (Guid)dynConstraints[36] );
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
          Object[] prmP00DQ2;
          prmP00DQ2 = new Object[] {
          new ParDef("AV55Notafiscalitemwwds_1_notafiscalid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Notafiscalitemwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV59Notafiscalitemwwds_5_notafiscalitemcodigo1",GXType.VarChar,60,0) ,
          new ParDef("lV63Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV63Notafiscalitemwwds_9_notafiscalitemcodigo2",GXType.VarChar,60,0) ,
          new ParDef("lV67Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV67Notafiscalitemwwds_13_notafiscalitemcodigo3",GXType.VarChar,60,0) ,
          new ParDef("lV68Notafiscalitemwwds_14_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV69Notafiscalitemwwds_15_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV70Notafiscalitemwwds_16_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV71Notafiscalitemwwds_17_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV72Notafiscalitemwwds_18_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV73Notafiscalitemwwds_19_tfnotafiscalitemdescricao_sel",GXType.VarChar,255,0) ,
          new ParDef("AV74Notafiscalitemwwds_20_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV75Notafiscalitemwwds_21_tfnotafiscalitemquantidade_to",GXType.Number,18,6) ,
          new ParDef("AV76Notafiscalitemwwds_22_tfnotafiscalitemvalorunitario",GXType.Number,18,2) ,
          new ParDef("AV77Notafiscalitemwwds_23_tfnotafiscalitemvalorunitario_to",GXType.Number,18,2) ,
          new ParDef("AV78Notafiscalitemwwds_24_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV79Notafiscalitemwwds_25_tfnotafiscalitemvalortotal_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00DQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DQ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10);
                return;
       }
    }

 }

}
