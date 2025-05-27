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
   public class categoriatitulowwexport : GXProcedure
   {
      public categoriatitulowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public categoriatitulowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "CategoriaTituloWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CATEGORIATITULONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21CategoriaTituloNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CategoriaTituloNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21CategoriaTituloNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CATEGORIATITULONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25CategoriaTituloNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CategoriaTituloNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CategoriaTituloNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CATEGORIATITULONOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29CategoriaTituloNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CategoriaTituloNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29CategoriaTituloNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCategoriaTituloNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCategoriaTituloNome_Sel)) ? "(Vazio)" : AV38TFCategoriaTituloNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCategoriaTituloNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFCategoriaTituloNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCategoriaTituloDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCategoriaTituloDescricao_Sel)) ? "(Vazio)" : AV40TFCategoriaTituloDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCategoriaTituloDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descrição") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCategoriaTituloDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV42TFCategoriaStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV42TFCategoriaStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV42TFCategoriaStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Descrição";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV45Categoriatitulowwds_1_filterfulltext = AV18FilterFullText;
         AV46Categoriatitulowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV47Categoriatitulowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV48Categoriatitulowwds_4_categoriatitulonome1 = AV21CategoriaTituloNome1;
         AV49Categoriatitulowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV50Categoriatitulowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV51Categoriatitulowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV52Categoriatitulowwds_8_categoriatitulonome2 = AV25CategoriaTituloNome2;
         AV53Categoriatitulowwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV54Categoriatitulowwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV55Categoriatitulowwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV56Categoriatitulowwds_12_categoriatitulonome3 = AV29CategoriaTituloNome3;
         AV57Categoriatitulowwds_13_tfcategoriatitulonome = AV37TFCategoriaTituloNome;
         AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel = AV38TFCategoriaTituloNome_Sel;
         AV59Categoriatitulowwds_15_tfcategoriatitulodescricao = AV39TFCategoriaTituloDescricao;
         AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = AV40TFCategoriaTituloDescricao_Sel;
         AV61Categoriatitulowwds_17_tfcategoriastatus_sel = AV42TFCategoriaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Categoriatitulowwds_1_filterfulltext ,
                                              AV46Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                              AV47Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                              AV48Categoriatitulowwds_4_categoriatitulonome1 ,
                                              AV49Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                              AV50Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                              AV51Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                              AV52Categoriatitulowwds_8_categoriatitulonome2 ,
                                              AV53Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                              AV54Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                              AV55Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                              AV56Categoriatitulowwds_12_categoriatitulonome3 ,
                                              AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                              AV57Categoriatitulowwds_13_tfcategoriatitulonome ,
                                              AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                              AV59Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                              AV61Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                              A427CategoriaTituloNome ,
                                              A428CategoriaTituloDescricao ,
                                              A431CategoriaStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV45Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Categoriatitulowwds_1_filterfulltext), "%", "");
         lV45Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Categoriatitulowwds_1_filterfulltext), "%", "");
         lV45Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Categoriatitulowwds_1_filterfulltext), "%", "");
         lV45Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Categoriatitulowwds_1_filterfulltext), "%", "");
         lV48Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV48Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV48Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV48Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV52Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV52Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV52Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV52Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV56Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV56Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV56Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV56Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV57Categoriatitulowwds_13_tfcategoriatitulonome = StringUtil.Concat( StringUtil.RTrim( AV57Categoriatitulowwds_13_tfcategoriatitulonome), "%", "");
         lV59Categoriatitulowwds_15_tfcategoriatitulodescricao = StringUtil.Concat( StringUtil.RTrim( AV59Categoriatitulowwds_15_tfcategoriatitulodescricao), "%", "");
         /* Using cursor P00A32 */
         pr_default.execute(0, new Object[] {lV45Categoriatitulowwds_1_filterfulltext, lV45Categoriatitulowwds_1_filterfulltext, lV45Categoriatitulowwds_1_filterfulltext, lV45Categoriatitulowwds_1_filterfulltext, lV48Categoriatitulowwds_4_categoriatitulonome1, lV48Categoriatitulowwds_4_categoriatitulonome1, lV52Categoriatitulowwds_8_categoriatitulonome2, lV52Categoriatitulowwds_8_categoriatitulonome2, lV56Categoriatitulowwds_12_categoriatitulonome3, lV56Categoriatitulowwds_12_categoriatitulonome3, lV57Categoriatitulowwds_13_tfcategoriatitulonome, AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel, lV59Categoriatitulowwds_15_tfcategoriatitulodescricao, AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A431CategoriaStatus = P00A32_A431CategoriaStatus[0];
            n431CategoriaStatus = P00A32_n431CategoriaStatus[0];
            A428CategoriaTituloDescricao = P00A32_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00A32_n428CategoriaTituloDescricao[0];
            A427CategoriaTituloNome = P00A32_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = P00A32_n427CategoriaTituloNome[0];
            A426CategoriaTituloId = P00A32_A426CategoriaTituloId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A427CategoriaTituloNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A428CategoriaTituloDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A431CategoriaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A431CategoriaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A431CategoriaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A431CategoriaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV31Session.Set("WWPExportFileName", "CategoriaTituloWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("CategoriaTituloWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CategoriaTituloWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("CategoriaTituloWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULONOME") == 0 )
            {
               AV37TFCategoriaTituloNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULONOME_SEL") == 0 )
            {
               AV38TFCategoriaTituloNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO") == 0 )
            {
               AV39TFCategoriaTituloDescricao = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO_SEL") == 0 )
            {
               AV40TFCategoriaTituloDescricao_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCATEGORIASTATUS_SEL") == 0 )
            {
               AV42TFCategoriaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV62GXV1 = (int)(AV62GXV1+1);
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
         AV21CategoriaTituloNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25CategoriaTituloNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29CategoriaTituloNome3 = "";
         AV38TFCategoriaTituloNome_Sel = "";
         AV37TFCategoriaTituloNome = "";
         AV40TFCategoriaTituloDescricao_Sel = "";
         AV39TFCategoriaTituloDescricao = "";
         AV45Categoriatitulowwds_1_filterfulltext = "";
         AV46Categoriatitulowwds_2_dynamicfiltersselector1 = "";
         AV48Categoriatitulowwds_4_categoriatitulonome1 = "";
         AV50Categoriatitulowwds_6_dynamicfiltersselector2 = "";
         AV52Categoriatitulowwds_8_categoriatitulonome2 = "";
         AV54Categoriatitulowwds_10_dynamicfiltersselector3 = "";
         AV56Categoriatitulowwds_12_categoriatitulonome3 = "";
         AV57Categoriatitulowwds_13_tfcategoriatitulonome = "";
         AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel = "";
         AV59Categoriatitulowwds_15_tfcategoriatitulodescricao = "";
         AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = "";
         lV45Categoriatitulowwds_1_filterfulltext = "";
         lV48Categoriatitulowwds_4_categoriatitulonome1 = "";
         lV52Categoriatitulowwds_8_categoriatitulonome2 = "";
         lV56Categoriatitulowwds_12_categoriatitulonome3 = "";
         lV57Categoriatitulowwds_13_tfcategoriatitulonome = "";
         lV59Categoriatitulowwds_15_tfcategoriatitulodescricao = "";
         A427CategoriaTituloNome = "";
         A428CategoriaTituloDescricao = "";
         P00A32_A431CategoriaStatus = new bool[] {false} ;
         P00A32_n431CategoriaStatus = new bool[] {false} ;
         P00A32_A428CategoriaTituloDescricao = new string[] {""} ;
         P00A32_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00A32_A427CategoriaTituloNome = new string[] {""} ;
         P00A32_n427CategoriaTituloNome = new bool[] {false} ;
         P00A32_A426CategoriaTituloId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriatitulowwexport__default(),
            new Object[][] {
                new Object[] {
               P00A32_A431CategoriaStatus, P00A32_n431CategoriaStatus, P00A32_A428CategoriaTituloDescricao, P00A32_n428CategoriaTituloDescricao, P00A32_A427CategoriaTituloNome, P00A32_n427CategoriaTituloNome, P00A32_A426CategoriaTituloId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV42TFCategoriaStatus_Sel ;
      private short GXt_int2 ;
      private short AV47Categoriatitulowwds_3_dynamicfiltersoperator1 ;
      private short AV51Categoriatitulowwds_7_dynamicfiltersoperator2 ;
      private short AV55Categoriatitulowwds_11_dynamicfiltersoperator3 ;
      private short AV61Categoriatitulowwds_17_tfcategoriastatus_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A426CategoriaTituloId ;
      private int AV62GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV49Categoriatitulowwds_5_dynamicfiltersenabled2 ;
      private bool AV53Categoriatitulowwds_9_dynamicfiltersenabled3 ;
      private bool A431CategoriaStatus ;
      private bool AV17OrderedDsc ;
      private bool n431CategoriaStatus ;
      private bool n428CategoriaTituloDescricao ;
      private bool n427CategoriaTituloNome ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21CategoriaTituloNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25CategoriaTituloNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29CategoriaTituloNome3 ;
      private string AV38TFCategoriaTituloNome_Sel ;
      private string AV37TFCategoriaTituloNome ;
      private string AV40TFCategoriaTituloDescricao_Sel ;
      private string AV39TFCategoriaTituloDescricao ;
      private string AV45Categoriatitulowwds_1_filterfulltext ;
      private string AV46Categoriatitulowwds_2_dynamicfiltersselector1 ;
      private string AV48Categoriatitulowwds_4_categoriatitulonome1 ;
      private string AV50Categoriatitulowwds_6_dynamicfiltersselector2 ;
      private string AV52Categoriatitulowwds_8_categoriatitulonome2 ;
      private string AV54Categoriatitulowwds_10_dynamicfiltersselector3 ;
      private string AV56Categoriatitulowwds_12_categoriatitulonome3 ;
      private string AV57Categoriatitulowwds_13_tfcategoriatitulonome ;
      private string AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel ;
      private string AV59Categoriatitulowwds_15_tfcategoriatitulodescricao ;
      private string AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ;
      private string lV45Categoriatitulowwds_1_filterfulltext ;
      private string lV48Categoriatitulowwds_4_categoriatitulonome1 ;
      private string lV52Categoriatitulowwds_8_categoriatitulonome2 ;
      private string lV56Categoriatitulowwds_12_categoriatitulonome3 ;
      private string lV57Categoriatitulowwds_13_tfcategoriatitulonome ;
      private string lV59Categoriatitulowwds_15_tfcategoriatitulodescricao ;
      private string A427CategoriaTituloNome ;
      private string A428CategoriaTituloDescricao ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P00A32_A431CategoriaStatus ;
      private bool[] P00A32_n431CategoriaStatus ;
      private string[] P00A32_A428CategoriaTituloDescricao ;
      private bool[] P00A32_n428CategoriaTituloDescricao ;
      private string[] P00A32_A427CategoriaTituloNome ;
      private bool[] P00A32_n427CategoriaTituloNome ;
      private int[] P00A32_A426CategoriaTituloId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class categoriatitulowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A32( IGxContext context ,
                                             string AV45Categoriatitulowwds_1_filterfulltext ,
                                             string AV46Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                             short AV47Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                             string AV48Categoriatitulowwds_4_categoriatitulonome1 ,
                                             bool AV49Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                             string AV50Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                             short AV51Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                             string AV52Categoriatitulowwds_8_categoriatitulonome2 ,
                                             bool AV53Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                             string AV54Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                             short AV55Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                             string AV56Categoriatitulowwds_12_categoriatitulonome3 ,
                                             string AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                             string AV57Categoriatitulowwds_13_tfcategoriatitulonome ,
                                             string AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                             string AV59Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                             short AV61Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                             string A427CategoriaTituloNome ,
                                             string A428CategoriaTituloDescricao ,
                                             bool A431CategoriaStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CategoriaStatus, CategoriaTituloDescricao, CategoriaTituloNome, CategoriaTituloId FROM CategoriaTitulo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Categoriatitulowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CategoriaTituloNome like '%' || :lV45Categoriatitulowwds_1_filterfulltext) or ( CategoriaTituloDescricao like '%' || :lV45Categoriatitulowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV45Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV45Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV47Categoriatitulowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV48Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV47Categoriatitulowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV48Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV49Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV51Categoriatitulowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV52Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV49Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV51Categoriatitulowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV52Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV53Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV55Categoriatitulowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV56Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV53Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV55Categoriatitulowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV56Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Categoriatitulowwds_13_tfcategoriatitulonome)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV57Categoriatitulowwds_13_tfcategoriatitulonome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ! ( StringUtil.StrCmp(AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome = ( :AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Categoriatitulowwds_15_tfcategoriatitulodescricao)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao like :lV59Categoriatitulowwds_15_tfcategoriatitulodescricao)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ! ( StringUtil.StrCmp(AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao = ( :AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloDescricao))=0))");
         }
         if ( AV61Categoriatitulowwds_17_tfcategoriastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = TRUE)");
         }
         if ( AV61Categoriatitulowwds_17_tfcategoriastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CategoriaTituloNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CategoriaTituloNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CategoriaTituloDescricao";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CategoriaTituloDescricao DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CategoriaStatus";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CategoriaStatus DESC";
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
                     return conditional_P00A32(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00A32;
          prmP00A32 = new Object[] {
          new ParDef("lV45Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV48Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV52Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV52Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV56Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV56Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV57Categoriatitulowwds_13_tfcategoriatitulonome",GXType.VarChar,60,0) ,
          new ParDef("AV58Categoriatitulowwds_14_tfcategoriatitulonome_sel",GXType.VarChar,60,0) ,
          new ParDef("lV59Categoriatitulowwds_15_tfcategoriatitulodescricao",GXType.VarChar,150,0) ,
          new ParDef("AV60Categoriatitulowwds_16_tfcategoriatitulodescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A32,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
