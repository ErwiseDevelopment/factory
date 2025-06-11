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
   public class clientewwexport : GXProcedure
   {
      public clientewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientewwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV13Filename = "" ;
         this.AV14ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV13Filename;
         aP1_ErrorMessage=this.AV14ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV14ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV13Filename = "" ;
         this.AV14ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV13Filename;
         aP1_ErrorMessage=this.AV14ErrorMessage;
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
         AV15CellRow = 1;
         AV16FirstColumn = 1;
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
         AV17Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV13Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV13Filename = GXt_char1 + "ClienteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17Random), 8, 0)) + ".xlsx";
         AV12ExcelDocument.Open(AV13Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV12ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Filtro principal") ;
            AV15CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20FilterFullText, out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV21DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV23ClienteDocumento1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteDocumento1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ClienteDocumento1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV52TipoClienteDescricao1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipoClienteDescricao1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TipoClienteDescricao1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV69ClienteConvenioDescricao1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV69ClienteConvenioDescricao1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV70ClienteNacionalidadeNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV70ClienteNacionalidadeNome1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV71ClienteProfissaoNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71ClienteProfissaoNome1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV60MunicipioNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60MunicipioNome1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60MunicipioNome1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV72BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV72BancoCodigo1) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 2 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Number = AV72BancoCodigo1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV73ResponsavelNacionalidadeNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73ResponsavelNacionalidadeNome1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73ResponsavelNacionalidadeNome1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV74ResponsavelProfissaoNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelProfissaoNome1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74ResponsavelProfissaoNome1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV75ResponsavelMunicipioNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelMunicipioNome1)) )
               {
                  AV15CellRow = (int)(AV15CellRow+1);
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                  if ( AV22DynamicFiltersOperator1 == 0 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV22DynamicFiltersOperator1 == 1 )
                  {
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75ResponsavelMunicipioNome1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV27ClienteDocumento2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ClienteDocumento2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27ClienteDocumento2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV54TipoClienteDescricao2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TipoClienteDescricao2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TipoClienteDescricao2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV76ClienteConvenioDescricao2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ClienteConvenioDescricao2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76ClienteConvenioDescricao2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV77ClienteNacionalidadeNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77ClienteNacionalidadeNome2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77ClienteNacionalidadeNome2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV78ClienteProfissaoNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78ClienteProfissaoNome2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78ClienteProfissaoNome2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV61MunicipioNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61MunicipioNome2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61MunicipioNome2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV79BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV79BancoCodigo2) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Number = AV79BancoCodigo2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV80ResponsavelNacionalidadeNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ResponsavelNacionalidadeNome2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80ResponsavelNacionalidadeNome2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV81ResponsavelProfissaoNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81ResponsavelProfissaoNome2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV81ResponsavelProfissaoNome2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV82ResponsavelMunicipioNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ResponsavelMunicipioNome2)) )
                  {
                     AV15CellRow = (int)(AV15CellRow+1);
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82ResponsavelMunicipioNome2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31ClienteDocumento3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31ClienteDocumento3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV56TipoClienteDescricao3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TipoClienteDescricao3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TipoClienteDescricao3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV83ClienteConvenioDescricao3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteConvenioDescricao3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Convenio Descricao", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV83ClienteConvenioDescricao3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV84ClienteNacionalidadeNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteNacionalidadeNome3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84ClienteNacionalidadeNome3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV85ClienteProfissaoNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85ClienteProfissaoNome3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV85ClienteProfissaoNome3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV62MunicipioNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62MunicipioNome3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62MunicipioNome3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV86BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV86BancoCodigo3) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 2 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Banco Codigo", ">", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Number = AV86BancoCodigo3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV87ResponsavelNacionalidadeNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nacionalidade Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV87ResponsavelNacionalidadeNome3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV88ResponsavelProfissaoNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Profissao Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV88ResponsavelProfissaoNome3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV89ResponsavelMunicipioNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) )
                     {
                        AV15CellRow = (int)(AV15CellRow+1);
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Bold = 1;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV89ResponsavelMunicipioNome3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTipoClienteDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Tipo cliente") ;
            AV15CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTipoClienteDescricao_Sel)) ? "(Vazio)" : AV59TFTipoClienteDescricao_Sel), out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTipoClienteDescricao)) ) )
            {
               GXt_int2 = (short)(AV15CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Tipo cliente") ;
               AV15CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFTipoClienteDescricao, out  GXt_char1) ;
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Razão social / nome") ;
            AV15CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV38TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV15CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Razão social / nome") ;
               AV15CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFClienteRazaoSocial, out  GXt_char1) ;
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Documento") ;
            AV15CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteDocumento_Sel)) ? "(Vazio)" : AV42TFClienteDocumento_Sel), out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteDocumento)) ) )
            {
               GXt_int2 = (short)(AV15CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Documento") ;
               AV15CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFClienteDocumento, out  GXt_char1) ;
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV45TFClienteTipoPessoa_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Tipo pessoa") ;
            AV15CellRow = GXt_int2;
            AV51i = 1;
            AV90GXV1 = 1;
            while ( AV90GXV1 <= AV45TFClienteTipoPessoa_Sels.Count )
            {
               AV44TFClienteTipoPessoa_Sel = ((string)AV45TFClienteTipoPessoa_Sels.Item(AV90GXV1));
               if ( AV51i == 1 )
               {
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text+", ";
               }
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text+gxdomaindmtipopessoa.getDescription(context,AV44TFClienteTipoPessoa_Sel);
               AV51i = (long)(AV51i+1);
               AV90GXV1 = (int)(AV90GXV1+1);
            }
         }
         if ( ! ( (0==AV46TFClienteStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Status") ;
            AV15CellRow = GXt_int2;
            if ( AV46TFClienteStatus_Sel == 1 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV46TFClienteStatus_Sel == 2 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         AV15CellRow = (int)(AV15CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Tipo cliente";
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "Razão social / nome";
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Text = "Documento";
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+3, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+3, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+3, 1, 1).Text = "Tipo pessoa";
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV92Clientewwds_1_filterfulltext = AV20FilterFullText;
         AV93Clientewwds_2_dynamicfiltersselector1 = AV21DynamicFiltersSelector1;
         AV94Clientewwds_3_dynamicfiltersoperator1 = AV22DynamicFiltersOperator1;
         AV95Clientewwds_4_clientedocumento1 = AV23ClienteDocumento1;
         AV96Clientewwds_5_tipoclientedescricao1 = AV52TipoClienteDescricao1;
         AV97Clientewwds_6_clienteconveniodescricao1 = AV69ClienteConvenioDescricao1;
         AV98Clientewwds_7_clientenacionalidadenome1 = AV70ClienteNacionalidadeNome1;
         AV99Clientewwds_8_clienteprofissaonome1 = AV71ClienteProfissaoNome1;
         AV100Clientewwds_9_municipionome1 = AV60MunicipioNome1;
         AV101Clientewwds_10_bancocodigo1 = AV72BancoCodigo1;
         AV102Clientewwds_11_responsavelnacionalidadenome1 = AV73ResponsavelNacionalidadeNome1;
         AV103Clientewwds_12_responsavelprofissaonome1 = AV74ResponsavelProfissaoNome1;
         AV104Clientewwds_13_responsavelmunicipionome1 = AV75ResponsavelMunicipioNome1;
         AV105Clientewwds_14_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV106Clientewwds_15_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV107Clientewwds_16_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV108Clientewwds_17_clientedocumento2 = AV27ClienteDocumento2;
         AV109Clientewwds_18_tipoclientedescricao2 = AV54TipoClienteDescricao2;
         AV110Clientewwds_19_clienteconveniodescricao2 = AV76ClienteConvenioDescricao2;
         AV111Clientewwds_20_clientenacionalidadenome2 = AV77ClienteNacionalidadeNome2;
         AV112Clientewwds_21_clienteprofissaonome2 = AV78ClienteProfissaoNome2;
         AV113Clientewwds_22_municipionome2 = AV61MunicipioNome2;
         AV114Clientewwds_23_bancocodigo2 = AV79BancoCodigo2;
         AV115Clientewwds_24_responsavelnacionalidadenome2 = AV80ResponsavelNacionalidadeNome2;
         AV116Clientewwds_25_responsavelprofissaonome2 = AV81ResponsavelProfissaoNome2;
         AV117Clientewwds_26_responsavelmunicipionome2 = AV82ResponsavelMunicipioNome2;
         AV118Clientewwds_27_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV119Clientewwds_28_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV120Clientewwds_29_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV121Clientewwds_30_clientedocumento3 = AV31ClienteDocumento3;
         AV122Clientewwds_31_tipoclientedescricao3 = AV56TipoClienteDescricao3;
         AV123Clientewwds_32_clienteconveniodescricao3 = AV83ClienteConvenioDescricao3;
         AV124Clientewwds_33_clientenacionalidadenome3 = AV84ClienteNacionalidadeNome3;
         AV125Clientewwds_34_clienteprofissaonome3 = AV85ClienteProfissaoNome3;
         AV126Clientewwds_35_municipionome3 = AV62MunicipioNome3;
         AV127Clientewwds_36_bancocodigo3 = AV86BancoCodigo3;
         AV128Clientewwds_37_responsavelnacionalidadenome3 = AV87ResponsavelNacionalidadeNome3;
         AV129Clientewwds_38_responsavelprofissaonome3 = AV88ResponsavelProfissaoNome3;
         AV130Clientewwds_39_responsavelmunicipionome3 = AV89ResponsavelMunicipioNome3;
         AV131Clientewwds_40_tftipoclientedescricao = AV58TFTipoClienteDescricao;
         AV132Clientewwds_41_tftipoclientedescricao_sel = AV59TFTipoClienteDescricao_Sel;
         AV133Clientewwds_42_tfclienterazaosocial = AV37TFClienteRazaoSocial;
         AV134Clientewwds_43_tfclienterazaosocial_sel = AV38TFClienteRazaoSocial_Sel;
         AV135Clientewwds_44_tfclientedocumento = AV41TFClienteDocumento;
         AV136Clientewwds_45_tfclientedocumento_sel = AV42TFClienteDocumento_Sel;
         AV137Clientewwds_46_tfclientetipopessoa_sels = AV45TFClienteTipoPessoa_Sels;
         AV138Clientewwds_47_tfclientestatus_sel = AV46TFClienteStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV137Clientewwds_46_tfclientetipopessoa_sels ,
                                              AV92Clientewwds_1_filterfulltext ,
                                              AV93Clientewwds_2_dynamicfiltersselector1 ,
                                              AV94Clientewwds_3_dynamicfiltersoperator1 ,
                                              AV95Clientewwds_4_clientedocumento1 ,
                                              AV96Clientewwds_5_tipoclientedescricao1 ,
                                              AV97Clientewwds_6_clienteconveniodescricao1 ,
                                              AV98Clientewwds_7_clientenacionalidadenome1 ,
                                              AV99Clientewwds_8_clienteprofissaonome1 ,
                                              AV100Clientewwds_9_municipionome1 ,
                                              AV101Clientewwds_10_bancocodigo1 ,
                                              AV102Clientewwds_11_responsavelnacionalidadenome1 ,
                                              AV103Clientewwds_12_responsavelprofissaonome1 ,
                                              AV104Clientewwds_13_responsavelmunicipionome1 ,
                                              AV105Clientewwds_14_dynamicfiltersenabled2 ,
                                              AV106Clientewwds_15_dynamicfiltersselector2 ,
                                              AV107Clientewwds_16_dynamicfiltersoperator2 ,
                                              AV108Clientewwds_17_clientedocumento2 ,
                                              AV109Clientewwds_18_tipoclientedescricao2 ,
                                              AV110Clientewwds_19_clienteconveniodescricao2 ,
                                              AV111Clientewwds_20_clientenacionalidadenome2 ,
                                              AV112Clientewwds_21_clienteprofissaonome2 ,
                                              AV113Clientewwds_22_municipionome2 ,
                                              AV114Clientewwds_23_bancocodigo2 ,
                                              AV115Clientewwds_24_responsavelnacionalidadenome2 ,
                                              AV116Clientewwds_25_responsavelprofissaonome2 ,
                                              AV117Clientewwds_26_responsavelmunicipionome2 ,
                                              AV118Clientewwds_27_dynamicfiltersenabled3 ,
                                              AV119Clientewwds_28_dynamicfiltersselector3 ,
                                              AV120Clientewwds_29_dynamicfiltersoperator3 ,
                                              AV121Clientewwds_30_clientedocumento3 ,
                                              AV122Clientewwds_31_tipoclientedescricao3 ,
                                              AV123Clientewwds_32_clienteconveniodescricao3 ,
                                              AV124Clientewwds_33_clientenacionalidadenome3 ,
                                              AV125Clientewwds_34_clienteprofissaonome3 ,
                                              AV126Clientewwds_35_municipionome3 ,
                                              AV127Clientewwds_36_bancocodigo3 ,
                                              AV128Clientewwds_37_responsavelnacionalidadenome3 ,
                                              AV129Clientewwds_38_responsavelprofissaonome3 ,
                                              AV130Clientewwds_39_responsavelmunicipionome3 ,
                                              AV132Clientewwds_41_tftipoclientedescricao_sel ,
                                              AV131Clientewwds_40_tftipoclientedescricao ,
                                              AV134Clientewwds_43_tfclienterazaosocial_sel ,
                                              AV133Clientewwds_42_tfclienterazaosocial ,
                                              AV136Clientewwds_45_tfclientedocumento_sel ,
                                              AV135Clientewwds_44_tfclientedocumento ,
                                              AV137Clientewwds_46_tfclientetipopessoa_sels.Count ,
                                              AV138Clientewwds_47_tfclientestatus_sel ,
                                              A193TipoClienteDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A174ClienteStatus ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              AV18OrderedBy ,
                                              AV19OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV92Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV92Clientewwds_1_filterfulltext), "%", "");
         lV95Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV95Clientewwds_4_clientedocumento1), "%", "");
         lV95Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV95Clientewwds_4_clientedocumento1), "%", "");
         lV96Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV96Clientewwds_5_tipoclientedescricao1), "%", "");
         lV96Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV96Clientewwds_5_tipoclientedescricao1), "%", "");
         lV97Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV97Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV97Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV97Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV98Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV98Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV98Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV98Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV99Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_8_clienteprofissaonome1), "%", "");
         lV99Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_8_clienteprofissaonome1), "%", "");
         lV100Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV100Clientewwds_9_municipionome1), "%", "");
         lV100Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV100Clientewwds_9_municipionome1), "%", "");
         lV102Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV102Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV103Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV103Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV104Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV104Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV108Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV108Clientewwds_17_clientedocumento2), "%", "");
         lV108Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV108Clientewwds_17_clientedocumento2), "%", "");
         lV109Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_18_tipoclientedescricao2), "%", "");
         lV109Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_18_tipoclientedescricao2), "%", "");
         lV110Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV110Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV111Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV111Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV112Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV112Clientewwds_21_clienteprofissaonome2), "%", "");
         lV112Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV112Clientewwds_21_clienteprofissaonome2), "%", "");
         lV113Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV113Clientewwds_22_municipionome2), "%", "");
         lV113Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV113Clientewwds_22_municipionome2), "%", "");
         lV115Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV115Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV116Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV116Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV117Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV117Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV121Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Clientewwds_30_clientedocumento3), "%", "");
         lV121Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV121Clientewwds_30_clientedocumento3), "%", "");
         lV122Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_31_tipoclientedescricao3), "%", "");
         lV122Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_31_tipoclientedescricao3), "%", "");
         lV123Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV123Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV124Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV124Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV125Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV125Clientewwds_34_clienteprofissaonome3), "%", "");
         lV125Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV125Clientewwds_34_clienteprofissaonome3), "%", "");
         lV126Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV126Clientewwds_35_municipionome3), "%", "");
         lV126Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV126Clientewwds_35_municipionome3), "%", "");
         lV128Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV128Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV129Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV129Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV130Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV130Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV131Clientewwds_40_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_40_tftipoclientedescricao), "%", "");
         lV133Clientewwds_42_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_42_tfclienterazaosocial), "%", "");
         lV135Clientewwds_44_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_44_tfclientedocumento), "%", "");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV92Clientewwds_1_filterfulltext, lV92Clientewwds_1_filterfulltext, lV92Clientewwds_1_filterfulltext, lV92Clientewwds_1_filterfulltext, lV92Clientewwds_1_filterfulltext, lV92Clientewwds_1_filterfulltext, lV92Clientewwds_1_filterfulltext, lV95Clientewwds_4_clientedocumento1, lV95Clientewwds_4_clientedocumento1, lV96Clientewwds_5_tipoclientedescricao1, lV96Clientewwds_5_tipoclientedescricao1, lV97Clientewwds_6_clienteconveniodescricao1, lV97Clientewwds_6_clienteconveniodescricao1, lV98Clientewwds_7_clientenacionalidadenome1, lV98Clientewwds_7_clientenacionalidadenome1, lV99Clientewwds_8_clienteprofissaonome1, lV99Clientewwds_8_clienteprofissaonome1, lV100Clientewwds_9_municipionome1, lV100Clientewwds_9_municipionome1, AV101Clientewwds_10_bancocodigo1, AV101Clientewwds_10_bancocodigo1, AV101Clientewwds_10_bancocodigo1, lV102Clientewwds_11_responsavelnacionalidadenome1, lV102Clientewwds_11_responsavelnacionalidadenome1, lV103Clientewwds_12_responsavelprofissaonome1, lV103Clientewwds_12_responsavelprofissaonome1, lV104Clientewwds_13_responsavelmunicipionome1, lV104Clientewwds_13_responsavelmunicipionome1, lV108Clientewwds_17_clientedocumento2, lV108Clientewwds_17_clientedocumento2, lV109Clientewwds_18_tipoclientedescricao2, lV109Clientewwds_18_tipoclientedescricao2, lV110Clientewwds_19_clienteconveniodescricao2, lV110Clientewwds_19_clienteconveniodescricao2, lV111Clientewwds_20_clientenacionalidadenome2, lV111Clientewwds_20_clientenacionalidadenome2, lV112Clientewwds_21_clienteprofissaonome2, lV112Clientewwds_21_clienteprofissaonome2, lV113Clientewwds_22_municipionome2, lV113Clientewwds_22_municipionome2, AV114Clientewwds_23_bancocodigo2, AV114Clientewwds_23_bancocodigo2, AV114Clientewwds_23_bancocodigo2, lV115Clientewwds_24_responsavelnacionalidadenome2, lV115Clientewwds_24_responsavelnacionalidadenome2, lV116Clientewwds_25_responsavelprofissaonome2, lV116Clientewwds_25_responsavelprofissaonome2, lV117Clientewwds_26_responsavelmunicipionome2, lV117Clientewwds_26_responsavelmunicipionome2, lV121Clientewwds_30_clientedocumento3, lV121Clientewwds_30_clientedocumento3, lV122Clientewwds_31_tipoclientedescricao3, lV122Clientewwds_31_tipoclientedescricao3, lV123Clientewwds_32_clienteconveniodescricao3, lV123Clientewwds_32_clienteconveniodescricao3, lV124Clientewwds_33_clientenacionalidadenome3, lV124Clientewwds_33_clientenacionalidadenome3, lV125Clientewwds_34_clienteprofissaonome3, lV125Clientewwds_34_clienteprofissaonome3, lV126Clientewwds_35_municipionome3, lV126Clientewwds_35_municipionome3, AV127Clientewwds_36_bancocodigo3, AV127Clientewwds_36_bancocodigo3, AV127Clientewwds_36_bancocodigo3, lV128Clientewwds_37_responsavelnacionalidadenome3, lV128Clientewwds_37_responsavelnacionalidadenome3, lV129Clientewwds_38_responsavelprofissaonome3, lV129Clientewwds_38_responsavelprofissaonome3, lV130Clientewwds_39_responsavelmunicipionome3, lV130Clientewwds_39_responsavelmunicipionome3, lV131Clientewwds_40_tftipoclientedescricao, AV132Clientewwds_41_tftipoclientedescricao_sel, lV133Clientewwds_42_tfclienterazaosocial, AV134Clientewwds_43_tfclienterazaosocial_sel, lV135Clientewwds_44_tfclientedocumento, AV136Clientewwds_45_tfclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A192TipoClienteId = P00692_A192TipoClienteId[0];
            n192TipoClienteId = P00692_n192TipoClienteId[0];
            A186MunicipioCodigo = P00692_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00692_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00692_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00692_n444ResponsavelMunicipio[0];
            A402BancoId = P00692_A402BancoId[0];
            n402BancoId = P00692_n402BancoId[0];
            A437ResponsavelNacionalidade = P00692_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00692_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00692_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00692_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00692_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00692_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00692_A487ClienteProfissao[0];
            n487ClienteProfissao = P00692_n487ClienteProfissao[0];
            A489ClienteConvenio = P00692_A489ClienteConvenio[0];
            n489ClienteConvenio = P00692_n489ClienteConvenio[0];
            A170ClienteRazaoSocial = P00692_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00692_n170ClienteRazaoSocial[0];
            A445ResponsavelMunicipioNome = P00692_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00692_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00692_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00692_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00692_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00692_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00692_A404BancoCodigo[0];
            n404BancoCodigo = P00692_n404BancoCodigo[0];
            A187MunicipioNome = P00692_A187MunicipioNome[0];
            n187MunicipioNome = P00692_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00692_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00692_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00692_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00692_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00692_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00692_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00692_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00692_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00692_A169ClienteDocumento[0];
            n169ClienteDocumento = P00692_n169ClienteDocumento[0];
            A174ClienteStatus = P00692_A174ClienteStatus[0];
            n174ClienteStatus = P00692_n174ClienteStatus[0];
            A172ClienteTipoPessoa = P00692_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P00692_n172ClienteTipoPessoa[0];
            A168ClienteId = P00692_A168ClienteId[0];
            A193TipoClienteDescricao = P00692_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00692_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00692_A187MunicipioNome[0];
            n187MunicipioNome = P00692_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00692_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00692_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00692_A404BancoCodigo[0];
            n404BancoCodigo = P00692_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00692_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00692_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00692_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00692_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00692_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00692_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00692_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00692_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00692_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00692_n490ClienteConvenioDescricao[0];
            AV15CellRow = (int)(AV15CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A193TipoClienteDescricao, out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A169ClienteDocumento, out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Text = GXt_char1;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+3, 1, 1).Text = gxdomaindmtipopessoa.getDescription(context,A172ClienteTipoPessoa);
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "true") == 0 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Text = "ATIVO";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "false") == 0 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Text = "INATIVO";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "true") == 0 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A174ClienteStatus)), "false") == 0 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+4, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV12ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV12ExcelDocument.Close();
         AV33Session.Set("WWPExportFilePath", AV13Filename);
         AV33Session.Set("WWPExportFileName", "ClienteWWExport.xlsx");
         AV13Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV12ExcelDocument.ErrCode != 0 )
         {
            AV13Filename = "";
            AV14ErrorMessage = AV12ExcelDocument.ErrDescription;
            AV12ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("ClienteWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("ClienteWWGridState"), null, "", "");
         }
         AV18OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV19OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV139GXV2 = 1;
         while ( AV139GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV139GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV58TFTipoClienteDescricao = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV59TFTipoClienteDescricao_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV37TFClienteRazaoSocial = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV38TFClienteRazaoSocial_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV41TFClienteDocumento = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV42TFClienteDocumento_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV43TFClienteTipoPessoa_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV45TFClienteTipoPessoa_Sels.FromJSonString(AV43TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV46TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV139GXV2 = (int)(AV139GXV2+1);
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
         AV13Filename = "";
         AV14ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12ExcelDocument = new ExcelDocumentI();
         AV20FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV21DynamicFiltersSelector1 = "";
         AV23ClienteDocumento1 = "";
         AV52TipoClienteDescricao1 = "";
         AV69ClienteConvenioDescricao1 = "";
         AV70ClienteNacionalidadeNome1 = "";
         AV71ClienteProfissaoNome1 = "";
         AV60MunicipioNome1 = "";
         AV73ResponsavelNacionalidadeNome1 = "";
         AV74ResponsavelProfissaoNome1 = "";
         AV75ResponsavelMunicipioNome1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27ClienteDocumento2 = "";
         AV54TipoClienteDescricao2 = "";
         AV76ClienteConvenioDescricao2 = "";
         AV77ClienteNacionalidadeNome2 = "";
         AV78ClienteProfissaoNome2 = "";
         AV61MunicipioNome2 = "";
         AV80ResponsavelNacionalidadeNome2 = "";
         AV81ResponsavelProfissaoNome2 = "";
         AV82ResponsavelMunicipioNome2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31ClienteDocumento3 = "";
         AV56TipoClienteDescricao3 = "";
         AV83ClienteConvenioDescricao3 = "";
         AV84ClienteNacionalidadeNome3 = "";
         AV85ClienteProfissaoNome3 = "";
         AV62MunicipioNome3 = "";
         AV87ResponsavelNacionalidadeNome3 = "";
         AV88ResponsavelProfissaoNome3 = "";
         AV89ResponsavelMunicipioNome3 = "";
         AV59TFTipoClienteDescricao_Sel = "";
         AV58TFTipoClienteDescricao = "";
         AV38TFClienteRazaoSocial_Sel = "";
         AV37TFClienteRazaoSocial = "";
         AV42TFClienteDocumento_Sel = "";
         AV41TFClienteDocumento = "";
         AV45TFClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV44TFClienteTipoPessoa_Sel = "";
         AV92Clientewwds_1_filterfulltext = "";
         AV93Clientewwds_2_dynamicfiltersselector1 = "";
         AV95Clientewwds_4_clientedocumento1 = "";
         AV96Clientewwds_5_tipoclientedescricao1 = "";
         AV97Clientewwds_6_clienteconveniodescricao1 = "";
         AV98Clientewwds_7_clientenacionalidadenome1 = "";
         AV99Clientewwds_8_clienteprofissaonome1 = "";
         AV100Clientewwds_9_municipionome1 = "";
         AV102Clientewwds_11_responsavelnacionalidadenome1 = "";
         AV103Clientewwds_12_responsavelprofissaonome1 = "";
         AV104Clientewwds_13_responsavelmunicipionome1 = "";
         AV106Clientewwds_15_dynamicfiltersselector2 = "";
         AV108Clientewwds_17_clientedocumento2 = "";
         AV109Clientewwds_18_tipoclientedescricao2 = "";
         AV110Clientewwds_19_clienteconveniodescricao2 = "";
         AV111Clientewwds_20_clientenacionalidadenome2 = "";
         AV112Clientewwds_21_clienteprofissaonome2 = "";
         AV113Clientewwds_22_municipionome2 = "";
         AV115Clientewwds_24_responsavelnacionalidadenome2 = "";
         AV116Clientewwds_25_responsavelprofissaonome2 = "";
         AV117Clientewwds_26_responsavelmunicipionome2 = "";
         AV119Clientewwds_28_dynamicfiltersselector3 = "";
         AV121Clientewwds_30_clientedocumento3 = "";
         AV122Clientewwds_31_tipoclientedescricao3 = "";
         AV123Clientewwds_32_clienteconveniodescricao3 = "";
         AV124Clientewwds_33_clientenacionalidadenome3 = "";
         AV125Clientewwds_34_clienteprofissaonome3 = "";
         AV126Clientewwds_35_municipionome3 = "";
         AV128Clientewwds_37_responsavelnacionalidadenome3 = "";
         AV129Clientewwds_38_responsavelprofissaonome3 = "";
         AV130Clientewwds_39_responsavelmunicipionome3 = "";
         AV131Clientewwds_40_tftipoclientedescricao = "";
         AV132Clientewwds_41_tftipoclientedescricao_sel = "";
         AV133Clientewwds_42_tfclienterazaosocial = "";
         AV134Clientewwds_43_tfclienterazaosocial_sel = "";
         AV135Clientewwds_44_tfclientedocumento = "";
         AV136Clientewwds_45_tfclientedocumento_sel = "";
         AV137Clientewwds_46_tfclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV92Clientewwds_1_filterfulltext = "";
         lV95Clientewwds_4_clientedocumento1 = "";
         lV96Clientewwds_5_tipoclientedescricao1 = "";
         lV97Clientewwds_6_clienteconveniodescricao1 = "";
         lV98Clientewwds_7_clientenacionalidadenome1 = "";
         lV99Clientewwds_8_clienteprofissaonome1 = "";
         lV100Clientewwds_9_municipionome1 = "";
         lV102Clientewwds_11_responsavelnacionalidadenome1 = "";
         lV103Clientewwds_12_responsavelprofissaonome1 = "";
         lV104Clientewwds_13_responsavelmunicipionome1 = "";
         lV108Clientewwds_17_clientedocumento2 = "";
         lV109Clientewwds_18_tipoclientedescricao2 = "";
         lV110Clientewwds_19_clienteconveniodescricao2 = "";
         lV111Clientewwds_20_clientenacionalidadenome2 = "";
         lV112Clientewwds_21_clienteprofissaonome2 = "";
         lV113Clientewwds_22_municipionome2 = "";
         lV115Clientewwds_24_responsavelnacionalidadenome2 = "";
         lV116Clientewwds_25_responsavelprofissaonome2 = "";
         lV117Clientewwds_26_responsavelmunicipionome2 = "";
         lV121Clientewwds_30_clientedocumento3 = "";
         lV122Clientewwds_31_tipoclientedescricao3 = "";
         lV123Clientewwds_32_clienteconveniodescricao3 = "";
         lV124Clientewwds_33_clientenacionalidadenome3 = "";
         lV125Clientewwds_34_clienteprofissaonome3 = "";
         lV126Clientewwds_35_municipionome3 = "";
         lV128Clientewwds_37_responsavelnacionalidadenome3 = "";
         lV129Clientewwds_38_responsavelprofissaonome3 = "";
         lV130Clientewwds_39_responsavelmunicipionome3 = "";
         lV131Clientewwds_40_tftipoclientedescricao = "";
         lV133Clientewwds_42_tfclienterazaosocial = "";
         lV135Clientewwds_44_tfclientedocumento = "";
         A172ClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         P00692_A192TipoClienteId = new short[1] ;
         P00692_n192TipoClienteId = new bool[] {false} ;
         P00692_A186MunicipioCodigo = new string[] {""} ;
         P00692_n186MunicipioCodigo = new bool[] {false} ;
         P00692_A444ResponsavelMunicipio = new string[] {""} ;
         P00692_n444ResponsavelMunicipio = new bool[] {false} ;
         P00692_A402BancoId = new int[1] ;
         P00692_n402BancoId = new bool[] {false} ;
         P00692_A437ResponsavelNacionalidade = new int[1] ;
         P00692_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00692_A484ClienteNacionalidade = new int[1] ;
         P00692_n484ClienteNacionalidade = new bool[] {false} ;
         P00692_A442ResponsavelProfissao = new int[1] ;
         P00692_n442ResponsavelProfissao = new bool[] {false} ;
         P00692_A487ClienteProfissao = new int[1] ;
         P00692_n487ClienteProfissao = new bool[] {false} ;
         P00692_A489ClienteConvenio = new int[1] ;
         P00692_n489ClienteConvenio = new bool[] {false} ;
         P00692_A170ClienteRazaoSocial = new string[] {""} ;
         P00692_n170ClienteRazaoSocial = new bool[] {false} ;
         P00692_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00692_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00692_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00692_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00692_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00692_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00692_A404BancoCodigo = new int[1] ;
         P00692_n404BancoCodigo = new bool[] {false} ;
         P00692_A187MunicipioNome = new string[] {""} ;
         P00692_n187MunicipioNome = new bool[] {false} ;
         P00692_A488ClienteProfissaoNome = new string[] {""} ;
         P00692_n488ClienteProfissaoNome = new bool[] {false} ;
         P00692_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00692_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00692_A490ClienteConvenioDescricao = new string[] {""} ;
         P00692_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00692_A193TipoClienteDescricao = new string[] {""} ;
         P00692_n193TipoClienteDescricao = new bool[] {false} ;
         P00692_A169ClienteDocumento = new string[] {""} ;
         P00692_n169ClienteDocumento = new bool[] {false} ;
         P00692_A174ClienteStatus = new bool[] {false} ;
         P00692_n174ClienteStatus = new bool[] {false} ;
         P00692_A172ClienteTipoPessoa = new string[] {""} ;
         P00692_n172ClienteTipoPessoa = new bool[] {false} ;
         P00692_A168ClienteId = new int[1] ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43TFClienteTipoPessoa_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientewwexport__default(),
            new Object[][] {
                new Object[] {
               P00692_A192TipoClienteId, P00692_n192TipoClienteId, P00692_A186MunicipioCodigo, P00692_n186MunicipioCodigo, P00692_A444ResponsavelMunicipio, P00692_n444ResponsavelMunicipio, P00692_A402BancoId, P00692_n402BancoId, P00692_A437ResponsavelNacionalidade, P00692_n437ResponsavelNacionalidade,
               P00692_A484ClienteNacionalidade, P00692_n484ClienteNacionalidade, P00692_A442ResponsavelProfissao, P00692_n442ResponsavelProfissao, P00692_A487ClienteProfissao, P00692_n487ClienteProfissao, P00692_A489ClienteConvenio, P00692_n489ClienteConvenio, P00692_A170ClienteRazaoSocial, P00692_n170ClienteRazaoSocial,
               P00692_A445ResponsavelMunicipioNome, P00692_n445ResponsavelMunicipioNome, P00692_A443ResponsavelProfissaoNome, P00692_n443ResponsavelProfissaoNome, P00692_A438ResponsavelNacionalidadeNome, P00692_n438ResponsavelNacionalidadeNome, P00692_A404BancoCodigo, P00692_n404BancoCodigo, P00692_A187MunicipioNome, P00692_n187MunicipioNome,
               P00692_A488ClienteProfissaoNome, P00692_n488ClienteProfissaoNome, P00692_A485ClienteNacionalidadeNome, P00692_n485ClienteNacionalidadeNome, P00692_A490ClienteConvenioDescricao, P00692_n490ClienteConvenioDescricao, P00692_A193TipoClienteDescricao, P00692_n193TipoClienteDescricao, P00692_A169ClienteDocumento, P00692_n169ClienteDocumento,
               P00692_A174ClienteStatus, P00692_n174ClienteStatus, P00692_A172ClienteTipoPessoa, P00692_n172ClienteTipoPessoa, P00692_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV46TFClienteStatus_Sel ;
      private short GXt_int2 ;
      private short AV94Clientewwds_3_dynamicfiltersoperator1 ;
      private short AV107Clientewwds_16_dynamicfiltersoperator2 ;
      private short AV120Clientewwds_29_dynamicfiltersoperator3 ;
      private short AV138Clientewwds_47_tfclientestatus_sel ;
      private short AV18OrderedBy ;
      private short A192TipoClienteId ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int AV17Random ;
      private int AV72BancoCodigo1 ;
      private int AV79BancoCodigo2 ;
      private int AV86BancoCodigo3 ;
      private int AV90GXV1 ;
      private int AV101Clientewwds_10_bancocodigo1 ;
      private int AV114Clientewwds_23_bancocodigo2 ;
      private int AV127Clientewwds_36_bancocodigo3 ;
      private int AV137Clientewwds_46_tfclientetipopessoa_sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A168ClienteId ;
      private int AV139GXV2 ;
      private long AV51i ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV105Clientewwds_14_dynamicfiltersenabled2 ;
      private bool AV118Clientewwds_27_dynamicfiltersenabled3 ;
      private bool A174ClienteStatus ;
      private bool AV19OrderedDsc ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n170ClienteRazaoSocial ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n193TipoClienteDescricao ;
      private bool n169ClienteDocumento ;
      private bool n174ClienteStatus ;
      private bool n172ClienteTipoPessoa ;
      private string AV43TFClienteTipoPessoa_SelsJson ;
      private string AV13Filename ;
      private string AV14ErrorMessage ;
      private string AV20FilterFullText ;
      private string AV21DynamicFiltersSelector1 ;
      private string AV23ClienteDocumento1 ;
      private string AV52TipoClienteDescricao1 ;
      private string AV69ClienteConvenioDescricao1 ;
      private string AV70ClienteNacionalidadeNome1 ;
      private string AV71ClienteProfissaoNome1 ;
      private string AV60MunicipioNome1 ;
      private string AV73ResponsavelNacionalidadeNome1 ;
      private string AV74ResponsavelProfissaoNome1 ;
      private string AV75ResponsavelMunicipioNome1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV27ClienteDocumento2 ;
      private string AV54TipoClienteDescricao2 ;
      private string AV76ClienteConvenioDescricao2 ;
      private string AV77ClienteNacionalidadeNome2 ;
      private string AV78ClienteProfissaoNome2 ;
      private string AV61MunicipioNome2 ;
      private string AV80ResponsavelNacionalidadeNome2 ;
      private string AV81ResponsavelProfissaoNome2 ;
      private string AV82ResponsavelMunicipioNome2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV31ClienteDocumento3 ;
      private string AV56TipoClienteDescricao3 ;
      private string AV83ClienteConvenioDescricao3 ;
      private string AV84ClienteNacionalidadeNome3 ;
      private string AV85ClienteProfissaoNome3 ;
      private string AV62MunicipioNome3 ;
      private string AV87ResponsavelNacionalidadeNome3 ;
      private string AV88ResponsavelProfissaoNome3 ;
      private string AV89ResponsavelMunicipioNome3 ;
      private string AV59TFTipoClienteDescricao_Sel ;
      private string AV58TFTipoClienteDescricao ;
      private string AV38TFClienteRazaoSocial_Sel ;
      private string AV37TFClienteRazaoSocial ;
      private string AV42TFClienteDocumento_Sel ;
      private string AV41TFClienteDocumento ;
      private string AV44TFClienteTipoPessoa_Sel ;
      private string AV92Clientewwds_1_filterfulltext ;
      private string AV93Clientewwds_2_dynamicfiltersselector1 ;
      private string AV95Clientewwds_4_clientedocumento1 ;
      private string AV96Clientewwds_5_tipoclientedescricao1 ;
      private string AV97Clientewwds_6_clienteconveniodescricao1 ;
      private string AV98Clientewwds_7_clientenacionalidadenome1 ;
      private string AV99Clientewwds_8_clienteprofissaonome1 ;
      private string AV100Clientewwds_9_municipionome1 ;
      private string AV102Clientewwds_11_responsavelnacionalidadenome1 ;
      private string AV103Clientewwds_12_responsavelprofissaonome1 ;
      private string AV104Clientewwds_13_responsavelmunicipionome1 ;
      private string AV106Clientewwds_15_dynamicfiltersselector2 ;
      private string AV108Clientewwds_17_clientedocumento2 ;
      private string AV109Clientewwds_18_tipoclientedescricao2 ;
      private string AV110Clientewwds_19_clienteconveniodescricao2 ;
      private string AV111Clientewwds_20_clientenacionalidadenome2 ;
      private string AV112Clientewwds_21_clienteprofissaonome2 ;
      private string AV113Clientewwds_22_municipionome2 ;
      private string AV115Clientewwds_24_responsavelnacionalidadenome2 ;
      private string AV116Clientewwds_25_responsavelprofissaonome2 ;
      private string AV117Clientewwds_26_responsavelmunicipionome2 ;
      private string AV119Clientewwds_28_dynamicfiltersselector3 ;
      private string AV121Clientewwds_30_clientedocumento3 ;
      private string AV122Clientewwds_31_tipoclientedescricao3 ;
      private string AV123Clientewwds_32_clienteconveniodescricao3 ;
      private string AV124Clientewwds_33_clientenacionalidadenome3 ;
      private string AV125Clientewwds_34_clienteprofissaonome3 ;
      private string AV126Clientewwds_35_municipionome3 ;
      private string AV128Clientewwds_37_responsavelnacionalidadenome3 ;
      private string AV129Clientewwds_38_responsavelprofissaonome3 ;
      private string AV130Clientewwds_39_responsavelmunicipionome3 ;
      private string AV131Clientewwds_40_tftipoclientedescricao ;
      private string AV132Clientewwds_41_tftipoclientedescricao_sel ;
      private string AV133Clientewwds_42_tfclienterazaosocial ;
      private string AV134Clientewwds_43_tfclienterazaosocial_sel ;
      private string AV135Clientewwds_44_tfclientedocumento ;
      private string AV136Clientewwds_45_tfclientedocumento_sel ;
      private string lV92Clientewwds_1_filterfulltext ;
      private string lV95Clientewwds_4_clientedocumento1 ;
      private string lV96Clientewwds_5_tipoclientedescricao1 ;
      private string lV97Clientewwds_6_clienteconveniodescricao1 ;
      private string lV98Clientewwds_7_clientenacionalidadenome1 ;
      private string lV99Clientewwds_8_clienteprofissaonome1 ;
      private string lV100Clientewwds_9_municipionome1 ;
      private string lV102Clientewwds_11_responsavelnacionalidadenome1 ;
      private string lV103Clientewwds_12_responsavelprofissaonome1 ;
      private string lV104Clientewwds_13_responsavelmunicipionome1 ;
      private string lV108Clientewwds_17_clientedocumento2 ;
      private string lV109Clientewwds_18_tipoclientedescricao2 ;
      private string lV110Clientewwds_19_clienteconveniodescricao2 ;
      private string lV111Clientewwds_20_clientenacionalidadenome2 ;
      private string lV112Clientewwds_21_clienteprofissaonome2 ;
      private string lV113Clientewwds_22_municipionome2 ;
      private string lV115Clientewwds_24_responsavelnacionalidadenome2 ;
      private string lV116Clientewwds_25_responsavelprofissaonome2 ;
      private string lV117Clientewwds_26_responsavelmunicipionome2 ;
      private string lV121Clientewwds_30_clientedocumento3 ;
      private string lV122Clientewwds_31_tipoclientedescricao3 ;
      private string lV123Clientewwds_32_clienteconveniodescricao3 ;
      private string lV124Clientewwds_33_clientenacionalidadenome3 ;
      private string lV125Clientewwds_34_clienteprofissaonome3 ;
      private string lV126Clientewwds_35_municipionome3 ;
      private string lV128Clientewwds_37_responsavelnacionalidadenome3 ;
      private string lV129Clientewwds_38_responsavelprofissaonome3 ;
      private string lV130Clientewwds_39_responsavelmunicipionome3 ;
      private string lV131Clientewwds_40_tftipoclientedescricao ;
      private string lV133Clientewwds_42_tfclienterazaosocial ;
      private string lV135Clientewwds_44_tfclientedocumento ;
      private string A172ClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private IGxSession AV33Session ;
      private ExcelDocumentI AV12ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV45TFClienteTipoPessoa_Sels ;
      private GxSimpleCollection<string> AV137Clientewwds_46_tfclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00692_A192TipoClienteId ;
      private bool[] P00692_n192TipoClienteId ;
      private string[] P00692_A186MunicipioCodigo ;
      private bool[] P00692_n186MunicipioCodigo ;
      private string[] P00692_A444ResponsavelMunicipio ;
      private bool[] P00692_n444ResponsavelMunicipio ;
      private int[] P00692_A402BancoId ;
      private bool[] P00692_n402BancoId ;
      private int[] P00692_A437ResponsavelNacionalidade ;
      private bool[] P00692_n437ResponsavelNacionalidade ;
      private int[] P00692_A484ClienteNacionalidade ;
      private bool[] P00692_n484ClienteNacionalidade ;
      private int[] P00692_A442ResponsavelProfissao ;
      private bool[] P00692_n442ResponsavelProfissao ;
      private int[] P00692_A487ClienteProfissao ;
      private bool[] P00692_n487ClienteProfissao ;
      private int[] P00692_A489ClienteConvenio ;
      private bool[] P00692_n489ClienteConvenio ;
      private string[] P00692_A170ClienteRazaoSocial ;
      private bool[] P00692_n170ClienteRazaoSocial ;
      private string[] P00692_A445ResponsavelMunicipioNome ;
      private bool[] P00692_n445ResponsavelMunicipioNome ;
      private string[] P00692_A443ResponsavelProfissaoNome ;
      private bool[] P00692_n443ResponsavelProfissaoNome ;
      private string[] P00692_A438ResponsavelNacionalidadeNome ;
      private bool[] P00692_n438ResponsavelNacionalidadeNome ;
      private int[] P00692_A404BancoCodigo ;
      private bool[] P00692_n404BancoCodigo ;
      private string[] P00692_A187MunicipioNome ;
      private bool[] P00692_n187MunicipioNome ;
      private string[] P00692_A488ClienteProfissaoNome ;
      private bool[] P00692_n488ClienteProfissaoNome ;
      private string[] P00692_A485ClienteNacionalidadeNome ;
      private bool[] P00692_n485ClienteNacionalidadeNome ;
      private string[] P00692_A490ClienteConvenioDescricao ;
      private bool[] P00692_n490ClienteConvenioDescricao ;
      private string[] P00692_A193TipoClienteDescricao ;
      private bool[] P00692_n193TipoClienteDescricao ;
      private string[] P00692_A169ClienteDocumento ;
      private bool[] P00692_n169ClienteDocumento ;
      private bool[] P00692_A174ClienteStatus ;
      private bool[] P00692_n174ClienteStatus ;
      private string[] P00692_A172ClienteTipoPessoa ;
      private bool[] P00692_n172ClienteTipoPessoa ;
      private int[] P00692_A168ClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class clientewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV137Clientewwds_46_tfclientetipopessoa_sels ,
                                             string AV92Clientewwds_1_filterfulltext ,
                                             string AV93Clientewwds_2_dynamicfiltersselector1 ,
                                             short AV94Clientewwds_3_dynamicfiltersoperator1 ,
                                             string AV95Clientewwds_4_clientedocumento1 ,
                                             string AV96Clientewwds_5_tipoclientedescricao1 ,
                                             string AV97Clientewwds_6_clienteconveniodescricao1 ,
                                             string AV98Clientewwds_7_clientenacionalidadenome1 ,
                                             string AV99Clientewwds_8_clienteprofissaonome1 ,
                                             string AV100Clientewwds_9_municipionome1 ,
                                             int AV101Clientewwds_10_bancocodigo1 ,
                                             string AV102Clientewwds_11_responsavelnacionalidadenome1 ,
                                             string AV103Clientewwds_12_responsavelprofissaonome1 ,
                                             string AV104Clientewwds_13_responsavelmunicipionome1 ,
                                             bool AV105Clientewwds_14_dynamicfiltersenabled2 ,
                                             string AV106Clientewwds_15_dynamicfiltersselector2 ,
                                             short AV107Clientewwds_16_dynamicfiltersoperator2 ,
                                             string AV108Clientewwds_17_clientedocumento2 ,
                                             string AV109Clientewwds_18_tipoclientedescricao2 ,
                                             string AV110Clientewwds_19_clienteconveniodescricao2 ,
                                             string AV111Clientewwds_20_clientenacionalidadenome2 ,
                                             string AV112Clientewwds_21_clienteprofissaonome2 ,
                                             string AV113Clientewwds_22_municipionome2 ,
                                             int AV114Clientewwds_23_bancocodigo2 ,
                                             string AV115Clientewwds_24_responsavelnacionalidadenome2 ,
                                             string AV116Clientewwds_25_responsavelprofissaonome2 ,
                                             string AV117Clientewwds_26_responsavelmunicipionome2 ,
                                             bool AV118Clientewwds_27_dynamicfiltersenabled3 ,
                                             string AV119Clientewwds_28_dynamicfiltersselector3 ,
                                             short AV120Clientewwds_29_dynamicfiltersoperator3 ,
                                             string AV121Clientewwds_30_clientedocumento3 ,
                                             string AV122Clientewwds_31_tipoclientedescricao3 ,
                                             string AV123Clientewwds_32_clienteconveniodescricao3 ,
                                             string AV124Clientewwds_33_clientenacionalidadenome3 ,
                                             string AV125Clientewwds_34_clienteprofissaonome3 ,
                                             string AV126Clientewwds_35_municipionome3 ,
                                             int AV127Clientewwds_36_bancocodigo3 ,
                                             string AV128Clientewwds_37_responsavelnacionalidadenome3 ,
                                             string AV129Clientewwds_38_responsavelprofissaonome3 ,
                                             string AV130Clientewwds_39_responsavelmunicipionome3 ,
                                             string AV132Clientewwds_41_tftipoclientedescricao_sel ,
                                             string AV131Clientewwds_40_tftipoclientedescricao ,
                                             string AV134Clientewwds_43_tfclienterazaosocial_sel ,
                                             string AV133Clientewwds_42_tfclienterazaosocial ,
                                             string AV136Clientewwds_45_tfclientedocumento_sel ,
                                             string AV135Clientewwds_44_tfclientedocumento ,
                                             int AV137Clientewwds_46_tfclientetipopessoa_sels_Count ,
                                             short AV138Clientewwds_47_tfclientestatus_sel ,
                                             string A193TipoClienteDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             bool A174ClienteStatus ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             short AV18OrderedBy ,
                                             bool AV19OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[76];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteRazaoSocial, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteStatus, T1.ClienteTipoPessoa, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.TipoClienteDescricao) like '%' || LOWER(:lV92Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteRazaoSocial) like '%' || LOWER(:lV92Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteDocumento) like '%' || LOWER(:lV92Clientewwds_1_filterfulltext)) or ( 'física' like '%' || LOWER(:lV92Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV92Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( 'ativo' like '%' || LOWER(:lV92Clientewwds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV92Clientewwds_1_filterfulltext) and T1.ClienteStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV95Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV95Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV96Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV96Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV97Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV97Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV98Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV98Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV99Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV99Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV100Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV100Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV101Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV101Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV101Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV101Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV101Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV101Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV102Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV102Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV103Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV103Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV104Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV94Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV104Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV108Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV108Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV109Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV109Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV110Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV110Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV111Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV111Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV112Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV112Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV113Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV113Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV114Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV114Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV114Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV114Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV114Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV114Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV115Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV115Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV116Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV116Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV117Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( AV105Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV107Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV117Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV121Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV121Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV122Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV122Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV123Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV123Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV124Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV124Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV125Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV125Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV126Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV126Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV127Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV127Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV127Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV127Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV127Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV127Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV128Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV128Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV129Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV129Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV130Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV118Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV120Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV130Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_41_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_40_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV131Clientewwds_40_tftipoclientedescricao)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_41_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV132Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV132Clientewwds_41_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( StringUtil.StrCmp(AV132Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Clientewwds_43_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_42_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV133Clientewwds_42_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Clientewwds_43_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV134Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV134Clientewwds_43_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( StringUtil.StrCmp(AV134Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_45_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_44_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV135Clientewwds_44_tfclientedocumento)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_45_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV136Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV136Clientewwds_45_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( StringUtil.StrCmp(AV136Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( AV137Clientewwds_46_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV137Clientewwds_46_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV138Clientewwds_47_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV138Clientewwds_47_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV18OrderedBy == 1 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV18OrderedBy == 1 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento DESC";
         }
         else if ( ( AV18OrderedBy == 2 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.TipoClienteDescricao";
         }
         else if ( ( AV18OrderedBy == 2 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.TipoClienteDescricao DESC";
         }
         else if ( ( AV18OrderedBy == 3 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         }
         else if ( ( AV18OrderedBy == 3 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC";
         }
         else if ( ( AV18OrderedBy == 4 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteTipoPessoa";
         }
         else if ( ( AV18OrderedBy == 4 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteTipoPessoa DESC";
         }
         else if ( ( AV18OrderedBy == 5 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteStatus";
         }
         else if ( ( AV18OrderedBy == 5 ) && ( AV19OrderedDsc ) )
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
                     return conditional_P00692(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (short)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (bool)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (int)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (short)dynConstraints[61] , (bool)dynConstraints[62] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV92Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV95Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV96Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV96Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV97Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV97Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV98Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV98Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV99Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV100Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV100Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV101Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV101Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV101Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV102Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV103Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV104Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV104Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV108Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV108Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV109Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV109Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV110Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV110Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV111Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV111Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV112Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV112Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV113Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV113Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV114Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV114Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV114Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV115Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV117Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV121Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV121Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV122Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV122Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV123Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV123Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV124Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV124Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV125Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV125Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV126Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV126Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV127Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV127Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV127Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV128Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV128Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV129Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV130Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV131Clientewwds_40_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV132Clientewwds_41_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV133Clientewwds_42_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV134Clientewwds_43_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV135Clientewwds_44_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV136Clientewwds_45_tfclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
                return;
       }
    }

 }

}
