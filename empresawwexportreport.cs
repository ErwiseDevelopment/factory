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
   public class empresawwexportreport : GXWebProcedure
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

      public empresawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public empresawwexportreport( IGxContext context )
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
         setOutputFileName("EmpresaWWExportReport");
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
            AV48Title = "Lista de Empresa";
            GXt_char1 = AV53Companyname;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV53Companyname = GXt_char1;
            GXt_char1 = AV47Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV47Phone = GXt_char1;
            GXt_char1 = AV45Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV45Mail = GXt_char1;
            GXt_char1 = AV49Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV49Website = GXt_char1;
            GXt_char1 = AV38AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV38AddressLine1 = GXt_char1;
            GXt_char1 = AV39AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV39AddressLine2 = GXt_char1;
            GXt_char1 = AV40AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV40AddressLine3 = GXt_char1;
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
            H7H0( true, 0) ;
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
            H7H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "EMPRESANOMEFANTASIA") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15EmpresaNomeFantasia1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15EmpresaNomeFantasia1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterEmpresaNomeFantasiaDescription = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterEmpresaNomeFantasiaDescription = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Contém", "", "", "", "", "", "", "");
                  }
                  AV17EmpresaNomeFantasia = AV15EmpresaNomeFantasia1;
                  H7H0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEmpresaNomeFantasiaDescription, "")), 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpresaNomeFantasia, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "EMPRESANOMEFANTASIA") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21EmpresaNomeFantasia2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpresaNomeFantasia2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterEmpresaNomeFantasiaDescription = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterEmpresaNomeFantasiaDescription = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Contém", "", "", "", "", "", "", "");
                     }
                     AV17EmpresaNomeFantasia = AV21EmpresaNomeFantasia2;
                     H7H0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEmpresaNomeFantasiaDescription, "")), 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpresaNomeFantasia, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "EMPRESANOMEFANTASIA") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25EmpresaNomeFantasia3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EmpresaNomeFantasia3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterEmpresaNomeFantasiaDescription = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterEmpresaNomeFantasiaDescription = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Contém", "", "", "", "", "", "", "");
                        }
                        AV17EmpresaNomeFantasia = AV25EmpresaNomeFantasia3;
                        H7H0( false, 20) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterEmpresaNomeFantasiaDescription, "")), 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpresaNomeFantasia, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEmpresaNomeFantasia_Sel)) )
         {
            AV37TempBoolean = (bool)(((StringUtil.StrCmp(AV32TFEmpresaNomeFantasia_Sel, "<#Empty#>")==0)));
            AV32TFEmpresaNomeFantasia_Sel = (AV37TempBoolean ? "(Vazio)" : AV32TFEmpresaNomeFantasia_Sel);
            H7H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome fantasia", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFEmpresaNomeFantasia_Sel, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV32TFEmpresaNomeFantasia_Sel = (AV37TempBoolean ? "<#Empty#>" : AV32TFEmpresaNomeFantasia_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFEmpresaNomeFantasia)) )
            {
               H7H0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome fantasia", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFEmpresaNomeFantasia, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEmpresaRazaoSocial_Sel)) )
         {
            AV37TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFEmpresaRazaoSocial_Sel, "<#Empty#>")==0)));
            AV34TFEmpresaRazaoSocial_Sel = (AV37TempBoolean ? "(Vazio)" : AV34TFEmpresaRazaoSocial_Sel);
            H7H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Razão social", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFEmpresaRazaoSocial_Sel, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFEmpresaRazaoSocial_Sel = (AV37TempBoolean ? "<#Empty#>" : AV34TFEmpresaRazaoSocial_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEmpresaRazaoSocial)) )
            {
               H7H0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Razão social", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFEmpresaRazaoSocial, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmpresaCNPJ_Sel)) )
         {
            AV37TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFEmpresaCNPJ_Sel, "<#Empty#>")==0)));
            AV36TFEmpresaCNPJ_Sel = (AV37TempBoolean ? "(Vazio)" : AV36TFEmpresaCNPJ_Sel);
            H7H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("CNPJ", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFEmpresaCNPJ_Sel, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFEmpresaCNPJ_Sel = (AV37TempBoolean ? "<#Empty#>" : AV36TFEmpresaCNPJ_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEmpresaCNPJ)) )
            {
               H7H0( false, 20) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CNPJ", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFEmpresaCNPJ, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV51TFEmpresaSede_Sel) )
         {
            if ( AV51TFEmpresaSede_Sel == 1 )
            {
               AV52FilterTFEmpresaSede_SelValueDescription = "Marcado";
            }
            else if ( AV51TFEmpresaSede_Sel == 2 )
            {
               AV52FilterTFEmpresaSede_SelValueDescription = "Desmarcado";
            }
            H7H0( false, 20) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sede", 25, Gx_line+0, 210, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52FilterTFEmpresaSede_SelValueDescription, "")), 210, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7H0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7H0( false, 36) ;
         getPrinter().GxAttris("Verdana", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome fantasia", 30, Gx_line+10, 242, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Razão social", 246, Gx_line+10, 458, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("CNPJ", 462, Gx_line+10, 569, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Sede", 573, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV57Empresawwds_1_filterfulltext = AV12FilterFullText;
         AV58Empresawwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV59Empresawwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV60Empresawwds_4_empresanomefantasia1 = AV15EmpresaNomeFantasia1;
         AV61Empresawwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV62Empresawwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV63Empresawwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV64Empresawwds_8_empresanomefantasia2 = AV21EmpresaNomeFantasia2;
         AV65Empresawwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV66Empresawwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV67Empresawwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV68Empresawwds_12_empresanomefantasia3 = AV25EmpresaNomeFantasia3;
         AV69Empresawwds_13_tfempresanomefantasia = AV31TFEmpresaNomeFantasia;
         AV70Empresawwds_14_tfempresanomefantasia_sel = AV32TFEmpresaNomeFantasia_Sel;
         AV71Empresawwds_15_tfempresarazaosocial = AV33TFEmpresaRazaoSocial;
         AV72Empresawwds_16_tfempresarazaosocial_sel = AV34TFEmpresaRazaoSocial_Sel;
         AV73Empresawwds_17_tfempresacnpj = AV35TFEmpresaCNPJ;
         AV74Empresawwds_18_tfempresacnpj_sel = AV36TFEmpresaCNPJ_Sel;
         AV75Empresawwds_19_tfempresasede_sel = AV51TFEmpresaSede_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Empresawwds_1_filterfulltext ,
                                              AV58Empresawwds_2_dynamicfiltersselector1 ,
                                              AV59Empresawwds_3_dynamicfiltersoperator1 ,
                                              AV60Empresawwds_4_empresanomefantasia1 ,
                                              AV61Empresawwds_5_dynamicfiltersenabled2 ,
                                              AV62Empresawwds_6_dynamicfiltersselector2 ,
                                              AV63Empresawwds_7_dynamicfiltersoperator2 ,
                                              AV64Empresawwds_8_empresanomefantasia2 ,
                                              AV65Empresawwds_9_dynamicfiltersenabled3 ,
                                              AV66Empresawwds_10_dynamicfiltersselector3 ,
                                              AV67Empresawwds_11_dynamicfiltersoperator3 ,
                                              AV68Empresawwds_12_empresanomefantasia3 ,
                                              AV70Empresawwds_14_tfempresanomefantasia_sel ,
                                              AV69Empresawwds_13_tfempresanomefantasia ,
                                              AV72Empresawwds_16_tfempresarazaosocial_sel ,
                                              AV71Empresawwds_15_tfempresarazaosocial ,
                                              AV74Empresawwds_18_tfempresacnpj_sel ,
                                              AV73Empresawwds_17_tfempresacnpj ,
                                              AV75Empresawwds_19_tfempresasede_sel ,
                                              A250EmpresaNomeFantasia ,
                                              A251EmpresaRazaoSocial ,
                                              A252EmpresaCNPJ ,
                                              A253EmpresaSede ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Empresawwds_1_filterfulltext), "%", "");
         lV57Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Empresawwds_1_filterfulltext), "%", "");
         lV57Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Empresawwds_1_filterfulltext), "%", "");
         lV57Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Empresawwds_1_filterfulltext), "%", "");
         lV57Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Empresawwds_1_filterfulltext), "%", "");
         lV60Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_4_empresanomefantasia1), "%", "");
         lV60Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV60Empresawwds_4_empresanomefantasia1), "%", "");
         lV64Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_8_empresanomefantasia2), "%", "");
         lV64Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV64Empresawwds_8_empresanomefantasia2), "%", "");
         lV68Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV68Empresawwds_12_empresanomefantasia3), "%", "");
         lV68Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV68Empresawwds_12_empresanomefantasia3), "%", "");
         lV69Empresawwds_13_tfempresanomefantasia = StringUtil.Concat( StringUtil.RTrim( AV69Empresawwds_13_tfempresanomefantasia), "%", "");
         lV71Empresawwds_15_tfempresarazaosocial = StringUtil.Concat( StringUtil.RTrim( AV71Empresawwds_15_tfempresarazaosocial), "%", "");
         lV73Empresawwds_17_tfempresacnpj = StringUtil.Concat( StringUtil.RTrim( AV73Empresawwds_17_tfempresacnpj), "%", "");
         /* Using cursor P007H2 */
         pr_default.execute(0, new Object[] {lV57Empresawwds_1_filterfulltext, lV57Empresawwds_1_filterfulltext, lV57Empresawwds_1_filterfulltext, lV57Empresawwds_1_filterfulltext, lV57Empresawwds_1_filterfulltext, lV60Empresawwds_4_empresanomefantasia1, lV60Empresawwds_4_empresanomefantasia1, lV64Empresawwds_8_empresanomefantasia2, lV64Empresawwds_8_empresanomefantasia2, lV68Empresawwds_12_empresanomefantasia3, lV68Empresawwds_12_empresanomefantasia3, lV69Empresawwds_13_tfempresanomefantasia, AV70Empresawwds_14_tfempresanomefantasia_sel, lV71Empresawwds_15_tfempresarazaosocial, AV72Empresawwds_16_tfempresarazaosocial_sel, lV73Empresawwds_17_tfempresacnpj, AV74Empresawwds_18_tfempresacnpj_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A253EmpresaSede = P007H2_A253EmpresaSede[0];
            n253EmpresaSede = P007H2_n253EmpresaSede[0];
            A252EmpresaCNPJ = P007H2_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = P007H2_n252EmpresaCNPJ[0];
            A251EmpresaRazaoSocial = P007H2_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = P007H2_n251EmpresaRazaoSocial[0];
            A250EmpresaNomeFantasia = P007H2_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = P007H2_n250EmpresaNomeFantasia[0];
            A249EmpresaId = P007H2_A249EmpresaId[0];
            AV50EmpresaSedeDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A253EmpresaSede)), "true") == 0 )
            {
               AV50EmpresaSedeDescription = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A253EmpresaSede)), "false") == 0 )
            {
               AV50EmpresaSedeDescription = "Não";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7H0( false, 36) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A250EmpresaNomeFantasia, "")), 30, Gx_line+10, 242, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A251EmpresaRazaoSocial, "")), 246, Gx_line+10, 458, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A252EmpresaCNPJ, "")), 462, Gx_line+10, 569, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50EmpresaSedeDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("EmpresaWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EmpresaWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("EmpresaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESANOMEFANTASIA") == 0 )
            {
               AV31TFEmpresaNomeFantasia = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESANOMEFANTASIA_SEL") == 0 )
            {
               AV32TFEmpresaNomeFantasia_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESARAZAOSOCIAL") == 0 )
            {
               AV33TFEmpresaRazaoSocial = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESARAZAOSOCIAL_SEL") == 0 )
            {
               AV34TFEmpresaRazaoSocial_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESACNPJ") == 0 )
            {
               AV35TFEmpresaCNPJ = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESACNPJ_SEL") == 0 )
            {
               AV36TFEmpresaCNPJ_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFEMPRESASEDE_SEL") == 0 )
            {
               AV51TFEmpresaSede_Sel = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV76GXV1 = (int)(AV76GXV1+1);
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

      protected void H7H0( bool bFoot ,
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
                  AV46PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV43DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Title, "")), 30, Gx_line+45, 283, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Website, "")), 283, Gx_line+62, 536, Gx_line+79, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+79, 2, 0, 0, 0) ;
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
         AV48Title = "";
         AV53Companyname = "";
         AV47Phone = "";
         AV45Mail = "";
         AV49Website = "";
         AV38AddressLine1 = "";
         AV39AddressLine2 = "";
         AV40AddressLine3 = "";
         GXt_char1 = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15EmpresaNomeFantasia1 = "";
         AV16FilterEmpresaNomeFantasiaDescription = "";
         AV17EmpresaNomeFantasia = "";
         AV19DynamicFiltersSelector2 = "";
         AV21EmpresaNomeFantasia2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25EmpresaNomeFantasia3 = "";
         AV32TFEmpresaNomeFantasia_Sel = "";
         AV31TFEmpresaNomeFantasia = "";
         AV34TFEmpresaRazaoSocial_Sel = "";
         AV33TFEmpresaRazaoSocial = "";
         AV36TFEmpresaCNPJ_Sel = "";
         AV35TFEmpresaCNPJ = "";
         AV52FilterTFEmpresaSede_SelValueDescription = "";
         AV57Empresawwds_1_filterfulltext = "";
         AV58Empresawwds_2_dynamicfiltersselector1 = "";
         AV60Empresawwds_4_empresanomefantasia1 = "";
         AV62Empresawwds_6_dynamicfiltersselector2 = "";
         AV64Empresawwds_8_empresanomefantasia2 = "";
         AV66Empresawwds_10_dynamicfiltersselector3 = "";
         AV68Empresawwds_12_empresanomefantasia3 = "";
         AV69Empresawwds_13_tfempresanomefantasia = "";
         AV70Empresawwds_14_tfempresanomefantasia_sel = "";
         AV71Empresawwds_15_tfempresarazaosocial = "";
         AV72Empresawwds_16_tfempresarazaosocial_sel = "";
         AV73Empresawwds_17_tfempresacnpj = "";
         AV74Empresawwds_18_tfempresacnpj_sel = "";
         lV57Empresawwds_1_filterfulltext = "";
         lV60Empresawwds_4_empresanomefantasia1 = "";
         lV64Empresawwds_8_empresanomefantasia2 = "";
         lV68Empresawwds_12_empresanomefantasia3 = "";
         lV69Empresawwds_13_tfempresanomefantasia = "";
         lV71Empresawwds_15_tfempresarazaosocial = "";
         lV73Empresawwds_17_tfempresacnpj = "";
         A250EmpresaNomeFantasia = "";
         A251EmpresaRazaoSocial = "";
         A252EmpresaCNPJ = "";
         P007H2_A253EmpresaSede = new bool[] {false} ;
         P007H2_n253EmpresaSede = new bool[] {false} ;
         P007H2_A252EmpresaCNPJ = new string[] {""} ;
         P007H2_n252EmpresaCNPJ = new bool[] {false} ;
         P007H2_A251EmpresaRazaoSocial = new string[] {""} ;
         P007H2_n251EmpresaRazaoSocial = new bool[] {false} ;
         P007H2_A250EmpresaNomeFantasia = new string[] {""} ;
         P007H2_n250EmpresaNomeFantasia = new bool[] {false} ;
         P007H2_A249EmpresaId = new int[1] ;
         AV50EmpresaSedeDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46PageInfo = "";
         AV43DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV41AppName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empresawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007H2_A253EmpresaSede, P007H2_n253EmpresaSede, P007H2_A252EmpresaCNPJ, P007H2_n252EmpresaCNPJ, P007H2_A251EmpresaRazaoSocial, P007H2_n251EmpresaRazaoSocial, P007H2_A250EmpresaNomeFantasia, P007H2_n250EmpresaNomeFantasia, P007H2_A249EmpresaId
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
      private short AV51TFEmpresaSede_Sel ;
      private short AV59Empresawwds_3_dynamicfiltersoperator1 ;
      private short AV63Empresawwds_7_dynamicfiltersoperator2 ;
      private short AV67Empresawwds_11_dynamicfiltersoperator3 ;
      private short AV75Empresawwds_19_tfempresasede_sel ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A249EmpresaId ;
      private int AV76GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV37TempBoolean ;
      private bool AV61Empresawwds_5_dynamicfiltersenabled2 ;
      private bool AV65Empresawwds_9_dynamicfiltersenabled3 ;
      private bool A253EmpresaSede ;
      private bool AV11OrderedDsc ;
      private bool n253EmpresaSede ;
      private bool n252EmpresaCNPJ ;
      private bool n251EmpresaRazaoSocial ;
      private bool n250EmpresaNomeFantasia ;
      private string AV53Companyname ;
      private string AV48Title ;
      private string AV47Phone ;
      private string AV45Mail ;
      private string AV49Website ;
      private string AV38AddressLine1 ;
      private string AV39AddressLine2 ;
      private string AV40AddressLine3 ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV15EmpresaNomeFantasia1 ;
      private string AV16FilterEmpresaNomeFantasiaDescription ;
      private string AV17EmpresaNomeFantasia ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21EmpresaNomeFantasia2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25EmpresaNomeFantasia3 ;
      private string AV32TFEmpresaNomeFantasia_Sel ;
      private string AV31TFEmpresaNomeFantasia ;
      private string AV34TFEmpresaRazaoSocial_Sel ;
      private string AV33TFEmpresaRazaoSocial ;
      private string AV36TFEmpresaCNPJ_Sel ;
      private string AV35TFEmpresaCNPJ ;
      private string AV52FilterTFEmpresaSede_SelValueDescription ;
      private string AV57Empresawwds_1_filterfulltext ;
      private string AV58Empresawwds_2_dynamicfiltersselector1 ;
      private string AV60Empresawwds_4_empresanomefantasia1 ;
      private string AV62Empresawwds_6_dynamicfiltersselector2 ;
      private string AV64Empresawwds_8_empresanomefantasia2 ;
      private string AV66Empresawwds_10_dynamicfiltersselector3 ;
      private string AV68Empresawwds_12_empresanomefantasia3 ;
      private string AV69Empresawwds_13_tfempresanomefantasia ;
      private string AV70Empresawwds_14_tfempresanomefantasia_sel ;
      private string AV71Empresawwds_15_tfempresarazaosocial ;
      private string AV72Empresawwds_16_tfempresarazaosocial_sel ;
      private string AV73Empresawwds_17_tfempresacnpj ;
      private string AV74Empresawwds_18_tfempresacnpj_sel ;
      private string lV57Empresawwds_1_filterfulltext ;
      private string lV60Empresawwds_4_empresanomefantasia1 ;
      private string lV64Empresawwds_8_empresanomefantasia2 ;
      private string lV68Empresawwds_12_empresanomefantasia3 ;
      private string lV69Empresawwds_13_tfempresanomefantasia ;
      private string lV71Empresawwds_15_tfempresarazaosocial ;
      private string lV73Empresawwds_17_tfempresacnpj ;
      private string A250EmpresaNomeFantasia ;
      private string A251EmpresaRazaoSocial ;
      private string A252EmpresaCNPJ ;
      private string AV50EmpresaSedeDescription ;
      private string AV46PageInfo ;
      private string AV43DateInfo ;
      private string AV41AppName ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P007H2_A253EmpresaSede ;
      private bool[] P007H2_n253EmpresaSede ;
      private string[] P007H2_A252EmpresaCNPJ ;
      private bool[] P007H2_n252EmpresaCNPJ ;
      private string[] P007H2_A251EmpresaRazaoSocial ;
      private bool[] P007H2_n251EmpresaRazaoSocial ;
      private string[] P007H2_A250EmpresaNomeFantasia ;
      private bool[] P007H2_n250EmpresaNomeFantasia ;
      private int[] P007H2_A249EmpresaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class empresawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007H2( IGxContext context ,
                                             string AV57Empresawwds_1_filterfulltext ,
                                             string AV58Empresawwds_2_dynamicfiltersselector1 ,
                                             short AV59Empresawwds_3_dynamicfiltersoperator1 ,
                                             string AV60Empresawwds_4_empresanomefantasia1 ,
                                             bool AV61Empresawwds_5_dynamicfiltersenabled2 ,
                                             string AV62Empresawwds_6_dynamicfiltersselector2 ,
                                             short AV63Empresawwds_7_dynamicfiltersoperator2 ,
                                             string AV64Empresawwds_8_empresanomefantasia2 ,
                                             bool AV65Empresawwds_9_dynamicfiltersenabled3 ,
                                             string AV66Empresawwds_10_dynamicfiltersselector3 ,
                                             short AV67Empresawwds_11_dynamicfiltersoperator3 ,
                                             string AV68Empresawwds_12_empresanomefantasia3 ,
                                             string AV70Empresawwds_14_tfempresanomefantasia_sel ,
                                             string AV69Empresawwds_13_tfempresanomefantasia ,
                                             string AV72Empresawwds_16_tfempresarazaosocial_sel ,
                                             string AV71Empresawwds_15_tfempresarazaosocial ,
                                             string AV74Empresawwds_18_tfempresacnpj_sel ,
                                             string AV73Empresawwds_17_tfempresacnpj ,
                                             short AV75Empresawwds_19_tfempresasede_sel ,
                                             string A250EmpresaNomeFantasia ,
                                             string A251EmpresaRazaoSocial ,
                                             string A252EmpresaCNPJ ,
                                             bool A253EmpresaSede ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[17];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT EmpresaSede, EmpresaCNPJ, EmpresaRazaoSocial, EmpresaNomeFantasia, EmpresaId FROM Empresa";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Empresawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmpresaNomeFantasia like '%' || :lV57Empresawwds_1_filterfulltext) or ( EmpresaRazaoSocial like '%' || :lV57Empresawwds_1_filterfulltext) or ( EmpresaCNPJ like '%' || :lV57Empresawwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV57Empresawwds_1_filterfulltext) and EmpresaSede = TRUE) or ( 'não' like '%' || LOWER(:lV57Empresawwds_1_filterfulltext) and EmpresaSede = FALSE))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV60Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV59Empresawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV60Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV64Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV61Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV63Empresawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV64Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV65Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV67Empresawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV68Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV65Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV67Empresawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV68Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_14_tfempresanomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Empresawwds_13_tfempresanomefantasia)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV69Empresawwds_13_tfempresanomefantasia)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_14_tfempresanomefantasia_sel)) && ! ( StringUtil.StrCmp(AV70Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia = ( :AV70Empresawwds_14_tfempresanomefantasia_sel))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV70Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia IS NULL or (char_length(trim(trailing ' ' from EmpresaNomeFantasia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Empresawwds_16_tfempresarazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Empresawwds_15_tfempresarazaosocial)) ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial like :lV71Empresawwds_15_tfempresarazaosocial)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Empresawwds_16_tfempresarazaosocial_sel)) && ! ( StringUtil.StrCmp(AV72Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial = ( :AV72Empresawwds_16_tfempresarazaosocial_sel))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV72Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial IS NULL or (char_length(trim(trailing ' ' from EmpresaRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Empresawwds_18_tfempresacnpj_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Empresawwds_17_tfempresacnpj)) ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ like :lV73Empresawwds_17_tfempresacnpj)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Empresawwds_18_tfempresacnpj_sel)) && ! ( StringUtil.StrCmp(AV74Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ = ( :AV74Empresawwds_18_tfempresacnpj_sel))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV74Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ IS NULL or (char_length(trim(trailing ' ' from EmpresaCNPJ))=0))");
         }
         if ( AV75Empresawwds_19_tfempresasede_sel == 1 )
         {
            AddWhere(sWhereString, "(EmpresaSede = TRUE)");
         }
         if ( AV75Empresawwds_19_tfempresasede_sel == 2 )
         {
            AddWhere(sWhereString, "(EmpresaSede = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaNomeFantasia";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaNomeFantasia DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaRazaoSocial";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaRazaoSocial DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaCNPJ";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaCNPJ DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaSede";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaSede DESC";
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
                     return conditional_P007H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP007H2;
          prmP007H2 = new Object[] {
          new ParDef("lV57Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV60Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV64Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV68Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV68Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV69Empresawwds_13_tfempresanomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV70Empresawwds_14_tfempresanomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV71Empresawwds_15_tfempresarazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV72Empresawwds_16_tfempresarazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV73Empresawwds_17_tfempresacnpj",GXType.VarChar,14,0) ,
          new ParDef("AV74Empresawwds_18_tfempresacnpj_sel",GXType.VarChar,14,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
