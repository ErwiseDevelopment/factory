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
   public class carteiradecobrancawwexport : GXProcedure
   {
      public carteiradecobrancawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiradecobrancawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "CarteiraDeCobrancaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CARTEIRADECOBRANCACODIGO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21CarteiraDeCobrancaCodigo1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CarteiraDeCobrancaCodigo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21CarteiraDeCobrancaCodigo1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CARTEIRADECOBRANCACODIGO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25CarteiraDeCobrancaCodigo2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CarteiraDeCobrancaCodigo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CarteiraDeCobrancaCodigo2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CARTEIRADECOBRANCACODIGO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29CarteiraDeCobrancaCodigo3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CarteiraDeCobrancaCodigo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29CarteiraDeCobrancaCodigo3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCarteiraDeCobrancaNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCarteiraDeCobrancaNome_Sel)) ? "(Vazio)" : AV38TFCarteiraDeCobrancaNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCarteiraDeCobrancaNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFCarteiraDeCobrancaNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCarteiraDeCobrancaConvenio_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Convênio") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCarteiraDeCobrancaConvenio_Sel)) ? "(Vazio)" : AV40TFCarteiraDeCobrancaConvenio_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCarteiraDeCobrancaConvenio)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Convênio") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCarteiraDeCobrancaConvenio, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV41TFCarteiraDeCobrancaStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV41TFCarteiraDeCobrancaStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV41TFCarteiraDeCobrancaStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Convênio";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV43Carteiradecobrancawwds_1_filterfulltext = AV18FilterFullText;
         AV44Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV45Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV21CarteiraDeCobrancaCodigo1;
         AV47Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV48Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV49Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV25CarteiraDeCobrancaCodigo2;
         AV51Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV52Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV53Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV29CarteiraDeCobrancaCodigo3;
         AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV59Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Carteiradecobrancawwds_1_filterfulltext ,
                                              AV44Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                              AV45Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                              AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                              AV47Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                              AV48Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                              AV49Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                              AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                              AV51Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                              AV52Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                              AV53Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                              AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                              AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                              AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                              AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                              AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                              AV59Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                              A1071CarteiraDeCobrancaNome ,
                                              A1073CarteiraDeCobrancaConvenio ,
                                              A1074CarteiraDeCobrancaStatus ,
                                              A1070CarteiraDeCobrancaCodigo ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV43Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV43Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV43Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome = StringUtil.Concat( StringUtil.RTrim( AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome), "%", "");
         lV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = StringUtil.Concat( StringUtil.RTrim( AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio), "%", "");
         /* Using cursor P00FL2 */
         pr_default.execute(0, new Object[] {lV43Carteiradecobrancawwds_1_filterfulltext, lV43Carteiradecobrancawwds_1_filterfulltext, lV43Carteiradecobrancawwds_1_filterfulltext, lV43Carteiradecobrancawwds_1_filterfulltext, lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome, AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, lV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio, AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1070CarteiraDeCobrancaCodigo = P00FL2_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = P00FL2_n1070CarteiraDeCobrancaCodigo[0];
            A1074CarteiraDeCobrancaStatus = P00FL2_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = P00FL2_n1074CarteiraDeCobrancaStatus[0];
            A1073CarteiraDeCobrancaConvenio = P00FL2_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = P00FL2_n1073CarteiraDeCobrancaConvenio[0];
            A1071CarteiraDeCobrancaNome = P00FL2_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = P00FL2_n1071CarteiraDeCobrancaNome[0];
            A1069CarteiraDeCobrancaId = P00FL2_A1069CarteiraDeCobrancaId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1071CarteiraDeCobrancaNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1073CarteiraDeCobrancaConvenio, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Inativo";
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
         AV31Session.Set("WWPExportFileName", "CarteiraDeCobrancaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("CarteiraDeCobrancaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CarteiraDeCobrancaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("CarteiraDeCobrancaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME") == 0 )
            {
               AV37TFCarteiraDeCobrancaNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME_SEL") == 0 )
            {
               AV38TFCarteiraDeCobrancaNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO") == 0 )
            {
               AV39TFCarteiraDeCobrancaConvenio = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO_SEL") == 0 )
            {
               AV40TFCarteiraDeCobrancaConvenio_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCASTATUS_SEL") == 0 )
            {
               AV41TFCarteiraDeCobrancaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV60GXV1 = (int)(AV60GXV1+1);
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
         AV21CarteiraDeCobrancaCodigo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25CarteiraDeCobrancaCodigo2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29CarteiraDeCobrancaCodigo3 = "";
         AV38TFCarteiraDeCobrancaNome_Sel = "";
         AV37TFCarteiraDeCobrancaNome = "";
         AV40TFCarteiraDeCobrancaConvenio_Sel = "";
         AV39TFCarteiraDeCobrancaConvenio = "";
         AV43Carteiradecobrancawwds_1_filterfulltext = "";
         AV44Carteiradecobrancawwds_2_dynamicfiltersselector1 = "";
         AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         AV48Carteiradecobrancawwds_6_dynamicfiltersselector2 = "";
         AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         AV52Carteiradecobrancawwds_10_dynamicfiltersselector3 = "";
         AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = "";
         AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = "";
         lV43Carteiradecobrancawwds_1_filterfulltext = "";
         lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         lV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         lV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         A1071CarteiraDeCobrancaNome = "";
         A1073CarteiraDeCobrancaConvenio = "";
         A1070CarteiraDeCobrancaCodigo = "";
         P00FL2_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FL2_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         P00FL2_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FL2_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FL2_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         P00FL2_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         P00FL2_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         P00FL2_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         P00FL2_A1069CarteiraDeCobrancaId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carteiradecobrancawwexport__default(),
            new Object[][] {
                new Object[] {
               P00FL2_A1070CarteiraDeCobrancaCodigo, P00FL2_n1070CarteiraDeCobrancaCodigo, P00FL2_A1074CarteiraDeCobrancaStatus, P00FL2_n1074CarteiraDeCobrancaStatus, P00FL2_A1073CarteiraDeCobrancaConvenio, P00FL2_n1073CarteiraDeCobrancaConvenio, P00FL2_A1071CarteiraDeCobrancaNome, P00FL2_n1071CarteiraDeCobrancaNome, P00FL2_A1069CarteiraDeCobrancaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV41TFCarteiraDeCobrancaStatus_Sel ;
      private short GXt_int2 ;
      private short AV45Carteiradecobrancawwds_3_dynamicfiltersoperator1 ;
      private short AV49Carteiradecobrancawwds_7_dynamicfiltersoperator2 ;
      private short AV53Carteiradecobrancawwds_11_dynamicfiltersoperator3 ;
      private short AV59Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A1069CarteiraDeCobrancaId ;
      private int AV60GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV47Carteiradecobrancawwds_5_dynamicfiltersenabled2 ;
      private bool AV51Carteiradecobrancawwds_9_dynamicfiltersenabled3 ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool AV17OrderedDsc ;
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool n1071CarteiraDeCobrancaNome ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21CarteiraDeCobrancaCodigo1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25CarteiraDeCobrancaCodigo2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29CarteiraDeCobrancaCodigo3 ;
      private string AV38TFCarteiraDeCobrancaNome_Sel ;
      private string AV37TFCarteiraDeCobrancaNome ;
      private string AV40TFCarteiraDeCobrancaConvenio_Sel ;
      private string AV39TFCarteiraDeCobrancaConvenio ;
      private string AV43Carteiradecobrancawwds_1_filterfulltext ;
      private string AV44Carteiradecobrancawwds_2_dynamicfiltersselector1 ;
      private string AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string AV48Carteiradecobrancawwds_6_dynamicfiltersselector2 ;
      private string AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string AV52Carteiradecobrancawwds_10_dynamicfiltersselector3 ;
      private string AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ;
      private string AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ;
      private string lV43Carteiradecobrancawwds_1_filterfulltext ;
      private string lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string lV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string lV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string A1071CarteiraDeCobrancaNome ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00FL2_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FL2_n1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FL2_A1074CarteiraDeCobrancaStatus ;
      private bool[] P00FL2_n1074CarteiraDeCobrancaStatus ;
      private string[] P00FL2_A1073CarteiraDeCobrancaConvenio ;
      private bool[] P00FL2_n1073CarteiraDeCobrancaConvenio ;
      private string[] P00FL2_A1071CarteiraDeCobrancaNome ;
      private bool[] P00FL2_n1071CarteiraDeCobrancaNome ;
      private int[] P00FL2_A1069CarteiraDeCobrancaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class carteiradecobrancawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FL2( IGxContext context ,
                                             string AV43Carteiradecobrancawwds_1_filterfulltext ,
                                             string AV44Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                             short AV45Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                             string AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                             bool AV47Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                             string AV48Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                             short AV49Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                             string AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                             bool AV51Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                             string AV52Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                             short AV53Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                             string AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                             string AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                             string AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                             string AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                             string AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                             short AV59Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                             string A1071CarteiraDeCobrancaNome ,
                                             string A1073CarteiraDeCobrancaConvenio ,
                                             bool A1074CarteiraDeCobrancaStatus ,
                                             string A1070CarteiraDeCobrancaCodigo ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaCodigo, CarteiraDeCobrancaStatus, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaNome, CarteiraDeCobrancaId FROM CarteiraDeCobranca";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Carteiradecobrancawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CarteiraDeCobrancaNome like '%' || :lV43Carteiradecobrancawwds_1_filterfulltext) or ( CarteiraDeCobrancaConvenio like '%' || :lV43Carteiradecobrancawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV43Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV43Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV45Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV45Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV47Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV49Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV47Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV49Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV51Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV53Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV51Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV53Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome like :lV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ! ( StringUtil.StrCmp(AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome = ( :AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio like :lV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ! ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio = ( :AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaConvenio))=0))");
         }
         if ( AV59Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = TRUE)");
         }
         if ( AV59Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaCodigo";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaNome DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaConvenio";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaConvenio DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaStatus";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaStatus DESC";
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
                     return conditional_P00FL2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP00FL2;
          prmP00FL2 = new Object[] {
          new ParDef("lV43Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV46Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV50Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV54Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV55Carteiradecobrancawwds_13_tfcarteiradecobrancanome",GXType.VarChar,100,0) ,
          new ParDef("AV56Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio",GXType.VarChar,20,0) ,
          new ParDef("AV58Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
