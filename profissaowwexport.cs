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
   public class profissaowwexport : GXProcedure
   {
      public profissaowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profissaowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ProfissaoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PROFISSAONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21ProfissaoNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ProfissaoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ProfissaoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFISSAONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25ProfissaoNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ProfissaoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ProfissaoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PROFISSAONOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29ProfissaoNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ProfissaoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ProfissaoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV35TFProfissaoId) && (0==AV36TFProfissaoId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV35TFProfissaoId;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV36TFProfissaoId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProfissaoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProfissaoNome_Sel)) ? "(Vazio)" : AV38TFProfissaoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProfissaoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFProfissaoNome, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Id";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Nome";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV40Profissaowwds_1_filterfulltext = AV18FilterFullText;
         AV41Profissaowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV42Profissaowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV43Profissaowwds_4_profissaonome1 = AV21ProfissaoNome1;
         AV44Profissaowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV45Profissaowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV46Profissaowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV47Profissaowwds_8_profissaonome2 = AV25ProfissaoNome2;
         AV48Profissaowwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV49Profissaowwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV50Profissaowwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV51Profissaowwds_12_profissaonome3 = AV29ProfissaoNome3;
         AV52Profissaowwds_13_tfprofissaoid = AV35TFProfissaoId;
         AV53Profissaowwds_14_tfprofissaoid_to = AV36TFProfissaoId_To;
         AV54Profissaowwds_15_tfprofissaonome = AV37TFProfissaoNome;
         AV55Profissaowwds_16_tfprofissaonome_sel = AV38TFProfissaoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Profissaowwds_1_filterfulltext ,
                                              AV41Profissaowwds_2_dynamicfiltersselector1 ,
                                              AV42Profissaowwds_3_dynamicfiltersoperator1 ,
                                              AV43Profissaowwds_4_profissaonome1 ,
                                              AV44Profissaowwds_5_dynamicfiltersenabled2 ,
                                              AV45Profissaowwds_6_dynamicfiltersselector2 ,
                                              AV46Profissaowwds_7_dynamicfiltersoperator2 ,
                                              AV47Profissaowwds_8_profissaonome2 ,
                                              AV48Profissaowwds_9_dynamicfiltersenabled3 ,
                                              AV49Profissaowwds_10_dynamicfiltersselector3 ,
                                              AV50Profissaowwds_11_dynamicfiltersoperator3 ,
                                              AV51Profissaowwds_12_profissaonome3 ,
                                              AV52Profissaowwds_13_tfprofissaoid ,
                                              AV53Profissaowwds_14_tfprofissaoid_to ,
                                              AV55Profissaowwds_16_tfprofissaonome_sel ,
                                              AV54Profissaowwds_15_tfprofissaonome ,
                                              A440ProfissaoId ,
                                              A441ProfissaoNome ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV40Profissaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Profissaowwds_1_filterfulltext), "%", "");
         lV40Profissaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Profissaowwds_1_filterfulltext), "%", "");
         lV43Profissaowwds_4_profissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV43Profissaowwds_4_profissaonome1), "%", "");
         lV43Profissaowwds_4_profissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV43Profissaowwds_4_profissaonome1), "%", "");
         lV47Profissaowwds_8_profissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV47Profissaowwds_8_profissaonome2), "%", "");
         lV47Profissaowwds_8_profissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV47Profissaowwds_8_profissaonome2), "%", "");
         lV51Profissaowwds_12_profissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV51Profissaowwds_12_profissaonome3), "%", "");
         lV51Profissaowwds_12_profissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV51Profissaowwds_12_profissaonome3), "%", "");
         lV54Profissaowwds_15_tfprofissaonome = StringUtil.Concat( StringUtil.RTrim( AV54Profissaowwds_15_tfprofissaonome), "%", "");
         /* Using cursor P00A72 */
         pr_default.execute(0, new Object[] {lV40Profissaowwds_1_filterfulltext, lV40Profissaowwds_1_filterfulltext, lV43Profissaowwds_4_profissaonome1, lV43Profissaowwds_4_profissaonome1, lV47Profissaowwds_8_profissaonome2, lV47Profissaowwds_8_profissaonome2, lV51Profissaowwds_12_profissaonome3, lV51Profissaowwds_12_profissaonome3, AV52Profissaowwds_13_tfprofissaoid, AV53Profissaowwds_14_tfprofissaoid_to, lV54Profissaowwds_15_tfprofissaonome, AV55Profissaowwds_16_tfprofissaonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A440ProfissaoId = P00A72_A440ProfissaoId[0];
            A441ProfissaoNome = P00A72_A441ProfissaoNome[0];
            n441ProfissaoNome = P00A72_n441ProfissaoNome[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A440ProfissaoId;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A441ProfissaoNome, out  GXt_char1) ;
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
         AV31Session.Set("WWPExportFileName", "ProfissaoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ProfissaoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfissaoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ProfissaoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROFISSAOID") == 0 )
            {
               AV35TFProfissaoId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFProfissaoId_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROFISSAONOME") == 0 )
            {
               AV37TFProfissaoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROFISSAONOME_SEL") == 0 )
            {
               AV38TFProfissaoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
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
         AV21ProfissaoNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ProfissaoNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ProfissaoNome3 = "";
         AV38TFProfissaoNome_Sel = "";
         AV37TFProfissaoNome = "";
         AV40Profissaowwds_1_filterfulltext = "";
         AV41Profissaowwds_2_dynamicfiltersselector1 = "";
         AV43Profissaowwds_4_profissaonome1 = "";
         AV45Profissaowwds_6_dynamicfiltersselector2 = "";
         AV47Profissaowwds_8_profissaonome2 = "";
         AV49Profissaowwds_10_dynamicfiltersselector3 = "";
         AV51Profissaowwds_12_profissaonome3 = "";
         AV54Profissaowwds_15_tfprofissaonome = "";
         AV55Profissaowwds_16_tfprofissaonome_sel = "";
         lV40Profissaowwds_1_filterfulltext = "";
         lV43Profissaowwds_4_profissaonome1 = "";
         lV47Profissaowwds_8_profissaonome2 = "";
         lV51Profissaowwds_12_profissaonome3 = "";
         lV54Profissaowwds_15_tfprofissaonome = "";
         A441ProfissaoNome = "";
         P00A72_A440ProfissaoId = new int[1] ;
         P00A72_A441ProfissaoNome = new string[] {""} ;
         P00A72_n441ProfissaoNome = new bool[] {false} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profissaowwexport__default(),
            new Object[][] {
                new Object[] {
               P00A72_A440ProfissaoId, P00A72_A441ProfissaoNome, P00A72_n441ProfissaoNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV42Profissaowwds_3_dynamicfiltersoperator1 ;
      private short AV46Profissaowwds_7_dynamicfiltersoperator2 ;
      private short AV50Profissaowwds_11_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV35TFProfissaoId ;
      private int AV36TFProfissaoId_To ;
      private int AV52Profissaowwds_13_tfprofissaoid ;
      private int AV53Profissaowwds_14_tfprofissaoid_to ;
      private int A440ProfissaoId ;
      private int AV56GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV44Profissaowwds_5_dynamicfiltersenabled2 ;
      private bool AV48Profissaowwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n441ProfissaoNome ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ProfissaoNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ProfissaoNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ProfissaoNome3 ;
      private string AV38TFProfissaoNome_Sel ;
      private string AV37TFProfissaoNome ;
      private string AV40Profissaowwds_1_filterfulltext ;
      private string AV41Profissaowwds_2_dynamicfiltersselector1 ;
      private string AV43Profissaowwds_4_profissaonome1 ;
      private string AV45Profissaowwds_6_dynamicfiltersselector2 ;
      private string AV47Profissaowwds_8_profissaonome2 ;
      private string AV49Profissaowwds_10_dynamicfiltersselector3 ;
      private string AV51Profissaowwds_12_profissaonome3 ;
      private string AV54Profissaowwds_15_tfprofissaonome ;
      private string AV55Profissaowwds_16_tfprofissaonome_sel ;
      private string lV40Profissaowwds_1_filterfulltext ;
      private string lV43Profissaowwds_4_profissaonome1 ;
      private string lV47Profissaowwds_8_profissaonome2 ;
      private string lV51Profissaowwds_12_profissaonome3 ;
      private string lV54Profissaowwds_15_tfprofissaonome ;
      private string A441ProfissaoNome ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00A72_A440ProfissaoId ;
      private string[] P00A72_A441ProfissaoNome ;
      private bool[] P00A72_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class profissaowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A72( IGxContext context ,
                                             string AV40Profissaowwds_1_filterfulltext ,
                                             string AV41Profissaowwds_2_dynamicfiltersselector1 ,
                                             short AV42Profissaowwds_3_dynamicfiltersoperator1 ,
                                             string AV43Profissaowwds_4_profissaonome1 ,
                                             bool AV44Profissaowwds_5_dynamicfiltersenabled2 ,
                                             string AV45Profissaowwds_6_dynamicfiltersselector2 ,
                                             short AV46Profissaowwds_7_dynamicfiltersoperator2 ,
                                             string AV47Profissaowwds_8_profissaonome2 ,
                                             bool AV48Profissaowwds_9_dynamicfiltersenabled3 ,
                                             string AV49Profissaowwds_10_dynamicfiltersselector3 ,
                                             short AV50Profissaowwds_11_dynamicfiltersoperator3 ,
                                             string AV51Profissaowwds_12_profissaonome3 ,
                                             int AV52Profissaowwds_13_tfprofissaoid ,
                                             int AV53Profissaowwds_14_tfprofissaoid_to ,
                                             string AV55Profissaowwds_16_tfprofissaonome_sel ,
                                             string AV54Profissaowwds_15_tfprofissaonome ,
                                             int A440ProfissaoId ,
                                             string A441ProfissaoNome ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ProfissaoId, ProfissaoNome FROM Profissao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Profissaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ProfissaoId,'999999999'), 2) like '%' || :lV40Profissaowwds_1_filterfulltext) or ( ProfissaoNome like '%' || :lV40Profissaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV41Profissaowwds_2_dynamicfiltersselector1, "PROFISSAONOME") == 0 ) && ( AV42Profissaowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Profissaowwds_4_profissaonome1)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV43Profissaowwds_4_profissaonome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV41Profissaowwds_2_dynamicfiltersselector1, "PROFISSAONOME") == 0 ) && ( AV42Profissaowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Profissaowwds_4_profissaonome1)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV43Profissaowwds_4_profissaonome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV44Profissaowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV45Profissaowwds_6_dynamicfiltersselector2, "PROFISSAONOME") == 0 ) && ( AV46Profissaowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Profissaowwds_8_profissaonome2)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV47Profissaowwds_8_profissaonome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV44Profissaowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV45Profissaowwds_6_dynamicfiltersselector2, "PROFISSAONOME") == 0 ) && ( AV46Profissaowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Profissaowwds_8_profissaonome2)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV47Profissaowwds_8_profissaonome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV48Profissaowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV49Profissaowwds_10_dynamicfiltersselector3, "PROFISSAONOME") == 0 ) && ( AV50Profissaowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Profissaowwds_12_profissaonome3)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV51Profissaowwds_12_profissaonome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV48Profissaowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV49Profissaowwds_10_dynamicfiltersselector3, "PROFISSAONOME") == 0 ) && ( AV50Profissaowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Profissaowwds_12_profissaonome3)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV51Profissaowwds_12_profissaonome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV52Profissaowwds_13_tfprofissaoid) )
         {
            AddWhere(sWhereString, "(ProfissaoId >= :AV52Profissaowwds_13_tfprofissaoid)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV53Profissaowwds_14_tfprofissaoid_to) )
         {
            AddWhere(sWhereString, "(ProfissaoId <= :AV53Profissaowwds_14_tfprofissaoid_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Profissaowwds_16_tfprofissaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Profissaowwds_15_tfprofissaonome)) ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like :lV54Profissaowwds_15_tfprofissaonome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Profissaowwds_16_tfprofissaonome_sel)) && ! ( StringUtil.StrCmp(AV55Profissaowwds_16_tfprofissaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProfissaoNome = ( :AV55Profissaowwds_16_tfprofissaonome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV55Profissaowwds_16_tfprofissaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from ProfissaoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ProfissaoNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ProfissaoNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ProfissaoId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ProfissaoId DESC";
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
                     return conditional_P00A72(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00A72;
          prmP00A72 = new Object[] {
          new ParDef("lV40Profissaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Profissaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Profissaowwds_4_profissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV43Profissaowwds_4_profissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV47Profissaowwds_8_profissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV47Profissaowwds_8_profissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV51Profissaowwds_12_profissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV51Profissaowwds_12_profissaonome3",GXType.VarChar,90,0) ,
          new ParDef("AV52Profissaowwds_13_tfprofissaoid",GXType.Int32,9,0) ,
          new ParDef("AV53Profissaowwds_14_tfprofissaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV54Profissaowwds_15_tfprofissaonome",GXType.VarChar,90,0) ,
          new ParDef("AV55Profissaowwds_16_tfprofissaonome_sel",GXType.VarChar,90,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A72,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
