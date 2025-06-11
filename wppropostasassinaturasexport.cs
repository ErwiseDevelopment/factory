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
   public class wppropostasassinaturasexport : GXProcedure
   {
      public wppropostasassinaturasexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wppropostasassinaturasexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WpPropostasAssinaturasExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV60PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV60PropostaMaxReembolsoId_F1) )
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
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV60PropostaMaxReembolsoId_F1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV61PropostaResponsavelDocumento1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61PropostaResponsavelDocumento1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61PropostaResponsavelDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV21PropostaPacienteClienteRazaoSocial1 = AV39GridStateDynamicFilter.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV22PropostaPacienteClienteDocumento1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PropostaPacienteClienteDocumento1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22PropostaPacienteClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV62PropostaClinicaDocumento1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62PropostaClinicaDocumento1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62PropostaClinicaDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV23ContratoNome1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ContratoNome1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ContratoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV24ConvenioCategoriaDescricao1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConvenioCategoriaDescricao1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ConvenioCategoriaDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV25DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(2));
               AV26DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV63PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV63PropostaMaxReembolsoId_F2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV63PropostaMaxReembolsoId_F2;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV64PropostaResponsavelDocumento2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64PropostaResponsavelDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64PropostaResponsavelDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV28PropostaPacienteClienteRazaoSocial2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PropostaPacienteClienteRazaoSocial2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28PropostaPacienteClienteRazaoSocial2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV29PropostaPacienteClienteDocumento2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29PropostaPacienteClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29PropostaPacienteClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV65PropostaClinicaDocumento2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65PropostaClinicaDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV65PropostaClinicaDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV30ContratoNome2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ContratoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ContratoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV31ConvenioCategoriaDescricao2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ConvenioCategoriaDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31ConvenioCategoriaDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV32DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(3));
                  AV33DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV66PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV66PropostaMaxReembolsoId_F3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV66PropostaMaxReembolsoId_F3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV67PropostaResponsavelDocumento3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67PropostaResponsavelDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67PropostaResponsavelDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV35PropostaPacienteClienteRazaoSocial3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35PropostaPacienteClienteRazaoSocial3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Proposta Paciente Cliente Razao Social", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35PropostaPacienteClienteRazaoSocial3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV36PropostaPacienteClienteDocumento3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36PropostaPacienteClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36PropostaPacienteClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV68PropostaClinicaDocumento3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68PropostaClinicaDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68PropostaClinicaDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV37ContratoNome3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ContratoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37ContratoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV38ConvenioCategoriaDescricao3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ConvenioCategoriaDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38ConvenioCategoriaDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProcedimentosMedicosNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Procedimento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProcedimentosMedicosNome_Sel)) ? "(Vazio)" : AV45TFProcedimentosMedicosNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProcedimentosMedicosNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Procedimento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFProcedimentosMedicosNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV48TFPropostaValor) && (Convert.ToDecimal(0)==AV49TFPropostaValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV48TFPropostaValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV49TFPropostaValor_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPropostaPacienteClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPropostaPacienteClienteRazaoSocial_Sel)) ? "(Vazio)" : AV55TFPropostaPacienteClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFPropostaPacienteClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFPropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFPropostaPacienteClienteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFPropostaPacienteClienteDocumento_Sel)) ? "(Vazio)" : AV57TFPropostaPacienteClienteDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFPropostaPacienteClienteDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFPropostaPacienteClienteDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV52TFPropostaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV53i = 1;
            AV69GXV1 = 1;
            while ( AV69GXV1 <= AV52TFPropostaStatus_Sels.Count )
            {
               AV51TFPropostaStatus_Sel = ((string)AV52TFPropostaStatus_Sels.Item(AV69GXV1));
               if ( AV53i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusproposta.getDescription(context,AV51TFPropostaStatus_Sel);
               AV53i = (long)(AV53i+1);
               AV69GXV1 = (int)(AV69GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Procedimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Paciente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "CPF";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV71Wppropostasassinaturasds_1_filterfulltext = AV18FilterFullText;
         AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = AV60PropostaMaxReembolsoId_F1;
         AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = AV61PropostaResponsavelDocumento1;
         AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = AV21PropostaPacienteClienteRazaoSocial1;
         AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = AV22PropostaPacienteClienteDocumento1;
         AV78Wppropostasassinaturasds_8_propostaclinicadocumento1 = AV62PropostaClinicaDocumento1;
         AV79Wppropostasassinaturasds_9_contratonome1 = AV23ContratoNome1;
         AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 = AV24ConvenioCategoriaDescricao1;
         AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = AV63PropostaMaxReembolsoId_F2;
         AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = AV64PropostaResponsavelDocumento2;
         AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = AV28PropostaPacienteClienteRazaoSocial2;
         AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = AV29PropostaPacienteClienteDocumento2;
         AV88Wppropostasassinaturasds_18_propostaclinicadocumento2 = AV65PropostaClinicaDocumento2;
         AV89Wppropostasassinaturasds_19_contratonome2 = AV30ContratoNome2;
         AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 = AV31ConvenioCategoriaDescricao2;
         AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = AV66PropostaMaxReembolsoId_F3;
         AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = AV67PropostaResponsavelDocumento3;
         AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = AV35PropostaPacienteClienteRazaoSocial3;
         AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = AV36PropostaPacienteClienteDocumento3;
         AV98Wppropostasassinaturasds_28_propostaclinicadocumento3 = AV68PropostaClinicaDocumento3;
         AV99Wppropostasassinaturasds_29_contratonome3 = AV37ContratoNome3;
         AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 = AV38ConvenioCategoriaDescricao3;
         AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = AV44TFProcedimentosMedicosNome;
         AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = AV45TFProcedimentosMedicosNome_Sel;
         AV103Wppropostasassinaturasds_33_tfpropostavalor = AV48TFPropostaValor;
         AV104Wppropostasassinaturasds_34_tfpropostavalor_to = AV49TFPropostaValor_To;
         AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = AV54TFPropostaPacienteClienteRazaoSocial;
         AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = AV55TFPropostaPacienteClienteRazaoSocial_Sel;
         AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = AV56TFPropostaPacienteClienteDocumento;
         AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = AV57TFPropostaPacienteClienteDocumento_Sel;
         AV109Wppropostasassinaturasds_39_tfpropostastatus_sels = AV52TFPropostaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV109Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                              AV71Wppropostasassinaturasds_1_filterfulltext ,
                                              AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                              AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                              AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                              AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                              AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                              AV78Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                              AV79Wppropostasassinaturasds_9_contratonome1 ,
                                              AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                              AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                              AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                              AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                              AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                              AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                              AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                              AV88Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                              AV89Wppropostasassinaturasds_19_contratonome2 ,
                                              AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                              AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                              AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                              AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                              AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                              AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                              AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                              AV98Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                              AV99Wppropostasassinaturasds_29_contratonome3 ,
                                              AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                              AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                              AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                              AV103Wppropostasassinaturasds_33_tfpropostavalor ,
                                              AV104Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                              AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                              AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                              AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                              AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                              AV109Wppropostasassinaturasds_39_tfpropostastatus_sels.Count ,
                                              A377ProcedimentosMedicosNome ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A580PropostaResponsavelDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A228ContratoNome ,
                                              A494ConvenioCategoriaDescricao ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                              AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV71Wppropostasassinaturasds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext), "%", "");
         lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1), "%", "");
         lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1), "%", "");
         lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1), "%", "");
         lV78Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV78Wppropostasassinaturasds_8_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV78Wppropostasassinaturasds_8_propostaclinicadocumento1), "%", "");
         lV79Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV79Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV79Wppropostasassinaturasds_9_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV79Wppropostasassinaturasds_9_contratonome1), "%", "");
         lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1), "%", "");
         lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2), "%", "");
         lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2), "%", "");
         lV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2), "%", "");
         lV88Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV88Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV88Wppropostasassinaturasds_18_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV88Wppropostasassinaturasds_18_propostaclinicadocumento2), "%", "");
         lV89Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV89Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV89Wppropostasassinaturasds_19_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV89Wppropostasassinaturasds_19_contratonome2), "%", "");
         lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2), "%", "");
         lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3), "%", "");
         lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3), "%", "");
         lV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3), "%", "");
         lV98Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV98Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV98Wppropostasassinaturasds_28_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV98Wppropostasassinaturasds_28_propostaclinicadocumento3), "%", "");
         lV99Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV99Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV99Wppropostasassinaturasds_29_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV99Wppropostasassinaturasds_29_contratonome3), "%", "");
         lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3), "%", "");
         lV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome), "%", "");
         lV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial), "%", "");
         lV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento), "%", "");
         /* Using cursor P00B63 */
         pr_default.execute(0, new Object[] {AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1, AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1, AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2, AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2, AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2, AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3, AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3, AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV71Wppropostasassinaturasds_1_filterfulltext, lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1, lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1, lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1, lV78Wppropostasassinaturasds_8_propostaclinicadocumento1, lV78Wppropostasassinaturasds_8_propostaclinicadocumento1, lV79Wppropostasassinaturasds_9_contratonome1, lV79Wppropostasassinaturasds_9_contratonome1, lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1, lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2, lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2, lV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2, lV88Wppropostasassinaturasds_18_propostaclinicadocumento2, lV88Wppropostasassinaturasds_18_propostaclinicadocumento2, lV89Wppropostasassinaturasds_19_contratonome2, lV89Wppropostasassinaturasds_19_contratonome2, lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2, lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3, lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3, lV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3, lV98Wppropostasassinaturasds_28_propostaclinicadocumento3, lV98Wppropostasassinaturasds_28_propostaclinicadocumento3, lV99Wppropostasassinaturasds_29_contratonome3, lV99Wppropostasassinaturasds_29_contratonome3, lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3, lV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome, AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, AV103Wppropostasassinaturasds_33_tfpropostavalor, AV104Wppropostasassinaturasds_34_tfpropostavalor_to, lV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial, AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, lV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento, AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P00B63_A227ContratoId[0];
            n227ContratoId = P00B63_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00B63_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00B63_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = P00B63_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P00B63_n493ConvenioCategoriaId[0];
            A504PropostaPacienteClienteId = P00B63_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00B63_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P00B63_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00B63_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P00B63_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00B63_n642PropostaClinicaId[0];
            A326PropostaValor = P00B63_A326PropostaValor[0];
            n326PropostaValor = P00B63_n326PropostaValor[0];
            A494ConvenioCategoriaDescricao = P00B63_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B63_n494ConvenioCategoriaDescricao[0];
            A228ContratoNome = P00B63_A228ContratoNome[0];
            n228ContratoNome = P00B63_n228ContratoNome[0];
            A652PropostaClinicaDocumento = P00B63_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B63_n652PropostaClinicaDocumento[0];
            A580PropostaResponsavelDocumento = P00B63_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B63_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P00B63_A329PropostaStatus[0];
            n329PropostaStatus = P00B63_n329PropostaStatus[0];
            A540PropostaPacienteClienteDocumento = P00B63_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B63_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00B63_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B63_n505PropostaPacienteClienteRazaoSocial[0];
            A377ProcedimentosMedicosNome = P00B63_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B63_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00B63_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P00B63_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B63_n649PropostaMaxReembolsoId_F[0];
            A228ContratoNome = P00B63_A228ContratoNome[0];
            n228ContratoNome = P00B63_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00B63_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00B63_n377ProcedimentosMedicosNome[0];
            A494ConvenioCategoriaDescricao = P00B63_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P00B63_n494ConvenioCategoriaDescricao[0];
            A540PropostaPacienteClienteDocumento = P00B63_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P00B63_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P00B63_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00B63_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P00B63_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P00B63_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P00B63_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P00B63_n652PropostaClinicaDocumento[0];
            A649PropostaMaxReembolsoId_F = P00B63_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P00B63_n649PropostaMaxReembolsoId_F[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A377ProcedimentosMedicosNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(A326PropostaValor);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A505PropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A540PropostaPacienteClienteDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = gxdomaindmstatusproposta.getDescription(context,A329PropostaStatus);
            if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
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
         AV40Session.Set("WWPExportFilePath", AV11Filename);
         AV40Session.Set("WWPExportFileName", "WpPropostasAssinaturasExport.xlsx");
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
         if ( StringUtil.StrCmp(AV40Session.Get("WpPropostasAssinaturasGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpPropostasAssinaturasGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("WpPropostasAssinaturasGridState"), null, "", "");
         }
         AV16OrderedBy = AV42GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV42GridState.gxTpr_Ordereddsc;
         AV110GXV2 = 1;
         while ( AV110GXV2 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV110GXV2));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV44TFProcedimentosMedicosNome = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV45TFProcedimentosMedicosNome_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV48TFPropostaValor = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, ".");
               AV49TFPropostaValor_To = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV54TFPropostaPacienteClienteRazaoSocial = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV55TFPropostaPacienteClienteRazaoSocial_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV56TFPropostaPacienteClienteDocumento = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV57TFPropostaPacienteClienteDocumento_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV52TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            AV110GXV2 = (int)(AV110GXV2+1);
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
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV61PropostaResponsavelDocumento1 = "";
         AV21PropostaPacienteClienteRazaoSocial1 = "";
         AV22PropostaPacienteClienteDocumento1 = "";
         AV62PropostaClinicaDocumento1 = "";
         AV23ContratoNome1 = "";
         AV24ConvenioCategoriaDescricao1 = "";
         AV26DynamicFiltersSelector2 = "";
         AV64PropostaResponsavelDocumento2 = "";
         AV28PropostaPacienteClienteRazaoSocial2 = "";
         AV29PropostaPacienteClienteDocumento2 = "";
         AV65PropostaClinicaDocumento2 = "";
         AV30ContratoNome2 = "";
         AV31ConvenioCategoriaDescricao2 = "";
         AV33DynamicFiltersSelector3 = "";
         AV67PropostaResponsavelDocumento3 = "";
         AV35PropostaPacienteClienteRazaoSocial3 = "";
         AV36PropostaPacienteClienteDocumento3 = "";
         AV68PropostaClinicaDocumento3 = "";
         AV37ContratoNome3 = "";
         AV38ConvenioCategoriaDescricao3 = "";
         AV45TFProcedimentosMedicosNome_Sel = "";
         AV44TFProcedimentosMedicosNome = "";
         AV55TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV54TFPropostaPacienteClienteRazaoSocial = "";
         AV57TFPropostaPacienteClienteDocumento_Sel = "";
         AV56TFPropostaPacienteClienteDocumento = "";
         AV52TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV51TFPropostaStatus_Sel = "";
         AV71Wppropostasassinaturasds_1_filterfulltext = "";
         AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 = "";
         AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = "";
         AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = "";
         AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = "";
         AV78Wppropostasassinaturasds_8_propostaclinicadocumento1 = "";
         AV79Wppropostasassinaturasds_9_contratonome1 = "";
         AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 = "";
         AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 = "";
         AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = "";
         AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = "";
         AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = "";
         AV88Wppropostasassinaturasds_18_propostaclinicadocumento2 = "";
         AV89Wppropostasassinaturasds_19_contratonome2 = "";
         AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 = "";
         AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 = "";
         AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = "";
         AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = "";
         AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = "";
         AV98Wppropostasassinaturasds_28_propostaclinicadocumento3 = "";
         AV99Wppropostasassinaturasds_29_contratonome3 = "";
         AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 = "";
         AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = "";
         AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel = "";
         AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = "";
         AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel = "";
         AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = "";
         AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel = "";
         AV109Wppropostasassinaturasds_39_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV71Wppropostasassinaturasds_1_filterfulltext = "";
         lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 = "";
         lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 = "";
         lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 = "";
         lV78Wppropostasassinaturasds_8_propostaclinicadocumento1 = "";
         lV79Wppropostasassinaturasds_9_contratonome1 = "";
         lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 = "";
         lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 = "";
         lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 = "";
         lV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 = "";
         lV88Wppropostasassinaturasds_18_propostaclinicadocumento2 = "";
         lV89Wppropostasassinaturasds_19_contratonome2 = "";
         lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 = "";
         lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 = "";
         lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 = "";
         lV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 = "";
         lV98Wppropostasassinaturasds_28_propostaclinicadocumento3 = "";
         lV99Wppropostasassinaturasds_29_contratonome3 = "";
         lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 = "";
         lV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome = "";
         lV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial = "";
         lV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento = "";
         A329PropostaStatus = "";
         A377ProcedimentosMedicosNome = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A580PropostaResponsavelDocumento = "";
         A652PropostaClinicaDocumento = "";
         A228ContratoNome = "";
         A494ConvenioCategoriaDescricao = "";
         P00B63_A227ContratoId = new int[1] ;
         P00B63_n227ContratoId = new bool[] {false} ;
         P00B63_A376ProcedimentosMedicosId = new int[1] ;
         P00B63_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00B63_A493ConvenioCategoriaId = new int[1] ;
         P00B63_n493ConvenioCategoriaId = new bool[] {false} ;
         P00B63_A504PropostaPacienteClienteId = new int[1] ;
         P00B63_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00B63_A553PropostaResponsavelId = new int[1] ;
         P00B63_n553PropostaResponsavelId = new bool[] {false} ;
         P00B63_A642PropostaClinicaId = new int[1] ;
         P00B63_n642PropostaClinicaId = new bool[] {false} ;
         P00B63_A326PropostaValor = new decimal[1] ;
         P00B63_n326PropostaValor = new bool[] {false} ;
         P00B63_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P00B63_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P00B63_A228ContratoNome = new string[] {""} ;
         P00B63_n228ContratoNome = new bool[] {false} ;
         P00B63_A652PropostaClinicaDocumento = new string[] {""} ;
         P00B63_n652PropostaClinicaDocumento = new bool[] {false} ;
         P00B63_A580PropostaResponsavelDocumento = new string[] {""} ;
         P00B63_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P00B63_A329PropostaStatus = new string[] {""} ;
         P00B63_n329PropostaStatus = new bool[] {false} ;
         P00B63_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P00B63_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P00B63_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00B63_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00B63_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00B63_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00B63_A323PropostaId = new int[1] ;
         P00B63_A649PropostaMaxReembolsoId_F = new int[1] ;
         P00B63_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         GXt_char1 = "";
         AV40Session = context.GetSession();
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50TFPropostaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppropostasassinaturasexport__default(),
            new Object[][] {
                new Object[] {
               P00B63_A227ContratoId, P00B63_n227ContratoId, P00B63_A376ProcedimentosMedicosId, P00B63_n376ProcedimentosMedicosId, P00B63_A493ConvenioCategoriaId, P00B63_n493ConvenioCategoriaId, P00B63_A504PropostaPacienteClienteId, P00B63_n504PropostaPacienteClienteId, P00B63_A553PropostaResponsavelId, P00B63_n553PropostaResponsavelId,
               P00B63_A642PropostaClinicaId, P00B63_n642PropostaClinicaId, P00B63_A326PropostaValor, P00B63_n326PropostaValor, P00B63_A494ConvenioCategoriaDescricao, P00B63_n494ConvenioCategoriaDescricao, P00B63_A228ContratoNome, P00B63_n228ContratoNome, P00B63_A652PropostaClinicaDocumento, P00B63_n652PropostaClinicaDocumento,
               P00B63_A580PropostaResponsavelDocumento, P00B63_n580PropostaResponsavelDocumento, P00B63_A329PropostaStatus, P00B63_n329PropostaStatus, P00B63_A540PropostaPacienteClienteDocumento, P00B63_n540PropostaPacienteClienteDocumento, P00B63_A505PropostaPacienteClienteRazaoSocial, P00B63_n505PropostaPacienteClienteRazaoSocial, P00B63_A377ProcedimentosMedicosNome, P00B63_n377ProcedimentosMedicosNome,
               P00B63_A323PropostaId, P00B63_A649PropostaMaxReembolsoId_F, P00B63_n649PropostaMaxReembolsoId_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV34DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 ;
      private short AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 ;
      private short AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV60PropostaMaxReembolsoId_F1 ;
      private int AV63PropostaMaxReembolsoId_F2 ;
      private int AV66PropostaMaxReembolsoId_F3 ;
      private int AV69GXV1 ;
      private int AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ;
      private int AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ;
      private int AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 ;
      private int AV109Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A323PropostaId ;
      private int AV110GXV2 ;
      private long AV53i ;
      private decimal AV48TFPropostaValor ;
      private decimal AV49TFPropostaValor_To ;
      private decimal AV103Wppropostasassinaturasds_33_tfpropostavalor ;
      private decimal AV104Wppropostasassinaturasds_34_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV32DynamicFiltersEnabled3 ;
      private bool AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 ;
      private bool AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n493ConvenioCategoriaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n326PropostaValor ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n228ContratoNome ;
      private bool n652PropostaClinicaDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n329PropostaStatus ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n649PropostaMaxReembolsoId_F ;
      private string AV50TFPropostaStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV61PropostaResponsavelDocumento1 ;
      private string AV21PropostaPacienteClienteRazaoSocial1 ;
      private string AV22PropostaPacienteClienteDocumento1 ;
      private string AV62PropostaClinicaDocumento1 ;
      private string AV23ContratoNome1 ;
      private string AV24ConvenioCategoriaDescricao1 ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV64PropostaResponsavelDocumento2 ;
      private string AV28PropostaPacienteClienteRazaoSocial2 ;
      private string AV29PropostaPacienteClienteDocumento2 ;
      private string AV65PropostaClinicaDocumento2 ;
      private string AV30ContratoNome2 ;
      private string AV31ConvenioCategoriaDescricao2 ;
      private string AV33DynamicFiltersSelector3 ;
      private string AV67PropostaResponsavelDocumento3 ;
      private string AV35PropostaPacienteClienteRazaoSocial3 ;
      private string AV36PropostaPacienteClienteDocumento3 ;
      private string AV68PropostaClinicaDocumento3 ;
      private string AV37ContratoNome3 ;
      private string AV38ConvenioCategoriaDescricao3 ;
      private string AV45TFProcedimentosMedicosNome_Sel ;
      private string AV44TFProcedimentosMedicosNome ;
      private string AV55TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV54TFPropostaPacienteClienteRazaoSocial ;
      private string AV57TFPropostaPacienteClienteDocumento_Sel ;
      private string AV56TFPropostaPacienteClienteDocumento ;
      private string AV51TFPropostaStatus_Sel ;
      private string AV71Wppropostasassinaturasds_1_filterfulltext ;
      private string AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 ;
      private string AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ;
      private string AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ;
      private string AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ;
      private string AV78Wppropostasassinaturasds_8_propostaclinicadocumento1 ;
      private string AV79Wppropostasassinaturasds_9_contratonome1 ;
      private string AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 ;
      private string AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 ;
      private string AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ;
      private string AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ;
      private string AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ;
      private string AV88Wppropostasassinaturasds_18_propostaclinicadocumento2 ;
      private string AV89Wppropostasassinaturasds_19_contratonome2 ;
      private string AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 ;
      private string AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 ;
      private string AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ;
      private string AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ;
      private string AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ;
      private string AV98Wppropostasassinaturasds_28_propostaclinicadocumento3 ;
      private string AV99Wppropostasassinaturasds_29_contratonome3 ;
      private string AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 ;
      private string AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ;
      private string AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ;
      private string AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ;
      private string AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ;
      private string AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ;
      private string AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ;
      private string lV71Wppropostasassinaturasds_1_filterfulltext ;
      private string lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ;
      private string lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ;
      private string lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ;
      private string lV78Wppropostasassinaturasds_8_propostaclinicadocumento1 ;
      private string lV79Wppropostasassinaturasds_9_contratonome1 ;
      private string lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 ;
      private string lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ;
      private string lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ;
      private string lV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ;
      private string lV88Wppropostasassinaturasds_18_propostaclinicadocumento2 ;
      private string lV89Wppropostasassinaturasds_19_contratonome2 ;
      private string lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 ;
      private string lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ;
      private string lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ;
      private string lV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ;
      private string lV98Wppropostasassinaturasds_28_propostaclinicadocumento3 ;
      private string lV99Wppropostasassinaturasds_29_contratonome3 ;
      private string lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 ;
      private string lV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ;
      private string lV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ;
      private string lV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ;
      private string A329PropostaStatus ;
      private string A377ProcedimentosMedicosNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A580PropostaResponsavelDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A228ContratoNome ;
      private string A494ConvenioCategoriaDescricao ;
      private IGxSession AV40Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV52TFPropostaStatus_Sels ;
      private GxSimpleCollection<string> AV109Wppropostasassinaturasds_39_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00B63_A227ContratoId ;
      private bool[] P00B63_n227ContratoId ;
      private int[] P00B63_A376ProcedimentosMedicosId ;
      private bool[] P00B63_n376ProcedimentosMedicosId ;
      private int[] P00B63_A493ConvenioCategoriaId ;
      private bool[] P00B63_n493ConvenioCategoriaId ;
      private int[] P00B63_A504PropostaPacienteClienteId ;
      private bool[] P00B63_n504PropostaPacienteClienteId ;
      private int[] P00B63_A553PropostaResponsavelId ;
      private bool[] P00B63_n553PropostaResponsavelId ;
      private int[] P00B63_A642PropostaClinicaId ;
      private bool[] P00B63_n642PropostaClinicaId ;
      private decimal[] P00B63_A326PropostaValor ;
      private bool[] P00B63_n326PropostaValor ;
      private string[] P00B63_A494ConvenioCategoriaDescricao ;
      private bool[] P00B63_n494ConvenioCategoriaDescricao ;
      private string[] P00B63_A228ContratoNome ;
      private bool[] P00B63_n228ContratoNome ;
      private string[] P00B63_A652PropostaClinicaDocumento ;
      private bool[] P00B63_n652PropostaClinicaDocumento ;
      private string[] P00B63_A580PropostaResponsavelDocumento ;
      private bool[] P00B63_n580PropostaResponsavelDocumento ;
      private string[] P00B63_A329PropostaStatus ;
      private bool[] P00B63_n329PropostaStatus ;
      private string[] P00B63_A540PropostaPacienteClienteDocumento ;
      private bool[] P00B63_n540PropostaPacienteClienteDocumento ;
      private string[] P00B63_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00B63_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00B63_A377ProcedimentosMedicosNome ;
      private bool[] P00B63_n377ProcedimentosMedicosNome ;
      private int[] P00B63_A323PropostaId ;
      private int[] P00B63_A649PropostaMaxReembolsoId_F ;
      private bool[] P00B63_n649PropostaMaxReembolsoId_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wppropostasassinaturasexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B63( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV109Wppropostasassinaturasds_39_tfpropostastatus_sels ,
                                             string AV71Wppropostasassinaturasds_1_filterfulltext ,
                                             string AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 ,
                                             short AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 ,
                                             string AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1 ,
                                             string AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1 ,
                                             string AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1 ,
                                             string AV78Wppropostasassinaturasds_8_propostaclinicadocumento1 ,
                                             string AV79Wppropostasassinaturasds_9_contratonome1 ,
                                             string AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1 ,
                                             bool AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 ,
                                             string AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 ,
                                             short AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 ,
                                             string AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2 ,
                                             string AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2 ,
                                             string AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2 ,
                                             string AV88Wppropostasassinaturasds_18_propostaclinicadocumento2 ,
                                             string AV89Wppropostasassinaturasds_19_contratonome2 ,
                                             string AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2 ,
                                             bool AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 ,
                                             string AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 ,
                                             short AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 ,
                                             string AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3 ,
                                             string AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3 ,
                                             string AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3 ,
                                             string AV98Wppropostasassinaturasds_28_propostaclinicadocumento3 ,
                                             string AV99Wppropostasassinaturasds_29_contratonome3 ,
                                             string AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3 ,
                                             string AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel ,
                                             string AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome ,
                                             decimal AV103Wppropostasassinaturasds_33_tfpropostavalor ,
                                             decimal AV104Wppropostasassinaturasds_34_tfpropostavalor_to ,
                                             string AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial ,
                                             string AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel ,
                                             string AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento ,
                                             int AV109Wppropostasassinaturasds_39_tfpropostastatus_sels_Count ,
                                             string A377ProcedimentosMedicosNome ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             string A540PropostaPacienteClienteDocumento ,
                                             string A580PropostaResponsavelDocumento ,
                                             string A652PropostaClinicaDocumento ,
                                             string A228ContratoNome ,
                                             string A494ConvenioCategoriaDescricao ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 ,
                                             int A649PropostaMaxReembolsoId_F ,
                                             int AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 ,
                                             int AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[98];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaValor, T4.ConvenioCategoriaDescricao, T2.ContratoNome, T7.ClienteDocumento AS PropostaClinicaDocumento, T6.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T5.ClienteDocumento AS PropostaPacienteClienteDocumento, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T8.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T4 ON T4.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T8 ON T8.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(Not ( :AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV72Wppropostasassinaturasds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 0 and ( Not (:AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 1 and ( Not (:AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 and :AV82Wppropostasassinaturasds_12_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 = 2 and ( Not (:AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 0 and ( Not (:AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) < :AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 1 and ( Not (:AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) = :AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 and :AV92Wppropostasassinaturasds_22_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 = 2 and ( Not (:AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T8.PropostaMaxReembolsoId_F, 0) > :AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wppropostasassinaturasds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ProcedimentosMedicosNome like '%' || :lV71Wppropostasassinaturasds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV71Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV71Wppropostasassinaturasds_1_filterfulltext) or ( T5.ClienteDocumento like '%' || :lV71Wppropostasassinaturasds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV71Wppropostasassinaturasds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')))");
         }
         else
         {
            GXv_int3[42] = 1;
            GXv_int3[43] = 1;
            GXv_int3[44] = 1;
            GXv_int3[45] = 1;
            GXv_int3[46] = 1;
            GXv_int3[47] = 1;
            GXv_int3[48] = 1;
            GXv_int3[49] = 1;
            GXv_int3[50] = 1;
            GXv_int3[51] = 1;
            GXv_int3[52] = 1;
            GXv_int3[53] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wppropostasassinaturasds_6_propostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosoci)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wppropostasassinaturasds_7_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV78Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wppropostasassinaturasds_8_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV78Wppropostasassinaturasds_8_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV79Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wppropostasassinaturasds_9_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV79Wppropostasassinaturasds_9_contratonome1)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Wppropostasassinaturasds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wppropostasassinaturasds_10_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wppropostasassinaturasds_16_propostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV87Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wppropostasassinaturasds_17_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV87Wppropostasassinaturasds_17_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV88Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wppropostasassinaturasds_18_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV88Wppropostasassinaturasds_18_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV89Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wppropostasassinaturasds_19_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV89Wppropostasassinaturasds_19_contratonome2)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Wppropostasassinaturasds_12_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wppropostasassinaturasds_20_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like :lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T6.ClienteDocumento like '%' || :lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wppropostasassinaturasds_26_propostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like '%' || :lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV97Wppropostasassinaturasds_27_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wppropostasassinaturasds_27_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV97Wppropostasassinaturasds_27_propostapacienteclientedocument)");
         }
         else
         {
            GXv_int3[83] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like :lV98Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[84] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wppropostasassinaturasds_28_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T7.ClienteDocumento like '%' || :lV98Wppropostasassinaturasds_28_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[85] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV99Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int3[86] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wppropostasassinaturasds_29_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV99Wppropostasassinaturasds_29_contratonome3)");
         }
         else
         {
            GXv_int3[87] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like :lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[88] = 1;
         }
         if ( AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Wppropostasassinaturasds_22_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wppropostasassinaturasds_30_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T4.ConvenioCategoriaDescricao like '%' || :lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[89] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[91] = 1;
         }
         if ( StringUtil.StrCmp(AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV103Wppropostasassinaturasds_33_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV103Wppropostasassinaturasds_33_tfpropostavalor)");
         }
         else
         {
            GXv_int3[92] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV104Wppropostasassinaturasds_34_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV104Wppropostasassinaturasds_34_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[93] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazao)");
         }
         else
         {
            GXv_int3[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazao))");
         }
         else
         {
            GXv_int3[95] = 1;
         }
         if ( StringUtil.StrCmp(AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocum)");
         }
         else
         {
            GXv_int3[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento = ( :AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocum))");
         }
         else
         {
            GXv_int3[97] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T5.ClienteDocumento))=0))");
         }
         if ( AV109Wppropostasassinaturasds_39_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV109Wppropostasassinaturasds_39_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaValor";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaValor DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.ClienteDocumento";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.ClienteDocumento DESC";
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
                     return conditional_P00B63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (short)dynConstraints[46] , (bool)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] , (int)dynConstraints[50] , (int)dynConstraints[51] );
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
          Object[] prmP00B63;
          prmP00B63 = new Object[] {
          new ParDef("AV72Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV72Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV72Wppropostasassinaturasds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV73Wppropostasassinaturasds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV74Wppropostasassinaturasds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV82Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV82Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV81Wppropostasassinaturasds_11_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV82Wppropostasassinaturasds_12_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV83Wppropostasassinaturasds_13_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV84Wppropostasassinaturasds_14_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV92Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV92Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV91Wppropostasassinaturasds_21_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV92Wppropostasassinaturasds_22_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV93Wppropostasassinaturasds_23_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV94Wppropostasassinaturasds_24_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Wppropostasassinaturasds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV75Wppropostasassinaturasds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV76Wppropostasassinaturasds_6_propostapacienteclienterazaosoci",GXType.VarChar,150,0) ,
          new ParDef("lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV77Wppropostasassinaturasds_7_propostapacienteclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("lV78Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV78Wppropostasassinaturasds_8_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV79Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV79Wppropostasassinaturasds_9_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV80Wppropostasassinaturasds_10_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV85Wppropostasassinaturasds_15_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV86Wppropostasassinaturasds_16_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV87Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV87Wppropostasassinaturasds_17_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV88Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV88Wppropostasassinaturasds_18_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV89Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV89Wppropostasassinaturasds_19_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV90Wppropostasassinaturasds_20_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV95Wppropostasassinaturasds_25_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV96Wppropostasassinaturasds_26_propostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV97Wppropostasassinaturasds_27_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV97Wppropostasassinaturasds_27_propostapacienteclientedocument",GXType.VarChar,20,0) ,
          new ParDef("lV98Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV98Wppropostasassinaturasds_28_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV99Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV99Wppropostasassinaturasds_29_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV100Wppropostasassinaturasds_30_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV101Wppropostasassinaturasds_31_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV102Wppropostasassinaturasds_32_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("AV103Wppropostasassinaturasds_33_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV104Wppropostasassinaturasds_34_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV105Wppropostasassinaturasds_35_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("AV106Wppropostasassinaturasds_36_tfpropostapacienteclienterazao",GXType.VarChar,150,0) ,
          new ParDef("lV107Wppropostasassinaturasds_37_tfpropostapacienteclientedocum",GXType.VarChar,20,0) ,
          new ParDef("AV108Wppropostasassinaturasds_38_tfpropostapacienteclientedocum",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B63,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
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
                ((int[]) buf[30])[0] = rslt.getInt(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
