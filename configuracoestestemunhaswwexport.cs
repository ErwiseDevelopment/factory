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
   public class configuracoestestemunhaswwexport : GXProcedure
   {
      public configuracoestestemunhaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracoestestemunhaswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ConfiguracoesTestemunhasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21ConfiguracoesTestemunhasNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ConfiguracoesTestemunhasNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Testemunhas Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Testemunhas Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ConfiguracoesTestemunhasNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25ConfiguracoesTestemunhasNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ConfiguracoesTestemunhasNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Testemunhas Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Testemunhas Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ConfiguracoesTestemunhasNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29ConfiguracoesTestemunhasNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ConfiguracoesTestemunhasNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Testemunhas Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Testemunhas Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ConfiguracoesTestemunhasNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConfiguracoesTestemunhasNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConfiguracoesTestemunhasNome_Sel)) ? "(Vazio)" : AV36TFConfiguracoesTestemunhasNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConfiguracoesTestemunhasNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFConfiguracoesTestemunhasNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConfiguracoesTestemunhasDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConfiguracoesTestemunhasDocumento_Sel)) ? "(Vazio)" : AV38TFConfiguracoesTestemunhasDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConfiguracoesTestemunhasDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFConfiguracoesTestemunhasDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConfiguracoesTestemunhasEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConfiguracoesTestemunhasEmail_Sel)) ? "(Vazio)" : AV40TFConfiguracoesTestemunhasEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConfiguracoesTestemunhasEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFConfiguracoesTestemunhasEmail, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nome";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "CPF";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "E-mail";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV42Configuracoestestemunhaswwds_1_filterfulltext = AV18FilterFullText;
         AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV44Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = AV21ConfiguracoesTestemunhasNome1;
         AV46Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV48Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = AV25ConfiguracoesTestemunhasNome2;
         AV50Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV52Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = AV29ConfiguracoesTestemunhasNome3;
         AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = AV35TFConfiguracoesTestemunhasNome;
         AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel = AV36TFConfiguracoesTestemunhasNome_Sel;
         AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = AV37TFConfiguracoesTestemunhasDocumento;
         AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel = AV38TFConfiguracoesTestemunhasDocumento_Sel;
         AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = AV39TFConfiguracoesTestemunhasEmail;
         AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel = AV40TFConfiguracoesTestemunhasEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Configuracoestestemunhaswwds_1_filterfulltext ,
                                              AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                              AV44Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                              AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                              AV46Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                              AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                              AV48Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                              AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                              AV50Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                              AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                              AV52Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                              AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                              AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                              AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                              AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                              AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                              AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                              AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                              A479ConfiguracoesTestemunhasNome ,
                                              A480ConfiguracoesTestemunhasDocumento ,
                                              A481ConfiguracoesTestemunhasEmail ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV9WWPContext.gxTpr_Userid ,
                                              A133SecUserId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV42Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV42Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV42Configuracoestestemunhaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Configuracoestestemunhaswwds_1_filterfulltext), "%", "");
         lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = StringUtil.Concat( StringUtil.RTrim( AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1), "%", "");
         lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = StringUtil.Concat( StringUtil.RTrim( AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2), "%", "");
         lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = StringUtil.Concat( StringUtil.RTrim( AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3), "%", "");
         lV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = StringUtil.Concat( StringUtil.RTrim( AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome), "%", "");
         lV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = StringUtil.Concat( StringUtil.RTrim( AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento), "%", "");
         lV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = StringUtil.Concat( StringUtil.RTrim( AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail), "%", "");
         /* Using cursor P00AD2 */
         pr_default.execute(0, new Object[] {AV9WWPContext.gxTpr_Userid, lV42Configuracoestestemunhaswwds_1_filterfulltext, lV42Configuracoestestemunhaswwds_1_filterfulltext, lV42Configuracoestestemunhaswwds_1_filterfulltext, lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1, lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2, lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3, lV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome, AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, lV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento, AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, lV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail, AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133SecUserId = P00AD2_A133SecUserId[0];
            n133SecUserId = P00AD2_n133SecUserId[0];
            A481ConfiguracoesTestemunhasEmail = P00AD2_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = P00AD2_n481ConfiguracoesTestemunhasEmail[0];
            A480ConfiguracoesTestemunhasDocumento = P00AD2_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = P00AD2_n480ConfiguracoesTestemunhasDocumento[0];
            A479ConfiguracoesTestemunhasNome = P00AD2_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = P00AD2_n479ConfiguracoesTestemunhasNome[0];
            A478ConfiguracoesTestemunhasId = P00AD2_A478ConfiguracoesTestemunhasId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A479ConfiguracoesTestemunhasNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A480ConfiguracoesTestemunhasDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A481ConfiguracoesTestemunhasEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "ConfiguracoesTestemunhasWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ConfiguracoesTestemunhasWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfiguracoesTestemunhasWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ConfiguracoesTestemunhasWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASNOME") == 0 )
            {
               AV35TFConfiguracoesTestemunhasNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASNOME_SEL") == 0 )
            {
               AV36TFConfiguracoesTestemunhasNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASDOCUMENTO") == 0 )
            {
               AV37TFConfiguracoesTestemunhasDocumento = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASDOCUMENTO_SEL") == 0 )
            {
               AV38TFConfiguracoesTestemunhasDocumento_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASEMAIL") == 0 )
            {
               AV39TFConfiguracoesTestemunhasEmail = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCONFIGURACOESTESTEMUNHASEMAIL_SEL") == 0 )
            {
               AV40TFConfiguracoesTestemunhasEmail_Sel = AV34GridStateFilterValue.gxTpr_Value;
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
         AV21ConfiguracoesTestemunhasNome1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ConfiguracoesTestemunhasNome2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ConfiguracoesTestemunhasNome3 = "";
         AV36TFConfiguracoesTestemunhasNome_Sel = "";
         AV35TFConfiguracoesTestemunhasNome = "";
         AV38TFConfiguracoesTestemunhasDocumento_Sel = "";
         AV37TFConfiguracoesTestemunhasDocumento = "";
         AV40TFConfiguracoesTestemunhasEmail_Sel = "";
         AV39TFConfiguracoesTestemunhasEmail = "";
         AV42Configuracoestestemunhaswwds_1_filterfulltext = "";
         AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1 = "";
         AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = "";
         AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2 = "";
         AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = "";
         AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3 = "";
         AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = "";
         AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = "";
         AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel = "";
         AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = "";
         AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel = "";
         AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = "";
         AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel = "";
         lV42Configuracoestestemunhaswwds_1_filterfulltext = "";
         lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 = "";
         lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 = "";
         lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 = "";
         lV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome = "";
         lV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento = "";
         lV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail = "";
         A479ConfiguracoesTestemunhasNome = "";
         A480ConfiguracoesTestemunhasDocumento = "";
         A481ConfiguracoesTestemunhasEmail = "";
         P00AD2_A133SecUserId = new short[1] ;
         P00AD2_n133SecUserId = new bool[] {false} ;
         P00AD2_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         P00AD2_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         P00AD2_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         P00AD2_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         P00AD2_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         P00AD2_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         P00AD2_A478ConfiguracoesTestemunhasId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracoestestemunhaswwexport__default(),
            new Object[][] {
                new Object[] {
               P00AD2_A133SecUserId, P00AD2_n133SecUserId, P00AD2_A481ConfiguracoesTestemunhasEmail, P00AD2_n481ConfiguracoesTestemunhasEmail, P00AD2_A480ConfiguracoesTestemunhasDocumento, P00AD2_n480ConfiguracoesTestemunhasDocumento, P00AD2_A479ConfiguracoesTestemunhasNome, P00AD2_n479ConfiguracoesTestemunhasNome, P00AD2_A478ConfiguracoesTestemunhasId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV44Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ;
      private short AV48Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ;
      private short AV52Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ;
      private short AV9WWPContext_gxTpr_Userid ;
      private short AV16OrderedBy ;
      private short A133SecUserId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A478ConfiguracoesTestemunhasId ;
      private int AV60GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV46Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ;
      private bool AV50Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n133SecUserId ;
      private bool n481ConfiguracoesTestemunhasEmail ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ConfiguracoesTestemunhasNome1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ConfiguracoesTestemunhasNome2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ConfiguracoesTestemunhasNome3 ;
      private string AV36TFConfiguracoesTestemunhasNome_Sel ;
      private string AV35TFConfiguracoesTestemunhasNome ;
      private string AV38TFConfiguracoesTestemunhasDocumento_Sel ;
      private string AV37TFConfiguracoesTestemunhasDocumento ;
      private string AV40TFConfiguracoesTestemunhasEmail_Sel ;
      private string AV39TFConfiguracoesTestemunhasEmail ;
      private string AV42Configuracoestestemunhaswwds_1_filterfulltext ;
      private string AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ;
      private string AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ;
      private string AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ;
      private string AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ;
      private string AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ;
      private string AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ;
      private string AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ;
      private string AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ;
      private string AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ;
      private string AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ;
      private string AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ;
      private string AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ;
      private string lV42Configuracoestestemunhaswwds_1_filterfulltext ;
      private string lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ;
      private string lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ;
      private string lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ;
      private string lV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ;
      private string lV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ;
      private string lV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ;
      private string A479ConfiguracoesTestemunhasNome ;
      private string A480ConfiguracoesTestemunhasDocumento ;
      private string A481ConfiguracoesTestemunhasEmail ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00AD2_A133SecUserId ;
      private bool[] P00AD2_n133SecUserId ;
      private string[] P00AD2_A481ConfiguracoesTestemunhasEmail ;
      private bool[] P00AD2_n481ConfiguracoesTestemunhasEmail ;
      private string[] P00AD2_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] P00AD2_n480ConfiguracoesTestemunhasDocumento ;
      private string[] P00AD2_A479ConfiguracoesTestemunhasNome ;
      private bool[] P00AD2_n479ConfiguracoesTestemunhasNome ;
      private int[] P00AD2_A478ConfiguracoesTestemunhasId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class configuracoestestemunhaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AD2( IGxContext context ,
                                             string AV42Configuracoestestemunhaswwds_1_filterfulltext ,
                                             string AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1 ,
                                             short AV44Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 ,
                                             string AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1 ,
                                             bool AV46Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 ,
                                             string AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2 ,
                                             short AV48Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 ,
                                             string AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2 ,
                                             bool AV50Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 ,
                                             string AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3 ,
                                             short AV52Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 ,
                                             string AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3 ,
                                             string AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel ,
                                             string AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome ,
                                             string AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel ,
                                             string AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento ,
                                             string AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel ,
                                             string AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail ,
                                             string A479ConfiguracoesTestemunhasNome ,
                                             string A480ConfiguracoesTestemunhasDocumento ,
                                             string A481ConfiguracoesTestemunhasEmail ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             short AV9WWPContext_gxTpr_Userid ,
                                             short A133SecUserId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecUserId, ConfiguracoesTestemunhasEmail, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas";
         AddWhere(sWhereString, "(SecUserId = :AV9WWPContext__Userid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Configuracoestestemunhaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracoesTestemunhasNome like '%' || :lV42Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasDocumento like '%' || :lV42Configuracoestestemunhaswwds_1_filterfulltext) or ( ConfiguracoesTestemunhasEmail like '%' || :lV42Configuracoestestemunhaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV44Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV43Configuracoestestemunhaswwds_2_dynamicfiltersselector1, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV44Configuracoestestemunhaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV46Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV48Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV46Configuracoestestemunhaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV47Configuracoestestemunhaswwds_6_dynamicfiltersselector2, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV48Configuracoestestemunhaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV50Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV52Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV50Configuracoestestemunhaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV51Configuracoestestemunhaswwds_10_dynamicfiltersselector3, "CONFIGURACOESTESTEMUNHASNOME") == 0 ) && ( AV52Configuracoestestemunhaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnome3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like '%' || :lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnom)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasnome)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome like :lV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel)) && ! ( StringUtil.StrCmp(AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome = ( :AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasNome IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasdocumento)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento like :lV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel)) && ! ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento = ( :AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasdocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasDocumento IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhasemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail like :lV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel)) && ! ( StringUtil.StrCmp(AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail = ( :AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhasemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracoesTestemunhasEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracoesTestemunhasEmail))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ConfiguracoesTestemunhasNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConfiguracoesTestemunhasNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ConfiguracoesTestemunhasDocumento";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConfiguracoesTestemunhasDocumento DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ConfiguracoesTestemunhasEmail";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ConfiguracoesTestemunhasEmail DESC";
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
                     return conditional_P00AD2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] );
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
          Object[] prmP00AD2;
          prmP00AD2 = new Object[] {
          new ParDef("AV9WWPContext__Userid",GXType.Int16,4,0) ,
          new ParDef("lV42Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Configuracoestestemunhaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV45Configuracoestestemunhaswwds_4_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV49Configuracoestestemunhaswwds_8_configuracoestestemunhasnome",GXType.VarChar,70,0) ,
          new ParDef("lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV53Configuracoestestemunhaswwds_12_configuracoestestemunhasnom",GXType.VarChar,70,0) ,
          new ParDef("lV54Configuracoestestemunhaswwds_13_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("AV55Configuracoestestemunhaswwds_14_tfconfiguracoestestemunhasn",GXType.VarChar,70,0) ,
          new ParDef("lV56Configuracoestestemunhaswwds_15_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("AV57Configuracoestestemunhaswwds_16_tfconfiguracoestestemunhasd",GXType.VarChar,40,0) ,
          new ParDef("lV58Configuracoestestemunhaswwds_17_tfconfiguracoestestemunhase",GXType.VarChar,100,0) ,
          new ParDef("AV59Configuracoestestemunhaswwds_18_tfconfiguracoestestemunhase",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AD2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
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
