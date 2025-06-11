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
   public class carteiradecobrancawwexportreport : GXWebProcedure
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

      public carteiradecobrancawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiradecobrancawwexportreport( IGxContext context )
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
         setOutputFileName("CarteiraDeCobrancaWWExportReport");
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
            AV51Title = "Lista de Carteira De Cobranca";
            GXt_char1 = AV53Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV53Companyname = GXt_char1;
            GXt_char1 = AV50Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV50Phone = GXt_char1;
            GXt_char1 = AV48Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV48Mail = GXt_char1;
            GXt_char1 = AV52Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV52Website = GXt_char1;
            GXt_char1 = AV41AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV41AddressLine1 = GXt_char1;
            GXt_char1 = AV42AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV42AddressLine2 = GXt_char1;
            GXt_char1 = AV43AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV43AddressLine3 = GXt_char1;
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
            HFM0( true, 0) ;
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
            HFM0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CARTEIRADECOBRANCACODIGO") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15CarteiraDeCobrancaCodigo1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CarteiraDeCobrancaCodigo1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterCarteiraDeCobrancaCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterCarteiraDeCobrancaCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17CarteiraDeCobrancaCodigo = AV15CarteiraDeCobrancaCodigo1;
                  HFM0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCarteiraDeCobrancaCodigoDescription, "")), 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CarteiraDeCobrancaCodigo, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CARTEIRADECOBRANCACODIGO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21CarteiraDeCobrancaCodigo2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CarteiraDeCobrancaCodigo2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterCarteiraDeCobrancaCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterCarteiraDeCobrancaCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17CarteiraDeCobrancaCodigo = AV21CarteiraDeCobrancaCodigo2;
                     HFM0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCarteiraDeCobrancaCodigoDescription, "")), 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CarteiraDeCobrancaCodigo, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CARTEIRADECOBRANCACODIGO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25CarteiraDeCobrancaCodigo3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CarteiraDeCobrancaCodigo3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterCarteiraDeCobrancaCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterCarteiraDeCobrancaCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17CarteiraDeCobrancaCodigo = AV25CarteiraDeCobrancaCodigo3;
                        HFM0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCarteiraDeCobrancaCodigoDescription, "")), 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CarteiraDeCobrancaCodigo, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCarteiraDeCobrancaNome_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFCarteiraDeCobrancaNome_Sel, "<#Empty#>")==0)));
            AV35TFCarteiraDeCobrancaNome_Sel = (AV40TempBoolean ? "(Vazio)" : AV35TFCarteiraDeCobrancaNome_Sel);
            HFM0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCarteiraDeCobrancaNome_Sel, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFCarteiraDeCobrancaNome_Sel = (AV40TempBoolean ? "<#Empty#>" : AV35TFCarteiraDeCobrancaNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCarteiraDeCobrancaNome)) )
            {
               HFM0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFCarteiraDeCobrancaNome, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCarteiraDeCobrancaConvenio_Sel)) )
         {
            AV40TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFCarteiraDeCobrancaConvenio_Sel, "<#Empty#>")==0)));
            AV37TFCarteiraDeCobrancaConvenio_Sel = (AV40TempBoolean ? "(Vazio)" : AV37TFCarteiraDeCobrancaConvenio_Sel);
            HFM0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Convênio", 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCarteiraDeCobrancaConvenio_Sel, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFCarteiraDeCobrancaConvenio_Sel = (AV40TempBoolean ? "<#Empty#>" : AV37TFCarteiraDeCobrancaConvenio_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCarteiraDeCobrancaConvenio)) )
            {
               HFM0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Convênio", 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCarteiraDeCobrancaConvenio, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV38TFCarteiraDeCobrancaStatus_Sel) )
         {
            if ( AV38TFCarteiraDeCobrancaStatus_Sel == 1 )
            {
               AV39FilterTFCarteiraDeCobrancaStatus_SelValueDescription = "Marcado";
            }
            else if ( AV38TFCarteiraDeCobrancaStatus_Sel == 2 )
            {
               AV39FilterTFCarteiraDeCobrancaStatus_SelValueDescription = "Desmarcado";
            }
            HFM0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 166, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39FilterTFCarteiraDeCobrancaStatus_SelValueDescription, "")), 166, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HFM0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HFM0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Convênio", 283, Gx_line+10, 533, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 537, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV57Carteiradecobrancawwds_1_filterfulltext = AV12FilterFullText;
         AV58Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV59Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV15CarteiraDeCobrancaCodigo1;
         AV61Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV21CarteiraDeCobrancaCodigo2;
         AV65Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV66Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV67Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV25CarteiraDeCobrancaCodigo3;
         AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV34TFCarteiraDeCobrancaNome;
         AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV35TFCarteiraDeCobrancaNome_Sel;
         AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV36TFCarteiraDeCobrancaConvenio;
         AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV37TFCarteiraDeCobrancaConvenio_Sel;
         AV73Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV38TFCarteiraDeCobrancaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Carteiradecobrancawwds_1_filterfulltext ,
                                              AV58Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                              AV59Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                              AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                              AV61Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                              AV62Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                              AV63Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                              AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                              AV65Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                              AV66Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                              AV67Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                              AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                              AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                              AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                              AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                              AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                              AV73Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                              A1071CarteiraDeCobrancaNome ,
                                              A1073CarteiraDeCobrancaConvenio ,
                                              A1074CarteiraDeCobrancaStatus ,
                                              A1070CarteiraDeCobrancaCodigo ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV57Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV57Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV57Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome = StringUtil.Concat( StringUtil.RTrim( AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome), "%", "");
         lV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = StringUtil.Concat( StringUtil.RTrim( AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio), "%", "");
         /* Using cursor P00FM2 */
         pr_default.execute(0, new Object[] {lV57Carteiradecobrancawwds_1_filterfulltext, lV57Carteiradecobrancawwds_1_filterfulltext, lV57Carteiradecobrancawwds_1_filterfulltext, lV57Carteiradecobrancawwds_1_filterfulltext, lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome, AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, lV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio, AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1070CarteiraDeCobrancaCodigo = P00FM2_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = P00FM2_n1070CarteiraDeCobrancaCodigo[0];
            A1074CarteiraDeCobrancaStatus = P00FM2_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = P00FM2_n1074CarteiraDeCobrancaStatus[0];
            A1073CarteiraDeCobrancaConvenio = P00FM2_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = P00FM2_n1073CarteiraDeCobrancaConvenio[0];
            A1071CarteiraDeCobrancaNome = P00FM2_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = P00FM2_n1071CarteiraDeCobrancaNome[0];
            A1069CarteiraDeCobrancaId = P00FM2_A1069CarteiraDeCobrancaId[0];
            AV27CarteiraDeCobrancaStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)), "true") == 0 )
            {
               AV27CarteiraDeCobrancaStatusDescription = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)), "false") == 0 )
            {
               AV27CarteiraDeCobrancaStatusDescription = "Inativo";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HFM0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1071CarteiraDeCobrancaNome, "")), 30, Gx_line+10, 279, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1073CarteiraDeCobrancaConvenio, "")), 283, Gx_line+10, 533, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27CarteiraDeCobrancaStatusDescription, "")), 537, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("CarteiraDeCobrancaWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CarteiraDeCobrancaWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("CarteiraDeCobrancaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME") == 0 )
            {
               AV34TFCarteiraDeCobrancaNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME_SEL") == 0 )
            {
               AV35TFCarteiraDeCobrancaNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO") == 0 )
            {
               AV36TFCarteiraDeCobrancaConvenio = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO_SEL") == 0 )
            {
               AV37TFCarteiraDeCobrancaConvenio_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCASTATUS_SEL") == 0 )
            {
               AV38TFCarteiraDeCobrancaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV74GXV1 = (int)(AV74GXV1+1);
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

      protected void HFM0( bool bFoot ,
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
                  AV49PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV46DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV51Title = "";
         AV53Companyname = "";
         AV50Phone = "";
         AV48Mail = "";
         AV52Website = "";
         AV41AddressLine1 = "";
         AV42AddressLine2 = "";
         AV43AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15CarteiraDeCobrancaCodigo1 = "";
         AV16FilterCarteiraDeCobrancaCodigoDescription = "";
         AV17CarteiraDeCobrancaCodigo = "";
         AV19DynamicFiltersSelector2 = "";
         AV21CarteiraDeCobrancaCodigo2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25CarteiraDeCobrancaCodigo3 = "";
         AV35TFCarteiraDeCobrancaNome_Sel = "";
         AV34TFCarteiraDeCobrancaNome = "";
         AV37TFCarteiraDeCobrancaConvenio_Sel = "";
         AV36TFCarteiraDeCobrancaConvenio = "";
         AV39FilterTFCarteiraDeCobrancaStatus_SelValueDescription = "";
         AV57Carteiradecobrancawwds_1_filterfulltext = "";
         AV58Carteiradecobrancawwds_2_dynamicfiltersselector1 = "";
         AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         AV62Carteiradecobrancawwds_6_dynamicfiltersselector2 = "";
         AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         AV66Carteiradecobrancawwds_10_dynamicfiltersselector3 = "";
         AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = "";
         AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = "";
         lV57Carteiradecobrancawwds_1_filterfulltext = "";
         lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         lV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         lV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         A1071CarteiraDeCobrancaNome = "";
         A1073CarteiraDeCobrancaConvenio = "";
         A1070CarteiraDeCobrancaCodigo = "";
         P00FM2_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FM2_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         P00FM2_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FM2_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         P00FM2_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         P00FM2_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         P00FM2_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         P00FM2_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         P00FM2_A1069CarteiraDeCobrancaId = new int[1] ;
         AV27CarteiraDeCobrancaStatusDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49PageInfo = "";
         AV46DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV44AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carteiradecobrancawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00FM2_A1070CarteiraDeCobrancaCodigo, P00FM2_n1070CarteiraDeCobrancaCodigo, P00FM2_A1074CarteiraDeCobrancaStatus, P00FM2_n1074CarteiraDeCobrancaStatus, P00FM2_A1073CarteiraDeCobrancaConvenio, P00FM2_n1073CarteiraDeCobrancaConvenio, P00FM2_A1071CarteiraDeCobrancaNome, P00FM2_n1071CarteiraDeCobrancaNome, P00FM2_A1069CarteiraDeCobrancaId
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
      private short AV38TFCarteiraDeCobrancaStatus_Sel ;
      private short AV59Carteiradecobrancawwds_3_dynamicfiltersoperator1 ;
      private short AV63Carteiradecobrancawwds_7_dynamicfiltersoperator2 ;
      private short AV67Carteiradecobrancawwds_11_dynamicfiltersoperator3 ;
      private short AV73Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A1069CarteiraDeCobrancaId ;
      private int AV74GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV40TempBoolean ;
      private bool AV61Carteiradecobrancawwds_5_dynamicfiltersenabled2 ;
      private bool AV65Carteiradecobrancawwds_9_dynamicfiltersenabled3 ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool AV11OrderedDsc ;
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool n1071CarteiraDeCobrancaNome ;
      private string AV53Companyname ;
      private string AV51Title ;
      private string AV50Phone ;
      private string AV48Mail ;
      private string AV52Website ;
      private string AV41AddressLine1 ;
      private string AV42AddressLine2 ;
      private string AV43AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15CarteiraDeCobrancaCodigo1 ;
      private string AV16FilterCarteiraDeCobrancaCodigoDescription ;
      private string AV17CarteiraDeCobrancaCodigo ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21CarteiraDeCobrancaCodigo2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25CarteiraDeCobrancaCodigo3 ;
      private string AV35TFCarteiraDeCobrancaNome_Sel ;
      private string AV34TFCarteiraDeCobrancaNome ;
      private string AV37TFCarteiraDeCobrancaConvenio_Sel ;
      private string AV36TFCarteiraDeCobrancaConvenio ;
      private string AV39FilterTFCarteiraDeCobrancaStatus_SelValueDescription ;
      private string AV57Carteiradecobrancawwds_1_filterfulltext ;
      private string AV58Carteiradecobrancawwds_2_dynamicfiltersselector1 ;
      private string AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string AV62Carteiradecobrancawwds_6_dynamicfiltersselector2 ;
      private string AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string AV66Carteiradecobrancawwds_10_dynamicfiltersselector3 ;
      private string AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ;
      private string AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ;
      private string lV57Carteiradecobrancawwds_1_filterfulltext ;
      private string lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string lV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string lV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string A1071CarteiraDeCobrancaNome ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private string AV27CarteiraDeCobrancaStatusDescription ;
      private string AV49PageInfo ;
      private string AV46DateInfo ;
      private string AV44AppName ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00FM2_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FM2_n1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FM2_A1074CarteiraDeCobrancaStatus ;
      private bool[] P00FM2_n1074CarteiraDeCobrancaStatus ;
      private string[] P00FM2_A1073CarteiraDeCobrancaConvenio ;
      private bool[] P00FM2_n1073CarteiraDeCobrancaConvenio ;
      private string[] P00FM2_A1071CarteiraDeCobrancaNome ;
      private bool[] P00FM2_n1071CarteiraDeCobrancaNome ;
      private int[] P00FM2_A1069CarteiraDeCobrancaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class carteiradecobrancawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FM2( IGxContext context ,
                                             string AV57Carteiradecobrancawwds_1_filterfulltext ,
                                             string AV58Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                             short AV59Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                             string AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                             bool AV61Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                             string AV62Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                             short AV63Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                             string AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                             bool AV65Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                             string AV66Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                             short AV67Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                             string AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                             string AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                             string AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                             string AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                             string AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                             short AV73Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                             string A1071CarteiraDeCobrancaNome ,
                                             string A1073CarteiraDeCobrancaConvenio ,
                                             bool A1074CarteiraDeCobrancaStatus ,
                                             string A1070CarteiraDeCobrancaCodigo ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT CarteiraDeCobrancaCodigo, CarteiraDeCobrancaStatus, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaNome, CarteiraDeCobrancaId FROM CarteiraDeCobranca";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Carteiradecobrancawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CarteiraDeCobrancaNome like '%' || :lV57Carteiradecobrancawwds_1_filterfulltext) or ( CarteiraDeCobrancaConvenio like '%' || :lV57Carteiradecobrancawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV57Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV57Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV59Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV59Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV61Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV63Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV63Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV65Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV67Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV65Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV67Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome like :lV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ! ( StringUtil.StrCmp(AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome = ( :AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio like :lV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ! ( StringUtil.StrCmp(AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio = ( :AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaConvenio))=0))");
         }
         if ( AV73Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = TRUE)");
         }
         if ( AV73Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaCodigo";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaNome";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaNome DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaConvenio";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaConvenio DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaStatus";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CarteiraDeCobrancaStatus DESC";
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
                     return conditional_P00FM2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP00FM2;
          prmP00FM2 = new Object[] {
          new ParDef("lV57Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV60Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV68Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV69Carteiradecobrancawwds_13_tfcarteiradecobrancanome",GXType.VarChar,100,0) ,
          new ParDef("AV70Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio",GXType.VarChar,20,0) ,
          new ParDef("AV72Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
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
