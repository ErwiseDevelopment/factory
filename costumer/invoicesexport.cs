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
namespace GeneXus.Programs.costumer {
   public class invoicesexport : GXProcedure
   {
      public invoicesexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public invoicesexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "invoicesExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
            {
               AV20NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV20NotaFiscalUF1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fiscal UF";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! (0==AV20NotaFiscalUF1) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmufcod.getDescription(context,AV20NotaFiscalUF1);
                  }
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
               {
                  AV23NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV23NotaFiscalUF2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fiscal UF";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! (0==AV23NotaFiscalUF2) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmufcod.getDescription(context,AV23NotaFiscalUF2);
                     }
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
                  {
                     AV26NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV26NotaFiscalUF3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fiscal UF";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! (0==AV26NotaFiscalUF3) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmufcod.getDescription(context,AV26NotaFiscalUF3);
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) ? "(Vazio)" : AV33TFNotaFiscalNumero_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32TFNotaFiscalNumero, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Itens") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) ? "(Vazio)" : AV35TFNotaFiscalQuantidadeResumo_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFNotaFiscalQuantidadeResumo_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Itens") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFNotaFiscalQuantidadeResumo_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) ? "(Vazio)" : AV37TFNotaFiscalValorFormatado_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFNotaFiscalValorFormatado_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFNotaFiscalValorFormatado_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendido") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) ? "(Vazio)" : AV39TFNotaFiscalValorVendidoFormatado_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalValorVendidoFormatado_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendido") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFNotaFiscalValorVendidoFormatado_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Saldo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) ? "(Vazio)" : AV41TFNotaFiscalSaldoFormatado_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalSaldoFormatado_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Saldo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFNotaFiscalSaldoFormatado_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV44TFNotaFiscalStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV45i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV44TFNotaFiscalStatus_Sels.Count )
            {
               AV43TFNotaFiscalStatus_Sel = ((string)AV44TFNotaFiscalStatus_Sels.Item(AV46GXV1));
               if ( AV45i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusnotaimportada.getDescription(context,AV43TFNotaFiscalStatus_Sel);
               AV45i = (long)(AV45i+1);
               AV46GXV1 = (int)(AV46GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Número";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Itens";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Vendido";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Saldo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV44TFNotaFiscalStatus_Sels ,
                                              AV19DynamicFiltersSelector1 ,
                                              AV20NotaFiscalUF1 ,
                                              AV21DynamicFiltersEnabled2 ,
                                              AV22DynamicFiltersSelector2 ,
                                              AV23NotaFiscalUF2 ,
                                              AV24DynamicFiltersEnabled3 ,
                                              AV25DynamicFiltersSelector3 ,
                                              AV26NotaFiscalUF3 ,
                                              AV33TFNotaFiscalNumero_Sel ,
                                              AV32TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV18FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV34TFNotaFiscalQuantidadeResumo_F ,
                                              AV37TFNotaFiscalValorFormatado_F_Sel ,
                                              AV36TFNotaFiscalValorFormatado_F ,
                                              AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV38TFNotaFiscalValorVendidoFormatado_F ,
                                              AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV40TFNotaFiscalSaldoFormatado_F ,
                                              AV44TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV32TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV32TFNotaFiscalNumero), "%", "");
         /* Using cursor P00DM7 */
         pr_default.execute(0, new Object[] {AV44TFNotaFiscalStatus_Sels.Count, AV20NotaFiscalUF1, AV23NotaFiscalUF2, AV26NotaFiscalUF3, lV32TFNotaFiscalNumero, AV33TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A794NotaFiscalId = P00DM7_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DM7_n794NotaFiscalId[0];
            A795NotaFiscalUF = P00DM7_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DM7_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DM7_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DM7_n799NotaFiscalNumero[0];
            A880NotaFiscalStatus = P00DM7_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DM7_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DM7_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DM7_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DM7_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DM7_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DM7_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = P00DM7_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = P00DM7_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DM7_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DM7_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DM7_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = P00DM7_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DM7_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DM7_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DM7_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV34TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV35TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV35TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV35TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV36TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV37TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV37TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV37TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV40TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV41TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV41TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV41TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV38TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV39TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV39TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV39TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
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
                                                   new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A799NotaFiscalNumero, out  GXt_char1) ;
                                                   AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
                                                   GXt_char1 = "";
                                                   new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A879NotaFiscalQuantidadeResumo_F, out  GXt_char1) ;
                                                   AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                                                   GXt_char1 = "";
                                                   new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A881NotaFiscalValorFormatado_F, out  GXt_char1) ;
                                                   AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
                                                   GXt_char1 = "";
                                                   new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A882NotaFiscalValorVendidoFormatado_F, out  GXt_char1) ;
                                                   AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
                                                   GXt_char1 = "";
                                                   new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A883NotaFiscalSaldoFormatado_F, out  GXt_char1) ;
                                                   AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
                                                   AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = gxdomaindmstatusnotaimportada.getDescription(context,A880NotaFiscalStatus);
                                                   if ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 )
                                                   {
                                                      AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 128, 128, 128);
                                                   }
                                                   else if ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 )
                                                   {
                                                      AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
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
                                    }
                                 }
                              }
                           }
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
         AV28Session.Set("WWPExportFilePath", AV11Filename);
         AV28Session.Set("WWPExportFileName", "invoicesExport.xlsx");
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
         if ( StringUtil.StrCmp(AV28Session.Get("Costumer.invoicesGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Costumer.invoicesGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("Costumer.invoicesGridState"), null, "", "");
         }
         AV16OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV48GXV2 = 1;
         while ( AV48GXV2 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV48GXV2));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV32TFNotaFiscalNumero = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV33TFNotaFiscalNumero_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALQUANTIDADERESUMO_F") == 0 )
            {
               AV34TFNotaFiscalQuantidadeResumo_F = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALQUANTIDADERESUMO_F_SEL") == 0 )
            {
               AV35TFNotaFiscalQuantidadeResumo_F_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORFORMATADO_F") == 0 )
            {
               AV36TFNotaFiscalValorFormatado_F = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORFORMATADO_F_SEL") == 0 )
            {
               AV37TFNotaFiscalValorFormatado_F_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORVENDIDOFORMATADO_F") == 0 )
            {
               AV38TFNotaFiscalValorVendidoFormatado_F = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL") == 0 )
            {
               AV39TFNotaFiscalValorVendidoFormatado_F_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSALDOFORMATADO_F") == 0 )
            {
               AV40TFNotaFiscalSaldoFormatado_F = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSALDOFORMATADO_F_SEL") == 0 )
            {
               AV41TFNotaFiscalSaldoFormatado_F_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSTATUS_SEL") == 0 )
            {
               AV42TFNotaFiscalStatus_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV44TFNotaFiscalStatus_Sels.FromJSonString(AV42TFNotaFiscalStatus_SelsJson, null);
            }
            AV48GXV2 = (int)(AV48GXV2+1);
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
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV33TFNotaFiscalNumero_Sel = "";
         AV32TFNotaFiscalNumero = "";
         AV35TFNotaFiscalQuantidadeResumo_F_Sel = "";
         AV34TFNotaFiscalQuantidadeResumo_F = "";
         AV37TFNotaFiscalValorFormatado_F_Sel = "";
         AV36TFNotaFiscalValorFormatado_F = "";
         AV39TFNotaFiscalValorVendidoFormatado_F_Sel = "";
         AV38TFNotaFiscalValorVendidoFormatado_F = "";
         AV41TFNotaFiscalSaldoFormatado_F_Sel = "";
         AV40TFNotaFiscalSaldoFormatado_F = "";
         AV44TFNotaFiscalStatus_Sels = new GxSimpleCollection<string>();
         AV43TFNotaFiscalStatus_Sel = "";
         lV18FilterFullText = "";
         lV32TFNotaFiscalNumero = "";
         A880NotaFiscalStatus = "";
         A799NotaFiscalNumero = "";
         A879NotaFiscalQuantidadeResumo_F = "";
         A881NotaFiscalValorFormatado_F = "";
         A882NotaFiscalValorVendidoFormatado_F = "";
         A883NotaFiscalSaldoFormatado_F = "";
         P00DM7_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DM7_n794NotaFiscalId = new bool[] {false} ;
         P00DM7_A795NotaFiscalUF = new short[1] ;
         P00DM7_n795NotaFiscalUF = new bool[] {false} ;
         P00DM7_A799NotaFiscalNumero = new string[] {""} ;
         P00DM7_n799NotaFiscalNumero = new bool[] {false} ;
         P00DM7_A880NotaFiscalStatus = new string[] {""} ;
         P00DM7_n880NotaFiscalStatus = new bool[] {false} ;
         P00DM7_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         P00DM7_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         P00DM7_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         P00DM7_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         P00DM7_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         P00DM7_A874NotaFiscalValorTotal_F = new decimal[1] ;
         A794NotaFiscalId = Guid.Empty;
         GXt_char1 = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42TFNotaFiscalStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.invoicesexport__default(),
            new Object[][] {
                new Object[] {
               P00DM7_A794NotaFiscalId, P00DM7_A795NotaFiscalUF, P00DM7_n795NotaFiscalUF, P00DM7_A799NotaFiscalNumero, P00DM7_n799NotaFiscalNumero, P00DM7_A880NotaFiscalStatus, P00DM7_n880NotaFiscalStatus, P00DM7_A877NotaFiscalQuantidadeDeItens_F, P00DM7_n877NotaFiscalQuantidadeDeItens_F, P00DM7_A878NotaFiscalQuantidadeDeItensVendidos_F,
               P00DM7_n878NotaFiscalQuantidadeDeItensVendidos_F, P00DM7_A875NotaFiscalValorTotalVendido_F, P00DM7_A874NotaFiscalValorTotal_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20NotaFiscalUF1 ;
      private short AV23NotaFiscalUF2 ;
      private short AV26NotaFiscalUF3 ;
      private short GXt_int2 ;
      private short A795NotaFiscalUF ;
      private short AV16OrderedBy ;
      private short A877NotaFiscalQuantidadeDeItens_F ;
      private short A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV46GXV1 ;
      private int AV44TFNotaFiscalStatus_Sels_Count ;
      private int AV48GXV2 ;
      private long AV45i ;
      private decimal A875NotaFiscalValorTotalVendido_F ;
      private decimal A874NotaFiscalValorTotal_F ;
      private decimal A876NotaFiscalSaldo_F ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV17OrderedDsc ;
      private bool n794NotaFiscalId ;
      private bool n795NotaFiscalUF ;
      private bool n799NotaFiscalNumero ;
      private bool n880NotaFiscalStatus ;
      private bool n877NotaFiscalQuantidadeDeItens_F ;
      private bool n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private string AV42TFNotaFiscalStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV33TFNotaFiscalNumero_Sel ;
      private string AV32TFNotaFiscalNumero ;
      private string AV35TFNotaFiscalQuantidadeResumo_F_Sel ;
      private string AV34TFNotaFiscalQuantidadeResumo_F ;
      private string AV37TFNotaFiscalValorFormatado_F_Sel ;
      private string AV36TFNotaFiscalValorFormatado_F ;
      private string AV39TFNotaFiscalValorVendidoFormatado_F_Sel ;
      private string AV38TFNotaFiscalValorVendidoFormatado_F ;
      private string AV41TFNotaFiscalSaldoFormatado_F_Sel ;
      private string AV40TFNotaFiscalSaldoFormatado_F ;
      private string AV43TFNotaFiscalStatus_Sel ;
      private string lV18FilterFullText ;
      private string lV32TFNotaFiscalNumero ;
      private string A880NotaFiscalStatus ;
      private string A799NotaFiscalNumero ;
      private string A879NotaFiscalQuantidadeResumo_F ;
      private string A881NotaFiscalValorFormatado_F ;
      private string A882NotaFiscalValorVendidoFormatado_F ;
      private string A883NotaFiscalSaldoFormatado_F ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV28Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV44TFNotaFiscalStatus_Sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DM7_A794NotaFiscalId ;
      private bool[] P00DM7_n794NotaFiscalId ;
      private short[] P00DM7_A795NotaFiscalUF ;
      private bool[] P00DM7_n795NotaFiscalUF ;
      private string[] P00DM7_A799NotaFiscalNumero ;
      private bool[] P00DM7_n799NotaFiscalNumero ;
      private string[] P00DM7_A880NotaFiscalStatus ;
      private bool[] P00DM7_n880NotaFiscalStatus ;
      private short[] P00DM7_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] P00DM7_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] P00DM7_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] P00DM7_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] P00DM7_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] P00DM7_A874NotaFiscalValorTotal_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class invoicesexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DM7( IGxContext context ,
                                             string A880NotaFiscalStatus ,
                                             GxSimpleCollection<string> AV44TFNotaFiscalStatus_Sels ,
                                             string AV19DynamicFiltersSelector1 ,
                                             short AV20NotaFiscalUF1 ,
                                             bool AV21DynamicFiltersEnabled2 ,
                                             string AV22DynamicFiltersSelector2 ,
                                             short AV23NotaFiscalUF2 ,
                                             bool AV24DynamicFiltersEnabled3 ,
                                             string AV25DynamicFiltersSelector3 ,
                                             short AV26NotaFiscalUF3 ,
                                             string AV33TFNotaFiscalNumero_Sel ,
                                             string AV32TFNotaFiscalNumero ,
                                             short A795NotaFiscalUF ,
                                             string A799NotaFiscalNumero ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV18FilterFullText ,
                                             string A879NotaFiscalQuantidadeResumo_F ,
                                             string A881NotaFiscalValorFormatado_F ,
                                             string A882NotaFiscalValorVendidoFormatado_F ,
                                             string A883NotaFiscalSaldoFormatado_F ,
                                             string AV35TFNotaFiscalQuantidadeResumo_F_Sel ,
                                             string AV34TFNotaFiscalQuantidadeResumo_F ,
                                             string AV37TFNotaFiscalValorFormatado_F_Sel ,
                                             string AV36TFNotaFiscalValorFormatado_F ,
                                             string AV39TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                             string AV38TFNotaFiscalValorVendidoFormatado_F ,
                                             string AV41TFNotaFiscalSaldoFormatado_F_Sel ,
                                             string AV40TFNotaFiscalSaldoFormatado_F ,
                                             int AV44TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.NotaFiscalUF, T1.NotaFiscalNumero, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV44TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV44TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV20NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV20NotaFiscalUF1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV21DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV23NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV23NotaFiscalUF2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV24DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV26NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV26NotaFiscalUF3)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV32TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV33TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV33TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV33TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalUF";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalNumero";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NotaFiscalNumero DESC";
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
                     return conditional_P00DM7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] );
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
          Object[] prmP00DM7;
          prmP00DM7 = new Object[] {
          new ParDef("AV44TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV20NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV23NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV26NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV32TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV33TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DM7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM7,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}
