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
   public class configuracaonotificacoeswwexport : GXProcedure
   {
      public configuracaonotificacoeswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracaonotificacoeswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ConfiguracaoNotificacoesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV17FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ConfiguracaoNotificacoesEmail1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConfiguracaoNotificacoesEmail1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Notificacoes Email", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Notificacoes Email", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ConfiguracaoNotificacoesEmail1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ConfiguracaoNotificacoesEmail2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConfiguracaoNotificacoesEmail2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Notificacoes Email", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Notificacoes Email", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ConfiguracaoNotificacoesEmail2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ConfiguracaoNotificacoesEmail3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ConfiguracaoNotificacoesEmail3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Notificacoes Email", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Notificacoes Email", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ConfiguracaoNotificacoesEmail3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConfiguracaoNotificacoesEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConfiguracaoNotificacoesEmail_Sel)) ? "(Vazio)" : AV35TFConfiguracaoNotificacoesEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConfiguracaoNotificacoesEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFConfiguracaoNotificacoesEmail, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "E-mail";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV37Configuracaonotificacoeswwds_1_filterfulltext = AV17FilterFullText;
         AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV39Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV20ConfiguracaoNotificacoesEmail1;
         AV41Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV43Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV24ConfiguracaoNotificacoesEmail2;
         AV45Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV47Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV28ConfiguracaoNotificacoesEmail3;
         AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV37Configuracaonotificacoeswwds_1_filterfulltext ,
                                              AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                              AV39Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                              AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                              AV41Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                              AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                              AV43Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                              AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                              AV45Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                              AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                              AV47Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                              AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                              AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                              AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                              A492ConfiguracaoNotificacoesEmail ,
                                              AV16OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV37Configuracaonotificacoeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV37Configuracaonotificacoeswwds_1_filterfulltext), "%", "");
         lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
         lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
         lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
         lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
         lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
         lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
         lV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = StringUtil.Concat( StringUtil.RTrim( AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail), "%", "");
         /* Using cursor P00AG2 */
         pr_default.execute(0, new Object[] {lV37Configuracaonotificacoeswwds_1_filterfulltext, lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail, AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A492ConfiguracaoNotificacoesEmail = P00AG2_A492ConfiguracaoNotificacoesEmail[0];
            n492ConfiguracaoNotificacoesEmail = P00AG2_n492ConfiguracaoNotificacoesEmail[0];
            A491ConfiguracaoNotificacoesId = P00AG2_A491ConfiguracaoNotificacoesId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A492ConfiguracaoNotificacoesEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
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
         AV30Session.Set("WWPExportFilePath", AV11Filename);
         AV30Session.Set("WWPExportFileName", "ConfiguracaoNotificacoesWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV30Session.Get("ConfiguracaoNotificacoesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfiguracaoNotificacoesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ConfiguracaoNotificacoesWWGridState"), null, "", "");
         }
         AV16OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONFIGURACAONOTIFICACOESEMAIL") == 0 )
            {
               AV34TFConfiguracaoNotificacoesEmail = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONFIGURACAONOTIFICACOESEMAIL_SEL") == 0 )
            {
               AV35TFConfiguracaoNotificacoesEmail_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
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
         AV17FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20ConfiguracaoNotificacoesEmail1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ConfiguracaoNotificacoesEmail2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ConfiguracaoNotificacoesEmail3 = "";
         AV35TFConfiguracaoNotificacoesEmail_Sel = "";
         AV34TFConfiguracaoNotificacoesEmail = "";
         AV37Configuracaonotificacoeswwds_1_filterfulltext = "";
         AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = "";
         AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = "";
         AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = "";
         AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = "";
         AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = "";
         AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = "";
         AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = "";
         AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = "";
         lV37Configuracaonotificacoeswwds_1_filterfulltext = "";
         lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = "";
         lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = "";
         lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = "";
         lV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = "";
         A492ConfiguracaoNotificacoesEmail = "";
         P00AG2_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         P00AG2_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         P00AG2_A491ConfiguracaoNotificacoesId = new int[1] ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracaonotificacoeswwexport__default(),
            new Object[][] {
                new Object[] {
               P00AG2_A492ConfiguracaoNotificacoesEmail, P00AG2_n492ConfiguracaoNotificacoesEmail, P00AG2_A491ConfiguracaoNotificacoesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV39Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ;
      private short AV43Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ;
      private short AV47Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A491ConfiguracaoNotificacoesId ;
      private int AV51GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV41Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ;
      private bool AV45Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ;
      private bool AV16OrderedDsc ;
      private bool n492ConfiguracaoNotificacoesEmail ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20ConfiguracaoNotificacoesEmail1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24ConfiguracaoNotificacoesEmail2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28ConfiguracaoNotificacoesEmail3 ;
      private string AV35TFConfiguracaoNotificacoesEmail_Sel ;
      private string AV34TFConfiguracaoNotificacoesEmail ;
      private string AV37Configuracaonotificacoeswwds_1_filterfulltext ;
      private string AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ;
      private string AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ;
      private string AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ;
      private string AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ;
      private string AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ;
      private string AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ;
      private string AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ;
      private string AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ;
      private string lV37Configuracaonotificacoeswwds_1_filterfulltext ;
      private string lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ;
      private string lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ;
      private string lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ;
      private string lV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ;
      private string A492ConfiguracaoNotificacoesEmail ;
      private IGxSession AV30Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00AG2_A492ConfiguracaoNotificacoesEmail ;
      private bool[] P00AG2_n492ConfiguracaoNotificacoesEmail ;
      private int[] P00AG2_A491ConfiguracaoNotificacoesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class configuracaonotificacoeswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AG2( IGxContext context ,
                                             string AV37Configuracaonotificacoeswwds_1_filterfulltext ,
                                             string AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                             short AV39Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                             string AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                             bool AV41Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                             string AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                             short AV43Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                             string AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                             bool AV45Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                             string AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                             short AV47Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                             string AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                             string AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                             string AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                             string A492ConfiguracaoNotificacoesEmail ,
                                             bool AV16OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ConfiguracaoNotificacoesEmail, ConfiguracaoNotificacoesId FROM ConfiguracaoNotificacoes";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Configuracaonotificacoeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracaoNotificacoesEmail like '%' || :lV37Configuracaonotificacoeswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV39Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV38Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV39Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV41Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV43Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV41Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV42Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV43Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV45Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV47Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV45Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV46Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV47Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ! ( StringUtil.StrCmp(AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail = ( :AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracaoNotificacoesEmail))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY ConfiguracaoNotificacoesEmail";
         }
         else if ( AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY ConfiguracaoNotificacoesEmail DESC";
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
                     return conditional_P00AG2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] );
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
          Object[] prmP00AG2;
          prmP00AG2 = new Object[] {
          new ParDef("lV37Configuracaonotificacoeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV40Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV44Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV48Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV49Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese",GXType.VarChar,100,0) ,
          new ParDef("AV50Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AG2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
