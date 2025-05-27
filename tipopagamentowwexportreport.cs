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
   public class tipopagamentowwexportreport : GXWebProcedure
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

      public tipopagamentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipopagamentowwexportreport( IGxContext context )
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
         setOutputFileName("TipoPagamentoWWExportReport");
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
            AV47Title = "Lista de Tipo Pagamento";
            GXt_char1 = AV49Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV49Companyname = GXt_char1;
            GXt_char1 = AV46Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV46Phone = GXt_char1;
            GXt_char1 = AV44Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV44Mail = GXt_char1;
            GXt_char1 = AV48Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV48Website = GXt_char1;
            GXt_char1 = AV37AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV37AddressLine1 = GXt_char1;
            GXt_char1 = AV38AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV38AddressLine2 = GXt_char1;
            GXt_char1 = AV39AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV39AddressLine3 = GXt_char1;
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
            H860( true, 0) ;
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
            H860( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TIPOPAGAMENTONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TipoPagamentoNome1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TipoPagamentoNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTipoPagamentoNomeDescription = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTipoPagamentoNomeDescription = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17TipoPagamentoNome = AV15TipoPagamentoNome1;
                  H860( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipoPagamentoNomeDescription, "")), 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipoPagamentoNome, "")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TIPOPAGAMENTONOME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TipoPagamentoNome2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipoPagamentoNome2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTipoPagamentoNomeDescription = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTipoPagamentoNomeDescription = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17TipoPagamentoNome = AV21TipoPagamentoNome2;
                     H860( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipoPagamentoNomeDescription, "")), 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipoPagamentoNome, "")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TIPOPAGAMENTONOME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TipoPagamentoNome3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipoPagamentoNome3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTipoPagamentoNomeDescription = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTipoPagamentoNomeDescription = StringUtil.Format( "%1 (%2)", "Pagamento Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17TipoPagamentoNome = AV25TipoPagamentoNome3;
                        H860( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTipoPagamentoNomeDescription, "")), 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TipoPagamentoNome, "")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFTipoPagamentoId) && (0==AV32TFTipoPagamentoId_To) ) )
         {
            H860( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pagamento Id", 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFTipoPagamentoId), "ZZZZZZZZ9")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFTipoPagamentoId_To_Description = StringUtil.Format( "%1 (%2)", "Pagamento Id", "Até", "", "", "", "", "", "", "");
            H860( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTipoPagamentoId_To_Description, "")), 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFTipoPagamentoId_To), "ZZZZZZZZ9")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTipoPagamentoNome_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFTipoPagamentoNome_Sel, "<#Empty#>")==0)));
            AV34TFTipoPagamentoNome_Sel = (AV36TempBoolean ? "(Vazio)" : AV34TFTipoPagamentoNome_Sel);
            H860( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Pagamento Nome", 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTipoPagamentoNome_Sel, "")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFTipoPagamentoNome_Sel = (AV36TempBoolean ? "<#Empty#>" : AV34TFTipoPagamentoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTipoPagamentoNome)) )
            {
               H860( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pagamento Nome", 25, Gx_line+0, 230, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTipoPagamentoNome, "")), 230, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H860( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H860( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Pagamento Id", 30, Gx_line+10, 281, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Pagamento Nome", 285, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV53Tipopagamentowwds_1_filterfulltext = AV12FilterFullText;
         AV54Tipopagamentowwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV55Tipopagamentowwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV56Tipopagamentowwds_4_tipopagamentonome1 = AV15TipoPagamentoNome1;
         AV57Tipopagamentowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV58Tipopagamentowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV59Tipopagamentowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV60Tipopagamentowwds_8_tipopagamentonome2 = AV21TipoPagamentoNome2;
         AV61Tipopagamentowwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV62Tipopagamentowwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV63Tipopagamentowwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV64Tipopagamentowwds_12_tipopagamentonome3 = AV25TipoPagamentoNome3;
         AV65Tipopagamentowwds_13_tftipopagamentoid = AV31TFTipoPagamentoId;
         AV66Tipopagamentowwds_14_tftipopagamentoid_to = AV32TFTipoPagamentoId_To;
         AV67Tipopagamentowwds_15_tftipopagamentonome = AV33TFTipoPagamentoNome;
         AV68Tipopagamentowwds_16_tftipopagamentonome_sel = AV34TFTipoPagamentoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Tipopagamentowwds_1_filterfulltext ,
                                              AV54Tipopagamentowwds_2_dynamicfiltersselector1 ,
                                              AV55Tipopagamentowwds_3_dynamicfiltersoperator1 ,
                                              AV56Tipopagamentowwds_4_tipopagamentonome1 ,
                                              AV57Tipopagamentowwds_5_dynamicfiltersenabled2 ,
                                              AV58Tipopagamentowwds_6_dynamicfiltersselector2 ,
                                              AV59Tipopagamentowwds_7_dynamicfiltersoperator2 ,
                                              AV60Tipopagamentowwds_8_tipopagamentonome2 ,
                                              AV61Tipopagamentowwds_9_dynamicfiltersenabled3 ,
                                              AV62Tipopagamentowwds_10_dynamicfiltersselector3 ,
                                              AV63Tipopagamentowwds_11_dynamicfiltersoperator3 ,
                                              AV64Tipopagamentowwds_12_tipopagamentonome3 ,
                                              AV65Tipopagamentowwds_13_tftipopagamentoid ,
                                              AV66Tipopagamentowwds_14_tftipopagamentoid_to ,
                                              AV68Tipopagamentowwds_16_tftipopagamentonome_sel ,
                                              AV67Tipopagamentowwds_15_tftipopagamentonome ,
                                              A288TipoPagamentoId ,
                                              A289TipoPagamentoNome ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Tipopagamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipopagamentowwds_1_filterfulltext), "%", "");
         lV53Tipopagamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Tipopagamentowwds_1_filterfulltext), "%", "");
         lV56Tipopagamentowwds_4_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV56Tipopagamentowwds_4_tipopagamentonome1), "%", "");
         lV56Tipopagamentowwds_4_tipopagamentonome1 = StringUtil.Concat( StringUtil.RTrim( AV56Tipopagamentowwds_4_tipopagamentonome1), "%", "");
         lV60Tipopagamentowwds_8_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV60Tipopagamentowwds_8_tipopagamentonome2), "%", "");
         lV60Tipopagamentowwds_8_tipopagamentonome2 = StringUtil.Concat( StringUtil.RTrim( AV60Tipopagamentowwds_8_tipopagamentonome2), "%", "");
         lV64Tipopagamentowwds_12_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV64Tipopagamentowwds_12_tipopagamentonome3), "%", "");
         lV64Tipopagamentowwds_12_tipopagamentonome3 = StringUtil.Concat( StringUtil.RTrim( AV64Tipopagamentowwds_12_tipopagamentonome3), "%", "");
         lV67Tipopagamentowwds_15_tftipopagamentonome = StringUtil.Concat( StringUtil.RTrim( AV67Tipopagamentowwds_15_tftipopagamentonome), "%", "");
         /* Using cursor P00862 */
         pr_default.execute(0, new Object[] {lV53Tipopagamentowwds_1_filterfulltext, lV53Tipopagamentowwds_1_filterfulltext, lV56Tipopagamentowwds_4_tipopagamentonome1, lV56Tipopagamentowwds_4_tipopagamentonome1, lV60Tipopagamentowwds_8_tipopagamentonome2, lV60Tipopagamentowwds_8_tipopagamentonome2, lV64Tipopagamentowwds_12_tipopagamentonome3, lV64Tipopagamentowwds_12_tipopagamentonome3, AV65Tipopagamentowwds_13_tftipopagamentoid, AV66Tipopagamentowwds_14_tftipopagamentoid_to, lV67Tipopagamentowwds_15_tftipopagamentonome, AV68Tipopagamentowwds_16_tftipopagamentonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A288TipoPagamentoId = P00862_A288TipoPagamentoId[0];
            A289TipoPagamentoNome = P00862_A289TipoPagamentoNome[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H860( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A288TipoPagamentoId), "ZZZZZZZZ9")), 30, Gx_line+10, 281, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A289TipoPagamentoNome, "")), 285, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("TipoPagamentoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoPagamentoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("TipoPagamentoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTOID") == 0 )
            {
               AV31TFTipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV32TFTipoPagamentoId_To = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME") == 0 )
            {
               AV33TFTipoPagamentoNome = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTIPOPAGAMENTONOME_SEL") == 0 )
            {
               AV34TFTipoPagamentoNome_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV69GXV1 = (int)(AV69GXV1+1);
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

      protected void H860( bool bFoot ,
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
                  AV45PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV42DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV47Title = "";
         AV49Companyname = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15TipoPagamentoNome1 = "";
         AV16FilterTipoPagamentoNomeDescription = "";
         AV17TipoPagamentoNome = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TipoPagamentoNome2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TipoPagamentoNome3 = "";
         AV35TFTipoPagamentoId_To_Description = "";
         AV34TFTipoPagamentoNome_Sel = "";
         AV33TFTipoPagamentoNome = "";
         AV53Tipopagamentowwds_1_filterfulltext = "";
         AV54Tipopagamentowwds_2_dynamicfiltersselector1 = "";
         AV56Tipopagamentowwds_4_tipopagamentonome1 = "";
         AV58Tipopagamentowwds_6_dynamicfiltersselector2 = "";
         AV60Tipopagamentowwds_8_tipopagamentonome2 = "";
         AV62Tipopagamentowwds_10_dynamicfiltersselector3 = "";
         AV64Tipopagamentowwds_12_tipopagamentonome3 = "";
         AV67Tipopagamentowwds_15_tftipopagamentonome = "";
         AV68Tipopagamentowwds_16_tftipopagamentonome_sel = "";
         lV53Tipopagamentowwds_1_filterfulltext = "";
         lV56Tipopagamentowwds_4_tipopagamentonome1 = "";
         lV60Tipopagamentowwds_8_tipopagamentonome2 = "";
         lV64Tipopagamentowwds_12_tipopagamentonome3 = "";
         lV67Tipopagamentowwds_15_tftipopagamentonome = "";
         A289TipoPagamentoNome = "";
         P00862_A288TipoPagamentoId = new int[1] ;
         P00862_A289TipoPagamentoNome = new string[] {""} ;
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipopagamentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00862_A288TipoPagamentoId, P00862_A289TipoPagamentoNome
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
      private short AV55Tipopagamentowwds_3_dynamicfiltersoperator1 ;
      private short AV59Tipopagamentowwds_7_dynamicfiltersoperator2 ;
      private short AV63Tipopagamentowwds_11_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFTipoPagamentoId ;
      private int AV32TFTipoPagamentoId_To ;
      private int AV65Tipopagamentowwds_13_tftipopagamentoid ;
      private int AV66Tipopagamentowwds_14_tftipopagamentoid_to ;
      private int A288TipoPagamentoId ;
      private int AV69GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV57Tipopagamentowwds_5_dynamicfiltersenabled2 ;
      private bool AV61Tipopagamentowwds_9_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV49Companyname ;
      private string AV47Title ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15TipoPagamentoNome1 ;
      private string AV16FilterTipoPagamentoNomeDescription ;
      private string AV17TipoPagamentoNome ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21TipoPagamentoNome2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25TipoPagamentoNome3 ;
      private string AV35TFTipoPagamentoId_To_Description ;
      private string AV34TFTipoPagamentoNome_Sel ;
      private string AV33TFTipoPagamentoNome ;
      private string AV53Tipopagamentowwds_1_filterfulltext ;
      private string AV54Tipopagamentowwds_2_dynamicfiltersselector1 ;
      private string AV56Tipopagamentowwds_4_tipopagamentonome1 ;
      private string AV58Tipopagamentowwds_6_dynamicfiltersselector2 ;
      private string AV60Tipopagamentowwds_8_tipopagamentonome2 ;
      private string AV62Tipopagamentowwds_10_dynamicfiltersselector3 ;
      private string AV64Tipopagamentowwds_12_tipopagamentonome3 ;
      private string AV67Tipopagamentowwds_15_tftipopagamentonome ;
      private string AV68Tipopagamentowwds_16_tftipopagamentonome_sel ;
      private string lV53Tipopagamentowwds_1_filterfulltext ;
      private string lV56Tipopagamentowwds_4_tipopagamentonome1 ;
      private string lV60Tipopagamentowwds_8_tipopagamentonome2 ;
      private string lV64Tipopagamentowwds_12_tipopagamentonome3 ;
      private string lV67Tipopagamentowwds_15_tftipopagamentonome ;
      private string A289TipoPagamentoNome ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00862_A288TipoPagamentoId ;
      private string[] P00862_A289TipoPagamentoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class tipopagamentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00862( IGxContext context ,
                                             string AV53Tipopagamentowwds_1_filterfulltext ,
                                             string AV54Tipopagamentowwds_2_dynamicfiltersselector1 ,
                                             short AV55Tipopagamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Tipopagamentowwds_4_tipopagamentonome1 ,
                                             bool AV57Tipopagamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Tipopagamentowwds_6_dynamicfiltersselector2 ,
                                             short AV59Tipopagamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Tipopagamentowwds_8_tipopagamentonome2 ,
                                             bool AV61Tipopagamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Tipopagamentowwds_10_dynamicfiltersselector3 ,
                                             short AV63Tipopagamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Tipopagamentowwds_12_tipopagamentonome3 ,
                                             int AV65Tipopagamentowwds_13_tftipopagamentoid ,
                                             int AV66Tipopagamentowwds_14_tftipopagamentoid_to ,
                                             string AV68Tipopagamentowwds_16_tftipopagamentonome_sel ,
                                             string AV67Tipopagamentowwds_15_tftipopagamentonome ,
                                             int A288TipoPagamentoId ,
                                             string A289TipoPagamentoNome ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Tipopagamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TipoPagamentoId,'999999999'), 2) like '%' || :lV53Tipopagamentowwds_1_filterfulltext) or ( TipoPagamentoNome like '%' || :lV53Tipopagamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Tipopagamentowwds_2_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV55Tipopagamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tipopagamentowwds_4_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV56Tipopagamentowwds_4_tipopagamentonome1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Tipopagamentowwds_2_dynamicfiltersselector1, "TIPOPAGAMENTONOME") == 0 ) && ( AV55Tipopagamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Tipopagamentowwds_4_tipopagamentonome1)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV56Tipopagamentowwds_4_tipopagamentonome1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV57Tipopagamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Tipopagamentowwds_6_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV59Tipopagamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tipopagamentowwds_8_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV60Tipopagamentowwds_8_tipopagamentonome2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV57Tipopagamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Tipopagamentowwds_6_dynamicfiltersselector2, "TIPOPAGAMENTONOME") == 0 ) && ( AV59Tipopagamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Tipopagamentowwds_8_tipopagamentonome2)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV60Tipopagamentowwds_8_tipopagamentonome2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV61Tipopagamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Tipopagamentowwds_10_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV63Tipopagamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipopagamentowwds_12_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV64Tipopagamentowwds_12_tipopagamentonome3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Tipopagamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Tipopagamentowwds_10_dynamicfiltersselector3, "TIPOPAGAMENTONOME") == 0 ) && ( AV63Tipopagamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Tipopagamentowwds_12_tipopagamentonome3)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like '%' || :lV64Tipopagamentowwds_12_tipopagamentonome3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV65Tipopagamentowwds_13_tftipopagamentoid) )
         {
            AddWhere(sWhereString, "(TipoPagamentoId >= :AV65Tipopagamentowwds_13_tftipopagamentoid)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV66Tipopagamentowwds_14_tftipopagamentoid_to) )
         {
            AddWhere(sWhereString, "(TipoPagamentoId <= :AV66Tipopagamentowwds_14_tftipopagamentoid_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Tipopagamentowwds_16_tftipopagamentonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Tipopagamentowwds_15_tftipopagamentonome)) ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome like :lV67Tipopagamentowwds_15_tftipopagamentonome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Tipopagamentowwds_16_tftipopagamentonome_sel)) && ! ( StringUtil.StrCmp(AV68Tipopagamentowwds_16_tftipopagamentonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoPagamentoNome = ( :AV68Tipopagamentowwds_16_tftipopagamentonome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Tipopagamentowwds_16_tftipopagamentonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TipoPagamentoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoPagamentoNome";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoPagamentoNome DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY TipoPagamentoId";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TipoPagamentoId DESC";
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
                     return conditional_P00862(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00862;
          prmP00862 = new Object[] {
          new ParDef("lV53Tipopagamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Tipopagamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Tipopagamentowwds_4_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV56Tipopagamentowwds_4_tipopagamentonome1",GXType.VarChar,60,0) ,
          new ParDef("lV60Tipopagamentowwds_8_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV60Tipopagamentowwds_8_tipopagamentonome2",GXType.VarChar,60,0) ,
          new ParDef("lV64Tipopagamentowwds_12_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("lV64Tipopagamentowwds_12_tipopagamentonome3",GXType.VarChar,60,0) ,
          new ParDef("AV65Tipopagamentowwds_13_tftipopagamentoid",GXType.Int32,9,0) ,
          new ParDef("AV66Tipopagamentowwds_14_tftipopagamentoid_to",GXType.Int32,9,0) ,
          new ParDef("lV67Tipopagamentowwds_15_tftipopagamentonome",GXType.VarChar,60,0) ,
          new ParDef("AV68Tipopagamentowwds_16_tftipopagamentonome_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00862", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00862,100, GxCacheFrequency.OFF ,true,false )
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
