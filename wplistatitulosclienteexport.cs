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
   public class wplistatitulosclienteexport : GXProcedure
   {
      public wplistatitulosclienteexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistatitulosclienteexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WpListaTitulosClienteExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV21DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV23TituloValor1 = NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV23TituloValor1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV23TituloValor1);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV27TituloValor2 = NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV27TituloValor2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV27TituloValor2);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31TituloValor3 = NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV31TituloValor3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV31TituloValor3);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFTituloId) && (0==AV38TFTituloId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Titulo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFTituloId;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFTituloId_To;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV39TFTituloValor) && (Convert.ToDecimal(0)==AV40TFTituloValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV39TFTituloValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV40TFTituloValor_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFTituloDesconto) && (Convert.ToDecimal(0)==AV42TFTituloDesconto_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Desconto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV41TFTituloDesconto);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV42TFTituloDesconto_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFTituloCompetencia_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Competência") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFTituloCompetencia_F_Sel)) ? "(Vazio)" : AV44TFTituloCompetencia_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTituloCompetencia_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Competência") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFTituloCompetencia_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV45TFTituloProrrogacao) && (DateTime.MinValue==AV46TFTituloProrrogacao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vencimento") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV45TFTituloProrrogacao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV46TFTituloProrrogacao_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( ( AV49TFTituloTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV54i = 1;
            AV55GXV1 = 1;
            while ( AV55GXV1 <= AV49TFTituloTipo_Sels.Count )
            {
               AV48TFTituloTipo_Sel = ((string)AV49TFTituloTipo_Sels.Item(AV55GXV1));
               if ( AV54i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmtitulodc.getDescription(context,AV48TFTituloTipo_Sel);
               AV54i = (long)(AV54i+1);
               AV55GXV1 = (int)(AV55GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV50TFTituloSaldo_F) && (Convert.ToDecimal(0)==AV51TFTituloSaldo_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Saldo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV50TFTituloSaldo_F);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV51TFTituloSaldo_F_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFTituloStatus_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFTituloStatus_F_Sel)) ? "(Vazio)" : AV53TFTituloStatus_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTituloStatus_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFTituloStatus_F, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Titulo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Desconto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Competência";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Vencimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Tipo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Saldo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Situação";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Wplistatitulosclienteds_1_clienteid = AV16ClienteId;
         AV58Wplistatitulosclienteds_2_filterfulltext = AV20FilterFullText;
         AV59Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV21DynamicFiltersSelector1;
         AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV22DynamicFiltersOperator1;
         AV61Wplistatitulosclienteds_5_titulovalor1 = AV23TituloValor1;
         AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV63Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV65Wplistatitulosclienteds_9_titulovalor2 = AV27TituloValor2;
         AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV67Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV69Wplistatitulosclienteds_13_titulovalor3 = AV31TituloValor3;
         AV70Wplistatitulosclienteds_14_tftituloid = AV37TFTituloId;
         AV71Wplistatitulosclienteds_15_tftituloid_to = AV38TFTituloId_To;
         AV72Wplistatitulosclienteds_16_tftitulovalor = AV39TFTituloValor;
         AV73Wplistatitulosclienteds_17_tftitulovalor_to = AV40TFTituloValor_To;
         AV74Wplistatitulosclienteds_18_tftitulodesconto = AV41TFTituloDesconto;
         AV75Wplistatitulosclienteds_19_tftitulodesconto_to = AV42TFTituloDesconto_To;
         AV76Wplistatitulosclienteds_20_tftitulocompetencia_f = AV43TFTituloCompetencia_F;
         AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV44TFTituloCompetencia_F_Sel;
         AV78Wplistatitulosclienteds_22_tftituloprorrogacao = AV45TFTituloProrrogacao;
         AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV46TFTituloProrrogacao_To;
         AV80Wplistatitulosclienteds_24_tftitulotipo_sels = AV49TFTituloTipo_Sels;
         AV81Wplistatitulosclienteds_25_tftitulosaldo_f = AV50TFTituloSaldo_F;
         AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV51TFTituloSaldo_F_To;
         AV83Wplistatitulosclienteds_27_tftitulostatus_f = AV52TFTituloStatus_F;
         AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV53TFTituloStatus_F_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV80Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                              AV59Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                              AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                              AV61Wplistatitulosclienteds_5_titulovalor1 ,
                                              AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                              AV63Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                              AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                              AV65Wplistatitulosclienteds_9_titulovalor2 ,
                                              AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                              AV67Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                              AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                              AV69Wplistatitulosclienteds_13_titulovalor3 ,
                                              AV70Wplistatitulosclienteds_14_tftituloid ,
                                              AV71Wplistatitulosclienteds_15_tftituloid_to ,
                                              AV72Wplistatitulosclienteds_16_tftitulovalor ,
                                              AV73Wplistatitulosclienteds_17_tftitulovalor_to ,
                                              AV74Wplistatitulosclienteds_18_tftitulodesconto ,
                                              AV75Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                              AV78Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                              AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                              AV80Wplistatitulosclienteds_24_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A261TituloId ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV18OrderedBy ,
                                              AV19OrderedDsc ,
                                              AV58Wplistatitulosclienteds_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                              AV76Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                              AV81Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                              AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                              AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                              AV83Wplistatitulosclienteds_27_tftitulostatus_f ,
                                              A284TituloDeleted ,
                                              A168ClienteId ,
                                              AV57Wplistatitulosclienteds_1_clienteid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV83Wplistatitulosclienteds_27_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV83Wplistatitulosclienteds_27_tftitulostatus_f), "%", "");
         /* Using cursor P00DH4 */
         pr_default.execute(0, new Object[] {AV81Wplistatitulosclienteds_25_tftitulosaldo_f, AV81Wplistatitulosclienteds_25_tftitulosaldo_f, AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV83Wplistatitulosclienteds_27_tftitulostatus_f, lV83Wplistatitulosclienteds_27_tftitulostatus_f, AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV57Wplistatitulosclienteds_1_clienteid, AV61Wplistatitulosclienteds_5_titulovalor1, AV61Wplistatitulosclienteds_5_titulovalor1, AV61Wplistatitulosclienteds_5_titulovalor1, AV65Wplistatitulosclienteds_9_titulovalor2, AV65Wplistatitulosclienteds_9_titulovalor2, AV65Wplistatitulosclienteds_9_titulovalor2, AV69Wplistatitulosclienteds_13_titulovalor3, AV69Wplistatitulosclienteds_13_titulovalor3, AV69Wplistatitulosclienteds_13_titulovalor3, AV70Wplistatitulosclienteds_14_tftituloid, AV71Wplistatitulosclienteds_15_tftituloid_to, AV72Wplistatitulosclienteds_16_tftitulovalor, AV73Wplistatitulosclienteds_17_tftitulovalor_to, AV74Wplistatitulosclienteds_18_tftitulodesconto, AV75Wplistatitulosclienteds_19_tftitulodesconto_to, AV78Wplistatitulosclienteds_22_tftituloprorrogacao, AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00DH4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00DH4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00DH4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DH4_n794NotaFiscalId[0];
            A284TituloDeleted = P00DH4_A284TituloDeleted[0];
            n284TituloDeleted = P00DH4_n284TituloDeleted[0];
            A264TituloProrrogacao = P00DH4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00DH4_n264TituloProrrogacao[0];
            A276TituloDesconto = P00DH4_A276TituloDesconto[0];
            n276TituloDesconto = P00DH4_n276TituloDesconto[0];
            A261TituloId = P00DH4_A261TituloId[0];
            n261TituloId = P00DH4_n261TituloId[0];
            A282TituloStatus_F = P00DH4_A282TituloStatus_F[0];
            A283TituloTipo = P00DH4_A283TituloTipo[0];
            n283TituloTipo = P00DH4_n283TituloTipo[0];
            A168ClienteId = P00DH4_A168ClienteId[0];
            n168ClienteId = P00DH4_n168ClienteId[0];
            A275TituloSaldo_F = P00DH4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00DH4_n275TituloSaldo_F[0];
            A262TituloValor = P00DH4_A262TituloValor[0];
            n262TituloValor = P00DH4_n262TituloValor[0];
            A286TituloCompetenciaAno = P00DH4_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00DH4_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00DH4_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00DH4_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00DH4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DH4_n794NotaFiscalId[0];
            A168ClienteId = P00DH4_A168ClienteId[0];
            n168ClienteId = P00DH4_n168ClienteId[0];
            A275TituloSaldo_F = P00DH4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00DH4_n275TituloSaldo_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wplistatitulosclienteds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A261TituloId), 9, 0) , StringUtil.PadR( "%" + AV58Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV58Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV58Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV58Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV58Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV58Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV58Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV58Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wplistatitulosclienteds_20_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV76Wplistatitulosclienteds_20_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
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
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A261TituloId;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(A262TituloValor);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A276TituloDesconto);
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A295TituloCompetencia_F, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( A264TituloProrrogacao ) ;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = GXt_dtime3;
                        if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) < DateTimeUtil.ResetTime ( Gx_date ) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                        }
                        else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) == DateTimeUtil.ResetTime ( Gx_date ) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                        }
                        else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) > DateTimeUtil.ResetTime ( Gx_date ) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = gxdomaindmtitulodc.getDescription(context,A283TituloTipo);
                        if ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                        }
                        else if ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Number = (double)(A275TituloSaldo_F);
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A282TituloStatus_F, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = GXt_char1;
                        /* Execute user subroutine: 'AFTERWRITELINE' */
                        S172 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
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
         AV33Session.Set("WWPExportFilePath", AV11Filename);
         AV33Session.Set("WWPExportFileName", "WpListaTitulosClienteExport.xlsx");
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
         if ( StringUtil.StrCmp(AV33Session.Get("WpListaTitulosClienteGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpListaTitulosClienteGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("WpListaTitulosClienteGridState"), null, "", "");
         }
         AV18OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV19OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV86GXV2 = 1;
         while ( AV86GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV86GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOID") == 0 )
            {
               AV37TFTituloId = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFTituloId_To = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV39TFTituloValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV40TFTituloValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV41TFTituloDesconto = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV42TFTituloDesconto_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV43TFTituloCompetencia_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV44TFTituloCompetencia_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV45TFTituloProrrogacao = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV46TFTituloProrrogacao_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV47TFTituloTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV49TFTituloTipo_Sels.FromJSonString(AV47TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOSALDO_F") == 0 )
            {
               AV50TFTituloSaldo_F = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV51TFTituloSaldo_F_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F") == 0 )
            {
               AV52TFTituloStatus_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F_SEL") == 0 )
            {
               AV53TFTituloStatus_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV16ClienteId = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTERAZAOSOCIAL") == 0 )
            {
               AV17ClienteRazaoSocial = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV86GXV2 = (int)(AV86GXV2+1);
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
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV21DynamicFiltersSelector1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV44TFTituloCompetencia_F_Sel = "";
         AV43TFTituloCompetencia_F = "";
         AV45TFTituloProrrogacao = DateTime.MinValue;
         AV46TFTituloProrrogacao_To = DateTime.MinValue;
         AV49TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV48TFTituloTipo_Sel = "";
         AV53TFTituloStatus_F_Sel = "";
         AV52TFTituloStatus_F = "";
         AV58Wplistatitulosclienteds_2_filterfulltext = "";
         AV59Wplistatitulosclienteds_3_dynamicfiltersselector1 = "";
         AV63Wplistatitulosclienteds_7_dynamicfiltersselector2 = "";
         AV67Wplistatitulosclienteds_11_dynamicfiltersselector3 = "";
         AV76Wplistatitulosclienteds_20_tftitulocompetencia_f = "";
         AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = "";
         AV78Wplistatitulosclienteds_22_tftituloprorrogacao = DateTime.MinValue;
         AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to = DateTime.MinValue;
         AV80Wplistatitulosclienteds_24_tftitulotipo_sels = new GxSimpleCollection<string>();
         AV83Wplistatitulosclienteds_27_tftitulostatus_f = "";
         AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel = "";
         lV58Wplistatitulosclienteds_2_filterfulltext = "";
         lV83Wplistatitulosclienteds_27_tftitulostatus_f = "";
         A283TituloTipo = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A282TituloStatus_F = "";
         P00DH4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00DH4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00DH4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DH4_n794NotaFiscalId = new bool[] {false} ;
         P00DH4_A284TituloDeleted = new bool[] {false} ;
         P00DH4_n284TituloDeleted = new bool[] {false} ;
         P00DH4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00DH4_n264TituloProrrogacao = new bool[] {false} ;
         P00DH4_A276TituloDesconto = new decimal[1] ;
         P00DH4_n276TituloDesconto = new bool[] {false} ;
         P00DH4_A261TituloId = new int[1] ;
         P00DH4_n261TituloId = new bool[] {false} ;
         P00DH4_A282TituloStatus_F = new string[] {""} ;
         P00DH4_A283TituloTipo = new string[] {""} ;
         P00DH4_n283TituloTipo = new bool[] {false} ;
         P00DH4_A168ClienteId = new int[1] ;
         P00DH4_n168ClienteId = new bool[] {false} ;
         P00DH4_A275TituloSaldo_F = new decimal[1] ;
         P00DH4_n275TituloSaldo_F = new bool[] {false} ;
         P00DH4_A262TituloValor = new decimal[1] ;
         P00DH4_n262TituloValor = new bool[] {false} ;
         P00DH4_A286TituloCompetenciaAno = new short[1] ;
         P00DH4_n286TituloCompetenciaAno = new bool[] {false} ;
         P00DH4_A287TituloCompetenciaMes = new short[1] ;
         P00DH4_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         Gx_date = DateTime.MinValue;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFTituloTipo_SelsJson = "";
         AV17ClienteRazaoSocial = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistatitulosclienteexport__default(),
            new Object[][] {
                new Object[] {
               P00DH4_A890NotaFiscalParcelamentoID, P00DH4_n890NotaFiscalParcelamentoID, P00DH4_A794NotaFiscalId, P00DH4_n794NotaFiscalId, P00DH4_A284TituloDeleted, P00DH4_n284TituloDeleted, P00DH4_A264TituloProrrogacao, P00DH4_n264TituloProrrogacao, P00DH4_A276TituloDesconto, P00DH4_n276TituloDesconto,
               P00DH4_A261TituloId, P00DH4_A282TituloStatus_F, P00DH4_A283TituloTipo, P00DH4_n283TituloTipo, P00DH4_A168ClienteId, P00DH4_n168ClienteId, P00DH4_A275TituloSaldo_F, P00DH4_n275TituloSaldo_F, P00DH4_A262TituloValor, P00DH4_n262TituloValor,
               P00DH4_A286TituloCompetenciaAno, P00DH4_n286TituloCompetenciaAno, P00DH4_A287TituloCompetenciaMes, P00DH4_n287TituloCompetenciaMes
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV22DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 ;
      private short AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 ;
      private short AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 ;
      private short AV18OrderedBy ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV37TFTituloId ;
      private int AV38TFTituloId_To ;
      private int AV55GXV1 ;
      private int AV57Wplistatitulosclienteds_1_clienteid ;
      private int AV16ClienteId ;
      private int AV70Wplistatitulosclienteds_14_tftituloid ;
      private int AV71Wplistatitulosclienteds_15_tftituloid_to ;
      private int AV80Wplistatitulosclienteds_24_tftitulotipo_sels_Count ;
      private int A261TituloId ;
      private int A168ClienteId ;
      private int AV86GXV2 ;
      private long AV54i ;
      private decimal AV23TituloValor1 ;
      private decimal AV27TituloValor2 ;
      private decimal AV31TituloValor3 ;
      private decimal AV39TFTituloValor ;
      private decimal AV40TFTituloValor_To ;
      private decimal AV41TFTituloDesconto ;
      private decimal AV42TFTituloDesconto_To ;
      private decimal AV50TFTituloSaldo_F ;
      private decimal AV51TFTituloSaldo_F_To ;
      private decimal AV61Wplistatitulosclienteds_5_titulovalor1 ;
      private decimal AV65Wplistatitulosclienteds_9_titulovalor2 ;
      private decimal AV69Wplistatitulosclienteds_13_titulovalor3 ;
      private decimal AV72Wplistatitulosclienteds_16_tftitulovalor ;
      private decimal AV73Wplistatitulosclienteds_17_tftitulovalor_to ;
      private decimal AV74Wplistatitulosclienteds_18_tftitulodesconto ;
      private decimal AV75Wplistatitulosclienteds_19_tftitulodesconto_to ;
      private decimal AV81Wplistatitulosclienteds_25_tftitulosaldo_f ;
      private decimal AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A275TituloSaldo_F ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV45TFTituloProrrogacao ;
      private DateTime AV46TFTituloProrrogacao_To ;
      private DateTime AV78Wplistatitulosclienteds_22_tftituloprorrogacao ;
      private DateTime AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 ;
      private bool AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 ;
      private bool AV19OrderedDsc ;
      private bool A284TituloDeleted ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n284TituloDeleted ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n261TituloId ;
      private bool n283TituloTipo ;
      private bool n168ClienteId ;
      private bool n275TituloSaldo_F ;
      private bool n262TituloValor ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private string AV47TFTituloTipo_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV20FilterFullText ;
      private string AV21DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV44TFTituloCompetencia_F_Sel ;
      private string AV43TFTituloCompetencia_F ;
      private string AV48TFTituloTipo_Sel ;
      private string AV53TFTituloStatus_F_Sel ;
      private string AV52TFTituloStatus_F ;
      private string AV58Wplistatitulosclienteds_2_filterfulltext ;
      private string AV59Wplistatitulosclienteds_3_dynamicfiltersselector1 ;
      private string AV63Wplistatitulosclienteds_7_dynamicfiltersselector2 ;
      private string AV67Wplistatitulosclienteds_11_dynamicfiltersselector3 ;
      private string AV76Wplistatitulosclienteds_20_tftitulocompetencia_f ;
      private string AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ;
      private string AV83Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel ;
      private string lV58Wplistatitulosclienteds_2_filterfulltext ;
      private string lV83Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string A283TituloTipo ;
      private string A295TituloCompetencia_F ;
      private string A282TituloStatus_F ;
      private string AV17ClienteRazaoSocial ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV33Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV49TFTituloTipo_Sels ;
      private GxSimpleCollection<string> AV80Wplistatitulosclienteds_24_tftitulotipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DH4_A890NotaFiscalParcelamentoID ;
      private bool[] P00DH4_n890NotaFiscalParcelamentoID ;
      private Guid[] P00DH4_A794NotaFiscalId ;
      private bool[] P00DH4_n794NotaFiscalId ;
      private bool[] P00DH4_A284TituloDeleted ;
      private bool[] P00DH4_n284TituloDeleted ;
      private DateTime[] P00DH4_A264TituloProrrogacao ;
      private bool[] P00DH4_n264TituloProrrogacao ;
      private decimal[] P00DH4_A276TituloDesconto ;
      private bool[] P00DH4_n276TituloDesconto ;
      private int[] P00DH4_A261TituloId ;
      private bool[] P00DH4_n261TituloId ;
      private string[] P00DH4_A282TituloStatus_F ;
      private string[] P00DH4_A283TituloTipo ;
      private bool[] P00DH4_n283TituloTipo ;
      private int[] P00DH4_A168ClienteId ;
      private bool[] P00DH4_n168ClienteId ;
      private decimal[] P00DH4_A275TituloSaldo_F ;
      private bool[] P00DH4_n275TituloSaldo_F ;
      private decimal[] P00DH4_A262TituloValor ;
      private bool[] P00DH4_n262TituloValor ;
      private short[] P00DH4_A286TituloCompetenciaAno ;
      private bool[] P00DH4_n286TituloCompetenciaAno ;
      private short[] P00DH4_A287TituloCompetenciaMes ;
      private bool[] P00DH4_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wplistatitulosclienteexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DH4( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV80Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                             string AV59Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                             short AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                             decimal AV61Wplistatitulosclienteds_5_titulovalor1 ,
                                             bool AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                             string AV63Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                             short AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                             decimal AV65Wplistatitulosclienteds_9_titulovalor2 ,
                                             bool AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                             string AV67Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                             short AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                             decimal AV69Wplistatitulosclienteds_13_titulovalor3 ,
                                             int AV70Wplistatitulosclienteds_14_tftituloid ,
                                             int AV71Wplistatitulosclienteds_15_tftituloid_to ,
                                             decimal AV72Wplistatitulosclienteds_16_tftitulovalor ,
                                             decimal AV73Wplistatitulosclienteds_17_tftitulovalor_to ,
                                             decimal AV74Wplistatitulosclienteds_18_tftitulodesconto ,
                                             decimal AV75Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                             DateTime AV78Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                             DateTime AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                             int AV80Wplistatitulosclienteds_24_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             int A261TituloId ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             short AV18OrderedBy ,
                                             bool AV19OrderedDsc ,
                                             string AV58Wplistatitulosclienteds_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV77Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                             string AV76Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                             decimal AV81Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                             decimal AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                             string AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                             string AV83Wplistatitulosclienteds_27_tftitulostatus_f ,
                                             bool A284TituloDeleted ,
                                             int A168ClienteId ,
                                             int AV57Wplistatitulosclienteds_1_clienteid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[29];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloDeleted, T1.TituloProrrogacao, T1.TituloDesconto, T1.TituloId, CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T1.TituloTipo, T3.ClienteId, COALESCE( T4.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloValor, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM (((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) INNER JOIN (SELECT ( COALESCE( T5.TituloValor, 0) - COALESCE( T5.TituloDesconto, 0)) - COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T5.TituloId FROM (Titulo T5 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T5.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = T5.TituloId) ) T4 ON T4.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV81Wplistatitulosclienteds_25_tftitulosaldo_f = 0) or ( COALESCE( T4.TituloSaldo_F, 0) >= :AV81Wplistatitulosclienteds_25_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to = 0) or ( COALESCE( T4.TituloSaldo_F, 0) <= :AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV83Wplistatitulosclienteds_27_tftitulostatus_f))=0))) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END like :lV83Wplistatitulosclienteds_27_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and Not :AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel = ( '<#Empty#>')) or ( CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END = ( :AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from CASE  WHEN (COALESCE( T4.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T4.TituloSaldo_F, 0) = COALESCE( T1.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END))=0)))");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(T3.ClienteId = :AV57Wplistatitulosclienteds_1_clienteid)");
         if ( ( StringUtil.StrCmp(AV59Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV61Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV61Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV61Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV61Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV60Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV61Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV61Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV65Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV65Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV62Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV64Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV65Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV69Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV69Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV69Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV69Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV66Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV68Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV69Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV69Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (0==AV70Wplistatitulosclienteds_14_tftituloid) )
         {
            AddWhere(sWhereString, "(T1.TituloId >= :AV70Wplistatitulosclienteds_14_tftituloid)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV71Wplistatitulosclienteds_15_tftituloid_to) )
         {
            AddWhere(sWhereString, "(T1.TituloId <= :AV71Wplistatitulosclienteds_15_tftituloid_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Wplistatitulosclienteds_16_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV72Wplistatitulosclienteds_16_tftitulovalor)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Wplistatitulosclienteds_17_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV73Wplistatitulosclienteds_17_tftitulovalor_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Wplistatitulosclienteds_18_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV74Wplistatitulosclienteds_18_tftitulodesconto)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Wplistatitulosclienteds_19_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV75Wplistatitulosclienteds_19_tftitulodesconto_to)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Wplistatitulosclienteds_22_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV78Wplistatitulosclienteds_22_tftituloprorrogacao)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( AV80Wplistatitulosclienteds_24_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80Wplistatitulosclienteds_24_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV18OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.TituloCompetenciaAno DESC, T1.TituloCompetenciaMes DESC";
         }
         else if ( ( AV18OrderedBy == 2 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloId";
         }
         else if ( ( AV18OrderedBy == 2 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloId DESC";
         }
         else if ( ( AV18OrderedBy == 3 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloValor";
         }
         else if ( ( AV18OrderedBy == 3 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloValor DESC";
         }
         else if ( ( AV18OrderedBy == 4 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloDesconto";
         }
         else if ( ( AV18OrderedBy == 4 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloDesconto DESC";
         }
         else if ( ( AV18OrderedBy == 5 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloProrrogacao";
         }
         else if ( ( AV18OrderedBy == 5 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloProrrogacao DESC";
         }
         else if ( ( AV18OrderedBy == 6 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloTipo";
         }
         else if ( ( AV18OrderedBy == 6 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloTipo DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DH4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] );
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
          Object[] prmP00DH4;
          prmP00DH4 = new Object[] {
          new ParDef("AV81Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV81Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV82Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV83Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV83Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV84Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV57Wplistatitulosclienteds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("AV61Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV61Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV61Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV65Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV65Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV65Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV69Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV69Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV69Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV70Wplistatitulosclienteds_14_tftituloid",GXType.Int32,9,0) ,
          new ParDef("AV71Wplistatitulosclienteds_15_tftituloid_to",GXType.Int32,9,0) ,
          new ParDef("AV72Wplistatitulosclienteds_16_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV73Wplistatitulosclienteds_17_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV74Wplistatitulosclienteds_18_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV75Wplistatitulosclienteds_19_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV78Wplistatitulosclienteds_22_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV79Wplistatitulosclienteds_23_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DH4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH4,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((short[]) buf[20])[0] = rslt.getShort(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((short[]) buf[22])[0] = rslt.getShort(13);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
