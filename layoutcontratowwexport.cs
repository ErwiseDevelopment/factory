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
   public class layoutcontratowwexport : GXProcedure
   {
      public layoutcontratowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public layoutcontratowwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
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
         AV14CellRow = 1;
         AV15FirstColumn = 1;
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
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "LayoutContratoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Filtro principal") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "LAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22LayoutContratoDescricao1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22LayoutContratoDescricao1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22LayoutContratoDescricao1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LAYOUTCONTRATODESCRICAO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26LayoutContratoDescricao2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26LayoutContratoDescricao2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26LayoutContratoDescricao2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "LAYOUTCONTRATODESCRICAO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30LayoutContratoDescricao3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30LayoutContratoDescricao3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30LayoutContratoDescricao3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFLayoutContratoDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV37TFLayoutContratoDescricao_Sel)) ? "(Vazio)" : AV37TFLayoutContratoDescricao_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFLayoutContratoDescricao)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFLayoutContratoDescricao, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV38TFLayoutContratoStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ativo") ;
            AV14CellRow = GXt_int2;
            if ( AV38TFLayoutContratoStatus_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV38TFLayoutContratoStatus_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( ( AV58TFLayoutContratoTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
            AV14CellRow = GXt_int2;
            AV54i = 1;
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV58TFLayoutContratoTipo_Sels.Count )
            {
               AV57TFLayoutContratoTipo_Sel = ((string)AV58TFLayoutContratoTipo_Sels.Item(AV61GXV1));
               if ( AV54i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+gxdomaintipolayout.getDescription(context,AV57TFLayoutContratoTipo_Sel);
               AV54i = (long)(AV54i+1);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFLayoutContratoTag_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tag") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFLayoutContratoTag_Sel)) ? "(Vazio)" : AV60TFLayoutContratoTag_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFLayoutContratoTag)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tag") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFLayoutContratoTag, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Descrição";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Ativo";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = "Tipo";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "Tag";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV63Layoutcontratowwds_1_filterfulltext = AV19FilterFullText;
         AV64Layoutcontratowwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Layoutcontratowwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Layoutcontratowwds_4_layoutcontratodescricao1 = AV22LayoutContratoDescricao1;
         AV67Layoutcontratowwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Layoutcontratowwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Layoutcontratowwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Layoutcontratowwds_8_layoutcontratodescricao2 = AV26LayoutContratoDescricao2;
         AV71Layoutcontratowwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Layoutcontratowwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Layoutcontratowwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Layoutcontratowwds_12_layoutcontratodescricao3 = AV30LayoutContratoDescricao3;
         AV75Layoutcontratowwds_13_tflayoutcontratodescricao = AV36TFLayoutContratoDescricao;
         AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV37TFLayoutContratoDescricao_Sel;
         AV77Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV38TFLayoutContratoStatus_Sel;
         AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV58TFLayoutContratoTipo_Sels;
         AV79Layoutcontratowwds_17_tflayoutcontratotag = AV59TFLayoutContratoTag;
         AV80Layoutcontratowwds_18_tflayoutcontratotag_sel = AV60TFLayoutContratoTag_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A906LayoutContratoTipo ,
                                              AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                              AV63Layoutcontratowwds_1_filterfulltext ,
                                              AV64Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                              AV65Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                              AV66Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                              AV67Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                              AV68Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                              AV69Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                              AV70Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                              AV71Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                              AV72Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                              AV73Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                              AV74Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                              AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                              AV75Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                              AV77Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                              AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels.Count ,
                                              AV80Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                              AV79Layoutcontratowwds_17_tflayoutcontratotag ,
                                              A155LayoutContratoDescricao ,
                                              A156LayoutContratoStatus ,
                                              A1000LayoutContratoTag ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV63Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext), "%", "");
         lV66Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV66Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV66Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV70Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV70Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV74Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV74Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV74Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV74Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV75Layoutcontratowwds_13_tflayoutcontratodescricao = StringUtil.Concat( StringUtil.RTrim( AV75Layoutcontratowwds_13_tflayoutcontratodescricao), "%", "");
         lV79Layoutcontratowwds_17_tflayoutcontratotag = StringUtil.Concat( StringUtil.RTrim( AV79Layoutcontratowwds_17_tflayoutcontratotag), "%", "");
         /* Using cursor P005F2 */
         pr_default.execute(0, new Object[] {lV63Layoutcontratowwds_1_filterfulltext, lV63Layoutcontratowwds_1_filterfulltext, lV63Layoutcontratowwds_1_filterfulltext, lV63Layoutcontratowwds_1_filterfulltext, lV63Layoutcontratowwds_1_filterfulltext, lV63Layoutcontratowwds_1_filterfulltext, lV63Layoutcontratowwds_1_filterfulltext, lV66Layoutcontratowwds_4_layoutcontratodescricao1, lV66Layoutcontratowwds_4_layoutcontratodescricao1, lV70Layoutcontratowwds_8_layoutcontratodescricao2, lV70Layoutcontratowwds_8_layoutcontratodescricao2, lV74Layoutcontratowwds_12_layoutcontratodescricao3, lV74Layoutcontratowwds_12_layoutcontratodescricao3, lV75Layoutcontratowwds_13_tflayoutcontratodescricao, AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel, lV79Layoutcontratowwds_17_tflayoutcontratotag, AV80Layoutcontratowwds_18_tflayoutcontratotag_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1000LayoutContratoTag = P005F2_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = P005F2_n1000LayoutContratoTag[0];
            A906LayoutContratoTipo = P005F2_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = P005F2_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = P005F2_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = P005F2_n156LayoutContratoStatus[0];
            A155LayoutContratoDescricao = P005F2_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = P005F2_n155LayoutContratoDescricao[0];
            A154LayoutContratoId = P005F2_A154LayoutContratoId[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A155LayoutContratoDescricao, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A156LayoutContratoStatus)), "true") == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A156LayoutContratoStatus)), "false") == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Não";
            }
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = gxdomaintipolayout.getDescription(context,A906LayoutContratoTipo);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1000LayoutContratoTag, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = GXt_char1;
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
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "LayoutContratoWWExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("LayoutContratoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "LayoutContratoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("LayoutContratoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV81GXV2 = 1;
         while ( AV81GXV2 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV81GXV2));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV36TFLayoutContratoDescricao = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO_SEL") == 0 )
            {
               AV37TFLayoutContratoDescricao_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOSTATUS_SEL") == 0 )
            {
               AV38TFLayoutContratoStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTIPO_SEL") == 0 )
            {
               AV56TFLayoutContratoTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV58TFLayoutContratoTipo_Sels.FromJSonString(AV56TFLayoutContratoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG") == 0 )
            {
               AV59TFLayoutContratoTag = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG_SEL") == 0 )
            {
               AV60TFLayoutContratoTag_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV81GXV2 = (int)(AV81GXV2+1);
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22LayoutContratoDescricao1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26LayoutContratoDescricao2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30LayoutContratoDescricao3 = "";
         AV37TFLayoutContratoDescricao_Sel = "";
         AV36TFLayoutContratoDescricao = "";
         AV58TFLayoutContratoTipo_Sels = new GxSimpleCollection<string>();
         AV57TFLayoutContratoTipo_Sel = "";
         AV60TFLayoutContratoTag_Sel = "";
         AV59TFLayoutContratoTag = "";
         AV63Layoutcontratowwds_1_filterfulltext = "";
         AV64Layoutcontratowwds_2_dynamicfiltersselector1 = "";
         AV66Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         AV68Layoutcontratowwds_6_dynamicfiltersselector2 = "";
         AV70Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         AV72Layoutcontratowwds_10_dynamicfiltersselector3 = "";
         AV74Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         AV75Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel = "";
         AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels = new GxSimpleCollection<string>();
         AV79Layoutcontratowwds_17_tflayoutcontratotag = "";
         AV80Layoutcontratowwds_18_tflayoutcontratotag_sel = "";
         lV63Layoutcontratowwds_1_filterfulltext = "";
         lV66Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         lV70Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         lV74Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         lV75Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         lV79Layoutcontratowwds_17_tflayoutcontratotag = "";
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         A1000LayoutContratoTag = "";
         P005F2_A1000LayoutContratoTag = new string[] {""} ;
         P005F2_n1000LayoutContratoTag = new bool[] {false} ;
         P005F2_A906LayoutContratoTipo = new string[] {""} ;
         P005F2_n906LayoutContratoTipo = new bool[] {false} ;
         P005F2_A156LayoutContratoStatus = new bool[] {false} ;
         P005F2_n156LayoutContratoStatus = new bool[] {false} ;
         P005F2_A155LayoutContratoDescricao = new string[] {""} ;
         P005F2_n155LayoutContratoDescricao = new bool[] {false} ;
         P005F2_A154LayoutContratoId = new short[1] ;
         GXt_char1 = "";
         AV32Session = context.GetSession();
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56TFLayoutContratoTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.layoutcontratowwexport__default(),
            new Object[][] {
                new Object[] {
               P005F2_A1000LayoutContratoTag, P005F2_n1000LayoutContratoTag, P005F2_A906LayoutContratoTipo, P005F2_n906LayoutContratoTipo, P005F2_A156LayoutContratoStatus, P005F2_n156LayoutContratoStatus, P005F2_A155LayoutContratoDescricao, P005F2_n155LayoutContratoDescricao, P005F2_A154LayoutContratoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV38TFLayoutContratoStatus_Sel ;
      private short GXt_int2 ;
      private short AV65Layoutcontratowwds_3_dynamicfiltersoperator1 ;
      private short AV69Layoutcontratowwds_7_dynamicfiltersoperator2 ;
      private short AV73Layoutcontratowwds_11_dynamicfiltersoperator3 ;
      private short AV77Layoutcontratowwds_15_tflayoutcontratostatus_sel ;
      private short AV17OrderedBy ;
      private short A154LayoutContratoId ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV61GXV1 ;
      private int AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ;
      private int AV81GXV2 ;
      private long AV54i ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV67Layoutcontratowwds_5_dynamicfiltersenabled2 ;
      private bool AV71Layoutcontratowwds_9_dynamicfiltersenabled3 ;
      private bool A156LayoutContratoStatus ;
      private bool AV18OrderedDsc ;
      private bool n1000LayoutContratoTag ;
      private bool n906LayoutContratoTipo ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private string AV56TFLayoutContratoTipo_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22LayoutContratoDescricao1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26LayoutContratoDescricao2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30LayoutContratoDescricao3 ;
      private string AV37TFLayoutContratoDescricao_Sel ;
      private string AV36TFLayoutContratoDescricao ;
      private string AV57TFLayoutContratoTipo_Sel ;
      private string AV60TFLayoutContratoTag_Sel ;
      private string AV59TFLayoutContratoTag ;
      private string AV63Layoutcontratowwds_1_filterfulltext ;
      private string AV64Layoutcontratowwds_2_dynamicfiltersselector1 ;
      private string AV66Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string AV68Layoutcontratowwds_6_dynamicfiltersselector2 ;
      private string AV70Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string AV72Layoutcontratowwds_10_dynamicfiltersselector3 ;
      private string AV74Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string AV75Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel ;
      private string AV79Layoutcontratowwds_17_tflayoutcontratotag ;
      private string AV80Layoutcontratowwds_18_tflayoutcontratotag_sel ;
      private string lV63Layoutcontratowwds_1_filterfulltext ;
      private string lV66Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string lV70Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string lV74Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string lV75Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string lV79Layoutcontratowwds_17_tflayoutcontratotag ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private string A1000LayoutContratoTag ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV58TFLayoutContratoTipo_Sels ;
      private GxSimpleCollection<string> AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P005F2_A1000LayoutContratoTag ;
      private bool[] P005F2_n1000LayoutContratoTag ;
      private string[] P005F2_A906LayoutContratoTipo ;
      private bool[] P005F2_n906LayoutContratoTipo ;
      private bool[] P005F2_A156LayoutContratoStatus ;
      private bool[] P005F2_n156LayoutContratoStatus ;
      private string[] P005F2_A155LayoutContratoDescricao ;
      private bool[] P005F2_n155LayoutContratoDescricao ;
      private short[] P005F2_A154LayoutContratoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class layoutcontratowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005F2( IGxContext context ,
                                             string A906LayoutContratoTipo ,
                                             GxSimpleCollection<string> AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                             string AV63Layoutcontratowwds_1_filterfulltext ,
                                             string AV64Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                             short AV65Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV66Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                             bool AV67Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                             short AV69Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                             bool AV71Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                             string AV72Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                             short AV73Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                             string AV74Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                             string AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                             string AV75Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                             short AV77Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                             int AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ,
                                             string AV80Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                             string AV79Layoutcontratowwds_17_tflayoutcontratotag ,
                                             string A155LayoutContratoDescricao ,
                                             bool A156LayoutContratoStatus ,
                                             string A1000LayoutContratoTag ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT LayoutContratoTag, LayoutContratoTipo, LayoutContratoStatus, LayoutContratoDescricao, LayoutContratoId FROM LayoutContrato";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Layoutcontratowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LayoutContratoDescricao like '%' || :lV63Layoutcontratowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV63Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = TRUE) or ( 'não' like '%' || LOWER(:lV63Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = FALSE) or ( 'contrato' like '%' || LOWER(:lV63Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'C')) or ( 'mensagem' like '%' || LOWER(:lV63Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'M')) or ( 'acoplado' like '%' || LOWER(:lV63Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'A')) or ( LayoutContratoTag like '%' || :lV63Layoutcontratowwds_1_filterfulltext))");
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
         if ( ( StringUtil.StrCmp(AV64Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV65Layoutcontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV66Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV65Layoutcontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV66Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV69Layoutcontratowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV70Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV69Layoutcontratowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV70Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV71Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV73Layoutcontratowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV74Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV71Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV73Layoutcontratowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV74Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Layoutcontratowwds_13_tflayoutcontratodescricao)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV75Layoutcontratowwds_13_tflayoutcontratodescricao)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ! ( StringUtil.StrCmp(AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao = ( :AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao IS NULL or (char_length(trim(trailing ' ' from LayoutContratoDescricao))=0))");
         }
         if ( AV77Layoutcontratowwds_15_tflayoutcontratostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = TRUE)");
         }
         if ( AV77Layoutcontratowwds_15_tflayoutcontratostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = FALSE)");
         }
         if ( AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Layoutcontratowwds_16_tflayoutcontratotipo_sels, "LayoutContratoTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Layoutcontratowwds_17_tflayoutcontratotag)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag like :lV79Layoutcontratowwds_17_tflayoutcontratotag)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ! ( StringUtil.StrCmp(AV80Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag = ( :AV80Layoutcontratowwds_18_tflayoutcontratotag_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV80Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoTag IS NULL or (char_length(trim(trailing ' ' from LayoutContratoTag))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoDescricao";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoDescricao DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoStatus";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoStatus DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoTipo";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoTipo DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LayoutContratoTag";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LayoutContratoTag DESC";
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
                     return conditional_P005F2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP005F2;
          prmP005F2 = new Object[] {
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV66Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV70Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV70Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV74Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV74Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV75Layoutcontratowwds_13_tflayoutcontratodescricao",GXType.VarChar,60,0) ,
          new ParDef("AV76Layoutcontratowwds_14_tflayoutcontratodescricao_sel",GXType.VarChar,60,0) ,
          new ParDef("lV79Layoutcontratowwds_17_tflayoutcontratotag",GXType.VarChar,40,0) ,
          new ParDef("AV80Layoutcontratowwds_18_tflayoutcontratotag_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
