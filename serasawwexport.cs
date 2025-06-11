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
   public class serasawwexport : GXProcedure
   {
      public serasawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "SerasaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SERASANUMEROPROPOSTA") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21SerasaNumeroProposta1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SerasaNumeroProposta1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Numero Proposta", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Numero Proposta", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21SerasaNumeroProposta1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SERASANUMEROPROPOSTA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25SerasaNumeroProposta2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SerasaNumeroProposta2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Numero Proposta", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Numero Proposta", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25SerasaNumeroProposta2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SERASANUMEROPROPOSTA") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29SerasaNumeroProposta3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SerasaNumeroProposta3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Numero Proposta", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Numero Proposta", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29SerasaNumeroProposta3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV44TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSerasaNumeroProposta_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Identificador") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSerasaNumeroProposta_Sel)) ? "(Vazio)" : AV36TFSerasaNumeroProposta_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSerasaNumeroProposta)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Identificador") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFSerasaNumeroProposta, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV37TFSerasaPolitica) && (Convert.ToDecimal(0)==AV38TFSerasaPolitica_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Política") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV37TFSerasaPolitica);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV38TFSerasaPolitica_To);
         }
         if ( ! ( (DateTime.MinValue==AV39TFSerasaCreatedAt) && (DateTime.MinValue==AV40TFSerasaCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV39TFSerasaCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV40TFSerasaCreatedAt_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSerasaTipoVenda_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de venda") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSerasaTipoVenda_Sel)) ? "(Vazio)" : AV42TFSerasaTipoVenda_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSerasaTipoVenda)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de venda") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFSerasaTipoVenda, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nome";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Identificador";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Política";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Data";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Tipo de venda";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV49Serasawwds_1_filterfulltext = AV18FilterFullText;
         AV50Serasawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV51Serasawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV52Serasawwds_4_serasanumeroproposta1 = AV21SerasaNumeroProposta1;
         AV53Serasawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV54Serasawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV55Serasawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV56Serasawwds_8_serasanumeroproposta2 = AV25SerasaNumeroProposta2;
         AV57Serasawwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV58Serasawwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV59Serasawwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV60Serasawwds_12_serasanumeroproposta3 = AV29SerasaNumeroProposta3;
         AV61Serasawwds_13_tfclienterazaosocial = AV43TFClienteRazaoSocial;
         AV62Serasawwds_14_tfclienterazaosocial_sel = AV44TFClienteRazaoSocial_Sel;
         AV63Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV64Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV65Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV66Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV67Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV68Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV69Serasawwds_21_tfserasatipovenda = AV41TFSerasaTipoVenda;
         AV70Serasawwds_22_tfserasatipovenda_sel = AV42TFSerasaTipoVenda_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A168ClienteId ,
                                              AV47Array_ClienteId ,
                                              AV49Serasawwds_1_filterfulltext ,
                                              AV50Serasawwds_2_dynamicfiltersselector1 ,
                                              AV51Serasawwds_3_dynamicfiltersoperator1 ,
                                              AV52Serasawwds_4_serasanumeroproposta1 ,
                                              AV53Serasawwds_5_dynamicfiltersenabled2 ,
                                              AV54Serasawwds_6_dynamicfiltersselector2 ,
                                              AV55Serasawwds_7_dynamicfiltersoperator2 ,
                                              AV56Serasawwds_8_serasanumeroproposta2 ,
                                              AV57Serasawwds_9_dynamicfiltersenabled3 ,
                                              AV58Serasawwds_10_dynamicfiltersselector3 ,
                                              AV59Serasawwds_11_dynamicfiltersoperator3 ,
                                              AV60Serasawwds_12_serasanumeroproposta3 ,
                                              AV62Serasawwds_14_tfclienterazaosocial_sel ,
                                              AV61Serasawwds_13_tfclienterazaosocial ,
                                              AV64Serasawwds_16_tfserasanumeroproposta_sel ,
                                              AV63Serasawwds_15_tfserasanumeroproposta ,
                                              AV65Serasawwds_17_tfserasapolitica ,
                                              AV66Serasawwds_18_tfserasapolitica_to ,
                                              AV67Serasawwds_19_tfserasacreatedat ,
                                              AV68Serasawwds_20_tfserasacreatedat_to ,
                                              AV70Serasawwds_22_tfserasatipovenda_sel ,
                                              AV69Serasawwds_21_tfserasatipovenda ,
                                              A170ClienteRazaoSocial ,
                                              A663SerasaNumeroProposta ,
                                              A664SerasaPolitica ,
                                              A666SerasaTipoVenda ,
                                              A665SerasaCreatedAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV49Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Serasawwds_1_filterfulltext), "%", "");
         lV49Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Serasawwds_1_filterfulltext), "%", "");
         lV49Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Serasawwds_1_filterfulltext), "%", "");
         lV49Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Serasawwds_1_filterfulltext), "%", "");
         lV52Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV52Serasawwds_4_serasanumeroproposta1), "%", "");
         lV52Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV52Serasawwds_4_serasanumeroproposta1), "%", "");
         lV56Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV56Serasawwds_8_serasanumeroproposta2), "%", "");
         lV56Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV56Serasawwds_8_serasanumeroproposta2), "%", "");
         lV60Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV60Serasawwds_12_serasanumeroproposta3), "%", "");
         lV60Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV60Serasawwds_12_serasanumeroproposta3), "%", "");
         lV61Serasawwds_13_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV61Serasawwds_13_tfclienterazaosocial), "%", "");
         lV63Serasawwds_15_tfserasanumeroproposta = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_15_tfserasanumeroproposta), "%", "");
         lV69Serasawwds_21_tfserasatipovenda = StringUtil.Concat( StringUtil.RTrim( AV69Serasawwds_21_tfserasatipovenda), "%", "");
         /* Using cursor P00CL2 */
         pr_default.execute(0, new Object[] {lV49Serasawwds_1_filterfulltext, lV49Serasawwds_1_filterfulltext, lV49Serasawwds_1_filterfulltext, lV49Serasawwds_1_filterfulltext, lV52Serasawwds_4_serasanumeroproposta1, lV52Serasawwds_4_serasanumeroproposta1, lV56Serasawwds_8_serasanumeroproposta2, lV56Serasawwds_8_serasanumeroproposta2, lV60Serasawwds_12_serasanumeroproposta3, lV60Serasawwds_12_serasanumeroproposta3, lV61Serasawwds_13_tfclienterazaosocial, AV62Serasawwds_14_tfclienterazaosocial_sel, lV63Serasawwds_15_tfserasanumeroproposta, AV64Serasawwds_16_tfserasanumeroproposta_sel, AV65Serasawwds_17_tfserasapolitica, AV66Serasawwds_18_tfserasapolitica_to, AV67Serasawwds_19_tfserasacreatedat, AV68Serasawwds_20_tfserasacreatedat_to, lV69Serasawwds_21_tfserasatipovenda, AV70Serasawwds_22_tfserasatipovenda_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = P00CL2_A168ClienteId[0];
            n168ClienteId = P00CL2_n168ClienteId[0];
            A665SerasaCreatedAt = P00CL2_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = P00CL2_n665SerasaCreatedAt[0];
            A664SerasaPolitica = P00CL2_A664SerasaPolitica[0];
            n664SerasaPolitica = P00CL2_n664SerasaPolitica[0];
            A666SerasaTipoVenda = P00CL2_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = P00CL2_n666SerasaTipoVenda[0];
            A663SerasaNumeroProposta = P00CL2_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = P00CL2_n663SerasaNumeroProposta[0];
            A170ClienteRazaoSocial = P00CL2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CL2_n170ClienteRazaoSocial[0];
            A662SerasaId = P00CL2_A662SerasaId[0];
            A170ClienteRazaoSocial = P00CL2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CL2_n170ClienteRazaoSocial[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A663SerasaNumeroProposta, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A664SerasaPolitica);
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = A665SerasaCreatedAt;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A666SerasaTipoVenda, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "SerasaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("SerasaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SerasaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("SerasaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV43TFClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV44TFClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASANUMEROPROPOSTA") == 0 )
            {
               AV35TFSerasaNumeroProposta = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASANUMEROPROPOSTA_SEL") == 0 )
            {
               AV36TFSerasaNumeroProposta_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAPOLITICA") == 0 )
            {
               AV37TFSerasaPolitica = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV38TFSerasaPolitica_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASACREATEDAT") == 0 )
            {
               AV39TFSerasaCreatedAt = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV40TFSerasaCreatedAt_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASATIPOVENDA") == 0 )
            {
               AV41TFSerasaTipoVenda = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASATIPOVENDA_SEL") == 0 )
            {
               AV42TFSerasaTipoVenda_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTESIDS") == 0 )
            {
               AV45ClientesIds = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV46PropostaId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV71GXV1 = (int)(AV71GXV1+1);
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
         AV21SerasaNumeroProposta1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25SerasaNumeroProposta2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29SerasaNumeroProposta3 = "";
         AV44TFClienteRazaoSocial_Sel = "";
         AV43TFClienteRazaoSocial = "";
         AV36TFSerasaNumeroProposta_Sel = "";
         AV35TFSerasaNumeroProposta = "";
         AV39TFSerasaCreatedAt = (DateTime)(DateTime.MinValue);
         AV40TFSerasaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV42TFSerasaTipoVenda_Sel = "";
         AV41TFSerasaTipoVenda = "";
         AV49Serasawwds_1_filterfulltext = "";
         AV50Serasawwds_2_dynamicfiltersselector1 = "";
         AV52Serasawwds_4_serasanumeroproposta1 = "";
         AV54Serasawwds_6_dynamicfiltersselector2 = "";
         AV56Serasawwds_8_serasanumeroproposta2 = "";
         AV58Serasawwds_10_dynamicfiltersselector3 = "";
         AV60Serasawwds_12_serasanumeroproposta3 = "";
         AV61Serasawwds_13_tfclienterazaosocial = "";
         AV62Serasawwds_14_tfclienterazaosocial_sel = "";
         AV63Serasawwds_15_tfserasanumeroproposta = "";
         AV64Serasawwds_16_tfserasanumeroproposta_sel = "";
         AV67Serasawwds_19_tfserasacreatedat = (DateTime)(DateTime.MinValue);
         AV68Serasawwds_20_tfserasacreatedat_to = (DateTime)(DateTime.MinValue);
         AV69Serasawwds_21_tfserasatipovenda = "";
         AV70Serasawwds_22_tfserasatipovenda_sel = "";
         lV49Serasawwds_1_filterfulltext = "";
         lV52Serasawwds_4_serasanumeroproposta1 = "";
         lV56Serasawwds_8_serasanumeroproposta2 = "";
         lV60Serasawwds_12_serasanumeroproposta3 = "";
         lV61Serasawwds_13_tfclienterazaosocial = "";
         lV63Serasawwds_15_tfserasanumeroproposta = "";
         lV69Serasawwds_21_tfserasatipovenda = "";
         AV47Array_ClienteId = new GxSimpleCollection<int>();
         A170ClienteRazaoSocial = "";
         A663SerasaNumeroProposta = "";
         A666SerasaTipoVenda = "";
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         P00CL2_A168ClienteId = new int[1] ;
         P00CL2_n168ClienteId = new bool[] {false} ;
         P00CL2_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CL2_n665SerasaCreatedAt = new bool[] {false} ;
         P00CL2_A664SerasaPolitica = new decimal[1] ;
         P00CL2_n664SerasaPolitica = new bool[] {false} ;
         P00CL2_A666SerasaTipoVenda = new string[] {""} ;
         P00CL2_n666SerasaTipoVenda = new bool[] {false} ;
         P00CL2_A663SerasaNumeroProposta = new string[] {""} ;
         P00CL2_n663SerasaNumeroProposta = new bool[] {false} ;
         P00CL2_A170ClienteRazaoSocial = new string[] {""} ;
         P00CL2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00CL2_A662SerasaId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasawwexport__default(),
            new Object[][] {
                new Object[] {
               P00CL2_A168ClienteId, P00CL2_n168ClienteId, P00CL2_A665SerasaCreatedAt, P00CL2_n665SerasaCreatedAt, P00CL2_A664SerasaPolitica, P00CL2_n664SerasaPolitica, P00CL2_A666SerasaTipoVenda, P00CL2_n666SerasaTipoVenda, P00CL2_A663SerasaNumeroProposta, P00CL2_n663SerasaNumeroProposta,
               P00CL2_A170ClienteRazaoSocial, P00CL2_n170ClienteRazaoSocial, P00CL2_A662SerasaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV51Serasawwds_3_dynamicfiltersoperator1 ;
      private short AV55Serasawwds_7_dynamicfiltersoperator2 ;
      private short AV59Serasawwds_11_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private short AV45ClientesIds ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A168ClienteId ;
      private int A662SerasaId ;
      private int AV71GXV1 ;
      private int AV46PropostaId ;
      private decimal AV37TFSerasaPolitica ;
      private decimal AV38TFSerasaPolitica_To ;
      private decimal AV65Serasawwds_17_tfserasapolitica ;
      private decimal AV66Serasawwds_18_tfserasapolitica_to ;
      private decimal A664SerasaPolitica ;
      private string GXt_char1 ;
      private DateTime AV39TFSerasaCreatedAt ;
      private DateTime AV40TFSerasaCreatedAt_To ;
      private DateTime AV67Serasawwds_19_tfserasacreatedat ;
      private DateTime AV68Serasawwds_20_tfserasacreatedat_to ;
      private DateTime A665SerasaCreatedAt ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV53Serasawwds_5_dynamicfiltersenabled2 ;
      private bool AV57Serasawwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n168ClienteId ;
      private bool n665SerasaCreatedAt ;
      private bool n664SerasaPolitica ;
      private bool n666SerasaTipoVenda ;
      private bool n663SerasaNumeroProposta ;
      private bool n170ClienteRazaoSocial ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21SerasaNumeroProposta1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25SerasaNumeroProposta2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29SerasaNumeroProposta3 ;
      private string AV44TFClienteRazaoSocial_Sel ;
      private string AV43TFClienteRazaoSocial ;
      private string AV36TFSerasaNumeroProposta_Sel ;
      private string AV35TFSerasaNumeroProposta ;
      private string AV42TFSerasaTipoVenda_Sel ;
      private string AV41TFSerasaTipoVenda ;
      private string AV49Serasawwds_1_filterfulltext ;
      private string AV50Serasawwds_2_dynamicfiltersselector1 ;
      private string AV52Serasawwds_4_serasanumeroproposta1 ;
      private string AV54Serasawwds_6_dynamicfiltersselector2 ;
      private string AV56Serasawwds_8_serasanumeroproposta2 ;
      private string AV58Serasawwds_10_dynamicfiltersselector3 ;
      private string AV60Serasawwds_12_serasanumeroproposta3 ;
      private string AV61Serasawwds_13_tfclienterazaosocial ;
      private string AV62Serasawwds_14_tfclienterazaosocial_sel ;
      private string AV63Serasawwds_15_tfserasanumeroproposta ;
      private string AV64Serasawwds_16_tfserasanumeroproposta_sel ;
      private string AV69Serasawwds_21_tfserasatipovenda ;
      private string AV70Serasawwds_22_tfserasatipovenda_sel ;
      private string lV49Serasawwds_1_filterfulltext ;
      private string lV52Serasawwds_4_serasanumeroproposta1 ;
      private string lV56Serasawwds_8_serasanumeroproposta2 ;
      private string lV60Serasawwds_12_serasanumeroproposta3 ;
      private string lV61Serasawwds_13_tfclienterazaosocial ;
      private string lV63Serasawwds_15_tfserasanumeroproposta ;
      private string lV69Serasawwds_21_tfserasatipovenda ;
      private string A170ClienteRazaoSocial ;
      private string A663SerasaNumeroProposta ;
      private string A666SerasaTipoVenda ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<int> AV47Array_ClienteId ;
      private IDataStoreProvider pr_default ;
      private int[] P00CL2_A168ClienteId ;
      private bool[] P00CL2_n168ClienteId ;
      private DateTime[] P00CL2_A665SerasaCreatedAt ;
      private bool[] P00CL2_n665SerasaCreatedAt ;
      private decimal[] P00CL2_A664SerasaPolitica ;
      private bool[] P00CL2_n664SerasaPolitica ;
      private string[] P00CL2_A666SerasaTipoVenda ;
      private bool[] P00CL2_n666SerasaTipoVenda ;
      private string[] P00CL2_A663SerasaNumeroProposta ;
      private bool[] P00CL2_n663SerasaNumeroProposta ;
      private string[] P00CL2_A170ClienteRazaoSocial ;
      private bool[] P00CL2_n170ClienteRazaoSocial ;
      private int[] P00CL2_A662SerasaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class serasawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CL2( IGxContext context ,
                                             int A168ClienteId ,
                                             GxSimpleCollection<int> AV47Array_ClienteId ,
                                             string AV49Serasawwds_1_filterfulltext ,
                                             string AV50Serasawwds_2_dynamicfiltersselector1 ,
                                             short AV51Serasawwds_3_dynamicfiltersoperator1 ,
                                             string AV52Serasawwds_4_serasanumeroproposta1 ,
                                             bool AV53Serasawwds_5_dynamicfiltersenabled2 ,
                                             string AV54Serasawwds_6_dynamicfiltersselector2 ,
                                             short AV55Serasawwds_7_dynamicfiltersoperator2 ,
                                             string AV56Serasawwds_8_serasanumeroproposta2 ,
                                             bool AV57Serasawwds_9_dynamicfiltersenabled3 ,
                                             string AV58Serasawwds_10_dynamicfiltersselector3 ,
                                             short AV59Serasawwds_11_dynamicfiltersoperator3 ,
                                             string AV60Serasawwds_12_serasanumeroproposta3 ,
                                             string AV62Serasawwds_14_tfclienterazaosocial_sel ,
                                             string AV61Serasawwds_13_tfclienterazaosocial ,
                                             string AV64Serasawwds_16_tfserasanumeroproposta_sel ,
                                             string AV63Serasawwds_15_tfserasanumeroproposta ,
                                             decimal AV65Serasawwds_17_tfserasapolitica ,
                                             decimal AV66Serasawwds_18_tfserasapolitica_to ,
                                             DateTime AV67Serasawwds_19_tfserasacreatedat ,
                                             DateTime AV68Serasawwds_20_tfserasacreatedat_to ,
                                             string AV70Serasawwds_22_tfserasatipovenda_sel ,
                                             string AV69Serasawwds_21_tfserasatipovenda ,
                                             string A170ClienteRazaoSocial ,
                                             string A663SerasaNumeroProposta ,
                                             decimal A664SerasaPolitica ,
                                             string A666SerasaTipoVenda ,
                                             DateTime A665SerasaCreatedAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.SerasaCreatedAt, T1.SerasaPolitica, T1.SerasaTipoVenda, T1.SerasaNumeroProposta, T2.ClienteRazaoSocial, T1.SerasaId FROM (Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV47Array_ClienteId, "T1.ClienteId IN (", ")")+")");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV49Serasawwds_1_filterfulltext) or ( T1.SerasaNumeroProposta like '%' || :lV49Serasawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.SerasaPolitica,'999999999990.99'), 2) like '%' || :lV49Serasawwds_1_filterfulltext) or ( T1.SerasaTipoVenda like '%' || :lV49Serasawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV51Serasawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV52Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV51Serasawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV52Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV53Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV55Serasawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV56Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV53Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV55Serasawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV56Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV57Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV59Serasawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV60Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV57Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV59Serasawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV60Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_14_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasawwds_13_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV61Serasawwds_13_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_14_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV62Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV62Serasawwds_14_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasawwds_16_tfserasanumeroproposta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasawwds_15_tfserasanumeroproposta)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV63Serasawwds_15_tfserasanumeroproposta)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasawwds_16_tfserasanumeroproposta_sel)) && ! ( StringUtil.StrCmp(AV64Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta = ( :AV64Serasawwds_16_tfserasanumeroproposta_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV64Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta IS NULL or (char_length(trim(trailing ' ' from T1.SerasaNumeroProposta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV65Serasawwds_17_tfserasapolitica) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica >= :AV65Serasawwds_17_tfserasapolitica)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV66Serasawwds_18_tfserasapolitica_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica <= :AV66Serasawwds_18_tfserasapolitica_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Serasawwds_19_tfserasacreatedat) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt >= :AV67Serasawwds_19_tfserasacreatedat)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Serasawwds_20_tfserasacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt <= :AV68Serasawwds_20_tfserasacreatedat_to)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_22_tfserasatipovenda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasawwds_21_tfserasatipovenda)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda like :lV69Serasawwds_21_tfserasatipovenda)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_22_tfserasatipovenda_sel)) && ! ( StringUtil.StrCmp(AV70Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda = ( :AV70Serasawwds_22_tfserasatipovenda_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV70Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda IS NULL or (char_length(trim(trailing ' ' from T1.SerasaTipoVenda))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SerasaNumeroProposta";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SerasaNumeroProposta DESC";
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
            scmdbuf += " ORDER BY T1.SerasaPolitica";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SerasaPolitica DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SerasaCreatedAt";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SerasaCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SerasaTipoVenda";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SerasaTipoVenda DESC";
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
                     return conditional_P00CL2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP00CL2;
          prmP00CL2 = new Object[] {
          new ParDef("lV49Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV52Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV61Serasawwds_13_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV62Serasawwds_14_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV63Serasawwds_15_tfserasanumeroproposta",GXType.VarChar,40,0) ,
          new ParDef("AV64Serasawwds_16_tfserasanumeroproposta_sel",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasawwds_17_tfserasapolitica",GXType.Number,15,2) ,
          new ParDef("AV66Serasawwds_18_tfserasapolitica_to",GXType.Number,15,2) ,
          new ParDef("AV67Serasawwds_19_tfserasacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV68Serasawwds_20_tfserasacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV69Serasawwds_21_tfserasatipovenda",GXType.VarChar,40,0) ,
          new ParDef("AV70Serasawwds_22_tfserasatipovenda_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CL2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
