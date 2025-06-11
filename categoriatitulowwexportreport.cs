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
   public class categoriatitulowwexportreport : GXWebProcedure
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

      public categoriatitulowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public categoriatitulowwexportreport( IGxContext context )
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
         setOutputFileName("CategoriaTituloWWExportReport");
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
            AV57Title = "Lista de Categoria Titulo";
            GXt_char1 = AV59Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV59Companyname = GXt_char1;
            GXt_char1 = AV56Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV56Phone = GXt_char1;
            GXt_char1 = AV54Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV54Mail = GXt_char1;
            GXt_char1 = AV58Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV58Website = GXt_char1;
            GXt_char1 = AV47AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV47AddressLine1 = GXt_char1;
            GXt_char1 = AV48AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV48AddressLine2 = GXt_char1;
            GXt_char1 = AV49AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV49AddressLine3 = GXt_char1;
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
            HA40( true, 0) ;
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
            HA40( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CATEGORIATITULONOME") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15CategoriaTituloNome1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CategoriaTituloNome1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterCategoriaTituloNomeDescription = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterCategoriaTituloNomeDescription = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17CategoriaTituloNome = AV15CategoriaTituloNome1;
                  HA40( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCategoriaTituloNomeDescription, "")), 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CategoriaTituloNome, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CATEGORIATITULONOME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21CategoriaTituloNome2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CategoriaTituloNome2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterCategoriaTituloNomeDescription = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterCategoriaTituloNomeDescription = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17CategoriaTituloNome = AV21CategoriaTituloNome2;
                     HA40( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCategoriaTituloNomeDescription, "")), 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CategoriaTituloNome, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CATEGORIATITULONOME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25CategoriaTituloNome3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CategoriaTituloNome3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterCategoriaTituloNomeDescription = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterCategoriaTituloNomeDescription = StringUtil.Format( "%1 (%2)", "Titulo Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17CategoriaTituloNome = AV25CategoriaTituloNome3;
                        HA40( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCategoriaTituloNomeDescription, "")), 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CategoriaTituloNome, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCategoriaTituloNome_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFCategoriaTituloNome_Sel, "<#Empty#>")==0)));
            AV36TFCategoriaTituloNome_Sel = (AV45TempBoolean ? "(Vazio)" : AV36TFCategoriaTituloNome_Sel);
            HA40( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFCategoriaTituloNome_Sel, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFCategoriaTituloNome_Sel = (AV45TempBoolean ? "<#Empty#>" : AV36TFCategoriaTituloNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCategoriaTituloNome)) )
            {
               HA40( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCategoriaTituloNome, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCategoriaTituloDescricao_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFCategoriaTituloDescricao_Sel, "<#Empty#>")==0)));
            AV38TFCategoriaTituloDescricao_Sel = (AV45TempBoolean ? "(Vazio)" : AV38TFCategoriaTituloDescricao_Sel);
            HA40( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCategoriaTituloDescricao_Sel, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFCategoriaTituloDescricao_Sel = (AV45TempBoolean ? "<#Empty#>" : AV38TFCategoriaTituloDescricao_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCategoriaTituloDescricao)) )
            {
               HA40( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCategoriaTituloDescricao, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV41TFCategoriaStatus_Sel) )
         {
            if ( AV41TFCategoriaStatus_Sel == 1 )
            {
               AV44FilterTFCategoriaStatus_SelValueDescription = "Marcado";
            }
            else if ( AV41TFCategoriaStatus_Sel == 2 )
            {
               AV44FilterTFCategoriaStatus_SelValueDescription = "Desmarcado";
            }
            HA40( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Status", 25, Gx_line+0, 196, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44FilterTFCategoriaStatus_SelValueDescription, "")), 196, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HA40( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HA40( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 283, Gx_line+10, 533, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Status", 537, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV63Categoriatitulowwds_1_filterfulltext = AV12FilterFullText;
         AV64Categoriatitulowwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV65Categoriatitulowwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV66Categoriatitulowwds_4_categoriatitulonome1 = AV15CategoriaTituloNome1;
         AV67Categoriatitulowwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV68Categoriatitulowwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV69Categoriatitulowwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV70Categoriatitulowwds_8_categoriatitulonome2 = AV21CategoriaTituloNome2;
         AV71Categoriatitulowwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV72Categoriatitulowwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV73Categoriatitulowwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV74Categoriatitulowwds_12_categoriatitulonome3 = AV25CategoriaTituloNome3;
         AV75Categoriatitulowwds_13_tfcategoriatitulonome = AV35TFCategoriaTituloNome;
         AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel = AV36TFCategoriaTituloNome_Sel;
         AV77Categoriatitulowwds_15_tfcategoriatitulodescricao = AV37TFCategoriaTituloDescricao;
         AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = AV38TFCategoriaTituloDescricao_Sel;
         AV79Categoriatitulowwds_17_tfcategoriastatus_sel = AV41TFCategoriaStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV63Categoriatitulowwds_1_filterfulltext ,
                                              AV64Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                              AV65Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                              AV66Categoriatitulowwds_4_categoriatitulonome1 ,
                                              AV67Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                              AV68Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                              AV69Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                              AV70Categoriatitulowwds_8_categoriatitulonome2 ,
                                              AV71Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                              AV72Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                              AV73Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                              AV74Categoriatitulowwds_12_categoriatitulonome3 ,
                                              AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                              AV75Categoriatitulowwds_13_tfcategoriatitulonome ,
                                              AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                              AV77Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                              AV79Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                              A427CategoriaTituloNome ,
                                              A428CategoriaTituloDescricao ,
                                              A431CategoriaStatus ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Categoriatitulowwds_1_filterfulltext), "%", "");
         lV63Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Categoriatitulowwds_1_filterfulltext), "%", "");
         lV63Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Categoriatitulowwds_1_filterfulltext), "%", "");
         lV63Categoriatitulowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Categoriatitulowwds_1_filterfulltext), "%", "");
         lV66Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV66Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV66Categoriatitulowwds_4_categoriatitulonome1 = StringUtil.Concat( StringUtil.RTrim( AV66Categoriatitulowwds_4_categoriatitulonome1), "%", "");
         lV70Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV70Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV70Categoriatitulowwds_8_categoriatitulonome2 = StringUtil.Concat( StringUtil.RTrim( AV70Categoriatitulowwds_8_categoriatitulonome2), "%", "");
         lV74Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV74Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV74Categoriatitulowwds_12_categoriatitulonome3 = StringUtil.Concat( StringUtil.RTrim( AV74Categoriatitulowwds_12_categoriatitulonome3), "%", "");
         lV75Categoriatitulowwds_13_tfcategoriatitulonome = StringUtil.Concat( StringUtil.RTrim( AV75Categoriatitulowwds_13_tfcategoriatitulonome), "%", "");
         lV77Categoriatitulowwds_15_tfcategoriatitulodescricao = StringUtil.Concat( StringUtil.RTrim( AV77Categoriatitulowwds_15_tfcategoriatitulodescricao), "%", "");
         /* Using cursor P00A42 */
         pr_default.execute(0, new Object[] {lV63Categoriatitulowwds_1_filterfulltext, lV63Categoriatitulowwds_1_filterfulltext, lV63Categoriatitulowwds_1_filterfulltext, lV63Categoriatitulowwds_1_filterfulltext, lV66Categoriatitulowwds_4_categoriatitulonome1, lV66Categoriatitulowwds_4_categoriatitulonome1, lV70Categoriatitulowwds_8_categoriatitulonome2, lV70Categoriatitulowwds_8_categoriatitulonome2, lV74Categoriatitulowwds_12_categoriatitulonome3, lV74Categoriatitulowwds_12_categoriatitulonome3, lV75Categoriatitulowwds_13_tfcategoriatitulonome, AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel, lV77Categoriatitulowwds_15_tfcategoriatitulodescricao, AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A431CategoriaStatus = P00A42_A431CategoriaStatus[0];
            n431CategoriaStatus = P00A42_n431CategoriaStatus[0];
            A428CategoriaTituloDescricao = P00A42_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = P00A42_n428CategoriaTituloDescricao[0];
            A427CategoriaTituloNome = P00A42_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = P00A42_n427CategoriaTituloNome[0];
            A426CategoriaTituloId = P00A42_A426CategoriaTituloId[0];
            AV28CategoriaStatusDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A431CategoriaStatus)), "true") == 0 )
            {
               AV28CategoriaStatusDescription = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A431CategoriaStatus)), "false") == 0 )
            {
               AV28CategoriaStatusDescription = "Inativo";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HA40( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A427CategoriaTituloNome, "")), 30, Gx_line+10, 279, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A428CategoriaTituloDescricao, "")), 283, Gx_line+10, 533, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28CategoriaStatusDescription, "")), 537, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("CategoriaTituloWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CategoriaTituloWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("CategoriaTituloWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV80GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULONOME") == 0 )
            {
               AV35TFCategoriaTituloNome = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULONOME_SEL") == 0 )
            {
               AV36TFCategoriaTituloNome_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO") == 0 )
            {
               AV37TFCategoriaTituloDescricao = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIATITULODESCRICAO_SEL") == 0 )
            {
               AV38TFCategoriaTituloDescricao_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCATEGORIASTATUS_SEL") == 0 )
            {
               AV41TFCategoriaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV80GXV1 = (int)(AV80GXV1+1);
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

      protected void HA40( bool bFoot ,
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
                  AV55PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV57Title = "";
         AV59Companyname = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15CategoriaTituloNome1 = "";
         AV16FilterCategoriaTituloNomeDescription = "";
         AV17CategoriaTituloNome = "";
         AV19DynamicFiltersSelector2 = "";
         AV21CategoriaTituloNome2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25CategoriaTituloNome3 = "";
         AV36TFCategoriaTituloNome_Sel = "";
         AV35TFCategoriaTituloNome = "";
         AV38TFCategoriaTituloDescricao_Sel = "";
         AV37TFCategoriaTituloDescricao = "";
         AV44FilterTFCategoriaStatus_SelValueDescription = "";
         AV63Categoriatitulowwds_1_filterfulltext = "";
         AV64Categoriatitulowwds_2_dynamicfiltersselector1 = "";
         AV66Categoriatitulowwds_4_categoriatitulonome1 = "";
         AV68Categoriatitulowwds_6_dynamicfiltersselector2 = "";
         AV70Categoriatitulowwds_8_categoriatitulonome2 = "";
         AV72Categoriatitulowwds_10_dynamicfiltersselector3 = "";
         AV74Categoriatitulowwds_12_categoriatitulonome3 = "";
         AV75Categoriatitulowwds_13_tfcategoriatitulonome = "";
         AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel = "";
         AV77Categoriatitulowwds_15_tfcategoriatitulodescricao = "";
         AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel = "";
         lV63Categoriatitulowwds_1_filterfulltext = "";
         lV66Categoriatitulowwds_4_categoriatitulonome1 = "";
         lV70Categoriatitulowwds_8_categoriatitulonome2 = "";
         lV74Categoriatitulowwds_12_categoriatitulonome3 = "";
         lV75Categoriatitulowwds_13_tfcategoriatitulonome = "";
         lV77Categoriatitulowwds_15_tfcategoriatitulodescricao = "";
         A427CategoriaTituloNome = "";
         A428CategoriaTituloDescricao = "";
         P00A42_A431CategoriaStatus = new bool[] {false} ;
         P00A42_n431CategoriaStatus = new bool[] {false} ;
         P00A42_A428CategoriaTituloDescricao = new string[] {""} ;
         P00A42_n428CategoriaTituloDescricao = new bool[] {false} ;
         P00A42_A427CategoriaTituloNome = new string[] {""} ;
         P00A42_n427CategoriaTituloNome = new bool[] {false} ;
         P00A42_A426CategoriaTituloId = new int[1] ;
         AV28CategoriaStatusDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriatitulowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00A42_A431CategoriaStatus, P00A42_n431CategoriaStatus, P00A42_A428CategoriaTituloDescricao, P00A42_n428CategoriaTituloDescricao, P00A42_A427CategoriaTituloNome, P00A42_n427CategoriaTituloNome, P00A42_A426CategoriaTituloId
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
      private short AV41TFCategoriaStatus_Sel ;
      private short AV65Categoriatitulowwds_3_dynamicfiltersoperator1 ;
      private short AV69Categoriatitulowwds_7_dynamicfiltersoperator2 ;
      private short AV73Categoriatitulowwds_11_dynamicfiltersoperator3 ;
      private short AV79Categoriatitulowwds_17_tfcategoriastatus_sel ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A426CategoriaTituloId ;
      private int AV80GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool AV67Categoriatitulowwds_5_dynamicfiltersenabled2 ;
      private bool AV71Categoriatitulowwds_9_dynamicfiltersenabled3 ;
      private bool A431CategoriaStatus ;
      private bool AV11OrderedDsc ;
      private bool n431CategoriaStatus ;
      private bool n428CategoriaTituloDescricao ;
      private bool n427CategoriaTituloNome ;
      private string AV59Companyname ;
      private string AV57Title ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15CategoriaTituloNome1 ;
      private string AV16FilterCategoriaTituloNomeDescription ;
      private string AV17CategoriaTituloNome ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21CategoriaTituloNome2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25CategoriaTituloNome3 ;
      private string AV36TFCategoriaTituloNome_Sel ;
      private string AV35TFCategoriaTituloNome ;
      private string AV38TFCategoriaTituloDescricao_Sel ;
      private string AV37TFCategoriaTituloDescricao ;
      private string AV44FilterTFCategoriaStatus_SelValueDescription ;
      private string AV63Categoriatitulowwds_1_filterfulltext ;
      private string AV64Categoriatitulowwds_2_dynamicfiltersselector1 ;
      private string AV66Categoriatitulowwds_4_categoriatitulonome1 ;
      private string AV68Categoriatitulowwds_6_dynamicfiltersselector2 ;
      private string AV70Categoriatitulowwds_8_categoriatitulonome2 ;
      private string AV72Categoriatitulowwds_10_dynamicfiltersselector3 ;
      private string AV74Categoriatitulowwds_12_categoriatitulonome3 ;
      private string AV75Categoriatitulowwds_13_tfcategoriatitulonome ;
      private string AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel ;
      private string AV77Categoriatitulowwds_15_tfcategoriatitulodescricao ;
      private string AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ;
      private string lV63Categoriatitulowwds_1_filterfulltext ;
      private string lV66Categoriatitulowwds_4_categoriatitulonome1 ;
      private string lV70Categoriatitulowwds_8_categoriatitulonome2 ;
      private string lV74Categoriatitulowwds_12_categoriatitulonome3 ;
      private string lV75Categoriatitulowwds_13_tfcategoriatitulonome ;
      private string lV77Categoriatitulowwds_15_tfcategoriatitulodescricao ;
      private string A427CategoriaTituloNome ;
      private string A428CategoriaTituloDescricao ;
      private string AV28CategoriaStatusDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P00A42_A431CategoriaStatus ;
      private bool[] P00A42_n431CategoriaStatus ;
      private string[] P00A42_A428CategoriaTituloDescricao ;
      private bool[] P00A42_n428CategoriaTituloDescricao ;
      private string[] P00A42_A427CategoriaTituloNome ;
      private bool[] P00A42_n427CategoriaTituloNome ;
      private int[] P00A42_A426CategoriaTituloId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class categoriatitulowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A42( IGxContext context ,
                                             string AV63Categoriatitulowwds_1_filterfulltext ,
                                             string AV64Categoriatitulowwds_2_dynamicfiltersselector1 ,
                                             short AV65Categoriatitulowwds_3_dynamicfiltersoperator1 ,
                                             string AV66Categoriatitulowwds_4_categoriatitulonome1 ,
                                             bool AV67Categoriatitulowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Categoriatitulowwds_6_dynamicfiltersselector2 ,
                                             short AV69Categoriatitulowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Categoriatitulowwds_8_categoriatitulonome2 ,
                                             bool AV71Categoriatitulowwds_9_dynamicfiltersenabled3 ,
                                             string AV72Categoriatitulowwds_10_dynamicfiltersselector3 ,
                                             short AV73Categoriatitulowwds_11_dynamicfiltersoperator3 ,
                                             string AV74Categoriatitulowwds_12_categoriatitulonome3 ,
                                             string AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel ,
                                             string AV75Categoriatitulowwds_13_tfcategoriatitulonome ,
                                             string AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel ,
                                             string AV77Categoriatitulowwds_15_tfcategoriatitulodescricao ,
                                             short AV79Categoriatitulowwds_17_tfcategoriastatus_sel ,
                                             string A427CategoriaTituloNome ,
                                             string A428CategoriaTituloDescricao ,
                                             bool A431CategoriaStatus ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT CategoriaStatus, CategoriaTituloDescricao, CategoriaTituloNome, CategoriaTituloId FROM CategoriaTitulo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Categoriatitulowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CategoriaTituloNome like '%' || :lV63Categoriatitulowwds_1_filterfulltext) or ( CategoriaTituloDescricao like '%' || :lV63Categoriatitulowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV63Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV63Categoriatitulowwds_1_filterfulltext) and CategoriaStatus = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV65Categoriatitulowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV66Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Categoriatitulowwds_2_dynamicfiltersselector1, "CATEGORIATITULONOME") == 0 ) && ( AV65Categoriatitulowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Categoriatitulowwds_4_categoriatitulonome1)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV66Categoriatitulowwds_4_categoriatitulonome1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV67Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV69Categoriatitulowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV70Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV67Categoriatitulowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Categoriatitulowwds_6_dynamicfiltersselector2, "CATEGORIATITULONOME") == 0 ) && ( AV69Categoriatitulowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Categoriatitulowwds_8_categoriatitulonome2)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV70Categoriatitulowwds_8_categoriatitulonome2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV71Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV73Categoriatitulowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV74Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV71Categoriatitulowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Categoriatitulowwds_10_dynamicfiltersselector3, "CATEGORIATITULONOME") == 0 ) && ( AV73Categoriatitulowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Categoriatitulowwds_12_categoriatitulonome3)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like '%' || :lV74Categoriatitulowwds_12_categoriatitulonome3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Categoriatitulowwds_13_tfcategoriatitulonome)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome like :lV75Categoriatitulowwds_13_tfcategoriatitulonome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel)) && ! ( StringUtil.StrCmp(AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome = ( :AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloNome IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Categoriatitulowwds_15_tfcategoriatitulodescricao)) ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao like :lV77Categoriatitulowwds_15_tfcategoriatitulodescricao)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel)) && ! ( StringUtil.StrCmp(AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao = ( :AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CategoriaTituloDescricao IS NULL or (char_length(trim(trailing ' ' from CategoriaTituloDescricao))=0))");
         }
         if ( AV79Categoriatitulowwds_17_tfcategoriastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = TRUE)");
         }
         if ( AV79Categoriatitulowwds_17_tfcategoriastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CategoriaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY CategoriaTituloNome";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CategoriaTituloNome DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY CategoriaTituloDescricao";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CategoriaTituloDescricao DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY CategoriaStatus";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CategoriaStatus DESC";
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
                     return conditional_P00A42(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00A42;
          prmP00A42 = new Object[] {
          new ParDef("lV63Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Categoriatitulowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV66Categoriatitulowwds_4_categoriatitulonome1",GXType.VarChar,60,0) ,
          new ParDef("lV70Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV70Categoriatitulowwds_8_categoriatitulonome2",GXType.VarChar,60,0) ,
          new ParDef("lV74Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV74Categoriatitulowwds_12_categoriatitulonome3",GXType.VarChar,60,0) ,
          new ParDef("lV75Categoriatitulowwds_13_tfcategoriatitulonome",GXType.VarChar,60,0) ,
          new ParDef("AV76Categoriatitulowwds_14_tfcategoriatitulonome_sel",GXType.VarChar,60,0) ,
          new ParDef("lV77Categoriatitulowwds_15_tfcategoriatitulodescricao",GXType.VarChar,150,0) ,
          new ParDef("AV78Categoriatitulowwds_16_tfcategoriatitulodescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A42,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
