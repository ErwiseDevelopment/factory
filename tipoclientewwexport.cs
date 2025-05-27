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
   public class tipoclientewwexport : GXProcedure
   {
      public tipoclientewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipoclientewwexport( IGxContext context )
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
         AV13Filename = GXt_char1 + "TipoClienteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV22DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV23TipoClienteDescricao1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TipoClienteDescricao1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23TipoClienteDescricao1, out  GXt_char1) ;
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV27TipoClienteDescricao2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TipoClienteDescricao2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27TipoClienteDescricao2, out  GXt_char1) ;
                     AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31TipoClienteDescricao3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TipoClienteDescricao3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31TipoClienteDescricao3, out  GXt_char1) ;
                        AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTipoClienteDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Descrição") ;
            AV15CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTipoClienteDescricao_Sel)) ? "(Vazio)" : AV49TFTipoClienteDescricao_Sel), out  GXt_char1) ;
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTipoClienteDescricao)) ) )
            {
               GXt_int2 = (short)(AV15CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Descrição") ;
               AV15CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFTipoClienteDescricao, out  GXt_char1) ;
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV52TFTipoClienteTipoPessoa_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Tipo Pessoa") ;
            AV15CellRow = GXt_int2;
            AV53i = 1;
            AV55GXV1 = 1;
            while ( AV55GXV1 <= AV52TFTipoClienteTipoPessoa_Sels.Count )
            {
               AV51TFTipoClienteTipoPessoa_Sel = ((string)AV52TFTipoClienteTipoPessoa_Sels.Item(AV55GXV1));
               if ( AV53i == 1 )
               {
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text+", ";
               }
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text+gxdomaindmtipopessoa.getDescription(context,AV51TFTipoClienteTipoPessoa_Sel);
               AV53i = (long)(AV53i+1);
               AV55GXV1 = (int)(AV55GXV1+1);
            }
         }
         if ( ! ( (0==AV54TFTipoClientePortal_Sel) ) )
         {
            GXt_int2 = (short)(AV15CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV12ExcelDocument,  true, ref  GXt_int2,  (short)(AV16FirstColumn),  "Acesso ao portal clinica") ;
            AV15CellRow = GXt_int2;
            if ( AV54TFTipoClientePortal_Sel == 1 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV54TFTipoClientePortal_Sel == 2 )
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
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+0, 1, 1).Text = "Descrição";
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = "Tipo Pessoa";
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Bold = 1;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Color = 11;
         AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Text = "Acesso ao portal clinica";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Tipoclientewwds_1_filterfulltext = AV20FilterFullText;
         AV58Tipoclientewwds_2_dynamicfiltersselector1 = AV21DynamicFiltersSelector1;
         AV59Tipoclientewwds_3_dynamicfiltersoperator1 = AV22DynamicFiltersOperator1;
         AV60Tipoclientewwds_4_tipoclientedescricao1 = AV23TipoClienteDescricao1;
         AV61Tipoclientewwds_5_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV62Tipoclientewwds_6_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV63Tipoclientewwds_7_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV64Tipoclientewwds_8_tipoclientedescricao2 = AV27TipoClienteDescricao2;
         AV65Tipoclientewwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV66Tipoclientewwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV67Tipoclientewwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV68Tipoclientewwds_12_tipoclientedescricao3 = AV31TipoClienteDescricao3;
         AV69Tipoclientewwds_13_tftipoclientedescricao = AV48TFTipoClienteDescricao;
         AV70Tipoclientewwds_14_tftipoclientedescricao_sel = AV49TFTipoClienteDescricao_Sel;
         AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV52TFTipoClienteTipoPessoa_Sels;
         AV72Tipoclientewwds_16_tftipoclienteportal_sel = AV54TFTipoClientePortal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A194TipoClienteTipoPessoa ,
                                              AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                              AV57Tipoclientewwds_1_filterfulltext ,
                                              AV58Tipoclientewwds_2_dynamicfiltersselector1 ,
                                              AV59Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                              AV60Tipoclientewwds_4_tipoclientedescricao1 ,
                                              AV61Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                              AV62Tipoclientewwds_6_dynamicfiltersselector2 ,
                                              AV63Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                              AV64Tipoclientewwds_8_tipoclientedescricao2 ,
                                              AV65Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                              AV66Tipoclientewwds_10_dynamicfiltersselector3 ,
                                              AV67Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                              AV68Tipoclientewwds_12_tipoclientedescricao3 ,
                                              AV70Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                              AV69Tipoclientewwds_13_tftipoclientedescricao ,
                                              AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels.Count ,
                                              AV72Tipoclientewwds_16_tftipoclienteportal_sel ,
                                              A193TipoClienteDescricao ,
                                              A207TipoClientePortal ,
                                              AV18OrderedBy ,
                                              AV19OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Tipoclientewwds_1_filterfulltext), "%", "");
         lV57Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Tipoclientewwds_1_filterfulltext), "%", "");
         lV57Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Tipoclientewwds_1_filterfulltext), "%", "");
         lV57Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Tipoclientewwds_1_filterfulltext), "%", "");
         lV57Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Tipoclientewwds_1_filterfulltext), "%", "");
         lV60Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV60Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV60Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV60Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV64Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV64Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV64Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV64Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV68Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV68Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV68Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV68Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV69Tipoclientewwds_13_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV69Tipoclientewwds_13_tftipoclientedescricao), "%", "");
         /* Using cursor P00632 */
         pr_default.execute(0, new Object[] {lV57Tipoclientewwds_1_filterfulltext, lV57Tipoclientewwds_1_filterfulltext, lV57Tipoclientewwds_1_filterfulltext, lV57Tipoclientewwds_1_filterfulltext, lV57Tipoclientewwds_1_filterfulltext, lV60Tipoclientewwds_4_tipoclientedescricao1, lV60Tipoclientewwds_4_tipoclientedescricao1, lV64Tipoclientewwds_8_tipoclientedescricao2, lV64Tipoclientewwds_8_tipoclientedescricao2, lV68Tipoclientewwds_12_tipoclientedescricao3, lV68Tipoclientewwds_12_tipoclientedescricao3, lV69Tipoclientewwds_13_tftipoclientedescricao, AV70Tipoclientewwds_14_tftipoclientedescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A207TipoClientePortal = P00632_A207TipoClientePortal[0];
            n207TipoClientePortal = P00632_n207TipoClientePortal[0];
            A194TipoClienteTipoPessoa = P00632_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = P00632_n194TipoClienteTipoPessoa[0];
            A193TipoClienteDescricao = P00632_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00632_n193TipoClienteDescricao[0];
            A192TipoClienteId = P00632_A192TipoClienteId[0];
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
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+1, 1, 1).Text = gxdomaindmtipopessoa.getDescription(context,A194TipoClienteTipoPessoa);
            AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A207TipoClientePortal)), "true") == 0 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Text = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A207TipoClientePortal)), "false") == 0 )
            {
               AV12ExcelDocument.get_Cells(AV15CellRow, AV16FirstColumn+2, 1, 1).Text = "Não";
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
         AV33Session.Set("WWPExportFileName", "TipoClienteWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV33Session.Get("TipoClienteWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoClienteWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("TipoClienteWWGridState"), null, "", "");
         }
         AV18OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV19OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV73GXV2 = 1;
         while ( AV73GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV73GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV48TFTipoClienteDescricao = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV49TFTipoClienteDescricao_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV50TFTipoClienteTipoPessoa_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV52TFTipoClienteTipoPessoa_Sels.FromJSonString(AV50TFTipoClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEPORTAL_SEL") == 0 )
            {
               AV54TFTipoClientePortal_Sel = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV73GXV2 = (int)(AV73GXV2+1);
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
         AV23TipoClienteDescricao1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27TipoClienteDescricao2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31TipoClienteDescricao3 = "";
         AV49TFTipoClienteDescricao_Sel = "";
         AV48TFTipoClienteDescricao = "";
         AV52TFTipoClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV51TFTipoClienteTipoPessoa_Sel = "";
         AV57Tipoclientewwds_1_filterfulltext = "";
         AV58Tipoclientewwds_2_dynamicfiltersselector1 = "";
         AV60Tipoclientewwds_4_tipoclientedescricao1 = "";
         AV62Tipoclientewwds_6_dynamicfiltersselector2 = "";
         AV64Tipoclientewwds_8_tipoclientedescricao2 = "";
         AV66Tipoclientewwds_10_dynamicfiltersselector3 = "";
         AV68Tipoclientewwds_12_tipoclientedescricao3 = "";
         AV69Tipoclientewwds_13_tftipoclientedescricao = "";
         AV70Tipoclientewwds_14_tftipoclientedescricao_sel = "";
         AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV57Tipoclientewwds_1_filterfulltext = "";
         lV60Tipoclientewwds_4_tipoclientedescricao1 = "";
         lV64Tipoclientewwds_8_tipoclientedescricao2 = "";
         lV68Tipoclientewwds_12_tipoclientedescricao3 = "";
         lV69Tipoclientewwds_13_tftipoclientedescricao = "";
         A194TipoClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         P00632_A207TipoClientePortal = new bool[] {false} ;
         P00632_n207TipoClientePortal = new bool[] {false} ;
         P00632_A194TipoClienteTipoPessoa = new string[] {""} ;
         P00632_n194TipoClienteTipoPessoa = new bool[] {false} ;
         P00632_A193TipoClienteDescricao = new string[] {""} ;
         P00632_n193TipoClienteDescricao = new bool[] {false} ;
         P00632_A192TipoClienteId = new short[1] ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50TFTipoClienteTipoPessoa_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoclientewwexport__default(),
            new Object[][] {
                new Object[] {
               P00632_A207TipoClientePortal, P00632_n207TipoClientePortal, P00632_A194TipoClienteTipoPessoa, P00632_n194TipoClienteTipoPessoa, P00632_A193TipoClienteDescricao, P00632_n193TipoClienteDescricao, P00632_A192TipoClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV54TFTipoClientePortal_Sel ;
      private short GXt_int2 ;
      private short AV59Tipoclientewwds_3_dynamicfiltersoperator1 ;
      private short AV63Tipoclientewwds_7_dynamicfiltersoperator2 ;
      private short AV67Tipoclientewwds_11_dynamicfiltersoperator3 ;
      private short AV72Tipoclientewwds_16_tftipoclienteportal_sel ;
      private short AV18OrderedBy ;
      private short A192TipoClienteId ;
      private int AV15CellRow ;
      private int AV16FirstColumn ;
      private int AV17Random ;
      private int AV55GXV1 ;
      private int AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ;
      private int AV73GXV2 ;
      private long AV53i ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV61Tipoclientewwds_5_dynamicfiltersenabled2 ;
      private bool AV65Tipoclientewwds_9_dynamicfiltersenabled3 ;
      private bool A207TipoClientePortal ;
      private bool AV19OrderedDsc ;
      private bool n207TipoClientePortal ;
      private bool n194TipoClienteTipoPessoa ;
      private bool n193TipoClienteDescricao ;
      private string AV50TFTipoClienteTipoPessoa_SelsJson ;
      private string AV13Filename ;
      private string AV14ErrorMessage ;
      private string AV20FilterFullText ;
      private string AV21DynamicFiltersSelector1 ;
      private string AV23TipoClienteDescricao1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV27TipoClienteDescricao2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV31TipoClienteDescricao3 ;
      private string AV49TFTipoClienteDescricao_Sel ;
      private string AV48TFTipoClienteDescricao ;
      private string AV51TFTipoClienteTipoPessoa_Sel ;
      private string AV57Tipoclientewwds_1_filterfulltext ;
      private string AV58Tipoclientewwds_2_dynamicfiltersselector1 ;
      private string AV60Tipoclientewwds_4_tipoclientedescricao1 ;
      private string AV62Tipoclientewwds_6_dynamicfiltersselector2 ;
      private string AV64Tipoclientewwds_8_tipoclientedescricao2 ;
      private string AV66Tipoclientewwds_10_dynamicfiltersselector3 ;
      private string AV68Tipoclientewwds_12_tipoclientedescricao3 ;
      private string AV69Tipoclientewwds_13_tftipoclientedescricao ;
      private string AV70Tipoclientewwds_14_tftipoclientedescricao_sel ;
      private string lV57Tipoclientewwds_1_filterfulltext ;
      private string lV60Tipoclientewwds_4_tipoclientedescricao1 ;
      private string lV64Tipoclientewwds_8_tipoclientedescricao2 ;
      private string lV68Tipoclientewwds_12_tipoclientedescricao3 ;
      private string lV69Tipoclientewwds_13_tftipoclientedescricao ;
      private string A194TipoClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private IGxSession AV33Session ;
      private ExcelDocumentI AV12ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV52TFTipoClienteTipoPessoa_Sels ;
      private GxSimpleCollection<string> AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] P00632_A207TipoClientePortal ;
      private bool[] P00632_n207TipoClientePortal ;
      private string[] P00632_A194TipoClienteTipoPessoa ;
      private bool[] P00632_n194TipoClienteTipoPessoa ;
      private string[] P00632_A193TipoClienteDescricao ;
      private bool[] P00632_n193TipoClienteDescricao ;
      private short[] P00632_A192TipoClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class tipoclientewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00632( IGxContext context ,
                                             string A194TipoClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                             string AV57Tipoclientewwds_1_filterfulltext ,
                                             string AV58Tipoclientewwds_2_dynamicfiltersselector1 ,
                                             short AV59Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV60Tipoclientewwds_4_tipoclientedescricao1 ,
                                             bool AV61Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                             string AV62Tipoclientewwds_6_dynamicfiltersselector2 ,
                                             short AV63Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                             string AV64Tipoclientewwds_8_tipoclientedescricao2 ,
                                             bool AV65Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                             string AV66Tipoclientewwds_10_dynamicfiltersselector3 ,
                                             short AV67Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                             string AV68Tipoclientewwds_12_tipoclientedescricao3 ,
                                             string AV70Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                             string AV69Tipoclientewwds_13_tftipoclientedescricao ,
                                             int AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ,
                                             short AV72Tipoclientewwds_16_tftipoclienteportal_sel ,
                                             string A193TipoClienteDescricao ,
                                             bool A207TipoClientePortal ,
                                             short AV18OrderedBy ,
                                             bool AV19OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TipoClientePortal, TipoClienteTipoPessoa, TipoClienteDescricao, TipoClienteId FROM TipoCliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Tipoclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TipoClienteDescricao like '%' || :lV57Tipoclientewwds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV57Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV57Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'JURIDICA')) or ( 'sim' like '%' || LOWER(:lV57Tipoclientewwds_1_filterfulltext) and TipoClientePortal = TRUE) or ( 'não' like '%' || LOWER(:lV57Tipoclientewwds_1_filterfulltext) and TipoClientePortal = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV59Tipoclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV60Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV59Tipoclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV60Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV61Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV63Tipoclientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV64Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV61Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV63Tipoclientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV64Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV65Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV67Tipoclientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV68Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV65Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV67Tipoclientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV68Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Tipoclientewwds_14_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Tipoclientewwds_13_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV69Tipoclientewwds_13_tftipoclientedescricao)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Tipoclientewwds_14_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV70Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao = ( :AV70Tipoclientewwds_14_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV70Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from TipoClienteDescricao))=0))");
         }
         if ( AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71Tipoclientewwds_15_tftipoclientetipopessoa_sels, "TipoClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV72Tipoclientewwds_16_tftipoclienteportal_sel == 1 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = TRUE)");
         }
         if ( AV72Tipoclientewwds_16_tftipoclienteportal_sel == 2 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV18OrderedBy == 1 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoClienteDescricao";
         }
         else if ( ( AV18OrderedBy == 1 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoClienteDescricao DESC";
         }
         else if ( ( AV18OrderedBy == 2 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoClienteTipoPessoa";
         }
         else if ( ( AV18OrderedBy == 2 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoClienteTipoPessoa DESC";
         }
         else if ( ( AV18OrderedBy == 3 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoClientePortal";
         }
         else if ( ( AV18OrderedBy == 3 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoClientePortal DESC";
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
                     return conditional_P00632(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00632;
          prmP00632 = new Object[] {
          new ParDef("lV57Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV60Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV64Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV64Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV68Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV69Tipoclientewwds_13_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV70Tipoclientewwds_14_tftipoclientedescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
