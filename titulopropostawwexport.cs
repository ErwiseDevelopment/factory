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
   public class titulopropostawwexport : GXProcedure
   {
      public titulopropostawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulopropostawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "TituloPropostaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21TituloValor1 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV21TituloValor1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV21TituloValor1);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25TituloValor2 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV25TituloValor2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV25TituloValor2);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29TituloValor3 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV29TituloValor3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV29TituloValor3);
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCategoriaTituloDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Categoria") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCategoriaTituloDescricao_Sel)) ? "(Vazio)" : AV68TFCategoriaTituloDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCategoriaTituloDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Categoria") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67TFCategoriaTituloDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV61TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV46TFTituloValor) && (Convert.ToDecimal(0)==AV47TFTituloValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV46TFTituloValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV47TFTituloValor_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV48TFTituloDesconto) && (Convert.ToDecimal(0)==AV49TFTituloDesconto_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Desconto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV48TFTituloDesconto);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV49TFTituloDesconto_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTituloCompetencia_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Competência") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTituloCompetencia_F_Sel)) ? "(Vazio)" : AV65TFTituloCompetencia_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFTituloCompetencia_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Competência") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFTituloCompetencia_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV50TFTituloProrrogacao) && (DateTime.MinValue==AV51TFTituloProrrogacao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vencimento") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV50TFTituloProrrogacao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TFTituloProrrogacao_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( ( AV54TFTituloTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV59i = 1;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV54TFTituloTipo_Sels.Count )
            {
               AV53TFTituloTipo_Sel = ((string)AV54TFTituloTipo_Sels.Item(AV70GXV1));
               if ( AV59i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmtitulodc.getDescription(context,AV53TFTituloTipo_Sel);
               AV59i = (long)(AV59i+1);
               AV70GXV1 = (int)(AV70GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Cliente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Desconto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Competência";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Vencimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Tipo";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV54TFTituloTipo_Sels ,
                                              AV19DynamicFiltersSelector1 ,
                                              AV20DynamicFiltersOperator1 ,
                                              AV21TituloValor1 ,
                                              AV22DynamicFiltersEnabled2 ,
                                              AV23DynamicFiltersSelector2 ,
                                              AV24DynamicFiltersOperator2 ,
                                              AV25TituloValor2 ,
                                              AV26DynamicFiltersEnabled3 ,
                                              AV27DynamicFiltersSelector3 ,
                                              AV28DynamicFiltersOperator3 ,
                                              AV29TituloValor3 ,
                                              AV68TFCategoriaTituloDescricao_Sel ,
                                              AV67TFCategoriaTituloDescricao ,
                                              AV61TFClienteRazaoSocial_Sel ,
                                              AV60TFClienteRazaoSocial ,
                                              AV46TFTituloValor ,
                                              AV47TFTituloValor_To ,
                                              AV48TFTituloDesconto ,
                                              AV49TFTituloDesconto_To ,
                                              AV50TFTituloProrrogacao ,
                                              AV51TFTituloProrrogacao_To ,
                                              AV54TFTituloTipo_Sels.Count ,
                                              AV66TituloTipo ,
                                              A262TituloValor ,
                                              A428CategoriaTituloDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV18FilterFullText ,
                                              A295TituloCompetencia_F ,
                                              AV65TFTituloCompetencia_F_Sel ,
                                              AV64TFTituloCompetencia_F ,
                                              AV69TituloPropostaId ,
                                              A419TituloPropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV67TFCategoriaTituloDescricao = StringUtil.Concat( StringUtil.RTrim( AV67TFCategoriaTituloDescricao), "%", "");
         lV60TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV60TFClienteRazaoSocial), "%", "");
         /* Using cursor P00AM2 */
         pr_default.execute(0, new Object[] {AV69TituloPropostaId, AV21TituloValor1, AV21TituloValor1, AV21TituloValor1, AV25TituloValor2, AV25TituloValor2, AV25TituloValor2, AV29TituloValor3, AV29TituloValor3, AV29TituloValor3, lV67TFCategoriaTituloDescricao, AV68TFCategoriaTituloDescricao_Sel, lV60TFClienteRazaoSocial, AV61TFClienteRazaoSocial_Sel, AV46TFTituloValor, AV47TFTituloValor_To, AV48TFTituloDesconto, AV49TFTituloDesconto_To, AV50TFTituloProrrogacao, AV51TFTituloProrrogacao_To, AV66TituloTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A426CategoriaTituloId = P00AM2_A426CategoriaTituloId[0];
            n426CategoriaTituloId = P00AM2_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = P00AM2_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00AM2_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00AM2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AM2_n794NotaFiscalId[0];
            A168ClienteId = P00AM2_A168ClienteId[0];
            n168ClienteId = P00AM2_n168ClienteId[0];
            A264TituloProrrogacao = P00AM2_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00AM2_n264TituloProrrogacao[0];
            A283TituloTipo = P00AM2_A283TituloTipo[0];
            n283TituloTipo = P00AM2_n283TituloTipo[0];
            A276TituloDesconto = P00AM2_A276TituloDesconto[0];
            n276TituloDesconto = P00AM2_n276TituloDesconto[0];
            A262TituloValor = P00AM2_A262TituloValor[0];
            n262TituloValor = P00AM2_n262TituloValor[0];
            A170ClienteRazaoSocial = P00AM2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AM2_n170ClienteRazaoSocial[0];
            A428CategoriaTituloDescricao = P00AM2_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AM2_n428CategoriaTituloDescricao[0];
            A419TituloPropostaId = P00AM2_A419TituloPropostaId[0];
            n419TituloPropostaId = P00AM2_n419TituloPropostaId[0];
            A286TituloCompetenciaAno = P00AM2_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00AM2_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00AM2_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00AM2_n287TituloCompetenciaMes[0];
            A261TituloId = P00AM2_A261TituloId[0];
            A428CategoriaTituloDescricao = P00AM2_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00AM2_n428CategoriaTituloDescricao[0];
            A794NotaFiscalId = P00AM2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00AM2_n794NotaFiscalId[0];
            A168ClienteId = P00AM2_A168ClienteId[0];
            n168ClienteId = P00AM2_n168ClienteId[0];
            A170ClienteRazaoSocial = P00AM2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00AM2_n170ClienteRazaoSocial[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) || ( ( StringUtil.Like( A428CategoriaTituloDescricao , StringUtil.PadR( "%" + AV18FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV18FilterFullText , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV18FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV18FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTituloCompetencia_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFTituloCompetencia_F)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV64TFTituloCompetencia_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTituloCompetencia_F_Sel)) && ! ( StringUtil.StrCmp(AV65TFTituloCompetencia_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV65TFTituloCompetencia_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV65TFTituloCompetencia_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
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
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A428CategoriaTituloDescricao, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A262TituloValor);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A276TituloDesconto);
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A295TituloCompetencia_F, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( A264TituloProrrogacao ) ;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = GXt_dtime3;
                        if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) < DateTimeUtil.ResetTime ( Gx_date ) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                        }
                        else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) == DateTimeUtil.ResetTime ( Gx_date ) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                        }
                        else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) > DateTimeUtil.ResetTime ( Gx_date ) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = gxdomaindmtitulodc.getDescription(context,A283TituloTipo);
                        if ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                        }
                        else if ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
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
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "TituloPropostaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("TituloPropostaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TituloPropostaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("TituloPropostaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV73GXV2 = 1;
         while ( AV73GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV73GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO") == 0 )
            {
               AV67TFCategoriaTituloDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO_SEL") == 0 )
            {
               AV68TFCategoriaTituloDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV60TFClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV61TFClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV46TFTituloValor = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV47TFTituloValor_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV48TFTituloDesconto = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV49TFTituloDesconto_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV64TFTituloCompetencia_F = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV65TFTituloCompetencia_F_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV50TFTituloProrrogacao = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV51TFTituloProrrogacao_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV52TFTituloTipo_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV54TFTituloTipo_Sels.FromJSonString(AV52TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&TITULOPROPOSTAID") == 0 )
            {
               AV69TituloPropostaId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV73GXV2 = (int)(AV73GXV2+1);
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
         AV23DynamicFiltersSelector2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV68TFCategoriaTituloDescricao_Sel = "";
         AV67TFCategoriaTituloDescricao = "";
         AV61TFClienteRazaoSocial_Sel = "";
         AV60TFClienteRazaoSocial = "";
         AV65TFTituloCompetencia_F_Sel = "";
         AV64TFTituloCompetencia_F = "";
         AV50TFTituloProrrogacao = DateTime.MinValue;
         AV51TFTituloProrrogacao_To = DateTime.MinValue;
         AV54TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV53TFTituloTipo_Sel = "";
         lV18FilterFullText = "";
         lV67TFCategoriaTituloDescricao = "";
         lV60TFClienteRazaoSocial = "";
         A283TituloTipo = "";
         AV66TituloTipo = "";
         A428CategoriaTituloDescricao = "";
         A170ClienteRazaoSocial = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         P00AM2_A426CategoriaTituloId = new int[1] ;
         P00AM2_n426CategoriaTituloId = new bool[] {false} ;
         P00AM2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00AM2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00AM2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00AM2_n794NotaFiscalId = new bool[] {false} ;
         P00AM2_A168ClienteId = new int[1] ;
         P00AM2_n168ClienteId = new bool[] {false} ;
         P00AM2_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00AM2_n264TituloProrrogacao = new bool[] {false} ;
         P00AM2_A283TituloTipo = new string[] {""} ;
         P00AM2_n283TituloTipo = new bool[] {false} ;
         P00AM2_A276TituloDesconto = new decimal[1] ;
         P00AM2_n276TituloDesconto = new bool[] {false} ;
         P00AM2_A262TituloValor = new decimal[1] ;
         P00AM2_n262TituloValor = new bool[] {false} ;
         P00AM2_A170ClienteRazaoSocial = new string[] {""} ;
         P00AM2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00AM2_A428CategoriaTituloDescricao = new string[] {""} ;
         P00AM2_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00AM2_A419TituloPropostaId = new int[1] ;
         P00AM2_n419TituloPropostaId = new bool[] {false} ;
         P00AM2_A286TituloCompetenciaAno = new short[1] ;
         P00AM2_n286TituloCompetenciaAno = new bool[] {false} ;
         P00AM2_A287TituloCompetenciaMes = new short[1] ;
         P00AM2_n287TituloCompetenciaMes = new bool[] {false} ;
         P00AM2_A261TituloId = new int[1] ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         GXt_char1 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         Gx_date = DateTime.MinValue;
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52TFTituloTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulopropostawwexport__default(),
            new Object[][] {
                new Object[] {
               P00AM2_A426CategoriaTituloId, P00AM2_n426CategoriaTituloId, P00AM2_A890NotaFiscalParcelamentoID, P00AM2_n890NotaFiscalParcelamentoID, P00AM2_A794NotaFiscalId, P00AM2_n794NotaFiscalId, P00AM2_A168ClienteId, P00AM2_n168ClienteId, P00AM2_A264TituloProrrogacao, P00AM2_n264TituloProrrogacao,
               P00AM2_A283TituloTipo, P00AM2_n283TituloTipo, P00AM2_A276TituloDesconto, P00AM2_n276TituloDesconto, P00AM2_A262TituloValor, P00AM2_n262TituloValor, P00AM2_A170ClienteRazaoSocial, P00AM2_n170ClienteRazaoSocial, P00AM2_A428CategoriaTituloDescricao, P00AM2_n428CategoriaTituloDescricao,
               P00AM2_A419TituloPropostaId, P00AM2_n419TituloPropostaId, P00AM2_A286TituloCompetenciaAno, P00AM2_n286TituloCompetenciaAno, P00AM2_A287TituloCompetenciaMes, P00AM2_n287TituloCompetenciaMes, P00AM2_A261TituloId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV70GXV1 ;
      private int AV54TFTituloTipo_Sels_Count ;
      private int AV69TituloPropostaId ;
      private int A419TituloPropostaId ;
      private int A426CategoriaTituloId ;
      private int A168ClienteId ;
      private int A261TituloId ;
      private int AV73GXV2 ;
      private long AV59i ;
      private decimal AV21TituloValor1 ;
      private decimal AV25TituloValor2 ;
      private decimal AV29TituloValor3 ;
      private decimal AV46TFTituloValor ;
      private decimal AV47TFTituloValor_To ;
      private decimal AV48TFTituloDesconto ;
      private decimal AV49TFTituloDesconto_To ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV50TFTituloProrrogacao ;
      private DateTime AV51TFTituloProrrogacao_To ;
      private DateTime A264TituloProrrogacao ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV17OrderedDsc ;
      private bool n426CategoriaTituloId ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n264TituloProrrogacao ;
      private bool n283TituloTipo ;
      private bool n276TituloDesconto ;
      private bool n262TituloValor ;
      private bool n170ClienteRazaoSocial ;
      private bool n428CategoriaTituloDescricao ;
      private bool n419TituloPropostaId ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private string AV52TFTituloTipo_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV68TFCategoriaTituloDescricao_Sel ;
      private string AV67TFCategoriaTituloDescricao ;
      private string AV61TFClienteRazaoSocial_Sel ;
      private string AV60TFClienteRazaoSocial ;
      private string AV65TFTituloCompetencia_F_Sel ;
      private string AV64TFTituloCompetencia_F ;
      private string AV53TFTituloTipo_Sel ;
      private string lV18FilterFullText ;
      private string lV67TFCategoriaTituloDescricao ;
      private string lV60TFClienteRazaoSocial ;
      private string A283TituloTipo ;
      private string AV66TituloTipo ;
      private string A428CategoriaTituloDescricao ;
      private string A170ClienteRazaoSocial ;
      private string A295TituloCompetencia_F ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV54TFTituloTipo_Sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00AM2_A426CategoriaTituloId ;
      private bool[] P00AM2_n426CategoriaTituloId ;
      private Guid[] P00AM2_A890NotaFiscalParcelamentoID ;
      private bool[] P00AM2_n890NotaFiscalParcelamentoID ;
      private Guid[] P00AM2_A794NotaFiscalId ;
      private bool[] P00AM2_n794NotaFiscalId ;
      private int[] P00AM2_A168ClienteId ;
      private bool[] P00AM2_n168ClienteId ;
      private DateTime[] P00AM2_A264TituloProrrogacao ;
      private bool[] P00AM2_n264TituloProrrogacao ;
      private string[] P00AM2_A283TituloTipo ;
      private bool[] P00AM2_n283TituloTipo ;
      private decimal[] P00AM2_A276TituloDesconto ;
      private bool[] P00AM2_n276TituloDesconto ;
      private decimal[] P00AM2_A262TituloValor ;
      private bool[] P00AM2_n262TituloValor ;
      private string[] P00AM2_A170ClienteRazaoSocial ;
      private bool[] P00AM2_n170ClienteRazaoSocial ;
      private string[] P00AM2_A428CategoriaTituloDescricao ;
      private bool[] P00AM2_n428CategoriaTituloDescricao ;
      private int[] P00AM2_A419TituloPropostaId ;
      private bool[] P00AM2_n419TituloPropostaId ;
      private short[] P00AM2_A286TituloCompetenciaAno ;
      private bool[] P00AM2_n286TituloCompetenciaAno ;
      private short[] P00AM2_A287TituloCompetenciaMes ;
      private bool[] P00AM2_n287TituloCompetenciaMes ;
      private int[] P00AM2_A261TituloId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class titulopropostawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AM2( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV54TFTituloTipo_Sels ,
                                             string AV19DynamicFiltersSelector1 ,
                                             short AV20DynamicFiltersOperator1 ,
                                             decimal AV21TituloValor1 ,
                                             bool AV22DynamicFiltersEnabled2 ,
                                             string AV23DynamicFiltersSelector2 ,
                                             short AV24DynamicFiltersOperator2 ,
                                             decimal AV25TituloValor2 ,
                                             bool AV26DynamicFiltersEnabled3 ,
                                             string AV27DynamicFiltersSelector3 ,
                                             short AV28DynamicFiltersOperator3 ,
                                             decimal AV29TituloValor3 ,
                                             string AV68TFCategoriaTituloDescricao_Sel ,
                                             string AV67TFCategoriaTituloDescricao ,
                                             string AV61TFClienteRazaoSocial_Sel ,
                                             string AV60TFClienteRazaoSocial ,
                                             decimal AV46TFTituloValor ,
                                             decimal AV47TFTituloValor_To ,
                                             decimal AV48TFTituloDesconto ,
                                             decimal AV49TFTituloDesconto_To ,
                                             DateTime AV50TFTituloProrrogacao ,
                                             DateTime AV51TFTituloProrrogacao_To ,
                                             int AV54TFTituloTipo_Sels_Count ,
                                             string AV66TituloTipo ,
                                             decimal A262TituloValor ,
                                             string A428CategoriaTituloDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV18FilterFullText ,
                                             string A295TituloCompetencia_F ,
                                             string AV65TFTituloCompetencia_F_Sel ,
                                             string AV64TFTituloCompetencia_F ,
                                             int AV69TituloPropostaId ,
                                             int A419TituloPropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[21];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.CategoriaTituloId, T1.NotaFiscalParcelamentoID, T3.NotaFiscalId, T4.ClienteId, T1.TituloProrrogacao, T1.TituloTipo, T1.TituloDesconto, T1.TituloValor, T5.ClienteRazaoSocial, T2.CategoriaTituloDescricao, T1.TituloPropostaId, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes, T1.TituloId FROM ((((Titulo T1 LEFT JOIN CategoriaTitulo T2 ON T2.CategoriaTituloId = T1.CategoriaTituloId) LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.ClienteId)";
         AddWhere(sWhereString, "(T1.TituloPropostaId = :AV69TituloPropostaId)");
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV21TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV21TituloValor1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV21TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV21TituloValor1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ( AV20DynamicFiltersOperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV21TituloValor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV21TituloValor1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV22DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV24DynamicFiltersOperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV25TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV25TituloValor2)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV22DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV24DynamicFiltersOperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV25TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV25TituloValor2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV22DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ( AV24DynamicFiltersOperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV25TituloValor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV25TituloValor2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV28DynamicFiltersOperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV29TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV29TituloValor3)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV28DynamicFiltersOperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV29TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV29TituloValor3)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV26DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ( AV28DynamicFiltersOperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV29TituloValor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV29TituloValor3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCategoriaTituloDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCategoriaTituloDescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao like :lV67TFCategoriaTituloDescricao)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCategoriaTituloDescricao_Sel)) && ! ( StringUtil.StrCmp(AV68TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CategoriaTituloDescricao = ( :AV68TFCategoriaTituloDescricao_Sel))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68TFCategoriaTituloDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CategoriaTituloDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV60TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV61TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV61TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV46TFTituloValor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV46TFTituloValor)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV47TFTituloValor_To) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV47TFTituloValor_To)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV48TFTituloDesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV48TFTituloDesconto)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV49TFTituloDesconto_To) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV49TFTituloDesconto_To)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV50TFTituloProrrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV50TFTituloProrrogacao)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV51TFTituloProrrogacao_To) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV51TFTituloProrrogacao_To)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV54TFTituloTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54TFTituloTipo_Sels, "T1.TituloTipo IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TituloTipo)) )
         {
            AddWhere(sWhereString, "(T1.TituloTipo = ( :AV66TituloTipo))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloValor";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloValor DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T2.CategoriaTituloDescricao";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T2.CategoriaTituloDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T5.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T5.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloDesconto";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloDesconto DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloProrrogacao";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloProrrogacao DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId, T1.TituloTipo";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaId DESC, T1.TituloTipo DESC";
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
                     return conditional_P00AM2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (decimal)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (decimal)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (int)dynConstraints[37] );
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
          Object[] prmP00AM2;
          prmP00AM2 = new Object[] {
          new ParDef("AV69TituloPropostaId",GXType.Int32,9,0) ,
          new ParDef("AV21TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV21TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV21TituloValor1",GXType.Number,18,2) ,
          new ParDef("AV25TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV25TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV25TituloValor2",GXType.Number,18,2) ,
          new ParDef("AV29TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV29TituloValor3",GXType.Number,18,2) ,
          new ParDef("AV29TituloValor3",GXType.Number,18,2) ,
          new ParDef("lV67TFCategoriaTituloDescricao",GXType.VarChar,150,0) ,
          new ParDef("AV68TFCategoriaTituloDescricao_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV60TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV61TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("AV46TFTituloValor",GXType.Number,18,2) ,
          new ParDef("AV47TFTituloValor_To",GXType.Number,18,2) ,
          new ParDef("AV48TFTituloDesconto",GXType.Number,18,2) ,
          new ParDef("AV49TFTituloDesconto_To",GXType.Number,18,2) ,
          new ParDef("AV50TFTituloProrrogacao",GXType.Date,8,0) ,
          new ParDef("AV51TFTituloProrrogacao_To",GXType.Date,8,0) ,
          new ParDef("AV66TituloTipo",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((short[]) buf[22])[0] = rslt.getShort(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((short[]) buf[24])[0] = rslt.getShort(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
