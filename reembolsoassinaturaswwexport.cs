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
   public class reembolsoassinaturaswwexport : GXProcedure
   {
      public reembolsoassinaturaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoassinaturaswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ReembolsoAssinaturasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "REEMBOLSOASSINATURASNOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21ReembolsoAssinaturasNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ReembolsoAssinaturasNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome amigável do arquivo/documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome amigável do arquivo/documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ReembolsoAssinaturasNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "REEMBOLSOASSINATURASNOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25ReembolsoAssinaturasNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ReembolsoAssinaturasNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome amigável do arquivo/documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome amigável do arquivo/documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ReembolsoAssinaturasNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "REEMBOLSOASSINATURASNOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29ReembolsoAssinaturasNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ReembolsoAssinaturasNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome amigável do arquivo/documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome amigável do arquivo/documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ReembolsoAssinaturasNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoAssinaturasNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoAssinaturasNome_Sel)) ? "(Vazio)" : AV36TFReembolsoAssinaturasNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReembolsoAssinaturasNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFReembolsoAssinaturasNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV37TFReembolsoAssinaturasEmissao) && (DateTime.MinValue==AV38TFReembolsoAssinaturasEmissao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data/hora de emissão") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV37TFReembolsoAssinaturasEmissao;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV38TFReembolsoAssinaturasEmissao_To;
         }
         if ( ! ( ( AV43TFPropostaAssinaturaStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV44i = 1;
            AV45GXV1 = 1;
            while ( AV45GXV1 <= AV43TFPropostaAssinaturaStatus_Sels.Count )
            {
               AV42TFPropostaAssinaturaStatus_Sel = ((string)AV43TFPropostaAssinaturaStatus_Sels.Item(AV45GXV1));
               if ( AV44i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmassinaturastatus.getDescription(context,AV42TFPropostaAssinaturaStatus_Sel);
               AV44i = (long)(AV44i+1);
               AV45GXV1 = (int)(AV45GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Documento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Data/hora de emissão";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV47Reembolsoassinaturaswwds_1_reembolsoid = AV40ReembolsoId;
         AV48Reembolsoassinaturaswwds_2_filterfulltext = AV18FilterFullText;
         AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV50Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV21ReembolsoAssinaturasNome1;
         AV52Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV54Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV25ReembolsoAssinaturasNome2;
         AV56Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV58Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV29ReembolsoAssinaturasNome3;
         AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV43TFPropostaAssinaturaStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A574PropostaAssinaturaStatus ,
                                              AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                              AV48Reembolsoassinaturaswwds_2_filterfulltext ,
                                              AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                              AV50Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                              AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                              AV52Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                              AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                              AV54Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                              AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                              AV56Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                              AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                              AV58Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                              AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                              AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                              AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                              AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                              AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                              AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels.Count ,
                                              A632ReembolsoAssinaturasNome ,
                                              A633ReembolsoAssinaturasEmissao ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV47Reembolsoassinaturaswwds_1_reembolsoid ,
                                              A518ReembolsoId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV48Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV48Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV48Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV48Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV48Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
         lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
         lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
         lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
         lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
         lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
         lV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = StringUtil.Concat( StringUtil.RTrim( AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome), "%", "");
         /* Using cursor P00CC2 */
         pr_default.execute(0, new Object[] {AV47Reembolsoassinaturaswwds_1_reembolsoid, lV48Reembolsoassinaturaswwds_2_filterfulltext, lV48Reembolsoassinaturaswwds_2_filterfulltext, lV48Reembolsoassinaturaswwds_2_filterfulltext, lV48Reembolsoassinaturaswwds_2_filterfulltext, lV48Reembolsoassinaturaswwds_2_filterfulltext, lV48Reembolsoassinaturaswwds_2_filterfulltext, lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome, AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao, AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A572PropostaContratoAssinaturaId = P00CC2_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = P00CC2_n572PropostaContratoAssinaturaId[0];
            A571PropostaAssinatura = P00CC2_A571PropostaAssinatura[0];
            n571PropostaAssinatura = P00CC2_n571PropostaAssinatura[0];
            A633ReembolsoAssinaturasEmissao = P00CC2_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = P00CC2_n633ReembolsoAssinaturasEmissao[0];
            A574PropostaAssinaturaStatus = P00CC2_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = P00CC2_n574PropostaAssinaturaStatus[0];
            A632ReembolsoAssinaturasNome = P00CC2_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = P00CC2_n632ReembolsoAssinaturasNome[0];
            A518ReembolsoId = P00CC2_A518ReembolsoId[0];
            n518ReembolsoId = P00CC2_n518ReembolsoId[0];
            A631ReembolsoAssinaturasId = P00CC2_A631ReembolsoAssinaturasId[0];
            A571PropostaAssinatura = P00CC2_A571PropostaAssinatura[0];
            n571PropostaAssinatura = P00CC2_n571PropostaAssinatura[0];
            A574PropostaAssinaturaStatus = P00CC2_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = P00CC2_n574PropostaAssinaturaStatus[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A632ReembolsoAssinaturasNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = A633ReembolsoAssinaturasEmissao;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = gxdomaindmassinaturastatus.getDescription(context,A574PropostaAssinaturaStatus);
            if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "ENVIADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
            }
            else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "REJEITADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "CANCELADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "ASSINADO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "AGUARDANDO_ENVIO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
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
         AV31Session.Set("WWPExportFileName", "ReembolsoAssinaturasWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ReembolsoAssinaturasWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ReembolsoAssinaturasWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ReembolsoAssinaturasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV65GXV2 = 1;
         while ( AV65GXV2 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV65GXV2));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASNOME") == 0 )
            {
               AV35TFReembolsoAssinaturasNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASNOME_SEL") == 0 )
            {
               AV36TFReembolsoAssinaturasNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASEMISSAO") == 0 )
            {
               AV37TFReembolsoAssinaturasEmissao = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV38TFReembolsoAssinaturasEmissao_To = context.localUtil.CToT( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROPOSTAASSINATURASTATUS_SEL") == 0 )
            {
               AV41TFPropostaAssinaturaStatus_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV43TFPropostaAssinaturaStatus_Sels.FromJSonString(AV41TFPropostaAssinaturaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV39PropostaId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&REEMBOLSOID") == 0 )
            {
               AV40ReembolsoId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV65GXV2 = (int)(AV65GXV2+1);
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
         AV21ReembolsoAssinaturasNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ReembolsoAssinaturasNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ReembolsoAssinaturasNome3 = "";
         AV36TFReembolsoAssinaturasNome_Sel = "";
         AV35TFReembolsoAssinaturasNome = "";
         AV37TFReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         AV38TFReembolsoAssinaturasEmissao_To = (DateTime)(DateTime.MinValue);
         AV43TFPropostaAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV42TFPropostaAssinaturaStatus_Sel = "";
         AV48Reembolsoassinaturaswwds_2_filterfulltext = "";
         AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = "";
         AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = "";
         AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = "";
         AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = "";
         AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = "";
         AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = "";
         AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = "";
         AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = "";
         AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = (DateTime)(DateTime.MinValue);
         AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = (DateTime)(DateTime.MinValue);
         AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = new GxSimpleCollection<string>();
         lV48Reembolsoassinaturaswwds_2_filterfulltext = "";
         lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = "";
         lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = "";
         lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = "";
         lV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = "";
         A574PropostaAssinaturaStatus = "";
         A632ReembolsoAssinaturasNome = "";
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         P00CC2_A572PropostaContratoAssinaturaId = new int[1] ;
         P00CC2_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         P00CC2_A571PropostaAssinatura = new long[1] ;
         P00CC2_n571PropostaAssinatura = new bool[] {false} ;
         P00CC2_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         P00CC2_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         P00CC2_A574PropostaAssinaturaStatus = new string[] {""} ;
         P00CC2_n574PropostaAssinaturaStatus = new bool[] {false} ;
         P00CC2_A632ReembolsoAssinaturasNome = new string[] {""} ;
         P00CC2_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         P00CC2_A518ReembolsoId = new int[1] ;
         P00CC2_n518ReembolsoId = new bool[] {false} ;
         P00CC2_A631ReembolsoAssinaturasId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41TFPropostaAssinaturaStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoassinaturaswwexport__default(),
            new Object[][] {
                new Object[] {
               P00CC2_A572PropostaContratoAssinaturaId, P00CC2_n572PropostaContratoAssinaturaId, P00CC2_A571PropostaAssinatura, P00CC2_n571PropostaAssinatura, P00CC2_A633ReembolsoAssinaturasEmissao, P00CC2_n633ReembolsoAssinaturasEmissao, P00CC2_A574PropostaAssinaturaStatus, P00CC2_n574PropostaAssinaturaStatus, P00CC2_A632ReembolsoAssinaturasNome, P00CC2_n632ReembolsoAssinaturasNome,
               P00CC2_A518ReembolsoId, P00CC2_n518ReembolsoId, P00CC2_A631ReembolsoAssinaturasId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV50Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ;
      private short AV54Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ;
      private short AV58Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV45GXV1 ;
      private int AV47Reembolsoassinaturaswwds_1_reembolsoid ;
      private int AV40ReembolsoId ;
      private int AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ;
      private int A518ReembolsoId ;
      private int A572PropostaContratoAssinaturaId ;
      private int A631ReembolsoAssinaturasId ;
      private int AV65GXV2 ;
      private int AV39PropostaId ;
      private long AV44i ;
      private long A571PropostaAssinatura ;
      private string GXt_char1 ;
      private DateTime AV37TFReembolsoAssinaturasEmissao ;
      private DateTime AV38TFReembolsoAssinaturasEmissao_To ;
      private DateTime AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ;
      private DateTime AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ;
      private DateTime A633ReembolsoAssinaturasEmissao ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV52Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ;
      private bool AV56Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool n571PropostaAssinatura ;
      private bool n633ReembolsoAssinaturasEmissao ;
      private bool n574PropostaAssinaturaStatus ;
      private bool n632ReembolsoAssinaturasNome ;
      private bool n518ReembolsoId ;
      private string AV41TFPropostaAssinaturaStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ReembolsoAssinaturasNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ReembolsoAssinaturasNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ReembolsoAssinaturasNome3 ;
      private string AV36TFReembolsoAssinaturasNome_Sel ;
      private string AV35TFReembolsoAssinaturasNome ;
      private string AV42TFPropostaAssinaturaStatus_Sel ;
      private string AV48Reembolsoassinaturaswwds_2_filterfulltext ;
      private string AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ;
      private string AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ;
      private string AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ;
      private string AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ;
      private string AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ;
      private string AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ;
      private string AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ;
      private string AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ;
      private string lV48Reembolsoassinaturaswwds_2_filterfulltext ;
      private string lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ;
      private string lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ;
      private string lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ;
      private string lV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ;
      private string A574PropostaAssinaturaStatus ;
      private string A632ReembolsoAssinaturasNome ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV43TFPropostaAssinaturaStatus_Sels ;
      private GxSimpleCollection<string> AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00CC2_A572PropostaContratoAssinaturaId ;
      private bool[] P00CC2_n572PropostaContratoAssinaturaId ;
      private long[] P00CC2_A571PropostaAssinatura ;
      private bool[] P00CC2_n571PropostaAssinatura ;
      private DateTime[] P00CC2_A633ReembolsoAssinaturasEmissao ;
      private bool[] P00CC2_n633ReembolsoAssinaturasEmissao ;
      private string[] P00CC2_A574PropostaAssinaturaStatus ;
      private bool[] P00CC2_n574PropostaAssinaturaStatus ;
      private string[] P00CC2_A632ReembolsoAssinaturasNome ;
      private bool[] P00CC2_n632ReembolsoAssinaturasNome ;
      private int[] P00CC2_A518ReembolsoId ;
      private bool[] P00CC2_n518ReembolsoId ;
      private int[] P00CC2_A631ReembolsoAssinaturasId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class reembolsoassinaturaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CC2( IGxContext context ,
                                             string A574PropostaAssinaturaStatus ,
                                             GxSimpleCollection<string> AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                             string AV48Reembolsoassinaturaswwds_2_filterfulltext ,
                                             string AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                             short AV50Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                             string AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                             bool AV52Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                             string AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                             short AV54Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                             string AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                             bool AV56Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                             string AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                             short AV58Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                             string AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                             string AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                             string AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                             DateTime AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                             DateTime AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                             int AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ,
                                             string A632ReembolsoAssinaturasNome ,
                                             DateTime A633ReembolsoAssinaturasEmissao ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV47Reembolsoassinaturaswwds_1_reembolsoid ,
                                             int A518ReembolsoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PropostaContratoAssinaturaId, T2.PropostaAssinatura AS PropostaAssinatura, T1.ReembolsoAssinaturasEmissao, T3.AssinaturaStatus AS PropostaAssinaturaStatus, T1.ReembolsoAssinaturasNome, T1.ReembolsoId, T1.ReembolsoAssinaturasId FROM ((ReembolsoAssinaturas T1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = T1.PropostaContratoAssinaturaId) LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.PropostaAssinatura)";
         AddWhere(sWhereString, "(T1.ReembolsoId = :AV47Reembolsoassinaturaswwds_1_reembolsoid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Reembolsoassinaturaswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ReembolsoAssinaturasNome like '%' || :lV48Reembolsoassinaturaswwds_2_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV48Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV48Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV48Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV48Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV48Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV50Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV50Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV52Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV54Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV52Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV54Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV56Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV58Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV56Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV58Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ! ( StringUtil.StrCmp(AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome = ( :AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoAssinaturasNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao >= :AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao <= :AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV64Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels, "T3.AssinaturaStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoId, T1.ReembolsoAssinaturasEmissao";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoId DESC, T1.ReembolsoAssinaturasEmissao DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoId, T1.ReembolsoAssinaturasNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoId DESC, T1.ReembolsoAssinaturasNome DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoId, T3.AssinaturaStatus";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoId DESC, T3.AssinaturaStatus DESC";
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
                     return conditional_P00CC2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] );
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
          Object[] prmP00CC2;
          prmP00CC2 = new Object[] {
          new ParDef("AV47Reembolsoassinaturaswwds_1_reembolsoid",GXType.Int32,9,0) ,
          new ParDef("lV48Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV51Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV55Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV59Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV60Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome",GXType.VarChar,100,0) ,
          new ParDef("AV61Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel",GXType.VarChar,100,0) ,
          new ParDef("AV62Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao",GXType.DateTime,8,5) ,
          new ParDef("AV63Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00CC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
