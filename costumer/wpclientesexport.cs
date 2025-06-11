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
namespace GeneXus.Programs.costumer {
   public class wpclientesexport : GXProcedure
   {
      public wpclientesexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpclientesexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WpClientesExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV63TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Representante") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFResponsavelNome_Sel)) ? "(Vazio)" : AV65TFResponsavelNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFResponsavelNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Representante") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFResponsavelNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV67TFResponsavelEmail_Sel)) ? "(Vazio)" : AV67TFResponsavelEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFResponsavelEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV66TFResponsavelEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV68TFClienteCreatedAt) && (DateTime.MinValue==AV69TFClienteCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data de registro") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV68TFClienteCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV69TFClienteCreatedAt_To;
         }
         if ( ! ( ( AV72TFClienteSituacao_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV75i = 1;
            AV76GXV1 = 1;
            while ( AV76GXV1 <= AV72TFClienteSituacao_Sels.Count )
            {
               AV71TFClienteSituacao_Sel = AV72TFClienteSituacao_Sels.GetString(AV76GXV1);
               if ( AV75i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmsituacao.getDescription(context,AV71TFClienteSituacao_Sel);
               AV75i = (long)(AV75i+1);
               AV76GXV1 = (int)(AV76GXV1+1);
            }
         }
         if ( ! ( (0==AV73TFClienteCountNotas_F) && (0==AV74TFClienteCountNotas_F_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Notas") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV73TFClienteCountNotas_F;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV74TFClienteCountNotas_F_To;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Representante";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Email";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Data de registro";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Notas";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV78Costumer_wpclientesds_1_filterfulltext = AV18FilterFullText;
         AV79Costumer_wpclientesds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV81Costumer_wpclientesds_4_clientedocumento1 = AV21ClienteDocumento1;
         AV82Costumer_wpclientesds_5_tipoclientedescricao1 = AV22TipoClienteDescricao1;
         AV83Costumer_wpclientesds_6_clienteconveniodescricao1 = AV23ClienteConvenioDescricao1;
         AV84Costumer_wpclientesds_7_clientenacionalidadenome1 = AV24ClienteNacionalidadeNome1;
         AV85Costumer_wpclientesds_8_clienteprofissaonome1 = AV25ClienteProfissaoNome1;
         AV86Costumer_wpclientesds_9_municipionome1 = AV26MunicipioNome1;
         AV87Costumer_wpclientesds_10_bancocodigo1 = AV27BancoCodigo1;
         AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV28ResponsavelNacionalidadeNome1;
         AV89Costumer_wpclientesds_12_responsavelprofissaonome1 = AV29ResponsavelProfissaoNome1;
         AV90Costumer_wpclientesds_13_responsavelmunicipionome1 = AV30ResponsavelMunicipioNome1;
         AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV31DynamicFiltersEnabled2;
         AV92Costumer_wpclientesds_15_dynamicfiltersselector2 = AV32DynamicFiltersSelector2;
         AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV33DynamicFiltersOperator2;
         AV94Costumer_wpclientesds_17_clientedocumento2 = AV34ClienteDocumento2;
         AV95Costumer_wpclientesds_18_tipoclientedescricao2 = AV35TipoClienteDescricao2;
         AV96Costumer_wpclientesds_19_clienteconveniodescricao2 = AV36ClienteConvenioDescricao2;
         AV97Costumer_wpclientesds_20_clientenacionalidadenome2 = AV37ClienteNacionalidadeNome2;
         AV98Costumer_wpclientesds_21_clienteprofissaonome2 = AV38ClienteProfissaoNome2;
         AV99Costumer_wpclientesds_22_municipionome2 = AV39MunicipioNome2;
         AV100Costumer_wpclientesds_23_bancocodigo2 = AV40BancoCodigo2;
         AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV41ResponsavelNacionalidadeNome2;
         AV102Costumer_wpclientesds_25_responsavelprofissaonome2 = AV42ResponsavelProfissaoNome2;
         AV103Costumer_wpclientesds_26_responsavelmunicipionome2 = AV43ResponsavelMunicipioNome2;
         AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV44DynamicFiltersEnabled3;
         AV105Costumer_wpclientesds_28_dynamicfiltersselector3 = AV45DynamicFiltersSelector3;
         AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV46DynamicFiltersOperator3;
         AV107Costumer_wpclientesds_30_clientedocumento3 = AV47ClienteDocumento3;
         AV108Costumer_wpclientesds_31_tipoclientedescricao3 = AV48TipoClienteDescricao3;
         AV109Costumer_wpclientesds_32_clienteconveniodescricao3 = AV49ClienteConvenioDescricao3;
         AV110Costumer_wpclientesds_33_clientenacionalidadenome3 = AV50ClienteNacionalidadeNome3;
         AV111Costumer_wpclientesds_34_clienteprofissaonome3 = AV51ClienteProfissaoNome3;
         AV112Costumer_wpclientesds_35_municipionome3 = AV52MunicipioNome3;
         AV113Costumer_wpclientesds_36_bancocodigo3 = AV53BancoCodigo3;
         AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV54ResponsavelNacionalidadeNome3;
         AV115Costumer_wpclientesds_38_responsavelprofissaonome3 = AV55ResponsavelProfissaoNome3;
         AV116Costumer_wpclientesds_39_responsavelmunicipionome3 = AV56ResponsavelMunicipioNome3;
         AV117Costumer_wpclientesds_40_tfclienterazaosocial = AV62TFClienteRazaoSocial;
         AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV63TFClienteRazaoSocial_Sel;
         AV119Costumer_wpclientesds_42_tfresponsavelnome = AV64TFResponsavelNome;
         AV120Costumer_wpclientesds_43_tfresponsavelnome_sel = AV65TFResponsavelNome_Sel;
         AV121Costumer_wpclientesds_44_tfresponsavelemail = AV66TFResponsavelEmail;
         AV122Costumer_wpclientesds_45_tfresponsavelemail_sel = AV67TFResponsavelEmail_Sel;
         AV123Costumer_wpclientesds_46_tfclientecreatedat = AV68TFClienteCreatedAt;
         AV124Costumer_wpclientesds_47_tfclientecreatedat_to = AV69TFClienteCreatedAt_To;
         AV125Costumer_wpclientesds_48_tfclientesituacao_sels = AV72TFClienteSituacao_Sels;
         AV126Costumer_wpclientesds_49_tfclientecountnotas_f = AV73TFClienteCountNotas_F;
         AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV74TFClienteCountNotas_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A884ClienteSituacao ,
                                              AV125Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                              AV79Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                              AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                              AV81Costumer_wpclientesds_4_clientedocumento1 ,
                                              AV82Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                              AV83Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                              AV84Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                              AV85Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                              AV86Costumer_wpclientesds_9_municipionome1 ,
                                              AV87Costumer_wpclientesds_10_bancocodigo1 ,
                                              AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                              AV89Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                              AV90Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                              AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                              AV92Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                              AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                              AV94Costumer_wpclientesds_17_clientedocumento2 ,
                                              AV95Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                              AV96Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                              AV97Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                              AV98Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                              AV99Costumer_wpclientesds_22_municipionome2 ,
                                              AV100Costumer_wpclientesds_23_bancocodigo2 ,
                                              AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                              AV102Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                              AV103Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                              AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                              AV105Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                              AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                              AV107Costumer_wpclientesds_30_clientedocumento3 ,
                                              AV108Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                              AV109Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                              AV110Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                              AV111Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                              AV112Costumer_wpclientesds_35_municipionome3 ,
                                              AV113Costumer_wpclientesds_36_bancocodigo3 ,
                                              AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                              AV115Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                              AV116Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                              AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                              AV117Costumer_wpclientesds_40_tfclienterazaosocial ,
                                              AV120Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                              AV119Costumer_wpclientesds_42_tfresponsavelnome ,
                                              AV122Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                              AV121Costumer_wpclientesds_44_tfresponsavelemail ,
                                              AV123Costumer_wpclientesds_46_tfclientecreatedat ,
                                              AV124Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                              AV125Costumer_wpclientesds_48_tfclientesituacao_sels.Count ,
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
                                              A170ClienteRazaoSocial ,
                                              A436ResponsavelNome ,
                                              A456ResponsavelEmail ,
                                              A175ClienteCreatedAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV78Costumer_wpclientesds_1_filterfulltext ,
                                              A886ClienteCountNotas_F ,
                                              AV126Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                              AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                              A793TipoClientePortalPjPf } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV78Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV81Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV81Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV81Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV81Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV82Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV82Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV82Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV82Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV83Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV83Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV83Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV83Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV84Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV84Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV84Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV84Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV85Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV85Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV86Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV86Costumer_wpclientesds_9_municipionome1), "%", "");
         lV86Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV86Costumer_wpclientesds_9_municipionome1), "%", "");
         lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV89Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV89Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV90Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV90Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV94Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV94Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV94Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV95Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV95Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV96Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV96Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV97Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV97Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV98Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV98Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV98Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV99Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV99Costumer_wpclientesds_22_municipionome2), "%", "");
         lV99Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV99Costumer_wpclientesds_22_municipionome2), "%", "");
         lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV102Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV102Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV103Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV103Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV107Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV107Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV107Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV107Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV108Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV108Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV109Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV109Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV110Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV110Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV111Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV111Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV111Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV111Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV112Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV112Costumer_wpclientesds_35_municipionome3), "%", "");
         lV112Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV112Costumer_wpclientesds_35_municipionome3), "%", "");
         lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV115Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV115Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV116Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV116Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV117Costumer_wpclientesds_40_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_40_tfclienterazaosocial), "%", "");
         lV119Costumer_wpclientesds_42_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_42_tfresponsavelnome), "%", "");
         lV121Costumer_wpclientesds_44_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_44_tfresponsavelemail), "%", "");
         /* Using cursor P00E33 */
         pr_default.execute(0, new Object[] {AV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, lV78Costumer_wpclientesds_1_filterfulltext, AV126Costumer_wpclientesds_49_tfclientecountnotas_f, AV126Costumer_wpclientesds_49_tfclientecountnotas_f, AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to, AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to, lV81Costumer_wpclientesds_4_clientedocumento1, lV81Costumer_wpclientesds_4_clientedocumento1, lV82Costumer_wpclientesds_5_tipoclientedescricao1, lV82Costumer_wpclientesds_5_tipoclientedescricao1, lV83Costumer_wpclientesds_6_clienteconveniodescricao1, lV83Costumer_wpclientesds_6_clienteconveniodescricao1, lV84Costumer_wpclientesds_7_clientenacionalidadenome1, lV84Costumer_wpclientesds_7_clientenacionalidadenome1, lV85Costumer_wpclientesds_8_clienteprofissaonome1, lV85Costumer_wpclientesds_8_clienteprofissaonome1, lV86Costumer_wpclientesds_9_municipionome1, lV86Costumer_wpclientesds_9_municipionome1, AV87Costumer_wpclientesds_10_bancocodigo1, AV87Costumer_wpclientesds_10_bancocodigo1, AV87Costumer_wpclientesds_10_bancocodigo1, lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV89Costumer_wpclientesds_12_responsavelprofissaonome1, lV89Costumer_wpclientesds_12_responsavelprofissaonome1, lV90Costumer_wpclientesds_13_responsavelmunicipionome1, lV90Costumer_wpclientesds_13_responsavelmunicipionome1, lV94Costumer_wpclientesds_17_clientedocumento2, lV94Costumer_wpclientesds_17_clientedocumento2, lV95Costumer_wpclientesds_18_tipoclientedescricao2, lV95Costumer_wpclientesds_18_tipoclientedescricao2, lV96Costumer_wpclientesds_19_clienteconveniodescricao2, lV96Costumer_wpclientesds_19_clienteconveniodescricao2, lV97Costumer_wpclientesds_20_clientenacionalidadenome2, lV97Costumer_wpclientesds_20_clientenacionalidadenome2, lV98Costumer_wpclientesds_21_clienteprofissaonome2, lV98Costumer_wpclientesds_21_clienteprofissaonome2, lV99Costumer_wpclientesds_22_municipionome2, lV99Costumer_wpclientesds_22_municipionome2, AV100Costumer_wpclientesds_23_bancocodigo2, AV100Costumer_wpclientesds_23_bancocodigo2, AV100Costumer_wpclientesds_23_bancocodigo2, lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV102Costumer_wpclientesds_25_responsavelprofissaonome2, lV102Costumer_wpclientesds_25_responsavelprofissaonome2, lV103Costumer_wpclientesds_26_responsavelmunicipionome2, lV103Costumer_wpclientesds_26_responsavelmunicipionome2, lV107Costumer_wpclientesds_30_clientedocumento3, lV107Costumer_wpclientesds_30_clientedocumento3, lV108Costumer_wpclientesds_31_tipoclientedescricao3, lV108Costumer_wpclientesds_31_tipoclientedescricao3, lV109Costumer_wpclientesds_32_clienteconveniodescricao3, lV109Costumer_wpclientesds_32_clienteconveniodescricao3, lV110Costumer_wpclientesds_33_clientenacionalidadenome3, lV110Costumer_wpclientesds_33_clientenacionalidadenome3, lV111Costumer_wpclientesds_34_clienteprofissaonome3, lV111Costumer_wpclientesds_34_clienteprofissaonome3, lV112Costumer_wpclientesds_35_municipionome3, lV112Costumer_wpclientesds_35_municipionome3, AV113Costumer_wpclientesds_36_bancocodigo3, AV113Costumer_wpclientesds_36_bancocodigo3, AV113Costumer_wpclientesds_36_bancocodigo3, lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV115Costumer_wpclientesds_38_responsavelprofissaonome3, lV115Costumer_wpclientesds_38_responsavelprofissaonome3, lV116Costumer_wpclientesds_39_responsavelmunicipionome3, lV116Costumer_wpclientesds_39_responsavelmunicipionome3, lV117Costumer_wpclientesds_40_tfclienterazaosocial, AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel, lV119Costumer_wpclientesds_42_tfresponsavelnome, AV120Costumer_wpclientesds_43_tfresponsavelnome_sel, lV121Costumer_wpclientesds_44_tfresponsavelemail, AV122Costumer_wpclientesds_45_tfresponsavelemail_sel, AV123Costumer_wpclientesds_46_tfclientecreatedat, AV124Costumer_wpclientesds_47_tfclientecreatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A192TipoClienteId = P00E33_A192TipoClienteId[0];
            n192TipoClienteId = P00E33_n192TipoClienteId[0];
            A186MunicipioCodigo = P00E33_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00E33_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00E33_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00E33_n444ResponsavelMunicipio[0];
            A402BancoId = P00E33_A402BancoId[0];
            n402BancoId = P00E33_n402BancoId[0];
            A437ResponsavelNacionalidade = P00E33_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00E33_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00E33_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00E33_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00E33_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00E33_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00E33_A487ClienteProfissao[0];
            n487ClienteProfissao = P00E33_n487ClienteProfissao[0];
            A489ClienteConvenio = P00E33_A489ClienteConvenio[0];
            n489ClienteConvenio = P00E33_n489ClienteConvenio[0];
            A168ClienteId = P00E33_A168ClienteId[0];
            n168ClienteId = P00E33_n168ClienteId[0];
            A793TipoClientePortalPjPf = P00E33_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E33_n793TipoClientePortalPjPf[0];
            A175ClienteCreatedAt = P00E33_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = P00E33_n175ClienteCreatedAt[0];
            A445ResponsavelMunicipioNome = P00E33_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E33_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00E33_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E33_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00E33_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E33_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00E33_A404BancoCodigo[0];
            n404BancoCodigo = P00E33_n404BancoCodigo[0];
            A187MunicipioNome = P00E33_A187MunicipioNome[0];
            n187MunicipioNome = P00E33_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00E33_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E33_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00E33_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E33_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00E33_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E33_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00E33_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E33_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00E33_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E33_n169ClienteDocumento[0];
            A884ClienteSituacao = P00E33_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E33_n884ClienteSituacao[0];
            A456ResponsavelEmail = P00E33_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E33_n456ResponsavelEmail[0];
            A436ResponsavelNome = P00E33_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E33_n436ResponsavelNome[0];
            A170ClienteRazaoSocial = P00E33_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E33_n170ClienteRazaoSocial[0];
            A886ClienteCountNotas_F = P00E33_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E33_n886ClienteCountNotas_F[0];
            A793TipoClientePortalPjPf = P00E33_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E33_n793TipoClientePortalPjPf[0];
            A193TipoClienteDescricao = P00E33_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E33_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00E33_A187MunicipioNome[0];
            n187MunicipioNome = P00E33_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00E33_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E33_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00E33_A404BancoCodigo[0];
            n404BancoCodigo = P00E33_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00E33_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E33_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00E33_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E33_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00E33_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E33_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00E33_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E33_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00E33_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E33_n490ClienteConvenioDescricao[0];
            A886ClienteCountNotas_F = P00E33_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E33_n886ClienteCountNotas_F[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A436ResponsavelNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A456ResponsavelEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = A175ClienteCreatedAt;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = gxdomaindmsituacao.getDescription(context,A884ClienteSituacao);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A886ClienteCountNotas_F;
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
         AV58Session.Set("WWPExportFilePath", AV11Filename);
         AV58Session.Set("WWPExportFileName", "WpClientesExport.xlsx");
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
         if ( StringUtil.StrCmp(AV58Session.Get("Costumer.WpClientesGridState"), "") == 0 )
         {
            AV60GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Costumer.WpClientesGridState"), null, "", "");
         }
         else
         {
            AV60GridState.FromXml(AV58Session.Get("Costumer.WpClientesGridState"), null, "", "");
         }
         AV16OrderedBy = AV60GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV60GridState.gxTpr_Ordereddsc;
         AV128GXV2 = 1;
         while ( AV128GXV2 <= AV60GridState.gxTpr_Filtervalues.Count )
         {
            AV61GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV60GridState.gxTpr_Filtervalues.Item(AV128GXV2));
            if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV62TFClienteRazaoSocial = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV63TFClienteRazaoSocial_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV64TFResponsavelNome = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV65TFResponsavelNome_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV66TFResponsavelEmail = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV67TFResponsavelEmail_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTECREATEDAT") == 0 )
            {
               AV68TFClienteCreatedAt = context.localUtil.CToT( AV61GridStateFilterValue.gxTpr_Value, 4);
               AV69TFClienteCreatedAt_To = context.localUtil.CToT( AV61GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV70TFClienteSituacao_SelsJson = AV61GridStateFilterValue.gxTpr_Value;
               AV72TFClienteSituacao_Sels.FromJSonString(AV70TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFCLIENTECOUNTNOTAS_F") == 0 )
            {
               AV73TFClienteCountNotas_F = (short)(Math.Round(NumberUtil.Val( AV61GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV74TFClienteCountNotas_F_To = (short)(Math.Round(NumberUtil.Val( AV61GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV128GXV2 = (int)(AV128GXV2+1);
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
         AV63TFClienteRazaoSocial_Sel = "";
         AV62TFClienteRazaoSocial = "";
         AV65TFResponsavelNome_Sel = "";
         AV64TFResponsavelNome = "";
         AV67TFResponsavelEmail_Sel = "";
         AV66TFResponsavelEmail = "";
         AV68TFClienteCreatedAt = (DateTime)(DateTime.MinValue);
         AV69TFClienteCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV72TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV71TFClienteSituacao_Sel = "";
         AV78Costumer_wpclientesds_1_filterfulltext = "";
         AV79Costumer_wpclientesds_2_dynamicfiltersselector1 = "";
         AV81Costumer_wpclientesds_4_clientedocumento1 = "";
         AV82Costumer_wpclientesds_5_tipoclientedescricao1 = "";
         AV83Costumer_wpclientesds_6_clienteconveniodescricao1 = "";
         AV84Costumer_wpclientesds_7_clientenacionalidadenome1 = "";
         AV85Costumer_wpclientesds_8_clienteprofissaonome1 = "";
         AV86Costumer_wpclientesds_9_municipionome1 = "";
         AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 = "";
         AV89Costumer_wpclientesds_12_responsavelprofissaonome1 = "";
         AV90Costumer_wpclientesds_13_responsavelmunicipionome1 = "";
         AV92Costumer_wpclientesds_15_dynamicfiltersselector2 = "";
         AV94Costumer_wpclientesds_17_clientedocumento2 = "";
         AV95Costumer_wpclientesds_18_tipoclientedescricao2 = "";
         AV96Costumer_wpclientesds_19_clienteconveniodescricao2 = "";
         AV97Costumer_wpclientesds_20_clientenacionalidadenome2 = "";
         AV98Costumer_wpclientesds_21_clienteprofissaonome2 = "";
         AV99Costumer_wpclientesds_22_municipionome2 = "";
         AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 = "";
         AV102Costumer_wpclientesds_25_responsavelprofissaonome2 = "";
         AV103Costumer_wpclientesds_26_responsavelmunicipionome2 = "";
         AV105Costumer_wpclientesds_28_dynamicfiltersselector3 = "";
         AV107Costumer_wpclientesds_30_clientedocumento3 = "";
         AV108Costumer_wpclientesds_31_tipoclientedescricao3 = "";
         AV109Costumer_wpclientesds_32_clienteconveniodescricao3 = "";
         AV110Costumer_wpclientesds_33_clientenacionalidadenome3 = "";
         AV111Costumer_wpclientesds_34_clienteprofissaonome3 = "";
         AV112Costumer_wpclientesds_35_municipionome3 = "";
         AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 = "";
         AV115Costumer_wpclientesds_38_responsavelprofissaonome3 = "";
         AV116Costumer_wpclientesds_39_responsavelmunicipionome3 = "";
         AV117Costumer_wpclientesds_40_tfclienterazaosocial = "";
         AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel = "";
         AV119Costumer_wpclientesds_42_tfresponsavelnome = "";
         AV120Costumer_wpclientesds_43_tfresponsavelnome_sel = "";
         AV121Costumer_wpclientesds_44_tfresponsavelemail = "";
         AV122Costumer_wpclientesds_45_tfresponsavelemail_sel = "";
         AV123Costumer_wpclientesds_46_tfclientecreatedat = (DateTime)(DateTime.MinValue);
         AV124Costumer_wpclientesds_47_tfclientecreatedat_to = (DateTime)(DateTime.MinValue);
         AV125Costumer_wpclientesds_48_tfclientesituacao_sels = new GxSimpleCollection<string>();
         lV78Costumer_wpclientesds_1_filterfulltext = "";
         lV81Costumer_wpclientesds_4_clientedocumento1 = "";
         lV82Costumer_wpclientesds_5_tipoclientedescricao1 = "";
         lV83Costumer_wpclientesds_6_clienteconveniodescricao1 = "";
         lV84Costumer_wpclientesds_7_clientenacionalidadenome1 = "";
         lV85Costumer_wpclientesds_8_clienteprofissaonome1 = "";
         lV86Costumer_wpclientesds_9_municipionome1 = "";
         lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 = "";
         lV89Costumer_wpclientesds_12_responsavelprofissaonome1 = "";
         lV90Costumer_wpclientesds_13_responsavelmunicipionome1 = "";
         lV94Costumer_wpclientesds_17_clientedocumento2 = "";
         lV95Costumer_wpclientesds_18_tipoclientedescricao2 = "";
         lV96Costumer_wpclientesds_19_clienteconveniodescricao2 = "";
         lV97Costumer_wpclientesds_20_clientenacionalidadenome2 = "";
         lV98Costumer_wpclientesds_21_clienteprofissaonome2 = "";
         lV99Costumer_wpclientesds_22_municipionome2 = "";
         lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 = "";
         lV102Costumer_wpclientesds_25_responsavelprofissaonome2 = "";
         lV103Costumer_wpclientesds_26_responsavelmunicipionome2 = "";
         lV107Costumer_wpclientesds_30_clientedocumento3 = "";
         lV108Costumer_wpclientesds_31_tipoclientedescricao3 = "";
         lV109Costumer_wpclientesds_32_clienteconveniodescricao3 = "";
         lV110Costumer_wpclientesds_33_clientenacionalidadenome3 = "";
         lV111Costumer_wpclientesds_34_clienteprofissaonome3 = "";
         lV112Costumer_wpclientesds_35_municipionome3 = "";
         lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 = "";
         lV115Costumer_wpclientesds_38_responsavelprofissaonome3 = "";
         lV116Costumer_wpclientesds_39_responsavelmunicipionome3 = "";
         lV117Costumer_wpclientesds_40_tfclienterazaosocial = "";
         lV119Costumer_wpclientesds_42_tfresponsavelnome = "";
         lV121Costumer_wpclientesds_44_tfresponsavelemail = "";
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
         A170ClienteRazaoSocial = "";
         A436ResponsavelNome = "";
         A456ResponsavelEmail = "";
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         P00E33_A192TipoClienteId = new short[1] ;
         P00E33_n192TipoClienteId = new bool[] {false} ;
         P00E33_A186MunicipioCodigo = new string[] {""} ;
         P00E33_n186MunicipioCodigo = new bool[] {false} ;
         P00E33_A444ResponsavelMunicipio = new string[] {""} ;
         P00E33_n444ResponsavelMunicipio = new bool[] {false} ;
         P00E33_A402BancoId = new int[1] ;
         P00E33_n402BancoId = new bool[] {false} ;
         P00E33_A437ResponsavelNacionalidade = new int[1] ;
         P00E33_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00E33_A484ClienteNacionalidade = new int[1] ;
         P00E33_n484ClienteNacionalidade = new bool[] {false} ;
         P00E33_A442ResponsavelProfissao = new int[1] ;
         P00E33_n442ResponsavelProfissao = new bool[] {false} ;
         P00E33_A487ClienteProfissao = new int[1] ;
         P00E33_n487ClienteProfissao = new bool[] {false} ;
         P00E33_A489ClienteConvenio = new int[1] ;
         P00E33_n489ClienteConvenio = new bool[] {false} ;
         P00E33_A168ClienteId = new int[1] ;
         P00E33_n168ClienteId = new bool[] {false} ;
         P00E33_A793TipoClientePortalPjPf = new bool[] {false} ;
         P00E33_n793TipoClientePortalPjPf = new bool[] {false} ;
         P00E33_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E33_n175ClienteCreatedAt = new bool[] {false} ;
         P00E33_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00E33_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00E33_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00E33_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00E33_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00E33_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00E33_A404BancoCodigo = new int[1] ;
         P00E33_n404BancoCodigo = new bool[] {false} ;
         P00E33_A187MunicipioNome = new string[] {""} ;
         P00E33_n187MunicipioNome = new bool[] {false} ;
         P00E33_A488ClienteProfissaoNome = new string[] {""} ;
         P00E33_n488ClienteProfissaoNome = new bool[] {false} ;
         P00E33_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00E33_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00E33_A490ClienteConvenioDescricao = new string[] {""} ;
         P00E33_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00E33_A193TipoClienteDescricao = new string[] {""} ;
         P00E33_n193TipoClienteDescricao = new bool[] {false} ;
         P00E33_A169ClienteDocumento = new string[] {""} ;
         P00E33_n169ClienteDocumento = new bool[] {false} ;
         P00E33_A884ClienteSituacao = new string[] {""} ;
         P00E33_n884ClienteSituacao = new bool[] {false} ;
         P00E33_A456ResponsavelEmail = new string[] {""} ;
         P00E33_n456ResponsavelEmail = new bool[] {false} ;
         P00E33_A436ResponsavelNome = new string[] {""} ;
         P00E33_n436ResponsavelNome = new bool[] {false} ;
         P00E33_A170ClienteRazaoSocial = new string[] {""} ;
         P00E33_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E33_A886ClienteCountNotas_F = new short[1] ;
         P00E33_n886ClienteCountNotas_F = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         GXt_char1 = "";
         AV58Session = context.GetSession();
         AV61GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV70TFClienteSituacao_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.wpclientesexport__default(),
            new Object[][] {
                new Object[] {
               P00E33_A192TipoClienteId, P00E33_n192TipoClienteId, P00E33_A186MunicipioCodigo, P00E33_n186MunicipioCodigo, P00E33_A444ResponsavelMunicipio, P00E33_n444ResponsavelMunicipio, P00E33_A402BancoId, P00E33_n402BancoId, P00E33_A437ResponsavelNacionalidade, P00E33_n437ResponsavelNacionalidade,
               P00E33_A484ClienteNacionalidade, P00E33_n484ClienteNacionalidade, P00E33_A442ResponsavelProfissao, P00E33_n442ResponsavelProfissao, P00E33_A487ClienteProfissao, P00E33_n487ClienteProfissao, P00E33_A489ClienteConvenio, P00E33_n489ClienteConvenio, P00E33_A168ClienteId, P00E33_A793TipoClientePortalPjPf,
               P00E33_n793TipoClientePortalPjPf, P00E33_A175ClienteCreatedAt, P00E33_n175ClienteCreatedAt, P00E33_A445ResponsavelMunicipioNome, P00E33_n445ResponsavelMunicipioNome, P00E33_A443ResponsavelProfissaoNome, P00E33_n443ResponsavelProfissaoNome, P00E33_A438ResponsavelNacionalidadeNome, P00E33_n438ResponsavelNacionalidadeNome, P00E33_A404BancoCodigo,
               P00E33_n404BancoCodigo, P00E33_A187MunicipioNome, P00E33_n187MunicipioNome, P00E33_A488ClienteProfissaoNome, P00E33_n488ClienteProfissaoNome, P00E33_A485ClienteNacionalidadeNome, P00E33_n485ClienteNacionalidadeNome, P00E33_A490ClienteConvenioDescricao, P00E33_n490ClienteConvenioDescricao, P00E33_A193TipoClienteDescricao,
               P00E33_n193TipoClienteDescricao, P00E33_A169ClienteDocumento, P00E33_n169ClienteDocumento, P00E33_A884ClienteSituacao, P00E33_n884ClienteSituacao, P00E33_A456ResponsavelEmail, P00E33_n456ResponsavelEmail, P00E33_A436ResponsavelNome, P00E33_n436ResponsavelNome, P00E33_A170ClienteRazaoSocial,
               P00E33_n170ClienteRazaoSocial, P00E33_A886ClienteCountNotas_F, P00E33_n886ClienteCountNotas_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV33DynamicFiltersOperator2 ;
      private short AV46DynamicFiltersOperator3 ;
      private short AV73TFClienteCountNotas_F ;
      private short AV74TFClienteCountNotas_F_To ;
      private short GXt_int2 ;
      private short AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 ;
      private short AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 ;
      private short AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 ;
      private short AV126Costumer_wpclientesds_49_tfclientecountnotas_f ;
      private short AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to ;
      private short AV16OrderedBy ;
      private short A886ClienteCountNotas_F ;
      private short A192TipoClienteId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV27BancoCodigo1 ;
      private int AV40BancoCodigo2 ;
      private int AV53BancoCodigo3 ;
      private int AV76GXV1 ;
      private int AV87Costumer_wpclientesds_10_bancocodigo1 ;
      private int AV100Costumer_wpclientesds_23_bancocodigo2 ;
      private int AV113Costumer_wpclientesds_36_bancocodigo3 ;
      private int AV125Costumer_wpclientesds_48_tfclientesituacao_sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A168ClienteId ;
      private int AV128GXV2 ;
      private long AV75i ;
      private string AV71TFClienteSituacao_Sel ;
      private string A884ClienteSituacao ;
      private string GXt_char1 ;
      private DateTime AV68TFClienteCreatedAt ;
      private DateTime AV69TFClienteCreatedAt_To ;
      private DateTime AV123Costumer_wpclientesds_46_tfclientecreatedat ;
      private DateTime AV124Costumer_wpclientesds_47_tfclientecreatedat_to ;
      private DateTime A175ClienteCreatedAt ;
      private bool returnInSub ;
      private bool AV31DynamicFiltersEnabled2 ;
      private bool AV44DynamicFiltersEnabled3 ;
      private bool AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 ;
      private bool AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool A793TipoClientePortalPjPf ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n168ClienteId ;
      private bool n793TipoClientePortalPjPf ;
      private bool n175ClienteCreatedAt ;
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
      private bool n884ClienteSituacao ;
      private bool n456ResponsavelEmail ;
      private bool n436ResponsavelNome ;
      private bool n170ClienteRazaoSocial ;
      private bool n886ClienteCountNotas_F ;
      private string AV70TFClienteSituacao_SelsJson ;
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
      private string AV63TFClienteRazaoSocial_Sel ;
      private string AV62TFClienteRazaoSocial ;
      private string AV65TFResponsavelNome_Sel ;
      private string AV64TFResponsavelNome ;
      private string AV67TFResponsavelEmail_Sel ;
      private string AV66TFResponsavelEmail ;
      private string AV78Costumer_wpclientesds_1_filterfulltext ;
      private string AV79Costumer_wpclientesds_2_dynamicfiltersselector1 ;
      private string AV81Costumer_wpclientesds_4_clientedocumento1 ;
      private string AV82Costumer_wpclientesds_5_tipoclientedescricao1 ;
      private string AV83Costumer_wpclientesds_6_clienteconveniodescricao1 ;
      private string AV84Costumer_wpclientesds_7_clientenacionalidadenome1 ;
      private string AV85Costumer_wpclientesds_8_clienteprofissaonome1 ;
      private string AV86Costumer_wpclientesds_9_municipionome1 ;
      private string AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 ;
      private string AV89Costumer_wpclientesds_12_responsavelprofissaonome1 ;
      private string AV90Costumer_wpclientesds_13_responsavelmunicipionome1 ;
      private string AV92Costumer_wpclientesds_15_dynamicfiltersselector2 ;
      private string AV94Costumer_wpclientesds_17_clientedocumento2 ;
      private string AV95Costumer_wpclientesds_18_tipoclientedescricao2 ;
      private string AV96Costumer_wpclientesds_19_clienteconveniodescricao2 ;
      private string AV97Costumer_wpclientesds_20_clientenacionalidadenome2 ;
      private string AV98Costumer_wpclientesds_21_clienteprofissaonome2 ;
      private string AV99Costumer_wpclientesds_22_municipionome2 ;
      private string AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 ;
      private string AV102Costumer_wpclientesds_25_responsavelprofissaonome2 ;
      private string AV103Costumer_wpclientesds_26_responsavelmunicipionome2 ;
      private string AV105Costumer_wpclientesds_28_dynamicfiltersselector3 ;
      private string AV107Costumer_wpclientesds_30_clientedocumento3 ;
      private string AV108Costumer_wpclientesds_31_tipoclientedescricao3 ;
      private string AV109Costumer_wpclientesds_32_clienteconveniodescricao3 ;
      private string AV110Costumer_wpclientesds_33_clientenacionalidadenome3 ;
      private string AV111Costumer_wpclientesds_34_clienteprofissaonome3 ;
      private string AV112Costumer_wpclientesds_35_municipionome3 ;
      private string AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 ;
      private string AV115Costumer_wpclientesds_38_responsavelprofissaonome3 ;
      private string AV116Costumer_wpclientesds_39_responsavelmunicipionome3 ;
      private string AV117Costumer_wpclientesds_40_tfclienterazaosocial ;
      private string AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel ;
      private string AV119Costumer_wpclientesds_42_tfresponsavelnome ;
      private string AV120Costumer_wpclientesds_43_tfresponsavelnome_sel ;
      private string AV121Costumer_wpclientesds_44_tfresponsavelemail ;
      private string AV122Costumer_wpclientesds_45_tfresponsavelemail_sel ;
      private string lV78Costumer_wpclientesds_1_filterfulltext ;
      private string lV81Costumer_wpclientesds_4_clientedocumento1 ;
      private string lV82Costumer_wpclientesds_5_tipoclientedescricao1 ;
      private string lV83Costumer_wpclientesds_6_clienteconveniodescricao1 ;
      private string lV84Costumer_wpclientesds_7_clientenacionalidadenome1 ;
      private string lV85Costumer_wpclientesds_8_clienteprofissaonome1 ;
      private string lV86Costumer_wpclientesds_9_municipionome1 ;
      private string lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 ;
      private string lV89Costumer_wpclientesds_12_responsavelprofissaonome1 ;
      private string lV90Costumer_wpclientesds_13_responsavelmunicipionome1 ;
      private string lV94Costumer_wpclientesds_17_clientedocumento2 ;
      private string lV95Costumer_wpclientesds_18_tipoclientedescricao2 ;
      private string lV96Costumer_wpclientesds_19_clienteconveniodescricao2 ;
      private string lV97Costumer_wpclientesds_20_clientenacionalidadenome2 ;
      private string lV98Costumer_wpclientesds_21_clienteprofissaonome2 ;
      private string lV99Costumer_wpclientesds_22_municipionome2 ;
      private string lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 ;
      private string lV102Costumer_wpclientesds_25_responsavelprofissaonome2 ;
      private string lV103Costumer_wpclientesds_26_responsavelmunicipionome2 ;
      private string lV107Costumer_wpclientesds_30_clientedocumento3 ;
      private string lV108Costumer_wpclientesds_31_tipoclientedescricao3 ;
      private string lV109Costumer_wpclientesds_32_clienteconveniodescricao3 ;
      private string lV110Costumer_wpclientesds_33_clientenacionalidadenome3 ;
      private string lV111Costumer_wpclientesds_34_clienteprofissaonome3 ;
      private string lV112Costumer_wpclientesds_35_municipionome3 ;
      private string lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 ;
      private string lV115Costumer_wpclientesds_38_responsavelprofissaonome3 ;
      private string lV116Costumer_wpclientesds_39_responsavelmunicipionome3 ;
      private string lV117Costumer_wpclientesds_40_tfclienterazaosocial ;
      private string lV119Costumer_wpclientesds_42_tfresponsavelnome ;
      private string lV121Costumer_wpclientesds_44_tfresponsavelemail ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A170ClienteRazaoSocial ;
      private string A436ResponsavelNome ;
      private string A456ResponsavelEmail ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private IGxSession AV58Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV60GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV57GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV72TFClienteSituacao_Sels ;
      private GxSimpleCollection<string> AV125Costumer_wpclientesds_48_tfclientesituacao_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00E33_A192TipoClienteId ;
      private bool[] P00E33_n192TipoClienteId ;
      private string[] P00E33_A186MunicipioCodigo ;
      private bool[] P00E33_n186MunicipioCodigo ;
      private string[] P00E33_A444ResponsavelMunicipio ;
      private bool[] P00E33_n444ResponsavelMunicipio ;
      private int[] P00E33_A402BancoId ;
      private bool[] P00E33_n402BancoId ;
      private int[] P00E33_A437ResponsavelNacionalidade ;
      private bool[] P00E33_n437ResponsavelNacionalidade ;
      private int[] P00E33_A484ClienteNacionalidade ;
      private bool[] P00E33_n484ClienteNacionalidade ;
      private int[] P00E33_A442ResponsavelProfissao ;
      private bool[] P00E33_n442ResponsavelProfissao ;
      private int[] P00E33_A487ClienteProfissao ;
      private bool[] P00E33_n487ClienteProfissao ;
      private int[] P00E33_A489ClienteConvenio ;
      private bool[] P00E33_n489ClienteConvenio ;
      private int[] P00E33_A168ClienteId ;
      private bool[] P00E33_n168ClienteId ;
      private bool[] P00E33_A793TipoClientePortalPjPf ;
      private bool[] P00E33_n793TipoClientePortalPjPf ;
      private DateTime[] P00E33_A175ClienteCreatedAt ;
      private bool[] P00E33_n175ClienteCreatedAt ;
      private string[] P00E33_A445ResponsavelMunicipioNome ;
      private bool[] P00E33_n445ResponsavelMunicipioNome ;
      private string[] P00E33_A443ResponsavelProfissaoNome ;
      private bool[] P00E33_n443ResponsavelProfissaoNome ;
      private string[] P00E33_A438ResponsavelNacionalidadeNome ;
      private bool[] P00E33_n438ResponsavelNacionalidadeNome ;
      private int[] P00E33_A404BancoCodigo ;
      private bool[] P00E33_n404BancoCodigo ;
      private string[] P00E33_A187MunicipioNome ;
      private bool[] P00E33_n187MunicipioNome ;
      private string[] P00E33_A488ClienteProfissaoNome ;
      private bool[] P00E33_n488ClienteProfissaoNome ;
      private string[] P00E33_A485ClienteNacionalidadeNome ;
      private bool[] P00E33_n485ClienteNacionalidadeNome ;
      private string[] P00E33_A490ClienteConvenioDescricao ;
      private bool[] P00E33_n490ClienteConvenioDescricao ;
      private string[] P00E33_A193TipoClienteDescricao ;
      private bool[] P00E33_n193TipoClienteDescricao ;
      private string[] P00E33_A169ClienteDocumento ;
      private bool[] P00E33_n169ClienteDocumento ;
      private string[] P00E33_A884ClienteSituacao ;
      private bool[] P00E33_n884ClienteSituacao ;
      private string[] P00E33_A456ResponsavelEmail ;
      private bool[] P00E33_n456ResponsavelEmail ;
      private string[] P00E33_A436ResponsavelNome ;
      private bool[] P00E33_n436ResponsavelNome ;
      private string[] P00E33_A170ClienteRazaoSocial ;
      private bool[] P00E33_n170ClienteRazaoSocial ;
      private short[] P00E33_A886ClienteCountNotas_F ;
      private bool[] P00E33_n886ClienteCountNotas_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV61GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wpclientesexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E33( IGxContext context ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV125Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                             string AV79Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                             short AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                             string AV81Costumer_wpclientesds_4_clientedocumento1 ,
                                             string AV82Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                             string AV83Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                             string AV84Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                             string AV85Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                             string AV86Costumer_wpclientesds_9_municipionome1 ,
                                             int AV87Costumer_wpclientesds_10_bancocodigo1 ,
                                             string AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                             string AV89Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                             string AV90Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                             bool AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                             string AV92Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                             short AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                             string AV94Costumer_wpclientesds_17_clientedocumento2 ,
                                             string AV95Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                             string AV96Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                             string AV97Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                             string AV98Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                             string AV99Costumer_wpclientesds_22_municipionome2 ,
                                             int AV100Costumer_wpclientesds_23_bancocodigo2 ,
                                             string AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                             string AV102Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                             string AV103Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                             bool AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                             string AV105Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                             short AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                             string AV107Costumer_wpclientesds_30_clientedocumento3 ,
                                             string AV108Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                             string AV109Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                             string AV110Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                             string AV111Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                             string AV112Costumer_wpclientesds_35_municipionome3 ,
                                             int AV113Costumer_wpclientesds_36_bancocodigo3 ,
                                             string AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                             string AV115Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                             string AV116Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                             string AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                             string AV117Costumer_wpclientesds_40_tfclienterazaosocial ,
                                             string AV120Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                             string AV119Costumer_wpclientesds_42_tfresponsavelnome ,
                                             string AV122Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                             string AV121Costumer_wpclientesds_44_tfresponsavelemail ,
                                             DateTime AV123Costumer_wpclientesds_46_tfclientecreatedat ,
                                             DateTime AV124Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                             int AV125Costumer_wpclientesds_48_tfclientesituacao_sels_Count ,
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
                                             string A170ClienteRazaoSocial ,
                                             string A436ResponsavelNome ,
                                             string A456ResponsavelEmail ,
                                             DateTime A175ClienteCreatedAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV78Costumer_wpclientesds_1_filterfulltext ,
                                             short A886ClienteCountNotas_F ,
                                             short AV126Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                             short AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                             bool A793TipoClientePortalPjPf )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[83];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T2.TipoClientePortalPjPf, T1.ClienteCreatedAt, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteSituacao, T1.ResponsavelEmail, T1.ResponsavelNome, T1.ClienteRazaoSocial, COALESCE( T11.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM ((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE T1.ClienteId = ClienteId GROUP BY ClienteId ) T11 ON T11.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV78Costumer_wpclientesds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV78Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelNome like '%' || :lV78Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelEmail like '%' || :lV78Costumer_wpclientesds_1_filterfulltext) or ( 'aguardando análise' like '%' || LOWER(:lV78Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'P')) or ( 'aprovado' like '%' || LOWER(:lV78Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'A')) or ( 'rejeitado' like '%' || LOWER(:lV78Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'R')) or ( SUBSTR(TO_CHAR(COALESCE( T11.ClienteCountNotas_F, 0),'9999'), 2) like '%' || :lV78Costumer_wpclientesds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV126Costumer_wpclientesds_49_tfclientecountnotas_f = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) >= :AV126Costumer_wpclientesds_49_tfclientecountnotas_f))");
         AddWhere(sWhereString, "((:AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) <= :AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to))");
         AddWhere(sWhereString, "(T2.TipoClientePortalPjPf)");
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV81Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV81Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV82Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV82Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV83Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV83Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV84Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV84Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV85Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV85Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV87Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV87Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV87Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV87Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV87Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV87Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV89Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV89Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV90Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV80Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV90Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV94Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV94Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV95Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV95Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV96Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV96Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV97Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV97Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV98Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV98Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV99Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV99Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV100Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV100Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV100Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV100Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV100Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV100Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV102Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV102Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV103Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( AV91Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV93Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV103Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV107Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV107Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV108Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV108Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV109Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV109Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV110Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV110Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV111Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV111Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV112Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV112Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV113Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV113Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV113Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV113Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV113Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV113Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV115Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV115Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV116Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV104Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV105Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV106Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV116Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_40_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV117Costumer_wpclientesds_40_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( StringUtil.StrCmp(AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_42_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV119Costumer_wpclientesds_42_tfresponsavelnome)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV120Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV120Costumer_wpclientesds_43_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( StringUtil.StrCmp(AV120Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_44_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV121Costumer_wpclientesds_44_tfresponsavelemail)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV122Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV122Costumer_wpclientesds_45_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( StringUtil.StrCmp(AV122Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( ! (DateTime.MinValue==AV123Costumer_wpclientesds_46_tfclientecreatedat) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt >= :AV123Costumer_wpclientesds_46_tfclientecreatedat)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Costumer_wpclientesds_47_tfclientecreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt <= :AV124Costumer_wpclientesds_47_tfclientecreatedat_to)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV125Costumer_wpclientesds_48_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV125Costumer_wpclientesds_48_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.ClienteDocumento";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ResponsavelNome DESC";
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
            scmdbuf += " ORDER BY T1.ClienteCreatedAt";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ClienteSituacao DESC";
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
                     return conditional_P00E33(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (DateTime)dynConstraints[46] , (DateTime)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (int)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (DateTime)dynConstraints[62] , (short)dynConstraints[63] , (bool)dynConstraints[64] , (string)dynConstraints[65] , (short)dynConstraints[66] , (short)dynConstraints[67] , (short)dynConstraints[68] , (bool)dynConstraints[69] );
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
          Object[] prmP00E33;
          prmP00E33 = new Object[] {
          new ParDef("AV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV126Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV126Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("AV127Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("lV81Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV81Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV82Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV82Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV83Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV83Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV84Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV84Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV85Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV86Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV86Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV87Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV87Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV87Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV88Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV89Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV89Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV90Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV90Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV94Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV94Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV95Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV95Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV96Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV96Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV97Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV97Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV98Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV98Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV99Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV99Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV100Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV100Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV100Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV101Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV102Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV102Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV103Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV103Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV107Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV107Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV108Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV108Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV109Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV109Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV110Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV110Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV111Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV111Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV112Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV112Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV113Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV113Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV113Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV114Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV115Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV115Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV116Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV116Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV117Costumer_wpclientesds_40_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV118Costumer_wpclientesds_41_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV119Costumer_wpclientesds_42_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV120Costumer_wpclientesds_43_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV121Costumer_wpclientesds_44_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV122Costumer_wpclientesds_45_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV123Costumer_wpclientesds_46_tfclientecreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV124Costumer_wpclientesds_47_tfclientecreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00E33", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E33,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getString(23, 1);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
       }
    }

 }

}
