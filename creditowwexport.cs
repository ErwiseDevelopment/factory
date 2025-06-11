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
   public class creditowwexport : GXProcedure
   {
      public creditowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public creditowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "CreditoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CREDITOVALOR") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21CreditoValor1 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV21CreditoValor1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV21CreditoValor1);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CREDITOVALOR") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25CreditoValor2 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV25CreditoValor2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV25CreditoValor2);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CREDITOVALOR") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29CreditoValor3 = NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV29CreditoValor3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV29CreditoValor3);
                     }
                  }
               }
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV39TFCreditoValor) && (Convert.ToDecimal(0)==AV40TFCreditoValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV39TFCreditoValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV40TFCreditoValor_To);
         }
         if ( ! ( (DateTime.MinValue==AV41TFCreditoVigencia) && (DateTime.MinValue==AV42TFCreditoVigencia_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vigência") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV41TFCreditoVigencia ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV42TFCreditoVigencia_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Vigência";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV51Creditowwds_1_clienteid = AV49ClienteId;
         AV52Creditowwds_2_filterfulltext = AV18FilterFullText;
         AV53Creditowwds_3_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV54Creditowwds_4_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV55Creditowwds_5_creditovalor1 = AV21CreditoValor1;
         AV56Creditowwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV57Creditowwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV58Creditowwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV59Creditowwds_9_creditovalor2 = AV25CreditoValor2;
         AV60Creditowwds_10_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV61Creditowwds_11_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV62Creditowwds_12_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV63Creditowwds_13_creditovalor3 = AV29CreditoValor3;
         AV64Creditowwds_14_tfcreditovalor = AV39TFCreditoValor;
         AV65Creditowwds_15_tfcreditovalor_to = AV40TFCreditoValor_To;
         AV66Creditowwds_16_tfcreditovigencia = AV41TFCreditoVigencia;
         AV67Creditowwds_17_tfcreditovigencia_to = AV42TFCreditoVigencia_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Creditowwds_2_filterfulltext ,
                                              AV53Creditowwds_3_dynamicfiltersselector1 ,
                                              AV54Creditowwds_4_dynamicfiltersoperator1 ,
                                              AV55Creditowwds_5_creditovalor1 ,
                                              AV56Creditowwds_6_dynamicfiltersenabled2 ,
                                              AV57Creditowwds_7_dynamicfiltersselector2 ,
                                              AV58Creditowwds_8_dynamicfiltersoperator2 ,
                                              AV59Creditowwds_9_creditovalor2 ,
                                              AV60Creditowwds_10_dynamicfiltersenabled3 ,
                                              AV61Creditowwds_11_dynamicfiltersselector3 ,
                                              AV62Creditowwds_12_dynamicfiltersoperator3 ,
                                              AV63Creditowwds_13_creditovalor3 ,
                                              AV64Creditowwds_14_tfcreditovalor ,
                                              AV65Creditowwds_15_tfcreditovalor_to ,
                                              AV66Creditowwds_16_tfcreditovigencia ,
                                              AV67Creditowwds_17_tfcreditovigencia_to ,
                                              A857CreditoValor ,
                                              A858CreditoVigencia ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV51Creditowwds_1_clienteid ,
                                              A168ClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV52Creditowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Creditowwds_2_filterfulltext), "%", "");
         /* Using cursor P00DL2 */
         pr_default.execute(0, new Object[] {AV51Creditowwds_1_clienteid, lV52Creditowwds_2_filterfulltext, AV55Creditowwds_5_creditovalor1, AV55Creditowwds_5_creditovalor1, AV55Creditowwds_5_creditovalor1, AV59Creditowwds_9_creditovalor2, AV59Creditowwds_9_creditovalor2, AV59Creditowwds_9_creditovalor2, AV63Creditowwds_13_creditovalor3, AV63Creditowwds_13_creditovalor3, AV63Creditowwds_13_creditovalor3, AV64Creditowwds_14_tfcreditovalor, AV65Creditowwds_15_tfcreditovalor_to, AV66Creditowwds_16_tfcreditovigencia, AV67Creditowwds_17_tfcreditovigencia_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A858CreditoVigencia = P00DL2_A858CreditoVigencia[0];
            n858CreditoVigencia = P00DL2_n858CreditoVigencia[0];
            A857CreditoValor = P00DL2_A857CreditoValor[0];
            n857CreditoValor = P00DL2_n857CreditoValor[0];
            A168ClienteId = P00DL2_A168ClienteId[0];
            n168ClienteId = P00DL2_n168ClienteId[0];
            A856CreditoId = P00DL2_A856CreditoId[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = (double)(A857CreditoValor);
            GXt_dtime3 = DateTimeUtil.ResetTime( A858CreditoVigencia ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
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
         AV31Session.Set("WWPExportFileName", "CreditoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("CreditoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CreditoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("CreditoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCREDITOVALOR") == 0 )
            {
               AV39TFCreditoValor = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV40TFCreditoValor_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCREDITOVIGENCIA") == 0 )
            {
               AV41TFCreditoVigencia = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV42TFCreditoVigencia_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV49ClienteId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV68GXV1 = (int)(AV68GXV1+1);
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
         GXt_char1 = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV41TFCreditoVigencia = DateTime.MinValue;
         AV42TFCreditoVigencia_To = DateTime.MinValue;
         AV52Creditowwds_2_filterfulltext = "";
         AV53Creditowwds_3_dynamicfiltersselector1 = "";
         AV57Creditowwds_7_dynamicfiltersselector2 = "";
         AV61Creditowwds_11_dynamicfiltersselector3 = "";
         AV66Creditowwds_16_tfcreditovigencia = DateTime.MinValue;
         AV67Creditowwds_17_tfcreditovigencia_to = DateTime.MinValue;
         lV52Creditowwds_2_filterfulltext = "";
         A858CreditoVigencia = DateTime.MinValue;
         P00DL2_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         P00DL2_n858CreditoVigencia = new bool[] {false} ;
         P00DL2_A857CreditoValor = new decimal[1] ;
         P00DL2_n857CreditoValor = new bool[] {false} ;
         P00DL2_A168ClienteId = new int[1] ;
         P00DL2_n168ClienteId = new bool[] {false} ;
         P00DL2_A856CreditoId = new int[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.creditowwexport__default(),
            new Object[][] {
                new Object[] {
               P00DL2_A858CreditoVigencia, P00DL2_n858CreditoVigencia, P00DL2_A857CreditoValor, P00DL2_n857CreditoValor, P00DL2_A168ClienteId, P00DL2_n168ClienteId, P00DL2_A856CreditoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV54Creditowwds_4_dynamicfiltersoperator1 ;
      private short AV58Creditowwds_8_dynamicfiltersoperator2 ;
      private short AV62Creditowwds_12_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV51Creditowwds_1_clienteid ;
      private int AV49ClienteId ;
      private int A168ClienteId ;
      private int A856CreditoId ;
      private int AV68GXV1 ;
      private decimal AV21CreditoValor1 ;
      private decimal AV25CreditoValor2 ;
      private decimal AV29CreditoValor3 ;
      private decimal AV39TFCreditoValor ;
      private decimal AV40TFCreditoValor_To ;
      private decimal AV55Creditowwds_5_creditovalor1 ;
      private decimal AV59Creditowwds_9_creditovalor2 ;
      private decimal AV63Creditowwds_13_creditovalor3 ;
      private decimal AV64Creditowwds_14_tfcreditovalor ;
      private decimal AV65Creditowwds_15_tfcreditovalor_to ;
      private decimal A857CreditoValor ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV41TFCreditoVigencia ;
      private DateTime AV42TFCreditoVigencia_To ;
      private DateTime AV66Creditowwds_16_tfcreditovigencia ;
      private DateTime AV67Creditowwds_17_tfcreditovigencia_to ;
      private DateTime A858CreditoVigencia ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV56Creditowwds_6_dynamicfiltersenabled2 ;
      private bool AV60Creditowwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n858CreditoVigencia ;
      private bool n857CreditoValor ;
      private bool n168ClienteId ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV52Creditowwds_2_filterfulltext ;
      private string AV53Creditowwds_3_dynamicfiltersselector1 ;
      private string AV57Creditowwds_7_dynamicfiltersselector2 ;
      private string AV61Creditowwds_11_dynamicfiltersselector3 ;
      private string lV52Creditowwds_2_filterfulltext ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00DL2_A858CreditoVigencia ;
      private bool[] P00DL2_n858CreditoVigencia ;
      private decimal[] P00DL2_A857CreditoValor ;
      private bool[] P00DL2_n857CreditoValor ;
      private int[] P00DL2_A168ClienteId ;
      private bool[] P00DL2_n168ClienteId ;
      private int[] P00DL2_A856CreditoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class creditowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DL2( IGxContext context ,
                                             string AV52Creditowwds_2_filterfulltext ,
                                             string AV53Creditowwds_3_dynamicfiltersselector1 ,
                                             short AV54Creditowwds_4_dynamicfiltersoperator1 ,
                                             decimal AV55Creditowwds_5_creditovalor1 ,
                                             bool AV56Creditowwds_6_dynamicfiltersenabled2 ,
                                             string AV57Creditowwds_7_dynamicfiltersselector2 ,
                                             short AV58Creditowwds_8_dynamicfiltersoperator2 ,
                                             decimal AV59Creditowwds_9_creditovalor2 ,
                                             bool AV60Creditowwds_10_dynamicfiltersenabled3 ,
                                             string AV61Creditowwds_11_dynamicfiltersselector3 ,
                                             short AV62Creditowwds_12_dynamicfiltersoperator3 ,
                                             decimal AV63Creditowwds_13_creditovalor3 ,
                                             decimal AV64Creditowwds_14_tfcreditovalor ,
                                             decimal AV65Creditowwds_15_tfcreditovalor_to ,
                                             DateTime AV66Creditowwds_16_tfcreditovigencia ,
                                             DateTime AV67Creditowwds_17_tfcreditovigencia_to ,
                                             decimal A857CreditoValor ,
                                             DateTime A858CreditoVigencia ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV51Creditowwds_1_clienteid ,
                                             int A168ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[15];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT CreditoVigencia, CreditoValor, ClienteId, CreditoId FROM Credito";
         AddWhere(sWhereString, "(ClienteId = :AV51Creditowwds_1_clienteid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Creditowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(CreditoValor,'999999999999990.99'), 2) like '%' || :lV52Creditowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Creditowwds_3_dynamicfiltersselector1, "CREDITOVALOR") == 0 ) && ( AV54Creditowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55Creditowwds_5_creditovalor1) ) )
         {
            AddWhere(sWhereString, "(CreditoValor < :AV55Creditowwds_5_creditovalor1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Creditowwds_3_dynamicfiltersselector1, "CREDITOVALOR") == 0 ) && ( AV54Creditowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55Creditowwds_5_creditovalor1) ) )
         {
            AddWhere(sWhereString, "(CreditoValor = :AV55Creditowwds_5_creditovalor1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Creditowwds_3_dynamicfiltersselector1, "CREDITOVALOR") == 0 ) && ( AV54Creditowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55Creditowwds_5_creditovalor1) ) )
         {
            AddWhere(sWhereString, "(CreditoValor > :AV55Creditowwds_5_creditovalor1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV56Creditowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Creditowwds_7_dynamicfiltersselector2, "CREDITOVALOR") == 0 ) && ( AV58Creditowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV59Creditowwds_9_creditovalor2) ) )
         {
            AddWhere(sWhereString, "(CreditoValor < :AV59Creditowwds_9_creditovalor2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV56Creditowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Creditowwds_7_dynamicfiltersselector2, "CREDITOVALOR") == 0 ) && ( AV58Creditowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV59Creditowwds_9_creditovalor2) ) )
         {
            AddWhere(sWhereString, "(CreditoValor = :AV59Creditowwds_9_creditovalor2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV56Creditowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Creditowwds_7_dynamicfiltersselector2, "CREDITOVALOR") == 0 ) && ( AV58Creditowwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV59Creditowwds_9_creditovalor2) ) )
         {
            AddWhere(sWhereString, "(CreditoValor > :AV59Creditowwds_9_creditovalor2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV60Creditowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Creditowwds_11_dynamicfiltersselector3, "CREDITOVALOR") == 0 ) && ( AV62Creditowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV63Creditowwds_13_creditovalor3) ) )
         {
            AddWhere(sWhereString, "(CreditoValor < :AV63Creditowwds_13_creditovalor3)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV60Creditowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Creditowwds_11_dynamicfiltersselector3, "CREDITOVALOR") == 0 ) && ( AV62Creditowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV63Creditowwds_13_creditovalor3) ) )
         {
            AddWhere(sWhereString, "(CreditoValor = :AV63Creditowwds_13_creditovalor3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV60Creditowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Creditowwds_11_dynamicfiltersselector3, "CREDITOVALOR") == 0 ) && ( AV62Creditowwds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV63Creditowwds_13_creditovalor3) ) )
         {
            AddWhere(sWhereString, "(CreditoValor > :AV63Creditowwds_13_creditovalor3)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV64Creditowwds_14_tfcreditovalor) )
         {
            AddWhere(sWhereString, "(CreditoValor >= :AV64Creditowwds_14_tfcreditovalor)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV65Creditowwds_15_tfcreditovalor_to) )
         {
            AddWhere(sWhereString, "(CreditoValor <= :AV65Creditowwds_15_tfcreditovalor_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Creditowwds_16_tfcreditovigencia) )
         {
            AddWhere(sWhereString, "(CreditoVigencia >= :AV66Creditowwds_16_tfcreditovigencia)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Creditowwds_17_tfcreditovigencia_to) )
         {
            AddWhere(sWhereString, "(CreditoVigencia <= :AV67Creditowwds_17_tfcreditovigencia_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteId, CreditoVigencia";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteId DESC, CreditoVigencia DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteId, CreditoValor";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteId DESC, CreditoValor DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DL2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] );
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
          Object[] prmP00DL2;
          prmP00DL2 = new Object[] {
          new ParDef("AV51Creditowwds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("lV52Creditowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Creditowwds_5_creditovalor1",GXType.Number,18,2) ,
          new ParDef("AV55Creditowwds_5_creditovalor1",GXType.Number,18,2) ,
          new ParDef("AV55Creditowwds_5_creditovalor1",GXType.Number,18,2) ,
          new ParDef("AV59Creditowwds_9_creditovalor2",GXType.Number,18,2) ,
          new ParDef("AV59Creditowwds_9_creditovalor2",GXType.Number,18,2) ,
          new ParDef("AV59Creditowwds_9_creditovalor2",GXType.Number,18,2) ,
          new ParDef("AV63Creditowwds_13_creditovalor3",GXType.Number,18,2) ,
          new ParDef("AV63Creditowwds_13_creditovalor3",GXType.Number,18,2) ,
          new ParDef("AV63Creditowwds_13_creditovalor3",GXType.Number,18,2) ,
          new ParDef("AV64Creditowwds_14_tfcreditovalor",GXType.Number,18,2) ,
          new ParDef("AV65Creditowwds_15_tfcreditovalor_to",GXType.Number,18,2) ,
          new ParDef("AV66Creditowwds_16_tfcreditovigencia",GXType.Date,8,0) ,
          new ParDef("AV67Creditowwds_17_tfcreditovigencia_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
