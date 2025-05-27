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
   public class wpcontratostexport : GXProcedure
   {
      public wpcontratostexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpcontratostexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WpContratosTExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22ContratoNome1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ContratoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ContratoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23ContratoClienteDocumento1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ContratoClienteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ContratoClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27ContratoNome2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ContratoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27ContratoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28ContratoClienteDocumento2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ContratoClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ContratoClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32ContratoNome3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ContratoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32ContratoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33ContratoClienteDocumento3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ContratoClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33ContratoClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFContratoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFContratoNome_Sel)) ? "(Vazio)" : AV40TFContratoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFContratoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV48TFContratoSituacao_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação") ;
            AV13CellRow = GXt_int2;
            AV49i = 1;
            AV52GXV1 = 1;
            while ( AV52GXV1 <= AV48TFContratoSituacao_Sels.Count )
            {
               AV47TFContratoSituacao_Sel = ((string)AV48TFContratoSituacao_Sels.Item(AV52GXV1));
               if ( AV49i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmcontratosituacao.getDescription(context,AV47TFContratoSituacao_Sel);
               AV49i = (long)(AV49i+1);
               AV52GXV1 = (int)(AV52GXV1+1);
            }
         }
         if ( ! ( (0==AV50TFContratoCountAssinantes_F) && (0==AV51TFContratoCountAssinantes_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Participantes") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV50TFContratoCountAssinantes_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV51TFContratoCountAssinantes_F_To;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Situação";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Participantes";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Wpcontratostds_1_filterfulltext = AV19FilterFullText;
         AV55Wpcontratostds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV56Wpcontratostds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV57Wpcontratostds_4_contratonome1 = AV22ContratoNome1;
         AV58Wpcontratostds_5_contratoclientedocumento1 = AV23ContratoClienteDocumento1;
         AV59Wpcontratostds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV60Wpcontratostds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV61Wpcontratostds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV62Wpcontratostds_9_contratonome2 = AV27ContratoNome2;
         AV63Wpcontratostds_10_contratoclientedocumento2 = AV28ContratoClienteDocumento2;
         AV64Wpcontratostds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV65Wpcontratostds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV66Wpcontratostds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV67Wpcontratostds_14_contratonome3 = AV32ContratoNome3;
         AV68Wpcontratostds_15_contratoclientedocumento3 = AV33ContratoClienteDocumento3;
         AV69Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV70Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV71Wpcontratostds_18_tfcontratosituacao_sels = AV48TFContratoSituacao_Sels;
         AV72Wpcontratostds_19_tfcontratocountassinantes_f = AV50TFContratoCountAssinantes_F;
         AV73Wpcontratostds_20_tfcontratocountassinantes_f_to = AV51TFContratoCountAssinantes_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A471ContratoSituacao ,
                                              AV71Wpcontratostds_18_tfcontratosituacao_sels ,
                                              AV55Wpcontratostds_2_dynamicfiltersselector1 ,
                                              AV56Wpcontratostds_3_dynamicfiltersoperator1 ,
                                              AV57Wpcontratostds_4_contratonome1 ,
                                              AV58Wpcontratostds_5_contratoclientedocumento1 ,
                                              AV59Wpcontratostds_6_dynamicfiltersenabled2 ,
                                              AV60Wpcontratostds_7_dynamicfiltersselector2 ,
                                              AV61Wpcontratostds_8_dynamicfiltersoperator2 ,
                                              AV62Wpcontratostds_9_contratonome2 ,
                                              AV63Wpcontratostds_10_contratoclientedocumento2 ,
                                              AV64Wpcontratostds_11_dynamicfiltersenabled3 ,
                                              AV65Wpcontratostds_12_dynamicfiltersselector3 ,
                                              AV66Wpcontratostds_13_dynamicfiltersoperator3 ,
                                              AV67Wpcontratostds_14_contratonome3 ,
                                              AV68Wpcontratostds_15_contratoclientedocumento3 ,
                                              AV70Wpcontratostds_17_tfcontratonome_sel ,
                                              AV69Wpcontratostds_16_tfcontratonome ,
                                              AV71Wpcontratostds_18_tfcontratosituacao_sels.Count ,
                                              A228ContratoNome ,
                                              A475ContratoClienteDocumento ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV54Wpcontratostds_1_filterfulltext ,
                                              A1007ContratoCountAssinantes_F ,
                                              AV72Wpcontratostds_19_tfcontratocountassinantes_f ,
                                              AV73Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                              AV16ClienteId ,
                                              A473ContratoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpcontratostds_1_filterfulltext), "%", "");
         lV54Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpcontratostds_1_filterfulltext), "%", "");
         lV54Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpcontratostds_1_filterfulltext), "%", "");
         lV54Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpcontratostds_1_filterfulltext), "%", "");
         lV54Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wpcontratostds_1_filterfulltext), "%", "");
         lV57Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpcontratostds_4_contratonome1), "%", "");
         lV57Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpcontratostds_4_contratonome1), "%", "");
         lV58Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV58Wpcontratostds_5_contratoclientedocumento1), "%", "");
         lV58Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV58Wpcontratostds_5_contratoclientedocumento1), "%", "");
         lV62Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV62Wpcontratostds_9_contratonome2), "%", "");
         lV62Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV62Wpcontratostds_9_contratonome2), "%", "");
         lV63Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV63Wpcontratostds_10_contratoclientedocumento2), "%", "");
         lV63Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV63Wpcontratostds_10_contratoclientedocumento2), "%", "");
         lV67Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV67Wpcontratostds_14_contratonome3), "%", "");
         lV67Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV67Wpcontratostds_14_contratonome3), "%", "");
         lV68Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV68Wpcontratostds_15_contratoclientedocumento3), "%", "");
         lV68Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV68Wpcontratostds_15_contratoclientedocumento3), "%", "");
         lV69Wpcontratostds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_16_tfcontratonome), "%", "");
         /* Using cursor P00F13 */
         pr_default.execute(0, new Object[] {AV16ClienteId, AV54Wpcontratostds_1_filterfulltext, lV54Wpcontratostds_1_filterfulltext, lV54Wpcontratostds_1_filterfulltext, lV54Wpcontratostds_1_filterfulltext, lV54Wpcontratostds_1_filterfulltext, lV54Wpcontratostds_1_filterfulltext, AV72Wpcontratostds_19_tfcontratocountassinantes_f, AV72Wpcontratostds_19_tfcontratocountassinantes_f, AV73Wpcontratostds_20_tfcontratocountassinantes_f_to, AV73Wpcontratostds_20_tfcontratocountassinantes_f_to, lV57Wpcontratostds_4_contratonome1, lV57Wpcontratostds_4_contratonome1, lV58Wpcontratostds_5_contratoclientedocumento1, lV58Wpcontratostds_5_contratoclientedocumento1, lV62Wpcontratostds_9_contratonome2, lV62Wpcontratostds_9_contratonome2, lV63Wpcontratostds_10_contratoclientedocumento2, lV63Wpcontratostds_10_contratoclientedocumento2, lV67Wpcontratostds_14_contratonome3, lV67Wpcontratostds_14_contratonome3, lV68Wpcontratostds_15_contratoclientedocumento3, lV68Wpcontratostds_15_contratoclientedocumento3, lV69Wpcontratostds_16_tfcontratonome, AV70Wpcontratostds_17_tfcontratonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P00F13_A227ContratoId[0];
            n227ContratoId = P00F13_n227ContratoId[0];
            A473ContratoClienteId = P00F13_A473ContratoClienteId[0];
            n473ContratoClienteId = P00F13_n473ContratoClienteId[0];
            A475ContratoClienteDocumento = P00F13_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00F13_n475ContratoClienteDocumento[0];
            A471ContratoSituacao = P00F13_A471ContratoSituacao[0];
            n471ContratoSituacao = P00F13_n471ContratoSituacao[0];
            A228ContratoNome = P00F13_A228ContratoNome[0];
            n228ContratoNome = P00F13_n228ContratoNome[0];
            A1007ContratoCountAssinantes_F = P00F13_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = P00F13_n1007ContratoCountAssinantes_F[0];
            A475ContratoClienteDocumento = P00F13_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00F13_n475ContratoClienteDocumento[0];
            A1007ContratoCountAssinantes_F = P00F13_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = P00F13_n1007ContratoCountAssinantes_F[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A228ContratoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmcontratosituacao.getDescription(context,A471ContratoSituacao);
            if ( StringUtil.StrCmp(A471ContratoSituacao, "EmElaboracao") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 128, 128, 128);
            }
            else if ( StringUtil.StrCmp(A471ContratoSituacao, "ColetandoAssinatura") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A471ContratoSituacao, "Assinado") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A1007ContratoCountAssinantes_F;
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
         AV35Session.Set("WWPExportFilePath", AV11Filename);
         AV35Session.Set("WWPExportFileName", "WpContratosTExport.xlsx");
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
         if ( StringUtil.StrCmp(AV35Session.Get("WpContratosTGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpContratosTGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("WpContratosTGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV74GXV2 = 1;
         while ( AV74GXV2 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV74GXV2));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV39TFContratoNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV40TFContratoNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCONTRATOSITUACAO_SEL") == 0 )
            {
               AV46TFContratoSituacao_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV48TFContratoSituacao_Sels.FromJSonString(AV46TFContratoSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCONTRATOCOUNTASSINANTES_F") == 0 )
            {
               AV50TFContratoCountAssinantes_F = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFContratoCountAssinantes_F_To = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV16ClienteId = (int)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV74GXV2 = (int)(AV74GXV2+1);
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
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ContratoNome1 = "";
         AV23ContratoClienteDocumento1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27ContratoNome2 = "";
         AV28ContratoClienteDocumento2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32ContratoNome3 = "";
         AV33ContratoClienteDocumento3 = "";
         AV40TFContratoNome_Sel = "";
         AV39TFContratoNome = "";
         AV48TFContratoSituacao_Sels = new GxSimpleCollection<string>();
         AV47TFContratoSituacao_Sel = "";
         AV54Wpcontratostds_1_filterfulltext = "";
         AV55Wpcontratostds_2_dynamicfiltersselector1 = "";
         AV57Wpcontratostds_4_contratonome1 = "";
         AV58Wpcontratostds_5_contratoclientedocumento1 = "";
         AV60Wpcontratostds_7_dynamicfiltersselector2 = "";
         AV62Wpcontratostds_9_contratonome2 = "";
         AV63Wpcontratostds_10_contratoclientedocumento2 = "";
         AV65Wpcontratostds_12_dynamicfiltersselector3 = "";
         AV67Wpcontratostds_14_contratonome3 = "";
         AV68Wpcontratostds_15_contratoclientedocumento3 = "";
         AV69Wpcontratostds_16_tfcontratonome = "";
         AV70Wpcontratostds_17_tfcontratonome_sel = "";
         AV71Wpcontratostds_18_tfcontratosituacao_sels = new GxSimpleCollection<string>();
         lV54Wpcontratostds_1_filterfulltext = "";
         lV57Wpcontratostds_4_contratonome1 = "";
         lV58Wpcontratostds_5_contratoclientedocumento1 = "";
         lV62Wpcontratostds_9_contratonome2 = "";
         lV63Wpcontratostds_10_contratoclientedocumento2 = "";
         lV67Wpcontratostds_14_contratonome3 = "";
         lV68Wpcontratostds_15_contratoclientedocumento3 = "";
         lV69Wpcontratostds_16_tfcontratonome = "";
         A471ContratoSituacao = "";
         A228ContratoNome = "";
         A475ContratoClienteDocumento = "";
         P00F13_A227ContratoId = new int[1] ;
         P00F13_n227ContratoId = new bool[] {false} ;
         P00F13_A473ContratoClienteId = new int[1] ;
         P00F13_n473ContratoClienteId = new bool[] {false} ;
         P00F13_A475ContratoClienteDocumento = new string[] {""} ;
         P00F13_n475ContratoClienteDocumento = new bool[] {false} ;
         P00F13_A471ContratoSituacao = new string[] {""} ;
         P00F13_n471ContratoSituacao = new bool[] {false} ;
         P00F13_A228ContratoNome = new string[] {""} ;
         P00F13_n228ContratoNome = new bool[] {false} ;
         P00F13_A1007ContratoCountAssinantes_F = new short[1] ;
         P00F13_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         GXt_char1 = "";
         AV35Session = context.GetSession();
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFContratoSituacao_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcontratostexport__default(),
            new Object[][] {
                new Object[] {
               P00F13_A227ContratoId, P00F13_A473ContratoClienteId, P00F13_n473ContratoClienteId, P00F13_A475ContratoClienteDocumento, P00F13_n475ContratoClienteDocumento, P00F13_A471ContratoSituacao, P00F13_n471ContratoSituacao, P00F13_A228ContratoNome, P00F13_n228ContratoNome, P00F13_A1007ContratoCountAssinantes_F,
               P00F13_n1007ContratoCountAssinantes_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV50TFContratoCountAssinantes_F ;
      private short AV51TFContratoCountAssinantes_F_To ;
      private short GXt_int2 ;
      private short AV56Wpcontratostds_3_dynamicfiltersoperator1 ;
      private short AV61Wpcontratostds_8_dynamicfiltersoperator2 ;
      private short AV66Wpcontratostds_13_dynamicfiltersoperator3 ;
      private short AV72Wpcontratostds_19_tfcontratocountassinantes_f ;
      private short AV73Wpcontratostds_20_tfcontratocountassinantes_f_to ;
      private short AV17OrderedBy ;
      private short A1007ContratoCountAssinantes_F ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV52GXV1 ;
      private int AV71Wpcontratostds_18_tfcontratosituacao_sels_Count ;
      private int AV16ClienteId ;
      private int A473ContratoClienteId ;
      private int A227ContratoId ;
      private int AV74GXV2 ;
      private long AV49i ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV59Wpcontratostds_6_dynamicfiltersenabled2 ;
      private bool AV64Wpcontratostds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n227ContratoId ;
      private bool n473ContratoClienteId ;
      private bool n475ContratoClienteDocumento ;
      private bool n471ContratoSituacao ;
      private bool n228ContratoNome ;
      private bool n1007ContratoCountAssinantes_F ;
      private string AV46TFContratoSituacao_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22ContratoNome1 ;
      private string AV23ContratoClienteDocumento1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV27ContratoNome2 ;
      private string AV28ContratoClienteDocumento2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV32ContratoNome3 ;
      private string AV33ContratoClienteDocumento3 ;
      private string AV40TFContratoNome_Sel ;
      private string AV39TFContratoNome ;
      private string AV47TFContratoSituacao_Sel ;
      private string AV54Wpcontratostds_1_filterfulltext ;
      private string AV55Wpcontratostds_2_dynamicfiltersselector1 ;
      private string AV57Wpcontratostds_4_contratonome1 ;
      private string AV58Wpcontratostds_5_contratoclientedocumento1 ;
      private string AV60Wpcontratostds_7_dynamicfiltersselector2 ;
      private string AV62Wpcontratostds_9_contratonome2 ;
      private string AV63Wpcontratostds_10_contratoclientedocumento2 ;
      private string AV65Wpcontratostds_12_dynamicfiltersselector3 ;
      private string AV67Wpcontratostds_14_contratonome3 ;
      private string AV68Wpcontratostds_15_contratoclientedocumento3 ;
      private string AV69Wpcontratostds_16_tfcontratonome ;
      private string AV70Wpcontratostds_17_tfcontratonome_sel ;
      private string lV54Wpcontratostds_1_filterfulltext ;
      private string lV57Wpcontratostds_4_contratonome1 ;
      private string lV58Wpcontratostds_5_contratoclientedocumento1 ;
      private string lV62Wpcontratostds_9_contratonome2 ;
      private string lV63Wpcontratostds_10_contratoclientedocumento2 ;
      private string lV67Wpcontratostds_14_contratonome3 ;
      private string lV68Wpcontratostds_15_contratoclientedocumento3 ;
      private string lV69Wpcontratostds_16_tfcontratonome ;
      private string A471ContratoSituacao ;
      private string A228ContratoNome ;
      private string A475ContratoClienteDocumento ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV48TFContratoSituacao_Sels ;
      private GxSimpleCollection<string> AV71Wpcontratostds_18_tfcontratosituacao_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00F13_A227ContratoId ;
      private bool[] P00F13_n227ContratoId ;
      private int[] P00F13_A473ContratoClienteId ;
      private bool[] P00F13_n473ContratoClienteId ;
      private string[] P00F13_A475ContratoClienteDocumento ;
      private bool[] P00F13_n475ContratoClienteDocumento ;
      private string[] P00F13_A471ContratoSituacao ;
      private bool[] P00F13_n471ContratoSituacao ;
      private string[] P00F13_A228ContratoNome ;
      private bool[] P00F13_n228ContratoNome ;
      private short[] P00F13_A1007ContratoCountAssinantes_F ;
      private bool[] P00F13_n1007ContratoCountAssinantes_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wpcontratostexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F13( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV71Wpcontratostds_18_tfcontratosituacao_sels ,
                                             string AV55Wpcontratostds_2_dynamicfiltersselector1 ,
                                             short AV56Wpcontratostds_3_dynamicfiltersoperator1 ,
                                             string AV57Wpcontratostds_4_contratonome1 ,
                                             string AV58Wpcontratostds_5_contratoclientedocumento1 ,
                                             bool AV59Wpcontratostds_6_dynamicfiltersenabled2 ,
                                             string AV60Wpcontratostds_7_dynamicfiltersselector2 ,
                                             short AV61Wpcontratostds_8_dynamicfiltersoperator2 ,
                                             string AV62Wpcontratostds_9_contratonome2 ,
                                             string AV63Wpcontratostds_10_contratoclientedocumento2 ,
                                             bool AV64Wpcontratostds_11_dynamicfiltersenabled3 ,
                                             string AV65Wpcontratostds_12_dynamicfiltersselector3 ,
                                             short AV66Wpcontratostds_13_dynamicfiltersoperator3 ,
                                             string AV67Wpcontratostds_14_contratonome3 ,
                                             string AV68Wpcontratostds_15_contratoclientedocumento3 ,
                                             string AV70Wpcontratostds_17_tfcontratonome_sel ,
                                             string AV69Wpcontratostds_16_tfcontratonome ,
                                             int AV71Wpcontratostds_18_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV54Wpcontratostds_1_filterfulltext ,
                                             short A1007ContratoCountAssinantes_F ,
                                             short AV72Wpcontratostds_19_tfcontratocountassinantes_f ,
                                             short AV73Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                             int AV16ClienteId ,
                                             int A473ContratoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[25];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ContratoClienteId AS ContratoClienteId, T2.ClienteDocumento AS ContratoClienteDocumento, T1.ContratoSituacao, T1.ContratoNome, COALESCE( T3.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM ((Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T5.ContratoId, T4.ClienteId FROM (AssinaturaParticipante T4 LEFT JOIN Assinatura T5 ON T5.AssinaturaId = T4.AssinaturaId) WHERE T1.ContratoId = T5.ContratoId and T1.ContratoClienteId = T4.ClienteId GROUP BY T5.ContratoId, T4.ClienteId ) T3 ON T3.ContratoId = T1.ContratoId AND T3.ClienteId = T1.ContratoClienteId)";
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV16ClienteId)");
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV54Wpcontratostds_1_filterfulltext))=0) or ( ( T1.ContratoNome like '%' || :lV54Wpcontratostds_1_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV54Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV54Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV54Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')) or ( SUBSTR(TO_CHAR(COALESCE( T3.ContratoCountAssinantes_F, 0),'9999'), 2) like '%' || :lV54Wpcontratostds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV72Wpcontratostds_19_tfcontratocountassinantes_f = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) >= :AV72Wpcontratostds_19_tfcontratocountassinantes_f))");
         AddWhere(sWhereString, "((:AV73Wpcontratostds_20_tfcontratocountassinantes_f_to = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) <= :AV73Wpcontratostds_20_tfcontratocountassinantes_f_to))");
         if ( ( StringUtil.StrCmp(AV55Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV56Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV57Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV56Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV57Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV56Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV58Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV56Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV58Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV59Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV61Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV62Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV59Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV61Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV62Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV59Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV63Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV59Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV63Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV64Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV66Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV67Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV64Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV66Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV67Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV64Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV66Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV68Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV64Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV66Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV68Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpcontratostds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV69Wpcontratostds_16_tfcontratonome)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpcontratostds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV70Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV70Wpcontratostds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV71Wpcontratostds_18_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71Wpcontratostds_18_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContratoNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContratoNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContratoSituacao";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContratoSituacao DESC";
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
                     return conditional_P00F13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
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
          Object[] prmP00F13;
          prmP00F13 = new Object[] {
          new ParDef("AV16ClienteId",GXType.Int32,9,0) ,
          new ParDef("AV54Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV72Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV72Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV73Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV73Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("lV57Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV57Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV58Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV58Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV62Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV62Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV63Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV63Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV67Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV68Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV68Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV69Wpcontratostds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV70Wpcontratostds_17_tfcontratonome_sel",GXType.VarChar,125,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F13,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
