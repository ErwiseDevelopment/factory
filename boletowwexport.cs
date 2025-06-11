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
   public class boletowwexport : GXProcedure
   {
      public boletowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boletowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "BoletoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "BOLETOSNOSSONUMERO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21BoletosNossoNumero1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21BoletosNossoNumero1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nosso Número", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nosso Número", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21BoletosNossoNumero1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "BOLETOSNOSSONUMERO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25BoletosNossoNumero2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25BoletosNossoNumero2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nosso Número", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nosso Número", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25BoletosNossoNumero2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "BOLETOSNOSSONUMERO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29BoletosNossoNumero3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29BoletosNossoNumero3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nosso Número", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nosso Número", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29BoletosNossoNumero3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFBoletosNossoNumero_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nosso Número") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFBoletosNossoNumero_Sel)) ? "(Vazio)" : AV36TFBoletosNossoNumero_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFBoletosNossoNumero)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nosso Número") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFBoletosNossoNumero, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBoletosSeuNumero_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Seu Número") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBoletosSeuNumero_Sel)) ? "(Vazio)" : AV38TFBoletosSeuNumero_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFBoletosSeuNumero)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Seu Número") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFBoletosSeuNumero, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFBoletosNumero_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFBoletosNumero_Sel)) ? "(Vazio)" : AV40TFBoletosNumero_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFBoletosNumero)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFBoletosNumero, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV43TFBoletosStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV71i = 1;
            AV73GXV1 = 1;
            while ( AV73GXV1 <= AV43TFBoletosStatus_Sels.Count )
            {
               AV42TFBoletosStatus_Sel = ((string)AV43TFBoletosStatus_Sels.Item(AV73GXV1));
               if ( AV71i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusboleto.getDescription(context,AV42TFBoletosStatus_Sel);
               AV71i = (long)(AV71i+1);
               AV73GXV1 = (int)(AV73GXV1+1);
            }
         }
         if ( ! ( (DateTime.MinValue==AV44TFBoletosDataEmissao) && (DateTime.MinValue==AV45TFBoletosDataEmissao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Emissão") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFBoletosDataEmissao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV45TFBoletosDataEmissao_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV46TFBoletosDataVencimento) && (DateTime.MinValue==AV47TFBoletosDataVencimento_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vencimento") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV46TFBoletosDataVencimento ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV47TFBoletosDataVencimento_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV48TFBoletosDataRegistro) && (DateTime.MinValue==AV49TFBoletosDataRegistro_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data de Registro") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV48TFBoletosDataRegistro;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV49TFBoletosDataRegistro_To;
         }
         if ( ! ( (DateTime.MinValue==AV50TFBoletosDataPagamento) && (DateTime.MinValue==AV51TFBoletosDataPagamento_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data do Pagamento") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV50TFBoletosDataPagamento ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TFBoletosDataPagamento_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV52TFBoletosDataBaixa) && (DateTime.MinValue==AV53TFBoletosDataBaixa_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data da Baixa") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV52TFBoletosDataBaixa ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV53TFBoletosDataBaixa_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV54TFBoletosValorNominal) && (Convert.ToDecimal(0)==AV55TFBoletosValorNominal_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor Nominal") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV54TFBoletosValorNominal);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV55TFBoletosValorNominal_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV56TFBoletosValorPago) && (Convert.ToDecimal(0)==AV57TFBoletosValorPago_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor Pago") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV56TFBoletosValorPago);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV57TFBoletosValorPago_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV58TFBoletosValorDesconto) && (Convert.ToDecimal(0)==AV59TFBoletosValorDesconto_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Desconto") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV58TFBoletosValorDesconto);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV59TFBoletosValorDesconto_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV60TFBoletosValorJuros) && (Convert.ToDecimal(0)==AV61TFBoletosValorJuros_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Juros") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV60TFBoletosValorJuros);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV61TFBoletosValorJuros_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV62TFBoletosValorMulta) && (Convert.ToDecimal(0)==AV63TFBoletosValorMulta_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Multa") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV62TFBoletosValorMulta);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV63TFBoletosValorMulta_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFBoletosSacadoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome do Sacado") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFBoletosSacadoNome_Sel)) ? "(Vazio)" : AV65TFBoletosSacadoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFBoletosSacadoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome do Sacado") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFBoletosSacadoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFBoletosSacadoDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento do Sacado") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV67TFBoletosSacadoDocumento_Sel)) ? "(Vazio)" : AV67TFBoletosSacadoDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFBoletosSacadoDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento do Sacado") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV66TFBoletosSacadoDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV70TFBoletosSacadoTipoDocumento_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Documento") ;
            AV13CellRow = GXt_int2;
            AV71i = 1;
            AV74GXV2 = 1;
            while ( AV74GXV2 <= AV70TFBoletosSacadoTipoDocumento_Sels.Count )
            {
               AV69TFBoletosSacadoTipoDocumento_Sel = ((string)AV70TFBoletosSacadoTipoDocumento_Sels.Item(AV74GXV2));
               if ( AV71i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmboletostipodocumento.getDescription(context,AV69TFBoletosSacadoTipoDocumento_Sel);
               AV71i = (long)(AV71i+1);
               AV74GXV2 = (int)(AV74GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nosso Número";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Seu Número";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Número";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Emissão";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Vencimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Data de Registro";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Data do Pagamento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Data da Baixa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Valor Nominal";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Valor Pago";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Text = "Desconto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Text = "Juros";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Text = "Multa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Text = "Nome do Sacado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Text = "Documento do Sacado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Text = "Tipo Documento";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV76Boletowwds_1_carteiradecobrancaid = AV72CarteiraDeCobrancaId;
         AV77Boletowwds_2_filterfulltext = AV18FilterFullText;
         AV78Boletowwds_3_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV79Boletowwds_4_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV80Boletowwds_5_boletosnossonumero1 = AV21BoletosNossoNumero1;
         AV81Boletowwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV82Boletowwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV83Boletowwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV84Boletowwds_9_boletosnossonumero2 = AV25BoletosNossoNumero2;
         AV85Boletowwds_10_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV86Boletowwds_11_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV87Boletowwds_12_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV88Boletowwds_13_boletosnossonumero3 = AV29BoletosNossoNumero3;
         AV89Boletowwds_14_tfboletosnossonumero = AV35TFBoletosNossoNumero;
         AV90Boletowwds_15_tfboletosnossonumero_sel = AV36TFBoletosNossoNumero_Sel;
         AV91Boletowwds_16_tfboletosseunumero = AV37TFBoletosSeuNumero;
         AV92Boletowwds_17_tfboletosseunumero_sel = AV38TFBoletosSeuNumero_Sel;
         AV93Boletowwds_18_tfboletosnumero = AV39TFBoletosNumero;
         AV94Boletowwds_19_tfboletosnumero_sel = AV40TFBoletosNumero_Sel;
         AV95Boletowwds_20_tfboletosstatus_sels = AV43TFBoletosStatus_Sels;
         AV96Boletowwds_21_tfboletosdataemissao = AV44TFBoletosDataEmissao;
         AV97Boletowwds_22_tfboletosdataemissao_to = AV45TFBoletosDataEmissao_To;
         AV98Boletowwds_23_tfboletosdatavencimento = AV46TFBoletosDataVencimento;
         AV99Boletowwds_24_tfboletosdatavencimento_to = AV47TFBoletosDataVencimento_To;
         AV100Boletowwds_25_tfboletosdataregistro = AV48TFBoletosDataRegistro;
         AV101Boletowwds_26_tfboletosdataregistro_to = AV49TFBoletosDataRegistro_To;
         AV102Boletowwds_27_tfboletosdatapagamento = AV50TFBoletosDataPagamento;
         AV103Boletowwds_28_tfboletosdatapagamento_to = AV51TFBoletosDataPagamento_To;
         AV104Boletowwds_29_tfboletosdatabaixa = AV52TFBoletosDataBaixa;
         AV105Boletowwds_30_tfboletosdatabaixa_to = AV53TFBoletosDataBaixa_To;
         AV106Boletowwds_31_tfboletosvalornominal = AV54TFBoletosValorNominal;
         AV107Boletowwds_32_tfboletosvalornominal_to = AV55TFBoletosValorNominal_To;
         AV108Boletowwds_33_tfboletosvalorpago = AV56TFBoletosValorPago;
         AV109Boletowwds_34_tfboletosvalorpago_to = AV57TFBoletosValorPago_To;
         AV110Boletowwds_35_tfboletosvalordesconto = AV58TFBoletosValorDesconto;
         AV111Boletowwds_36_tfboletosvalordesconto_to = AV59TFBoletosValorDesconto_To;
         AV112Boletowwds_37_tfboletosvalorjuros = AV60TFBoletosValorJuros;
         AV113Boletowwds_38_tfboletosvalorjuros_to = AV61TFBoletosValorJuros_To;
         AV114Boletowwds_39_tfboletosvalormulta = AV62TFBoletosValorMulta;
         AV115Boletowwds_40_tfboletosvalormulta_to = AV63TFBoletosValorMulta_To;
         AV116Boletowwds_41_tfboletossacadonome = AV64TFBoletosSacadoNome;
         AV117Boletowwds_42_tfboletossacadonome_sel = AV65TFBoletosSacadoNome_Sel;
         AV118Boletowwds_43_tfboletossacadodocumento = AV66TFBoletosSacadoDocumento;
         AV119Boletowwds_44_tfboletossacadodocumento_sel = AV67TFBoletosSacadoDocumento_Sel;
         AV120Boletowwds_45_tfboletossacadotipodocumento_sels = AV70TFBoletosSacadoTipoDocumento_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1083BoletosStatus ,
                                              AV95Boletowwds_20_tfboletosstatus_sels ,
                                              A1096BoletosSacadoTipoDocumento ,
                                              AV120Boletowwds_45_tfboletossacadotipodocumento_sels ,
                                              AV77Boletowwds_2_filterfulltext ,
                                              AV78Boletowwds_3_dynamicfiltersselector1 ,
                                              AV79Boletowwds_4_dynamicfiltersoperator1 ,
                                              AV80Boletowwds_5_boletosnossonumero1 ,
                                              AV81Boletowwds_6_dynamicfiltersenabled2 ,
                                              AV82Boletowwds_7_dynamicfiltersselector2 ,
                                              AV83Boletowwds_8_dynamicfiltersoperator2 ,
                                              AV84Boletowwds_9_boletosnossonumero2 ,
                                              AV85Boletowwds_10_dynamicfiltersenabled3 ,
                                              AV86Boletowwds_11_dynamicfiltersselector3 ,
                                              AV87Boletowwds_12_dynamicfiltersoperator3 ,
                                              AV88Boletowwds_13_boletosnossonumero3 ,
                                              AV90Boletowwds_15_tfboletosnossonumero_sel ,
                                              AV89Boletowwds_14_tfboletosnossonumero ,
                                              AV92Boletowwds_17_tfboletosseunumero_sel ,
                                              AV91Boletowwds_16_tfboletosseunumero ,
                                              AV94Boletowwds_19_tfboletosnumero_sel ,
                                              AV93Boletowwds_18_tfboletosnumero ,
                                              AV95Boletowwds_20_tfboletosstatus_sels.Count ,
                                              AV96Boletowwds_21_tfboletosdataemissao ,
                                              AV97Boletowwds_22_tfboletosdataemissao_to ,
                                              AV98Boletowwds_23_tfboletosdatavencimento ,
                                              AV99Boletowwds_24_tfboletosdatavencimento_to ,
                                              AV100Boletowwds_25_tfboletosdataregistro ,
                                              AV101Boletowwds_26_tfboletosdataregistro_to ,
                                              AV102Boletowwds_27_tfboletosdatapagamento ,
                                              AV103Boletowwds_28_tfboletosdatapagamento_to ,
                                              AV104Boletowwds_29_tfboletosdatabaixa ,
                                              AV105Boletowwds_30_tfboletosdatabaixa_to ,
                                              AV106Boletowwds_31_tfboletosvalornominal ,
                                              AV107Boletowwds_32_tfboletosvalornominal_to ,
                                              AV108Boletowwds_33_tfboletosvalorpago ,
                                              AV109Boletowwds_34_tfboletosvalorpago_to ,
                                              AV110Boletowwds_35_tfboletosvalordesconto ,
                                              AV111Boletowwds_36_tfboletosvalordesconto_to ,
                                              AV112Boletowwds_37_tfboletosvalorjuros ,
                                              AV113Boletowwds_38_tfboletosvalorjuros_to ,
                                              AV114Boletowwds_39_tfboletosvalormulta ,
                                              AV115Boletowwds_40_tfboletosvalormulta_to ,
                                              AV117Boletowwds_42_tfboletossacadonome_sel ,
                                              AV116Boletowwds_41_tfboletossacadonome ,
                                              AV119Boletowwds_44_tfboletossacadodocumento_sel ,
                                              AV118Boletowwds_43_tfboletossacadodocumento ,
                                              AV120Boletowwds_45_tfboletossacadotipodocumento_sels.Count ,
                                              A1078BoletosNossoNumero ,
                                              A1079BoletosSeuNumero ,
                                              A1080BoletosNumero ,
                                              A1089BoletosValorNominal ,
                                              A1090BoletosValorPago ,
                                              A1091BoletosValorDesconto ,
                                              A1092BoletosValorJuros ,
                                              A1093BoletosValorMulta ,
                                              A1094BoletosSacadoNome ,
                                              A1095BoletosSacadoDocumento ,
                                              A1084BoletosDataEmissao ,
                                              A1085BoletosDataVencimento ,
                                              A1086BoletosDataRegistro ,
                                              A1087BoletosDataPagamento ,
                                              A1088BoletosDataBaixa ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV76Boletowwds_1_carteiradecobrancaid ,
                                              A1069CarteiraDeCobrancaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV77Boletowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Boletowwds_2_filterfulltext), "%", "");
         lV80Boletowwds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV80Boletowwds_5_boletosnossonumero1), "%", "");
         lV80Boletowwds_5_boletosnossonumero1 = StringUtil.Concat( StringUtil.RTrim( AV80Boletowwds_5_boletosnossonumero1), "%", "");
         lV84Boletowwds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV84Boletowwds_9_boletosnossonumero2), "%", "");
         lV84Boletowwds_9_boletosnossonumero2 = StringUtil.Concat( StringUtil.RTrim( AV84Boletowwds_9_boletosnossonumero2), "%", "");
         lV88Boletowwds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV88Boletowwds_13_boletosnossonumero3), "%", "");
         lV88Boletowwds_13_boletosnossonumero3 = StringUtil.Concat( StringUtil.RTrim( AV88Boletowwds_13_boletosnossonumero3), "%", "");
         lV89Boletowwds_14_tfboletosnossonumero = StringUtil.Concat( StringUtil.RTrim( AV89Boletowwds_14_tfboletosnossonumero), "%", "");
         lV91Boletowwds_16_tfboletosseunumero = StringUtil.Concat( StringUtil.RTrim( AV91Boletowwds_16_tfboletosseunumero), "%", "");
         lV93Boletowwds_18_tfboletosnumero = StringUtil.Concat( StringUtil.RTrim( AV93Boletowwds_18_tfboletosnumero), "%", "");
         lV116Boletowwds_41_tfboletossacadonome = StringUtil.Concat( StringUtil.RTrim( AV116Boletowwds_41_tfboletossacadonome), "%", "");
         lV118Boletowwds_43_tfboletossacadodocumento = StringUtil.Concat( StringUtil.RTrim( AV118Boletowwds_43_tfboletossacadodocumento), "%", "");
         /* Using cursor P00FN2 */
         pr_default.execute(0, new Object[] {AV76Boletowwds_1_carteiradecobrancaid, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV77Boletowwds_2_filterfulltext, lV80Boletowwds_5_boletosnossonumero1, lV80Boletowwds_5_boletosnossonumero1, lV84Boletowwds_9_boletosnossonumero2, lV84Boletowwds_9_boletosnossonumero2, lV88Boletowwds_13_boletosnossonumero3, lV88Boletowwds_13_boletosnossonumero3, lV89Boletowwds_14_tfboletosnossonumero, AV90Boletowwds_15_tfboletosnossonumero_sel, lV91Boletowwds_16_tfboletosseunumero, AV92Boletowwds_17_tfboletosseunumero_sel, lV93Boletowwds_18_tfboletosnumero, AV94Boletowwds_19_tfboletosnumero_sel, AV96Boletowwds_21_tfboletosdataemissao, AV97Boletowwds_22_tfboletosdataemissao_to, AV98Boletowwds_23_tfboletosdatavencimento, AV99Boletowwds_24_tfboletosdatavencimento_to, AV100Boletowwds_25_tfboletosdataregistro, AV101Boletowwds_26_tfboletosdataregistro_to, AV102Boletowwds_27_tfboletosdatapagamento, AV103Boletowwds_28_tfboletosdatapagamento_to, AV104Boletowwds_29_tfboletosdatabaixa, AV105Boletowwds_30_tfboletosdatabaixa_to, AV106Boletowwds_31_tfboletosvalornominal, AV107Boletowwds_32_tfboletosvalornominal_to, AV108Boletowwds_33_tfboletosvalorpago, AV109Boletowwds_34_tfboletosvalorpago_to, AV110Boletowwds_35_tfboletosvalordesconto, AV111Boletowwds_36_tfboletosvalordesconto_to, AV112Boletowwds_37_tfboletosvalorjuros, AV113Boletowwds_38_tfboletosvalorjuros_to, AV114Boletowwds_39_tfboletosvalormulta, AV115Boletowwds_40_tfboletosvalormulta_to, lV116Boletowwds_41_tfboletossacadonome, AV117Boletowwds_42_tfboletossacadonome_sel, lV118Boletowwds_43_tfboletossacadodocumento, AV119Boletowwds_44_tfboletossacadodocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1093BoletosValorMulta = P00FN2_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = P00FN2_n1093BoletosValorMulta[0];
            A1092BoletosValorJuros = P00FN2_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = P00FN2_n1092BoletosValorJuros[0];
            A1091BoletosValorDesconto = P00FN2_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = P00FN2_n1091BoletosValorDesconto[0];
            A1090BoletosValorPago = P00FN2_A1090BoletosValorPago[0];
            n1090BoletosValorPago = P00FN2_n1090BoletosValorPago[0];
            A1089BoletosValorNominal = P00FN2_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = P00FN2_n1089BoletosValorNominal[0];
            A1088BoletosDataBaixa = P00FN2_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = P00FN2_n1088BoletosDataBaixa[0];
            A1087BoletosDataPagamento = P00FN2_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = P00FN2_n1087BoletosDataPagamento[0];
            A1086BoletosDataRegistro = P00FN2_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = P00FN2_n1086BoletosDataRegistro[0];
            A1085BoletosDataVencimento = P00FN2_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = P00FN2_n1085BoletosDataVencimento[0];
            A1084BoletosDataEmissao = P00FN2_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = P00FN2_n1084BoletosDataEmissao[0];
            A1096BoletosSacadoTipoDocumento = P00FN2_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = P00FN2_n1096BoletosSacadoTipoDocumento[0];
            A1095BoletosSacadoDocumento = P00FN2_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = P00FN2_n1095BoletosSacadoDocumento[0];
            A1094BoletosSacadoNome = P00FN2_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = P00FN2_n1094BoletosSacadoNome[0];
            A1083BoletosStatus = P00FN2_A1083BoletosStatus[0];
            n1083BoletosStatus = P00FN2_n1083BoletosStatus[0];
            A1080BoletosNumero = P00FN2_A1080BoletosNumero[0];
            n1080BoletosNumero = P00FN2_n1080BoletosNumero[0];
            A1079BoletosSeuNumero = P00FN2_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = P00FN2_n1079BoletosSeuNumero[0];
            A1078BoletosNossoNumero = P00FN2_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = P00FN2_n1078BoletosNossoNumero[0];
            A1069CarteiraDeCobrancaId = P00FN2_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = P00FN2_n1069CarteiraDeCobrancaId[0];
            A1077BoletosId = P00FN2_A1077BoletosId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1078BoletosNossoNumero, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1079BoletosSeuNumero, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1080BoletosNumero, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = gxdomaindmstatusboleto.getDescription(context,A1083BoletosStatus);
            GXt_dtime3 = DateTimeUtil.ResetTime( A1084BoletosDataEmissao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( A1085BoletosDataVencimento ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = GXt_dtime3;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Date = A1086BoletosDataRegistro;
            GXt_dtime3 = DateTimeUtil.ResetTime( A1087BoletosDataPagamento ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Date = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( A1088BoletosDataBaixa ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Date = GXt_dtime3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Number = (double)(A1089BoletosValorNominal);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Number = (double)(A1090BoletosValorPago);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+11, 1, 1).Number = (double)(A1091BoletosValorDesconto);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+12, 1, 1).Number = (double)(A1092BoletosValorJuros);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+13, 1, 1).Number = (double)(A1093BoletosValorMulta);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1094BoletosSacadoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+14, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1095BoletosSacadoDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+15, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+16, 1, 1).Text = gxdomaindmboletostipodocumento.getDescription(context,A1096BoletosSacadoTipoDocumento);
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
         AV31Session.Set("WWPExportFileName", "BoletoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("BoletoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "BoletoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("BoletoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV121GXV3 = 1;
         while ( AV121GXV3 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV121GXV3));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSNOSSONUMERO") == 0 )
            {
               AV35TFBoletosNossoNumero = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSNOSSONUMERO_SEL") == 0 )
            {
               AV36TFBoletosNossoNumero_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSEUNUMERO") == 0 )
            {
               AV37TFBoletosSeuNumero = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSEUNUMERO_SEL") == 0 )
            {
               AV38TFBoletosSeuNumero_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSNUMERO") == 0 )
            {
               AV39TFBoletosNumero = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSNUMERO_SEL") == 0 )
            {
               AV40TFBoletosNumero_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSTATUS_SEL") == 0 )
            {
               AV41TFBoletosStatus_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV43TFBoletosStatus_Sels.FromJSonString(AV41TFBoletosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAEMISSAO") == 0 )
            {
               AV44TFBoletosDataEmissao = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV45TFBoletosDataEmissao_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAVENCIMENTO") == 0 )
            {
               AV46TFBoletosDataVencimento = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV47TFBoletosDataVencimento_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAREGISTRO") == 0 )
            {
               AV48TFBoletosDataRegistro = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV49TFBoletosDataRegistro_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATAPAGAMENTO") == 0 )
            {
               AV50TFBoletosDataPagamento = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV51TFBoletosDataPagamento_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSDATABAIXA") == 0 )
            {
               AV52TFBoletosDataBaixa = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV53TFBoletosDataBaixa_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORNOMINAL") == 0 )
            {
               AV54TFBoletosValorNominal = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV55TFBoletosValorNominal_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORPAGO") == 0 )
            {
               AV56TFBoletosValorPago = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV57TFBoletosValorPago_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORDESCONTO") == 0 )
            {
               AV58TFBoletosValorDesconto = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV59TFBoletosValorDesconto_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORJUROS") == 0 )
            {
               AV60TFBoletosValorJuros = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV61TFBoletosValorJuros_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSVALORMULTA") == 0 )
            {
               AV62TFBoletosValorMulta = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV63TFBoletosValorMulta_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADONOME") == 0 )
            {
               AV64TFBoletosSacadoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADONOME_SEL") == 0 )
            {
               AV65TFBoletosSacadoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADODOCUMENTO") == 0 )
            {
               AV66TFBoletosSacadoDocumento = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADODOCUMENTO_SEL") == 0 )
            {
               AV67TFBoletosSacadoDocumento_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBOLETOSSACADOTIPODOCUMENTO_SEL") == 0 )
            {
               AV68TFBoletosSacadoTipoDocumento_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV70TFBoletosSacadoTipoDocumento_Sels.FromJSonString(AV68TFBoletosSacadoTipoDocumento_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&CARTEIRADECOBRANCAID") == 0 )
            {
               AV72CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV121GXV3 = (int)(AV121GXV3+1);
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
         AV21BoletosNossoNumero1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25BoletosNossoNumero2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29BoletosNossoNumero3 = "";
         AV36TFBoletosNossoNumero_Sel = "";
         AV35TFBoletosNossoNumero = "";
         AV38TFBoletosSeuNumero_Sel = "";
         AV37TFBoletosSeuNumero = "";
         AV40TFBoletosNumero_Sel = "";
         AV39TFBoletosNumero = "";
         AV43TFBoletosStatus_Sels = new GxSimpleCollection<string>();
         AV42TFBoletosStatus_Sel = "";
         AV44TFBoletosDataEmissao = DateTime.MinValue;
         AV45TFBoletosDataEmissao_To = DateTime.MinValue;
         AV46TFBoletosDataVencimento = DateTime.MinValue;
         AV47TFBoletosDataVencimento_To = DateTime.MinValue;
         AV48TFBoletosDataRegistro = (DateTime)(DateTime.MinValue);
         AV49TFBoletosDataRegistro_To = (DateTime)(DateTime.MinValue);
         AV50TFBoletosDataPagamento = DateTime.MinValue;
         AV51TFBoletosDataPagamento_To = DateTime.MinValue;
         AV52TFBoletosDataBaixa = DateTime.MinValue;
         AV53TFBoletosDataBaixa_To = DateTime.MinValue;
         AV65TFBoletosSacadoNome_Sel = "";
         AV64TFBoletosSacadoNome = "";
         AV67TFBoletosSacadoDocumento_Sel = "";
         AV66TFBoletosSacadoDocumento = "";
         AV70TFBoletosSacadoTipoDocumento_Sels = new GxSimpleCollection<string>();
         AV69TFBoletosSacadoTipoDocumento_Sel = "";
         AV77Boletowwds_2_filterfulltext = "";
         AV78Boletowwds_3_dynamicfiltersselector1 = "";
         AV80Boletowwds_5_boletosnossonumero1 = "";
         AV82Boletowwds_7_dynamicfiltersselector2 = "";
         AV84Boletowwds_9_boletosnossonumero2 = "";
         AV86Boletowwds_11_dynamicfiltersselector3 = "";
         AV88Boletowwds_13_boletosnossonumero3 = "";
         AV89Boletowwds_14_tfboletosnossonumero = "";
         AV90Boletowwds_15_tfboletosnossonumero_sel = "";
         AV91Boletowwds_16_tfboletosseunumero = "";
         AV92Boletowwds_17_tfboletosseunumero_sel = "";
         AV93Boletowwds_18_tfboletosnumero = "";
         AV94Boletowwds_19_tfboletosnumero_sel = "";
         AV95Boletowwds_20_tfboletosstatus_sels = new GxSimpleCollection<string>();
         AV96Boletowwds_21_tfboletosdataemissao = DateTime.MinValue;
         AV97Boletowwds_22_tfboletosdataemissao_to = DateTime.MinValue;
         AV98Boletowwds_23_tfboletosdatavencimento = DateTime.MinValue;
         AV99Boletowwds_24_tfboletosdatavencimento_to = DateTime.MinValue;
         AV100Boletowwds_25_tfboletosdataregistro = (DateTime)(DateTime.MinValue);
         AV101Boletowwds_26_tfboletosdataregistro_to = (DateTime)(DateTime.MinValue);
         AV102Boletowwds_27_tfboletosdatapagamento = DateTime.MinValue;
         AV103Boletowwds_28_tfboletosdatapagamento_to = DateTime.MinValue;
         AV104Boletowwds_29_tfboletosdatabaixa = DateTime.MinValue;
         AV105Boletowwds_30_tfboletosdatabaixa_to = DateTime.MinValue;
         AV116Boletowwds_41_tfboletossacadonome = "";
         AV117Boletowwds_42_tfboletossacadonome_sel = "";
         AV118Boletowwds_43_tfboletossacadodocumento = "";
         AV119Boletowwds_44_tfboletossacadodocumento_sel = "";
         AV120Boletowwds_45_tfboletossacadotipodocumento_sels = new GxSimpleCollection<string>();
         lV77Boletowwds_2_filterfulltext = "";
         lV80Boletowwds_5_boletosnossonumero1 = "";
         lV84Boletowwds_9_boletosnossonumero2 = "";
         lV88Boletowwds_13_boletosnossonumero3 = "";
         lV89Boletowwds_14_tfboletosnossonumero = "";
         lV91Boletowwds_16_tfboletosseunumero = "";
         lV93Boletowwds_18_tfboletosnumero = "";
         lV116Boletowwds_41_tfboletossacadonome = "";
         lV118Boletowwds_43_tfboletossacadodocumento = "";
         A1083BoletosStatus = "";
         A1096BoletosSacadoTipoDocumento = "";
         A1078BoletosNossoNumero = "";
         A1079BoletosSeuNumero = "";
         A1080BoletosNumero = "";
         A1094BoletosSacadoNome = "";
         A1095BoletosSacadoDocumento = "";
         A1084BoletosDataEmissao = DateTime.MinValue;
         A1085BoletosDataVencimento = DateTime.MinValue;
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         A1087BoletosDataPagamento = DateTime.MinValue;
         A1088BoletosDataBaixa = DateTime.MinValue;
         P00FN2_A1093BoletosValorMulta = new decimal[1] ;
         P00FN2_n1093BoletosValorMulta = new bool[] {false} ;
         P00FN2_A1092BoletosValorJuros = new decimal[1] ;
         P00FN2_n1092BoletosValorJuros = new bool[] {false} ;
         P00FN2_A1091BoletosValorDesconto = new decimal[1] ;
         P00FN2_n1091BoletosValorDesconto = new bool[] {false} ;
         P00FN2_A1090BoletosValorPago = new decimal[1] ;
         P00FN2_n1090BoletosValorPago = new bool[] {false} ;
         P00FN2_A1089BoletosValorNominal = new decimal[1] ;
         P00FN2_n1089BoletosValorNominal = new bool[] {false} ;
         P00FN2_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         P00FN2_n1088BoletosDataBaixa = new bool[] {false} ;
         P00FN2_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         P00FN2_n1087BoletosDataPagamento = new bool[] {false} ;
         P00FN2_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         P00FN2_n1086BoletosDataRegistro = new bool[] {false} ;
         P00FN2_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00FN2_n1085BoletosDataVencimento = new bool[] {false} ;
         P00FN2_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00FN2_n1084BoletosDataEmissao = new bool[] {false} ;
         P00FN2_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         P00FN2_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         P00FN2_A1095BoletosSacadoDocumento = new string[] {""} ;
         P00FN2_n1095BoletosSacadoDocumento = new bool[] {false} ;
         P00FN2_A1094BoletosSacadoNome = new string[] {""} ;
         P00FN2_n1094BoletosSacadoNome = new bool[] {false} ;
         P00FN2_A1083BoletosStatus = new string[] {""} ;
         P00FN2_n1083BoletosStatus = new bool[] {false} ;
         P00FN2_A1080BoletosNumero = new string[] {""} ;
         P00FN2_n1080BoletosNumero = new bool[] {false} ;
         P00FN2_A1079BoletosSeuNumero = new string[] {""} ;
         P00FN2_n1079BoletosSeuNumero = new bool[] {false} ;
         P00FN2_A1078BoletosNossoNumero = new string[] {""} ;
         P00FN2_n1078BoletosNossoNumero = new bool[] {false} ;
         P00FN2_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FN2_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FN2_A1077BoletosId = new int[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41TFBoletosStatus_SelsJson = "";
         AV68TFBoletosSacadoTipoDocumento_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boletowwexport__default(),
            new Object[][] {
                new Object[] {
               P00FN2_A1093BoletosValorMulta, P00FN2_n1093BoletosValorMulta, P00FN2_A1092BoletosValorJuros, P00FN2_n1092BoletosValorJuros, P00FN2_A1091BoletosValorDesconto, P00FN2_n1091BoletosValorDesconto, P00FN2_A1090BoletosValorPago, P00FN2_n1090BoletosValorPago, P00FN2_A1089BoletosValorNominal, P00FN2_n1089BoletosValorNominal,
               P00FN2_A1088BoletosDataBaixa, P00FN2_n1088BoletosDataBaixa, P00FN2_A1087BoletosDataPagamento, P00FN2_n1087BoletosDataPagamento, P00FN2_A1086BoletosDataRegistro, P00FN2_n1086BoletosDataRegistro, P00FN2_A1085BoletosDataVencimento, P00FN2_n1085BoletosDataVencimento, P00FN2_A1084BoletosDataEmissao, P00FN2_n1084BoletosDataEmissao,
               P00FN2_A1096BoletosSacadoTipoDocumento, P00FN2_n1096BoletosSacadoTipoDocumento, P00FN2_A1095BoletosSacadoDocumento, P00FN2_n1095BoletosSacadoDocumento, P00FN2_A1094BoletosSacadoNome, P00FN2_n1094BoletosSacadoNome, P00FN2_A1083BoletosStatus, P00FN2_n1083BoletosStatus, P00FN2_A1080BoletosNumero, P00FN2_n1080BoletosNumero,
               P00FN2_A1079BoletosSeuNumero, P00FN2_n1079BoletosSeuNumero, P00FN2_A1078BoletosNossoNumero, P00FN2_n1078BoletosNossoNumero, P00FN2_A1069CarteiraDeCobrancaId, P00FN2_n1069CarteiraDeCobrancaId, P00FN2_A1077BoletosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV79Boletowwds_4_dynamicfiltersoperator1 ;
      private short AV83Boletowwds_8_dynamicfiltersoperator2 ;
      private short AV87Boletowwds_12_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV73GXV1 ;
      private int AV74GXV2 ;
      private int AV76Boletowwds_1_carteiradecobrancaid ;
      private int AV72CarteiraDeCobrancaId ;
      private int AV95Boletowwds_20_tfboletosstatus_sels_Count ;
      private int AV120Boletowwds_45_tfboletossacadotipodocumento_sels_Count ;
      private int A1069CarteiraDeCobrancaId ;
      private int A1077BoletosId ;
      private int AV121GXV3 ;
      private long AV71i ;
      private decimal AV54TFBoletosValorNominal ;
      private decimal AV55TFBoletosValorNominal_To ;
      private decimal AV56TFBoletosValorPago ;
      private decimal AV57TFBoletosValorPago_To ;
      private decimal AV58TFBoletosValorDesconto ;
      private decimal AV59TFBoletosValorDesconto_To ;
      private decimal AV60TFBoletosValorJuros ;
      private decimal AV61TFBoletosValorJuros_To ;
      private decimal AV62TFBoletosValorMulta ;
      private decimal AV63TFBoletosValorMulta_To ;
      private decimal AV106Boletowwds_31_tfboletosvalornominal ;
      private decimal AV107Boletowwds_32_tfboletosvalornominal_to ;
      private decimal AV108Boletowwds_33_tfboletosvalorpago ;
      private decimal AV109Boletowwds_34_tfboletosvalorpago_to ;
      private decimal AV110Boletowwds_35_tfboletosvalordesconto ;
      private decimal AV111Boletowwds_36_tfboletosvalordesconto_to ;
      private decimal AV112Boletowwds_37_tfboletosvalorjuros ;
      private decimal AV113Boletowwds_38_tfboletosvalorjuros_to ;
      private decimal AV114Boletowwds_39_tfboletosvalormulta ;
      private decimal AV115Boletowwds_40_tfboletosvalormulta_to ;
      private decimal A1089BoletosValorNominal ;
      private decimal A1090BoletosValorPago ;
      private decimal A1091BoletosValorDesconto ;
      private decimal A1092BoletosValorJuros ;
      private decimal A1093BoletosValorMulta ;
      private string GXt_char1 ;
      private DateTime AV48TFBoletosDataRegistro ;
      private DateTime AV49TFBoletosDataRegistro_To ;
      private DateTime AV100Boletowwds_25_tfboletosdataregistro ;
      private DateTime AV101Boletowwds_26_tfboletosdataregistro_to ;
      private DateTime A1086BoletosDataRegistro ;
      private DateTime GXt_dtime3 ;
      private DateTime AV44TFBoletosDataEmissao ;
      private DateTime AV45TFBoletosDataEmissao_To ;
      private DateTime AV46TFBoletosDataVencimento ;
      private DateTime AV47TFBoletosDataVencimento_To ;
      private DateTime AV50TFBoletosDataPagamento ;
      private DateTime AV51TFBoletosDataPagamento_To ;
      private DateTime AV52TFBoletosDataBaixa ;
      private DateTime AV53TFBoletosDataBaixa_To ;
      private DateTime AV96Boletowwds_21_tfboletosdataemissao ;
      private DateTime AV97Boletowwds_22_tfboletosdataemissao_to ;
      private DateTime AV98Boletowwds_23_tfboletosdatavencimento ;
      private DateTime AV99Boletowwds_24_tfboletosdatavencimento_to ;
      private DateTime AV102Boletowwds_27_tfboletosdatapagamento ;
      private DateTime AV103Boletowwds_28_tfboletosdatapagamento_to ;
      private DateTime AV104Boletowwds_29_tfboletosdatabaixa ;
      private DateTime AV105Boletowwds_30_tfboletosdatabaixa_to ;
      private DateTime A1084BoletosDataEmissao ;
      private DateTime A1085BoletosDataVencimento ;
      private DateTime A1087BoletosDataPagamento ;
      private DateTime A1088BoletosDataBaixa ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV81Boletowwds_6_dynamicfiltersenabled2 ;
      private bool AV85Boletowwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n1093BoletosValorMulta ;
      private bool n1092BoletosValorJuros ;
      private bool n1091BoletosValorDesconto ;
      private bool n1090BoletosValorPago ;
      private bool n1089BoletosValorNominal ;
      private bool n1088BoletosDataBaixa ;
      private bool n1087BoletosDataPagamento ;
      private bool n1086BoletosDataRegistro ;
      private bool n1085BoletosDataVencimento ;
      private bool n1084BoletosDataEmissao ;
      private bool n1096BoletosSacadoTipoDocumento ;
      private bool n1095BoletosSacadoDocumento ;
      private bool n1094BoletosSacadoNome ;
      private bool n1083BoletosStatus ;
      private bool n1080BoletosNumero ;
      private bool n1079BoletosSeuNumero ;
      private bool n1078BoletosNossoNumero ;
      private bool n1069CarteiraDeCobrancaId ;
      private string AV41TFBoletosStatus_SelsJson ;
      private string AV68TFBoletosSacadoTipoDocumento_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21BoletosNossoNumero1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25BoletosNossoNumero2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29BoletosNossoNumero3 ;
      private string AV36TFBoletosNossoNumero_Sel ;
      private string AV35TFBoletosNossoNumero ;
      private string AV38TFBoletosSeuNumero_Sel ;
      private string AV37TFBoletosSeuNumero ;
      private string AV40TFBoletosNumero_Sel ;
      private string AV39TFBoletosNumero ;
      private string AV42TFBoletosStatus_Sel ;
      private string AV65TFBoletosSacadoNome_Sel ;
      private string AV64TFBoletosSacadoNome ;
      private string AV67TFBoletosSacadoDocumento_Sel ;
      private string AV66TFBoletosSacadoDocumento ;
      private string AV69TFBoletosSacadoTipoDocumento_Sel ;
      private string AV77Boletowwds_2_filterfulltext ;
      private string AV78Boletowwds_3_dynamicfiltersselector1 ;
      private string AV80Boletowwds_5_boletosnossonumero1 ;
      private string AV82Boletowwds_7_dynamicfiltersselector2 ;
      private string AV84Boletowwds_9_boletosnossonumero2 ;
      private string AV86Boletowwds_11_dynamicfiltersselector3 ;
      private string AV88Boletowwds_13_boletosnossonumero3 ;
      private string AV89Boletowwds_14_tfboletosnossonumero ;
      private string AV90Boletowwds_15_tfboletosnossonumero_sel ;
      private string AV91Boletowwds_16_tfboletosseunumero ;
      private string AV92Boletowwds_17_tfboletosseunumero_sel ;
      private string AV93Boletowwds_18_tfboletosnumero ;
      private string AV94Boletowwds_19_tfboletosnumero_sel ;
      private string AV116Boletowwds_41_tfboletossacadonome ;
      private string AV117Boletowwds_42_tfboletossacadonome_sel ;
      private string AV118Boletowwds_43_tfboletossacadodocumento ;
      private string AV119Boletowwds_44_tfboletossacadodocumento_sel ;
      private string lV77Boletowwds_2_filterfulltext ;
      private string lV80Boletowwds_5_boletosnossonumero1 ;
      private string lV84Boletowwds_9_boletosnossonumero2 ;
      private string lV88Boletowwds_13_boletosnossonumero3 ;
      private string lV89Boletowwds_14_tfboletosnossonumero ;
      private string lV91Boletowwds_16_tfboletosseunumero ;
      private string lV93Boletowwds_18_tfboletosnumero ;
      private string lV116Boletowwds_41_tfboletossacadonome ;
      private string lV118Boletowwds_43_tfboletossacadodocumento ;
      private string A1083BoletosStatus ;
      private string A1096BoletosSacadoTipoDocumento ;
      private string A1078BoletosNossoNumero ;
      private string A1079BoletosSeuNumero ;
      private string A1080BoletosNumero ;
      private string A1094BoletosSacadoNome ;
      private string A1095BoletosSacadoDocumento ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV43TFBoletosStatus_Sels ;
      private GxSimpleCollection<string> AV70TFBoletosSacadoTipoDocumento_Sels ;
      private GxSimpleCollection<string> AV95Boletowwds_20_tfboletosstatus_sels ;
      private GxSimpleCollection<string> AV120Boletowwds_45_tfboletossacadotipodocumento_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00FN2_A1093BoletosValorMulta ;
      private bool[] P00FN2_n1093BoletosValorMulta ;
      private decimal[] P00FN2_A1092BoletosValorJuros ;
      private bool[] P00FN2_n1092BoletosValorJuros ;
      private decimal[] P00FN2_A1091BoletosValorDesconto ;
      private bool[] P00FN2_n1091BoletosValorDesconto ;
      private decimal[] P00FN2_A1090BoletosValorPago ;
      private bool[] P00FN2_n1090BoletosValorPago ;
      private decimal[] P00FN2_A1089BoletosValorNominal ;
      private bool[] P00FN2_n1089BoletosValorNominal ;
      private DateTime[] P00FN2_A1088BoletosDataBaixa ;
      private bool[] P00FN2_n1088BoletosDataBaixa ;
      private DateTime[] P00FN2_A1087BoletosDataPagamento ;
      private bool[] P00FN2_n1087BoletosDataPagamento ;
      private DateTime[] P00FN2_A1086BoletosDataRegistro ;
      private bool[] P00FN2_n1086BoletosDataRegistro ;
      private DateTime[] P00FN2_A1085BoletosDataVencimento ;
      private bool[] P00FN2_n1085BoletosDataVencimento ;
      private DateTime[] P00FN2_A1084BoletosDataEmissao ;
      private bool[] P00FN2_n1084BoletosDataEmissao ;
      private string[] P00FN2_A1096BoletosSacadoTipoDocumento ;
      private bool[] P00FN2_n1096BoletosSacadoTipoDocumento ;
      private string[] P00FN2_A1095BoletosSacadoDocumento ;
      private bool[] P00FN2_n1095BoletosSacadoDocumento ;
      private string[] P00FN2_A1094BoletosSacadoNome ;
      private bool[] P00FN2_n1094BoletosSacadoNome ;
      private string[] P00FN2_A1083BoletosStatus ;
      private bool[] P00FN2_n1083BoletosStatus ;
      private string[] P00FN2_A1080BoletosNumero ;
      private bool[] P00FN2_n1080BoletosNumero ;
      private string[] P00FN2_A1079BoletosSeuNumero ;
      private bool[] P00FN2_n1079BoletosSeuNumero ;
      private string[] P00FN2_A1078BoletosNossoNumero ;
      private bool[] P00FN2_n1078BoletosNossoNumero ;
      private int[] P00FN2_A1069CarteiraDeCobrancaId ;
      private bool[] P00FN2_n1069CarteiraDeCobrancaId ;
      private int[] P00FN2_A1077BoletosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class boletowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FN2( IGxContext context ,
                                             string A1083BoletosStatus ,
                                             GxSimpleCollection<string> AV95Boletowwds_20_tfboletosstatus_sels ,
                                             string A1096BoletosSacadoTipoDocumento ,
                                             GxSimpleCollection<string> AV120Boletowwds_45_tfboletossacadotipodocumento_sels ,
                                             string AV77Boletowwds_2_filterfulltext ,
                                             string AV78Boletowwds_3_dynamicfiltersselector1 ,
                                             short AV79Boletowwds_4_dynamicfiltersoperator1 ,
                                             string AV80Boletowwds_5_boletosnossonumero1 ,
                                             bool AV81Boletowwds_6_dynamicfiltersenabled2 ,
                                             string AV82Boletowwds_7_dynamicfiltersselector2 ,
                                             short AV83Boletowwds_8_dynamicfiltersoperator2 ,
                                             string AV84Boletowwds_9_boletosnossonumero2 ,
                                             bool AV85Boletowwds_10_dynamicfiltersenabled3 ,
                                             string AV86Boletowwds_11_dynamicfiltersselector3 ,
                                             short AV87Boletowwds_12_dynamicfiltersoperator3 ,
                                             string AV88Boletowwds_13_boletosnossonumero3 ,
                                             string AV90Boletowwds_15_tfboletosnossonumero_sel ,
                                             string AV89Boletowwds_14_tfboletosnossonumero ,
                                             string AV92Boletowwds_17_tfboletosseunumero_sel ,
                                             string AV91Boletowwds_16_tfboletosseunumero ,
                                             string AV94Boletowwds_19_tfboletosnumero_sel ,
                                             string AV93Boletowwds_18_tfboletosnumero ,
                                             int AV95Boletowwds_20_tfboletosstatus_sels_Count ,
                                             DateTime AV96Boletowwds_21_tfboletosdataemissao ,
                                             DateTime AV97Boletowwds_22_tfboletosdataemissao_to ,
                                             DateTime AV98Boletowwds_23_tfboletosdatavencimento ,
                                             DateTime AV99Boletowwds_24_tfboletosdatavencimento_to ,
                                             DateTime AV100Boletowwds_25_tfboletosdataregistro ,
                                             DateTime AV101Boletowwds_26_tfboletosdataregistro_to ,
                                             DateTime AV102Boletowwds_27_tfboletosdatapagamento ,
                                             DateTime AV103Boletowwds_28_tfboletosdatapagamento_to ,
                                             DateTime AV104Boletowwds_29_tfboletosdatabaixa ,
                                             DateTime AV105Boletowwds_30_tfboletosdatabaixa_to ,
                                             decimal AV106Boletowwds_31_tfboletosvalornominal ,
                                             decimal AV107Boletowwds_32_tfboletosvalornominal_to ,
                                             decimal AV108Boletowwds_33_tfboletosvalorpago ,
                                             decimal AV109Boletowwds_34_tfboletosvalorpago_to ,
                                             decimal AV110Boletowwds_35_tfboletosvalordesconto ,
                                             decimal AV111Boletowwds_36_tfboletosvalordesconto_to ,
                                             decimal AV112Boletowwds_37_tfboletosvalorjuros ,
                                             decimal AV113Boletowwds_38_tfboletosvalorjuros_to ,
                                             decimal AV114Boletowwds_39_tfboletosvalormulta ,
                                             decimal AV115Boletowwds_40_tfboletosvalormulta_to ,
                                             string AV117Boletowwds_42_tfboletossacadonome_sel ,
                                             string AV116Boletowwds_41_tfboletossacadonome ,
                                             string AV119Boletowwds_44_tfboletossacadodocumento_sel ,
                                             string AV118Boletowwds_43_tfboletossacadodocumento ,
                                             int AV120Boletowwds_45_tfboletossacadotipodocumento_sels_Count ,
                                             string A1078BoletosNossoNumero ,
                                             string A1079BoletosSeuNumero ,
                                             string A1080BoletosNumero ,
                                             decimal A1089BoletosValorNominal ,
                                             decimal A1090BoletosValorPago ,
                                             decimal A1091BoletosValorDesconto ,
                                             decimal A1092BoletosValorJuros ,
                                             decimal A1093BoletosValorMulta ,
                                             string A1094BoletosSacadoNome ,
                                             string A1095BoletosSacadoDocumento ,
                                             DateTime A1084BoletosDataEmissao ,
                                             DateTime A1085BoletosDataVencimento ,
                                             DateTime A1086BoletosDataRegistro ,
                                             DateTime A1087BoletosDataPagamento ,
                                             DateTime A1088BoletosDataBaixa ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV76Boletowwds_1_carteiradecobrancaid ,
                                             int A1069CarteiraDeCobrancaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[55];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT BoletosValorMulta, BoletosValorJuros, BoletosValorDesconto, BoletosValorPago, BoletosValorNominal, BoletosDataBaixa, BoletosDataPagamento, BoletosDataRegistro, BoletosDataVencimento, BoletosDataEmissao, BoletosSacadoTipoDocumento, BoletosSacadoDocumento, BoletosSacadoNome, BoletosStatus, BoletosNumero, BoletosSeuNumero, BoletosNossoNumero, CarteiraDeCobrancaId, BoletosId FROM Boleto";
         AddWhere(sWhereString, "(CarteiraDeCobrancaId = :AV76Boletowwds_1_carteiradecobrancaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Boletowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( BoletosNossoNumero like '%' || :lV77Boletowwds_2_filterfulltext) or ( BoletosSeuNumero like '%' || :lV77Boletowwds_2_filterfulltext) or ( BoletosNumero like '%' || :lV77Boletowwds_2_filterfulltext) or ( 'rascunho' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosStatus = ( 'RASCUNHO')) or ( 'registrado' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosStatus = ( 'REGISTRADO')) or ( 'liquidado' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosStatus = ( 'LIQUIDADO')) or ( 'baixado' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosStatus = ( 'BAIXADO')) or ( 'vencido' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosStatus = ( 'VENCIDO')) or ( 'erro' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosStatus = ( 'ERRO')) or ( SUBSTR(TO_CHAR(BoletosValorNominal,'999999999999990.99'), 2) like '%' || :lV77Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorPago,'999999999999990.99'), 2) like '%' || :lV77Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorDesconto,'999999999999990.99'), 2) like '%' || :lV77Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorJuros,'999999999999990.99'), 2) like '%' || :lV77Boletowwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(BoletosValorMulta,'999999999999990.99'), 2) like '%' || :lV77Boletowwds_2_filterfulltext) or ( BoletosSacadoNome like '%' || :lV77Boletowwds_2_filterfulltext) or ( BoletosSacadoDocumento like '%' || :lV77Boletowwds_2_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV77Boletowwds_2_filterfulltext) and BoletosSacadoTipoDocumento = ( 'CNPJ')))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
            GXv_int4[9] = 1;
            GXv_int4[10] = 1;
            GXv_int4[11] = 1;
            GXv_int4[12] = 1;
            GXv_int4[13] = 1;
            GXv_int4[14] = 1;
            GXv_int4[15] = 1;
            GXv_int4[16] = 1;
            GXv_int4[17] = 1;
            GXv_int4[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Boletowwds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV79Boletowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Boletowwds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV80Boletowwds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Boletowwds_3_dynamicfiltersselector1, "BOLETOSNOSSONUMERO") == 0 ) && ( AV79Boletowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Boletowwds_5_boletosnossonumero1)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV80Boletowwds_5_boletosnossonumero1)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( AV81Boletowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Boletowwds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV83Boletowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Boletowwds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV84Boletowwds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( AV81Boletowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Boletowwds_7_dynamicfiltersselector2, "BOLETOSNOSSONUMERO") == 0 ) && ( AV83Boletowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Boletowwds_9_boletosnossonumero2)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV84Boletowwds_9_boletosnossonumero2)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( AV85Boletowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Boletowwds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV87Boletowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Boletowwds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV88Boletowwds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( AV85Boletowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Boletowwds_11_dynamicfiltersselector3, "BOLETOSNOSSONUMERO") == 0 ) && ( AV87Boletowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Boletowwds_13_boletosnossonumero3)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like '%' || :lV88Boletowwds_13_boletosnossonumero3)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Boletowwds_15_tfboletosnossonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Boletowwds_14_tfboletosnossonumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero like :lV89Boletowwds_14_tfboletosnossonumero)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Boletowwds_15_tfboletosnossonumero_sel)) && ! ( StringUtil.StrCmp(AV90Boletowwds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero = ( :AV90Boletowwds_15_tfboletosnossonumero_sel))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV90Boletowwds_15_tfboletosnossonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNossoNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNossoNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Boletowwds_17_tfboletosseunumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Boletowwds_16_tfboletosseunumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero like :lV91Boletowwds_16_tfboletosseunumero)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Boletowwds_17_tfboletosseunumero_sel)) && ! ( StringUtil.StrCmp(AV92Boletowwds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero = ( :AV92Boletowwds_17_tfboletosseunumero_sel))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV92Boletowwds_17_tfboletosseunumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSeuNumero IS NULL or (char_length(trim(trailing ' ' from BoletosSeuNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Boletowwds_19_tfboletosnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Boletowwds_18_tfboletosnumero)) ) )
         {
            AddWhere(sWhereString, "(BoletosNumero like :lV93Boletowwds_18_tfboletosnumero)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Boletowwds_19_tfboletosnumero_sel)) && ! ( StringUtil.StrCmp(AV94Boletowwds_19_tfboletosnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosNumero = ( :AV94Boletowwds_19_tfboletosnumero_sel))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( StringUtil.StrCmp(AV94Boletowwds_19_tfboletosnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosNumero IS NULL or (char_length(trim(trailing ' ' from BoletosNumero))=0))");
         }
         if ( AV95Boletowwds_20_tfboletosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV95Boletowwds_20_tfboletosstatus_sels, "BoletosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV96Boletowwds_21_tfboletosdataemissao) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao >= :AV96Boletowwds_21_tfboletosdataemissao)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV97Boletowwds_22_tfboletosdataemissao_to) )
         {
            AddWhere(sWhereString, "(BoletosDataEmissao <= :AV97Boletowwds_22_tfboletosdataemissao_to)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Boletowwds_23_tfboletosdatavencimento) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento >= :AV98Boletowwds_23_tfboletosdatavencimento)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV99Boletowwds_24_tfboletosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataVencimento <= :AV99Boletowwds_24_tfboletosdatavencimento_to)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Boletowwds_25_tfboletosdataregistro) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro >= :AV100Boletowwds_25_tfboletosdataregistro)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV101Boletowwds_26_tfboletosdataregistro_to) )
         {
            AddWhere(sWhereString, "(BoletosDataRegistro <= :AV101Boletowwds_26_tfboletosdataregistro_to)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Boletowwds_27_tfboletosdatapagamento) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento >= :AV102Boletowwds_27_tfboletosdatapagamento)");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Boletowwds_28_tfboletosdatapagamento_to) )
         {
            AddWhere(sWhereString, "(BoletosDataPagamento <= :AV103Boletowwds_28_tfboletosdatapagamento_to)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Boletowwds_29_tfboletosdatabaixa) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa >= :AV104Boletowwds_29_tfboletosdatabaixa)");
         }
         else
         {
            GXv_int4[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Boletowwds_30_tfboletosdatabaixa_to) )
         {
            AddWhere(sWhereString, "(BoletosDataBaixa <= :AV105Boletowwds_30_tfboletosdatabaixa_to)");
         }
         else
         {
            GXv_int4[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV106Boletowwds_31_tfboletosvalornominal) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal >= :AV106Boletowwds_31_tfboletosvalornominal)");
         }
         else
         {
            GXv_int4[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV107Boletowwds_32_tfboletosvalornominal_to) )
         {
            AddWhere(sWhereString, "(BoletosValorNominal <= :AV107Boletowwds_32_tfboletosvalornominal_to)");
         }
         else
         {
            GXv_int4[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV108Boletowwds_33_tfboletosvalorpago) )
         {
            AddWhere(sWhereString, "(BoletosValorPago >= :AV108Boletowwds_33_tfboletosvalorpago)");
         }
         else
         {
            GXv_int4[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV109Boletowwds_34_tfboletosvalorpago_to) )
         {
            AddWhere(sWhereString, "(BoletosValorPago <= :AV109Boletowwds_34_tfboletosvalorpago_to)");
         }
         else
         {
            GXv_int4[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV110Boletowwds_35_tfboletosvalordesconto) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto >= :AV110Boletowwds_35_tfboletosvalordesconto)");
         }
         else
         {
            GXv_int4[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV111Boletowwds_36_tfboletosvalordesconto_to) )
         {
            AddWhere(sWhereString, "(BoletosValorDesconto <= :AV111Boletowwds_36_tfboletosvalordesconto_to)");
         }
         else
         {
            GXv_int4[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Boletowwds_37_tfboletosvalorjuros) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros >= :AV112Boletowwds_37_tfboletosvalorjuros)");
         }
         else
         {
            GXv_int4[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV113Boletowwds_38_tfboletosvalorjuros_to) )
         {
            AddWhere(sWhereString, "(BoletosValorJuros <= :AV113Boletowwds_38_tfboletosvalorjuros_to)");
         }
         else
         {
            GXv_int4[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV114Boletowwds_39_tfboletosvalormulta) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta >= :AV114Boletowwds_39_tfboletosvalormulta)");
         }
         else
         {
            GXv_int4[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Boletowwds_40_tfboletosvalormulta_to) )
         {
            AddWhere(sWhereString, "(BoletosValorMulta <= :AV115Boletowwds_40_tfboletosvalormulta_to)");
         }
         else
         {
            GXv_int4[50] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Boletowwds_42_tfboletossacadonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Boletowwds_41_tfboletossacadonome)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome like :lV116Boletowwds_41_tfboletossacadonome)");
         }
         else
         {
            GXv_int4[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Boletowwds_42_tfboletossacadonome_sel)) && ! ( StringUtil.StrCmp(AV117Boletowwds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome = ( :AV117Boletowwds_42_tfboletossacadonome_sel))");
         }
         else
         {
            GXv_int4[52] = 1;
         }
         if ( StringUtil.StrCmp(AV117Boletowwds_42_tfboletossacadonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoNome IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Boletowwds_44_tfboletossacadodocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Boletowwds_43_tfboletossacadodocumento)) ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento like :lV118Boletowwds_43_tfboletossacadodocumento)");
         }
         else
         {
            GXv_int4[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Boletowwds_44_tfboletossacadodocumento_sel)) && ! ( StringUtil.StrCmp(AV119Boletowwds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento = ( :AV119Boletowwds_44_tfboletossacadodocumento_sel))");
         }
         else
         {
            GXv_int4[54] = 1;
         }
         if ( StringUtil.StrCmp(AV119Boletowwds_44_tfboletossacadodocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BoletosSacadoDocumento IS NULL or (char_length(trim(trailing ' ' from BoletosSacadoDocumento))=0))");
         }
         if ( AV120Boletowwds_45_tfboletossacadotipodocumento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV120Boletowwds_45_tfboletossacadotipodocumento_sels, "BoletosSacadoTipoDocumento IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosNossoNumero";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosNossoNumero DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSeuNumero";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSeuNumero DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosNumero";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosNumero DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosStatus";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosStatus DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosDataEmissao";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataEmissao DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosDataVencimento";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataVencimento DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosDataRegistro";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataRegistro DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosDataPagamento";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataPagamento DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosDataBaixa";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosDataBaixa DESC";
         }
         else if ( ( AV16OrderedBy == 10 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosValorNominal";
         }
         else if ( ( AV16OrderedBy == 10 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorNominal DESC";
         }
         else if ( ( AV16OrderedBy == 11 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosValorPago";
         }
         else if ( ( AV16OrderedBy == 11 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorPago DESC";
         }
         else if ( ( AV16OrderedBy == 12 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosValorDesconto";
         }
         else if ( ( AV16OrderedBy == 12 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorDesconto DESC";
         }
         else if ( ( AV16OrderedBy == 13 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosValorJuros";
         }
         else if ( ( AV16OrderedBy == 13 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorJuros DESC";
         }
         else if ( ( AV16OrderedBy == 14 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosValorMulta";
         }
         else if ( ( AV16OrderedBy == 14 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosValorMulta DESC";
         }
         else if ( ( AV16OrderedBy == 15 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoNome";
         }
         else if ( ( AV16OrderedBy == 15 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSacadoNome DESC";
         }
         else if ( ( AV16OrderedBy == 16 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoDocumento";
         }
         else if ( ( AV16OrderedBy == 16 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSacadoDocumento DESC";
         }
         else if ( ( AV16OrderedBy == 17 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId, BoletosSacadoTipoDocumento";
         }
         else if ( ( AV16OrderedBy == 17 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaId DESC, BoletosSacadoTipoDocumento DESC";
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
                     return conditional_P00FN2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (DateTime)dynConstraints[60] , (DateTime)dynConstraints[61] , (DateTime)dynConstraints[62] , (short)dynConstraints[63] , (bool)dynConstraints[64] , (int)dynConstraints[65] , (int)dynConstraints[66] );
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
          Object[] prmP00FN2;
          prmP00FN2 = new Object[] {
          new ParDef("AV76Boletowwds_1_carteiradecobrancaid",GXType.Int32,9,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Boletowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV80Boletowwds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV80Boletowwds_5_boletosnossonumero1",GXType.VarChar,50,0) ,
          new ParDef("lV84Boletowwds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV84Boletowwds_9_boletosnossonumero2",GXType.VarChar,50,0) ,
          new ParDef("lV88Boletowwds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV88Boletowwds_13_boletosnossonumero3",GXType.VarChar,50,0) ,
          new ParDef("lV89Boletowwds_14_tfboletosnossonumero",GXType.VarChar,50,0) ,
          new ParDef("AV90Boletowwds_15_tfboletosnossonumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV91Boletowwds_16_tfboletosseunumero",GXType.VarChar,50,0) ,
          new ParDef("AV92Boletowwds_17_tfboletosseunumero_sel",GXType.VarChar,50,0) ,
          new ParDef("lV93Boletowwds_18_tfboletosnumero",GXType.VarChar,50,0) ,
          new ParDef("AV94Boletowwds_19_tfboletosnumero_sel",GXType.VarChar,50,0) ,
          new ParDef("AV96Boletowwds_21_tfboletosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV97Boletowwds_22_tfboletosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV98Boletowwds_23_tfboletosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV99Boletowwds_24_tfboletosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV100Boletowwds_25_tfboletosdataregistro",GXType.DateTime,8,5) ,
          new ParDef("AV101Boletowwds_26_tfboletosdataregistro_to",GXType.DateTime,8,5) ,
          new ParDef("AV102Boletowwds_27_tfboletosdatapagamento",GXType.Date,8,0) ,
          new ParDef("AV103Boletowwds_28_tfboletosdatapagamento_to",GXType.Date,8,0) ,
          new ParDef("AV104Boletowwds_29_tfboletosdatabaixa",GXType.Date,8,0) ,
          new ParDef("AV105Boletowwds_30_tfboletosdatabaixa_to",GXType.Date,8,0) ,
          new ParDef("AV106Boletowwds_31_tfboletosvalornominal",GXType.Number,18,2) ,
          new ParDef("AV107Boletowwds_32_tfboletosvalornominal_to",GXType.Number,18,2) ,
          new ParDef("AV108Boletowwds_33_tfboletosvalorpago",GXType.Number,18,2) ,
          new ParDef("AV109Boletowwds_34_tfboletosvalorpago_to",GXType.Number,18,2) ,
          new ParDef("AV110Boletowwds_35_tfboletosvalordesconto",GXType.Number,18,2) ,
          new ParDef("AV111Boletowwds_36_tfboletosvalordesconto_to",GXType.Number,18,2) ,
          new ParDef("AV112Boletowwds_37_tfboletosvalorjuros",GXType.Number,18,2) ,
          new ParDef("AV113Boletowwds_38_tfboletosvalorjuros_to",GXType.Number,18,2) ,
          new ParDef("AV114Boletowwds_39_tfboletosvalormulta",GXType.Number,18,2) ,
          new ParDef("AV115Boletowwds_40_tfboletosvalormulta_to",GXType.Number,18,2) ,
          new ParDef("lV116Boletowwds_41_tfboletossacadonome",GXType.VarChar,100,0) ,
          new ParDef("AV117Boletowwds_42_tfboletossacadonome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV118Boletowwds_43_tfboletossacadodocumento",GXType.VarChar,20,0) ,
          new ParDef("AV119Boletowwds_44_tfboletossacadodocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FN2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((int[]) buf[34])[0] = rslt.getInt(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                return;
       }
    }

 }

}
