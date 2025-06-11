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
   public class operacoeslistaexport : GXProcedure
   {
      public operacoeslistaexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoeslistaexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "OperacoesListaExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV61TFOperacoesId) && (0==AV62TFOperacoesId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Identificador") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV61TFOperacoesId;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV62TFOperacoesId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razão social") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV43TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razão social") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV44TFOperacoesData) && (DateTime.MinValue==AV45TFOperacoesData_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFOperacoesData ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV45TFOperacoesData_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( ( AV48TFOperacoesStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV59i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV48TFOperacoesStatus_Sels.Count )
            {
               AV47TFOperacoesStatus_Sel = ((string)AV48TFOperacoesStatus_Sels.Item(AV63GXV1));
               if ( AV59i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusoperacao.getDescription(context,AV47TFOperacoesStatus_Sel);
               AV59i = (long)(AV59i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV49TFOperacoesTaxaEfetiva) && (Convert.ToDecimal(0)==AV50TFOperacoesTaxaEfetiva_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Taxa") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV49TFOperacoesTaxaEfetiva);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV50TFOperacoesTaxaEfetiva_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV51TFOperacoesTaxaMora) && (Convert.ToDecimal(0)==AV52TFOperacoesTaxaMora_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Mora") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV51TFOperacoesTaxaMora);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV52TFOperacoesTaxaMora_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFContratoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFContratoNome_Sel)) ? "(Vazio)" : AV54TFContratoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFContratoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFContratoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV55TFOperacoesCreatedAt) && (DateTime.MinValue==AV56TFOperacoesCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV55TFOperacoesCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV56TFOperacoesCreatedAt_To;
         }
         if ( ! ( (DateTime.MinValue==AV57TFOperacoesUpdateAt) && (DateTime.MinValue==AV58TFOperacoesUpdateAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV57TFOperacoesUpdateAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV58TFOperacoesUpdateAt_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Identificador";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Razão social";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Data";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Taxa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Mora";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Contrato";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Criado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Atualizado em";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV65Operacoeslistads_1_filterfulltext = AV18FilterFullText;
         AV66Operacoeslistads_2_tfoperacoesid = AV61TFOperacoesId;
         AV67Operacoeslistads_3_tfoperacoesid_to = AV62TFOperacoesId_To;
         AV68Operacoeslistads_4_tfclienterazaosocial = AV42TFClienteRazaoSocial;
         AV69Operacoeslistads_5_tfclienterazaosocial_sel = AV43TFClienteRazaoSocial_Sel;
         AV70Operacoeslistads_6_tfoperacoesdata = AV44TFOperacoesData;
         AV71Operacoeslistads_7_tfoperacoesdata_to = AV45TFOperacoesData_To;
         AV72Operacoeslistads_8_tfoperacoesstatus_sels = AV48TFOperacoesStatus_Sels;
         AV73Operacoeslistads_9_tfoperacoestaxaefetiva = AV49TFOperacoesTaxaEfetiva;
         AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV50TFOperacoesTaxaEfetiva_To;
         AV75Operacoeslistads_11_tfoperacoestaxamora = AV51TFOperacoesTaxaMora;
         AV76Operacoeslistads_12_tfoperacoestaxamora_to = AV52TFOperacoesTaxaMora_To;
         AV77Operacoeslistads_13_tfcontratonome = AV53TFContratoNome;
         AV78Operacoeslistads_14_tfcontratonome_sel = AV54TFContratoNome_Sel;
         AV79Operacoeslistads_15_tfoperacoescreatedat = AV55TFOperacoesCreatedAt;
         AV80Operacoeslistads_16_tfoperacoescreatedat_to = AV56TFOperacoesCreatedAt_To;
         AV81Operacoeslistads_17_tfoperacoesupdateat = AV57TFOperacoesUpdateAt;
         AV82Operacoeslistads_18_tfoperacoesupdateat_to = AV58TFOperacoesUpdateAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1012OperacoesStatus ,
                                              AV72Operacoeslistads_8_tfoperacoesstatus_sels ,
                                              AV65Operacoeslistads_1_filterfulltext ,
                                              AV66Operacoeslistads_2_tfoperacoesid ,
                                              AV67Operacoeslistads_3_tfoperacoesid_to ,
                                              AV69Operacoeslistads_5_tfclienterazaosocial_sel ,
                                              AV68Operacoeslistads_4_tfclienterazaosocial ,
                                              AV70Operacoeslistads_6_tfoperacoesdata ,
                                              AV71Operacoeslistads_7_tfoperacoesdata_to ,
                                              AV72Operacoeslistads_8_tfoperacoesstatus_sels.Count ,
                                              AV73Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                              AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                              AV75Operacoeslistads_11_tfoperacoestaxamora ,
                                              AV76Operacoeslistads_12_tfoperacoestaxamora_to ,
                                              AV78Operacoeslistads_14_tfcontratonome_sel ,
                                              AV77Operacoeslistads_13_tfcontratonome ,
                                              AV79Operacoeslistads_15_tfoperacoescreatedat ,
                                              AV80Operacoeslistads_16_tfoperacoescreatedat_to ,
                                              AV81Operacoeslistads_17_tfoperacoesupdateat ,
                                              AV82Operacoeslistads_18_tfoperacoesupdateat_to ,
                                              A1010OperacoesId ,
                                              A170ClienteRazaoSocial ,
                                              A1015OperacoesTaxaEfetiva ,
                                              A1016OperacoesTaxaMora ,
                                              A228ContratoNome ,
                                              A1011OperacoesData ,
                                              A1017OperacoesCreatedAt ,
                                              A1018OperacoesUpdateAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV60ClienteId ,
                                              A168ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV65Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext), "%", "");
         lV68Operacoeslistads_4_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV68Operacoeslistads_4_tfclienterazaosocial), "%", "");
         lV77Operacoeslistads_13_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV77Operacoeslistads_13_tfcontratonome), "%", "");
         /* Using cursor P00F52 */
         pr_default.execute(0, new Object[] {AV60ClienteId, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, lV65Operacoeslistads_1_filterfulltext, AV66Operacoeslistads_2_tfoperacoesid, AV67Operacoeslistads_3_tfoperacoesid_to, lV68Operacoeslistads_4_tfclienterazaosocial, AV69Operacoeslistads_5_tfclienterazaosocial_sel, AV70Operacoeslistads_6_tfoperacoesdata, AV71Operacoeslistads_7_tfoperacoesdata_to, AV73Operacoeslistads_9_tfoperacoestaxaefetiva, AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to, AV75Operacoeslistads_11_tfoperacoestaxamora, AV76Operacoeslistads_12_tfoperacoestaxamora_to, lV77Operacoeslistads_13_tfcontratonome, AV78Operacoeslistads_14_tfcontratonome_sel, AV79Operacoeslistads_15_tfoperacoescreatedat, AV80Operacoeslistads_16_tfoperacoescreatedat_to, AV81Operacoeslistads_17_tfoperacoesupdateat, AV82Operacoeslistads_18_tfoperacoesupdateat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P00F52_A227ContratoId[0];
            n227ContratoId = P00F52_n227ContratoId[0];
            A168ClienteId = P00F52_A168ClienteId[0];
            n168ClienteId = P00F52_n168ClienteId[0];
            A1018OperacoesUpdateAt = P00F52_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = P00F52_n1018OperacoesUpdateAt[0];
            A1017OperacoesCreatedAt = P00F52_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = P00F52_n1017OperacoesCreatedAt[0];
            A1016OperacoesTaxaMora = P00F52_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = P00F52_n1016OperacoesTaxaMora[0];
            A1015OperacoesTaxaEfetiva = P00F52_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = P00F52_n1015OperacoesTaxaEfetiva[0];
            A1011OperacoesData = P00F52_A1011OperacoesData[0];
            n1011OperacoesData = P00F52_n1011OperacoesData[0];
            A1010OperacoesId = P00F52_A1010OperacoesId[0];
            A228ContratoNome = P00F52_A228ContratoNome[0];
            n228ContratoNome = P00F52_n228ContratoNome[0];
            A1012OperacoesStatus = P00F52_A1012OperacoesStatus[0];
            n1012OperacoesStatus = P00F52_n1012OperacoesStatus[0];
            A170ClienteRazaoSocial = P00F52_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F52_n170ClienteRazaoSocial[0];
            A228ContratoNome = P00F52_A228ContratoNome[0];
            n228ContratoNome = P00F52_n228ContratoNome[0];
            A170ClienteRazaoSocial = P00F52_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F52_n170ClienteRazaoSocial[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A1010OperacoesId;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_dtime3 = DateTimeUtil.ResetTime( A1011OperacoesData ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = GXt_dtime3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = gxdomaindmstatusoperacao.getDescription(context,A1012OperacoesStatus);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A1015OperacoesTaxaEfetiva);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = (double)(A1016OperacoesTaxaMora);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A228ContratoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Date = A1017OperacoesCreatedAt;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Date = A1018OperacoesUpdateAt;
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
         AV38Session.Set("WWPExportFilePath", AV11Filename);
         AV38Session.Set("WWPExportFileName", "OperacoesListaExport.xlsx");
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
         if ( StringUtil.StrCmp(AV38Session.Get("OperacoesListaGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacoesListaGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("OperacoesListaGridState"), null, "", "");
         }
         AV16OrderedBy = AV40GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESID") == 0 )
            {
               AV61TFOperacoesId = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV62TFOperacoesId_To = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV42TFClienteRazaoSocial = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV43TFClienteRazaoSocial_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESDATA") == 0 )
            {
               AV44TFOperacoesData = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV45TFOperacoesData_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESSTATUS_SEL") == 0 )
            {
               AV46TFOperacoesStatus_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV48TFOperacoesStatus_Sels.FromJSonString(AV46TFOperacoesStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESTAXAEFETIVA") == 0 )
            {
               AV49TFOperacoesTaxaEfetiva = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV50TFOperacoesTaxaEfetiva_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESTAXAMORA") == 0 )
            {
               AV51TFOperacoesTaxaMora = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV52TFOperacoesTaxaMora_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV53TFContratoNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV54TFContratoNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESCREATEDAT") == 0 )
            {
               AV55TFOperacoesCreatedAt = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV56TFOperacoesCreatedAt_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFOPERACOESUPDATEAT") == 0 )
            {
               AV57TFOperacoesUpdateAt = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV58TFOperacoesUpdateAt_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV60ClienteId = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV83GXV2 = (int)(AV83GXV2+1);
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
         AV43TFClienteRazaoSocial_Sel = "";
         AV42TFClienteRazaoSocial = "";
         AV44TFOperacoesData = DateTime.MinValue;
         AV45TFOperacoesData_To = DateTime.MinValue;
         AV48TFOperacoesStatus_Sels = new GxSimpleCollection<string>();
         AV47TFOperacoesStatus_Sel = "";
         AV54TFContratoNome_Sel = "";
         AV53TFContratoNome = "";
         AV55TFOperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         AV56TFOperacoesCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV57TFOperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         AV58TFOperacoesUpdateAt_To = (DateTime)(DateTime.MinValue);
         AV65Operacoeslistads_1_filterfulltext = "";
         AV68Operacoeslistads_4_tfclienterazaosocial = "";
         AV69Operacoeslistads_5_tfclienterazaosocial_sel = "";
         AV70Operacoeslistads_6_tfoperacoesdata = DateTime.MinValue;
         AV71Operacoeslistads_7_tfoperacoesdata_to = DateTime.MinValue;
         AV72Operacoeslistads_8_tfoperacoesstatus_sels = new GxSimpleCollection<string>();
         AV77Operacoeslistads_13_tfcontratonome = "";
         AV78Operacoeslistads_14_tfcontratonome_sel = "";
         AV79Operacoeslistads_15_tfoperacoescreatedat = (DateTime)(DateTime.MinValue);
         AV80Operacoeslistads_16_tfoperacoescreatedat_to = (DateTime)(DateTime.MinValue);
         AV81Operacoeslistads_17_tfoperacoesupdateat = (DateTime)(DateTime.MinValue);
         AV82Operacoeslistads_18_tfoperacoesupdateat_to = (DateTime)(DateTime.MinValue);
         lV65Operacoeslistads_1_filterfulltext = "";
         lV68Operacoeslistads_4_tfclienterazaosocial = "";
         lV77Operacoeslistads_13_tfcontratonome = "";
         A1012OperacoesStatus = "";
         A170ClienteRazaoSocial = "";
         A228ContratoNome = "";
         A1011OperacoesData = DateTime.MinValue;
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         P00F52_A227ContratoId = new int[1] ;
         P00F52_n227ContratoId = new bool[] {false} ;
         P00F52_A168ClienteId = new int[1] ;
         P00F52_n168ClienteId = new bool[] {false} ;
         P00F52_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         P00F52_n1018OperacoesUpdateAt = new bool[] {false} ;
         P00F52_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F52_n1017OperacoesCreatedAt = new bool[] {false} ;
         P00F52_A1016OperacoesTaxaMora = new decimal[1] ;
         P00F52_n1016OperacoesTaxaMora = new bool[] {false} ;
         P00F52_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         P00F52_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         P00F52_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         P00F52_n1011OperacoesData = new bool[] {false} ;
         P00F52_A1010OperacoesId = new int[1] ;
         P00F52_A228ContratoNome = new string[] {""} ;
         P00F52_n228ContratoNome = new bool[] {false} ;
         P00F52_A1012OperacoesStatus = new string[] {""} ;
         P00F52_n1012OperacoesStatus = new bool[] {false} ;
         P00F52_A170ClienteRazaoSocial = new string[] {""} ;
         P00F52_n170ClienteRazaoSocial = new bool[] {false} ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFOperacoesStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoeslistaexport__default(),
            new Object[][] {
                new Object[] {
               P00F52_A227ContratoId, P00F52_n227ContratoId, P00F52_A168ClienteId, P00F52_n168ClienteId, P00F52_A1018OperacoesUpdateAt, P00F52_n1018OperacoesUpdateAt, P00F52_A1017OperacoesCreatedAt, P00F52_n1017OperacoesCreatedAt, P00F52_A1016OperacoesTaxaMora, P00F52_n1016OperacoesTaxaMora,
               P00F52_A1015OperacoesTaxaEfetiva, P00F52_n1015OperacoesTaxaEfetiva, P00F52_A1011OperacoesData, P00F52_n1011OperacoesData, P00F52_A1010OperacoesId, P00F52_A228ContratoNome, P00F52_n228ContratoNome, P00F52_A1012OperacoesStatus, P00F52_n1012OperacoesStatus, P00F52_A170ClienteRazaoSocial,
               P00F52_n170ClienteRazaoSocial
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
      private int AV61TFOperacoesId ;
      private int AV62TFOperacoesId_To ;
      private int AV63GXV1 ;
      private int AV66Operacoeslistads_2_tfoperacoesid ;
      private int AV67Operacoeslistads_3_tfoperacoesid_to ;
      private int AV72Operacoeslistads_8_tfoperacoesstatus_sels_Count ;
      private int A1010OperacoesId ;
      private int AV60ClienteId ;
      private int A168ClienteId ;
      private int A227ContratoId ;
      private int AV83GXV2 ;
      private long AV59i ;
      private decimal AV49TFOperacoesTaxaEfetiva ;
      private decimal AV50TFOperacoesTaxaEfetiva_To ;
      private decimal AV51TFOperacoesTaxaMora ;
      private decimal AV52TFOperacoesTaxaMora_To ;
      private decimal AV73Operacoeslistads_9_tfoperacoestaxaefetiva ;
      private decimal AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to ;
      private decimal AV75Operacoeslistads_11_tfoperacoestaxamora ;
      private decimal AV76Operacoeslistads_12_tfoperacoestaxamora_to ;
      private decimal A1015OperacoesTaxaEfetiva ;
      private decimal A1016OperacoesTaxaMora ;
      private string GXt_char1 ;
      private DateTime AV55TFOperacoesCreatedAt ;
      private DateTime AV56TFOperacoesCreatedAt_To ;
      private DateTime AV57TFOperacoesUpdateAt ;
      private DateTime AV58TFOperacoesUpdateAt_To ;
      private DateTime AV79Operacoeslistads_15_tfoperacoescreatedat ;
      private DateTime AV80Operacoeslistads_16_tfoperacoescreatedat_to ;
      private DateTime AV81Operacoeslistads_17_tfoperacoesupdateat ;
      private DateTime AV82Operacoeslistads_18_tfoperacoesupdateat_to ;
      private DateTime A1017OperacoesCreatedAt ;
      private DateTime A1018OperacoesUpdateAt ;
      private DateTime GXt_dtime3 ;
      private DateTime AV44TFOperacoesData ;
      private DateTime AV45TFOperacoesData_To ;
      private DateTime AV70Operacoeslistads_6_tfoperacoesdata ;
      private DateTime AV71Operacoeslistads_7_tfoperacoesdata_to ;
      private DateTime A1011OperacoesData ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private bool n227ContratoId ;
      private bool n168ClienteId ;
      private bool n1018OperacoesUpdateAt ;
      private bool n1017OperacoesCreatedAt ;
      private bool n1016OperacoesTaxaMora ;
      private bool n1015OperacoesTaxaEfetiva ;
      private bool n1011OperacoesData ;
      private bool n228ContratoNome ;
      private bool n1012OperacoesStatus ;
      private bool n170ClienteRazaoSocial ;
      private string AV46TFOperacoesStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV43TFClienteRazaoSocial_Sel ;
      private string AV42TFClienteRazaoSocial ;
      private string AV47TFOperacoesStatus_Sel ;
      private string AV54TFContratoNome_Sel ;
      private string AV53TFContratoNome ;
      private string AV65Operacoeslistads_1_filterfulltext ;
      private string AV68Operacoeslistads_4_tfclienterazaosocial ;
      private string AV69Operacoeslistads_5_tfclienterazaosocial_sel ;
      private string AV77Operacoeslistads_13_tfcontratonome ;
      private string AV78Operacoeslistads_14_tfcontratonome_sel ;
      private string lV65Operacoeslistads_1_filterfulltext ;
      private string lV68Operacoeslistads_4_tfclienterazaosocial ;
      private string lV77Operacoeslistads_13_tfcontratonome ;
      private string A1012OperacoesStatus ;
      private string A170ClienteRazaoSocial ;
      private string A228ContratoNome ;
      private IGxSession AV38Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV48TFOperacoesStatus_Sels ;
      private GxSimpleCollection<string> AV72Operacoeslistads_8_tfoperacoesstatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00F52_A227ContratoId ;
      private bool[] P00F52_n227ContratoId ;
      private int[] P00F52_A168ClienteId ;
      private bool[] P00F52_n168ClienteId ;
      private DateTime[] P00F52_A1018OperacoesUpdateAt ;
      private bool[] P00F52_n1018OperacoesUpdateAt ;
      private DateTime[] P00F52_A1017OperacoesCreatedAt ;
      private bool[] P00F52_n1017OperacoesCreatedAt ;
      private decimal[] P00F52_A1016OperacoesTaxaMora ;
      private bool[] P00F52_n1016OperacoesTaxaMora ;
      private decimal[] P00F52_A1015OperacoesTaxaEfetiva ;
      private bool[] P00F52_n1015OperacoesTaxaEfetiva ;
      private DateTime[] P00F52_A1011OperacoesData ;
      private bool[] P00F52_n1011OperacoesData ;
      private int[] P00F52_A1010OperacoesId ;
      private string[] P00F52_A228ContratoNome ;
      private bool[] P00F52_n228ContratoNome ;
      private string[] P00F52_A1012OperacoesStatus ;
      private bool[] P00F52_n1012OperacoesStatus ;
      private string[] P00F52_A170ClienteRazaoSocial ;
      private bool[] P00F52_n170ClienteRazaoSocial ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class operacoeslistaexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F52( IGxContext context ,
                                             string A1012OperacoesStatus ,
                                             GxSimpleCollection<string> AV72Operacoeslistads_8_tfoperacoesstatus_sels ,
                                             string AV65Operacoeslistads_1_filterfulltext ,
                                             int AV66Operacoeslistads_2_tfoperacoesid ,
                                             int AV67Operacoeslistads_3_tfoperacoesid_to ,
                                             string AV69Operacoeslistads_5_tfclienterazaosocial_sel ,
                                             string AV68Operacoeslistads_4_tfclienterazaosocial ,
                                             DateTime AV70Operacoeslistads_6_tfoperacoesdata ,
                                             DateTime AV71Operacoeslistads_7_tfoperacoesdata_to ,
                                             int AV72Operacoeslistads_8_tfoperacoesstatus_sels_Count ,
                                             decimal AV73Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                             decimal AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                             decimal AV75Operacoeslistads_11_tfoperacoestaxamora ,
                                             decimal AV76Operacoeslistads_12_tfoperacoestaxamora_to ,
                                             string AV78Operacoeslistads_14_tfcontratonome_sel ,
                                             string AV77Operacoeslistads_13_tfcontratonome ,
                                             DateTime AV79Operacoeslistads_15_tfoperacoescreatedat ,
                                             DateTime AV80Operacoeslistads_16_tfoperacoescreatedat_to ,
                                             DateTime AV81Operacoeslistads_17_tfoperacoesupdateat ,
                                             DateTime AV82Operacoeslistads_18_tfoperacoesupdateat_to ,
                                             int A1010OperacoesId ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A1015OperacoesTaxaEfetiva ,
                                             decimal A1016OperacoesTaxaMora ,
                                             string A228ContratoNome ,
                                             DateTime A1011OperacoesData ,
                                             DateTime A1017OperacoesCreatedAt ,
                                             DateTime A1018OperacoesUpdateAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV60ClienteId ,
                                             int A168ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[26];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ClienteId, T1.OperacoesUpdateAt, T1.OperacoesCreatedAt, T1.OperacoesTaxaMora, T1.OperacoesTaxaEfetiva, T1.OperacoesData, T1.OperacoesId, T2.ContratoNome, T1.OperacoesStatus, T3.ClienteRazaoSocial FROM ((Operacoes T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV60ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Operacoeslistads_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.OperacoesId,'999999999'), 2) like '%' || :lV65Operacoeslistads_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV65Operacoeslistads_1_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV65Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'PENDENTE')) or ( 'aprovada' like '%' || LOWER(:lV65Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'APROVADA')) or ( 'recusada' like '%' || LOWER(:lV65Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'RECUSADA')) or ( 'liquidada' like '%' || LOWER(:lV65Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'LIQUIDADA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaEfetiva,'99999999990.9999'), 2) like '%' || :lV65Operacoeslistads_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaMora,'99999999990.9999'), 2) like '%' || :lV65Operacoeslistads_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV65Operacoeslistads_1_filterfulltext))");
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
         }
         if ( ! (0==AV66Operacoeslistads_2_tfoperacoesid) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId >= :AV66Operacoeslistads_2_tfoperacoesid)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV67Operacoeslistads_3_tfoperacoesid_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId <= :AV67Operacoeslistads_3_tfoperacoesid_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Operacoeslistads_5_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Operacoeslistads_4_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV68Operacoeslistads_4_tfclienterazaosocial)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Operacoeslistads_5_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV69Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV69Operacoeslistads_5_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( ! (DateTime.MinValue==AV70Operacoeslistads_6_tfoperacoesdata) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData >= :AV70Operacoeslistads_6_tfoperacoesdata)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Operacoeslistads_7_tfoperacoesdata_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData <= :AV71Operacoeslistads_7_tfoperacoesdata_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV72Operacoeslistads_8_tfoperacoesstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV72Operacoeslistads_8_tfoperacoesstatus_sels, "T1.OperacoesStatus IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV73Operacoeslistads_9_tfoperacoestaxaefetiva) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva >= :AV73Operacoeslistads_9_tfoperacoestaxaefetiva)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva <= :AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Operacoeslistads_11_tfoperacoestaxamora) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora >= :AV75Operacoeslistads_11_tfoperacoestaxamora)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Operacoeslistads_12_tfoperacoestaxamora_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora <= :AV76Operacoeslistads_12_tfoperacoestaxamora_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Operacoeslistads_14_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Operacoeslistads_13_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV77Operacoeslistads_13_tfcontratonome)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Operacoeslistads_14_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV78Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV78Operacoeslistads_14_tfcontratonome_sel))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV78Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV79Operacoeslistads_15_tfoperacoescreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt >= :AV79Operacoeslistads_15_tfoperacoescreatedat)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Operacoeslistads_16_tfoperacoescreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt <= :AV80Operacoeslistads_16_tfoperacoescreatedat_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Operacoeslistads_17_tfoperacoesupdateat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt >= :AV81Operacoeslistads_17_tfoperacoesupdateat)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Operacoeslistads_18_tfoperacoesupdateat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt <= :AV82Operacoeslistads_18_tfoperacoesupdateat_to)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesData";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesData DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesId DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesStatus";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesStatus DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesTaxaEfetiva";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesTaxaEfetiva DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesTaxaMora";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesTaxaMora DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ContratoNome";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ContratoNome DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesCreatedAt";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.OperacoesUpdateAt";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.OperacoesUpdateAt DESC";
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
                     return conditional_P00F52(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
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
          Object[] prmP00F52;
          prmP00F52 = new Object[] {
          new ParDef("AV60ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV66Operacoeslistads_2_tfoperacoesid",GXType.Int32,9,0) ,
          new ParDef("AV67Operacoeslistads_3_tfoperacoesid_to",GXType.Int32,9,0) ,
          new ParDef("lV68Operacoeslistads_4_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV69Operacoeslistads_5_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV70Operacoeslistads_6_tfoperacoesdata",GXType.Date,8,0) ,
          new ParDef("AV71Operacoeslistads_7_tfoperacoesdata_to",GXType.Date,8,0) ,
          new ParDef("AV73Operacoeslistads_9_tfoperacoestaxaefetiva",GXType.Number,16,4) ,
          new ParDef("AV74Operacoeslistads_10_tfoperacoestaxaefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV75Operacoeslistads_11_tfoperacoestaxamora",GXType.Number,16,4) ,
          new ParDef("AV76Operacoeslistads_12_tfoperacoestaxamora_to",GXType.Number,16,4) ,
          new ParDef("lV77Operacoeslistads_13_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV78Operacoeslistads_14_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV79Operacoeslistads_15_tfoperacoescreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV80Operacoeslistads_16_tfoperacoescreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV81Operacoeslistads_17_tfoperacoesupdateat",GXType.DateTime,8,5) ,
          new ParDef("AV82Operacoeslistads_18_tfoperacoesupdateat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00F52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F52,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
