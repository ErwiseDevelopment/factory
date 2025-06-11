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
   public class contawwexport : GXProcedure
   {
      public contawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ContaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTASALDOATUAL") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21ContaSaldoAtual1 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV21ContaSaldoAtual1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV21ContaSaldoAtual1);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONTASALDOATUAL") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25ContaSaldoAtual2 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV25ContaSaldoAtual2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV25ContaSaldoAtual2);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTASALDOATUAL") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29ContaSaldoAtual3 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV29ContaSaldoAtual3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Saldo", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV29ContaSaldoAtual3);
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFContaNomeConta_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFContaNomeConta_Sel)) ? "(Vazio)" : AV36TFContaNomeConta_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFContaNomeConta)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFContaNomeConta, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV38TFContaSaldoAtual) && (Convert.ToDecimal(0)==AV39TFContaSaldoAtual_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Saldo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV38TFContaSaldoAtual);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV39TFContaSaldoAtual_To);
         }
         if ( ! ( (0==AV37TFContaStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV37TFContaStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV37TFContaStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Saldo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV41Contawwds_1_filterfulltext = AV18FilterFullText;
         AV42Contawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV43Contawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV44Contawwds_4_contasaldoatual1 = AV21ContaSaldoAtual1;
         AV45Contawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV46Contawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV47Contawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV48Contawwds_8_contasaldoatual2 = AV25ContaSaldoAtual2;
         AV49Contawwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV50Contawwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV51Contawwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV52Contawwds_12_contasaldoatual3 = AV29ContaSaldoAtual3;
         AV53Contawwds_13_tfcontanomeconta = AV35TFContaNomeConta;
         AV54Contawwds_14_tfcontanomeconta_sel = AV36TFContaNomeConta_Sel;
         AV55Contawwds_15_tfcontasaldoatual = AV38TFContaSaldoAtual;
         AV56Contawwds_16_tfcontasaldoatual_to = AV39TFContaSaldoAtual_To;
         AV57Contawwds_17_tfcontastatus_sel = AV37TFContaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Contawwds_1_filterfulltext ,
                                              AV42Contawwds_2_dynamicfiltersselector1 ,
                                              AV43Contawwds_3_dynamicfiltersoperator1 ,
                                              AV44Contawwds_4_contasaldoatual1 ,
                                              AV45Contawwds_5_dynamicfiltersenabled2 ,
                                              AV46Contawwds_6_dynamicfiltersselector2 ,
                                              AV47Contawwds_7_dynamicfiltersoperator2 ,
                                              AV48Contawwds_8_contasaldoatual2 ,
                                              AV49Contawwds_9_dynamicfiltersenabled3 ,
                                              AV50Contawwds_10_dynamicfiltersselector3 ,
                                              AV51Contawwds_11_dynamicfiltersoperator3 ,
                                              AV52Contawwds_12_contasaldoatual3 ,
                                              AV54Contawwds_14_tfcontanomeconta_sel ,
                                              AV53Contawwds_13_tfcontanomeconta ,
                                              AV55Contawwds_15_tfcontasaldoatual ,
                                              AV56Contawwds_16_tfcontasaldoatual_to ,
                                              AV57Contawwds_17_tfcontastatus_sel ,
                                              A424ContaNomeConta ,
                                              A423ContaSaldoAtual ,
                                              A430ContaStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV41Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Contawwds_1_filterfulltext), "%", "");
         lV41Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Contawwds_1_filterfulltext), "%", "");
         lV41Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Contawwds_1_filterfulltext), "%", "");
         lV41Contawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Contawwds_1_filterfulltext), "%", "");
         lV53Contawwds_13_tfcontanomeconta = StringUtil.Concat( StringUtil.RTrim( AV53Contawwds_13_tfcontanomeconta), "%", "");
         /* Using cursor P00A22 */
         pr_default.execute(0, new Object[] {lV41Contawwds_1_filterfulltext, lV41Contawwds_1_filterfulltext, lV41Contawwds_1_filterfulltext, lV41Contawwds_1_filterfulltext, AV44Contawwds_4_contasaldoatual1, AV44Contawwds_4_contasaldoatual1, AV44Contawwds_4_contasaldoatual1, AV48Contawwds_8_contasaldoatual2, AV48Contawwds_8_contasaldoatual2, AV48Contawwds_8_contasaldoatual2, AV52Contawwds_12_contasaldoatual3, AV52Contawwds_12_contasaldoatual3, AV52Contawwds_12_contasaldoatual3, lV53Contawwds_13_tfcontanomeconta, AV54Contawwds_14_tfcontanomeconta_sel, AV55Contawwds_15_tfcontasaldoatual, AV56Contawwds_16_tfcontasaldoatual_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A423ContaSaldoAtual = P00A22_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = P00A22_n423ContaSaldoAtual[0];
            A430ContaStatus = P00A22_A430ContaStatus[0];
            n430ContaStatus = P00A22_n430ContaStatus[0];
            A424ContaNomeConta = P00A22_A424ContaNomeConta[0];
            n424ContaNomeConta = P00A22_n424ContaNomeConta[0];
            A422ContaId = P00A22_A422ContaId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A424ContaNomeConta, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(A423ContaSaldoAtual);
            if ( ( A423ContaSaldoAtual == Convert.ToDecimal( 0 )) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( ( A423ContaSaldoAtual > Convert.ToDecimal( 0 )) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( ( A423ContaSaldoAtual < Convert.ToDecimal( 0 )) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A430ContaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A430ContaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A430ContaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A430ContaStatus)), "false") == 0 )
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
         AV31Session.Set("WWPExportFileName", "ContaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ContaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ContaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ContaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTANOMECONTA") == 0 )
            {
               AV35TFContaNomeConta = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTANOMECONTA_SEL") == 0 )
            {
               AV36TFContaNomeConta_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTASALDOATUAL") == 0 )
            {
               AV38TFContaSaldoAtual = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV39TFContaSaldoAtual_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONTASTATUS_SEL") == 0 )
            {
               AV37TFContaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV58GXV1 = (int)(AV58GXV1+1);
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
         AV23DynamicFiltersSelector2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV36TFContaNomeConta_Sel = "";
         AV35TFContaNomeConta = "";
         AV41Contawwds_1_filterfulltext = "";
         AV42Contawwds_2_dynamicfiltersselector1 = "";
         AV46Contawwds_6_dynamicfiltersselector2 = "";
         AV50Contawwds_10_dynamicfiltersselector3 = "";
         AV53Contawwds_13_tfcontanomeconta = "";
         AV54Contawwds_14_tfcontanomeconta_sel = "";
         lV41Contawwds_1_filterfulltext = "";
         lV53Contawwds_13_tfcontanomeconta = "";
         A424ContaNomeConta = "";
         P00A22_A423ContaSaldoAtual = new decimal[1] ;
         P00A22_n423ContaSaldoAtual = new bool[] {false} ;
         P00A22_A430ContaStatus = new bool[] {false} ;
         P00A22_n430ContaStatus = new bool[] {false} ;
         P00A22_A424ContaNomeConta = new string[] {""} ;
         P00A22_n424ContaNomeConta = new bool[] {false} ;
         P00A22_A422ContaId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contawwexport__default(),
            new Object[][] {
                new Object[] {
               P00A22_A423ContaSaldoAtual, P00A22_n423ContaSaldoAtual, P00A22_A430ContaStatus, P00A22_n430ContaStatus, P00A22_A424ContaNomeConta, P00A22_n424ContaNomeConta, P00A22_A422ContaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV37TFContaStatus_Sel ;
      private short GXt_int2 ;
      private short AV43Contawwds_3_dynamicfiltersoperator1 ;
      private short AV47Contawwds_7_dynamicfiltersoperator2 ;
      private short AV51Contawwds_11_dynamicfiltersoperator3 ;
      private short AV57Contawwds_17_tfcontastatus_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A422ContaId ;
      private int AV58GXV1 ;
      private decimal AV21ContaSaldoAtual1 ;
      private decimal AV25ContaSaldoAtual2 ;
      private decimal AV29ContaSaldoAtual3 ;
      private decimal AV38TFContaSaldoAtual ;
      private decimal AV39TFContaSaldoAtual_To ;
      private decimal AV44Contawwds_4_contasaldoatual1 ;
      private decimal AV48Contawwds_8_contasaldoatual2 ;
      private decimal AV52Contawwds_12_contasaldoatual3 ;
      private decimal AV55Contawwds_15_tfcontasaldoatual ;
      private decimal AV56Contawwds_16_tfcontasaldoatual_to ;
      private decimal A423ContaSaldoAtual ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV45Contawwds_5_dynamicfiltersenabled2 ;
      private bool AV49Contawwds_9_dynamicfiltersenabled3 ;
      private bool A430ContaStatus ;
      private bool AV17OrderedDsc ;
      private bool n423ContaSaldoAtual ;
      private bool n430ContaStatus ;
      private bool n424ContaNomeConta ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV36TFContaNomeConta_Sel ;
      private string AV35TFContaNomeConta ;
      private string AV41Contawwds_1_filterfulltext ;
      private string AV42Contawwds_2_dynamicfiltersselector1 ;
      private string AV46Contawwds_6_dynamicfiltersselector2 ;
      private string AV50Contawwds_10_dynamicfiltersselector3 ;
      private string AV53Contawwds_13_tfcontanomeconta ;
      private string AV54Contawwds_14_tfcontanomeconta_sel ;
      private string lV41Contawwds_1_filterfulltext ;
      private string lV53Contawwds_13_tfcontanomeconta ;
      private string A424ContaNomeConta ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00A22_A423ContaSaldoAtual ;
      private bool[] P00A22_n423ContaSaldoAtual ;
      private bool[] P00A22_A430ContaStatus ;
      private bool[] P00A22_n430ContaStatus ;
      private string[] P00A22_A424ContaNomeConta ;
      private bool[] P00A22_n424ContaNomeConta ;
      private int[] P00A22_A422ContaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class contawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A22( IGxContext context ,
                                             string AV41Contawwds_1_filterfulltext ,
                                             string AV42Contawwds_2_dynamicfiltersselector1 ,
                                             short AV43Contawwds_3_dynamicfiltersoperator1 ,
                                             decimal AV44Contawwds_4_contasaldoatual1 ,
                                             bool AV45Contawwds_5_dynamicfiltersenabled2 ,
                                             string AV46Contawwds_6_dynamicfiltersselector2 ,
                                             short AV47Contawwds_7_dynamicfiltersoperator2 ,
                                             decimal AV48Contawwds_8_contasaldoatual2 ,
                                             bool AV49Contawwds_9_dynamicfiltersenabled3 ,
                                             string AV50Contawwds_10_dynamicfiltersselector3 ,
                                             short AV51Contawwds_11_dynamicfiltersoperator3 ,
                                             decimal AV52Contawwds_12_contasaldoatual3 ,
                                             string AV54Contawwds_14_tfcontanomeconta_sel ,
                                             string AV53Contawwds_13_tfcontanomeconta ,
                                             decimal AV55Contawwds_15_tfcontasaldoatual ,
                                             decimal AV56Contawwds_16_tfcontasaldoatual_to ,
                                             short AV57Contawwds_17_tfcontastatus_sel ,
                                             string A424ContaNomeConta ,
                                             decimal A423ContaSaldoAtual ,
                                             bool A430ContaStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ContaSaldoAtual, ContaStatus, ContaNomeConta, ContaId FROM Conta";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Contawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ContaNomeConta like '%' || :lV41Contawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ContaSaldoAtual,'999999999999990.99'), 2) like '%' || :lV41Contawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV41Contawwds_1_filterfulltext) and ContaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV41Contawwds_1_filterfulltext) and ContaStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Contawwds_2_dynamicfiltersselector1, "CONTASALDOATUAL") == 0 ) && ( AV43Contawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV44Contawwds_4_contasaldoatual1) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual < :AV44Contawwds_4_contasaldoatual1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Contawwds_2_dynamicfiltersselector1, "CONTASALDOATUAL") == 0 ) && ( AV43Contawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV44Contawwds_4_contasaldoatual1) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual = :AV44Contawwds_4_contasaldoatual1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV42Contawwds_2_dynamicfiltersselector1, "CONTASALDOATUAL") == 0 ) && ( AV43Contawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV44Contawwds_4_contasaldoatual1) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual > :AV44Contawwds_4_contasaldoatual1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV45Contawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Contawwds_6_dynamicfiltersselector2, "CONTASALDOATUAL") == 0 ) && ( AV47Contawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV48Contawwds_8_contasaldoatual2) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual < :AV48Contawwds_8_contasaldoatual2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV45Contawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Contawwds_6_dynamicfiltersselector2, "CONTASALDOATUAL") == 0 ) && ( AV47Contawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV48Contawwds_8_contasaldoatual2) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual = :AV48Contawwds_8_contasaldoatual2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV45Contawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV46Contawwds_6_dynamicfiltersselector2, "CONTASALDOATUAL") == 0 ) && ( AV47Contawwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV48Contawwds_8_contasaldoatual2) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual > :AV48Contawwds_8_contasaldoatual2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV49Contawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Contawwds_10_dynamicfiltersselector3, "CONTASALDOATUAL") == 0 ) && ( AV51Contawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV52Contawwds_12_contasaldoatual3) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual < :AV52Contawwds_12_contasaldoatual3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV49Contawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Contawwds_10_dynamicfiltersselector3, "CONTASALDOATUAL") == 0 ) && ( AV51Contawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV52Contawwds_12_contasaldoatual3) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual = :AV52Contawwds_12_contasaldoatual3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV49Contawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Contawwds_10_dynamicfiltersselector3, "CONTASALDOATUAL") == 0 ) && ( AV51Contawwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV52Contawwds_12_contasaldoatual3) ) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual > :AV52Contawwds_12_contasaldoatual3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Contawwds_14_tfcontanomeconta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contawwds_13_tfcontanomeconta)) ) )
         {
            AddWhere(sWhereString, "(ContaNomeConta like :lV53Contawwds_13_tfcontanomeconta)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Contawwds_14_tfcontanomeconta_sel)) && ! ( StringUtil.StrCmp(AV54Contawwds_14_tfcontanomeconta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ContaNomeConta = ( :AV54Contawwds_14_tfcontanomeconta_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV54Contawwds_14_tfcontanomeconta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ContaNomeConta IS NULL or (char_length(trim(trailing ' ' from ContaNomeConta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV55Contawwds_15_tfcontasaldoatual) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual >= :AV55Contawwds_15_tfcontasaldoatual)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Contawwds_16_tfcontasaldoatual_to) )
         {
            AddWhere(sWhereString, "(ContaSaldoAtual <= :AV56Contawwds_16_tfcontasaldoatual_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV57Contawwds_17_tfcontastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ContaStatus = TRUE)");
         }
         if ( AV57Contawwds_17_tfcontastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ContaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ContaSaldoAtual";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ContaSaldoAtual DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ContaNomeConta";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ContaNomeConta DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ContaStatus";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ContaStatus DESC";
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
                     return conditional_P00A22(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00A22;
          prmP00A22 = new Object[] {
          new ParDef("lV41Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Contawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV44Contawwds_4_contasaldoatual1",GXType.Number,18,2) ,
          new ParDef("AV44Contawwds_4_contasaldoatual1",GXType.Number,18,2) ,
          new ParDef("AV44Contawwds_4_contasaldoatual1",GXType.Number,18,2) ,
          new ParDef("AV48Contawwds_8_contasaldoatual2",GXType.Number,18,2) ,
          new ParDef("AV48Contawwds_8_contasaldoatual2",GXType.Number,18,2) ,
          new ParDef("AV48Contawwds_8_contasaldoatual2",GXType.Number,18,2) ,
          new ParDef("AV52Contawwds_12_contasaldoatual3",GXType.Number,18,2) ,
          new ParDef("AV52Contawwds_12_contasaldoatual3",GXType.Number,18,2) ,
          new ParDef("AV52Contawwds_12_contasaldoatual3",GXType.Number,18,2) ,
          new ParDef("lV53Contawwds_13_tfcontanomeconta",GXType.VarChar,60,2) ,
          new ParDef("AV54Contawwds_14_tfcontanomeconta_sel",GXType.VarChar,60,2) ,
          new ParDef("AV55Contawwds_15_tfcontasaldoatual",GXType.Number,18,2) ,
          new ParDef("AV56Contawwds_16_tfcontasaldoatual_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00A22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
