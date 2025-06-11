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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class documentoswwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public documentoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoswwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("DocumentosWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV46Title = "Lista de Documentos";
            GXt_char1 = AV52Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV52Companyname = GXt_char1;
            GXt_char1 = AV45Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV45Phone = GXt_char1;
            GXt_char1 = AV43Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV43Mail = GXt_char1;
            GXt_char1 = AV47Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV47Website = GXt_char1;
            GXt_char1 = AV36AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV36AddressLine1 = GXt_char1;
            GXt_char1 = AV37AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV37AddressLine2 = GXt_char1;
            GXt_char1 = AV38AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV38AddressLine3 = GXt_char1;
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9S0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) )
         {
            H9S0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "DOCUMENTOSDESCRICAO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15DocumentosDescricao1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15DocumentosDescricao1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterDocumentosDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descricao", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterDocumentosDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descricao", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17DocumentosDescricao = AV15DocumentosDescricao1;
                  H9S0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDocumentosDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocumentosDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "DOCUMENTOSDESCRICAO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21DocumentosDescricao2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DocumentosDescricao2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterDocumentosDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descricao", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterDocumentosDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descricao", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17DocumentosDescricao = AV21DocumentosDescricao2;
                     H9S0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDocumentosDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocumentosDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "DOCUMENTOSDESCRICAO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25DocumentosDescricao3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25DocumentosDescricao3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterDocumentosDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descricao", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterDocumentosDescricaoDescription = StringUtil.Format( "%1 (%2)", "Descricao", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17DocumentosDescricao = AV25DocumentosDescricao3;
                        H9S0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDocumentosDescricaoDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocumentosDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFDocumentosDescricao_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV32TFDocumentosDescricao_Sel, "<#Empty#>")==0)));
            AV32TFDocumentosDescricao_Sel = (AV35TempBoolean ? "(Vazio)" : AV32TFDocumentosDescricao_Sel);
            H9S0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descricao", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFDocumentosDescricao_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV32TFDocumentosDescricao_Sel = (AV35TempBoolean ? "<#Empty#>" : AV32TFDocumentosDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFDocumentosDescricao)) )
            {
               H9S0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descricao", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFDocumentosDescricao, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV33TFDocumentosStatus_Sel) )
         {
            if ( AV33TFDocumentosStatus_Sel == 1 )
            {
               AV34FilterTFDocumentosStatus_SelValueDescription = "Marcado";
            }
            else if ( AV33TFDocumentosStatus_Sel == 2 )
            {
               AV34FilterTFDocumentosStatus_SelValueDescription = "Desmarcado";
            }
            H9S0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34FilterTFDocumentosStatus_SelValueDescription, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV50TFDocumentoObrigatorio_Sel) )
         {
            if ( AV50TFDocumentoObrigatorio_Sel == 1 )
            {
               AV51FilterTFDocumentoObrigatorio_SelValueDescription = "Marcado";
            }
            else if ( AV50TFDocumentoObrigatorio_Sel == 2 )
            {
               AV51FilterTFDocumentoObrigatorio_SelValueDescription = "Desmarcado";
            }
            H9S0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Obrigatorio", 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51FilterTFDocumentoObrigatorio_SelValueDescription, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H9S0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H9S0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Descricao", 30, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 283, Gx_line+10, 533, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Obrigatorio", 537, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV56Documentoswwds_1_filterfulltext = AV12FilterFullText;
         AV57Documentoswwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV58Documentoswwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV59Documentoswwds_4_documentosdescricao1 = AV15DocumentosDescricao1;
         AV60Documentoswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV61Documentoswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV62Documentoswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV63Documentoswwds_8_documentosdescricao2 = AV21DocumentosDescricao2;
         AV64Documentoswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Documentoswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Documentoswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Documentoswwds_12_documentosdescricao3 = AV25DocumentosDescricao3;
         AV68Documentoswwds_13_tfdocumentosdescricao = AV31TFDocumentosDescricao;
         AV69Documentoswwds_14_tfdocumentosdescricao_sel = AV32TFDocumentosDescricao_Sel;
         AV70Documentoswwds_15_tfdocumentosstatus_sel = AV33TFDocumentosStatus_Sel;
         AV71Documentoswwds_16_tfdocumentoobrigatorio_sel = AV50TFDocumentoObrigatorio_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Documentoswwds_1_filterfulltext ,
                                              AV57Documentoswwds_2_dynamicfiltersselector1 ,
                                              AV58Documentoswwds_3_dynamicfiltersoperator1 ,
                                              AV59Documentoswwds_4_documentosdescricao1 ,
                                              AV60Documentoswwds_5_dynamicfiltersenabled2 ,
                                              AV61Documentoswwds_6_dynamicfiltersselector2 ,
                                              AV62Documentoswwds_7_dynamicfiltersoperator2 ,
                                              AV63Documentoswwds_8_documentosdescricao2 ,
                                              AV64Documentoswwds_9_dynamicfiltersenabled3 ,
                                              AV65Documentoswwds_10_dynamicfiltersselector3 ,
                                              AV66Documentoswwds_11_dynamicfiltersoperator3 ,
                                              AV67Documentoswwds_12_documentosdescricao3 ,
                                              AV69Documentoswwds_14_tfdocumentosdescricao_sel ,
                                              AV68Documentoswwds_13_tfdocumentosdescricao ,
                                              AV70Documentoswwds_15_tfdocumentosstatus_sel ,
                                              AV71Documentoswwds_16_tfdocumentoobrigatorio_sel ,
                                              A406DocumentosDescricao ,
                                              A407DocumentosStatus ,
                                              A413DocumentoObrigatorio ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Documentoswwds_1_filterfulltext), "%", "");
         lV56Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Documentoswwds_1_filterfulltext), "%", "");
         lV56Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Documentoswwds_1_filterfulltext), "%", "");
         lV56Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Documentoswwds_1_filterfulltext), "%", "");
         lV56Documentoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Documentoswwds_1_filterfulltext), "%", "");
         lV59Documentoswwds_4_documentosdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV59Documentoswwds_4_documentosdescricao1), "%", "");
         lV59Documentoswwds_4_documentosdescricao1 = StringUtil.Concat( StringUtil.RTrim( AV59Documentoswwds_4_documentosdescricao1), "%", "");
         lV63Documentoswwds_8_documentosdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV63Documentoswwds_8_documentosdescricao2), "%", "");
         lV63Documentoswwds_8_documentosdescricao2 = StringUtil.Concat( StringUtil.RTrim( AV63Documentoswwds_8_documentosdescricao2), "%", "");
         lV67Documentoswwds_12_documentosdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV67Documentoswwds_12_documentosdescricao3), "%", "");
         lV67Documentoswwds_12_documentosdescricao3 = StringUtil.Concat( StringUtil.RTrim( AV67Documentoswwds_12_documentosdescricao3), "%", "");
         lV68Documentoswwds_13_tfdocumentosdescricao = StringUtil.Concat( StringUtil.RTrim( AV68Documentoswwds_13_tfdocumentosdescricao), "%", "");
         /* Using cursor P009S2 */
         pr_default.execute(0, new Object[] {lV56Documentoswwds_1_filterfulltext, lV56Documentoswwds_1_filterfulltext, lV56Documentoswwds_1_filterfulltext, lV56Documentoswwds_1_filterfulltext, lV56Documentoswwds_1_filterfulltext, lV59Documentoswwds_4_documentosdescricao1, lV59Documentoswwds_4_documentosdescricao1, lV63Documentoswwds_8_documentosdescricao2, lV63Documentoswwds_8_documentosdescricao2, lV67Documentoswwds_12_documentosdescricao3, lV67Documentoswwds_12_documentosdescricao3, lV68Documentoswwds_13_tfdocumentosdescricao, AV69Documentoswwds_14_tfdocumentosdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A413DocumentoObrigatorio = P009S2_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = P009S2_n413DocumentoObrigatorio[0];
            A407DocumentosStatus = P009S2_A407DocumentosStatus[0];
            n407DocumentosStatus = P009S2_n407DocumentosStatus[0];
            A406DocumentosDescricao = P009S2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P009S2_n406DocumentosDescricao[0];
            A405DocumentosId = P009S2_A405DocumentosId[0];
            AV48DocumentosStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A407DocumentosStatus)), "true") == 0 )
            {
               AV48DocumentosStatusDescription = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A407DocumentosStatus)), "false") == 0 )
            {
               AV48DocumentosStatusDescription = "Inativo";
            }
            AV49DocumentoObrigatorioDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A413DocumentoObrigatorio)), "true") == 0 )
            {
               AV49DocumentoObrigatorioDescription = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A413DocumentoObrigatorio)), "false") == 0 )
            {
               AV49DocumentoObrigatorioDescription = "Não";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H9S0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A406DocumentosDescricao, "")), 30, Gx_line+10, 279, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48DocumentosStatusDescription, "")), 283, Gx_line+10, 533, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49DocumentoObrigatorioDescription, "")), 537, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
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

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("DocumentosWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentosWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("DocumentosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO") == 0 )
            {
               AV31TFDocumentosDescricao = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO_SEL") == 0 )
            {
               AV32TFDocumentosDescricao_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSSTATUS_SEL") == 0 )
            {
               AV33TFDocumentosStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOOBRIGATORIO_SEL") == 0 )
            {
               AV50TFDocumentoObrigatorio_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV72GXV1 = (int)(AV72GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H9S0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV44PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV41DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+109, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+129);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV46Title = "";
         AV52Companyname = "";
         AV45Phone = "";
         AV43Mail = "";
         AV47Website = "";
         AV36AddressLine1 = "";
         AV37AddressLine2 = "";
         AV38AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15DocumentosDescricao1 = "";
         AV16FilterDocumentosDescricaoDescription = "";
         AV17DocumentosDescricao = "";
         AV19DynamicFiltersSelector2 = "";
         AV21DocumentosDescricao2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25DocumentosDescricao3 = "";
         AV32TFDocumentosDescricao_Sel = "";
         AV31TFDocumentosDescricao = "";
         AV34FilterTFDocumentosStatus_SelValueDescription = "";
         AV51FilterTFDocumentoObrigatorio_SelValueDescription = "";
         AV56Documentoswwds_1_filterfulltext = "";
         AV57Documentoswwds_2_dynamicfiltersselector1 = "";
         AV59Documentoswwds_4_documentosdescricao1 = "";
         AV61Documentoswwds_6_dynamicfiltersselector2 = "";
         AV63Documentoswwds_8_documentosdescricao2 = "";
         AV65Documentoswwds_10_dynamicfiltersselector3 = "";
         AV67Documentoswwds_12_documentosdescricao3 = "";
         AV68Documentoswwds_13_tfdocumentosdescricao = "";
         AV69Documentoswwds_14_tfdocumentosdescricao_sel = "";
         lV56Documentoswwds_1_filterfulltext = "";
         lV59Documentoswwds_4_documentosdescricao1 = "";
         lV63Documentoswwds_8_documentosdescricao2 = "";
         lV67Documentoswwds_12_documentosdescricao3 = "";
         lV68Documentoswwds_13_tfdocumentosdescricao = "";
         A406DocumentosDescricao = "";
         P009S2_A413DocumentoObrigatorio = new bool[] {false} ;
         P009S2_n413DocumentoObrigatorio = new bool[] {false} ;
         P009S2_A407DocumentosStatus = new bool[] {false} ;
         P009S2_n407DocumentosStatus = new bool[] {false} ;
         P009S2_A406DocumentosDescricao = new string[] {""} ;
         P009S2_n406DocumentosDescricao = new bool[] {false} ;
         P009S2_A405DocumentosId = new int[1] ;
         AV48DocumentosStatusDescription = "";
         AV49DocumentoObrigatorioDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44PageInfo = "";
         AV41DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV39AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P009S2_A413DocumentoObrigatorio, P009S2_n413DocumentoObrigatorio, P009S2_A407DocumentosStatus, P009S2_n407DocumentosStatus, P009S2_A406DocumentosDescricao, P009S2_n406DocumentosDescricao, P009S2_A405DocumentosId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV33TFDocumentosStatus_Sel ;
      private short AV50TFDocumentoObrigatorio_Sel ;
      private short AV58Documentoswwds_3_dynamicfiltersoperator1 ;
      private short AV62Documentoswwds_7_dynamicfiltersoperator2 ;
      private short AV66Documentoswwds_11_dynamicfiltersoperator3 ;
      private short AV70Documentoswwds_15_tfdocumentosstatus_sel ;
      private short AV71Documentoswwds_16_tfdocumentoobrigatorio_sel ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A405DocumentosId ;
      private int AV72GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV35TempBoolean ;
      private bool AV60Documentoswwds_5_dynamicfiltersenabled2 ;
      private bool AV64Documentoswwds_9_dynamicfiltersenabled3 ;
      private bool A407DocumentosStatus ;
      private bool A413DocumentoObrigatorio ;
      private bool AV11OrderedDsc ;
      private bool n413DocumentoObrigatorio ;
      private bool n407DocumentosStatus ;
      private bool n406DocumentosDescricao ;
      private string AV52Companyname ;
      private string AV46Title ;
      private string AV45Phone ;
      private string AV43Mail ;
      private string AV47Website ;
      private string AV36AddressLine1 ;
      private string AV37AddressLine2 ;
      private string AV38AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15DocumentosDescricao1 ;
      private string AV16FilterDocumentosDescricaoDescription ;
      private string AV17DocumentosDescricao ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21DocumentosDescricao2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25DocumentosDescricao3 ;
      private string AV32TFDocumentosDescricao_Sel ;
      private string AV31TFDocumentosDescricao ;
      private string AV34FilterTFDocumentosStatus_SelValueDescription ;
      private string AV51FilterTFDocumentoObrigatorio_SelValueDescription ;
      private string AV56Documentoswwds_1_filterfulltext ;
      private string AV57Documentoswwds_2_dynamicfiltersselector1 ;
      private string AV59Documentoswwds_4_documentosdescricao1 ;
      private string AV61Documentoswwds_6_dynamicfiltersselector2 ;
      private string AV63Documentoswwds_8_documentosdescricao2 ;
      private string AV65Documentoswwds_10_dynamicfiltersselector3 ;
      private string AV67Documentoswwds_12_documentosdescricao3 ;
      private string AV68Documentoswwds_13_tfdocumentosdescricao ;
      private string AV69Documentoswwds_14_tfdocumentosdescricao_sel ;
      private string lV56Documentoswwds_1_filterfulltext ;
      private string lV59Documentoswwds_4_documentosdescricao1 ;
      private string lV63Documentoswwds_8_documentosdescricao2 ;
      private string lV67Documentoswwds_12_documentosdescricao3 ;
      private string lV68Documentoswwds_13_tfdocumentosdescricao ;
      private string A406DocumentosDescricao ;
      private string AV48DocumentosStatusDescription ;
      private string AV49DocumentoObrigatorioDescription ;
      private string AV44PageInfo ;
      private string AV41DateInfo ;
      private string AV39AppName ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P009S2_A413DocumentoObrigatorio ;
      private bool[] P009S2_n413DocumentoObrigatorio ;
      private bool[] P009S2_A407DocumentosStatus ;
      private bool[] P009S2_n407DocumentosStatus ;
      private string[] P009S2_A406DocumentosDescricao ;
      private bool[] P009S2_n406DocumentosDescricao ;
      private int[] P009S2_A405DocumentosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class documentoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009S2( IGxContext context ,
                                             string AV56Documentoswwds_1_filterfulltext ,
                                             string AV57Documentoswwds_2_dynamicfiltersselector1 ,
                                             short AV58Documentoswwds_3_dynamicfiltersoperator1 ,
                                             string AV59Documentoswwds_4_documentosdescricao1 ,
                                             bool AV60Documentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Documentoswwds_6_dynamicfiltersselector2 ,
                                             short AV62Documentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Documentoswwds_8_documentosdescricao2 ,
                                             bool AV64Documentoswwds_9_dynamicfiltersenabled3 ,
                                             string AV65Documentoswwds_10_dynamicfiltersselector3 ,
                                             short AV66Documentoswwds_11_dynamicfiltersoperator3 ,
                                             string AV67Documentoswwds_12_documentosdescricao3 ,
                                             string AV69Documentoswwds_14_tfdocumentosdescricao_sel ,
                                             string AV68Documentoswwds_13_tfdocumentosdescricao ,
                                             short AV70Documentoswwds_15_tfdocumentosstatus_sel ,
                                             short AV71Documentoswwds_16_tfdocumentoobrigatorio_sel ,
                                             string A406DocumentosDescricao ,
                                             bool A407DocumentosStatus ,
                                             bool A413DocumentoObrigatorio ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DocumentoObrigatorio, DocumentosStatus, DocumentosDescricao, DocumentosId FROM Documentos";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Documentoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocumentosDescricao like '%' || :lV56Documentoswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV56Documentoswwds_1_filterfulltext) and DocumentosStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV56Documentoswwds_1_filterfulltext) and DocumentosStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV56Documentoswwds_1_filterfulltext) and DocumentoObrigatorio = TRUE) or ( 'não' like '%' || LOWER(:lV56Documentoswwds_1_filterfulltext) and DocumentoObrigatorio = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Documentoswwds_2_dynamicfiltersselector1, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV58Documentoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Documentoswwds_4_documentosdescricao1)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV59Documentoswwds_4_documentosdescricao1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Documentoswwds_2_dynamicfiltersselector1, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV58Documentoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Documentoswwds_4_documentosdescricao1)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV59Documentoswwds_4_documentosdescricao1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV60Documentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Documentoswwds_6_dynamicfiltersselector2, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV62Documentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentoswwds_8_documentosdescricao2)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV63Documentoswwds_8_documentosdescricao2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV60Documentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Documentoswwds_6_dynamicfiltersselector2, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV62Documentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentoswwds_8_documentosdescricao2)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV63Documentoswwds_8_documentosdescricao2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV64Documentoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Documentoswwds_10_dynamicfiltersselector3, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV66Documentoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Documentoswwds_12_documentosdescricao3)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV67Documentoswwds_12_documentosdescricao3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV64Documentoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Documentoswwds_10_dynamicfiltersselector3, "DOCUMENTOSDESCRICAO") == 0 ) && ( AV66Documentoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Documentoswwds_12_documentosdescricao3)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like '%' || :lV67Documentoswwds_12_documentosdescricao3)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Documentoswwds_14_tfdocumentosdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Documentoswwds_13_tfdocumentosdescricao)) ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao like :lV68Documentoswwds_13_tfdocumentosdescricao)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Documentoswwds_14_tfdocumentosdescricao_sel)) && ! ( StringUtil.StrCmp(AV69Documentoswwds_14_tfdocumentosdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocumentosDescricao = ( :AV69Documentoswwds_14_tfdocumentosdescricao_sel))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Documentoswwds_14_tfdocumentosdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocumentosDescricao IS NULL or (char_length(trim(trailing ' ' from DocumentosDescricao))=0))");
         }
         if ( AV70Documentoswwds_15_tfdocumentosstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(DocumentosStatus = TRUE)");
         }
         if ( AV70Documentoswwds_15_tfdocumentosstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(DocumentosStatus = FALSE)");
         }
         if ( AV71Documentoswwds_16_tfdocumentoobrigatorio_sel == 1 )
         {
            AddWhere(sWhereString, "(DocumentoObrigatorio = TRUE)");
         }
         if ( AV71Documentoswwds_16_tfdocumentoobrigatorio_sel == 2 )
         {
            AddWhere(sWhereString, "(DocumentoObrigatorio = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY DocumentosDescricao";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocumentosDescricao DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY DocumentosStatus";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocumentosStatus DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY DocumentoObrigatorio";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocumentoObrigatorio DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P009S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP009S2;
          prmP009S2 = new Object[] {
          new ParDef("lV56Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Documentoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Documentoswwds_4_documentosdescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV59Documentoswwds_4_documentosdescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV63Documentoswwds_8_documentosdescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV63Documentoswwds_8_documentosdescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV67Documentoswwds_12_documentosdescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV67Documentoswwds_12_documentosdescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV68Documentoswwds_13_tfdocumentosdescricao",GXType.VarChar,40,0) ,
          new ParDef("AV69Documentoswwds_14_tfdocumentosdescricao_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S2,100, GxCacheFrequency.OFF ,true,false )
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
