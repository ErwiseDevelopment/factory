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
   public class tipopagamentowwexport : GXProcedure
   {
      public tipopagamentowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipopagamentowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "TipoPagamentoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21TipoPagamentoNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipoPagamentoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21TipoPagamentoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25TipoPagamentoNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipoPagamentoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25TipoPagamentoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29TipoPagamentoNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TipoPagamentoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29TipoPagamentoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV35TFTipoPagamentoId) && (0==AV36TFTipoPagamentoId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pagamento Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV35TFTipoPagamentoId;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV36TFTipoPagamentoId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoPagamentoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pagamento Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoPagamentoNome_Sel)) ? "(Vazio)" : AV38TFTipoPagamentoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipoPagamentoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Pagamento Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipoPagamentoNome, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Pagamento Id";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Pagamento Nome";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV40Tipopagamentowwds_1_filterfulltext = AV18FilterFullText;
         AV41Tipopagamentowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV42Tipopagamentowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV43Tipopagamentowwds_4_tipopagamentonome1 = AV21TipoPagamentoNome1;
         AV44Tipopagamentowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV45Tipopagamentowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV46Tipopagamentowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV47Tipopagamentowwds_8_tipopagamentonome2 = AV25TipoPagamentoNome2;
         AV48Tipopagamentowwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV49Tipopagamentowwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV50Tipopagamentowwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV51Tipopagamentowwds_12_tipopagamentonome3 = AV29TipoPagamentoNome3;
         AV52Tipopagamentowwds_13_tftipopagamentoid = AV35TFTipoPagamentoId;
         AV53Tipopagamentowwds_14_tftipopagamentoid_to = AV36TFTipoPagamentoId_To;
         AV54Tipopagamentowwds_15_tftipopagamentonome = AV37TFTipoPagamentoNome;
         AV55Tipopagamentowwds_16_tftipopagamentonome_sel = AV38TFTipoPagamentoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Tipopagamentowwds_1_filterfulltext ,
                                              AV41Tipopagamentowwds_2_dynamicfiltersselector1 ,
                                              AV42Tipopagamentowwds_3_dynamicfiltersoperator1 ,
                                              AV43Tipopagamentowwds_4_tipopagamentonome1 ,
                                              AV44Tipopagamentowwds_5_dynamicfiltersenabled2 ,
                                              AV45Tipopagamentowwds_6_dynamicfiltersselector2 ,
                                              AV46Tipopagamentowwds_7_dynamicfiltersoperator2 ,
                                              AV47Tipopagamentowwds_8_tipopagamentonome2 ,
                                              AV48Tipopagamentowwds_9_dynamicfiltersenabled3 ,
                                              AV49Tipopagamentowwds_10_dynamicfiltersselector3 ,
                                              AV50Tipopagamentowwds_11_dynamicfiltersoperator3 ,
                                              AV51Tipopagamentowwds_12_tipopagamentonome3 ,
                                              AV52Tipopagamentowwds_13_tftipopagamentoid ,
                                              AV53Tipopagamentowwds_14_tftipopagamentoid_to ,
                                              AV55Tipopagamentowwds_16_tftipopagamentonome_sel ,
                                              AV54Tipopagamentowwds_15_tftipopagamentonome ,
                                              A288TipoPagamentoId ,
                                              A289TipoPagamentoNome ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Tipopagamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Tipopagamentowwds_1_filterfulltext), "%", "");
         lV40Tipopagamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Tipopagamentowwds_1_filterfulltext), "%", "");
         lV43Tipopagamentowwds_4_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV43Tipopagamentowwds_4_tipopagamentonome1), "%", "");
         lV43Tipopagamentowwds_4_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV43Tipopagamentowwds_4_tipopagamentonome1), "%", "");
         lV47Tipopagamentowwds_8_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV47Tipopagamentowwds_8_tipopagamentonome2), "%", "");
         lV47Tipopagamentowwds_8_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV47Tipopagamentowwds_8_tipopagamentonome2), "%", "");
         lV51Tipopagamentowwds_12_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV51Tipopagamentowwds_12_tipopagamentonome3), "%", "");
         lV51Tipopagamentowwds_12_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV51Tipopagamentowwds_12_tipopagamentonome3), "%", "");
         lV54Tipopagamentowwds_15_tftipopagamentonome = StringUtil.Concat( StringUtil.RTrim( AV54Tipopagamentowwds_15_tftipopagamentonome), "%", "");
         /* Using cursor P00852 */
         pr_default.execute(0, new Object[] {lV40Tipopagamentowwds_1_filterfulltext, lV40Tipopagamentowwds_1_filterfulltext, lV43Tipopagamentowwds_4_tipopagamentonome1, lV43Tipopagamentowwds_4_tipopagamentonome1, lV47Tipopagamentowwds_8_tipopagamentonome2, lV47Tipopagamentowwds_8_tipopagamentonome2, lV51Tipopagamentowwds_12_tipopagamentonome3, lV51Tipopagamentowwds_12_tipopagamentonome3, AV52Tipopagamentowwds_13_tftipopagamentoid, AV53Tipopagamentowwds_14_tftipopagamentoid_to, lV54Tipopagamentowwds_15_tftipopagamentonome, AV55Tipopagamentowwds_16_tftipopagamentonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A288TipoPagamentoId = P00852_A288TipoPagamentoId[0];
            A289TipoPagamentoNome = P00852_A289TipoPagamentoNome[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A288TipoPagamentoId;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A289TipoPagamentoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "TipoPagamentoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("TipoPagamentoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoPagamentoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("TipoPagamentoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTOID") == 0 )
            {
               AV35TFTipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFTipoPagamentoId_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME") == 0 )
            {
               AV37TFTipoPagamentoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME_SEL") == 0 )
            {
               AV38TFTipoPagamentoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV1 = (int)(AV56GXV1+1);
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
         AV21TipoPagamentoNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25TipoPagamentoNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29TipoPagamentoNome3 = "";
         AV38TFTipoPagamentoNome_Sel = "";
         AV37TFTipoPagamentoNome = "";
         AV40Tipopagamentowwds_1_filterfulltext = "";
         AV41Tipopagamentowwds_2_dynamicfiltersselector1 = "";
         AV43Tipopagamentowwds_4_tipopagamentonome1 = "";
         AV45Tipopagamentowwds_6_dynamicfiltersselector2 = "";
         AV47Tipopagamentowwds_8_tipopagamentonome2 = "";
         AV49Tipopagamentowwds_10_dynamicfiltersselector3 = "";
         AV51Tipopagamentowwds_12_tipopagamentonome3 = "";
         AV54Tipopagamentowwds_15_tftipopagamentonome = "";
         AV55Tipopagamentowwds_16_tftipopagamentonome_sel = "";
         lV40Tipopagamentowwds_1_filterfulltext = "";
         lV43Tipopagamentowwds_4_tipopagamentonome1 = "";
         lV47Tipopagamentowwds_8_tipopagamentonome2 = "";
         lV51Tipopagamentowwds_12_tipopagamentonome3 = "";
         lV54Tipopagamentowwds_15_tftipopagamentonome = "";
         A289TipoPagamentoNome = "";
         P00852_A288TipoPagamentoId = new int[1] ;
         P00852_A289TipoPagamentoNome = new string[] {""} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipopagamentowwexport__default(),
            new Object[][] {
                new Object[] {
               P00852_A288TipoPagamentoId, P00852_A289TipoPagamentoNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV42Tipopagamentowwds_3_dynamicfiltersoperator1 ;
      private short AV46Tipopagamentowwds_7_dynamicfiltersoperator2 ;
      private short AV50Tipopagamentowwds_11_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV35TFTipoPagamentoId ;
      private int AV36TFTipoPagamentoId_To ;
      private int AV52Tipopagamentowwds_13_tftipopagamentoid ;
      private int AV53Tipopagamentowwds_14_tftipopagamentoid_to ;
      private int A288TipoPagamentoId ;
      private int AV56GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV44Tipopagamentowwds_5_dynamicfiltersenabled2 ;
      private bool AV48Tipopagamentowwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21TipoPagamentoNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25TipoPagamentoNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29TipoPagamentoNome3 ;
      private string AV38TFTipoPagamentoNome_Sel ;
      private string AV37TFTipoPagamentoNome ;
      private string AV40Tipopagamentowwds_1_filterfulltext ;
      private string AV41Tipopagamentowwds_2_dynamicfiltersselector1 ;
      private string AV43Tipopagamentowwds_4_tipopagamentonome1 ;
      private string AV45Tipopagamentowwds_6_dynamicfiltersselector2 ;
      private string AV47Tipopagamentowwds_8_tipopagamentonome2 ;
      private string AV49Tipopagamentowwds_10_dynamicfiltersselector3 ;
      private string AV51Tipopagamentowwds_12_tipopagamentonome3 ;
      private string AV54Tipopagamentowwds_15_tftipopagamentonome ;
      private string AV55Tipopagamentowwds_16_tftipopagamentonome_sel ;
      private string lV40Tipopagamentowwds_1_filterfulltext ;
      private string lV43Tipopagamentowwds_4_tipopagamentonome1 ;
      private string lV47Tipopagamentowwds_8_tipopagamentonome2 ;
      private string lV51Tipopagamentowwds_12_tipopagamentonome3 ;
      private string lV54Tipopagamentowwds_15_tftipopagamentonome ;
      private string A289TipoPagamentoNome ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00852_A288TipoPagamentoId ;
      private string[] P00852_A289TipoPagamentoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class tipopagamentowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00852( IGxContext context ,
                                             string AV40Tipopagamentowwds_1_filterfulltext ,
                                             string AV41Tipopagamentowwds_2_dynamicfiltersselector1 ,
                                             short AV42Tipopagamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV43Tipopagamentowwds_4_tipopagamentonome1 ,
                                             bool AV44Tipopagamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV45Tipopagamentowwds_6_dynamicfiltersselector2 ,
                                             short AV46Tipopagamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV47Tipopagamentowwds_8_tipopagamentonome2 ,
                                             bool AV48Tipopagamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV49Tipopagamentowwds_10_dynamicfiltersselector3 ,
                                             short AV50Tipopagamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV51Tipopagamentowwds_12_tipopagamentonome3 ,
                                             int AV52Tipopagamentowwds_13_tftipopagamentoid ,
                                             int AV53Tipopagamentowwds_14_tftipopagamentoid_to ,
                                             string AV55Tipopagamentowwds_16_tftipopagamentonome_sel ,
                                             string AV54Tipopagamentowwds_15_tftipopagamentonome ,
                                             int A288TipoPagamentoId ,
                                             string A289TipoPagamentoNome ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Tipopagamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TipoPagamentoId,'999999999'), 2) like '%' || :lV40Tipopagamentowwds_1_filterfulltext) or ( TipoPagamentoNome like '%' || :lV40Tipopagamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV41Tipopagamentowwds_2_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV42Tipopagamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Tipopagamentowwds_4_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV43Tipopagamentowwds_4_tipopagamentonome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV41Tipopagamentowwds_2_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV42Tipopagamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Tipopagamentowwds_4_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV43Tipopagamentowwds_4_tipopagamentonome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV44Tipopagamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV45Tipopagamentowwds_6_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV46Tipopagamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Tipopagamentowwds_8_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV47Tipopagamentowwds_8_tipopagamentonome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV44Tipopagamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV45Tipopagamentowwds_6_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV46Tipopagamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Tipopagamentowwds_8_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV47Tipopagamentowwds_8_tipopagamentonome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV48Tipopagamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV49Tipopagamentowwds_10_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV50Tipopagamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Tipopagamentowwds_12_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV51Tipopagamentowwds_12_tipopagamentonome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV48Tipopagamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV49Tipopagamentowwds_10_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV50Tipopagamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Tipopagamentowwds_12_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV51Tipopagamentowwds_12_tipopagamentonome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV52Tipopagamentowwds_13_tftipopagamentoid) )
         {
            AddWhere(sWhereString, "(TipoPagamentoId >= :AV52Tipopagamentowwds_13_tftipopagamentoid)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV53Tipopagamentowwds_14_tftipopagamentoid_to) )
         {
            AddWhere(sWhereString, "(TipoPagamentoId <= :AV53Tipopagamentowwds_14_tftipopagamentoid_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Tipopagamentowwds_16_tftipopagamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Tipopagamentowwds_15_tftipopagamentonome)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV54Tipopagamentowwds_15_tftipopagamentonome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Tipopagamentowwds_16_tftipopagamentonome_sel)) && ! ( StringUtil.StrCmp(AV55Tipopagamentowwds_16_tftipopagamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome = ( :AV55Tipopagamentowwds_16_tftipopagamentonome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV55Tipopagamentowwds_16_tftipopagamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TipoPagamentoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoPagamentoNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoPagamentoNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoPagamentoId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoPagamentoId DESC";
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
                     return conditional_P00852(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00852;
          prmP00852 = new Object[] {
          new ParDef("lV40Tipopagamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Tipopagamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Tipopagamentowwds_4_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV43Tipopagamentowwds_4_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV47Tipopagamentowwds_8_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV47Tipopagamentowwds_8_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV51Tipopagamentowwds_12_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("lV51Tipopagamentowwds_12_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("AV52Tipopagamentowwds_13_tftipopagamentoid",GXType.Int32,9,0) ,
          new ParDef("AV53Tipopagamentowwds_14_tftipopagamentoid_to",GXType.Int32,9,0) ,
          new ParDef("lV54Tipopagamentowwds_15_tftipopagamentonome",GXType.VarChar,60,0) ,
          new ParDef("AV55Tipopagamentowwds_16_tftipopagamentonome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00852", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00852,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
