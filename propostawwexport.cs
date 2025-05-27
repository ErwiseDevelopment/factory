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
   public class propostawwexport : GXProcedure
   {
      public propostawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "PropostaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV84PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV84PropostaMaxReembolsoId_F1) )
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
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV84PropostaMaxReembolsoId_F1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV85PropostaResponsavelDocumento1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85PropostaResponsavelDocumento1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV85PropostaResponsavelDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV86PropostaPacienteClienteDocumento1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86PropostaPacienteClienteDocumento1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV86PropostaPacienteClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV87PropostaClinicaDocumento1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87PropostaClinicaDocumento1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV87PropostaClinicaDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV88ConvenioCategoriaDescricao1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ConvenioCategoriaDescricao1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV88ConvenioCategoriaDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV89PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV89PropostaMaxReembolsoId_F2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV89PropostaMaxReembolsoId_F2;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV90PropostaResponsavelDocumento2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90PropostaResponsavelDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV90PropostaResponsavelDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV91PropostaPacienteClienteDocumento2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91PropostaPacienteClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV91PropostaPacienteClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV92PropostaClinicaDocumento2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92PropostaClinicaDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV92PropostaClinicaDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV93ConvenioCategoriaDescricao2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93ConvenioCategoriaDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV93ConvenioCategoriaDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV94PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV94PropostaMaxReembolsoId_F3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reembolso Id_F", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV94PropostaMaxReembolsoId_F3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV95PropostaResponsavelDocumento3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95PropostaResponsavelDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Responsavel Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV95PropostaResponsavelDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV96PropostaPacienteClienteDocumento3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96PropostaPacienteClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV96PropostaPacienteClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV97PropostaClinicaDocumento3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97PropostaClinicaDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Clinica Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV97PropostaClinicaDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV98ConvenioCategoriaDescricao3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98ConvenioCategoriaDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV98ConvenioCategoriaDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFPropostaClinicaNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Clinica Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV77TFPropostaClinicaNome_Sel)) ? "(Vazio)" : AV77TFPropostaClinicaNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFPropostaClinicaNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Clinica Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76TFPropostaClinicaNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV49TFPropostaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV54i = 1;
            AV99GXV1 = 1;
            while ( AV99GXV1 <= AV49TFPropostaStatus_Sels.Count )
            {
               AV48TFPropostaStatus_Sel = ((string)AV49TFPropostaStatus_Sels.Item(AV99GXV1));
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
               AV99GXV1 = (int)(AV99GXV1+1);
            }
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
         if ( ! ( (0==AV80TFPropostaMaiorScore_F) && (0==AV81TFPropostaMaiorScore_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Maior score") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV80TFPropostaMaiorScore_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV81TFPropostaMaiorScore_F_To;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV82TFPropostaMaiorValorRecomendado) && (Convert.ToDecimal(0)==AV83TFPropostaMaiorValorRecomendado_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Maior valor recomendado") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV82TFPropostaMaiorValorRecomendado);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV83TFPropostaMaiorValorRecomendado_To);
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Clinica Nome";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Paciente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Maior score";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Maior valor recomendado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV101Propostawwds_1_filterfulltext = AV18FilterFullText;
         AV102Propostawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV103Propostawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV104Propostawwds_4_propostamaxreembolsoid_f1 = AV84PropostaMaxReembolsoId_F1;
         AV105Propostawwds_5_propostaresponsaveldocumento1 = AV85PropostaResponsavelDocumento1;
         AV106Propostawwds_6_propostapacienteclientedocumento1 = AV86PropostaPacienteClienteDocumento1;
         AV107Propostawwds_7_propostaclinicadocumento1 = AV87PropostaClinicaDocumento1;
         AV108Propostawwds_8_conveniocategoriadescricao1 = AV88ConvenioCategoriaDescricao1;
         AV109Propostawwds_9_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV110Propostawwds_10_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV111Propostawwds_11_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV112Propostawwds_12_propostamaxreembolsoid_f2 = AV89PropostaMaxReembolsoId_F2;
         AV113Propostawwds_13_propostaresponsaveldocumento2 = AV90PropostaResponsavelDocumento2;
         AV114Propostawwds_14_propostapacienteclientedocumento2 = AV91PropostaPacienteClienteDocumento2;
         AV115Propostawwds_15_propostaclinicadocumento2 = AV92PropostaClinicaDocumento2;
         AV116Propostawwds_16_conveniocategoriadescricao2 = AV93ConvenioCategoriaDescricao2;
         AV117Propostawwds_17_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV118Propostawwds_18_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV119Propostawwds_19_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV120Propostawwds_20_propostamaxreembolsoid_f3 = AV94PropostaMaxReembolsoId_F3;
         AV121Propostawwds_21_propostaresponsaveldocumento3 = AV95PropostaResponsavelDocumento3;
         AV122Propostawwds_22_propostapacienteclientedocumento3 = AV96PropostaPacienteClienteDocumento3;
         AV123Propostawwds_23_propostaclinicadocumento3 = AV97PropostaClinicaDocumento3;
         AV124Propostawwds_24_conveniocategoriadescricao3 = AV98ConvenioCategoriaDescricao3;
         AV125Propostawwds_25_tfpropostaclinicanome = AV76TFPropostaClinicaNome;
         AV126Propostawwds_26_tfpropostaclinicanome_sel = AV77TFPropostaClinicaNome_Sel;
         AV127Propostawwds_27_tfpropostastatus_sels = AV49TFPropostaStatus_Sels;
         AV128Propostawwds_28_tfpropostapacienteclienterazaosocial = AV78TFPropostaPacienteClienteRazaoSocial;
         AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV79TFPropostaPacienteClienteRazaoSocial_Sel;
         AV130Propostawwds_30_tfpropostamaiorscore_f = AV80TFPropostaMaiorScore_F;
         AV131Propostawwds_31_tfpropostamaiorscore_f_to = AV81TFPropostaMaiorScore_F_To;
         AV132Propostawwds_32_tfpropostamaiorvalorrecomendado = AV82TFPropostaMaiorValorRecomendado;
         AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV83TFPropostaMaiorValorRecomendado_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV127Propostawwds_27_tfpropostastatus_sels ,
                                              AV102Propostawwds_2_dynamicfiltersselector1 ,
                                              AV103Propostawwds_3_dynamicfiltersoperator1 ,
                                              AV105Propostawwds_5_propostaresponsaveldocumento1 ,
                                              AV106Propostawwds_6_propostapacienteclientedocumento1 ,
                                              AV107Propostawwds_7_propostaclinicadocumento1 ,
                                              AV108Propostawwds_8_conveniocategoriadescricao1 ,
                                              AV109Propostawwds_9_dynamicfiltersenabled2 ,
                                              AV110Propostawwds_10_dynamicfiltersselector2 ,
                                              AV111Propostawwds_11_dynamicfiltersoperator2 ,
                                              AV113Propostawwds_13_propostaresponsaveldocumento2 ,
                                              AV114Propostawwds_14_propostapacienteclientedocumento2 ,
                                              AV115Propostawwds_15_propostaclinicadocumento2 ,
                                              AV116Propostawwds_16_conveniocategoriadescricao2 ,
                                              AV117Propostawwds_17_dynamicfiltersenabled3 ,
                                              AV118Propostawwds_18_dynamicfiltersselector3 ,
                                              AV119Propostawwds_19_dynamicfiltersoperator3 ,
                                              AV121Propostawwds_21_propostaresponsaveldocumento3 ,
                                              AV122Propostawwds_22_propostapacienteclientedocumento3 ,
                                              AV123Propostawwds_23_propostaclinicadocumento3 ,
                                              AV124Propostawwds_24_conveniocategoriadescricao3 ,
                                              AV126Propostawwds_26_tfpropostaclinicanome_sel ,
                                              AV125Propostawwds_25_tfpropostaclinicanome ,
                                              AV127Propostawwds_27_tfpropostastatus_sels.Count ,
                                              AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              AV128Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              AV9WWPContext.gxTpr_Iscliente ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A494ConvenioCategoriaDescricao ,
                                              A643PropostaClinicaNome ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV101Propostawwds_1_filterfulltext ,
                                              A784PropostaMaiorScore_F ,
                                              A788PropostaMaiorValorRecomendado ,
                                              AV104Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV112Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              AV120Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              AV130Propostawwds_30_tfpropostamaiorscore_f ,
                                              AV131Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              AV132Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV101Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Propostawwds_1_filterfulltext), "%", "");
         lV105Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV105Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV105Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV105Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV106Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV106Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV106Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV106Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV107Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV107Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV107Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV107Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV108Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV108Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV113Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV113Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV113Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV113Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV114Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV114Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV114Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV114Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV115Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV115Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV116Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV116Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV121Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV121Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV122Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV122Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV122Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV123Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV123Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV123Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV123Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV124Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV124Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV124Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV125Propostawwds_25_tfpropostaclinicanome = StringUtil.Concat( StringUtil.RTrim( AV125Propostawwds_25_tfpropostaclinicanome), "%", "");
         lV128Propostawwds_28_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_28_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P008H12 */
         pr_default.execute(0, new Object[] {AV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, lV101Propostawwds_1_filterfulltext, AV102Propostawwds_2_dynamicfiltersselector1, AV103Propostawwds_3_dynamicfiltersoperator1, AV104Propostawwds_4_propostamaxreembolsoid_f1, AV104Propostawwds_4_propostamaxreembolsoid_f1, AV102Propostawwds_2_dynamicfiltersselector1, AV103Propostawwds_3_dynamicfiltersoperator1, AV104Propostawwds_4_propostamaxreembolsoid_f1, AV104Propostawwds_4_propostamaxreembolsoid_f1, AV102Propostawwds_2_dynamicfiltersselector1, AV103Propostawwds_3_dynamicfiltersoperator1, AV104Propostawwds_4_propostamaxreembolsoid_f1, AV104Propostawwds_4_propostamaxreembolsoid_f1, AV109Propostawwds_9_dynamicfiltersenabled2, AV110Propostawwds_10_dynamicfiltersselector2, AV111Propostawwds_11_dynamicfiltersoperator2, AV112Propostawwds_12_propostamaxreembolsoid_f2, AV112Propostawwds_12_propostamaxreembolsoid_f2, AV109Propostawwds_9_dynamicfiltersenabled2, AV110Propostawwds_10_dynamicfiltersselector2, AV111Propostawwds_11_dynamicfiltersoperator2, AV112Propostawwds_12_propostamaxreembolsoid_f2, AV112Propostawwds_12_propostamaxreembolsoid_f2, AV109Propostawwds_9_dynamicfiltersenabled2, AV110Propostawwds_10_dynamicfiltersselector2, AV111Propostawwds_11_dynamicfiltersoperator2, AV112Propostawwds_12_propostamaxreembolsoid_f2, AV112Propostawwds_12_propostamaxreembolsoid_f2, AV117Propostawwds_17_dynamicfiltersenabled3, AV118Propostawwds_18_dynamicfiltersselector3, AV119Propostawwds_19_dynamicfiltersoperator3, AV120Propostawwds_20_propostamaxreembolsoid_f3, AV120Propostawwds_20_propostamaxreembolsoid_f3, AV117Propostawwds_17_dynamicfiltersenabled3, AV118Propostawwds_18_dynamicfiltersselector3, AV119Propostawwds_19_dynamicfiltersoperator3, AV120Propostawwds_20_propostamaxreembolsoid_f3, AV120Propostawwds_20_propostamaxreembolsoid_f3, AV117Propostawwds_17_dynamicfiltersenabled3, AV118Propostawwds_18_dynamicfiltersselector3, AV119Propostawwds_19_dynamicfiltersoperator3, AV120Propostawwds_20_propostamaxreembolsoid_f3, AV120Propostawwds_20_propostamaxreembolsoid_f3, AV130Propostawwds_30_tfpropostamaiorscore_f, AV130Propostawwds_30_tfpropostamaiorscore_f, AV131Propostawwds_31_tfpropostamaiorscore_f_to, AV131Propostawwds_31_tfpropostamaiorscore_f_to, AV132Propostawwds_32_tfpropostamaiorvalorrecomendado, AV132Propostawwds_32_tfpropostamaiorvalorrecomendado, AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to, AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to, lV105Propostawwds_5_propostaresponsaveldocumento1, lV105Propostawwds_5_propostaresponsaveldocumento1, lV106Propostawwds_6_propostapacienteclientedocumento1, lV106Propostawwds_6_propostapacienteclientedocumento1, lV107Propostawwds_7_propostaclinicadocumento1, lV107Propostawwds_7_propostaclinicadocumento1, lV108Propostawwds_8_conveniocategoriadescricao1, lV108Propostawwds_8_conveniocategoriadescricao1, lV113Propostawwds_13_propostaresponsaveldocumento2, lV113Propostawwds_13_propostaresponsaveldocumento2, lV114Propostawwds_14_propostapacienteclientedocumento2, lV114Propostawwds_14_propostapacienteclientedocumento2, lV115Propostawwds_15_propostaclinicadocumento2, lV115Propostawwds_15_propostaclinicadocumento2, lV116Propostawwds_16_conveniocategoriadescricao2, lV116Propostawwds_16_conveniocategoriadescricao2, lV121Propostawwds_21_propostaresponsaveldocumento3, lV121Propostawwds_21_propostaresponsaveldocumento3, lV122Propostawwds_22_propostapacienteclientedocumento3, lV122Propostawwds_22_propostapacienteclientedocumento3, lV123Propostawwds_23_propostaclinicadocumento3, lV123Propostawwds_23_propostaclinicadocumento3, lV124Propostawwds_24_conveniocategoriadescricao3, lV124Propostawwds_24_conveniocategoriadescricao3, lV125Propostawwds_25_tfpropostaclinicanome, AV126Propostawwds_26_tfpropostaclinicanome_sel, lV128Propostawwds_28_tfpropostapacienteclienterazaosocial, AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, AV9WWPContext.gxTpr_Secuserclienteid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A493ConvenioCategoriaId = P008H12_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P008H12_n493ConvenioCategoriaId[0];
            A504PropostaPacienteClienteId = P008H12_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P008H12_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P008H12_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P008H12_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P008H12_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P008H12_n642PropostaClinicaId[0];
            A328PropostaCratedBy = P008H12_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P008H12_n328PropostaCratedBy[0];
            A494ConvenioCategoriaDescricao = P008H12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P008H12_n494ConvenioCategoriaDescricao[0];
            A652PropostaClinicaDocumento = P008H12_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P008H12_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P008H12_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P008H12_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P008H12_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P008H12_n580PropostaResponsavelDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P008H12_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P008H12_n505PropostaPacienteClienteRazaoSocial[0];
            A329PropostaStatus = P008H12_A329PropostaStatus[0];
            n329PropostaStatus = P008H12_n329PropostaStatus[0];
            A643PropostaClinicaNome = P008H12_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = P008H12_n643PropostaClinicaNome[0];
            A788PropostaMaiorValorRecomendado = P008H12_A788PropostaMaiorValorRecomendado[0];
            n788PropostaMaiorValorRecomendado = P008H12_n788PropostaMaiorValorRecomendado[0];
            A784PropostaMaiorScore_F = P008H12_A784PropostaMaiorScore_F[0];
            n784PropostaMaiorScore_F = P008H12_n784PropostaMaiorScore_F[0];
            A323PropostaId = P008H12_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P008H12_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P008H12_n649PropostaMaxReembolsoId_F[0];
            A494ConvenioCategoriaDescricao = P008H12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P008H12_n494ConvenioCategoriaDescricao[0];
            A540PropostaPacienteClienteDocumento = P008H12_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P008H12_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P008H12_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P008H12_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P008H12_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P008H12_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P008H12_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P008H12_n652PropostaClinicaDocumento[0];
            A643PropostaClinicaNome = P008H12_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = P008H12_n643PropostaClinicaNome[0];
            A788PropostaMaiorValorRecomendado = P008H12_A788PropostaMaiorValorRecomendado[0];
            n788PropostaMaiorValorRecomendado = P008H12_n788PropostaMaiorValorRecomendado[0];
            A784PropostaMaiorScore_F = P008H12_A784PropostaMaiorScore_F[0];
            n784PropostaMaiorScore_F = P008H12_n784PropostaMaiorScore_F[0];
            A649PropostaMaxReembolsoId_F = P008H12_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P008H12_n649PropostaMaxReembolsoId_F[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A643PropostaClinicaNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmstatusproposta.getDescription(context,A329PropostaStatus);
            if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
            }
            else if ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A505PropostaPacienteClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A784PropostaMaiorScore_F;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = (double)(A788PropostaMaiorValorRecomendado);
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
         AV31Session.Set("WWPExportFileName", "PropostaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("PropostaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("PropostaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV134GXV2 = 1;
         while ( AV134GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV134GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTACLINICANOME") == 0 )
            {
               AV76TFPropostaClinicaNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTACLINICANOME_SEL") == 0 )
            {
               AV77TFPropostaClinicaNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV47TFPropostaStatus_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV49TFPropostaStatus_Sels.FromJSonString(AV47TFPropostaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV78TFPropostaPacienteClienteRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV79TFPropostaPacienteClienteRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAMAIORSCORE_F") == 0 )
            {
               AV80TFPropostaMaiorScore_F = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV81TFPropostaMaiorScore_F_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAMAIORVALORRECOMENDADO") == 0 )
            {
               AV82TFPropostaMaiorValorRecomendado = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV83TFPropostaMaiorValorRecomendado_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV134GXV2 = (int)(AV134GXV2+1);
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
         AV85PropostaResponsavelDocumento1 = "";
         AV86PropostaPacienteClienteDocumento1 = "";
         AV87PropostaClinicaDocumento1 = "";
         AV88ConvenioCategoriaDescricao1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV90PropostaResponsavelDocumento2 = "";
         AV91PropostaPacienteClienteDocumento2 = "";
         AV92PropostaClinicaDocumento2 = "";
         AV93ConvenioCategoriaDescricao2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV95PropostaResponsavelDocumento3 = "";
         AV96PropostaPacienteClienteDocumento3 = "";
         AV97PropostaClinicaDocumento3 = "";
         AV98ConvenioCategoriaDescricao3 = "";
         AV77TFPropostaClinicaNome_Sel = "";
         AV76TFPropostaClinicaNome = "";
         AV49TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV48TFPropostaStatus_Sel = "";
         AV79TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV78TFPropostaPacienteClienteRazaoSocial = "";
         AV101Propostawwds_1_filterfulltext = "";
         AV102Propostawwds_2_dynamicfiltersselector1 = "";
         AV105Propostawwds_5_propostaresponsaveldocumento1 = "";
         AV106Propostawwds_6_propostapacienteclientedocumento1 = "";
         AV107Propostawwds_7_propostaclinicadocumento1 = "";
         AV108Propostawwds_8_conveniocategoriadescricao1 = "";
         AV110Propostawwds_10_dynamicfiltersselector2 = "";
         AV113Propostawwds_13_propostaresponsaveldocumento2 = "";
         AV114Propostawwds_14_propostapacienteclientedocumento2 = "";
         AV115Propostawwds_15_propostaclinicadocumento2 = "";
         AV116Propostawwds_16_conveniocategoriadescricao2 = "";
         AV118Propostawwds_18_dynamicfiltersselector3 = "";
         AV121Propostawwds_21_propostaresponsaveldocumento3 = "";
         AV122Propostawwds_22_propostapacienteclientedocumento3 = "";
         AV123Propostawwds_23_propostaclinicadocumento3 = "";
         AV124Propostawwds_24_conveniocategoriadescricao3 = "";
         AV125Propostawwds_25_tfpropostaclinicanome = "";
         AV126Propostawwds_26_tfpropostaclinicanome_sel = "";
         AV127Propostawwds_27_tfpropostastatus_sels = new GxSimpleCollection<string>();
         AV128Propostawwds_28_tfpropostapacienteclienterazaosocial = "";
         AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = "";
         lV101Propostawwds_1_filterfulltext = "";
         lV105Propostawwds_5_propostaresponsaveldocumento1 = "";
         lV106Propostawwds_6_propostapacienteclientedocumento1 = "";
         lV107Propostawwds_7_propostaclinicadocumento1 = "";
         lV108Propostawwds_8_conveniocategoriadescricao1 = "";
         lV113Propostawwds_13_propostaresponsaveldocumento2 = "";
         lV114Propostawwds_14_propostapacienteclientedocumento2 = "";
         lV115Propostawwds_15_propostaclinicadocumento2 = "";
         lV116Propostawwds_16_conveniocategoriadescricao2 = "";
         lV121Propostawwds_21_propostaresponsaveldocumento3 = "";
         lV122Propostawwds_22_propostapacienteclientedocumento3 = "";
         lV123Propostawwds_23_propostaclinicadocumento3 = "";
         lV124Propostawwds_24_conveniocategoriadescricao3 = "";
         lV125Propostawwds_25_tfpropostaclinicanome = "";
         lV128Propostawwds_28_tfpropostapacienteclienterazaosocial = "";
         A329PropostaStatus = "";
         A580PropostaResponsavelDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         A652PropostaClinicaDocumento = "";
         A494ConvenioCategoriaDescricao = "";
         A643PropostaClinicaNome = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         P008H12_A493ConvenioCategoriaId = new int[1] ;
         P008H12_n493ConvenioCategoriaId = new bool[] {false} ;
         P008H12_A504PropostaPacienteClienteId = new int[1] ;
         P008H12_n504PropostaPacienteClienteId = new bool[] {false} ;
         P008H12_A553PropostaResponsavelId = new int[1] ;
         P008H12_n553PropostaResponsavelId = new bool[] {false} ;
         P008H12_A642PropostaClinicaId = new int[1] ;
         P008H12_n642PropostaClinicaId = new bool[] {false} ;
         P008H12_A328PropostaCratedBy = new short[1] ;
         P008H12_n328PropostaCratedBy = new bool[] {false} ;
         P008H12_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P008H12_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P008H12_A652PropostaClinicaDocumento = new string[] {""} ;
         P008H12_n652PropostaClinicaDocumento = new bool[] {false} ;
         P008H12_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P008H12_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P008H12_A580PropostaResponsavelDocumento = new string[] {""} ;
         P008H12_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P008H12_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P008H12_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P008H12_A329PropostaStatus = new string[] {""} ;
         P008H12_n329PropostaStatus = new bool[] {false} ;
         P008H12_A643PropostaClinicaNome = new string[] {""} ;
         P008H12_n643PropostaClinicaNome = new bool[] {false} ;
         P008H12_A788PropostaMaiorValorRecomendado = new decimal[1] ;
         P008H12_n788PropostaMaiorValorRecomendado = new bool[] {false} ;
         P008H12_A784PropostaMaiorScore_F = new short[1] ;
         P008H12_n784PropostaMaiorScore_F = new bool[] {false} ;
         P008H12_A323PropostaId = new int[1] ;
         P008H12_A649PropostaMaxReembolsoId_F = new int[1] ;
         P008H12_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFPropostaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostawwexport__default(),
            new Object[][] {
                new Object[] {
               P008H12_A493ConvenioCategoriaId, P008H12_n493ConvenioCategoriaId, P008H12_A504PropostaPacienteClienteId, P008H12_n504PropostaPacienteClienteId, P008H12_A553PropostaResponsavelId, P008H12_n553PropostaResponsavelId, P008H12_A642PropostaClinicaId, P008H12_n642PropostaClinicaId, P008H12_A328PropostaCratedBy, P008H12_n328PropostaCratedBy,
               P008H12_A494ConvenioCategoriaDescricao, P008H12_n494ConvenioCategoriaDescricao, P008H12_A652PropostaClinicaDocumento, P008H12_n652PropostaClinicaDocumento, P008H12_A540PropostaPacienteClienteDocumento, P008H12_n540PropostaPacienteClienteDocumento, P008H12_A580PropostaResponsavelDocumento, P008H12_n580PropostaResponsavelDocumento, P008H12_A505PropostaPacienteClienteRazaoSocial, P008H12_n505PropostaPacienteClienteRazaoSocial,
               P008H12_A329PropostaStatus, P008H12_n329PropostaStatus, P008H12_A643PropostaClinicaNome, P008H12_n643PropostaClinicaNome, P008H12_A788PropostaMaiorValorRecomendado, P008H12_n788PropostaMaiorValorRecomendado, P008H12_A784PropostaMaiorScore_F, P008H12_n784PropostaMaiorScore_F, P008H12_A323PropostaId, P008H12_A649PropostaMaxReembolsoId_F,
               P008H12_n649PropostaMaxReembolsoId_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV80TFPropostaMaiorScore_F ;
      private short AV81TFPropostaMaiorScore_F_To ;
      private short GXt_int2 ;
      private short AV103Propostawwds_3_dynamicfiltersoperator1 ;
      private short AV111Propostawwds_11_dynamicfiltersoperator2 ;
      private short AV119Propostawwds_19_dynamicfiltersoperator3 ;
      private short AV130Propostawwds_30_tfpropostamaiorscore_f ;
      private short AV131Propostawwds_31_tfpropostamaiorscore_f_to ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A328PropostaCratedBy ;
      private short AV16OrderedBy ;
      private short A784PropostaMaiorScore_F ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV84PropostaMaxReembolsoId_F1 ;
      private int AV89PropostaMaxReembolsoId_F2 ;
      private int AV94PropostaMaxReembolsoId_F3 ;
      private int AV99GXV1 ;
      private int AV104Propostawwds_4_propostamaxreembolsoid_f1 ;
      private int AV112Propostawwds_12_propostamaxreembolsoid_f2 ;
      private int AV120Propostawwds_20_propostamaxreembolsoid_f3 ;
      private int AV127Propostawwds_27_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A323PropostaId ;
      private int AV134GXV2 ;
      private long AV54i ;
      private decimal AV82TFPropostaMaiorValorRecomendado ;
      private decimal AV83TFPropostaMaiorValorRecomendado_To ;
      private decimal AV132Propostawwds_32_tfpropostamaiorvalorrecomendado ;
      private decimal AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to ;
      private decimal A788PropostaMaiorValorRecomendado ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV109Propostawwds_9_dynamicfiltersenabled2 ;
      private bool AV117Propostawwds_17_dynamicfiltersenabled3 ;
      private bool AV9WWPContext_gxTpr_Iscliente ;
      private bool AV17OrderedDsc ;
      private bool n493ConvenioCategoriaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n328PropostaCratedBy ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n652PropostaClinicaDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n329PropostaStatus ;
      private bool n643PropostaClinicaNome ;
      private bool n788PropostaMaiorValorRecomendado ;
      private bool n784PropostaMaiorScore_F ;
      private bool n649PropostaMaxReembolsoId_F ;
      private string AV47TFPropostaStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV85PropostaResponsavelDocumento1 ;
      private string AV86PropostaPacienteClienteDocumento1 ;
      private string AV87PropostaClinicaDocumento1 ;
      private string AV88ConvenioCategoriaDescricao1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV90PropostaResponsavelDocumento2 ;
      private string AV91PropostaPacienteClienteDocumento2 ;
      private string AV92PropostaClinicaDocumento2 ;
      private string AV93ConvenioCategoriaDescricao2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV95PropostaResponsavelDocumento3 ;
      private string AV96PropostaPacienteClienteDocumento3 ;
      private string AV97PropostaClinicaDocumento3 ;
      private string AV98ConvenioCategoriaDescricao3 ;
      private string AV77TFPropostaClinicaNome_Sel ;
      private string AV76TFPropostaClinicaNome ;
      private string AV48TFPropostaStatus_Sel ;
      private string AV79TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV78TFPropostaPacienteClienteRazaoSocial ;
      private string AV101Propostawwds_1_filterfulltext ;
      private string AV102Propostawwds_2_dynamicfiltersselector1 ;
      private string AV105Propostawwds_5_propostaresponsaveldocumento1 ;
      private string AV106Propostawwds_6_propostapacienteclientedocumento1 ;
      private string AV107Propostawwds_7_propostaclinicadocumento1 ;
      private string AV108Propostawwds_8_conveniocategoriadescricao1 ;
      private string AV110Propostawwds_10_dynamicfiltersselector2 ;
      private string AV113Propostawwds_13_propostaresponsaveldocumento2 ;
      private string AV114Propostawwds_14_propostapacienteclientedocumento2 ;
      private string AV115Propostawwds_15_propostaclinicadocumento2 ;
      private string AV116Propostawwds_16_conveniocategoriadescricao2 ;
      private string AV118Propostawwds_18_dynamicfiltersselector3 ;
      private string AV121Propostawwds_21_propostaresponsaveldocumento3 ;
      private string AV122Propostawwds_22_propostapacienteclientedocumento3 ;
      private string AV123Propostawwds_23_propostaclinicadocumento3 ;
      private string AV124Propostawwds_24_conveniocategoriadescricao3 ;
      private string AV125Propostawwds_25_tfpropostaclinicanome ;
      private string AV126Propostawwds_26_tfpropostaclinicanome_sel ;
      private string AV128Propostawwds_28_tfpropostapacienteclienterazaosocial ;
      private string AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ;
      private string lV101Propostawwds_1_filterfulltext ;
      private string lV105Propostawwds_5_propostaresponsaveldocumento1 ;
      private string lV106Propostawwds_6_propostapacienteclientedocumento1 ;
      private string lV107Propostawwds_7_propostaclinicadocumento1 ;
      private string lV108Propostawwds_8_conveniocategoriadescricao1 ;
      private string lV113Propostawwds_13_propostaresponsaveldocumento2 ;
      private string lV114Propostawwds_14_propostapacienteclientedocumento2 ;
      private string lV115Propostawwds_15_propostaclinicadocumento2 ;
      private string lV116Propostawwds_16_conveniocategoriadescricao2 ;
      private string lV121Propostawwds_21_propostaresponsaveldocumento3 ;
      private string lV122Propostawwds_22_propostapacienteclientedocumento3 ;
      private string lV123Propostawwds_23_propostaclinicadocumento3 ;
      private string lV124Propostawwds_24_conveniocategoriadescricao3 ;
      private string lV125Propostawwds_25_tfpropostaclinicanome ;
      private string lV128Propostawwds_28_tfpropostapacienteclienterazaosocial ;
      private string A329PropostaStatus ;
      private string A580PropostaResponsavelDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A494ConvenioCategoriaDescricao ;
      private string A643PropostaClinicaNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV49TFPropostaStatus_Sels ;
      private GxSimpleCollection<string> AV127Propostawwds_27_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P008H12_A493ConvenioCategoriaId ;
      private bool[] P008H12_n493ConvenioCategoriaId ;
      private int[] P008H12_A504PropostaPacienteClienteId ;
      private bool[] P008H12_n504PropostaPacienteClienteId ;
      private int[] P008H12_A553PropostaResponsavelId ;
      private bool[] P008H12_n553PropostaResponsavelId ;
      private int[] P008H12_A642PropostaClinicaId ;
      private bool[] P008H12_n642PropostaClinicaId ;
      private short[] P008H12_A328PropostaCratedBy ;
      private bool[] P008H12_n328PropostaCratedBy ;
      private string[] P008H12_A494ConvenioCategoriaDescricao ;
      private bool[] P008H12_n494ConvenioCategoriaDescricao ;
      private string[] P008H12_A652PropostaClinicaDocumento ;
      private bool[] P008H12_n652PropostaClinicaDocumento ;
      private string[] P008H12_A540PropostaPacienteClienteDocumento ;
      private bool[] P008H12_n540PropostaPacienteClienteDocumento ;
      private string[] P008H12_A580PropostaResponsavelDocumento ;
      private bool[] P008H12_n580PropostaResponsavelDocumento ;
      private string[] P008H12_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P008H12_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P008H12_A329PropostaStatus ;
      private bool[] P008H12_n329PropostaStatus ;
      private string[] P008H12_A643PropostaClinicaNome ;
      private bool[] P008H12_n643PropostaClinicaNome ;
      private decimal[] P008H12_A788PropostaMaiorValorRecomendado ;
      private bool[] P008H12_n788PropostaMaiorValorRecomendado ;
      private short[] P008H12_A784PropostaMaiorScore_F ;
      private bool[] P008H12_n784PropostaMaiorScore_F ;
      private int[] P008H12_A323PropostaId ;
      private int[] P008H12_A649PropostaMaxReembolsoId_F ;
      private bool[] P008H12_n649PropostaMaxReembolsoId_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class propostawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008H12( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV127Propostawwds_27_tfpropostastatus_sels ,
                                              string AV102Propostawwds_2_dynamicfiltersselector1 ,
                                              short AV103Propostawwds_3_dynamicfiltersoperator1 ,
                                              string AV105Propostawwds_5_propostaresponsaveldocumento1 ,
                                              string AV106Propostawwds_6_propostapacienteclientedocumento1 ,
                                              string AV107Propostawwds_7_propostaclinicadocumento1 ,
                                              string AV108Propostawwds_8_conveniocategoriadescricao1 ,
                                              bool AV109Propostawwds_9_dynamicfiltersenabled2 ,
                                              string AV110Propostawwds_10_dynamicfiltersselector2 ,
                                              short AV111Propostawwds_11_dynamicfiltersoperator2 ,
                                              string AV113Propostawwds_13_propostaresponsaveldocumento2 ,
                                              string AV114Propostawwds_14_propostapacienteclientedocumento2 ,
                                              string AV115Propostawwds_15_propostaclinicadocumento2 ,
                                              string AV116Propostawwds_16_conveniocategoriadescricao2 ,
                                              bool AV117Propostawwds_17_dynamicfiltersenabled3 ,
                                              string AV118Propostawwds_18_dynamicfiltersselector3 ,
                                              short AV119Propostawwds_19_dynamicfiltersoperator3 ,
                                              string AV121Propostawwds_21_propostaresponsaveldocumento3 ,
                                              string AV122Propostawwds_22_propostapacienteclientedocumento3 ,
                                              string AV123Propostawwds_23_propostaclinicadocumento3 ,
                                              string AV124Propostawwds_24_conveniocategoriadescricao3 ,
                                              string AV126Propostawwds_26_tfpropostaclinicanome_sel ,
                                              string AV125Propostawwds_25_tfpropostaclinicanome ,
                                              int AV127Propostawwds_27_tfpropostastatus_sels_Count ,
                                              string AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV128Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              bool AV9WWPContext_gxTpr_Iscliente ,
                                              string A580PropostaResponsavelDocumento ,
                                              string A540PropostaPacienteClienteDocumento ,
                                              string A652PropostaClinicaDocumento ,
                                              string A494ConvenioCategoriaDescricao ,
                                              string A643PropostaClinicaNome ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              short A328PropostaCratedBy ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              short AV16OrderedBy ,
                                              bool AV17OrderedDsc ,
                                              string AV101Propostawwds_1_filterfulltext ,
                                              short A784PropostaMaiorScore_F ,
                                              decimal A788PropostaMaiorValorRecomendado ,
                                              int AV104Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              int A649PropostaMaxReembolsoId_F ,
                                              int AV112Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              int AV120Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              short AV130Propostawwds_30_tfpropostamaiorscore_f ,
                                              short AV131Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              decimal AV132Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              decimal AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[92];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaCratedBy, T2.ConvenioCategoriaDescricao, T5.ClienteDocumento AS PropostaClinicaDocumento, T3.ClienteDocumento AS PropostaPacienteClienteDocumento, T4.ClienteDocumento AS PropostaResponsavelDocumento, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaStatus, T5.ClienteRazaoSocial AS PropostaClinicaNome, COALESCE( T6.PropostaMaiorValorRecomendado, 0) AS PropostaMaiorValorRecomendado, COALESCE( T6.PropostaMaiorScore_F, 0) AS PropostaMaiorScore_F, T1.PropostaId, COALESCE( T7.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM ((((((Proposta T1 LEFT JOIN ConvenioCategoria T2 ON T2.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaClinicaId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T9.PropostaSerasaScoreUltimaData_F, 0) > COALESCE( T10.PropostaSerasaScoreUltimaData_F, 0) THEN COALESCE( T9.PropostaSerasaScoreUltimaData_F, 0) ELSE COALESCE( T10.PropostaSerasaScoreUltimaData_F, 0) END AS PropostaMaiorScore_F, T8.PropostaId, CASE  WHEN COALESCE( T11.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) > COALESCE( T12.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) THEN COALESCE( T11.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) ELSE COALESCE( T12.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) END AS PropostaMaiorValorRecomendado FROM ((((Proposta T8 LEFT JOIN LATERAL (SELECT MAX(T13.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T14.SerasaUltimaData_F,";
         scmdbuf += " DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T9 ON T9.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T10 ON T10.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T11 ON T11.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F,";
         scmdbuf += " COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T12 ON T12.ClienteId = T8.PropostaPacienteClienteId) ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV101Propostawwds_1_filterfulltext))=0) or ( ( T5.ClienteRazaoSocial like '%' || :lV101Propostawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV101Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T3.ClienteRazaoSocial like '%' || :lV101Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaMaiorScore_F, 0),'9999'), 2) like '%' || :lV101Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaMaiorValorRecomendado, 0),'999999999999990.99'), 2) like '%' || :lV101Propostawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(Not ( :AV102Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV103Propostawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV104Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV104Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV102Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV103Propostawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV104Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV104Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV102Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV103Propostawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV104Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV104Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_9_dynamicfiltersenabled2 and :AV110Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Propostawwds_11_dynamicfiltersoperator2 = 0 and ( Not (:AV112Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV112Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_9_dynamicfiltersenabled2 and :AV110Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Propostawwds_11_dynamicfiltersoperator2 = 1 and ( Not (:AV112Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV112Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_9_dynamicfiltersenabled2 and :AV110Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV111Propostawwds_11_dynamicfiltersoperator2 = 2 and ( Not (:AV112Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV112Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV117Propostawwds_17_dynamicfiltersenabled3 and :AV118Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV119Propostawwds_19_dynamicfiltersoperator3 = 0 and ( Not (:AV120Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV120Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV117Propostawwds_17_dynamicfiltersenabled3 and :AV118Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV119Propostawwds_19_dynamicfiltersoperator3 = 1 and ( Not (:AV120Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV120Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV117Propostawwds_17_dynamicfiltersenabled3 and :AV118Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV119Propostawwds_19_dynamicfiltersoperator3 = 2 and ( Not (:AV120Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV120Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV130Propostawwds_30_tfpropostamaiorscore_f = 0) or ( COALESCE( T6.PropostaMaiorScore_F, 0) >= :AV130Propostawwds_30_tfpropostamaiorscore_f))");
         AddWhere(sWhereString, "((:AV131Propostawwds_31_tfpropostamaiorscore_f_to = 0) or ( COALESCE( T6.PropostaMaiorScore_F, 0) <= :AV131Propostawwds_31_tfpropostamaiorscore_f_to))");
         AddWhere(sWhereString, "((:AV132Propostawwds_32_tfpropostamaiorvalorrecomendado = 0) or ( COALESCE( T6.PropostaMaiorValorRecomendado, 0) >= :AV132Propostawwds_32_tfpropostamaiorvalorrecomendado))");
         AddWhere(sWhereString, "((:AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to = 0) or ( COALESCE( T6.PropostaMaiorValorRecomendado, 0) <= :AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to))");
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV105Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV105Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV106Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV106Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV107Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV107Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV108Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV103Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV108Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV113Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV113Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV114Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV114Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV115Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV115Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV116Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( AV109Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV111Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV116Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV121Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV121Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV122Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV122Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV123Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[83] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV123Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[84] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV124Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[85] = 1;
         }
         if ( AV117Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV118Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV119Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV124Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[86] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Propostawwds_26_tfpropostaclinicanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Propostawwds_25_tfpropostaclinicanome)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV125Propostawwds_25_tfpropostaclinicanome)");
         }
         else
         {
            GXv_int3[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Propostawwds_26_tfpropostaclinicanome_sel)) && ! ( StringUtil.StrCmp(AV126Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV126Propostawwds_26_tfpropostaclinicanome_sel))");
         }
         else
         {
            GXv_int3[88] = 1;
         }
         if ( StringUtil.StrCmp(AV126Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( AV127Propostawwds_27_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV127Propostawwds_27_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_28_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV128Propostawwds_28_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[90] = 1;
         }
         if ( StringUtil.StrCmp(AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( AV9WWPContext_gxTpr_Iscliente )
         {
            AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_1Secuserclienteid)");
         }
         else
         {
            GXv_int3[91] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.PropostaId DESC";
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
            scmdbuf += " ORDER BY T1.PropostaStatus";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PropostaStatus DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial DESC";
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
                     return conditional_P008H12(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (string)dynConstraints[38] , (short)dynConstraints[39] , (decimal)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] , (short)dynConstraints[45] , (short)dynConstraints[46] , (decimal)dynConstraints[47] , (decimal)dynConstraints[48] );
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
          Object[] prmP008H12;
          prmP008H12 = new Object[] {
          new ParDef("AV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV102Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV103Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV104Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV104Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV103Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV104Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV104Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV102Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV103Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV104Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV104Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV110Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV111Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV112Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV112Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV117Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV118Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV119Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV120Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV120Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV117Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV118Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV119Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV120Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV120Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV117Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV118Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV119Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV120Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV120Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV130Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV130Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV131Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV131Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV132Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV132Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("AV133Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("lV105Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV105Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV106Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV106Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV107Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV107Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV108Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV108Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV113Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV114Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV114Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV116Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV116Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV121Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV121Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV123Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV123Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV124Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV124Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV125Propostawwds_25_tfpropostaclinicanome",GXType.VarChar,150,0) ,
          new ParDef("AV126Propostawwds_26_tfpropostaclinicanome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV128Propostawwds_28_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV129Propostawwds_29_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008H12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H12,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
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
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((short[]) buf[26])[0] = rslt.getShort(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
       }
    }

 }

}
