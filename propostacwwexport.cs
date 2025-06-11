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
   public class propostacwwexport : GXProcedure
   {
      public propostacwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacwwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "PropostaCWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFProcedimentosMedicosNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Procedimento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV75TFProcedimentosMedicosNome_Sel)) ? "(Vazio)" : AV75TFProcedimentosMedicosNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFProcedimentosMedicosNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Procedimento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74TFProcedimentosMedicosNome, out  GXt_char1) ;
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
         if ( ! ( ( AV49TFPropostaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV54i = 1;
            AV80GXV1 = 1;
            while ( AV80GXV1 <= AV49TFPropostaStatus_Sels.Count )
            {
               AV48TFPropostaStatus_Sel = ((string)AV49TFPropostaStatus_Sels.Item(AV80GXV1));
               if ( AV54i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmstatusproposta.getDescription(context,AV48TFPropostaStatus_Sel);
               AV54i = (long)(AV54i+1);
               AV80GXV1 = (int)(AV80GXV1+1);
            }
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
         if ( ! ( (0==AV52TFPropostaQuantidadeAprovadores) && (0==AV53TFPropostaQuantidadeAprovadores_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Aprovações minímas") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV52TFPropostaQuantidadeAprovadores;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV53TFPropostaQuantidadeAprovadores_To;
         }
         if ( ! ( (0==AV68TFPropostaAprovacoes_F) && (0==AV69TFPropostaAprovacoes_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Aprovações") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV68TFPropostaAprovacoes_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV69TFPropostaAprovacoes_F_To;
         }
         if ( ! ( (0==AV70TFPropostaReprovacoes_F) && (0==AV71TFPropostaReprovacoes_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Reprovações") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV70TFPropostaReprovacoes_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV71TFPropostaReprovacoes_F_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFPropostaPacienteClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV79TFPropostaPacienteClienteRazaoSocial_Sel)) ? "(Vazio)" : AV79TFPropostaPacienteClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFPropostaPacienteClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Paciente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78TFPropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Procedimento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descrição";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Contrato";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Aprovações minímas";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Aprovações";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Reprovações";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Paciente";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV82Propostacwwds_1_filterfulltext = AV18FilterFullText;
         AV83Propostacwwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV84Propostacwwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV85Propostacwwds_4_propostatitulo1 = AV21PropostaTitulo1;
         AV86Propostacwwds_5_contratonome1 = AV59ContratoNome1;
         AV87Propostacwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV88Propostacwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV89Propostacwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV90Propostacwwds_9_propostatitulo2 = AV25PropostaTitulo2;
         AV91Propostacwwds_10_contratonome2 = AV60ContratoNome2;
         AV92Propostacwwds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV93Propostacwwds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV94Propostacwwds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV95Propostacwwds_14_propostatitulo3 = AV29PropostaTitulo3;
         AV96Propostacwwds_15_contratonome3 = AV61ContratoNome3;
         AV97Propostacwwds_16_tfprocedimentosmedicosnome = AV74TFProcedimentosMedicosNome;
         AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel = AV75TFProcedimentosMedicosNome_Sel;
         AV99Propostacwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV100Propostacwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV101Propostacwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV102Propostacwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV103Propostacwwds_22_tfpropostastatus_sels = AV49TFPropostaStatus_Sels;
         AV104Propostacwwds_23_tfcontratonome = AV55TFContratoNome;
         AV105Propostacwwds_24_tfcontratonome_sel = AV56TFContratoNome_Sel;
         AV106Propostacwwds_25_tfpropostaquantidadeaprovadores = AV52TFPropostaQuantidadeAprovadores;
         AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to = AV53TFPropostaQuantidadeAprovadores_To;
         AV108Propostacwwds_27_tfpropostaaprovacoes_f = AV68TFPropostaAprovacoes_F;
         AV109Propostacwwds_28_tfpropostaaprovacoes_f_to = AV69TFPropostaAprovacoes_F_To;
         AV110Propostacwwds_29_tfpropostareprovacoes_f = AV70TFPropostaReprovacoes_F;
         AV111Propostacwwds_30_tfpropostareprovacoes_f_to = AV71TFPropostaReprovacoes_F_To;
         AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial = AV78TFPropostaPacienteClienteRazaoSocial;
         AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = AV79TFPropostaPacienteClienteRazaoSocial_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV103Propostacwwds_22_tfpropostastatus_sels ,
                                              AV83Propostacwwds_2_dynamicfiltersselector1 ,
                                              AV84Propostacwwds_3_dynamicfiltersoperator1 ,
                                              AV85Propostacwwds_4_propostatitulo1 ,
                                              AV86Propostacwwds_5_contratonome1 ,
                                              AV87Propostacwwds_6_dynamicfiltersenabled2 ,
                                              AV88Propostacwwds_7_dynamicfiltersselector2 ,
                                              AV89Propostacwwds_8_dynamicfiltersoperator2 ,
                                              AV90Propostacwwds_9_propostatitulo2 ,
                                              AV91Propostacwwds_10_contratonome2 ,
                                              AV92Propostacwwds_11_dynamicfiltersenabled3 ,
                                              AV93Propostacwwds_12_dynamicfiltersselector3 ,
                                              AV94Propostacwwds_13_dynamicfiltersoperator3 ,
                                              AV95Propostacwwds_14_propostatitulo3 ,
                                              AV96Propostacwwds_15_contratonome3 ,
                                              AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV97Propostacwwds_16_tfprocedimentosmedicosnome ,
                                              AV100Propostacwwds_19_tfpropostadescricao_sel ,
                                              AV99Propostacwwds_18_tfpropostadescricao ,
                                              AV101Propostacwwds_20_tfpropostavalor ,
                                              AV102Propostacwwds_21_tfpropostavalor_to ,
                                              AV103Propostacwwds_22_tfpropostastatus_sels.Count ,
                                              AV105Propostacwwds_24_tfcontratonome_sel ,
                                              AV104Propostacwwds_23_tfcontratonome ,
                                              AV106Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                              AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                              AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                              AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A330PropostaQuantidadeAprovadores ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV82Propostacwwds_1_filterfulltext ,
                                              A341PropostaAprovacoes_F ,
                                              A342PropostaReprovacoes_F ,
                                              AV108Propostacwwds_27_tfpropostaaprovacoes_f ,
                                              AV109Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                              AV110Propostacwwds_29_tfpropostareprovacoes_f ,
                                              AV111Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                              A642PropostaClinicaId ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              A133SecUserId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV82Propostacwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Propostacwwds_1_filterfulltext), "%", "");
         lV85Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV85Propostacwwds_4_propostatitulo1), "%", "");
         lV85Propostacwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV85Propostacwwds_4_propostatitulo1), "%", "");
         lV86Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Propostacwwds_5_contratonome1), "%", "");
         lV86Propostacwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV86Propostacwwds_5_contratonome1), "%", "");
         lV90Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacwwds_9_propostatitulo2), "%", "");
         lV90Propostacwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV90Propostacwwds_9_propostatitulo2), "%", "");
         lV91Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacwwds_10_contratonome2), "%", "");
         lV91Propostacwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV91Propostacwwds_10_contratonome2), "%", "");
         lV95Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacwwds_14_propostatitulo3), "%", "");
         lV95Propostacwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV95Propostacwwds_14_propostatitulo3), "%", "");
         lV96Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacwwds_15_contratonome3), "%", "");
         lV96Propostacwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV96Propostacwwds_15_contratonome3), "%", "");
         lV97Propostacwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV97Propostacwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV99Propostacwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV99Propostacwwds_18_tfpropostadescricao), "%", "");
         lV104Propostacwwds_23_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV104Propostacwwds_23_tfcontratonome), "%", "");
         lV112Propostacwwds_31_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P009M4 */
         pr_default.execute(0, new Object[] {AV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, lV82Propostacwwds_1_filterfulltext, AV108Propostacwwds_27_tfpropostaaprovacoes_f, AV108Propostacwwds_27_tfpropostaaprovacoes_f, AV109Propostacwwds_28_tfpropostaaprovacoes_f_to, AV109Propostacwwds_28_tfpropostaaprovacoes_f_to, AV110Propostacwwds_29_tfpropostareprovacoes_f, AV110Propostacwwds_29_tfpropostareprovacoes_f, AV111Propostacwwds_30_tfpropostareprovacoes_f_to, AV111Propostacwwds_30_tfpropostareprovacoes_f_to, A133SecUserId, AV9WWPContext.gxTpr_Secuserclienteid, lV85Propostacwwds_4_propostatitulo1, lV85Propostacwwds_4_propostatitulo1, lV86Propostacwwds_5_contratonome1, lV86Propostacwwds_5_contratonome1, lV90Propostacwwds_9_propostatitulo2, lV90Propostacwwds_9_propostatitulo2, lV91Propostacwwds_10_contratonome2, lV91Propostacwwds_10_contratonome2, lV95Propostacwwds_14_propostatitulo3, lV95Propostacwwds_14_propostatitulo3, lV96Propostacwwds_15_contratonome3, lV96Propostacwwds_15_contratonome3, lV97Propostacwwds_16_tfprocedimentosmedicosnome, AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel, lV99Propostacwwds_18_tfpropostadescricao, AV100Propostacwwds_19_tfpropostadescricao_sel, AV101Propostacwwds_20_tfpropostavalor, AV102Propostacwwds_21_tfpropostavalor_to, lV104Propostacwwds_23_tfcontratonome, AV105Propostacwwds_24_tfcontratonome_sel, AV106Propostacwwds_25_tfpropostaquantidadeaprovadores, AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to, lV112Propostacwwds_31_tfpropostapacienteclienterazaosocial, AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = P009M4_A227ContratoId[0];
            n227ContratoId = P009M4_n227ContratoId[0];
            A376ProcedimentosMedicosId = P009M4_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = P009M4_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = P009M4_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009M4_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = P009M4_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P009M4_n504PropostaPacienteClienteId[0];
            A210SecUserClienteId = P009M4_A210SecUserClienteId[0];
            n210SecUserClienteId = P009M4_n210SecUserClienteId[0];
            A642PropostaClinicaId = P009M4_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P009M4_n642PropostaClinicaId[0];
            A330PropostaQuantidadeAprovadores = P009M4_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = P009M4_n330PropostaQuantidadeAprovadores[0];
            A326PropostaValor = P009M4_A326PropostaValor[0];
            n326PropostaValor = P009M4_n326PropostaValor[0];
            A324PropostaTitulo = P009M4_A324PropostaTitulo[0];
            n324PropostaTitulo = P009M4_n324PropostaTitulo[0];
            A505PropostaPacienteClienteRazaoSocial = P009M4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009M4_n505PropostaPacienteClienteRazaoSocial[0];
            A228ContratoNome = P009M4_A228ContratoNome[0];
            n228ContratoNome = P009M4_n228ContratoNome[0];
            A329PropostaStatus = P009M4_A329PropostaStatus[0];
            n329PropostaStatus = P009M4_n329PropostaStatus[0];
            A325PropostaDescricao = P009M4_A325PropostaDescricao[0];
            n325PropostaDescricao = P009M4_n325PropostaDescricao[0];
            A377ProcedimentosMedicosNome = P009M4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009M4_n377ProcedimentosMedicosNome[0];
            A323PropostaId = P009M4_A323PropostaId[0];
            n323PropostaId = P009M4_n323PropostaId[0];
            A342PropostaReprovacoes_F = P009M4_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009M4_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009M4_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009M4_n341PropostaAprovacoes_F[0];
            A228ContratoNome = P009M4_A228ContratoNome[0];
            n228ContratoNome = P009M4_n228ContratoNome[0];
            A377ProcedimentosMedicosNome = P009M4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = P009M4_n377ProcedimentosMedicosNome[0];
            A210SecUserClienteId = P009M4_A210SecUserClienteId[0];
            n210SecUserClienteId = P009M4_n210SecUserClienteId[0];
            A505PropostaPacienteClienteRazaoSocial = P009M4_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P009M4_n505PropostaPacienteClienteRazaoSocial[0];
            A342PropostaReprovacoes_F = P009M4_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = P009M4_n342PropostaReprovacoes_F[0];
            A341PropostaAprovacoes_F = P009M4_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = P009M4_n341PropostaAprovacoes_F[0];
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
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = gxdomaindmstatusproposta.getDescription(context,A329PropostaStatus);
            if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A228ContratoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A330PropostaQuantidadeAprovadores;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Number = A341PropostaAprovacoes_F;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Number = A342PropostaReprovacoes_F;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A505PropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "PropostaCWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("PropostaCWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaCWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("PropostaCWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV114GXV2 = 1;
         while ( AV114GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV114GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV74TFProcedimentosMedicosNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV75TFProcedimentosMedicosNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV47TFPropostaStatus_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV49TFPropostaStatus_Sels.FromJSonString(AV47TFPropostaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV55TFContratoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV56TFContratoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAQUANTIDADEAPROVADORES") == 0 )
            {
               AV52TFPropostaQuantidadeAprovadores = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV53TFPropostaQuantidadeAprovadores_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAAPROVACOES_F") == 0 )
            {
               AV68TFPropostaAprovacoes_F = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV69TFPropostaAprovacoes_F_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAREPROVACOES_F") == 0 )
            {
               AV70TFPropostaReprovacoes_F = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV71TFPropostaReprovacoes_F_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV78TFPropostaPacienteClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV79TFPropostaPacienteClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV114GXV2 = (int)(AV114GXV2+1);
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
         AV75TFProcedimentosMedicosNome_Sel = "";
         AV74TFProcedimentosMedicosNome = "";
         AV40TFPropostaDescricao_Sel = "";
         AV39TFPropostaDescricao = "";
         AV49TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV48TFPropostaStatus_Sel = "";
         AV56TFContratoNome_Sel = "";
         AV55TFContratoNome = "";
         AV79TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV78TFPropostaPacienteClienteRazaoSocial = "";
         AV82Propostacwwds_1_filterfulltext = "";
         AV83Propostacwwds_2_dynamicfiltersselector1 = "";
         AV85Propostacwwds_4_propostatitulo1 = "";
         AV86Propostacwwds_5_contratonome1 = "";
         AV88Propostacwwds_7_dynamicfiltersselector2 = "";
         AV90Propostacwwds_9_propostatitulo2 = "";
         AV91Propostacwwds_10_contratonome2 = "";
         AV93Propostacwwds_12_dynamicfiltersselector3 = "";
         AV95Propostacwwds_14_propostatitulo3 = "";
         AV96Propostacwwds_15_contratonome3 = "";
         AV97Propostacwwds_16_tfprocedimentosmedicosnome = "";
         AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel = "";
         AV99Propostacwwds_18_tfpropostadescricao = "";
         AV100Propostacwwds_19_tfpropostadescricao_sel = "";
         AV103Propostacwwds_22_tfpropostastatus_sels = new GxSimpleCollection<string>();
         AV104Propostacwwds_23_tfcontratonome = "";
         AV105Propostacwwds_24_tfcontratonome_sel = "";
         AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial = "";
         AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel = "";
         lV82Propostacwwds_1_filterfulltext = "";
         lV85Propostacwwds_4_propostatitulo1 = "";
         lV86Propostacwwds_5_contratonome1 = "";
         lV90Propostacwwds_9_propostatitulo2 = "";
         lV91Propostacwwds_10_contratonome2 = "";
         lV95Propostacwwds_14_propostatitulo3 = "";
         lV96Propostacwwds_15_contratonome3 = "";
         lV97Propostacwwds_16_tfprocedimentosmedicosnome = "";
         lV99Propostacwwds_18_tfpropostadescricao = "";
         lV104Propostacwwds_23_tfcontratonome = "";
         lV112Propostacwwds_31_tfpropostapacienteclienterazaosocial = "";
         A329PropostaStatus = "";
         A324PropostaTitulo = "";
         A228ContratoNome = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         P009M4_A227ContratoId = new int[1] ;
         P009M4_n227ContratoId = new bool[] {false} ;
         P009M4_A376ProcedimentosMedicosId = new int[1] ;
         P009M4_n376ProcedimentosMedicosId = new bool[] {false} ;
         P009M4_A328PropostaCratedBy = new short[1] ;
         P009M4_n328PropostaCratedBy = new bool[] {false} ;
         P009M4_A504PropostaPacienteClienteId = new int[1] ;
         P009M4_n504PropostaPacienteClienteId = new bool[] {false} ;
         P009M4_A210SecUserClienteId = new short[1] ;
         P009M4_n210SecUserClienteId = new bool[] {false} ;
         P009M4_A642PropostaClinicaId = new int[1] ;
         P009M4_n642PropostaClinicaId = new bool[] {false} ;
         P009M4_A330PropostaQuantidadeAprovadores = new short[1] ;
         P009M4_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         P009M4_A326PropostaValor = new decimal[1] ;
         P009M4_n326PropostaValor = new bool[] {false} ;
         P009M4_A324PropostaTitulo = new string[] {""} ;
         P009M4_n324PropostaTitulo = new bool[] {false} ;
         P009M4_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P009M4_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P009M4_A228ContratoNome = new string[] {""} ;
         P009M4_n228ContratoNome = new bool[] {false} ;
         P009M4_A329PropostaStatus = new string[] {""} ;
         P009M4_n329PropostaStatus = new bool[] {false} ;
         P009M4_A325PropostaDescricao = new string[] {""} ;
         P009M4_n325PropostaDescricao = new bool[] {false} ;
         P009M4_A377ProcedimentosMedicosNome = new string[] {""} ;
         P009M4_n377ProcedimentosMedicosNome = new bool[] {false} ;
         P009M4_A323PropostaId = new int[1] ;
         P009M4_n323PropostaId = new bool[] {false} ;
         P009M4_A342PropostaReprovacoes_F = new short[1] ;
         P009M4_n342PropostaReprovacoes_F = new bool[] {false} ;
         P009M4_A341PropostaAprovacoes_F = new short[1] ;
         P009M4_n341PropostaAprovacoes_F = new bool[] {false} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFPropostaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacwwexport__default(),
            new Object[][] {
                new Object[] {
               P009M4_A227ContratoId, P009M4_n227ContratoId, P009M4_A376ProcedimentosMedicosId, P009M4_n376ProcedimentosMedicosId, P009M4_A328PropostaCratedBy, P009M4_n328PropostaCratedBy, P009M4_A504PropostaPacienteClienteId, P009M4_n504PropostaPacienteClienteId, P009M4_A210SecUserClienteId, P009M4_n210SecUserClienteId,
               P009M4_A642PropostaClinicaId, P009M4_n642PropostaClinicaId, P009M4_A330PropostaQuantidadeAprovadores, P009M4_n330PropostaQuantidadeAprovadores, P009M4_A326PropostaValor, P009M4_n326PropostaValor, P009M4_A324PropostaTitulo, P009M4_n324PropostaTitulo, P009M4_A505PropostaPacienteClienteRazaoSocial, P009M4_n505PropostaPacienteClienteRazaoSocial,
               P009M4_A228ContratoNome, P009M4_n228ContratoNome, P009M4_A329PropostaStatus, P009M4_n329PropostaStatus, P009M4_A325PropostaDescricao, P009M4_n325PropostaDescricao, P009M4_A377ProcedimentosMedicosNome, P009M4_n377ProcedimentosMedicosNome, P009M4_A323PropostaId, P009M4_A342PropostaReprovacoes_F,
               P009M4_n342PropostaReprovacoes_F, P009M4_A341PropostaAprovacoes_F, P009M4_n341PropostaAprovacoes_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV52TFPropostaQuantidadeAprovadores ;
      private short AV53TFPropostaQuantidadeAprovadores_To ;
      private short AV68TFPropostaAprovacoes_F ;
      private short AV69TFPropostaAprovacoes_F_To ;
      private short AV70TFPropostaReprovacoes_F ;
      private short AV71TFPropostaReprovacoes_F_To ;
      private short GXt_int2 ;
      private short AV84Propostacwwds_3_dynamicfiltersoperator1 ;
      private short AV89Propostacwwds_8_dynamicfiltersoperator2 ;
      private short AV94Propostacwwds_13_dynamicfiltersoperator3 ;
      private short AV106Propostacwwds_25_tfpropostaquantidadeaprovadores ;
      private short AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to ;
      private short AV108Propostacwwds_27_tfpropostaaprovacoes_f ;
      private short AV109Propostacwwds_28_tfpropostaaprovacoes_f_to ;
      private short AV110Propostacwwds_29_tfpropostareprovacoes_f ;
      private short AV111Propostacwwds_30_tfpropostareprovacoes_f_to ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A330PropostaQuantidadeAprovadores ;
      private short AV16OrderedBy ;
      private short A341PropostaAprovacoes_F ;
      private short A342PropostaReprovacoes_F ;
      private short A133SecUserId ;
      private short A210SecUserClienteId ;
      private short A328PropostaCratedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV80GXV1 ;
      private int AV103Propostacwwds_22_tfpropostastatus_sels_Count ;
      private int A642PropostaClinicaId ;
      private int A227ContratoId ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int AV114GXV2 ;
      private long AV54i ;
      private decimal AV41TFPropostaValor ;
      private decimal AV42TFPropostaValor_To ;
      private decimal AV101Propostacwwds_20_tfpropostavalor ;
      private decimal AV102Propostacwwds_21_tfpropostavalor_to ;
      private decimal A326PropostaValor ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV87Propostacwwds_6_dynamicfiltersenabled2 ;
      private bool AV92Propostacwwds_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n210SecUserClienteId ;
      private bool n642PropostaClinicaId ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n326PropostaValor ;
      private bool n324PropostaTitulo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n228ContratoNome ;
      private bool n329PropostaStatus ;
      private bool n325PropostaDescricao ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n323PropostaId ;
      private bool n342PropostaReprovacoes_F ;
      private bool n341PropostaAprovacoes_F ;
      private string AV47TFPropostaStatus_SelsJson ;
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
      private string AV75TFProcedimentosMedicosNome_Sel ;
      private string AV74TFProcedimentosMedicosNome ;
      private string AV40TFPropostaDescricao_Sel ;
      private string AV39TFPropostaDescricao ;
      private string AV48TFPropostaStatus_Sel ;
      private string AV56TFContratoNome_Sel ;
      private string AV55TFContratoNome ;
      private string AV79TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV78TFPropostaPacienteClienteRazaoSocial ;
      private string AV82Propostacwwds_1_filterfulltext ;
      private string AV83Propostacwwds_2_dynamicfiltersselector1 ;
      private string AV85Propostacwwds_4_propostatitulo1 ;
      private string AV86Propostacwwds_5_contratonome1 ;
      private string AV88Propostacwwds_7_dynamicfiltersselector2 ;
      private string AV90Propostacwwds_9_propostatitulo2 ;
      private string AV91Propostacwwds_10_contratonome2 ;
      private string AV93Propostacwwds_12_dynamicfiltersselector3 ;
      private string AV95Propostacwwds_14_propostatitulo3 ;
      private string AV96Propostacwwds_15_contratonome3 ;
      private string AV97Propostacwwds_16_tfprocedimentosmedicosnome ;
      private string AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel ;
      private string AV99Propostacwwds_18_tfpropostadescricao ;
      private string AV100Propostacwwds_19_tfpropostadescricao_sel ;
      private string AV104Propostacwwds_23_tfcontratonome ;
      private string AV105Propostacwwds_24_tfcontratonome_sel ;
      private string AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial ;
      private string AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ;
      private string lV82Propostacwwds_1_filterfulltext ;
      private string lV85Propostacwwds_4_propostatitulo1 ;
      private string lV86Propostacwwds_5_contratonome1 ;
      private string lV90Propostacwwds_9_propostatitulo2 ;
      private string lV91Propostacwwds_10_contratonome2 ;
      private string lV95Propostacwwds_14_propostatitulo3 ;
      private string lV96Propostacwwds_15_contratonome3 ;
      private string lV97Propostacwwds_16_tfprocedimentosmedicosnome ;
      private string lV99Propostacwwds_18_tfpropostadescricao ;
      private string lV104Propostacwwds_23_tfcontratonome ;
      private string lV112Propostacwwds_31_tfpropostapacienteclienterazaosocial ;
      private string A329PropostaStatus ;
      private string A324PropostaTitulo ;
      private string A228ContratoNome ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV49TFPropostaStatus_Sels ;
      private GxSimpleCollection<string> AV103Propostacwwds_22_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P009M4_A227ContratoId ;
      private bool[] P009M4_n227ContratoId ;
      private int[] P009M4_A376ProcedimentosMedicosId ;
      private bool[] P009M4_n376ProcedimentosMedicosId ;
      private short[] P009M4_A328PropostaCratedBy ;
      private bool[] P009M4_n328PropostaCratedBy ;
      private int[] P009M4_A504PropostaPacienteClienteId ;
      private bool[] P009M4_n504PropostaPacienteClienteId ;
      private short[] P009M4_A210SecUserClienteId ;
      private bool[] P009M4_n210SecUserClienteId ;
      private int[] P009M4_A642PropostaClinicaId ;
      private bool[] P009M4_n642PropostaClinicaId ;
      private short[] P009M4_A330PropostaQuantidadeAprovadores ;
      private bool[] P009M4_n330PropostaQuantidadeAprovadores ;
      private decimal[] P009M4_A326PropostaValor ;
      private bool[] P009M4_n326PropostaValor ;
      private string[] P009M4_A324PropostaTitulo ;
      private bool[] P009M4_n324PropostaTitulo ;
      private string[] P009M4_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P009M4_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P009M4_A228ContratoNome ;
      private bool[] P009M4_n228ContratoNome ;
      private string[] P009M4_A329PropostaStatus ;
      private bool[] P009M4_n329PropostaStatus ;
      private string[] P009M4_A325PropostaDescricao ;
      private bool[] P009M4_n325PropostaDescricao ;
      private string[] P009M4_A377ProcedimentosMedicosNome ;
      private bool[] P009M4_n377ProcedimentosMedicosNome ;
      private int[] P009M4_A323PropostaId ;
      private bool[] P009M4_n323PropostaId ;
      private short[] P009M4_A342PropostaReprovacoes_F ;
      private bool[] P009M4_n342PropostaReprovacoes_F ;
      private short[] P009M4_A341PropostaAprovacoes_F ;
      private bool[] P009M4_n341PropostaAprovacoes_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class propostacwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009M4( IGxContext context ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV103Propostacwwds_22_tfpropostastatus_sels ,
                                             string AV83Propostacwwds_2_dynamicfiltersselector1 ,
                                             short AV84Propostacwwds_3_dynamicfiltersoperator1 ,
                                             string AV85Propostacwwds_4_propostatitulo1 ,
                                             string AV86Propostacwwds_5_contratonome1 ,
                                             bool AV87Propostacwwds_6_dynamicfiltersenabled2 ,
                                             string AV88Propostacwwds_7_dynamicfiltersselector2 ,
                                             short AV89Propostacwwds_8_dynamicfiltersoperator2 ,
                                             string AV90Propostacwwds_9_propostatitulo2 ,
                                             string AV91Propostacwwds_10_contratonome2 ,
                                             bool AV92Propostacwwds_11_dynamicfiltersenabled3 ,
                                             string AV93Propostacwwds_12_dynamicfiltersselector3 ,
                                             short AV94Propostacwwds_13_dynamicfiltersoperator3 ,
                                             string AV95Propostacwwds_14_propostatitulo3 ,
                                             string AV96Propostacwwds_15_contratonome3 ,
                                             string AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV97Propostacwwds_16_tfprocedimentosmedicosnome ,
                                             string AV100Propostacwwds_19_tfpropostadescricao_sel ,
                                             string AV99Propostacwwds_18_tfpropostadescricao ,
                                             decimal AV101Propostacwwds_20_tfpropostavalor ,
                                             decimal AV102Propostacwwds_21_tfpropostavalor_to ,
                                             int AV103Propostacwwds_22_tfpropostastatus_sels_Count ,
                                             string AV105Propostacwwds_24_tfcontratonome_sel ,
                                             string AV104Propostacwwds_23_tfcontratonome ,
                                             short AV106Propostacwwds_25_tfpropostaquantidadeaprovadores ,
                                             short AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to ,
                                             string AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             short A330PropostaQuantidadeAprovadores ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV82Propostacwwds_1_filterfulltext ,
                                             short A341PropostaAprovacoes_F ,
                                             short A342PropostaReprovacoes_F ,
                                             short AV108Propostacwwds_27_tfpropostaaprovacoes_f ,
                                             short AV109Propostacwwds_28_tfpropostaaprovacoes_f_to ,
                                             short AV110Propostacwwds_29_tfpropostareprovacoes_f ,
                                             short AV111Propostacwwds_30_tfpropostareprovacoes_f_to ,
                                             int A642PropostaClinicaId ,
                                             short AV9WWPContext_gxTpr_Secuserclienteid ,
                                             short A133SecUserId ,
                                             short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[51];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T4.SecUserClienteId, T1.PropostaClinicaId, T1.PropostaQuantidadeAprovadores, T1.PropostaValor, T1.PropostaTitulo, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T2.ContratoNome, T1.PropostaStatus, T1.PropostaDescricao, T3.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T6.PropostaReprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T7.PropostaReprovacoes_F, 0) AS PropostaAprovacoes_F FROM ((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T4 ON T4.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaReprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T7 ON T7.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV82Propostacwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV82Propostacwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV82Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV82Propostacwwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV82Propostacwwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T2.ContratoNome like '%' || :lV82Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaQuantidadeAprovadores,'9999'), 2) like '%' || :lV82Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T7.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV82Propostacwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaReprovacoes_F, 0),'9999'), 2) like '%' || :lV82Propostacwwds_1_filterfulltext) or ( T5.ClienteRazaoSocial like '%' || :lV82Propostacwwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV108Propostacwwds_27_tfpropostaaprovacoes_f = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) >= :AV108Propostacwwds_27_tfpropostaaprovacoes_f))");
         AddWhere(sWhereString, "((:AV109Propostacwwds_28_tfpropostaaprovacoes_f_to = 0) or ( COALESCE( T7.PropostaReprovacoes_F, 0) <= :AV109Propostacwwds_28_tfpropostaaprovacoes_f_to))");
         AddWhere(sWhereString, "((:AV110Propostacwwds_29_tfpropostareprovacoes_f = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) >= :AV110Propostacwwds_29_tfpropostareprovacoes_f))");
         AddWhere(sWhereString, "((:AV111Propostacwwds_30_tfpropostareprovacoes_f_to = 0) or ( COALESCE( T6.PropostaReprovacoes_F, 0) <= :AV111Propostacwwds_30_tfpropostareprovacoes_f_to))");
         AddWhere(sWhereString, "(T1.PropostaClinicaId = CASE  WHEN (:AV9WWPCo_1Secuserclienteid = 0) THEN :SecUserId ELSE T4.SecUserClienteId END)");
         if ( ( StringUtil.StrCmp(AV83Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV84Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV85Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Propostacwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV84Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Propostacwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV85Propostacwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV84Propostacwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV86Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Propostacwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV84Propostacwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Propostacwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV86Propostacwwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV87Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV89Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV90Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV87Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Propostacwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV89Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Propostacwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV90Propostacwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV87Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV89Propostacwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV91Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV87Propostacwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Propostacwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV89Propostacwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Propostacwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV91Propostacwwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV92Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV94Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV95Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV92Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Propostacwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV94Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Propostacwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV95Propostacwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV92Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV94Propostacwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV96Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV92Propostacwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Propostacwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV94Propostacwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Propostacwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV96Propostacwwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Propostacwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV97Propostacwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Propostacwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV99Propostacwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV100Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV100Propostacwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV100Propostacwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV101Propostacwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV101Propostacwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV102Propostacwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV102Propostacwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV103Propostacwwds_22_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV103Propostacwwds_22_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_24_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Propostacwwds_23_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV104Propostacwwds_23_tfcontratonome)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacwwds_24_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV105Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV105Propostacwwds_24_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( StringUtil.StrCmp(AV105Propostacwwds_24_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (0==AV106Propostacwwds_25_tfpropostaquantidadeaprovadores) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores >= :AV106Propostacwwds_25_tfpropostaquantidadeaprovadores)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (0==AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaQuantidadeAprovadores <= :AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacwwds_31_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV112Propostacwwds_31_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
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
            scmdbuf += " ORDER BY T1.PropostaStatus";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ContratoNome";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ContratoNome DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PropostaQuantidadeAprovadores";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaQuantidadeAprovadores DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.ClienteRazaoSocial DESC";
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
                     return conditional_P009M4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (short)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (short)dynConstraints[44] , (int)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (short)dynConstraints[48] );
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
          Object[] prmP009M4;
          prmP009M4 = new Object[] {
          new ParDef("AV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV82Propostacwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV108Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV108Propostacwwds_27_tfpropostaaprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV109Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV109Propostacwwds_28_tfpropostaaprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV110Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV110Propostacwwds_29_tfpropostareprovacoes_f",GXType.Int16,4,0) ,
          new ParDef("AV111Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV111Propostacwwds_30_tfpropostareprovacoes_f_to",GXType.Int16,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV85Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV85Propostacwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV86Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV86Propostacwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV90Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV90Propostacwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV91Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV91Propostacwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV95Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV95Propostacwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV96Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV96Propostacwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV97Propostacwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV98Propostacwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV99Propostacwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV100Propostacwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV101Propostacwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV102Propostacwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV104Propostacwwds_23_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV105Propostacwwds_24_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV106Propostacwwds_25_tfpropostaquantidadeaprovadores",GXType.Int16,4,0) ,
          new ParDef("AV107Propostacwwds_26_tfpropostaquantidadeaprovadores_to",GXType.Int16,4,0) ,
          new ParDef("lV112Propostacwwds_31_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV113Propostacwwds_32_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
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
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
