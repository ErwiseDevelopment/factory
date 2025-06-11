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
   public class especialidadewwexport : GXProcedure
   {
      public especialidadewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public especialidadewwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "EspecialidadeWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "ESPECIALIDADENOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21EspecialidadeNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21EspecialidadeNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Especialidade", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Especialidade", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21EspecialidadeNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "ESPECIALIDADENOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25EspecialidadeNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EspecialidadeNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Especialidade", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Especialidade", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25EspecialidadeNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "ESPECIALIDADENOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29EspecialidadeNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EspecialidadeNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Especialidade", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Especialidade", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29EspecialidadeNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEspecialidadeNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Especialidade") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEspecialidadeNome_Sel)) ? "(Vazio)" : AV36TFEspecialidadeNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEspecialidadeNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Especialidade") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFEspecialidadeNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV37TFEspecialidadeStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV37TFEspecialidadeStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV37TFEspecialidadeStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Especialidade";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV39Especialidadewwds_1_filterfulltext = AV18FilterFullText;
         AV40Especialidadewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV41Especialidadewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV42Especialidadewwds_4_especialidadenome1 = AV21EspecialidadeNome1;
         AV43Especialidadewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV44Especialidadewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV45Especialidadewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV46Especialidadewwds_8_especialidadenome2 = AV25EspecialidadeNome2;
         AV47Especialidadewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV48Especialidadewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV49Especialidadewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV50Especialidadewwds_12_especialidadenome3 = AV29EspecialidadeNome3;
         AV51Especialidadewwds_13_tfespecialidadenome = AV35TFEspecialidadeNome;
         AV52Especialidadewwds_14_tfespecialidadenome_sel = AV36TFEspecialidadeNome_Sel;
         AV53Especialidadewwds_15_tfespecialidadestatus_sel = AV37TFEspecialidadeStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39Especialidadewwds_1_filterfulltext ,
                                              AV40Especialidadewwds_2_dynamicfiltersselector1 ,
                                              AV41Especialidadewwds_3_dynamicfiltersoperator1 ,
                                              AV42Especialidadewwds_4_especialidadenome1 ,
                                              AV43Especialidadewwds_5_dynamicfiltersenabled2 ,
                                              AV44Especialidadewwds_6_dynamicfiltersselector2 ,
                                              AV45Especialidadewwds_7_dynamicfiltersoperator2 ,
                                              AV46Especialidadewwds_8_especialidadenome2 ,
                                              AV47Especialidadewwds_9_dynamicfiltersenabled3 ,
                                              AV48Especialidadewwds_10_dynamicfiltersselector3 ,
                                              AV49Especialidadewwds_11_dynamicfiltersoperator3 ,
                                              AV50Especialidadewwds_12_especialidadenome3 ,
                                              AV52Especialidadewwds_14_tfespecialidadenome_sel ,
                                              AV51Especialidadewwds_13_tfespecialidadenome ,
                                              AV53Especialidadewwds_15_tfespecialidadestatus_sel ,
                                              A458EspecialidadeNome ,
                                              A595EspecialidadeStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV39Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Especialidadewwds_1_filterfulltext), "%", "");
         lV39Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Especialidadewwds_1_filterfulltext), "%", "");
         lV39Especialidadewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Especialidadewwds_1_filterfulltext), "%", "");
         lV42Especialidadewwds_4_especialidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV42Especialidadewwds_4_especialidadenome1), "%", "");
         lV42Especialidadewwds_4_especialidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV42Especialidadewwds_4_especialidadenome1), "%", "");
         lV46Especialidadewwds_8_especialidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV46Especialidadewwds_8_especialidadenome2), "%", "");
         lV46Especialidadewwds_8_especialidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV46Especialidadewwds_8_especialidadenome2), "%", "");
         lV50Especialidadewwds_12_especialidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV50Especialidadewwds_12_especialidadenome3), "%", "");
         lV50Especialidadewwds_12_especialidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV50Especialidadewwds_12_especialidadenome3), "%", "");
         lV51Especialidadewwds_13_tfespecialidadenome = StringUtil.Concat( StringUtil.RTrim( AV51Especialidadewwds_13_tfespecialidadenome), "%", "");
         /* Using cursor P00BO2 */
         pr_default.execute(0, new Object[] {lV39Especialidadewwds_1_filterfulltext, lV39Especialidadewwds_1_filterfulltext, lV39Especialidadewwds_1_filterfulltext, lV42Especialidadewwds_4_especialidadenome1, lV42Especialidadewwds_4_especialidadenome1, lV46Especialidadewwds_8_especialidadenome2, lV46Especialidadewwds_8_especialidadenome2, lV50Especialidadewwds_12_especialidadenome3, lV50Especialidadewwds_12_especialidadenome3, lV51Especialidadewwds_13_tfespecialidadenome, AV52Especialidadewwds_14_tfespecialidadenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A595EspecialidadeStatus = P00BO2_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = P00BO2_n595EspecialidadeStatus[0];
            A458EspecialidadeNome = P00BO2_A458EspecialidadeNome[0];
            n458EspecialidadeNome = P00BO2_n458EspecialidadeNome[0];
            A457EspecialidadeId = P00BO2_A457EspecialidadeId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A458EspecialidadeNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A595EspecialidadeStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A595EspecialidadeStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A595EspecialidadeStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A595EspecialidadeStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV31Session.Set("WWPExportFileName", "EspecialidadeWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("EspecialidadeWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EspecialidadeWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("EspecialidadeWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADENOME") == 0 )
            {
               AV35TFEspecialidadeNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADENOME_SEL") == 0 )
            {
               AV36TFEspecialidadeNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESPECIALIDADESTATUS_SEL") == 0 )
            {
               AV37TFEspecialidadeStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV54GXV1 = (int)(AV54GXV1+1);
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
         AV21EspecialidadeNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25EspecialidadeNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29EspecialidadeNome3 = "";
         AV36TFEspecialidadeNome_Sel = "";
         AV35TFEspecialidadeNome = "";
         AV39Especialidadewwds_1_filterfulltext = "";
         AV40Especialidadewwds_2_dynamicfiltersselector1 = "";
         AV42Especialidadewwds_4_especialidadenome1 = "";
         AV44Especialidadewwds_6_dynamicfiltersselector2 = "";
         AV46Especialidadewwds_8_especialidadenome2 = "";
         AV48Especialidadewwds_10_dynamicfiltersselector3 = "";
         AV50Especialidadewwds_12_especialidadenome3 = "";
         AV51Especialidadewwds_13_tfespecialidadenome = "";
         AV52Especialidadewwds_14_tfespecialidadenome_sel = "";
         lV39Especialidadewwds_1_filterfulltext = "";
         lV42Especialidadewwds_4_especialidadenome1 = "";
         lV46Especialidadewwds_8_especialidadenome2 = "";
         lV50Especialidadewwds_12_especialidadenome3 = "";
         lV51Especialidadewwds_13_tfespecialidadenome = "";
         A458EspecialidadeNome = "";
         P00BO2_A595EspecialidadeStatus = new bool[] {false} ;
         P00BO2_n595EspecialidadeStatus = new bool[] {false} ;
         P00BO2_A458EspecialidadeNome = new string[] {""} ;
         P00BO2_n458EspecialidadeNome = new bool[] {false} ;
         P00BO2_A457EspecialidadeId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.especialidadewwexport__default(),
            new Object[][] {
                new Object[] {
               P00BO2_A595EspecialidadeStatus, P00BO2_n595EspecialidadeStatus, P00BO2_A458EspecialidadeNome, P00BO2_n458EspecialidadeNome, P00BO2_A457EspecialidadeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV37TFEspecialidadeStatus_Sel ;
      private short GXt_int2 ;
      private short AV41Especialidadewwds_3_dynamicfiltersoperator1 ;
      private short AV45Especialidadewwds_7_dynamicfiltersoperator2 ;
      private short AV49Especialidadewwds_11_dynamicfiltersoperator3 ;
      private short AV53Especialidadewwds_15_tfespecialidadestatus_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A457EspecialidadeId ;
      private int AV54GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV43Especialidadewwds_5_dynamicfiltersenabled2 ;
      private bool AV47Especialidadewwds_9_dynamicfiltersenabled3 ;
      private bool A595EspecialidadeStatus ;
      private bool AV17OrderedDsc ;
      private bool n595EspecialidadeStatus ;
      private bool n458EspecialidadeNome ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21EspecialidadeNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25EspecialidadeNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29EspecialidadeNome3 ;
      private string AV36TFEspecialidadeNome_Sel ;
      private string AV35TFEspecialidadeNome ;
      private string AV39Especialidadewwds_1_filterfulltext ;
      private string AV40Especialidadewwds_2_dynamicfiltersselector1 ;
      private string AV42Especialidadewwds_4_especialidadenome1 ;
      private string AV44Especialidadewwds_6_dynamicfiltersselector2 ;
      private string AV46Especialidadewwds_8_especialidadenome2 ;
      private string AV48Especialidadewwds_10_dynamicfiltersselector3 ;
      private string AV50Especialidadewwds_12_especialidadenome3 ;
      private string AV51Especialidadewwds_13_tfespecialidadenome ;
      private string AV52Especialidadewwds_14_tfespecialidadenome_sel ;
      private string lV39Especialidadewwds_1_filterfulltext ;
      private string lV42Especialidadewwds_4_especialidadenome1 ;
      private string lV46Especialidadewwds_8_especialidadenome2 ;
      private string lV50Especialidadewwds_12_especialidadenome3 ;
      private string lV51Especialidadewwds_13_tfespecialidadenome ;
      private string A458EspecialidadeNome ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P00BO2_A595EspecialidadeStatus ;
      private bool[] P00BO2_n595EspecialidadeStatus ;
      private string[] P00BO2_A458EspecialidadeNome ;
      private bool[] P00BO2_n458EspecialidadeNome ;
      private int[] P00BO2_A457EspecialidadeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class especialidadewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BO2( IGxContext context ,
                                             string AV39Especialidadewwds_1_filterfulltext ,
                                             string AV40Especialidadewwds_2_dynamicfiltersselector1 ,
                                             short AV41Especialidadewwds_3_dynamicfiltersoperator1 ,
                                             string AV42Especialidadewwds_4_especialidadenome1 ,
                                             bool AV43Especialidadewwds_5_dynamicfiltersenabled2 ,
                                             string AV44Especialidadewwds_6_dynamicfiltersselector2 ,
                                             short AV45Especialidadewwds_7_dynamicfiltersoperator2 ,
                                             string AV46Especialidadewwds_8_especialidadenome2 ,
                                             bool AV47Especialidadewwds_9_dynamicfiltersenabled3 ,
                                             string AV48Especialidadewwds_10_dynamicfiltersselector3 ,
                                             short AV49Especialidadewwds_11_dynamicfiltersoperator3 ,
                                             string AV50Especialidadewwds_12_especialidadenome3 ,
                                             string AV52Especialidadewwds_14_tfespecialidadenome_sel ,
                                             string AV51Especialidadewwds_13_tfespecialidadenome ,
                                             short AV53Especialidadewwds_15_tfespecialidadestatus_sel ,
                                             string A458EspecialidadeNome ,
                                             bool A595EspecialidadeStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT EspecialidadeStatus, EspecialidadeNome, EspecialidadeId FROM Especialidade";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Especialidadewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EspecialidadeNome like '%' || :lV39Especialidadewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV39Especialidadewwds_1_filterfulltext) and EspecialidadeStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV39Especialidadewwds_1_filterfulltext) and EspecialidadeStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV40Especialidadewwds_2_dynamicfiltersselector1, "ESPECIALIDADENOME") == 0 ) && ( AV41Especialidadewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Especialidadewwds_4_especialidadenome1)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV42Especialidadewwds_4_especialidadenome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV40Especialidadewwds_2_dynamicfiltersselector1, "ESPECIALIDADENOME") == 0 ) && ( AV41Especialidadewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Especialidadewwds_4_especialidadenome1)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV42Especialidadewwds_4_especialidadenome1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV43Especialidadewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV44Especialidadewwds_6_dynamicfiltersselector2, "ESPECIALIDADENOME") == 0 ) && ( AV45Especialidadewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Especialidadewwds_8_especialidadenome2)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV46Especialidadewwds_8_especialidadenome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV43Especialidadewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV44Especialidadewwds_6_dynamicfiltersselector2, "ESPECIALIDADENOME") == 0 ) && ( AV45Especialidadewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Especialidadewwds_8_especialidadenome2)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV46Especialidadewwds_8_especialidadenome2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV47Especialidadewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV48Especialidadewwds_10_dynamicfiltersselector3, "ESPECIALIDADENOME") == 0 ) && ( AV49Especialidadewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Especialidadewwds_12_especialidadenome3)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV50Especialidadewwds_12_especialidadenome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV47Especialidadewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV48Especialidadewwds_10_dynamicfiltersselector3, "ESPECIALIDADENOME") == 0 ) && ( AV49Especialidadewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Especialidadewwds_12_especialidadenome3)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like '%' || :lV50Especialidadewwds_12_especialidadenome3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Especialidadewwds_14_tfespecialidadenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Especialidadewwds_13_tfespecialidadenome)) ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome like :lV51Especialidadewwds_13_tfespecialidadenome)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Especialidadewwds_14_tfespecialidadenome_sel)) && ! ( StringUtil.StrCmp(AV52Especialidadewwds_14_tfespecialidadenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EspecialidadeNome = ( :AV52Especialidadewwds_14_tfespecialidadenome_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Especialidadewwds_14_tfespecialidadenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EspecialidadeNome IS NULL or (char_length(trim(trailing ' ' from EspecialidadeNome))=0))");
         }
         if ( AV53Especialidadewwds_15_tfespecialidadestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(EspecialidadeStatus = TRUE)");
         }
         if ( AV53Especialidadewwds_15_tfespecialidadestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(EspecialidadeStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY EspecialidadeNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EspecialidadeNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY EspecialidadeStatus";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EspecialidadeStatus DESC";
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
                     return conditional_P00BO2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP00BO2;
          prmP00BO2 = new Object[] {
          new ParDef("lV39Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV39Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV39Especialidadewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Especialidadewwds_4_especialidadenome1",GXType.VarChar,60,0) ,
          new ParDef("lV42Especialidadewwds_4_especialidadenome1",GXType.VarChar,60,0) ,
          new ParDef("lV46Especialidadewwds_8_especialidadenome2",GXType.VarChar,60,0) ,
          new ParDef("lV46Especialidadewwds_8_especialidadenome2",GXType.VarChar,60,0) ,
          new ParDef("lV50Especialidadewwds_12_especialidadenome3",GXType.VarChar,60,0) ,
          new ParDef("lV50Especialidadewwds_12_especialidadenome3",GXType.VarChar,60,0) ,
          new ParDef("lV51Especialidadewwds_13_tfespecialidadenome",GXType.VarChar,60,0) ,
          new ParDef("AV52Especialidadewwds_14_tfespecialidadenome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BO2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BO2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
