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
   public class clienterepresentanteswwexport : GXProcedure
   {
      public clienterepresentanteswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienterepresentanteswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ClienteRepresentantesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV84TipoClienteId) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo Cliente Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV84TipoClienteId;
         }
         if ( AV60GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV57GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV60GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV57GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV21ClienteDocumento1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV22TipoClienteDescricao1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TipoClienteDescricao1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22TipoClienteDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV23ClienteConvenioDescricao1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteConvenioDescricao1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ClienteConvenioDescricao1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV24ClienteNacionalidadeNome1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteNacionalidadeNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ClienteNacionalidadeNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV25ClienteProfissaoNome1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ClienteProfissaoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ClienteProfissaoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV26MunicipioNome1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MunicipioNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26MunicipioNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV27BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV57GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV27BancoCodigo1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV27BancoCodigo1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV28ResponsavelNacionalidadeNome1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ResponsavelNacionalidadeNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ResponsavelNacionalidadeNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV29ResponsavelProfissaoNome1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ResponsavelProfissaoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ResponsavelProfissaoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV57GridStateDynamicFilter.gxTpr_Operator;
               AV30ResponsavelMunicipioNome1 = AV57GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ResponsavelMunicipioNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ResponsavelMunicipioNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV60GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV31DynamicFiltersEnabled2 = true;
               AV57GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV60GridState.gxTpr_Dynamicfilters.Item(2));
               AV32DynamicFiltersSelector2 = AV57GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV34ClienteDocumento2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34ClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV35TipoClienteDescricao2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TipoClienteDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TipoClienteDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV36ClienteConvenioDescricao2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ClienteConvenioDescricao2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36ClienteConvenioDescricao2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV37ClienteNacionalidadeNome2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ClienteNacionalidadeNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37ClienteNacionalidadeNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV38ClienteProfissaoNome2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ClienteProfissaoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38ClienteProfissaoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV39MunicipioNome2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39MunicipioNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39MunicipioNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV40BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV57GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV40BancoCodigo2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV40BancoCodigo2;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV41ResponsavelNacionalidadeNome2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41ResponsavelNacionalidadeNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41ResponsavelNacionalidadeNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV42ResponsavelProfissaoNome2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResponsavelProfissaoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42ResponsavelProfissaoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV33DynamicFiltersOperator2 = AV57GridStateDynamicFilter.gxTpr_Operator;
                  AV43ResponsavelMunicipioNome2 = AV57GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ResponsavelMunicipioNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV33DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV33DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43ResponsavelMunicipioNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV60GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV44DynamicFiltersEnabled3 = true;
                  AV57GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV60GridState.gxTpr_Dynamicfilters.Item(3));
                  AV45DynamicFiltersSelector3 = AV57GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV47ClienteDocumento3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47ClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV48TipoClienteDescricao3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TipoClienteDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TipoClienteDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV49ClienteConvenioDescricao3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ClienteConvenioDescricao3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49ClienteConvenioDescricao3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV50ClienteNacionalidadeNome3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ClienteNacionalidadeNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50ClienteNacionalidadeNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV51ClienteProfissaoNome3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ClienteProfissaoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51ClienteProfissaoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV52MunicipioNome3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52MunicipioNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52MunicipioNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV53BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV57GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV53BancoCodigo3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV53BancoCodigo3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV54ResponsavelNacionalidadeNome3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ResponsavelNacionalidadeNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54ResponsavelNacionalidadeNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV55ResponsavelProfissaoNome3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ResponsavelProfissaoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55ResponsavelProfissaoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV46DynamicFiltersOperator3 = AV57GridStateDynamicFilter.gxTpr_Operator;
                     AV56ResponsavelMunicipioNome3 = AV57GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelMunicipioNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV46DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV46DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56ResponsavelMunicipioNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) ? "(Vazio)" : AV63TFResponsavelNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFResponsavelNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFResponsavelNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) ? "(Vazio)" : AV65TFResponsavelCPF_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelCPF)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFResponsavelCPF, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Celular") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) ? "(Vazio)" : AV67TFResponsavelCelular_F_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelCelular_F)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Celular") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV66TFResponsavelCelular_F, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) ? "(Vazio)" : AV69TFResponsavelEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFResponsavelEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68TFResponsavelEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV72TFResponsavelCargo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cargo") ;
            AV13CellRow = GXt_int2;
            AV83i = 1;
            AV85GXV1 = 1;
            while ( AV85GXV1 <= AV72TFResponsavelCargo_Sels.Count )
            {
               AV71TFResponsavelCargo_Sel = ((string)AV72TFResponsavelCargo_Sels.Item(AV85GXV1));
               if ( AV83i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmcargo.getDescription(context,AV71TFResponsavelCargo_Sel);
               AV83i = (long)(AV83i+1);
               AV85GXV1 = (int)(AV85GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CNPJ") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteDocumento_Sel)) ? "(Vazio)" : AV74TFClienteDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CNPJ") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73TFClienteDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razão Social") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV76TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV76TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razão Social") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75TFClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV82TFClienteSituacao_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação") ;
            AV13CellRow = GXt_int2;
            AV83i = 1;
            AV86GXV2 = 1;
            while ( AV86GXV2 <= AV82TFClienteSituacao_Sels.Count )
            {
               AV81TFClienteSituacao_Sel = AV82TFClienteSituacao_Sels.GetString(AV86GXV2);
               if ( AV83i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmsituacao.getDescription(context,AV81TFClienteSituacao_Sel);
               AV83i = (long)(AV83i+1);
               AV86GXV2 = (int)(AV86GXV2+1);
            }
         }
         if ( ! ( (0==AV79TFClienteStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV79TFClienteStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV79TFClienteStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "CPF";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Celular";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Email";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Cargo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "CNPJ";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Razão Social";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Situação";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV72TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV82TFClienteSituacao_Sels ,
                                              AV19DynamicFiltersSelector1 ,
                                              AV20DynamicFiltersOperator1 ,
                                              AV21ClienteDocumento1 ,
                                              AV22TipoClienteDescricao1 ,
                                              AV23ClienteConvenioDescricao1 ,
                                              AV24ClienteNacionalidadeNome1 ,
                                              AV25ClienteProfissaoNome1 ,
                                              AV26MunicipioNome1 ,
                                              AV27BancoCodigo1 ,
                                              AV28ResponsavelNacionalidadeNome1 ,
                                              AV29ResponsavelProfissaoNome1 ,
                                              AV30ResponsavelMunicipioNome1 ,
                                              AV31DynamicFiltersEnabled2 ,
                                              AV32DynamicFiltersSelector2 ,
                                              AV33DynamicFiltersOperator2 ,
                                              AV34ClienteDocumento2 ,
                                              AV35TipoClienteDescricao2 ,
                                              AV36ClienteConvenioDescricao2 ,
                                              AV37ClienteNacionalidadeNome2 ,
                                              AV38ClienteProfissaoNome2 ,
                                              AV39MunicipioNome2 ,
                                              AV40BancoCodigo2 ,
                                              AV41ResponsavelNacionalidadeNome2 ,
                                              AV42ResponsavelProfissaoNome2 ,
                                              AV43ResponsavelMunicipioNome2 ,
                                              AV44DynamicFiltersEnabled3 ,
                                              AV45DynamicFiltersSelector3 ,
                                              AV46DynamicFiltersOperator3 ,
                                              AV47ClienteDocumento3 ,
                                              AV48TipoClienteDescricao3 ,
                                              AV49ClienteConvenioDescricao3 ,
                                              AV50ClienteNacionalidadeNome3 ,
                                              AV51ClienteProfissaoNome3 ,
                                              AV52MunicipioNome3 ,
                                              AV53BancoCodigo3 ,
                                              AV54ResponsavelNacionalidadeNome3 ,
                                              AV55ResponsavelProfissaoNome3 ,
                                              AV56ResponsavelMunicipioNome3 ,
                                              AV63TFResponsavelNome_Sel ,
                                              AV62TFResponsavelNome ,
                                              AV65TFResponsavelCPF_Sel ,
                                              AV64TFResponsavelCPF ,
                                              AV69TFResponsavelEmail_Sel ,
                                              AV68TFResponsavelEmail ,
                                              AV72TFResponsavelCargo_Sels.Count ,
                                              AV74TFClienteDocumento_Sel ,
                                              AV73TFClienteDocumento ,
                                              AV76TFClienteRazaoSocial_Sel ,
                                              AV75TFClienteRazaoSocial ,
                                              AV82TFClienteSituacao_Sels.Count ,
                                              AV79TFClienteStatus_Sel ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV18FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV67TFResponsavelCelular_F_Sel ,
                                              AV66TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV21ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteDocumento1), "%", "");
         lV21ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV21ClienteDocumento1), "%", "");
         lV22TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV22TipoClienteDescricao1), "%", "");
         lV22TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV22TipoClienteDescricao1), "%", "");
         lV23ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV23ClienteConvenioDescricao1), "%", "");
         lV23ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV23ClienteConvenioDescricao1), "%", "");
         lV24ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV24ClienteNacionalidadeNome1), "%", "");
         lV24ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV24ClienteNacionalidadeNome1), "%", "");
         lV25ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV25ClienteProfissaoNome1), "%", "");
         lV25ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV25ClienteProfissaoNome1), "%", "");
         lV26MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV26MunicipioNome1), "%", "");
         lV26MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV26MunicipioNome1), "%", "");
         lV28ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV28ResponsavelNacionalidadeNome1), "%", "");
         lV28ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV28ResponsavelNacionalidadeNome1), "%", "");
         lV29ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV29ResponsavelProfissaoNome1), "%", "");
         lV29ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV29ResponsavelProfissaoNome1), "%", "");
         lV30ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV30ResponsavelMunicipioNome1), "%", "");
         lV30ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV30ResponsavelMunicipioNome1), "%", "");
         lV34ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV34ClienteDocumento2), "%", "");
         lV34ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV34ClienteDocumento2), "%", "");
         lV35TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV35TipoClienteDescricao2), "%", "");
         lV35TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV35TipoClienteDescricao2), "%", "");
         lV36ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV36ClienteConvenioDescricao2), "%", "");
         lV36ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV36ClienteConvenioDescricao2), "%", "");
         lV37ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV37ClienteNacionalidadeNome2), "%", "");
         lV37ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV37ClienteNacionalidadeNome2), "%", "");
         lV38ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV38ClienteProfissaoNome2), "%", "");
         lV38ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV38ClienteProfissaoNome2), "%", "");
         lV39MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV39MunicipioNome2), "%", "");
         lV39MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV39MunicipioNome2), "%", "");
         lV41ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV41ResponsavelNacionalidadeNome2), "%", "");
         lV41ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV41ResponsavelNacionalidadeNome2), "%", "");
         lV42ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV42ResponsavelProfissaoNome2), "%", "");
         lV42ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV42ResponsavelProfissaoNome2), "%", "");
         lV43ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV43ResponsavelMunicipioNome2), "%", "");
         lV43ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV43ResponsavelMunicipioNome2), "%", "");
         lV47ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV47ClienteDocumento3), "%", "");
         lV47ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV47ClienteDocumento3), "%", "");
         lV48TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV48TipoClienteDescricao3), "%", "");
         lV48TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV48TipoClienteDescricao3), "%", "");
         lV49ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV49ClienteConvenioDescricao3), "%", "");
         lV49ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV49ClienteConvenioDescricao3), "%", "");
         lV50ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV50ClienteNacionalidadeNome3), "%", "");
         lV50ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV50ClienteNacionalidadeNome3), "%", "");
         lV51ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV51ClienteProfissaoNome3), "%", "");
         lV51ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV51ClienteProfissaoNome3), "%", "");
         lV52MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV52MunicipioNome3), "%", "");
         lV52MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV52MunicipioNome3), "%", "");
         lV54ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV54ResponsavelNacionalidadeNome3), "%", "");
         lV54ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV54ResponsavelNacionalidadeNome3), "%", "");
         lV55ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV55ResponsavelProfissaoNome3), "%", "");
         lV55ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV55ResponsavelProfissaoNome3), "%", "");
         lV56ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV56ResponsavelMunicipioNome3), "%", "");
         lV56ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV56ResponsavelMunicipioNome3), "%", "");
         lV62TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV62TFResponsavelNome), "%", "");
         lV64TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV64TFResponsavelCPF), "%", "");
         lV68TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV68TFResponsavelEmail), "%", "");
         lV73TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV73TFClienteDocumento), "%", "");
         lV75TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV75TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DX2 */
         pr_default.execute(0, new Object[] {lV21ClienteDocumento1, lV21ClienteDocumento1, lV22TipoClienteDescricao1, lV22TipoClienteDescricao1, lV23ClienteConvenioDescricao1, lV23ClienteConvenioDescricao1, lV24ClienteNacionalidadeNome1, lV24ClienteNacionalidadeNome1, lV25ClienteProfissaoNome1, lV25ClienteProfissaoNome1, lV26MunicipioNome1, lV26MunicipioNome1, AV27BancoCodigo1, AV27BancoCodigo1, AV27BancoCodigo1, lV28ResponsavelNacionalidadeNome1, lV28ResponsavelNacionalidadeNome1, lV29ResponsavelProfissaoNome1, lV29ResponsavelProfissaoNome1, lV30ResponsavelMunicipioNome1, lV30ResponsavelMunicipioNome1, lV34ClienteDocumento2, lV34ClienteDocumento2, lV35TipoClienteDescricao2, lV35TipoClienteDescricao2, lV36ClienteConvenioDescricao2, lV36ClienteConvenioDescricao2, lV37ClienteNacionalidadeNome2, lV37ClienteNacionalidadeNome2, lV38ClienteProfissaoNome2, lV38ClienteProfissaoNome2, lV39MunicipioNome2, lV39MunicipioNome2, AV40BancoCodigo2, AV40BancoCodigo2, AV40BancoCodigo2, lV41ResponsavelNacionalidadeNome2, lV41ResponsavelNacionalidadeNome2, lV42ResponsavelProfissaoNome2, lV42ResponsavelProfissaoNome2, lV43ResponsavelMunicipioNome2, lV43ResponsavelMunicipioNome2, lV47ClienteDocumento3, lV47ClienteDocumento3, lV48TipoClienteDescricao3, lV48TipoClienteDescricao3, lV49ClienteConvenioDescricao3, lV49ClienteConvenioDescricao3, lV50ClienteNacionalidadeNome3, lV50ClienteNacionalidadeNome3, lV51ClienteProfissaoNome3, lV51ClienteProfissaoNome3, lV52MunicipioNome3, lV52MunicipioNome3, AV53BancoCodigo3, AV53BancoCodigo3, AV53BancoCodigo3, lV54ResponsavelNacionalidadeNome3, lV54ResponsavelNacionalidadeNome3, lV55ResponsavelProfissaoNome3, lV55ResponsavelProfissaoNome3, lV56ResponsavelMunicipioNome3, lV56ResponsavelMunicipioNome3, lV62TFResponsavelNome, AV63TFResponsavelNome_Sel, lV64TFResponsavelCPF, AV65TFResponsavelCPF_Sel, lV68TFResponsavelEmail, AV69TFResponsavelEmail_Sel, lV73TFClienteDocumento, AV74TFClienteDocumento_Sel, lV75TFClienteRazaoSocial, AV76TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A186MunicipioCodigo = P00DX2_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DX2_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DX2_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DX2_n444ResponsavelMunicipio[0];
            A402BancoId = P00DX2_A402BancoId[0];
            n402BancoId = P00DX2_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DX2_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DX2_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DX2_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DX2_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DX2_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DX2_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DX2_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DX2_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DX2_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DX2_n489ClienteConvenio[0];
            A445ResponsavelMunicipioNome = P00DX2_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DX2_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DX2_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DX2_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DX2_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DX2_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DX2_A404BancoCodigo[0];
            n404BancoCodigo = P00DX2_n404BancoCodigo[0];
            A187MunicipioNome = P00DX2_A187MunicipioNome[0];
            n187MunicipioNome = P00DX2_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DX2_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DX2_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DX2_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DX2_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DX2_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DX2_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DX2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DX2_n193TipoClienteDescricao[0];
            A192TipoClienteId = P00DX2_A192TipoClienteId[0];
            n192TipoClienteId = P00DX2_n192TipoClienteId[0];
            A174ClienteStatus = P00DX2_A174ClienteStatus[0];
            n174ClienteStatus = P00DX2_n174ClienteStatus[0];
            A884ClienteSituacao = P00DX2_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DX2_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DX2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DX2_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00DX2_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DX2_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DX2_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DX2_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DX2_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DX2_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00DX2_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DX2_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00DX2_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DX2_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DX2_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DX2_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DX2_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DX2_n454ResponsavelDDD[0];
            A168ClienteId = P00DX2_A168ClienteId[0];
            A187MunicipioNome = P00DX2_A187MunicipioNome[0];
            n187MunicipioNome = P00DX2_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DX2_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DX2_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DX2_A404BancoCodigo[0];
            n404BancoCodigo = P00DX2_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DX2_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DX2_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DX2_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DX2_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DX2_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DX2_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DX2_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DX2_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DX2_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DX2_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DX2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DX2_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV18FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV18FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV18FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV66TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV67TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV67TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV67TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A436ResponsavelNome, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A447ResponsavelCPF, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A577ResponsavelCelular_F, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A456ResponsavelEmail, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = gxdomaindmcargo.getDescription(context,A885ResponsavelCargo);
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A169ClienteDocumento, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = gxdomaindmsituacao.getDescription(context,A884ClienteSituacao);
                        if ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                        }
                        else if ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
                        else if ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "true") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "ATIVO";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "false") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "INATIVO";
                        }
                        if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "true") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "false") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV58Session.Set("WWPExportFilePath", AV11Filename);
         AV58Session.Set("WWPExportFileName", "ClienteRepresentantesWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV58Session.Get("ClienteRepresentantesWWGridState"), "") == 0 )
         {
            AV60GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteRepresentantesWWGridState"), null, "", "");
         }
         else
         {
            AV60GridState.FromXml(AV58Session.Get("ClienteRepresentantesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV60GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV60GridState.gxTpr_Ordereddsc;
         AV88GXV3 = 1;
         while ( AV88GXV3 <= AV60GridState.gxTpr_Filtervalues.Count )
         {
            AV61GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV60GridState.gxTpr_Filtervalues.Item(AV88GXV3));
            if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TIPOCLIENTEID") == 0 )
            {
               AV84TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV61GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV62TFResponsavelNome = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV63TFResponsavelNome_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF") == 0 )
            {
               AV64TFResponsavelCPF = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF_SEL") == 0 )
            {
               AV65TFResponsavelCPF_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F") == 0 )
            {
               AV66TFResponsavelCelular_F = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F_SEL") == 0 )
            {
               AV67TFResponsavelCelular_F_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV68TFResponsavelEmail = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV69TFResponsavelEmail_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCARGO_SEL") == 0 )
            {
               AV70TFResponsavelCargo_SelsJson = AV61GridStateFilterValue.gxTpr_Value;
               AV72TFResponsavelCargo_Sels.FromJSonString(AV70TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV73TFClienteDocumento = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV74TFClienteDocumento_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV75TFClienteRazaoSocial = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV76TFClienteRazaoSocial_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV80TFClienteSituacao_SelsJson = AV61GridStateFilterValue.gxTpr_Value;
               AV82TFClienteSituacao_Sels.FromJSonString(AV80TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV79TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV61GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV88GXV3 = (int)(AV88GXV3+1);
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
         AV60GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV57GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV21ClienteDocumento1 = "";
         AV22TipoClienteDescricao1 = "";
         AV23ClienteConvenioDescricao1 = "";
         AV24ClienteNacionalidadeNome1 = "";
         AV25ClienteProfissaoNome1 = "";
         AV26MunicipioNome1 = "";
         AV28ResponsavelNacionalidadeNome1 = "";
         AV29ResponsavelProfissaoNome1 = "";
         AV30ResponsavelMunicipioNome1 = "";
         AV32DynamicFiltersSelector2 = "";
         AV34ClienteDocumento2 = "";
         AV35TipoClienteDescricao2 = "";
         AV36ClienteConvenioDescricao2 = "";
         AV37ClienteNacionalidadeNome2 = "";
         AV38ClienteProfissaoNome2 = "";
         AV39MunicipioNome2 = "";
         AV41ResponsavelNacionalidadeNome2 = "";
         AV42ResponsavelProfissaoNome2 = "";
         AV43ResponsavelMunicipioNome2 = "";
         AV45DynamicFiltersSelector3 = "";
         AV47ClienteDocumento3 = "";
         AV48TipoClienteDescricao3 = "";
         AV49ClienteConvenioDescricao3 = "";
         AV50ClienteNacionalidadeNome3 = "";
         AV51ClienteProfissaoNome3 = "";
         AV52MunicipioNome3 = "";
         AV54ResponsavelNacionalidadeNome3 = "";
         AV55ResponsavelProfissaoNome3 = "";
         AV56ResponsavelMunicipioNome3 = "";
         AV63TFResponsavelNome_Sel = "";
         AV62TFResponsavelNome = "";
         AV65TFResponsavelCPF_Sel = "";
         AV64TFResponsavelCPF = "";
         AV67TFResponsavelCelular_F_Sel = "";
         AV66TFResponsavelCelular_F = "";
         AV69TFResponsavelEmail_Sel = "";
         AV68TFResponsavelEmail = "";
         AV72TFResponsavelCargo_Sels = new GxSimpleCollection<string>();
         AV71TFResponsavelCargo_Sel = "";
         AV74TFClienteDocumento_Sel = "";
         AV73TFClienteDocumento = "";
         AV76TFClienteRazaoSocial_Sel = "";
         AV75TFClienteRazaoSocial = "";
         AV82TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV81TFClienteSituacao_Sel = "";
         lV18FilterFullText = "";
         lV21ClienteDocumento1 = "";
         lV22TipoClienteDescricao1 = "";
         lV23ClienteConvenioDescricao1 = "";
         lV24ClienteNacionalidadeNome1 = "";
         lV25ClienteProfissaoNome1 = "";
         lV26MunicipioNome1 = "";
         lV28ResponsavelNacionalidadeNome1 = "";
         lV29ResponsavelProfissaoNome1 = "";
         lV30ResponsavelMunicipioNome1 = "";
         lV34ClienteDocumento2 = "";
         lV35TipoClienteDescricao2 = "";
         lV36ClienteConvenioDescricao2 = "";
         lV37ClienteNacionalidadeNome2 = "";
         lV38ClienteProfissaoNome2 = "";
         lV39MunicipioNome2 = "";
         lV41ResponsavelNacionalidadeNome2 = "";
         lV42ResponsavelProfissaoNome2 = "";
         lV43ResponsavelMunicipioNome2 = "";
         lV47ClienteDocumento3 = "";
         lV48TipoClienteDescricao3 = "";
         lV49ClienteConvenioDescricao3 = "";
         lV50ClienteNacionalidadeNome3 = "";
         lV51ClienteProfissaoNome3 = "";
         lV52MunicipioNome3 = "";
         lV54ResponsavelNacionalidadeNome3 = "";
         lV55ResponsavelProfissaoNome3 = "";
         lV56ResponsavelMunicipioNome3 = "";
         lV62TFResponsavelNome = "";
         lV64TFResponsavelCPF = "";
         lV68TFResponsavelEmail = "";
         lV73TFClienteDocumento = "";
         lV75TFClienteRazaoSocial = "";
         A885ResponsavelCargo = "";
         A884ClienteSituacao = "";
         A169ClienteDocumento = "";
         A193TipoClienteDescricao = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A170ClienteRazaoSocial = "";
         A577ResponsavelCelular_F = "";
         P00DX2_A186MunicipioCodigo = new string[] {""} ;
         P00DX2_n186MunicipioCodigo = new bool[] {false} ;
         P00DX2_A444ResponsavelMunicipio = new string[] {""} ;
         P00DX2_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DX2_A402BancoId = new int[1] ;
         P00DX2_n402BancoId = new bool[] {false} ;
         P00DX2_A437ResponsavelNacionalidade = new int[1] ;
         P00DX2_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DX2_A484ClienteNacionalidade = new int[1] ;
         P00DX2_n484ClienteNacionalidade = new bool[] {false} ;
         P00DX2_A442ResponsavelProfissao = new int[1] ;
         P00DX2_n442ResponsavelProfissao = new bool[] {false} ;
         P00DX2_A487ClienteProfissao = new int[1] ;
         P00DX2_n487ClienteProfissao = new bool[] {false} ;
         P00DX2_A489ClienteConvenio = new int[1] ;
         P00DX2_n489ClienteConvenio = new bool[] {false} ;
         P00DX2_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DX2_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DX2_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DX2_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DX2_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DX2_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DX2_A404BancoCodigo = new int[1] ;
         P00DX2_n404BancoCodigo = new bool[] {false} ;
         P00DX2_A187MunicipioNome = new string[] {""} ;
         P00DX2_n187MunicipioNome = new bool[] {false} ;
         P00DX2_A488ClienteProfissaoNome = new string[] {""} ;
         P00DX2_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DX2_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DX2_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DX2_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DX2_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DX2_A193TipoClienteDescricao = new string[] {""} ;
         P00DX2_n193TipoClienteDescricao = new bool[] {false} ;
         P00DX2_A192TipoClienteId = new short[1] ;
         P00DX2_n192TipoClienteId = new bool[] {false} ;
         P00DX2_A174ClienteStatus = new bool[] {false} ;
         P00DX2_n174ClienteStatus = new bool[] {false} ;
         P00DX2_A884ClienteSituacao = new string[] {""} ;
         P00DX2_n884ClienteSituacao = new bool[] {false} ;
         P00DX2_A170ClienteRazaoSocial = new string[] {""} ;
         P00DX2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DX2_A169ClienteDocumento = new string[] {""} ;
         P00DX2_n169ClienteDocumento = new bool[] {false} ;
         P00DX2_A885ResponsavelCargo = new string[] {""} ;
         P00DX2_n885ResponsavelCargo = new bool[] {false} ;
         P00DX2_A456ResponsavelEmail = new string[] {""} ;
         P00DX2_n456ResponsavelEmail = new bool[] {false} ;
         P00DX2_A447ResponsavelCPF = new string[] {""} ;
         P00DX2_n447ResponsavelCPF = new bool[] {false} ;
         P00DX2_A436ResponsavelNome = new string[] {""} ;
         P00DX2_n436ResponsavelNome = new bool[] {false} ;
         P00DX2_A455ResponsavelNumero = new int[1] ;
         P00DX2_n455ResponsavelNumero = new bool[] {false} ;
         P00DX2_A454ResponsavelDDD = new short[1] ;
         P00DX2_n454ResponsavelDDD = new bool[] {false} ;
         P00DX2_A168ClienteId = new int[1] ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         GXt_char1 = "";
         AV58Session = context.GetSession();
         AV61GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV70TFResponsavelCargo_SelsJson = "";
         AV80TFClienteSituacao_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienterepresentanteswwexport__default(),
            new Object[][] {
                new Object[] {
               P00DX2_A186MunicipioCodigo, P00DX2_n186MunicipioCodigo, P00DX2_A444ResponsavelMunicipio, P00DX2_n444ResponsavelMunicipio, P00DX2_A402BancoId, P00DX2_n402BancoId, P00DX2_A437ResponsavelNacionalidade, P00DX2_n437ResponsavelNacionalidade, P00DX2_A484ClienteNacionalidade, P00DX2_n484ClienteNacionalidade,
               P00DX2_A442ResponsavelProfissao, P00DX2_n442ResponsavelProfissao, P00DX2_A487ClienteProfissao, P00DX2_n487ClienteProfissao, P00DX2_A489ClienteConvenio, P00DX2_n489ClienteConvenio, P00DX2_A445ResponsavelMunicipioNome, P00DX2_n445ResponsavelMunicipioNome, P00DX2_A443ResponsavelProfissaoNome, P00DX2_n443ResponsavelProfissaoNome,
               P00DX2_A438ResponsavelNacionalidadeNome, P00DX2_n438ResponsavelNacionalidadeNome, P00DX2_A404BancoCodigo, P00DX2_n404BancoCodigo, P00DX2_A187MunicipioNome, P00DX2_n187MunicipioNome, P00DX2_A488ClienteProfissaoNome, P00DX2_n488ClienteProfissaoNome, P00DX2_A485ClienteNacionalidadeNome, P00DX2_n485ClienteNacionalidadeNome,
               P00DX2_A490ClienteConvenioDescricao, P00DX2_n490ClienteConvenioDescricao, P00DX2_A193TipoClienteDescricao, P00DX2_n193TipoClienteDescricao, P00DX2_A192TipoClienteId, P00DX2_n192TipoClienteId, P00DX2_A174ClienteStatus, P00DX2_n174ClienteStatus, P00DX2_A884ClienteSituacao, P00DX2_n884ClienteSituacao,
               P00DX2_A170ClienteRazaoSocial, P00DX2_n170ClienteRazaoSocial, P00DX2_A169ClienteDocumento, P00DX2_n169ClienteDocumento, P00DX2_A885ResponsavelCargo, P00DX2_n885ResponsavelCargo, P00DX2_A456ResponsavelEmail, P00DX2_n456ResponsavelEmail, P00DX2_A447ResponsavelCPF, P00DX2_n447ResponsavelCPF,
               P00DX2_A436ResponsavelNome, P00DX2_n436ResponsavelNome, P00DX2_A455ResponsavelNumero, P00DX2_n455ResponsavelNumero, P00DX2_A454ResponsavelDDD, P00DX2_n454ResponsavelDDD, P00DX2_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV84TipoClienteId ;
      private short AV20DynamicFiltersOperator1 ;
      private short AV33DynamicFiltersOperator2 ;
      private short AV46DynamicFiltersOperator3 ;
      private short AV79TFClienteStatus_Sel ;
      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private short A192TipoClienteId ;
      private short A454ResponsavelDDD ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV27BancoCodigo1 ;
      private int AV40BancoCodigo2 ;
      private int AV53BancoCodigo3 ;
      private int AV85GXV1 ;
      private int AV86GXV2 ;
      private int AV72TFResponsavelCargo_Sels_Count ;
      private int AV82TFClienteSituacao_Sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A455ResponsavelNumero ;
      private int A168ClienteId ;
      private int AV88GXV3 ;
      private long AV83i ;
      private string AV81TFClienteSituacao_Sel ;
      private string A884ClienteSituacao ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV31DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool A174ClienteStatus ;
      private bool AV17OrderedDsc ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n193TipoClienteDescricao ;
      private bool n192TipoClienteId ;
      private bool n174ClienteStatus ;
      private bool n884ClienteSituacao ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n885ResponsavelCargo ;
      private bool n456ResponsavelEmail ;
      private bool n447ResponsavelCPF ;
      private bool n436ResponsavelNome ;
      private bool n455ResponsavelNumero ;
      private bool n454ResponsavelDDD ;
      private string AV70TFResponsavelCargo_SelsJson ;
      private string AV80TFClienteSituacao_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ClienteDocumento1 ;
      private string AV22TipoClienteDescricao1 ;
      private string AV23ClienteConvenioDescricao1 ;
      private string AV24ClienteNacionalidadeNome1 ;
      private string AV25ClienteProfissaoNome1 ;
      private string AV26MunicipioNome1 ;
      private string AV28ResponsavelNacionalidadeNome1 ;
      private string AV29ResponsavelProfissaoNome1 ;
      private string AV30ResponsavelMunicipioNome1 ;
      private string AV32DynamicFiltersSelector2 ;
      private string AV34ClienteDocumento2 ;
      private string AV35TipoClienteDescricao2 ;
      private string AV36ClienteConvenioDescricao2 ;
      private string AV37ClienteNacionalidadeNome2 ;
      private string AV38ClienteProfissaoNome2 ;
      private string AV39MunicipioNome2 ;
      private string AV41ResponsavelNacionalidadeNome2 ;
      private string AV42ResponsavelProfissaoNome2 ;
      private string AV43ResponsavelMunicipioNome2 ;
      private string AV45DynamicFiltersSelector3 ;
      private string AV47ClienteDocumento3 ;
      private string AV48TipoClienteDescricao3 ;
      private string AV49ClienteConvenioDescricao3 ;
      private string AV50ClienteNacionalidadeNome3 ;
      private string AV51ClienteProfissaoNome3 ;
      private string AV52MunicipioNome3 ;
      private string AV54ResponsavelNacionalidadeNome3 ;
      private string AV55ResponsavelProfissaoNome3 ;
      private string AV56ResponsavelMunicipioNome3 ;
      private string AV63TFResponsavelNome_Sel ;
      private string AV62TFResponsavelNome ;
      private string AV65TFResponsavelCPF_Sel ;
      private string AV64TFResponsavelCPF ;
      private string AV67TFResponsavelCelular_F_Sel ;
      private string AV66TFResponsavelCelular_F ;
      private string AV69TFResponsavelEmail_Sel ;
      private string AV68TFResponsavelEmail ;
      private string AV71TFResponsavelCargo_Sel ;
      private string AV74TFClienteDocumento_Sel ;
      private string AV73TFClienteDocumento ;
      private string AV76TFClienteRazaoSocial_Sel ;
      private string AV75TFClienteRazaoSocial ;
      private string lV18FilterFullText ;
      private string lV21ClienteDocumento1 ;
      private string lV22TipoClienteDescricao1 ;
      private string lV23ClienteConvenioDescricao1 ;
      private string lV24ClienteNacionalidadeNome1 ;
      private string lV25ClienteProfissaoNome1 ;
      private string lV26MunicipioNome1 ;
      private string lV28ResponsavelNacionalidadeNome1 ;
      private string lV29ResponsavelProfissaoNome1 ;
      private string lV30ResponsavelMunicipioNome1 ;
      private string lV34ClienteDocumento2 ;
      private string lV35TipoClienteDescricao2 ;
      private string lV36ClienteConvenioDescricao2 ;
      private string lV37ClienteNacionalidadeNome2 ;
      private string lV38ClienteProfissaoNome2 ;
      private string lV39MunicipioNome2 ;
      private string lV41ResponsavelNacionalidadeNome2 ;
      private string lV42ResponsavelProfissaoNome2 ;
      private string lV43ResponsavelMunicipioNome2 ;
      private string lV47ClienteDocumento3 ;
      private string lV48TipoClienteDescricao3 ;
      private string lV49ClienteConvenioDescricao3 ;
      private string lV50ClienteNacionalidadeNome3 ;
      private string lV51ClienteProfissaoNome3 ;
      private string lV52MunicipioNome3 ;
      private string lV54ResponsavelNacionalidadeNome3 ;
      private string lV55ResponsavelProfissaoNome3 ;
      private string lV56ResponsavelMunicipioNome3 ;
      private string lV62TFResponsavelNome ;
      private string lV64TFResponsavelCPF ;
      private string lV68TFResponsavelEmail ;
      private string lV73TFClienteDocumento ;
      private string lV75TFClienteRazaoSocial ;
      private string A885ResponsavelCargo ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A436ResponsavelNome ;
      private string A447ResponsavelCPF ;
      private string A456ResponsavelEmail ;
      private string A170ClienteRazaoSocial ;
      private string A577ResponsavelCelular_F ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private IGxSession AV58Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV60GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV57GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV72TFResponsavelCargo_Sels ;
      private GxSimpleCollection<string> AV82TFClienteSituacao_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DX2_A186MunicipioCodigo ;
      private bool[] P00DX2_n186MunicipioCodigo ;
      private string[] P00DX2_A444ResponsavelMunicipio ;
      private bool[] P00DX2_n444ResponsavelMunicipio ;
      private int[] P00DX2_A402BancoId ;
      private bool[] P00DX2_n402BancoId ;
      private int[] P00DX2_A437ResponsavelNacionalidade ;
      private bool[] P00DX2_n437ResponsavelNacionalidade ;
      private int[] P00DX2_A484ClienteNacionalidade ;
      private bool[] P00DX2_n484ClienteNacionalidade ;
      private int[] P00DX2_A442ResponsavelProfissao ;
      private bool[] P00DX2_n442ResponsavelProfissao ;
      private int[] P00DX2_A487ClienteProfissao ;
      private bool[] P00DX2_n487ClienteProfissao ;
      private int[] P00DX2_A489ClienteConvenio ;
      private bool[] P00DX2_n489ClienteConvenio ;
      private string[] P00DX2_A445ResponsavelMunicipioNome ;
      private bool[] P00DX2_n445ResponsavelMunicipioNome ;
      private string[] P00DX2_A443ResponsavelProfissaoNome ;
      private bool[] P00DX2_n443ResponsavelProfissaoNome ;
      private string[] P00DX2_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DX2_n438ResponsavelNacionalidadeNome ;
      private int[] P00DX2_A404BancoCodigo ;
      private bool[] P00DX2_n404BancoCodigo ;
      private string[] P00DX2_A187MunicipioNome ;
      private bool[] P00DX2_n187MunicipioNome ;
      private string[] P00DX2_A488ClienteProfissaoNome ;
      private bool[] P00DX2_n488ClienteProfissaoNome ;
      private string[] P00DX2_A485ClienteNacionalidadeNome ;
      private bool[] P00DX2_n485ClienteNacionalidadeNome ;
      private string[] P00DX2_A490ClienteConvenioDescricao ;
      private bool[] P00DX2_n490ClienteConvenioDescricao ;
      private string[] P00DX2_A193TipoClienteDescricao ;
      private bool[] P00DX2_n193TipoClienteDescricao ;
      private short[] P00DX2_A192TipoClienteId ;
      private bool[] P00DX2_n192TipoClienteId ;
      private bool[] P00DX2_A174ClienteStatus ;
      private bool[] P00DX2_n174ClienteStatus ;
      private string[] P00DX2_A884ClienteSituacao ;
      private bool[] P00DX2_n884ClienteSituacao ;
      private string[] P00DX2_A170ClienteRazaoSocial ;
      private bool[] P00DX2_n170ClienteRazaoSocial ;
      private string[] P00DX2_A169ClienteDocumento ;
      private bool[] P00DX2_n169ClienteDocumento ;
      private string[] P00DX2_A885ResponsavelCargo ;
      private bool[] P00DX2_n885ResponsavelCargo ;
      private string[] P00DX2_A456ResponsavelEmail ;
      private bool[] P00DX2_n456ResponsavelEmail ;
      private string[] P00DX2_A447ResponsavelCPF ;
      private bool[] P00DX2_n447ResponsavelCPF ;
      private string[] P00DX2_A436ResponsavelNome ;
      private bool[] P00DX2_n436ResponsavelNome ;
      private int[] P00DX2_A455ResponsavelNumero ;
      private bool[] P00DX2_n455ResponsavelNumero ;
      private short[] P00DX2_A454ResponsavelDDD ;
      private bool[] P00DX2_n454ResponsavelDDD ;
      private int[] P00DX2_A168ClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV61GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class clienterepresentanteswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DX2( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV72TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV82TFClienteSituacao_Sels ,
                                             string AV19DynamicFiltersSelector1 ,
                                             short AV20DynamicFiltersOperator1 ,
                                             string AV21ClienteDocumento1 ,
                                             string AV22TipoClienteDescricao1 ,
                                             string AV23ClienteConvenioDescricao1 ,
                                             string AV24ClienteNacionalidadeNome1 ,
                                             string AV25ClienteProfissaoNome1 ,
                                             string AV26MunicipioNome1 ,
                                             int AV27BancoCodigo1 ,
                                             string AV28ResponsavelNacionalidadeNome1 ,
                                             string AV29ResponsavelProfissaoNome1 ,
                                             string AV30ResponsavelMunicipioNome1 ,
                                             bool AV31DynamicFiltersEnabled2 ,
                                             string AV32DynamicFiltersSelector2 ,
                                             short AV33DynamicFiltersOperator2 ,
                                             string AV34ClienteDocumento2 ,
                                             string AV35TipoClienteDescricao2 ,
                                             string AV36ClienteConvenioDescricao2 ,
                                             string AV37ClienteNacionalidadeNome2 ,
                                             string AV38ClienteProfissaoNome2 ,
                                             string AV39MunicipioNome2 ,
                                             int AV40BancoCodigo2 ,
                                             string AV41ResponsavelNacionalidadeNome2 ,
                                             string AV42ResponsavelProfissaoNome2 ,
                                             string AV43ResponsavelMunicipioNome2 ,
                                             bool AV44DynamicFiltersEnabled3 ,
                                             string AV45DynamicFiltersSelector3 ,
                                             short AV46DynamicFiltersOperator3 ,
                                             string AV47ClienteDocumento3 ,
                                             string AV48TipoClienteDescricao3 ,
                                             string AV49ClienteConvenioDescricao3 ,
                                             string AV50ClienteNacionalidadeNome3 ,
                                             string AV51ClienteProfissaoNome3 ,
                                             string AV52MunicipioNome3 ,
                                             int AV53BancoCodigo3 ,
                                             string AV54ResponsavelNacionalidadeNome3 ,
                                             string AV55ResponsavelProfissaoNome3 ,
                                             string AV56ResponsavelMunicipioNome3 ,
                                             string AV63TFResponsavelNome_Sel ,
                                             string AV62TFResponsavelNome ,
                                             string AV65TFResponsavelCPF_Sel ,
                                             string AV64TFResponsavelCPF ,
                                             string AV69TFResponsavelEmail_Sel ,
                                             string AV68TFResponsavelEmail ,
                                             int AV72TFResponsavelCargo_Sels_Count ,
                                             string AV74TFClienteDocumento_Sel ,
                                             string AV73TFClienteDocumento ,
                                             string AV76TFClienteRazaoSocial_Sel ,
                                             string AV75TFClienteRazaoSocial ,
                                             int AV82TFClienteSituacao_Sels_Count ,
                                             short AV79TFClienteStatus_Sel ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV18FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV67TFResponsavelCelular_F_Sel ,
                                             string AV66TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[73];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV21ClienteDocumento1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV21ClienteDocumento1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV22TipoClienteDescricao1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV22TipoClienteDescricao1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV23ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV23ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV24ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV24ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV25ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV25ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV26MunicipioNome1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV26MunicipioNome1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! (0==AV27BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV27BancoCodigo1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! (0==AV27BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV27BancoCodigo1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV20DynamicFiltersOperator1 == 2 ) && ( ! (0==AV27BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV27BancoCodigo1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV28ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV28ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV29ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV29ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV30ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV20DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV30ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV34ClienteDocumento2)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV34ClienteDocumento2)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV35TipoClienteDescricao2)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV35TipoClienteDescricao2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV36ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV36ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV37ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV37ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV38ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV38ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV39MunicipioNome2)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV39MunicipioNome2)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! (0==AV40BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV40BancoCodigo2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! (0==AV40BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV40BancoCodigo2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV33DynamicFiltersOperator2 == 2 ) && ( ! (0==AV40BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV40BancoCodigo2)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV41ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV41ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV42ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV42ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV43ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( AV31DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV32DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV33DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV43ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV47ClienteDocumento3)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV47ClienteDocumento3)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV48TipoClienteDescricao3)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV48TipoClienteDescricao3)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV49ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV49ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV50ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV50ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV51ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV51ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV52MunicipioNome3)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV52MunicipioNome3)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! (0==AV53BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV53BancoCodigo3)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! (0==AV53BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV53BancoCodigo3)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV46DynamicFiltersOperator3 == 2 ) && ( ! (0==AV53BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV53BancoCodigo3)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV54ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV54ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV55ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV55ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV56ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( AV44DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV45DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV46DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV56ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV62TFResponsavelNome)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV63TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV63TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( StringUtil.StrCmp(AV63TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV64TFResponsavelCPF)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV65TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV65TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( StringUtil.StrCmp(AV65TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV68TFResponsavelEmail)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV69TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV69TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( StringUtil.StrCmp(AV69TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV72TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV72TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV73TFClienteDocumento)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV74TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV74TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( StringUtil.StrCmp(AV74TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV75TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV76TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV76TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( StringUtil.StrCmp(AV76TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV82TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV82TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV79TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV79TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCPF DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelEmail DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelCargo DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus DESC";
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
                     return conditional_P00DX2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (short)dynConstraints[70] , (bool)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (short)dynConstraints[76] );
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
          Object[] prmP00DX2;
          prmP00DX2 = new Object[] {
          new ParDef("lV21ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV21ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV22TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV22TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV23ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV23ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV24ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV24ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV25ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV25ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV26MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV26MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV27BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV27BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV27BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV28ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV28ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV29ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV29ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV30ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV30ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV34ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV34ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV35TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV35TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV36ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV36ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV37ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV37ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV38ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV38ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV39MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV39MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV40BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV40BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV40BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV41ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV41ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV42ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV42ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV43ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV43ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV47ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV47ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV48TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV48TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV49ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV49ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV50ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV50ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV51ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV51ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV52MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV52MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV53BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV53BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV53BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV54ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV54ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV55ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV55ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV56ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV56ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV62TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV63TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV64TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV65TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV68TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV69TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV73TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV74TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV75TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV76TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DX2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((short[]) buf[34])[0] = rslt.getShort(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((bool[]) buf[36])[0] = rslt.getBool(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getString(20, 1);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
       }
    }

 }

}
