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
   public class wpregistrartituloexport : GXProcedure
   {
      public wpregistrartituloexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpregistrartituloexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WPRegistrarTituloExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV21TituloValor1 = NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, ".");
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
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV22ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22ContaBancariaNumero1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV22ContaBancariaNumero1;
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV26TituloValor2 = NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV26TituloValor2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV26TituloValor2);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV27ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV27ContaBancariaNumero2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV27ContaBancariaNumero2;
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV31TituloValor3 = NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, ".");
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
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV32ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV32ContaBancariaNumero3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV32ContaBancariaNumero3;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV128TFTituloCLienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sacado") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV128TFTituloCLienteRazaoSocial_Sel)) ? "(Vazio)" : AV128TFTituloCLienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV127TFTituloCLienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sacado") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV127TFTituloCLienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV126TFTituloPropostaDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Proposta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV126TFTituloPropostaDescricao_Sel)) ? "(Vazio)" : AV126TFTituloPropostaDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV125TFTituloPropostaDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Proposta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV125TFTituloPropostaDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV111TFTituloPropostaTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo da proposta") ;
            AV13CellRow = GXt_int2;
            AV122i = 1;
            AV129GXV1 = 1;
            while ( AV129GXV1 <= AV111TFTituloPropostaTipo_Sels.Count )
            {
               AV110TFTituloPropostaTipo_Sel = ((string)AV111TFTituloPropostaTipo_Sels.Item(AV129GXV1));
               if ( AV122i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmtitulopropostatipo.getDescription(context,AV110TFTituloPropostaTipo_Sel);
               AV122i = (long)(AV122i+1);
               AV129GXV1 = (int)(AV129GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV44TFTituloValor) && (Convert.ToDecimal(0)==AV45TFTituloValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV44TFTituloValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV45TFTituloValor_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV46TFTituloDesconto) && (Convert.ToDecimal(0)==AV47TFTituloDesconto_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Desconto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV46TFTituloDesconto);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV47TFTituloDesconto_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFTituloCompetencia_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Competência") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFTituloCompetencia_F_Sel)) ? "(Vazio)" : AV57TFTituloCompetencia_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFTituloCompetencia_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Competência") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFTituloCompetencia_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV58TFTituloProrrogacao) && (DateTime.MinValue==AV59TFTituloProrrogacao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vencimento") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV58TFTituloProrrogacao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV59TFTituloProrrogacao_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV72TFTituloJurosMora) && (Convert.ToDecimal(0)==AV73TFTituloJurosMora_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Juros Mora") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV72TFTituloJurosMora);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV73TFTituloJurosMora_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV124TFNotaFiscalNumero_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nota de origem") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV124TFNotaFiscalNumero_Sel)) ? "(Vazio)" : AV124TFNotaFiscalNumero_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV123TFNotaFiscalNumero)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nota de origem") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV123TFNotaFiscalNumero, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Sacado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Proposta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Tipo da proposta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Desconto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Competência";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Vencimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Juros Mora";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Nota de origem";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV131Wpregistrartitulods_1_filterfulltext = AV18FilterFullText;
         AV132Wpregistrartitulods_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV133Wpregistrartitulods_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV134Wpregistrartitulods_4_titulovalor1 = AV21TituloValor1;
         AV135Wpregistrartitulods_5_contabancarianumero1 = AV22ContaBancariaNumero1;
         AV136Wpregistrartitulods_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV137Wpregistrartitulods_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV138Wpregistrartitulods_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV139Wpregistrartitulods_9_titulovalor2 = AV26TituloValor2;
         AV140Wpregistrartitulods_10_contabancarianumero2 = AV27ContaBancariaNumero2;
         AV141Wpregistrartitulods_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV142Wpregistrartitulods_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV143Wpregistrartitulods_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV144Wpregistrartitulods_14_titulovalor3 = AV31TituloValor3;
         AV145Wpregistrartitulods_15_contabancarianumero3 = AV32ContaBancariaNumero3;
         AV146Wpregistrartitulods_16_tftituloclienterazaosocial = AV127TFTituloCLienteRazaoSocial;
         AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel = AV128TFTituloCLienteRazaoSocial_Sel;
         AV148Wpregistrartitulods_18_tftitulopropostadescricao = AV125TFTituloPropostaDescricao;
         AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel = AV126TFTituloPropostaDescricao_Sel;
         AV150Wpregistrartitulods_20_tftitulopropostatipo_sels = AV111TFTituloPropostaTipo_Sels;
         AV151Wpregistrartitulods_21_tftitulovalor = AV44TFTituloValor;
         AV152Wpregistrartitulods_22_tftitulovalor_to = AV45TFTituloValor_To;
         AV153Wpregistrartitulods_23_tftitulodesconto = AV46TFTituloDesconto;
         AV154Wpregistrartitulods_24_tftitulodesconto_to = AV47TFTituloDesconto_To;
         AV155Wpregistrartitulods_25_tftitulocompetencia_f = AV56TFTituloCompetencia_F;
         AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel = AV57TFTituloCompetencia_F_Sel;
         AV157Wpregistrartitulods_27_tftituloprorrogacao = AV58TFTituloProrrogacao;
         AV158Wpregistrartitulods_28_tftituloprorrogacao_to = AV59TFTituloProrrogacao_To;
         AV159Wpregistrartitulods_29_tftitulojurosmora = AV72TFTituloJurosMora;
         AV160Wpregistrartitulods_30_tftitulojurosmora_to = AV73TFTituloJurosMora_To;
         AV161Wpregistrartitulods_31_tfnotafiscalnumero = AV123TFNotaFiscalNumero;
         AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel = AV124TFNotaFiscalNumero_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A648TituloPropostaTipo ,
                                              AV150Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                              AV132Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                              AV133Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                              AV134Wpregistrartitulods_4_titulovalor1 ,
                                              AV135Wpregistrartitulods_5_contabancarianumero1 ,
                                              AV136Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                              AV137Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                              AV138Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                              AV139Wpregistrartitulods_9_titulovalor2 ,
                                              AV140Wpregistrartitulods_10_contabancarianumero2 ,
                                              AV141Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                              AV142Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                              AV143Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                              AV144Wpregistrartitulods_14_titulovalor3 ,
                                              AV145Wpregistrartitulods_15_contabancarianumero3 ,
                                              AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                              AV146Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                              AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                              AV148Wpregistrartitulods_18_tftitulopropostadescricao ,
                                              AV150Wpregistrartitulods_20_tftitulopropostatipo_sels.Count ,
                                              AV151Wpregistrartitulods_21_tftitulovalor ,
                                              AV152Wpregistrartitulods_22_tftitulovalor_to ,
                                              AV153Wpregistrartitulods_23_tftitulodesconto ,
                                              AV154Wpregistrartitulods_24_tftitulodesconto_to ,
                                              AV157Wpregistrartitulods_27_tftituloprorrogacao ,
                                              AV158Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                              AV159Wpregistrartitulods_29_tftitulojurosmora ,
                                              AV160Wpregistrartitulods_30_tftitulojurosmora_to ,
                                              AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                              AV161Wpregistrartitulods_31_tfnotafiscalnumero ,
                                              A262TituloValor ,
                                              A952ContaBancariaNumero ,
                                              A972TituloCLienteRazaoSocial ,
                                              A971TituloPropostaDescricao ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              A498TituloJurosMora ,
                                              A799NotaFiscalNumero ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV131Wpregistrartitulods_1_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                              AV155Wpregistrartitulods_25_tftitulocompetencia_f ,
                                              A951ContaBancariaId ,
                                              A284TituloDeleted ,
                                              A314TituloArchived ,
                                              A275TituloSaldo_F ,
                                              A283TituloTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV146Wpregistrartitulods_16_tftituloclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV146Wpregistrartitulods_16_tftituloclienterazaosocial), "%", "");
         lV148Wpregistrartitulods_18_tftitulopropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV148Wpregistrartitulods_18_tftitulopropostadescricao), "%", "");
         lV161Wpregistrartitulods_31_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV161Wpregistrartitulods_31_tfnotafiscalnumero), "%", "");
         /* Using cursor P00EU4 */
         pr_default.execute(0, new Object[] {AV134Wpregistrartitulods_4_titulovalor1, AV134Wpregistrartitulods_4_titulovalor1, AV134Wpregistrartitulods_4_titulovalor1, AV135Wpregistrartitulods_5_contabancarianumero1, AV135Wpregistrartitulods_5_contabancarianumero1, AV135Wpregistrartitulods_5_contabancarianumero1, AV139Wpregistrartitulods_9_titulovalor2, AV139Wpregistrartitulods_9_titulovalor2, AV139Wpregistrartitulods_9_titulovalor2, AV140Wpregistrartitulods_10_contabancarianumero2, AV140Wpregistrartitulods_10_contabancarianumero2, AV140Wpregistrartitulods_10_contabancarianumero2, AV144Wpregistrartitulods_14_titulovalor3, AV144Wpregistrartitulods_14_titulovalor3, AV144Wpregistrartitulods_14_titulovalor3, AV145Wpregistrartitulods_15_contabancarianumero3, AV145Wpregistrartitulods_15_contabancarianumero3, AV145Wpregistrartitulods_15_contabancarianumero3, lV146Wpregistrartitulods_16_tftituloclienterazaosocial, AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel, lV148Wpregistrartitulods_18_tftitulopropostadescricao, AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel, AV151Wpregistrartitulods_21_tftitulovalor, AV152Wpregistrartitulods_22_tftitulovalor_to, AV153Wpregistrartitulods_23_tftitulodesconto, AV154Wpregistrartitulods_24_tftitulodesconto_to, AV157Wpregistrartitulods_27_tftituloprorrogacao, AV158Wpregistrartitulods_28_tftituloprorrogacao_to, AV159Wpregistrartitulods_29_tftitulojurosmora, AV160Wpregistrartitulods_30_tftitulojurosmora_to, lV161Wpregistrartitulods_31_tfnotafiscalnumero, AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A890NotaFiscalParcelamentoID = P00EU4_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = P00EU4_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = P00EU4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EU4_n794NotaFiscalId[0];
            A419TituloPropostaId = P00EU4_A419TituloPropostaId[0];
            n419TituloPropostaId = P00EU4_n419TituloPropostaId[0];
            A420TituloClienteId = P00EU4_A420TituloClienteId[0];
            n420TituloClienteId = P00EU4_n420TituloClienteId[0];
            A261TituloId = P00EU4_A261TituloId[0];
            n261TituloId = P00EU4_n261TituloId[0];
            A283TituloTipo = P00EU4_A283TituloTipo[0];
            n283TituloTipo = P00EU4_n283TituloTipo[0];
            A314TituloArchived = P00EU4_A314TituloArchived[0];
            n314TituloArchived = P00EU4_n314TituloArchived[0];
            A284TituloDeleted = P00EU4_A284TituloDeleted[0];
            n284TituloDeleted = P00EU4_n284TituloDeleted[0];
            A951ContaBancariaId = P00EU4_A951ContaBancariaId[0];
            n951ContaBancariaId = P00EU4_n951ContaBancariaId[0];
            A498TituloJurosMora = P00EU4_A498TituloJurosMora[0];
            n498TituloJurosMora = P00EU4_n498TituloJurosMora[0];
            A264TituloProrrogacao = P00EU4_A264TituloProrrogacao[0];
            n264TituloProrrogacao = P00EU4_n264TituloProrrogacao[0];
            A276TituloDesconto = P00EU4_A276TituloDesconto[0];
            n276TituloDesconto = P00EU4_n276TituloDesconto[0];
            A952ContaBancariaNumero = P00EU4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EU4_n952ContaBancariaNumero[0];
            A262TituloValor = P00EU4_A262TituloValor[0];
            n262TituloValor = P00EU4_n262TituloValor[0];
            A799NotaFiscalNumero = P00EU4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EU4_n799NotaFiscalNumero[0];
            A648TituloPropostaTipo = P00EU4_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = P00EU4_n648TituloPropostaTipo[0];
            A971TituloPropostaDescricao = P00EU4_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EU4_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EU4_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EU4_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EU4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EU4_n275TituloSaldo_F[0];
            A286TituloCompetenciaAno = P00EU4_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = P00EU4_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = P00EU4_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = P00EU4_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = P00EU4_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EU4_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00EU4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EU4_n799NotaFiscalNumero[0];
            A971TituloPropostaDescricao = P00EU4_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = P00EU4_n971TituloPropostaDescricao[0];
            A972TituloCLienteRazaoSocial = P00EU4_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = P00EU4_n972TituloCLienteRazaoSocial[0];
            A275TituloSaldo_F = P00EU4_A275TituloSaldo_F[0];
            n275TituloSaldo_F = P00EU4_n275TituloSaldo_F[0];
            A952ContaBancariaNumero = P00EU4_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EU4_n952ContaBancariaNumero[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV131Wpregistrartitulods_1_filterfulltext)) || ( ( StringUtil.Like( A972TituloCLienteRazaoSocial , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A971TituloPropostaDescricao , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "iof" , StringUtil.PadR( "%" + StringUtil.Lower( AV131Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) ) || ( StringUtil.Like( "taxa" , StringUtil.PadR( "%" + StringUtil.Lower( AV131Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) ) || ( StringUtil.Like( "reembolso" , StringUtil.PadR( "%" + StringUtil.Lower( AV131Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) ) || ( StringUtil.Like( "comum" , StringUtil.PadR( "%" + StringUtil.Lower( AV131Wpregistrartitulods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A498TituloJurosMora, 16, 4) , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV131Wpregistrartitulods_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Wpregistrartitulods_25_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV155Wpregistrartitulods_25_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A972TituloCLienteRazaoSocial, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A971TituloPropostaDescricao, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = gxdomaindmtitulopropostatipo.getDescription(context,A648TituloPropostaTipo);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A262TituloValor);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A276TituloDesconto);
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A295TituloCompetencia_F, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( A264TituloProrrogacao ) ;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Date = GXt_dtime3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Number = (double)(A498TituloJurosMora);
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A799NotaFiscalNumero, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = GXt_char1;
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
         AV34Session.Set("WWPExportFilePath", AV11Filename);
         AV34Session.Set("WWPExportFileName", "WPRegistrarTituloExport.xlsx");
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
         if ( StringUtil.StrCmp(AV34Session.Get("WPRegistrarTituloGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WPRegistrarTituloGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("WPRegistrarTituloGridState"), null, "", "");
         }
         AV16OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV163GXV2 = 1;
         while ( AV163GXV2 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV163GXV2));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL") == 0 )
            {
               AV127TFTituloCLienteRazaoSocial = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV128TFTituloCLienteRazaoSocial_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO") == 0 )
            {
               AV125TFTituloPropostaDescricao = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV126TFTituloPropostaDescricao_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOPROPOSTATIPO_SEL") == 0 )
            {
               AV109TFTituloPropostaTipo_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV111TFTituloPropostaTipo_Sels.FromJSonString(AV109TFTituloPropostaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV44TFTituloValor = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV45TFTituloValor_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV46TFTituloDesconto = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV47TFTituloDesconto_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV56TFTituloCompetencia_F = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV57TFTituloCompetencia_F_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV58TFTituloProrrogacao = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV59TFTituloProrrogacao_To = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTITULOJUROSMORA") == 0 )
            {
               AV72TFTituloJurosMora = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV73TFTituloJurosMora_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV123TFNotaFiscalNumero = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV124TFNotaFiscalNumero_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV163GXV2 = (int)(AV163GXV2+1);
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
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV128TFTituloCLienteRazaoSocial_Sel = "";
         AV127TFTituloCLienteRazaoSocial = "";
         AV126TFTituloPropostaDescricao_Sel = "";
         AV125TFTituloPropostaDescricao = "";
         AV111TFTituloPropostaTipo_Sels = new GxSimpleCollection<string>();
         AV110TFTituloPropostaTipo_Sel = "";
         AV57TFTituloCompetencia_F_Sel = "";
         AV56TFTituloCompetencia_F = "";
         AV58TFTituloProrrogacao = DateTime.MinValue;
         AV59TFTituloProrrogacao_To = DateTime.MinValue;
         AV124TFNotaFiscalNumero_Sel = "";
         AV123TFNotaFiscalNumero = "";
         AV131Wpregistrartitulods_1_filterfulltext = "";
         AV132Wpregistrartitulods_2_dynamicfiltersselector1 = "";
         AV137Wpregistrartitulods_7_dynamicfiltersselector2 = "";
         AV142Wpregistrartitulods_12_dynamicfiltersselector3 = "";
         AV146Wpregistrartitulods_16_tftituloclienterazaosocial = "";
         AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel = "";
         AV148Wpregistrartitulods_18_tftitulopropostadescricao = "";
         AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel = "";
         AV150Wpregistrartitulods_20_tftitulopropostatipo_sels = new GxSimpleCollection<string>();
         AV155Wpregistrartitulods_25_tftitulocompetencia_f = "";
         AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel = "";
         AV157Wpregistrartitulods_27_tftituloprorrogacao = DateTime.MinValue;
         AV158Wpregistrartitulods_28_tftituloprorrogacao_to = DateTime.MinValue;
         AV161Wpregistrartitulods_31_tfnotafiscalnumero = "";
         AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel = "";
         lV131Wpregistrartitulods_1_filterfulltext = "";
         lV146Wpregistrartitulods_16_tftituloclienterazaosocial = "";
         lV148Wpregistrartitulods_18_tftitulopropostadescricao = "";
         lV161Wpregistrartitulods_31_tfnotafiscalnumero = "";
         A648TituloPropostaTipo = "";
         A972TituloCLienteRazaoSocial = "";
         A971TituloPropostaDescricao = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A799NotaFiscalNumero = "";
         A295TituloCompetencia_F = "";
         A283TituloTipo = "";
         P00EU4_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EU4_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         P00EU4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EU4_n794NotaFiscalId = new bool[] {false} ;
         P00EU4_A419TituloPropostaId = new int[1] ;
         P00EU4_n419TituloPropostaId = new bool[] {false} ;
         P00EU4_A420TituloClienteId = new int[1] ;
         P00EU4_n420TituloClienteId = new bool[] {false} ;
         P00EU4_A261TituloId = new int[1] ;
         P00EU4_n261TituloId = new bool[] {false} ;
         P00EU4_A283TituloTipo = new string[] {""} ;
         P00EU4_n283TituloTipo = new bool[] {false} ;
         P00EU4_A314TituloArchived = new bool[] {false} ;
         P00EU4_n314TituloArchived = new bool[] {false} ;
         P00EU4_A284TituloDeleted = new bool[] {false} ;
         P00EU4_n284TituloDeleted = new bool[] {false} ;
         P00EU4_A951ContaBancariaId = new int[1] ;
         P00EU4_n951ContaBancariaId = new bool[] {false} ;
         P00EU4_A498TituloJurosMora = new decimal[1] ;
         P00EU4_n498TituloJurosMora = new bool[] {false} ;
         P00EU4_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         P00EU4_n264TituloProrrogacao = new bool[] {false} ;
         P00EU4_A276TituloDesconto = new decimal[1] ;
         P00EU4_n276TituloDesconto = new bool[] {false} ;
         P00EU4_A952ContaBancariaNumero = new long[1] ;
         P00EU4_n952ContaBancariaNumero = new bool[] {false} ;
         P00EU4_A262TituloValor = new decimal[1] ;
         P00EU4_n262TituloValor = new bool[] {false} ;
         P00EU4_A799NotaFiscalNumero = new string[] {""} ;
         P00EU4_n799NotaFiscalNumero = new bool[] {false} ;
         P00EU4_A648TituloPropostaTipo = new string[] {""} ;
         P00EU4_n648TituloPropostaTipo = new bool[] {false} ;
         P00EU4_A971TituloPropostaDescricao = new string[] {""} ;
         P00EU4_n971TituloPropostaDescricao = new bool[] {false} ;
         P00EU4_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00EU4_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00EU4_A275TituloSaldo_F = new decimal[1] ;
         P00EU4_n275TituloSaldo_F = new bool[] {false} ;
         P00EU4_A286TituloCompetenciaAno = new short[1] ;
         P00EU4_n286TituloCompetenciaAno = new bool[] {false} ;
         P00EU4_A287TituloCompetenciaMes = new short[1] ;
         P00EU4_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV109TFTituloPropostaTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistrartituloexport__default(),
            new Object[][] {
                new Object[] {
               P00EU4_A890NotaFiscalParcelamentoID, P00EU4_n890NotaFiscalParcelamentoID, P00EU4_A794NotaFiscalId, P00EU4_n794NotaFiscalId, P00EU4_A419TituloPropostaId, P00EU4_n419TituloPropostaId, P00EU4_A420TituloClienteId, P00EU4_n420TituloClienteId, P00EU4_A261TituloId, P00EU4_A283TituloTipo,
               P00EU4_n283TituloTipo, P00EU4_A314TituloArchived, P00EU4_n314TituloArchived, P00EU4_A284TituloDeleted, P00EU4_n284TituloDeleted, P00EU4_A951ContaBancariaId, P00EU4_n951ContaBancariaId, P00EU4_A498TituloJurosMora, P00EU4_n498TituloJurosMora, P00EU4_A264TituloProrrogacao,
               P00EU4_n264TituloProrrogacao, P00EU4_A276TituloDesconto, P00EU4_n276TituloDesconto, P00EU4_A952ContaBancariaNumero, P00EU4_n952ContaBancariaNumero, P00EU4_A262TituloValor, P00EU4_n262TituloValor, P00EU4_A799NotaFiscalNumero, P00EU4_n799NotaFiscalNumero, P00EU4_A648TituloPropostaTipo,
               P00EU4_n648TituloPropostaTipo, P00EU4_A971TituloPropostaDescricao, P00EU4_n971TituloPropostaDescricao, P00EU4_A972TituloCLienteRazaoSocial, P00EU4_n972TituloCLienteRazaoSocial, P00EU4_A275TituloSaldo_F, P00EU4_n275TituloSaldo_F, P00EU4_A286TituloCompetenciaAno, P00EU4_n286TituloCompetenciaAno, P00EU4_A287TituloCompetenciaMes,
               P00EU4_n287TituloCompetenciaMes
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV133Wpregistrartitulods_3_dynamicfiltersoperator1 ;
      private short AV138Wpregistrartitulods_8_dynamicfiltersoperator2 ;
      private short AV143Wpregistrartitulods_13_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV129GXV1 ;
      private int AV150Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ;
      private int A951ContaBancariaId ;
      private int A419TituloPropostaId ;
      private int A420TituloClienteId ;
      private int A261TituloId ;
      private int AV163GXV2 ;
      private long AV22ContaBancariaNumero1 ;
      private long AV27ContaBancariaNumero2 ;
      private long AV32ContaBancariaNumero3 ;
      private long AV122i ;
      private long AV135Wpregistrartitulods_5_contabancarianumero1 ;
      private long AV140Wpregistrartitulods_10_contabancarianumero2 ;
      private long AV145Wpregistrartitulods_15_contabancarianumero3 ;
      private long A952ContaBancariaNumero ;
      private decimal AV21TituloValor1 ;
      private decimal AV26TituloValor2 ;
      private decimal AV31TituloValor3 ;
      private decimal AV44TFTituloValor ;
      private decimal AV45TFTituloValor_To ;
      private decimal AV46TFTituloDesconto ;
      private decimal AV47TFTituloDesconto_To ;
      private decimal AV72TFTituloJurosMora ;
      private decimal AV73TFTituloJurosMora_To ;
      private decimal AV134Wpregistrartitulods_4_titulovalor1 ;
      private decimal AV139Wpregistrartitulods_9_titulovalor2 ;
      private decimal AV144Wpregistrartitulods_14_titulovalor3 ;
      private decimal AV151Wpregistrartitulods_21_tftitulovalor ;
      private decimal AV152Wpregistrartitulods_22_tftitulovalor_to ;
      private decimal AV153Wpregistrartitulods_23_tftitulodesconto ;
      private decimal AV154Wpregistrartitulods_24_tftitulodesconto_to ;
      private decimal AV159Wpregistrartitulods_29_tftitulojurosmora ;
      private decimal AV160Wpregistrartitulods_30_tftitulojurosmora_to ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A498TituloJurosMora ;
      private decimal A275TituloSaldo_F ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV58TFTituloProrrogacao ;
      private DateTime AV59TFTituloProrrogacao_To ;
      private DateTime AV157Wpregistrartitulods_27_tftituloprorrogacao ;
      private DateTime AV158Wpregistrartitulods_28_tftituloprorrogacao_to ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV136Wpregistrartitulods_6_dynamicfiltersenabled2 ;
      private bool AV141Wpregistrartitulods_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool A284TituloDeleted ;
      private bool A314TituloArchived ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n419TituloPropostaId ;
      private bool n420TituloClienteId ;
      private bool n261TituloId ;
      private bool n283TituloTipo ;
      private bool n314TituloArchived ;
      private bool n284TituloDeleted ;
      private bool n951ContaBancariaId ;
      private bool n498TituloJurosMora ;
      private bool n264TituloProrrogacao ;
      private bool n276TituloDesconto ;
      private bool n952ContaBancariaNumero ;
      private bool n262TituloValor ;
      private bool n799NotaFiscalNumero ;
      private bool n648TituloPropostaTipo ;
      private bool n971TituloPropostaDescricao ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n275TituloSaldo_F ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private string AV109TFTituloPropostaTipo_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV128TFTituloCLienteRazaoSocial_Sel ;
      private string AV127TFTituloCLienteRazaoSocial ;
      private string AV126TFTituloPropostaDescricao_Sel ;
      private string AV125TFTituloPropostaDescricao ;
      private string AV110TFTituloPropostaTipo_Sel ;
      private string AV57TFTituloCompetencia_F_Sel ;
      private string AV56TFTituloCompetencia_F ;
      private string AV124TFNotaFiscalNumero_Sel ;
      private string AV123TFNotaFiscalNumero ;
      private string AV131Wpregistrartitulods_1_filterfulltext ;
      private string AV132Wpregistrartitulods_2_dynamicfiltersselector1 ;
      private string AV137Wpregistrartitulods_7_dynamicfiltersselector2 ;
      private string AV142Wpregistrartitulods_12_dynamicfiltersselector3 ;
      private string AV146Wpregistrartitulods_16_tftituloclienterazaosocial ;
      private string AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel ;
      private string AV148Wpregistrartitulods_18_tftitulopropostadescricao ;
      private string AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel ;
      private string AV155Wpregistrartitulods_25_tftitulocompetencia_f ;
      private string AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel ;
      private string AV161Wpregistrartitulods_31_tfnotafiscalnumero ;
      private string AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel ;
      private string lV131Wpregistrartitulods_1_filterfulltext ;
      private string lV146Wpregistrartitulods_16_tftituloclienterazaosocial ;
      private string lV148Wpregistrartitulods_18_tftitulopropostadescricao ;
      private string lV161Wpregistrartitulods_31_tfnotafiscalnumero ;
      private string A648TituloPropostaTipo ;
      private string A972TituloCLienteRazaoSocial ;
      private string A971TituloPropostaDescricao ;
      private string A799NotaFiscalNumero ;
      private string A295TituloCompetencia_F ;
      private string A283TituloTipo ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV34Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV111TFTituloPropostaTipo_Sels ;
      private GxSimpleCollection<string> AV150Wpregistrartitulods_20_tftitulopropostatipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EU4_A890NotaFiscalParcelamentoID ;
      private bool[] P00EU4_n890NotaFiscalParcelamentoID ;
      private Guid[] P00EU4_A794NotaFiscalId ;
      private bool[] P00EU4_n794NotaFiscalId ;
      private int[] P00EU4_A419TituloPropostaId ;
      private bool[] P00EU4_n419TituloPropostaId ;
      private int[] P00EU4_A420TituloClienteId ;
      private bool[] P00EU4_n420TituloClienteId ;
      private int[] P00EU4_A261TituloId ;
      private bool[] P00EU4_n261TituloId ;
      private string[] P00EU4_A283TituloTipo ;
      private bool[] P00EU4_n283TituloTipo ;
      private bool[] P00EU4_A314TituloArchived ;
      private bool[] P00EU4_n314TituloArchived ;
      private bool[] P00EU4_A284TituloDeleted ;
      private bool[] P00EU4_n284TituloDeleted ;
      private int[] P00EU4_A951ContaBancariaId ;
      private bool[] P00EU4_n951ContaBancariaId ;
      private decimal[] P00EU4_A498TituloJurosMora ;
      private bool[] P00EU4_n498TituloJurosMora ;
      private DateTime[] P00EU4_A264TituloProrrogacao ;
      private bool[] P00EU4_n264TituloProrrogacao ;
      private decimal[] P00EU4_A276TituloDesconto ;
      private bool[] P00EU4_n276TituloDesconto ;
      private long[] P00EU4_A952ContaBancariaNumero ;
      private bool[] P00EU4_n952ContaBancariaNumero ;
      private decimal[] P00EU4_A262TituloValor ;
      private bool[] P00EU4_n262TituloValor ;
      private string[] P00EU4_A799NotaFiscalNumero ;
      private bool[] P00EU4_n799NotaFiscalNumero ;
      private string[] P00EU4_A648TituloPropostaTipo ;
      private bool[] P00EU4_n648TituloPropostaTipo ;
      private string[] P00EU4_A971TituloPropostaDescricao ;
      private bool[] P00EU4_n971TituloPropostaDescricao ;
      private string[] P00EU4_A972TituloCLienteRazaoSocial ;
      private bool[] P00EU4_n972TituloCLienteRazaoSocial ;
      private decimal[] P00EU4_A275TituloSaldo_F ;
      private bool[] P00EU4_n275TituloSaldo_F ;
      private short[] P00EU4_A286TituloCompetenciaAno ;
      private bool[] P00EU4_n286TituloCompetenciaAno ;
      private short[] P00EU4_A287TituloCompetenciaMes ;
      private bool[] P00EU4_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wpregistrartituloexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EU4( IGxContext context ,
                                             string A648TituloPropostaTipo ,
                                             GxSimpleCollection<string> AV150Wpregistrartitulods_20_tftitulopropostatipo_sels ,
                                             string AV132Wpregistrartitulods_2_dynamicfiltersselector1 ,
                                             short AV133Wpregistrartitulods_3_dynamicfiltersoperator1 ,
                                             decimal AV134Wpregistrartitulods_4_titulovalor1 ,
                                             long AV135Wpregistrartitulods_5_contabancarianumero1 ,
                                             bool AV136Wpregistrartitulods_6_dynamicfiltersenabled2 ,
                                             string AV137Wpregistrartitulods_7_dynamicfiltersselector2 ,
                                             short AV138Wpregistrartitulods_8_dynamicfiltersoperator2 ,
                                             decimal AV139Wpregistrartitulods_9_titulovalor2 ,
                                             long AV140Wpregistrartitulods_10_contabancarianumero2 ,
                                             bool AV141Wpregistrartitulods_11_dynamicfiltersenabled3 ,
                                             string AV142Wpregistrartitulods_12_dynamicfiltersselector3 ,
                                             short AV143Wpregistrartitulods_13_dynamicfiltersoperator3 ,
                                             decimal AV144Wpregistrartitulods_14_titulovalor3 ,
                                             long AV145Wpregistrartitulods_15_contabancarianumero3 ,
                                             string AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel ,
                                             string AV146Wpregistrartitulods_16_tftituloclienterazaosocial ,
                                             string AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel ,
                                             string AV148Wpregistrartitulods_18_tftitulopropostadescricao ,
                                             int AV150Wpregistrartitulods_20_tftitulopropostatipo_sels_Count ,
                                             decimal AV151Wpregistrartitulods_21_tftitulovalor ,
                                             decimal AV152Wpregistrartitulods_22_tftitulovalor_to ,
                                             decimal AV153Wpregistrartitulods_23_tftitulodesconto ,
                                             decimal AV154Wpregistrartitulods_24_tftitulodesconto_to ,
                                             DateTime AV157Wpregistrartitulods_27_tftituloprorrogacao ,
                                             DateTime AV158Wpregistrartitulods_28_tftituloprorrogacao_to ,
                                             decimal AV159Wpregistrartitulods_29_tftitulojurosmora ,
                                             decimal AV160Wpregistrartitulods_30_tftitulojurosmora_to ,
                                             string AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel ,
                                             string AV161Wpregistrartitulods_31_tfnotafiscalnumero ,
                                             decimal A262TituloValor ,
                                             long A952ContaBancariaNumero ,
                                             string A972TituloCLienteRazaoSocial ,
                                             string A971TituloPropostaDescricao ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             decimal A498TituloJurosMora ,
                                             string A799NotaFiscalNumero ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV131Wpregistrartitulods_1_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             string AV156Wpregistrartitulods_26_tftitulocompetencia_f_sel ,
                                             string AV155Wpregistrartitulods_25_tftitulocompetencia_f ,
                                             int A951ContaBancariaId ,
                                             bool A284TituloDeleted ,
                                             bool A314TituloArchived ,
                                             decimal A275TituloSaldo_F ,
                                             string A283TituloTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[32];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloPropostaId AS TituloPropostaId, T1.TituloClienteId AS TituloClienteId, T1.TituloId, T1.TituloTipo, T1.TituloArchived, T1.TituloDeleted, T1.ContaBancariaId, T1.TituloJurosMora, T1.TituloProrrogacao, T1.TituloDesconto, T7.ContaBancariaNumero, T1.TituloValor, T3.NotaFiscalNumero, T1.TituloPropostaTipo, T4.PropostaDescricao AS TituloPropostaDescricao, T5.ClienteRazaoSocial AS TituloCLienteRazaoSocial, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Proposta T4 ON T4.PropostaId = T1.TituloPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.TituloClienteId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT JOIN ContaBancaria T7 ON T7.ContaBancariaId = T1.ContaBancariaId)";
         AddWhere(sWhereString, "((T1.ContaBancariaId = 0) or T1.ContaBancariaId IS NULL)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         AddWhere(sWhereString, "(Not T1.TituloArchived)");
         AddWhere(sWhereString, "(Not (COALESCE( T6.TituloSaldo_F, 0) = 0))");
         AddWhere(sWhereString, "(T1.TituloTipo = ( 'CREDITO'))");
         if ( ( StringUtil.StrCmp(AV132Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV133Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV134Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV134Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV133Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV134Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV134Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Wpregistrartitulods_2_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV133Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV134Wpregistrartitulods_4_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV134Wpregistrartitulods_4_titulovalor1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV133Wpregistrartitulods_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV135Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV135Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV133Wpregistrartitulods_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV135Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV135Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Wpregistrartitulods_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV133Wpregistrartitulods_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV135Wpregistrartitulods_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV135Wpregistrartitulods_5_contabancarianumero1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV136Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV137Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV138Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV139Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV139Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV136Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV137Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV138Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV139Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV139Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV136Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV137Wpregistrartitulods_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV138Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV139Wpregistrartitulods_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV139Wpregistrartitulods_9_titulovalor2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV136Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV137Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV138Wpregistrartitulods_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV140Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV140Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV136Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV137Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV138Wpregistrartitulods_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV140Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV140Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV136Wpregistrartitulods_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV137Wpregistrartitulods_7_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV138Wpregistrartitulods_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV140Wpregistrartitulods_10_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV140Wpregistrartitulods_10_contabancarianumero2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV141Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV142Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV143Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV144Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV144Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV141Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV142Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV143Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV144Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV144Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV141Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV142Wpregistrartitulods_12_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV143Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV144Wpregistrartitulods_14_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV144Wpregistrartitulods_14_titulovalor3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV141Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV142Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV143Wpregistrartitulods_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV145Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero < :AV145Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV141Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV142Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV143Wpregistrartitulods_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV145Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero = :AV145Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV141Wpregistrartitulods_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV142Wpregistrartitulods_12_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV143Wpregistrartitulods_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV145Wpregistrartitulods_15_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T7.ContaBancariaNumero > :AV145Wpregistrartitulods_15_contabancarianumero3)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Wpregistrartitulods_16_tftituloclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV146Wpregistrartitulods_16_tftituloclienterazaosocial)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Wpregistrartitulods_18_tftitulopropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao like :lV148Wpregistrartitulods_18_tftitulopropostadescricao)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao = ( :AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T4.PropostaDescricao))=0))");
         }
         if ( AV150Wpregistrartitulods_20_tftitulopropostatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV150Wpregistrartitulods_20_tftitulopropostatipo_sels, "T1.TituloPropostaTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV151Wpregistrartitulods_21_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV151Wpregistrartitulods_21_tftitulovalor)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Wpregistrartitulods_22_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV152Wpregistrartitulods_22_tftitulovalor_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Wpregistrartitulods_23_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV153Wpregistrartitulods_23_tftitulodesconto)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Wpregistrartitulods_24_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV154Wpregistrartitulods_24_tftitulodesconto_to)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV157Wpregistrartitulods_27_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV157Wpregistrartitulods_27_tftituloprorrogacao)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV158Wpregistrartitulods_28_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV158Wpregistrartitulods_28_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV159Wpregistrartitulods_29_tftitulojurosmora) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora >= :AV159Wpregistrartitulods_29_tftitulojurosmora)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Wpregistrartitulods_30_tftitulojurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.TituloJurosMora <= :AV160Wpregistrartitulods_30_tftitulojurosmora_to)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Wpregistrartitulods_31_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero like :lV161Wpregistrartitulods_31_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero = ( :AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T3.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloProrrogacao DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.PropostaDescricao";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.PropostaDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaTipo";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloPropostaTipo DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloValor";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloValor DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloDesconto DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TituloJurosMora";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TituloJurosMora DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.NotaFiscalNumero";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.NotaFiscalNumero DESC";
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
                     return conditional_P00EU4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (long)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (DateTime)dynConstraints[36] , (decimal)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (int)dynConstraints[45] , (bool)dynConstraints[46] , (bool)dynConstraints[47] , (decimal)dynConstraints[48] , (string)dynConstraints[49] );
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
          Object[] prmP00EU4;
          prmP00EU4 = new Object[] {
          new ParDef("AV134Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV134Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV134Wpregistrartitulods_4_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV135Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV135Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV135Wpregistrartitulods_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV139Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV139Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV139Wpregistrartitulods_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV140Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV140Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV140Wpregistrartitulods_10_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV144Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV144Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV144Wpregistrartitulods_14_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV145Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV145Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV145Wpregistrartitulods_15_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV146Wpregistrartitulods_16_tftituloclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV147Wpregistrartitulods_17_tftituloclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV148Wpregistrartitulods_18_tftitulopropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV149Wpregistrartitulods_19_tftitulopropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV151Wpregistrartitulods_21_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV152Wpregistrartitulods_22_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV153Wpregistrartitulods_23_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV154Wpregistrartitulods_24_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV157Wpregistrartitulods_27_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV158Wpregistrartitulods_28_tftituloprorrogacao_to",GXType.Date,8,0) ,
          new ParDef("AV159Wpregistrartitulods_29_tftitulojurosmora",GXType.Number,16,4) ,
          new ParDef("AV160Wpregistrartitulods_30_tftitulojurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV161Wpregistrartitulods_31_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV162Wpregistrartitulods_32_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU4,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                return;
       }
    }

 }

}
