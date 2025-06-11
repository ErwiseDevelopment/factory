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
   public class assinaturawwexport : GXProcedure
   {
      public assinaturawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "AssinaturaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "ASSINATURASTATUS") == 0 )
            {
               AV21AssinaturaStatus1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AssinaturaStatus1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Status";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AssinaturaStatus1)) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturastatus.getDescription(context,AV21AssinaturaStatus1);
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV22ContratoNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ContratoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ContratoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "ASSINATURASTATUS") == 0 )
               {
                  AV26AssinaturaStatus2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AssinaturaStatus2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Status";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AssinaturaStatus2)) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturastatus.getDescription(context,AV26AssinaturaStatus2);
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV27ContratoNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ContratoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27ContratoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "ASSINATURASTATUS") == 0 )
                  {
                     AV31AssinaturaStatus3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31AssinaturaStatus3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Status";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31AssinaturaStatus3)) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturastatus.getDescription(context,AV31AssinaturaStatus3);
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV32ContratoNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ContratoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32ContratoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome_Sel)) ? "(Vazio)" : AV39TFContratoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFContratoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFContratoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV42TFAssinaturaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação") ;
            AV13CellRow = GXt_int2;
            AV47i = 1;
            AV54GXV1 = 1;
            while ( AV54GXV1 <= AV42TFAssinaturaStatus_Sels.Count )
            {
               AV41TFAssinaturaStatus_Sel = ((string)AV42TFAssinaturaStatus_Sels.Item(AV54GXV1));
               if ( AV47i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmassinaturastatus.getDescription(context,AV41TFAssinaturaStatus_Sel);
               AV47i = (long)(AV47i+1);
               AV54GXV1 = (int)(AV54GXV1+1);
            }
         }
         if ( ! ( (DateTime.MinValue==AV48TFContratoDataInicial) && (DateTime.MinValue==AV49TFContratoDataInicial_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vigência inicial") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV48TFContratoDataInicial ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV49TFContratoDataInicial_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV50TFContratoDataFinal) && (DateTime.MinValue==AV51TFContratoDataFinal_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Final") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV50TFContratoDataFinal ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TFContratoDataFinal_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV43TFAssinaturaFinalizadoData) && (DateTime.MinValue==AV44TFAssinaturaFinalizadoData_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Assinatura finalizada") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV43TFAssinaturaFinalizadoData;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV44TFAssinaturaFinalizadoData_To;
         }
         if ( ! ( (0==AV45TFAssinaturaParticipantes_F) && (0==AV46TFAssinaturaParticipantes_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Participantes") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV45TFAssinaturaParticipantes_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV46TFAssinaturaParticipantes_F_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Contrato";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Situação";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Vigência inicial";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Final";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Assinatura finalizada";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Participantes";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Assinaturawwds_1_filterfulltext = AV18FilterFullText;
         AV57Assinaturawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV58Assinaturawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV59Assinaturawwds_4_assinaturastatus1 = AV21AssinaturaStatus1;
         AV60Assinaturawwds_5_contratonome1 = AV22ContratoNome1;
         AV61Assinaturawwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV62Assinaturawwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV63Assinaturawwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV64Assinaturawwds_9_assinaturastatus2 = AV26AssinaturaStatus2;
         AV65Assinaturawwds_10_contratonome2 = AV27ContratoNome2;
         AV66Assinaturawwds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV67Assinaturawwds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV68Assinaturawwds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV69Assinaturawwds_14_assinaturastatus3 = AV31AssinaturaStatus3;
         AV70Assinaturawwds_15_contratonome3 = AV32ContratoNome3;
         AV71Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV72Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV73Assinaturawwds_18_tfassinaturastatus_sels = AV42TFAssinaturaStatus_Sels;
         AV74Assinaturawwds_19_tfcontratodatainicial = AV48TFContratoDataInicial;
         AV75Assinaturawwds_20_tfcontratodatainicial_to = AV49TFContratoDataInicial_To;
         AV76Assinaturawwds_21_tfcontratodatafinal = AV50TFContratoDataFinal;
         AV77Assinaturawwds_22_tfcontratodatafinal_to = AV51TFContratoDataFinal_To;
         AV78Assinaturawwds_23_tfassinaturafinalizadodata = AV43TFAssinaturaFinalizadoData;
         AV79Assinaturawwds_24_tfassinaturafinalizadodata_to = AV44TFAssinaturaFinalizadoData_To;
         AV80Assinaturawwds_25_tfassinaturaparticipantes_f = AV45TFAssinaturaParticipantes_F;
         AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV46TFAssinaturaParticipantes_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A239AssinaturaStatus ,
                                              AV73Assinaturawwds_18_tfassinaturastatus_sels ,
                                              AV57Assinaturawwds_2_dynamicfiltersselector1 ,
                                              AV59Assinaturawwds_4_assinaturastatus1 ,
                                              AV58Assinaturawwds_3_dynamicfiltersoperator1 ,
                                              AV60Assinaturawwds_5_contratonome1 ,
                                              AV61Assinaturawwds_6_dynamicfiltersenabled2 ,
                                              AV62Assinaturawwds_7_dynamicfiltersselector2 ,
                                              AV64Assinaturawwds_9_assinaturastatus2 ,
                                              AV63Assinaturawwds_8_dynamicfiltersoperator2 ,
                                              AV65Assinaturawwds_10_contratonome2 ,
                                              AV66Assinaturawwds_11_dynamicfiltersenabled3 ,
                                              AV67Assinaturawwds_12_dynamicfiltersselector3 ,
                                              AV69Assinaturawwds_14_assinaturastatus3 ,
                                              AV68Assinaturawwds_13_dynamicfiltersoperator3 ,
                                              AV70Assinaturawwds_15_contratonome3 ,
                                              AV72Assinaturawwds_17_tfcontratonome_sel ,
                                              AV71Assinaturawwds_16_tfcontratonome ,
                                              AV73Assinaturawwds_18_tfassinaturastatus_sels.Count ,
                                              AV74Assinaturawwds_19_tfcontratodatainicial ,
                                              AV75Assinaturawwds_20_tfcontratodatainicial_to ,
                                              AV76Assinaturawwds_21_tfcontratodatafinal ,
                                              AV77Assinaturawwds_22_tfcontratodatafinal_to ,
                                              AV78Assinaturawwds_23_tfassinaturafinalizadodata ,
                                              AV79Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                              AV52AssinaturaStatus ,
                                              A228ContratoNome ,
                                              A362ContratoDataInicial ,
                                              A363ContratoDataFinal ,
                                              A366AssinaturaFinalizadoData ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV56Assinaturawwds_1_filterfulltext ,
                                              A367AssinaturaParticipantes_F ,
                                              AV80Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                              AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV56Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Assinaturawwds_1_filterfulltext), "%", "");
         lV60Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV60Assinaturawwds_5_contratonome1), "%", "");
         lV60Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV60Assinaturawwds_5_contratonome1), "%", "");
         lV65Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV65Assinaturawwds_10_contratonome2), "%", "");
         lV65Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV65Assinaturawwds_10_contratonome2), "%", "");
         lV70Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV70Assinaturawwds_15_contratonome3), "%", "");
         lV70Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV70Assinaturawwds_15_contratonome3), "%", "");
         lV71Assinaturawwds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV71Assinaturawwds_16_tfcontratonome), "%", "");
         /* Using cursor P00903 */
         pr_default.execute(0, new Object[] {AV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, lV56Assinaturawwds_1_filterfulltext, AV80Assinaturawwds_25_tfassinaturaparticipantes_f, AV80Assinaturawwds_25_tfassinaturaparticipantes_f, AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV59Assinaturawwds_4_assinaturastatus1, lV60Assinaturawwds_5_contratonome1, lV60Assinaturawwds_5_contratonome1, AV64Assinaturawwds_9_assinaturastatus2, lV65Assinaturawwds_10_contratonome2, lV65Assinaturawwds_10_contratonome2, AV69Assinaturawwds_14_assinaturastatus3, lV70Assinaturawwds_15_contratonome3, lV70Assinaturawwds_15_contratonome3, lV71Assinaturawwds_16_tfcontratonome, AV72Assinaturawwds_17_tfcontratonome_sel, AV74Assinaturawwds_19_tfcontratodatainicial, AV75Assinaturawwds_20_tfcontratodatainicial_to, AV76Assinaturawwds_21_tfcontratodatafinal, AV77Assinaturawwds_22_tfcontratodatafinal_to, AV78Assinaturawwds_23_tfassinaturafinalizadodata, AV79Assinaturawwds_24_tfassinaturafinalizadodata_to, AV52AssinaturaStatus});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P00903_A227ContratoId[0];
            n227ContratoId = P00903_n227ContratoId[0];
            A366AssinaturaFinalizadoData = P00903_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = P00903_n366AssinaturaFinalizadoData[0];
            A363ContratoDataFinal = P00903_A363ContratoDataFinal[0];
            n363ContratoDataFinal = P00903_n363ContratoDataFinal[0];
            A362ContratoDataInicial = P00903_A362ContratoDataInicial[0];
            n362ContratoDataInicial = P00903_n362ContratoDataInicial[0];
            A239AssinaturaStatus = P00903_A239AssinaturaStatus[0];
            n239AssinaturaStatus = P00903_n239AssinaturaStatus[0];
            A228ContratoNome = P00903_A228ContratoNome[0];
            n228ContratoNome = P00903_n228ContratoNome[0];
            A238AssinaturaId = P00903_A238AssinaturaId[0];
            n238AssinaturaId = P00903_n238AssinaturaId[0];
            A367AssinaturaParticipantes_F = P00903_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = P00903_n367AssinaturaParticipantes_F[0];
            A363ContratoDataFinal = P00903_A363ContratoDataFinal[0];
            n363ContratoDataFinal = P00903_n363ContratoDataFinal[0];
            A362ContratoDataInicial = P00903_A362ContratoDataInicial[0];
            n362ContratoDataInicial = P00903_n362ContratoDataInicial[0];
            A228ContratoNome = P00903_A228ContratoNome[0];
            n228ContratoNome = P00903_n228ContratoNome[0];
            A367AssinaturaParticipantes_F = P00903_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = P00903_n367AssinaturaParticipantes_F[0];
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
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturastatus.getDescription(context,A239AssinaturaStatus);
            GXt_dtime3 = DateTimeUtil.ResetTime( A362ContratoDataInicial ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( A363ContratoDataFinal ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = A366AssinaturaFinalizadoData;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A367AssinaturaParticipantes_F;
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
         AV34Session.Set("WWPExportFilePath", AV11Filename);
         AV34Session.Set("WWPExportFileName", "AssinaturaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV34Session.Get("AssinaturaWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AssinaturaWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("AssinaturaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV82GXV2 = 1;
         while ( AV82GXV2 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV82GXV2));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV38TFContratoNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV39TFContratoNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURASTATUS_SEL") == 0 )
            {
               AV40TFAssinaturaStatus_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV42TFAssinaturaStatus_Sels.FromJSonString(AV40TFAssinaturaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAINICIAL") == 0 )
            {
               AV48TFContratoDataInicial = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV49TFContratoDataInicial_To = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAFINAL") == 0 )
            {
               AV50TFContratoDataFinal = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV51TFContratoDataFinal_To = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURAFINALIZADODATA") == 0 )
            {
               AV43TFAssinaturaFinalizadoData = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV44TFAssinaturaFinalizadoData_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTES_F") == 0 )
            {
               AV45TFAssinaturaParticipantes_F = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV46TFAssinaturaParticipantes_F_To = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURASTATUS") == 0 )
            {
               AV52AssinaturaStatus = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&VIGENTE") == 0 )
            {
               AV53Vigente = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV82GXV2 = (int)(AV82GXV2+1);
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
         AV21AssinaturaStatus1 = "";
         AV22ContratoNome1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26AssinaturaStatus2 = "";
         AV27ContratoNome2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31AssinaturaStatus3 = "";
         AV32ContratoNome3 = "";
         AV39TFContratoNome_Sel = "";
         AV38TFContratoNome = "";
         AV42TFAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV41TFAssinaturaStatus_Sel = "";
         AV48TFContratoDataInicial = DateTime.MinValue;
         AV49TFContratoDataInicial_To = DateTime.MinValue;
         AV50TFContratoDataFinal = DateTime.MinValue;
         AV51TFContratoDataFinal_To = DateTime.MinValue;
         AV43TFAssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         AV44TFAssinaturaFinalizadoData_To = (DateTime)(DateTime.MinValue);
         AV56Assinaturawwds_1_filterfulltext = "";
         AV57Assinaturawwds_2_dynamicfiltersselector1 = "";
         AV59Assinaturawwds_4_assinaturastatus1 = "";
         AV60Assinaturawwds_5_contratonome1 = "";
         AV62Assinaturawwds_7_dynamicfiltersselector2 = "";
         AV64Assinaturawwds_9_assinaturastatus2 = "";
         AV65Assinaturawwds_10_contratonome2 = "";
         AV67Assinaturawwds_12_dynamicfiltersselector3 = "";
         AV69Assinaturawwds_14_assinaturastatus3 = "";
         AV70Assinaturawwds_15_contratonome3 = "";
         AV71Assinaturawwds_16_tfcontratonome = "";
         AV72Assinaturawwds_17_tfcontratonome_sel = "";
         AV73Assinaturawwds_18_tfassinaturastatus_sels = new GxSimpleCollection<string>();
         AV74Assinaturawwds_19_tfcontratodatainicial = DateTime.MinValue;
         AV75Assinaturawwds_20_tfcontratodatainicial_to = DateTime.MinValue;
         AV76Assinaturawwds_21_tfcontratodatafinal = DateTime.MinValue;
         AV77Assinaturawwds_22_tfcontratodatafinal_to = DateTime.MinValue;
         AV78Assinaturawwds_23_tfassinaturafinalizadodata = (DateTime)(DateTime.MinValue);
         AV79Assinaturawwds_24_tfassinaturafinalizadodata_to = (DateTime)(DateTime.MinValue);
         lV56Assinaturawwds_1_filterfulltext = "";
         lV60Assinaturawwds_5_contratonome1 = "";
         lV65Assinaturawwds_10_contratonome2 = "";
         lV70Assinaturawwds_15_contratonome3 = "";
         lV71Assinaturawwds_16_tfcontratonome = "";
         A239AssinaturaStatus = "";
         AV52AssinaturaStatus = "";
         A228ContratoNome = "";
         A362ContratoDataInicial = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         P00903_A227ContratoId = new int[1] ;
         P00903_n227ContratoId = new bool[] {false} ;
         P00903_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         P00903_n366AssinaturaFinalizadoData = new bool[] {false} ;
         P00903_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         P00903_n363ContratoDataFinal = new bool[] {false} ;
         P00903_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         P00903_n362ContratoDataInicial = new bool[] {false} ;
         P00903_A239AssinaturaStatus = new string[] {""} ;
         P00903_n239AssinaturaStatus = new bool[] {false} ;
         P00903_A228ContratoNome = new string[] {""} ;
         P00903_n228ContratoNome = new bool[] {false} ;
         P00903_A238AssinaturaId = new long[1] ;
         P00903_n238AssinaturaId = new bool[] {false} ;
         P00903_A367AssinaturaParticipantes_F = new short[1] ;
         P00903_n367AssinaturaParticipantes_F = new bool[] {false} ;
         GXt_char1 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40TFAssinaturaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturawwexport__default(),
            new Object[][] {
                new Object[] {
               P00903_A227ContratoId, P00903_n227ContratoId, P00903_A366AssinaturaFinalizadoData, P00903_n366AssinaturaFinalizadoData, P00903_A363ContratoDataFinal, P00903_n363ContratoDataFinal, P00903_A362ContratoDataInicial, P00903_n362ContratoDataInicial, P00903_A239AssinaturaStatus, P00903_n239AssinaturaStatus,
               P00903_A228ContratoNome, P00903_n228ContratoNome, P00903_A238AssinaturaId, P00903_A367AssinaturaParticipantes_F, P00903_n367AssinaturaParticipantes_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV45TFAssinaturaParticipantes_F ;
      private short AV46TFAssinaturaParticipantes_F_To ;
      private short GXt_int2 ;
      private short AV58Assinaturawwds_3_dynamicfiltersoperator1 ;
      private short AV63Assinaturawwds_8_dynamicfiltersoperator2 ;
      private short AV68Assinaturawwds_13_dynamicfiltersoperator3 ;
      private short AV80Assinaturawwds_25_tfassinaturaparticipantes_f ;
      private short AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to ;
      private short AV16OrderedBy ;
      private short A367AssinaturaParticipantes_F ;
      private short AV53Vigente ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV54GXV1 ;
      private int AV73Assinaturawwds_18_tfassinaturastatus_sels_Count ;
      private int A227ContratoId ;
      private int AV82GXV2 ;
      private long AV47i ;
      private long A238AssinaturaId ;
      private string GXt_char1 ;
      private DateTime AV43TFAssinaturaFinalizadoData ;
      private DateTime AV44TFAssinaturaFinalizadoData_To ;
      private DateTime AV78Assinaturawwds_23_tfassinaturafinalizadodata ;
      private DateTime AV79Assinaturawwds_24_tfassinaturafinalizadodata_to ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime GXt_dtime3 ;
      private DateTime AV48TFContratoDataInicial ;
      private DateTime AV49TFContratoDataInicial_To ;
      private DateTime AV50TFContratoDataFinal ;
      private DateTime AV51TFContratoDataFinal_To ;
      private DateTime AV74Assinaturawwds_19_tfcontratodatainicial ;
      private DateTime AV75Assinaturawwds_20_tfcontratodatainicial_to ;
      private DateTime AV76Assinaturawwds_21_tfcontratodatafinal ;
      private DateTime AV77Assinaturawwds_22_tfcontratodatafinal_to ;
      private DateTime A362ContratoDataInicial ;
      private DateTime A363ContratoDataFinal ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV61Assinaturawwds_6_dynamicfiltersenabled2 ;
      private bool AV66Assinaturawwds_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n227ContratoId ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n363ContratoDataFinal ;
      private bool n362ContratoDataInicial ;
      private bool n239AssinaturaStatus ;
      private bool n228ContratoNome ;
      private bool n238AssinaturaId ;
      private bool n367AssinaturaParticipantes_F ;
      private string AV40TFAssinaturaStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21AssinaturaStatus1 ;
      private string AV22ContratoNome1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26AssinaturaStatus2 ;
      private string AV27ContratoNome2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV31AssinaturaStatus3 ;
      private string AV32ContratoNome3 ;
      private string AV39TFContratoNome_Sel ;
      private string AV38TFContratoNome ;
      private string AV41TFAssinaturaStatus_Sel ;
      private string AV56Assinaturawwds_1_filterfulltext ;
      private string AV57Assinaturawwds_2_dynamicfiltersselector1 ;
      private string AV59Assinaturawwds_4_assinaturastatus1 ;
      private string AV60Assinaturawwds_5_contratonome1 ;
      private string AV62Assinaturawwds_7_dynamicfiltersselector2 ;
      private string AV64Assinaturawwds_9_assinaturastatus2 ;
      private string AV65Assinaturawwds_10_contratonome2 ;
      private string AV67Assinaturawwds_12_dynamicfiltersselector3 ;
      private string AV69Assinaturawwds_14_assinaturastatus3 ;
      private string AV70Assinaturawwds_15_contratonome3 ;
      private string AV71Assinaturawwds_16_tfcontratonome ;
      private string AV72Assinaturawwds_17_tfcontratonome_sel ;
      private string lV56Assinaturawwds_1_filterfulltext ;
      private string lV60Assinaturawwds_5_contratonome1 ;
      private string lV65Assinaturawwds_10_contratonome2 ;
      private string lV70Assinaturawwds_15_contratonome3 ;
      private string lV71Assinaturawwds_16_tfcontratonome ;
      private string A239AssinaturaStatus ;
      private string AV52AssinaturaStatus ;
      private string A228ContratoNome ;
      private IGxSession AV34Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV42TFAssinaturaStatus_Sels ;
      private GxSimpleCollection<string> AV73Assinaturawwds_18_tfassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00903_A227ContratoId ;
      private bool[] P00903_n227ContratoId ;
      private DateTime[] P00903_A366AssinaturaFinalizadoData ;
      private bool[] P00903_n366AssinaturaFinalizadoData ;
      private DateTime[] P00903_A363ContratoDataFinal ;
      private bool[] P00903_n363ContratoDataFinal ;
      private DateTime[] P00903_A362ContratoDataInicial ;
      private bool[] P00903_n362ContratoDataInicial ;
      private string[] P00903_A239AssinaturaStatus ;
      private bool[] P00903_n239AssinaturaStatus ;
      private string[] P00903_A228ContratoNome ;
      private bool[] P00903_n228ContratoNome ;
      private long[] P00903_A238AssinaturaId ;
      private bool[] P00903_n238AssinaturaId ;
      private short[] P00903_A367AssinaturaParticipantes_F ;
      private bool[] P00903_n367AssinaturaParticipantes_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class assinaturawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00903( IGxContext context ,
                                             string A239AssinaturaStatus ,
                                             GxSimpleCollection<string> AV73Assinaturawwds_18_tfassinaturastatus_sels ,
                                             string AV57Assinaturawwds_2_dynamicfiltersselector1 ,
                                             string AV59Assinaturawwds_4_assinaturastatus1 ,
                                             short AV58Assinaturawwds_3_dynamicfiltersoperator1 ,
                                             string AV60Assinaturawwds_5_contratonome1 ,
                                             bool AV61Assinaturawwds_6_dynamicfiltersenabled2 ,
                                             string AV62Assinaturawwds_7_dynamicfiltersselector2 ,
                                             string AV64Assinaturawwds_9_assinaturastatus2 ,
                                             short AV63Assinaturawwds_8_dynamicfiltersoperator2 ,
                                             string AV65Assinaturawwds_10_contratonome2 ,
                                             bool AV66Assinaturawwds_11_dynamicfiltersenabled3 ,
                                             string AV67Assinaturawwds_12_dynamicfiltersselector3 ,
                                             string AV69Assinaturawwds_14_assinaturastatus3 ,
                                             short AV68Assinaturawwds_13_dynamicfiltersoperator3 ,
                                             string AV70Assinaturawwds_15_contratonome3 ,
                                             string AV72Assinaturawwds_17_tfcontratonome_sel ,
                                             string AV71Assinaturawwds_16_tfcontratonome ,
                                             int AV73Assinaturawwds_18_tfassinaturastatus_sels_Count ,
                                             DateTime AV74Assinaturawwds_19_tfcontratodatainicial ,
                                             DateTime AV75Assinaturawwds_20_tfcontratodatainicial_to ,
                                             DateTime AV76Assinaturawwds_21_tfcontratodatafinal ,
                                             DateTime AV77Assinaturawwds_22_tfcontratodatafinal_to ,
                                             DateTime AV78Assinaturawwds_23_tfassinaturafinalizadodata ,
                                             DateTime AV79Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                             string AV52AssinaturaStatus ,
                                             string A228ContratoNome ,
                                             DateTime A362ContratoDataInicial ,
                                             DateTime A363ContratoDataFinal ,
                                             DateTime A366AssinaturaFinalizadoData ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV56Assinaturawwds_1_filterfulltext ,
                                             short A367AssinaturaParticipantes_F ,
                                             short AV80Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                             short AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[30];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.AssinaturaFinalizadoData, T2.ContratoDataFinal, T2.ContratoDataInicial, T1.AssinaturaStatus, T2.ContratoNome, T1.AssinaturaId, COALESCE( T3.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM ((Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE T1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T3 ON T3.AssinaturaId = T1.AssinaturaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV56Assinaturawwds_1_filterfulltext))=0) or ( ( T2.ContratoNome like '%' || :lV56Assinaturawwds_1_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV56Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV56Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV56Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV56Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV56Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.AssinaturaParticipantes_F, 0),'9999'), 2) like '%' || :lV56Assinaturawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV80Assinaturawwds_25_tfassinaturaparticipantes_f = 0) or ( COALESCE( T3.AssinaturaParticipantes_F, 0) >= :AV80Assinaturawwds_25_tfassinaturaparticipantes_f))");
         AddWhere(sWhereString, "((:AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to = 0) or ( COALESCE( T3.AssinaturaParticipantes_F, 0) <= :AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to))");
         if ( ( StringUtil.StrCmp(AV57Assinaturawwds_2_dynamicfiltersselector1, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Assinaturawwds_4_assinaturastatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV59Assinaturawwds_4_assinaturastatus1))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV58Assinaturawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV60Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV58Assinaturawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV60Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV61Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Assinaturawwds_7_dynamicfiltersselector2, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Assinaturawwds_9_assinaturastatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV64Assinaturawwds_9_assinaturastatus2))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV61Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV63Assinaturawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV65Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV61Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV63Assinaturawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV65Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV66Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Assinaturawwds_12_dynamicfiltersselector3, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Assinaturawwds_14_assinaturastatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV69Assinaturawwds_14_assinaturastatus3))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV66Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV68Assinaturawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV70Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV66Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV68Assinaturawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV70Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Assinaturawwds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Assinaturawwds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV71Assinaturawwds_16_tfcontratonome)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Assinaturawwds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV72Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV72Assinaturawwds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV72Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( AV73Assinaturawwds_18_tfassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV73Assinaturawwds_18_tfassinaturastatus_sels, "T1.AssinaturaStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV74Assinaturawwds_19_tfcontratodatainicial) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial >= :AV74Assinaturawwds_19_tfcontratodatainicial)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Assinaturawwds_20_tfcontratodatainicial_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial <= :AV75Assinaturawwds_20_tfcontratodatainicial_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Assinaturawwds_21_tfcontratodatafinal) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataFinal >= :AV76Assinaturawwds_21_tfcontratodatafinal)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Assinaturawwds_22_tfcontratodatafinal_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataFinal <= :AV77Assinaturawwds_22_tfcontratodatafinal_to)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Assinaturawwds_23_tfassinaturafinalizadodata) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData >= :AV78Assinaturawwds_23_tfassinaturafinalizadodata)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Assinaturawwds_24_tfassinaturafinalizadodata_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData <= :AV79Assinaturawwds_24_tfassinaturafinalizadodata_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52AssinaturaStatus)) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV52AssinaturaStatus))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ContratoNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ContratoNome DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaStatus";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaStatus DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ContratoDataInicial";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ContratoDataInicial DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ContratoDataFinal";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ContratoDataFinal DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaFinalizadoData";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaFinalizadoData DESC";
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
                     return conditional_P00903(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] );
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
          Object[] prmP00903;
          prmP00903 = new Object[] {
          new ParDef("AV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV80Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV80Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV81Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV59Assinaturawwds_4_assinaturastatus1",GXType.VarChar,40,0) ,
          new ParDef("lV60Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV60Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("AV64Assinaturawwds_9_assinaturastatus2",GXType.VarChar,40,0) ,
          new ParDef("lV65Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV65Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("AV69Assinaturawwds_14_assinaturastatus3",GXType.VarChar,40,0) ,
          new ParDef("lV70Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV70Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV71Assinaturawwds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV72Assinaturawwds_17_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV74Assinaturawwds_19_tfcontratodatainicial",GXType.Date,8,0) ,
          new ParDef("AV75Assinaturawwds_20_tfcontratodatainicial_to",GXType.Date,8,0) ,
          new ParDef("AV76Assinaturawwds_21_tfcontratodatafinal",GXType.Date,8,0) ,
          new ParDef("AV77Assinaturawwds_22_tfcontratodatafinal_to",GXType.Date,8,0) ,
          new ParDef("AV78Assinaturawwds_23_tfassinaturafinalizadodata",GXType.DateTime,8,5) ,
          new ParDef("AV79Assinaturawwds_24_tfassinaturafinalizadodata_to",GXType.DateTime,8,5) ,
          new ParDef("AV52AssinaturaStatus",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00903", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00903,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
