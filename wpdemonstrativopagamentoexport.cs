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
   public class wpdemonstrativopagamentoexport : GXProcedure
   {
      public wpdemonstrativopagamentoexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdemonstrativopagamentoexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WpDemonstrativoPagamentoExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV75PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV75PropostaMaxReembolsoId_F1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV75PropostaMaxReembolsoId_F1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV76PropostaResponsavelDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76PropostaResponsavelDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76PropostaResponsavelDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV77PropostaPacienteClienteDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77PropostaPacienteClienteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77PropostaPacienteClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV78PropostaClinicaDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78PropostaClinicaDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78PropostaClinicaDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV21PropostaPacienteClienteRazaoSocial1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21PropostaPacienteClienteRazaoSocial1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21PropostaPacienteClienteRazaoSocial1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV22ContratoNome1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ContratoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ContratoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV23ConvenioCategoriaDescricao1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ConvenioCategoriaDescricao1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ConvenioCategoriaDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV79PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV79PropostaMaxReembolsoId_F2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV79PropostaMaxReembolsoId_F2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV80PropostaResponsavelDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80PropostaResponsavelDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80PropostaResponsavelDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV81PropostaPacienteClienteDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81PropostaPacienteClienteDocumento2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV81PropostaPacienteClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV82PropostaClinicaDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82PropostaClinicaDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82PropostaClinicaDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV27PropostaPacienteClienteRazaoSocial2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27PropostaPacienteClienteRazaoSocial2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27PropostaPacienteClienteRazaoSocial2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV28ContratoNome2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ContratoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ContratoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV29ConvenioCategoriaDescricao2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ConvenioCategoriaDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ConvenioCategoriaDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV30DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(3));
                  AV31DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV83PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV83PropostaMaxReembolsoId_F3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV83PropostaMaxReembolsoId_F3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV84PropostaResponsavelDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84PropostaResponsavelDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84PropostaResponsavelDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV85PropostaPacienteClienteDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85PropostaPacienteClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV85PropostaPacienteClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV86PropostaClinicaDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86PropostaClinicaDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV86PropostaClinicaDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV33PropostaPacienteClienteRazaoSocial3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33PropostaPacienteClienteRazaoSocial3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33PropostaPacienteClienteRazaoSocial3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV34ContratoNome3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ContratoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34ContratoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV35ConvenioCategoriaDescricao3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ConvenioCategoriaDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35ConvenioCategoriaDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPropostaPacienteClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPropostaPacienteClienteRazaoSocial_Sel)) ? "(Vazio)" : AV42TFPropostaPacienteClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPropostaPacienteClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFPropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPropostaDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descricao") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPropostaDescricao_Sel)) ? "(Vazio)" : AV46TFPropostaDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFPropostaDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descricao") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFPropostaDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV47TFPropostaValor) && (Convert.ToDecimal(0)==AV48TFPropostaValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV47TFPropostaValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV48TFPropostaValor_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV49TFPropostaTaxaAdministrativa) && (Convert.ToDecimal(0)==AV50TFPropostaTaxaAdministrativa_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "(%)Taxa") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV49TFPropostaTaxaAdministrativa);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV50TFPropostaTaxaAdministrativa_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV69TFPropostaValorTaxa_F) && (Convert.ToDecimal(0)==AV70TFPropostaValorTaxa_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Taxa") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV69TFPropostaValorTaxa_F);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV70TFPropostaValorTaxa_F_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV53TFPropostaJurosMora) && (Convert.ToDecimal(0)==AV54TFPropostaJurosMora_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "(%)Juros mora") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV53TFPropostaJurosMora);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV54TFPropostaJurosMora_To);
         }
         if ( ! ( (DateTime.MinValue==AV73TFPropostaDataCreditoCliente_F) && (DateTime.MinValue==AV74TFPropostaDataCreditoCliente_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV73TFPropostaDataCreditoCliente_F ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV74TFPropostaDataCreditoCliente_F_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV71TFPropostaValorJurosMora_F) && (Convert.ToDecimal(0)==AV72TFPropostaValorJurosMora_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Juros mora") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV71TFPropostaValorJurosMora_F);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV72TFPropostaValorJurosMora_F_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFPropostaSecUserName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Clinica") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV68TFPropostaSecUserName_Sel)) ? "(Vazio)" : AV68TFPropostaSecUserName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFPropostaSecUserName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Clinica") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67TFPropostaSecUserName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV59TFPropostaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV66i = 1;
            AV87GXV1 = 1;
            while ( AV87GXV1 <= AV59TFPropostaStatus_Sels.Count )
            {
               AV58TFPropostaStatus_Sel = ((string)AV59TFPropostaStatus_Sels.Item(AV87GXV1));
               if ( AV66i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusproposta.getDescription(context,AV58TFPropostaStatus_Sel);
               AV66i = (long)(AV66i+1);
               AV87GXV1 = (int)(AV87GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descricao";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "(%)Taxa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Taxa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "(%)Juros mora";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Data";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Juros mora";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Clinica";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV89Wpdemonstrativopagamentods_1_filterfulltext = AV18FilterFullText;
         AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = AV75PropostaMaxReembolsoId_F1;
         AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = AV76PropostaResponsavelDocumento1;
         AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = AV77PropostaPacienteClienteDocumento1;
         AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = AV78PropostaClinicaDocumento1;
         AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = AV21PropostaPacienteClienteRazaoSocial1;
         AV97Wpdemonstrativopagamentods_9_contratonome1 = AV22ContratoNome1;
         AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = AV23ConvenioCategoriaDescricao1;
         AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = AV79PropostaMaxReembolsoId_F2;
         AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = AV80PropostaResponsavelDocumento2;
         AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = AV81PropostaPacienteClienteDocumento2;
         AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = AV82PropostaClinicaDocumento2;
         AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = AV27PropostaPacienteClienteRazaoSocial2;
         AV107Wpdemonstrativopagamentods_19_contratonome2 = AV28ContratoNome2;
         AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = AV29ConvenioCategoriaDescricao2;
         AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = AV83PropostaMaxReembolsoId_F3;
         AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = AV84PropostaResponsavelDocumento3;
         AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = AV85PropostaPacienteClienteDocumento3;
         AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = AV86PropostaClinicaDocumento3;
         AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = AV33PropostaPacienteClienteRazaoSocial3;
         AV117Wpdemonstrativopagamentods_29_contratonome3 = AV34ContratoNome3;
         AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = AV35ConvenioCategoriaDescricao3;
         AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = AV41TFPropostaPacienteClienteRazaoSocial;
         AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = AV42TFPropostaPacienteClienteRazaoSocial_Sel;
         AV121Wpdemonstrativopagamentods_33_tfpropostadescricao = AV45TFPropostaDescricao;
         AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = AV46TFPropostaDescricao_Sel;
         AV123Wpdemonstrativopagamentods_35_tfpropostavalor = AV47TFPropostaValor;
         AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to = AV48TFPropostaValor_To;
         AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa = AV49TFPropostaTaxaAdministrativa;
         AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to = AV50TFPropostaTaxaAdministrativa_To;
         AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f = AV69TFPropostaValorTaxa_F;
         AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to = AV70TFPropostaValorTaxa_F_To;
         AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora = AV53TFPropostaJurosMora;
         AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to = AV54TFPropostaJurosMora_To;
         AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = AV73TFPropostaDataCreditoCliente_F;
         AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = AV74TFPropostaDataCreditoCliente_F_To;
         AV133Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f = AV71TFPropostaValorJurosMora_F;
         AV134Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to = AV72TFPropostaValorJurosMora_F_To;
         AV135Wpdemonstrativopagamentods_47_tfpropostasecusername = AV67TFPropostaSecUserName;
         AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = AV68TFPropostaSecUserName_Sel;
         AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels = AV59TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                              AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                              AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                              AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                              AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                              AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                              AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                              AV97Wpdemonstrativopagamentods_9_contratonome1 ,
                                              AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                              AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                              AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                              AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                              AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                              AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                              AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                              AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                              AV107Wpdemonstrativopagamentods_19_contratonome2 ,
                                              AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                              AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                              AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                              AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                              AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                              AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                              AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                              AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                              AV117Wpdemonstrativopagamentods_29_contratonome3 ,
                                              AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                              AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                              AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                              AV121Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                              AV123Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                              AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                              AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                              AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                              AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                              AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                              AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                              AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                              AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                              AV135Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                              AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels.Count ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A501PropostaTaxaAdministrativa ,
                                              A508PropostaJurosMora ,
                                              A512PropostaSecUserName ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV89Wpdemonstrativopagamentods_1_filterfulltext ,
                                              A513PropostaValorTaxa_F ,
                                              A514PropostaValorJurosMora_F ,
                                              AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                              AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                              AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                              A515PropostaDataCreditoCliente_F ,
                                              AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                              AV133Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                              AV134Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1), "%", "");
         lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1), "%", "");
         lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1), "%", "");
         lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1), "%", "");
         lV97Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV97Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV97Wpdemonstrativopagamentods_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV97Wpdemonstrativopagamentods_9_contratonome1), "%", "");
         lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1), "%", "");
         lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2), "%", "");
         lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2), "%", "");
         lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2), "%", "");
         lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2), "%", "");
         lV107Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV107Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV107Wpdemonstrativopagamentods_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV107Wpdemonstrativopagamentods_19_contratonome2), "%", "");
         lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2), "%", "");
         lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3), "%", "");
         lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3), "%", "");
         lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3), "%", "");
         lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3), "%", "");
         lV117Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV117Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV117Wpdemonstrativopagamentods_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV117Wpdemonstrativopagamentods_29_contratonome3), "%", "");
         lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3), "%", "");
         lV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial), "%", "");
         lV121Wpdemonstrativopagamentods_33_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV121Wpdemonstrativopagamentods_33_tfpropostadescricao), "%", "");
         lV135Wpdemonstrativopagamentods_47_tfpropostasecusername = StringUtil.Concat( StringUtil.RTrim( AV135Wpdemonstrativopagamentods_47_tfpropostasecusername), "%", "");
         /* Using cursor P00AL5 */
         pr_default.execute(0, new Object[] {AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1, AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1, AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2, AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2, AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2, AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3, AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3, AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3, AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f, AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to, lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1, lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1, lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1, lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1, lV97Wpdemonstrativopagamentods_9_contratonome1, lV97Wpdemonstrativopagamentods_9_contratonome1, lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1, lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2, lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2, lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2, lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2, lV107Wpdemonstrativopagamentods_19_contratonome2, lV107Wpdemonstrativopagamentods_19_contratonome2, lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2, lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3, lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3, lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3, lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3, lV117Wpdemonstrativopagamentods_29_contratonome3, lV117Wpdemonstrativopagamentods_29_contratonome3, lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3, lV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial, AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, lV121Wpdemonstrativopagamentods_33_tfpropostadescricao, AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, AV123Wpdemonstrativopagamentods_35_tfpropostavalor, AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to, AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa, AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to, AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f, AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to, AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora, AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to, lV135Wpdemonstrativopagamentods_47_tfpropostasecusername, AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P00AL5_A227ContratoId[0];
            n227ContratoId = P00AL5_n227ContratoId[0];
            A493ConvenioCategoriaId = P00AL5_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00AL5_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = P00AL5_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00AL5_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P00AL5_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00AL5_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00AL5_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00AL5_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00AL5_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00AL5_n642PropostaClinicaId[0];
            A513PropostaValorTaxa_F = P00AL5_A513PropostaValorTaxa_F[0];
            A494ConvenioCategoriaDescricao = P00AL5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AL5_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00AL5_A228ContratoNome[0];
            n228ContratoNome = P00AL5_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00AL5_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AL5_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P00AL5_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AL5_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P00AL5_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AL5_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P00AL5_A329PropostaStatus[0];
            n329PropostaStatus = P00AL5_n329PropostaStatus[0];
            A512PropostaSecUserName = P00AL5_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AL5_n512PropostaSecUserName[0];
            A325PropostaDescricao = P00AL5_A325PropostaDescricao[0];
            n325PropostaDescricao = P00AL5_n325PropostaDescricao[0];
            A505PropostaPacienteClienteRazaoSocial = P00AL5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AL5_n505PropostaPacienteClienteRazaoSocial[0];
            A327PropostaCreatedAt = P00AL5_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = P00AL5_n327PropostaCreatedAt[0];
            A501PropostaTaxaAdministrativa = P00AL5_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = P00AL5_n501PropostaTaxaAdministrativa[0];
            A323PropostaId = P00AL5_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00AL5_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AL5_n649PropostaMaxReembolsoId_F[0];
            A326PropostaValor = P00AL5_A326PropostaValor[0];
            n326PropostaValor = P00AL5_n326PropostaValor[0];
            A508PropostaJurosMora = P00AL5_A508PropostaJurosMora[0];
            n508PropostaJurosMora = P00AL5_n508PropostaJurosMora[0];
            A507PropostaSLA = P00AL5_A507PropostaSLA[0];
            n507PropostaSLA = P00AL5_n507PropostaSLA[0];
            A515PropostaDataCreditoCliente_F = P00AL5_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AL5_n515PropostaDataCreditoCliente_F[0];
            A228ContratoNome = P00AL5_A228ContratoNome[0];
            n228ContratoNome = P00AL5_n228ContratoNome[0];
            A494ConvenioCategoriaDescricao = P00AL5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00AL5_n494ConvenioCategoriaDescricao[0];
            A512PropostaSecUserName = P00AL5_A512PropostaSecUserName[0];
            n512PropostaSecUserName = P00AL5_n512PropostaSecUserName[0];
            A540PropostaPacienteClienteDocumento = P00AL5_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00AL5_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00AL5_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00AL5_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P00AL5_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00AL5_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00AL5_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00AL5_n652PropostaClinicaDocumento[0];
            A515PropostaDataCreditoCliente_F = P00AL5_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = P00AL5_n515PropostaDataCreditoCliente_F[0];
            A649PropostaMaxReembolsoId_F = P00AL5_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00AL5_n649PropostaMaxReembolsoId_F[0];
            GXt_decimal4 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal4) ;
            A514PropostaValorJurosMora_F = GXt_decimal4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpdemonstrativopagamentods_1_filterfulltext)) || ( ( StringUtil.Like( A505PropostaPacienteClienteRazaoSocial , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( A325PropostaDescricao , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A326PropostaValor, 18, 2) , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A501PropostaTaxaAdministrativa, 16, 4) , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A513PropostaValorTaxa_F, 18, 2) , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A508PropostaJurosMora, 16, 4) , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A514PropostaValorJurosMora_F, 18, 2) , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A512PropostaSecUserName , StringUtil.PadR( "%" + AV89Wpdemonstrativopagamentods_1_filterfulltext , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "pendente aprovação" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) ) || ( StringUtil.Like( "em análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) ) || ( StringUtil.Like( "revisão" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) ) || ( StringUtil.Like( "cancelado" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) ) ||
            ( StringUtil.Like( "aguardando assinatura" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) ) || ( StringUtil.Like( "análise reprovada" , StringUtil.PadR( "%" + StringUtil.Lower( AV89Wpdemonstrativopagamentods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) ) )
            )
            {
               if ( (Convert.ToDecimal(0)==AV133Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f) || ( ( A514PropostaValorJurosMora_F >= AV133Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV134Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to) || ( ( A514PropostaValorJurosMora_F <= AV134Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ) ) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A505PropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A325PropostaDescricao, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A326PropostaValor);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A501PropostaTaxaAdministrativa);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A513PropostaValorTaxa_F);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = (double)(A508PropostaJurosMora);
                     GXt_dtime3 = DateTimeUtil.ResetTime( A515PropostaDataCreditoCliente_F ) ;
                     AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Date = GXt_dtime3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Number = (double)(A514PropostaValorJurosMora_F);
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A512PropostaSecUserName, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = GXt_char1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = gxdomaindmstatusproposta.getDescription(context,A329PropostaStatus);
                     if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                     }
                     else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
                     }
                     else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                     }
                     else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                     }
                     else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
                     }
                     else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV37Session.Set("WWPExportFilePath", AV11Filename);
         AV37Session.Set("WWPExportFileName", "WpDemonstrativoPagamentoExport.xlsx");
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
         if ( StringUtil.StrCmp(AV37Session.Get("WpDemonstrativoPagamentoGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpDemonstrativoPagamentoGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("WpDemonstrativoPagamentoGridState"), null, "", "");
         }
         AV16OrderedBy = AV39GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV39GridState.gxTpr_Ordereddsc;
         AV138GXV2 = 1;
         while ( AV138GXV2 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV138GXV2));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV41TFPropostaPacienteClienteRazaoSocial = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV42TFPropostaPacienteClienteRazaoSocial_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV45TFPropostaDescricao = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV46TFPropostaDescricao_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV47TFPropostaValor = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV48TFPropostaValor_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTATAXAADMINISTRATIVA") == 0 )
            {
               AV49TFPropostaTaxaAdministrativa = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV50TFPropostaTaxaAdministrativa_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALORTAXA_F") == 0 )
            {
               AV69TFPropostaValorTaxa_F = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV70TFPropostaValorTaxa_F_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTAJUROSMORA") == 0 )
            {
               AV53TFPropostaJurosMora = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV54TFPropostaJurosMora_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTADATACREDITOCLIENTE_F") == 0 )
            {
               AV73TFPropostaDataCreditoCliente_F = context.localUtil.CToD( AV40GridStateFilterValue.gxTpr_Value, 4);
               AV74TFPropostaDataCreditoCliente_F_To = context.localUtil.CToD( AV40GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALORJUROSMORA_F") == 0 )
            {
               AV71TFPropostaValorJurosMora_F = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV72TFPropostaValorJurosMora_F_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTASECUSERNAME") == 0 )
            {
               AV67TFPropostaSecUserName = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTASECUSERNAME_SEL") == 0 )
            {
               AV68TFPropostaSecUserName_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV57TFPropostaStatus_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV59TFPropostaStatus_Sels.FromJSonString(AV57TFPropostaStatus_SelsJson, null);
            }
            AV138GXV2 = (int)(AV138GXV2+1);
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
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV76PropostaResponsavelDocumento1 = "";
         AV77PropostaPacienteClienteDocumento1 = "";
         AV78PropostaClinicaDocumento1 = "";
         AV21PropostaPacienteClienteRazaoSocial1 = "";
         AV22ContratoNome1 = "";
         AV23ConvenioCategoriaDescricao1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV80PropostaResponsavelDocumento2 = "";
         AV81PropostaPacienteClienteDocumento2 = "";
         AV82PropostaClinicaDocumento2 = "";
         AV27PropostaPacienteClienteRazaoSocial2 = "";
         AV28ContratoNome2 = "";
         AV29ConvenioCategoriaDescricao2 = "";
         AV31DynamicFiltersSelector3 = "";
         AV84PropostaResponsavelDocumento3 = "";
         AV85PropostaPacienteClienteDocumento3 = "";
         AV86PropostaClinicaDocumento3 = "";
         AV33PropostaPacienteClienteRazaoSocial3 = "";
         AV34ContratoNome3 = "";
         AV35ConvenioCategoriaDescricao3 = "";
         AV42TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV41TFPropostaPacienteClienteRazaoSocial = "";
         AV46TFPropostaDescricao_Sel = "";
         AV45TFPropostaDescricao = "";
         AV73TFPropostaDataCreditoCliente_F = DateTime.MinValue;
         AV74TFPropostaDataCreditoCliente_F_To = DateTime.MinValue;
         AV68TFPropostaSecUserName_Sel = "";
         AV67TFPropostaSecUserName = "";
         AV59TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV58TFPropostaStatus_Sel = "";
         AV89Wpdemonstrativopagamentods_1_filterfulltext = "";
         AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = "";
         AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = "";
         AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = "";
         AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = "";
         AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = "";
         AV97Wpdemonstrativopagamentods_9_contratonome1 = "";
         AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = "";
         AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = "";
         AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = "";
         AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = "";
         AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = "";
         AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = "";
         AV107Wpdemonstrativopagamentods_19_contratonome2 = "";
         AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = "";
         AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = "";
         AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = "";
         AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = "";
         AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = "";
         AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = "";
         AV117Wpdemonstrativopagamentods_29_contratonome3 = "";
         AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = "";
         AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = "";
         AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel = "";
         AV121Wpdemonstrativopagamentods_33_tfpropostadescricao = "";
         AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel = "";
         AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f = DateTime.MinValue;
         AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to = DateTime.MinValue;
         AV135Wpdemonstrativopagamentods_47_tfpropostasecusername = "";
         AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel = "";
         AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV89Wpdemonstrativopagamentods_1_filterfulltext = "";
         lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 = "";
         lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 = "";
         lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 = "";
         lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 = "";
         lV97Wpdemonstrativopagamentods_9_contratonome1 = "";
         lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 = "";
         lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 = "";
         lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 = "";
         lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 = "";
         lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 = "";
         lV107Wpdemonstrativopagamentods_19_contratonome2 = "";
         lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 = "";
         lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 = "";
         lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 = "";
         lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 = "";
         lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 = "";
         lV117Wpdemonstrativopagamentods_29_contratonome3 = "";
         lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 = "";
         lV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial = "";
         lV121Wpdemonstrativopagamentods_33_tfpropostadescricao = "";
         lV135Wpdemonstrativopagamentods_47_tfpropostasecusername = "";
         A329PropostaStatus = "";
         A580PropostaResponsavelDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         A652PropostaClinicaDocumento = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A228ContratoNome = "";
         A494ConvenioCategoriaDescricao = "";
         A325PropostaDescricao = "";
         A512PropostaSecUserName = "";
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         P00AL5_A227ContratoId = new int[1] ;
         P00AL5_n227ContratoId = new bool[] {false} ;
         P00AL5_A493ConvenioCategoriaId = new int[1] ;
         P00AL5_n493ConvenioCategoriaId = new bool[] {false} ;
         P00AL5_A328PropostaCratedBy = new short[1] ;
         P00AL5_n328PropostaCratedBy = new bool[] {false} ;
         P00AL5_A504PropostaPacienteClienteId = new int[1] ;
         P00AL5_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00AL5_A553PropostaResponsavelId = new int[1] ;
         P00AL5_n553PropostaResponsavelId = new bool[] {false} ;
         P00AL5_A642PropostaClinicaId = new int[1] ;
         P00AL5_n642PropostaClinicaId = new bool[] {false} ;
         P00AL5_A513PropostaValorTaxa_F = new decimal[1] ;
         P00AL5_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00AL5_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00AL5_A228ContratoNome = new string[] {""} ;
         P00AL5_n228ContratoNome = new bool[] {false} ;
         P00AL5_A652PropostaClinicaDocumento = new string[] {""} ;
         P00AL5_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00AL5_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00AL5_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00AL5_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00AL5_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00AL5_A329PropostaStatus = new string[] {""} ;
         P00AL5_n329PropostaStatus = new bool[] {false} ;
         P00AL5_A512PropostaSecUserName = new string[] {""} ;
         P00AL5_n512PropostaSecUserName = new bool[] {false} ;
         P00AL5_A325PropostaDescricao = new string[] {""} ;
         P00AL5_n325PropostaDescricao = new bool[] {false} ;
         P00AL5_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00AL5_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00AL5_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00AL5_n327PropostaCreatedAt = new bool[] {false} ;
         P00AL5_A501PropostaTaxaAdministrativa = new decimal[1] ;
         P00AL5_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         P00AL5_A323PropostaId = new int[1] ;
         P00AL5_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00AL5_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         P00AL5_A326PropostaValor = new decimal[1] ;
         P00AL5_n326PropostaValor = new bool[] {false} ;
         P00AL5_A508PropostaJurosMora = new decimal[1] ;
         P00AL5_n508PropostaJurosMora = new bool[] {false} ;
         P00AL5_A507PropostaSLA = new short[1] ;
         P00AL5_n507PropostaSLA = new bool[] {false} ;
         P00AL5_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         P00AL5_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         AV37Session = context.GetSession();
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV57TFPropostaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdemonstrativopagamentoexport__default(),
            new Object[][] {
                new Object[] {
               P00AL5_A227ContratoId, P00AL5_n227ContratoId, P00AL5_A493ConvenioCategoriaId, P00AL5_n493ConvenioCategoriaId, P00AL5_A328PropostaCratedBy, P00AL5_n328PropostaCratedBy, P00AL5_A504PropostaPacienteClienteId, P00AL5_n504PropostaPacienteClienteId, P00AL5_A553PropostaResponsavelId, P00AL5_n553PropostaResponsavelId,
               P00AL5_A642PropostaClinicaId, P00AL5_n642PropostaClinicaId, P00AL5_A513PropostaValorTaxa_F, P00AL5_A494ConvenioCategoriaDescricao, P00AL5_n494ConvenioCategoriaDescricao, P00AL5_A228ContratoNome, P00AL5_n228ContratoNome, P00AL5_A652PropostaClinicaDocumento, P00AL5_n652PropostaClinicaDocumento, P00AL5_A540PropostaPacienteClienteDocumento,
               P00AL5_n540PropostaPacienteClienteDocumento, P00AL5_A580PropostaResponsavelDocumento, P00AL5_n580PropostaResponsavelDocumento, P00AL5_A329PropostaStatus, P00AL5_n329PropostaStatus, P00AL5_A512PropostaSecUserName, P00AL5_n512PropostaSecUserName, P00AL5_A325PropostaDescricao, P00AL5_n325PropostaDescricao, P00AL5_A505PropostaPacienteClienteRazaoSocial,
               P00AL5_n505PropostaPacienteClienteRazaoSocial, P00AL5_A327PropostaCreatedAt, P00AL5_n327PropostaCreatedAt, P00AL5_A501PropostaTaxaAdministrativa, P00AL5_n501PropostaTaxaAdministrativa, P00AL5_A323PropostaId, P00AL5_A649PropostaMaxReembolsoId_F, P00AL5_n649PropostaMaxReembolsoId_F, P00AL5_A326PropostaValor, P00AL5_n326PropostaValor,
               P00AL5_A508PropostaJurosMora, P00AL5_n508PropostaJurosMora, P00AL5_A507PropostaSLA, P00AL5_n507PropostaSLA, P00AL5_A515PropostaDataCreditoCliente_F, P00AL5_n515PropostaDataCreditoCliente_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ;
      private short AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ;
      private short AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private short A328PropostaCratedBy ;
      private short A507PropostaSLA ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV75PropostaMaxReembolsoId_F1 ;
      private int AV79PropostaMaxReembolsoId_F2 ;
      private int AV83PropostaMaxReembolsoId_F3 ;
      private int AV87GXV1 ;
      private int AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ;
      private int AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ;
      private int AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ;
      private int AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A227ContratoId ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A323PropostaId ;
      private int AV138GXV2 ;
      private long AV66i ;
      private decimal AV47TFPropostaValor ;
      private decimal AV48TFPropostaValor_To ;
      private decimal AV49TFPropostaTaxaAdministrativa ;
      private decimal AV50TFPropostaTaxaAdministrativa_To ;
      private decimal AV69TFPropostaValorTaxa_F ;
      private decimal AV70TFPropostaValorTaxa_F_To ;
      private decimal AV53TFPropostaJurosMora ;
      private decimal AV54TFPropostaJurosMora_To ;
      private decimal AV71TFPropostaValorJurosMora_F ;
      private decimal AV72TFPropostaValorJurosMora_F_To ;
      private decimal AV123Wpdemonstrativopagamentods_35_tfpropostavalor ;
      private decimal AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to ;
      private decimal AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ;
      private decimal AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ;
      private decimal AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ;
      private decimal AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ;
      private decimal AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora ;
      private decimal AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ;
      private decimal AV133Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ;
      private decimal AV134Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to ;
      private decimal A326PropostaValor ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A508PropostaJurosMora ;
      private decimal A513PropostaValorTaxa_F ;
      private decimal A514PropostaValorJurosMora_F ;
      private decimal GXt_decimal4 ;
      private string GXt_char1 ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime GXt_dtime3 ;
      private DateTime AV73TFPropostaDataCreditoCliente_F ;
      private DateTime AV74TFPropostaDataCreditoCliente_F_To ;
      private DateTime AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ;
      private DateTime AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ;
      private DateTime A515PropostaDataCreditoCliente_F ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ;
      private bool AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n227ContratoId ;
      private bool n493ConvenioCategoriaId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n228ContratoNome ;
      private bool n652PropostaClinicaDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n329PropostaStatus ;
      private bool n512PropostaSecUserName ;
      private bool n325PropostaDescricao ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n327PropostaCreatedAt ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n326PropostaValor ;
      private bool n508PropostaJurosMora ;
      private bool n507PropostaSLA ;
      private bool n515PropostaDataCreditoCliente_F ;
      private string AV57TFPropostaStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV76PropostaResponsavelDocumento1 ;
      private string AV77PropostaPacienteClienteDocumento1 ;
      private string AV78PropostaClinicaDocumento1 ;
      private string AV21PropostaPacienteClienteRazaoSocial1 ;
      private string AV22ContratoNome1 ;
      private string AV23ConvenioCategoriaDescricao1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV80PropostaResponsavelDocumento2 ;
      private string AV81PropostaPacienteClienteDocumento2 ;
      private string AV82PropostaClinicaDocumento2 ;
      private string AV27PropostaPacienteClienteRazaoSocial2 ;
      private string AV28ContratoNome2 ;
      private string AV29ConvenioCategoriaDescricao2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV84PropostaResponsavelDocumento3 ;
      private string AV85PropostaPacienteClienteDocumento3 ;
      private string AV86PropostaClinicaDocumento3 ;
      private string AV33PropostaPacienteClienteRazaoSocial3 ;
      private string AV34ContratoNome3 ;
      private string AV35ConvenioCategoriaDescricao3 ;
      private string AV42TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV41TFPropostaPacienteClienteRazaoSocial ;
      private string AV46TFPropostaDescricao_Sel ;
      private string AV45TFPropostaDescricao ;
      private string AV68TFPropostaSecUserName_Sel ;
      private string AV67TFPropostaSecUserName ;
      private string AV58TFPropostaStatus_Sel ;
      private string AV89Wpdemonstrativopagamentods_1_filterfulltext ;
      private string AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ;
      private string AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ;
      private string AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ;
      private string AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ;
      private string AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ;
      private string AV97Wpdemonstrativopagamentods_9_contratonome1 ;
      private string AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ;
      private string AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ;
      private string AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ;
      private string AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ;
      private string AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ;
      private string AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ;
      private string AV107Wpdemonstrativopagamentods_19_contratonome2 ;
      private string AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ;
      private string AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ;
      private string AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ;
      private string AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ;
      private string AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ;
      private string AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ;
      private string AV117Wpdemonstrativopagamentods_29_contratonome3 ;
      private string AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ;
      private string AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ;
      private string AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ;
      private string AV121Wpdemonstrativopagamentods_33_tfpropostadescricao ;
      private string AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ;
      private string AV135Wpdemonstrativopagamentods_47_tfpropostasecusername ;
      private string AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ;
      private string lV89Wpdemonstrativopagamentods_1_filterfulltext ;
      private string lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ;
      private string lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ;
      private string lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ;
      private string lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ;
      private string lV97Wpdemonstrativopagamentods_9_contratonome1 ;
      private string lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ;
      private string lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ;
      private string lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ;
      private string lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ;
      private string lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ;
      private string lV107Wpdemonstrativopagamentods_19_contratonome2 ;
      private string lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ;
      private string lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ;
      private string lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ;
      private string lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ;
      private string lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ;
      private string lV117Wpdemonstrativopagamentods_29_contratonome3 ;
      private string lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ;
      private string lV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ;
      private string lV121Wpdemonstrativopagamentods_33_tfpropostadescricao ;
      private string lV135Wpdemonstrativopagamentods_47_tfpropostasecusername ;
      private string A329PropostaStatus ;
      private string A580PropostaResponsavelDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A228ContratoNome ;
      private string A494ConvenioCategoriaDescricao ;
      private string A325PropostaDescricao ;
      private string A512PropostaSecUserName ;
      private IGxSession AV37Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV59TFPropostaStatus_Sels ;
      private GxSimpleCollection<string> AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00AL5_A227ContratoId ;
      private bool[] P00AL5_n227ContratoId ;
      private int[] P00AL5_A493ConvenioCategoriaId ;
      private bool[] P00AL5_n493ConvenioCategoriaId ;
      private short[] P00AL5_A328PropostaCratedBy ;
      private bool[] P00AL5_n328PropostaCratedBy ;
      private int[] P00AL5_A504PropostaPacienteClienteId ;
      private bool[] P00AL5_n504PropostaPacienteClienteId ;
      private int[] P00AL5_A553PropostaResponsavelId ;
      private bool[] P00AL5_n553PropostaResponsavelId ;
      private int[] P00AL5_A642PropostaClinicaId ;
      private bool[] P00AL5_n642PropostaClinicaId ;
      private decimal[] P00AL5_A513PropostaValorTaxa_F ;
      private string[] P00AL5_A494ConvenioCategoriaDescricao ;
      private bool[] P00AL5_n494ConvenioCategoriaDescricao ;
      private string[] P00AL5_A228ContratoNome ;
      private bool[] P00AL5_n228ContratoNome ;
      private string[] P00AL5_A652PropostaClinicaDocumento ;
      private bool[] P00AL5_n652PropostaClinicaDocumento ;
      private string[] P00AL5_A540PropostaPacienteClienteDocumento ;
      private bool[] P00AL5_n540PropostaPacienteClienteDocumento ;
      private string[] P00AL5_A580PropostaResponsavelDocumento ;
      private bool[] P00AL5_n580PropostaResponsavelDocumento ;
      private string[] P00AL5_A329PropostaStatus ;
      private bool[] P00AL5_n329PropostaStatus ;
      private string[] P00AL5_A512PropostaSecUserName ;
      private bool[] P00AL5_n512PropostaSecUserName ;
      private string[] P00AL5_A325PropostaDescricao ;
      private bool[] P00AL5_n325PropostaDescricao ;
      private string[] P00AL5_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00AL5_n505PropostaPacienteClienteRazaoSocial ;
      private DateTime[] P00AL5_A327PropostaCreatedAt ;
      private bool[] P00AL5_n327PropostaCreatedAt ;
      private decimal[] P00AL5_A501PropostaTaxaAdministrativa ;
      private bool[] P00AL5_n501PropostaTaxaAdministrativa ;
      private int[] P00AL5_A323PropostaId ;
      private int[] P00AL5_A649PropostaMaxReembolsoId_F ;
      private bool[] P00AL5_n649PropostaMaxReembolsoId_F ;
      private decimal[] P00AL5_A326PropostaValor ;
      private bool[] P00AL5_n326PropostaValor ;
      private decimal[] P00AL5_A508PropostaJurosMora ;
      private bool[] P00AL5_n508PropostaJurosMora ;
      private short[] P00AL5_A507PropostaSLA ;
      private bool[] P00AL5_n507PropostaSLA ;
      private DateTime[] P00AL5_A515PropostaDataCreditoCliente_F ;
      private bool[] P00AL5_n515PropostaDataCreditoCliente_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wpdemonstrativopagamentoexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AL5( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels ,
                                             string AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 ,
                                             short AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 ,
                                             string AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1 ,
                                             string AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1 ,
                                             string AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1 ,
                                             string AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1 ,
                                             string AV97Wpdemonstrativopagamentods_9_contratonome1 ,
                                             string AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1 ,
                                             bool AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 ,
                                             string AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 ,
                                             short AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 ,
                                             string AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2 ,
                                             string AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2 ,
                                             string AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2 ,
                                             string AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2 ,
                                             string AV107Wpdemonstrativopagamentods_19_contratonome2 ,
                                             string AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2 ,
                                             bool AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 ,
                                             string AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 ,
                                             short AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 ,
                                             string AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3 ,
                                             string AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3 ,
                                             string AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3 ,
                                             string AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3 ,
                                             string AV117Wpdemonstrativopagamentods_29_contratonome3 ,
                                             string AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3 ,
                                             string AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial ,
                                             string AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel ,
                                             string AV121Wpdemonstrativopagamentods_33_tfpropostadescricao ,
                                             decimal AV123Wpdemonstrativopagamentods_35_tfpropostavalor ,
                                             decimal AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to ,
                                             decimal AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa ,
                                             decimal AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to ,
                                             decimal AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f ,
                                             decimal AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to ,
                                             decimal AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora ,
                                             decimal AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to ,
                                             string AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel ,
                                             string AV135Wpdemonstrativopagamentods_47_tfpropostasecusername ,
                                             int AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             decimal A501PropostaTaxaAdministrativa ,
                                             decimal A508PropostaJurosMora ,
                                             string A512PropostaSecUserName ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV89Wpdemonstrativopagamentods_1_filterfulltext ,
                                             decimal A513PropostaValorTaxa_F ,
                                             decimal A514PropostaValorJurosMora_F ,
                                             int AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 ,
                                             int AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 ,
                                             DateTime AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente_f ,
                                             DateTime A515PropostaDataCreditoCliente_F ,
                                             DateTime AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente_f_to ,
                                             decimal AV133Wpdemonstrativopagamentods_45_tfpropostavalorjurosmora_f ,
                                             decimal AV134Wpdemonstrativopagamentods_46_tfpropostavalorjurosmora_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[96];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ConvenioCategoriaId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, CAST(COALESCE( T1.PropostaValor, 0) * CAST(( CAST(COALESCE( T1.PropostaTaxaAdministrativa, 0) AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10)) AS PropostaValorTaxa_F, T3.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T4.SecUserFullName AS PropostaSecUserName, T1.PropostaDescricao, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaCreatedAt, T1.PropostaTaxaAdministrativa, T1.PropostaId, COALESCE( T9.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, T1.PropostaValor, T1.PropostaJurosMora, T1.PropostaSLA, COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM ((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(COALESCE( T15.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T10.TituloPropostaId AS TituloPropostaId FROM ((((Titulo T10 LEFT JOIN NotaFiscalParcelamento T11 ON T11.NotaFiscalParcelamentoID = T10.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T12 ON T12.NotaFiscalId";
         scmdbuf += " = T11.NotaFiscalId) LEFT JOIN Proposta T13 ON T13.PropostaId = T10.TituloPropostaId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T10.TituloId = TituloId GROUP BY TituloId ) T15 ON T15.TituloId = T10.TituloId),  Proposta T14 WHERE (T1.PropostaId = T10.TituloPropostaId) AND (T12.ClienteId = T13.PropostaPacienteClienteId) AND (T10.TituloPropostaId = T14.PropostaId) AND (T10.TituloTipo = ( 'DEBITO')) GROUP BY T10.TituloPropostaId ) T8 ON T8.TituloPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T9 ON T9.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 0 and ( Not (:AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 1 and ( Not (:AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 = 2 and ( Not (:AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 0 and ( Not (:AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 1 and ( Not (:AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 and :AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 = 2 and ( Not (:AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 0 and ( Not (:AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) < :AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 1 and ( Not (:AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) = :AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 and :AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 = 2 and ( Not (:AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T9.PropostaMaxReembolsoId_F, 0) > :AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') >= :AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente))");
         AddWhere(sWhereString, "((:AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente = DATE '00010101') or ( COALESCE( T8.PropostaDataCreditoCliente_F, DATE '00010101') <= :AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente))");
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumen)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaoso)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV97Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wpdemonstrativopagamentods_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV97Wpdemonstrativopagamentods_9_contratonome1)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wpdemonstrativopagamentods_16_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int5[63] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int5[64] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpdemonstrativopagamentods_18_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int5[65] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV107Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int5[66] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpdemonstrativopagamentods_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV107Wpdemonstrativopagamentods_19_contratonome2)");
         }
         else
         {
            GXv_int5[67] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int5[68] = 1;
         }
         if ( AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int5[69] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int5[70] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento)");
         }
         else
         {
            GXv_int5[71] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int5[72] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpdemonstrativopagamentods_26_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocum)");
         }
         else
         {
            GXv_int5[73] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int5[74] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int5[75] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int5[76] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wpdemonstrativopagamentods_28_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazao)");
         }
         else
         {
            GXv_int5[77] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV117Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int5[78] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpdemonstrativopagamentods_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV117Wpdemonstrativopagamentods_29_contratonome3)");
         }
         else
         {
            GXv_int5[79] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like :lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int5[80] = 1;
         }
         if ( AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T3.ConvenioCategoriaDescricao like '%' || :lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int5[81] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz)");
         }
         else
         {
            GXv_int5[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz))");
         }
         else
         {
            GXv_int5[83] = 1;
         }
         if ( StringUtil.StrCmp(AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpdemonstrativopagamentods_33_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV121Wpdemonstrativopagamentods_33_tfpropostadescricao)");
         }
         else
         {
            GXv_int5[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int5[85] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV123Wpdemonstrativopagamentods_35_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV123Wpdemonstrativopagamentods_35_tfpropostavalor)");
         }
         else
         {
            GXv_int5[86] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to)");
         }
         else
         {
            GXv_int5[87] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa >= :AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int5[88] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaTaxaAdministrativa <= :AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa)");
         }
         else
         {
            GXv_int5[89] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) >= :AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f)");
         }
         else
         {
            GXv_int5[90] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to) )
         {
            AddWhere(sWhereString, "(( CAST(T1.PropostaValor * CAST(( CAST(T1.PropostaTaxaAdministrativa AS NUMERIC(26,10)) / 100) AS NUMERIC(28,10)) AS NUMERIC(28,10))) <= :AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to)");
         }
         else
         {
            GXv_int5[91] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora >= :AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora)");
         }
         else
         {
            GXv_int5[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaJurosMora <= :AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to)");
         }
         else
         {
            GXv_int5[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wpdemonstrativopagamentods_47_tfpropostasecusername)) ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName like :lV135Wpdemonstrativopagamentods_47_tfpropostasecusername)");
         }
         else
         {
            GXv_int5[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel)) && ! ( StringUtil.StrCmp(AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName = ( :AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel))");
         }
         else
         {
            GXv_int5[95] = 1;
         }
         if ( StringUtil.StrCmp(AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T4.SecUserFullName))=0))");
         }
         if ( AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV137Wpdemonstrativopagamentods_49_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.PropostaCreatedAt DESC";
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
            scmdbuf += " ORDER BY T1.PropostaDescricao";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaValor";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaValor DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaTaxaAdministrativa";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaTaxaAdministrativa DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaJurosMora";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaJurosMora DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.SecUserFullName";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.SecUserFullName DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AL5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (string)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (int)dynConstraints[59] , (int)dynConstraints[60] , (int)dynConstraints[61] , (int)dynConstraints[62] , (DateTime)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (decimal)dynConstraints[66] , (decimal)dynConstraints[67] );
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
          Object[] prmP00AL5;
          prmP00AL5 = new Object[] {
          new ParDef("AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV90Wpdemonstrativopagamentods_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV91Wpdemonstrativopagamentods_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV92Wpdemonstrativopagamentods_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV99Wpdemonstrativopagamentods_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV100Wpdemonstrativopagamentods_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV101Wpdemonstrativopagamentods_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV102Wpdemonstrativopagamentods_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV109Wpdemonstrativopagamentods_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV110Wpdemonstrativopagamentods_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV111Wpdemonstrativopagamentods_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV112Wpdemonstrativopagamentods_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV131Wpdemonstrativopagamentods_43_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("AV132Wpdemonstrativopagamentods_44_tfpropostadatacreditocliente",GXType.Date,8,0) ,
          new ParDef("lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV93Wpdemonstrativopagamentods_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV94Wpdemonstrativopagamentods_6_propostapacienteclientedocumen",GXType.VarChar,20,0) ,
          new ParDef("lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV95Wpdemonstrativopagamentods_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV96Wpdemonstrativopagamentods_8_propostapacienteclienterazaoso",GXType.VarChar,150,0) ,
          new ParDef("lV97Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV97Wpdemonstrativopagamentods_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV98Wpdemonstrativopagamentods_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV103Wpdemonstrativopagamentods_15_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV104Wpdemonstrativopagamentods_16_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV105Wpdemonstrativopagamentods_17_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV106Wpdemonstrativopagamentods_18_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV107Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV107Wpdemonstrativopagamentods_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV108Wpdemonstrativopagamentods_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV113Wpdemonstrativopagamentods_25_propostaresponsaveldocumento",GXType.VarChar,20,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV114Wpdemonstrativopagamentods_26_propostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV115Wpdemonstrativopagamentods_27_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV116Wpdemonstrativopagamentods_28_propostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV117Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV117Wpdemonstrativopagamentods_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV118Wpdemonstrativopagamentods_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV119Wpdemonstrativopagamentods_31_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("AV120Wpdemonstrativopagamentods_32_tfpropostapacienteclienteraz",GXType.VarChar,150,0) ,
          new ParDef("lV121Wpdemonstrativopagamentods_33_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV122Wpdemonstrativopagamentods_34_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV123Wpdemonstrativopagamentods_35_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV124Wpdemonstrativopagamentods_36_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV125Wpdemonstrativopagamentods_37_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV126Wpdemonstrativopagamentods_38_tfpropostataxaadministrativa",GXType.Number,16,4) ,
          new ParDef("AV127Wpdemonstrativopagamentods_39_tfpropostavalortaxa_f",GXType.Number,18,2) ,
          new ParDef("AV128Wpdemonstrativopagamentods_40_tfpropostavalortaxa_f_to",GXType.Number,18,2) ,
          new ParDef("AV129Wpdemonstrativopagamentods_41_tfpropostajurosmora",GXType.Number,16,4) ,
          new ParDef("AV130Wpdemonstrativopagamentods_42_tfpropostajurosmora_to",GXType.Number,16,4) ,
          new ParDef("lV135Wpdemonstrativopagamentods_47_tfpropostasecusername",GXType.VarChar,150,0) ,
          new ParDef("AV136Wpdemonstrativopagamentods_48_tfpropostasecusername_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AL5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AL5,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[31])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((short[]) buf[42])[0] = rslt.getShort(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[44])[0] = rslt.getGXDate(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                return;
       }
    }

 }

}
