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
   public class propostanotawwexport : GXProcedure
   {
      public propostanotawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostanotawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "PropostaNotaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21PropostaQtdItensNota_F1 = (short)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV21PropostaQtdItensNota_F1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV21PropostaQtdItensNota_F1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAQTDITENSNOTA_F") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25PropostaQtdItensNota_F2 = (short)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV25PropostaQtdItensNota_F2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV25PropostaQtdItensNota_F2;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROPOSTAQTDITENSNOTA_F") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29PropostaQtdItensNota_F3 = (short)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV29PropostaQtdItensNota_F3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Itens Nota_F", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV29PropostaQtdItensNota_F3;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaProtocolo_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Protocolo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaProtocolo_Sel)) ? "(Vazio)" : AV36TFPropostaProtocolo_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaProtocolo)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Protocolo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFPropostaProtocolo, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPropostaEmpresaRazao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPropostaEmpresaRazao_Sel)) ? "(Vazio)" : AV38TFPropostaEmpresaRazao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPropostaEmpresaRazao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFPropostaEmpresaRazao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV39TFPropostaQtdItensNota_F) && (0==AV40TFPropostaQtdItensNota_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Quantidade") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV39TFPropostaQtdItensNota_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV40TFPropostaQtdItensNota_F_To;
         }
         if ( ! ( ( AV43TFPropostaTipoProposta_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Proposta") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV52GXV1 = 1;
            while ( AV52GXV1 <= AV43TFPropostaTipoProposta_Sels.Count )
            {
               AV42TFPropostaTipoProposta_Sel = ((string)AV43TFPropostaTipoProposta_Sels.Item(AV52GXV1));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmtipoproposta.getDescription(context,AV42TFPropostaTipoProposta_Sel);
               AV51i = (long)(AV51i+1);
               AV52GXV1 = (int)(AV52GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV44TFPropostaSumItensnota_F) && (Convert.ToDecimal(0)==AV45TFPropostaSumItensnota_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Total") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV44TFPropostaSumItensnota_F);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV45TFPropostaSumItensnota_F_To);
         }
         if ( ! ( (DateTime.MinValue==AV46TFPropostaCreatedAt) && (DateTime.MinValue==AV47TFPropostaCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data Criação") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV46TFPropostaCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV47TFPropostaCreatedAt_To;
         }
         if ( ! ( ( AV50TFPropostaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV53GXV2 = 1;
            while ( AV53GXV2 <= AV50TFPropostaStatus_Sels.Count )
            {
               AV49TFPropostaStatus_Sel = ((string)AV50TFPropostaStatus_Sels.Item(AV53GXV2));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusproposta.getDescription(context,AV49TFPropostaStatus_Sel);
               AV51i = (long)(AV51i+1);
               AV53GXV2 = (int)(AV53GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Protocolo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Cliente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Quantidade";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Tipo Proposta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Total";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Data Criação";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Propostanotawwds_1_filterfulltext = AV18FilterFullText;
         AV56Propostanotawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV57Propostanotawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV58Propostanotawwds_4_propostaqtditensnota_f1 = AV21PropostaQtdItensNota_F1;
         AV59Propostanotawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV60Propostanotawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV61Propostanotawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV62Propostanotawwds_8_propostaqtditensnota_f2 = AV25PropostaQtdItensNota_F2;
         AV63Propostanotawwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV64Propostanotawwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV65Propostanotawwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV66Propostanotawwds_12_propostaqtditensnota_f3 = AV29PropostaQtdItensNota_F3;
         AV67Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV68Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV69Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV70Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV71Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV73Propostanotawwds_19_tfpropostatipoproposta_sels = AV43TFPropostaTipoProposta_Sels;
         AV74Propostanotawwds_20_tfpropostasumitensnota_f = AV44TFPropostaSumItensnota_F;
         AV75Propostanotawwds_21_tfpropostasumitensnota_f_to = AV45TFPropostaSumItensnota_F_To;
         AV76Propostanotawwds_22_tfpropostacreatedat = AV46TFPropostaCreatedAt;
         AV77Propostanotawwds_23_tfpropostacreatedat_to = AV47TFPropostaCreatedAt_To;
         AV78Propostanotawwds_24_tfpropostastatus_sels = AV50TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A849PropostaTipoProposta ,
                                              AV73Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                              A329PropostaStatus ,
                                              AV78Propostanotawwds_24_tfpropostastatus_sels ,
                                              AV68Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                              AV67Propostanotawwds_13_tfpropostaprotocolo ,
                                              AV70Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                              AV69Propostanotawwds_15_tfpropostaempresarazao ,
                                              AV73Propostanotawwds_19_tfpropostatipoproposta_sels.Count ,
                                              AV74Propostanotawwds_20_tfpropostasumitensnota_f ,
                                              AV75Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                              AV76Propostanotawwds_22_tfpropostacreatedat ,
                                              AV77Propostanotawwds_23_tfpropostacreatedat_to ,
                                              AV78Propostanotawwds_24_tfpropostastatus_sels.Count ,
                                              A853PropostaProtocolo ,
                                              A888PropostaEmpresaRazao ,
                                              A887PropostaSumItensnota_F ,
                                              A327PropostaCreatedAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV55Propostanotawwds_1_filterfulltext ,
                                              A854PropostaQtdItensNota_F ,
                                              AV56Propostanotawwds_2_dynamicfiltersselector1 ,
                                              AV57Propostanotawwds_3_dynamicfiltersoperator1 ,
                                              AV58Propostanotawwds_4_propostaqtditensnota_f1 ,
                                              AV59Propostanotawwds_5_dynamicfiltersenabled2 ,
                                              AV60Propostanotawwds_6_dynamicfiltersselector2 ,
                                              AV61Propostanotawwds_7_dynamicfiltersoperator2 ,
                                              AV62Propostanotawwds_8_propostaqtditensnota_f2 ,
                                              AV63Propostanotawwds_9_dynamicfiltersenabled3 ,
                                              AV64Propostanotawwds_10_dynamicfiltersselector3 ,
                                              AV65Propostanotawwds_11_dynamicfiltersoperator3 ,
                                              AV66Propostanotawwds_12_propostaqtditensnota_f3 ,
                                              AV71Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                              AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV55Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Propostanotawwds_1_filterfulltext), "%", "");
         lV67Propostanotawwds_13_tfpropostaprotocolo = StringUtil.Concat( StringUtil.RTrim( AV67Propostanotawwds_13_tfpropostaprotocolo), "%", "");
         lV69Propostanotawwds_15_tfpropostaempresarazao = StringUtil.Concat( StringUtil.RTrim( AV69Propostanotawwds_15_tfpropostaempresarazao), "%", "");
         /* Using cursor P00E63 */
         pr_default.execute(0, new Object[] {AV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, lV55Propostanotawwds_1_filterfulltext, AV56Propostanotawwds_2_dynamicfiltersselector1, AV57Propostanotawwds_3_dynamicfiltersoperator1, AV58Propostanotawwds_4_propostaqtditensnota_f1, AV58Propostanotawwds_4_propostaqtditensnota_f1, AV56Propostanotawwds_2_dynamicfiltersselector1, AV57Propostanotawwds_3_dynamicfiltersoperator1, AV58Propostanotawwds_4_propostaqtditensnota_f1, AV58Propostanotawwds_4_propostaqtditensnota_f1, AV56Propostanotawwds_2_dynamicfiltersselector1, AV57Propostanotawwds_3_dynamicfiltersoperator1, AV58Propostanotawwds_4_propostaqtditensnota_f1, AV58Propostanotawwds_4_propostaqtditensnota_f1, AV59Propostanotawwds_5_dynamicfiltersenabled2, AV60Propostanotawwds_6_dynamicfiltersselector2, AV61Propostanotawwds_7_dynamicfiltersoperator2, AV62Propostanotawwds_8_propostaqtditensnota_f2, AV62Propostanotawwds_8_propostaqtditensnota_f2, AV59Propostanotawwds_5_dynamicfiltersenabled2, AV60Propostanotawwds_6_dynamicfiltersselector2, AV61Propostanotawwds_7_dynamicfiltersoperator2, AV62Propostanotawwds_8_propostaqtditensnota_f2, AV62Propostanotawwds_8_propostaqtditensnota_f2, AV59Propostanotawwds_5_dynamicfiltersenabled2, AV60Propostanotawwds_6_dynamicfiltersselector2, AV61Propostanotawwds_7_dynamicfiltersoperator2, AV62Propostanotawwds_8_propostaqtditensnota_f2, AV62Propostanotawwds_8_propostaqtditensnota_f2, AV63Propostanotawwds_9_dynamicfiltersenabled3, AV64Propostanotawwds_10_dynamicfiltersselector3, AV65Propostanotawwds_11_dynamicfiltersoperator3, AV66Propostanotawwds_12_propostaqtditensnota_f3, AV66Propostanotawwds_12_propostaqtditensnota_f3, AV63Propostanotawwds_9_dynamicfiltersenabled3, AV64Propostanotawwds_10_dynamicfiltersselector3, AV65Propostanotawwds_11_dynamicfiltersoperator3, AV66Propostanotawwds_12_propostaqtditensnota_f3, AV66Propostanotawwds_12_propostaqtditensnota_f3, AV63Propostanotawwds_9_dynamicfiltersenabled3, AV64Propostanotawwds_10_dynamicfiltersselector3, AV65Propostanotawwds_11_dynamicfiltersoperator3, AV66Propostanotawwds_12_propostaqtditensnota_f3, AV66Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_17_tfpropostaqtditensnota_f, AV71Propostanotawwds_17_tfpropostaqtditensnota_f, AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to, AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to, lV67Propostanotawwds_13_tfpropostaprotocolo, AV68Propostanotawwds_14_tfpropostaprotocolo_sel, lV69Propostanotawwds_15_tfpropostaempresarazao, AV70Propostanotawwds_16_tfpropostaempresarazao_sel, AV74Propostanotawwds_20_tfpropostasumitensnota_f, AV75Propostanotawwds_21_tfpropostasumitensnota_f_to, AV76Propostanotawwds_22_tfpropostacreatedat, AV77Propostanotawwds_23_tfpropostacreatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A850PropostaEmpresaClienteId = P00E63_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = P00E63_n850PropostaEmpresaClienteId[0];
            A323PropostaId = P00E63_A323PropostaId[0];
            n323PropostaId = P00E63_n323PropostaId[0];
            A327PropostaCreatedAt = P00E63_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = P00E63_n327PropostaCreatedAt[0];
            A329PropostaStatus = P00E63_A329PropostaStatus[0];
            n329PropostaStatus = P00E63_n329PropostaStatus[0];
            A849PropostaTipoProposta = P00E63_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = P00E63_n849PropostaTipoProposta[0];
            A888PropostaEmpresaRazao = P00E63_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E63_n888PropostaEmpresaRazao[0];
            A853PropostaProtocolo = P00E63_A853PropostaProtocolo[0];
            n853PropostaProtocolo = P00E63_n853PropostaProtocolo[0];
            A887PropostaSumItensnota_F = P00E63_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E63_A854PropostaQtdItensNota_F[0];
            A888PropostaEmpresaRazao = P00E63_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = P00E63_n888PropostaEmpresaRazao[0];
            A887PropostaSumItensnota_F = P00E63_A887PropostaSumItensnota_F[0];
            A854PropostaQtdItensNota_F = P00E63_A854PropostaQtdItensNota_F[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A853PropostaProtocolo, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A888PropostaEmpresaRazao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A854PropostaQtdItensNota_F;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = gxdomaindmtipoproposta.getDescription(context,A849PropostaTipoProposta);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A887PropostaSumItensnota_F);
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = A327PropostaCreatedAt;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = gxdomaindmstatusproposta.getDescription(context,A329PropostaStatus);
            if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 128, 128, 128);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV31Session.Set("WWPExportFileName", "PropostaNotaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("PropostaNotaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaNotaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("PropostaNotaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV79GXV3 = 1;
         while ( AV79GXV3 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV79GXV3));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO") == 0 )
            {
               AV35TFPropostaProtocolo = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO_SEL") == 0 )
            {
               AV36TFPropostaProtocolo_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO") == 0 )
            {
               AV37TFPropostaEmpresaRazao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO_SEL") == 0 )
            {
               AV38TFPropostaEmpresaRazao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV39TFPropostaQtdItensNota_F = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV40TFPropostaQtdItensNota_F_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTATIPOPROPOSTA_SEL") == 0 )
            {
               AV41TFPropostaTipoProposta_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV43TFPropostaTipoProposta_Sels.FromJSonString(AV41TFPropostaTipoProposta_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTASUMITENSNOTA_F") == 0 )
            {
               AV44TFPropostaSumItensnota_F = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV45TFPropostaSumItensnota_F_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTACREATEDAT") == 0 )
            {
               AV46TFPropostaCreatedAt = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV47TFPropostaCreatedAt_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV48TFPropostaStatus_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV50TFPropostaStatus_Sels.FromJSonString(AV48TFPropostaStatus_SelsJson, null);
            }
            AV79GXV3 = (int)(AV79GXV3+1);
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
         AV36TFPropostaProtocolo_Sel = "";
         AV35TFPropostaProtocolo = "";
         AV38TFPropostaEmpresaRazao_Sel = "";
         AV37TFPropostaEmpresaRazao = "";
         AV43TFPropostaTipoProposta_Sels = new GxSimpleCollection<string>();
         AV42TFPropostaTipoProposta_Sel = "";
         AV46TFPropostaCreatedAt = (DateTime)(DateTime.MinValue);
         AV47TFPropostaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV50TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV49TFPropostaStatus_Sel = "";
         AV55Propostanotawwds_1_filterfulltext = "";
         AV56Propostanotawwds_2_dynamicfiltersselector1 = "";
         AV60Propostanotawwds_6_dynamicfiltersselector2 = "";
         AV64Propostanotawwds_10_dynamicfiltersselector3 = "";
         AV67Propostanotawwds_13_tfpropostaprotocolo = "";
         AV68Propostanotawwds_14_tfpropostaprotocolo_sel = "";
         AV69Propostanotawwds_15_tfpropostaempresarazao = "";
         AV70Propostanotawwds_16_tfpropostaempresarazao_sel = "";
         AV73Propostanotawwds_19_tfpropostatipoproposta_sels = new GxSimpleCollection<string>();
         AV76Propostanotawwds_22_tfpropostacreatedat = (DateTime)(DateTime.MinValue);
         AV77Propostanotawwds_23_tfpropostacreatedat_to = (DateTime)(DateTime.MinValue);
         AV78Propostanotawwds_24_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV55Propostanotawwds_1_filterfulltext = "";
         lV67Propostanotawwds_13_tfpropostaprotocolo = "";
         lV69Propostanotawwds_15_tfpropostaempresarazao = "";
         A849PropostaTipoProposta = "";
         A329PropostaStatus = "";
         A853PropostaProtocolo = "";
         A888PropostaEmpresaRazao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         P00E63_A850PropostaEmpresaClienteId = new int[1] ;
         P00E63_n850PropostaEmpresaClienteId = new bool[] {false} ;
         P00E63_A323PropostaId = new int[1] ;
         P00E63_n323PropostaId = new bool[] {false} ;
         P00E63_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E63_n327PropostaCreatedAt = new bool[] {false} ;
         P00E63_A329PropostaStatus = new string[] {""} ;
         P00E63_n329PropostaStatus = new bool[] {false} ;
         P00E63_A849PropostaTipoProposta = new string[] {""} ;
         P00E63_n849PropostaTipoProposta = new bool[] {false} ;
         P00E63_A888PropostaEmpresaRazao = new string[] {""} ;
         P00E63_n888PropostaEmpresaRazao = new bool[] {false} ;
         P00E63_A853PropostaProtocolo = new string[] {""} ;
         P00E63_n853PropostaProtocolo = new bool[] {false} ;
         P00E63_A887PropostaSumItensnota_F = new decimal[1] ;
         P00E63_A854PropostaQtdItensNota_F = new short[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41TFPropostaTipoProposta_SelsJson = "";
         AV48TFPropostaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostanotawwexport__default(),
            new Object[][] {
                new Object[] {
               P00E63_A850PropostaEmpresaClienteId, P00E63_n850PropostaEmpresaClienteId, P00E63_A323PropostaId, P00E63_A327PropostaCreatedAt, P00E63_n327PropostaCreatedAt, P00E63_A329PropostaStatus, P00E63_n329PropostaStatus, P00E63_A849PropostaTipoProposta, P00E63_n849PropostaTipoProposta, P00E63_A888PropostaEmpresaRazao,
               P00E63_n888PropostaEmpresaRazao, P00E63_A853PropostaProtocolo, P00E63_n853PropostaProtocolo, P00E63_A887PropostaSumItensnota_F, P00E63_A854PropostaQtdItensNota_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV21PropostaQtdItensNota_F1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV25PropostaQtdItensNota_F2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV29PropostaQtdItensNota_F3 ;
      private short AV39TFPropostaQtdItensNota_F ;
      private short AV40TFPropostaQtdItensNota_F_To ;
      private short GXt_int2 ;
      private short AV57Propostanotawwds_3_dynamicfiltersoperator1 ;
      private short AV58Propostanotawwds_4_propostaqtditensnota_f1 ;
      private short AV61Propostanotawwds_7_dynamicfiltersoperator2 ;
      private short AV62Propostanotawwds_8_propostaqtditensnota_f2 ;
      private short AV65Propostanotawwds_11_dynamicfiltersoperator3 ;
      private short AV66Propostanotawwds_12_propostaqtditensnota_f3 ;
      private short AV71Propostanotawwds_17_tfpropostaqtditensnota_f ;
      private short AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to ;
      private short AV16OrderedBy ;
      private short A854PropostaQtdItensNota_F ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV52GXV1 ;
      private int AV53GXV2 ;
      private int AV73Propostanotawwds_19_tfpropostatipoproposta_sels_Count ;
      private int AV78Propostanotawwds_24_tfpropostastatus_sels_Count ;
      private int A850PropostaEmpresaClienteId ;
      private int A323PropostaId ;
      private int AV79GXV3 ;
      private long AV51i ;
      private decimal AV44TFPropostaSumItensnota_F ;
      private decimal AV45TFPropostaSumItensnota_F_To ;
      private decimal AV74Propostanotawwds_20_tfpropostasumitensnota_f ;
      private decimal AV75Propostanotawwds_21_tfpropostasumitensnota_f_to ;
      private decimal A887PropostaSumItensnota_F ;
      private string GXt_char1 ;
      private DateTime AV46TFPropostaCreatedAt ;
      private DateTime AV47TFPropostaCreatedAt_To ;
      private DateTime AV76Propostanotawwds_22_tfpropostacreatedat ;
      private DateTime AV77Propostanotawwds_23_tfpropostacreatedat_to ;
      private DateTime A327PropostaCreatedAt ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV59Propostanotawwds_5_dynamicfiltersenabled2 ;
      private bool AV63Propostanotawwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n323PropostaId ;
      private bool n327PropostaCreatedAt ;
      private bool n329PropostaStatus ;
      private bool n849PropostaTipoProposta ;
      private bool n888PropostaEmpresaRazao ;
      private bool n853PropostaProtocolo ;
      private string AV41TFPropostaTipoProposta_SelsJson ;
      private string AV48TFPropostaStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV36TFPropostaProtocolo_Sel ;
      private string AV35TFPropostaProtocolo ;
      private string AV38TFPropostaEmpresaRazao_Sel ;
      private string AV37TFPropostaEmpresaRazao ;
      private string AV42TFPropostaTipoProposta_Sel ;
      private string AV49TFPropostaStatus_Sel ;
      private string AV55Propostanotawwds_1_filterfulltext ;
      private string AV56Propostanotawwds_2_dynamicfiltersselector1 ;
      private string AV60Propostanotawwds_6_dynamicfiltersselector2 ;
      private string AV64Propostanotawwds_10_dynamicfiltersselector3 ;
      private string AV67Propostanotawwds_13_tfpropostaprotocolo ;
      private string AV68Propostanotawwds_14_tfpropostaprotocolo_sel ;
      private string AV69Propostanotawwds_15_tfpropostaempresarazao ;
      private string AV70Propostanotawwds_16_tfpropostaempresarazao_sel ;
      private string lV55Propostanotawwds_1_filterfulltext ;
      private string lV67Propostanotawwds_13_tfpropostaprotocolo ;
      private string lV69Propostanotawwds_15_tfpropostaempresarazao ;
      private string A849PropostaTipoProposta ;
      private string A329PropostaStatus ;
      private string A853PropostaProtocolo ;
      private string A888PropostaEmpresaRazao ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV43TFPropostaTipoProposta_Sels ;
      private GxSimpleCollection<string> AV50TFPropostaStatus_Sels ;
      private GxSimpleCollection<string> AV73Propostanotawwds_19_tfpropostatipoproposta_sels ;
      private GxSimpleCollection<string> AV78Propostanotawwds_24_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00E63_A850PropostaEmpresaClienteId ;
      private bool[] P00E63_n850PropostaEmpresaClienteId ;
      private int[] P00E63_A323PropostaId ;
      private bool[] P00E63_n323PropostaId ;
      private DateTime[] P00E63_A327PropostaCreatedAt ;
      private bool[] P00E63_n327PropostaCreatedAt ;
      private string[] P00E63_A329PropostaStatus ;
      private bool[] P00E63_n329PropostaStatus ;
      private string[] P00E63_A849PropostaTipoProposta ;
      private bool[] P00E63_n849PropostaTipoProposta ;
      private string[] P00E63_A888PropostaEmpresaRazao ;
      private bool[] P00E63_n888PropostaEmpresaRazao ;
      private string[] P00E63_A853PropostaProtocolo ;
      private bool[] P00E63_n853PropostaProtocolo ;
      private decimal[] P00E63_A887PropostaSumItensnota_F ;
      private short[] P00E63_A854PropostaQtdItensNota_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class propostanotawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E63( IGxContext context ,
                                             string A849PropostaTipoProposta ,
                                             GxSimpleCollection<string> AV73Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV78Propostanotawwds_24_tfpropostastatus_sels ,
                                             string AV68Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                             string AV67Propostanotawwds_13_tfpropostaprotocolo ,
                                             string AV70Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                             string AV69Propostanotawwds_15_tfpropostaempresarazao ,
                                             int AV73Propostanotawwds_19_tfpropostatipoproposta_sels_Count ,
                                             decimal AV74Propostanotawwds_20_tfpropostasumitensnota_f ,
                                             decimal AV75Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                             DateTime AV76Propostanotawwds_22_tfpropostacreatedat ,
                                             DateTime AV77Propostanotawwds_23_tfpropostacreatedat_to ,
                                             int AV78Propostanotawwds_24_tfpropostastatus_sels_Count ,
                                             string A853PropostaProtocolo ,
                                             string A888PropostaEmpresaRazao ,
                                             decimal A887PropostaSumItensnota_F ,
                                             DateTime A327PropostaCreatedAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV55Propostanotawwds_1_filterfulltext ,
                                             short A854PropostaQtdItensNota_F ,
                                             string AV56Propostanotawwds_2_dynamicfiltersselector1 ,
                                             short AV57Propostanotawwds_3_dynamicfiltersoperator1 ,
                                             short AV58Propostanotawwds_4_propostaqtditensnota_f1 ,
                                             bool AV59Propostanotawwds_5_dynamicfiltersenabled2 ,
                                             string AV60Propostanotawwds_6_dynamicfiltersselector2 ,
                                             short AV61Propostanotawwds_7_dynamicfiltersoperator2 ,
                                             short AV62Propostanotawwds_8_propostaqtditensnota_f2 ,
                                             bool AV63Propostanotawwds_9_dynamicfiltersenabled3 ,
                                             string AV64Propostanotawwds_10_dynamicfiltersselector3 ,
                                             short AV65Propostanotawwds_11_dynamicfiltersoperator3 ,
                                             short AV66Propostanotawwds_12_propostaqtditensnota_f3 ,
                                             short AV71Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                             short AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[69];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T1.PropostaId, T1.PropostaCreatedAt, T1.PropostaStatus, T1.PropostaTipoProposta, T2.ClienteRazaoSocial AS PropostaEmpresaRazao, T1.PropostaProtocolo, COALESCE( T3.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM ((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaEmpresaClienteId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId, COUNT(*) AS PropostaQtdItensNota_F FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV55Propostanotawwds_1_filterfulltext))=0) or ( ( T1.PropostaProtocolo like '%' || :lV55Propostanotawwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV55Propostanotawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaQtdItensNota_F, 0),'9999'), 2) like '%' || :lV55Propostanotawwds_1_filterfulltext) or ( 'clinica' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'CLINICA')) or ( 'compra de título' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'COMPRA_TITULO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaSumItensnota_F, 0),'999999999999990.99'), 2) like '%' || :lV55Propostanotawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV55Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada'))))");
         AddWhere(sWhereString, "(Not ( :AV56Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV57Propostanotawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV58Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV58Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV56Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV57Propostanotawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV58Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV58Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV56Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV57Propostanotawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV58Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV58Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV59Propostanotawwds_5_dynamicfiltersenabled2 and :AV60Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV61Propostanotawwds_7_dynamicfiltersoperator2 = 0 and ( Not (:AV62Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV62Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV59Propostanotawwds_5_dynamicfiltersenabled2 and :AV60Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV61Propostanotawwds_7_dynamicfiltersoperator2 = 1 and ( Not (:AV62Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV62Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV59Propostanotawwds_5_dynamicfiltersenabled2 and :AV60Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV61Propostanotawwds_7_dynamicfiltersoperator2 = 2 and ( Not (:AV62Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV62Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV63Propostanotawwds_9_dynamicfiltersenabled3 and :AV64Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV65Propostanotawwds_11_dynamicfiltersoperator3 = 0 and ( Not (:AV66Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV66Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV63Propostanotawwds_9_dynamicfiltersenabled3 and :AV64Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV65Propostanotawwds_11_dynamicfiltersoperator3 = 1 and ( Not (:AV66Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV66Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV63Propostanotawwds_9_dynamicfiltersenabled3 and :AV64Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV65Propostanotawwds_11_dynamicfiltersoperator3 = 2 and ( Not (:AV66Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV66Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "((:AV71Propostanotawwds_17_tfpropostaqtditensnota_f = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) >= :AV71Propostanotawwds_17_tfpropostaqtditensnota_f))");
         AddWhere(sWhereString, "((:AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) <= :AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to))");
         AddWhere(sWhereString, "(COALESCE( T3.PropostaQtdItensNota_F, 0) > 0)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Propostanotawwds_14_tfpropostaprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Propostanotawwds_13_tfpropostaprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo like :lV67Propostanotawwds_13_tfpropostaprotocolo)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Propostanotawwds_14_tfpropostaprotocolo_sel)) && ! ( StringUtil.StrCmp(AV68Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo = ( :AV68Propostanotawwds_14_tfpropostaprotocolo_sel))");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( StringUtil.StrCmp(AV68Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.PropostaProtocolo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Propostanotawwds_16_tfpropostaempresarazao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Propostanotawwds_15_tfpropostaempresarazao)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV69Propostanotawwds_15_tfpropostaempresarazao)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Propostanotawwds_16_tfpropostaempresarazao_sel)) && ! ( StringUtil.StrCmp(AV70Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV70Propostanotawwds_16_tfpropostaempresarazao_sel))");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( StringUtil.StrCmp(AV70Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV73Propostanotawwds_19_tfpropostatipoproposta_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV73Propostanotawwds_19_tfpropostatipoproposta_sels, "T1.PropostaTipoProposta IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV74Propostanotawwds_20_tfpropostasumitensnota_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) >= :AV74Propostanotawwds_20_tfpropostasumitensnota_f)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Propostanotawwds_21_tfpropostasumitensnota_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) <= :AV75Propostanotawwds_21_tfpropostasumitensnota_f_to)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Propostanotawwds_22_tfpropostacreatedat) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt >= :AV76Propostanotawwds_22_tfpropostacreatedat)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Propostanotawwds_23_tfpropostacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt <= :AV77Propostanotawwds_23_tfpropostacreatedat_to)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV78Propostanotawwds_24_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Propostanotawwds_24_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaProtocolo";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaProtocolo DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaTipoProposta";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaTipoProposta DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC";
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
                     return conditional_P00E63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] );
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
          Object[] prmP00E63;
          prmP00E63 = new Object[] {
          new ParDef("AV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV56Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV57Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV58Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV58Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV56Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV57Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV58Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV58Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV56Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV57Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV58Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV58Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV59Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV60Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV61Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV62Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV62Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV59Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV60Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV61Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV62Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV62Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV59Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV60Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV61Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV62Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV62Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV64Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV65Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV66Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV66Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV64Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV65Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV66Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV66Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV64Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV65Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV66Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV66Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("AV72Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("lV67Propostanotawwds_13_tfpropostaprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV68Propostanotawwds_14_tfpropostaprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Propostanotawwds_15_tfpropostaempresarazao",GXType.VarChar,150,0) ,
          new ParDef("AV70Propostanotawwds_16_tfpropostaempresarazao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV74Propostanotawwds_20_tfpropostasumitensnota_f",GXType.Number,18,2) ,
          new ParDef("AV75Propostanotawwds_21_tfpropostasumitensnota_f_to",GXType.Number,18,2) ,
          new ParDef("AV76Propostanotawwds_22_tfpropostacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV77Propostanotawwds_23_tfpropostacreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00E63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E63,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((short[]) buf[14])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
