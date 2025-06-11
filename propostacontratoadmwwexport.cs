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
   public class propostacontratoadmwwexport : GXProcedure
   {
      public propostacontratoadmwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratoadmwwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "PropostaContratoAdmWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTATITULO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21PropostaTitulo1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21PropostaTitulo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21PropostaTitulo1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV59ContratoNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59ContratoNome1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59ContratoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTATITULO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25PropostaTitulo2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25PropostaTitulo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25PropostaTitulo2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV60ContratoNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60ContratoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60ContratoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROPOSTATITULO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29PropostaTitulo3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29PropostaTitulo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29PropostaTitulo3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV61ContratoNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ContratoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61ContratoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFProcedimentosMedicosNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Procedimento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV73TFProcedimentosMedicosNome_Sel)) ? "(Vazio)" : AV73TFProcedimentosMedicosNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFProcedimentosMedicosNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Procedimento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV72TFProcedimentosMedicosNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPropostaDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPropostaDescricao_Sel)) ? "(Vazio)" : AV40TFPropostaDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPropostaDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFPropostaDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFPropostaValor) && (Convert.ToDecimal(0)==AV42TFPropostaValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV41TFPropostaValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV42TFPropostaValor_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFContratoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFContratoNome_Sel)) ? "(Vazio)" : AV56TFContratoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFContratoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFContratoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPropostaPacienteClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPropostaPacienteClienteRazaoSocial_Sel)) ? "(Vazio)" : AV75TFPropostaPacienteClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPropostaPacienteClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74TFPropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV78TFReembolsoStatusAtual_F_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação reembolso") ;
            AV13CellRow = GXt_int2;
            AV54i = 1;
            AV79GXV1 = 1;
            while ( AV79GXV1 <= AV78TFReembolsoStatusAtual_F_Sels.Count )
            {
               AV77TFReembolsoStatusAtual_F_Sel = ((string)AV78TFReembolsoStatusAtual_F_Sels.Item(AV79GXV1));
               if ( AV54i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmreembolsostatus.getDescription(context,AV77TFReembolsoStatusAtual_F_Sel);
               AV54i = (long)(AV54i+1);
               AV79GXV1 = (int)(AV79GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descrição";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Contrato";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Paciente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Situação reembolso";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV81Propostacontratoadmwwds_1_filterfulltext = AV18FilterFullText;
         AV82Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV84Propostacontratoadmwwds_4_propostatitulo1 = AV21PropostaTitulo1;
         AV85Propostacontratoadmwwds_5_contratonome1 = AV59ContratoNome1;
         AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Propostacontratoadmwwds_9_propostatitulo2 = AV25PropostaTitulo2;
         AV90Propostacontratoadmwwds_10_contratonome2 = AV60ContratoNome2;
         AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV92Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV94Propostacontratoadmwwds_14_propostatitulo3 = AV29PropostaTitulo3;
         AV95Propostacontratoadmwwds_15_contratonome3 = AV61ContratoNome3;
         AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV72TFProcedimentosMedicosNome;
         AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV73TFProcedimentosMedicosNome_Sel;
         AV98Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV100Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV101Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV102Propostacontratoadmwwds_22_tfcontratonome = AV55TFContratoNome;
         AV103Propostacontratoadmwwds_23_tfcontratonome_sel = AV56TFContratoNome_Sel;
         AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV74TFPropostaPacienteClienteRazaoSocial;
         AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV75TFPropostaPacienteClienteRazaoSocial_Sel;
         AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV78TFReembolsoStatusAtual_F_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              AV82Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              AV84Propostacontratoadmwwds_4_propostatitulo1 ,
                                              AV85Propostacontratoadmwwds_5_contratonome1 ,
                                              AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              AV87Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              AV89Propostacontratoadmwwds_9_propostatitulo2 ,
                                              AV90Propostacontratoadmwwds_10_contratonome2 ,
                                              AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              AV92Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              AV94Propostacontratoadmwwds_14_propostatitulo3 ,
                                              AV95Propostacontratoadmwwds_15_contratonome3 ,
                                              AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              AV98Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              AV100Propostacontratoadmwwds_20_tfpropostavalor ,
                                              AV101Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              AV103Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              AV102Propostacontratoadmwwds_22_tfcontratonome ,
                                              AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV81Propostacontratoadmwwds_1_filterfulltext ,
                                              AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              A329PropostaStatus ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A328PropostaCratedBy } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV81Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV84Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV84Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV84Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV84Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV85Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV85Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV85Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV85Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV89Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV89Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV89Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV89Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV90Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV90Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV94Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV94Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV94Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV95Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV95Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV98Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV98Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
         lV102Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV102Propostacontratoadmwwds_22_tfcontratonome), "%", "");
         lV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P00BZ4 */
         pr_default.execute(0, new Object[] {AV9WWPContext.gxTpr_Secuserclienteid, AV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, lV81Propostacontratoadmwwds_1_filterfulltext, AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, lV84Propostacontratoadmwwds_4_propostatitulo1, lV84Propostacontratoadmwwds_4_propostatitulo1, lV85Propostacontratoadmwwds_5_contratonome1, lV85Propostacontratoadmwwds_5_contratonome1, lV89Propostacontratoadmwwds_9_propostatitulo2, lV89Propostacontratoadmwwds_9_propostatitulo2, lV90Propostacontratoadmwwds_10_contratonome2, lV90Propostacontratoadmwwds_10_contratonome2, lV94Propostacontratoadmwwds_14_propostatitulo3, lV94Propostacontratoadmwwds_14_propostatitulo3, lV95Propostacontratoadmwwds_15_contratonome3, lV95Propostacontratoadmwwds_15_contratonome3, lV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV98Propostacontratoadmwwds_18_tfpropostadescricao, AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV100Propostacontratoadmwwds_20_tfpropostavalor, AV101Propostacontratoadmwwds_21_tfpropostavalor_to, lV102Propostacontratoadmwwds_22_tfcontratonome, AV103Propostacontratoadmwwds_23_tfcontratonome_sel, lV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P00BZ4_A227ContratoId[0];
            n227ContratoId = P00BZ4_n227ContratoId[0];
            A376ProcedimentosMedicosId = P00BZ4_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P00BZ4_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = P00BZ4_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00BZ4_n504PropostaPacienteClienteId[0];
            A329PropostaStatus = P00BZ4_A329PropostaStatus[0];
            n329PropostaStatus = P00BZ4_n329PropostaStatus[0];
            A328PropostaCratedBy = P00BZ4_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00BZ4_n328PropostaCratedBy[0];
            A326PropostaValor = P00BZ4_A326PropostaValor[0];
            n326PropostaValor = P00BZ4_n326PropostaValor[0];
            A324PropostaTitulo = P00BZ4_A324PropostaTitulo[0];
            n324PropostaTitulo = P00BZ4_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P00BZ4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BZ4_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P00BZ4_A228ContratoNome[0];
            n228ContratoNome = P00BZ4_n228ContratoNome[0];
            A325PropostaDescricao = P00BZ4_A325PropostaDescricao[0];
            n325PropostaDescricao = P00BZ4_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P00BZ4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BZ4_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P00BZ4_A323PropostaId[0];
            A548ReembolsoStatusAtual_F = P00BZ4_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BZ4_n548ReembolsoStatusAtual_F[0];
            A228ContratoNome = P00BZ4_A228ContratoNome[0];
            n228ContratoNome = P00BZ4_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P00BZ4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P00BZ4_n377ProcedimentosMedicosNome[0];
            A505PropostaPacienteClienteRazaoSocial = P00BZ4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P00BZ4_n505PropostaPacienteClienteRazaoSocial[0];
            A548ReembolsoStatusAtual_F = P00BZ4_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = P00BZ4_n548ReembolsoStatusAtual_F[0];
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
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A325PropostaDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A326PropostaValor);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A228ContratoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A505PropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "PropostaContratoAdmWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("PropostaContratoAdmWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaContratoAdmWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("PropostaContratoAdmWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV107GXV2 = 1;
         while ( AV107GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV107GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV72TFProcedimentosMedicosNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV73TFProcedimentosMedicosNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV39TFPropostaDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV40TFPropostaDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV41TFPropostaValor = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV42TFPropostaValor_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV55TFContratoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV56TFContratoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV74TFPropostaPacienteClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV75TFPropostaPacienteClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV76TFReembolsoStatusAtual_F_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV78TFReembolsoStatusAtual_F_Sels.FromJSonString(AV76TFReembolsoStatusAtual_F_SelsJson, null);
            }
            AV107GXV2 = (int)(AV107GXV2+1);
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
         AV21PropostaTitulo1 = "";
         AV59ContratoNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25PropostaTitulo2 = "";
         AV60ContratoNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29PropostaTitulo3 = "";
         AV61ContratoNome3 = "";
         AV73TFProcedimentosMedicosNome_Sel = "";
         AV72TFProcedimentosMedicosNome = "";
         AV40TFPropostaDescricao_Sel = "";
         AV39TFPropostaDescricao = "";
         AV56TFContratoNome_Sel = "";
         AV55TFContratoNome = "";
         AV75TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV74TFPropostaPacienteClienteRazaoSocial = "";
         AV78TFReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV77TFReembolsoStatusAtual_F_Sel = "";
         AV81Propostacontratoadmwwds_1_filterfulltext = "";
         AV82Propostacontratoadmwwds_2_dynamicfiltersselector1 = "";
         AV84Propostacontratoadmwwds_4_propostatitulo1 = "";
         AV85Propostacontratoadmwwds_5_contratonome1 = "";
         AV87Propostacontratoadmwwds_7_dynamicfiltersselector2 = "";
         AV89Propostacontratoadmwwds_9_propostatitulo2 = "";
         AV90Propostacontratoadmwwds_10_contratonome2 = "";
         AV92Propostacontratoadmwwds_12_dynamicfiltersselector3 = "";
         AV94Propostacontratoadmwwds_14_propostatitulo3 = "";
         AV95Propostacontratoadmwwds_15_contratonome3 = "";
         AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = "";
         AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = "";
         AV98Propostacontratoadmwwds_18_tfpropostadescricao = "";
         AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel = "";
         AV102Propostacontratoadmwwds_22_tfcontratonome = "";
         AV103Propostacontratoadmwwds_23_tfcontratonome_sel = "";
         AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = "";
         AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = "";
         AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         lV81Propostacontratoadmwwds_1_filterfulltext = "";
         lV84Propostacontratoadmwwds_4_propostatitulo1 = "";
         lV85Propostacontratoadmwwds_5_contratonome1 = "";
         lV89Propostacontratoadmwwds_9_propostatitulo2 = "";
         lV90Propostacontratoadmwwds_10_contratonome2 = "";
         lV94Propostacontratoadmwwds_14_propostatitulo3 = "";
         lV95Propostacontratoadmwwds_15_contratonome3 = "";
         lV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = "";
         lV98Propostacontratoadmwwds_18_tfpropostadescricao = "";
         lV102Propostacontratoadmwwds_22_tfcontratonome = "";
         lV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = "";
         A548ReembolsoStatusAtual_F = "";
         A324PropostaTitulo = "";
         A228ContratoNome = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A329PropostaStatus = "";
         P00BZ4_A227ContratoId = new int[1] ;
         P00BZ4_n227ContratoId = new bool[] {false} ;
         P00BZ4_A376ProcedimentosMedicosId = new int[1] ;
         P00BZ4_n376ProcedimentosMedicosId = new bool[] {false} ;
         P00BZ4_A504PropostaPacienteClienteId = new int[1] ;
         P00BZ4_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00BZ4_A329PropostaStatus = new string[] {""} ;
         P00BZ4_n329PropostaStatus = new bool[] {false} ;
         P00BZ4_A328PropostaCratedBy = new short[1] ;
         P00BZ4_n328PropostaCratedBy = new bool[] {false} ;
         P00BZ4_A326PropostaValor = new decimal[1] ;
         P00BZ4_n326PropostaValor = new bool[] {false} ;
         P00BZ4_A324PropostaTitulo = new string[] {""} ;
         P00BZ4_n324PropostaTitulo = new bool[] {false} ;
         P00BZ4_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00BZ4_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00BZ4_A228ContratoNome = new string[] {""} ;
         P00BZ4_n228ContratoNome = new bool[] {false} ;
         P00BZ4_A325PropostaDescricao = new string[] {""} ;
         P00BZ4_n325PropostaDescricao = new bool[] {false} ;
         P00BZ4_A377ProcedimentosMedicosNome = new string[] {""} ;
         P00BZ4_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P00BZ4_A323PropostaId = new int[1] ;
         P00BZ4_A548ReembolsoStatusAtual_F = new string[] {""} ;
         P00BZ4_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV76TFReembolsoStatusAtual_F_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratoadmwwexport__default(),
            new Object[][] {
                new Object[] {
               P00BZ4_A227ContratoId, P00BZ4_n227ContratoId, P00BZ4_A376ProcedimentosMedicosId, P00BZ4_n376ProcedimentosMedicosId, P00BZ4_A504PropostaPacienteClienteId, P00BZ4_n504PropostaPacienteClienteId, P00BZ4_A329PropostaStatus, P00BZ4_n329PropostaStatus, P00BZ4_A328PropostaCratedBy, P00BZ4_n328PropostaCratedBy,
               P00BZ4_A326PropostaValor, P00BZ4_n326PropostaValor, P00BZ4_A324PropostaTitulo, P00BZ4_n324PropostaTitulo, P00BZ4_A505PropostaPacienteClienteRazaoSocial, P00BZ4_n505PropostaPacienteClienteRazaoSocial, P00BZ4_A228ContratoNome, P00BZ4_n228ContratoNome, P00BZ4_A325PropostaDescricao, P00BZ4_n325PropostaDescricao,
               P00BZ4_A377ProcedimentosMedicosNome, P00BZ4_n377ProcedimentosMedicosNome, P00BZ4_A323PropostaId, P00BZ4_A548ReembolsoStatusAtual_F, P00BZ4_n548ReembolsoStatusAtual_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 ;
      private short AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 ;
      private short AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short AV16OrderedBy ;
      private short A328PropostaCratedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV79GXV1 ;
      private int AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int AV107GXV2 ;
      private long AV54i ;
      private decimal AV41TFPropostaValor ;
      private decimal AV42TFPropostaValor_To ;
      private decimal AV100Propostacontratoadmwwds_20_tfpropostavalor ;
      private decimal AV101Propostacontratoadmwwds_21_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 ;
      private bool AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n329PropostaStatus ;
      private bool n328PropostaCratedBy ;
      private bool n326PropostaValor ;
      private bool n324PropostaTitulo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n228ContratoNome ;
      private bool n325PropostaDescricao ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n548ReembolsoStatusAtual_F ;
      private string AV76TFReembolsoStatusAtual_F_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21PropostaTitulo1 ;
      private string AV59ContratoNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25PropostaTitulo2 ;
      private string AV60ContratoNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29PropostaTitulo3 ;
      private string AV61ContratoNome3 ;
      private string AV73TFProcedimentosMedicosNome_Sel ;
      private string AV72TFProcedimentosMedicosNome ;
      private string AV40TFPropostaDescricao_Sel ;
      private string AV39TFPropostaDescricao ;
      private string AV56TFContratoNome_Sel ;
      private string AV55TFContratoNome ;
      private string AV75TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV74TFPropostaPacienteClienteRazaoSocial ;
      private string AV77TFReembolsoStatusAtual_F_Sel ;
      private string AV81Propostacontratoadmwwds_1_filterfulltext ;
      private string AV82Propostacontratoadmwwds_2_dynamicfiltersselector1 ;
      private string AV84Propostacontratoadmwwds_4_propostatitulo1 ;
      private string AV85Propostacontratoadmwwds_5_contratonome1 ;
      private string AV87Propostacontratoadmwwds_7_dynamicfiltersselector2 ;
      private string AV89Propostacontratoadmwwds_9_propostatitulo2 ;
      private string AV90Propostacontratoadmwwds_10_contratonome2 ;
      private string AV92Propostacontratoadmwwds_12_dynamicfiltersselector3 ;
      private string AV94Propostacontratoadmwwds_14_propostatitulo3 ;
      private string AV95Propostacontratoadmwwds_15_contratonome3 ;
      private string AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ;
      private string AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ;
      private string AV98Propostacontratoadmwwds_18_tfpropostadescricao ;
      private string AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel ;
      private string AV102Propostacontratoadmwwds_22_tfcontratonome ;
      private string AV103Propostacontratoadmwwds_23_tfcontratonome_sel ;
      private string AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ;
      private string AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ;
      private string lV81Propostacontratoadmwwds_1_filterfulltext ;
      private string lV84Propostacontratoadmwwds_4_propostatitulo1 ;
      private string lV85Propostacontratoadmwwds_5_contratonome1 ;
      private string lV89Propostacontratoadmwwds_9_propostatitulo2 ;
      private string lV90Propostacontratoadmwwds_10_contratonome2 ;
      private string lV94Propostacontratoadmwwds_14_propostatitulo3 ;
      private string lV95Propostacontratoadmwwds_15_contratonome3 ;
      private string lV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ;
      private string lV98Propostacontratoadmwwds_18_tfpropostadescricao ;
      private string lV102Propostacontratoadmwwds_22_tfcontratonome ;
      private string lV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ;
      private string A548ReembolsoStatusAtual_F ;
      private string A324PropostaTitulo ;
      private string A228ContratoNome ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A329PropostaStatus ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV78TFReembolsoStatusAtual_F_Sels ;
      private GxSimpleCollection<string> AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00BZ4_A227ContratoId ;
      private bool[] P00BZ4_n227ContratoId ;
      private int[] P00BZ4_A376ProcedimentosMedicosId ;
      private bool[] P00BZ4_n376ProcedimentosMedicosId ;
      private int[] P00BZ4_A504PropostaPacienteClienteId ;
      private bool[] P00BZ4_n504PropostaPacienteClienteId ;
      private string[] P00BZ4_A329PropostaStatus ;
      private bool[] P00BZ4_n329PropostaStatus ;
      private short[] P00BZ4_A328PropostaCratedBy ;
      private bool[] P00BZ4_n328PropostaCratedBy ;
      private decimal[] P00BZ4_A326PropostaValor ;
      private bool[] P00BZ4_n326PropostaValor ;
      private string[] P00BZ4_A324PropostaTitulo ;
      private bool[] P00BZ4_n324PropostaTitulo ;
      private string[] P00BZ4_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P00BZ4_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P00BZ4_A228ContratoNome ;
      private bool[] P00BZ4_n228ContratoNome ;
      private string[] P00BZ4_A325PropostaDescricao ;
      private bool[] P00BZ4_n325PropostaDescricao ;
      private string[] P00BZ4_A377ProcedimentosMedicosNome ;
      private bool[] P00BZ4_n377ProcedimentosMedicosNome ;
      private int[] P00BZ4_A323PropostaId ;
      private string[] P00BZ4_A548ReembolsoStatusAtual_F ;
      private bool[] P00BZ4_n548ReembolsoStatusAtual_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class propostacontratoadmwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BZ4( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV82Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                             short AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                             string AV84Propostacontratoadmwwds_4_propostatitulo1 ,
                                             string AV85Propostacontratoadmwwds_5_contratonome1 ,
                                             bool AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                             string AV87Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                             short AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                             string AV89Propostacontratoadmwwds_9_propostatitulo2 ,
                                             string AV90Propostacontratoadmwwds_10_contratonome2 ,
                                             bool AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                             string AV92Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                             short AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                             string AV94Propostacontratoadmwwds_14_propostatitulo3 ,
                                             string AV95Propostacontratoadmwwds_15_contratonome3 ,
                                             string AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                             string AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                             string AV98Propostacontratoadmwwds_18_tfpropostadescricao ,
                                             decimal AV100Propostacontratoadmwwds_20_tfpropostavalor ,
                                             decimal AV101Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                             string AV103Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                             string AV102Propostacontratoadmwwds_22_tfcontratonome ,
                                             string AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV81Propostacontratoadmwwds_1_filterfulltext ,
                                             int AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                             string A329PropostaStatus ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             short A328PropostaCratedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[34];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaStatus, T1.PropostaCratedBy, T1.PropostaValor, T1.PropostaTitulo, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaDescricao, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T5.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM ((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MIN(T6.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId FROM ((ReembolsoEtapa T6 LEFT JOIN Reembolso T7 ON T7.ReembolsoId = T6.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T6.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T6.ReembolsoId) WHERE (T1.PropostaId = T7.ReembolsoPropostaId) AND (T6.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_1Secuserclienteid)");
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV81Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV81Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV81Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV81Propostacontratoadmwwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV81Propostacontratoadmwwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV81Propostacontratoadmwwds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV81Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV81Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV81Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV81Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV106ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV106Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV82Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV84Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV84Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV85Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV83Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV85Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV89Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV89Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV90Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV86Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV88Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV90Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV94Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV94Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV95Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV91Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV93Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV95Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( StringUtil.StrCmp(AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV98Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV100Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV100Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV101Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV101Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV102Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV103Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.PropostaId DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ProcedimentosMedicosNome DESC";
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
            scmdbuf += " ORDER BY T2.ContratoNome";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ContratoNome DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial DESC";
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
                     return conditional_P00BZ4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] );
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
          Object[] prmP00BZ4;
          prmP00BZ4 = new Object[] {
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("AV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV106ProCount",GXType.Int32,9,0) ,
          new ParDef("lV84Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV84Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV85Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV85Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV89Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV89Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV90Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV90Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV94Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV94Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV96Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV97Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV98Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV99Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV100Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV101Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV102Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV103Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV104Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV105Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BZ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BZ4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
