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
   public class reembolsowwexport : GXProcedure
   {
      public reembolsowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ReembolsoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21ReembolsoPropostaPacienteClienteRazaoSocial1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ReembolsoPropostaPacienteClienteRazaoSocial1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razao Social", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razao Social", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ReembolsoPropostaPacienteClienteRazaoSocial1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV53WorkflowConvenioDesc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53WorkflowConvenioDesc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53WorkflowConvenioDesc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25ReembolsoPropostaPacienteClienteRazaoSocial2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ReembolsoPropostaPacienteClienteRazaoSocial2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razao Social", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razao Social", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ReembolsoPropostaPacienteClienteRazaoSocial2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV54WorkflowConvenioDesc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54WorkflowConvenioDesc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54WorkflowConvenioDesc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29ReembolsoPropostaPacienteClienteRazaoSocial3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ReembolsoPropostaPacienteClienteRazaoSocial3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razao Social", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Razao Social", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ReembolsoPropostaPacienteClienteRazaoSocial3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV55WorkflowConvenioDesc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55WorkflowConvenioDesc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Passo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55WorkflowConvenioDesc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel)) ? "(Vazio)" : AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReembolsoPropostaPacienteClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFReembolsoPropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFReembolsoProtocolo_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Protocolo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFReembolsoProtocolo_Sel)) ? "(Vazio)" : AV38TFReembolsoProtocolo_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFReembolsoProtocolo)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Protocolo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFReembolsoProtocolo, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV39TFReembolsoCreatedAt) && (DateTime.MinValue==AV40TFReembolsoCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data de inicio") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV39TFReembolsoCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV40TFReembolsoCreatedAt_To;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFReembolsoPropostaValor) && (Convert.ToDecimal(0)==AV42TFReembolsoPropostaValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV41TFReembolsoPropostaValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV42TFReembolsoPropostaValor_To);
         }
         if ( ! ( (DateTime.MinValue==AV43TFReembolsoDataAberturaConvenio) && (DateTime.MinValue==AV44TFReembolsoDataAberturaConvenio_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data abertura") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV43TFReembolsoDataAberturaConvenio ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFReembolsoDataAberturaConvenio_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( ( AV49TFReembolsoStatusAtual_F_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV56GXV1 = 1;
            while ( AV56GXV1 <= AV49TFReembolsoStatusAtual_F_Sels.Count )
            {
               AV48TFReembolsoStatusAtual_F_Sel = ((string)AV49TFReembolsoStatusAtual_F_Sels.Item(AV56GXV1));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmreembolsostatus.getDescription(context,AV48TFReembolsoStatusAtual_F_Sel);
               AV50i = (long)(AV50i+1);
               AV56GXV1 = (int)(AV56GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFWorkflowConvenioDesc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Passo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFWorkflowConvenioDesc_Sel)) ? "(Vazio)" : AV52TFWorkflowConvenioDesc_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFWorkflowConvenioDesc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Passo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFWorkflowConvenioDesc, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Paciente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Protocolo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Data de inicio";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Data abertura";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Passo";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Reembolsowwds_1_filterfulltext = AV18FilterFullText;
         AV59Reembolsowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV60Reembolsowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV21ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV62Reembolsowwds_5_workflowconveniodesc1 = AV53WorkflowConvenioDesc1;
         AV63Reembolsowwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV64Reembolsowwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV65Reembolsowwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV25ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV67Reembolsowwds_10_workflowconveniodesc2 = AV54WorkflowConvenioDesc2;
         AV68Reembolsowwds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV69Reembolsowwds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV70Reembolsowwds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV29ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV72Reembolsowwds_15_workflowconveniodesc3 = AV55WorkflowConvenioDesc3;
         AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV75Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV76Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV77Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV78Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV79Reembolsowwds_22_tfreembolsopropostavalor = AV41TFReembolsoPropostaValor;
         AV80Reembolsowwds_23_tfreembolsopropostavalor_to = AV42TFReembolsoPropostaValor_To;
         AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV43TFReembolsoDataAberturaConvenio;
         AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV44TFReembolsoDataAberturaConvenio_To;
         AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV49TFReembolsoStatusAtual_F_Sels;
         AV84Reembolsowwds_27_tfworkflowconveniodesc = AV51TFWorkflowConvenioDesc;
         AV85Reembolsowwds_28_tfworkflowconveniodesc_sel = AV52TFWorkflowConvenioDesc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV59Reembolsowwds_2_dynamicfiltersselector1 ,
                                              AV60Reembolsowwds_3_dynamicfiltersoperator1 ,
                                              AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                              AV62Reembolsowwds_5_workflowconveniodesc1 ,
                                              AV63Reembolsowwds_6_dynamicfiltersenabled2 ,
                                              AV64Reembolsowwds_7_dynamicfiltersselector2 ,
                                              AV65Reembolsowwds_8_dynamicfiltersoperator2 ,
                                              AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                              AV67Reembolsowwds_10_workflowconveniodesc2 ,
                                              AV68Reembolsowwds_11_dynamicfiltersenabled3 ,
                                              AV69Reembolsowwds_12_dynamicfiltersselector3 ,
                                              AV70Reembolsowwds_13_dynamicfiltersoperator3 ,
                                              AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                              AV72Reembolsowwds_15_workflowconveniodesc3 ,
                                              AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV76Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                              AV75Reembolsowwds_18_tfreembolsoprotocolo ,
                                              AV77Reembolsowwds_20_tfreembolsocreatedat ,
                                              AV78Reembolsowwds_21_tfreembolsocreatedat_to ,
                                              AV79Reembolsowwds_22_tfreembolsopropostavalor ,
                                              AV80Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                              AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                              AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                              AV85Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                              AV84Reembolsowwds_27_tfworkflowconveniodesc ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A736WorkflowConvenioDesc ,
                                              A546ReembolsoProtocolo ,
                                              A522ReembolsoCreatedAt ,
                                              A543ReembolsoPropostaValor ,
                                              A525ReembolsoDataAberturaConvenio ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV58Reembolsowwds_1_filterfulltext ,
                                              AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV62Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV62Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV62Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV62Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV67Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV67Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV67Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV67Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV72Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV72Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV72Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV72Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV75Reembolsowwds_18_tfreembolsoprotocolo = StringUtil.Concat( StringUtil.RTrim( AV75Reembolsowwds_18_tfreembolsoprotocolo), "%", "");
         lV84Reembolsowwds_27_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV84Reembolsowwds_27_tfworkflowconveniodesc), "%", "");
         /* Using cursor P00C22 */
         pr_default.execute(0, new Object[] {AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count, lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV62Reembolsowwds_5_workflowconveniodesc1, lV62Reembolsowwds_5_workflowconveniodesc1, lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV67Reembolsowwds_10_workflowconveniodesc2, lV67Reembolsowwds_10_workflowconveniodesc2, lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV72Reembolsowwds_15_workflowconveniodesc3, lV72Reembolsowwds_15_workflowconveniodesc3, lV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial, AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, lV75Reembolsowwds_18_tfreembolsoprotocolo, AV76Reembolsowwds_19_tfreembolsoprotocolo_sel, AV77Reembolsowwds_20_tfreembolsocreatedat, AV78Reembolsowwds_21_tfreembolsocreatedat_to, AV79Reembolsowwds_22_tfreembolsopropostavalor, AV80Reembolsowwds_23_tfreembolsopropostavalor_to, AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio, AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to, lV84Reembolsowwds_27_tfworkflowconveniodesc, AV85Reembolsowwds_28_tfworkflowconveniodesc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A742WorkflowConvenioId = P00C22_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = P00C22_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = P00C22_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = P00C22_n542ReembolsoPropostaId[0];
            A558ReembolsoPropostaPacienteClienteId = P00C22_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C22_n558ReembolsoPropostaPacienteClienteId[0];
            A525ReembolsoDataAberturaConvenio = P00C22_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = P00C22_n525ReembolsoDataAberturaConvenio[0];
            A543ReembolsoPropostaValor = P00C22_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C22_n543ReembolsoPropostaValor[0];
            A522ReembolsoCreatedAt = P00C22_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = P00C22_n522ReembolsoCreatedAt[0];
            A736WorkflowConvenioDesc = P00C22_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C22_n736WorkflowConvenioDesc[0];
            A546ReembolsoProtocolo = P00C22_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = P00C22_n546ReembolsoProtocolo[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C22_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C22_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A518ReembolsoId = P00C22_A518ReembolsoId[0];
            n518ReembolsoId = P00C22_n518ReembolsoId[0];
            A736WorkflowConvenioDesc = P00C22_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = P00C22_n736WorkflowConvenioDesc[0];
            A558ReembolsoPropostaPacienteClienteId = P00C22_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = P00C22_n558ReembolsoPropostaPacienteClienteId[0];
            A543ReembolsoPropostaValor = P00C22_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = P00C22_n543ReembolsoPropostaValor[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C22_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C22_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A550ReembolsoPropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A546ReembolsoProtocolo, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = A522ReembolsoCreatedAt;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A543ReembolsoPropostaValor);
            GXt_dtime3 = DateTimeUtil.ResetTime( A525ReembolsoDataAberturaConvenio ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = GXt_dtime3;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A548ReembolsoStatusAtual_F)) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = gxdomaindmreembolsostatus.getDescription(context,A548ReembolsoStatusAtual_F);
            }
            if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "EM_ANALISE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "FINALIZADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "REANALISE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A736WorkflowConvenioDesc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "ReembolsoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ReembolsoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ReembolsoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ReembolsoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV86GXV2 = 1;
         while ( AV86GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV86GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV35TFReembolsoPropostaPacienteClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROTOCOLO") == 0 )
            {
               AV37TFReembolsoProtocolo = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROTOCOLO_SEL") == 0 )
            {
               AV38TFReembolsoProtocolo_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOCREATEDAT") == 0 )
            {
               AV39TFReembolsoCreatedAt = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV40TFReembolsoCreatedAt_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAVALOR") == 0 )
            {
               AV41TFReembolsoPropostaValor = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV42TFReembolsoPropostaValor_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSODATAABERTURACONVENIO") == 0 )
            {
               AV43TFReembolsoDataAberturaConvenio = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV44TFReembolsoDataAberturaConvenio_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV47TFReembolsoStatusAtual_F_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV49TFReembolsoStatusAtual_F_Sels.FromJSonString(AV47TFReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV51TFWorkflowConvenioDesc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV52TFWorkflowConvenioDesc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV86GXV2 = (int)(AV86GXV2+1);
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
         AV21ReembolsoPropostaPacienteClienteRazaoSocial1 = "";
         AV53WorkflowConvenioDesc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ReembolsoPropostaPacienteClienteRazaoSocial2 = "";
         AV54WorkflowConvenioDesc2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ReembolsoPropostaPacienteClienteRazaoSocial3 = "";
         AV55WorkflowConvenioDesc3 = "";
         AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV35TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV38TFReembolsoProtocolo_Sel = "";
         AV37TFReembolsoProtocolo = "";
         AV39TFReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         AV40TFReembolsoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV43TFReembolsoDataAberturaConvenio = DateTime.MinValue;
         AV44TFReembolsoDataAberturaConvenio_To = DateTime.MinValue;
         AV49TFReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV48TFReembolsoStatusAtual_F_Sel = "";
         AV52TFWorkflowConvenioDesc_Sel = "";
         AV51TFWorkflowConvenioDesc = "";
         AV58Reembolsowwds_1_filterfulltext = "";
         AV59Reembolsowwds_2_dynamicfiltersselector1 = "";
         AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = "";
         AV62Reembolsowwds_5_workflowconveniodesc1 = "";
         AV64Reembolsowwds_7_dynamicfiltersselector2 = "";
         AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = "";
         AV67Reembolsowwds_10_workflowconveniodesc2 = "";
         AV69Reembolsowwds_12_dynamicfiltersselector3 = "";
         AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = "";
         AV72Reembolsowwds_15_workflowconveniodesc3 = "";
         AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = "";
         AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = "";
         AV75Reembolsowwds_18_tfreembolsoprotocolo = "";
         AV76Reembolsowwds_19_tfreembolsoprotocolo_sel = "";
         AV77Reembolsowwds_20_tfreembolsocreatedat = (DateTime)(DateTime.MinValue);
         AV78Reembolsowwds_21_tfreembolsocreatedat_to = (DateTime)(DateTime.MinValue);
         AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio = DateTime.MinValue;
         AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = DateTime.MinValue;
         AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV84Reembolsowwds_27_tfworkflowconveniodesc = "";
         AV85Reembolsowwds_28_tfworkflowconveniodesc_sel = "";
         lV58Reembolsowwds_1_filterfulltext = "";
         lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = "";
         lV62Reembolsowwds_5_workflowconveniodesc1 = "";
         lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = "";
         lV67Reembolsowwds_10_workflowconveniodesc2 = "";
         lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = "";
         lV72Reembolsowwds_15_workflowconveniodesc3 = "";
         lV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = "";
         lV75Reembolsowwds_18_tfreembolsoprotocolo = "";
         lV84Reembolsowwds_27_tfworkflowconveniodesc = "";
         A548ReembolsoStatusAtual_F = "";
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A736WorkflowConvenioDesc = "";
         A546ReembolsoProtocolo = "";
         A522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         P00C22_A742WorkflowConvenioId = new int[1] ;
         P00C22_n742WorkflowConvenioId = new bool[] {false} ;
         P00C22_A542ReembolsoPropostaId = new int[1] ;
         P00C22_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C22_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C22_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C22_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         P00C22_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         P00C22_A543ReembolsoPropostaValor = new decimal[1] ;
         P00C22_n543ReembolsoPropostaValor = new bool[] {false} ;
         P00C22_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00C22_n522ReembolsoCreatedAt = new bool[] {false} ;
         P00C22_A736WorkflowConvenioDesc = new string[] {""} ;
         P00C22_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00C22_A546ReembolsoProtocolo = new string[] {""} ;
         P00C22_n546ReembolsoProtocolo = new bool[] {false} ;
         P00C22_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C22_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C22_A518ReembolsoId = new int[1] ;
         P00C22_n518ReembolsoId = new bool[] {false} ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFReembolsoStatusAtual_F_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsowwexport__default(),
            new Object[][] {
                new Object[] {
               P00C22_A742WorkflowConvenioId, P00C22_n742WorkflowConvenioId, P00C22_A542ReembolsoPropostaId, P00C22_n542ReembolsoPropostaId, P00C22_A558ReembolsoPropostaPacienteClienteId, P00C22_n558ReembolsoPropostaPacienteClienteId, P00C22_A525ReembolsoDataAberturaConvenio, P00C22_n525ReembolsoDataAberturaConvenio, P00C22_A543ReembolsoPropostaValor, P00C22_n543ReembolsoPropostaValor,
               P00C22_A522ReembolsoCreatedAt, P00C22_n522ReembolsoCreatedAt, P00C22_A736WorkflowConvenioDesc, P00C22_n736WorkflowConvenioDesc, P00C22_A546ReembolsoProtocolo, P00C22_n546ReembolsoProtocolo, P00C22_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C22_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00C22_A518ReembolsoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV60Reembolsowwds_3_dynamicfiltersoperator1 ;
      private short AV65Reembolsowwds_8_dynamicfiltersoperator2 ;
      private short AV70Reembolsowwds_13_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV56GXV1 ;
      private int AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int A742WorkflowConvenioId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A518ReembolsoId ;
      private int AV86GXV2 ;
      private long AV50i ;
      private decimal AV41TFReembolsoPropostaValor ;
      private decimal AV42TFReembolsoPropostaValor_To ;
      private decimal AV79Reembolsowwds_22_tfreembolsopropostavalor ;
      private decimal AV80Reembolsowwds_23_tfreembolsopropostavalor_to ;
      private decimal A543ReembolsoPropostaValor ;
      private string GXt_char1 ;
      private DateTime AV39TFReembolsoCreatedAt ;
      private DateTime AV40TFReembolsoCreatedAt_To ;
      private DateTime AV77Reembolsowwds_20_tfreembolsocreatedat ;
      private DateTime AV78Reembolsowwds_21_tfreembolsocreatedat_to ;
      private DateTime A522ReembolsoCreatedAt ;
      private DateTime GXt_dtime3 ;
      private DateTime AV43TFReembolsoDataAberturaConvenio ;
      private DateTime AV44TFReembolsoDataAberturaConvenio_To ;
      private DateTime AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio ;
      private DateTime AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV63Reembolsowwds_6_dynamicfiltersenabled2 ;
      private bool AV68Reembolsowwds_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n742WorkflowConvenioId ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n543ReembolsoPropostaValor ;
      private bool n522ReembolsoCreatedAt ;
      private bool n736WorkflowConvenioDesc ;
      private bool n546ReembolsoProtocolo ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n518ReembolsoId ;
      private string AV47TFReembolsoStatusAtual_F_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ReembolsoPropostaPacienteClienteRazaoSocial1 ;
      private string AV53WorkflowConvenioDesc1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ReembolsoPropostaPacienteClienteRazaoSocial2 ;
      private string AV54WorkflowConvenioDesc2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ReembolsoPropostaPacienteClienteRazaoSocial3 ;
      private string AV55WorkflowConvenioDesc3 ;
      private string AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV35TFReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV38TFReembolsoProtocolo_Sel ;
      private string AV37TFReembolsoProtocolo ;
      private string AV48TFReembolsoStatusAtual_F_Sel ;
      private string AV52TFWorkflowConvenioDesc_Sel ;
      private string AV51TFWorkflowConvenioDesc ;
      private string AV58Reembolsowwds_1_filterfulltext ;
      private string AV59Reembolsowwds_2_dynamicfiltersselector1 ;
      private string AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ;
      private string AV62Reembolsowwds_5_workflowconveniodesc1 ;
      private string AV64Reembolsowwds_7_dynamicfiltersselector2 ;
      private string AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ;
      private string AV67Reembolsowwds_10_workflowconveniodesc2 ;
      private string AV69Reembolsowwds_12_dynamicfiltersselector3 ;
      private string AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ;
      private string AV72Reembolsowwds_15_workflowconveniodesc3 ;
      private string AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ;
      private string AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ;
      private string AV75Reembolsowwds_18_tfreembolsoprotocolo ;
      private string AV76Reembolsowwds_19_tfreembolsoprotocolo_sel ;
      private string AV84Reembolsowwds_27_tfworkflowconveniodesc ;
      private string AV85Reembolsowwds_28_tfworkflowconveniodesc_sel ;
      private string lV58Reembolsowwds_1_filterfulltext ;
      private string lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ;
      private string lV62Reembolsowwds_5_workflowconveniodesc1 ;
      private string lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ;
      private string lV67Reembolsowwds_10_workflowconveniodesc2 ;
      private string lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ;
      private string lV72Reembolsowwds_15_workflowconveniodesc3 ;
      private string lV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ;
      private string lV75Reembolsowwds_18_tfreembolsoprotocolo ;
      private string lV84Reembolsowwds_27_tfworkflowconveniodesc ;
      private string A548ReembolsoStatusAtual_F ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A736WorkflowConvenioDesc ;
      private string A546ReembolsoProtocolo ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV49TFReembolsoStatusAtual_F_Sels ;
      private GxSimpleCollection<string> AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00C22_A742WorkflowConvenioId ;
      private bool[] P00C22_n742WorkflowConvenioId ;
      private int[] P00C22_A542ReembolsoPropostaId ;
      private bool[] P00C22_n542ReembolsoPropostaId ;
      private int[] P00C22_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C22_n558ReembolsoPropostaPacienteClienteId ;
      private DateTime[] P00C22_A525ReembolsoDataAberturaConvenio ;
      private bool[] P00C22_n525ReembolsoDataAberturaConvenio ;
      private decimal[] P00C22_A543ReembolsoPropostaValor ;
      private bool[] P00C22_n543ReembolsoPropostaValor ;
      private DateTime[] P00C22_A522ReembolsoCreatedAt ;
      private bool[] P00C22_n522ReembolsoCreatedAt ;
      private string[] P00C22_A736WorkflowConvenioDesc ;
      private bool[] P00C22_n736WorkflowConvenioDesc ;
      private string[] P00C22_A546ReembolsoProtocolo ;
      private bool[] P00C22_n546ReembolsoProtocolo ;
      private string[] P00C22_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C22_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00C22_A518ReembolsoId ;
      private bool[] P00C22_n518ReembolsoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class reembolsowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C22( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV59Reembolsowwds_2_dynamicfiltersselector1 ,
                                             short AV60Reembolsowwds_3_dynamicfiltersoperator1 ,
                                             string AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                             string AV62Reembolsowwds_5_workflowconveniodesc1 ,
                                             bool AV63Reembolsowwds_6_dynamicfiltersenabled2 ,
                                             string AV64Reembolsowwds_7_dynamicfiltersselector2 ,
                                             short AV65Reembolsowwds_8_dynamicfiltersoperator2 ,
                                             string AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                             string AV67Reembolsowwds_10_workflowconveniodesc2 ,
                                             bool AV68Reembolsowwds_11_dynamicfiltersenabled3 ,
                                             string AV69Reembolsowwds_12_dynamicfiltersselector3 ,
                                             short AV70Reembolsowwds_13_dynamicfiltersoperator3 ,
                                             string AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                             string AV72Reembolsowwds_15_workflowconveniodesc3 ,
                                             string AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV76Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                             string AV75Reembolsowwds_18_tfreembolsoprotocolo ,
                                             DateTime AV77Reembolsowwds_20_tfreembolsocreatedat ,
                                             DateTime AV78Reembolsowwds_21_tfreembolsocreatedat_to ,
                                             decimal AV79Reembolsowwds_22_tfreembolsopropostavalor ,
                                             decimal AV80Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                             DateTime AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                             DateTime AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                             string AV85Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                             string AV84Reembolsowwds_27_tfworkflowconveniodesc ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             string A736WorkflowConvenioDesc ,
                                             string A546ReembolsoProtocolo ,
                                             DateTime A522ReembolsoCreatedAt ,
                                             decimal A543ReembolsoPropostaValor ,
                                             DateTime A525ReembolsoDataAberturaConvenio ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV58Reembolsowwds_1_filterfulltext ,
                                             int AV83Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[25];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.WorkflowConvenioId, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.ReembolsoDataAberturaConvenio, T3.PropostaValor AS ReembolsoPropostaValor, T1.ReembolsoCreatedAt, T2.WorkflowConvenioDesc, T1.ReembolsoProtocolo, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoId FROM (((Reembolso T1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.WorkflowConvenioId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId)";
         if ( ( StringUtil.StrCmp(AV59Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV60Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV60Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV60Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV62Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV60Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV62Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV63Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV65Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV63Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV65Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV63Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV65Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV67Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV63Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV65Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV67Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV68Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV70Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV68Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV70Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV68Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV70Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV72Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV68Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV70Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV72Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reembolsowwds_18_tfreembolsoprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo like :lV75Reembolsowwds_18_tfreembolsoprotocolo)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ! ( StringUtil.StrCmp(AV76Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo = ( :AV76Reembolsowwds_19_tfreembolsoprotocolo_sel))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV76Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoProtocolo))=0))");
         }
         if ( ! (DateTime.MinValue==AV77Reembolsowwds_20_tfreembolsocreatedat) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt >= :AV77Reembolsowwds_20_tfreembolsocreatedat)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Reembolsowwds_21_tfreembolsocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt <= :AV78Reembolsowwds_21_tfreembolsocreatedat_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Reembolsowwds_22_tfreembolsopropostavalor) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor >= :AV79Reembolsowwds_22_tfreembolsopropostavalor)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Reembolsowwds_23_tfreembolsopropostavalor_to) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor <= :AV80Reembolsowwds_23_tfreembolsopropostavalor_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio >= :AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio <= :AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reembolsowwds_27_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV84Reembolsowwds_27_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV85Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV85Reembolsowwds_28_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV85Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoProtocolo";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoProtocolo DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoCreatedAt";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.PropostaValor";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.PropostaValor DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoDataAberturaConvenio";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoDataAberturaConvenio DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.WorkflowConvenioDesc";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.WorkflowConvenioDesc DESC";
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
                     return conditional_P00C22(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (decimal)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] );
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
          Object[] prmP00C22;
          prmP00C22 = new Object[] {
          new ParDef("AV83ReemCount",GXType.Int32,9,0) ,
          new ParDef("lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV61Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV62Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV62Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV66Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV67Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV67Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV71Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV72Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV72Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV73Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("AV74Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV75Reembolsowwds_18_tfreembolsoprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV76Reembolsowwds_19_tfreembolsoprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV77Reembolsowwds_20_tfreembolsocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV78Reembolsowwds_21_tfreembolsocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV79Reembolsowwds_22_tfreembolsopropostavalor",GXType.Number,18,2) ,
          new ParDef("AV80Reembolsowwds_23_tfreembolsopropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV81Reembolsowwds_24_tfreembolsodataaberturaconvenio",GXType.Date,8,0) ,
          new ParDef("AV82Reembolsowwds_25_tfreembolsodataaberturaconvenio_to",GXType.Date,8,0) ,
          new ParDef("lV84Reembolsowwds_27_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV85Reembolsowwds_28_tfworkflowconveniodesc_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C22,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
