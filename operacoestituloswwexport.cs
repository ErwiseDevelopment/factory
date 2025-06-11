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
   public class operacoestituloswwexport : GXProcedure
   {
      public operacoestituloswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoestituloswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "OperacoesTitulosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "OPERACOESTITULOSTIPO") == 0 )
            {
               AV20OperacoesTitulosTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20OperacoesTitulosTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20OperacoesTitulosTipo1)) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmoperacoestipotitulo.getDescription(context,AV20OperacoesTitulosTipo1);
                  }
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "OPERACOESTITULOSTIPO") == 0 )
               {
                  AV23OperacoesTitulosTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23OperacoesTitulosTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23OperacoesTitulosTipo2)) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmoperacoestipotitulo.getDescription(context,AV23OperacoesTitulosTipo2);
                     }
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "OPERACOESTITULOSTIPO") == 0 )
                  {
                     AV26OperacoesTitulosTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26OperacoesTitulosTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26OperacoesTitulosTipo3)) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmoperacoestipotitulo.getDescription(context,AV26OperacoesTitulosTipo3);
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFSacadoRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sacado") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFSacadoRazaoSocial_Sel)) ? "(Vazio)" : AV58TFSacadoRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFSacadoRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sacado") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFSacadoRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV34TFOperacoesTitulosTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV54i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV34TFOperacoesTitulosTipo_Sels.Count )
            {
               AV33TFOperacoesTitulosTipo_Sel = ((string)AV34TFOperacoesTitulosTipo_Sels.Item(AV59GXV1));
               if ( AV54i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmoperacoestipotitulo.getDescription(context,AV33TFOperacoesTitulosTipo_Sel);
               AV54i = (long)(AV54i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
         }
         if ( ! ( (0==AV35TFOperacoesTitulosNumero) && (0==AV36TFOperacoesTitulosNumero_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número nota") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV35TFOperacoesTitulosNumero;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV36TFOperacoesTitulosNumero_To;
         }
         if ( ! ( (DateTime.MinValue==AV37TFOperacoesTitulosDataEmissao) && (DateTime.MinValue==AV38TFOperacoesTitulosDataEmissao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Emissão") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV37TFOperacoesTitulosDataEmissao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV38TFOperacoesTitulosDataEmissao_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV39TFOperacoesTitulosDataVencimento) && (DateTime.MinValue==AV40TFOperacoesTitulosDataVencimento_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vencimento") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39TFOperacoesTitulosDataVencimento ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40TFOperacoesTitulosDataVencimento_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFOperacoesTitulosValor) && (Convert.ToDecimal(0)==AV42TFOperacoesTitulosValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV41TFOperacoesTitulosValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV42TFOperacoesTitulosValor_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV43TFOperacoesTitulosLiquido) && (Convert.ToDecimal(0)==AV44TFOperacoesTitulosLiquido_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Líquido") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV43TFOperacoesTitulosLiquido);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV44TFOperacoesTitulosLiquido_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFOperacoesTitulosTaxa) && (Convert.ToDecimal(0)==AV46TFOperacoesTitulosTaxa_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Taxa") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV45TFOperacoesTitulosTaxa);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV46TFOperacoesTitulosTaxa_To);
         }
         if ( ! ( ( AV49TFOperacoesTitulosStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV54i = 1;
            AV60GXV2 = 1;
            while ( AV60GXV2 <= AV49TFOperacoesTitulosStatus_Sels.Count )
            {
               AV48TFOperacoesTitulosStatus_Sel = ((string)AV49TFOperacoesTitulosStatus_Sels.Item(AV60GXV2));
               if ( AV54i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatustitulo.getDescription(context,AV48TFOperacoesTitulosStatus_Sel);
               AV54i = (long)(AV54i+1);
               AV60GXV2 = (int)(AV60GXV2+1);
            }
         }
         if ( ! ( (DateTime.MinValue==AV50TFOperacoesTitulosCreatedAt) && (DateTime.MinValue==AV51TFOperacoesTitulosCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV50TFOperacoesTitulosCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV51TFOperacoesTitulosCreatedAt_To;
         }
         if ( ! ( (DateTime.MinValue==AV52TFOperacoesTitulosUpdatedAt) && (DateTime.MinValue==AV53TFOperacoesTitulosUpdatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV52TFOperacoesTitulosUpdatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV53TFOperacoesTitulosUpdatedAt_To;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Número nota";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Emissão";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Vencimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Líquido";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Taxa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Criado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Atualizado em";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Operacoestituloswwds_1_operacoesid = AV55OperacoesId;
         AV63Operacoestituloswwds_2_filterfulltext = AV18FilterFullText;
         AV64Operacoestituloswwds_3_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Operacoestituloswwds_4_operacoestitulostipo1 = AV20OperacoesTitulosTipo1;
         AV66Operacoestituloswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV67Operacoestituloswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV68Operacoestituloswwds_7_operacoestitulostipo2 = AV23OperacoesTitulosTipo2;
         AV69Operacoestituloswwds_8_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV70Operacoestituloswwds_9_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV71Operacoestituloswwds_10_operacoestitulostipo3 = AV26OperacoesTitulosTipo3;
         AV72Operacoestituloswwds_11_tfsacadorazaosocial = AV57TFSacadoRazaoSocial;
         AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel = AV58TFSacadoRazaoSocial_Sel;
         AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels = AV34TFOperacoesTitulosTipo_Sels;
         AV75Operacoestituloswwds_14_tfoperacoestitulosnumero = AV35TFOperacoesTitulosNumero;
         AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to = AV36TFOperacoesTitulosNumero_To;
         AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao = AV37TFOperacoesTitulosDataEmissao;
         AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = AV38TFOperacoesTitulosDataEmissao_To;
         AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = AV39TFOperacoesTitulosDataVencimento;
         AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = AV40TFOperacoesTitulosDataVencimento_To;
         AV81Operacoestituloswwds_20_tfoperacoestitulosvalor = AV41TFOperacoesTitulosValor;
         AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to = AV42TFOperacoesTitulosValor_To;
         AV83Operacoestituloswwds_22_tfoperacoestitulosliquido = AV43TFOperacoesTitulosLiquido;
         AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to = AV44TFOperacoesTitulosLiquido_To;
         AV85Operacoestituloswwds_24_tfoperacoestitulostaxa = AV45TFOperacoesTitulosTaxa;
         AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to = AV46TFOperacoesTitulosTaxa_To;
         AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = AV49TFOperacoesTitulosStatus_Sels;
         AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat = AV50TFOperacoesTitulosCreatedAt;
         AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = AV51TFOperacoesTitulosCreatedAt_To;
         AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat = AV52TFOperacoesTitulosUpdatedAt;
         AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = AV53TFOperacoesTitulosUpdatedAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1020OperacoesTitulosTipo ,
                                              AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                              A1027OperacoesTitulosStatus ,
                                              AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                              AV63Operacoestituloswwds_2_filterfulltext ,
                                              AV64Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                              AV65Operacoestituloswwds_4_operacoestitulostipo1 ,
                                              AV66Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                              AV67Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                              AV68Operacoestituloswwds_7_operacoestitulostipo2 ,
                                              AV69Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                              AV70Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                              AV71Operacoestituloswwds_10_operacoestitulostipo3 ,
                                              AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                              AV72Operacoestituloswwds_11_tfsacadorazaosocial ,
                                              AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels.Count ,
                                              AV75Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                              AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                              AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                              AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                              AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                              AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                              AV81Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                              AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                              AV83Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                              AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                              AV85Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                              AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                              AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels.Count ,
                                              AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                              AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                              AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                              AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                              A1035SacadoRazaoSocial ,
                                              A1021OperacoesTitulosNumero ,
                                              A1024OperacoesTitulosValor ,
                                              A1025OperacoesTitulosLiquido ,
                                              A1026OperacoesTitulosTaxa ,
                                              A1022OperacoesTitulosDataEmissao ,
                                              A1023OperacoesTitulosDataVencimento ,
                                              A1028OperacoesTitulosCreatedAt ,
                                              A1029OperacoesTitulosUpdatedAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV62Operacoestituloswwds_1_operacoesid ,
                                              A1010OperacoesId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV63Operacoestituloswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext), "%", "");
         lV72Operacoestituloswwds_11_tfsacadorazaosocial = StringUtil.Concat( StringUtil.RTrim( AV72Operacoestituloswwds_11_tfsacadorazaosocial), "%", "");
         /* Using cursor P00F72 */
         pr_default.execute(0, new Object[] {AV62Operacoestituloswwds_1_operacoesid, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, lV63Operacoestituloswwds_2_filterfulltext, AV65Operacoestituloswwds_4_operacoestitulostipo1, AV68Operacoestituloswwds_7_operacoestitulostipo2, AV71Operacoestituloswwds_10_operacoestitulostipo3, lV72Operacoestituloswwds_11_tfsacadorazaosocial, AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel, AV75Operacoestituloswwds_14_tfoperacoestitulosnumero, AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to, AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao, AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to, AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento, AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to, AV81Operacoestituloswwds_20_tfoperacoestitulosvalor, AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to, AV83Operacoestituloswwds_22_tfoperacoestitulosliquido, AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to, AV85Operacoestituloswwds_24_tfoperacoestitulostaxa, AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to, AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat, AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to, AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat, AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1034SacadoId = P00F72_A1034SacadoId[0];
            n1034SacadoId = P00F72_n1034SacadoId[0];
            A1029OperacoesTitulosUpdatedAt = P00F72_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = P00F72_n1029OperacoesTitulosUpdatedAt[0];
            A1028OperacoesTitulosCreatedAt = P00F72_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = P00F72_n1028OperacoesTitulosCreatedAt[0];
            A1026OperacoesTitulosTaxa = P00F72_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = P00F72_n1026OperacoesTitulosTaxa[0];
            A1025OperacoesTitulosLiquido = P00F72_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = P00F72_n1025OperacoesTitulosLiquido[0];
            A1024OperacoesTitulosValor = P00F72_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = P00F72_n1024OperacoesTitulosValor[0];
            A1023OperacoesTitulosDataVencimento = P00F72_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = P00F72_n1023OperacoesTitulosDataVencimento[0];
            A1022OperacoesTitulosDataEmissao = P00F72_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = P00F72_n1022OperacoesTitulosDataEmissao[0];
            A1021OperacoesTitulosNumero = P00F72_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = P00F72_n1021OperacoesTitulosNumero[0];
            A1027OperacoesTitulosStatus = P00F72_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = P00F72_n1027OperacoesTitulosStatus[0];
            A1020OperacoesTitulosTipo = P00F72_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = P00F72_n1020OperacoesTitulosTipo[0];
            A1035SacadoRazaoSocial = P00F72_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = P00F72_n1035SacadoRazaoSocial[0];
            A1010OperacoesId = P00F72_A1010OperacoesId[0];
            n1010OperacoesId = P00F72_n1010OperacoesId[0];
            A1019OperacoesTitulosId = P00F72_A1019OperacoesTitulosId[0];
            A1035SacadoRazaoSocial = P00F72_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = P00F72_n1035SacadoRazaoSocial[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1035SacadoRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1020OperacoesTitulosTipo)) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmoperacoestipotitulo.getDescription(context,A1020OperacoesTitulosTipo);
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A1021OperacoesTitulosNumero;
            GXt_dtime3 = DateTimeUtil.ResetTime( A1022OperacoesTitulosDataEmissao ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( A1023OperacoesTitulosDataVencimento ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = GXt_dtime3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = (double)(A1024OperacoesTitulosValor);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Number = (double)(A1025OperacoesTitulosLiquido);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Number = (double)(A1026OperacoesTitulosTaxa);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = gxdomaindmstatustitulo.getDescription(context,A1027OperacoesTitulosStatus);
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Date = A1028OperacoesTitulosCreatedAt;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Date = A1029OperacoesTitulosUpdatedAt;
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
         AV28Session.Set("WWPExportFilePath", AV11Filename);
         AV28Session.Set("WWPExportFileName", "OperacoesTitulosWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV28Session.Get("OperacoesTitulosWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacoesTitulosWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("OperacoesTitulosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV92GXV3 = 1;
         while ( AV92GXV3 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV92GXV3));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSACADORAZAOSOCIAL") == 0 )
            {
               AV57TFSacadoRazaoSocial = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFSACADORAZAOSOCIAL_SEL") == 0 )
            {
               AV58TFSacadoRazaoSocial_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSTIPO_SEL") == 0 )
            {
               AV32TFOperacoesTitulosTipo_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV34TFOperacoesTitulosTipo_Sels.FromJSonString(AV32TFOperacoesTitulosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSNUMERO") == 0 )
            {
               AV35TFOperacoesTitulosNumero = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFOperacoesTitulosNumero_To = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSDATAEMISSAO") == 0 )
            {
               AV37TFOperacoesTitulosDataEmissao = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV38TFOperacoesTitulosDataEmissao_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSDATAVENCIMENTO") == 0 )
            {
               AV39TFOperacoesTitulosDataVencimento = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV40TFOperacoesTitulosDataVencimento_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSVALOR") == 0 )
            {
               AV41TFOperacoesTitulosValor = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV42TFOperacoesTitulosValor_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSLIQUIDO") == 0 )
            {
               AV43TFOperacoesTitulosLiquido = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV44TFOperacoesTitulosLiquido_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSTAXA") == 0 )
            {
               AV45TFOperacoesTitulosTaxa = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV46TFOperacoesTitulosTaxa_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSSTATUS_SEL") == 0 )
            {
               AV47TFOperacoesTitulosStatus_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV49TFOperacoesTitulosStatus_Sels.FromJSonString(AV47TFOperacoesTitulosStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSCREATEDAT") == 0 )
            {
               AV50TFOperacoesTitulosCreatedAt = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV51TFOperacoesTitulosCreatedAt_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFOPERACOESTITULOSUPDATEDAT") == 0 )
            {
               AV52TFOperacoesTitulosUpdatedAt = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV53TFOperacoesTitulosUpdatedAt_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&OPERACOESID") == 0 )
            {
               AV55OperacoesId = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&TRNMODE") == 0 )
            {
               AV56TrnMode = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV92GXV3 = (int)(AV92GXV3+1);
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
         AV20OperacoesTitulosTipo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV23OperacoesTitulosTipo2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV26OperacoesTitulosTipo3 = "";
         AV58TFSacadoRazaoSocial_Sel = "";
         AV57TFSacadoRazaoSocial = "";
         AV34TFOperacoesTitulosTipo_Sels = new GxSimpleCollection<string>();
         AV33TFOperacoesTitulosTipo_Sel = "";
         AV37TFOperacoesTitulosDataEmissao = DateTime.MinValue;
         AV38TFOperacoesTitulosDataEmissao_To = DateTime.MinValue;
         AV39TFOperacoesTitulosDataVencimento = DateTime.MinValue;
         AV40TFOperacoesTitulosDataVencimento_To = DateTime.MinValue;
         AV49TFOperacoesTitulosStatus_Sels = new GxSimpleCollection<string>();
         AV48TFOperacoesTitulosStatus_Sel = "";
         AV50TFOperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         AV51TFOperacoesTitulosCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV52TFOperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         AV53TFOperacoesTitulosUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV63Operacoestituloswwds_2_filterfulltext = "";
         AV64Operacoestituloswwds_3_dynamicfiltersselector1 = "";
         AV65Operacoestituloswwds_4_operacoestitulostipo1 = "";
         AV67Operacoestituloswwds_6_dynamicfiltersselector2 = "";
         AV68Operacoestituloswwds_7_operacoestitulostipo2 = "";
         AV70Operacoestituloswwds_9_dynamicfiltersselector3 = "";
         AV71Operacoestituloswwds_10_operacoestitulostipo3 = "";
         AV72Operacoestituloswwds_11_tfsacadorazaosocial = "";
         AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel = "";
         AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels = new GxSimpleCollection<string>();
         AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao = DateTime.MinValue;
         AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to = DateTime.MinValue;
         AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento = DateTime.MinValue;
         AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to = DateTime.MinValue;
         AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels = new GxSimpleCollection<string>();
         AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat = (DateTime)(DateTime.MinValue);
         AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to = (DateTime)(DateTime.MinValue);
         AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat = (DateTime)(DateTime.MinValue);
         AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to = (DateTime)(DateTime.MinValue);
         lV63Operacoestituloswwds_2_filterfulltext = "";
         lV72Operacoestituloswwds_11_tfsacadorazaosocial = "";
         A1020OperacoesTitulosTipo = "";
         A1027OperacoesTitulosStatus = "";
         A1035SacadoRazaoSocial = "";
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         P00F72_A1034SacadoId = new int[1] ;
         P00F72_n1034SacadoId = new bool[] {false} ;
         P00F72_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F72_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         P00F72_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F72_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         P00F72_A1026OperacoesTitulosTaxa = new decimal[1] ;
         P00F72_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         P00F72_A1025OperacoesTitulosLiquido = new decimal[1] ;
         P00F72_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         P00F72_A1024OperacoesTitulosValor = new decimal[1] ;
         P00F72_n1024OperacoesTitulosValor = new bool[] {false} ;
         P00F72_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         P00F72_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         P00F72_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         P00F72_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         P00F72_A1021OperacoesTitulosNumero = new int[1] ;
         P00F72_n1021OperacoesTitulosNumero = new bool[] {false} ;
         P00F72_A1027OperacoesTitulosStatus = new string[] {""} ;
         P00F72_n1027OperacoesTitulosStatus = new bool[] {false} ;
         P00F72_A1020OperacoesTitulosTipo = new string[] {""} ;
         P00F72_n1020OperacoesTitulosTipo = new bool[] {false} ;
         P00F72_A1035SacadoRazaoSocial = new string[] {""} ;
         P00F72_n1035SacadoRazaoSocial = new bool[] {false} ;
         P00F72_A1010OperacoesId = new int[1] ;
         P00F72_n1010OperacoesId = new bool[] {false} ;
         P00F72_A1019OperacoesTitulosId = new int[1] ;
         GXt_char1 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV32TFOperacoesTitulosTipo_SelsJson = "";
         AV47TFOperacoesTitulosStatus_SelsJson = "";
         AV56TrnMode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoestituloswwexport__default(),
            new Object[][] {
                new Object[] {
               P00F72_A1034SacadoId, P00F72_n1034SacadoId, P00F72_A1029OperacoesTitulosUpdatedAt, P00F72_n1029OperacoesTitulosUpdatedAt, P00F72_A1028OperacoesTitulosCreatedAt, P00F72_n1028OperacoesTitulosCreatedAt, P00F72_A1026OperacoesTitulosTaxa, P00F72_n1026OperacoesTitulosTaxa, P00F72_A1025OperacoesTitulosLiquido, P00F72_n1025OperacoesTitulosLiquido,
               P00F72_A1024OperacoesTitulosValor, P00F72_n1024OperacoesTitulosValor, P00F72_A1023OperacoesTitulosDataVencimento, P00F72_n1023OperacoesTitulosDataVencimento, P00F72_A1022OperacoesTitulosDataEmissao, P00F72_n1022OperacoesTitulosDataEmissao, P00F72_A1021OperacoesTitulosNumero, P00F72_n1021OperacoesTitulosNumero, P00F72_A1027OperacoesTitulosStatus, P00F72_n1027OperacoesTitulosStatus,
               P00F72_A1020OperacoesTitulosTipo, P00F72_n1020OperacoesTitulosTipo, P00F72_A1035SacadoRazaoSocial, P00F72_n1035SacadoRazaoSocial, P00F72_A1010OperacoesId, P00F72_n1010OperacoesId, P00F72_A1019OperacoesTitulosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV59GXV1 ;
      private int AV35TFOperacoesTitulosNumero ;
      private int AV36TFOperacoesTitulosNumero_To ;
      private int AV60GXV2 ;
      private int AV62Operacoestituloswwds_1_operacoesid ;
      private int AV55OperacoesId ;
      private int AV75Operacoestituloswwds_14_tfoperacoestitulosnumero ;
      private int AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to ;
      private int AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ;
      private int AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ;
      private int A1021OperacoesTitulosNumero ;
      private int A1010OperacoesId ;
      private int A1034SacadoId ;
      private int A1019OperacoesTitulosId ;
      private int AV92GXV3 ;
      private long AV54i ;
      private decimal AV41TFOperacoesTitulosValor ;
      private decimal AV42TFOperacoesTitulosValor_To ;
      private decimal AV43TFOperacoesTitulosLiquido ;
      private decimal AV44TFOperacoesTitulosLiquido_To ;
      private decimal AV45TFOperacoesTitulosTaxa ;
      private decimal AV46TFOperacoesTitulosTaxa_To ;
      private decimal AV81Operacoestituloswwds_20_tfoperacoestitulosvalor ;
      private decimal AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to ;
      private decimal AV83Operacoestituloswwds_22_tfoperacoestitulosliquido ;
      private decimal AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to ;
      private decimal AV85Operacoestituloswwds_24_tfoperacoestitulostaxa ;
      private decimal AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to ;
      private decimal A1024OperacoesTitulosValor ;
      private decimal A1025OperacoesTitulosLiquido ;
      private decimal A1026OperacoesTitulosTaxa ;
      private string GXt_char1 ;
      private string AV56TrnMode ;
      private DateTime AV50TFOperacoesTitulosCreatedAt ;
      private DateTime AV51TFOperacoesTitulosCreatedAt_To ;
      private DateTime AV52TFOperacoesTitulosUpdatedAt ;
      private DateTime AV53TFOperacoesTitulosUpdatedAt_To ;
      private DateTime AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat ;
      private DateTime AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ;
      private DateTime AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat ;
      private DateTime AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ;
      private DateTime A1028OperacoesTitulosCreatedAt ;
      private DateTime A1029OperacoesTitulosUpdatedAt ;
      private DateTime GXt_dtime3 ;
      private DateTime AV37TFOperacoesTitulosDataEmissao ;
      private DateTime AV38TFOperacoesTitulosDataEmissao_To ;
      private DateTime AV39TFOperacoesTitulosDataVencimento ;
      private DateTime AV40TFOperacoesTitulosDataVencimento_To ;
      private DateTime AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao ;
      private DateTime AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ;
      private DateTime AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ;
      private DateTime AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ;
      private DateTime A1022OperacoesTitulosDataEmissao ;
      private DateTime A1023OperacoesTitulosDataVencimento ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV66Operacoestituloswwds_5_dynamicfiltersenabled2 ;
      private bool AV69Operacoestituloswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n1034SacadoId ;
      private bool n1029OperacoesTitulosUpdatedAt ;
      private bool n1028OperacoesTitulosCreatedAt ;
      private bool n1026OperacoesTitulosTaxa ;
      private bool n1025OperacoesTitulosLiquido ;
      private bool n1024OperacoesTitulosValor ;
      private bool n1023OperacoesTitulosDataVencimento ;
      private bool n1022OperacoesTitulosDataEmissao ;
      private bool n1021OperacoesTitulosNumero ;
      private bool n1027OperacoesTitulosStatus ;
      private bool n1020OperacoesTitulosTipo ;
      private bool n1035SacadoRazaoSocial ;
      private bool n1010OperacoesId ;
      private string AV32TFOperacoesTitulosTipo_SelsJson ;
      private string AV47TFOperacoesTitulosStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV20OperacoesTitulosTipo1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV23OperacoesTitulosTipo2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV26OperacoesTitulosTipo3 ;
      private string AV58TFSacadoRazaoSocial_Sel ;
      private string AV57TFSacadoRazaoSocial ;
      private string AV33TFOperacoesTitulosTipo_Sel ;
      private string AV48TFOperacoesTitulosStatus_Sel ;
      private string AV63Operacoestituloswwds_2_filterfulltext ;
      private string AV64Operacoestituloswwds_3_dynamicfiltersselector1 ;
      private string AV65Operacoestituloswwds_4_operacoestitulostipo1 ;
      private string AV67Operacoestituloswwds_6_dynamicfiltersselector2 ;
      private string AV68Operacoestituloswwds_7_operacoestitulostipo2 ;
      private string AV70Operacoestituloswwds_9_dynamicfiltersselector3 ;
      private string AV71Operacoestituloswwds_10_operacoestitulostipo3 ;
      private string AV72Operacoestituloswwds_11_tfsacadorazaosocial ;
      private string AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel ;
      private string lV63Operacoestituloswwds_2_filterfulltext ;
      private string lV72Operacoestituloswwds_11_tfsacadorazaosocial ;
      private string A1020OperacoesTitulosTipo ;
      private string A1027OperacoesTitulosStatus ;
      private string A1035SacadoRazaoSocial ;
      private IGxSession AV28Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV34TFOperacoesTitulosTipo_Sels ;
      private GxSimpleCollection<string> AV49TFOperacoesTitulosStatus_Sels ;
      private GxSimpleCollection<string> AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels ;
      private GxSimpleCollection<string> AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00F72_A1034SacadoId ;
      private bool[] P00F72_n1034SacadoId ;
      private DateTime[] P00F72_A1029OperacoesTitulosUpdatedAt ;
      private bool[] P00F72_n1029OperacoesTitulosUpdatedAt ;
      private DateTime[] P00F72_A1028OperacoesTitulosCreatedAt ;
      private bool[] P00F72_n1028OperacoesTitulosCreatedAt ;
      private decimal[] P00F72_A1026OperacoesTitulosTaxa ;
      private bool[] P00F72_n1026OperacoesTitulosTaxa ;
      private decimal[] P00F72_A1025OperacoesTitulosLiquido ;
      private bool[] P00F72_n1025OperacoesTitulosLiquido ;
      private decimal[] P00F72_A1024OperacoesTitulosValor ;
      private bool[] P00F72_n1024OperacoesTitulosValor ;
      private DateTime[] P00F72_A1023OperacoesTitulosDataVencimento ;
      private bool[] P00F72_n1023OperacoesTitulosDataVencimento ;
      private DateTime[] P00F72_A1022OperacoesTitulosDataEmissao ;
      private bool[] P00F72_n1022OperacoesTitulosDataEmissao ;
      private int[] P00F72_A1021OperacoesTitulosNumero ;
      private bool[] P00F72_n1021OperacoesTitulosNumero ;
      private string[] P00F72_A1027OperacoesTitulosStatus ;
      private bool[] P00F72_n1027OperacoesTitulosStatus ;
      private string[] P00F72_A1020OperacoesTitulosTipo ;
      private bool[] P00F72_n1020OperacoesTitulosTipo ;
      private string[] P00F72_A1035SacadoRazaoSocial ;
      private bool[] P00F72_n1035SacadoRazaoSocial ;
      private int[] P00F72_A1010OperacoesId ;
      private bool[] P00F72_n1010OperacoesId ;
      private int[] P00F72_A1019OperacoesTitulosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class operacoestituloswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F72( IGxContext context ,
                                             string A1020OperacoesTitulosTipo ,
                                             GxSimpleCollection<string> AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels ,
                                             string A1027OperacoesTitulosStatus ,
                                             GxSimpleCollection<string> AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels ,
                                             string AV63Operacoestituloswwds_2_filterfulltext ,
                                             string AV64Operacoestituloswwds_3_dynamicfiltersselector1 ,
                                             string AV65Operacoestituloswwds_4_operacoestitulostipo1 ,
                                             bool AV66Operacoestituloswwds_5_dynamicfiltersenabled2 ,
                                             string AV67Operacoestituloswwds_6_dynamicfiltersselector2 ,
                                             string AV68Operacoestituloswwds_7_operacoestitulostipo2 ,
                                             bool AV69Operacoestituloswwds_8_dynamicfiltersenabled3 ,
                                             string AV70Operacoestituloswwds_9_dynamicfiltersselector3 ,
                                             string AV71Operacoestituloswwds_10_operacoestitulostipo3 ,
                                             string AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel ,
                                             string AV72Operacoestituloswwds_11_tfsacadorazaosocial ,
                                             int AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count ,
                                             int AV75Operacoestituloswwds_14_tfoperacoestitulosnumero ,
                                             int AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to ,
                                             DateTime AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao ,
                                             DateTime AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to ,
                                             DateTime AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento ,
                                             DateTime AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to ,
                                             decimal AV81Operacoestituloswwds_20_tfoperacoestitulosvalor ,
                                             decimal AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to ,
                                             decimal AV83Operacoestituloswwds_22_tfoperacoestitulosliquido ,
                                             decimal AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to ,
                                             decimal AV85Operacoestituloswwds_24_tfoperacoestitulostaxa ,
                                             decimal AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to ,
                                             int AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count ,
                                             DateTime AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat ,
                                             DateTime AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to ,
                                             DateTime AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat ,
                                             DateTime AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to ,
                                             string A1035SacadoRazaoSocial ,
                                             int A1021OperacoesTitulosNumero ,
                                             decimal A1024OperacoesTitulosValor ,
                                             decimal A1025OperacoesTitulosLiquido ,
                                             decimal A1026OperacoesTitulosTaxa ,
                                             DateTime A1022OperacoesTitulosDataEmissao ,
                                             DateTime A1023OperacoesTitulosDataVencimento ,
                                             DateTime A1028OperacoesTitulosCreatedAt ,
                                             DateTime A1029OperacoesTitulosUpdatedAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV62Operacoestituloswwds_1_operacoesid ,
                                             int A1010OperacoesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[35];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.SacadoId AS SacadoId, T1.OperacoesTitulosUpdatedAt, T1.OperacoesTitulosCreatedAt, T1.OperacoesTitulosTaxa, T1.OperacoesTitulosLiquido, T1.OperacoesTitulosValor, T1.OperacoesTitulosDataVencimento, T1.OperacoesTitulosDataEmissao, T1.OperacoesTitulosNumero, T1.OperacoesTitulosStatus, T1.OperacoesTitulosTipo, T2.ClienteRazaoSocial AS SacadoRazaoSocial, T1.OperacoesId, T1.OperacoesTitulosId FROM (OperacoesTitulos T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.SacadoId)";
         AddWhere(sWhereString, "(T1.OperacoesId = :AV62Operacoestituloswwds_1_operacoesid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Operacoestituloswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV63Operacoestituloswwds_2_filterfulltext) or ( 'na' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and (char_length(trim(trailing ' ' from T1.OperacoesTitulosTipo))=0)) or ( 'nota fiscal' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'NOTA_FISCAL')) or ( 'rpa' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosTipo = ( 'RPA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosNumero,'999999999'), 2) like '%' || :lV63Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosValor,'999999999999990.99'), 2) like '%' || :lV63Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosLiquido,'999999999999990.99'), 2) like '%' || :lV63Operacoestituloswwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTitulosTaxa,'99999999990.9999'), 2) like '%' || :lV63Operacoestituloswwds_2_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'PENDENTE')) or ( 'aceito' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'ACEITO')) or ( 'recusado' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'RECUSADO')) or ( 'vencido' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'VENCIDO')) or ( 'liquidado' like '%' || LOWER(:lV63Operacoestituloswwds_2_filterfulltext) and T1.OperacoesTitulosStatus = ( 'LIQUIDADO')))");
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
         }
         if ( ( StringUtil.StrCmp(AV64Operacoestituloswwds_3_dynamicfiltersselector1, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Operacoestituloswwds_4_operacoestitulostipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV65Operacoestituloswwds_4_operacoestitulostipo1))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV66Operacoestituloswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Operacoestituloswwds_6_dynamicfiltersselector2, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Operacoestituloswwds_7_operacoestitulostipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV68Operacoestituloswwds_7_operacoestitulostipo2))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV69Operacoestituloswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Operacoestituloswwds_9_dynamicfiltersselector3, "OPERACOESTITULOSTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Operacoestituloswwds_10_operacoestitulostipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTipo = ( :AV71Operacoestituloswwds_10_operacoestitulostipo3))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Operacoestituloswwds_11_tfsacadorazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV72Operacoestituloswwds_11_tfsacadorazaosocial)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel)) && ! ( StringUtil.StrCmp(AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV74Operacoestituloswwds_13_tfoperacoestitulostipo_sels, "T1.OperacoesTitulosTipo IN (", ")")+")");
         }
         if ( ! (0==AV75Operacoestituloswwds_14_tfoperacoestitulosnumero) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero >= :AV75Operacoestituloswwds_14_tfoperacoestitulosnumero)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (0==AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosNumero <= :AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao >= :AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataEmissao <= :AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento >= :AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosDataVencimento <= :AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV81Operacoestituloswwds_20_tfoperacoestitulosvalor) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor >= :AV81Operacoestituloswwds_20_tfoperacoestitulosvalor)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosValor <= :AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Operacoestituloswwds_22_tfoperacoestitulosliquido) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido >= :AV83Operacoestituloswwds_22_tfoperacoestitulosliquido)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosLiquido <= :AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Operacoestituloswwds_24_tfoperacoestitulostaxa) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa >= :AV85Operacoestituloswwds_24_tfoperacoestitulostaxa)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosTaxa <= :AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Operacoestituloswwds_26_tfoperacoestitulosstatus_sels, "T1.OperacoesTitulosStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt >= :AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosCreatedAt <= :AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt >= :AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTitulosUpdatedAt <= :AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosDataVencimento";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosDataVencimento DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T2.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T2.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosTipo";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosTipo DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosNumero";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosNumero DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosDataEmissao";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosDataEmissao DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosValor";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosValor DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosLiquido";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosLiquido DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosTaxa";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosTaxa DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosStatus";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosStatus DESC";
         }
         else if ( ( AV16OrderedBy == 10 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosCreatedAt";
         }
         else if ( ( AV16OrderedBy == 10 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 11 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId, T1.OperacoesTitulosUpdatedAt";
         }
         else if ( ( AV16OrderedBy == 11 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC, T1.OperacoesTitulosUpdatedAt DESC";
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
                     return conditional_P00F72(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (int)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (int)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] );
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
          Object[] prmP00F72;
          prmP00F72 = new Object[] {
          new ParDef("AV62Operacoestituloswwds_1_operacoesid",GXType.Int32,9,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Operacoestituloswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Operacoestituloswwds_4_operacoestitulostipo1",GXType.VarChar,40,0) ,
          new ParDef("AV68Operacoestituloswwds_7_operacoestitulostipo2",GXType.VarChar,40,0) ,
          new ParDef("AV71Operacoestituloswwds_10_operacoestitulostipo3",GXType.VarChar,40,0) ,
          new ParDef("lV72Operacoestituloswwds_11_tfsacadorazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV73Operacoestituloswwds_12_tfsacadorazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV75Operacoestituloswwds_14_tfoperacoestitulosnumero",GXType.Int32,9,0) ,
          new ParDef("AV76Operacoestituloswwds_15_tfoperacoestitulosnumero_to",GXType.Int32,9,0) ,
          new ParDef("AV77Operacoestituloswwds_16_tfoperacoestitulosdataemissao",GXType.Date,8,0) ,
          new ParDef("AV78Operacoestituloswwds_17_tfoperacoestitulosdataemissao_to",GXType.Date,8,0) ,
          new ParDef("AV79Operacoestituloswwds_18_tfoperacoestitulosdatavencimento",GXType.Date,8,0) ,
          new ParDef("AV80Operacoestituloswwds_19_tfoperacoestitulosdatavencimento_to",GXType.Date,8,0) ,
          new ParDef("AV81Operacoestituloswwds_20_tfoperacoestitulosvalor",GXType.Number,18,2) ,
          new ParDef("AV82Operacoestituloswwds_21_tfoperacoestitulosvalor_to",GXType.Number,18,2) ,
          new ParDef("AV83Operacoestituloswwds_22_tfoperacoestitulosliquido",GXType.Number,18,2) ,
          new ParDef("AV84Operacoestituloswwds_23_tfoperacoestitulosliquido_to",GXType.Number,18,2) ,
          new ParDef("AV85Operacoestituloswwds_24_tfoperacoestitulostaxa",GXType.Number,16,4) ,
          new ParDef("AV86Operacoestituloswwds_25_tfoperacoestitulostaxa_to",GXType.Number,16,4) ,
          new ParDef("AV88Operacoestituloswwds_27_tfoperacoestituloscreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV89Operacoestituloswwds_28_tfoperacoestituloscreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV90Operacoestituloswwds_29_tfoperacoestitulosupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV91Operacoestituloswwds_30_tfoperacoestitulosupdatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00F72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F72,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
